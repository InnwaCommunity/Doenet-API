using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
  [Table("tbl_hc_category")]
  public class Category : BaseModel
  {
    [Column("category_id")]
    [Key]
    public int CategoryId { get; set; }

    [Required]
    [Column("category_name")]
    [StringLength(100)]
    public string CategoryName { get; set; } = string.Empty;

    [Column("cluster_id")]
    public int ClusterId {get;set;}

    [Column("total")]
    public int Total { get; set; }

    [Column("last_balance")]
    public int LastBalance { get; set; }

    [Column("start_date")]
    public DateTime? StartDate { get; set; }
    [Column("end_date")]
    public DateTime? EndDate { get; set; }
  }
}