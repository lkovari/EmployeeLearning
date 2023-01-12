using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;
using FluentAssertions;

namespace EmployeeLearningTests
{
    public class JobRoleTests
    {
        #region CONSTANTS
        private static readonly int VIDEO_COUNT_FOR_TEST = 5;
        private static readonly int VIDEO_TEST_ID = 0;
        private static readonly string VIDEO_TEST_NAME = "Ethics";
        private static readonly int VIDEO_EXPECTED_ID = 0;
        private static readonly string VIDEO_EXPECTED_NAME = "Ethics";
        private static readonly int JOBROLE_TEST_ID = 0;
        private static readonly int JOBROLE_EXPECTED_ID = 0;
        private static readonly string JOBROLE_TEST_NAME = "CTO";
        private static readonly string JOBROLE_EXPECTED_NAME = "CTO";
        #endregion

        #region PRIVATE METHODS

        private List<Video> CreateVideos()
        {
            List<Video> videos = new();
            for (int ix = 0; ix < VIDEO_COUNT_FOR_TEST; ix++)
            {
                videos.Add(new Video(VIDEO_TEST_ID + ix, VIDEO_TEST_NAME + ix));
            }
            return videos;
        }

        private static void JobRoleInstanceCreatedTest(JobRole jobRole)
        {
            jobRole.Should().NotBeNull();
        }

        private static void JobRolePropertiesTest(JobRole jobRole)
        {
            jobRole.Id.Should().Be(JOBROLE_EXPECTED_ID);
            jobRole.Name.Should().Be(JOBROLE_EXPECTED_NAME);
            JobRoleLearningPathTest(jobRole);
        }

        private static void JobRoleLearningPathTest(JobRole jobRole)
           {
            jobRole.LearningPath.Should().NotBeNull();
            jobRole.LearningPath.Count.Should().BeGreaterThan(0);
            for (int ix = 0; ix < jobRole.LearningPath.Count; ix++)
            {
                jobRole.LearningPath.ElementAt(ix).Should().NotBeNull();
                jobRole.LearningPath.ElementAt(ix).Id.Should().NotBe(null);
                jobRole.LearningPath.ElementAt(ix).Id.Should().Be(VIDEO_EXPECTED_ID + ix);
                jobRole.LearningPath.ElementAt(ix).Name.Should().NotBeNull();
                jobRole.LearningPath.ElementAt(ix).Name.Should().Be(VIDEO_EXPECTED_NAME + ix);
            }
        }

        private JobRole CreateJobRole(Nullable<int> id, string? name, List<Video>? videos)
        {
            var jobRole = new JobRole(id, name, videos);
            return jobRole;
        }

        #endregion

        #region PUBLIC TEST METHODS
        [Test]
        public void JobRoleInstanceCreatedTest()
        {
            Action action = () =>
            {
                JobRole jobRole = CreateJobRole(null, null, CreateVideos());
                jobRole.Should().NotBeNull();
            };
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void JobRoleContentNotNullTest()
        {
            JobRole jobRole = CreateJobRole(JOBROLE_TEST_ID, JOBROLE_TEST_NAME, CreateVideos());
            JobRoleInstanceCreatedTest(jobRole);
        }

        [Test]
        public void JobRoleContentTest()
        {
            JobRole jobRole = CreateJobRole(JOBROLE_TEST_ID, JOBROLE_TEST_NAME, CreateVideos());
            JobRoleInstanceCreatedTest(jobRole);
            JobRolePropertiesTest(jobRole);
        }


        [Test]
        public void JobRoleVideosMarkAllAsWatchedTest()
        {
            JobRole jobRole = CreateJobRole(JOBROLE_TEST_ID, JOBROLE_TEST_NAME, CreateVideos());
            jobRole.LearningPath.Should().NotBeNull();
            jobRole.LearningPath.ToList().ForEach(v => v.VideoMarkAsWatched());
            bool isWatched = true;
            jobRole.LearningPath.ToList().ForEach(v => isWatched = isWatched && v.IsWatched);
            isWatched.Should().Be(true);
        }

        [Test]
        public void JobRoleVideosMarkAllAsUnWatchedTest()
        {
            JobRole jobRole = CreateJobRole(JOBROLE_TEST_ID, JOBROLE_TEST_NAME, CreateVideos());
            jobRole.LearningPath.Should().NotBeNull();
            bool isWatched = false;
            jobRole.LearningPath.ToList().ForEach(v => isWatched = isWatched || v.IsWatched);
            isWatched.Should().Be(false);
        }

        [Test]
        public void JobRoleWithIdNullTest()
        {
            Action action = () =>
            {
                JobRole jobRole = CreateJobRole(null, JOBROLE_TEST_NAME, CreateVideos());
                JobRoleInstanceCreatedTest(jobRole);
                jobRole.Id.Should().Be(null);
            };
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void JobRoleWithEmptyNameTest()
        {
            JobRole jobRole = CreateJobRole(JOBROLE_TEST_ID, string.Empty, CreateVideos());
            JobRoleInstanceCreatedTest(jobRole);
            jobRole.Name.Should().Be(string.Empty);
        }

        [Test]
        public void JobRoleWithNullIdParameterTest()
        {
            Action action = () =>
            {
                JobRole? jobRole = CreateJobRole(null, JOBROLE_TEST_NAME, CreateVideos());
            };
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void JobRoleWithNullNameParameterTest()
        {
            Action action = () =>
            {
                JobRole? jobRole = CreateJobRole(JOBROLE_TEST_ID, null, CreateVideos());
            };
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void JobRoleWithNullVideosParameterTest()
        {
            Action action = () =>
            {
                JobRole? jobRole = CreateJobRole(JOBROLE_TEST_ID, JOBROLE_TEST_NAME, null);
            };
            action.Should().Throw<ArgumentException>();
        }
        #endregion
    }
}
