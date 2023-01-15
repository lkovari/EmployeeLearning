using EmployeeLearning.model.employee;
using EmployeeLearning.testdata.employeestorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.model.employees
{
    public class Employees
    {
        #region PROPERTIES
        public List<Employee> CompanyEmployees { get; set;  }
        #endregion

        #region CONSTRUCTOR
        public Employees() {
            CompanyEmployees = new List<Employee>();
        }
        #endregion
    }
}
