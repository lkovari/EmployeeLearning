using EmployeeLearning.adapters.displaymodel;

namespace EmployeeLearning.adapters.watchhistory
{
    public class DisplayHistoryOfWatchedVideosConsoleAdapter : IDisplayHistoryOfWatchedVideos
    {
        public void DisplayHistory(AdapterModel model)
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
