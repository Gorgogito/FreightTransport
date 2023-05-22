using FreightTransport.Domain.Common;

namespace FreightTransport.Domain
{
  public class User : BaseDomainModel
  {

    public User() { }

    public string? IDUser { get; set; }
    public string? Contraseña { get; set; }
    public string? Descripcion { get; set; }
    public string? Observacion { get; set; }
    public string? Telefono { get; set; }
    public string? EMail { get; set; }
    public long? CompanyId { get; set; }
    public virtual Company? Company { get; set; }

  }
}
