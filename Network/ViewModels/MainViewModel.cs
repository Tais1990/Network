using Network.Models;
using Network.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.ViewModels
{
    /// <summary>
    /// состояние системы
    /// </summary>
    public enum State { NotBegin, Play, Pause }
    /// <summary>
    ///  переход между состояниями системы
    /// </summary>
    public enum StateAction { ReStart, Play, Pause, NotBegin }

    public class MainViewModel : BaseVM
    {
        #region States, function, command
        /// <summary>
        /// переход между состояниями системы
        /// </summary>        
        public StateAction StateAction { get; set; }
        /// <summary>
        /// состояние системы
        /// </summary>
        private State _state;
        /// <summary>
        /// состояние системы
        /// </summary>
        public State State
        {
            get { return _state; }
            set
            {
                _state = value;
                RaisePropertyChanged("State");
                RaisePropertyChanged("OnMove");
                RaisePropertyChanged("StateAction");
            }
        }
        public bool OnMove => State.Equals(State.Play);
        public DelegateCommand ToPlay
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    // вычисление состояния перехода
                    this.StateAction = StateAction.Play;
                    // само состояние
                    this.State = State.Play;
                },
                (obj) => this.State.Equals(State.Pause));
            }
        }
        public DelegateCommand ToPause
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    // вычисление состояния перехода
                    this.StateAction = StateAction.Pause;
                    // само состояние
                    this.State = State.Pause;
                },
                (obj) => this.State.Equals(State.Play));
            }
        }
        public DelegateCommand ToReStart
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    // вычисление состояния перехода
                    this.StateAction = StateAction.ReStart;
                    // само состояние
                    this.State = State.Play;
                },
                (obj) => (this.State.Equals(State.Pause) || this.State.Equals(State.NotBegin)));
            }
        }
        #endregion

        
        private Collection<ParticleGraphic> particleGraphics = new Collection<ParticleGraphic>();
        public ObservableCollection<ParticleGraphic> ParticleGraphics => new ObservableCollection<ParticleGraphic>(particleGraphics);

        public MainViewModel()
        {
            this.State = State.NotBegin;
            this.StateAction = StateAction.NotBegin;

            Configuration configuration = new Configuration();
            double coefficient = 350 / configuration.length;
            foreach (Particle particle in configuration.particles)
            {
                this.particleGraphics.Add(new ParticleGraphic(particle, coefficient));
            }
        }
    }
}
