using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCon.Factories
{
    public static class DbConnectorFactory
    {
        public static IDbConnector GetDbConnector()
        {
            IDbConnector con = new SQLiteConnector();
            return con;
        }
    }
}
