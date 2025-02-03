using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_api.Models;


public class Task
{
  public Guid Id { get; set; }

  public Guid CategoryId { get; set; }

  public string Title { get; set; }

  public string Description { get; set; }

  public bool IsComplete { get; set; }

  public Priority Priority { get; set; }

  public DateTime CreatedAt { get; set; }

  public virtual Category Category { get; set; }

  public string Resume { get; set; }
}

public enum Priority
{
  Low,
  Medium,
  High
}