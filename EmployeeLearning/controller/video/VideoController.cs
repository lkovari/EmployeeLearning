using EmployeeLearning.model.video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.controller.video
{
    public class VideoController : IVideoController
    {
        private Video _video;
        
        public VideoController(Video video) {
            _video = video;
        }

        #region PUBLIC METHODS
        public void MarkAsWatched()
        {
            _video.MarkAsUnWatched();
        }

        public void MarkAsUnWatched()
        {
            _video.MarkAsUnWatched();

        }
        #endregion
    }
}
