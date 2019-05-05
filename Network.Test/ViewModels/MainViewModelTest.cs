using Network.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xunit;

public class MainViewModelTest
{
    #region Constructor
    [Fact]
    public void CanInstantiateMainViewModel()
    {
        MainViewModel viewModel = new MainViewModel();
    }
    [Fact]
    public void DefaultState()
    {
        MainViewModel viewModel = new MainViewModel();
        Assert.Equal(State.NotBegin, viewModel.State);
        Assert.Equal(StateAction.NotBegin, viewModel.StateAction);
    }
    #endregion
    #region Command
    [Fact]
    public void CanExecuteToPlayCommand()
    {
        MainViewModel viewModel = new MainViewModel();
        ICommand commandToPlay = viewModel.ToPlay;        
        Assert.False(commandToPlay.CanExecute(null));
    }
    [Fact]
    public void CanExecuteToPauseCommand()
    {
        MainViewModel viewModel = new MainViewModel();
        ICommand commandToPause = viewModel.ToPause;
        Assert.False(commandToPause.CanExecute(null));
    }
    [Fact]
    public void CanExecuteToReStartCommand()
    {
        MainViewModel viewModel = new MainViewModel();
        ICommand commandToReStart = viewModel.ToReStart;
        Assert.True(commandToReStart.CanExecute(null));
        commandToReStart.Execute(null);
    }
    [Fact]
    public void ExecuteToReStartCommand()
    {
        MainViewModel viewModel = new MainViewModel();
        ICommand commandToReStart = viewModel.ToReStart;
        commandToReStart.Execute(null);
        Assert.Equal(State.Play, viewModel.State);
        Assert.Equal(StateAction.ReStart, viewModel.StateAction);
    }
    [Fact]
    public void RoutingState1()
    {
        MainViewModel viewModel = new MainViewModel();
        ICommand commandToReStart = viewModel.ToReStart;
        ICommand commandToPause = viewModel.ToPause;
        ICommand commandToPlay = viewModel.ToPlay;
        // тесты на начальные значения и возможные команды - проходятся ранее
        commandToReStart.Execute(null);
        // тест на изменение остояние после выполнения первой комманды - см ранее
        // проверяем возможные действия по автмату
        Assert.False(commandToPlay.CanExecute(null));
        Assert.False(commandToReStart.CanExecute(null));
        Assert.True(commandToPause.CanExecute(null));
        // выполняем переход по команде pause
        commandToPause.Execute(null);
        // проверяем в какие состояние ушли после выролнения операции Pusa
        Assert.Equal(State.Pause, viewModel.State);
        Assert.Equal(StateAction.Pause, viewModel.StateAction);
        // проверяем возможные действия по автмату
        Assert.True(commandToPlay.CanExecute(null));
        Assert.True(commandToReStart.CanExecute(null));
        Assert.False(commandToPause.CanExecute(null));
        // первый вариант - начинаем воспроизведение с предыдушего момента
        commandToPlay.Execute(null);
        // проверяем состояния после этого
        Assert.Equal(State.Play, viewModel.State);
        Assert.Equal(StateAction.Play, viewModel.StateAction);
    }
    [Fact]
    public void RoutingState2()
    {
        MainViewModel viewModel = new MainViewModel();
        ICommand commandToReStart = viewModel.ToReStart;
        ICommand commandToPause = viewModel.ToPause;
        ICommand commandToPlay = viewModel.ToPlay;
        // тесты на начальные значения и возможные команды - проходятся ранее
        commandToReStart.Execute(null);
        // тест на изменение остояние после выполнения первой комманды - см ранее
        // проверяем возможные действия по автмату
        Assert.False(commandToPlay.CanExecute(null));
        Assert.False(commandToReStart.CanExecute(null));
        Assert.True(commandToPause.CanExecute(null));
        // выполняем переход по команде pause
        commandToPause.Execute(null);
        // проверяем в какие состояние ушли после выролнения операции Pusa
        Assert.Equal(State.Pause, viewModel.State);
        Assert.Equal(StateAction.Pause, viewModel.StateAction);
        // проверяем возможные действия по автмату
        Assert.True(commandToPlay.CanExecute(null));
        Assert.True(commandToReStart.CanExecute(null));
        Assert.False(commandToPause.CanExecute(null));
        // второй вариант - начинаем воспроизведение с самотого начала
        commandToReStart.Execute(null);
        // проверяем состояния после этого
        Assert.Equal(State.Play, viewModel.State);
        Assert.Equal(StateAction.ReStart, viewModel.StateAction);
    }
    #endregion
}
