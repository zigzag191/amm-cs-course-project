﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.DataAccess.Entities;

[Table("phone_comment")]
public class PhoneComment : BaseEntity
{
    public string Comment { get; set; }
    public DateTime CreationTime { get; set; }

    [Key]
    public int PhoneId { get; set; }
    public Phone Phone { get; set; }

    [Key]
    public int UserId { get; set; }
    public User User { get; set; }
}
