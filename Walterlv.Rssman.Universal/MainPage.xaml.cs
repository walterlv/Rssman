using System.IO;
using Windows.ApplicationModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Walterlv.Rssman.Services;

namespace Walterlv.Rssman
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            var folder = Package.Current.InstalledLocation;
            using (var stream = await folder.OpenStreamForReadAsync("sample-opml.xml"))
            {
                var opml = await Opml.ParseAsync(stream);
            }
        }
    }
}
