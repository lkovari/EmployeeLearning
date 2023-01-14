using EmployeeLearning.model.employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.datahandler.employees
{
    public interface IEmployeesDataHandler
    {
        public void AddEmployees(List<Employee> employees);
        public void AddEmployee(Employee employee);
        public void RemoveEmployee(Guid employeeId);
        public void ModifyEmployee(Employee employee);
        public List<Employee> GetAllEmployees();
        public Employee GetEmployeeById(Guid? employeeId);
    }
}
