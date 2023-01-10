using EmployeeLearning.builder;
using EmployeeLearning.model.employee;
using EmployeeLearning.model.jobrole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.controller.employee
{
    public class EmployeeController : IEmployeeController
    {
        private Employee _employee;

        public EmployeeController(Employee employee)
        {
            _employee = employee;
        }

        public void SetupJobRole(JobRole jobRole)
        {
            _employee.JobRole = jobRole;
        }
    }
}
