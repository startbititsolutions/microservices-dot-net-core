using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrackingService.Model
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
}
