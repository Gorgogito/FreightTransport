using FreightTransport.ApplicationCore.Model.Common;
using System.Collections.Generic;

namespace FreightTransport.ApplicationCore
{
  public interface IControllerBase<T> where T : BaseDomainModel
  {
    List<T> GetAll();

    List<T> GetByCode(long code);

    void AddEntity(T entity);

    void UpdateEntity(T entity);

    void DeleteEntity(T entity);
  }
}
