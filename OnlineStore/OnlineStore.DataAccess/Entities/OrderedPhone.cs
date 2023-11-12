using System.ComponentModel.DataAnnotations;

namespace OnlineStore.DataAccess.Entities;

public class OrderedPhone : BaseEntity
{
    public int Amount { get; set; }

    [Key]
    public int PhoneId { get; set; }
    public Phone Phone { get; set; }

    [Key]
    public int OrderId { get; set; }
    public Order Order { get; set; }
}
