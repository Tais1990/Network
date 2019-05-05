using Network.Models;
using Network.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xunit;

public class ParticleGraphicTest
{
    #region Constructor
    [Fact]
    public void CanInstantiateParticleGraphicRendom()
    {
        ParticleGraphic particleGraphic = new ParticleGraphic(new Particle(), 10);
    }
    [Fact]
    public void CanInstantiateParticleGraphic()
    {
        ParticleGraphic particleGraphic = new ParticleGraphic(new Particle(20, 30, 5), 10);        
        Assert.Equal(150, particleGraphic.StartPoint.X);
        Assert.Equal(250, particleGraphic.StartPoint.Y);
        Assert.Equal(50, particleGraphic.Radius);
    }
    #endregion
}
