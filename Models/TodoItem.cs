namespace TodoApi.Models
{
  public class TodoItem
  {
    public long TodoItemId { get; set; }
    public string TodoItemName { get; set; } = "";
    public string Address { get; set; } = "";
    public bool IsComplete { get; set; }
    public string? Secret { get; set; }
  }
}
namespace TodoApi.Models
{
  public class TodoItemDTO
  {
    public long TodoItemDTOId { get; set; }
    public string TodoItemDTOName { get; set; } = "";
    public string Address { get; set; } = "";
    public bool IsComplete { get; set; }
    public string? Secret { get; set; }
  }
}