using BusinessLogicLayer.models;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class AutherManager
    {
        private readonly DBManager _dbManager = new DBManager();

        public List<Authers> GetAllAuthers()
        {
            string query = "SELECT Id, FirstName, LastName, Phone, Email, Address FROM Auther";

            DataTable table = _dbManager.ExecuteQuery(query);

            List<Authers> authors = new List<Authers>();

            if (table == null)
                return authors;

            foreach (DataRow row in table.Rows)
            {
                Authers author = new Authers
                {
                    Id = row["Id"] != DBNull.Value ? Convert.ToInt32(row["Id"]) : 0,
                    FirstName = row["FirstName"]?.ToString(),
                    LastName = row["LastName"]?.ToString(),
                    Phone = row["Phone"]?.ToString(),
                    Email = row["Email"]?.ToString(),
                    Address = row["Address"]?.ToString()
                };

                authors.Add(author);
            }

            return authors;
        }

        public int AddAuther(Authers auther)
        {
            string query = @"INSERT INTO Auther 
                            (FirstName, LastName, Phone, Email, Address)
                            VALUES 
                            (@FirstName, @LastName, @Phone, @Email, @Address)";

            var parameters = new Dictionary<string, object>
            {
                {"@FirstName", auther.FirstName},
                {"@LastName", auther.LastName},
                {"@Phone", auther.Phone},
                {"@Email", auther.Email},
                {"@Address", auther.Address}
            };

            return _dbManager.ExecuteNonQuery(query, parameters);
        }

        public int UpdateAuther(Authers auther)
        {
            string query = @"UPDATE Auther SET
                            FirstName = @FirstName,
                            LastName = @LastName,
                            Phone = @Phone,
                            Email = @Email,
                            Address = @Address
                            WHERE Id = @Id";

            var parameters = new Dictionary<string, object>
            {
                {"@Id", auther.Id},
                {"@FirstName", auther.FirstName},
                {"@LastName", auther.LastName},
                {"@Phone", auther.Phone},
                {"@Email", auther.Email},
                {"@Address", auther.Address}
            };

            return _dbManager.ExecuteNonQuery(query, parameters);
        }

        public int DeleteAuther(int id)
        {
            string query = "DELETE FROM Auther WHERE Id = @Id";

            var parameters = new Dictionary<string, object>
            {
                {"@Id", id}
            };

            return _dbManager.ExecuteNonQuery(query, parameters);
        }

        public Authers GetAutherById(int id)
        {
            string query = "SELECT * FROM Auther WHERE Id = @Id";

            var parameters = new Dictionary<string, object>
            {
                {"@Id", id}
            };

            DataTable table = _dbManager.ExecuteQuery(query, parameters);

            if (table.Rows.Count == 0)
                return null;

            DataRow row = table.Rows[0];

            return new Authers
            {
                Id = Convert.ToInt32(row["Id"]),
                FirstName = row["FirstName"]?.ToString(),
                LastName = row["LastName"]?.ToString(),
                Phone = row["Phone"]?.ToString(),
                Email = row["Email"]?.ToString(),
                Address = row["Address"]?.ToString()
            };
        }
    }
}