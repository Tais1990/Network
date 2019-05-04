using Network.Models;
using System;
using Xunit;

    public class VectorTest
    {
        [Fact]
        public void CanInstantiateVectorEmpty()
        {
            Vector vector = new Vector();
        }
        [Fact]
        public void CanInstantiateVectorWithCoordinates()
        {
            Vector vector = new Vector(-5, 9);
            Assert.Equal(-5, vector.X);
            Assert.Equal(9, vector.Y);
        }
        [Fact]
        public void CanInstantiateVectorCopy()
        {
            Vector vector = new Vector(1, 9);
            Vector vectorNew = new Vector(vector);
            Assert.Equal(1, vectorNew.X);
            Assert.Equal(9, vectorNew.Y);
        }

        [Fact]
        public void CalcueteMod()
        {
            Vector vector = new Vector(1, 1);
            Assert.Equal(Math.Sqrt(2), vector.Mod());
        }
        [Fact]
        public void CalcueteModInt()
        {
            Vector vector = new Vector(4, -3);
            Assert.Equal(5, vector.Mod());
        }        
        [Fact]
        public void Multiplication1()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(-9, 5);
            Assert.Equal(1, a * b);
        }
        [Fact]
        public void Multiplication2()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(9, 5);
            Assert.Equal(19, a * b);
        }
        [Fact]
        public void AngleBeteen1()
        {
            Vector a = new Vector(10, 0);
            Vector b = new Vector(0, 10);
            Assert.Equal(Math.PI * 0.5, a ^ b);
        }
        [Fact]
        public void AngleBeteen2()
        {
            Vector a = new Vector(10, 0);
            Vector b = new Vector(1, 0);
            Assert.Equal(0, a ^ b);
        }
        [Fact]
        public void AngleBeteen3()
        {
            Vector a = new Vector(10, 0);
            Vector b = new Vector(-1, 0);
            Assert.Equal(Math.PI, a ^ b);
        }
        [Fact]
        public void AngleBeteen4()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(-2, 1);
            Assert.Equal(Math.PI * 0.5, a ^ b);
        }
        [Fact]
        public void AngleBeteen5()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(-2, 1);
            Assert.Equal(Math.PI * (-0.5), b ^ a);
        }
        [Fact]
        public void AngleBeteen6()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(2, -1);
            Assert.Equal(Math.PI * (-0.5), a ^ b);
        }
        [Fact]
        public void AngleBeteen7()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(-1, -2);
            Assert.Equal(Math.PI, a ^ b, MyMath.Precision);
        }
        [Fact]
        public void Plus1()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(1, 2);
            Vector c = a + b;
            Assert.Equal(2, c.X);
            Assert.Equal(4, c.Y);
        }
        [Fact]
        public void Plus2()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(1, -2);
            Vector c = a + b;
            Assert.Equal(2, c.X);
            Assert.Equal(0, c.Y);
        }
        [Fact]
        public void Minus1()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(1, 2);
            Vector c = a - b;
            Assert.Equal(0, c.X);
            Assert.Equal(0, c.Y);
        }
        [Fact]
        public void Minus2()
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(1, -2);
            Vector c = a - b;
            Assert.Equal(0, c.X);
            Assert.Equal(4, c.Y);
        }
        [Fact]
        public void Rotation1()
        {
            Vector vector = new Vector(1, 2);
            Vector v = vector.Rotation(Math.PI * 0.5);
            Assert.Equal(-2, v.X, MyMath.Precision);
            Assert.Equal(1, v.Y, MyMath.Precision);
        }
        [Fact]
        public void Rotation2()
        {
            Vector vector = new Vector(1, 2);
            Vector v = vector.Rotation(-Math.PI * 0.5);
            Assert.Equal(2, v.X, MyMath.Precision);
            Assert.Equal(-1, v.Y, MyMath.Precision);
        }
        [Fact]
        public void Rotation3()
        {
            Vector vector = new Vector(1, 2);
            Vector v = vector.Rotation(Math.PI);
            Assert.Equal(-1, v.X, MyMath.Precision);
            Assert.Equal(-2, v.Y, MyMath.Precision);
        }
        [Fact]
        public void Rotation4()
        {
            Vector vector = new Vector(1, Math.Sqrt(3));
            Vector v = vector.Rotation(Math.PI / 6.0);
            Assert.Equal(0, v.X, MyMath.Precision);
            Assert.Equal(2, v.Y, MyMath.Precision);
        }
        [Fact]
        public void Rotation5()
        {
            Vector vector = new Vector(1, Math.Sqrt(3));
            Vector v = vector.Rotation((-1) * Math.PI / 3.0);
            Assert.Equal(2, v.X, MyMath.Precision);
            Assert.Equal(0, v.Y, MyMath.Precision);
        }
    }

