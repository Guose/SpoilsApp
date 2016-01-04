﻿using Spoils.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Spoils.BLL
{
    public class SpoilsHandler : ISequence, IScannable
    {
        public string Customer { get; set; }
        public string JobNumber { get; set; }
        public int TextFileIndexer { get; set; }
        public long FirstNumber { get; set; }
        public long LastNumber { get; set; }
        public bool WasAScan { get; set; }

        public DataTable RetrieveSpoilRecords()
        {
            ManualRecord mr = new ManualRecord(FirstNumber, LastNumber);
            ScanRecord sr = new ScanRecord(FirstNumber, LastNumber);

            if (WasAScan)
            {
                return sr.ScannedRecordsFetcher();
            }
            else
            {
                return mr.ManualRecordsFetcher();
            }
        }

        public DataTable RetrieveDataFromDAL()
        {
            // An intance of the filesearcher class that retrieves file location based on user input to UI
            FileSearcher file = new FileSearcher(Customer, JobNumber);
            RecordData ps = new RecordData();
            string fileLocation = file.RetrieveTextFilesFromCustomerFolder()[TextFileIndexer].ToString();

            return ps.ReturnDataTableFromTextFile(fileLocation, '|');
        }

        public List<string> TextFilesInCustomerFolder()
        {
            FileSearcher textFiles = new FileSearcher(Customer, JobNumber);
            return textFiles.RetrieveTextFilesFromCustomerFolder();
        }
    }
}
