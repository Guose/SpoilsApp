using System;
using System.Collections.Generic;
using System.IO;

namespace Spoils.Data
{
    public class FileSearcher : IDisposable
    {
        private string _jobNumber;
        private string _customerName;
        private string _dataFolder;

        //Constructor that passes in customer name and job number
        public FileSearcher(string customerName, string jobNumSubFolder) : this()
        {
            _customerName = customerName;
            _jobNumber = jobNumSubFolder;
        }

        //Default Constructor
        public FileSearcher() 
        {

        }
        public int Index { get; set; }

        internal string JobNumber
        {
            get { return _jobNumber; }
            set { _jobNumber = value; }
        }

        internal string CustomerFolder
        {
            get { return _customerName; }
            set { _customerName = value; }
        }


        private string startInFolder = @"\\Cedar\odda\JIP Workflows\";
        //private string startInFolder = @"C:\Users\jelder\Desktop\Visual Studio JJE\JJE\";
        //private string startInFolder = @"C:\Users\Justin\Desktop\Visual Studio\JJE\";

        public List<string> ListOfJobNumbers(string customerName)
        {
            string customerFolder = startInFolder + customerName;
            List<string> jobNumbers = new List<string>();

            foreach (string jobFolder in Directory.GetDirectories(customerFolder))
            {
                FileInfo fi = new FileInfo(jobFolder);
                jobNumbers.Add(fi.Name);
            }
            return jobNumbers;
        }

        public List<string> ListOfFoldersInCustomers()
        {
            List<string> folders = new List<string>();

            foreach (string item in Directory.GetDirectories(startInFolder))
            {
                FileInfo fi = new FileInfo(item);
                folders.Add(fi.Name);
            }
            return folders;
        }


        //returns a list of text files in the directory to UI comboBox
        public string[] RetrieveTextFilesFromCustomerFolder()
        {
            string path = RetrieveCustomerFolderName();            
            List<string> fileList = new List<string>();

            foreach (string file in Directory.GetFiles(path, "*.txt"))
            {                
                fileList.Add(file);
            }

            string[] filesArray = fileList.ToArray();
            return filesArray;
        }

        //Gets the customer name and adds it to the directory string specified by UI textbox
        private string RetrieveCustomerFolderName()
        {   _dataFolder = RetrieveSubFolderWithJobNumber() + @"\Data\";
            return _dataFolder;
        }

        //gets the job number folder specified by UI textbox
        private string RetrieveSubFolderWithJobNumber()
        {
            string insideCustomerFolder = startInFolder + CustomerFolder;
            string[] subfolder = Directory.GetDirectories(insideCustomerFolder, _jobNumber + "*");
            string path = subfolder[0];
            return path;
        }


        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //dispose managed state (managed objects).
                    startInFolder = string.Empty;
                    CustomerFolder = string.Empty;
                    JobNumber = string.Empty;
                }

                // free unmanaged resources (unmanaged objects) and override a finalizer below.
                // set large fields to null.

                disposedValue = true;
            }
        }

        // override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~FileSearcher() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            //uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
