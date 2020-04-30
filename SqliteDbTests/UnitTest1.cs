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
                var r1 = con.GetRecord(1);
                Assert.IsNotNull(r1);
                Assert.AreEqual(r1.Hebrew, "משה");
                Assert.AreEqual(r1.English, "Moshe");
                var r2 = con.GetRecord("דוד");
                Assert.IsNotNull(r2);
                Assert.AreEqual(r2.Result.Hebrew, "דוד");
                Assert.AreEqual(r2.Result.English, "David");

                var r3 = con.GetRecord(4);
                Assert.IsNull(r3);
                var r4 = con.GetRecord("חיים");
                Assert.IsNull(r4.Result);
                 

            }


        }
    }
}
