using EmployeeLearning.model.employee;
using EmployeeLearning.model.jobrole;
using EmployeeLearning.testdata.jobrolestore;

namespace EmployeeLearning.testdata.employeestorage
{
    public sealed class EmployeeTestDataProvider
    {
        public List<Employee> Employees = new ();

        private EmployeeTestDataProvider()
        {
            List<JobRole> jobRoles1 = new();
            jobRoles1.Add(JobRoleTestDataProvider.Instance.JobRoles[0]);
            jobRoles1.Add(JobRoleTestDataProvider.Instance.JobRoles[1]);
            Employees.Add(new Employee("John Doe",
                "JDoe",
                "WPM961MtfBONmDTjCqMhNw==",
                jobRoles1));
            List<JobRole> jobRoles2 = new();
            jobRoles2.Add(JobRoleTestDataProvider.Instance.JobRoles[2]);
            jobRoles2.Add(JobRoleTestDataProvider.Instance.JobRoles[3]);
            Employees.Add(new Employee("Elenor Doe",
                "EDoe",
                "DZR6Iys/x8NB1N5ETZpYMw==",
                jobRoles2));
            List<JobRole> jobRoles3 = new();
            jobRoles3.Add(JobRoleTestDataProvider.Instance.JobRoles[2]);
            jobRoles3.Add(JobRoleTestDataProvider.Instance.JobRoles[3]);
            Employees.Add(new Employee("Karman Doe",
                "KDoe",
                "s4z0Cj7DG2Z2q2mCsliNAQ==",
                jobRoles3));
            List<JobRole> jobRoles4 = new();
            jobRoles4.Add(JobRoleTestDataProvider.Instance.JobRoles[4]);
            jobRoles4.Add(JobRoleTestDataProvider.Instance.JobRoles[5]);
            Employees.Add(new Employee("Zoe Doe",
                "ZDoe",
                "QGxoB+wqfx/K+jBAGspHBg==",
                jobRoles4));
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
