using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;

namespace Bank_Project_3_4
{
    public partial class FormLogOut : SfForm
    {
        public FormLogOut()
        {
            InitializeComponent();
        }

        private void FormLogOut_Load(object sender, EventArgs e)
        {
            this.Style.Border = new Pen(Color.Silver, 2);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
