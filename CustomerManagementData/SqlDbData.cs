using CustomerManagementModel;
using System.Data.SqlClient;
using System.Globalization;

namespace CustomerManagementData
{
    public class SqlDbData
    {
        string connectionString
            = "Server=localhost\\SQLEXPRESS;Database=CustomerManagementDb;Integrated Security=True;";

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

        public int AddCustomer(Customer customer)
        {
            return AddCustomer(customer.FirstName, customer.LastName, customer.Orders, customer.DateOrdered, customer.OrderStatus);
        }

        public int AddCustomer(string firstName, string lastName, string orders, string dateOrdered, string orderStatus)
        {
            int success;

            string insertStatement = "INSERT INTO customer (FirstName, LastName, Orders, DateOrdered, OrderStatus) VALUES (@FirstName, @LastName, @Orders, @DateOrdered, @OrderStatus)";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection))
                {
                    insertCommand.Parameters.AddWithValue("@FirstName", firstName);
                    insertCommand.Parameters.AddWithValue("@LastName", lastName);
                    insertCommand.Parameters.AddWithValue("@Orders", orders);
                    insertCommand.Parameters.AddWithValue("@DateOrdered", dateOrdered);
                    insertCommand.Parameters.AddWithValue("@OrderStatus", orderStatus);

                    sqlConnection.Open();
                    success = insertCommand.ExecuteNonQuery();
                }
            }

            return success;
        }

        public int UpdateCustomer(string firstName, string lastName, string orderStatus)
        {
            int success;

            string updateStatement = "UPDATE customer SET OrderStatus = @OrderStatus WHERE FirstName = @FirstName AND LastName = @LastName";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection))
                {
                    updateCommand.Parameters.AddWithValue("@FirstName", firstName);
                    updateCommand.Parameters.AddWithValue("@LastName", lastName);
                    updateCommand.Parameters.AddWithValue("@OrderStatus", orderStatus);

                    sqlConnection.Open();
                    success = updateCommand.ExecuteNonQuery();
                }
            }

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