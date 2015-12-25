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
        public ScanRecord(long firstNumber, long lastNumber, bool wasScanned, DataTable dt) : base(firstNumber, lastNumber, wasScanned, dt)
        {
            FirstNumber = firstNumber;
            LastNumber = lastNumber;
            WasScanned = wasScanned;
            DataFromFile = dt;
        }

        internal DataTable FetchScannedRangeOfRecords()
        {
            IdUniqueToFind = FirstNumber.ToString().PadLeft(10, '0');
            foreach (DataColumn dc in DataFromFile.Columns)
            {
                if (DoMainBreak)
                    break;
                if (dc.ColumnName.Contains("BARCODE") || dc.ColumnName.Contains("BALLOTBC"))
                {
                    ColumnToSearch = dc.ColumnName.ToString();
                    foreach (DataRow drv in DataFromFile.Rows)
                    {
                        if (drv[ColumnToSearch].ToString() == FirstNumber.ToString().PadLeft(10, '0'))
                        {
                            RecordsToDataTable.Rows.Add(drv);
                            FirstNumber++;
                            if (FirstNumber >= LastNumber)
                            {
                                DoMainBreak = true;
                                break;
                            }
                        }
                    }if (DoMainBreak)
                        break;
                }
            }return RecordsToDataTable;
        }
    }
}
