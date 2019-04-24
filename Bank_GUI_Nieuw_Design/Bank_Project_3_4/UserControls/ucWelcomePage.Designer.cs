namespace Bank_Project_3_4.UserControls
{
    partial class ucWelcomePage
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
            this.lblPinCode = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.SuspendLayout();
            // 
            // lblPinCode
            // 
            this.lblPinCode.AutoSize = false;
            this.lblPinCode.BackColor = System.Drawing.Color.Azure;
            this.lblPinCode.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.lblPinCode.Location = new System.Drawing.Point(286, 218);
            this.lblPinCode.Name = "lblPinCode";
            this.lblPinCode.Size = new System.Drawing.Size(570, 30);
            this.lblPinCode.TabIndex = 26;
            this.lblPinCode.Text = "PIN: ";
            this.lblPinCode.Visible = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(278, 173);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(570, 45);
            this.lblWelcome.TabIndex = 25;
            this.lblWelcome.Text = "Welkom, houd uw pas voor de reader.";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnCancel.Location = new System.Drawing.Point(709, 455);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(139, 33);
            this.btnCancel.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            // 
            // ucWelcomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblPinCode);
            this.Controls.Add(this.lblWelcome);
            this.Name = "ucWelcomePage";
            this.Size = new System.Drawing.Size(1129, 600);
            this.Load += new System.EventHandler(this.ucWelcomePage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel lblPinCode;
        private System.Windows.Forms.Label lblWelcome;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
    }
}
