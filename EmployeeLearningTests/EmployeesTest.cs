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
        private readonly string EXPECTED_EXCEPTION_MESSAGE_OF_FIND =
            "GetEmployeeById: Employee Not Found by Id!";
        #endregion

        #region PUBLIC TEST METHODS
        [Test]
        public void EmployeesAddEmployeesTest()
        {
            var employees = new Employees();
            employees.Should().NotBeNull();
            employees.AddEmployees(EmployeeTestDataProvider.Instance.Employees);
            employees.GetAllEmployees().Should().NotBeNull();
            employees.GetAllEmployees().Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void EmployeesAddEmployeTest()
        {
            var employees = new Employees();
            employees.Should().NotBeNull();
            employees.AddEmployees(EmployeeTestDataProvider.Instance.Employees);
            employees.GetAllEmployees().Should().NotBeNull();
            employees.GetAllEmployees().Count.Should().BeGreaterThan(0);
            int numberOfEmployes = employees.GetAllEmployees().Count;

            var employee = new Employee(IdProvider.NewEmployeeId,
                "Alistair McIntyre",
                JobRoleTestDataProvider.Instance.JobRoles[9]);
            employee.Should().NotBeNull();
            employees.AddEmployee(employee);
            employees.GetAllEmployees().Count.Should().BeGreaterThan(numberOfEmployes);
            var foundEmployee = employees.GetEmployeeById(employee.Id);
            foundEmployee.Should().NotBeNull();
            foundEmployee.Should().BeSameAs(employee);
        }

        [Test]
        public void EmployeesRemoveEmployeeTest()
        {
            var employees = new Employees();
            employees.Should().NotBeNull();
            employees.AddEmployees(EmployeeTestDataProvider.Instance.Employees);
            employees.GetAllEmployees().Should().NotBeNull();
            employees.GetAllEmployees().Count.Should().BeGreaterThan(0);
            int numberOfEmployes = employees.GetAllEmployees().Count;
            Employee firstEmployeeToRemove = EmployeeTestDataProvider.Instance.Employees[0];
            employees.RemoveEmployee(firstEmployeeToRemove.Id);
            employees.GetAllEmployees().Count.Should().BeLessThan(numberOfEmployes);
            Action action = () =>
            {
                Employee foundEmploye = employees.GetEmployeeById(firstEmployeeToRemove.Id);
            };
            action.Should().Throw<Exception>().WithMessage(EXPECTED_EXCEPTION_MESSAGE_OF_FIND);
        }

        [Test]
        public void EmployeesModifyEmployeeTest()
        {
            var employees = new Employees();
            employees.Should().NotBeNull();
            employees.AddEmployees(EmployeeTestDataProvider.Instance.Employees);
            employees.GetAllEmployees().Should().NotBeNull();
            employees.GetAllEmployees().Count.Should().BeGreaterThan(0);
            Employee foundEmployee =
                employees.GetEmployeeById(EmployeeTestDataProvider.Instance.Employees[0].Id);
            foundEmployee.Should().NotBeNull();
            Employee newEmployee = new Employee(foundEmployee.Id, "Elek Mechemed", foundEmployee.JobRole);
            employees.ModifyEmployee(newEmployee);
            Employee foundModifiedEmployee = employees.GetEmployeeById(foundEmployee.Id);
            foundModifiedEmployee.Should().NotBeNull();
            foundModifiedEmployee.Should().BeSameAs(newEmployee);
        }
        #endregion
    }
}
