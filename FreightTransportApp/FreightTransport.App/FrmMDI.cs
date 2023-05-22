namespace FreightTransport.App
{
  public partial class FrmMDI : DevComponents.DotNetBar.Metro.MetroAppForm
  {
    public FrmMDI()
    {
      InitializeComponent();
    }

    private void FrmMDI_Load(object sender, System.EventArgs e)
    {
      FrmLogin FLogin = new FrmLogin();
      FLogin.ShowDialog();
    }
  }
}
