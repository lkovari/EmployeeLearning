using EmployeeLearning.model.employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.controller.employees
{
    public interface IEmployeesController
    {
        public void AddEmployee(Employee employee);
        public void RemoveEmployee(int employeeId);
        public List<Employee> GetAllEmployees();
        public Employee GetEmployeeById(int? employeId);
    }
}
