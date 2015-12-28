using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Spoils.Data
{
    public class FileSearcher : IDisposable
    {
        /// <summary>
        /// FileSearcher contructor passes two parameters
        /// </summary>
        /// <param name="customerName">customer name for subfolder</param>
        /// <param name="jobNumSubFolder">first 6 digits of subfolder(Job Number)</param>
        public FileSearcher(string customerName, string jobNumSubFolder) : this()
        {
            CustomerFolder = customerName;
            JobNumber = jobNumSubFolder;
        }

        public FileSearcher()
        {

        }

        private string jobNumber;

        internal string JobNumber
        {
            get { return jobNumber; }
            set { jobNumber = value; }
        }

        private string customerFolder;

        internal string CustomerFolder
        {
            get { return customerFolder; }
            set { customerFolder = value; }
        }

        //private string textFile;
        private string startInFolder = @"C:\Users\Justin\Desktop\Visual Studio\JJE\"; //C:\Users\Justin\Desktop\Visual Studio\JJE\Test Folder\123456 Test Data Folder\Data

        //returns a list of text files in the directory to UI comboBox
        public List<string> RetrieveTextFilesFromCustomerFolder()
        {
            string[] files = Directory.GetFiles(RetrieveCustomerFolderName(), "*.txt");
            List<string> fileList = new List<string>();
            
            foreach (string file in files)
            {
                fileList.Add(file);
            }

            //for (int i = 0; i < files.Length; i++)
            //{
            //    textFile = files[i];
            //}
            return fileList;
        }

        //Gets the customer name and adds it to the directory string specified by UI textbox
        private string RetrieveCustomerFolderName()
        {
            string filePath = RetrieveSubFolderWithJobNumber()[0] + @"\Data\";
            return filePath;
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
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
