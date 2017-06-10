namespace SistemaPC
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmPrepPed2 : Form
    {
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dgPrepPed")]
        private DataGrid _dgPrepPed;
        [AccessedThroughProperty("editCantEti")]
        private TextBox _editCantEti;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label5")]
        private Label _Label5;
        [AccessedThroughProperty("Label6")]
        private Label _Label6;
        [AccessedThroughProperty("txtCliente")]
        private TextBox _txtCliente;
        [AccessedThroughProperty("txtFechaEnt")]
        private TextBox _txtFechaEnt;
        [AccessedThroughProperty("txtNroOV")]
        private TextBox _txtNroOV;
        private IContainer components;
        public DataSet DS;

        public frmPrepPed2()
        {
            base.Load += new EventHandler(this.frmPrepPed2_Load);
            base.Closed += new EventHandler(this.frmPrepPed2_Closed);
            this.DS = new DataSet();
            this.InitializeComponent();
        }

        private void Actualiza()
        {
            int num;
            SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096");
            connection.Open();
            SqlCommand command = new SqlCommand("insert into ImpEAPrePed (NroOV,TipoOV) values ('" + Variables.gNroOV + "'," + StringType.FromInteger(Variables.gTipoOV) + ")", connection);
            try
            {
                num = command.ExecuteNonQuery();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                connection.Close();
                ProjectData.ClearProjectError();
                return;
                ProjectData.ClearProjectError();
            }
            command = new SqlCommand("update " + Variables.gTermi + "TmpEAPrepPed set Impreso='S' where NroOV='" + Variables.gNroOV + "' and TipoOV=" + StringType.FromInteger(Variables.gTipoOV), connection);
            try
            {
                num = command.ExecuteNonQuery();
            }
            catch (Exception exception3)
            {
                ProjectData.SetProjectError(exception3);
                Exception exception2 = exception3;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, MsgBoxStyle.OKOnly, null);
                connection.Close();
                ProjectData.ClearProjectError();
                return;
                ProjectData.ClearProjectError();
            }
            connection.Close();
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            if (StringType.StrCmp(Variables.gColor, "R", false) == 0)
            {
                Interaction.MsgBox("No puede imprimir etiqueta de esta orden", MsgBoxStyle.Critical, "Operador");
                this.cmbSalir.Focus();
            }
            else if (StringType.StrCmp(this.editCantEti.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe ingresar cantidad de etiquetas a imprimir", MsgBoxStyle.Critical, "Operador");
                this.editCantEti.Focus();
            }
            else if (!Information.IsNumeric(this.editCantEti.Text))
            {
                Interaction.MsgBox("Cantidad de etiquetas a imprimir debe ser num\x00e9rica", MsgBoxStyle.Critical, "Operador");
                this.editCantEti.Focus();
            }
            else
            {
                int num2;
                if (File.Exists(@"C:\PrepPed.txt"))
                {
                    FileSystem.Kill(@"C:\PrepPed.txt");
                }
                if (Variables.gTipoOV != 6)
                {
                    num2 = FileSystem.FreeFile();
                    FileSystem.FileOpen(num2, @"C:\PrepPed.txt", OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
                    FileSystem.PrintLine(num2, new object[] { "\x0002c0000" });
                    FileSystem.PrintLine(num2, new object[] { "\x0002e" });
                    FileSystem.PrintLine(num2, new object[] { "\x0002M1407" });
                    FileSystem.PrintLine(num2, new object[] { "\x0002a" });
                    FileSystem.PrintLine(num2, new object[] { "\x0002RN" });
                    FileSystem.PrintLine(num2, new object[] { "\x0002s" });
                    FileSystem.PrintLine(num2, new object[] { "\x0002V0" });
                    FileSystem.PrintLine(num2, new object[] { "\x0002O0110" });
                    FileSystem.PrintLine(num2, new object[] { "\x0002Kf0038" });
                    FileSystem.PrintLine(num2, new object[] { "\x0002L" });
                    FileSystem.PrintLine(num2, new object[] { "D11" });
                    FileSystem.PrintLine(num2, new object[] { "A0" });
                    FileSystem.PrintLine(num2, new object[] { "Q" + Strings.Format(Conversion.Val(this.editCantEti.Text), "0000") });
                    FileSystem.PrintLine(num2, new object[] { "491100500140064Metodo de entrega: " });
                    FileSystem.PrintLine(num2, new object[] { "491100501900066" + Variables.gDescMetEnt });
                    FileSystem.PrintLine(num2, new object[] { "491100500140094Cliente: " });
                    FileSystem.PrintLine(num2, new object[] { "491100500860096" + Variables.gCliente });
                    FileSystem.PrintLine(num2, new object[] { "491100500140126" + Variables.gObserva1 });
                    FileSystem.PrintLine(num2, new object[] { "491100500140156" + Variables.gObserva2 });
                    FileSystem.PrintLine(num2, new object[] { "491100500140186Fecha Entrega: " + Strings.Format(Variables.gFechaEnt, "dd/MM/yyyy") });
                    FileSystem.PrintLine(num2, new object[] { "491100700160225Orden de Venta Nro. " + Variables.gNroOV });
                    FileSystem.PrintLine(num2, new object[] { "4e7709000290329A" + Variables.gNroOV });
                    FileSystem.PrintLine(num2, new object[] { "E" });
                    FileSystem.FileClose(new int[] { num2 });
                    Interaction.Shell(@"C:\PrepPed.bat", AppWinStyle.MinimizedFocus, false, -1);
                }
                else
                {
                    double num;
                    string str;
                    string str2;
                    string str3;
                    SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=True;packet size=4096");
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT OR030100.OR03005,OR030100.OR03006,OR030100.OR03007,OR030100.OR03011 FROM dbo.OR030100 where OR03001='" + Variables.gNroOV + "' and OR03034=1", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        str = StringType.FromObject(reader["OR03005"]);
                        str2 = Strings.Trim(StringType.FromObject(reader["OR03006"])) + " " + Strings.Trim(StringType.FromObject(reader["OR03007"]));
                        num = DoubleType.FromObject(ObjectType.MulObj(reader["OR03011"], -1));
                        reader.Close();
                    }
                    else
                    {
                        str = "";
                        str2 = "";
                        num = 0.0;
                        reader.Close();
                    }
                    reader = new SqlCommand("SELECT OR040100.OR04003 FROM dbo.OR040100 where OR04001='" + Variables.gNroOV + "'", connection).ExecuteReader();
                    if (reader.Read())
                    {
                        if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR04003"])), "0", false) == 0)
                        {
                            str3 = "";
                        }
                        else
                        {
                            str3 = StringType.FromObject(reader["OR04003"]);
                        }
                        reader.Close();
                    }
                    else
                    {
                        str3 = "";
                        reader.Close();
                    }
                    num2 = FileSystem.FreeFile();
                    FileSystem.FileOpen(num2, @"C:\PrepPed.txt", OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
                    FileSystem.PrintLine(num2, new object[] { "\x0002c0000" });
                    FileSystem.PrintLine(num2, new object[] { "\x0002e" });
                    FileSystem.PrintLine(num2, new object[] { "\x0002M1407" });
                    FileSystem.PrintLine(num2, new object[] { "\x0002a" });
                    FileSystem.PrintLine(num2, new object[] { "\x0002RN" });
                    FileSystem.PrintLine(num2, new object[] { "\x0002s" });
                    FileSystem.PrintLine(num2, new object[] { "\x0002V0" });
                    FileSystem.PrintLine(num2, new object[] { "\x0002O0110" });
                    FileSystem.PrintLine(num2, new object[] { "\x0002Kf0038" });
                    FileSystem.PrintLine(num2, new object[] { "\x0002L" });
                    FileSystem.PrintLine(num2, new object[] { "D11" });
                    FileSystem.PrintLine(num2, new object[] { "A0" });
                    FileSystem.PrintLine(num2, new object[] { "Q" + Strings.Format(Conversion.Val(this.editCantEti.Text), "0000") });
                    FileSystem.PrintLine(num2, new object[] { "491100500140034" + Variables.gCliente });
                    FileSystem.PrintLine(num2, new object[] { "491100500140054O.Venta Nro : " + str3 });
                    FileSystem.PrintLine(num2, new object[] { "491100500140074Cantidad      : " + Strings.Format(num, "#####0") });
                    FileSystem.PrintLine(num2, new object[] { "491100500140104Producto      : " + str });
                    FileSystem.PrintLine(num2, new object[] { "491100500140124" + str2 });
                    FileSystem.PrintLine(num2, new object[] { "4e5509000140214C" + str });
                    FileSystem.PrintLine(num2, new object[] { "491100500140236O.Ensamblado Nro.  : " + Variables.gNroOV });
                    FileSystem.PrintLine(num2, new object[] { "4e5509000140329A" + Variables.gNroOV });
                    FileSystem.PrintLine(num2, new object[] { "E" });
                    FileSystem.FileClose(new int[] { num2 });
                    Interaction.Shell(@"C:\PrepPed.bat", AppWinStyle.MinimizedFocus, false, -1);
                }
                this.Actualiza();
                this.Close();
            }
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgPrepPed_Navigate(object sender, NavigateEventArgs ne)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void editCantEti_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        ~frmPrepPed2()
        {
        }

        private void frmPrepPed2_Closed(object sender, EventArgs e)
        {
        }

        private void frmPrepPed2_Load(object sender, EventArgs e)
        {
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
            new SqlDataAdapter("select Codigo,CantOrden,CantPrep,Stock,Desc1,Desc2,Estante,Stock03,Stock04,Stock05,Stock06,Stock07,Stock08,Stock09 from " + Variables.gTermi + "TmpPrepPed where Producto=0 order by Estante", selectConnectionString).Fill(this.DS, Variables.gTermi + "TmpPrepPed");
            this.dgPrepPed.DataSource = this.DS.Tables[Variables.gTermi + "TmpPrepPed"];
            DataGridTableStyle table = new DataGridTableStyle();
            table.MappingName = Variables.gTermi + "TmpPrepPed";
            DataGridTextBoxColumn column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column15 = column;
            column15.HeaderText = "Estante";
            column15.MappingName = "Estante";
            column15.Width = 50;
            column15 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column14 = column;
            column14.HeaderText = "C\x00f3digo";
            column14.MappingName = "Codigo";
            column14.Width = 70;
            column14 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column13 = column;
            column13.HeaderText = "OV";
            column13.MappingName = "CantOrden";
            column13.Format = "######0";
            column13.Alignment = HorizontalAlignment.Right;
            column13.Width = 40;
            column13 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column12 = column;
            column12.HeaderText = "Prep.";
            column12.MappingName = "CantPrep";
            column12.Format = "######0";
            column12.Alignment = HorizontalAlignment.Right;
            column12.Width = 40;
            column12 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column11 = column;
            column11.HeaderText = "Stock";
            column11.MappingName = "Stock";
            column11.Format = "######0";
            column11.Alignment = HorizontalAlignment.Right;
            column11.Width = 40;
            column11 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column10 = column;
            column10.HeaderText = "Descripci\x00f3n";
            column10.MappingName = "Desc1";
            column10.Width = 200;
            column10 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column9 = column;
            column9.HeaderText = "Descripci\x00f3n";
            column9.MappingName = "Desc2";
            column9.Width = 140;
            column9 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column8 = column;
            column8.HeaderText = "Stk Al.03";
            column8.MappingName = "Stock03";
            column8.Format = "######0";
            column8.Alignment = HorizontalAlignment.Right;
            column8.Width = 0x37;
            column8 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column7 = column;
            column7.HeaderText = "Stk Al.04";
            column7.MappingName = "Stock04";
            column7.Format = "######0";
            column7.Alignment = HorizontalAlignment.Right;
            column7.Width = 0x37;
            column7 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column6 = column;
            column6.HeaderText = "Stk Al.05";
            column6.MappingName = "Stock05";
            column6.Format = "######0";
            column6.Alignment = HorizontalAlignment.Right;
            column6.Width = 0x37;
            column6 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column5 = column;
            column5.HeaderText = "Stk Al.06";
            column5.MappingName = "Stock06";
            column5.Format = "######0";
            column5.Alignment = HorizontalAlignment.Right;
            column5.Width = 0x37;
            column5 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column4 = column;
            column4.HeaderText = "Stk Al.07";
            column4.MappingName = "Stock07";
            column4.Format = "######0";
            column4.Alignment = HorizontalAlignment.Right;
            column4.Width = 0x37;
            column4 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column3 = column;
            column3.HeaderText = "Stk Al.08";
            column3.MappingName = "Stock08";
            column3.Format = "######0";
            column3.Alignment = HorizontalAlignment.Right;
            column3.Width = 0x37;
            column3 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column2 = column;
            column2.HeaderText = "Stk Al.09";
            column2.MappingName = "Stock09";
            column2.Format = "######0";
            column2.Alignment = HorizontalAlignment.Right;
            column2.Width = 0x37;
            column2 = null;
            table.GridColumnStyles.Add(column);
            this.dgPrepPed.TableStyles.Add(table);
            this.dgPrepPed.Refresh();
            this.txtNroOV.Text = Variables.gNroOV;
            this.txtFechaEnt.Text = Strings.Format(Variables.gFechaEnt, "dd/MM/yyyy");
            this.txtCliente.Text = Variables.gCliente;
            this.editCantEti.Focus();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmPrepPed2));
            this.cmbSalir = new Button();
            this.dgPrepPed = new DataGrid();
            this.Label6 = new Label();
            this.txtCliente = new TextBox();
            this.Label5 = new Label();
            this.txtFechaEnt = new TextBox();
            this.Label1 = new Label();
            this.txtNroOV = new TextBox();
            this.Label2 = new Label();
            this.editCantEti = new TextBox();
            this.cmbAceptar = new Button();
            this.dgPrepPed.BeginInit();
            this.SuspendLayout();
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            this.cmbSalir.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Point point = new Point(0x158, 0x210);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            Size size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 10;
            this.cmbSalir.Text = "&Salir";
            this.dgPrepPed.CaptionFont = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dgPrepPed.CaptionText = "Productos";
            this.dgPrepPed.DataMember = "";
            this.dgPrepPed.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dgPrepPed.HeaderForeColor = SystemColors.ControlText;
            point = new Point(8, 0x38);
            this.dgPrepPed.Location = point;
            this.dgPrepPed.Name = "dgPrepPed";
            this.dgPrepPed.ReadOnly = true;
            size = new Size(0x3f0, 0x1d0);
            this.dgPrepPed.Size = size;
            this.dgPrepPed.TabIndex = 6;
            this.Label6.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x1d0, 0x10);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(0x38, 20);
            this.Label6.Size = size;
            this.Label6.TabIndex = 4;
            this.Label6.Text = "Cliente:";
            this.txtCliente.BackColor = SystemColors.Window;
            this.txtCliente.Enabled = false;
            this.txtCliente.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x210, 0x10);
            this.txtCliente.Location = point;
            this.txtCliente.MaxLength = 0x23;
            this.txtCliente.Name = "txtCliente";
            size = new Size(480, 0x16);
            this.txtCliente.Size = size;
            this.txtCliente.TabIndex = 5;
            this.txtCliente.Text = "";
            this.Label5.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x100, 0x10);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size(0x68, 20);
            this.Label5.Size = size;
            this.Label5.TabIndex = 2;
            this.Label5.Text = "Fecha Entrega:";
            this.txtFechaEnt.BackColor = SystemColors.Window;
            this.txtFechaEnt.Enabled = false;
            this.txtFechaEnt.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x170, 0x10);
            this.txtFechaEnt.Location = point;
            this.txtFechaEnt.MaxLength = 10;
            this.txtFechaEnt.Name = "txtFechaEnt";
            size = new Size(80, 0x16);
            this.txtFechaEnt.Size = size;
            this.txtFechaEnt.TabIndex = 3;
            this.txtFechaEnt.Text = "";
            this.Label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x10);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x88, 20);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0;
            this.Label1.Text = "N\x00b0 Orden de Venta:";
            this.txtNroOV.BackColor = SystemColors.Window;
            this.txtNroOV.Enabled = false;
            this.txtNroOV.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x98, 0x10);
            this.txtNroOV.Location = point;
            this.txtNroOV.MaxLength = 10;
            this.txtNroOV.Name = "txtNroOV";
            size = new Size(80, 0x16);
            this.txtNroOV.Size = size;
            this.txtNroOV.TabIndex = 1;
            this.txtNroOV.Text = "";
            this.Label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x228);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0xd0, 20);
            this.Label2.Size = size;
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Cantidad de Etiquetas a Imprimir:";
            this.editCantEti.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0xe8, 0x228);
            this.editCantEti.Location = point;
            this.editCantEti.MaxLength = 4;
            this.editCantEti.Name = "editCantEti";
            size = new Size(80, 0x16);
            this.editCantEti.Size = size;
            this.editCantEti.TabIndex = 8;
            this.editCantEti.Text = "";
            this.cmbAceptar.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x158, 0x240);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 9;
            this.cmbAceptar.Text = "&Aceptar";
            size = new Size(6, 15);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x404, 0x2d5);
            this.ClientSize = size;
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.editCantEti);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtNroOV);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.txtFechaEnt);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.dgPrepPed);
            this.Controls.Add(this.cmbSalir);
            this.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmPrepPed2";
            this.Text = "Preparaci\x00f3n de Pedidos";
            this.WindowState = FormWindowState.Maximized;
            this.dgPrepPed.EndInit();
            this.ResumeLayout(false);
        }

        internal virtual Button cmbAceptar
        {
            get
            {
                return this._cmbAceptar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbAceptar != null)
                {
                    this._cmbAceptar.Click -= new EventHandler(this.cmbAceptar_Click);
                }
                this._cmbAceptar = value;
                if (this._cmbAceptar != null)
                {
                    this._cmbAceptar.Click += new EventHandler(this.cmbAceptar_Click);
                }
            }
        }

        internal virtual Button cmbSalir
        {
            get
            {
                return this._cmbSalir;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbSalir != null)
                {
                    this._cmbSalir.Click -= new EventHandler(this.cmbSalir_Click);
                }
                this._cmbSalir = value;
                if (this._cmbSalir != null)
                {
                    this._cmbSalir.Click += new EventHandler(this.cmbSalir_Click);
                }
            }
        }

        internal virtual DataGrid dgPrepPed
        {
            get
            {
                return this._dgPrepPed;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dgPrepPed != null)
                {
                    this._dgPrepPed.Navigate -= new NavigateEventHandler(this.dgPrepPed_Navigate);
                }
                this._dgPrepPed = value;
                if (this._dgPrepPed != null)
                {
                    this._dgPrepPed.Navigate += new NavigateEventHandler(this.dgPrepPed_Navigate);
                }
            }
        }

        internal virtual TextBox editCantEti
        {
            get
            {
                return this._editCantEti;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editCantEti != null)
                {
                    this._editCantEti.KeyPress -= new KeyPressEventHandler(this.editCantEti_KeyPress);
                }
                this._editCantEti = value;
                if (this._editCantEti != null)
                {
                    this._editCantEti.KeyPress += new KeyPressEventHandler(this.editCantEti_KeyPress);
                }
            }
        }

        internal virtual Label Label1
        {
            get
            {
                return this._Label1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label1 != null)
                {
                }
                this._Label1 = value;
                if (this._Label1 != null)
                {
                }
            }
        }

        internal virtual Label Label2
        {
            get
            {
                return this._Label2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label2 != null)
                {
                }
                this._Label2 = value;
                if (this._Label2 != null)
                {
                }
            }
        }

        internal virtual Label Label5
        {
            get
            {
                return this._Label5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label5 != null)
                {
                }
                this._Label5 = value;
                if (this._Label5 != null)
                {
                }
            }
        }

        internal virtual Label Label6
        {
            get
            {
                return this._Label6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label6 != null)
                {
                }
                this._Label6 = value;
                if (this._Label6 != null)
                {
                }
            }
        }

        internal virtual TextBox txtCliente
        {
            get
            {
                return this._txtCliente;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtCliente != null)
                {
                }
                this._txtCliente = value;
                if (this._txtCliente != null)
                {
                }
            }
        }

        internal virtual TextBox txtFechaEnt
        {
            get
            {
                return this._txtFechaEnt;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtFechaEnt != null)
                {
                }
                this._txtFechaEnt = value;
                if (this._txtFechaEnt != null)
                {
                }
            }
        }

        internal virtual TextBox txtNroOV
        {
            get
            {
                return this._txtNroOV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtNroOV != null)
                {
                }
                this._txtNroOV = value;
                if (this._txtNroOV != null)
                {
                }
            }
        }
    }
}

