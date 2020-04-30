using System;
using System.Data.Entity;

namespace DataBaseCon
{
    public class SQLiteConnector
    {
        public NamesModel GetContext()
        {
            NamesModel sqlontext = new NamesModel();
            return sqlontext;
        }
        public async void  SaveData(string hebrew, string english, bool isGoogle)
        {
            using (var db = GetContext())
            {
                var data =await db.Names.ToListAsync();
                foreach (var item in data)
                {
                    Console.WriteLine(item.English + " " + item.Hebrew);
                }
                var newEntry = new Names() { DateUpdated = DateTime.Now.ToString(), DateCreated = DateTime.Now.ToString(), Hebrew = hebrew, English = english, IsGoogle = isGoogle };
                db.Names.Add(newEntry);
                db.SaveChanges();
            }





        }

    }



}