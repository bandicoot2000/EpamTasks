using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsSystem
{
    public class Clothes : Product
    {
        protected Clothes(string name, double price) : base(name, price) { }

        public override bool Equals(object obj)
        {
            return obj is Clothes clothes && base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static  Clothes operator +(Clothes clothes1, Clothes clothes2)
        {
            return new Clothes(clothes1.Name + "-" + clothes2.Name, (clothes1.Price + clothes2.Price) / 2);
        }

        public static explicit operator Clothes(Food food) => new Clothes(food.Name, food.Price);
        public static explicit operator Clothes(Toys toys) => new Clothes(toys.Name, toys.Price);
    }
}
