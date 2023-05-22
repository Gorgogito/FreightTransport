using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;

namespace FreightTransport.App.Utility
{

  //
  // Resumen:
  //     Alignment of the content
  public enum Alignment
  {
    //
    NotSet = -1,
    //
    // Resumen:
    //     TopLeft
    TopLeft = 0,
    //
    // Resumen:
    //     TopCenter
    TopCenter = 1,
    //
    // Resumen:
    //     TopRight
    TopRight = 2,
    //
    // Resumen:
    //     MiddleLeft
    MiddleLeft = 3,
    //
    // Resumen:
    //     MiddleCenter
    MiddleCenter = 4,
    //
    // Resumen:
    //     MiddleRight
    MiddleRight = 5,
    //
    // Resumen:
    //     BottomLeft
    BottomLeft = 6,
    //
    // Resumen:
    //     BottomCenter
    BottomCenter = 7,
    //
    // Resumen:
    //     BottomRight
    BottomRight = 8
  }

  public class DataFind : IDisposable
  {

    [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);

    public void Alzheimer()
    {
      GC.Collect();
      GC.WaitForPendingFinalizers();
      SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
    }

    #region « DECLARACIÓN DE VARIABLES »

    FrmFilter formito;

    ResultRowDataEventArgs rr;

    #endregion

    #region « DECLARACIÓN DE EVENTOS »

    public event FrmFilter.EventResultRowData ResultRowData;

    #endregion

    #region « CONSTRUCTORES Y DESTRUCTORES »

    public DataFind()
    {
      formito = new FrmFilter();
      formito.ResultRowData += Filter_ResultRowData;
    }

    ~DataFind()
    {
      formito.ResultRowData -= Filter_ResultRowData;
      formito = null;
      rr = null;
      GC.Collect();
      GC.WaitForPendingFinalizers();
      SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
    }

    #endregion

    #region « PROCESOS PRIVADOS »

    private void Filter_ResultRowData(object sender, ResultRowDataEventArgs e)
    {
      ResultRowData?.Invoke(sender, e);
      rr = e;
    }

    public ResultRowDataEventArgs ShowFind()
    {
      formito.ShowDialog();
      formito.Dispose();
      return rr;
    }

    #endregion

    public void Size(int width, int height)
    {
      Width = width;
      Height = height;
    }

    #region « PROPIEDADES »

    public string Flag
    {
      get { return formito.Flag; }
      set { formito.Flag = value; }
    }

    public ColColumns Columns
    {
      get { return formito.Columns; }
    }

    public int Width
    {
      get { return formito.Width; }
      set { formito.Width = value; }
    }

    public int Height
    {
      get { return formito.Height; }
      set { formito.Height = value; }
    }

    public System.Drawing.Color GridBorderColorBottom
    {
      get { return formito.GridBorderColorBottom; }
      set { formito.GridBorderColorBottom = value; }
    }

    public System.Drawing.Color GridBorderColorTop
    {
      get { return formito.GridBorderColorTop; }
      set { formito.GridBorderColorTop = value; }
    }

    public System.Drawing.Color GridBorderColorLeft
    {
      get { return formito.GridBorderColorLeft; }
      set { formito.GridBorderColorLeft = value; }
    }

    public System.Drawing.Color GridBorderColorRight
    {
      get { return formito.GridBorderColorRight; }
      set { formito.GridBorderColorRight = value; }
    }

    public System.Drawing.Font TitleFont
    {
      get { return formito.TitleFont; }
      set { formito.TitleFont = value; }
    }

    public string TitleText
    {
      get { return formito.Text; }
      set { formito.Text = value; }
    }

    public System.Windows.Forms.FormStartPosition StartPosition
    {
      get { return formito.StartPosition; }
      set { formito.StartPosition = value; }
    }

    public bool TopMost
    {
      get { return formito.TopMost; }
      set { formito.TopMost = value; }
    }

    public void SetSource<T>(List<T> source) 
    {
      formito.SetSource(source);
    }

    #endregion

    #region IDisposable Support
    private bool disposedValue = false; // Para detectar llamadas redundantes

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          // TODO: elimine el estado administrado (objetos administrados).
          formito.ResultRowData -= Filter_ResultRowData;
          formito.Destroy();
          formito = null;
          rr = null;
        }

        // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
        // TODO: configure los campos grandes en nulos.

        disposedValue = true;
      }
    }

    // Este código se agrega para implementar correctamente el patrón descartable.
    public void Dispose()
    {
      // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
      Dispose(true);
      // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
      GC.SuppressFinalize(this);
    }
    #endregion

  }

  public class ColColumns
  {

    private System.Collections.ArrayList AlArray;

    public ColColumns()
    { AlArray = new System.Collections.ArrayList(); }

    public int Add(DevComponents.DotNetBar.SuperGrid.GridColumn value)
    { return AlArray.Add(value); }

    public void Create
    (string name, string headertext, int width, string datapropertyname, bool visible, Alignment alignment)
    {
      DevComponents.DotNetBar.SuperGrid.GridColumn col;
      col = new DevComponents.DotNetBar.SuperGrid.GridColumn
      {
        Name = name,
        HeaderText = headertext,
        Width = width,
        DataPropertyName = datapropertyname,
        Visible = visible
      };
      col.CellStyles.Default.Alignment = (DevComponents.DotNetBar.SuperGrid.Style.Alignment)alignment;
      AlArray.Add(col);
    }

    public void Clear()
    { AlArray.Clear(); }

    public void Insert(int index, DevComponents.DotNetBar.SuperGrid.GridColumn value)
    { AlArray.Insert(index, value); }

    public void Remove(DevComponents.DotNetBar.SuperGrid.GridColumn value)
    { AlArray.Remove(value); }

    public void RemoveAt(int index)
    { AlArray.RemoveAt(index); }

    public int Count
    { get { return AlArray.Count; } }

    public DevComponents.DotNetBar.SuperGrid.GridColumn this[int index]
    { get { return (DevComponents.DotNetBar.SuperGrid.GridColumn)AlArray[index]; } }

    public DevComponents.DotNetBar.SuperGrid.GridColumn CreateColums()
    {
      DevComponents.DotNetBar.SuperGrid.GridColumn col;
      col = new DevComponents.DotNetBar.SuperGrid.GridColumn();
      return col;
    }

  }


}
