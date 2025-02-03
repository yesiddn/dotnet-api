using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dotnet_api.Models;
public class Category
{
  public Guid Id { get; set; }

  public string Name { get; set; }

  public string Description { get; set; }

  public Difficulty Difficulty { get; set; }

  [JsonIgnore]
  public virtual ICollection<Task> Tasks { get; set; }
}

public enum Difficulty
{
  Easy,
  Medium,
  Hard
}