using EmployeeLearning.testdata.idprovider;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.model
{
    public class BaseModel
    {
        #region PROPERTIES
        private readonly Guid _id;
        public Guid Id { get { return _id; } }

        [Required]
        public string Name { get; }
        #endregion

        #region CONSTRUCTOR
        public BaseModel(string? name)
        {
            _id = IdProvider.Instance.NewId;
            if (name == null)
            {
                throw new ArgumentException(string.Format("Parameter {{0}}", name));
            } else
            {
                Name = name;
            }
        }
        #endregion
    }
}
