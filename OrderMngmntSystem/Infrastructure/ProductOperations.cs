
using OrderMngmntSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMngmntSystem.Infrastructure
{
    public class ProductOperations : IProductOperations
    {
        public OrderMngmntDbContext _productContext;
        public ProductOperations(OrderMngmntDbContext productContext)
        {
            _productContext = productContext;
        }


        public async Task DeleteProductCategory(ProductService product)
        {

            _productContext.Remove<ProductService>(product);
            await _productContext.SaveChangesAsync();

        }

        //public ProductService GetByCategory(string catg)
        //{
        //    return _productContext.Find<ProductService>(catg);
        //}

        public async Task<IList<ProductService>> GetProductDetails()
        {
            await Task.Delay(1000);
            return _productContext.Set<ProductService>().ToList();
        }

        public async Task AddCustomer(Customer customer)
        {
            _productContext.Add<Customer>(customer);

            await _productContext.SaveChangesAsync();
        }
        public async Task<CustomerOrder> SearchOrderProducts(int orderId)
        {

            return await _productContext.FindAsync<CustomerOrder>(orderId);

        }
        public async Task<ProductService> GetProductName(int productId)
        {
            return await _productContext.FindAsync<ProductService>(productId);
        }
        public async Task AddProduct(ProductService product)
        {

            _productContext.Add<ProductService>(product);
            await _productContext.SaveChangesAsync();
        }
    }
}
