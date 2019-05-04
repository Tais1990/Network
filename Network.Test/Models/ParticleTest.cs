using Network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

public class ParticleTest
{
    #region Constructor
    [Fact]
    public void CanInstantiateParticleEmpty()
    {
        Particle particle = new Particle();
    }
    [Fact]
    public void CanInstantiateParticleWithCoordinate()
    {
        Particle particle = new Particle(10.3, 69.5);
        Assert.Equal(10.3, particle.X);
        Assert.Equal(69.5, particle.Y);
    }
    [Fact]
    public void CanInstantiateParticleWithCoordinateAndRadius()
    {
        Particle particle = new Particle(10.3, 69.5, 5.5);
        Assert.Equal(10.3, particle.X);
        Assert.Equal(69.5, particle.Y);
        Assert.Equal(5.5, particle.Radius);
    }
    [Fact]
    public void CanInstantiateParticleCopy()
    {
        Particle particle = new Particle();
        Particle newParticle = new Particle(particle);
        Assert.Equal(particle.X, newParticle.X);
        Assert.Equal(particle.Y, newParticle.Y);
        Assert.Equal(particle.Radius, newParticle.Radius);
        Assert.Equal(particle.Speed.X, newParticle.Speed.X);
        Assert.Equal(particle.Speed.Y, newParticle.Speed.Y);
        particle.X = 200;
        Assert.NotEqual(particle.X, newParticle.X);
        particle.Speed.Y = -500;
        Assert.NotEqual(particle.Speed.Y, newParticle.Speed.Y);
    }
    [Fact]
    public void CanInstantiateParticleWithCoordinateAndRadiusAndSpeed()
    {
        Particle particle = new Particle(10.3, 69.5, 5.5, 10, 8);
        Assert.Equal(10.3, particle.X);
        Assert.Equal(69.5, particle.Y);
        Assert.Equal(5.5, particle.Radius);
        Assert.Equal(10, particle.Speed.X);
        Assert.Equal(8, particle.Speed.Y);
    }
    [Fact]
    public void CanInstantiateParticleWithCoordinateAndSpeed()
    {
        Particle particle = new Particle(10.3, 69.5, 10, 8);
        Assert.Equal(10.3, particle.X);
        Assert.Equal(69.5, particle.Y);
        Assert.Equal(10, particle.Speed.X);
        Assert.Equal(8, particle.Speed.Y);
    }
    [Fact]
    public void CanInstantiateParticleWithCoordinateAndSpeedVector()
    {
        Particle particle = new Particle(10.3, 69.5, new Vector(10, 8));
        Assert.Equal(10.3, particle.X);
        Assert.Equal(69.5, particle.Y);
        Assert.Equal(10, particle.Speed.X);
        Assert.Equal(8, particle.Speed.Y);
    }
    [Fact]
    public void CanInstantiateParticleWithCoordinateAndRadiusAndSpeedVector()
    {
        Particle particle = new Particle(10.3, 69.5, 5.5, new Vector(10, 8));
        Assert.Equal(10.3, particle.X);
        Assert.Equal(69.5, particle.Y);
        Assert.Equal(5.5, particle.Radius);
        Assert.Equal(10, particle.Speed.X);
        Assert.Equal(8, particle.Speed.Y);
    }
    #endregion
    #region Operators
    /// <summary>
    /// Вектор соединяющий частицу b с частицей a
    /// </summary>
    /// <param name="a">первая частица</param>
    /// <param name="b">вторая частица</param>
    /// <returns></returns>
    [Fact]
    public void VectorBetweenParticle()
    {
        Particle a = new Particle(10, 2);
        Particle b = new Particle(1, 10);
        Vector vectorBeteen = b - a;
        Assert.Equal(-9, vectorBeteen.X);
        Assert.Equal(8, vectorBeteen.Y);
    }
    #endregion
    #region Function
    [Fact]
    public void Distance1()
    {
        Particle a = new Particle(10, 5);
        Particle b = new Particle(10, -5);
        Assert.Equal(10, Particle.Distance(b, a), MyMath.Precision);
        Assert.Equal(10, Particle.Distance(a, b), MyMath.Precision);
    }
    [Fact]
    public void Distance2()
    {
        Particle a = new Particle(1, 2);
        Particle b = new Particle(4, 6);
        Assert.Equal(5, Particle.Distance(b, a), MyMath.Precision);
        Assert.Equal(5, Particle.Distance(a, b), MyMath.Precision);
    }
    [Fact]
    public void Distance3()
    {
        Particle a = new Particle(1, 2);
        Particle b = new Particle(2, 3);
        Assert.Equal(Math.Sqrt(2), Particle.Distance(b, a), MyMath.Precision);
        Assert.Equal(Math.Sqrt(2), Particle.Distance(a, b), MyMath.Precision);
    }
    [Fact]
    public void CrossСut1()
    {
        Particle a = new Particle(1, 2, 2);
        Particle b = new Particle(4, 6, 3);
        Assert.True(Particle.CrossСut(a, b));
    }
    [Fact]
    public void CrossСut2()
    {
        Particle a = new Particle(1, 2, 1.9);
        Particle b = new Particle(4, 6, 3);
        Assert.False(Particle.CrossСut(a, b));
    }
    [Fact]
    public void CrossWall1()
    {
        Particle a = new Particle(4, 2, 1, new Vector(1, 0));
        a.CrossWall(5, 10);
        Assert.Equal(-1, a.Speed.X);
    }
    [Fact]
    public void CrossWall2()
    {
        Particle a = new Particle(4, 2, 1, new Vector(-1, 0));
        a.CrossWall(5, 10);
        Assert.Equal(-1, a.Speed.X);
    }
    [Fact]
    public void CrossWall3()
    {
        Particle a = new Particle(3, 1, 1, new Vector(0, -1));
        a.CrossWall(5, 10);
        Assert.Equal(1, a.Speed.Y);
    }
    [Fact]
    public void CrossWall4()
    {
        Particle a = new Particle(3, 1, 1, new Vector(0, 1));
        a.CrossWall(5, 10);
        Assert.Equal(1, a.Speed.Y);
    }
    #endregion
}

