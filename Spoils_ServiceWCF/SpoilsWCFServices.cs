using Spoils.BLL;
using System.Collections.Generic;
using System.Data;
using System;

namespace Spoils_ServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SpoilsWCFService" in both code and config file together.
    public class SpoilsWCFServices : ISpoilsWCFServices
    {
        internal DataContract dc = new DataContract(); 

        public string CustomerName(SpoilsHandler customerName)
        {
            dc.CustomerName = customerName.Customer;            
            return dc.CustomerName;
        }

        public string JobNumber(SpoilsHandler jobNumber)
        {
            dc.JobNumber = jobNumber.JobNumber;
            return dc.JobNumber;
        }

        public long FirstNumber(SpoilsHandler firstNum)
        {
            dc.FirstNumber = firstNum.FirstNumber;
            return dc.FirstNumber;
        }

        public long LastNumber(SpoilsHandler lastNum)
        {
            dc.LastNumber = lastNum.LastNumber;
            return dc.LastNumber;
        }

        public List<string> ListOfTextFiles(string customer, string job)
        {
            var listOfTextFiles = new List<string>();
            var sph = new SpoilsHandler();
            sph.Customer = customer;
            sph.JobNumber = job;
            listOfTextFiles = sph.TextFilesInCustomerFolder();

            return listOfTextFiles;
        }

        public int TextFileIndexer(SpoilsHandler textFileIndex)
        {
            dc.IndexOfTextFile = textFileIndex.TextFileIndexer;
            return dc.IndexOfTextFile;
        }

        public bool WasScanned(SpoilsHandler wasScanned)
        {
            dc.WasScanned = wasScanned.WasAScan;
            return dc.WasScanned;
        }
// TODO: find a way to incorporate the file location with the RetrieveData method in the SpoilHandler Class
        public DataTable GetSpoilRecordsDT(long firstNum, long lastNum)
        {
            var sphDataNums = new SpoilsHandler();
            sphDataNums.FirstNumber = firstNum;
            sphDataNums.LastNumber = lastNum;

            dc.GetSpoilRecords = sphDataNums.RetrieveDataFromDAL();
            return dc.GetSpoilRecords;
        }

        public DataTable ReturnSpoilRecordsDT()
        {
            var sphDataTable = new SpoilsHandler();
            dc.ReturnSpoilRecords = sphDataTable.RetrieveSpoilRecords();
            return dc.ReturnSpoilRecords;
        }
    }
}
