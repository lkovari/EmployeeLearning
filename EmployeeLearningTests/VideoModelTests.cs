using EmployeeLearning.model.video;
using FluentAssertions;

namespace EmployeeLearningTests
{
    public class VideoModelTests
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
        private static void VideoContentNotNullTest(Video video)
        {
            video.Name.Should().NotBeNull();
            video.Id.Should().NotBe(null);
        }

        private static void VideoContentMatchedTest(Video video)
        {
            video.Name.Should().Be(EXPECTED_NAME);
            video.Id.Should().Be(EXPECTED_ID);
        }
        #endregion

        [Test]
        public void TestVideoInstanceCreated()
        {
            Video video = new(TEST_ID, TEST_NAME);
            video.Should().NotBeNull();
        }

        #region PUBLIC METHODS
        [Test]
        public void TestVideoContentNotNull()
        {
            TestVideoInstanceCreated();
            Video video = new(TEST_ID, TEST_NAME);
            video.Should().NotBeNull();
            VideoContentNotNullTest(video);
        }

        [Test]
        public void TestVideoContentMatched()
        {
            Video video = new(TEST_ID, TEST_NAME);
            video.Should().NotBeNull();
            VideoContentNotNullTest(video);
            VideoContentMatchedTest(video);
        }

        [Test]
        public void TestMarkVideoAsWatched()
        {
            Video? video = new(TEST_ID, TEST_NAME);
            video.MarkAsWatched();
            video.IsWatched.Should().Be(true);
        }

        [Test]
        public void TestMarkVideoAsUnWatched()
        {
            Video? video = new(TEST_ID, TEST_NAME);
            video.MarkAsUnWatched();
            video.IsWatched.Should().Be(false);
        }

        [Test]
        public void TestMarkVideoLastSeenDateCleared()
        {
            Video? video = new(TEST_ID, TEST_NAME);
            video.MarkAsUnWatched();
            video.Watched.Should().BeNull();
        }

        [Test]
        public void TestVideoSeenDate()
        {
            Video? video = new(TEST_ID, TEST_NAME);
            video.MarkAsWatched();
            video.Watched.Should().NotBeNull();
        }

        [Test]
        public void TestVideoInstanceNotCreated()
        {
            Video? video = null;
            video.Should().BeNull();
        }
        #endregion
    }
}