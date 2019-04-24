namespace Bank_Project_3_4.UserControls
{
    partial class ucMainMenu
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
            this.btnWithdraw = new Syncfusion.WinForms.Controls.SfButton();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.btnGetSaldo = new Syncfusion.WinForms.Controls.SfButton();
            this.SuspendLayout();
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.AccessibleName = "Button";
            this.btnWithdraw.BackColor = System.Drawing.Color.Azure;
            this.btnWithdraw.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.btnWithdraw.Location = new System.Drawing.Point(0, 94);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(222, 92);
            this.btnWithdraw.Style.BackColor = System.Drawing.Color.Azure;
            this.btnWithdraw.TabIndex = 0;
            this.btnWithdraw.Text = "Geld opnemen";
            this.btnWithdraw.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.BackColor = System.Drawing.Color.Azure;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.btnCancel.Location = new System.Drawing.Point(0, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(222, 92);
            this.btnCancel.Style.BackColor = System.Drawing.Color.Azure;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Annuleren/uitloggen";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnGetSaldo
            // 
            this.btnGetSaldo.AccessibleName = "Button";
            this.btnGetSaldo.BackColor = System.Drawing.Color.Azure;
            this.btnGetSaldo.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.btnGetSaldo.Location = new System.Drawing.Point(0, 192);
            this.btnGetSaldo.Name = "btnGetSaldo";
            this.btnGetSaldo.Size = new System.Drawing.Size(222, 92);
            this.btnGetSaldo.Style.BackColor = System.Drawing.Color.Azure;
            this.btnGetSaldo.TabIndex = 3;
            this.btnGetSaldo.Text = "Saldo opvragen";
            this.btnGetSaldo.UseVisualStyleBackColor = false;
            // 
            // ucMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.Controls.Add(this.btnGetSaldo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnWithdraw);
            this.Name = "ucMainMenu";
            this.Size = new System.Drawing.Size(1129, 600);
            this.Load += new System.EventHandler(this.ucMainMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.WinForms.Controls.SfButton btnWithdraw;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
        private Syncfusion.WinForms.Controls.SfButton btnGetSaldo;
    }
}
