using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.DataAccess.Entities;

[Table("phone")]
public class Phone : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string PhotoUrl { get; set; }

    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; }

    public int StorageSize { get; set; }
    public int RamSize { get; set; }

    public int ProcessorId { get; set; }
    public Processor Processor { get; set; }

    public virtual ICollection<PhoneRating> Ratings { get; set; }
    public virtual ICollection<PhoneComment> Comments { get; set; }
    public virtual ICollection<ItemInShoppingCart> ItemsInShoppingCart { get; set; }
    public virtual ICollection<OrderedPhone> OrderedPhones { get; set; }
}
