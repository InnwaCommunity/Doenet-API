using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
  [Table("tbl_admin")]
  public class Admin : BaseModel
  {
    [Column("admin_id")]
    [Key]
    public int AdminId { get; set; }

    [Required]
    [Column("admin_name")]
    [StringLength(50)]
    public string AdminName { get; set; } = string.Empty;

    [Column("admin_email")]
    [StringLength(100)]
    public string AdminEmail { get; set; } = string.Empty;

    [Required]
    [Column("login_name")]
    [StringLength(50)]
    public string LoginName { get; set; } = string.Empty;

    // public int LoginFailCount { get; set; }

    [Required]
    [Column("password")]
    public string Password { get; set; } = string.Empty;

    [Required]
    [Column("salt")]
    public string Salt { get; set; } = string.Empty;

    [Column("inactive")]
    public bool Inactive { get; set; }

    // public bool IsBlock { get; set; }
    // public DateTime CreateDate { get; set; }
    // public DateTime ModifiedDate { get; set; }

    // public DateTime? LastLoginDate { get; set; }

    [Column("customer_level_id")]
    public int? AdminLevelId { get; set; }

    [ForeignKey("AdminLevelId")]
    public AdminLevel? AdminLevel { get; set; }

    [Column("AdminPhoto")]
    public string AdminPhoto { get; set; } = string.Empty;

  }
}