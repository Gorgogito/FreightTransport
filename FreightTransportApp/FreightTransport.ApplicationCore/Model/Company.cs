using FreightTransport.ApplicationCore.Model.Common;

namespace FreightTransport.ApplicationCore.Model
{
  public class Company : BaseDomainModel
  {

    public Company() { }

    public string Ruc { get; set; }
    public string Descripcion { get; set; }
    public string Observacion { get; set; }
    public string Direccion { get; set; }
    public string Representante { get; set; }
    public string Telefono { get; set; }
    public string EMail { get; set; }
    public string Web { get; set; }    

  }
}
