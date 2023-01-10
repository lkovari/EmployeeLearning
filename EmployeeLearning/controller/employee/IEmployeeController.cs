using EmployeeLearning.model.employee;
using EmployeeLearning.model.jobrole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.controller.employee
{
    public interface IEmployeeController
    {
        public void SetupJobRole(JobRole jobRole);
    }
}
