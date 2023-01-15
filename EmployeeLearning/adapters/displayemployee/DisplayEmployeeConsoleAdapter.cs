using EmployeeLearning.adapters.displaymodel;

namespace EmployeeLearning.adapters.displayemployee
{
    public class DisplayEmployeeConsoleAdapter : IDisplayEmployee
    {
        /// <summary>
        /// Display Employee Data
        /// </summary>
        /// <param name="model">AdapterModel</param>
        public void DisplayEmployee(AdapterModel model)
        {
            Console.WriteLine();
            Console.WriteLine(model.Tittle);
            Console.WriteLine(model.Text);
            Console.WriteLine();
        }
    }
}
