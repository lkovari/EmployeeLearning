using EmployeeLearning.adapters.displaymodel;

namespace EmployeeLearning.adapters.watchhistory
{
    public class DisplayHistoryOfWatchedVideosConsoleAdapter : IDisplayHistoryOfWatchedVideos
    {
        public void DisplayHistory(AdapterModel model)
        {
            Console.WriteLine(model.Text);
        }
    }
}
