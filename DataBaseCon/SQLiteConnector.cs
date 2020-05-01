using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Common.Models;
using Common.Poco;


namespace DataBaseCon
{
    public class SQLiteConnector 
    {
        public NamesModel GetContext()
        {
            NamesModel sqlontext = new NamesModel();
            return sqlontext;
        }
        public async void SaveData(string hebrew, string english, bool isGoogle)
        {
            using (var db = GetContext())
            {
                var data = await db.Names.ToListAsync();
                foreach (var item in data)
                {
                    Console.WriteLine(item.English + " " + item.Hebrew);
                }
                var newEntry = new Name() { DateUpdated = DateTime.Now.ToString(), DateCreated = DateTime.Now.ToString(), Hebrew = hebrew, English = english, IsGoogle = isGoogle };
                db.Names.Add(newEntry);
                db.SaveChanges();
            }





        }

        public async Task<List<Name>> GetAllRecords()
        {
            using (var db = GetContext())
            {
                var data = await db.Names.ToListAsync();
                return data;
            }
        }

        public Name GetRecord(int id)
        {
            using (var db = GetContext())
            {
                return db.Names.Find(new object[] { id });
            }
        }
        public async Task<Name> GetRecord(string HebrewName)
        {
            using (var db = GetContext())
            {
                return await db.Names.FirstOrDefaultAsync(r => r.Hebrew == HebrewName);
            }
        }

        
    }



}