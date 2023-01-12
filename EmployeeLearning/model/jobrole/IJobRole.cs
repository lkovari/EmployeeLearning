using EmployeeLearning.model.video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.model.jobrole
{
    public interface IJobRole
    {
        public void AssignVideoToJobRole(Video video);
        public void UnassignedVideoFromJobRole(int videoId);
        public Video FindVideoByIdOfJobRole(int videoId);
        public List<Video> GetAssignedVideosOfJobRole();
    }
}
