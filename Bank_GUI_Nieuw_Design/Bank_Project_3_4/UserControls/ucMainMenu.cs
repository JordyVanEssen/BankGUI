﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Project_3_4.UserControls
{
    public partial class ucMainMenu : UserControl
    {
        public ucMainMenu()
        {
            InitializeComponent();
        }

        private void ucMainMenu_Load(object sender, EventArgs e)
        {
            SetUserControlDefault setDefault = new SetUserControlDefault();
            this.BackColor = setDefault.backColor();
            this.Height = setDefault.height();
            this.Width = setDefault.width();
        }
    }
}
