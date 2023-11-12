using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.DataAccess.Entities;

[Table("manufacturer")]
public class Manufacturer : BaseEntity
{
    public string CompanyName { get; set; }
    public virtual ICollection<Phone> Phones { get; set; }
}
