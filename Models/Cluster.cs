using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
  [Table("tbl_cluster")]
  public class Cluster : BaseModel
  {
    [Column("cluster_id")]
    [Key]
    public int ClusterId { get; set; }

    [Required]
    [Column("cluster_name")]
    [StringLength(100)]
    public string ClusterName { get; set; } = string.Empty;

    [Column("ispassword_use")]
    public bool IsPasswordUse{get;set;}

    [Column("password")]
    public string Password { get; set; } = string.Empty;
    [Column("salt")]
    public string Salt { get; set; } = string.Empty;

    [Column("inactive")]
    public bool Inactive { get; set; }

    [Column("cluster_create_date")]
    public DateTime CreateDate { get; set; }

    [Column("cluster_modifie_date")]
    public DateTime ModifiedDate { get; set; }

  }
}