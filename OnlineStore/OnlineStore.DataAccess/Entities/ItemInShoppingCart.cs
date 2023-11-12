using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.DataAccess.Entities;

[Table("item_in_shopping_cart")]
public class ItemInShoppingCart : BaseEntity
{
    public int Amount { get; set; }

    [Key]
    public int PhoneId { get; set; }
    public Phone Phone { get; set; }

    [Key]
    public int UserId { get; set; }
    public User User { get; set; }
}
