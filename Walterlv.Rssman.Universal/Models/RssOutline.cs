using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Walterlv.Rssman.Models
{
    [DebuggerDisplay("RssOutline {Text,nq}, {XmlUrl,nq}, Count={Children.Count,nq}")]
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

        public bool HasChildren => Children.Any();

        public ObservableCollection<RssOutline> Children { get; } = new ObservableCollection<RssOutline>();

        protected override void OnDeserializing(XElement element)
        {
            var text = element.Attribute("text");
            Text = text?.Value;

            var type = element.Attribute("type");
            if (type != null && Enum.TryParse(type.Value, out OutlineType outlineType))
            {
                Type = outlineType;
            }

            var xmlUrl = element.Attribute("xmlUrl");
            XmlUrl = xmlUrl?.Value;

            var htmlUrl = element.Attribute("htmlUrl");
            HtmlUrl = htmlUrl?.Value;

            var outlines = element.XPathSelectElements("outline");
            Children.Clear();
            foreach (var value in outlines)
            {
                var outline = new RssOutline();
                outline.Deserialize(value);
                Children.Add(outline);
            }
        }
    }
}
