using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLearning.model.employee;
using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;
using EmployeeLearning.testdata.employeestorage;
using EmployeeLearning.testdata.videostore;
using FluentAssertions;

namespace EmployeeLearningTests
{
    public class LowLevelBusinessLogicTests
    {
        #region CONSTANTS
        public static readonly int EMPLOYEE_INDEX0 = 0;
        public static readonly int EMPLOYEE_INDEX1 = 1;
        public static readonly int EMPLOYEE_INDEX2 = 2;
        public static readonly int EMPLOYEE_INDEX3 = 3;

        public static readonly int EXPECTED_VALUE_ZERO = 0;
        
        public static readonly int EXPECTED_VALUE_1 = 1;
        public static readonly int EXPECTED_VALUE_2 = 2;
        public static readonly int EXPECTED_VALUE_3 = 3;

        public static readonly int INDEX0_OF_SEEN_VIDEOCOURSE;
        
        public static readonly int VIDEOCOURSE_INDEX0 = 0;
        public static readonly int VIDEOCOURSE_INDEX1 = 1;
        public static readonly int VIDEOCOURSE_INDEX2 = 2;
        public static readonly int VIDEOCOURSE_INDEX3 = 3;
        public static readonly int VIDEOCOURSE_INDEX4 = 4;
        public static readonly int VIDEOCOURSE_INDEX5 = 5;
        public static readonly int VIDEOCOURSE_INDEX6 = 6;
        public static readonly int VIDEOCOURSE_INDEX7 = 7;
        public static readonly int VIDEOCOURSE_INDEX8 = 8;
        public static readonly int VIDEOCOURSE_INDEX9 = 9;
        public static readonly int VIDEOCOURSE_INDEX10 = 10;

        #endregion

        readonly List<Employee> employees = EmployeeTestDataProvider.Instance.Employees;

        #region PUBLIC METHODS
        [Test]
        public void ResetWatchOfVideoTest()
        {
            employees.ElementAt(EMPLOYEE_INDEX0).ResetVideoWatches();
            employees.ElementAt(EMPLOYEE_INDEX0).JobRole.LearningPath.ElementAt(VIDEOCOURSE_INDEX0).VideoMarkAsWatched();
            employees.ElementAt(EMPLOYEE_INDEX0).JobRole.LearningPath.ElementAt(VIDEOCOURSE_INDEX0).VideoMarkAsWatched();
            employees.ElementAt(EMPLOYEE_INDEX0).GetWatchedVideos().Count().Should().Be(EXPECTED_VALUE_1);
            employees.ElementAt(EMPLOYEE_INDEX0).GetWatchedVideos().ElementAt(INDEX0_OF_SEEN_VIDEOCOURSE).HitCount.Should().Be(EXPECTED_VALUE_2);

            employees.ElementAt(EMPLOYEE_INDEX0).ResetVideoWatches();
            employees.ElementAt(EMPLOYEE_INDEX0).GetWatchedVideos().Count().Should().Be(EXPECTED_VALUE_ZERO);
            employees.ElementAt(EMPLOYEE_INDEX0).JobRole.LearningPath.ElementAt(VIDEOCOURSE_INDEX0).HitCount.Should().Be(EXPECTED_VALUE_ZERO);
        }

        [Test]
        public void WatchVideoTest()
        {
            employees.ElementAt(EMPLOYEE_INDEX0).ResetVideoWatches();
            employees.ElementAt(EMPLOYEE_INDEX0).JobRole.LearningPath.ElementAt(VIDEOCOURSE_INDEX0).VideoMarkAsWatched();
            employees.ElementAt(EMPLOYEE_INDEX0).JobRole.LearningPath.ElementAt(VIDEOCOURSE_INDEX0).VideoMarkAsWatched();
            employees.ElementAt(EMPLOYEE_INDEX0).GetWatchedVideos().Count().Should().Be(EXPECTED_VALUE_1);
            employees.ElementAt(EMPLOYEE_INDEX0).GetWatchedVideos().ElementAt(INDEX0_OF_SEEN_VIDEOCOURSE).HitCount.Should().Be(EXPECTED_VALUE_2);
        }

        [Test]
        public void WatchedVideosHitCountTest()
        {
            employees.ElementAt(EMPLOYEE_INDEX0).ResetVideoWatches();
            employees.ElementAt(EMPLOYEE_INDEX0).JobRole.LearningPath.ElementAt(VIDEOCOURSE_INDEX0).VideoMarkAsWatched();
            employees.ElementAt(EMPLOYEE_INDEX0).JobRole.LearningPath.ElementAt(VIDEOCOURSE_INDEX0).VideoMarkAsWatched();
            employees.ElementAt(EMPLOYEE_INDEX0).JobRole.LearningPath.ElementAt(VIDEOCOURSE_INDEX0).VideoMarkAsWatched();
            employees.ElementAt(EMPLOYEE_INDEX0).GetWatchedVideos().Count().Should().Be(EXPECTED_VALUE_1);
            employees.ElementAt(EMPLOYEE_INDEX0).GetWatchedVideos().ElementAt(INDEX0_OF_SEEN_VIDEOCOURSE).HitCount.Should().Be(EXPECTED_VALUE_3);
        }

        [Test]
        public void ClearWatchOfVideoTest()
        {
            employees.ElementAt(EMPLOYEE_INDEX0).ResetVideoWatches();
            employees.ElementAt(EMPLOYEE_INDEX0).JobRole.LearningPath.ElementAt(VIDEOCOURSE_INDEX0).VideoMarkAsWatched();
            employees.ElementAt(EMPLOYEE_INDEX0).JobRole.LearningPath.ElementAt(VIDEOCOURSE_INDEX0).VideoMarkAsWatched();
            employees.ElementAt(EMPLOYEE_INDEX0).GetWatchedVideos().Count().Should().Be(EXPECTED_VALUE_1);
            employees.ElementAt(EMPLOYEE_INDEX0).GetWatchedVideos().ElementAt(INDEX0_OF_SEEN_VIDEOCOURSE).HitCount.Should().Be(EXPECTED_VALUE_2);

            employees.ElementAt(EMPLOYEE_INDEX0).JobRole.LearningPath.ElementAt(VIDEOCOURSE_INDEX0).VideoMarkAsUnWatched();
            employees.ElementAt(EMPLOYEE_INDEX0).JobRole.LearningPath.ElementAt(VIDEOCOURSE_INDEX0).VideoMarkAsUnWatched();
            employees.ElementAt(EMPLOYEE_INDEX0).GetWatchedVideos().Count().Should().Be(EXPECTED_VALUE_ZERO);
            employees.ElementAt(EMPLOYEE_INDEX0).JobRole.LearningPath.ElementAt(VIDEOCOURSE_INDEX0).HitCount.Should().Be(EXPECTED_VALUE_ZERO);
        }
        #endregion
    }
}
