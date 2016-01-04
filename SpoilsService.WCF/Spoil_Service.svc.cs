using Spoils.BLL;
using System.Collections.Generic;
using System.Data;

namespace SpoilsService.WCF
{
    public class Spoil_Service : ISpoil_Service
    {
        public SpoilsHandler _Spoils = new SpoilsHandler();
        public string CustomerName()
        {
            return _Spoils.Customer;
        }

        public string JobNumber()
        {
            return _Spoils.JobNumber;
        }

        public List<string> TextFilesInCustomerFile()
        {
            return _Spoils.TextFilesInCustomerFolder();
        }

        public long FirstNumber()
        {
            return _Spoils.FirstNumber;
        }

        public long LastNumber()
        {
            return _Spoils.LastNumber;
        }

        public DataTable RetrieveSpoilRecords()
        {
            return _Spoils.RetrieveSpoilRecords();
        }

        public int TextFileIndexer()
        {
            return _Spoils.TextFileIndexer;
        }

        public bool WasScanned()
        {
            return _Spoils.WasAScan;
        }
    }
}
