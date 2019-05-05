using Network.Models;
using System;
using System.Collections.Generic;
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

    class MainViewModel : BaseVM
    {
        #region States and function
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


        public MainViewModel()
        {
            this.State = State.NotBegin;
            this.StateAction = StateAction.NotBegin;
        }
    }
}
