using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BasicNavigation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage2 : Page
    {
        public BlankPage2()
        {
            this.InitializeComponent();
        }

        private void buttonGoto1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BlankPage1));
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
            AppBarToggleButton toggleButton = sender as AppBarToggleButton;
            bool isChecked = toggleButton.IsChecked.HasValue ?
                             (bool)toggleButton?.IsChecked.Value : false;
            textBlockCaption.FontWeight = isChecked ? FontWeights.Bold : FontWeights.Normal;
        }

    }
}
