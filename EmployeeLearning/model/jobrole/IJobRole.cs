﻿using EmployeeLearning.model.video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.model.jobrole
{
    public interface IJobRole
    {
        public void addVideo(Video video);
        public void removeVideo(int videoId);
        public Video FindVideoById(int videoId);
        public void MarkAllAsUnWatched();
        public List<Video> GetWatchedVideos();
        public List<Video> GetAllVideos();
    }
}
