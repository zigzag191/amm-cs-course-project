using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.DataAccess.Entities;

[Table("order")]
public class Order : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int OrderStateId { get; set; }
    public OrderState OrderState { get; set; }

    public DateTime OrderDate { get; set; }

    public virtual ICollection<OrderedPhone> OrderedPhones { get; set; }
}
