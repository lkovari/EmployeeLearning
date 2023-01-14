using EmployeeLearning.model.video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.controller.video
{
    public interface IVideoDataHandler
    {
        public Video Video { get; set; }
        public void VideoStartingToPlay(int videoId);
        public void VideoStopOfPlay(int videoId);
        public void PlayVideo();
        public void VideoMarkAsWatched();
        public void VideoMarkAsUnWatched();
    }
}
