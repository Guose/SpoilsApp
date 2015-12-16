using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Spoils.BLL
{
    class ManualRecord : SequenceNumbers
    {
        public ManualRecord()   
        {
                
        }

        public ManualRecord(long firstNumber, long lastNumber, bool wasScanned, DataTable dt) : base(firstNumber, lastNumber)
        {
            WasScanned = wasScanned;
            DataFromFile = dt;
        }

        public DataTable RecordsToDataTable
        { get; set; }

        public bool WasScanned
        { get; set; }

        public DataTable DataFromFile
        { get; set; }

        public string IdUniqueToFind
        { get; set; }

        internal string ColumnToSearch = string.Empty;
       
        internal DataTable FetchManualRangeOfRecords()
        {
            if (WasScanned == false)
            {
                IdUniqueToFind = FirstNumber.ToString();
                foreach (DataColumn dc in DataFromFile.Rows)
                {
                    if (dc.ColumnName.Contains("KEY") || dc.ColumnName.Contains("Count") || dc.ColumnName.Contains("BARCODE")) 
                    {
                        ColumnToSearch = dc.ColumnName.ToString();
                        foreach (DataRow drv in DataFromFile.Rows)
                        {
                            if (drv[ColumnToSearch].ToString() == FirstNumber.ToString())
                            {
                                RecordsToDataTable.Rows.Add(drv.ItemArray);
                                FirstNumber++;
                                if (FirstNumber >= LastNumber)
                                {
                                    CheckNumbersAreEqual();
                                    break;
                                }
                            }
                        }
                        if (CheckNumbersAreEqual())
                            break;
                    }
                }
            }return RecordsToDataTable;
        } 

    }
}
