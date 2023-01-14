using EmployeeLearning.adapters.displaymodel;

namespace EmployeeLearning.adapters.assignedvideos
{
    public class DisplayAssignedVideosConsoleAdapter : IDisplayAssignedVideos
    {
        /// <summary>
        /// Display assigned Video row
        /// </summary>
        /// <param name="model"></param>
        public void DisplayAssignedVideos(AdapterModel model)
        {
            Console.WriteLine(model.Text);
        }
    }
}
