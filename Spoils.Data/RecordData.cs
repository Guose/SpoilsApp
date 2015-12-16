using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace Spoils.Data
{
    public class RecordData
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

        private DataTable dataFile;

        public DataTable DataFromFile
        {
            get { return dataFile; }
            set { dataFile = value; }
        }

        private DataRow rows;

        public DataRow Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        private DataColumn columns;

        public DataColumn Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        private string[] LineArray;

        #endregion PROP

        #region METHOD

        /// <summary>
        /// Parse out each field of text file into columns and rows this is the calling method to the program
        /// </summary>
        /// <param name="location">UI comboBox will select file location</param>
        /// <param name="delimeter">this is how each field/column is seperated</param>
        /// <returns>returns datatable to</returns>
        public DataTable DataFromTextFile(string location, char delimeter = '|') //try to use a different parameter for this method other then file location
        {                                                                        
            LineArray = File.ReadAllLines(location); //use something other then File.ReadAllLines method to retrieve data.
            DataFromFile = FormDataTable(LineArray, delimeter);
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
