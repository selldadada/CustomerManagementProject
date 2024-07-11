namespace CustomerManagementServices
{
    public class CustomerValidationServices
    {

        CustomerGetServices getservices = new CustomerGetServices();

        public bool CheckIfCustomerExists(string FirstName, string LastName)
        {
            bool result = getservices.GetCustomer(FirstName, LastName) != null;
            return result;
        }
    }
}