using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
  [Table("tbl_hc_invite_member")]
  public class InviteMember : BaseModel
  {
    [Column("invite_id")]
    [Key]
    public int InviteId { get; set; }

    [Column("cluster_id")]
    public int ClusterId {get;set;}

    [Column("requester_id")]
    public int RequesterId { get; set; }

    [Column("approver_id")]
    public int ApproverId { get; set; }

    [Column("position")]
    public string Position { get; set; } = string.Empty;

    [Column("access")]
    public bool Access {get;set;}

    [Column("reject")]
    public bool Reject {get;set;}
    
    [Column("create_date")]
    public DateTime CreateDate { get; set; }
  }
}