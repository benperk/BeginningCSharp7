using System;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BasicNavigation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();

            webViewControl.Navigate(new Uri("http://www.wrox.com"));
            Application.Current.Resuming += (sender, o) => webViewControl.Navigate(new Uri("https://www.amazon.com/s/ref=nb_sb_noss_2?url=search-alias%3Dstripbooks&field-keywords=Beginning+C%23+7+Programming+with+Visual+Studio+2017"));

        }

        private void buttonGoto2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BlankPage2));
        }
        private void buttonGoto3_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BlankPage3));
        }
        private void buttonGoBack_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack) this.Frame.GoBack();
        }

        private void AppBarButtonForward_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoForward) this.Frame.GoForward();
        }
        private void AppBarToggleButtonBold_Click(object sender, RoutedEventArgs e)
        {
            AppState.SetState(GetType().Name, (bool)toggleButtonBold.IsChecked);
            AppBarToggleButton toggleButton = sender as AppBarToggleButton;
            bool isChecked = toggleButton.IsChecked.HasValue ?
                             (bool)toggleButton?.IsChecked.Value : false;
            textBlockCaption.FontWeight = isChecked ? FontWeights.Bold : FontWeights.Normal;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            toggleButtonBold.IsChecked = AppState.GetState(GetType().Name);
            AppBarToggleButtonBold_Click(toggleButtonBold, new RoutedEventArgs());
        }

    }
}
