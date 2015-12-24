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
        }

        #region Buttons
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

        private void btnCompleteRange_Click(object sender, RoutedEventArgs e)
        {
            ChangeVisibility(true);
        }

        private void btnCompleteSingle_Click(object sender, RoutedEventArgs e)
        {
            ChangeVisibility(true);
        }

        #endregion Buttons

        private void ChangeVisibility(bool original)
        {
            if (original == false)
            {
                Application.Current.MainWindow.Height = 600;
                Application.Current.MainWindow.Width = 1250;
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
            spoilsGrid.ScrollIntoView(spoilsGrid.Items[spoilsGrid.Items.Count - 2]);
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
    }
}
