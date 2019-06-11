namespace Bank_Project_3_4.UserControls
{
    partial class ucOtherAmountTransaction
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
            this.grpbOtherTransaction = new System.Windows.Forms.GroupBox();
            this.btnFinishTransaction = new Syncfusion.WinForms.Controls.SfButton();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblBill = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.cmbChooseBill = new System.Windows.Forms.ComboBox();
            this.grpbOtherTransaction.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbOtherTransaction
            // 
            this.grpbOtherTransaction.BackColor = System.Drawing.Color.MintCream;
            this.grpbOtherTransaction.Controls.Add(this.btnFinishTransaction);
            this.grpbOtherTransaction.Controls.Add(this.autoLabel2);
            this.grpbOtherTransaction.Controls.Add(this.lblBill);
            this.grpbOtherTransaction.Controls.Add(this.tbAmount);
            this.grpbOtherTransaction.Controls.Add(this.lblAmount);
            this.grpbOtherTransaction.Controls.Add(this.cmbChooseBill);
            this.grpbOtherTransaction.Location = new System.Drawing.Point(28, 24);
            this.grpbOtherTransaction.Name = "grpbOtherTransaction";
            this.grpbOtherTransaction.Size = new System.Drawing.Size(372, 160);
            this.grpbOtherTransaction.TabIndex = 42;
            this.grpbOtherTransaction.TabStop = false;
            this.grpbOtherTransaction.Visible = false;
            // 
            // btnFinishTransaction
            // 
            this.btnFinishTransaction.AccessibleName = "Button";
            this.btnFinishTransaction.BackColor = System.Drawing.Color.LightGray;
            this.btnFinishTransaction.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnFinishTransaction.Location = new System.Drawing.Point(273, 121);
            this.btnFinishTransaction.Name = "btnFinishTransaction";
            this.btnFinishTransaction.Size = new System.Drawing.Size(93, 33);
            this.btnFinishTransaction.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnFinishTransaction.TabIndex = 28;
            this.btnFinishTransaction.Text = "Opnemen";
            this.btnFinishTransaction.UseVisualStyleBackColor = false;
            this.btnFinishTransaction.Click += new System.EventHandler(this.BtnFinishTransaction_Click);
            // 
            // autoLabel2
            // 
            this.autoLabel2.BackColor = System.Drawing.Color.MintCream;
            this.autoLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.autoLabel2.Location = new System.Drawing.Point(12, 24);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(337, 19);
            this.autoLabel2.TabIndex = 13;
            this.autoLabel2.Text = "Vul zelf een bedrag in en daarna het gewenste biljet:";
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
            // ucOtherAmountTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.Controls.Add(this.grpbOtherTransaction);
            this.Name = "ucOtherAmountTransaction";
            this.Size = new System.Drawing.Size(929, 450);
            this.grpbOtherTransaction.ResumeLayout(false);
            this.grpbOtherTransaction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbOtherTransaction;
        private Syncfusion.WinForms.Controls.SfButton btnFinishTransaction;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private System.Windows.Forms.Label lblBill;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.ComboBox cmbChooseBill;
    }
}
