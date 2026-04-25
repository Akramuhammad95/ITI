using Application.interfaces;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.Data.SqlClient;
namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Employee employee)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string query = @"INSERT INTO Employees
            (SSN, FName, LName, DNO, BDate, Address, Gender, Salary)
            VALUES (@SSN, @FName, @LName, @DNO, @BDate, @Address, @Gender, @Salary)";

            using SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@SSN", employee.SSN);
            cmd.Parameters.AddWithValue("@FName", employee.FName);
            cmd.Parameters.AddWithValue("@LName", employee.LName);
            cmd.Parameters.AddWithValue("@DNO", employee.DNO);
            cmd.Parameters.AddWithValue("@BDate", employee.BDate);
            cmd.Parameters.AddWithValue("@Address", employee.Address);
            cmd.Parameters.AddWithValue("@Gender", employee.Gender.ToString());
            cmd.Parameters.AddWithValue("@Salary", employee.Salary);

            cmd.ExecuteNonQuery();
        }


        public async Task <List<Employee>> Search(string name)
        {
            var list = new List<Employee>();

            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string query = @"SELECT * FROM Employees 
                             WHERE FName LIKE @Name OR LName LIKE @Name";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", $"%{name}%");

            using SqlDataReader reader = cmd.ExecuteReader();

            Thread.Sleep(3000);

            while (reader.Read())
            {
                list.Add(new Employee(
                    (int)reader["SSN"],
                    reader["FName"].ToString(),
                    reader["LName"].ToString(),
                    (int)reader["DNO"],
                    (DateTime)reader["BDate"],
                    reader["Address"].ToString(),
                    Enum.Parse<Sex>(reader["Gender"].ToString()),
                    (decimal)reader["Salary"]
                ));
            }

            return list;
        }

    }
}