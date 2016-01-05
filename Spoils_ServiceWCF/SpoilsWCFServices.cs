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

        public List<string> ListOfTextFiles(string customer, string job)
        {
            var listOfTextFiles = new List<string>();
            var sph = new SpoilsHandler();
            sph.Customer = customer;
            sph.JobNumber = job;
            listOfTextFiles = sph.TextFilesInCustomerFolder();

            return listOfTextFiles;
        }

        public DataTable GetSpoilRecordsDT(long firstNum, long lastNum, string fileLocation)
        {
            DataTable returnSpoilsDT = new DataTable();
            var sphDataNums = new SpoilsHandler();
            sphDataNums.FirstNumber = firstNum;
            sphDataNums.LastNumber = lastNum;
            sphDataNums.FileLocation = fileLocation;
            returnSpoilsDT = sphDataNums.RetrieveSpoilRecords();

            if (dc.GetSpoilRecords != null)
            {
                foreach (DataRow dr in returnSpoilsDT.Rows)
                {
                    dc.GetSpoilRecords.ImportRow(dr);
                }
            }
            else
            {
                dc.GetSpoilRecords = returnSpoilsDT;
            }
            return dc.GetSpoilRecords;
        }

        //public DataTable SortDataTable()
        //{
        //    DataTable dtAscend = dc.GetSpoilRecords.Clone();

        //    if (dtAscend.Columns[0].ColumnName == "KEY")
        //    {
                
        //    }
        //}
    }
}
