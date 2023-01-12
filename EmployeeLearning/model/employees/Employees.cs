using EmployeeLearning.model.employee;
using EmployeeLearning.testdata.employeestorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.model.employees
{
    public class Employees : IEmployees
    {
        private List<Employee> employees;

        public Employees() {
            employees = new List<Employee>();
        }

        public void AddEmployees(List<Employee> employeesRange)
        {
            employees.AddRange(employeesRange);
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public void ModifyEmployee(Employee employee)
        {
            int employeIndex = employees.FindIndex(e => e.Id == employee.Id);

            if (employeIndex != -1)
            {
                employees[employeIndex] = employee;
            } else
            {
                throw new Exception("Modify Employee: Employee Not Found in Employees!");
            }
                
        }

        public void RemoveEmployee(int? employeeId)
        {
            bool isSuccess = employees.Remove(GetEmployeeById(employeeId));
            if (!isSuccess)
            {
                throw new Exception("Remove Employee: Employee Not Found in Employees!");
            }
        }

        public Employee GetEmployeeById(int? employeeId)
        {
            Employee? foundEmployee = null;
            try
            {
                foundEmployee = employees.Single(e => e.Id == employeeId);
            }
            catch (Exception)
            {
                throw new Exception("GetEmployeeById: Employee Not Found by Id!");
            }
            return foundEmployee;
        }
    }
}
