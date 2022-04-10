using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderMngmntSystem.Models
{
    public class CustomerOrder
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("customerId")]
        public int customerId { get; set; }
        [ForeignKey("productId")]
        public int productId { get; set; }

        public DateTime OrderedDate { get; set; }
    }
}
