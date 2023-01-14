
using EmployeeLearning.adapters.assignedvideos;
using EmployeeLearning.adapters.watchhistory;
using EmployeeLearning.datahandler.employee;
using EmployeeLearning.datahandler.employees;
using EmployeeLearning.model.employee;

namespace EmployeeLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeesDataHandler employeesController = new EmployeesDataHandler();
            Employee employee = employeesController.GetAllEmployees()[0];

            EmployeeDataHandler employeeController = 
                new EmployeeDataHandler(employee,
                    new DisplayAssignedVideosConsoleAdapter(),
                    new DisplayHistoryOfWatchedVideosConsoleAdapter()
                );
            employeeController.DisplayAssignedVideos();
            employeeController.GetAssignedVideos().ForEach(video => {
                employeeController.WatchingAVideo(video.Id);
                employeeController.WatchingAVideo(video.Id);
            });
            employeeController.DisplayWatchHistory();
        }
    }
}
