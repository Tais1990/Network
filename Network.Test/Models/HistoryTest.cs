using Network.Models;
using System.Collections.ObjectModel;
using Xunit;

public class HistoryTest
{
    #region Constructor
    [Fact]
    public void CanInstantiateHistoryEmpty()
    {
        History history = new History();
    }

    #endregion
}
