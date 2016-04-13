using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using SpoilsApp.WCF;
using System;
using System.IO.Ports;
using System.IO;

namespace Spoils.WPF_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SpoilsDataContract dc = new SpoilsDataContract();
        private SpoilsWCFService spoil_Service = new SpoilsWCFService();

        private Messages message = new Messages();


        public MainWindow()
        {
            InitializeComponent();
            GetCOMPortName();
            StartUpView();
            PopulateCustomerList();
        }


        #region Buttons
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dc.FileLocation = cboTextFileList.SelectedValue.ToString();
                spoil_Service.SaveToTextFile(dc.FileLocation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //spoilsClient.Close();
            }
        }

        private void btnStartNewSpoil_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InitializeComponent();
                GetCOMPortName();
                StartUpView();
                PopulateCustomerList();
            }
            catch { }
            finally
            {
                //spoilsClient.Close();
            }
        }

        public void btnSubmitRange_Click(object sender, RoutedEventArgs e)
        {            
            long firstNum = long.Parse(txtFirstNum.Text);
            long lastNum = long.Parse(txtLastNum.Text);

            try
            {
                dc.FileLocation = cboTextFileList.SelectedValue.ToString();
                spoilsGrid.DataContext = spoil_Service.RetrieveSpoilsRecordsDT(firstNum, lastNum, dc.FileLocation, dc.WasScanned);
            }
            catch
            {
                message.ToString();
                ChangeVisibility(true);
            }
            finally
            {
                txtFirstNum.Focus();
                txtFindRec.Visibility = Visibility.Visible;
                btnCompleteRange.Visibility = Visibility.Visible;
                btnSubmitRange.IsEnabled = false;
                ViewChangeOne();
                //spoilsClient.Close();
            }
        }

        public void btnSubmitSingle_Click(object sender, RoutedEventArgs e)
        {
            long singleNum = long.Parse(txtSingleNum.Text);
            // TODO: find a way to incorporate the file location with the RetrieveData method in the Spoils_Service & SpoilHandler Class
            try
            {                
                dc.FileLocation = cboTextFileList.SelectedValue.ToString();
                spoilsGrid.DataContext = spoil_Service.RetrieveSpoilsRecordsDT(singleNum, singleNum, dc.FileLocation, dc.WasScanned);

            }
            catch
            {
                message.ToString();
                ChangeVisibility(true);
            }
            finally
            {
                btnCompleteSingle.Visibility = Visibility.Visible;
                txtSingleNum.SelectionStart = 0;
                txtSingleNum.SelectionLength = txtSingleNum.Text.Length;
                btnSubmitSingle.IsEnabled = false;
                ViewChangeOne();
                //spoilsClient.Close();
            }
        }
        
        private void btnSingle_Click(object sender, RoutedEventArgs e)
        {
            isSingle = true;
            stkSingle.Visibility = Visibility.Visible;
            txtSingleNum.Focus();
            ChangeVisibility(false);
            SelectScanningMode("scanAddSpoil");
        }

        private void btnRange_Click(object sender, RoutedEventArgs e)
        {           
            isSingle = false;
            stkRange.Visibility = Visibility.Visible;
            txtFirstNum.Focus();
            ChangeVisibility(false);
            SelectScanningMode("scanAddSpoil");
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult clearWarning = MessageBox.Show("Are you sure you want to clear the data?", "WARNING", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (clearWarning == MessageBoxResult.Yes)
            {
                ClearAllData();
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

        private void btnLoadPrintstream_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextFilesList();

                lblCustomer.Visibility = Visibility.Hidden;
                lblJobNum.Visibility = Visibility.Hidden;
                ChangeVisibility(true);
                cboTextFileList.Visibility = Visibility.Visible;
                cboCustomerNames.Visibility = Visibility.Hidden;
                cboJobNumbers.Visibility = Visibility.Hidden;
                btnLoadPrintstream.Visibility = Visibility.Hidden;
                btnRange.IsEnabled = false;
                btnSingle.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Customer Name or Job Number", MessageBoxButton.OK, MessageBoxImage.Error);
                StartUpView();
            }
        }

        #endregion Buttons
        

        #region Methods

        private void PopulateJobNumberList()
        {
            cboJobNumbers.Items.Clear();
            string jobNumber = string.Empty;
            foreach (var item in spoil_Service.GetJobNumbers(spoil_Service.CustomerName))
            {
                if (item.Length > 6)
                {
                    jobNumber = item.Substring(0, 6);
                    cboJobNumbers.Items.Add(jobNumber);
                }                
            }
        }

        private void PopulateCustomerList()
        {
            cboCustomerNames.Focus();
            foreach (var item in spoil_Service.GetCustomerNames())
            {
                cboCustomerNames.Items.Add(item);
            }            
        }

        private void GetCOMPortName()
        {
            List<string> comPorts = new List<string>();

            foreach (ComPort.ComPortInfo comPort in ComPort.ComPortInfo.GetComPortsInfo())
            {
                comPorts.Add(string.Format("{0}-{1}", comPort.Name, comPort.Description));
            }
            cboComPort.ItemsSource = comPorts;
        }

        private void ViewChangeOne()
        {
            try
            {
                if (spoilsGrid.DataContext != null)
                {
                    spoilsGrid.ScrollIntoView(spoilsGrid.Items[spoilsGrid.Items.Count - 2]);
                }
                spoilsGrid.Visibility = Visibility.Visible;
                lblFocusToBottom.Visibility = Visibility.Visible;
                lblFocusToTop.Visibility = Visibility.Visible;
                btnSave.IsEnabled = true;
                txtFindRec.Visibility = Visibility.Visible;
            }
            catch (ArgumentOutOfRangeException are)
            {
                MessageBox.Show(are.Message + "\n\nIs the correct file loaded?", "ERROR MESSAGE", MessageBoxButton.OK, MessageBoxImage.Error);
            }           
        }

        public void TextFilesList()
        {
            try
            {
                string customerName = cboCustomerNames.SelectedValue.ToString();
                string jobNumber = cboJobNumbers.SelectedValue.ToString();

                string[] textlist = spoil_Service.RetrieveListOfTextFiles(customerName, jobNumber);

                if (cboTextFileList.Items.Count <= 1)
                {
                    foreach (string item in textlist)
                    {
                        //FileInfo fi = new FileInfo(item);
                        //TO DO: Assign fi.Directory to a private Directory array at class level to hold collection of directories for each file from data access layer filesearcher class

                        cboTextFileList.Items.Add(item);
                    }
                }
                else
                {
                    cboTextFileList.ItemsSource = null;
                }

                lblFileLoaded.Visibility = Visibility.Visible;
            }
            finally
            {
                //spoilsClient.Close();                
            }
        }

        private void ClearAllData()
        {
            
            txtFirstNum.Text = "";
            txtLastNum.Text = "";
            txtSingleNum.Text = "";
            txtFindRec.Text = "Find";
            txtFindRec.Foreground = new SolidColorBrush(Colors.Gray);
            txtFindRec.Visibility = Visibility.Hidden;
            spoilsGrid.DataContext = null;                       
            spoilsGrid.Visibility = Visibility.Hidden;
            lblFocusToBottom.Visibility = Visibility.Hidden;
            lblFocusToTop.Visibility = Visibility.Hidden;
            cboComPort.Visibility = Visibility.Hidden;
            lblScannerCOM.Visibility = Visibility.Hidden;
            StartUpView();
            //spoilsClient.Close();
        }

        private void StartUpView()
        {            
            spoilsGrid.Visibility = Visibility.Hidden;
            lblFileLoaded.Visibility = Visibility.Hidden;
            btnSingle.Visibility = Visibility.Hidden;
            btnRange.Visibility = Visibility.Hidden;
            ComboBoxReset();      
            cboTextFileList.Visibility = Visibility.Hidden;
            Height = 350;
            Width = 375;
            btnBack.Visibility = Visibility.Hidden;
            stkRange.Visibility = Visibility.Hidden;
            stkSingle.Visibility = Visibility.Hidden;
            btnLoadPrintstream.Visibility = Visibility.Visible;
            btnLoadPrintstream.IsEnabled = false;
            lblCustomer.Visibility = Visibility.Visible;
            cboCustomerNames.Visibility = Visibility.Visible;
            cboJobNumbers.Visibility = Visibility.Visible;
            lblJobNum.Visibility = Visibility.Visible;
            cboCustomerNames.Focus();
        }

        internal void ComboBoxReset()
        {
            cboTextFileList.Items.Clear();
            cboTextFileList.Items.Add("Select Printstream");
            cboTextFileList.SelectedIndex = 0;
        }

        public void ChangeVisibility(bool original)
        {
            if (original == false)
            {
                Height = 615;
                Width = 1250;
                btnSingle.Visibility = Visibility.Hidden;
                btnRange.Visibility = Visibility.Hidden;
                spoilsGrid.Visibility = Visibility.Visible;
                btnBack.Visibility = Visibility.Visible;
            }
            else
            {
                Application.Current.MainWindow.Height = 350;
                Application.Current.MainWindow.Width = 375;
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            spoil_Service.DeleteExcelFile();
        }

        private void cboJobNumbers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            btnLoadPrintstream.IsEnabled = true;
        }

        private void cboCustomerNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            spoil_Service.CustomerName = cboCustomerNames.SelectedValue.ToString();
            PopulateJobNumberList();
            cboJobNumbers.SelectedIndex = 0;
        }

        private void cboTextFileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cboComPort.Visibility = Visibility.Visible;
            lblScannerCOM.Visibility = Visibility.Visible;
            lblFileLoaded.Visibility = Visibility.Visible;
            Application.Current.MainWindow.Width = 1250;
            btnSingle.IsEnabled = true;
            btnRange.IsEnabled = true;
        }

        void txtFirstNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtLastNum.SelectionStart = 0;
                txtLastNum.SelectionLength = txtLastNum.Text.Length;
                dc.WasScanned = false;                
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
            try
            {
                spoilsGrid.ScrollIntoView(spoilsGrid.Items[spoilsGrid.Items.Count - 2]);
            }
            catch
            {
                message.ToString();
            }            
        }

        private void lblFocusToTop_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                spoilsGrid.ScrollIntoView(spoilsGrid.Items[spoilsGrid.SelectedIndex = 0]);
            }
            catch
            {
                message.ToString();
            }
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


        #region Scanner

        internal bool isSingle;
        internal bool isRangeFirstScan;
        internal bool isFirstScanCaptured;
        private bool scanAddSpoil;
        private bool scanRemoveSpoil;
        private bool exitScanMode;
        private bool insertionScan;

        public void SelectScanningMode(string scanType)
        {
            if (scanType == "scanAddSpoil")
                scanAddSpoil = true;

            if (scanType == "scanRemoveSpoil")
                scanRemoveSpoil = true;

            if (scanType == "exitScanMode")
                exitScanMode = true;

            if (scanType == "insertionScan")
                insertionScan = true;

            ConnectToScanner();
        }

        private SerialPort temp;


        public void ConnectToScanner()
        {
            try
            {
                temp.Close();
                temp.DataReceived -= temp_DataReceived;
            }
            catch { }

            try
            {
                string selectedItem = cboComPort.Text;
                string value = selectedItem.Substring(0, 4);
                temp = new SerialPort();
                //temp.PortName = Properties.Settings.Default.PortName;
                temp.PortName = value;
                temp.DataBits = int.Parse("8");
                temp.BaudRate = int.Parse("115200");
                temp.Parity = Parity.None;
                temp.StopBits = StopBits.One;
                temp.DiscardNull = false;
                temp.NewLine = "\r\n";
                //temp.ReceivedBytesThreshold = 1;
                temp.Handshake = Handshake.None;
                temp.Open();
                temp.DiscardInBuffer();
                temp.DataReceived += temp_DataReceived;
            }
            catch
            {
                MessageBoxResult connectCom = MessageBox.Show("Are you using a Barcode Scanner?", "Scanner NOT Detected", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (connectCom == MessageBoxResult.Yes)
                {
                    MessageBoxResult message = MessageBox.Show("Please select a COM Port to use Scanner", "Select COM Port", MessageBoxButton.OK, MessageBoxImage.Hand);
                    if (message == MessageBoxResult.OK)
                    {
                        ChangeVisibility(true);
                        Application.Current.MainWindow.Width = 1250;
                    }
                }
                else
                { }
            }
        }

        private void temp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort port = (SerialPort)sender;
            string dataRead = ((SerialPort)sender).ReadLine();

            try
            {
                if (isSingle)
                {
                    dc.WasScanned = true;
                    Dispatcher.BeginInvoke((Action)(() => txtSingleNum.Text = dataRead));
                    Dispatcher.BeginInvoke((Action)(() => btnSubmitSingle_Click(null, null)));
                    Dispatcher.BeginInvoke((Action)(() => txtSingleNum.SelectionStart = 0));
                    Dispatcher.BeginInvoke((Action)(() => txtSingleNum.SelectionLength = txtSingleNum.Text.Length));
                    
                }
                else
                {
                    if (isFirstScanCaptured == false)
                    {
                        isRangeFirstScan = true;
                        isFirstScanCaptured = true;
                        Dispatcher.BeginInvoke((Action)(() => txtFirstNum.Text = dataRead));
                        Dispatcher.BeginInvoke((Action)(() => txtLastNum.Focus()));
                        Dispatcher.BeginInvoke((Action)(() => txtLastNum.SelectionStart = 0));
                        Dispatcher.BeginInvoke((Action)(() => txtLastNum.SelectionLength = txtLastNum.Text.Length));
                        
                    }
                    else
                    {
                        isRangeFirstScan = false;
                        isFirstScanCaptured = false;
                        dc.WasScanned = true;
                        Dispatcher.BeginInvoke((Action)(() => txtLastNum.Text = dataRead));
                        Dispatcher.BeginInvoke((Action)(() => btnSubmitRange_Click(null, null)));
                        Dispatcher.BeginInvoke((Action)(() => txtFirstNum.SelectionStart = 0));
                        Dispatcher.BeginInvoke((Action)(() => txtFirstNum.SelectionLength = txtFirstNum.Text.Length));
                    }
                }
            }
            catch { }
        }

        #endregion Scanner


        #region MessageClass

        internal class Messages
        {
            public Messages()
            {
            }

            public Messages(string message)
            {
                NoDataPresent = message;
            }

            public string NoDataPresent { get; set; }

            public override string ToString()
            {
                string output = string.Empty;
                output += MessageBox.Show("Data has not been loaded to the program", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return output;
            }
        }


        #endregion MessageClass

    }
}
