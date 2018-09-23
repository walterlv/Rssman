using System.Collections.ObjectModel;

namespace Walterlv.Rssman.Models
{
    public sealed class RssOpml : OpmlModel
    {
        private string _title;

        public string Title
        {
            get => _title;
            set => SetValue(ref _title, value);
        }

        public ObservableCollection<RssOutline> Children { get; } = new ObservableCollection<RssOutline>();
    }
}
