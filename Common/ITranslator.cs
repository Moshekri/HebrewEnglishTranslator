using Common.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ITranslator
    {
        Name GetFirstName(string hebrewFirstName);
        Name GetLastName(string HebrewLastName);

    }
}
