using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsSystem
{
    public class Food : Product
    {
        protected Food(string name, double price) : base(name, price) { }

        public override bool Equals(object obj)
        {
            return obj is Food food && base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static Food operator +(Food food1, Food food2)
        {
            return new Food(food1.Name + "-" + food2.Name, (food1.Price + food2.Price) / 2);
        }

        public static explicit operator Food(Clothes clothes) => new Food(clothes.Name, clothes.Price);
        public static explicit operator Food(Toys toys) => new Food(toys.Name, toys.Price);
    }
}
