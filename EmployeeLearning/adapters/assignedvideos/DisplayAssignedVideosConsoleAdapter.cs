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
            Console.WriteLine(); 
            Console.WriteLine(model.Tittle);
            if (model.Data != null && model.Data.Count > 0)
            {
                model.Data.ForEach(d => Console.WriteLine(d));
            }
            Console.WriteLine();
        }
    }
}
