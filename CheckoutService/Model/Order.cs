using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CheckoutService.Model
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public DateTime CreatedOn { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int UserId { get; set; }
  
       /* [ForeignKey("BillingDetailsId")]
        public virtual BillingDetails? BillingDetails { get; set; }

        public int? BillingDetailsId { get; set; }*/

    }
    public class Orderviewmodel
    {
        public string TransactionId { get; set; }
        public int UserId { get; set; }
        public  List<ProductViewModel> products { get; set; }
    }
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
