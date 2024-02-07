using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
  [Table("tbl_notification")]
  public class Notification : BaseModel
  {
    [Column("noti_id")]
    [Key]
    public int NotiId { get; set; }

    [Column("noti_description")]
    public string Description {get;set;} = string.Empty;


    [Column("noti_creator_id")]
    public int NotiCreatorId { get; set; }

    [Column("access_user_id")]
    public int AccessUserId { get; set; }

    [Column("detail_id")]
    public int DetailId {get;set;}

    [Column("is_seen")]
    public bool IsSeen {get;set;}

    [Column("is_sent")]
    public bool IsSent {get;set;}
    
    [Column("create_date")]
    public DateTime CreateDate { get; set; }
    
    [Column("noti_type")]
    public string NotiType {get;set;} = string.Empty;
  }
}