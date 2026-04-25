using Application.DTO;
using Application.interfaces;
using Domain.Entities;

namespace Day9
{
    public partial class Form1 : Form
    {
        private readonly IEmployeeService _service;

        public Form1(IEmployeeService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dto = new EmployeeDto
            {
                SSN = int.Parse(txtSSN.Text),
                FName = txtFName.Text,
                LName = txtLName.Text,
                DNO = int.Parse(txtDNO.Text),
                //BDate = dtpBirth.,
                Address = txtAddress.Text,
                Gender = rbFemale.Checked ? Sex.F : Sex.M,
                Salary = decimal.Parse(txtSalary.Text)
            };

            _service.AddEmployee(dto);

            MessageBox.Show("Added");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                btnSearch.Enabled = false;

                listBoxEmployees.Items.Clear();
                listBoxEmployees.Items.Add("Loading...");

                var result = await _service.SearchEmployee(txtSearch.Text);

                // عرض النتائج
                listBoxEmployees.Items.Clear();

                if (result.Count == 0)
                {
                    listBoxEmployees.Items.Add("No employees found");
                    return;
                }

                foreach (var emp in result)
                {
                    listBoxEmployees.Items.Add(
                        $"{emp.SSN} | {emp.FName} {emp.LName} | Salary: {emp.Salary}"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                btnSearch.Enabled = true;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
