using EmployeeLearning.model.video;
using EmployeeLearning.testdata.idprovider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.testdata.videostore
{
    public sealed class VideoTestDataProvider
    {
        public readonly List<Video> Videos = new();
        private VideoTestDataProvider()
        {
            Videos.Add(new Video(IdProvider.NewVideoId, "Video A"));
            Videos.Add(new Video(IdProvider.NewVideoId, "Video B"));
            Videos.Add(new Video(IdProvider.NewVideoId, "Video C"));
            Videos.Add(new Video(IdProvider.NewVideoId, "Video D"));
            Videos.Add(new Video(IdProvider.NewVideoId, "Video E"));
            Videos.Add(new Video(IdProvider.NewVideoId, "Video F"));
            Videos.Add(new Video(IdProvider.NewVideoId, "Video G"));
            Videos.Add(new Video(IdProvider.NewVideoId, "Video H"));
            Videos.Add(new Video(IdProvider.NewVideoId, "Video I"));
            Videos.Add(new Video(IdProvider.NewVideoId, "Video J"));
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
