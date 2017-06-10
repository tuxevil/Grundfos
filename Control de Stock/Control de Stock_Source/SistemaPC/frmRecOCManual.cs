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
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmRecOCManual : Form
    {
        [AccessedThroughProperty("cbProveedor")]
        private ComboBox _cbProveedor;
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbContinuar")]
        private Button _cmbContinuar;
        [AccessedThroughProperty("cmbIngresar")]
        private Button _cmbIngresar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dgFcProv")]
        private DataGrid _dgFcProv;
        [AccessedThroughProperty("dtpFechaImp")]
        private DateTimePicker _dtpFechaImp;
        [AccessedThroughProperty("dtpFechaRec")]
        private DateTimePicker _dtpFechaRec;
        [AccessedThroughProperty("editNroFC")]
        private TextBox _editNroFC;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("Label5")]
        private Label _Label5;
        [AccessedThroughProperty("Label6")]
        private Label _Label6;
        [AccessedThroughProperty("txtCodAduana")]
        private TextBox _txtCodAduana;
        [AccessedThroughProperty("txtDescAdu")]
        private TextBox _txtDescAdu;
        [AccessedThroughProperty("txtDespacho")]
        private TextBox _txtDespacho;
        public SqlDataAdapter Adap;
        public SqlDataAdapter AdapDespacho;
        public SqlDataAdapter AdapProveedor;
        public SqlCommandBuilder CB;
        private IContainer components;
        public DataSet DS;
        public bool gOK;

        public frmRecOCManual()
        {
            base.Closed += new EventHandler(this.frmRecOCManual_Closed);
            base.Load += new EventHandler(this.frmRecOCManual_Load);
            this.DS = new DataSet();
            this.InitializeComponent();
        }

        private void cbProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.txtDespacho.Focus();
            }
        }

        private void cbProveedor_LocationChanged(object sender, EventArgs e)
        {
        }

        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            if (BooleanType.FromObject(ObjectType.BitAndObj(StringType.StrCmp(this.cbProveedor.Text, Strings.Space(0), false) == 0, ObjectType.ObjTst(this.cbProveedor.SelectedValue, Strings.Space(0), false) == 0)))
            {
                Interaction.MsgBox("Debe seleccionar proveedor", 0x10, "Operador");
                this.cbProveedor.Focus();
            }
            else if (StringType.StrCmp(this.txtDespacho.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe ingresar Despacho", 0x10, "Operador");
                this.txtDespacho.Focus();
            }
            else if (StringType.StrCmp(this.txtCodAduana.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe ingresar C\x00f3digo de Aduana", 0x10, "Operador");
                this.txtCodAduana.Focus();
            }
            else
            {
                this.dtpFechaRec.Enabled = false;
                this.cbProveedor.Enabled = false;
                this.cmbAceptar.Enabled = false;
                this.GroupBox2.Enabled = false;
                Variables.gDespacho = this.txtDespacho.Text;
                Variables.gFechaImp = this.dtpFechaImp.Value;
                Variables.gCodAduana = this.txtCodAduana.Text;
                string connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlDataReader reader = new SqlCommand("select * from MercRec where Despacho='" + Variables.gDespacho + "'", connection).ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    connection.Close();
                    if (Interaction.MsgBox("Este despacho ya fue procesado, continua?", 4, "Operador") == 7)
                    {
                        this.dtpFechaRec.Enabled = true;
                        this.cbProveedor.Enabled = true;
                        this.cmbAceptar.Enabled = true;
                        this.GroupBox2.Enabled = true;
                        this.dtpFechaRec.Focus();
                        return;
                    }
                }
                else
                {
                    reader.Close();
                }
                Variables.gCodProv = StringType.FromObject(this.cbProveedor.SelectedValue);
                string selectCommandText = "select * from Despachos where Despacho='" + Variables.gDespacho + "' order by NroFCProv";
                this.Adap = new SqlDataAdapter(selectCommandText, connectionString);
                this.CB = new SqlCommandBuilder(this.Adap);
                this.Adap.Fill(this.DS, "FCProv");
                this.dgFcProv.DataSource = this.DS.Tables["FCProv"];
                DataGridTableStyle table = new DataGridTableStyle();
                table.MappingName = "FCProv";
                DataGridTextBoxColumn column = new DataGridTextBoxColumn();
                column = new DataGridTextBoxColumn();
                DataGridTextBoxColumn column2 = column;
                column2.HeaderText = "Factura Proveedor";
                column2.MappingName = "NroFCProv";
                column2.Width = 150;
                column2 = null;
                table.GridColumnStyles.Add(column);
                this.dgFcProv.TableStyles.Add(table);
                this.dgFcProv.Refresh();
                this.GroupBox1.Visible = true;
                this.editNroFC.Focus();
            }
        }

        private void cmbContinuar_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Los datos del despacho son correctos?", 4, "Operador") == 7)
            {
                this.GroupBox2.Enabled = true;
                this.txtDespacho.Focus();
            }
            else
            {
                Variables.gFechaRec = this.dtpFechaRec.Value;
                Variables.gCodProv = StringType.FromObject(this.cbProveedor.SelectedValue);
                Variables.gNomProv = this.cbProveedor.Text;
                Variables.gDespacho = this.txtDespacho.Text;
                Variables.gFechaImp = this.dtpFechaImp.Value;
                Variables.gCodAduana = this.txtCodAduana.Text;
                Variables.gNomAduana = this.txtDescAdu.Text;
                frmRecOCManual1 manual = new frmRecOCManual1();
                this.Hide();
                manual.Show();
            }
        }

        private void cmbIngresar_Click(object sender, EventArgs e)
        {
            if (StringType.StrCmp(this.editNroFC.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe ingresar nro.factura proveedor", 0x10, "Operador");
                this.editNroFC.Focus();
            }
            else
            {
                SqlConnection connection;
                string str2;
                bool flag = false;
                try
                {
                    str2 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
                    connection = new SqlConnection(str2);
                    connection.Open();
                    flag = true;
                    new SqlCommand("insert into Despachos (Despacho,NroFCProv) values ('" + Variables.gDespacho + "','" + this.editNroFC.Text + "')", connection).ExecuteNonQuery();
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    if (flag)
                    {
                        connection.Close();
                        flag = false;
                    }
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                    this.Close();
                    ProjectData.ClearProjectError();
                }
                connection.Close();
                flag = false;
                string selectCommandText = "select * from Despachos where Despacho='" + Variables.gDespacho + "' order by NroFCProv";
                this.Adap = new SqlDataAdapter(selectCommandText, str2);
                this.DS.Tables["FCProv"].Clear();
                this.Adap.Fill(this.DS, "FCProv");
                this.dgFcProv.DataSource = this.DS.Tables["FCProv"];
                this.dgFcProv.Refresh();
                this.editNroFC.Text = "";
                this.editNroFC.Focus();
            }
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgFcProv_Click(object sender, EventArgs e)
        {
        }

        private void dgFcProv_DoubleClick(object sender, EventArgs e)
        {
            bool flag = false;
            if ((this.DS.Tables["FCProv"].Rows.Count != 0) && (Interaction.MsgBox("Desea eliminar la factura", 4, "Operador") == 6))
            {
                SqlConnection connection;
                string str3;
                try
                {
                    str3 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                    connection = new SqlConnection(str3);
                    connection.Open();
                    flag = true;
                    int num = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("delete Despachos where Despacho='" + Variables.gDespacho + "' and NroFCProv='", this.dgFcProv[this.dgFcProv.CurrentCell.RowNumber, 0]), "'")), connection).ExecuteNonQuery();
                    connection.Close();
                    flag = false;
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    if (flag)
                    {
                        connection.Close();
                        flag = false;
                    }
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                    this.Close();
                    ProjectData.ClearProjectError();
                }
                string selectCommandText = "select * from Despachos where Despacho='" + Variables.gDespacho + "' order by NroFCProv";
                this.Adap = new SqlDataAdapter(selectCommandText, str3);
                this.DS.Tables["FCProv"].Clear();
                this.Adap.Fill(this.DS, "FCProv");
                this.dgFcProv.DataSource = this.DS.Tables["FCProv"];
                this.dgFcProv.Refresh();
            }
        }

        private void dgFcProv_Navigate(object sender, NavigateEventArgs ne)
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

        private void dtpFechaImp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.txtCodAduana.Focus();
            }
        }

        private void dtpFechaImp_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtpFechaRec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cbProveedor.Focus();
            }
        }

        private void dtpFechaRec_ValueChanged(object sender, EventArgs e)
        {
        }

        private void editNroFC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                if (StringType.StrCmp(this.editNroFC.Text, Strings.Space(0), false) == 0)
                {
                    this.cmbContinuar.Focus();
                }
                else
                {
                    this.cmbIngresar.Focus();
                }
            }
        }

        private void editNroFC_TextChanged(object sender, EventArgs e)
        {
        }

        ~frmRecOCManual()
        {
        }

        private void frmRecOCManual_Closed(object sender, EventArgs e)
        {
            new frmMenuOCompra().Show();
        }

        private void frmRecOCManual_Load(object sender, EventArgs e)
        {
            bool flag = false;
            this.dtpFechaRec.Value = DateAndTime.get_Now();
            try
            {
                string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=True;packet size=4096";
                string selectCommandText = "SELECT distinct ltrim(PC01003)+'-'+ltrim(PL01002) as NomProv,PC01003 FROM dbo.PC010100 inner join PL010100 on PC01003=PL01001 inner join PC030100 on PC01001=PC03001 where PC03010-PC03011<>0 order by NomProv";
                this.AdapProveedor = new SqlDataAdapter(selectCommandText, selectConnectionString);
                this.AdapProveedor.Fill(this.DS, "PC010100");
                this.cbProveedor.DataSource = this.DS.Tables["PC010100"];
                this.cbProveedor.DisplayMember = "NomProv";
                this.cbProveedor.ValueMember = "PC01003";
                this.cbProveedor.Refresh();
                new SqlConnection(selectConnectionString).Open();
                flag = true;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                if (flag)
                {
                    SqlConnection connection;
                    connection.Close();
                    flag = false;
                }
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                this.Close();
                ProjectData.ClearProjectError();
            }
            this.cbProveedor.Text = "";
            this.cbProveedor.SelectedValue = "";
            this.txtDespacho.Text = "";
            this.dtpFechaImp.Value = DateAndTime.get_Now();
            this.txtCodAduana.Text = "";
            this.txtDescAdu.Text = "";
            this.dtpFechaRec.Focus();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.Label2 = new Label();
            this.cbProveedor = new ComboBox();
            this.GroupBox1 = new GroupBox();
            this.dgFcProv = new DataGrid();
            this.cmbIngresar = new Button();
            this.editNroFC = new TextBox();
            this.Label4 = new Label();
            this.cmbContinuar = new Button();
            this.txtDescAdu = new TextBox();
            this.Label1 = new Label();
            this.txtDespacho = new TextBox();
            this.Label3 = new Label();
            this.Label5 = new Label();
            this.txtCodAduana = new TextBox();
            this.dtpFechaImp = new DateTimePicker();
            this.GroupBox2 = new GroupBox();
            this.dtpFechaRec = new DateTimePicker();
            this.Label6 = new Label();
            this.GroupBox1.SuspendLayout();
            this.dgFcProv.BeginInit();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            Point point = new Point(0x218, 0xa8);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 4;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0x1b0, 0xa8);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 5;
            this.cmbSalir.Text = "&Salir";
            this.Label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x30);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x58, 0x10);
            this.Label2.Size = size;
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Proveedor:";
            this.cbProveedor.BackColor = SystemColors.Window;
            this.cbProveedor.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x30);
            this.cbProveedor.Location = point;
            this.cbProveedor.Name = "cbProveedor";
            size = new Size(0x1d8, 0x18);
            this.cbProveedor.Size = size;
            this.cbProveedor.TabIndex = 1;
            this.cbProveedor.Text = "ComboBox1";
            this.GroupBox1.Controls.Add(this.dgFcProv);
            this.GroupBox1.Controls.Add(this.cmbIngresar);
            this.GroupBox1.Controls.Add(this.editNroFC);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.cmbContinuar);
            this.GroupBox1.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x108);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(0x178, 0x120);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 3;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Facturas Proveedor";
            this.GroupBox1.Visible = false;
            this.dgFcProv.CaptionFont = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dgFcProv.CaptionText = "Facturas Proveedor";
            this.dgFcProv.DataMember = "";
            this.dgFcProv.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dgFcProv.HeaderForeColor = SystemColors.ControlText;
            point = new Point(0x10, 0x48);
            this.dgFcProv.Location = point;
            this.dgFcProv.Name = "dgFcProv";
            this.dgFcProv.ReadOnly = true;
            size = new Size(0xd8, 200);
            this.dgFcProv.Size = size;
            this.dgFcProv.TabIndex = 3;
            this.cmbIngresar.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x108, 0x18);
            this.cmbIngresar.Location = point;
            this.cmbIngresar.Name = "cmbIngresar";
            size = new Size(0x60, 40);
            this.cmbIngresar.Size = size;
            this.cmbIngresar.TabIndex = 2;
            this.cmbIngresar.Text = "&Ingresar";
            this.editNroFC.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x90, 0x20);
            this.editNroFC.Location = point;
            this.editNroFC.MaxLength = 10;
            this.editNroFC.Name = "editNroFC";
            size = new Size(0x70, 0x16);
            this.editNroFC.Size = size;
            this.editNroFC.TabIndex = 1;
            this.editNroFC.Text = "";
            this.Label4.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x20);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(80, 0x10);
            this.Label4.Size = size;
            this.Label4.TabIndex = 0;
            this.Label4.Text = "N\x00b0 Factura:";
            this.cmbContinuar.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x100, 0xe0);
            this.cmbContinuar.Location = point;
            this.cmbContinuar.Name = "cmbContinuar";
            size = new Size(0x60, 40);
            this.cmbContinuar.Size = size;
            this.cmbContinuar.TabIndex = 4;
            this.cmbContinuar.Text = "&Continuar";
            this.txtDescAdu.BackColor = SystemColors.Window;
            this.txtDescAdu.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x90, 120);
            this.txtDescAdu.Location = point;
            this.txtDescAdu.MaxLength = 0x19;
            this.txtDescAdu.Name = "txtDescAdu";
            size = new Size(160, 0x16);
            this.txtDescAdu.Size = size;
            this.txtDescAdu.TabIndex = 6;
            this.txtDescAdu.Text = "";
            this.Label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x18);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x70, 0x10);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Despacho:";
            this.txtDespacho.BackColor = SystemColors.Window;
            this.txtDespacho.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x90, 0x18);
            this.txtDespacho.Location = point;
            this.txtDespacho.MaxLength = 0x19;
            this.txtDespacho.Name = "txtDespacho";
            size = new Size(160, 0x16);
            this.txtDespacho.Size = size;
            this.txtDespacho.TabIndex = 1;
            this.txtDespacho.Text = "";
            this.Label3.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x38);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x70, 0x10);
            this.Label3.Size = size;
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Fecha Imp.:";
            this.Label5.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x58);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size(0x70, 0x10);
            this.Label5.Size = size;
            this.Label5.TabIndex = 4;
            this.Label5.Text = "C\x00f3digo Aduana:";
            this.txtCodAduana.BackColor = SystemColors.Window;
            this.txtCodAduana.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x90, 0x58);
            this.txtCodAduana.Location = point;
            this.txtCodAduana.MaxLength = 10;
            this.txtCodAduana.Name = "txtCodAduana";
            size = new Size(80, 0x16);
            this.txtCodAduana.Size = size;
            this.txtCodAduana.TabIndex = 5;
            this.txtCodAduana.Text = "";
            this.dtpFechaImp.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaImp.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaImp.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaImp.Format = DateTimePickerFormat.Short;
            point = new Point(0x90, 0x38);
            this.dtpFechaImp.Location = point;
            this.dtpFechaImp.Name = "dtpFechaImp";
            size = new Size(0x60, 0x16);
            this.dtpFechaImp.Size = size;
            this.dtpFechaImp.TabIndex = 3;
            DateTime time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpFechaImp.Value = time;
            this.GroupBox2.Controls.Add(this.dtpFechaImp);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.txtCodAduana);
            this.GroupBox2.Controls.Add(this.txtDescAdu);
            this.GroupBox2.Controls.Add(this.Label1);
            this.GroupBox2.Controls.Add(this.txtDespacho);
            this.GroupBox2.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x58);
            this.GroupBox2.Location = point;
            this.GroupBox2.Name = "GroupBox2";
            size = new Size(0x178, 160);
            this.GroupBox2.Size = size;
            this.GroupBox2.TabIndex = 2;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Datos Despacho";
            this.dtpFechaRec.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaRec.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaRec.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaRec.Format = DateTimePickerFormat.Short;
            point = new Point(160, 0x10);
            this.dtpFechaRec.Location = point;
            this.dtpFechaRec.Name = "dtpFechaRec";
            size = new Size(0x60, 0x16);
            this.dtpFechaRec.Size = size;
            this.dtpFechaRec.TabIndex = 7;
            time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpFechaRec.Value = time;
            this.Label6.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x10);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(0x70, 0x10);
            this.Label6.Size = size;
            this.Label6.TabIndex = 6;
            this.Label6.Text = "Fecha Recepci\x00f3n:";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.dtpFechaRec);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.cbProveedor);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Name = "frmRecOCManual";
            this.Text = "Recepci\x00f3n O.Compra Manual";
            this.WindowState = FormWindowState.Maximized;
            this.GroupBox1.ResumeLayout(false);
            this.dgFcProv.EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void txtCodAduana_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void txtCodAduana_LostFocus(object sender, EventArgs e)
        {
            if (StringType.StrCmp(this.txtCodAduana.Text, Strings.Space(0), false) != 0)
            {
                SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=True;packet size=4096");
                connection.Open();
                SqlDataReader reader = new SqlCommand("SELECT SY24002,SY24003 FROM dbo.SY240100 where SY24001='YO' and SY24002='" + this.txtCodAduana.Text + "'", connection).ExecuteReader();
                if (reader.Read())
                {
                    this.txtDescAdu.Text = StringType.FromObject(reader["SY24003"]);
                    reader.Close();
                    connection.Close();
                }
                else
                {
                    Interaction.MsgBox("C\x00f3digo Aduana inexistente", 0x40, "Operador");
                    this.txtDescAdu.Text = "";
                    reader.Close();
                }
            }
        }

        private void txtCodAduana_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtDespacho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.dtpFechaImp.Focus();
            }
        }

        private void txtDespacho_TextChanged(object sender, EventArgs e)
        {
        }

        internal virtual ComboBox cbProveedor
        {
            get
            {
                return this._cbProveedor;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cbProveedor != null)
                {
                    this._cbProveedor.LocationChanged -= new EventHandler(this.cbProveedor_LocationChanged);
                    this._cbProveedor.KeyPress -= new KeyPressEventHandler(this.cbProveedor_KeyPress);
                    this._cbProveedor.SelectedIndexChanged -= new EventHandler(this.cbProveedor_SelectedIndexChanged);
                }
                this._cbProveedor = value;
                if (this._cbProveedor != null)
                {
                    this._cbProveedor.LocationChanged += new EventHandler(this.cbProveedor_LocationChanged);
                    this._cbProveedor.KeyPress += new KeyPressEventHandler(this.cbProveedor_KeyPress);
                    this._cbProveedor.SelectedIndexChanged += new EventHandler(this.cbProveedor_SelectedIndexChanged);
                }
            }
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

        internal virtual Button cmbContinuar
        {
            get
            {
                return this._cmbContinuar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbContinuar != null)
                {
                    this._cmbContinuar.Click -= new EventHandler(this.cmbContinuar_Click);
                }
                this._cmbContinuar = value;
                if (this._cmbContinuar != null)
                {
                    this._cmbContinuar.Click += new EventHandler(this.cmbContinuar_Click);
                }
            }
        }

        internal virtual Button cmbIngresar
        {
            get
            {
                return this._cmbIngresar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbIngresar != null)
                {
                    this._cmbIngresar.Click -= new EventHandler(this.cmbIngresar_Click);
                }
                this._cmbIngresar = value;
                if (this._cmbIngresar != null)
                {
                    this._cmbIngresar.Click += new EventHandler(this.cmbIngresar_Click);
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

        internal virtual DataGrid dgFcProv
        {
            get
            {
                return this._dgFcProv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dgFcProv != null)
                {
                    this._dgFcProv.DoubleClick -= new EventHandler(this.dgFcProv_DoubleClick);
                    this._dgFcProv.Click -= new EventHandler(this.dgFcProv_Click);
                    this._dgFcProv.Navigate -= new NavigateEventHandler(this.dgFcProv_Navigate);
                }
                this._dgFcProv = value;
                if (this._dgFcProv != null)
                {
                    this._dgFcProv.DoubleClick += new EventHandler(this.dgFcProv_DoubleClick);
                    this._dgFcProv.Click += new EventHandler(this.dgFcProv_Click);
                    this._dgFcProv.Navigate += new NavigateEventHandler(this.dgFcProv_Navigate);
                }
            }
        }

        internal virtual DateTimePicker dtpFechaImp
        {
            get
            {
                return this._dtpFechaImp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpFechaImp != null)
                {
                    this._dtpFechaImp.KeyPress -= new KeyPressEventHandler(this.dtpFechaImp_KeyPress);
                    this._dtpFechaImp.ValueChanged -= new EventHandler(this.dtpFechaImp_ValueChanged);
                }
                this._dtpFechaImp = value;
                if (this._dtpFechaImp != null)
                {
                    this._dtpFechaImp.KeyPress += new KeyPressEventHandler(this.dtpFechaImp_KeyPress);
                    this._dtpFechaImp.ValueChanged += new EventHandler(this.dtpFechaImp_ValueChanged);
                }
            }
        }

        internal virtual DateTimePicker dtpFechaRec
        {
            get
            {
                return this._dtpFechaRec;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpFechaRec != null)
                {
                    this._dtpFechaRec.KeyPress -= new KeyPressEventHandler(this.dtpFechaRec_KeyPress);
                    this._dtpFechaRec.ValueChanged -= new EventHandler(this.dtpFechaRec_ValueChanged);
                }
                this._dtpFechaRec = value;
                if (this._dtpFechaRec != null)
                {
                    this._dtpFechaRec.KeyPress += new KeyPressEventHandler(this.dtpFechaRec_KeyPress);
                    this._dtpFechaRec.ValueChanged += new EventHandler(this.dtpFechaRec_ValueChanged);
                }
            }
        }

        internal virtual TextBox editNroFC
        {
            get
            {
                return this._editNroFC;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editNroFC != null)
                {
                    this._editNroFC.KeyPress -= new KeyPressEventHandler(this.editNroFC_KeyPress);
                    this._editNroFC.TextChanged -= new EventHandler(this.editNroFC_TextChanged);
                }
                this._editNroFC = value;
                if (this._editNroFC != null)
                {
                    this._editNroFC.KeyPress += new KeyPressEventHandler(this.editNroFC_KeyPress);
                    this._editNroFC.TextChanged += new EventHandler(this.editNroFC_TextChanged);
                }
            }
        }

        internal virtual GroupBox GroupBox1
        {
            get
            {
                return this._GroupBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._GroupBox1 != null)
                {
                }
                this._GroupBox1 = value;
                if (this._GroupBox1 != null)
                {
                }
            }
        }

        internal virtual GroupBox GroupBox2
        {
            get
            {
                return this._GroupBox2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._GroupBox2 != null)
                {
                }
                this._GroupBox2 = value;
                if (this._GroupBox2 != null)
                {
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

        internal virtual Label Label3
        {
            get
            {
                return this._Label3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label3 != null)
                {
                }
                this._Label3 = value;
                if (this._Label3 != null)
                {
                }
            }
        }

        internal virtual Label Label4
        {
            get
            {
                return this._Label4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label4 != null)
                {
                }
                this._Label4 = value;
                if (this._Label4 != null)
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

        internal virtual TextBox txtCodAduana
        {
            get
            {
                return this._txtCodAduana;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtCodAduana != null)
                {
                    this._txtCodAduana.KeyPress -= new KeyPressEventHandler(this.txtCodAduana_KeyPress);
                    this._txtCodAduana.LostFocus -= new EventHandler(this.txtCodAduana_LostFocus);
                    this._txtCodAduana.TextChanged -= new EventHandler(this.txtCodAduana_TextChanged);
                }
                this._txtCodAduana = value;
                if (this._txtCodAduana != null)
                {
                    this._txtCodAduana.KeyPress += new KeyPressEventHandler(this.txtCodAduana_KeyPress);
                    this._txtCodAduana.LostFocus += new EventHandler(this.txtCodAduana_LostFocus);
                    this._txtCodAduana.TextChanged += new EventHandler(this.txtCodAduana_TextChanged);
                }
            }
        }

        internal virtual TextBox txtDescAdu
        {
            get
            {
                return this._txtDescAdu;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtDescAdu != null)
                {
                }
                this._txtDescAdu = value;
                if (this._txtDescAdu != null)
                {
                }
            }
        }

        internal virtual TextBox txtDespacho
        {
            get
            {
                return this._txtDespacho;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtDespacho != null)
                {
                    this._txtDespacho.KeyPress -= new KeyPressEventHandler(this.txtDespacho_KeyPress);
                    this._txtDespacho.TextChanged -= new EventHandler(this.txtDespacho_TextChanged);
                }
                this._txtDespacho = value;
                if (this._txtDespacho != null)
                {
                    this._txtDespacho.KeyPress += new KeyPressEventHandler(this.txtDespacho_KeyPress);
                    this._txtDespacho.TextChanged += new EventHandler(this.txtDespacho_TextChanged);
                }
            }
        }
    }
}

