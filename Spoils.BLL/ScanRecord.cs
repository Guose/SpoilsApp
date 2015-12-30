using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Spoils.BLL
{
    internal class ScanRecord : ManualRecord
    {
        public ScanRecord()
        {

        }
        public ScanRecord(long firstNumber, long lastNumber) : base(firstNumber, lastNumber)
        {
            FirstNumber = firstNumber;
            LastNumber = lastNumber;
        }

        public DataTable ScannedRecordsFetcher()
        {
            if (WasAScan)
            {
                IdUniqueToFind = FirstNumber.ToString().PadLeft(10, '0');
                foreach (DataColumn dc in DataFromFile.Columns)
                {
                    if (DoMainBreak) break;
                    if (dc.ColumnName.Contains("BARCODE") || dc.ColumnName.Contains("BALLOTBC"))
                    {
                        ColumnToSearch = dc.ColumnName.ToString();
                        foreach (DataRow drv in DataFromFile.Rows)
                        {
                            if (drv[ColumnToSearch].ToString() == FirstNumber.ToString().PadLeft(10, '0'))
                            {
                                SpoilRecordsReturnedDT.Rows.Add(drv);
                                FirstNumber++;
                                if (FirstNumber == LastNumber)
                                {
                                    CheckNumbersAreEqual();
                                    break;
                                }
                            }
                        }
                        if (CheckNumbersAreEqual()) break;
                    }
                }                
            }
            return SpoilRecordsReturnedDT;
        }
    }
}
