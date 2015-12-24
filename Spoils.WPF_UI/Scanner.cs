using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Spoils.WPF_UI
{
    public class Scanner : MainWindow
    {
        //private string colBCName = "";
        private SerialPort temp;
        public bool isSingle = false;
        public bool isRangeFirstScan = false;
        public bool isFirstScanCaptured = false;

        //fix this field with Handler class
        public bool wasScanned = false;


        public void SelectScanningMode(string scanType)
        {
            bool scanAddSpoil = false;
            bool scanRemoveSpoil = false;
            bool exitScanMode = false;
            bool insertionScan = false;

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

        private void ConnectToScanner()
        {
            MainWindow mw = new MainWindow();

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
                MessageBoxResult connectCom = MessageBox.Show("Please select a COM Port name to use Barcode Scanner", "Scanner is NOT Connected", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                if (connectCom == MessageBoxResult.OK)
                {
                    mw.ChangeVisibility(true);
                    Application.Current.MainWindow.Width = 1250;
                }
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
                    Dispatcher.BeginInvoke((Action)(() => txtSingleNum.Text = dataRead));
                    Dispatcher.BeginInvoke((Action)(() => tnSubmitSingle_Click(null, null)));
                    Dispatcher.BeginInvoke((Action)(() => txtSingleNum.SelectionStart = 0));
                    Dispatcher.BeginInvoke((Action)(() => txtSingleNum.SelectionLength = txtSingleNum.Text.Length));
                    wasScanned = true;
                }
                else
                {
                    if (isFirstScanCaptured == false)
                    {
                        isRangeFirstScan = true;
                        Dispatcher.BeginInvoke((Action)(() => txtFirstNum.Text = dataRead));
                        Dispatcher.BeginInvoke((Action)(() => txtLastNum.Focus()));
                        Dispatcher.BeginInvoke((Action)(() => txtLastNum.SelectionStart = 0));
                        Dispatcher.BeginInvoke((Action)(() => txtLastNum.SelectionLength = txtLastNum.Text.Length));
                        isFirstScanCaptured = true;
                    }
                    else
                    {
                        Dispatcher.BeginInvoke((Action)(() => txtLastNum.Text = dataRead));
                        Dispatcher.BeginInvoke((Action)(() => BtnSubmitRange_Click(null, null)));
                        Dispatcher.BeginInvoke((Action)(() => txtFirstNum.SelectionStart = 0));
                        Dispatcher.BeginInvoke((Action)(() => txtFirstNum.SelectionLength = txtFirstNum.Text.Length));
                        isRangeFirstScan = false;
                        isFirstScanCaptured = false;
                        wasScanned = true;
                    }
                }                
            }
            catch { }
        }

        private void tnSubmitSingle_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnSubmitRange_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
