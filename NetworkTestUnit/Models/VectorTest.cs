//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Network.Models.Tests
{
    /*
    [TestClass()]
    public class VectorTest
    {
        [TestMethod()]
        public void CanInstantiateVectorEmpty()
        {
            Vector vector = new Vector();
        }
        [TestMethod()]
        public void CanInstantiateVectorWithCoordinates()
        {
            Vector vector = new Vector(-5, 9);
            Assert.AreEqual(vector.x, -5);
            Assert.AreEqual(vector.y, 9);
        }
        [TestMethod()]
        public void CanInstantiateVectorCopy()
        {
            Vector vector = new Vector(1, 9);
            Vector vectorNew = new Vector(vector);
            Assert.AreEqual(vectorNew.x, 1);
            Assert.AreEqual(vectorNew.y, 9);
        }

        public void CalcueteMod()
        {
            Vector vector = new Vector(1, 1);
            Assert.AreEqual(vector.mod(), Math.Sqrt(2));
        }
        [TestMethod()]
        public void CalcueteModInt()
        {
            Vector vector = new Vector(4, -3);
            Assert.AreEqual(vector.mod(), 5);
        }
        //[TestInitialize]
        // тут может быть прописано то, что должно выполниться перед всеми тестами. только обязательно public
        [TestMethod()]
        public void Multiplication1()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(-9, 5);
            Assert.AreEqual(a * b, 1);
        }
        [TestMethod()]
        public void Multiplication2()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(9, 5);
            Assert.AreEqual(a * b, 19);
        }
        [TestMethod()]
        public void AngleBeteen1()
        {
            Vector a = new Vector(10, 0);
            Vector b = new Vector(0, 10);
            Assert.AreEqual(a ^ b, Math.PI * 0.5);
        }
        [TestMethod()]
        public void AngleBeteen2()
        {
            Vector a = new Vector(10, 0);
            Vector b = new Vector(1, 0);
            Assert.AreEqual(a ^ b, 0);
        }
        [TestMethod()]
        public void AngleBeteen3()
        {
            Vector a = new Vector(10, 0);
            Vector b = new Vector(-1, 0);
            Assert.AreEqual(a ^ b, Math.PI);
        }
        [TestMethod()]
        public void AngleBeteen4()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(-2, 1);
            Assert.AreEqual(a ^ b, Math.PI * 0.5);
        }
        [TestMethod()]
        public void AngleBeteen5()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(-2, 1);
            Assert.AreEqual(b ^ a, Math.PI * (-0.5));
        }
        [TestMethod()]
        public void AngleBeteen6()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(2, -1);
            Assert.AreEqual(a ^ b, Math.PI * (-0.5));
        }
        [TestMethod()]
        public void AngleBeteen7()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(-1, -2);
            Assert.AreEqual(a ^ b, Math.PI, MyMath.Epsilon);
        }
        [TestMethod()]
        public void Plus1()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(1, 2);
            Vector c = a + b;
            Assert.AreEqual(c.x, 2);
            Assert.AreEqual(c.y, 4);
        }
        [TestMethod()]
        public void Plus2()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(1, -2);
            Vector c = a + b;
            Assert.AreEqual(c.x, 2);
            Assert.AreEqual(c.y, 0);
        }
        [TestMethod()]
        public void Minus1()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(1, 2);
            Vector c = a - b;
            Assert.AreEqual(c.x, 0);
            Assert.AreEqual(c.y, 0);
        }
        [TestMethod()]
        public void Minus2()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(1, -2);
            Vector c = a - b;
            Assert.AreEqual(c.x, 0);
            Assert.AreEqual(c.y, 4);
        }
        [TestMethod()]
        public void Rotation1()
        {
            Vector vector = new Vector(1, 2);
            Vector v = vector.rotation(Math.PI * 0.5);
            Assert.AreEqual(v.x, -2, MyMath.Epsilon);
            Assert.AreEqual(v.y, 1, MyMath.Epsilon);
        }
        [TestMethod()]
        public void Rotation2()
        {
            Vector vector = new Vector(1, 2);
            Vector v = vector.rotation(-Math.PI * 0.5);
            Assert.AreEqual(v.x, 2, MyMath.Epsilon);
            Assert.AreEqual(v.y, -1, MyMath.Epsilon);
        }
        [TestMethod()]
        public void Rotation3()
        {
            Vector vector = new Vector(1, 2);
            Vector v = vector.rotation(Math.PI);
            Assert.AreEqual(v.x, -1, MyMath.Epsilon);
            Assert.AreEqual(v.y, -2, MyMath.Epsilon);
        }
        [TestMethod()]
        public void Rotation4()
        {
            Vector vector = new Vector(1, Math.Sqrt(3));
            Vector v = vector.rotation(Math.PI / 6.0);
            Assert.AreEqual(v.x, 0, MyMath.Epsilon);
            Assert.AreEqual(v.y, 2, MyMath.Epsilon);
        }
        [TestMethod()]
        public void Rotation5()
        {
            Vector vector = new Vector(1, Math.Sqrt(3));
            Vector v = vector.rotation((-1) * Math.PI / 3.0);
            Assert.AreEqual(v.x, 2, MyMath.Epsilon);
            Assert.AreEqual(v.y, 0, MyMath.Epsilon);
        }
    }
    */
}