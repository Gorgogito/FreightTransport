namespace FreightTransport.App
{
  partial class FrmLogin
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
      this.line2 = new DevComponents.DotNetBar.Controls.Line();
      this.BtCancelar = new DevComponents.DotNetBar.ButtonX();
      this.BtAceptar = new DevComponents.DotNetBar.ButtonX();
      this.TxtContraseña = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.TxtCUsuario = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
      this.TxtCEmpresa = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.TxtDEmpresa = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.LblDUsuario = new DevComponents.DotNetBar.LabelX();
      this.ReflectionImage1 = new DevComponents.DotNetBar.Controls.ReflectionImage();
      this.SuspendLayout();
      // 
      // line2
      // 
      this.line2.BackColor = System.Drawing.Color.Transparent;
      this.line2.ForeColor = System.Drawing.Color.Gray;
      this.line2.Location = new System.Drawing.Point(317, 258);
      this.line2.Name = "line2";
      this.line2.Size = new System.Drawing.Size(341, 10);
      this.line2.TabIndex = 24;
      this.line2.Text = "line2";
      this.line2.Thickness = 2;
      // 
      // BtCancelar
      // 
      this.BtCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.BtCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.highlighter1.SetHighlightColor(this.BtCancelar, DevComponents.DotNetBar.Validator.eHighlightColor.Custom);
      this.BtCancelar.ImageTextSpacing = 10;
      this.BtCancelar.Location = new System.Drawing.Point(317, 367);
      this.BtCancelar.Name = "BtCancelar";
      this.BtCancelar.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
      this.BtCancelar.Size = new System.Drawing.Size(341, 40);
      this.BtCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
      this.BtCancelar.TabIndex = 26;
      this.BtCancelar.Text = "&Cancelar";
      this.BtCancelar.Click += new System.EventHandler(this.BtCancelar_Click);
      // 
      // BtAceptar
      // 
      this.BtAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.BtAceptar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.highlighter1.SetHighlightColor(this.BtAceptar, DevComponents.DotNetBar.Validator.eHighlightColor.Custom);
      this.BtAceptar.ImageTextSpacing = 10;
      this.BtAceptar.Location = new System.Drawing.Point(317, 306);
      this.BtAceptar.Name = "BtAceptar";
      this.BtAceptar.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
      this.BtAceptar.Size = new System.Drawing.Size(341, 40);
      this.BtAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
      this.BtAceptar.TabIndex = 25;
      this.BtAceptar.Text = "&Ingresar";
      this.BtAceptar.Click += new System.EventHandler(this.BtAceptar_Click);
      // 
      // TxtContraseña
      // 
      this.TxtContraseña.BackColor = System.Drawing.Color.Black;
      // 
      // 
      // 
      this.TxtContraseña.Border.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
      this.TxtContraseña.Border.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
      this.TxtContraseña.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.TxtContraseña.Border.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
      this.TxtContraseña.Border.BorderBottomWidth = 1;
      this.TxtContraseña.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.TxtContraseña.Border.BorderLeftWidth = 1;
      this.TxtContraseña.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.TxtContraseña.Border.BorderRightWidth = 1;
      this.TxtContraseña.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.TxtContraseña.Border.BorderTopWidth = 1;
      this.TxtContraseña.Border.Class = "DataGridViewBorder";
      this.TxtContraseña.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.TxtContraseña.DisabledBackColor = System.Drawing.Color.White;
      this.TxtContraseña.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.TxtContraseña.ForeColor = System.Drawing.Color.White;
      this.highlighter1.SetHighlightOnFocus(this.TxtContraseña, true);
      this.TxtContraseña.Location = new System.Drawing.Point(337, 195);
      this.TxtContraseña.Name = "TxtContraseña";
      this.TxtContraseña.PreventEnterBeep = true;
      this.TxtContraseña.Size = new System.Drawing.Size(307, 30);
      this.TxtContraseña.TabIndex = 23;
      this.TxtContraseña.UseSystemPasswordChar = true;
      this.TxtContraseña.WatermarkColor = System.Drawing.Color.DarkGray;
      this.TxtContraseña.WatermarkText = "Ingresa tu contraseña";
      this.TxtContraseña.Enter += new System.EventHandler(this.TxtContraseña_Enter);
      this.TxtContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtContraseña_KeyPress);
      // 
      // TxtCUsuario
      // 
      this.TxtCUsuario.BackColor = System.Drawing.Color.Black;
      // 
      // 
      // 
      this.TxtCUsuario.Border.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
      this.TxtCUsuario.Border.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
      this.TxtCUsuario.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.TxtCUsuario.Border.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
      this.TxtCUsuario.Border.BorderBottomWidth = 1;
      this.TxtCUsuario.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.TxtCUsuario.Border.BorderLeftWidth = 1;
      this.TxtCUsuario.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.TxtCUsuario.Border.BorderRightWidth = 1;
      this.TxtCUsuario.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.TxtCUsuario.Border.BorderTopWidth = 1;
      this.TxtCUsuario.Border.Class = "DataGridViewBorder";
      this.TxtCUsuario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.TxtCUsuario.DisabledBackColor = System.Drawing.Color.White;
      this.TxtCUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.TxtCUsuario.ForeColor = System.Drawing.Color.White;
      this.highlighter1.SetHighlightOnFocus(this.TxtCUsuario, true);
      this.TxtCUsuario.Location = new System.Drawing.Point(337, 93);
      this.TxtCUsuario.MaxLength = 0;
      this.TxtCUsuario.Name = "TxtCUsuario";
      this.TxtCUsuario.PreventEnterBeep = true;
      this.TxtCUsuario.Size = new System.Drawing.Size(307, 30);
      this.TxtCUsuario.TabIndex = 21;
      this.TxtCUsuario.WatermarkColor = System.Drawing.Color.DarkGray;
      this.TxtCUsuario.WatermarkText = "Ingrese Usuario";
      this.TxtCUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCUsuario_KeyPress);
      this.TxtCUsuario.Leave += new System.EventHandler(this.TxtCUsuario_Leave);
      // 
      // highlighter1
      // 
      this.highlighter1.ContainerControl = this;
      this.highlighter1.CustomHighlightColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))))};
      this.highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Custom;
      // 
      // TxtCEmpresa
      // 
      this.TxtCEmpresa.BackColor = System.Drawing.Color.Black;
      // 
      // 
      // 
      this.TxtCEmpresa.Border.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
      this.TxtCEmpresa.Border.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
      this.TxtCEmpresa.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.TxtCEmpresa.Border.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
      this.TxtCEmpresa.Border.BorderBottomWidth = 1;
      this.TxtCEmpresa.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.TxtCEmpresa.Border.BorderLeftWidth = 1;
      this.TxtCEmpresa.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.TxtCEmpresa.Border.BorderRightWidth = 1;
      this.TxtCEmpresa.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.TxtCEmpresa.Border.BorderTopWidth = 1;
      this.TxtCEmpresa.Border.Class = "DataGridViewBorder";
      this.TxtCEmpresa.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.TxtCEmpresa.ButtonCustom.Visible = true;
      this.TxtCEmpresa.DisabledBackColor = System.Drawing.Color.White;
      this.TxtCEmpresa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.TxtCEmpresa.ForeColor = System.Drawing.Color.White;
      this.highlighter1.SetHighlightOnFocus(this.TxtCEmpresa, true);
      this.TxtCEmpresa.Location = new System.Drawing.Point(337, 32);
      this.TxtCEmpresa.MaxLength = 4;
      this.TxtCEmpresa.Name = "TxtCEmpresa";
      this.TxtCEmpresa.PreventEnterBeep = true;
      this.TxtCEmpresa.Size = new System.Drawing.Size(48, 30);
      this.TxtCEmpresa.TabIndex = 27;
      this.TxtCEmpresa.WatermarkColor = System.Drawing.Color.DarkGray;
      this.TxtCEmpresa.ButtonCustomClick += new System.EventHandler(this.TxtCEmpresa_ButtonCustomClick);
      this.TxtCEmpresa.TextChanged += new System.EventHandler(this.TxtCEmpresa_TextChanged);
      this.TxtCEmpresa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCEmpresa_KeyDown);
      this.TxtCEmpresa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCEmpresa_KeyPress);
      this.TxtCEmpresa.Leave += new System.EventHandler(this.TxtCEmpresa_Leave);
      // 
      // TxtDEmpresa
      // 
      this.TxtDEmpresa.BackColor = System.Drawing.Color.Black;
      // 
      // 
      // 
      this.TxtDEmpresa.Border.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
      this.TxtDEmpresa.Border.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
      this.TxtDEmpresa.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.TxtDEmpresa.Border.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
      this.TxtDEmpresa.Border.BorderBottomWidth = 1;
      this.TxtDEmpresa.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.TxtDEmpresa.Border.BorderLeftWidth = 1;
      this.TxtDEmpresa.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.TxtDEmpresa.Border.BorderRightWidth = 1;
      this.TxtDEmpresa.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.TxtDEmpresa.Border.BorderTopWidth = 1;
      this.TxtDEmpresa.Border.Class = "DataGridViewBorder";
      this.TxtDEmpresa.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.TxtDEmpresa.DisabledBackColor = System.Drawing.Color.White;
      this.TxtDEmpresa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.TxtDEmpresa.ForeColor = System.Drawing.Color.White;
      this.highlighter1.SetHighlightOnFocus(this.TxtDEmpresa, true);
      this.TxtDEmpresa.Location = new System.Drawing.Point(389, 32);
      this.TxtDEmpresa.MaxLength = 4;
      this.TxtDEmpresa.Name = "TxtDEmpresa";
      this.TxtDEmpresa.PreventEnterBeep = true;
      this.TxtDEmpresa.Size = new System.Drawing.Size(255, 30);
      this.TxtDEmpresa.TabIndex = 29;
      this.TxtDEmpresa.WatermarkColor = System.Drawing.Color.DarkGray;
      this.TxtDEmpresa.WatermarkText = "Seleccionar Empresa";
      // 
      // LblDUsuario
      // 
      this.LblDUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
      // 
      // 
      // 
      this.LblDUsuario.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.LblDUsuario.BackgroundStyle.BorderBottomWidth = 1;
      this.LblDUsuario.BackgroundStyle.BorderColor = System.Drawing.Color.Gray;
      this.LblDUsuario.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.LblDUsuario.BackgroundStyle.BorderLeftWidth = 1;
      this.LblDUsuario.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.LblDUsuario.BackgroundStyle.BorderRightWidth = 1;
      this.LblDUsuario.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.LblDUsuario.BackgroundStyle.BorderTopWidth = 1;
      this.LblDUsuario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.LblDUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LblDUsuario.ForeColor = System.Drawing.Color.White;
      this.LblDUsuario.Location = new System.Drawing.Point(338, 138);
      this.LblDUsuario.Name = "LblDUsuario";
      this.LblDUsuario.Size = new System.Drawing.Size(306, 33);
      this.LblDUsuario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
      this.LblDUsuario.TabIndex = 28;
      // 
      // ReflectionImage1
      // 
      this.ReflectionImage1.BackColor = System.Drawing.Color.Transparent;
      // 
      // 
      // 
      this.ReflectionImage1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ReflectionImage1.BackgroundStyle.BorderBottomWidth = 1;
      this.ReflectionImage1.BackgroundStyle.BorderColor = System.Drawing.Color.Transparent;
      this.ReflectionImage1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ReflectionImage1.BackgroundStyle.BorderLeftWidth = 1;
      this.ReflectionImage1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ReflectionImage1.BackgroundStyle.BorderRightWidth = 1;
      this.ReflectionImage1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ReflectionImage1.BackgroundStyle.BorderTopWidth = 1;
      this.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
      this.ReflectionImage1.ForeColor = System.Drawing.Color.White;
      this.ReflectionImage1.Image = global::FreightTransport.App.Properties.Resources.default_avatar;
      this.ReflectionImage1.Location = new System.Drawing.Point(-1, -10);
      this.ReflectionImage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.ReflectionImage1.Name = "ReflectionImage1";
      this.ReflectionImage1.Size = new System.Drawing.Size(275, 412);
      this.ReflectionImage1.TabIndex = 13;
      // 
      // FrmLogin
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(686, 442);
      this.ControlBox = false;
      this.Controls.Add(this.TxtDEmpresa);
      this.Controls.Add(this.LblDUsuario);
      this.Controls.Add(this.TxtCEmpresa);
      this.Controls.Add(this.line2);
      this.Controls.Add(this.BtCancelar);
      this.Controls.Add(this.BtAceptar);
      this.Controls.Add(this.TxtContraseña);
      this.Controls.Add(this.TxtCUsuario);
      this.Controls.Add(this.ReflectionImage1);
      this.DoubleBuffered = true;
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmLogin";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "LOGIN";
      this.Shown += new System.EventHandler(this.FrmLogin_Shown);
      this.ResumeLayout(false);

    }

    #endregion
    internal DevComponents.DotNetBar.Controls.ReflectionImage ReflectionImage1;
    internal DevComponents.DotNetBar.Controls.Line line2;
    internal DevComponents.DotNetBar.ButtonX BtCancelar;
    internal DevComponents.DotNetBar.ButtonX BtAceptar;
    internal DevComponents.DotNetBar.Controls.TextBoxX TxtContraseña;
    internal DevComponents.DotNetBar.Controls.TextBoxX TxtCUsuario;
    private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
    internal DevComponents.DotNetBar.Controls.TextBoxX TxtCEmpresa;
    private DevComponents.DotNetBar.LabelX LblDUsuario;
    internal DevComponents.DotNetBar.Controls.TextBoxX TxtDEmpresa;
  }
}