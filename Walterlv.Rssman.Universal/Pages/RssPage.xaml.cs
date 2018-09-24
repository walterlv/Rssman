using System.Collections.ObjectModel;
using System.IO;
using Windows.ApplicationModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Walterlv.Rssman.Models;
using Walterlv.Rssman.Services;

namespace Walterlv.Rssman.Pages
{
    public sealed partial class RssPage : Page
    {
        public RssPage()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            var folder = Package.Current.InstalledLocation;
            using (var stream = await folder.OpenStreamForReadAsync("sample-opml.xml"))
            {
                var opml = await Opml.ParseAsync(stream);
                var outlines = opml.GetOutlines();
                RssList.Clear();
                foreach (var outline in outlines)
                {
                    RssList.Add(outline);
                }
            }
        }

        private ObservableCollection<RssOutline> RssList { get; } = new ObservableCollection<RssOutline>();
    }
}
