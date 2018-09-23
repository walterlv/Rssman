using System.ComponentModel;
using System.Runtime.CompilerServices;
using Walterlv.Rssman.Annotations;

namespace Walterlv.Rssman.Models
{
    /// <summary>
    /// 为 Outline Processor Markup Language 的元素提供基类。
    /// </summary>
    public abstract class OpmlModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected void SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return;
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [NotifyPropertyChangedInvocator]
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
