using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderMngmntSystem.Infrastructure;
using OrderMngmntSystem.Models;
using System;
using System.Threading.Tasks;

namespace OrderMngmntSystem.Controllers
{

  
    public class CustomerController : Controller
    {
        private readonly IProductOperations _productOperations;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(IProductOperations productOperations, ILogger<CustomerController> logger)
        {

            _logger = logger;
            _logger.LogInformation("Customer Called");
            _productOperations = productOperations;
        }
        

        //public async Task<ActionResult> GetProductDetails()
        //{
        //    var products = await _productOperations.GetProductDetails();

        //    try
        //    {
        //        _logger.LogInformation("Product -GetProductDetails endpoint called");

        //        if (products == null)
        //        {
        //            return NotFound();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Exception Occured -Exception detail", ex.InnerException);
        //    }
        //    return Ok(products);


        //}
        /* [HttpGet]
         [Route("GetCategory")]
         public ActionResult GetByCategory(string catg)
         {
             var categ = _productOperations.GetByCategory(catg);
             if (categ != null)
             {
                 return Ok(categ);
             }
             return BadRequest();

         }*/

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



        //public async Task<ActionResult> DeleteCategory(ProductService product)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Product -DeleteProduct endpoint called");
        //        if (product != null)
        //        {
        //            await _productOperations.DeleteProductCategory(product);
        //            return Ok(product);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Exception Occured -Exception detail", ex.InnerException);

        //    }
        //    return NotFound();

        //}
        
        public async Task<ActionResult> SearchOrderProducts(int OrderId)
        {
            try
            {
                _logger.LogInformation("CustomerOrder -OrderDetails endpoint called");
                var searchh = await _productOperations.SearchOrderProducts(OrderId);

                if (searchh != null)
                {
                    return Ok(searchh);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured -Exception detail", ex.InnerException);

            }
            return BadRequest("Not found");
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
    }

}
