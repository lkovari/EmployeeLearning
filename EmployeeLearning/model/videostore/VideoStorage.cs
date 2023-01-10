using EmployeeLearning.model.video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.model.videostore
{
    public sealed class VideoStorage
    {
        public List<Video> Videos = new();
        private VideoStorage()
        {
            Videos.Add(new Video(1, "Video A"));
            Videos.Add(new Video(2, "Video B"));
            Videos.Add(new Video(3, "Video C"));
            Videos.Add(new Video(4, "Video D"));
            Videos.Add(new Video(5, "Video E"));
            Videos.Add(new Video(6, "Video F"));
            Videos.Add(new Video(7, "Video G"));
            Videos.Add(new Video(8, "Video H"));
            Videos.Add(new Video(9, "Video I"));
            Videos.Add(new Video(10, "Video J"));
        }
        private static VideoStorage? videoStorage = null;
        public static VideoStorage Instance
        {
            get { 
                if (videoStorage == null)
                {
                    videoStorage = new VideoStorage();
                }
                return videoStorage;
            }
        }
     }
}
