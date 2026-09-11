using System.Windows.Forms;
using System.Xml.Linq;
using ApplicationLayer.DTOs;
using ApplicationLayer.Interfaces;

namespace Day8_winform_clean_archeticture
{
    public partial class Form1 : Form
    {
        private readonly IUserService _userService;

        public Form1()
        {
            InitializeComponent();
        }
        public Form1(IUserService userService) : this()
        {
            _userService = userService;
        }
        //private void btnRegister_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var dto = new UserDto
        //        {
        //            Name = txtName.Text,
        //            Email = txtEmail.Text,
        //            Password = txtPassword.Text
        //        };

        //        _userService.Register(dto);

        //        MessageBox.Show("Registered!");
        //        LoadUsers();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void LoadUsers()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _userService.GetAll();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

    }
}
