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
            this.label1 = new System.Windows.Forms.Label();
            this.tbLoggedInUser = new System.Windows.Forms.TextBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.grpbLoggedIn = new System.Windows.Forms.GroupBox();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.btnGetSaldo = new Syncfusion.WinForms.Controls.SfButton();
            this.btnLogOut = new Syncfusion.WinForms.Controls.SfButton();
            this.btnTransaction = new Syncfusion.WinForms.Controls.SfButton();
            this.tbUserSaldo = new System.Windows.Forms.TextBox();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.grpbLoggedIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM6";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.MyPort_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Gebruiker: ";
            // 
            // tbLoggedInUser
            // 
            this.tbLoggedInUser.BackColor = System.Drawing.Color.White;
            this.tbLoggedInUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbLoggedInUser.Location = new System.Drawing.Point(83, 24);
            this.tbLoggedInUser.Name = "tbLoggedInUser";
            this.tbLoggedInUser.ReadOnly = true;
            this.tbLoggedInUser.Size = new System.Drawing.Size(140, 25);
            this.tbLoggedInUser.TabIndex = 7;
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
            this.grpbLoggedIn.Controls.Add(this.autoLabel1);
            this.grpbLoggedIn.Controls.Add(this.btnGetSaldo);
            this.grpbLoggedIn.Controls.Add(this.btnLogOut);
            this.grpbLoggedIn.Controls.Add(this.btnTransaction);
            this.grpbLoggedIn.Controls.Add(this.tbUserSaldo);
            this.grpbLoggedIn.Controls.Add(this.tbLoggedInUser);
            this.grpbLoggedIn.Controls.Add(this.label1);
            this.grpbLoggedIn.Location = new System.Drawing.Point(38, 52);
            this.grpbLoggedIn.Name = "grpbLoggedIn";
            this.grpbLoggedIn.Size = new System.Drawing.Size(516, 267);
            this.grpbLoggedIn.TabIndex = 15;
            this.grpbLoggedIn.TabStop = false;
            this.grpbLoggedIn.Visible = false;
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.autoLabel1.Location = new System.Drawing.Point(7, 58);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(69, 19);
            this.autoLabel1.TabIndex = 17;
            this.autoLabel1.Text = "Uw Saldo:";
            // 
            // btnGetSaldo
            // 
            this.btnGetSaldo.AccessibleName = "Button";
            this.btnGetSaldo.BackColor = System.Drawing.Color.LightGray;
            this.btnGetSaldo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnGetSaldo.Image = ((System.Drawing.Image)(resources.GetObject("btnGetSaldo.Image")));
            this.btnGetSaldo.Location = new System.Drawing.Point(12, 118);
            this.btnGetSaldo.Name = "btnGetSaldo";
            this.btnGetSaldo.Size = new System.Drawing.Size(139, 33);
            this.btnGetSaldo.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnGetSaldo.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnGetSaldo.TabIndex = 19;
            this.btnGetSaldo.Text = "Saldo opvragen";
            this.btnGetSaldo.UseVisualStyleBackColor = false;
            this.btnGetSaldo.Click += new System.EventHandler(this.btnGetSaldo_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.AccessibleName = "Button";
            this.btnLogOut.BackColor = System.Drawing.Color.LightGray;
            this.btnLogOut.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnLogOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnLogOut.Location = new System.Drawing.Point(12, 220);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(139, 33);
            this.btnLogOut.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnLogOut.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnLogOut.TabIndex = 18;
            this.btnLogOut.Text = "Uitloggen";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnTransaction
            // 
            this.btnTransaction.AccessibleName = "Button";
            this.btnTransaction.BackColor = System.Drawing.Color.LightGray;
            this.btnTransaction.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnTransaction.Location = new System.Drawing.Point(12, 157);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(139, 33);
            this.btnTransaction.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnTransaction.TabIndex = 16;
            this.btnTransaction.Text = "Transactie uitvoeren";
            this.btnTransaction.UseVisualStyleBackColor = false;
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // tbUserSaldo
            // 
            this.tbUserSaldo.BackColor = System.Drawing.Color.White;
            this.tbUserSaldo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbUserSaldo.Location = new System.Drawing.Point(83, 58);
            this.tbUserSaldo.Name = "tbUserSaldo";
            this.tbUserSaldo.ReadOnly = true;
            this.tbUserSaldo.Size = new System.Drawing.Size(140, 25);
            this.tbUserSaldo.TabIndex = 17;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnCancel.Location = new System.Drawing.Point(50, 389);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(139, 33);
            this.btnCancel.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DeBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(682, 501);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLoggedInUser;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.GroupBox grpbLoggedIn;
        private System.Windows.Forms.TextBox tbUserSaldo;
        private Syncfusion.WinForms.Controls.SfButton btnTransaction;
        private Syncfusion.WinForms.Controls.SfButton btnLogOut;
        private Syncfusion.WinForms.Controls.SfButton btnGetSaldo;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
    }
}

