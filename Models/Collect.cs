using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TodoApi.Models
{
  [Table("tbl_hc_collect")]
  public class Collect : BaseModel
  {
    [Column("collect_id")]
    [Key]
    public int CollectId { get; set; }

    [Column("collect_description")]
    [StringLength(225)]
    public string CollectDescription {get;set;} = string.Empty;

    
    [Column("owner_id")] //user that possess
    public int OwnerId{get;set;}

    
    [Column("poster_id")]//poster that report this collect
    public int PosterId{get;set;}

    [Column("collect_value")]
    public int CollectValue { get; set; }

    [Column("category_id")]
    public int CategoryId {get;set;}

    // [Column("cluster_id")]
    // public int ClusterId {get;set;}

    [Column("collect_create_date")]
    public DateTime CreateDate {get;set;}

    [Column("modified_date")]
    public DateTime ModifiedDate {get;set;}

    
    [Column("command_count")]
    public int Count { get; set; }
  }
}