namespace FreightTransport.ApplicationCore.Infrastructure.Persistence
{
  public interface IContext
  {

    string GetAll();

    string GetByCode(long code);

    void AddEntity(string request);

    void UpdateEntity(string request);

    void DeleteEntity(string request);

  }
}
