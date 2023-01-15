using EmployeeLearning.adapters.displaymodel;


namespace EmployeeLearning.adapters.displayjobroles
{
    public class DisplayJobRolesConsoleAdapter : IDisplayJobRoles
    {
        /// <summary>
        /// Display JobRoles
        /// </summary>
        /// <param name="model">AdapterModel</param>
        public void DisplayJobRole(AdapterModel model)
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
