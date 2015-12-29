using Spoils.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SpoilsService.WCF
{
    public class Spoil_Service : ISpoil_Service
    {
        public SpoilsHandler _Spoils = new SpoilsHandler();
        public string CustomerName()
        {
            return _Spoils.Customer;
        }

        public long FirstNumber()
        {
            return _Spoils.FirstNumber;
        }

        public string JobNumber()
        {
            return _Spoils.JobNumber;
        }

        public long LastNumber()
        {
            return _Spoils.LastNumber;
        }

        public DataTable RetrieveSpoilRecords()
        {
            return _Spoils.PassRecordsThroughDataTable();
        }

        public int TextFileIndexer()
        {
            return _Spoils.TextFileIndexer;
        }
    }
}
