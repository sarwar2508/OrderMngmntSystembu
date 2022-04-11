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
        public async Task<ActionResult> GetProductDetails()
        {
            var products = await _productOperations.GetProductDetails();

            try
            {
                _logger.LogInformation("Product -GetProductDetails endpoint called");

                if (products == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured -Exception detail", ex.InnerException);
            }
            return View(products);


        }

        public async Task<ActionResult> DeleteCategory(ProductService product)
        {
            try
            {
                _logger.LogInformation("Product -DeleteProduct endpoint called");
                if (product != null)
                {
                    await _productOperations.DeleteProductCategory(product);
                    return Ok(product);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured -Exception detail", ex.InnerException);

            }
            return NotFound();

        }
       

        public async Task<ActionResult> AddCustomer(Customer customer)
        {

            try
            {
                _logger.LogInformation("Customer -AddCustomer endpoint called");
                if (customer != null)
                {
                    await _productOperations.AddCustomer(customer);
                    return Ok(customer);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured -Exception detail", ex.InnerException);

            }
            return BadRequest();
        }





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
