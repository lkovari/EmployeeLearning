using EmployeeLearning.model.employee;
using EmployeeLearning.model.jobrole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.builder
{
    public interface IEmployeeBuilder
    {
        void BuildId(int id);
        void BuildLastName(string lastName);
        void BuildFirstName(string firstName);
        void BuildJobRole(JobRole jobRole);
        Employee GetEmployee();
    }
}
