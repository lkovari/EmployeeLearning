using EmployeeLearning.model.employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.model.employees
{
    public interface IEmployees
    {
        public void AddEmployees(List<Employee> employees);
        public void AddEmployee(Employee employee);
        public void ModifyEmployee(Employee employee);
        public void RemoveEmployee(int? EmployeeId);
        public List<Employee> GetAllEmployees();
        public Employee GetEmployeeById(int? employeeId);
    }
}
