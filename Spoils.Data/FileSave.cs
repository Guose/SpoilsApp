using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using Microsoft.Win32;


namespace Spoils.Data
{
    public class FileSave
    {
        public DataTable SortAscending(string columnName, DataTable dt)
        {
            DataTable dtAsc = dt.Clone();
            dtAsc.Columns[columnName].DataType = Type.GetType("System.Int32");
            foreach (DataRow dr in dt.Rows)
            {
                dtAsc.ImportRow(dr);
            }
            dtAsc.AcceptChanges();
            if (dtAsc.Rows.Count > 0)
            {
                DataView dv = dtAsc.DefaultView;
                dv.Sort = columnName;
                dtAsc = dv.ToTable();
            }
            return dtAsc;
        }

        public string SaveSpoilsFile(string path, DataTable table, string header)
        {

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            string filename = dlg.FileName;
            string newFilename = AddSuffix(path, string.Format(filename));

            var result = new StringBuilder();
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    result.Append(row[i].ToString());
                    result.Append(i == table.Columns.Count - 1 ? "" : "|");
                }
                result.AppendLine();
            }
            using (StreamWriter objWriter = new StreamWriter(newFilename))
            {
                objWriter.WriteLine(header);
                objWriter.WriteLine(result.ToString());
                objWriter.Close();
            }
            return newFilename;
        }

        private string AddSuffix(string filename, string suffix)
        {
            string fDir = Path.GetDirectoryName(filename);
            string fName = Path.GetFileNameWithoutExtension(filename);
            string fExt = Path.GetExtension(filename);
            int n = 1;
            string spoils = "_SPOILS";
            do
            {
                filename = Path.Combine(fDir, String.Format("{0}{1}({2}){3}", fName, spoils, (n++), fExt));
            }
            while (File.Exists(filename));
            return filename;
        }

        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();
            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }
            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);
            if (duplicateList.Count > 0)
            {
                MessageBox.Show(duplicateList.Count + " Duplicate(s) have been removed.");
            }
            //Datatable which contains unique records will be return as output.
            return dTable;
        }
    }
}
