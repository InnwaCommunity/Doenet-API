
namespace TodoApi.Models
{
  public class AdminResult
  {
    public int AdminId { get; set; }

    public string AdminName { get; set; } = string.Empty;

    public string AdminEmail { get; set; } = string.Empty;

    public string LoginName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public bool Inactive { get; set; }

    public int? AdminLevelId { get; set; }

    public String? AdminLevelName { get; set; }

    public string AdminPhoto { get; set; } = string.Empty;

  }
}