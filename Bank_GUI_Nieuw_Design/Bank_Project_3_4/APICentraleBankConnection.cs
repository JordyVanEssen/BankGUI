using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Project_3_4
{
    public partial class APICentraleBankConnection : Form
    {
        CentralBankConnection cbc = new CentralBankConnection();

        public APICentraleBankConnection()
        {
            InitializeComponent();
        }

        private void APICentraleBankConnection_Shown(object sender, EventArgs e)
        {

        }

        private void APICentraleBankConnection_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            cbc.close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            cbc.getMessage();
        }
    }
}
