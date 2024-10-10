    using CustomerManagementModel;
    using CustomerManagementServices;

    namespace Client
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                CustomerGetServices getServices = new CustomerGetServices();
                CustomerTransactionServices transactionServices = new CustomerTransactionServices();
                EmailServices email = new EmailServices();

                bool running = true;

                while (running)
                {

                var customers = getServices.GetAllCustomers();

                Console.WriteLine("");
                Console.WriteLine("┌───────────────────────────────────────┐");
                Console.WriteLine("Welcome to Sellda's Tiktok Shop Database!");
                Console.WriteLine("└───────────────────────────────────────┘");
                Console.WriteLine("");
                Console.WriteLine("What do you want to do? Please select a number:");
                Console.WriteLine("");
                Console.WriteLine("1 - View Your Orders");
                Console.WriteLine("2 - Add an Order");
                Console.WriteLine("3 - Update an Order's Status");
                Console.WriteLine("4 - Delete an Order");
                Console.WriteLine("5 - Exit");
                Console.WriteLine("");
                Console.WriteLine("");

                string option = Console.ReadLine();

                if (int.TryParse(option, out int num))
                {
                    switch (num)
                    {
                        case 1:
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
                            break;

                        case 2:
                            Console.WriteLine("");
                            Console.WriteLine("Please Enter the Order Details.");
                            Console.WriteLine("");
                            Console.WriteLine("First Name:");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Last Name:");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Orders:");
                            string orders = Console.ReadLine();
                            Console.WriteLine("Date Ordered:");
                            string dateOrdered = Console.ReadLine();
                            Console.WriteLine("Order Status:");
                            string orderStatus = Console.ReadLine();
                            Console.WriteLine("");


                            if (transactionServices.CreateCustomer(firstName, lastName, orders, dateOrdered, orderStatus))
                            {
                                Console.WriteLine("Customer order saved successfully!");
                                email.AddOrderEmail();
                            }
                            else
                            {
                                Console.WriteLine("Failed to save the customer order.");
                            }
                            break;

                        case 3:
                            Console.WriteLine("");
                            Console.WriteLine("Please enter the Customer's Name then their new Order Status.");
                            Console.WriteLine("First Name:");
                            string firstName1 = Console.ReadLine();
                            Console.WriteLine("Last Name:");
                            string lastName1 = Console.ReadLine();
                            Console.WriteLine("New Order Status:");
                            string orderStatus1 = Console.ReadLine();
                            Console.WriteLine("");

                            if (transactionServices.UpdateCustomer(firstName1, lastName1, orderStatus1))
                            {
                                Console.WriteLine("Customer order updated successfully!");
                                email.UpdateOrderEmail();
                            }
                            else
                            {
                                Console.WriteLine("Failed to update the customer order.");
                            }
                            break;

                        case 4:
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("Please enter the Customer's Name to Delete their Order.");
                            Console.WriteLine("First Name:");
                            string firstName2 = Console.ReadLine();
                            Console.WriteLine("Last Name:");
                            string lastName2 = Console.ReadLine();
                            Console.WriteLine("");

                            Customer delete = new Customer
                            {
                                FirstName = firstName2,
                                LastName = lastName2
                            };

                            if (transactionServices.DeleteCustomer(delete))
                            {
                                Console.WriteLine("Customer order deleted successfully!");
                                email.DeleteOrderEmail();
                            }
                            else
                            {
                                Console.WriteLine("Failed to delete the customer order.");
                            }
                            break;

                        case 5:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please select a valid number.");
                            break;
                    }

                    if (running)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Press Enter to return to the Main Menu.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
    }
}