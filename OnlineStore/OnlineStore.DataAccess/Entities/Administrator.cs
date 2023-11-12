using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.DataAccess.Entities;

[Table("administrator")]
public class Administrator : BaseEntity
{
    public string PasswordHash { get; set; }
    public string Login { get; set; }
}
