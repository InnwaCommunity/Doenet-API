using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
  [Table("tbl_customertype")]
  public partial class CustomerType
  {
    [Column("custype_id")]
    [Key]
    public int Id { get; set; }

    [Column("custype_name")]
    [MaxLength(50)]
    [Required]
    public string CustypeName { get; set; } = string.Empty;

  }
}