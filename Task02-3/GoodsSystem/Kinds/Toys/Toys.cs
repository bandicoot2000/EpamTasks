using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsSystem
{
    public class Toys : Product
    {
        protected Toys(string name, double price) : base(name, price)
        {
        }
    }
}
