using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Walterlv.Rssman
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
