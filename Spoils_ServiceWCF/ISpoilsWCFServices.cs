using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Spoils.BLL;
using System.Data;

namespace Spoils_ServiceWCF
{
    
    [ServiceContract]
    public interface ISpoilsWCFServices
    {
        [OperationContract]
        string CustomerName(SpoilsHandler customerName);

        [OperationContract]
        string JobNumber(SpoilsHandler jobNumber);

        [OperationContract]
        long FirstNumber(SpoilsHandler firstNum);

        [OperationContract]
        long LastNumber(SpoilsHandler lastNum);

        [OperationContract]
        int TextFileIndexer(SpoilsHandler textFileIndex);

        [OperationContract]
        bool WasScanned(SpoilsHandler wasScanned);

        [OperationContract]
        List<string> ListOfTextFiles(string customer, string job);

        [OperationContract]
        DataTable GetSpoilRecordsDT(long firstNum, long lastNum);
    }
}
