using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBaseCon;

namespace SqliteDbTests
{
    [TestClass]
    public class SqliteTests
    {
        [TestMethod]
        public void DbContextMustNotBeNull()
        {
            SQLiteConnector con = new SQLiteConnector();
            using (var context = con.GetContext())
            {
                Assert.IsNotNull(context);
                con.SaveData("דוד", "David", true);
            }
            
           
        }
    }
}
