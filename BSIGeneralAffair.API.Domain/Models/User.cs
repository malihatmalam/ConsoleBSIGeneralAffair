using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BSIGeneralAffair.API.Domain.Models;

[Table("Users", Schema = "Person")]
[Index("UserFirstName", Name = "Index_UsersFirstName")]
[Index("UserUsername", Name = "UNIQUE_UsersUsername", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(35)]
    [Unicode(false)]
    public string UserFirstName { get; set; } = null!;

    [StringLength(35)]
    [Unicode(false)]
    public string? UserLastName { get; set; }

    [StringLength(9)]
    [Unicode(false)]
    public string UserUsername { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string UserPassword { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? UserToken { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string UserRole { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }

    [InverseProperty("ApprovalUser")]
    public virtual ICollection<Approval> Approvals { get; set; } = new List<Approval>();

    [InverseProperty("User")]
    public virtual ICollection<AssetUser> AssetUsers { get; set; } = new List<AssetUser>();

    [InverseProperty("User")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    [InverseProperty("User")]
    public virtual ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
}
