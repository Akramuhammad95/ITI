namespace Day9
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAdd = new Button();
            btnSearch = new Button();
            btnClear = new Button();
            btnLoadAll = new Button();
            txtAddress = new TextBox();
            txtDNO = new TextBox();
            txtFName = new TextBox();
            txtSalary = new TextBox();
            txtSSN = new TextBox();
            txtLName = new TextBox();
            txtSearch = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            dbMale = new RadioButton();
            rbFemale = new RadioButton();
            listBoxEmployees = new ListBox();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(326, 64);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add Employee";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(326, 126);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search  ";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(326, 185);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnLoadAll
            // 
            btnLoadAll.Location = new Point(326, 248);
            btnLoadAll.Name = "btnLoadAll";
            btnLoadAll.Size = new Size(94, 29);
            btnLoadAll.TabIndex = 3;
            btnLoadAll.Text = "All";
            btnLoadAll.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(92, 266);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(125, 27);
            txtAddress.TabIndex = 6;
            // 
            // txtDNO
            // 
            txtDNO.Location = new Point(86, 207);
            txtDNO.Name = "txtDNO";
            txtDNO.Size = new Size(125, 27);
            txtDNO.TabIndex = 8;
            // 
            // txtFName
            // 
            txtFName.Location = new Point(92, 66);
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(125, 27);
            txtFName.TabIndex = 9;
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(92, 361);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(125, 27);
            txtSalary.TabIndex = 10;
            // 
            // txtSSN
            // 
            txtSSN.Location = new Point(92, 12);
            txtSSN.Name = "txtSSN";
            txtSSN.Size = new Size(125, 27);
            txtSSN.TabIndex = 11;
            // 
            // txtLName
            // 
            txtLName.Location = new Point(92, 113);
            txtLName.Name = "txtLName";
            txtLName.Size = new Size(125, 27);
            txtLName.TabIndex = 12;
            txtLName.TextChanged += textBox8_TextChanged;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(295, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(260, 27);
            txtSearch.TabIndex = 13;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 14);
            label1.Name = "label1";
            label1.Size = new Size(36, 20);
            label1.TabIndex = 14;
            label1.Text = "SSN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 69);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 15;
            label2.Text = "First name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 168);
            label3.Name = "label3";
            label3.Size = new Size(144, 20);
            label3.TabIndex = 17;
            label3.Text = "Department number";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 120);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 16;
            label4.Text = "Last name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 368);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 21;
            label5.Text = "Salary";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 313);
            label6.Name = "label6";
            label6.Size = new Size(57, 20);
            label6.TabIndex = 20;
            label6.Text = "Gender";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 269);
            label7.Name = "label7";
            label7.Size = new Size(53, 20);
            label7.TabIndex = 19;
            label7.Text = "Adress";
            // 
            // dbMale
            // 
            dbMale.AutoSize = true;
            dbMale.Location = new Point(100, 311);
            dbMale.Name = "dbMale";
            dbMale.Size = new Size(63, 24);
            dbMale.TabIndex = 22;
            dbMale.TabStop = true;
            dbMale.Text = "Male";
            dbMale.UseVisualStyleBackColor = true;
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Location = new Point(259, 309);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(78, 24);
            rbFemale.TabIndex = 23;
            rbFemale.TabStop = true;
            rbFemale.Text = "Female";
            rbFemale.UseVisualStyleBackColor = true;
            // 
            // listBoxEmployees
            // 
            listBoxEmployees.FormattingEnabled = true;
            listBoxEmployees.Location = new Point(549, 120);
            listBoxEmployees.Name = "listBoxEmployees";
            listBoxEmployees.Size = new Size(150, 104);
            listBoxEmployees.TabIndex = 24;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBoxEmployees);
            Controls.Add(rbFemale);
            Controls.Add(dbMale);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSearch);
            Controls.Add(txtLName);
            Controls.Add(txtSSN);
            Controls.Add(txtSalary);
            Controls.Add(txtFName);
            Controls.Add(txtDNO);
            Controls.Add(txtAddress);
            Controls.Add(btnLoadAll);
            Controls.Add(btnClear);
            Controls.Add(btnSearch);
            Controls.Add(btnAdd);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Button btnSearch;
        private Button btnClear;
        private Button btnLoadAll;
        private TextBox txtAddress;
        private TextBox txtDNO;
        private TextBox txtFName;
        private TextBox txtSalary;
        private TextBox txtSSN;
        private TextBox txtLName;
        private TextBox txtSearch;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private RadioButton dbMale;
        private RadioButton rbFemale;
        private ListBox listBoxEmployees;
    }
}
