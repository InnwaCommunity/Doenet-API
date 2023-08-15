using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
  public class AdminRequest
  {
    [Key]
    public int AdminId { get; set; }

    [Required]
    [StringLength(50)]
    public string AdminName { get; set; } = string.Empty;

    [StringLength(100)]
    public string AdminEmail { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LoginName { get; set; } = string.Empty;

    // public int LoginFailCount { get; set; }

    [Required]
    public string Password { get; set; } = string.Empty;

    public bool Inactive { get; set; }

    // public bool IsBlock { get; set; }
    // public DateTime CreateDate { get; set; }
    // public DateTime ModifiedDate { get; set; }

    // public DateTime? LastLoginDate { get; set; }

    [Column("customer_level_id")]
    public int? AdminLevelId { get; set; }



    [Column("AdminPhoto")]
    public string AdminPhoto { get; set; } = string.Empty;

  }
}