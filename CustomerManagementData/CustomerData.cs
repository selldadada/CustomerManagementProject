using CustomerManagementModel;

namespace CustomerManagementData
{
    public class CustomerData
    {
        List<Customer> customers;
        SqlDbData sqlData;
        public CustomerData()
        {
            customers = new List<Customer>();
            sqlData = new SqlDbData();
        }

        public List<Customer> GetCustomers()
        {
            customers = sqlData.GetCustomers();
            return customers;
        }

        public int AddCustomer(Customer customer)
        {
            return sqlData.AddCustomer(customer.FirstName, customer.LastName, customer.Orders, customer.DateOrdered, customer.OrderStatus);
        }

        public int UpdateCustomer(Customer customer)
        {
            return sqlData.UpdateCustomer(customer.FirstName, customer.LastName);
        }

        public int DeleteCustomer(Customer customer)
        {
            return sqlData.DeleteCustomer(customer.FirstName, customer.LastName);
        }

    }
}
