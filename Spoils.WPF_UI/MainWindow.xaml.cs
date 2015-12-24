using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Spoils.WPF_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Height = 300;
            Width = 425;
        }


        #region Buttons

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSubmitRange_Click(object sender, RoutedEventArgs e)
        {
            btnCompleteRange.Visibility = Visibility.Visible;
            long firstNum = long.Parse(txtFirstNum.Text);
            long lastNum = long.Parse(txtLastNum.Text);

            try
            {
                //TO DO: Instantiate 
                //dt2 = GetBarcode(colBCName, firstNum, lastNum);

                //spoilsGrid.DataContext = dt2;
                spoilsGrid.Visibility = Visibility.Visible;
                lblFocusToBottom.Visibility = Visibility.Visible;
                lblFocusToTop.Visibility = Visibility.Visible;
                spoilsGrid.ScrollIntoView(spoilsGrid.Items[spoilsGrid.Items.Count - 2]);
                txtFirstNum.Focus();
                txtFindRec.Visibility = Visibility.Visible;
                btnSubmitRange.IsEnabled = false;
                btnSave.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Data has not been loaded to the program", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                ChangeVisibility(true);
            }

        }

        private void btnSubmitSingle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnCompleteSingle.Visibility = Visibility.Visible;
                int number = int.Parse(txtSingleNum.Text);

                //dt2 = GetBarcode(colBCName, number, number);

                //spoilsGrid.DataContext = dt2;
                spoilsGrid.Visibility = Visibility.Visible;
                lblFocusToBottom.Visibility = Visibility.Visible;
                lblFocusToTop.Visibility = Visibility.Visible;
                btnSave.IsEnabled = true;
                txtSingleNum.SelectionStart = 0;
                txtSingleNum.SelectionLength = txtSingleNum.Text.Length;
                txtFindRec.Visibility = Visibility.Visible;
                spoilsGrid.ScrollIntoView(spoilsGrid.Items[spoilsGrid.Items.Count - 2]);
                btnSubmitSingle.IsEnabled = false;
            }
            catch
            {
                MessageBox.Show("Data has not been loaded to the program", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                ChangeVisibility(true);
            }

        }

        
        private void btnSingle_Click(object sender, RoutedEventArgs e)
        {
            Scanner scanner = new Scanner();
            scanner.isSingle = true;
            ChangeVisibility(false);
            stkSingle.Visibility = Visibility.Visible;
            txtSingleNum.Focus();            
            //scanner.SelectScanningMode("scanAddSpoil");
        }

        private void btnRange_Click(object sender, RoutedEventArgs e)
        {
            Scanner scanner = new Scanner();
            scanner.isSingle = false;
            ChangeVisibility(false);
            stkRange.Visibility = Visibility.Visible;
            txtFirstNum.Focus();
            //scanner.SelectScanningMode("scanAddSpoil");
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult clearWarning = MessageBox.Show("Are you sure you want to clear the data?", "WARNING", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (clearWarning == MessageBoxResult.Yes)
            {
                //ClearAllData();
                lblDragFileHere.Visibility = Visibility.Visible;
                lblFileLoaded.Visibility = Visibility.Hidden;
                btnCompleteRange.Visibility = Visibility.Hidden;
                btnCompleteSingle.Visibility = Visibility.Hidden;
                btnSave.IsEnabled = false;
                ChangeVisibility(true);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ClearAllData();
            Close();
        }

        private void btnCompleteRange_Click(object sender, RoutedEventArgs e)
        {
            ChangeVisibility(true);
        }

        private void btnCompleteSingle_Click(object sender, RoutedEventArgs e)
        {
            ChangeVisibility(true);
        }

        #endregion Buttons


        #region Methods

        private void ClearAllData()
        {
            lblHeader.Content = "";
            lblPath.Content = "";
            txtFirstNum.Text = "";
            txtLastNum.Text = "";
            txtSingleNum.Text = "";
            txtFindRec.Text = "Find";
            txtFindRec.Foreground = new SolidColorBrush(Colors.Gray);
            txtFindRec.Visibility = Visibility.Hidden;
            spoilsGrid.DataContext = null;
            //dt = new DataTable();
            //dt2 = new DataTable();
            spoilsGrid.Visibility = Visibility.Hidden;
            lblFocusToBottom.Visibility = Visibility.Hidden;
            lblFocusToTop.Visibility = Visibility.Hidden;
            cboComPort.Visibility = Visibility.Hidden;
            lblScannerCOM.Visibility = Visibility.Hidden;
        }

        internal void ChangeVisibility(bool original)
        {
            if (original == false)
            {
                Height = 600;
                Width = 1250;
                btnSingle.Visibility = Visibility.Hidden;
                btnRange.Visibility = Visibility.Hidden;
                btnBack.Visibility = Visibility.Visible;
            }
            else
            {
                Application.Current.MainWindow.Height = 300;
                Application.Current.MainWindow.Width = 425;
                btnSingle.Visibility = Visibility.Visible;
                btnRange.Visibility = Visibility.Visible;
                btnBack.Visibility = Visibility.Hidden;
                stkRange.Visibility = Visibility.Hidden;
                stkSingle.Visibility = Visibility.Hidden;
                txtFirstNum.Text = "";
                txtLastNum.Text = "";
                txtSingleNum.Text = "";

                if (btnSubmitRange.IsEnabled == false || btnSubmitSingle.IsEnabled == false)
                {
                    btnCompleteRange.Visibility = Visibility.Hidden;
                    btnCompleteSingle.Visibility = Visibility.Hidden;
                }
            }
        }

        #endregion Methods


        #region Key Controls

        void txtFirstNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtLastNum.SelectionStart = 0;
                txtLastNum.SelectionLength = txtLastNum.Text.Length;
                // TODO:1 
                //Instantiate Manual Record
                //wasScanned = false;
                txtLastNum.Focus();
            }
        }

        private void txtLastNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtFirstNum.SelectionStart = 0;
                txtFirstNum.SelectionLength = txtFirstNum.Text.Length;
            }
        }

        private void txtLastNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSubmitRange.IsEnabled = true;
            }
        }

        private void txtSingleNum_KeyUp(object sender, KeyEventArgs e)
        {
            btnSubmitSingle.IsEnabled = true;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeVisibility(true);
        }

        private void lblFocusToBottom_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblFocusToBottom_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        public int GetIndexOfDataGrid(int SearchForThis)
        {
            return 0;
        }


        private void txtFindRec_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    int findRec = int.Parse(txtFindRec.Text);
                    foreach (DataRowView row in spoilsGrid.Items)
                    {
                        if (row.Row.ItemArray[0].ToString() == findRec.ToString())
                        {
                            spoilsGrid.SelectedIndex = spoilsGrid.Items.IndexOf(row);
                            spoilsGrid.ScrollIntoView(row);
                            spoilsGrid.SelectedItem = spoilsGrid.Items.IndexOf(row);
                            break;
                        }
                    }
                    txtFindRec.SelectionStart = 0;
                    txtFindRec.SelectionLength = txtFindRec.Text.Length;
                }
            }
            catch { MessageBox.Show("Record not found"); }

        }

        private void lblFocusToBottom_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string message = string.Empty;
            try
            {
                spoilsGrid.ScrollIntoView(spoilsGrid.Items[spoilsGrid.Items.Count - 2]);
            }
            catch (Exception)
            {
                
            }
            
        }

        private void lblFocusToTop_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            spoilsGrid.ScrollIntoView(spoilsGrid.Items[spoilsGrid.SelectedIndex = 0]);
        }

        private void txtFindRec_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtFindRec.Text = "";
            txtFindRec.Foreground = Brushes.Black;
        }

        private void cboComPort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.PortName = cboComPort.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboComPort.SelectedIndex = 1;
        }

        #endregion Key Controls

        private class Messages
        {
            public Messages(string message)
            {
                NoDataPresent = message;
            }

            public string NoDataPresent { get; set; }

            
        }


    }

}
