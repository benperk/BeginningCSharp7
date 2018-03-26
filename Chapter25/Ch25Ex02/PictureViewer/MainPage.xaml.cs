using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage.Search;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Popups;
using System.Linq;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PictureViewer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IList<ImageProperties> imageProperties = new List<ImageProperties>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void GetFiles()
        {
            try
            {
                StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
                IReadOnlyList<StorageFile> sortedItems = await picturesFolder.GetFilesAsync(CommonFileQuery.OrderByDate);
                var images = new List<BitmapImage>();
                if (sortedItems.Any())
                {
                    foreach (StorageFile file in sortedItems)
                    {
                        if (file.FileType.ToUpper() == ".JPG")
                        {
                            using (Windows.Storage.Streams.IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
                            {
                                BitmapImage bitmapImage = new BitmapImage();
                                await bitmapImage.SetSourceAsync(fileStream);
                                images.Add(bitmapImage);
                                imageProperties.Add(new ImageProperties
                                {
                                    FileName = file.DisplayName,
                                    Height = bitmapImage.PixelHeight,
                                    Width = bitmapImage.PixelWidth
                                });
                                if (imageProperties.Count > 10)
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    var message = new MessageDialog("There are no images in the Pictures Library");
                    await message.ShowAsync();
                }
                flipView.ItemsSource = images;
            }
            catch (UnauthorizedAccessException)
            {
                var message = new MessageDialog("The app does not have access to the Pictures Library on this device.");
                await message.ShowAsync();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetFiles();
        }

        private void flipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (flipView.SelectedIndex >= 0)
            {
                textBlockCurrentImageDisplayName.Text = imageProperties[flipView.SelectedIndex].FileName;
                textBlockCurrentImageImageHeight.Text = imageProperties[flipView.SelectedIndex].Height.ToString();
                textBlockCurrentImageImageWidth.Text = imageProperties[flipView.SelectedIndex].Width.ToString();
            }
        }

    }
}
