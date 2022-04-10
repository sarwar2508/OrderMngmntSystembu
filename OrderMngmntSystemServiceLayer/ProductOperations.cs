﻿using OrderMngmntRepositoryLayer;
using OrderMngmntSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderMngmntSystemServiceLayer
{
    public class ProductOperations : IProductOperations
    {
        public OrderMngmntDbContext _productContext;
        public ProductOperations(OrderMngmntDbContext productContext)
        {
            _productContext = productContext;
        }


        public void DeleteProductCategory(ProductService product)
        {
            //ProductService prodServ = SearchByCategory(categ);
            //if(prodServ != null)
            //{
            _productContext.Remove<ProductService>(product);
            _productContext.SaveChanges();

        }

        public ProductService GetByCategory(string catg)
        {
            return _productContext.Find<ProductService>(catg);
        }

        public IList<ProductService> GetProductDetails()
        {
            return _productContext.Set<ProductService>().ToList();
        }

        public void AddCustomer(Customer customer)
        {
            _productContext.Add<Customer>(customer);
            _productContext.SaveChanges();
        }
        public CustomerOrder SearchOrderProducts(int orderId)
        {

            return _productContext.Find<CustomerOrder>(orderId);


        }

        public void SearchOrderDate(DateTime orderDate)
        {
            _productContext.Find<CustomerOrder>(orderDate);
            _productContext.SaveChanges();
        }

        public ProductService SearchByCategory(string catg)
        {

            return _productContext.Find<ProductService>(catg);

        }
        public ProductService GetProductName(int productId)
        {
            return _productContext.Find<ProductService>(productId);
        }
        public void AddProduct(ProductService prod)
        {

            _productContext.Add<ProductService>(prod);
            _productContext.SaveChanges();
        }
    }
}
