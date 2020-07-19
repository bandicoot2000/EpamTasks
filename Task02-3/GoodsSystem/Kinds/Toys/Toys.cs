using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsSystem
{
    /// <summary>
    /// Class Toys.
    /// </summary>
    public class Toys : Product
    {
        /// <summary>
        /// Constructor toys.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="price">Price.</param>
        protected Toys(string name, double price) : base(name, price) { }

        /// <summary>
        /// Override method Equals.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Comparison result.</returns>
        public override bool Equals(object obj)
        {
            return obj is Toys toys && base.Equals(obj);
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
        /// Sum of two toys.
        /// </summary>
        /// <param name="toys1">First toys.</param>
        /// <param name="toys2">Second toys.</param>
        /// <returns>Result toys.</returns>
        public static Toys operator +(Toys toys1, Toys toys2)
        {
            return new Toys(toys1.Name + "-" + toys2.Name, (toys1.Price + toys2.Price) / 2);
        }

        /// <summary>
        /// Convert food to toys.
        /// </summary>
        /// <param name="food">Food.</param>
        public static explicit operator Toys(Food food) => new Toys(food.Name, food.Price);

        /// <summary>
        /// Convert clothes to toys.
        /// </summary>
        /// <param name="clothes">Clothes.</param>
        public static explicit operator Toys(Clothes clothes) => new Toys(clothes.Name, clothes.Price);
    }
}
