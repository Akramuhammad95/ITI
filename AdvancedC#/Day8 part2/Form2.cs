using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day8_part2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtValue.Text, out double value))
            {
                lblResult.Text = "Enter a valid number";
                return;
            }

            string selected = cmbUnit.SelectedItem?.ToString();

            double result = 0;
            string outputUnit = "";

            switch (selected)
            {
                case "m to km":
                    result = value / 1000;
                    outputUnit = "km";
                    break;

                case "m to mile":
                    result = value / 1609.34;
                    outputUnit = "mile";
                    break;

                case "mile to m":
                    result = value * 1609.34;
                    outputUnit = "m";
                    break;

                default:
                    lblResult.Text = "Select conversion type";
                    return;
            }

            lblResult.Text = $"Result: {result} {outputUnit}";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
