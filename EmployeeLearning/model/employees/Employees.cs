using EmployeeLearning.model.employee;

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
