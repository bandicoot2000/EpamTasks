using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoodsSystem;
using System.Runtime.CompilerServices;

namespace UnitTestGoodsSystem
{
    [TestClass]
    public class UnitTestGoodsSystem
    {
        [TestMethod]
        public void ClothesSum()
        {
            Shorts shorts = new Shorts();
            Sneakers sneakers = new Sneakers();
            Assert.AreEqual("Name: Shorts-Sneakers Price: 75,73", (shorts + sneakers).ToString());
        }

        [TestMethod]
        public void ToysSum()
        {
            Yo_Yo yo_Yo = new Yo_Yo();
            Ball ball = new Ball();
            Assert.AreEqual("Name: Yo_Yo-Ball Price: 9,39", (yo_Yo + ball).ToString());
        }

        [TestMethod]
        public void FoodSum()
        {
            Milk milk = new Milk();
            Bread bread = new Bread();
            Assert.AreEqual("Name: Milk-Bread Price: 1,63", (milk + bread).ToString());
        }

        [TestMethod]
        public void FoodToClothes()
        {
            Milk milk = new Milk();
            Clothes clothes = (Clothes)milk;
            Assert.AreEqual("Name: Milk Price: 2,10", (clothes).ToString());
        }
        [TestMethod]
        public void FoodToToys()
        {
            Milk milk = new Milk();
            Toys toys = (Toys)milk;
            Assert.AreEqual("Name: Milk Price: 2,10", (toys).ToString());
        }
        [TestMethod]
        public void ToysToClothes()
        {
            Ball ball = new Ball();
            Clothes clothes = (Clothes)ball;
            Assert.AreEqual("Name: Ball Price: 10,00", (clothes).ToString());
        }
        [TestMethod]
        public void ToysToFood()
        {
            Ball ball = new Ball();
            Food food = (Food)ball;
            Assert.AreEqual("Name: Ball Price: 10,00", (food).ToString());
        }
        [TestMethod]
        public void ClothesToFood()
        {
            Sneakers sneakers = new Sneakers();
            Food food = (Food)sneakers;
            Assert.AreEqual("Name: Sneakers Price: 100,90", (food).ToString());
        }
        [TestMethod]
        public void ClothesToToys()
        {
            Sneakers sneakers = new Sneakers();
            Toys toys = (Toys)sneakers;
            Assert.AreEqual("Name: Sneakers Price: 100,90", (toys).ToString());
        }
        [TestMethod]
        public void ProductToInt()
        {
            Sneakers sneakers = new Sneakers();
            int integer = (int)sneakers;
            Assert.AreEqual(10090, integer);
        }
        [TestMethod]
        public void ProductToDouble()
        {
            Sneakers sneakers = new Sneakers();
            double double_ = (double)sneakers;
            Assert.AreEqual(100.90, double_);
        }

    }
}
