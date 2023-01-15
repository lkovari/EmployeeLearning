using EmployeeLearning.adapters.displaymodel;
using EmployeeLearning.adapters.displayvideos;
using EmployeeLearning.model.video;

namespace EmployeeLearning.datahandler.videos
{
    public class VideosDataHandler : IVideosDataHandler
    {
        #region PUBLIC PROPERTIES
        public List<Video> Videos { get; private set; }
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
        public void addVideo(Video video)
        {
            Videos.Add(video);
        }

        public void removeVideoById(Guid videoId)
        {
            Videos.Remove(GetVideoById(videoId));
        }

        public void displayAllVideos()
        {
            List<string> allVideos = new();
            Videos.ForEach(video => {
                string textToDisplay = string.Format("ID {0} Tittle {1}", video.Id, video.Name);
                allVideos.Add(textToDisplay);
            });
            AdapterModel adapterModelForAllVideos = new();
            adapterModelForAllVideos.Tittle = "Videos";
            adapterModelForAllVideos.Data.AddRange(allVideos);
            adapterForDisplayVideos.DisplayVideos(adapterModelForAllVideos);
        }

        public Video GetVideoById(Guid videoId)
        {
            return (Video)Videos.Single(v => v.Id == videoId);
        }
        #endregion

    }
}
