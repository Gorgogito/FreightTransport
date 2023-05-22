using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FreightTransport.App.Utility
{
  public partial class FrmFilter : DevComponents.DotNetBar.Metro.MetroForm
  {

    #region « DECLARACIÓN DE VARIABLES »

    private Font FntFont;
    private IList<DevComponents.DotNetBar.SuperGrid.GridRow> rRows;
    private ColColumns columns;

    protected int RowIndex = -1;
    protected int ColIndex;

    private BindingSource BsData;
    private IContainer components;
    
    private string stringFind = string.Empty;
    private DataTable dt;
    internal DevComponents.DotNetBar.Validator.Highlighter hMantenimiento;
    internal DevComponents.DotNetBar.Validator.Highlighter hCode;
    private BindingNavigatorEx BnData;    
    private DevComponents.DotNetBar.ButtonItem bindingNavigatorAddNewItem;
    private DevComponents.DotNetBar.LabelItem bindingNavigatorCountItem;
    private DevComponents.DotNetBar.ButtonItem bindingNavigatorDeleteItem;
    private DevComponents.DotNetBar.ButtonItem bindingNavigatorMoveFirstItem;
    private DevComponents.DotNetBar.ButtonItem bindingNavigatorMovePreviousItem;
    private DevComponents.DotNetBar.TextBoxItem bindingNavigatorPositionItem;
    private DevComponents.DotNetBar.ButtonItem bindingNavigatorMoveNextItem;
    private DevComponents.DotNetBar.SuperGrid.SuperGridControl SgcData;
    private Label label1;
    private DevComponents.DotNetBar.ButtonItem bindingNavigatorMoveLastItem;
    #endregion

    #region « DECLARACIÓN DE DELEGADOS Y EVENTOS »

    public delegate void EventResultRowData(object sender, ResultRowDataEventArgs e);
    public event EventResultRowData ResultRowData;

    #endregion

    #region « PROPIEDADES »

    public string Flag { get; set; }

    public ColColumns Columns
    {
      get { return columns; }
    }

    public System.Drawing.Color GridBorderColorBottom
    {
      get { return SgcData.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor.Bottom; }
      set { SgcData.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor.Bottom = value; }
    }

    public System.Drawing.Color GridBorderColorTop
    {
      get { return SgcData.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor.Top; }
      set { SgcData.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor.Top = value; }
    }

    public System.Drawing.Color GridBorderColorLeft
    {
      get { return SgcData.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor.Left; }
      set { SgcData.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor.Left = value; }
    }

    public System.Drawing.Color GridBorderColorRight
    {
      get { return SgcData.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor.Right; }
      set { SgcData.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor.Right = value; }
    }

    public Font TitleFont
    {
      get { return this.CaptionFont; }
      set { this.CaptionFont = value; }
    }

    public System.Drawing.Color BackColorIni
    {
      get { return this.BackColor; }
      set { this.BackColor = value; }
    }

    private object Source{ get; set; }

    public void SetSource<T>(List<T> source) 
    {
      Source = source;
    }

    #endregion

    #region « CONSTRUCTORES Y DESTRUCTORES »

    public FrmFilter()
    {
      InitializeComponent();
      rRows = new List<DevComponents.DotNetBar.SuperGrid.GridRow>();
      columns = new ColColumns();
    }

    #region IDisposable Support

    protected virtual void Destroy(bool disposing)
    {
      if (disposing)
      {
        columns = null;
        rRows = null;
        dt.Dispose();
        dt = null;
        BsData.Dispose();
        BsData = null;
        components.Dispose();
        components = null;
        BnData.Dispose();
        BnData = null;
        bindingNavigatorAddNewItem.Dispose();
        bindingNavigatorAddNewItem = null;
        bindingNavigatorCountItem.Dispose();
        bindingNavigatorCountItem = null;
        bindingNavigatorDeleteItem.Dispose();
        bindingNavigatorDeleteItem = null;
        bindingNavigatorMoveFirstItem.Dispose();
        bindingNavigatorMoveFirstItem = null;
        bindingNavigatorMovePreviousItem.Dispose();
        bindingNavigatorMovePreviousItem = null;
        bindingNavigatorPositionItem.Dispose();
        bindingNavigatorPositionItem = null;
        bindingNavigatorMoveNextItem.Dispose();
        bindingNavigatorMoveNextItem = null;
        bindingNavigatorMoveLastItem.Dispose();
        bindingNavigatorMoveLastItem = null;
        label1.Dispose();
        label1 = null;
        SgcData.PrimaryGrid.Columns.Clear();
        SgcData.PrimaryGrid.Rows.Clear();
        SgcData.Dispose();
        SgcData = null;
      }
    }

    public void Destroy()
    {
      Destroy(true);
      GC.SuppressFinalize(this);
    }
    #endregion

    ~FrmFilter()
    {
      Destroy(false);
    }

    #endregion

    #region « PROCESOS PRIVADOS »
    
    protected virtual void OnEventResultRowData()
    {
      try
      {
        if (rRows.Count == 0) { return; }
        if (SgcData.PrimaryGrid.Rows.Count > 0)
        {
          EventResultRowData tmp = ResultRowData;
          if (tmp != null)
          {
            ResultRowDataEventArgs ee;
            ee = new ResultRowDataEventArgs
            {
              Flag = Flag
            };
            for (int F = 0; F < rRows.Count; F++)
            {
              ResultRow rr;
              rr = new ResultRow
              {
                IndexRow = RowIndex,
                FieldsCount = SgcData.PrimaryGrid.Columns.Count - 1
              };
              int numberColIni = 0;
              numberColIni = 0;
              for (int C = numberColIni; C < SgcData.PrimaryGrid.Columns.Count; C++)
              {
                ResultField cc;
                cc = new ResultField
                {
                  FieldName = SgcData.PrimaryGrid.Columns[C].DataPropertyName,
                  HeardText = SgcData.PrimaryGrid.Columns[C].HeaderText,
                  IndexField = C,
                  Value = SgcData.PrimaryGrid.GetCell(RowIndex, C).Value.ToString()
                };
                rr.ResultField.Add(cc);
              }
              ee.Rows.Add(rr);
            }
            tmp(this, ee);
          }
          this.Visible = false;
        }
      }
      catch (Exception ex)
      { System.Windows.Forms.MessageBox.Show(ex.Message + ex.Source); }
    }

    private void LoadData() 
    {
      try
      {
        this.Enabled = false;
        SgcData.PrimaryGrid.Columns.Clear();
        for (int B = 0; B < Columns.Count; B++)
        {
          DevComponents.DotNetBar.SuperGrid.GridColumn col;
          col = Columns[B];
          SgcData.PrimaryGrid.Columns.Add(col);
        }

        BsData.DataSource = Source;

        SgcData.PerformLayout();
        BnData.BindingSource = BsData;
        SgcData.PrimaryGrid.DataSource = BsData;
      }
      catch (Exception ex)
      { System.Windows.Forms.MessageBox.Show(ex.Message); }
      finally
      { this.Enabled = true; }
    }

    private void Seleccionar()
    {
      if (SgcData.PrimaryGrid.Rows.Count > 0)
      {
        if (RowIndex != -1)
        {
          rRows.Add((DevComponents.DotNetBar.SuperGrid.GridRow)SgcData.PrimaryGrid.Rows[RowIndex]);
          OnEventResultRowData();
          this.Close();
        }
      }
    }

    #endregion

    #region « EVENTOS DE FORMULARIO »

    private void FrmFilter_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData == System.Windows.Forms.Keys.Escape)
      { OnEventResultRowData(); }
    }

    private void FrmFilter_Shown(object sender, EventArgs e)
    {
      LoadData();
      for (int Z = 0; Z < columns.Count; Z++)
      { columns[Z].Name = "col" + Z.ToString(); }
      BnData.Top = 3;
      BnData.Left = 3;
      BnData.Width = this.Width - 22;
      BnData.Height = 40;
    }

    private void FrmFilter_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == System.Windows.Forms.Keys.Cancel || e.KeyCode == System.Windows.Forms.Keys.Escape)
      { this.Close(); }
    }

    #endregion

    #region « EVENTOS DE GRILLA »

    private void SgcData_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == System.Windows.Forms.Keys.Enter)
      { Seleccionar(); }
    }

    private void SgcData_CellDoubleClick(object sender, DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs e)
    { Seleccionar(); }

    private void SgcData_CellActivated(object sender, DevComponents.DotNetBar.SuperGrid.GridCellActivatedEventArgs e)
    {
      RowIndex = e.NewActiveCell.RowIndex;
      ColIndex = e.NewActiveCell.ColumnIndex;
    }

    private void SgcData_RowActivated(object sender, DevComponents.DotNetBar.SuperGrid.GridRowActivatedEventArgs e)
    {
      if (e.NewActiveRow != null) { RowIndex = e.NewActiveRow.RowIndex; }
    }

    #endregion

    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
      DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
      DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFilter));
      this.BsData = new System.Windows.Forms.BindingSource(this.components);
      this.hMantenimiento = new DevComponents.DotNetBar.Validator.Highlighter();
      this.SgcData = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
      this.hCode = new DevComponents.DotNetBar.Validator.Highlighter();
      this.BnData = new DevComponents.DotNetBar.Controls.BindingNavigatorEx(this.components);
      this.bindingNavigatorAddNewItem = new DevComponents.DotNetBar.ButtonItem();
      this.bindingNavigatorCountItem = new DevComponents.DotNetBar.LabelItem();
      this.bindingNavigatorDeleteItem = new DevComponents.DotNetBar.ButtonItem();
      this.bindingNavigatorMoveFirstItem = new DevComponents.DotNetBar.ButtonItem();
      this.bindingNavigatorMovePreviousItem = new DevComponents.DotNetBar.ButtonItem();
      this.bindingNavigatorPositionItem = new DevComponents.DotNetBar.TextBoxItem();
      this.bindingNavigatorMoveNextItem = new DevComponents.DotNetBar.ButtonItem();
      this.bindingNavigatorMoveLastItem = new DevComponents.DotNetBar.ButtonItem();
      this.label1 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.BsData)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BnData)).BeginInit();
      this.SuspendLayout();
      // 
      // hMantenimiento
      // 
      this.hMantenimiento.ContainerControl = this;
      this.hMantenimiento.CustomHighlightColors = new System.Drawing.Color[] {
        System.Drawing.Color.Gainsboro,
        System.Drawing.Color.MidnightBlue,
        System.Drawing.Color.Transparent};
      this.hMantenimiento.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Custom;
      // 
      // SgcData
      // 
      this.SgcData.BackColor = System.Drawing.Color.Gainsboro;
      this.SgcData.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SgcData.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
      this.SgcData.Font = new System.Drawing.Font("Arial", 10F);
      this.SgcData.ForeColor = System.Drawing.Color.Black;
      this.hMantenimiento.SetHighlightOnFocus(this.SgcData, true);
      this.SgcData.Location = new System.Drawing.Point(3, 33);
      this.SgcData.Name = "SgcData";
      // 
      // 
      // 
      this.SgcData.PrimaryGrid.AllowEdit = false;
      this.SgcData.PrimaryGrid.DefaultRowHeight = 30;
      this.SgcData.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Arial", 10F);
      this.SgcData.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Arial", 10F);
      background1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
      this.SgcData.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background = background1;
      this.SgcData.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Font = new System.Drawing.Font("Arial", 10F);
      this.SgcData.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.TextColor = System.Drawing.Color.Black;
      background2.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
      this.SgcData.PrimaryGrid.DefaultVisualStyles.FilterRowStyles.Default.FilterBackground = background2;
      this.SgcData.PrimaryGrid.DefaultVisualStyles.FilterRowStyles.Default.RowHeader.TextColor = System.Drawing.Color.Black;
      this.SgcData.PrimaryGrid.DefaultVisualStyles.FilterRowStyles.Selected.RowHeader.TextColor = System.Drawing.Color.Black;
      borderColor1.Bottom = System.Drawing.Color.DarkGreen;
      borderColor1.Left = System.Drawing.Color.DarkGreen;
      borderColor1.Right = System.Drawing.Color.DarkGreen;
      borderColor1.Top = System.Drawing.Color.DarkGreen;
      this.SgcData.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor = borderColor1;
      this.SgcData.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.HeaderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.SgcData.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.HorizontalLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.SgcData.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.VerticalLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.SgcData.PrimaryGrid.EnableColumnFiltering = true;
      this.SgcData.PrimaryGrid.EnableFiltering = true;
      this.SgcData.PrimaryGrid.EnableRowFiltering = true;
      // 
      // 
      // 
      this.SgcData.PrimaryGrid.Filter.ShowPanelFilterExpr = true;
      this.SgcData.PrimaryGrid.Filter.Visible = true;
      this.SgcData.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.Row;
      this.SgcData.PrimaryGrid.MinRowHeight = 30;
      this.SgcData.PrimaryGrid.RowWhitespaceClickBehavior = DevComponents.DotNetBar.SuperGrid.RowWhitespaceClickBehavior.None;
      this.SgcData.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.RowWithCellHighlight;
      this.SgcData.PrimaryGrid.VirtualRowHeight = 30;
      this.SgcData.PrimaryGrid.WhitespaceClickBehavior = DevComponents.DotNetBar.SuperGrid.WhitespaceClickBehavior.None;
      this.SgcData.Size = new System.Drawing.Size(598, 436);
      this.SgcData.TabIndex = 7;
      this.SgcData.Text = "superGridControl1";
      this.SgcData.CellActivated += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellActivatedEventArgs>(this.SgcData_CellActivated);
      this.SgcData.CellDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs>(this.SgcData_CellDoubleClick);
      this.SgcData.RowActivated += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowActivatedEventArgs>(this.SgcData_RowActivated);
      this.SgcData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SgcData_KeyDown);
      // 
      // hCode
      // 
      this.hCode.ContainerControl = this;
      this.hCode.CustomHighlightColors = new System.Drawing.Color[] {
        System.Drawing.Color.Transparent,
        System.Drawing.Color.PowderBlue,
        System.Drawing.Color.Green};
      this.hCode.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Custom;
      // 
      // BnData
      // 
      this.BnData.AddNewRecordButton = this.bindingNavigatorAddNewItem;
      this.BnData.AntiAlias = true;
      this.BnData.CountLabel = this.bindingNavigatorCountItem;
      this.BnData.CountLabelFormat = "de {0}";
      this.BnData.DeleteButton = this.bindingNavigatorDeleteItem;
      this.BnData.Dock = System.Windows.Forms.DockStyle.Top;
      this.BnData.Font = new System.Drawing.Font("Arial", 10F);
      this.BnData.IsMaximized = false;
      this.BnData.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
      this.BnData.Location = new System.Drawing.Point(3, 3);
      this.BnData.MoveFirstButton = this.bindingNavigatorMoveFirstItem;
      this.BnData.MoveLastButton = this.bindingNavigatorMoveLastItem;
      this.BnData.MoveNextButton = this.bindingNavigatorMoveNextItem;
      this.BnData.MovePreviousButton = this.bindingNavigatorMovePreviousItem;
      this.BnData.Name = "BnData";
      this.BnData.PositionTextBox = this.bindingNavigatorPositionItem;
      this.BnData.Size = new System.Drawing.Size(598, 25);
      this.BnData.Stretch = true;
      this.BnData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
      this.BnData.TabIndex = 4;
      this.BnData.TabStop = false;
      this.BnData.Text = "bindingNavigatorEx1";
      // 
      // bindingNavigatorAddNewItem
      // 
      this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
      this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
      this.bindingNavigatorAddNewItem.Text = "Add new";
      this.bindingNavigatorAddNewItem.Visible = false;
      // 
      // bindingNavigatorCountItem
      // 
      this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
      this.bindingNavigatorCountItem.Text = "de {0}";
      // 
      // bindingNavigatorDeleteItem
      // 
      this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
      this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
      this.bindingNavigatorDeleteItem.Text = "Delete";
      this.bindingNavigatorDeleteItem.Visible = false;
      // 
      // bindingNavigatorMoveFirstItem
      // 
      this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
      this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
      this.bindingNavigatorMoveFirstItem.Text = "Move first";
      // 
      // bindingNavigatorMovePreviousItem
      // 
      this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
      this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
      this.bindingNavigatorMovePreviousItem.Text = "Move previous";
      // 
      // bindingNavigatorPositionItem
      // 
      this.bindingNavigatorPositionItem.AccessibleName = "Position";
      this.bindingNavigatorPositionItem.BeginGroup = true;
      this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
      this.bindingNavigatorPositionItem.Text = "0";
      this.bindingNavigatorPositionItem.TextBoxWidth = 54;
      this.bindingNavigatorPositionItem.WatermarkColor = System.Drawing.SystemColors.GrayText;
      // 
      // bindingNavigatorMoveNextItem
      // 
      this.bindingNavigatorMoveNextItem.BeginGroup = true;
      this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
      this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
      this.bindingNavigatorMoveNextItem.Text = "Move next";
      // 
      // bindingNavigatorMoveLastItem
      // 
      this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
      this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
      this.bindingNavigatorMoveLastItem.Text = "Move last";
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Dock = System.Windows.Forms.DockStyle.Top;
      this.label1.ForeColor = System.Drawing.Color.Black;
      this.label1.Location = new System.Drawing.Point(3, 28);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(598, 5);
      this.label1.TabIndex = 6;
      // 
      // FrmFilter
      // 
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
      this.BottomLeftCornerSize = 0;
      this.BottomRightCornerSize = 0;
      this.ClientSize = new System.Drawing.Size(604, 472);
      this.Controls.Add(this.SgcData);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.BnData);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmFilter";
      this.Padding = new System.Windows.Forms.Padding(3);
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.TopLeftCornerSize = 0;
      this.TopRightCornerSize = 0;
      this.Shown += new System.EventHandler(this.FrmFilter_Shown);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmFilter_KeyDown);
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmFilter_KeyUp);
      ((System.ComponentModel.ISupportInitialize)(this.BsData)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BnData)).EndInit();
      this.ResumeLayout(false);

    }

  }

  #region « CLASES ANEXAS »

  public static class DataTypeExtensions
  {
    #region Methods

    public static string Left(this string str, int length)
    {
      str = (str ?? string.Empty);
      return str.Substring(0, Math.Min(length, str.Length));
    }

    public static string Right(this string str, int length)
    {
      str = (str ?? string.Empty);
      return (str.Length >= length)
          ? str.Substring(str.Length - length, length)
          : str;
    }

    #endregion
  }

  public class DataRows
  {

    private System.Collections.ArrayList AlArray;

    public DataRows()
    { AlArray = new System.Collections.ArrayList(); }

    public int Add(ResultRow value)
    { return AlArray.Add(value); }

    public void Clear()
    { AlArray.Clear(); }

    public void Insert(int index, ResultRow value)
    { AlArray.Insert(index, value); }

    public void Remove(ResultRow value)
    { AlArray.Remove(value); }

    public void RemoveAt(int index)
    { AlArray.RemoveAt(index); }

    public int Count
    { get { return AlArray.Count; } }

    public ResultRow this[int index]
    { get { return (ResultRow)AlArray[index]; } }

  }

  #region « Event Results »

  public class ResultRowDataEventArgs : EventArgs
  {

    private DataRows Datarows;

    public ResultRowDataEventArgs()
    {
      Rows = new List<ResultRow>();
      Datarows = new DataRows();
    }

    public IList<ResultRow> Rows
    { get; set; }

    public DataRows DataRows
    {
      get
      {
        Datarows.Clear();
        for (int r = 0; r < Rows.Count; r++)
        { Datarows.Add(Rows[r]); }
        return Datarows;
      }
    }

    public string Flag { get; set; }

  }

  #endregion

  #region « Field Results »

  public class DataFields
  {

    private System.Collections.ArrayList AlArray;

    public DataFields()
    { AlArray = new System.Collections.ArrayList(); }

    public int Add(ResultField value)
    { return AlArray.Add(value); }

    public void Clear()
    { AlArray.Clear(); }

    public void Insert(int index, ResultField value)
    { AlArray.Insert(index, value); }

    public void Remove(ResultField value)
    { AlArray.Remove(value); }

    public void RemoveAt(int index)
    { AlArray.RemoveAt(index); }

    public int Count
    { get { return AlArray.Count; } }

    public ResultField this[int index]
    { get { return (ResultField)AlArray[index]; } }

  }

  public class ResultField
  {
    public IList<ResultRow> Rows { get; set; }

    public string FieldName { get; set; }
    public string HeardText { get; set; }
    public object Value { get; set; }
    public int IndexField { get; set; }

  }

  #endregion

  #region « ResultRow Results »

  public class ResultRow
  {
    private DataFields fields;

    public ResultRow()
    {
      ResultField = new List<ResultField>();
      fields = new DataFields();
    }

    ~ResultRow()
    { ResultField = null; }

    public IList<ResultField> ResultField { get; set; }

    public DataFields Fields
    {
      get
      {
        fields.Clear();
        for (int r = 0; r < ResultField.Count; r++)
        { fields.Add(ResultField[r]); }
        return fields;
      }
    }

    public int FieldsCount { get; set; }

    public int IndexRow { get; set; }

  }

  #endregion

  #endregion

}
