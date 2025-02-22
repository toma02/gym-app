using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BusinessLogicLayer;
using FoiFitness;
using System.Numerics;

namespace UnitTests
{
    public class YoutubeAPI_Tests
    {
        readonly string defaultYoutubeVideoID = "aRz0QZc8TDE";
        [Fact]
        public void ExtractVideoId_GivenYouTubeVideoLinkDoesntExists_ReturnsDefaultYoutubeVideoID()
        {
            // Arrange
            string youtubeLink = "";
            YoutubeAPI youtubeAPI = new YoutubeAPI(youtubeLink);

            //Act
            string videoID = youtubeAPI.ExtractVideoId(youtubeLink);

            //Assert
            Assert.Equal(defaultYoutubeVideoID, videoID);
        }

        [Fact]
        public void ExtractVideoId_GivenDesktopYouTubeVideoLink_ReturnsExtractedYoutubeVideoID()
        {
            // Arrange
            string youtubeLink = "https://www.youtube.com/watch?v=4Y2ZdHCOXok";
            YoutubeAPI youtubeAPI = new YoutubeAPI(youtubeLink);

            //Act
            string videoID = youtubeAPI.ExtractVideoId(youtubeLink);

            //Assert
            Assert.Equal("4Y2ZdHCOXok", videoID);
        }

        [Fact]
        public void ExtractVideoId_GivenMobileYouTubeVideoLink_ReturnsExtractedYoutubeVideoID()
        {
            // Arrange
            string youtubeLink = "https://youtu.be/4Y2ZdHCOXok";
            YoutubeAPI youtubeAPI = new YoutubeAPI(youtubeLink);

            //Act
            string videoID = youtubeAPI.ExtractVideoId(youtubeLink);

            //Assert
            Assert.Equal("4Y2ZdHCOXok", videoID);
        }

        [Fact]
        public void ExtractVideoId_GivenDesktopYouTubeVideoLinkHasMistype_ReturnsDefaultYoutubeVideoID()
        {
            // Arrange
            string youtubeLink = "https://www.youtube.com/wath?v=4Y2ZdHCOXok";
            YoutubeAPI youtubeAPI = new YoutubeAPI(youtubeLink);

            //Act
            string videoID = youtubeAPI.ExtractVideoId(youtubeLink);

            //Assert
            Assert.Equal(defaultYoutubeVideoID, videoID);
        }

        [Fact]
        public void ExtractVideoId_GivenMobileYouTubeVideoLinkHasMistype_ReturnsDefaultYoutubeVideoID()
        {
            // Arrange
            string youtubeLink = "https://zoutu.be/4Y2ZdHCOXok";
            YoutubeAPI youtubeAPI = new YoutubeAPI(youtubeLink);

            //Act
            string videoID = youtubeAPI.ExtractVideoId(youtubeLink);

            //Assert
            Assert.Equal(defaultYoutubeVideoID, videoID);
        }

        [Fact]
        public void ExtractVideoId_GivenDesktopYouTubeVideoLinkNoID_ReturnsDefaultYoutubeVideoID()
        {
            // Arrange
            string youtubeLink = "https://www.youtube.com/watch?v=";
            YoutubeAPI youtubeAPI = new YoutubeAPI(youtubeLink);

            //Act
            string videoID = youtubeAPI.ExtractVideoId(youtubeLink);

            //Assert
            Assert.Equal(defaultYoutubeVideoID, videoID);
        }

        [Fact]
        public void ExtractVideoId_GivenMobileYouTubeVideoLinkNoID_ReturnsDefaultYoutubeVideoID()
        {
            // Arrange
            string youtubeLink = "https://youtu.be/";
            YoutubeAPI youtubeAPI = new YoutubeAPI(youtubeLink);

            //Act
            string videoID = youtubeAPI.ExtractVideoId(youtubeLink);

            //Assert
            Assert.Equal(defaultYoutubeVideoID, videoID);
        }

        [Fact]
        public void ExtractVideoId_GivenNonYoutubeVideoLink_ReturnsDefaultYoutubeVideoID()
        {
            // Arrange
            string videoLink1 = "https://www.dailymotion.com/video/x8coadx";
            string videoLink2 = "https://www.tiktok.com/@jeremyethier/video/7220094812484095238";

            YoutubeAPI youtubeAPI = new YoutubeAPI(videoLink1);

            //Act
            string videoID1 = youtubeAPI.ExtractVideoId(videoLink1);
            string videoID2 = youtubeAPI.ExtractVideoId(videoLink2);

            //Assert
            Assert.Equal(defaultYoutubeVideoID, videoID1);
            Assert.Equal(defaultYoutubeVideoID, videoID2);
        }

        [Fact]
        public void GetThumbnail_GivenValidYouTubeVideoLink_ReturnsThumbnailLink()
        {
            // Arrange
            string youtubeLink = "https://www.youtube.com/watch?v=4Y2ZdHCOXok&ab_channel=JeremyEthier";
            YoutubeAPI youtubeAPI = new YoutubeAPI(youtubeLink);

            //Act
            string thumbnail = youtubeAPI.GetThumbnail();

            //Assert
            Assert.Equal("https://i.ytimg.com/vi/4Y2ZdHCOXok/hqdefault.jpg", thumbnail);
        }

        [Fact]
        public void GetThumbnail_GivenInValidYouTubeVideoLink_ReturnsThumbnailLinkOfDefaultVideo()
        {
            // Arrange
            string youtubeLink = "https://www.youtube.com/wath?v=4Y2ZdHCOXok&ab_channel=JeremyEthier";
            YoutubeAPI youtubeAPI = new YoutubeAPI(youtubeLink);

            //Act
            string thumbnail = youtubeAPI.GetThumbnail();

            //Assert
            Assert.Equal("https://i.ytimg.com/vi/aRz0QZc8TDE/hqdefault.jpg", thumbnail);
        }
    }
}
