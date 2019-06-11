namespace Bank_Project_3_4.UserControls
{
    partial class ucFastTransaction
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
            this.grpbFastTransaction = new System.Windows.Forms.GroupBox();
            this.btnOtherAmount = new Syncfusion.WinForms.Controls.SfButton();
            this.btnAmount200 = new Syncfusion.WinForms.Controls.SfButton();
            this.btnAmount100 = new Syncfusion.WinForms.Controls.SfButton();
            this.btnAmount50 = new Syncfusion.WinForms.Controls.SfButton();
            this.btnAmount10 = new Syncfusion.WinForms.Controls.SfButton();
            this.grpbFastTransaction.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbFastTransaction
            // 
            this.grpbFastTransaction.BackColor = System.Drawing.Color.MintCream;
            this.grpbFastTransaction.Controls.Add(this.btnOtherAmount);
            this.grpbFastTransaction.Controls.Add(this.btnAmount200);
            this.grpbFastTransaction.Controls.Add(this.btnAmount100);
            this.grpbFastTransaction.Controls.Add(this.btnAmount50);
            this.grpbFastTransaction.Controls.Add(this.btnAmount10);
            this.grpbFastTransaction.Location = new System.Drawing.Point(21, 14);
            this.grpbFastTransaction.Name = "grpbFastTransaction";
            this.grpbFastTransaction.Size = new System.Drawing.Size(263, 191);
            this.grpbFastTransaction.TabIndex = 45;
            this.grpbFastTransaction.TabStop = false;
            // 
            // btnOtherAmount
            // 
            this.btnOtherAmount.AccessibleName = "Button";
            this.btnOtherAmount.BackColor = System.Drawing.Color.LightGray;
            this.btnOtherAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnOtherAmount.Location = new System.Drawing.Point(164, 141);
            this.btnOtherAmount.Name = "btnOtherAmount";
            this.btnOtherAmount.Size = new System.Drawing.Size(93, 33);
            this.btnOtherAmount.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnOtherAmount.TabIndex = 25;
            this.btnOtherAmount.Text = "Anderss";
            this.btnOtherAmount.UseVisualStyleBackColor = false;
            this.btnOtherAmount.Click += new System.EventHandler(this.BtnOtherAmount_Click);
            // 
            // btnAmount200
            // 
            this.btnAmount200.AccessibleName = "Button";
            this.btnAmount200.BackColor = System.Drawing.Color.LightGray;
            this.btnAmount200.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnAmount200.Location = new System.Drawing.Point(32, 141);
            this.btnAmount200.Name = "btnAmount200";
            this.btnAmount200.Size = new System.Drawing.Size(86, 33);
            this.btnAmount200.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnAmount200.TabIndex = 24;
            this.btnAmount200.Text = "€ 200";
            this.btnAmount200.UseVisualStyleBackColor = false;
            // 
            // btnAmount100
            // 
            this.btnAmount100.AccessibleName = "Button";
            this.btnAmount100.BackColor = System.Drawing.Color.LightGray;
            this.btnAmount100.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnAmount100.Location = new System.Drawing.Point(32, 102);
            this.btnAmount100.Name = "btnAmount100";
            this.btnAmount100.Size = new System.Drawing.Size(86, 33);
            this.btnAmount100.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnAmount100.TabIndex = 23;
            this.btnAmount100.Text = "€ 100";
            this.btnAmount100.UseVisualStyleBackColor = false;
            // 
            // btnAmount50
            // 
            this.btnAmount50.AccessibleName = "Button";
            this.btnAmount50.BackColor = System.Drawing.Color.LightGray;
            this.btnAmount50.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnAmount50.Location = new System.Drawing.Point(32, 63);
            this.btnAmount50.Name = "btnAmount50";
            this.btnAmount50.Size = new System.Drawing.Size(86, 33);
            this.btnAmount50.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnAmount50.TabIndex = 22;
            this.btnAmount50.Text = "€ 50";
            this.btnAmount50.UseVisualStyleBackColor = false;
            // 
            // btnAmount10
            // 
            this.btnAmount10.AccessibleName = "Button";
            this.btnAmount10.BackColor = System.Drawing.Color.LightGray;
            this.btnAmount10.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnAmount10.Location = new System.Drawing.Point(32, 24);
            this.btnAmount10.Name = "btnAmount10";
            this.btnAmount10.Size = new System.Drawing.Size(86, 33);
            this.btnAmount10.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnAmount10.TabIndex = 21;
            this.btnAmount10.Text = "€ 10";
            this.btnAmount10.UseVisualStyleBackColor = false;
            this.btnAmount10.Click += new System.EventHandler(this.BtnAmount10_Click);
            // 
            // ucFastTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.Controls.Add(this.grpbFastTransaction);
            this.Name = "ucFastTransaction";
            this.Size = new System.Drawing.Size(623, 361);
            this.Load += new System.EventHandler(this.UcFastTransaction_Load);
            this.grpbFastTransaction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbFastTransaction;
        private Syncfusion.WinForms.Controls.SfButton btnOtherAmount;
        private Syncfusion.WinForms.Controls.SfButton btnAmount200;
        private Syncfusion.WinForms.Controls.SfButton btnAmount100;
        private Syncfusion.WinForms.Controls.SfButton btnAmount50;
        private Syncfusion.WinForms.Controls.SfButton btnAmount10;
    }
}
