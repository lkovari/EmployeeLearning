﻿using EmployeeLearning.adapters.displaymodel;

namespace EmployeeLearning.adapters.watchhistory
{
    public class DisplayHistoryOfWatchedVideosConsoleAdapter : IDisplayHistoryOfWatchedVideos
    {
        /// <summary>
        /// Display Watched Videos History
        /// </summary>
        /// <param name="model">AdapterModel</param>
        public void DisplayHistory(AdapterModel model)
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
