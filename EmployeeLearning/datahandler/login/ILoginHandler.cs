using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.datahandler.login
{
    public interface ILoginHandler
    {
        public bool Login(string username, string password);
    }
}
