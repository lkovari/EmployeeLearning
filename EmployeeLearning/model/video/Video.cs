

namespace EmployeeLearning.model.video
{
    public class Video : IVideo
    {
        #region PROPERTIES
        public Nullable<int> Id { get; set; }
        
        public string Name { get; set; }

        private bool _isWatched;
        public bool IsWatched { get { return _isWatched; } }
        
        private DateTime? _watchDate = null;
        public DateTime? WatchDate { get { return _watchDate; } }

        private int _hitCount = 0;
        public int HitCount { get { return _hitCount; } }
        #endregion

        public Video(Nullable<int> id, string name)
        {
            Id = id;
            Name = name;
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
            _isWatched = true;
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
        public void MarkAsWatched()
        {
            SetupIsWatched();
            SetupWatchDate();
            IncrementHitCount();
        }

        public void MarkAsUnWatched()
        {
            CleanIsWatched();
            CleanWatchDate();
            CleanHitCount();
        }
        #endregion
    }
}
