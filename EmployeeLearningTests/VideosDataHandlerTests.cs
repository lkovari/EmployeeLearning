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
            videosDataHandler.getAllVideos().Should().NotBeNull();
            videosDataHandler.getAllVideos().Count.Should().BeGreaterThan(NUMBER_OF_VIDEOS_COUNT_ZERO);
        }

        [Test]
        public void VideosDataHandlerAddVideoTest()
        {
            videosDataHandler.Should().NotBeNull();
            videosDataHandler.getAllVideos().Should().NotBeNull();
            int videoCountBeforeAdd = videosDataHandler.getAllVideos().Count;
            Video video = new("New Video");
            videosDataHandler.addVideo(video);
            int videoCountAfterAdd = videosDataHandler.getAllVideos().Count;
            videoCountAfterAdd.Should().BeGreaterThan(videoCountBeforeAdd);
            Video foundVideo = videosDataHandler.GetVideoById(video.Id);
            foundVideo.Should().BeSameAs(video);
        }

        [Test]
        public void VideosDataHandlerRemoveVideoTest()
        {
            videosDataHandler.Should().NotBeNull();
            videosDataHandler.getAllVideos().Should().NotBeNull();
            int videoCountBeforeRemove = videosDataHandler.getAllVideos().Count;
            Video videoToRemove = videosDataHandler.getAllVideos()[VIDEO_INDEX_ZERO];
            videosDataHandler.removeVideoById(videoToRemove.Id);
            int videoCountAfterRemove = videosDataHandler.getAllVideos().Count;
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
            videosDataHandler.getAllVideos().Should().NotBeNull();
            int videoCount = videosDataHandler.getAllVideos().Count;
            videoCount.Should().Be(VideoTestDataProvider.Instance.Videos.Count);
        }

        [Test]
        public void VideosDataHandlerGetVideoByIdTest()
        {
            videosDataHandler.Should().NotBeNull();
            Video videoToGet = videosDataHandler.getAllVideos()[VIDEO_INDEX_ZERO];
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
