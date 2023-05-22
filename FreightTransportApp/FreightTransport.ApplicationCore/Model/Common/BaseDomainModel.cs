using System;

namespace FreightTransport.ApplicationCore.Model.Common
{

  public abstract class BaseDomainModel
  {
    public long Id { get; set; }
    public int StateId { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CreatedBy { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public int LastModifiedBy { get; set; }
  }

}
