using EmployeeLearning.adapters.assignedvideos;
using EmployeeLearning.adapters.displayemployee;
using EmployeeLearning.adapters.watchhistory;
using EmployeeLearning.datahandler.employee;
using EmployeeLearning.model.employee;
using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;
using EmployeeLearning.testdata.employeestorage;
using EmployeeLearning.testdata.idprovider;
using FluentAssertions;

namespace EmployeeLearningTests
{
    public class EmployeeDataHandlerTests
    {
        #region CONSTANTS
        private readonly int EMPLOYEE_TEST_DATA_INDEX = 0;
        private readonly int EMPLOYEE_JOBROLE_LERNINGPATH_ZERO_COUNT = 0;
        private readonly int EMPLOYEE_ASSIGNED_VIDEO_INDEX = 0;
        private readonly int VIDEO_WATCHED_0_TIMES = 0;
        private readonly int VIDEO_WATCHED_1_TIMES = 1;
        private readonly int VIDEO_WATCHED_2_TIMES = 2;
        private readonly int WATCHED_VIDEO_COUNT_ONE = 1;
        #endregion

        #region DATA HANDLER
        private EmployeeDataHandler employeeDataHandler;
        #endregion

        #region INITIALIZE
        [SetUp]
        public void Setup()
        {
            employeeDataHandler =
                new EmployeeDataHandler(EmployeeTestDataProvider.
                    Instance.Employees[EMPLOYEE_TEST_DATA_INDEX],
                    new DisplayEmployeeConsoleAdapter(),
                    new DisplayAssignedVideosConsoleAdapter(),
                    new DisplayHistoryOfWatchedVideosConsoleAdapter()
                );
        }
        #endregion

        #region PUBLIC TEST METHODS
        [Test]
        public void EmployeeDataHandlerInstanceTest()
        {
            employeeDataHandler.Should().NotBeNull();
        }

        [Test]
        public void EmployeeDataHandlerEmployeInstanceTest()
        {
            employeeDataHandler.Employee.Should().NotBeNull();
        }

        [Test]
        public void EmployeeEmployeJobRoleInstanceTest()
        {
            employeeDataHandler.Employee.JobRole.Should().NotBeNull();
            employeeDataHandler.Employee.JobRole.Id.Should().NotBeEmpty();
            employeeDataHandler.Employee.JobRole.Name.Should().NotBeNull();
            employeeDataHandler.Employee.JobRole.LearningPath.Should().NotBeNull();
        }

        [Test]
        public void EmployeeEmployeJobRoleTest()
        {
            employeeDataHandler.Employee.JobRole.Should().NotBeNull();
            employeeDataHandler.Employee.JobRole.Id.Should().NotBeEmpty();
            employeeDataHandler.Employee.JobRole.Name.Should().NotBeNull();
            employeeDataHandler.Employee.JobRole.LearningPath.Should().NotBeNull();
            employeeDataHandler.Employee.JobRole.LearningPath.Count.Should().
                BeGreaterThan(EMPLOYEE_JOBROLE_LERNINGPATH_ZERO_COUNT);
        }

        [Test]
        public void EmployeeNamePropertyNotSetTest()
        {
            Action action = () =>
            {
                Employee newEmployee = new(null,
                    employeeDataHandler.Employee.UserName,
                    employeeDataHandler.Employee.Password,
                    employeeDataHandler.Employee.JobRole);
            };
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void EmployeeWatchAVideoTest()
        {
            Video interestedVideo = 
                employeeDataHandler.GetAssignedVideos()[EMPLOYEE_ASSIGNED_VIDEO_INDEX];
            interestedVideo.Should().NotBeNull();
            employeeDataHandler.WatchingAVideo(interestedVideo.Id);
            interestedVideo.IsWatched.Should().BeTrue();
            interestedVideo.WatchDate.Should().NotBeNull();
            interestedVideo.WatchCount.Should().BeGreaterThan(VIDEO_WATCHED_0_TIMES);
        }

        [Test]
        public void EmployeeWatchAVideoWatchCountTest()
        {
            employeeDataHandler.ResetVideoWatches();
            Video interestedVideo =
                employeeDataHandler.GetAssignedVideos()[EMPLOYEE_ASSIGNED_VIDEO_INDEX];
            interestedVideo.Should().NotBeNull();
            interestedVideo.WatchCount.Should().Be(VIDEO_WATCHED_0_TIMES);
            employeeDataHandler.WatchingAVideo(interestedVideo.Id);
            employeeDataHandler.WatchingAVideo(interestedVideo.Id);
            interestedVideo.IsWatched.Should().BeTrue();
            interestedVideo.WatchDate.Should().NotBeNull();
            interestedVideo.WatchCount.Should().Be(VIDEO_WATCHED_2_TIMES);
            employeeDataHandler.GetWatchedVideos().Count.Should().Be(WATCHED_VIDEO_COUNT_ONE);
        }

        [Test]
        public void EmployeeResetWatchAVideoWatchCountTest()
        {
            Video interestedVideo =
                employeeDataHandler.GetAssignedVideos()[EMPLOYEE_ASSIGNED_VIDEO_INDEX];
            interestedVideo.Should().NotBeNull();
            employeeDataHandler.GetWatchedVideos().Count.Should().Be(VIDEO_WATCHED_0_TIMES);
            employeeDataHandler.WatchingAVideo(interestedVideo.Id);
            employeeDataHandler.GetWatchedVideos().Count.Should().Be(VIDEO_WATCHED_1_TIMES);
            employeeDataHandler.WatchingAVideo(interestedVideo.Id);
            interestedVideo.IsWatched.Should().BeTrue();
            interestedVideo.WatchDate.Should().NotBeNull();
            interestedVideo.WatchCount.Should().Be(VIDEO_WATCHED_2_TIMES);
            employeeDataHandler.ResetVideoWatches();
            employeeDataHandler.GetWatchedVideos().Count.Should().Be(VIDEO_WATCHED_0_TIMES);
        }

        [Test]
        public void EmployeeGetAssignedVideoByIdTest()
        {
            Video interestedVideo =
                employeeDataHandler.GetAssignedVideos()[EMPLOYEE_ASSIGNED_VIDEO_INDEX];
            Video foundInterestedVideo = employeeDataHandler.GetAssignedVideoById(interestedVideo.Id);
            foundInterestedVideo.Should().NotBeNull();
            foundInterestedVideo.Should().BeSameAs(interestedVideo);
        }

        [Test]
        public void EmployeeGetAssignedVideoByIdNotFoundTest()
        {
            Guid dummyVideoId = IdProvider.Instance.NewId;
            Action action = () =>
            {
                Video foundInterestedVideo = employeeDataHandler.GetAssignedVideoById(dummyVideoId);
            };
            action.Should().Throw<Exception>();
        }

        #endregion
    }
}
