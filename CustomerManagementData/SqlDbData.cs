using CustomerManagementModel;
using System.Data.SqlClient;
using System.Globalization;

namespace CustomerManagementData
{
    public class SqlDbData
    {
        string connectionString
            = "Server=localhost\\SQLEXPRESS;Database=CustomerManagementDb;Trusted_Connection=True;";

        SqlConnection sqlConnection;

        public SqlDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<Customer> GetCustomers()
        {
            string selectStatement = "SELECT * FROM customer;";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<Customer> customers = new List<Customer>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string firstName = reader["FirstName"].ToString();
                string lastName = reader["LastName"].ToString();
                string orders = reader["Orders"].ToString();
                string dateOrderedStr = reader["DateOrdered"].ToString();
                DateTime dateOrdered = DateTime.Parse(dateOrderedStr, CultureInfo.InvariantCulture);
                DateOnly dateOrderedOnly = DateOnly.FromDateTime(dateOrdered);
                DateTime dateOrderedDateTime = dateOrderedOnly.ToDateTime(TimeOnly.MinValue);
                string orderStatus = reader["OrderStatus"].ToString();

                Customer readCustomer = new Customer
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Orders = orders,
                    DateOrdered = dateOrderedDateTime,
                    OrderStatus = orderStatus,
                };

                customers.Add(readCustomer);
            }

            sqlConnection.Close();

            return customers;
        }

        public int AddCustomer(string firstName, string lastName)
        {
            int success;

            string insertStatement = "INSERT INTO customer (FirstName, LastName, Orders, DateOrdered, OrderStatus) VALUES (@FirstName, @LastName, @Orders, @DateOrdered, @Status)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@FirstName", firstName);
            insertCommand.Parameters.AddWithValue("@LastName", lastName);
            insertCommand.Parameters.AddWithValue("@Orders", "");
            insertCommand.Parameters.AddWithValue("@DateOrdered", DateTime.Now);
            insertCommand.Parameters.AddWithValue("@Status", 1);

            sqlConnection.Open();
            success = insertCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return success;
        }

        public int UpdateCustomer(string firstName, string lastName)
        {
            int success;

            string updateStatement = "UPDATE customer SET LastName = @LastName WHERE FirstName = @FirstName";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@FirstName", firstName);
            updateCommand.Parameters.AddWithValue("@LastName", lastName);

            sqlConnection.Open();
            success = updateCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return success;
        }

        public int DeleteCustomer(string firstName, string lastName)
        {
            int success;

            string deleteStatement = "DELETE FROM customer WHERE FirstName = @FirstName AND LastName = @LastName";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);

            deleteCommand.Parameters.AddWithValue("@FirstName", firstName);
            deleteCommand.Parameters.AddWithValue("@LastName", lastName);

            sqlConnection.Open();
            success = deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return success;
        }
    }
}