using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.model.video
{
    public class Video : IVideo
    {
        #region PROPERTIES
        public int Id { get; }
        
        public string Name { get; }
        
        private bool _isWatched;
        public bool IsWatched { get { return _isWatched; } }
        
        private DateTime? _watched = null;
        public DateTime? Watched { get { return _watched; } }
        #endregion

        public Video(int id, string name)
        {
            Id = id;
            Name = name;
        }

        #region PUBLIC METHODS
        public void MarkAsWatched()
        {
            _isWatched = true;
            _watched = DateTime.Now;
        }

        public void MarkAsUnWatched()
        {
            _isWatched = false;
            _watched = null;
        }
        #endregion
    }
}
