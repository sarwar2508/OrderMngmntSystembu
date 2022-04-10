using Microsoft.EntityFrameworkCore;
using OrderMngmntSystem.Models;
using System;


namespace OrderMngmntSystem.Infrastructure
{
    public class OrderMngmntDbContext:DbContext
    {
        public OrderMngmntDbContext(DbContextOptions<OrderMngmntDbContext> options) : base(options) { }


        DbSet<Customer> Customers { get; set; }
        DbSet<ProductService> Products { get; set; }
        DbSet<CustomerOrder> customerOrders { get; set; }
    }
}
