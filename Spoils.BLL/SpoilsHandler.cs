using Spoils.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Spoils.BLL
{
    public class SpoilsHandler
    {
        public string Customer { get; set; }
        public string JobNumber { get; set; }

        public DataTable RetrieveDataFromDAL(DataTable printstream)
        {
            // An intance of the filesearcher class that retrieves file location based on user input to UI
            FileSearcher file = new FileSearcher(Customer, JobNumber);

            RecordData ps = new RecordData();
            printstream = ps.DataFromTextFile(file.RetrieveTextFilesFromCustomerFolder(), '|');

            return printstream; 
        }



    }
}
