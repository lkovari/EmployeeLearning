using EmployeeLearning.model.employee;
using EmployeeLearning.model.employees;
using EmployeeLearning.testdata.employeestorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.controller.employees
{
    public class EmployeesController : IEmployeesController
    {
        private Employees employees = new();

        private void ApplyTestData()
        {
            employees.AddEmployees(EmployeeTestDataProvider.Instance.Employees);
        }

        public EmployeesController()
        {
            if (employees.GetAllEmployees().Count < 1)
            {
                ApplyTestData();
            }
        }

        public void AddEmployee(Employee employee)
        {
            employees.AddEmployee(employee);
        }

        public void RemoveEmployee(int employeeId)        
        {
            employees.RemoveEmployee(employeeId);
        }

        public List<Employee> GetAllEmployees()
        {
            return employees.GetAllEmployees();
        }

        public Employee GetEmployeeById(int? employeId)
        {
            return employees.GetEmployeeById(employeId);
        }
    }
}
