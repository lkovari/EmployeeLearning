
using EmployeeLearning.adapters.displayjobroles;
using EmployeeLearning.datahandler.jobroles;
using EmployeeLearning.model.jobrole;
using EmployeeLearning.testdata.idprovider;
using EmployeeLearning.testdata.jobrolestore;
using EmployeeLearning.testdata.videostore;
using FluentAssertions;

namespace EmployeeLearningTests
{
    public class JobRolesDataHandlerTests
    {
        #region CONSTANTS
        private readonly int NUMBER_OF_JOBROLES_COUNT_ZERO = 0;
        private readonly int JOBROLE_INDEX_ZERO = 0;
        #endregion

        #region DATA HANDLER
        private JobRolesDataHandler jobRolesDataHandler;
        #endregion

        #region INITIALIZE
        [SetUp]
        public void Setup()
        {
            jobRolesDataHandler = new(JobRoleTestDataProvider.Instance.JobRoles,
                new DisplayJobRolesConsoleAdapter());
        }
        #endregion

        #region TEST METHODS
        [Test]
        public void JobRolesDataHandlerNotNullTest()
        {
            jobRolesDataHandler.Should().NotBeNull();
        }


        [Test]
        public void JobRolesDataHandlerVideosExistsTest()
        {
            jobRolesDataHandler.Should().NotBeNull();
            jobRolesDataHandler.GetAllJobRoles().Should().NotBeNull();
            jobRolesDataHandler.GetAllJobRoles().Count.Should().BeGreaterThan(NUMBER_OF_JOBROLES_COUNT_ZERO);
        }

        [Test]
        public void JobRolesDataHandlerAddVideoTest()
        {
            jobRolesDataHandler.Should().NotBeNull();
            jobRolesDataHandler.GetAllJobRoles().Should().NotBeNull();
            int jobRoleCountBeforeAdd = jobRolesDataHandler.GetAllJobRoles().Count;
            JobRole newJobRole = new("New JobRole", VideoTestDataProvider.Instance.Videos);
            jobRolesDataHandler.AddJobRole(newJobRole);
            int jobRoleCountAfterAdd = jobRolesDataHandler.GetAllJobRoles().Count;
            jobRoleCountAfterAdd.Should().BeGreaterThan(jobRoleCountBeforeAdd);
            JobRole foundJobRole = jobRolesDataHandler.GetJobRoleById(newJobRole.Id);
            foundJobRole.Should().BeSameAs(newJobRole);
        }

        [Test]
        public void JobRolesDataHandlerRemoveVideoTest()
        {
            jobRolesDataHandler.Should().NotBeNull();
            jobRolesDataHandler.GetAllJobRoles().Should().NotBeNull();
            int jobRoleCountBeforeRemove = jobRolesDataHandler.GetAllJobRoles().Count;
            JobRole jobRoleToRemove = jobRolesDataHandler.GetAllJobRoles()[JOBROLE_INDEX_ZERO];
            jobRolesDataHandler.RemoveJobRoleById(jobRoleToRemove.Id);
            int jobRoleCountAfterRemove = jobRolesDataHandler.GetAllJobRoles().Count;
            jobRoleCountAfterRemove.Should().BeLessThan(jobRoleCountBeforeRemove);
            Action action = () =>
            {
                JobRole foundVideo = jobRolesDataHandler.GetJobRoleById(jobRoleToRemove.Id);
            };
            action.Should().Throw<Exception>();
        }

        [Test]
        public void JobRolesDataHandlerGetAllJobRolesTest()
        {
            jobRolesDataHandler.Should().NotBeNull();
            jobRolesDataHandler.GetAllJobRoles().Should().NotBeNull();
            int jobRoleCount = jobRolesDataHandler.GetAllJobRoles().Count;
            jobRoleCount.Should().Be(JobRoleTestDataProvider.Instance.JobRoles.Count);
        }

        [Test]
        public void JobRolesDataHandlerGetVideoByIdTest()
        {
            jobRolesDataHandler.Should().NotBeNull();
            JobRole jobRoleToGet = jobRolesDataHandler.GetAllJobRoles()[JOBROLE_INDEX_ZERO];
            JobRole foundJobRole = jobRolesDataHandler.GetJobRoleById(jobRoleToGet.Id);
            foundJobRole.Should().BeSameAs(jobRoleToGet);
        }

        [Test]
        public void JobRolesDataHandlerGetVideoByIdFailedTest()
        {
            jobRolesDataHandler.Should().NotBeNull();
            Action action = () =>
            {
                JobRole foundJobRole = jobRolesDataHandler.GetJobRoleById(IdProvider.Instance.NewId);
            };
            action.Should().Throw<Exception>();
        }
        #endregion
    }
}
