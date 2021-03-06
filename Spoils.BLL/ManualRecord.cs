﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Spoils.BLL
{
    internal class ManualRecord : SpoilsHandler, ISequence
    {
        public ManualRecord()   
        {
                
        }

        public ManualRecord(long firstNumber, long lastNumber)
        {
            FirstNumber = firstNumber;
            LastNumber = lastNumber;
        }

        public DataTable SpoilRecordsReturnedDT { get; set; }

        internal DataTable DataFromFile { get; set; }

        internal string IdUniqueToFind { get; set; }

        internal string ColumnToSearch = string.Empty;

        public DataTable ManualRecordsFetcher()
        {
            CloneDataTable();
            LastNumber = LastNumber + 1;
            IdUniqueToFind = FirstNumber.ToString();
                foreach (DataColumn dc in DataFromFile.Columns)
                {
                    if (dc.ColumnName.Contains("SEQ") || dc.ColumnName.Contains("Count") || dc.ColumnName.Contains("Seq") || dc.ColumnName.Contains("BarCode")) 
                    {
                        ColumnToSearch = dc.ColumnName.ToString();
                        foreach (DataRow drv in DataFromFile.Rows)
                        {
                            if (drv[ColumnToSearch].ToString() == FirstNumber.ToString())
                            {
                                SpoilRecordsReturnedDT.Rows.Add(drv.ItemArray);
                                FirstNumber++;
                                if (FirstNumber >= LastNumber)
                                {
                                    CheckNumbersAreEqual();
                                    break;
                                }
                            }
                        }
                        if (CheckNumbersAreEqual()) break;
                    }
                }
            return SpoilRecordsReturnedDT;
        }

        internal DataTable CloneDataTable()
        {
            SpoilRecordsReturnedDT = DataFromFile.Clone();
            return SpoilRecordsReturnedDT;
        }
    }
}
