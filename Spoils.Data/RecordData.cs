using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace Spoils.Data
{
    public class RecordData : FileSearcher
    {
        #region CTOR
        public RecordData()
        {

        }

        public RecordData(DataTable file) : this()
        {
            DataFromFile = file;
        }
        #endregion CTOR


        #region PROP

        internal DataTable DataFromFile { get; set;}

        public int Indexer { get; set; }

        internal DataRow Rows { get; set; }

        internal DataColumn Columns { get; set; }

        private string[] LineArray;

        #endregion PROP

        #region METHOD

        /// <summary>
        /// Parse out each field of text file into columns and rows this is the calling method to the program
        /// </summary>
        /// <param name="location">UI comboBox will select file location</param>
        /// <param name="delimeter">this is how each field/column is seperated</param>
        /// <returns>returns datatable to</returns>
        public DataTable DataFromTextFile(List<string> list, char pipe = '|')
        {
            LineArray = File.ReadAllLines(list[Indexer]);
            DataFromFile = FormDataTable(LineArray, pipe);
            return DataFromFile;
        }

        private DataTable FormDataTable(string[] LineArray, char delimeter)
        {
            DataTable dt = new DataTable();
            AddColumnsToTable(LineArray, delimeter, ref dt);
            AddRowToTable(LineArray, delimeter, ref dt);
            return dt;
        }

        private void AddRowToTable(string[] rowCollection, char delimeter, ref DataTable dt)
        {
            for (int i = 1; i < rowCollection.Length; i++)
            {
                string[] rows = rowCollection[i].Split(delimeter);
                Rows = dt.NewRow();
                for (int r = 0; r < rows.Length; r++)
                {
                    Rows[r] = rows[r];
                }
                dt.Rows.Add(Rows);
            }
        }

        private void AddColumnsToTable(string[] columnCollection, char delimeter, ref DataTable dt)
        {
            string[] columns = columnCollection[0].Split(delimeter);

            foreach (string column in columns)
            {
                Columns = new DataColumn(column, typeof(string));
                dt.Columns.Add(Columns);
            }
        }
        #endregion METHOD
    }
}
