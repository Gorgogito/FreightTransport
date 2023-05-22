using System.IO;
using System.Net;

namespace FreightTransport.ApplicationCore.Infrastructure.Persistence.Contexts
{
  public class UserContext : IContext
  {

    public string GetAll()
    {

      var method = $"/User/GetAll";
      var request = (HttpWebRequest)WebRequest.Create(ApiContext.GetProfile.Url + method);
      request.Method = "GET";
      request.ContentType = "application/json";
      request.Accept = "application/json";

      try
      {
        using (WebResponse response = request.GetResponse())
        {
          using (Stream strReader = response.GetResponseStream())
          {
            if (strReader == null) return string.Empty;
            using (StreamReader objReader = new StreamReader(strReader))
            {
              string responseBody = objReader.ReadToEnd();
              // Do something with responseBody
              return responseBody;
            }
          }
        }
      }
      catch (WebException ex)
      {
        // Handle error
        return string.Empty;
      }

    }

    public string GetByCode(long code)
    {
      var method = $"/User/GetCode/" + code.ToString();
      var request = (HttpWebRequest)WebRequest.Create(ApiContext.GetProfile.Url + method);
      request.Method = "GET";
      request.ContentType = "application/json";
      request.Accept = "application/json";

      try
      {
        using (WebResponse response = request.GetResponse())
        {
          using (Stream strReader = response.GetResponseStream())
          {
            if (strReader == null) return string.Empty;
            using (StreamReader objReader = new StreamReader(strReader))
            {
              string responseBody = objReader.ReadToEnd();
              // Do something with responseBody
              return responseBody;
            }
          }
        }
      }
      catch (WebException ex)
      {
        // Handle error
        return string.Empty;
      }

    }

    public void AddEntity(string request)
    {
      throw new System.NotImplementedException();
    }

    public void DeleteEntity(string request)
    {
      throw new System.NotImplementedException();
    }

    public void UpdateEntity(string request)
    {
      throw new System.NotImplementedException();
    }

  }
}
