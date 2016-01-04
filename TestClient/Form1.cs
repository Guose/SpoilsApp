using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestClient.ServiceReference1;

namespace TestClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataContract dc = new DataContract();
            dc.CustomerName = "Justin";
            SpoilsWCFServicesClient client = new SpoilsWCFServicesClient();
            MessageBox.Show(dc.CustomerName, "My Service");
            client.Close();





        }
    }
}
