using EmployeeLearning.model.video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.model.jobrole
{
    public class JobRole : IJobRole
    {
        #region PROPERTIES
        public int Id { get; }
        public string Name { get; }

        private readonly List<Video> _learningPath;
        public List<Video> LearningPath { get { return _learningPath; } }
        #endregion

        public JobRole(int id, string name, List<Video> videos)
        {
            Id = id;
            Name = name;
            _learningPath = videos;
        }

        #region PUBLIC METHODS
        public Video FindVideoById(int videoId)
        {
            return ((Video)(from video in _learningPath where video.Id == videoId select video));
        }

        public void MarkAllAsUnWatched()
        {
            _learningPath.ForEach(v => v.MarkAsUnWatched());
        }
        #endregion
    }
}
