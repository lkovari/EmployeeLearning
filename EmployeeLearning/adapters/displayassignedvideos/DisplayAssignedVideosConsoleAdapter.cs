using EmployeeLearning.adapters.displaymodel;

namespace EmployeeLearning.adapters.assignedvideos
{
    public class DisplayAssignedVideosConsoleAdapter : IDisplayAssignedVideos
    {
        /// <summary>
        /// Display assigned Videos
        /// </summary>
        /// <param name="model"></param>
        public void DisplayAssignedVideos(AdapterModel model)
        {
            Console.WriteLine(); 
            Console.WriteLine(model.Tittle);
            if (model.Data != null && model.Data.Count > 0)
            {
                model.Data.ForEach(data => Console.WriteLine(data));
            }
            Console.WriteLine();
        }
    }
}
