using EmployeeLearning.model.video;

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
