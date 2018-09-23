using System.Collections.ObjectModel;

namespace Walterlv.Rssman.Models
{
    public sealed class RssOutline : OpmlModel
    {
        private string _text;
        private OutlineType _type;
        private string _xmlUrl;
        private string _htmlUrl;

        public string Text
        {
            get => _text;
            set => SetValue(ref _text, value);
        }

        private string Title
        {
            get => _text;
            set => SetValue(ref _text, value);
        }

        public OutlineType Type
        {
            get => _type;
            set => SetValue(ref _type, value);
        }

        public string XmlUrl
        {
            get => _xmlUrl;
            set => SetValue(ref _xmlUrl, value);
        }

        public string HtmlUrl
        {
            get => _htmlUrl;
            set => SetValue(ref _htmlUrl, value);
        }

        public ObservableCollection<RssOutline> Children { get; } = new ObservableCollection<RssOutline>();
    }
}
