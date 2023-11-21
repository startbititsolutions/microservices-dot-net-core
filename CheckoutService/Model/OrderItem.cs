using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CheckoutService.Model
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Orders? Order { get; set;}
        public int OrderId { get; set; }
        public Product? products { get; set; }
        public int ProductId { get; set; }
        
        public int Quantity { get; set; }
        public decimal ItemPrice { get; set; }

    }
}
