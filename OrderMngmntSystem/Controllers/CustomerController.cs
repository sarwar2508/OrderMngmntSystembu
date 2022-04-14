using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderMngmntSystem.Infrastructure;
using OrderMngmntSystem.Models;
using System;
using System.Threading.Tasks;
using System.Linq;


namespace OrderMngmntSystem.Controllers
{

  
    public class CustomerController : Controller
    {
        private readonly IProductOperations _productOperations;
        private readonly ILogger<CustomerController> _logger;
        private readonly SendServiceBusMessage _sendServiceBusMessage;

        public CustomerController(IProductOperations productOperations, ILogger<CustomerController> Logger,
            SendServiceBusMessage sendServiceBusMessage)
        {
            _logger = Logger;
            _productOperations = productOperations;
            _logger.LogInformation("Customer Called");
            _sendServiceBusMessage = sendServiceBusMessage;
        }
        //public CustomerController(IProductOperations productOperations, ILogger<CustomerController> logger)
        //{

        //    _logger = logger;
        //    _logger.LogInformation("Customer Called");
        //    _productOperations = productOperations;
        //}


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

        public IActionResult CustomerPage()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }
      
        public ActionResult DeleteProduct()
        {
            return View();
        }


        public async Task<ActionResult> ProductDetailsList()
        {
            var products = await _productOperations.EditProduct();

            try
            {
                _logger.LogInformation("Product -EditProduct endpoint called");

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
        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductService prod)
        {
            try
            {
                _logger.LogInformation("Product -AddProduct endpoint called");
                if (prod != null)
                {
                    await _productOperations.AddProduct(prod);
                    ViewBag.Message = string.Format("Product Added Successfully");
                    return View(prod);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured -Exception detail", ex.InnerException);

            }
           
            return BadRequest();
        }
        public async Task<ActionResult> EditProduct()
        {
            var products = await _productOperations.EditProduct();

            try
            {
                _logger.LogInformation("Product -EditProduct endpoint called");

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

        [HttpPost]
        public async Task<ActionResult> DeleteProduct(ProductService product)
        {
            try
            {
                _logger.LogInformation("Product -DeleteProduct endpoint called");
                if (product != null)
                {
                    await _productOperations.DeleteProductCategory(product);
                    ViewBag.Message = string.Format("Product Deleted Successfully");

                    return View(product);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured -Exception detail", ex.InnerException);

            }
            return NotFound();

        }

        [HttpPost]
        public async Task<ActionResult> SearchOrderProducts(int OrderId)
        {
            try
            {
                _logger.LogInformation("CustomerOrder -OrderDetails endpoint called");
                var searchh = await _productOperations.SearchOrderProducts(OrderId);

                if (searchh != null)
                {
                    return View(searchh);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured -Exception detail", ex.InnerException);

            }
            return BadRequest("Not found");
        }
       
        [HttpGet]
        public async Task<ActionResult> GetProductbyId(int ProductId)
        {
            try
            {
                _logger.LogInformation("Product -GetProductbyId endpoint called");
                if (ProductId != 0)
                {
                    var res = await _productOperations.GetProductName(ProductId);
                    return View(res);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured -Exception detail", ex.InnerException);

            }
            return NotFound();
        }
    }

}
