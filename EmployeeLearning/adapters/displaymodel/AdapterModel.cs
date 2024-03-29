﻿
namespace EmployeeLearning.adapters.displaymodel
{
    public class AdapterModel
    {
        public string? Tittle { get; set; }
        public Dictionary<string, object>? Parameters { get; set; } // for future parameters
        public string? Text { get; set; }
        public List<string> Data { get; set; }

        public AdapterModel()
        {
            Data = new List<string>();
        }
    }
}
