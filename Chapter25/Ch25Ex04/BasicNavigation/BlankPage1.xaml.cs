using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
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

    }
}
