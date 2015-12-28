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
        public string CustomerName(string customerName)
        {                       
            return customerName;
        }

        public string JobNumber(string jobNumber)
        {
            return jobNumber;
        }

        public DataTable RetrieveRecordData(DataTable dt)
        {
            var records = new SpoilsHandler();
            return records.RetrieveDataFromDAL(dt);
        }
    }
}
