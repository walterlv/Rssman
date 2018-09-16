using System;
using System.Runtime.Serialization;

namespace Walterlv.Rssman.Model
{
    /// <summary>
    /// Model for RSS item
    /// </summary>
    [DataContract(IsReference = true)]
    public class RssItem
    {
        /// <summary>
        /// Property for item title
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Property for item summary
        /// </summary>
        [DataMember]
        public string Text { get; set; }

        /// <summary>
        /// Property for item URL
        /// </summary>
        [DataMember]
        public string Url { get; set; }

        /// <summary>
        /// Property for item timestamp
        /// </summary>
        [DataMember]
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// Property for item feed information
        /// </summary>
        [DataMember]
        public RssFeed Feed { get; set; }

        /// <summary>
        /// Image associated with the item
        /// </summary>
        /// [DataMember]
        public string Image;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title">Title of the item</param>
        /// <param name="text">Summary of the item</param>
        /// <param name="url">URL of the item</param>
        /// <param name="date">Timestamp of the item</param>
        /// <param name="feed">Feed information</param>
        /// <param name="image">Image associated with the item</param>
        public RssItem(string title, string text, string url, DateTimeOffset date, RssFeed feed, string image)
        {
            Title = title;
            Text = text;
            Url = url;
            Timestamp = date;
            Feed = feed;
            Image = image;
        }
    }
}