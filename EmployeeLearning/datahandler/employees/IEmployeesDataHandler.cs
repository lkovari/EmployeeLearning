using EmployeeLearning.model.employee;

namespace EmployeeLearning.datahandler.employees
{
    public interface IEmployeesDataHandler
    {
        public void AddEmployees(List<Employee> employees);
        public void AddEmployee(Employee employee);
        public void RemoveEmployee(Guid employeeId);
        public void ModifyEmployee(Employee employee);
        public List<Employee> GetAllEmployees();
        public Employee GetEmployeeById(Guid? employeeId);
        public Employee GetEmployeeByUserName(string userName);
    }
}
