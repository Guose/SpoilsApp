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
        public string CustomerName;

        [DataMember]
        public string JobNumber;

        [DataMember]
        public long FirstNumber;

        [DataMember]
        public long LastNumber;

        [DataMember]
        public int TextFileIndex;

        [DataMember]
        public List<string> TextFilesInDataFolder;

        [DataMember]
        public bool WasScanned;

        [DataMember]
        public DataTable RetrieveSpoilRecords;



    }
}
