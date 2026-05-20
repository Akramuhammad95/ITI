using System.Net.Http.Json;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly HttpClient httpClient;

        public Form1()
        {
            InitializeComponent();

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7000/");
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadCourses();
        }

        // =========================
        // LOAD COURSES
        // =========================
        private async Task LoadCourses()
        {
            var responseMessage = await httpClient.GetAsync("api/course/get");

            if (responseMessage.IsSuccessStatusCode)
            {
                var crs =
                    await responseMessage.Content.ReadFromJsonAsync<List<CourseData>>();

                dgv_courses.DataSource = crs;
            }
        }

        // =========================
        // ADD COURSE
        // =========================
        private async void btn_add_Click(object sender, EventArgs e)
        {
            var course = new CourseData()
            {
                name = txt_name.Text,
                description = txt_description.Text,
                duration = int.Parse(txt_duration.Text)
            };

            var response =
                await httpClient.PostAsJsonAsync("api/course/post", course);

            if (response.IsSuccessStatusCode)
            {
                await LoadCourses();

                txt_name.Text = "";
                txt_description.Text = "";
                txt_duration.Text = "";

                MessageBox.Show("Added Successfully");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        // =========================
        // DELETE SELECTED COURSE
        // =========================
        private async void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_courses.CurrentRow == null)
            {
                MessageBox.Show("Select Course First");
                return;
            }

            int id = Convert.ToInt32(
                dgv_courses.CurrentRow.Cells["id"].Value
            );

            var response =
                await httpClient.DeleteAsync($"api/course/deleteCourse/{id}");

            if (response.IsSuccessStatusCode)
            {
                await LoadCourses();

                MessageBox.Show("Deleted Successfully");
            }
            else
            {
                MessageBox.Show("Delete Failed");
            }
        }
    }
}