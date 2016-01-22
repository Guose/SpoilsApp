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
        string[] ListOfTextFiles(string customer, string job);

        [OperationContract]
        DataTable GetSpoilRecordsDT(long firstNum, long lastNum, string fileLocation, bool wasAscan);

        [OperationContract]
        void SaveToTextFile(string path);
    }
}
