using CustomerManagementAPI;
using CustomerManagementServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace AccountManagement.API.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerManagementController : Controller
    {
        CustomerGetServices _customerGetServices;
        CustomerTransactionServices _customerTransactionServices;

        public CustomerManagementController()
        {
            _customerGetServices = new CustomerGetServices();
            _customerTransactionServices = new CustomerTransactionServices();
        }

        [HttpGet]
        public IEnumerable<CustomerManagementAPI.Customer> GetCustomers()
        {
            var allCustomers = _customerGetServices.GetAllCustomers();

            List<CustomerManagementAPI.Customer> users = new List<CustomerManagementAPI.Customer>();

            foreach (var item in allCustomers)
            {
                users.Add(new CustomerManagementAPI.Customer
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Orders = item.Orders,
                    DateOrdered = item.DateOrdered,
                    OrderStatus = item.OrderStatus,
                });
            }

            return users;
        }

        [HttpPost]
        public JsonResult AddCustomer(Customer request)
        {
            var result = _customerTransactionServices.CreateCustomer(
                request.FirstName,
                request.LastName,
                request.Orders,
                request.DateOrdered,
                request.OrderStatus);

            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateCustomer(Customer request)
        {
            var result = _customerTransactionServices.UpdateCustomer(request.FirstName, request.LastName, request.OrderStatus);

            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeleteCustomer(Customer request)
        {
            var customerModel = new CustomerManagementModel.Customer
            {

                FirstName = request.FirstName,
                LastName = request.LastName,
                Orders = request.Orders,
                DateOrdered = request.DateOrdered,
                OrderStatus = request.OrderStatus
            };

            var result = _customerTransactionServices.DeleteCustomer(customerModel);

            return new JsonResult(result);
        }
    }
}