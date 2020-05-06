using Common.Poco;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Common.Models;

namespace Common.Interfaces
{
    public interface IDbConnector
    {
        Task<List<Name>> GetAllRecords();
        NamesModel GetContext();
        Name GetRecord(int id);
        Task<Name> GetRecord(string HebrewName);
        void SaveData(string hebrew, string english, bool isGoogle);
    }
}