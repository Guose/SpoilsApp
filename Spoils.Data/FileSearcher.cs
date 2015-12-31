﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Spoils.Data
{
    public class FileSearcher : IDisposable
    {
        //Constructor that passes in customer name and job number
        public FileSearcher(string customerName, string jobNumSubFolder, int indexer) : this()
        {
            CustomerFolder = customerName;
            JobNumber = jobNumSubFolder;
            Index = indexer;
        }

        //Default Constructor
        public FileSearcher() 
        {

        }
        public int Index { get; set; }

        internal string JobNumber { get; set; }

        internal string CustomerFolder { get; set; }


        private string startInFolder = @"C:\Users\Justin\Desktop\Visual Studio\JJE\";


        //returns a list of text files in the directory to UI comboBox
        public List<string> RetrieveTextFilesFromCustomerFolder()
        {
            string[] files = Directory.GetFiles(RetrieveCustomerFolderName(), "*.txt");
            List<string> fileList = new List<string>();
            
            foreach (string file in files)
            {
                fileList.Add(file);
            }
            return fileList;
        }

        //Gets the customer name and adds it to the directory string specified by UI textbox
        private string RetrieveCustomerFolderName()
        {   string dataFolder = RetrieveSubFolderWithJobNumber()[Index] + @"\Data\";
            return dataFolder;
        }

        //gets the job number folder specified by UI textbox
        private string[] RetrieveSubFolderWithJobNumber()
        {
            string insideCustomerFolder = startInFolder + CustomerFolder;
            string[] subfolder = Directory.GetDirectories(insideCustomerFolder, JobNumber + "*");
            return subfolder;
        }


        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    startInFolder = string.Empty;
                    CustomerFolder = string.Empty;
                    JobNumber = string.Empty;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~FileSearcher() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
