using EmployeeLearning.model.employee;
using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearningTests
{
    public class EmployeeTests
    {
        #region CONSTANTS
        private static readonly int EMPLOYEE_MIN_ID = -1;
        private static readonly int EMPLOYEE_ID = 0;
        private static readonly string EMPLOYEE_LAST_NAME = "John";
        private static readonly string EMPLOYEE_FIRST_NAME = "Doe";
        private static readonly int VIDEO_COUNT_FOR_TEST = 5;
        private static readonly int VIDEO_TEST_ID = 1;
        private static readonly string VIDEO_TEST_NAME = "Ethics";
        private static readonly int JOBROLE_TEST_ID = 1;
        private static readonly string JOBROLE_TEST_NAME = "CTO";
        private static readonly int TWO_TIMES_WATCHED = 2;
        private static readonly int ONE_VIDEO_WATCHER = 1;
        #endregion

        private JobRole CreateJobRole()
        {
            List<Video> videos = new();
            for (int ix = 0; ix < VIDEO_COUNT_FOR_TEST; ix++)
            {
                videos.Add(new Video(VIDEO_TEST_ID + ix, VIDEO_TEST_NAME + ix));
            }
            return new(JOBROLE_TEST_ID, JOBROLE_TEST_NAME, videos);
        }

        private Employee CreateEmployee()
        {
            return new Employee(EMPLOYEE_ID, EMPLOYEE_LAST_NAME, EMPLOYEE_FIRST_NAME, CreateJobRole());
        }

        [Test]
        public void EmployeeInstanceCreatedTest()
        {
            Employee employee = CreateEmployee();
            employee.Should().NotBeNull();
        }

        [Test]
        public void EmployeeNameTest()
        {
            Employee employee = CreateEmployee();
            employee.Should().NotBeNull();
            employee.LastName.Should().NotBeNull();
            employee.FirstName.Should().NotBeNull();
        }

        [Test]
        public void EmployeeIdTest()
        {
            Employee employee = CreateEmployee();
            employee.Should().NotBeNull();
            employee.Id.Should().BeGreaterThan(EMPLOYEE_MIN_ID);
        }

        [Test]
        public void EmployeeJobRoleTest()
        {
            Employee employee = CreateEmployee();
            employee.Should().NotBeNull();
            employee.JobRole.Should().NotBeNull();
        }

        [Test]
        public void EmployeeJobRoleVideoExistsTest()
        {
            Employee employee = CreateEmployee();
            employee.Should().NotBeNull();
            employee.JobRole.Should().NotBeNull();
            employee.JobRole.LearningPath.Should().NotBeNull();
            employee.JobRole.LearningPath.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void EmployeeJobRoleVideoWatchedTest()
        {
            Employee employee = CreateEmployee();
            employee.Should().NotBeNull();
            employee.JobRole.Should().NotBeNull();
            employee.JobRole.LearningPath.Should().NotBeNull();
            employee.JobRole.LearningPath.ElementAt(0).MarkAsWatched();
            employee.JobRole.LearningPath.ElementAt(0).IsWatched.Should().BeTrue();
        }

        [Test]
        public void EmployeeJobRoleVideoUnWatchedTest()
        {
            Employee employee = CreateEmployee();
            employee.Should().NotBeNull();
            employee.JobRole.Should().NotBeNull();
            employee.JobRole.LearningPath.Should().NotBeNull();
            employee.JobRole.LearningPath.ElementAt(0).MarkAsWatched();
            employee.JobRole.LearningPath.ElementAt(0).MarkAsUnWatched();
            employee.JobRole.LearningPath.ElementAt(0).IsWatched.Should().BeFalse();
        }


        [Test]
        public void EmployeeJobRoleVideoHitCountTest()
        {
            Employee employee = CreateEmployee();
            employee.Should().NotBeNull();
            employee.JobRole.Should().NotBeNull();
            employee.JobRole.LearningPath.Should().NotBeNull();
            employee.JobRole.LearningPath.ElementAt(0).MarkAsWatched();
            employee.JobRole.LearningPath.ElementAt(0).MarkAsWatched();
            employee.JobRole.LearningPath.ElementAt(0).HitCount.Should().BeGreaterThanOrEqualTo(TWO_TIMES_WATCHED);
            employee.GetWatchedVideos().Should().NotBeNull();
            employee.GetWatchedVideos().Count.Should().BeGreaterThanOrEqualTo(ONE_VIDEO_WATCHER);

        }

        [Test]
        public void EmployeeJobRoleVideoHitCountClearTest()
        {
            Employee employee = CreateEmployee();
            employee.Should().NotBeNull();
            employee.JobRole.Should().NotBeNull();
            employee.JobRole.LearningPath.Should().NotBeNull();
            employee.JobRole.LearningPath.ElementAt(0).MarkAsWatched();
            employee.JobRole.LearningPath.ElementAt(0).MarkAsWatched();
            employee.JobRole.LearningPath.ElementAt(0).MarkAsUnWatched();
            employee.GetWatchedVideos().Should().NotBeNull();
            employee.GetWatchedVideos().Count.Should().Be(0);
        }

    }
}
