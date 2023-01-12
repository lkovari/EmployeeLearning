using EmployeeLearning.controller.employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using EmployeeLearning.controller.employees;
using EmployeeLearning.model.employee;
using EmployeeLearning.adapters.assignedvideos;
using EmployeeLearning.adapters.watchhistory;
using EmployeeLearning.testdata.jobrolestore;
using EmployeeLearning.testdata.idprovider;

namespace EmployeeLearningTests
{
    public class ControllersTest
    {
        [Test]
        public void EmployeesControllerInstanceTest()
        {
            EmployeesController employeesController = new EmployeesController();
            employeesController.Should().NotBeNull();
        }

        [Test]
        public void EmployeeControllerInstanceTest()
        {
            EmployeesController employeesController = new EmployeesController();
            Employee employee = employeesController.GetAllEmployees()[0];

            EmployeeController employeeController =
                new EmployeeController(employee,
                    new DisplayAssignedVideosConsoleAdapter(),
                    new DisplayHistoryOfWatchedVideosConsoleAdapter()
                );
            employeeController.Should().NotBeNull();
        }

        [Test]
        public void EmployeesControllerAllEmployeeTest()
        {
            EmployeesController employeesController = new EmployeesController();
            List<Employee>? employees = employeesController.GetAllEmployees();
            employees.Should().NotBeNull();
            employees.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void EmployeesControllerAddEmployeeTest()
        {
            EmployeesController employeesController = new EmployeesController();
            int numberOfEmployee = employeesController.GetAllEmployees().Count;
            Employee newEmployee = new(IdProvider.NewJobRoleId, "Erika Gusbakothy", JobRoleTestDataProvider.Instance.JobRoles[0]);
            newEmployee.Should().NotBeNull();
            employeesController.AddEmployee(newEmployee);
            Employee foundEmployee = employeesController.GetEmployeeById(newEmployee.Id);
            foundEmployee.Should().NotBeNull();
            foundEmployee.Should().BeSameAs(newEmployee);
            employeesController.GetAllEmployees().Count.Should().BeGreaterThan(numberOfEmployee);
        }

    }
}
