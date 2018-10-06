using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using Windows.ApplicationModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Parsers.Rss;
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
        private readonly ObservableCollection<RssSchema> ArticleList = new ObservableCollection<RssSchema>();

        private async void RssListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ArticleList.Clear();

            if (RssListView.SelectedItem is RssOutline outline)
            {
                var list = await Rss.FetchAsync(outline.XmlUrl);
                foreach (var schema in list)
                {
                    ArticleList.Add(schema);
                }
            }
        }

        private void ArticleListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WebView.Navigate(new Uri("about:blank"));

            if (ArticleListView.SelectedItem is RssSchema schema)
            {
                WebView.Navigate(new Uri(schema.FeedUrl));
            }
        }
    }
}
