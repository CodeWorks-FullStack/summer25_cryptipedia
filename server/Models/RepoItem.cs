namespace cryptipedia.Models;

// abstract denotes that this class can only be inherited from, and never instantiated on its own
public abstract class RepoItem<T>
{
  public T Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}