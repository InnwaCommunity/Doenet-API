using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
  [Table("tbl_usereport")]
  public class UseReport : BaseModel
  {
    [Column("report_id")]
    [Key]
    public int ReportId { get; set; }

    [Required]
    [Column("report_description")]
    [StringLength(225)]
    public string ReportDescription { get; set; } = string.Empty;                     

    [Column("use_amount")]
    public int UseAmount { get; set; }

    [Column("category_id")]
    public int ClusterId {get;set;}

    [Column("member_id")]
    public int MemberId{get;set;}

    [Column("report_date")]
    public DateTime ReportDate { get; set; }
  }
}