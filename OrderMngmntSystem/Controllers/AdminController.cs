using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderMngmntSystem.Infrastructure;
using OrderMngmntSystem.Models;
using System;
using System.Threading.Tasks;

namespace OrderMngmntSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductOperations _productOperations;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IProductOperations productOperations, ILogger<AdminController> logger)
        {

            _logger = logger;
            _logger.LogInformation("Customer Called");
            _productOperations = productOperations;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminPage()
        {
            return View();
        }
        
        public IActionResult AddCustomer()
        {
            return View();
        }
       
        public async Task<ActionResult> GetCustomerDetails()
        {
            var customers = await _productOperations.GetCustomerDetails();

            try
            {
                _logger.LogInformation("Customer -GetCustomerDetails endpoint called");

                if (customers == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured -Exception detail", ex.InnerException);
            }
            return View(customers);


        }

        public async Task<ActionResult> GetCustomerOrderDetails()
        {
            var customer = await _productOperations.GetCustomerOrderDetails();

            try
            {
                _logger.LogInformation("Customer -GetCustomerOrderDetails endpoint called");

                if (customer == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured -Exception detail", ex.InnerException);
            }
            return View(customer);


        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer(Customer customer)
        {
            try
            {
                _logger.LogInformation("Product -AddCustomer endpoint called");
                if (customer != null)
                {
                    await _productOperations.AddCustomer(customer);
                    ViewBag.Message = string.Format("Customer Added Successfully");
                    return View(customer);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured -Exception detail", ex.InnerException);

            }

            return BadRequest();
        }

       
       

        //public async Task<ActionResult> AddCustomer(Customer customer)
        //{

        //    try
        //    {
        //        _logger.LogInformation("Customer -AddCustomer endpoint called");
        //        if (customer != null)
        //        {
        //            await _productOperations.AddCustomer(customer);
        //            return Ok(customer);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Exception Occured -Exception detail", ex.InnerException);

        //    }
        //    return BadRequest();
        //}





        //public async Task<ActionResult> SearchOrderProducts(int OrderId)
        //{
        //    try
        //    {
        //        _logger.LogInformation("CustomerOrder -OrderDetails endpoint called");
        //        var searchh = await _productOperations.SearchOrderProducts(OrderId);

        //        if (searchh != null)
        //        {
        //            return Ok(searchh);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Exception Occured -Exception detail", ex.InnerException);

        //    }
        //    return BadRequest("Not found");
        //}
        //public async Task<ActionResult> GetProductSellingHistory(int ProductId)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Product -DetailsById endpoint called");
        //        if (ProductId != 0)
        //        {
        //            var res = await _productOperations.GetProductName(ProductId);
        //            return Ok(res);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Exception Occured -Exception detail", ex.InnerException);

        //    }
        //    return NotFound();
        //}
        //public async Task<ActionResult> AddProduct(ProductService prod)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Product -AddProduct endpoint called");
        //        if (prod != null)
        //        {
        //            await _productOperations.AddProduct(prod);
        //            return Ok(prod);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Exception Occured -Exception detail", ex.InnerException);

        //    }
        //    return BadRequest();
        //}
    }
}
