using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DBRecordingGrades
{
    /// <summary>
    /// Create and Fill DB.
    /// </summary>
    public static class DataBaseManager
    {
        /// <summary>
        /// Delete and Create DB.
        /// </summary>
        /// <param name="connectStringInit">Init connect String.</param>
        /// <returns>Successful completion method.</returns>
        public static bool DBInitialize(string connectStringInit)
        {
            const string DB_DROP = "IF DB_ID(N'AcademicYear2020_t7') IS NOT NULL DROP DATABASE AcademicYear2020_t7";
            const string DB_CREATE = "CREATE DATABASE AcademicYear2020_t7";

            using (SqlConnection sqlConnection = new SqlConnection(string.Format(connectStringInit, "master")))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(DB_DROP, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlCommand = new SqlCommand(DB_CREATE, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            using (SqlConnection sqlConnection = new SqlConnection(string.Format(connectStringInit, "AcademicYear2020_t7")))
            {
                sqlConnection.Open();
                string command = Regex.Replace(File.ReadAllText(@"../../../DBRecordingGrades/DB_Initialization.sql"), "USE AcademicYear2020_t7", "")
                    .Replace('\n', ' ').Replace('\r', ' ');
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            return true;
        }
        /// <summary>
        /// Fill DB.
        /// </summary>
        /// <param name="connectString">Connect String</param>
        /// <returns>Successful completion method.</returns>
        public static bool DBFilling(string connectString)
        {

            const int ASSESSMENTFORMS_COUNT = 2;
            const int SESSIONTYPES_COUNT = 2;
            const int SUBJECTS_COUNT = 8;
            const int GROUPS_COUNT = 6;
            const int STUDENTS_COUNT = 120;
            const int PASSSUBJECTS_COUNT = 60;
            const int GRADES_COUNT = 7000;

            Random random = new Random();

            ConnectionFactory connection = ConnectionFactory.GetСonnectionFactory(DataBaseType.MSSQL, connectString);

            #region AssessmentForms
            AssessmentForms[] forms = new AssessmentForms[ASSESSMENTFORMS_COUNT]
            {
                new AssessmentForms(1, "Exem"),
                new AssessmentForms(2, "Test")
            };

            IAssessmentForms assessmentForms = connection.GetAssessmentForms();

            for (int i = 0; i < ASSESSMENTFORMS_COUNT; i++)
            {
                assessmentForms.Insert(forms[i]);
            }
            #endregion

            #region SessionTypes
            SessionTypes[] types = new SessionTypes[SESSIONTYPES_COUNT]
            {
                new SessionTypes(1, "Winter"),
                new SessionTypes(2, "Summer")
            };

            ISessionTypes sessionTypes = connection.GetSessionTypes();

            for (int i = 0; i < SESSIONTYPES_COUNT; i++)
            {
                sessionTypes.Insert(types[i]);
            }
            #endregion

            #region Subjects
            Subjects[] subjects = new Subjects[SUBJECTS_COUNT]
            {
                new Subjects(1, "Maths"),
                new Subjects(2, "Chemistry"),
                new Subjects(3, "Physics"),
                new Subjects(4, "OOP"),
                new Subjects(5, "OAIP"),
                new Subjects(6, "DB"),
                new Subjects(7, "AGU"),
                new Subjects(8, "English language"),
            };

            ISubjects subject = connection.GetSubjects();

            for (int i = 0; i < SUBJECTS_COUNT; i++)
            {
                subject.Insert(subjects[i]);
            }
            #endregion

            #region Groups
            Groups[] groups = new Groups[GROUPS_COUNT]
            {
                new Groups(1, "ITI - 11", "Game industry"),
                new Groups(2, "ITP - 11", "Industrial Industry"),
                new Groups(3, "ITI - 21", "Game industry"),
                new Groups(4, "ITP - 21", "Industrial Industry"),
                new Groups(5, "ITI - 31", "Game industry"),
                new Groups(6, "ITP - 31", "Industrial Industry")
            };

            IGroups group = connection.GetGroups();

            for (int i = 0; i < GROUPS_COUNT; i++)
            {
                group.Insert(groups[i]);
            }
            #endregion

            #region Students
           
            string[] secondNames = new string[]
            {
                "Akylich",
                "Jukova",
                "Piskun",
                "Beliy",
                "Kniga",
                "Svtski",
                "Eremich",
                "Ivashin",
                "Kylishov",
                "Fidorovich"
            };
            string[] firstNames = new string[]
            {
                "Artem",
                "Yra",
                "Naysty",
                "Ily",
                "Pasha",
                "Sasha",
                "Danik",
                "Dasha",
                "Ruslan",
                "Kirill"
            };
            string[] midleNames = new string[]
            {
                "Pavlovich",
                "Aleksandrovich",
                "Artemovich",
                "Yryvich",
                "Kirilovich",
                "Ynovich",
                "Dmitreivich",
                "Nikitovich",
                "Sergeivich",
                "Genadivich"
            };
            string[] gender = new string[]
            {
                "M",
                "F"
            };


            IStudents students = connection.GetStudents();

            for (int i = 0; i < STUDENTS_COUNT; i++)
            {
                students.Insert(new Students(0, 
                    secondNames[random.Next(secondNames.Length)],
                    firstNames[random.Next(firstNames.Length)],
                    midleNames[random.Next(midleNames.Length)],
                    gender[random.Next(gender.Length)],
                    new DateTime(random.Next(1996, 2003), random.Next(12) + 1, random.Next(28) + 1),
                    random.Next(GROUPS_COUNT) + 1));
            }
            #endregion

            #region PassSubjects
            string[] examinators = new string[]
            {
                "Viscki Grigorvixh Pushnou",
                "Syslic Dmitriy Pavlovich",
                "Miranda Anastasiy Alecsandracna",
                "Alecksey Filly Victorovich",
                "Minirya Voviy Dorick",
                "Fillych Divo Lol",
                "Monster Programer Bos",
                "Super Prepod Mos"
            };
            IPassSubjects passSubjects = connection.GetPassSubjects();

            for (int i = 0; i < PASSSUBJECTS_COUNT; i++)
            {
                int subjectId = random.Next(SUBJECTS_COUNT) + 1;
                passSubjects.Insert(new PassSubjects(0,
                        random.Next(GROUPS_COUNT) + 1,
                        random.Next(SESSIONTYPES_COUNT) + 1,
                        random.Next(ASSESSMENTFORMS_COUNT) + 1,
                        random.Next(SUBJECTS_COUNT) + 1,
                        examinators[random.Next(examinators.Length)]));
            }
            #endregion

            #region Grades

            IGrades grades = connection.GetGrades();

            for (int i = 0; i < GRADES_COUNT; i++)
            {
                grades.Insert(new Grades(0, random.Next(PASSSUBJECTS_COUNT) + 1, random.Next(STUDENTS_COUNT) + 1, random.Next(11)));
            }
            #endregion

            return true;
        }
    }
}
