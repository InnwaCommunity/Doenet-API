using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TodoApi.Models
{
  [Table("tbl_hc_admin")]
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

    [Column("user_id")]
    public int UserId{get;set;}
    
    [Column("login_fail_count")]
    public int LoginFailCount { get; set; }//default 0

    [Required]
    [Column("password")]
    [StringLength(50)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [Column("salt")]
    [StringLength(50)]
    public string Salt { get; set; } = string.Empty;

    [Column("inactive")]
    public bool Inactive { get; set; }

    [Column("isblock")]
    public bool IsBlock { get; set; }

    [Column("createdate")]
    public DateTime CreateDate { get; set; }
    // public DateTime ModifiedDate { get; set; }

    // public DateTime? LastLoginDate { get; set; }

    [Column("admin_level_id")]
    public int? AdminLevelId { get; set; }

    [ForeignKey("AdminLevelId")]
    public AdminLevel? AdminLevel { get; set; }

    [Column("admin_photo")]
    public string AdminPhoto { get; set; } = string.Empty;

  }
}