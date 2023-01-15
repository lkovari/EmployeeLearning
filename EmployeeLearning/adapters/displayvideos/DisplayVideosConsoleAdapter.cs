using EmployeeLearning.adapters.displaymodel;

namespace EmployeeLearning.adapters.displayvideos
{
    public class DisplayVideosConsoleAdapter : IDisplayVideos
    {
        /// <summary>
        /// Display Videos
        /// </summary>
        /// <param name="model">AdapterModel</param>
        void IDisplayVideos.DisplayVideos(AdapterModel model)
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
