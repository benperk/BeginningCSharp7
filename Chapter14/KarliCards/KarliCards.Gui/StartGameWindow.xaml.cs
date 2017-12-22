using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace KarliCards.Gui
{
    /// <summary>
    /// Interaction logic for StartGameWindow.xaml
    /// </summary>
    public partial class StartGameWindow : Window
    {
        private GameOptions gameOptions;

        public StartGameWindow()
        {
            if (gameOptions == null)
            {
                if (File.Exists("GameOptions.xml"))
                {
                    using (var stream = File.OpenRead("GameOptions.xml"))
                    {
                        var serializer = new XmlSerializer(typeof(GameOptions));
                        gameOptions = serializer.Deserialize(stream) as GameOptions;
                    }
                }
                else
                    gameOptions = new GameOptions();
            }
            DataContext = gameOptions;
            InitializeComponent();

            if (gameOptions.PlayAgainstComputer)
                playerNamesListBox.SelectionMode = SelectionMode.Single;
            else
                playerNamesListBox.SelectionMode = SelectionMode.Extended;

        }

        private void playerNamesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gameOptions.PlayAgainstComputer)
                okButton.IsEnabled = (playerNamesListBox.SelectedItems.Count == 1);
            else
                okButton.IsEnabled = (playerNamesListBox.SelectedItems.Count ==
        gameOptions.NumberOfPlayers);
        }

        private void addNewPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(newPlayerTextBox.Text))
                gameOptions.AddPlayer(newPlayerTextBox.Text);
            newPlayerTextBox.Text = string.Empty;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (string item in playerNamesListBox.SelectedItems)
            {
                gameOptions.SelectedPlayers.Add(item);
            }

            using (var stream = File.Open("GameOptions.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(GameOptions));
                serializer.Serialize(stream, gameOptions);
            }
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            gameOptions = null;
            Close();
        }

    }
}
