using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.DataAccess.Entities;

[Table("processor")]
public class Processor : BaseEntity
{
    public int Frequency { get; set; }
    public int NumberOfCores { get; set; }
    public int Tdp { get; set; }

    public virtual ICollection<Phone> Phones { get; set; }
}
