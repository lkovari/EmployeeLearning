
using EmployeeLearning.adapters.assignedvideos;
using EmployeeLearning.adapters.displayvideos;
using EmployeeLearning.adapters.watchhistory;
using EmployeeLearning.datahandler.employee;
using EmployeeLearning.datahandler.employees;
using EmployeeLearning.datahandler.videos;
using EmployeeLearning.model.employee;
using EmployeeLearning.testdata.digest;
using EmployeeLearning.testdata.videostore;

namespace EmployeeLearning
{
    internal class Program
    {
        private static int FIRST_EMPLOYE = 0;

        static void Main(string[] args)
        {
            /*
            Console.WriteLine("JDoe >" + CreateDigest.GenerateDigest("JDoe") + "<");
            Console.WriteLine("EDoe >" + CreateDigest.GenerateDigest("EDoe") + "<");
            Console.WriteLine("KDoe >" + CreateDigest.GenerateDigest("KDoe") + "<");
            Console.WriteLine("ZDoe >" + CreateDigest.GenerateDigest("ZDoe") + "<");
            */

            EmployeesDataHandler employeesController = new EmployeesDataHandler();
            Employee employee = employeesController.GetAllEmployees()[FIRST_EMPLOYE];

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

            VideosDataHandler videosDataHandler = new VideosDataHandler(VideoTestDataProvider.Instance.Videos,
                    new DisplayVideosConsoleAdapter());
            videosDataHandler.displayAllVideos();
        }
    }
}
