using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;
using FluentAssertions;

namespace EmployeeLearningTests
{
    public class JobRoleTests
    {
        #region CONSTANTS
        private static readonly int VIDEO_COUNT = 5;
        private static readonly int VIDEO_TEST_ID = 1;
        private static readonly string VIDEO_TEST_NAME = "Ethics";
        private static readonly int VIDEO_EXPECTED_ID = 1;
        private static readonly string VIDEO_EXPECTED_NAME = "Ethics";
        private static readonly int JOBROLE_TEST_ID = 1;
        private static readonly int JOBROLE_EXPECTED_ID = 1;
        private static readonly string JOBROLE_TEST_NAME = "CTO";
        private static readonly string JOBROLE_EXPECTED_NAME = "CTO";
        private static readonly List<Video> videos = new();
        #endregion

        [SetUp]
        public void Setup()
        {
            for (int ix = 0; ix < VIDEO_COUNT; ix++)
            {
                videos.Add(new Video(VIDEO_TEST_ID + ix, VIDEO_TEST_NAME + ix));
            }
        }

        #region PRIVATE METHODS
        private static void JobRoleContentNotNull(JobRole jobRole)
        {
            jobRole.Should().NotBeNull();
            jobRole.Id.Should().NotBe(null);
            jobRole.Name.Should().NotBeNull();
            jobRole.LearningPath.Should().NotBeNull();
        }

        private static void JobRoleContentMatched(JobRole jobRole)
        {
            jobRole.Id.Should().Be(JOBROLE_EXPECTED_ID);
            jobRole.Name.Should().Be(JOBROLE_EXPECTED_NAME);
        }
        #endregion

        #region PUBLIC METHODS
        [Test]
        public void TestJobRoleInstanceCreated()
        {
            JobRole jobRole = new(JOBROLE_TEST_ID, JOBROLE_TEST_NAME, videos);
            jobRole.Should().NotBeNull();
        }

        [Test]
        public void TestJobRoleContentNotNull()
        {
            JobRole jobRole = new(JOBROLE_TEST_ID, JOBROLE_TEST_NAME, videos);
            JobRoleContentNotNull(jobRole);
        }

        [Test]
        public void TestJobRoleContentMatched()
        {
            JobRole jobRole = new(JOBROLE_TEST_ID, JOBROLE_TEST_NAME, videos);
            JobRoleContentNotNull(jobRole);
            JobRoleContentMatched(jobRole);

            for (int ix = 0; ix < jobRole.LearningPath.Count; ix++)
            {
                jobRole.LearningPath[ix].Should().NotBeNull();
                jobRole.LearningPath[ix].Id.Should().NotBe(null);
                jobRole.LearningPath[ix].Id.Should().Be(VIDEO_EXPECTED_ID + ix);
                jobRole.LearningPath[ix].Name.Should().NotBeNull();
                jobRole.LearningPath[ix].Name.Should().Be(VIDEO_EXPECTED_NAME + ix);
            }
        }

        [Test]
        public void TestJobRoleVideosMarkAllAsWatched()
        {
            JobRole jobRole = new(JOBROLE_TEST_ID, JOBROLE_TEST_NAME, videos);
            jobRole.LearningPath.Should().NotBeNull();
            jobRole.LearningPath.ForEach(v => v.MarkAsWatched());
            bool isWatched = true;
            jobRole.LearningPath.ForEach(v => isWatched = isWatched && v.IsWatched);
            isWatched.Should().Be(true);
        }

        [Test]
        public void TestJobRoleVideosMarkAllAsUnWatched()
        {
            JobRole jobRole = new(JOBROLE_TEST_ID, JOBROLE_TEST_NAME, videos);
            jobRole.LearningPath.Should().NotBeNull();
            bool isWatched = false;
            jobRole.LearningPath.ForEach(v => isWatched = isWatched || v.IsWatched);
            isWatched.Should().Be(false);
        }
        #endregion
    }
}
