using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsSystem
{
    /// <summary>
    /// Class food.
    /// </summary>
    public class Food : Product
    {
        /// <summary>
        /// Food constructor.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="price">Prise.</param>
        protected Food(string name, double price) : base(name, price) { }

        /// <summary>
        /// Override method Equals.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Comparison result.</returns>
        public override bool Equals(object obj)
        {
            return obj is Food food && base.Equals(obj);
        }

        /// <summary>
        /// Override method GetHashCode.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Sum of two food.
        /// </summary>
        /// <param name="food1">First food.</param>
        /// <param name="food2">Second food.</param>
        /// <returns></returns>
        public static Food operator +(Food food1, Food food2)
        {
            return new Food(food1.Name + "-" + food2.Name, (food1.Price + food2.Price) / 2);
        }

        /// <summary>
        /// Convert clothes to food.
        /// </summary>
        /// <param name="clothes">Clothes.</param>
        public static explicit operator Food(Clothes clothes) => new Food(clothes.Name, clothes.Price);

        /// <summary>
        /// Convert toys to food.
        /// </summary>
        /// <param name="toys">Toys.</param>
        public static explicit operator Food(Toys toys) => new Food(toys.Name, toys.Price);
    }
}
