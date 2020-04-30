using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

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

        public async Task<List<Names>> GetAllRecords()
        {
            using (var db = GetContext())
            {
                var data =  await db.Names.ToListAsync();
                return data;
            }
        }

        public  Names GetRecord(int id)
        {
            using (var db = GetContext())
            {
              return  db.Names.Find(new object[]{id});
            }
        }
        public async Task<Names> GetRecord(string HebrewName)
        {
            using (var db = GetContext())
            {
                return await db.Names.FirstOrDefaultAsync(r => r.Hebrew == HebrewName);
            }
        }

    }



}