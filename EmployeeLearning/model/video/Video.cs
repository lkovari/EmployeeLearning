
namespace EmployeeLearning.model.video
{
    public class Video : BaseModel
    {
        #region PROPERTIES
        public bool IsWatched { get; set; }
        public DateTime? WatchDate { get; set; }

        public int WatchCount { get; set; }
        public int Completed { get; set; }
        public int DurationInMins { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Video(string? name) : base(name)
        {
            IsWatched = false;
            WatchDate = null;
            WatchCount = 0;
            Completed = 0;
            DurationInMins = 0;
        }
        #endregion
    }
}
