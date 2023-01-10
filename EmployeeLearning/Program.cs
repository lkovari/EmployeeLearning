using EmployeeLearning.model.employee;
using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;
using EmployeeLearning.model.videostore;

namespace EmployeeLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>(); 
            List<Video> learningPathVideos1 = new()
            {
                VideoStorage.Instance.Videos[0],
                VideoStorage.Instance.Videos[1]
            };
            JobRole jobRole = new JobRole(0, "Role A", learningPathVideos1); ;
            employees.Add(new Employee(0, "John", "Doe", jobRole));
            List<Video> learningPathVideos2 = new()
            {
                VideoStorage.Instance.Videos[2],
                VideoStorage.Instance.Videos[3],
                VideoStorage.Instance.Videos[4]
            };
            jobRole = new JobRole(0, "Role B", learningPathVideos2); ;
            employees.Add(new Employee(0, "Jane", "Doe", jobRole));
            List<Video> learningPathVideos3 = new()
            {
                VideoStorage.Instance.Videos[5],
                VideoStorage.Instance.Videos[6],
                VideoStorage.Instance.Videos[7]
            };
            jobRole = new JobRole(0, "Role C", learningPathVideos3); ;
            employees.Add(new Employee(0, "Jenifer", "Doe", jobRole));
            List<Video> learningPathVideos4 = new()
            {
                VideoStorage.Instance.Videos[8],
                VideoStorage.Instance.Videos[9]
            };
            jobRole = new JobRole(0, "Role D", learningPathVideos4);
            employees.Add(new Employee(0, "Jaime", "Doe", jobRole));

            employees.ElementAt(0).JobRole.LearningPath.ElementAt(0).MarkAsWatched();
            employees.ElementAt(0).JobRole.LearningPath.ElementAt(0).MarkAsWatched();
        }
    }
}
