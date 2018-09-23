using System.Xml.Linq;

namespace Walterlv.Rssman.Models
{
    /// <summary>
    /// 为 Outline Processor Markup Language 的元素提供基类。
    /// </summary>
    public abstract class OpmlModel : NotificationObject
    {
        public void Deserialize(XElement element)
        {
            OnDeserializing(element);
        }

        protected virtual void OnDeserializing(XElement element)
        {
        }
    }
}
