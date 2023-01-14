﻿using EmployeeLearning.adapters.assignedvideos;
using EmployeeLearning.adapters.watchhistory;
using EmployeeLearning.datahandler.employee;
using EmployeeLearning.model.employee;
using EmployeeLearning.model.employees;
using EmployeeLearning.testdata.employeestorage;

namespace EmployeeLearning.datahandler.employees
{
    public class EmployeesDataHandler : IEmployeesDataHandler
    {
        IEmployeeDataHandler employeeDataHandler;

        private Employees employees = new();

        #region PRIVATE METHODS
        private void ApplyTestData()
        {
            employees.CompanyEmployees.AddRange(EmployeeTestDataProvider.Instance.Employees);
        }
        #endregion

        #region CONSTRUCTOR
        public EmployeesDataHandler()
        {
            #region JUST FOR TESTING PURPOSES
            if (employees.CompanyEmployees.Count < 1)
            {
                ApplyTestData();
            }
            #endregion

            employeeDataHandler =
                new EmployeeDataHandler(employees.CompanyEmployees[0],
                    new DisplayAssignedVideosConsoleAdapter(),
                    new DisplayHistoryOfWatchedVideosConsoleAdapter()
                );
            
        }
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// Add an Employee
        /// </summary>
        /// <param name="employee">Employee</param>
        public void AddEmployee(Employee employee)
        {
            employees.CompanyEmployees.Add(employee);
        }

        /// <summary>
        /// Remove an Employee by id
        /// </summary>
        /// <param name="employeeId">Guid</param>
        /// <exception cref="Exception">Throw when not found the Employee by Id</exception>
        public void RemoveEmployee(Guid employeeId)        
        {
            Employee foundEmployee = employees.CompanyEmployees.Single(e => e.Id == employeeId);
            if (foundEmployee != null)
            {
                employees.CompanyEmployees.Remove(foundEmployee);
            } else
            {
                throw new Exception("EmployeesDataHandler: Employee not found by Id!");
            }
        }

        /// <summary>
        /// Get all Employees
        /// </summary>
        /// <returns>List of Employee</returns>
        public List<Employee> GetAllEmployees()
        {
            return employees.CompanyEmployees;
        }

        /// <summary>
        /// Get Employe by Id
        /// </summary>
        /// <param name="employeeId">The Id of the Employee</param>
        /// <returns>Employee</returns>
        public Employee GetEmployeeById(Guid? employeeId)
        {
            return employees.CompanyEmployees.Single(e => e.Id == employeeId);
        }

        /// <summary>
        /// Add Eployees, so add a List of Employee
        /// </summary>
        /// <param name="employees">List of Employee</param>
        public void AddEmployees(List<Employee> employeesToAdd)
        {
            employees.CompanyEmployees.AddRange(employeesToAdd);
        }

        /// <summary>
        /// Modify Employee, replace the Employe in the list of Employees with the passed
        /// </summary>
        /// <param name="employee">Employee</param>
        /// <exception cref="Exception">Throw when the Employe not found in the Employees</exception>
        public void ModifyEmployee(Employee employee)
        {
            int employeIndex = employees.CompanyEmployees.FindIndex(e => e.Id == employee.Id);
            if (employeIndex != -1)
            {
                employees.CompanyEmployees[employeIndex] = employee;
            }
            else
            {
                throw new Exception("Modify Employee: Employee Not Found in Employees!");
            }
        }
        #endregion
    }
}
