using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.model
{
    public class BaseModel
    {
        #region PROPERTIES
        public Nullable<int> Id { get; }

        public string Name { get; }
        #endregion

        public BaseModel(Nullable<int> id, string? name)
        {
            if (id == null)
            {
                throw new ArgumentException(string.Format("Parameter {{0}}", id));
            } else
            {
                Id = id;
            }
            if (name == null)
            {
                throw new ArgumentException(string.Format("Parameter {{0}}", name));
            } else
            {
                Name = name;
            }
        }
    }
}
