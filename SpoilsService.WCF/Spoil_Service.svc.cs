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

        public bool Scan(bool scan)
        {
            return scan;
        }

        public DataTable RetrieveRecordData(DataTable dt)
        {
            return dt;
        }

        public bool Manual(bool manual)
        {
            return manual;
        }
    }
}
