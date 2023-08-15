namespace TodoApi.Models
{
  public class Hero
  {
    public long HeroId { get; set; }
    public string HeroName { get; set; } = "";
    public string Address { get; set; } = "";
    public bool IsComplete { get; set; }
    public string? Secret { get; set; }
  }

  public class HeroDTO
  {
    public long HeroDTOId { get; set; }
    public string HeroDTOName { get; set; } = "";
    public string Address { get; set; } = "";
    public bool IsComplete { get; set; }
    public string? Secret { get; set; }
  }

}


