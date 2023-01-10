using EmployeeLearning.model.employee;
using EmployeeLearning.model.jobrole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.builder
{
    public class EmployeeBuilder : IEmployeeBuilder
    {
        private Employee _employee = new Employee();

        public void BuildFirstName(string firstName)
        {
            _employee.FirstName = firstName;
        }

        public void BuildId(int id)
        {
            _employee.Id = id;
        }

        public void BuildJobRole(JobRole jobRole)
        {
            _employee.JobRole = jobRole;
        }

        public void BuildLastName(string lastName)
        {
            _employee.LastName = lastName;
        }

        public Employee GetEmployee()
        {
            return _employee;
        }
    }
}
