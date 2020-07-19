using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsSystem
{
    public class Toys : Product
    {
        protected Toys(string name, double price) : base(name, price) { }

        public override bool Equals(object obj)
        {
            return obj is Toys toys && base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static Toys operator +(Toys toys1, Toys toys2)
        {
            return new Toys(toys1.Name + "-" + toys2.Name, (toys1.Price + toys2.Price) / 2);
        }

        public static explicit operator Toys(Food food) => new Toys(food.Name, food.Price);
        public static explicit operator Toys(Clothes clothes) => new Toys(clothes.Name, clothes.Price);
    }
}
