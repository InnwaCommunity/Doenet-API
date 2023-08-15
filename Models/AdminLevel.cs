
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
  [Table("tbl_adminlevel")]
  public partial class AdminLevel
  {
    [Column("adminlevel_id")]
    [Key]
    public int AdminLevelId { get; set; }

    [Column("adminlevel_name")]
    [MaxLength(50)]
    [Required]
    public string AdmLevName { get; set; } = string.Empty;

  }
}