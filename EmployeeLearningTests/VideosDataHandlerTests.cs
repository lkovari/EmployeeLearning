using EmployeeLearning.adapters.displayvideos;
using EmployeeLearning.datahandler.videos;
using EmployeeLearning.model.video;
using EmployeeLearning.testdata.idprovider;
using EmployeeLearning.testdata.videostore;
using FluentAssertions;

namespace EmployeeLearningTests
{
    public class VideosDataHandlerTests
    {
        #region CONSTANTS
        private readonly int NUMBER_OF_VIDEOS_COUNT_ZERO = 0;
        private readonly int VIDEO_INDEX_ZERO = 0;
        #endregion

        #region DATA HANDLER
        private VideosDataHandler videosDataHandler;
        #endregion

        #region INITIALIZE
        [SetUp]
        public void Setup()
        {
            videosDataHandler = new(VideoTestDataProvider.Instance.Videos,
                new DisplayVideosConsoleAdapter());
        }
        #endregion

        #region TEST METHODS
        [Test]
        public void VideosDataHandlerNotNullTest()
        {
            videosDataHandler.Should().NotBeNull();
        }

        [Test]
        public void VideosDataHandlerVideosExistsTest()
        {
            videosDataHandler.Should().NotBeNull();
            videosDataHandler.GetAllVideos().Should().NotBeNull();
            videosDataHandler.GetAllVideos().Count.Should().BeGreaterThan(NUMBER_OF_VIDEOS_COUNT_ZERO);
        }

        [Test]
        public void VideosDataHandlerAddVideoTest()
        {
            videosDataHandler.Should().NotBeNull();
            videosDataHandler.GetAllVideos().Should().NotBeNull();
            int videoCountBeforeAdd = videosDataHandler.GetAllVideos().Count;
            Video video = new("New Video");
            videosDataHandler.AddVideo(video);
            int videoCountAfterAdd = videosDataHandler.GetAllVideos().Count;
            videoCountAfterAdd.Should().BeGreaterThan(videoCountBeforeAdd);
            Video foundVideo = videosDataHandler.GetVideoById(video.Id);
            foundVideo.Should().BeSameAs(video);
        }

        [Test]
        public void VideosDataHandlerRemoveVideoTest()
        {
            videosDataHandler.Should().NotBeNull();
            videosDataHandler.GetAllVideos().Should().NotBeNull();
            int videoCountBeforeRemove = videosDataHandler.GetAllVideos().Count;
            Video videoToRemove = videosDataHandler.GetAllVideos()[VIDEO_INDEX_ZERO];
            videosDataHandler.RemoveVideoById(videoToRemove.Id);
            int videoCountAfterRemove = videosDataHandler.GetAllVideos().Count;
            videoCountAfterRemove.Should().BeLessThan(videoCountBeforeRemove);
            Action action = () =>
            {
                Video foundVideo = videosDataHandler.GetVideoById(videoToRemove.Id);
            };
            action.Should().Throw<Exception>();
        }

        [Test]
        public void VideosDataHandlerGetAllVideosTest()
        {
            videosDataHandler.Should().NotBeNull();
            videosDataHandler.GetAllVideos().Should().NotBeNull();
            int videoCount = videosDataHandler.GetAllVideos().Count;
            videoCount.Should().Be(VideoTestDataProvider.Instance.Videos.Count);
        }

        [Test]
        public void VideosDataHandlerGetVideoByIdTest()
        {
            videosDataHandler.Should().NotBeNull();
            Video videoToGet = videosDataHandler.GetAllVideos()[VIDEO_INDEX_ZERO];
            Video foundVideo = videosDataHandler.GetVideoById(videoToGet.Id);
            foundVideo.Should().BeSameAs(videoToGet);
        }

        [Test]
        public void VideosDataHandlerGetVideoByIdFailedTest()
        {
            videosDataHandler.Should().NotBeNull();
            Action action = () =>
            {
                Video foundVideo = videosDataHandler.GetVideoById(IdProvider.Instance.NewId);
            };
            action.Should().Throw<Exception>();
        }

        #endregion
    }
}
