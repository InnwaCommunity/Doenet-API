using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TodoApi.Models
{
  public class CustomerResult
  {
    public int CustomerId { get; set; }
    public String CustomerName { get; set; } = string.Empty;
    public String CustomerAddress { get; set; } = string.Empty;
    public int? CustomerTypeId { get; set; }
    public String? CustomerTypeName { get; set; }
    public string CustomerPhoto { get; set; } = string.Empty;
  }
}