using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace KarliCards.Gui
{
    public partial class OptionsWindow : Window
    {
        private GameOptions gameOptions;

        public OptionsWindow()
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
        }

        private void dumbAIRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            gameOptions.ComputerSkill = ComputerSkillLevel.Dumb;
        }

        private void goodAIRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            gameOptions.ComputerSkill = ComputerSkillLevel.Good;
        }

        private void cheatingAIRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            gameOptions.ComputerSkill = ComputerSkillLevel.Cheats;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
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
