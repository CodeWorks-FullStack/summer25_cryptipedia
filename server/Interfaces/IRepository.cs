namespace cryptipedia.Interfaces;

public interface IRepository<T>
{
  public T Create(T data);
  public List<T> GetAll();
  public T GetById(int id);
  public void Delete(int id);
  public void Update(T data);
}