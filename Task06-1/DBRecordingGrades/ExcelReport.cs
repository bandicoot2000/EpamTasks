using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Dynamic;

namespace DBRecordingGrades
{
    /// <summary>
    /// Report DB in Excel.
    /// </summary>
    public static class ExcelReport
    {
        private static AssessmentForms[] assessmentForms;
        private static Subjects[] subjects;
        private static SessionTypes[] sessionTypes;
        private static Groups[] groups;
        private static Students[] students;
        private static PassSubjects[] passSubjects;
        private static Grades[] grades;

        private static Application excel;
        private static Workbook workbook;
        private static Worksheet worksheet;


        private static void InitializeDB(string connection)
        {
            ConnectionFactory connectionFactory = ConnectionFactory.GetСonnectionFactory(DataBaseType.MSSQL, connection);

            assessmentForms = connectionFactory.GetAssessmentForms().GetAllAssessmentForms();
            subjects = connectionFactory.GetSubjects().GetAllSubjects();
            sessionTypes = connectionFactory.GetSessionTypes().GetAllSessionTypes();
            groups = connectionFactory.GetGroups().GetAllGroups();
            students = connectionFactory.GetStudents().GetAllStudents();
            passSubjects = connectionFactory.GetPassSubjects().GetAllPassSubjects();
            grades = connectionFactory.GetGrades().GetAllGrades();
        }

        private static void InitializeExcel(int countSheet)
        {
            excel = new Application();
            excel.SheetsInNewWorkbook = countSheet;
            workbook = excel.Workbooks.Add(Type.Missing);
            excel.DisplayAlerts = false;
        }

        private static void DisposeDB()
        {
            assessmentForms = null;
            subjects = null;
            sessionTypes = null;
            groups = null;
            students = null;
            passSubjects = null;
            grades = null;
        }

        private static void DisposeExcel()
        {
            workbook.Close();
            excel = null;
            workbook = null;
            worksheet = null;
        }

        /// <summary>
        /// Report all DB in Excel.
        /// </summary>
        /// <param name="connection">Connection DB.</param>
        /// <param name="sortType">Sorting type.</param>
        /// <returns>Successful completion method.</returns>
        public static bool SessionsReport(string connection, SortType sortType)
        {

            InitializeDB(connection);
            InitializeExcel(sessionTypes.Length);

            int pos;

            for (int i = 0; i < sessionTypes.Length; i++)
            {
                worksheet = (Worksheet)excel.Worksheets.get_Item(i+1);
                worksheet.Name = sessionTypes[i].SessionTypeName;
                pos = 1;
                worksheet.Cells[pos, 1] = "Full Name";
                worksheet.Columns[1].ColumnWidth = 30;

                for (int j = 0; j < subjects.Length; j++)
                {
                    worksheet.Cells[pos, j + 2] = subjects[j].SubjectName;
                    worksheet.Columns[j + 2].ColumnWidth = 20;
                }

                pos++;

                for (int j = 0; j < groups.Length; j++)
                {

                    worksheet.Cells[pos, 1] = groups[j].GroupName;

                    IEnumerable<PassSubjects> passSubjectsGroup = passSubjects
                        .Where(passSubject => passSubject.GroupId == groups[j].GroupId && passSubject.SessionTypeId == sessionTypes[i].SessionTypeId);
                    

                    for (int k = 0; k < subjects.Length; k++)
                    {
                        int g = 0;
                        while (g < passSubjectsGroup.Count() && passSubjectsGroup.ElementAt(g).SubjectId != subjects[k].SubjectId) g++;
                        if (g == passSubjectsGroup.Count()) worksheet.Cells[pos, k + 2] = "-";
                        else worksheet.Cells[pos, k + 2] = GetAssessmentFormName(passSubjectsGroup.ElementAt(g).AssessmentFormId, assessmentForms);
                    }

                    pos++;

                    IEnumerable<Students> studentsGroup = SortStudentsBy(students.Where(student => student.GroupId == groups[j].GroupId), sortType);

                    foreach (Students student in studentsGroup)
                    {
                        worksheet.Cells[pos, 1] = GetFullName(student);

                        for (int k = 0; k < subjects.Length; k++)
                        {
                            int g = 0;
                            while (g < passSubjectsGroup.Count() && passSubjectsGroup.ElementAt(g).SubjectId != subjects[k].SubjectId) g++;
                            if (g == passSubjectsGroup.Count()) worksheet.Cells[pos, k + 2] = "-";
                            else
                            {
                                Grades grade = grades.Where(grad => grad.PassSubjectId == passSubjectsGroup.ElementAt(g).PassSubjectId && grad.StudentId == student.StudentId).FirstOrDefault();
                                if(grade == null) worksheet.Cells[pos, k + 2] = "-";
                                else worksheet.Cells[pos, k + 2] = grade.Grade;
                            }
                        }

                        pos++;
                    }

                }

            }

            excel.Application.ActiveWorkbook.SaveAs(Directory.GetCurrentDirectory() + "\\SessionsReport.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            DisposeDB();
            DisposeExcel();

            return true;
        }

        private static IEnumerable<Students> SortStudentsBy(IEnumerable<Students> students, SortType sort)
        {
            switch (sort)
            {
                case SortType.Name:
                    return students.OrderBy(stydent => stydent.FirstName);
                case SortType.Gender:
                    return students.OrderBy(stydent => stydent.Gender);
                case SortType.Birthday:
                    return students.OrderBy(stydent => stydent.Birthday);
                default:
                    throw new Exception("SortType not found!");
            }
        }

        private static string GetAssessmentFormName(int index, AssessmentForms[] assessmentForms)
        {
            for (int i = 0; i < assessmentForms.Length; i++)
            {
                if (assessmentForms[i].AssessmentFormId == index) return assessmentForms[i].AssessmentFormName;
            }
            throw new Exception("Index error. index = " + index + " count = " + assessmentForms.Length);
        }

        private static string GetFullName(Students student)
        {
            return student.SecondName + " " + student.FirstName + " " + student.MiddleName;
        }

        private static Students GetStudentsByIndex(int index, Students[] students)
        {
            foreach (var student in students)
            {
                if (student.StudentId == index) return student;
            }
            throw new Exception("Index not found!");
        }

        private static IEnumerable<Grades> GradesStudentGroup(IEnumerator<Grades> gradesStudent, int index)
        {
            List<Grades> grades = new List<Grades>();
            while (gradesStudent.MoveNext())
            {
                if (gradesStudent.Current.PassSubjectId == index) grades.Add(gradesStudent.Current);
            }
            return grades;
        }

        /// <summary>
        /// Return Studets to be expelled.
        /// </summary>
        /// <param name="connection">Connection.</param>
        /// <returns>Students to be expelled.</returns>
        public static Students[] StudentsToBeExpelled(string connection)
        {
            InitializeDB(connection);

            IEnumerable<IGrouping<int, Grades>> students = grades.Where(grade => grade.Grade < 4).GroupBy(grade => grade.StudentId);

            List<Students> studentsExpelled = new List<Students>();

            foreach (IGrouping<int, Grades> student in students)
            {
                if (student.Count() > 2) studentsExpelled.Add(GetStudentsByIndex(student.Key, ExcelReport.students));
            }

            DisposeDB();

            return studentsExpelled.ToArray();
        }

        /// <summary>
        /// Create Summary table.
        /// </summary>
        /// <param name="connection">Connection.</param>
        /// <returns>Successful completion method.</returns>
        public static bool GetSummaryTable(string connection)
        {
            InitializeDB(connection);
            InitializeExcel(sessionTypes.Length);


            for (int i = 0; i < sessionTypes.Length; i++)
            {
                worksheet = (Worksheet)excel.Worksheets.get_Item(i + 1);
                worksheet.Name = sessionTypes[i].SessionTypeName;

                worksheet.Cells[1, 1] = "Grop Name";
                worksheet.Cells[1, 2] = "Min";
                worksheet.Cells[1, 3] = "Max";
                worksheet.Cells[1, 4] = "Average";

                for (int j = 0; j < groups.Length; j++)
                {
                    worksheet.Cells[j + 2, 1] = groups[j].GroupName;
                    worksheet.Cells[j + 2, 2] = MinGroupScore(groups[j].GroupId, sessionTypes[i].SessionTypeId);
                    worksheet.Cells[j + 2, 3] = MaxGroupScore(groups[j].GroupId, sessionTypes[i].SessionTypeId);
                    worksheet.Cells[j + 2, 4] = AverageGroupScore(groups[j].GroupId, sessionTypes[i].SessionTypeId);
                }
            }

            excel.Application.ActiveWorkbook.SaveAs(Directory.GetCurrentDirectory() + "\\SummaryTable.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            

            DisposeDB();
            DisposeExcel();

            return true;
        }

        private static int MinGroupScore(int indexGroup, int indexSession)
        {
            int min = -1;
            foreach (Students student in students)
            {
                if (student.GroupId == indexGroup)
                {
                    int minStudentScore = MinStudentScore(student.StudentId, indexSession);
                    if (min == -1) min = minStudentScore;
                    if (min > minStudentScore) min = minStudentScore;
                }
            }
            if (min != -1) return min;
            return min;
        }

        private static int MinStudentScore(int indexStudent, int indexSession)
        {
            int min = -1;
            foreach (Grades grade in grades)
            {
                if (grade.StudentId == indexStudent && GetPassSubjects(grade.PassSubjectId).SessionTypeId == indexSession)
                {
                    if (min == -1) min = grade.Grade;
                    if (min > grade.Grade) min = grade.Grade;
                }
            }
            if (min != -1) return min;
            return min;
        }

        private static int MaxGroupScore(int indexGroup, int indexSession)
        {
            int max = -1;
            foreach (Students student in students)
            {
                if (student.GroupId == indexGroup)
                {
                    int maxStudentScore = MaxStudentScore(student.StudentId, indexSession);
                    if (max == -1) max = maxStudentScore;
                    if (max < maxStudentScore) max = maxStudentScore;
                }
            }
            if (max != -1) return max;
            return max;
        }

        private static int MaxStudentScore(int indexStudent, int indexSession)
        {
            int max = -1;
            foreach (Grades grade in grades)
            {
                if (grade.StudentId == indexStudent && GetPassSubjects(grade.PassSubjectId).SessionTypeId == indexSession)
                {
                    if (max == -1) max = grade.Grade;
                    if (max < grade.Grade) max = grade.Grade;
                }
            }
            if (max != -1) return max;
            return max;
        }

        private static float AverageGroupScore(int indexGroup, int indexSession)
        {
            float sum = 0;
            int count = 0;
            foreach (Students student in students)
            {
                if (student.GroupId == indexGroup)
                {
                    sum += AverageStudentScore(student.StudentId, indexSession);
                    count++;
                }
            }
            if (count > 0) return sum / count;
            return 0;
        }

        private static float AverageStudentScore(int indexStudent, int indexSession)
        {
            float sum = 0;
            int count = 0;
            foreach (Grades grade in grades)
            {
                if( grade.StudentId == indexStudent && GetPassSubjects(grade.PassSubjectId).SessionTypeId == indexSession)
                {
                    sum += grade.Grade;
                    count++;
                }
            }
            if (count > 0) return sum / count;
            return 0;
        }

        private static PassSubjects GetPassSubjects(int indexPassSubject)
        {
            foreach (var passSubjects in passSubjects)
            {
                if (passSubjects.PassSubjectId == indexPassSubject) return passSubjects;
            }
            throw new Exception("Index not found!");
        }

        /// <summary>
        /// Specialization average score.
        /// </summary>
        /// <param name="connection">Connection.</param>
        /// <returns>Successful completion method.</returns>
        public static bool GetSpecializationTable(string connection)
        {
            InitializeDB(connection);
            InitializeExcel(sessionTypes.Length);

            IEnumerable<IGrouping<string, Groups>> groups = ExcelReport.groups.GroupBy(group => group.Specialization);

            for (int i = 0; i < sessionTypes.Length; i++)
            {
                worksheet = (Worksheet)excel.Worksheets.get_Item(i + 1);
                worksheet.Name = sessionTypes[i].SessionTypeName;

                worksheet.Cells[1, 1] = "Specialization";
                worksheet.Cells[1, 2] = "Average";

                for (int j = 0; j < groups.Count(); j++)
                {
                    worksheet.Cells[j + 2, 1] = groups.ElementAt(j).Key;

                    float averageSpecialization = 0;
                    int groupCount = 0;

                    IEnumerator<Groups> groupEnumerator = groups.ElementAt(j).GetEnumerator();

                    while(groupEnumerator.MoveNext())
                    {
                        averageSpecialization += AverageGroupScore(groupEnumerator.Current.GroupId, sessionTypes[i].SessionTypeId);
                        groupCount++;
                    }

                    worksheet.Cells[j + 2, 2] = averageSpecialization / groupCount;
                }
            }

            excel.Application.ActiveWorkbook.SaveAs(Directory.GetCurrentDirectory() + "\\SpecializationTable.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);


            DisposeDB();
            DisposeExcel();

            return true;
        }

        /// <summary>
        /// Examinator average score.
        /// </summary>
        /// <param name="connection">Connection.</param>
        /// <returns>Successful completion method.</returns>
        public static bool GetExaminatorTable(string connection)
        {
            InitializeDB(connection);
            InitializeExcel(sessionTypes.Length);

            IEnumerable<IGrouping<string, PassSubjects>> examinators = passSubjects.GroupBy(passSubject => passSubject.Examinator);

            for (int i = 0; i < sessionTypes.Length; i++)
            {
                worksheet = (Worksheet)excel.Worksheets.get_Item(i + 1);
                worksheet.Name = sessionTypes[i].SessionTypeName;

                worksheet.Cells[1, 1] = "Examinator";
                worksheet.Cells[1, 2] = "Average";

                for (int j = 0; j < examinators.Count(); j++)
                {
                    worksheet.Cells[j + 2, 1] = examinators.ElementAt(j).Key;

                    float averageExaminator = 0;
                    int examCount = 0;

                    IEnumerator<PassSubjects> examEnumerator = examinators.ElementAt(j).GetEnumerator();

                    while (examEnumerator.MoveNext())
                    {
                        averageExaminator += AveragePassSubjectScore(examEnumerator.Current.GroupId, sessionTypes[i].SessionTypeId);
                        examCount++;
                    }

                    worksheet.Cells[j + 2, 2] = averageExaminator / examCount;
                }
            }

            excel.Application.ActiveWorkbook.SaveAs(Directory.GetCurrentDirectory() + "\\ExaminatorTable.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);


            DisposeDB();
            DisposeExcel();

            return true;
        }

        private static float AveragePassSubjectScore(int indexPassSubject, int indexSession)
        {
            float sum = 0;
            int count = 0;
            foreach (Grades grade in grades)
            {
                if (grade.PassSubjectId == indexPassSubject && GetPassSubjects(grade.PassSubjectId).SessionTypeId == indexSession)
                {
                    sum += grade.Grade;
                    count++;
                }
            }
            if (count > 0) return sum / count;
            return 0;
        }
    }
}
