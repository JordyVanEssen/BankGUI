namespace Bank_Project_3_4
{
    partial class FormTransaction
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
            this.cmbChooseBill = new System.Windows.Forms.ComboBox();
            this.rbtnDeposit = new System.Windows.Forms.RadioButton();
            this.rbtnWithdrawel = new System.Windows.Forms.RadioButton();
            this.grpbMode = new System.Windows.Forms.GroupBox();
            this.grpbChooseAmount = new System.Windows.Forms.GroupBox();
            this.tbUserSaldo = new System.Windows.Forms.TextBox();
            this.lblBill = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.rtbReceipt = new System.Windows.Forms.RichTextBox();
            this.btnPrintReceipt = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButton2 = new Syncfusion.WinForms.Controls.SfButton();
            this.btnGetSaldo = new Syncfusion.WinForms.Controls.SfButton();
            this.btnConfirm = new Syncfusion.WinForms.Controls.SfButton();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.grpbMode.SuspendLayout();
            this.grpbChooseAmount.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbChooseBill
            // 
            this.cmbChooseBill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChooseBill.FormattingEnabled = true;
            this.cmbChooseBill.Location = new System.Drawing.Point(114, 121);
            this.cmbChooseBill.Name = "cmbChooseBill";
            this.cmbChooseBill.Size = new System.Drawing.Size(143, 25);
            this.cmbChooseBill.TabIndex = 0;
            this.cmbChooseBill.Visible = false;
            // 
            // rbtnDeposit
            // 
            this.rbtnDeposit.AutoSize = true;
            this.rbtnDeposit.Location = new System.Drawing.Point(6, 49);
            this.rbtnDeposit.Name = "rbtnDeposit";
            this.rbtnDeposit.Size = new System.Drawing.Size(103, 23);
            this.rbtnDeposit.TabIndex = 1;
            this.rbtnDeposit.TabStop = true;
            this.rbtnDeposit.Text = "Geld storten";
            this.rbtnDeposit.UseVisualStyleBackColor = true;
            this.rbtnDeposit.CheckedChanged += new System.EventHandler(this.rbtnDeposit_CheckedChanged);
            // 
            // rbtnWithdrawel
            // 
            this.rbtnWithdrawel.AutoSize = true;
            this.rbtnWithdrawel.Location = new System.Drawing.Point(6, 78);
            this.rbtnWithdrawel.Name = "rbtnWithdrawel";
            this.rbtnWithdrawel.Size = new System.Drawing.Size(117, 23);
            this.rbtnWithdrawel.TabIndex = 2;
            this.rbtnWithdrawel.TabStop = true;
            this.rbtnWithdrawel.Text = "Geld opnemen";
            this.rbtnWithdrawel.UseVisualStyleBackColor = true;
            this.rbtnWithdrawel.CheckedChanged += new System.EventHandler(this.rbtnWithdrawel_CheckedChanged);
            // 
            // grpbMode
            // 
            this.grpbMode.BackColor = System.Drawing.Color.MintCream;
            this.grpbMode.Controls.Add(this.autoLabel1);
            this.grpbMode.Controls.Add(this.rbtnDeposit);
            this.grpbMode.Controls.Add(this.rbtnWithdrawel);
            this.grpbMode.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.grpbMode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.grpbMode.Location = new System.Drawing.Point(31, 20);
            this.grpbMode.Name = "grpbMode";
            this.grpbMode.Size = new System.Drawing.Size(263, 107);
            this.grpbMode.TabIndex = 3;
            this.grpbMode.TabStop = false;
            // 
            // grpbChooseAmount
            // 
            this.grpbChooseAmount.BackColor = System.Drawing.Color.MintCream;
            this.grpbChooseAmount.Controls.Add(this.label1);
            this.grpbChooseAmount.Controls.Add(this.autoLabel2);
            this.grpbChooseAmount.Controls.Add(this.tbUserSaldo);
            this.grpbChooseAmount.Controls.Add(this.lblBill);
            this.grpbChooseAmount.Controls.Add(this.tbAmount);
            this.grpbChooseAmount.Controls.Add(this.lblAmount);
            this.grpbChooseAmount.Controls.Add(this.cmbChooseBill);
            this.grpbChooseAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.grpbChooseAmount.Location = new System.Drawing.Point(31, 133);
            this.grpbChooseAmount.Name = "grpbChooseAmount";
            this.grpbChooseAmount.Size = new System.Drawing.Size(263, 161);
            this.grpbChooseAmount.TabIndex = 4;
            this.grpbChooseAmount.TabStop = false;
            this.grpbChooseAmount.Enter += new System.EventHandler(this.grpbChooseBill_Enter);
            // 
            // tbUserSaldo
            // 
            this.tbUserSaldo.Location = new System.Drawing.Point(114, 56);
            this.tbUserSaldo.Name = "tbUserSaldo";
            this.tbUserSaldo.ReadOnly = true;
            this.tbUserSaldo.Size = new System.Drawing.Size(143, 25);
            this.tbUserSaldo.TabIndex = 5;
            // 
            // lblBill
            // 
            this.lblBill.AutoSize = true;
            this.lblBill.Location = new System.Drawing.Point(5, 124);
            this.lblBill.Name = "lblBill";
            this.lblBill.Size = new System.Drawing.Size(88, 19);
            this.lblBill.TabIndex = 3;
            this.lblBill.Text = "Kies uw biljet";
            this.lblBill.Visible = false;
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(114, 87);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(143, 25);
            this.tbAmount.TabIndex = 2;
            this.tbAmount.TextChanged += new System.EventHandler(this.tbAmount_TextChanged);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(5, 90);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(55, 19);
            this.lblAmount.TabIndex = 1;
            this.lblAmount.Text = "Bedrag:";
            // 
            // rtbReceipt
            // 
            this.rtbReceipt.BackColor = System.Drawing.Color.White;
            this.rtbReceipt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbReceipt.Location = new System.Drawing.Point(300, 28);
            this.rtbReceipt.Name = "rtbReceipt";
            this.rtbReceipt.ReadOnly = true;
            this.rtbReceipt.Size = new System.Drawing.Size(260, 361);
            this.rtbReceipt.TabIndex = 6;
            this.rtbReceipt.Text = "";
            // 
            // btnPrintReceipt
            // 
            this.btnPrintReceipt.AccessibleName = "Button";
            this.btnPrintReceipt.BackColor = System.Drawing.Color.LightGray;
            this.btnPrintReceipt.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnPrintReceipt.Location = new System.Drawing.Point(31, 327);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new System.Drawing.Size(161, 28);
            this.btnPrintReceipt.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnPrintReceipt.TabIndex = 9;
            this.btnPrintReceipt.Text = "Print het bonnetje";
            this.btnPrintReceipt.UseVisualStyleBackColor = false;
            this.btnPrintReceipt.Visible = false;
            this.btnPrintReceipt.Click += new System.EventHandler(this.btnPrintReceipt_Click);
            // 
            // sfButton2
            // 
            this.sfButton2.AccessibleName = "Button";
            this.sfButton2.BackColor = System.Drawing.Color.LightGray;
            this.sfButton2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.sfButton2.Location = new System.Drawing.Point(198, 361);
            this.sfButton2.Name = "sfButton2";
            this.sfButton2.Size = new System.Drawing.Size(96, 28);
            this.sfButton2.Style.BackColor = System.Drawing.Color.LightGray;
            this.sfButton2.TabIndex = 10;
            this.sfButton2.Text = "Terug";
            this.sfButton2.UseVisualStyleBackColor = false;
            this.sfButton2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGetSaldo
            // 
            this.btnGetSaldo.AccessibleName = "Button";
            this.btnGetSaldo.BackColor = System.Drawing.Color.LightGray;
            this.btnGetSaldo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnGetSaldo.Location = new System.Drawing.Point(198, 327);
            this.btnGetSaldo.Name = "btnGetSaldo";
            this.btnGetSaldo.Size = new System.Drawing.Size(96, 28);
            this.btnGetSaldo.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnGetSaldo.TabIndex = 11;
            this.btnGetSaldo.Text = "Saldo";
            this.btnGetSaldo.UseVisualStyleBackColor = false;
            this.btnGetSaldo.Click += new System.EventHandler(this.btnGetSaldo_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleName = "Button";
            this.btnConfirm.BackColor = System.Drawing.Color.LightGray;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnConfirm.Location = new System.Drawing.Point(31, 361);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(161, 28);
            this.btnConfirm.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnConfirm.TabIndex = 12;
            this.btnConfirm.Text = "Voltooi transactie";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // autoLabel1
            // 
            this.autoLabel1.BackColor = System.Drawing.Color.MintCream;
            this.autoLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.autoLabel1.Location = new System.Drawing.Point(6, 21);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(140, 19);
            this.autoLabel1.TabIndex = 3;
            this.autoLabel1.Text = "Kies wat u wilt doen:";
            // 
            // autoLabel2
            // 
            this.autoLabel2.BackColor = System.Drawing.Color.MintCream;
            this.autoLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.autoLabel2.Location = new System.Drawing.Point(6, 21);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(49, 19);
            this.autoLabel2.TabIndex = 13;
            this.autoLabel2.Text = "Vul in:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "Uw saldo:";
            // 
            // FormTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(571, 412);
            this.ControlBox = false;
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnGetSaldo);
            this.Controls.Add(this.sfButton2);
            this.Controls.Add(this.btnPrintReceipt);
            this.Controls.Add(this.rtbReceipt);
            this.Controls.Add(this.grpbChooseAmount);
            this.Controls.Add(this.grpbMode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTransaction";
            this.Style.BackColor = System.Drawing.Color.Azure;
            this.Text = "Transactie";
            this.Load += new System.EventHandler(this.FormTransaction_Load);
            this.grpbMode.ResumeLayout(false);
            this.grpbMode.PerformLayout();
            this.grpbChooseAmount.ResumeLayout(false);
            this.grpbChooseAmount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbChooseBill;
        private System.Windows.Forms.RadioButton rbtnDeposit;
        private System.Windows.Forms.RadioButton rbtnWithdrawel;
        private System.Windows.Forms.GroupBox grpbMode;
        private System.Windows.Forms.GroupBox grpbChooseAmount;
        private System.Windows.Forms.Label lblBill;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.RichTextBox rtbReceipt;
        private System.Windows.Forms.TextBox tbUserSaldo;
        private Syncfusion.WinForms.Controls.SfButton btnPrintReceipt;
        private Syncfusion.WinForms.Controls.SfButton sfButton2;
        private Syncfusion.WinForms.Controls.SfButton btnGetSaldo;
        private Syncfusion.WinForms.Controls.SfButton btnConfirm;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private System.Windows.Forms.Label label1;
    }
}