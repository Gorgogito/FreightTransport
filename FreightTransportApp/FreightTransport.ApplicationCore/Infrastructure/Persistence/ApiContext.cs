using Newtonsoft.Json;

namespace FreightTransport.ApplicationCore.Infrastructure.Persistence
{
  public static class ApiContext
  {

    public static UseProfile GetProfile { get; set; }

    public static void SetApiContext(string json)
    { GetProfile = JsonConvert.DeserializeObject<UseProfile>(json); }

   }

  public class UseProfile
  {
    public string Url { get; set; }
  }

}
