using Network.ViewModels;
using Network.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Network.UserControls
{
    /// <summary>
    /// Логика взаимодействия для MoveParticle.xaml
    /// </summary>
    public partial class MoveParticle : UserControl
    {
        public MoveParticle()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Коллекция шариков для дижения
        /// </summary>
        public ObservableCollection<ParticleGraphic> Source
        {
            get { return (ObservableCollection<ParticleGraphic>)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
        /// <summary>
        /// Коллекция шариков для дижения
        /// </summary>
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register(
                "Source", typeof(ObservableCollection<ParticleGraphic>), typeof(MoveParticle),
                new PropertyMetadata(new ObservableCollection<ParticleGraphic>(), (o, args) => ((MoveParticle)o).UpdateValues()));

        private enum TypeAction
        {
            /// <summary>
            /// Начала движени я с 0
            /// </summary>
            Begin,
            /// <summary>
            /// начало движения и предыдущего места
            /// </summary>
            Play,
            /// <summary>
            /// поуза в воспроизведении
            /// </summary>
            Pause
        };
        /// <summary>
        /// Формирование dataTrigger с соответствующм путём и значением
        /// </summary>
        /// <param name="propertyPath"></param>
        /// <param name="beginValue"></param>
        /// <returns></returns>
        private DataTrigger dataTriggerChangeState(PropertyPath propertyPath, object beginValue)
        {
            DataTrigger dataTrigger = new DataTrigger()
            {
                Binding = new Binding()
                {
                    Path = propertyPath
                }
            };
            dataTrigger.Value = beginValue;
            return dataTrigger;
        }
        /// <summary>
        /// Формирование комплпкса триггеров на изменение состояния StateAction на то или иное свойство
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        private Dictionary<TypeAction, DataTrigger> GetComplexTrigger(Shape shape)
        {
            // возвращаемая коллекцию триггеров
            Dictionary<TypeAction, DataTrigger> result = new Dictionary<TypeAction, DataTrigger>();
            // старт движения
            DataTrigger trigger = dataTriggerChangeState(new PropertyPath("StateAction"), StateAction.ReStart);
            result.Add(TypeAction.Begin, trigger);

            // возобновление движения
            trigger = dataTriggerChangeState(new PropertyPath("StateAction"), StateAction.Play);
            result.Add(TypeAction.Play, trigger);

            // приостановка движения
            trigger = dataTriggerChangeState(new PropertyPath("StateAction"), StateAction.Pause);
            result.Add(TypeAction.Pause, trigger);
            return result;
        }

        private BeginStoryboard GetBeginStoryboard(Shape shape, int timeMove, ParticleGraphic particle = null)
        {            
            // наше движение
            // вычисление пути
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = particle.StartPoint;
            PolyLineSegment pBezierSegment = new PolyLineSegment();

            foreach (Point point in particle.Points)
            {
                pBezierSegment.Points.Add(point);
            }

            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);
            // Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();

            // движение
            // поток движения
            Storyboard storyboard = new Storyboard();

            DoubleAnimationUsingPath animationX = new DoubleAnimationUsingPath()
            {
                PathGeometry = animationPath,
                Duration = new Duration(TimeSpan.FromSeconds(timeMove)),
                Source = PathAnimationSource.X
            };
            Storyboard.SetTarget(animationX, shape);
            Storyboard.SetTargetProperty(animationX, new PropertyPath(Canvas.LeftProperty));
            storyboard.Children.Add(animationX);

            DoubleAnimationUsingPath animationY = new DoubleAnimationUsingPath()
            {
                PathGeometry = animationPath,
                Duration = new Duration(TimeSpan.FromSeconds(timeMove)),
                Source = PathAnimationSource.Y,
            };
            Storyboard.SetTarget(animationY, shape);
            Storyboard.SetTargetProperty(animationY, new PropertyPath(Canvas.TopProperty));
            storyboard.Children.Add(animationY);
            storyboard.Name = "StoryboardMain";

            BeginStoryboard beginStoryboard = new BeginStoryboard();
            beginStoryboard.Storyboard = storyboard;
            beginStoryboard.Name = "begin" + storyboard.Name;
            return beginStoryboard;
        }
        /// <summary>
        /// движение для случаев, когда нам необходимо задать движение на изменение какого-нибудь поля
        /// </summary>
        /// <param name="type"></param>
        /// <param name="shape"></param>
        /// <param name="particle"></param>
        /// <returns></returns>
        private Dictionary<TypeAction, TriggerAction> GetComplexAction(Shape shape, int timeMove, ParticleGraphic particle)
        {
            // коллеция движений
            Dictionary<TypeAction, TriggerAction> result = new Dictionary<TypeAction, TriggerAction>();
            BeginStoryboard beginStoryboard = GetBeginStoryboard(shape, timeMove, particle);
            result.Add(TypeAction.Begin, beginStoryboard);
            PauseStoryboard pauseStoryboard = new PauseStoryboard() { BeginStoryboardName = beginStoryboard.Name };
            result.Add(TypeAction.Pause, pauseStoryboard);
            ResumeStoryboard resumeStoryboard = new ResumeStoryboard() { BeginStoryboardName = beginStoryboard.Name };
            result.Add(TypeAction.Play, resumeStoryboard);
            return result;
        }

        void UpdateValues()
        {
            foreach (ParticleGraphic particle in this.Source)
            {
                // сам элемент для отрисовки
                Ellipse ellipse = new Ellipse();
                // изначальное положение частицы
                ellipse.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                ellipse.Width = particle.Radius * 2;
                ellipse.Height = particle.Radius * 2;
                Canvas.SetTop(ellipse, particle.StartPoint.Y);
                Canvas.SetLeft(ellipse, particle.StartPoint.X);

                var style = new Style(typeof(Ellipse));


                Dictionary<TypeAction, TriggerAction> actions = GetComplexAction(ellipse, 10, particle);
                Dictionary<TypeAction, DataTrigger> triggers = GetComplexTrigger(ellipse);
                // инициатор движения
                TriggerAction triggerAction;
                if (!actions.TryGetValue(TypeAction.Begin, out triggerAction) || triggerAction == null || !triggerAction.GetType().Equals(typeof(BeginStoryboard)))
                    return;
                style.RegisterName(((BeginStoryboard)triggerAction).Name, ((BeginStoryboard)triggerAction));
                foreach (KeyValuePair<TypeAction, DataTrigger> pair in triggers)
                {
                    TriggerAction action = null;
                    if (actions.TryGetValue(pair.Key, out action) && action != null)
                    {
                        pair.Value.EnterActions.Add(action);
                    }
                    style.Triggers.Add(pair.Value);
                }
                // подключение триггера к стилю создаваемого объекта

                ellipse.Style = style;
                
                MyCanva.Children.Add(ellipse);
            }
        }

    }
}
