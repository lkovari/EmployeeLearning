using EmployeeLearning.adapters.assignedvideos;
using EmployeeLearning.adapters.displayemployee;
using EmployeeLearning.adapters.watchhistory;
using EmployeeLearning.datahandler.employee;
using EmployeeLearning.model.employee;
using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;
using EmployeeLearning.testdata.employeestorage;
using EmployeeLearning.testdata.idprovider;
using EmployeeLearning.testdata.jobrolestore;
using FluentAssertions;

namespace EmployeeLearningTests
{
    public class EmployeeDataHandlerTests
    {
        #region CONSTANTS
        private readonly int EMPLOYEE_TEST_DATA_INDEX = 0;
        private readonly int EMPLOYEE_JOBROLE_LERNINGPATH_ZERO_COUNT = 0;
        private readonly int FIRST_JOB_ROLE = 0;
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
            employeeDataHandler.Employee.JobRoles.Should().NotBeNull();
            employeeDataHandler.Employee.JobRoles[FIRST_JOB_ROLE].Id.Should().NotBeEmpty();
            employeeDataHandler.Employee.JobRoles[FIRST_JOB_ROLE].Name.Should().NotBeNull();
            employeeDataHandler.Employee.JobRoles[FIRST_JOB_ROLE].LearningPath.Should().NotBeNull();
        }

        [Test]
        public void EmployeeEmployeJobRoleTest()
        {
            employeeDataHandler.Employee.JobRoles[FIRST_JOB_ROLE].Should().NotBeNull();
            employeeDataHandler.Employee.JobRoles[FIRST_JOB_ROLE].Id.Should().NotBeEmpty();
            employeeDataHandler.Employee.JobRoles[FIRST_JOB_ROLE].Name.Should().NotBeNull();
            employeeDataHandler.Employee.JobRoles[FIRST_JOB_ROLE].LearningPath.Should().NotBeNull();
            employeeDataHandler.Employee.JobRoles[FIRST_JOB_ROLE].LearningPath.Count.Should().
                BeGreaterThan(EMPLOYEE_JOBROLE_LERNINGPATH_ZERO_COUNT);
        }

        [Test]
        public void EmployeeNamePropertyNotSetTest()
        {
            Action action = () =>
            {
                List<JobRole> jobRoles1 = new();
                jobRoles1.Add(JobRoleTestDataProvider.Instance.JobRoles[4]);
                jobRoles1.Add(JobRoleTestDataProvider.Instance.JobRoles[5]);
                Employee newEmployee = new(null,
                    employeeDataHandler.Employee.UserName,
                    employeeDataHandler.Employee.Password,
                    jobRoles1);
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

        [Test]
        public void EmployeeAddJobRoleTest()
        {
            employeeDataHandler.Should().NotBeNull();
            int jobeRolesBeforeAddNew = employeeDataHandler.GetJobRoles().Count;
            JobRole newJobRole = new JobRole("New JobRole",
                JobRoleTestDataProvider.Instance.JobRoles[FIRST_JOB_ROLE].LearningPath);
            employeeDataHandler.AddJobRole(newJobRole);
            int jobeRolesAfterAddNew = employeeDataHandler.GetJobRoles().Count;
            jobeRolesAfterAddNew.Should().BeGreaterThan(jobeRolesBeforeAddNew);
        }

        [Test]
        public void EmployeeRemoveJobRoleTest()
        {
            employeeDataHandler.Should().NotBeNull();
            JobRole newJobRole = new JobRole("New JobRole",
                JobRoleTestDataProvider.Instance.JobRoles[FIRST_JOB_ROLE].LearningPath);
            employeeDataHandler.AddJobRole(newJobRole);
            int jobeRolesBeforeRemove = employeeDataHandler.GetJobRoles().Count;
            employeeDataHandler.RemoveJobRoleById(newJobRole.Id);
            int jobeRolesAfterRemove = employeeDataHandler.GetJobRoles().Count;
            jobeRolesAfterRemove.Should().BeLessThan(jobeRolesBeforeRemove);
        }

        [Test]
        public void EmployeeGetJobRoleByIdTest()
        {
            employeeDataHandler.Should().NotBeNull();
            Guid JobRoleId = employeeDataHandler.GetJobRoles()[1].Id;
            JobRole foundJobRole = employeeDataHandler.GetJobRoleById(JobRoleId);
            foundJobRole.Should().BeSameAs(employeeDataHandler.GetJobRoles()[1]);
        }
        #endregion
    }
}
