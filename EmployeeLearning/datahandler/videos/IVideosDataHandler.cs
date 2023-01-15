using EmployeeLearning.model.video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.datahandler.videos
{
    public interface IVideosDataHandler
    {
        public void addVideo(Video video);
        public void removeVideoById(Guid videoId);
        public void displayAllVideos();
        public Video GetVideoById(Guid videoId);
    }
}
