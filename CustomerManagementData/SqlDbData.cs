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
                string FirstName = reader["FirstName"].ToString();
                string LastName = reader["LastName"].ToString();
                string Orders = reader["Orders"].ToString();
                string DateOrdered = reader["DateOrdered"].ToString();
                string OrderStatus = reader["OrderStatus"].ToString();

                Customer readCustomer = new Customer
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Orders = Orders,
                    DateOrdered = DateOrdered,
                    OrderStatus = OrderStatus,
                };

                customers.Add(readCustomer);
            }

            sqlConnection.Close();

            return customers;
        }

        public int AddCustomer(string FirstName, string LastName, string Orders, string DateOrdered, string OrderStatus)
        {
            int success;

            string insertStatement = "INSERT INTO customer (FirstName, LastName, Orders, DateOrdered, OrderStatus) VALUES (@FirstName, @LastName, @Orders, @DateOrdered, @OrderStatus)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@FirstName", FirstName);
            insertCommand.Parameters.AddWithValue("@LastName", LastName);
            insertCommand.Parameters.AddWithValue("@Orders", Orders);
            insertCommand.Parameters.AddWithValue("@DateOrdered", DateOrdered);
            insertCommand.Parameters.AddWithValue("@OrderStatus", OrderStatus);

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