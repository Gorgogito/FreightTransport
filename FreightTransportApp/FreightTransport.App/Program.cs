using FreightTransport.ApplicationCore.Infrastructure.Persistence;
using System.Windows.Forms;
using System.IO;
using System;

namespace FreightTransport.App
{
  static class Program
  {
    /// <summary>
    /// Punto de entrada principal para la aplicación.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      using (StreamReader jsonStream = File.OpenText(AppDomain.CurrentDomain.BaseDirectory + "/Profile.json"))
      {
        var json = jsonStream.ReadToEnd();
        ApiContext.SetApiContext(json);
      }
      Application.Run(new FrmMDI());
    }
  }
}
