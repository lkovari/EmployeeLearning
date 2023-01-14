using EmployeeLearning.model.video;

namespace EmployeeLearning.testdata.videostore
{
    public sealed class VideoTestDataProvider
    {
        public readonly List<Video> Videos = new();
        private VideoTestDataProvider()
        {
            Videos.Add(new Video("Video A"));
            Videos.Add(new Video("Video B"));
            Videos.Add(new Video("Video C"));
            Videos.Add(new Video("Video D"));
            Videos.Add(new Video("Video E"));
            Videos.Add(new Video("Video F"));
            Videos.Add(new Video("Video G"));
            Videos.Add(new Video("Video H"));
            Videos.Add(new Video("Video I"));
            Videos.Add(new Video("Video J"));
        }
        private static VideoTestDataProvider? videoStorage = null;
        public static VideoTestDataProvider Instance
        {
            get
            {
                videoStorage ??= new VideoTestDataProvider();
                return videoStorage;
            }
        }
    }
}
