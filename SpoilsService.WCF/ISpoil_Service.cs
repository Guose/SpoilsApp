using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SpoilsService.WCF
{
    [ServiceContract]
    public interface ISpoil_Service
    {
        [OperationContract]
        DataTable RetrieveRecordData(DataTable dt);

        [OperationContract]
        string CustomerName(string customerName);

        [OperationContract]
        string JobNumber(string jobNumber);

        [OperationContract]
        bool Scan(bool scan);

        [OperationContract]
        bool Manual(bool manual);
    }
}
