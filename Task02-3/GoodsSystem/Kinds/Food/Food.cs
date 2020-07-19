using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsSystem
{
    public class Food : Product
    {
        protected Food(string name, double price) : base(name, price)
        {
        }
    }
}
