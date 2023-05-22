using FreightTransport.Domain;

namespace FreightTransport.Application.Features.Users.Queries
{
  public class UsersResponse
  {

    public long Id { get; set; }
    public string? IDUser { get; set; }
    public string? Contraseña { get; set; }
    public string? Descripcion { get; set; }
    public string? Observacion { get; set; }
    public string? Telefono { get; set; }
    public string? EMail { get; set; }
    public long? CompanyId { get; set; }    
    public int StateId { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int CreatedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public int LastModifiedBy { get; set; }

  }
}
