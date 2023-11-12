using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.DataAccess.Entities;

[Table("order_state")]
public class OrderState : BaseEntity
{
    public string Description { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}
