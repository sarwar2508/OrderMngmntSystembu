using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderMngmntSystem.Models
{
    public class Customer
    {
        [Key]
        public int customerId { get; set; }

        public string customerName { get; set; }
        public string Address { get; set; }
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
    }
}
