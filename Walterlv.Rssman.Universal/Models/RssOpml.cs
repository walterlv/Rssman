using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Walterlv.Rssman.Models
{
    [DebuggerDisplay("RssOpml {Title,nq}, Count={Children.Count,nq}")]
    public sealed class RssOpml : OpmlModel
    {
        private string _title;

        public string Title
        {
            get => _title;
            set => SetValue(ref _title, value);
        }

        public ObservableCollection<RssOutline> Children { get; } = new ObservableCollection<RssOutline>();

        protected override void OnDeserializing(XElement element)
        {
            var title = element.XPathSelectElement("head/title");
            Title = title?.Value;

            var outlines = element.XPathSelectElements("body/outline");
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
