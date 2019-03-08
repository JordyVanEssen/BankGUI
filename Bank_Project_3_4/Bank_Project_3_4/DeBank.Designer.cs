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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbLoggedInUser = new System.Windows.Forms.TextBox();
            this.grpbUserInterface = new System.Windows.Forms.GroupBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.grpbDeposit = new System.Windows.Forms.GroupBox();
            this.tbDepositMoney = new System.Windows.Forms.TextBox();
            this.btnDeposit = new System.Windows.Forms.Button();
            this.grpbWithdraw = new System.Windows.Forms.GroupBox();
            this.tbWithdrawMoney = new System.Windows.Forms.TextBox();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.grpbGetSaldo = new System.Windows.Forms.GroupBox();
            this.tbUserSaldo = new System.Windows.Forms.TextBox();
            this.btnGetSaldo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpbUserInterface.SuspendLayout();
            this.grpbDeposit.SuspendLayout();
            this.grpbWithdraw.SuspendLayout();
            this.grpbGetSaldo.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Gebruiker: ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(312, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(742, 308);
            this.dataGridView1.TabIndex = 6;
            // 
            // tbLoggedInUser
            // 
            this.tbLoggedInUser.Location = new System.Drawing.Point(69, 19);
            this.tbLoggedInUser.Name = "tbLoggedInUser";
            this.tbLoggedInUser.ReadOnly = true;
            this.tbLoggedInUser.Size = new System.Drawing.Size(100, 20);
            this.tbLoggedInUser.TabIndex = 7;
            // 
            // grpbUserInterface
            // 
            this.grpbUserInterface.Controls.Add(this.btnLogOut);
            this.grpbUserInterface.Controls.Add(this.grpbDeposit);
            this.grpbUserInterface.Controls.Add(this.grpbWithdraw);
            this.grpbUserInterface.Controls.Add(this.grpbGetSaldo);
            this.grpbUserInterface.Controls.Add(this.tbLoggedInUser);
            this.grpbUserInterface.Controls.Add(this.label1);
            this.grpbUserInterface.Location = new System.Drawing.Point(12, 12);
            this.grpbUserInterface.Name = "grpbUserInterface";
            this.grpbUserInterface.Size = new System.Drawing.Size(294, 402);
            this.grpbUserInterface.TabIndex = 8;
            this.grpbUserInterface.TabStop = false;
            this.grpbUserInterface.Visible = false;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(7, 373);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 11;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // grpbDeposit
            // 
            this.grpbDeposit.Controls.Add(this.tbDepositMoney);
            this.grpbDeposit.Controls.Add(this.btnDeposit);
            this.grpbDeposit.Location = new System.Drawing.Point(0, 239);
            this.grpbDeposit.Name = "grpbDeposit";
            this.grpbDeposit.Size = new System.Drawing.Size(263, 71);
            this.grpbDeposit.TabIndex = 10;
            this.grpbDeposit.TabStop = false;
            this.grpbDeposit.Text = "Geld storten";
            // 
            // tbDepositMoney
            // 
            this.tbDepositMoney.Location = new System.Drawing.Point(90, 31);
            this.tbDepositMoney.Name = "tbDepositMoney";
            this.tbDepositMoney.Size = new System.Drawing.Size(100, 20);
            this.tbDepositMoney.TabIndex = 1;
            // 
            // btnDeposit
            // 
            this.btnDeposit.Location = new System.Drawing.Point(9, 31);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(75, 34);
            this.btnDeposit.TabIndex = 0;
            this.btnDeposit.Text = "Dit bedrag storten";
            this.btnDeposit.UseVisualStyleBackColor = true;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // grpbWithdraw
            // 
            this.grpbWithdraw.Controls.Add(this.tbWithdrawMoney);
            this.grpbWithdraw.Controls.Add(this.btnWithdraw);
            this.grpbWithdraw.Location = new System.Drawing.Point(0, 151);
            this.grpbWithdraw.Name = "grpbWithdraw";
            this.grpbWithdraw.Size = new System.Drawing.Size(263, 71);
            this.grpbWithdraw.TabIndex = 9;
            this.grpbWithdraw.TabStop = false;
            this.grpbWithdraw.Text = "Geld opnemen";
            // 
            // tbWithdrawMoney
            // 
            this.tbWithdrawMoney.Location = new System.Drawing.Point(91, 31);
            this.tbWithdrawMoney.Name = "tbWithdrawMoney";
            this.tbWithdrawMoney.Size = new System.Drawing.Size(100, 20);
            this.tbWithdrawMoney.TabIndex = 1;
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Location = new System.Drawing.Point(9, 31);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(75, 34);
            this.btnWithdraw.TabIndex = 0;
            this.btnWithdraw.Text = "Dit bedrag opnemen";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // grpbGetSaldo
            // 
            this.grpbGetSaldo.Controls.Add(this.tbUserSaldo);
            this.grpbGetSaldo.Controls.Add(this.btnGetSaldo);
            this.grpbGetSaldo.Location = new System.Drawing.Point(0, 63);
            this.grpbGetSaldo.Name = "grpbGetSaldo";
            this.grpbGetSaldo.Size = new System.Drawing.Size(263, 71);
            this.grpbGetSaldo.TabIndex = 8;
            this.grpbGetSaldo.TabStop = false;
            this.grpbGetSaldo.Text = "Saldo opvragen";
            // 
            // tbUserSaldo
            // 
            this.tbUserSaldo.Location = new System.Drawing.Point(91, 33);
            this.tbUserSaldo.Name = "tbUserSaldo";
            this.tbUserSaldo.ReadOnly = true;
            this.tbUserSaldo.Size = new System.Drawing.Size(100, 20);
            this.tbUserSaldo.TabIndex = 1;
            // 
            // btnGetSaldo
            // 
            this.btnGetSaldo.Location = new System.Drawing.Point(9, 31);
            this.btnGetSaldo.Name = "btnGetSaldo";
            this.btnGetSaldo.Size = new System.Drawing.Size(75, 23);
            this.btnGetSaldo.TabIndex = 0;
            this.btnGetSaldo.Text = "Saldo";
            this.btnGetSaldo.UseVisualStyleBackColor = true;
            this.btnGetSaldo.Click += new System.EventHandler(this.btnGetSaldo_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(322, 27);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(235, 20);
            this.lblWelcome.TabIndex = 10;
            this.lblWelcome.Text = "Welkom, hou uw pas voor de reader.";
            // 
            // DeBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 462);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpbUserInterface);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DeBank";
            this.Text = "Pinautomaat";
            this.TransparencyKey = System.Drawing.Color.Silver;
            this.Load += new System.EventHandler(this.DeBank_Load);
            this.Shown += new System.EventHandler(this.DeBank_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpbUserInterface.ResumeLayout(false);
            this.grpbUserInterface.PerformLayout();
            this.grpbDeposit.ResumeLayout(false);
            this.grpbDeposit.PerformLayout();
            this.grpbWithdraw.ResumeLayout(false);
            this.grpbWithdraw.PerformLayout();
            this.grpbGetSaldo.ResumeLayout(false);
            this.grpbGetSaldo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbLoggedInUser;
        private System.Windows.Forms.GroupBox grpbUserInterface;
        private System.Windows.Forms.GroupBox grpbGetSaldo;
        private System.Windows.Forms.TextBox tbUserSaldo;
        private System.Windows.Forms.Button btnGetSaldo;
        private System.Windows.Forms.GroupBox grpbDeposit;
        private System.Windows.Forms.TextBox tbDepositMoney;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.GroupBox grpbWithdraw;
        private System.Windows.Forms.TextBox tbWithdrawMoney;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblWelcome;
    }
}

