using Newtonsoft.Json;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoiFitness
{
    public class YoutubeAPI
    {
        private const string V = "AIzaSyDh7nFmWqdyRMphQ-tpRwhXbqW0d5NhF1M";

        private string apiKey { get; set; }
        private string apiUrl { get; set; }
        private string videoID { get; set; }

        public YoutubeAPI(string videolink)
        {
            apiKey = V;
            videoID = ExtractVideoId(videolink);
            apiUrl = $"https://www.googleapis.com/youtube/v3/videos?id={videoID}&key={apiKey}&part=snippet";
        }

        public string ExtractVideoId(string youtubeLink)
        {
            string defaultVideoId = "aRz0QZc8TDE";
            string videoId;
            const string desktopLink = "youtube.com/watch?v=";
            const string mobileLink = "youtu.be/";
            if (youtubeLink.Contains(desktopLink))
            {
                videoId = youtubeLink.Substring(youtubeLink.IndexOf(desktopLink) + desktopLink.Length);
                if (videoId.Length > 10)
                    return videoId;
            }
            else if (youtubeLink.Contains(mobileLink))
            {
                videoId = youtubeLink.Substring(youtubeLink.IndexOf(mobileLink) + mobileLink.Length);
                if (videoId.Length > 10)
                    return videoId;
            }
            return defaultVideoId;
            
        }

        public string GetThumbnail()
        {
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(apiUrl);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                dynamic data = JsonConvert.DeserializeObject(json);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                string thumbnailUrl = data.items[0].snippet.thumbnails.high.url;
                return thumbnailUrl;
            }
        }
    }
}
