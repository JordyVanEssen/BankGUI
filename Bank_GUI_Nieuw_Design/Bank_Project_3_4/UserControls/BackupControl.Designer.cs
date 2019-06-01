namespace Bank_Project_3_4
{
    partial class BackupControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.lblPinCode = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.rtbReceipt = new System.Windows.Forms.RichTextBox();
            this.cmbChooseBill = new System.Windows.Forms.ComboBox();
            this.btnTransaction = new Syncfusion.WinForms.Controls.SfButton();
            this.lblAmount = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.lblBill = new System.Windows.Forms.Label();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.tbUserSaldo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetsaldo = new Syncfusion.WinForms.Controls.SfButton();
            this.btnLogout = new Syncfusion.WinForms.Controls.SfButton();
            this.grpbLoggedIn = new System.Windows.Forms.GroupBox();
            this.grpbLoggedIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM6";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnCancel.Location = new System.Drawing.Point(648, 508);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(139, 33);
            this.btnCancel.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            // 
            // lblPinCode
            // 
            this.lblPinCode.AutoSize = false;
            this.lblPinCode.BackColor = System.Drawing.Color.Azure;
            this.lblPinCode.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.lblPinCode.Location = new System.Drawing.Point(210, 66);
            this.lblPinCode.Name = "lblPinCode";
            this.lblPinCode.Size = new System.Drawing.Size(570, 30);
            this.lblPinCode.TabIndex = 34;
            this.lblPinCode.Text = "PIN: ";
            this.lblPinCode.Visible = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(202, 21);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(570, 45);
            this.lblWelcome.TabIndex = 33;
            this.lblWelcome.Text = "Welkom, houd uw pas voor de reader.";
            // 
            // rtbReceipt
            // 
            this.rtbReceipt.BackColor = System.Drawing.Color.White;
            this.rtbReceipt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbReceipt.Location = new System.Drawing.Point(648, 99);
            this.rtbReceipt.Name = "rtbReceipt";
            this.rtbReceipt.ReadOnly = true;
            this.rtbReceipt.Size = new System.Drawing.Size(389, 277);
            this.rtbReceipt.TabIndex = 32;
            this.rtbReceipt.Text = "";
            this.rtbReceipt.Visible = false;
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
            // tbAmount
            // 
            this.tbAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbAmount.Location = new System.Drawing.Point(120, 55);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(143, 25);
            this.tbAmount.TabIndex = 2;
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
            this.tbUserSaldo.Location = new System.Drawing.Point(120, 117);
            this.tbUserSaldo.Name = "tbUserSaldo";
            this.tbUserSaldo.ReadOnly = true;
            this.tbUserSaldo.Size = new System.Drawing.Size(143, 25);
            this.tbUserSaldo.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(8, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "Uw saldo:";
            // 
            // btnGetsaldo
            // 
            this.btnGetsaldo.AccessibleName = "Button";
            this.btnGetsaldo.BackColor = System.Drawing.Color.LightGray;
            this.btnGetsaldo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnGetsaldo.Location = new System.Drawing.Point(360, 94);
            this.btnGetsaldo.Name = "btnGetsaldo";
            this.btnGetsaldo.Size = new System.Drawing.Size(139, 33);
            this.btnGetsaldo.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnGetsaldo.TabIndex = 19;
            this.btnGetsaldo.Text = "Saldo opvragen";
            this.btnGetsaldo.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            this.btnLogout.AccessibleName = "Button";
            this.btnLogout.BackColor = System.Drawing.Color.LightGray;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnLogout.Location = new System.Drawing.Point(360, 224);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(139, 33);
            this.btnLogout.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnLogout.TabIndex = 20;
            this.btnLogout.Text = "Uitloggen";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // grpbLoggedIn
            // 
            this.grpbLoggedIn.BackColor = System.Drawing.Color.MintCream;
            this.grpbLoggedIn.Controls.Add(this.btnLogout);
            this.grpbLoggedIn.Controls.Add(this.btnGetsaldo);
            this.grpbLoggedIn.Controls.Add(this.label2);
            this.grpbLoggedIn.Controls.Add(this.tbUserSaldo);
            this.grpbLoggedIn.Controls.Add(this.autoLabel2);
            this.grpbLoggedIn.Controls.Add(this.lblBill);
            this.grpbLoggedIn.Controls.Add(this.tbAmount);
            this.grpbLoggedIn.Controls.Add(this.lblAmount);
            this.grpbLoggedIn.Controls.Add(this.btnTransaction);
            this.grpbLoggedIn.Controls.Add(this.cmbChooseBill);
            this.grpbLoggedIn.Location = new System.Drawing.Point(101, 99);
            this.grpbLoggedIn.Name = "grpbLoggedIn";
            this.grpbLoggedIn.Size = new System.Drawing.Size(516, 277);
            this.grpbLoggedIn.TabIndex = 36;
            this.grpbLoggedIn.TabStop = false;
            this.grpbLoggedIn.Visible = false;
            // 
            // BackupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.Controls.Add(this.grpbLoggedIn);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblPinCode);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.rtbReceipt);
            this.Name = "BackupControl";
            this.Size = new System.Drawing.Size(1139, 563);
            this.grpbLoggedIn.ResumeLayout(false);
            this.grpbLoggedIn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblPinCode;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.RichTextBox rtbReceipt;
        private System.Windows.Forms.ComboBox cmbChooseBill;
        private Syncfusion.WinForms.Controls.SfButton btnTransaction;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label lblBill;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private System.Windows.Forms.TextBox tbUserSaldo;
        private System.Windows.Forms.Label label2;
        private Syncfusion.WinForms.Controls.SfButton btnGetsaldo;
        private Syncfusion.WinForms.Controls.SfButton btnLogout;
        private System.Windows.Forms.GroupBox grpbLoggedIn;
    }
}
