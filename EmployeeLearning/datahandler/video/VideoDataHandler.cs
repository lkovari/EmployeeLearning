using EmployeeLearning.model.video;

namespace EmployeeLearning.controller.video
{
    public class VideoDataHandler : IVideoDataHandler
    {
        #region PROPERTIES
        public Video Video { get; set; }
        #endregion

        #region CONSTRUCTOR
        public VideoDataHandler(Video video)
        {
            Video = video;
        }

        public VideoDataHandler()
        {
        }
        #endregion

        #region PRIVATE METHOD

        private void MarkVideoAsWatched()
        {
            Video.IsWatched = true;
        }

        private void SetVideoWatchDate()
        {
            Video.WatchDate = DateTime.Now;
        }

        private void IncrementWatchCountOfVideo()
        {
            Video.WatchCount++;
        }

        private void MarkVideoAsUnwatched()
        {
            Video.IsWatched = false;
        }

        private void CleanWatchDate()
        {
            Video.WatchDate = null;
        }

        private void CleanWatchCountOfVideo()
        {
            Video.WatchCount = 0;
        }
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// Play a Video what selected to watch
        /// </summary>
        /// <exception cref="NotImplementedException">Not implemented yet</exception>
        public void PlayVideo()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Mark a Video as UnWatched
        /// </summary>
        public void VideoMarkAsUnWatched()
        {
            MarkVideoAsUnwatched();
            CleanWatchDate();
            CleanWatchCountOfVideo();
        }

        /// <summary>
        /// Mark the Video as Watched
        /// </summary>
        public void VideoMarkAsWatched()
        {
            MarkVideoAsWatched();
            SetVideoWatchDate();
            IncrementWatchCountOfVideo();
        }

        /// <summary>
        /// Stop watch of a Video
        /// </summary>
        /// <param name="videoId">The Id of the Video</param>
        /// <exception cref="NotImplementedException">Not implemented yet</exception>
        public void VideoStartingToPlay(int videoId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stop watch of a Video
        /// </summary>
        /// <param name="videoId">The Id of the Video</param>
        /// <exception cref="NotImplementedException">Not implemented yet</exception>
        public void VideoStopOfPlay(int videoId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
