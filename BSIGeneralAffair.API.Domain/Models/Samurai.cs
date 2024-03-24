using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BSIGeneralAffair.API.Domain.Models;

public partial class Samurai
{
    [Key]
    public int SamuraiId { get; set; }

    public string Name { get; set; } = null!;

    [InverseProperty("Samurai")]
    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();
}
