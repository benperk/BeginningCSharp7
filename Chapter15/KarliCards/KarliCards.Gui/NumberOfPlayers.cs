using System.Collections.ObjectModel;

namespace KarliCards.Gui
{
    public class NumberOfPlayers : ObservableCollection<int>
    {
        public NumberOfPlayers()
          : base()
        {
            Add(2);
            Add(3);
            Add(4);
        }
    }
}
