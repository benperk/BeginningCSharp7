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
            InitializeComponent();
            DataContextChanged += StartGame_DataContextChanged;
        }


        private void ChangeListBoxOptions()
        {
            if (gameOptions.PlayAgainstComputer)
                playerNamesListBox.SelectionMode = SelectionMode.Single;
            else
                playerNamesListBox.SelectionMode = SelectionMode.Extended;
        }
        void StartGame_DataContextChanged(object sender,
DependencyPropertyChangedEventArgs e)
        {
            gameOptions = DataContext as GameOptions;
            ChangeListBoxOptions();
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
            var gameOptions = DataContext as GameOptions;
            gameOptions.SelectedPlayers = new List<string>();
            foreach (string item in playerNamesListBox.SelectedItems)
            {
                gameOptions.SelectedPlayers.Add(item);
            }
            this.DialogResult = true;
            this.Close();
        }


        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            gameOptions = null;
            Close();
        }

    }
}
