using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Spoils_ServiceWCF
{
    [DataContract]
    public class DataContract
    {

        [DataMember]
        public string FileLocation { get; set; }

        [DataMember]
        public bool WasScanned { get; set; }

        [DataMember]
        public DataTable GetSpoilRecords { get; set; }

    }
}
