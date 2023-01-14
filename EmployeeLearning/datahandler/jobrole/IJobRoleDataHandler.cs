using EmployeeLearning.model.video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.datahandler.jobrole
{
    public interface IJobRoleDataHandler
    {
        public void AssignVideo(Video video);
        public void RemoveAssignedVideo(Guid videoId);
        public Video GetAssignedVideoById(Guid videoId);
        public List<Video> GetAssignedVideos();
    }
}
