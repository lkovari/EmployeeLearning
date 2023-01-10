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
        private static readonly List<Video> videos = new();
        private JobRole jobRole;
        #endregion

        [SetUp]
        public void Setup()
        {
            for (int ix = 0; ix < VIDEO_COUNT_FOR_TEST; ix++)
            {
                videos.Add(new Video(VIDEO_TEST_ID + ix, VIDEO_TEST_NAME + ix));
            }
            jobRole = new();
            jobRole.Id = JOBROLE_TEST_ID;
            jobRole.Name = JOBROLE_TEST_NAME;
            jobRole.LearningPath = videos;
        }

        private Employee CreateEmployee()
        {
            Employee employee = new Employee();
            employee.Id = EMPLOYEE_ID;
            employee.LastName = EMPLOYEE_LAST_NAME;
            employee.FirstName = EMPLOYEE_FIRST_NAME;
            employee.JobRole = jobRole;
            return employee;
        }

        [Test]
        public void EmployeeInstanceCreatedTest()
        {
            Employee employee = new();
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


    }
}
