using EmployeeLearning.testdata.idprovider;
using System.ComponentModel.DataAnnotations;


namespace EmployeeLearning.model
{
    public class BaseModel : ICloneable
    {
        #region PROPERTIES
        private readonly Guid _id;
        public Guid Id { get { return _id; } }

        [Required]
        public string Name { get; set; }
        #endregion

        #region CONSTRUCTOR
        public BaseModel(string? name)
        {
            _id = IdProvider.Instance.NewId;
            if (name == null)
            {
                throw new ArgumentException(string.Format("Parameter {{0}}", name));
            }
            else
            {
                Name = name;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion
    }
}
