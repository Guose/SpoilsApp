using Spoils.Data;
using System.Collections.Generic;
using System.Data;
using System.IO;


namespace Spoils.BLL
{
    public class SpoilsHandler : ISequence, IScannable
    {
        private long _firstNumber;
        private long _lastNumber;
        private bool _wasAScan;
        private bool _doMainBreak;
        private string _customer;
        private string _jobNumber;
        private string _fileLocation;
        private ExcelFile ex = new ExcelFile();

        #region CTOR
        public SpoilsHandler()
        {

        }

        public SpoilsHandler(string customer, string jobNumber) : this()
        {
            _customer = customer;
            _jobNumber = jobNumber;
        }

        public SpoilsHandler(long firstNum, long lastNum) : this()
        {
            if (lastNum < firstNum)
            {
                _firstNumber = lastNum;
                _lastNumber = firstNum;
            }
            else
            {
                _firstNumber = firstNum;
                _lastNumber = lastNum;
            }
        }
        #endregion CTOR

        #region Properties
        public string Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public string JobNumber
        {
            get { return _jobNumber; }
            set { _jobNumber = value; }
        }

        public string FileLocation
        {
            get { return _fileLocation; }
            set { _fileLocation = value; }
        }

        public bool DoMainBreak
        {
            get { return _doMainBreak; }
            set { _doMainBreak = value; }
        }

        public long FirstNumber
        {
            get { return _firstNumber; }

            set { _firstNumber = value; }
        }

        public long LastNumber
        {
            get { return _lastNumber; }

            set { _lastNumber = value; }
        }

        public bool WasAScan
        {
            get { return _wasAScan; }

            set { _wasAScan = value; }
        }

        public bool CheckNumbersAreEqual()
        {
            if (FirstNumber == LastNumber)
            {
                _doMainBreak = true;
            }
            return _doMainBreak;
        }
        #endregion Properties


        #region Methods

        public void CreateNewExcelFile(string fileLocation)
        {
            ex = new ExcelFile(fileLocation);
            ex.CreateExcelFile();
        }

        public void DeleteExcelFile()
        {
            ex.DeleteExcelFile();
        }

        public DataTable RetrieveSpoilRecords(string fileLocation)
        {
            ManualRecord mr = new ManualRecord(_firstNumber, _lastNumber);
            ScanRecord sr = new ScanRecord(_firstNumber, _lastNumber);
            
            ex.Path = fileLocation;
            ex.OpenExcelFile(_firstNumber, _lastNumber);

            if (_wasAScan)
            {
                sr.DataFromFile = RetrieveDataFromDAL(_fileLocation);
                return sr.ScannedRecordsFetcher();
            }
            else
            {
                mr.DataFromFile = RetrieveDataFromDAL(_fileLocation);
                return mr.ManualRecordsFetcher();
            }
        }

        public List<string> JobNumbers(string customerName)
        {
            FileSearcher fs = new FileSearcher();
            List<string> jobNumbers = new List<string>();
            jobNumbers = fs.ListOfJobNumbers(customerName);
            return jobNumbers;
        }

        public List<string> CustomerNames()
        {
            FileSearcher fs = new FileSearcher();
            List<string> folders = new List<string>();
            folders = fs.ListOfFoldersInCustomers();
            return folders;
        }

        public DataTable RetrieveDataFromDAL(string fileLocation)
        {
            // An intance of the filesearcher class that retrieves file location based on user input to UI
            FileDelimeter ps = new FileDelimeter();
            return ps.ReturnDataTableFromTextFile(fileLocation, '|');
        }

        public string[] TextFilesInCustomerFolder()
        {
            FileSearcher textFiles = new FileSearcher(_customer, _jobNumber);
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
            else if (dtAscend.Columns[0].ColumnName == "Seq")
            {
                fs.RemoveDuplicateRows(dT, "Seq");
                dtAscend = fs.SortAscending("Seq", dT);
            }
            return dtAscend;
        }

        public Email SendEmail()
        {
            return new Email();
        }

        public string SaveNewFileName(string path, DataTable dt, string header)
        {
            FileSave fs = new FileSave();
            string newFileName = fs.SaveSpoilsFile(path, dt, header);
            return newFileName;
        }

        public string HeaderRecord()
        {
            StreamReader sr = new StreamReader(_fileLocation);
            string header = sr.ReadLine();
            return header;
        }
        #endregion Methods
    }
}
