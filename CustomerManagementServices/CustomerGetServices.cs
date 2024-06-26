using CustomerManagementModel;
using CustomerManagementData;

namespace CustomerManagementServices
{
    public class CustomerGetServices
    {
        public List<Customer> GetAllCustomers()
        {
            SqlDbData customerData = new SqlDbData(); // Fixed the class name

            return customerData.GetCustomers();
        }

        public List<Customer> GetCustomersByStatus(string customerStatus)
        {
            List<Customer> customersByStatus = new List<Customer>();
            List<Customer> allCustomers = GetAllCustomers(); // Retrieve all customers first

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
            Customer foundCustomer = null; // Changed to null to check if found later

            foreach (var customer in GetAllCustomers())
            {
                if (customer.FirstName == firstName && customer.LastName == lastName)
                {
                    foundCustomer = customer;
                    break; // Exit loop once the customer is found
                }
            }

            return foundCustomer;
        }

        public Customer GetCustomer(string firstName)
        {
            Customer foundCustomer = null; // Changed to null to check if found later

            foreach (var customer in GetAllCustomers())
            {
                if (customer.FirstName == firstName)
                {
                    foundCustomer = customer;
                    break; // Exit loop once the customer is found
                }
            }

            return foundCustomer;
        }
    }
}