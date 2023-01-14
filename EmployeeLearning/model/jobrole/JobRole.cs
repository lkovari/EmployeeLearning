using EmployeeLearning.model.video;

namespace EmployeeLearning.model.jobrole
{
    public class JobRole : BaseModel
    {

        #region PROPERTIES
        public List<Video> LearningPath { get; }
        #endregion

        public JobRole(string? name, List<Video>? videos) : base(name)
        {
            if (videos == null)
            {
                throw new ArgumentException(string.Format("Parameter {{0}}", videos));
            }
            else
            {
                LearningPath = videos;
            }
        }
    }
}
