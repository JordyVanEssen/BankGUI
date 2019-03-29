namespace Bank_Project_3_4
{
    partial class DeBank
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeBank));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.lblWelcome = new System.Windows.Forms.Label();
            this.grpbLoggedIn = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.tbUserSaldo = new System.Windows.Forms.TextBox();
            this.btnGetSaldo = new Syncfusion.WinForms.Controls.SfButton();
            this.lblBill = new System.Windows.Forms.Label();
            this.btnLogOut = new Syncfusion.WinForms.Controls.SfButton();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnTransaction = new Syncfusion.WinForms.Controls.SfButton();
            this.cmbChooseBill = new System.Windows.Forms.ComboBox();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.rtbReceipt = new System.Windows.Forms.RichTextBox();
            this.grpbLoggedIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM6";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.MyPort_DataReceived);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(33, 19);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(388, 30);
            this.lblWelcome.TabIndex = 10;
            this.lblWelcome.Text = "Welkom, houd uw pas voor de reader.";
            // 
            // grpbLoggedIn
            // 
            this.grpbLoggedIn.BackColor = System.Drawing.Color.MintCream;
            this.grpbLoggedIn.Controls.Add(this.label2);
            this.grpbLoggedIn.Controls.Add(this.autoLabel2);
            this.grpbLoggedIn.Controls.Add(this.tbUserSaldo);
            this.grpbLoggedIn.Controls.Add(this.btnGetSaldo);
            this.grpbLoggedIn.Controls.Add(this.lblBill);
            this.grpbLoggedIn.Controls.Add(this.btnLogOut);
            this.grpbLoggedIn.Controls.Add(this.tbAmount);
            this.grpbLoggedIn.Controls.Add(this.lblAmount);
            this.grpbLoggedIn.Controls.Add(this.btnTransaction);
            this.grpbLoggedIn.Controls.Add(this.cmbChooseBill);
            this.grpbLoggedIn.Location = new System.Drawing.Point(38, 52);
            this.grpbLoggedIn.Name = "grpbLoggedIn";
            this.grpbLoggedIn.Size = new System.Drawing.Size(516, 282);
            this.grpbLoggedIn.TabIndex = 15;
            this.grpbLoggedIn.TabStop = false;
            this.grpbLoggedIn.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(11, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Uw saldo:";
            // 
            // autoLabel2
            // 
            this.autoLabel2.BackColor = System.Drawing.Color.MintCream;
            this.autoLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.autoLabel2.Location = new System.Drawing.Point(12, 24);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(297, 19);
            this.autoLabel2.TabIndex = 13;
            this.autoLabel2.Text = "Vul zelf een bedrag in of kies alleen een biljet:";
            // 
            // tbUserSaldo
            // 
            this.tbUserSaldo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbUserSaldo.Location = new System.Drawing.Point(120, 120);
            this.tbUserSaldo.Name = "tbUserSaldo";
            this.tbUserSaldo.ReadOnly = true;
            this.tbUserSaldo.Size = new System.Drawing.Size(143, 25);
            this.tbUserSaldo.TabIndex = 5;
            // 
            // btnGetSaldo
            // 
            this.btnGetSaldo.AccessibleName = "Button";
            this.btnGetSaldo.BackColor = System.Drawing.Color.LightGray;
            this.btnGetSaldo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnGetSaldo.Image = ((System.Drawing.Image)(resources.GetObject("btnGetSaldo.Image")));
            this.btnGetSaldo.Location = new System.Drawing.Point(360, 94);
            this.btnGetSaldo.Name = "btnGetSaldo";
            this.btnGetSaldo.Size = new System.Drawing.Size(139, 33);
            this.btnGetSaldo.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnGetSaldo.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnGetSaldo.TabIndex = 19;
            this.btnGetSaldo.Text = "Saldo opvragen";
            this.btnGetSaldo.UseVisualStyleBackColor = false;
            this.btnGetSaldo.Click += new System.EventHandler(this.btnGetSaldo_Click);
            // 
            // lblBill
            // 
            this.lblBill.AutoSize = true;
            this.lblBill.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBill.Location = new System.Drawing.Point(11, 89);
            this.lblBill.Name = "lblBill";
            this.lblBill.Size = new System.Drawing.Size(88, 19);
            this.lblBill.TabIndex = 3;
            this.lblBill.Text = "Kies uw biljet";
            // 
            // btnLogOut
            // 
            this.btnLogOut.AccessibleName = "Button";
            this.btnLogOut.BackColor = System.Drawing.Color.LightGray;
            this.btnLogOut.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnLogOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnLogOut.Location = new System.Drawing.Point(12, 232);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(139, 33);
            this.btnLogOut.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnLogOut.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnLogOut.TabIndex = 18;
            this.btnLogOut.Text = "Uitloggen";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // tbAmount
            // 
            this.tbAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbAmount.Location = new System.Drawing.Point(120, 55);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(143, 25);
            this.tbAmount.TabIndex = 2;
            this.tbAmount.TextChanged += new System.EventHandler(this.tbAmount_TextChanged);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAmount.Location = new System.Drawing.Point(11, 58);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(55, 19);
            this.lblAmount.TabIndex = 1;
            this.lblAmount.Text = "Bedrag:";
            // 
            // btnTransaction
            // 
            this.btnTransaction.AccessibleName = "Button";
            this.btnTransaction.BackColor = System.Drawing.Color.LightGray;
            this.btnTransaction.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnTransaction.Location = new System.Drawing.Point(360, 55);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(139, 33);
            this.btnTransaction.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnTransaction.TabIndex = 16;
            this.btnTransaction.Text = "Bedrag opnemen";
            this.btnTransaction.UseVisualStyleBackColor = false;
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // cmbChooseBill
            // 
            this.cmbChooseBill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChooseBill.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbChooseBill.FormattingEnabled = true;
            this.cmbChooseBill.Location = new System.Drawing.Point(120, 86);
            this.cmbChooseBill.Name = "cmbChooseBill";
            this.cmbChooseBill.Size = new System.Drawing.Size(143, 25);
            this.cmbChooseBill.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnCancel.Location = new System.Drawing.Point(50, 364);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(139, 33);
            this.btnCancel.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rtbReceipt
            // 
            this.rtbReceipt.BackColor = System.Drawing.Color.White;
            this.rtbReceipt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbReceipt.Location = new System.Drawing.Point(592, 52);
            this.rtbReceipt.Name = "rtbReceipt";
            this.rtbReceipt.ReadOnly = true;
            this.rtbReceipt.Size = new System.Drawing.Size(260, 345);
            this.rtbReceipt.TabIndex = 18;
            this.rtbReceipt.Text = "";
            this.rtbReceipt.Visible = false;
            // 
            // DeBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1007, 486);
            this.Controls.Add(this.rtbReceipt);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpbLoggedIn);
            this.Controls.Add(this.lblWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconSize = new System.Drawing.Size(25, 25);
            this.MaximizeBox = false;
            this.Name = "DeBank";
            this.Style.BackColor = System.Drawing.Color.Azure;
            this.Text = "Pinautomaat";
            this.TransparencyKey = System.Drawing.Color.Silver;
            this.Load += new System.EventHandler(this.DeBank_Load);
            this.grpbLoggedIn.ResumeLayout(false);
            this.grpbLoggedIn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.GroupBox grpbLoggedIn;
        private Syncfusion.WinForms.Controls.SfButton btnTransaction;
        private Syncfusion.WinForms.Controls.SfButton btnLogOut;
        private Syncfusion.WinForms.Controls.SfButton btnGetSaldo;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private System.Windows.Forms.TextBox tbUserSaldo;
        private System.Windows.Forms.Label lblBill;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.ComboBox cmbChooseBill;
        private System.Windows.Forms.RichTextBox rtbReceipt;
    }
}

