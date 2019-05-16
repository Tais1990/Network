using Network.Models;
using System.Collections.ObjectModel;
using Xunit;

public class ConfigurationTest
{
    #region Constructor
    [Fact]
    public void CanInstantiateConfigurationEmpty()
    {
        Configuration configuration = new Configuration();
    }
    [Fact]
    public void CanInstantiateConfiguration()
    {
        Collection<Particle> collectionParticle = new Collection<Particle>();
        collectionParticle.Add(new Particle(5, 7, 1, new Vector(1, 2)));
        collectionParticle.Add(new Particle(3, 15, 2, new Vector(10, -20)));
        Configuration configuration = new Configuration(25, 30, collectionParticle);
        Assert.Equal(25, configuration.Length);
        Assert.Equal(30, configuration.Width);
        Assert.Equal(2, configuration.Particles.Count);

        Assert.Equal(5, configuration.Particles[0].X);
        Assert.Equal(7, configuration.Particles[0].Y);
        Assert.Equal(1, configuration.Particles[0].Radius);
        Assert.Equal(1, configuration.Particles[0].Speed.X);
        Assert.Equal(2, configuration.Particles[0].Speed.Y);

        Assert.Equal(3, configuration.Particles[1].X);
        Assert.Equal(15, configuration.Particles[1].Y);
        Assert.Equal(2, configuration.Particles[1].Radius);
        Assert.Equal(10, configuration.Particles[1].Speed.X);
        Assert.Equal(-20, configuration.Particles[1].Speed.Y);
    }
    [Fact]
    public void CanInstantiateConfigurationCopy()
    {
        Collection<Particle> collectionParticle = new Collection<Particle>();
        collectionParticle.Add(new Particle(5, 7, 1, new Vector(1, 2)));
        collectionParticle.Add(new Particle(3, 15, 2, new Vector(10, -20)));
        Configuration configuration3 = new Configuration(25, 30, collectionParticle);
        Configuration configuration = new Configuration(configuration3);
        Assert.Equal(25, configuration.Length);
        Assert.Equal(30, configuration.Width);
        Assert.Equal(2, configuration.Particles.Count);

        Assert.Equal(5, configuration.Particles[0].X);
        Assert.Equal(7, configuration.Particles[0].Y);
        Assert.Equal(1, configuration.Particles[0].Radius);
        Assert.Equal(1, configuration.Particles[0].Speed.X);
        Assert.Equal(2, configuration.Particles[0].Speed.Y);

        Assert.Equal(3, configuration.Particles[1].X);
        Assert.Equal(15, configuration.Particles[1].Y);
        Assert.Equal(2, configuration.Particles[1].Radius);
        Assert.Equal(10, configuration.Particles[1].Speed.X);
        Assert.Equal(-20, configuration.Particles[1].Speed.Y);
    }
    #endregion

    #region Move
    [Fact]
    public void MoveTest1 ()
    {
        Collection<Particle> collectionParticle = new Collection<Particle>();
        collectionParticle.Add(new Particle(5, 7, 2, new Vector(1, 2)));
        Configuration configuration = new Configuration(25, 25, collectionParticle);
        configuration.Move(1);
        Assert.Equal(6, configuration.Particles[0].X);
        Assert.Equal(9, configuration.Particles[0].Y);
        configuration.Move(3);
        Assert.Equal(9, configuration.Particles[0].X);
        Assert.Equal(15, configuration.Particles[0].Y);
        configuration.Move(4);
        Assert.Equal(13, configuration.Particles[0].X);
        Assert.Equal(23, configuration.Particles[0].Y);
        configuration.Move(1);
        Assert.Equal(14, configuration.Particles[0].X);
        Assert.Equal(21, configuration.Particles[0].Y);
        configuration.Move(9);
        Assert.Equal(23, configuration.Particles[0].X);
        configuration.Move(1);
        Assert.Equal(22, configuration.Particles[0].X);
    }
    #endregion
}
