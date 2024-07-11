namespace CustomerManagementAPI
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Orders { get; set; }
        public DateTime DateOrdered { get; set; }
        public string OrderStatus { get; set; }
    }
}
