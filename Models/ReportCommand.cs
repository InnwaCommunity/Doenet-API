using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
  [Table("tbl_hc_report_command")]
  public class ReportCommand : BaseModel
  {
    [Column("command_id")]
    [Key]
    public int CommandId { get; set; }

    [Required]
    [Column("command_description")]
    public string CommandDescription { get; set; } = string.Empty;

    [Column("create_date")]
    public DateTime CreateDate {get;set;}

    [Column("use_report_id")]
    public int UseReportId{get;set;}

    [Column("commander_id")]
    public int CommanderId { get; set; }

  }
}