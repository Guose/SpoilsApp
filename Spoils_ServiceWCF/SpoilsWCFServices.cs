﻿using Spoils.BLL;
using System.Collections.Generic;
using System.Data;
using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace Spoils_ServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SpoilsWCFService" in both code and config file together.
    [Serializable]
    public class SpoilsWCFServices : ISpoilsWCFServices
    {
        internal DataContract dc = new DataContract();

        public SpoilsWCFServices()
        {

        }

        public SpoilsWCFServices(string customer, string jobNumber) :this()
        {
            CustomerName = customer;
            JobNumber = jobNumber;
        }

        public string CustomerName { get; set; }

        public string JobNumber { get; set; }
        
        public string[] ListOfTextFiles(string customer, string job)
        {
            string[] listOfTextFiles;
            SpoilsHandler sph = new SpoilsHandler();
            sph.Customer = customer;
            sph.JobNumber = job;
            listOfTextFiles = sph.TextFilesInCustomerFolder();

            return listOfTextFiles;
        }

        public void GetFileName()
        {
                        
        }

        public DataTable GetSpoilRecordsDT(long firstNum, long lastNum, string fileLocation, bool wasAscan)
        {
            DataTable returnSpoilsDT = new DataTable();
            SpoilsHandler sphDataNums = new SpoilsHandler();
            sphDataNums.FirstNumber = firstNum;
            sphDataNums.LastNumber = lastNum;

            sphDataNums.FileLocation = fileLocation;
            sphDataNums.WasAScan = wasAscan;
            returnSpoilsDT = sphDataNums.RetrieveSpoilRecords(fileLocation);

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

        public void SaveToTextFile(string path)
        {            
            SpoilsHandler sph = new SpoilsHandler();
            sph.FileLocation = path;
            string header = sph.HeaderRecord();

            DataTable dtAsc = sph.RemoveDupesAndSort(dc.GetSpoilRecords);

            string newFileName = sph.SaveNewFileName(path, dtAsc, header);

            FileInfo fi = new FileInfo(newFileName);

            var lines = File.ReadAllLines(newFileName);
            File.WriteAllLines(newFileName, lines.Take(lines.Length - 1).ToArray());
            string count = dtAsc.Rows.Count.ToString();
            MessageBox.Show("File Saved As:  " + fi.Name + "\n\n" + count + " records have been saved!", "'" + count + "'" + " - RECORD(s) EXPORTED      ", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
