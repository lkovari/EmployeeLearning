using EmployeeLearning.model.employee;
using EmployeeLearning.testdata.jobrolestore;

namespace EmployeeLearning.testdata.employeestorage
{
    public sealed class EmployeeTestDataProvider
    {
        public List<Employee> Employees = new ();

        private EmployeeTestDataProvider()
        {
            Employees.Add(new Employee("John Doe",
                "JDoe",
                "WPM961MtfBONmDTjCqMhNw==",
                JobRoleTestDataProvider.Instance.JobRoles[0]));
            Employees.Add(new Employee("Elenor Doe",
                "EDoe",
                "DZR6Iys/x8NB1N5ETZpYMw==",
                JobRoleTestDataProvider.Instance.JobRoles[1]));
            Employees.Add(new Employee("Karman Doe",
                "KDoe",
                "s4z0Cj7DG2Z2q2mCsliNAQ==",
                JobRoleTestDataProvider.Instance.JobRoles[2]));
            Employees.Add(new Employee("Zoe Doe",
                "ZDoe",
                "QGxoB+wqfx/K+jBAGspHBg==",
                JobRoleTestDataProvider.Instance.JobRoles[3]));
        }
        private static EmployeeTestDataProvider? employeeStorage = null;
        public static EmployeeTestDataProvider Instance
        {
            get
            {
                employeeStorage ??= new EmployeeTestDataProvider();
                return employeeStorage;
            }
        }
    }
}
