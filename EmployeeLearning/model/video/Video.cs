

using System.Runtime.Serialization;
using System;
using System.Transactions;

namespace EmployeeLearning.model.video
{
    public class Video : BaseModel, IVideo
    {
        #region PROPERTIES
        private bool _isWatched;
        public bool IsWatched { get { return _isWatched; } }
        
        private DateTime? _watchDate = null;
        public DateTime? WatchDate { get { return _watchDate; } }

        private int _hitCount = 0;
        public int HitCount { get { return _hitCount; } }
        public int Completed { get; }
        public int DurationInMins { get; }
        #endregion

        public Video(Nullable<int> id, string? name) : base(id, name)
        {
        }

        #region PRIVATE METHOD

        private void SetupIsWatched()
        {
            _isWatched = true;
        }

        private void SetupWatchDate()
        {
            _watchDate = DateTime.Now;
        }

        private void IncrementHitCount()
        {
            _hitCount++;
        }

        private void CleanIsWatched()
        {
            _isWatched = false;
        }

        private void CleanWatchDate()
        {
            _watchDate = null;
        }

        private void CleanHitCount()
        {
            _hitCount = 0;
        }
        #endregion

        #region PUBLIC METHODS
        public void VideoMarkAsWatched()
        {
            SetupIsWatched();
            SetupWatchDate();
            IncrementHitCount();
        }

        public void VideoMarkAsUnWatched()
        {
            CleanIsWatched();
            CleanWatchDate();
            CleanHitCount();
        }
        #endregion
    }
}
