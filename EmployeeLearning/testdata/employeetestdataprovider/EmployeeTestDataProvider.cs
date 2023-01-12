using EmployeeLearning.model.employee;
using EmployeeLearning.model.employees;
using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;
using EmployeeLearning.testdata.idprovider;
using EmployeeLearning.testdata.jobrolestore;
using EmployeeLearning.testdata.videostore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.testdata.employeestorage
{
    public sealed class EmployeeTestDataProvider
    {
        public List<Employee> Employees = new ();

        private EmployeeTestDataProvider()
        {
            Employees.Add(new Employee(IdProvider.NewEmployeeId, "John Doe", JobRoleTestDataProvider.Instance.JobRoles[0]));
            Employees.Add(new Employee(IdProvider.NewEmployeeId, "Jane Doe", JobRoleTestDataProvider.Instance.JobRoles[1]));
            Employees.Add(new Employee(IdProvider.NewEmployeeId, "Jenifer Doe", JobRoleTestDataProvider.Instance.JobRoles[2]));
            Employees.Add(new Employee(IdProvider.NewEmployeeId, "Jack Doe", JobRoleTestDataProvider.Instance.JobRoles[3]));
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
