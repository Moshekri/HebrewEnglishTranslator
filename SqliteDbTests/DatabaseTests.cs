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

                var r2 = con.GetRecord("דוד");
                Assert.IsNotNull(r2);
                Assert.AreEqual(r2.Result.Hebrew, "דוד");
                Assert.AreEqual(r2.Result.English, "David");



            }
        }
        [TestMethod]
        public void MuseReturnNameWhenUsingId()
        {
            SQLiteConnector con = new SQLiteConnector();
            using (var context = con.GetContext())
            {
                var r1 = con.GetRecord(1);
                Assert.IsNotNull(r1);
                Assert.AreEqual(r1.Hebrew, "משה");
                Assert.AreEqual(r1.English, "Moshe");
            }
        }
        [TestMethod]
        public void MuseReturnNameWhenUsingHebrewName()
        {
            SQLiteConnector con = new SQLiteConnector();
            using (var context = con.GetContext())
            {
                var r1 = con.GetRecord(1);
                Assert.IsNotNull(r1);
                Assert.AreEqual(r1.Hebrew, "משה");
                Assert.AreEqual(r1.English, "Moshe");
            }
        }
        [TestMethod]
        public void MuseReturnNameWhenUsingWrongId()
        {
            SQLiteConnector con = new SQLiteConnector();
            using (var context = con.GetContext())
            {
                var r3 = con.GetRecord(4);
                Assert.IsNull(r3);
            }
        }
        [TestMethod]
        public void MuseReturnNameWhenUsingWrongHebrewName()
        {
            SQLiteConnector con = new SQLiteConnector();
            using (var context = con.GetContext())
            {
                var r2 = con.GetRecord("ניסים");
                Assert.IsNull(r2.Result);

            }
        }


    }
}

