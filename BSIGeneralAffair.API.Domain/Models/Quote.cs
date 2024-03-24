using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BSIGeneralAffair.API.Domain.Models;

[Index("SamuraiId", Name = "IX_Quotes_SamuraiId")]
public partial class Quote
{
    [Key]
    public int QuoteId { get; set; }

    public string? Text { get; set; }

    public int SamuraiId { get; set; }

    [ForeignKey("SamuraiId")]
    [InverseProperty("Quotes")]
    public virtual Samurai Samurai { get; set; } = null!;
}
