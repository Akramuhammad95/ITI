namespace Day8_part2
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
            txtName = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            rbMale = new RadioButton();
            rbFemale = new RadioButton();
            label1 = new Label();
            label2 = new Label();
            chkFootball = new CheckBox();
            chkBoxing = new CheckBox();
            chkSwimming = new CheckBox();
            label4 = new Label();
            btnRegister = new Button();
            lblResult = new Label();
            btnGoToForm2 = new Button();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(136, 34);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 0;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(136, 110);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 1;
            txtEmail.TextChanged += textBox2_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(136, 185);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 2;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.Location = new Point(144, 270);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(63, 24);
            rbMale.TabIndex = 4;
            rbMale.TabStop = true;
            rbMale.Text = "Male";
            rbMale.UseVisualStyleBackColor = true;
            rbMale.CheckedChanged += rdMale_CheckedChanged;
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Location = new Point(413, 270);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(78, 24);
            rbFemale.TabIndex = 5;
            rbFemale.TabStop = true;
            rbFemale.Text = "Female";
            rbFemale.UseVisualStyleBackColor = true;
            rbFemale.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 17;
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 16;
            // 
            // chkFootball
            // 
            chkFootball.AutoSize = true;
            chkFootball.Location = new Point(136, 319);
            chkFootball.Name = "chkFootball";
            chkFootball.Size = new Size(86, 24);
            chkFootball.TabIndex = 10;
            chkFootball.Text = "Football";
            chkFootball.UseVisualStyleBackColor = true;
            chkFootball.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // chkBoxing
            // 
            chkBoxing.AutoSize = true;
            chkBoxing.Location = new Point(273, 319);
            chkBoxing.Name = "chkBoxing";
            chkBoxing.Size = new Size(77, 24);
            chkBoxing.TabIndex = 11;
            chkBoxing.Text = "Boxing";
            chkBoxing.UseVisualStyleBackColor = true;
            chkBoxing.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // chkSwimming
            // 
            chkSwimming.AutoSize = true;
            chkSwimming.Location = new Point(406, 319);
            chkSwimming.Name = "chkSwimming";
            chkSwimming.Size = new Size(101, 24);
            chkSwimming.TabIndex = 12;
            chkSwimming.Text = "Swimming";
            chkSwimming.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Crimson;
            label4.Location = new Point(530, 319);
            label4.Name = "label4";
            label4.Size = new Size(185, 20);
            label4.TabIndex = 13;
            label4.Text = "Choose at least one hobby";
            label4.Click += label4_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(326, 421);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(94, 29);
            btnRegister.TabIndex = 14;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(503, 420);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(0, 20);
            lblResult.TabIndex = 15;
            lblResult.Click += label5_Click;
            // 
            // btnGoToForm2
            // 
            btnGoToForm2.Location = new Point(568, 423);
            btnGoToForm2.Name = "btnGoToForm2";
            btnGoToForm2.Size = new Size(94, 29);
            btnGoToForm2.TabIndex = 18;
            btnGoToForm2.Text = "Go to form 2";
            btnGoToForm2.UseVisualStyleBackColor = true;
            btnGoToForm2.Click += btnGoToForm2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 495);
            Controls.Add(btnGoToForm2);
            Controls.Add(lblResult);
            Controls.Add(btnRegister);
            Controls.Add(label4);
            Controls.Add(chkSwimming);
            Controls.Add(chkBoxing);
            Controls.Add(chkFootball);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(rbFemale);
            Controls.Add(rbMale);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtName);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private RadioButton rbMale;
        private RadioButton rbFemale;
        private Label label1;
        private Label label2;
        private CheckBox chkFootball;
        private CheckBox chkBoxing;
        private CheckBox chkSwimming;
        private Label label4;
        private Button btnRegister;
        private Label lblResult;
        private Button btnGoToForm2;
    }
}
