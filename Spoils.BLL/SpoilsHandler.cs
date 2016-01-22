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
        public SpoilsHandler()
        {

        }

        public SpoilsHandler(long firstNum, long lastNum)
        {
            FirstNumber = firstNum;
            LastNumber = lastNum;
        }

        public string Customer { get; set; }
        public string JobNumber { get; set; }
        public string FileLocation { get; set; }
        public long FirstNumber { get; set; }
        public long LastNumber { get; set; }
        public bool WasAScan { get; set; }

        public DataTable RetrieveSpoilRecords()
        {
            ReverseSequenceNumbers(FirstNumber, LastNumber);
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

        public string[] TextFilesInCustomerFolder()
        {
            FileSearcher textFiles = new FileSearcher(Customer, JobNumber);
            return textFiles.RetrieveTextFilesFromCustomerFolder();
        }


        public DataTable RemoveDupesAndSort(DataTable dT)
        {
            DataTable dtAscend = dT.Clone();
            FileSave fs = new FileSave();

            if (dtAscend.Columns[0].ColumnName == "KEY")
            {
                fs.RemoveDuplicateRows(dT, "KEY");
                dtAscend = fs.SortAscending("KEY", dT);
            }
            else if (dtAscend.Columns[0].ColumnName == "Count")
            {
                fs.RemoveDuplicateRows(dT, "Count");
                dtAscend = fs.SortAscending("Count", dT);
            }
            else 
            {
                fs.RemoveDuplicateRows(dT, "Seq");
                dtAscend = fs.SortAscending("Seq", dT);
            }

            return dtAscend;
        }

        public string SaveNewFileName(string path, DataTable dt, string header)
        {
            FileSave fs = new FileSave();
            string newFileName = fs.SaveSpoilsFile(path, dt, header);
            return newFileName;
        }

        public string HeaderRecord()
        {
            StreamReader sr = new StreamReader(FileLocation);
            string headerRecord = sr.ReadLine();
            return headerRecord;
        }

        public void ReverseSequenceNumbers(long firstNum, long lastNum)
        {
            if (LastNumber < FirstNumber)
            {
                FirstNumber = lastNum;
                LastNumber = firstNum;
            }
            else
            {
                FirstNumber = firstNum;
                LastNumber = lastNum;
            }
        }
    }
}
