using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Walterlv.Rssman.Model
{
    /// <summary>
    /// A single RSS feed
    /// </summary>
    [DataContract(IsReference = true)]
    public class RssFeed : INotifyPropertyChanged
    {
        /// <summary>
        /// Implementation of PropertyChanged event declared in INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Property for URL of the feed
        /// </summary>
        [DataMember]
        public string Url { get; set; }

        /// <summary>
        /// Class member for image URL of the feed
        /// </summary>
        private string _imageUrl;

        /// <summary>
        /// Property for image URL of the feed
        /// </summary>
        [DataMember]
        public string ImageUrl
        {
            get
            {
                return _imageUrl;
            }
            set
            {
                if (_imageUrl != value)
                {
                    _imageUrl = value;
                    OnPropertyChanged("ImageURL");
                }
            }
        }

        /// <summary>
        /// The title of the feed
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// A list of items for this feed
        /// </summary>
        [DataMember]
        public List<RssItem> Items { get; set; }

        /// <summary>
        /// The timestamp this feed was last refreshed
        /// Used when checking if cache can be used or
        /// should the feed be refreshed
        /// </summary>
        [DataMember]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Whether the feed is visible on the RSSPage or not
        /// </summary>
        [DataMember]
        public bool IsVisible { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public RssFeed()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url">URL of the feed</param>
        /// <param name="title">Title of the feed</param>
        public RssFeed(string url, string title)
        {
            this.Url = url;
            this.Title = title;
            this.Items = new List<RssItem>();
        }

        /// <summary>
        /// Helper method for PropertyChanged event
        /// </summary>
        /// <param name="changed">Name of the property that has changed</param>
        protected virtual void OnPropertyChanged(string changed)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(changed));
            }
        }
    }
}
