namespace Bank_Project_3_4.UserControls
{
    partial class ucSaldo
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
            this.grpbSaldo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUserSaldo = new System.Windows.Forms.TextBox();
            this.grpbSaldo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbSaldo
            // 
            this.grpbSaldo.BackColor = System.Drawing.Color.MintCream;
            this.grpbSaldo.Controls.Add(this.label2);
            this.grpbSaldo.Controls.Add(this.tbUserSaldo);
            this.grpbSaldo.Location = new System.Drawing.Point(26, 26);
            this.grpbSaldo.Name = "grpbSaldo";
            this.grpbSaldo.Size = new System.Drawing.Size(279, 141);
            this.grpbSaldo.TabIndex = 47;
            this.grpbSaldo.TabStop = false;
            this.grpbSaldo.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(8, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 20;
            this.label2.Text = "Uw saldo:";
            // 
            // tbUserSaldo
            // 
            this.tbUserSaldo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbUserSaldo.Location = new System.Drawing.Point(120, 27);
            this.tbUserSaldo.Name = "tbUserSaldo";
            this.tbUserSaldo.ReadOnly = true;
            this.tbUserSaldo.Size = new System.Drawing.Size(143, 25);
            this.tbUserSaldo.TabIndex = 19;
            // 
            // ucSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.Controls.Add(this.grpbSaldo);
            this.Name = "ucSaldo";
            this.Size = new System.Drawing.Size(761, 442);
            this.Load += new System.EventHandler(this.UcSaldo_Load);
            this.grpbSaldo.ResumeLayout(false);
            this.grpbSaldo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbSaldo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUserSaldo;
    }
}
