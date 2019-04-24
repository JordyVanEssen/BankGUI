namespace Bank_Project_3_4.UserControls
{
    partial class ucGetsaldo
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbUserSaldo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.label2.Location = new System.Drawing.Point(429, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 30);
            this.label2.TabIndex = 14;
            this.label2.Text = "Uw saldo:";
            // 
            // tbUserSaldo
            // 
            this.tbUserSaldo.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.tbUserSaldo.Location = new System.Drawing.Point(541, 255);
            this.tbUserSaldo.Name = "tbUserSaldo";
            this.tbUserSaldo.ReadOnly = true;
            this.tbUserSaldo.Size = new System.Drawing.Size(143, 36);
            this.tbUserSaldo.TabIndex = 5;
            // 
            // ucGetsaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbUserSaldo);
            this.Name = "ucGetsaldo";
            this.Size = new System.Drawing.Size(1129, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUserSaldo;
    }
}
