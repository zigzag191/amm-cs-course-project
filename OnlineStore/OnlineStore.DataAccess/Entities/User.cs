using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.DataAccess.Entities;

[Table("user")]
public class User : BaseEntity
{
    public string PasswordHash { get; set; }
    public string Login { get; set; }

    public virtual ICollection<PhoneRating> Ratings { get; set; }
    public virtual ICollection<PhoneComment> Comments { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<ItemInShoppingCart> ItemsInShoppingCart { get; set; }
}
