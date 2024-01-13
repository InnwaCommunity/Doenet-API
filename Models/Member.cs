using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
  [Table("tbl_member")]
  public class Member : BaseModel
  {
    [Column("member_id")]
    [Key]
    public int MemberId { get; set; }

    [Column("user_id")]
    public int UserId {get;set;}//id that possess

    [Column("cluster_id")]
    public int ClusterId {get;set;}

    [Column("admin")]
    public bool Admin {get;set;}

    [Column("commander")]
    public bool Commander {get;set;}
    [Column("viewer")]
    public bool Viewer{get;set;}

    [Column("employee")]
    public bool Employee {get;set;}

    [Column("inactive")]
    public bool Inactive { get; set; }
  }
}