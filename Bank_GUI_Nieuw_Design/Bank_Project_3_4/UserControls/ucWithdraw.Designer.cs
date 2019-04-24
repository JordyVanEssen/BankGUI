namespace Bank_Project_3_4.UserControls
{
    partial class ucWithdraw
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
            this.grpbLoggedIn = new System.Windows.Forms.GroupBox();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblBill = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnTransaction = new Syncfusion.WinForms.Controls.SfButton();
            this.cmbChooseBill = new System.Windows.Forms.ComboBox();
            this.rtbReceipt = new System.Windows.Forms.RichTextBox();
            this.grpbLoggedIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbLoggedIn
            // 
            this.grpbLoggedIn.BackColor = System.Drawing.Color.MintCream;
            this.grpbLoggedIn.Controls.Add(this.rtbReceipt);
            this.grpbLoggedIn.Controls.Add(this.autoLabel2);
            this.grpbLoggedIn.Controls.Add(this.lblBill);
            this.grpbLoggedIn.Controls.Add(this.tbAmount);
            this.grpbLoggedIn.Controls.Add(this.lblAmount);
            this.grpbLoggedIn.Controls.Add(this.btnTransaction);
            this.grpbLoggedIn.Controls.Add(this.cmbChooseBill);
            this.grpbLoggedIn.Location = new System.Drawing.Point(317, 118);
            this.grpbLoggedIn.Name = "grpbLoggedIn";
            this.grpbLoggedIn.Size = new System.Drawing.Size(516, 420);
            this.grpbLoggedIn.TabIndex = 21;
            this.grpbLoggedIn.TabStop = false;
            this.grpbLoggedIn.Visible = false;
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
            // tbAmount
            // 
            this.tbAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbAmount.Location = new System.Drawing.Point(120, 55);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(143, 25);
            this.tbAmount.TabIndex = 2;
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
            // rtbReceipt
            // 
            this.rtbReceipt.BackColor = System.Drawing.Color.White;
            this.rtbReceipt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbReceipt.Location = new System.Drawing.Point(63, 137);
            this.rtbReceipt.Name = "rtbReceipt";
            this.rtbReceipt.ReadOnly = true;
            this.rtbReceipt.Size = new System.Drawing.Size(389, 277);
            this.rtbReceipt.TabIndex = 23;
            this.rtbReceipt.Text = "";
            this.rtbReceipt.Visible = false;
            // 
            // ucWithdraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.Controls.Add(this.grpbLoggedIn);
            this.Name = "ucWithdraw";
            this.Size = new System.Drawing.Size(1129, 600);
            this.grpbLoggedIn.ResumeLayout(false);
            this.grpbLoggedIn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbLoggedIn;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private System.Windows.Forms.Label lblBill;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label lblAmount;
        private Syncfusion.WinForms.Controls.SfButton btnTransaction;
        private System.Windows.Forms.ComboBox cmbChooseBill;
        private System.Windows.Forms.RichTextBox rtbReceipt;
    }
}
