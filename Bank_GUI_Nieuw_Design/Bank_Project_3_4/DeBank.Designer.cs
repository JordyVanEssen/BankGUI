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
            this.btnLogout = new Syncfusion.WinForms.Controls.SfButton();
            this.btnGetsaldo = new Syncfusion.WinForms.Controls.SfButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUserSaldo = new System.Windows.Forms.TextBox();
            this.lblBill = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnTransaction = new Syncfusion.WinForms.Controls.SfButton();
            this.cmbChooseBill = new System.Windows.Forms.ComboBox();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.lblPinCode = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.rtbReceipt = new System.Windows.Forms.RichTextBox();
            this.pnlOtherTransaction = new System.Windows.Forms.Panel();
            this.lblOtherTransaction = new System.Windows.Forms.Label();
            this.btnExeOtherTransaction = new Syncfusion.WinForms.Controls.SfButton();
            this.pnlSaldo = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlTransaction = new System.Windows.Forms.Panel();
            this.btnOtherTransaction = new Syncfusion.WinForms.Controls.SfButton();
            this.btn100 = new Syncfusion.WinForms.Controls.SfButton();
            this.btn50 = new Syncfusion.WinForms.Controls.SfButton();
            this.btn10 = new Syncfusion.WinForms.Controls.SfButton();
            this.btnBack = new Syncfusion.WinForms.Controls.SfButton();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.pnlChooseBill = new System.Windows.Forms.Panel();
            this.tbOtherIban = new System.Windows.Forms.TextBox();
            this.tbOtherPassword = new System.Windows.Forms.TextBox();
            this.btnOtherUserValidation = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlReceipt = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReceiptNo = new Syncfusion.WinForms.Controls.SfButton();
            this.btnReceiptyes = new Syncfusion.WinForms.Controls.SfButton();
            this.spMoneyDispenser = new System.IO.Ports.SerialPort(this.components);
            this.pnlOtherTransaction.SuspendLayout();
            this.pnlSaldo.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlTransaction.SuspendLayout();
            this.pnlBack.SuspendLayout();
            this.pnlChooseBill.SuspendLayout();
            this.pnlReceipt.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM6";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.MyPort_DataReceived);
            // 
            // btnLogout
            // 
            this.btnLogout.AccessibleName = "Button";
            this.btnLogout.BackColor = System.Drawing.Color.LightGray;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnLogout.Location = new System.Drawing.Point(12, 272);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(139, 33);
            this.btnLogout.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnLogout.TabIndex = 20;
            this.btnLogout.Text = "Uitloggen";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnGetsaldo
            // 
            this.btnGetsaldo.AccessibleName = "Button";
            this.btnGetsaldo.BackColor = System.Drawing.Color.LightGray;
            this.btnGetsaldo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnGetsaldo.Location = new System.Drawing.Point(12, 52);
            this.btnGetsaldo.Name = "btnGetsaldo";
            this.btnGetsaldo.Size = new System.Drawing.Size(139, 33);
            this.btnGetsaldo.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnGetsaldo.TabIndex = 19;
            this.btnGetsaldo.Text = "Saldo opvragen";
            this.btnGetsaldo.UseVisualStyleBackColor = false;
            this.btnGetsaldo.Click += new System.EventHandler(this.btnGetSaldo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(7, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "Uw saldo:";
            // 
            // tbUserSaldo
            // 
            this.tbUserSaldo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbUserSaldo.Location = new System.Drawing.Point(112, 21);
            this.tbUserSaldo.Name = "tbUserSaldo";
            this.tbUserSaldo.ReadOnly = true;
            this.tbUserSaldo.Size = new System.Drawing.Size(143, 25);
            this.tbUserSaldo.TabIndex = 17;
            // 
            // lblBill
            // 
            this.lblBill.AutoSize = true;
            this.lblBill.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBill.Location = new System.Drawing.Point(3, 17);
            this.lblBill.Name = "lblBill";
            this.lblBill.Size = new System.Drawing.Size(88, 19);
            this.lblBill.TabIndex = 3;
            this.lblBill.Text = "Kies uw biljet";
            // 
            // tbAmount
            // 
            this.tbAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbAmount.Location = new System.Drawing.Point(112, 52);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(143, 25);
            this.tbAmount.TabIndex = 2;
            this.tbAmount.TextChanged += new System.EventHandler(this.tbAmount_TextChanged);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAmount.Location = new System.Drawing.Point(3, 55);
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
            this.btnTransaction.Location = new System.Drawing.Point(12, 10);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(139, 33);
            this.btnTransaction.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnTransaction.TabIndex = 16;
            this.btnTransaction.Text = "Bedrag opnemen";
            this.btnTransaction.UseVisualStyleBackColor = false;
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // cmbChooseBill
            // 
            this.cmbChooseBill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChooseBill.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbChooseBill.FormattingEnabled = true;
            this.cmbChooseBill.Location = new System.Drawing.Point(7, 39);
            this.cmbChooseBill.Name = "cmbChooseBill";
            this.cmbChooseBill.Size = new System.Drawing.Size(143, 25);
            this.cmbChooseBill.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnCancel.Location = new System.Drawing.Point(603, 500);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(139, 33);
            this.btnCancel.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblPinCode
            // 
            this.lblPinCode.AutoSize = false;
            this.lblPinCode.BackColor = System.Drawing.Color.Azure;
            this.lblPinCode.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.lblPinCode.Location = new System.Drawing.Point(209, 77);
            this.lblPinCode.Name = "lblPinCode";
            this.lblPinCode.Size = new System.Drawing.Size(570, 30);
            this.lblPinCode.TabIndex = 39;
            this.lblPinCode.Text = "PIN: ";
            this.lblPinCode.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            this.lblMessage.Location = new System.Drawing.Point(201, 32);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(570, 45);
            this.lblMessage.TabIndex = 38;
            this.lblMessage.Text = "Welkom, houd uw pas voor de reader.";
            // 
            // rtbReceipt
            // 
            this.rtbReceipt.BackColor = System.Drawing.Color.White;
            this.rtbReceipt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbReceipt.Location = new System.Drawing.Point(764, 110);
            this.rtbReceipt.Name = "rtbReceipt";
            this.rtbReceipt.ReadOnly = true;
            this.rtbReceipt.Size = new System.Drawing.Size(388, 319);
            this.rtbReceipt.TabIndex = 37;
            this.rtbReceipt.Text = "";
            this.rtbReceipt.Visible = false;
            // 
            // pnlOtherTransaction
            // 
            this.pnlOtherTransaction.BackColor = System.Drawing.Color.MintCream;
            this.pnlOtherTransaction.Controls.Add(this.lblOtherTransaction);
            this.pnlOtherTransaction.Controls.Add(this.lblAmount);
            this.pnlOtherTransaction.Controls.Add(this.tbAmount);
            this.pnlOtherTransaction.Location = new System.Drawing.Point(352, 110);
            this.pnlOtherTransaction.Name = "pnlOtherTransaction";
            this.pnlOtherTransaction.Size = new System.Drawing.Size(267, 127);
            this.pnlOtherTransaction.TabIndex = 42;
            this.pnlOtherTransaction.Visible = false;
            // 
            // lblOtherTransaction
            // 
            this.lblOtherTransaction.AutoSize = true;
            this.lblOtherTransaction.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblOtherTransaction.Location = new System.Drawing.Point(7, 24);
            this.lblOtherTransaction.Name = "lblOtherTransaction";
            this.lblOtherTransaction.Size = new System.Drawing.Size(146, 19);
            this.lblOtherTransaction.TabIndex = 4;
            this.lblOtherTransaction.Text = "Vul zelf een bedrag in";
            // 
            // btnExeOtherTransaction
            // 
            this.btnExeOtherTransaction.AccessibleName = "Button";
            this.btnExeOtherTransaction.BackColor = System.Drawing.Color.LightGray;
            this.btnExeOtherTransaction.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnExeOtherTransaction.Location = new System.Drawing.Point(7, 70);
            this.btnExeOtherTransaction.Name = "btnExeOtherTransaction";
            this.btnExeOtherTransaction.Size = new System.Drawing.Size(143, 33);
            this.btnExeOtherTransaction.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnExeOtherTransaction.TabIndex = 21;
            this.btnExeOtherTransaction.Text = "Bedrag opnemen";
            this.btnExeOtherTransaction.UseVisualStyleBackColor = false;
            this.btnExeOtherTransaction.Click += new System.EventHandler(this.BtnExeOtherTransaction_Click);
            // 
            // pnlSaldo
            // 
            this.pnlSaldo.BackColor = System.Drawing.Color.MintCream;
            this.pnlSaldo.Controls.Add(this.tbUserSaldo);
            this.pnlSaldo.Controls.Add(this.label2);
            this.pnlSaldo.Location = new System.Drawing.Point(352, 110);
            this.pnlSaldo.Name = "pnlSaldo";
            this.pnlSaldo.Size = new System.Drawing.Size(267, 64);
            this.pnlSaldo.TabIndex = 43;
            this.pnlSaldo.Visible = false;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.MintCream;
            this.pnlMenu.Controls.Add(this.btnGetsaldo);
            this.pnlMenu.Controls.Add(this.btnLogout);
            this.pnlMenu.Controls.Add(this.btnTransaction);
            this.pnlMenu.Location = new System.Drawing.Point(175, 110);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(171, 319);
            this.pnlMenu.TabIndex = 44;
            this.pnlMenu.Visible = false;
            // 
            // pnlTransaction
            // 
            this.pnlTransaction.BackColor = System.Drawing.Color.MintCream;
            this.pnlTransaction.Controls.Add(this.btnOtherTransaction);
            this.pnlTransaction.Controls.Add(this.btn100);
            this.pnlTransaction.Controls.Add(this.btn50);
            this.pnlTransaction.Controls.Add(this.btn10);
            this.pnlTransaction.Location = new System.Drawing.Point(352, 110);
            this.pnlTransaction.Name = "pnlTransaction";
            this.pnlTransaction.Size = new System.Drawing.Size(197, 183);
            this.pnlTransaction.TabIndex = 45;
            this.pnlTransaction.Visible = false;
            // 
            // btnOtherTransaction
            // 
            this.btnOtherTransaction.AccessibleName = "Button";
            this.btnOtherTransaction.BackColor = System.Drawing.Color.LightGray;
            this.btnOtherTransaction.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnOtherTransaction.Location = new System.Drawing.Point(112, 10);
            this.btnOtherTransaction.Name = "btnOtherTransaction";
            this.btnOtherTransaction.Size = new System.Drawing.Size(72, 33);
            this.btnOtherTransaction.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnOtherTransaction.TabIndex = 24;
            this.btnOtherTransaction.Text = "Anderss";
            this.btnOtherTransaction.UseVisualStyleBackColor = false;
            this.btnOtherTransaction.Click += new System.EventHandler(this.BtnOtherTransaction_Click);
            // 
            // btn100
            // 
            this.btn100.AccessibleName = "Button";
            this.btn100.BackColor = System.Drawing.Color.LightGray;
            this.btn100.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btn100.Location = new System.Drawing.Point(21, 94);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(72, 33);
            this.btn100.Style.BackColor = System.Drawing.Color.LightGray;
            this.btn100.TabIndex = 23;
            this.btn100.Text = "R 50";
            this.btn100.UseVisualStyleBackColor = false;
            this.btn100.Click += new System.EventHandler(this.Btn100_Click);
            // 
            // btn50
            // 
            this.btn50.AccessibleName = "Button";
            this.btn50.BackColor = System.Drawing.Color.LightGray;
            this.btn50.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btn50.Location = new System.Drawing.Point(21, 52);
            this.btn50.Name = "btn50";
            this.btn50.Size = new System.Drawing.Size(72, 33);
            this.btn50.Style.BackColor = System.Drawing.Color.LightGray;
            this.btn50.TabIndex = 22;
            this.btn50.Text = "R 20";
            this.btn50.UseVisualStyleBackColor = false;
            this.btn50.Click += new System.EventHandler(this.Btn50_Click);
            // 
            // btn10
            // 
            this.btn10.AccessibleName = "Button";
            this.btn10.BackColor = System.Drawing.Color.LightGray;
            this.btn10.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btn10.Location = new System.Drawing.Point(21, 10);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(72, 33);
            this.btn10.Style.BackColor = System.Drawing.Color.LightGray;
            this.btn10.TabIndex = 21;
            this.btn10.Text = "R 10";
            this.btn10.UseVisualStyleBackColor = false;
            this.btn10.Click += new System.EventHandler(this.Btn10_Click);
            // 
            // btnBack
            // 
            this.btnBack.AccessibleName = "Button";
            this.btnBack.BackColor = System.Drawing.Color.LightGray;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnBack.Location = new System.Drawing.Point(3, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 33);
            this.btnBack.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnBack.TabIndex = 25;
            this.btnBack.Text = "Terug";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // pnlBack
            // 
            this.pnlBack.BackColor = System.Drawing.Color.MintCream;
            this.pnlBack.Controls.Add(this.btnBack);
            this.pnlBack.Location = new System.Drawing.Point(532, 387);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(87, 42);
            this.pnlBack.TabIndex = 46;
            this.pnlBack.Visible = false;
            // 
            // pnlChooseBill
            // 
            this.pnlChooseBill.BackColor = System.Drawing.Color.MintCream;
            this.pnlChooseBill.Controls.Add(this.btnExeOtherTransaction);
            this.pnlChooseBill.Controls.Add(this.cmbChooseBill);
            this.pnlChooseBill.Controls.Add(this.lblBill);
            this.pnlChooseBill.Location = new System.Drawing.Point(352, 243);
            this.pnlChooseBill.Name = "pnlChooseBill";
            this.pnlChooseBill.Size = new System.Drawing.Size(267, 115);
            this.pnlChooseBill.TabIndex = 47;
            this.pnlChooseBill.Visible = false;
            // 
            // tbOtherIban
            // 
            this.tbOtherIban.Location = new System.Drawing.Point(6, 110);
            this.tbOtherIban.Name = "tbOtherIban";
            this.tbOtherIban.Size = new System.Drawing.Size(135, 20);
            this.tbOtherIban.TabIndex = 48;
            // 
            // tbOtherPassword
            // 
            this.tbOtherPassword.Location = new System.Drawing.Point(6, 134);
            this.tbOtherPassword.Name = "tbOtherPassword";
            this.tbOtherPassword.Size = new System.Drawing.Size(135, 20);
            this.tbOtherPassword.TabIndex = 49;
            // 
            // btnOtherUserValidation
            // 
            this.btnOtherUserValidation.Location = new System.Drawing.Point(6, 161);
            this.btnOtherUserValidation.Name = "btnOtherUserValidation";
            this.btnOtherUserValidation.Size = new System.Drawing.Size(75, 23);
            this.btnOtherUserValidation.TabIndex = 50;
            this.btnOtherUserValidation.Text = "button1";
            this.btnOtherUserValidation.UseVisualStyleBackColor = true;
            this.btnOtherUserValidation.Click += new System.EventHandler(this.BtnOtherUserValidation_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 51;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pnlReceipt
            // 
            this.pnlReceipt.BackColor = System.Drawing.Color.MintCream;
            this.pnlReceipt.Controls.Add(this.label1);
            this.pnlReceipt.Controls.Add(this.btnReceiptNo);
            this.pnlReceipt.Controls.Add(this.btnReceiptyes);
            this.pnlReceipt.Location = new System.Drawing.Point(349, 109);
            this.pnlReceipt.Name = "pnlReceipt";
            this.pnlReceipt.Size = new System.Drawing.Size(200, 148);
            this.pnlReceipt.TabIndex = 52;
            this.pnlReceipt.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Wilt u een bonnetje?\r\n";
            // 
            // btnReceiptNo
            // 
            this.btnReceiptNo.AccessibleName = "Button";
            this.btnReceiptNo.BackColor = System.Drawing.Color.LightGray;
            this.btnReceiptNo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnReceiptNo.Location = new System.Drawing.Point(12, 89);
            this.btnReceiptNo.Name = "btnReceiptNo";
            this.btnReceiptNo.Size = new System.Drawing.Size(80, 33);
            this.btnReceiptNo.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnReceiptNo.TabIndex = 26;
            this.btnReceiptNo.Text = "Nee";
            this.btnReceiptNo.UseVisualStyleBackColor = false;
            this.btnReceiptNo.Click += new System.EventHandler(this.BtnReceiptNo_Click);
            // 
            // btnReceiptyes
            // 
            this.btnReceiptyes.AccessibleName = "Button";
            this.btnReceiptyes.BackColor = System.Drawing.Color.LightGray;
            this.btnReceiptyes.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnReceiptyes.Location = new System.Drawing.Point(12, 50);
            this.btnReceiptyes.Name = "btnReceiptyes";
            this.btnReceiptyes.Size = new System.Drawing.Size(80, 33);
            this.btnReceiptyes.Style.BackColor = System.Drawing.Color.LightGray;
            this.btnReceiptyes.TabIndex = 26;
            this.btnReceiptyes.Text = "Ja";
            this.btnReceiptyes.UseVisualStyleBackColor = false;
            this.btnReceiptyes.Click += new System.EventHandler(this.BtnReceiptyes_Click);
            // 
            // DeBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1169, 617);
            this.Controls.Add(this.pnlReceipt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOtherUserValidation);
            this.Controls.Add(this.tbOtherPassword);
            this.Controls.Add(this.tbOtherIban);
            this.Controls.Add(this.pnlChooseBill);
            this.Controls.Add(this.pnlOtherTransaction);
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.pnlTransaction);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlSaldo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblPinCode);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.rtbReceipt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconSize = new System.Drawing.Size(25, 25);
            this.MaximizeBox = false;
            this.Name = "DeBank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style.BackColor = System.Drawing.Color.Azure;
            this.Text = "Pinautomaat";
            this.TransparencyKey = System.Drawing.Color.Silver;
            this.Load += new System.EventHandler(this.DeBank_Load);
            this.pnlOtherTransaction.ResumeLayout(false);
            this.pnlOtherTransaction.PerformLayout();
            this.pnlSaldo.ResumeLayout(false);
            this.pnlSaldo.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlTransaction.ResumeLayout(false);
            this.pnlBack.ResumeLayout(false);
            this.pnlChooseBill.ResumeLayout(false);
            this.pnlChooseBill.PerformLayout();
            this.pnlReceipt.ResumeLayout(false);
            this.pnlReceipt.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private Syncfusion.WinForms.Controls.SfButton btnLogout;
        private Syncfusion.WinForms.Controls.SfButton btnGetsaldo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUserSaldo;
        private System.Windows.Forms.Label lblBill;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label lblAmount;
        private Syncfusion.WinForms.Controls.SfButton btnTransaction;
        private System.Windows.Forms.ComboBox cmbChooseBill;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblPinCode;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.RichTextBox rtbReceipt;
        private System.Windows.Forms.Panel pnlOtherTransaction;
        private System.Windows.Forms.Label lblOtherTransaction;
        private System.Windows.Forms.Panel pnlSaldo;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlTransaction;
        private Syncfusion.WinForms.Controls.SfButton btnOtherTransaction;
        private Syncfusion.WinForms.Controls.SfButton btn100;
        private Syncfusion.WinForms.Controls.SfButton btn50;
        private Syncfusion.WinForms.Controls.SfButton btn10;
        private Syncfusion.WinForms.Controls.SfButton btnExeOtherTransaction;
        private Syncfusion.WinForms.Controls.SfButton btnBack;
        private System.Windows.Forms.Panel pnlBack;
        private System.Windows.Forms.Panel pnlChooseBill;
        private System.Windows.Forms.TextBox tbOtherIban;
        private System.Windows.Forms.TextBox tbOtherPassword;
        private System.Windows.Forms.Button btnOtherUserValidation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlReceipt;
        private System.Windows.Forms.Label label1;
        private Syncfusion.WinForms.Controls.SfButton btnReceiptNo;
        private Syncfusion.WinForms.Controls.SfButton btnReceiptyes;
        private System.IO.Ports.SerialPort spMoneyDispenser;
    }
}

