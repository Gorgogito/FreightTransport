using FreightTransport.App.Utility;
using FreightTransport.ApplicationCore.Business;
using FreightTransport.ApplicationCore.Infrastructure.Persistence.Contexts;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FreightTransport.App
{
  public partial class FrmLogin : DevComponents.DotNetBar.Metro.MetroForm
  {

    #region « VARIABLES INTERNAS »

    private DataFind ObjFind;

    CompanyContext companyContext = new CompanyContext();
    UserContext userContext = new UserContext();

    BusinessCompany businessCompany;
    BusinessUser businessUser;

    #endregion

    #region « FORMULARIO »

    public FrmLogin()
    {
      InitializeComponent();

      businessCompany = new BusinessCompany(companyContext);
      businessUser = new BusinessUser(userContext);
    }

    private void FrmLogin_Shown(object sender, System.EventArgs e)
    {
      TxtCUsuario.BackColor = Color.FromArgb(45, 45, 48);
      TxtContraseña.BackColor = Color.FromArgb(45, 45, 48);
      TxtCEmpresa.BackColor = Color.FromArgb(45, 45, 48);
      TxtDEmpresa.BackColor = Color.FromArgb(45, 45, 48);
      TxtCEmpresa.Focus();
    }

    #endregion

    #region « EVENTOS DE TEXTBOX »

    #region « Empresa »

    private void TxtCEmpresa_ButtonCustomClick(object sender, System.EventArgs e)
    {
      ObjFind = new DataFind();
      ObjFind.ResultRowData += ObjFind_ResultRowData;
      var data = (from ent in businessCompany.GetAll() select new { ent.Id, ent.Ruc, ent.Descripcion }).ToList();
      ObjFind.SetSource(data);

      DevComponents.DotNetBar.SuperGrid.GridColumn c;
      ObjFind.Columns.Add(new DevComponents.DotNetBar.SuperGrid.GridColumn
      { Name = "Codigo", HeaderText = "CODIGO", Width = 60, DataPropertyName = "Id", Visible = true });

      ObjFind.Columns.Add(new DevComponents.DotNetBar.SuperGrid.GridColumn
      { Name = "Ruc", HeaderText = "R.U.C.", Width = 120, DataPropertyName = "Ruc", Visible = true });

      ObjFind.Columns.Add(new DevComponents.DotNetBar.SuperGrid.GridColumn
      { Name = "Descripcion", HeaderText = "DESCRIPCIÓN", Width = 300, DataPropertyName = "Descripcion", Visible = true });

      ObjFind.Width = 550;
      ObjFind.Height = 250;
      ObjFind.Flag = "Empresa";
      ObjFind.TitleText = "Filtrar Empresa";
      ObjFind.ShowFind();
    }

    private void TxtCEmpresa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
      if (e.KeyCode == System.Windows.Forms.Keys.F1) { TxtCEmpresa_ButtonCustomClick(sender, e); }
    }

    private void TxtCEmpresa_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (DoCmd.Strings.InStr(1, "0123456789"
                              + DoCmd.Strings.Chr((int)System.Windows.Forms.Keys.Delete)
                              + DoCmd.Strings.Chr((int)System.Windows.Forms.Keys.Enter)
                              + DoCmd.Strings.Chr((int)System.Windows.Forms.Keys.Back), e.KeyChar.ToString(), CompareMethod.Text) == 0)
      { e.Handled = true; }
      if (e.KeyChar == DoCmd.Strings.Chr((int)Keys.Enter))
      {
        if (TxtCEmpresa.Text == string.Empty)
        { TxtCEmpresa_ButtonCustomClick(sender, e); }
        else
        { TxtCUsuario.Select(); }
      }
    }

    private void TxtCEmpresa_Leave(object sender, EventArgs e)
    {
      if (TxtCEmpresa.Text == string.Empty) { return; }

      var data = (from ent in businessCompany.GetByCode((long)Convert.ToUInt64(TxtCEmpresa.Text))
                  select new { ent.Id, ent.Ruc, ent.Descripcion }).ToList();

      if (data.Count == 0)
      {

        DevComponents.DotNetBar.MessageBoxEx.Show(
        "Ingrese el codigo correcto", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

        TxtCEmpresa.Select();
      }
    }

    private void TxtCEmpresa_TextChanged(object sender, EventArgs e)
    {
      if (TxtCEmpresa.Text == string.Empty)
      {
        TxtDEmpresa.Text = string.Empty;
        return;
      }

      var data = (from ent in businessCompany.GetByCode((long)Convert.ToUInt64(TxtCEmpresa.Text))
                  select new { ent.Id, ent.Ruc, ent.Descripcion }).ToList();

      if (data.Count > 0)
      { TxtDEmpresa.Text = data[00].Descripcion; }
      else
      { TxtDEmpresa.Text = string.Empty; }
    }

    #endregion

    #region « Usuario »

    private void TxtCUsuario_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      if (e.KeyChar == DoCmd.Strings.Chr((int)Keys.Enter))
      {
        var data = (from ent in businessUser.GetAll()
                    where DoCmd.Strings.UCase(ent.IDUser) == DoCmd.Strings.UCase(TxtCUsuario.Text)
                    select new { ent.Id, ent.Descripcion }).ToList();

        if (data.Count > 0) { LblDUsuario.Text = data[0].Descripcion; }
        else { LblDUsuario.Text = string.Empty; }
        TxtContraseña.Select();
      }
    }

    private void TxtCUsuario_Leave(object sender, System.EventArgs e)
    {
      if (TxtCUsuario.Text == string.Empty) { return; }

      var data = (from ent in businessUser.GetAll()
                  where DoCmd.Strings.UCase(ent.IDUser) == DoCmd.Strings.UCase(TxtCUsuario.Text)
                  select new { ent.Id, ent.Descripcion }).ToList();

      if (data.Count == 0)
      {

        DevComponents.DotNetBar.MessageBoxEx.Show(
          "Usuario no existe.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

        TxtCUsuario.Select();

      }
      else
      { LblDUsuario.Text = data[0].Descripcion; }
    }

    private void TxtContraseña_Enter(object sender, System.EventArgs e)
    {
      TxtContraseña.SelectAll();
    }

    private void TxtContraseña_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      if (e.KeyChar == DoCmd.Strings.Chr((int)Keys.Enter))
      {
        BtAceptar.Select();
        BtAceptar_Click(BtAceptar, e);
      }
    }

    #endregion

    #endregion

    #region « RESULTADO DE LA BUSQUEDA »

    private void ObjFind_ResultRowData(object sender, ResultRowDataEventArgs e)
    {
      if (e.Rows is null) { return; }
      if (e.Rows.Count == 0) { return; }
      if (e.Rows[0].FieldsCount == 0) { return; }
      if (e.Flag == "Empresa")
      {
        if (e.Rows[0].ResultField[0].Value.ToString() == string.Empty) { return; }
        TxtCEmpresa.Text = e.Rows[0].ResultField[0].Value.ToString();
        TxtDEmpresa.Text = e.Rows[0].ResultField[2].Value.ToString();
      }
    }

    #endregion

    #region « EVENTOS DE BOTONES »

    private void BtCancelar_Click(object sender, System.EventArgs e)
    {
      this.Close();
      Application.Exit();
    }

    private void BtAceptar_Click(object sender, System.EventArgs e)
    {
      if (TxtCEmpresa.Text == string.Empty)
      {
        DevComponents.DotNetBar.MessageBoxEx.Show(
        "Ingrese empresa", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
      }

      if (TxtCUsuario.Text == string.Empty)
      {
        DevComponents.DotNetBar.MessageBoxEx.Show(
        "Ingrese usuario", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
      }

      var data = (from ent in businessUser.GetAll()
                  where DoCmd.Strings.UCase(ent.IDUser) == DoCmd.Strings.UCase(TxtCUsuario.Text)
                  select new { ent.Id, ent.Descripcion, ent.Contraseña }).ToList();

      if (data.Count > 0)
      {

        if (DoCmd.Strings.UCase(data[00].Contraseña) == DoCmd.Strings.UCase(TxtContraseña.Text))
        {
          this.Close();
        }
        else
        {
          DevComponents.DotNetBar.MessageBoxEx.Show(
            "Contraseña incorrecta.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
          TxtContraseña.Select();
        }
      }
      else
      {
        DevComponents.DotNetBar.MessageBoxEx.Show(
          "Usuario no existe.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
        TxtCUsuario.Select();
      }
    }

    #endregion

  }
}
