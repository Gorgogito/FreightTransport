namespace FreightTransport.Application.Features.Companies.Queries
{
  public class CompaniesResponse
  {

    public long Id { get; set; }
    public string? Ruc { get; set; }
    public string? Descripcion { get; set; }
    public string? Observacion { get; set; }
    public string? Direccion { get; set; }
    public string? Representante { get; set; }
    public string? Telefono { get; set; }
    public string? EMail { get; set; }
    public string? Web { get; set; }
    public int StateId { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int CreatedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public int LastModifiedBy { get; set; }

  }


}
