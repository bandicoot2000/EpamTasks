using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsSystem
{
    /// <summary>
    /// Class clothes.
    /// </summary>
    public class Clothes : Product
    {
        /// <summary>
        /// Construstor clothes.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="price">Price.</param>
        protected Clothes(string name, double price) : base(name, price) { }

        /// <summary>
        /// Override method Equals.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Comparison result.</returns>
        public override bool Equals(object obj)
        {
            return obj is Clothes clothes && base.Equals(obj);
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
        /// Sum of two clothes.
        /// </summary>
        /// <param name="clothes1">First clothes.</param>
        /// <param name="clothes2">Second clothes.</param>
        /// <returns>Result clothes.</returns>
        public static  Clothes operator +(Clothes clothes1, Clothes clothes2)
        {
            return new Clothes(clothes1.Name + "-" + clothes2.Name, (clothes1.Price + clothes2.Price) / 2);
        }

        /// <summary>
        /// Convert food to clothes.
        /// </summary>
        /// <param name="food">Food.</param>
        public static explicit operator Clothes(Food food) => new Clothes(food.Name, food.Price);

        /// <summary>
        /// Convert toys to clothes.
        /// </summary>
        /// <param name="toys">Toys.</param>
        public static explicit operator Clothes(Toys toys) => new Clothes(toys.Name, toys.Price);
    }
}
