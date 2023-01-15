using EmployeeLearning.datahandler.jobrole;
using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;
using EmployeeLearning.testdata.idprovider;
using EmployeeLearning.testdata.jobrolestore;
using FluentAssertions;

namespace EmployeeLearningTests
{
    public class JobRoleDataHandlerTests
    {
        #region CONSTANTS
        private static readonly int JOBROLE_TEST_DATA_INDEX0 = 0;
        private static readonly int JOBROLE_TEST_DATA_INDEX5 = 5;
        private static readonly int VIDEO_TEST_DATA_INDEX0 = 0;
        private static readonly int VIDEO_COUNT_EXPECTED_RESULT_ZERO = 0;
        private static readonly string VIDEO_TEST_NAME = "Ethics";
        #endregion

        #region DATA HANDLER
        private JobRoleDataHandler jobRoleDataHandler;
        #endregion

        #region INITIALIZE
        [SetUp]
        public void Setup()
        {
            jobRoleDataHandler = 
                new(JobRoleTestDataProvider.Instance.JobRoles[JOBROLE_TEST_DATA_INDEX0]);
        }
        #endregion

        #region PUBLIC TEST METHODS
        [Test]
        public void JobRoleDataHandlerInstanceTest()
        {
            jobRoleDataHandler.Should().NotBeNull();
        }

        [Test]
        public void JobRoleInstanceTest()
        {
            jobRoleDataHandler.JobRole.Should().NotBeNull();
        }

        [Test]
        public void JobRolePropertiesTest()
        {
            jobRoleDataHandler.JobRole.Should().NotBeNull();
            jobRoleDataHandler.JobRole.Id.Should().NotBeEmpty();
            jobRoleDataHandler.JobRole.Name.Should().NotBeNull();
            jobRoleDataHandler.JobRole.LearningPath.Should().NotBeNull();
            jobRoleDataHandler.JobRole.LearningPath.Count.Should()
                .BeGreaterThan(VIDEO_COUNT_EXPECTED_RESULT_ZERO);
        }


        [Test]
        public void JobRoleNamePropertyNotSetTest()
        {
            Action action = () =>
            {
                JobRole newJobRole = new(null, jobRoleDataHandler.JobRole.LearningPath);
            };
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void JobRoleAssignVideoToJobRoleTest()
        {
            Video video = new Video(VIDEO_TEST_NAME);
            int videosCountBeforeAdd = jobRoleDataHandler.JobRole.LearningPath.Count;
            jobRoleDataHandler.AssignVideo(video);
            int videosCountAfterAdd = jobRoleDataHandler.JobRole.LearningPath.Count;
            videosCountAfterAdd.Should().BeGreaterThan(videosCountBeforeAdd);
            Video foundVideo = jobRoleDataHandler.GetAssignedVideoById(video.Id);
            foundVideo.Should().NotBeNull();
            foundVideo.Should().BeSameAs(video);
        }

        [Test]
        public void JobRoleRemoveVideoFromJobRoleTest()
        {
            int videosCountBeforeRemove = jobRoleDataHandler.JobRole.LearningPath.Count;
            Video interestedVideo = jobRoleDataHandler.JobRole.LearningPath[JOBROLE_TEST_DATA_INDEX0];
            jobRoleDataHandler.RemoveAssignedVideoById(interestedVideo.Id);
            int videosCountAfterRemove = jobRoleDataHandler.JobRole.LearningPath.Count;
            videosCountAfterRemove.Should().BeLessThan(videosCountBeforeRemove);
            Action action = () =>
            {
                Video foundVideo = jobRoleDataHandler.GetAssignedVideoById(interestedVideo.Id);
            };
            action.Should().Throw<Exception>();
        }

        [Test]
        public void JobRoleFindVideoByIdTest()
        {
            JobRole jobRoleToFind =
                JobRoleTestDataProvider.Instance.JobRoles[JOBROLE_TEST_DATA_INDEX5];
            Action action = () =>
            {
                Video video = jobRoleDataHandler.GetAssignedVideoById(jobRoleToFind.LearningPath[VIDEO_TEST_DATA_INDEX0].Id);
            };
            action.Should().Throw<Exception>();
        }

        [Test]
        public void JobRoleFindVideoByIdFailedTest()
        {
            JobRole jobRoleToFind = 
                JobRoleTestDataProvider.Instance.JobRoles[JOBROLE_TEST_DATA_INDEX5];
            Action action = () =>
            {
                // pass a New Id intentionally
                Video video = jobRoleDataHandler.GetAssignedVideoById(IdProvider.Instance.NewId);
            };
            action.Should().Throw<Exception>();
        }
        #endregion
    }
}
