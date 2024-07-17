using CustomerManagementData;
using CustomerManagementModel;

namespace CustomerManagementServices
{
    public class CustomerTransactionServices
    {
        CustomerValidationServices validationServices = new CustomerValidationServices();
        CustomerData customerData = new CustomerData();

        public bool CreateCustomer(string firstName, string lastName, string orders, string dateOrdered, string orderStatus)
        {
            Customer customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Orders = orders,
                DateOrdered = dateOrdered,
                OrderStatus = orderStatus
            };

            return CreateCustomer(customer);
        }

        public bool CreateCustomer(Customer customer)
        {
            bool result = false;

            if (!validationServices.CheckIfCustomerExists(customer.FirstName, customer.LastName))
            {
                result = customerData.AddCustomer(customer) > 0;
            }

            return result;
        }

        public bool UpdateCustomer(Customer customers)
        {
            bool result = false;

            if (validationServices.CheckIfCustomerExists(customers.FirstName, customers.LastName))
            {
                result = customerData.UpdateCustomer(customers) > 0;
            }

            return result;
        }

        public bool UpdateCustomer(string firstName, string lastName, string orderStatus)
        {
            Customer customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                OrderStatus = orderStatus
            };

            return UpdateCustomer(customer);
        }

        public bool DeleteCustomer(Customer customers)
        {
            bool result = false;

            if (validationServices.CheckIfCustomerExists(customers.FirstName, customers.LastName))
            {
                result = customerData.DeleteCustomer(customers) > 0;
            }

            return result;
        }
    }
}