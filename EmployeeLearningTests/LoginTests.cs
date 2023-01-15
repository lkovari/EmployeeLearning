
using EmployeeLearning.datahandler.employees;
using EmployeeLearning.datahandler.login;
using EmployeeLearning.testdata.employeestorage;
using FluentAssertions;

namespace EmployeeLearningTests
{
    public class LoginTests
    {
        #region CONSTANTS
        private readonly int EMPLOYEE_INDEX0 = 0;
        #endregion

        #region DATA HANDLER
        private LoginHandler loginHandler;
        #endregion

        #region INITIALIZE
        [SetUp]
        public void Setup()
        {
            IEmployeesDataHandler employeesDataHandler = new EmployeesDataHandler();
            loginHandler = new LoginHandler(employeesDataHandler);
                
        }
        #endregion

        #region PUBLIC TEST METHODS
        [Test]
        public void EmployeeLoginTest()
        {
            string password = EmployeeTestDataProvider.Instance.Employees[EMPLOYEE_INDEX0].Password;
            Action action = () =>
            {
                bool isSuccess = loginHandler.Login("JDoe", password);
                isSuccess.Should().BeTrue();
            };
            action.Should().Throw<Exception>();
        }

        [Test]
        public void EmployeeLoginFailedTest()
        {
            Action action = () =>
            {
                bool isSuccess = loginHandler.Login("JDoe", "Incifincy");
                isSuccess.Should().BeTrue();
            };
            action.Should().Throw<Exception>();
        }
        #endregion
    }
}
