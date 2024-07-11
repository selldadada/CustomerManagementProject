using CustomerManagementModel;
using CustomerManagementData;

namespace CustomerManagementServices
{
    public class CustomerGetServices
    {
        public List<Customer> GetAllCustomers()
        {
            SqlDbData customerData = new SqlDbData();

            return customerData.GetCustomers();
        }

        public List<Customer> GetCustomersByStatus(string customerStatus)
        {
            List<Customer> customersByStatus = new List<Customer>();
            List<Customer> allCustomers = GetAllCustomers();

            foreach (var customer in allCustomers)
            {
                if (customer.OrderStatus == customerStatus)
                {
                    customersByStatus.Add(customer);
                }
            }

            return customersByStatus;
        }

        public Customer GetCustomer(string firstName, string lastName)
        {
            Customer foundCustomer = null;

            foreach (var customer in GetAllCustomers())
            {
                if (customer.FirstName == firstName && customer.LastName == lastName)
                {
                    foundCustomer = customer;
                    break;
                }
            }

            return foundCustomer;
        }

        public Customer GetCustomer(string firstName)
        {
            Customer foundCustomer = null;

            foreach (var customer in GetAllCustomers())
            {
                if (customer.FirstName == firstName)
                {
                    foundCustomer = customer;
                    break;
                }
            }

            return foundCustomer;
        }
    }
}