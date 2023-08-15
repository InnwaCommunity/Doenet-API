using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
  public class CustomerRequest
  {
    public int CustomerId { get; set; }
    [Required]
    [StringLength(50)]
    public String CustomerName { get; set; } = string.Empty;
    [StringLength(100)]
    public String CustomerAddress { get; set; } = string.Empty;
    public int? CustomerTypeId { get; set; }
    public String? CustomerTypeName { get; set; }
    public string CustomerPhoto { get; set; } = string.Empty;
  }
}