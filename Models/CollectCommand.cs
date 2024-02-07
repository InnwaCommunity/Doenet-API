using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
  [Table("tbl_hc_collect_command")]
  public class CollectCommand : BaseModel
  {
    [Column("command_id")]
    [Key]
    public int CommandId { get; set; }

    [Required]
    [Column("command_description")]
    public string CommandDescription { get; set; } = string.Empty;

    [Column("create_date")]
    public DateTime CreateDate {get;set;}

    [Column("collect_id")]
    public int UseReportId{get;set;}

    [Column("commander_id")]
    public int CommanderId { get; set; }

  }
}