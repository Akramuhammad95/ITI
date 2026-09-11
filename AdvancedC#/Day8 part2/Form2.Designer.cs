namespace Day8_part2
{
    partial class Form2
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
            txtValue = new TextBox();
            btnConvert = new Button();
            cmbUnit = new ComboBox();
            lblResult = new Label();
            SuspendLayout();
            // 
            // txtValue
            // 
            txtValue.Location = new Point(132, 127);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(125, 27);
            txtValue.TabIndex = 0;
            // 
            // btnConvert
            // 
            btnConvert.Cursor = Cursors.No;
            btnConvert.Location = new Point(562, 255);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(94, 29);
            btnConvert.TabIndex = 2;
            btnConvert.Text = "Submit";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // cmbUnit
            // 
            cmbUnit.FormattingEnabled = true;
            cmbUnit.Items.AddRange(new object[] { "m to km", "", "m to mile", "", "mile to m" });
            cmbUnit.Location = new Point(562, 108);
            cmbUnit.Name = "cmbUnit";
            cmbUnit.Size = new Size(151, 28);
            cmbUnit.TabIndex = 3;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(439, 357);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(0, 20);
            lblResult.TabIndex = 4;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResult);
            Controls.Add(cmbUnit);
            Controls.Add(btnConvert);
            Controls.Add(txtValue);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtValue;
        private Button btnConvert;
        private ComboBox cmbUnit;
        private Label lblResult;
    }
}