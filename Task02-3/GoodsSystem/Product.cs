using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsSystem
{
    public abstract class Product
    {
        public string Name { get; protected set; } 

        public double Price { get; protected set; }

        public static implicit operator int(Product product)
        {
            return (int)(product.Price * 100);
        }

        public static implicit operator double(Product product)
        {
            return product.Price;
        }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Name == product.Name &&
                   Price == product.Price;
        }

        public override int GetHashCode()
        {
            int hashCode = -44027456;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Price);
            return hashCode;
        }

        public override string ToString()
        {
            return "Name: " + Name + " Price: " + Price;
        }
    }
}
