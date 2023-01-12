
using EmployeeLearning.adapters.assignedvideos;
using EmployeeLearning.adapters.watchhistory;
using EmployeeLearning.controller.employee;
using EmployeeLearning.controller.employees;
using EmployeeLearning.model.employee;

namespace EmployeeLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeesController employeesController = new EmployeesController();
            Employee employee = employeesController.GetAllEmployees()[0];

            EmployeeController employeeController = 
                new EmployeeController(employee,
                    new DisplayAssignedVideosConsoleAdapter(),
                    new DisplayHistoryOfWatchedVideosConsoleAdapter()
                );
            employeeController.DisplayJobRoleBasedAssignedVideos();
            employeeController.GetAssignedVideos().ForEach(video => {
                employeeController.WatchingAVideo(video.Id);
                employeeController.WatchingAVideo(video.Id);
            });
            employeeController.DisplayWatchHistory();
        }
    }
}
