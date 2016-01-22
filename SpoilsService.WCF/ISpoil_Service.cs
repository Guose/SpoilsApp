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
        DataTable RetrieveSpoilRecords();

        [OperationContract]
        string CustomerName();

        [OperationContract]
        string JobNumber();

        [OperationContract]
        long FirstNumber();

        [OperationContract]
        long LastNumber();

        [OperationContract]
        string TextFileLocation();

        [OperationContract]
        string[] TextFilesInCustomerFile();

        [OperationContract]
        bool WasScanned();

    }
}
