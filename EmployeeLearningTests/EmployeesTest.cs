using EmployeeLearning.datahandler.employees;
using EmployeeLearning.model.employee;
using EmployeeLearning.model.employees;
using EmployeeLearning.testdata;
using EmployeeLearning.testdata.employeestorage;
using EmployeeLearning.testdata.idprovider;
using EmployeeLearning.testdata.jobrolestore;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearningTests
{
    public class EmployeesTest
    {
        #region CONSTANTS
        private readonly int EMPLOYE_COUNT_ZERO = 0;
        private readonly int EMPLOYE_INDEX_0 = 0;
        private readonly int JOBROLE_INDEX = 1;
        private readonly string EMPLOYEE_NEW_NAME = "John Carmac";
        #endregion

        private EmployeesDataHandler employeesDataHandler;

        #region INITIALIZE
        [SetUp]
        public void Setup()
        {
            employeesDataHandler = new EmployeesDataHandler();
        }
        #endregion

        #region PUBLIC TEST METHODS
        [Test]
        public void EmployeesDataHandlerInstanceTest()
        {
            employeesDataHandler.Should().NotBeNull();
        }

        [Test]
        public void EmployeesDataHandlerEmployeesCountTest()
        {
            employeesDataHandler.Should().NotBeNull();
            employeesDataHandler.GetAllEmployees().Count.Should().BeGreaterThan(EMPLOYE_COUNT_ZERO);
        }

        [Test]
        public void EmployeesDataHandlerEmployeeAddTest()
        {
            employeesDataHandler.Should().NotBeNull();
            int employeCoundBeforeAdd = employeesDataHandler.GetAllEmployees().Count;
            Employee employe = new("Alistair McIntyre",
                JobRoleTestDataProvider.Instance.JobRoles[JOBROLE_INDEX]);
            employeesDataHandler.AddEmployee(employe);
            int employeCoundAfterAdd = employeesDataHandler.GetAllEmployees().Count;
            employeCoundAfterAdd.Should().BeGreaterThan(employeCoundBeforeAdd);
            Employee foundEmployee = employeesDataHandler.GetEmployeeById(employe.Id);
            foundEmployee.Should().NotBeNull();
            foundEmployee.Should().BeSameAs(employe);
        }

        [Test]
        public void EmployeesDataHandlerAddEmployeesTest()
        {
            employeesDataHandler.Should().NotBeNull();
            int employeCoundBeforeAdd = employeesDataHandler.GetAllEmployees().Count;

            Employee employeOne = 
                new Employee("Ian Fraser Kilminster", JobRoleTestDataProvider.Instance.JobRoles[0]);
            Employee employeTwo =
                new Employee("Seimour Cray", JobRoleTestDataProvider.Instance.JobRoles[1]);
            List<Employee> employeesToAdd = new List<Employee>();
            employeesToAdd.Add(employeOne);
            employeesToAdd.Add(employeTwo);
            employeesDataHandler.AddEmployees(employeesToAdd);
            int employeesCountAfterAdd = employeesDataHandler.GetAllEmployees().Count;
            employeesCountAfterAdd.Should().Be(employeCoundBeforeAdd + 2);
        }

        [Test]
        public void EmployeesDataHandlerModifyEmployeesTest()
        {
            employeesDataHandler.Should().NotBeNull();
            employeesDataHandler.GetAllEmployees().Should().NotBeNull();
            employeesDataHandler.GetAllEmployees().Count.Should().BeGreaterThan(EMPLOYE_COUNT_ZERO);
            Employee employeToModify = employeesDataHandler.GetAllEmployees()[EMPLOYE_INDEX_0];
            Employee clonedEmloyee = (Employee)employeToModify.Clone();
            clonedEmloyee.Should().NotBeNull();
            clonedEmloyee.Name = EMPLOYEE_NEW_NAME;
            employeesDataHandler.ModifyEmployee(clonedEmloyee);
            Employee modifiedEmployee = employeesDataHandler.GetEmployeeById(employeToModify.Id);
            modifiedEmployee.Should().NotBeNull();
            modifiedEmployee.Name.Should().BeSameAs(EMPLOYEE_NEW_NAME); 
        }
        #endregion
    }
}
