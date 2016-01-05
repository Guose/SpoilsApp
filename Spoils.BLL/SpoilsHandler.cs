using Spoils.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Spoils.BLL
{
    public class SpoilsHandler : ISequence, IScannable
    {
        public string Customer { get; set; }
        public string JobNumber { get; set; }
        public string FileLocation { get; set; }
        public long FirstNumber { get; set; }
        public long LastNumber { get; set; }
        public bool WasAScan { get; set; }

        public DataTable RetrieveSpoilRecords()
        {
            ManualRecord mr = new ManualRecord(FirstNumber, LastNumber);
            ScanRecord sr = new ScanRecord(FirstNumber, LastNumber);


            if (WasAScan)
            {
                sr.DataFromFile = RetrieveDataFromDAL(FileLocation);
                return sr.ScannedRecordsFetcher();
            }
            else
            {
                mr.DataFromFile = RetrieveDataFromDAL(FileLocation);
                return mr.ManualRecordsFetcher();
            }
        }

        public DataTable RetrieveDataFromDAL(string fileLocation)
        {
            // An intance of the filesearcher class that retrieves file location based on user input to UI
            RecordData ps = new RecordData();
            return ps.ReturnDataTableFromTextFile(FileLocation, '|');
        }

        public List<string> TextFilesInCustomerFolder()
        {
            FileSearcher textFiles = new FileSearcher(Customer, JobNumber);
            return textFiles.RetrieveTextFilesFromCustomerFolder();
        }

        public string HeaderRecord()
        {
            StreamReader sr = new StreamReader(FileLocation);
            string headerRecord = sr.ReadLine();
            return headerRecord;
        }
    }
}
