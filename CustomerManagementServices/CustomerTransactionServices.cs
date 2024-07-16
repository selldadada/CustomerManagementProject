using CustomerManagementData;
using CustomerManagementModel;

namespace CustomerManagementServices
{
    public class CustomerTransactionServices
    {
        CustomerValidationServices validationServices = new CustomerValidationServices();
        CustomerData customerData = new CustomerData();

        public bool CreateCustomer(Customer customers)
        {
            bool result = false;

            if (validationServices.CheckIfCustomerExists(customers.FirstName, customers.LastName))
            {
                result = customerData.AddCustomer(customers) > 0;
            }

            return result;
        }

        public bool CreateCustomer(string FirstName, string LastName, string Orders, string DateOrdered, string OrderStatus)
        {
            Customer customers = new Customer { FirstName = FirstName, LastName = LastName, Orders = Orders, DateOrdered = DateOrdered, OrderStatus = OrderStatus};

            return CreateCustomer(customers);
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

        public bool UpdateCustomer(string FirstName, string LastName)
        {
            Customer customers = new Customer { FirstName = FirstName, LastName = LastName };

            return UpdateCustomer(customers);
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