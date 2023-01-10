using EmployeeLearning.model.video;
using FluentAssertions;
using FluentAssertions.Execution;

namespace EmployeeLearningTests
{
    public class VideoTests
    {
        #region CONSTANTS
        private static readonly int TEST_ID = 1;
        private static readonly string TEST_NAME = "Ethics";
        private static readonly int EXPECTED_ID = 1;
        private static readonly string EXPECTED_NAME = "Ethics";
        #endregion

        [SetUp]
        public void Setup()
        {
        }
        
        #region PRIVATE METHODS
        private static void VideoInstanceNotNullTest(Video video)
        {
            video.Name.Should().NotBeNull();
            video.Id.Should().NotBe(null);
        }

        private static void VideoPropertiesTest(Video video)
        {
            video.Name.Should().Be(EXPECTED_NAME);
            video.Id.Should().Be(EXPECTED_ID);
        }
        #endregion

        [Test]
        public void VideoInstanceIsCreatedTest()
        {
            Video video = new(TEST_ID, TEST_NAME);
            video.Should().NotBeNull();
        }

        #region PUBLIC METHODS
        [Test]
        public void VideoContentNotNullTest()
        {
            Video video = new(TEST_ID, TEST_NAME);
            video.Should().NotBeNull();
            VideoInstanceNotNullTest(video);
            VideoPropertiesTest(video);
        }

        [Test]
        public void VideoContentValidityTest()
        {
            Video video = new(TEST_ID, TEST_NAME);
            video.Should().NotBeNull();
            VideoInstanceNotNullTest(video);
            VideoPropertiesTest(video);
        }

        [Test]
        public void MarkVideoAsWatchedTest()
        {
            Video? video = new(TEST_ID, TEST_NAME);
            video.MarkAsWatched();
            video.IsWatched.Should().Be(true);
        }

        [Test]
        public void MarkVideoAsUnwatchedTest()
        {
            Video? video = new(TEST_ID, TEST_NAME);
            video.MarkAsUnWatched();
            video.WatchDate.Should().BeNull();
        }

        [Test]
        public void VideoSeenDateTest()
        {
            Video? video = new(TEST_ID, TEST_NAME);
            video.MarkAsWatched();
            video.WatchDate.Should().NotBeNull();
        }

        [Test]
        public void InstanceNotCreatedTest()
        {
            Video? video = null;
            video.Should().BeNull();
        }

        [Test]
        public void EmptyNamePaarameterTest()
        {
            Video? video = new(TEST_ID, String.Empty);
            video.Name.Should().Be(String.Empty);
        }

        #endregion
    }
}