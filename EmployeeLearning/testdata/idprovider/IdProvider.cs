using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.testdata.idprovider
{
    public sealed class IdProvider
    {
        public Guid NewId => Guid.NewGuid();

        private static IdProvider? idProvider = null;
        public static IdProvider Instance
        {
            get
            {
                idProvider ??= new IdProvider();
                return idProvider;
            }
        }
    }
}
