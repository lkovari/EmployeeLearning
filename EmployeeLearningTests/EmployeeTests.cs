using EmployeeLearning.model.employee;
using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearningTests
{
    public class EmployeeTests
    {
        #region CONSTANTS
        private static readonly int EMPLOYEE_MIN_ID = -1;
        private static readonly int EMPLOYEE_ID = 0;
        private static readonly string EMPLOYEE_NAME = "John Doe";
        private static readonly int VIDEO_COUNT_FOR_TEST = 5;
        private static readonly int VIDEO_TEST_ID = 1;
        private static readonly string VIDEO_TEST_NAME = "Ethics";
        private static readonly int JOBROLE_TEST_ID = 1;
        private static readonly string JOBROLE_TEST_NAME = "CTO";
        private static readonly int TWO_TIMES_WATCHED = 2;
        private static readonly int ONE_VIDEO_WATCHER = 1;

        public static readonly int EXPECTED_VALUE_ZERO = 0;
        public static readonly int EXPECTED_VALUE_1 = 1;
        public static readonly int EXPECTED_VALUE_2 = 2;
        #endregion

        #region PRIVATE FUNCTIONS
        private JobRole CreateJobRole()
        {
            List<Video> videos = new();
            for (int ix = 0; ix < VIDEO_COUNT_FOR_TEST; ix++)
            {
                videos.Add(new Video(VIDEO_TEST_ID + ix, VIDEO_TEST_NAME + ix));
            }
            return new(JOBROLE_TEST_ID, JOBROLE_TEST_NAME, videos);
        }


        private Employee CreateEmployee(Nullable<int> id, string? name, JobRole? jobRole)
        {
             return new Employee(id, name, jobRole);
        }
        #endregion

        #region PUBLIC TEST METHODS
        [Test]
        public void EmployeeInstanceCreatedTest()
        {
            Employee employee = CreateEmployee(EMPLOYEE_ID, EMPLOYEE_NAME, CreateJobRole());
            employee.Should().NotBeNull();
        }

        [Test]
        public void EmployeeNameTest()
        {
            Employee employee = CreateEmployee(EMPLOYEE_ID, EMPLOYEE_NAME, CreateJobRole());
            employee.Should().NotBeNull();
            employee.Name.Should().NotBeNull();
        }

        [Test]
        public void EmployeeIdTest()
        {
            Employee employee = CreateEmployee(EMPLOYEE_ID, EMPLOYEE_NAME, CreateJobRole());
            employee.Should().NotBeNull();
            employee.Id.Should().BeGreaterThan(EMPLOYEE_MIN_ID);
        }

        [Test]
        public void EmployeeJobRoleTest()
        {
            Employee employee = CreateEmployee(EMPLOYEE_ID, EMPLOYEE_NAME, CreateJobRole());
            employee.Should().NotBeNull();
            employee.JobRole.Should().NotBeNull();
        }

        [Test]
        public void EmployeeJobRoleVideoExistsTest()
        {
            Employee employee = CreateEmployee(EMPLOYEE_ID, EMPLOYEE_NAME, CreateJobRole());
            employee.Should().NotBeNull();
            employee.JobRole.Should().NotBeNull();
            employee.JobRole.LearningPath.Should().NotBeNull();
            employee.JobRole.LearningPath.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void EmployeeJobRoleVideoWatchedTest()
        {
            Employee employee = CreateEmployee(EMPLOYEE_ID, EMPLOYEE_NAME, CreateJobRole());
            employee.Should().NotBeNull();
            employee.JobRole.Should().NotBeNull();
            employee.JobRole.LearningPath.Should().NotBeNull();
            employee.JobRole.LearningPath.ElementAt(0).VideoMarkAsWatched();
            employee.JobRole.LearningPath.ElementAt(0).IsWatched.Should().BeTrue();
        }

        [Test]
        public void EmployeeJobRoleVideoUnWatchedTest()
        {
            Employee employee = CreateEmployee(EMPLOYEE_ID, EMPLOYEE_NAME, CreateJobRole());
            employee.Should().NotBeNull();
            employee.JobRole.Should().NotBeNull();
            employee.JobRole.LearningPath.Should().NotBeNull();
            employee.JobRole.LearningPath.ElementAt(0).VideoMarkAsWatched();
            employee.JobRole.LearningPath.ElementAt(0).VideoMarkAsUnWatched();
            employee.JobRole.LearningPath.ElementAt(0).IsWatched.Should().BeFalse();
        }


        [Test]
        public void EmployeeJobRoleVideoHitCountTest()
        {
            Employee employee = CreateEmployee(EMPLOYEE_ID, EMPLOYEE_NAME, CreateJobRole());
            employee.Should().NotBeNull();
            employee.JobRole.Should().NotBeNull();
            employee.JobRole.LearningPath.Should().NotBeNull();
            employee.JobRole.LearningPath.ElementAt(0).VideoMarkAsWatched();
            employee.JobRole.LearningPath.ElementAt(0).VideoMarkAsWatched();
            employee.JobRole.LearningPath.ElementAt(0).HitCount.Should().BeGreaterThanOrEqualTo(TWO_TIMES_WATCHED);
            employee.GetWatchedVideos().Should().NotBeNull();
            employee.GetWatchedVideos().Count.Should().BeGreaterThanOrEqualTo(ONE_VIDEO_WATCHER);

        }

        [Test]
        public void EmployeeJobRoleVideoHitCountClearTest()
        {
            Employee employee = CreateEmployee(EMPLOYEE_ID, EMPLOYEE_NAME, CreateJobRole());
            employee.Should().NotBeNull();
            employee.JobRole.Should().NotBeNull();
            employee.JobRole.LearningPath.Should().NotBeNull();
            employee.JobRole.LearningPath.ElementAt(0).VideoMarkAsWatched();
            employee.JobRole.LearningPath.ElementAt(0).VideoMarkAsWatched();
            employee.JobRole.LearningPath.ElementAt(0).VideoMarkAsUnWatched();
            employee.GetWatchedVideos().Should().NotBeNull();
            employee.GetWatchedVideos().Count.Should().Be(EXPECTED_VALUE_ZERO);
        }

        [Test]
        public void EmployeeNullIdParameterTest()
        {
            Action action = () =>
            {
                Employee? employee = CreateEmployee(null, EMPLOYEE_NAME, CreateJobRole());
            };
            action.Should().Throw<ArgumentException>();
        }
        [Test]
        public void EmployeeNullNameParameterTest()
        {
            Action action = () =>
            {
                Employee? employee = CreateEmployee(EMPLOYEE_ID, null, CreateJobRole());
            };
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void EmployeeNullJobRoleParameterTest()
        {
            Action action = () =>
            {
                Employee? employee = CreateEmployee(EMPLOYEE_ID, EMPLOYEE_NAME, null);
            };
            action.Should().Throw<ArgumentException>();
        }
        #endregion
    }
}
