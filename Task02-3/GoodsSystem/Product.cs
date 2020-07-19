using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsSystem
{
    /// <summary>
    /// Class product.
    /// </summary>
    public abstract class Product
    {
        /// <summary>
        /// Product name.
        /// </summary>
        public string Name { get; protected set; } 

        /// <summary>
        /// Product price.
        /// </summary>
        public double Price { get; protected set; }

        /// <summary>
        /// Convert product to int.
        /// </summary>
        /// <param name="product">Product.</param>
        public static implicit operator int(Product product)
        {
            return (int)(product.Price * 100);
        }

        /// <summary>
        /// Convert product to double.
        /// </summary>
        /// <param name="product">Product.</param>
        public static implicit operator double(Product product)
        {
            return product.Price;
        }

        /// <summary>
        /// Construstor product. 
        /// </summary>
        /// <param name="name">Product name.</param>
        /// <param name="price">Product price.</param>
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }


        /// <summary>
        /// Override method ToString.
        /// </summary>
        /// <returns>String product.</returns>
        public override string ToString()
        {
            return "Name: " + Name + " Price: " + Price.ToString("F");
        }

        /// <summary>
        /// Override method GetHashCode.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = -44027456;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Override method Equals.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Comparison result.</returns>
        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Name == product.Name &&
                   Price == product.Price;
        }
    }
}
