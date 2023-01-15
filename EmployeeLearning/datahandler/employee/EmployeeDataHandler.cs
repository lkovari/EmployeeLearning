using EmployeeLearning.adapters.assignedvideos;
using EmployeeLearning.adapters.displaymodel;
using EmployeeLearning.adapters.watchhistory;
using EmployeeLearning.controller.video;
using EmployeeLearning.datahandler.jobrole;
using EmployeeLearning.model.employee;
using EmployeeLearning.model.employees;
using EmployeeLearning.model.video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.datahandler.employee
{
    public class EmployeeDataHandler : IEmployeeDataHandler
    {
        #region PRIVATE MEMBERS
        private IJobRoleDataHandler jobRoleDataHandler;
        private IVideoDataHandler videoDataHandler;
        #endregion

        #region PUBLIC PROPERTIES
        public Employee Employee { get; private set; }
        #endregion

        #region DISPLAY ADAPTERS
        private IDisplayAssignedVideos displayAssignedVideos;
        private IDisplayHistoryOfWatchedVideos displayHistoryOfWatchedVideos;
        #endregion

        #region CONSTRUCTOR
        public EmployeeDataHandler(Employee employee,
            IDisplayAssignedVideos displayAssignedVideos,
            IDisplayHistoryOfWatchedVideos displayHistoryOfWatchedVideos)
        {
            Employee = employee;
            this.displayAssignedVideos = displayAssignedVideos;
            this.displayHistoryOfWatchedVideos = displayHistoryOfWatchedVideos;

            jobRoleDataHandler = new JobRoleDataHandler(employee.JobRole);
            videoDataHandler = new VideoDataHandler();
        }
        #endregion

        #region PUBLIC METHODS
        public void DisplayAssignedVideos()
        {
            jobRoleDataHandler = new JobRoleDataHandler(Employee.JobRole);
            List<string> assignedVideos = new();
            jobRoleDataHandler.GetAssignedVideos().ForEach(video => {
                string textToDisplay = string.Format("ID {0} Tittle {1}", video.Id, video.Name);
                assignedVideos.Add(textToDisplay);
            });
            AdapterModel adapterModelForAssignedVideos = new();
            adapterModelForAssignedVideos.Tittle = "Assigned Videos to JobRole";
            adapterModelForAssignedVideos.Data.AddRange(assignedVideos);
            displayAssignedVideos.DisplayAssignedVideos(adapterModelForAssignedVideos);
        }

        public void DisplayWatchHistory()
        {
            List<Video> watchedVideos = 
                jobRoleDataHandler.GetAssignedVideos()
                .Where(video => video.IsWatched).ToList();
            AdapterModel adapterModelForHistory = new();
            adapterModelForHistory.Tittle = "Watch History of JobRole's Videos";
            if (watchedVideos.Count > 0)
            {
                List<string> watchHistory = new List<string>();
                watchedVideos.ForEach(video =>
                {
                    string watchHistoryItem = string.Format("Watched at {0} Titlle {1} Total {2}# of Watches",
                        video.WatchDate, video.Name, video.WatchCount);
                    watchHistory.Add(watchHistoryItem);
                });
                adapterModelForHistory.Data.AddRange(watchHistory);
                displayHistoryOfWatchedVideos.DisplayHistory(adapterModelForHistory);
            } else
            {
                adapterModelForHistory.Text = "No Videos Watched!";
                displayHistoryOfWatchedVideos.DisplayHistory(adapterModelForHistory);
            }
        }

        public List<Video> GetAssignedVideos()
        {
            return jobRoleDataHandler.GetAssignedVideos();
        }

        public void WatchingAVideo(Guid videoId)
        {
            List<Video> assignedVideos = jobRoleDataHandler.GetAssignedVideos();
            Video? foundVideo = null;
            try
            {
                foundVideo = assignedVideos.Single(video => video.Id == videoId);
                if (foundVideo != null)
                {
                    videoDataHandler.Video = foundVideo;
                    videoDataHandler.VideoMarkAsWatched();
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

        public void ResetVideoWatches()
        {
            foreach ( Video video in jobRoleDataHandler.GetAssignedVideos())
            {
                videoDataHandler.Video = video;
                videoDataHandler.VideoMarkAsUnWatched();

            }
        }

        public Video GetAssignedVideoById(Guid videoId)
        {
            return jobRoleDataHandler.GetAssignedVideoById(videoId);
        }

        public List<Video> GetWatchedVideos()
        {
            return jobRoleDataHandler.
                GetAssignedVideos().Where(video => video.IsWatched).ToList();
        }
        #endregion
    }
}
