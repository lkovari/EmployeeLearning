using EmployeeLearning.adapters.displaymodel;
using EmployeeLearning.adapters.displayvideos;
using EmployeeLearning.model.video;

namespace EmployeeLearning.datahandler.videos
{
    public class VideosDataHandler : IVideosDataHandler
    {
        #region PUBLIC PROPERTIES
        private List<Video> Videos { get; set; }
        #endregion

        #region DISPLAY ADAPTERS
        private IDisplayVideos adapterForDisplayVideos;
        #endregion

        public VideosDataHandler(List<Video> videos, IDisplayVideos displayVideosAdapter)
        {
            Videos = videos;
            adapterForDisplayVideos = displayVideosAdapter;
        }

        #region PUBLIC METHODS
        /// <summary>
        /// Add a Video
        /// </summary>
        /// <param name="video">Video</param>
        public void addVideo(Video video)
        {
            Videos.Add(video);
        }

        /// <summary>
        /// Remove a Video by Id
        /// </summary>
        /// <param name="videoId">Guid</param>
        public void removeVideoById(Guid videoId)
        {
            Videos.Remove(GetVideoById(videoId));
        }

        /// <summary>
        /// Display All available Videos
        /// </summary>
        public void displayAllVideos()
        {
            List<string> allVideos = new();
            Videos.ForEach(video => {
                string textToDisplay = string.Format("ID {0} Tittle {1}", video.Id, video.Name);
                allVideos.Add(textToDisplay);
            });
            AdapterModel adapterModelForAllVideos = new();
            adapterModelForAllVideos.Tittle = "Available Videos";
            adapterModelForAllVideos.Data.AddRange(allVideos);
            adapterForDisplayVideos.DisplayVideos(adapterModelForAllVideos);
        }

        /// <summary>
        /// Get Video by Id
        /// </summary>
        /// <param name="videoId">Guid</param>
        /// <returns>Video</returns>
        public Video GetVideoById(Guid videoId)
        {
            return (Video)Videos.Single(v => v.Id == videoId);
        }

        /// <summary>
        /// Get all available Videos
        /// </summary>
        /// <returns>List<Video></returns>
        public List<Video> getAllVideos()
        {
            return Videos;
        }
        #endregion

    }
}
