using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.model.employee
{
    public class Employee : IEmployee
    {
        #region PROPERTIES
        public int Id { get; }
        public string LastName { get; }
        public string FirstName { get; }

        private readonly JobRole _jobRole;
        public JobRole JobRole { get { return _jobRole; } }
        #endregion

        public Employee(int id, string lastName, string firstName, JobRole jobRole)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            _jobRole = jobRole;
        }

        #region PUBLIC METHODS
        public void WatcVideo(int videoId)
        {
            _jobRole.FindVideoById(videoId).MarkAsWatched();
        }

        public void MarkAllVideoAsUnWatched()
        {
            _jobRole.MarkAllAsUnWatched();
        }
        #endregion
    }
}
