using EmployeeLearning.builder;
using EmployeeLearning.model.jobrole;

namespace EmployeeLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeBuilder employeeBuilder = new EmployeeBuilder();
            employeeBuilder.BuildId(0);
            employeeBuilder.BuildLastName("John");
            employeeBuilder.BuildFirstName("Doe");
            employeeBuilder.BuildJobRole(new JobRole());
        }
    }
}
