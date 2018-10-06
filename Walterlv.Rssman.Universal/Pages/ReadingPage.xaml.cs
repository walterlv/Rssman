using System.Collections.ObjectModel;
using System.IO;
using Windows.ApplicationModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Walterlv.Rssman.Models;
using Walterlv.Rssman.Services;

namespace Walterlv.Rssman.Pages
{
    public sealed partial class ReadingPage : Page
    {
        public ReadingPage()
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

        private readonly ObservableCollection<RssOutline> RssList = new ObservableCollection<RssOutline>();
        private readonly ObservableCollection<RssOutline> ArticleList = new ObservableCollection<RssOutline>();
    }
}
