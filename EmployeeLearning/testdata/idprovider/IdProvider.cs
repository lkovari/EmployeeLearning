using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLearning.testdata.idprovider
{
    public static class IdProvider
    {
        private static int _lastVideoId = 0;
        public static int NewVideoId { get { return _lastVideoId++; } }

        private static int _lastJobRoleId = 0;
        public static int NewJobRoleId { get { return _lastJobRoleId++; } }

        private static int _lastEmployeeId = 0;
        public static int NewEmployeeId { get { return _lastEmployeeId++; } }

    }
}
