using CustomerManagementModel;
using CustomerManagementData;
using CustomerManagementServices;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerGetServices getServices = new CustomerGetServices();

            var customers = getServices.GetAllCustomers();

            Console.WriteLine("");
            Console.WriteLine("┌───────────────────────────────────────┐");
            Console.WriteLine("Welcome to Sellda's Tiktok Shop Database!");
            Console.WriteLine("└───────────────────────────────────────┘");
            Console.WriteLine("");
            Console.WriteLine("Here's the Order List:");
            Console.WriteLine("");
            Console.WriteLine("");

            foreach (var item in customers)
            {
                Console.WriteLine("Customer Name: " + item.FirstName + " " + item.LastName);
                Console.WriteLine("Orders: " + item.Orders);
                Console.WriteLine("Date Ordered: " + item.DateOrdered);
                Console.WriteLine("Order Status: " + item.OrderStatus);
                Console.WriteLine("");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("");
            }
        }
    }
}
