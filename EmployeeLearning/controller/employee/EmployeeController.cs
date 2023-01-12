using EmployeeLearning.adapters.assignedvideos;
using EmployeeLearning.adapters.watchhistory;
using EmployeeLearning.model.employee;
using EmployeeLearning.model.employees;
using EmployeeLearning.model.video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.controller.employee
{
    public class EmployeeController : IEmployeeController
    {
        private IDisplayAssignedVideos DisplayAssignedVideos;
        private IDisplayHistoryOfWatchedVideos DisplayHistoryOfWatchedVideos;
        private readonly Employee employee;

        public EmployeeController(Employee employee,
            IDisplayAssignedVideos displayAssignedVideos,
            IDisplayHistoryOfWatchedVideos displayHistoryOfWatchedVideos)
        {
            this.employee = employee;
            DisplayAssignedVideos = displayAssignedVideos;
            DisplayHistoryOfWatchedVideos = displayHistoryOfWatchedVideos;
        }

        public void DisplayJobRoleBasedAssignedVideos()
        {
            employee.JobRole.GetAssignedVideosOfJobRole().ForEach(video => {
                string textToDisplay = string.Format("ID {0} Tittle {1}", video.Id, video.Name);
                DisplayAssignedVideos.DisplayAssignedVideos(textToDisplay);
            });
        }

        public void DisplayWatchHistory()
        {
            if (employee.GetWatchedVideos().Count > 0)
            {
                employee.GetWatchedVideos().ForEach(video =>
                {
                    DisplayHistoryOfWatchedVideos.DisplayHistory(
                        string.Format("Watched at {0} Titlle {1} Total {2}# of Watches",
                        video.WatchDate, video.Name, video.HitCount));
                });
            } else
            {
                DisplayHistoryOfWatchedVideos.DisplayHistory("No Videos Watched!");
            }
        }

        public List<Video> GetAssignedVideos()
        {
            return employee.GetAssignedVideos();
        }

        public void WatchingAVideo(int? videoId)
        {
            List<Video> assignedVideos = GetAssignedVideos();
            Video? foundVideo = null;
            try
            {
                foundVideo = assignedVideos.Single(video => video.Id == videoId);
                if (foundVideo != null)
                {
                    GetAssignedVideos()[assignedVideos.IndexOf(foundVideo)].VideoMarkAsWatched();
                } else
                {
                    throw new Exception("WatchingVideo: Video Not Found by Id!");
                }
            }
            catch (Exception)
            {
                throw new Exception("WatchingAVideo: Video Not Found by Id!");
            }
        }

        public void WatchingAVideo(int videoId)
        {
            Video video = employee.JobRole.FindVideoByIdOfJobRole(videoId);
            video.VideoMarkAsWatched();
        }
    }
}
