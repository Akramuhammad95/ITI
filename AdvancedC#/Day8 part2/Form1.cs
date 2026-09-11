namespace Day8_part2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;

            // Gender
            string gender = "";
            if (rbMale.Checked)
                gender = "Male";
            else if (rbFemale.Checked)
                gender = "Female";

            // Hobbies
            string hobbies = "";

            if (chkFootball.Checked)
                hobbies += "Football ";

            if (chkBoxing.Checked)
                hobbies += "Boxing ";

            if (chkSwimming.Checked)
                hobbies += "Swimming ";

            // Validation
            if (string.IsNullOrWhiteSpace(name) || gender == "" || hobbies == "")
            {
                lblResult.Text = "Please fill all fields!";
                lblResult.ForeColor = Color.Red;
                return;
            }

            // Show result
            lblResult.Text = $"Name: {name}\nGender: {gender}\nHobbies: {hobbies}";
            lblResult.ForeColor = Color.Green;
        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

       private void btnGoToForm2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

            this.Hide();
        }
    }
    
}
