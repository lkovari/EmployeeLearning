using EmployeeLearning.controller.video;
using EmployeeLearning.model.employee;
using EmployeeLearning.model.video;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Numeric;

namespace EmployeeLearningTests
{
    public class VideoTests
    {
        #region CONSTANTS
        private static readonly string TEST_NAME = "Ethics";
        private static readonly string EXPECTED_NAME = "Ethics";
        private static readonly int EXPECTED_RESULT_WATCHED_ZERO_TIMES = 0;
        private static readonly int EXPECTED_RESULT_WATCHED_ONE_TIMES = 1;
        private static readonly int EXPECTED_RESULT_WATCHED_TWO_TIMES = 2;
        #endregion

        private VideoDataHandler videoDataHandler;

        #region INITIALIZE
        [SetUp]
        public void Setup()
        {
            videoDataHandler = new(new(TEST_NAME));
        }
        #endregion

        #region TEST METHODS
        [Test]
        public void VideoInstanceNotNullTest()
        {
            videoDataHandler.Video.Name.Should().NotBeNull();
        }

        [Test]
        public void VideoNamePropertyTest()
        {
            videoDataHandler.Video.Name.Should().Be(EXPECTED_NAME);
        }

        [Test]
        public void MarkVideoAsWatchedTest()
        {
            videoDataHandler.VideoMarkAsWatched();
            videoDataHandler.Video.IsWatched.Should().Be(true);
        }

        [Test]
        public void MarkVideoAsUnwatchedTest()
        {
            videoDataHandler.VideoMarkAsWatched();
            videoDataHandler.Video.IsWatched.Should().Be(true);
            videoDataHandler.VideoMarkAsUnWatched();
            videoDataHandler.Video.IsWatched.Should().Be(false);
        }

        [Test]
        public void VideoWatchCountTest()
        {
            videoDataHandler.VideoMarkAsWatched();
            videoDataHandler.VideoMarkAsWatched();
            videoDataHandler.Video.IsWatched.Should().Be(true);
            videoDataHandler.Video.WatchCount.Should().Be(EXPECTED_RESULT_WATCHED_TWO_TIMES);
        }

        [Test]
        public void AfterUnwatchedVideoWatchCountTest()
        {
            videoDataHandler.VideoMarkAsWatched();
            videoDataHandler.Video.IsWatched.Should().Be(true);
            videoDataHandler.Video.WatchCount.Should().Be(EXPECTED_RESULT_WATCHED_ONE_TIMES);
            videoDataHandler.VideoMarkAsUnWatched();
            videoDataHandler.Video.WatchCount.Should().Be(EXPECTED_RESULT_WATCHED_ZERO_TIMES);
        }

        [Test]
        public void VideoWatchDateTest()
        {
            videoDataHandler.VideoMarkAsWatched();
            videoDataHandler.Video.WatchDate.Should().NotBeNull();
        }

        [Test]
        public void AfterUnwatchVideoWatchDateTest()
        {
            videoDataHandler.VideoMarkAsWatched();
            videoDataHandler.Video.WatchDate.Should().NotBeNull();
            videoDataHandler.VideoMarkAsUnWatched();
            videoDataHandler.Video.WatchDate.Should().BeNull();
        }

        [Test]
        public void VideoSeenDateTest()
        {
            videoDataHandler.VideoMarkAsUnWatched();
            videoDataHandler.Video.WatchDate.Should().BeNull();
        }
        #endregion
    }
}