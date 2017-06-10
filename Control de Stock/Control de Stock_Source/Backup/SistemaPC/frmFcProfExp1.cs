namespace SistemaPC
{
    using CrystalDecisions.CrystalReports.Engine;
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

    public class frmFcProfExp1 : Form
    {
        [AccessedThroughProperty("btnIngresar")]
        private Button _btnIngresar;
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dgTmpOVCli")]
        private DataGrid _dgTmpOVCli;
        [AccessedThroughProperty("dgTmpOVFcProExp")]
        private DataGrid _dgTmpOVFcProExp;
        [AccessedThroughProperty("editFlete")]
        private TextBox _editFlete;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("Label6")]
        private Label _Label6;
        [AccessedThroughProperty("rbAereo")]
        private RadioButton _rbAereo;
        [AccessedThroughProperty("rbCourier")]
        private RadioButton _rbCourier;
        [AccessedThroughProperty("rbMaritimo")]
        private RadioButton _rbMaritimo;
        [AccessedThroughProperty("rbTerrestre")]
        private RadioButton _rbTerrestre;
        [AccessedThroughProperty("txtCliente")]
        private TextBox _txtCliente;
        [AccessedThroughProperty("txtMoneda")]
        private TextBox _txtMoneda;
        [AccessedThroughProperty("txtNomAlmacen")]
        private TextBox _txtNomAlmacen;
        [AccessedThroughProperty("txtNroOV")]
        private TextBox _txtNroOV;
        public SqlDataAdapter Adap2;
        public SqlDataAdapter Adaptador;
        private IContainer components;
        public DataSet DS;
        public string mAlmacen;
        public string mCondEnt;
        public string mCondPago;

        public frmFcProfExp1()
        {
            base.Load += new EventHandler(this.frmFcProfExp1_Load);
            base.Closed += new EventHandler(this.frmFcProfExp1_Closed);
            this.DS = new DataSet();
            this.InitializeComponent();
        }

        private void ActTmp()
        {
            int num;
            SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
            connection.Open();
            string str = (("insert into " + Variables.gTermi + "TmpOVFcProExp (NroOV,Almacen,NomAlmacen,Flete,Tipo,Moneda,CondPago,CondEnt) values ('" + this.txtNroOV.Text) + "','" + this.mAlmacen) + "','" + this.txtNomAlmacen.Text + "'," + this.editFlete.Text + ",";
            if (!Variables.gFcProfIng)
            {
                if (this.rbAereo.Checked)
                {
                    str = str + "'AEREO',";
                }
                else if (this.rbTerrestre.Checked)
                {
                    str = str + "'TERRESTRE',";
                }
                else if (this.rbMaritimo.Checked)
                {
                    str = str + "'MARITIMO',";
                }
                else if (this.rbCourier.Checked)
                {
                    str = str + "'COURIER',";
                }
            }
            else if (this.rbAereo.Checked)
            {
                str = str + "'AIR',";
            }
            else if (this.rbTerrestre.Checked)
            {
                str = str + "'TRUCK',";
            }
            else if (this.rbMaritimo.Checked)
            {
                str = str + "'SEA',";
            }
            else if (this.rbCourier.Checked)
            {
                str = str + "'COURIER',";
            }
            SqlCommand command = new SqlCommand(((str + "'" + this.txtMoneda.Text) + "','" + this.mCondPago) + "','" + this.mCondEnt + "')", connection);
            try
            {
                num = command.ExecuteNonQuery();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                connection.Close();
                ProjectData.ClearProjectError();
                return;
                ProjectData.ClearProjectError();
            }
            command = new SqlCommand("Delete from " + Variables.gTermi + "TmpOVCli where NroOV='" + this.txtNroOV.Text + "'", connection);
            try
            {
                num = command.ExecuteNonQuery();
            }
            catch (Exception exception3)
            {
                ProjectData.SetProjectError(exception3);
                Exception exception2 = exception3;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, 0, null);
                connection.Close();
                ProjectData.ClearProjectError();
                return;
                ProjectData.ClearProjectError();
            }
            connection.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (StringType.StrCmp(this.editFlete.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe ingresar importe flete", 0x10, "Operador");
                this.editFlete.Focus();
            }
            else if (!Information.IsNumeric(this.editFlete.Text))
            {
                Interaction.MsgBox("Importe flete debe ser num\x00e9rico", 0x10, "Operador");
                this.editFlete.Focus();
            }
            else if (((!this.rbAereo.Checked & !this.rbTerrestre.Checked) & !this.rbMaritimo.Checked) & !this.rbCourier.Checked)
            {
                Interaction.MsgBox("Debe indicar tipo de flete", 0x10, "Operador");
                this.rbAereo.Focus();
            }
            else
            {
                this.GroupBox1.Enabled = false;
                this.ActTmp();
                this.GroupBox1.Enabled = true;
                this.GroupBox1.Visible = false;
                string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                string selectCommandText = "select * from " + Variables.gTermi + "TmpOVCli order by NomAlmacen,NroOV";
                this.Adaptador = new SqlDataAdapter(selectCommandText, selectConnectionString);
                this.DS.Tables[Variables.gTermi + "TmpOVCli"].Clear();
                this.Adaptador.Fill(this.DS, Variables.gTermi + "TmpOVCli");
                this.dgTmpOVCli.DataSource = this.DS.Tables[Variables.gTermi + "TmpOVCli"];
                this.dgTmpOVCli.Refresh();
                selectCommandText = "select * from " + Variables.gTermi + "TmpOVFcProExp order by NomAlmacen,NroOV";
                this.Adap2 = new SqlDataAdapter(selectCommandText, selectConnectionString);
                this.DS.Tables[Variables.gTermi + "TmpOVFcProExp"].Clear();
                this.Adap2.Fill(this.DS, Variables.gTermi + "TmpOVFcProExp");
                this.dgTmpOVFcProExp.DataSource = this.DS.Tables[Variables.gTermi + "TmpOVFcProExp"];
                this.dgTmpOVFcProExp.Refresh();
            }
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            if (this.DS.Tables[Variables.gTermi + "TmpOVFcProExp"].Rows.Count == 0)
            {
                Interaction.MsgBox("Debe seleccionar Ordenes de Venta", 0x10, "Operador");
            }
            else
            {
                this.cmbAceptar.Enabled = false;
                this.cmbSalir.Enabled = false;
                frmFcProfExp2 exp = new frmFcProfExp2();
                this.Hide();
                exp.Show();
            }
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgTmpOVCli_ChangeUICues(object sender, UICuesEventArgs e)
        {
        }

        private void dgTmpOVCli_Click(object sender, EventArgs e)
        {
            if (this.DS.Tables[Variables.gTermi + "TmpOVCli"].Rows.Count != 0)
            {
                Variables.gNroOV = StringType.FromObject(this.dgTmpOVCli[this.dgTmpOVCli.CurrentCell.RowNumber, 0]);
                Variables.gSalir = false;
                new frmFcProfExp3().ShowDialog();
                if (!Variables.gSalir)
                {
                    this.GroupBox1.Visible = true;
                    this.txtNroOV.Text = StringType.FromObject(this.dgTmpOVCli[this.dgTmpOVCli.CurrentCell.RowNumber, 0]);
                    this.mAlmacen = StringType.FromObject(this.dgTmpOVCli[this.dgTmpOVCli.CurrentCell.RowNumber, 1]);
                    this.txtNomAlmacen.Text = StringType.FromObject(this.dgTmpOVCli[this.dgTmpOVCli.CurrentCell.RowNumber, 2]);
                    this.txtMoneda.Text = StringType.FromObject(this.dgTmpOVCli[this.dgTmpOVCli.CurrentCell.RowNumber, 3]);
                    this.mCondPago = StringType.FromObject(this.dgTmpOVCli[this.dgTmpOVCli.CurrentCell.RowNumber, 4]);
                    this.mCondEnt = StringType.FromObject(this.dgTmpOVCli[this.dgTmpOVCli.CurrentCell.RowNumber, 5]);
                    this.editFlete.Text = "";
                    this.editFlete.Focus();
                }
                else
                {
                    this.GroupBox1.Visible = false;
                    this.txtNroOV.Text = "";
                    this.mAlmacen = "";
                    this.txtNomAlmacen.Text = "";
                    this.txtMoneda.Text = "";
                    this.mCondPago = "";
                    this.mCondEnt = "";
                    this.editFlete.Text = "";
                }
            }
        }

        private void dgTmpOVCli_Navigate(object sender, NavigateEventArgs ne)
        {
        }

        private void dgTmpOVFcProExp_DoubleClick(object sender, EventArgs e)
        {
            bool flag = false;
            if ((this.DS.Tables[Variables.gTermi + "TmpOVFCProExp"].Rows.Count != 0) && (Interaction.MsgBox("Desea eliminar esta OV", 4, "Operador") == 6))
            {
                SqlConnection connection;
                string str3;
                try
                {
                    str3 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                    connection = new SqlConnection(str3);
                    connection.Open();
                    flag = true;
                    SqlCommand command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpOVCli (NroOV,Almacen,NomAlmacen,Moneda,CondPago,CondEnt) values ('", this.dgTmpOVFcProExp[this.dgTmpOVFcProExp.CurrentCell.RowNumber, 0]), "','"), this.dgTmpOVFcProExp[this.dgTmpOVFcProExp.CurrentCell.RowNumber, 1]), "','"), this.dgTmpOVFcProExp[this.dgTmpOVFcProExp.CurrentCell.RowNumber, 2]), "','"), this.dgTmpOVFcProExp[this.dgTmpOVFcProExp.CurrentCell.RowNumber, 4]), "','"), this.dgTmpOVFcProExp[this.dgTmpOVFcProExp.CurrentCell.RowNumber, 6]), "','"), this.dgTmpOVFcProExp[this.dgTmpOVFcProExp.CurrentCell.RowNumber, 7]), "')")), connection);
                    int num = command.ExecuteNonQuery();
                    command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("delete " + Variables.gTermi + "TmpOVFcProExp where NroOV='", this.dgTmpOVFcProExp[this.dgTmpOVFcProExp.CurrentCell.RowNumber, 0]), "'")), connection);
                    num = command.ExecuteNonQuery();
                    num = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("update " + Variables.gTermi + "TmpItemFcProExp set Seleccion=0 where NroOV='", this.dgTmpOVFcProExp[this.dgTmpOVFcProExp.CurrentCell.RowNumber, 0]), "'")), connection).ExecuteNonQuery();
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
                    ProjectData.ClearProjectError();
                    return;
                    ProjectData.ClearProjectError();
                }
                string selectCommandText = "select * from " + Variables.gTermi + "TmpOVCli order by NomAlmacen,NroOV";
                this.Adaptador = new SqlDataAdapter(selectCommandText, str3);
                this.DS.Tables[Variables.gTermi + "TmpOVCli"].Clear();
                this.Adaptador.Fill(this.DS, Variables.gTermi + "TmpOVCli");
                this.dgTmpOVCli.DataSource = this.DS.Tables[Variables.gTermi + "TmpOVCli"];
                this.dgTmpOVCli.Refresh();
                selectCommandText = "select * from " + Variables.gTermi + "TmpOVFcProExp order by NomAlmacen,NroOV";
                this.Adap2 = new SqlDataAdapter(selectCommandText, str3);
                this.DS.Tables[Variables.gTermi + "TmpOVFcProExp"].Clear();
                this.Adap2.Fill(this.DS, Variables.gTermi + "TmpOVFcProExp");
                this.dgTmpOVFcProExp.DataSource = this.DS.Tables[Variables.gTermi + "TmpOVFcProExp"];
                this.dgTmpOVFcProExp.Refresh();
            }
        }

        private void dgTmpOVFcProExp_Navigate(object sender, NavigateEventArgs ne)
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
                this.rbAereo.Focus();
            }
        }

        private void editFlete_TextChanged(object sender, EventArgs e)
        {
        }

        ~frmFcProfExp1()
        {
        }

        private void frmFcProfExp1_Closed(object sender, EventArgs e)
        {
            new frmFcProfExp().Show();
        }

        private void frmFcProfExp1_Load(object sender, EventArgs e)
        {
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
            string selectCommandText = "select * from " + Variables.gTermi + "TmpOVCli order by NomAlmacen,NroOV";
            this.Adaptador = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.DS.Clear();
            this.Adaptador.Fill(this.DS, Variables.gTermi + "TmpOVCli");
            this.dgTmpOVCli.DataSource = this.DS.Tables[Variables.gTermi + "TmpOVCli"];
            DataGridTableStyle table = new DataGridTableStyle();
            table.MappingName = Variables.gTermi + "TmpOVCli";
            DataGridTextBoxColumn column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column16 = column;
            column16.HeaderText = "Nro. OV";
            column16.MappingName = "NroOV";
            column16.Alignment = HorizontalAlignment.Center;
            column16.Width = 100;
            column16 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column15 = column;
            column15.HeaderText = "";
            column15.MappingName = "Almacen";
            column15.Width = 0;
            column15 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column14 = column;
            column14.HeaderText = "Almac\x00e9n";
            column14.MappingName = "NomAlmacen";
            column14.Width = 250;
            column14 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column13 = column;
            column13.HeaderText = "";
            column13.MappingName = "Moneda";
            column13.Width = 0;
            column13 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column12 = column;
            column12.HeaderText = "";
            column12.MappingName = "CondPago";
            column12.Width = 0;
            column12 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column11 = column;
            column11.HeaderText = "";
            column11.MappingName = "CondEnt";
            column11.Width = 0;
            column11 = null;
            table.GridColumnStyles.Add(column);
            this.dgTmpOVCli.TableStyles.Add(table);
            this.dgTmpOVCli.Refresh();
            selectCommandText = "select * from " + Variables.gTermi + "TmpOVFcProExp order by NomAlmacen,NroOV";
            this.Adap2 = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.Adap2.Fill(this.DS, Variables.gTermi + "TmpOVFcProExp");
            this.dgTmpOVFcProExp.DataSource = this.DS.Tables[Variables.gTermi + "TmpOVFcProExp"];
            this.dgTmpOVFcProExp.Refresh();
            DataGridTableStyle style2 = new DataGridTableStyle();
            style2.MappingName = Variables.gTermi + "TmpOVFcProExp";
            DataGridTextBoxColumn column2 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column10 = column2;
            column10.HeaderText = "Nro. OV";
            column10.MappingName = "NroOV";
            column10.Alignment = HorizontalAlignment.Center;
            column10.Width = 100;
            column10 = null;
            style2.GridColumnStyles.Add(column2);
            column2 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column9 = column2;
            column9.HeaderText = "";
            column9.MappingName = "Almacen";
            column9.Width = 0;
            column9 = null;
            style2.GridColumnStyles.Add(column2);
            column2 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column8 = column2;
            column8.HeaderText = "Almac\x00e9n";
            column8.MappingName = "NomAlmacen";
            column8.Width = 250;
            column8 = null;
            style2.GridColumnStyles.Add(column2);
            column2 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column7 = column2;
            column7.HeaderText = "Flete";
            column7.MappingName = "Flete";
            column7.Format = "######0.00";
            column7.Alignment = HorizontalAlignment.Right;
            column7.Width = 80;
            column7 = null;
            style2.GridColumnStyles.Add(column2);
            column2 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column6 = column2;
            column6.HeaderText = "Moneda";
            column6.MappingName = "Moneda";
            column6.Alignment = HorizontalAlignment.Center;
            column6.Width = 80;
            column6 = null;
            style2.GridColumnStyles.Add(column2);
            column2 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column5 = column2;
            column5.HeaderText = "Tipo Flete";
            column5.MappingName = "Tipo";
            column5.Alignment = HorizontalAlignment.Center;
            column5.Width = 0x4b;
            column5 = null;
            style2.GridColumnStyles.Add(column2);
            column2 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column4 = column2;
            column4.HeaderText = "";
            column4.MappingName = "CondPago";
            column4.Width = 0;
            column4 = null;
            style2.GridColumnStyles.Add(column2);
            column2 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column3 = column2;
            column3.HeaderText = "";
            column3.MappingName = "CondEnt";
            column3.Width = 0;
            column3 = null;
            style2.GridColumnStyles.Add(column2);
            this.dgTmpOVFcProExp.TableStyles.Add(style2);
            this.dgTmpOVFcProExp.Refresh();
            this.txtCliente.Text = Variables.gNomCli;
        }

        private void ImpFcProf()
        {
            ReportDocument document = new ReportDocument();
            DataSet dataSet = new DataSet();
            try
            {
                string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
                dataSet.Clear();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from OR010100 where OR01002<>6 and OR01004='" + Variables.gCodCli + "'", selectConnectionString);
                string selectCommandText = "SELECT * FROM dbo.OR030100";
                SqlDataAdapter adapter2 = new SqlDataAdapter(selectCommandText, selectConnectionString);
                selectCommandText = "SELECT * FROM dbo.OR040100";
                SqlDataAdapter adapter3 = new SqlDataAdapter(selectCommandText, selectConnectionString);
                SqlDataAdapter adapter4 = new SqlDataAdapter("SELECT * from SL010100 where SL01001='" + Variables.gCodCli + "'", selectConnectionString);
                adapter.Fill(dataSet, "OR010100");
                adapter2.Fill(dataSet, "OR030100");
                adapter3.Fill(dataSet, "OR040100");
                adapter4.Fill(dataSet, "SL010100");
                string str3 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
                new SqlDataAdapter("select * from " + Variables.gTermi + "TmpOVFcProExp as PC1TmpOVFcProExp", str3).Fill(dataSet, "PC1TmpOVFcProExp");
                document.Load(Application.StartupPath + @"\fcprofexp.rpt");
                document.SetDataSource(dataSet);
                document.PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                ProjectData.ClearProjectError();
            }
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.cmbSalir = new Button();
            this.dgTmpOVCli = new DataGrid();
            this.Label6 = new Label();
            this.txtCliente = new TextBox();
            this.Label2 = new Label();
            this.editFlete = new TextBox();
            this.cmbAceptar = new Button();
            this.Label3 = new Label();
            this.txtNomAlmacen = new TextBox();
            this.Label1 = new Label();
            this.txtNroOV = new TextBox();
            this.txtMoneda = new TextBox();
            this.rbAereo = new RadioButton();
            this.rbTerrestre = new RadioButton();
            this.rbCourier = new RadioButton();
            this.GroupBox1 = new GroupBox();
            this.rbMaritimo = new RadioButton();
            this.btnIngresar = new Button();
            this.dgTmpOVFcProExp = new DataGrid();
            this.dgTmpOVCli.BeginInit();
            this.GroupBox1.SuspendLayout();
            this.dgTmpOVFcProExp.BeginInit();
            this.SuspendLayout();
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            this.cmbSalir.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Point point = new Point(0x298, 0x260);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            Size size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 6;
            this.cmbSalir.Text = "C&ancelar";
            this.dgTmpOVCli.CaptionFont = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dgTmpOVCli.CaptionText = "Ordenes de Venta";
            this.dgTmpOVCli.DataMember = "";
            this.dgTmpOVCli.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dgTmpOVCli.HeaderForeColor = SystemColors.ControlText;
            point = new Point(8, 0x38);
            this.dgTmpOVCli.Location = point;
            this.dgTmpOVCli.Name = "dgTmpOVCli";
            this.dgTmpOVCli.ReadOnly = true;
            size = new Size(0x278, 0x120);
            this.dgTmpOVCli.Size = size;
            this.dgTmpOVCli.TabIndex = 2;
            this.Label6.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x10);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(0x38, 20);
            this.Label6.Size = size;
            this.Label6.TabIndex = 0;
            this.Label6.Text = "Cliente:";
            this.txtCliente.BackColor = SystemColors.Window;
            this.txtCliente.Enabled = false;
            this.txtCliente.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x48, 0x10);
            this.txtCliente.Location = point;
            this.txtCliente.MaxLength = 0x23;
            this.txtCliente.Name = "txtCliente";
            size = new Size(0x238, 0x16);
            this.txtCliente.Size = size;
            this.txtCliente.TabIndex = 1;
            this.txtCliente.Text = "";
            this.Label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x38);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x38, 20);
            this.Label2.Size = size;
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Flete:";
            this.editFlete.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x48, 0x38);
            this.editFlete.Location = point;
            this.editFlete.MaxLength = 10;
            this.editFlete.Name = "editFlete";
            size = new Size(80, 0x16);
            this.editFlete.Size = size;
            this.editFlete.TabIndex = 5;
            this.editFlete.Text = "";
            this.cmbAceptar.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x298, 0x298);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 5;
            this.cmbAceptar.Text = "&Terminar";
            point = new Point(0xb8, 0x18);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x40, 0x10);
            this.Label3.Size = size;
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Almac\x00e9n:";
            this.txtNomAlmacen.BackColor = SystemColors.Window;
            this.txtNomAlmacen.Enabled = false;
            point = new Point(0x100, 0x18);
            this.txtNomAlmacen.Location = point;
            this.txtNomAlmacen.MaxLength = 0x23;
            this.txtNomAlmacen.Name = "txtNomAlmacen";
            size = new Size(0x170, 0x16);
            this.txtNomAlmacen.Size = size;
            this.txtNomAlmacen.TabIndex = 3;
            this.txtNomAlmacen.Text = "";
            point = new Point(8, 0x18);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x40, 0x10);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Nro.OV:";
            this.txtNroOV.BackColor = SystemColors.Window;
            this.txtNroOV.Enabled = false;
            point = new Point(0x48, 0x18);
            this.txtNroOV.Location = point;
            this.txtNroOV.MaxLength = 10;
            this.txtNroOV.Name = "txtNroOV";
            size = new Size(0x68, 0x16);
            this.txtNroOV.Size = size;
            this.txtNroOV.TabIndex = 1;
            this.txtNroOV.Text = "";
            this.txtMoneda.BackColor = SystemColors.Window;
            this.txtMoneda.Enabled = false;
            point = new Point(160, 0x38);
            this.txtMoneda.Location = point;
            this.txtMoneda.MaxLength = 3;
            this.txtMoneda.Name = "txtMoneda";
            size = new Size(40, 0x16);
            this.txtMoneda.Size = size;
            this.txtMoneda.TabIndex = 6;
            this.txtMoneda.Text = "";
            point = new Point(0xd0, 0x38);
            this.rbAereo.Location = point;
            this.rbAereo.Name = "rbAereo";
            size = new Size(0x40, 0x18);
            this.rbAereo.Size = size;
            this.rbAereo.TabIndex = 7;
            this.rbAereo.Text = "Aereo";
            point = new Point(280, 0x38);
            this.rbTerrestre.Location = point;
            this.rbTerrestre.Name = "rbTerrestre";
            size = new Size(80, 0x18);
            this.rbTerrestre.Size = size;
            this.rbTerrestre.TabIndex = 8;
            this.rbTerrestre.Text = "Terrestre";
            point = new Point(450, 0x38);
            this.rbCourier.Location = point;
            this.rbCourier.Name = "rbCourier";
            size = new Size(0x48, 0x18);
            this.rbCourier.Size = size;
            this.rbCourier.TabIndex = 10;
            this.rbCourier.Text = "Courier";
            this.GroupBox1.Controls.Add(this.rbMaritimo);
            this.GroupBox1.Controls.Add(this.btnIngresar);
            this.GroupBox1.Controls.Add(this.editFlete);
            this.GroupBox1.Controls.Add(this.rbAereo);
            this.GroupBox1.Controls.Add(this.txtMoneda);
            this.GroupBox1.Controls.Add(this.rbTerrestre);
            this.GroupBox1.Controls.Add(this.rbCourier);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.txtNomAlmacen);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.txtNroOV);
            this.GroupBox1.Controls.Add(this.Label2);
            point = new Point(8, 0x160);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(0x278, 0x68);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 3;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Visible = false;
            point = new Point(0x16a, 0x38);
            this.rbMaritimo.Location = point;
            this.rbMaritimo.Name = "rbMaritimo";
            size = new Size(80, 0x18);
            this.rbMaritimo.Size = size;
            this.rbMaritimo.TabIndex = 9;
            this.rbMaritimo.Text = "Mar\x00edtimo";
            this.btnIngresar.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x210, 0x38);
            this.btnIngresar.Location = point;
            this.btnIngresar.Name = "btnIngresar";
            size = new Size(0x60, 0x20);
            this.btnIngresar.Size = size;
            this.btnIngresar.TabIndex = 11;
            this.btnIngresar.Text = "&Ingresar";
            this.dgTmpOVFcProExp.CaptionFont = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dgTmpOVFcProExp.CaptionText = "Ordenes de Venta Seleccionadas";
            this.dgTmpOVFcProExp.DataMember = "";
            this.dgTmpOVFcProExp.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dgTmpOVFcProExp.HeaderForeColor = SystemColors.ControlText;
            point = new Point(8, 0x1d0);
            this.dgTmpOVFcProExp.Location = point;
            this.dgTmpOVFcProExp.Name = "dgTmpOVFcProExp";
            this.dgTmpOVFcProExp.ReadOnly = true;
            size = new Size(0x278, 0xf8);
            this.dgTmpOVFcProExp.Size = size;
            this.dgTmpOVFcProExp.TabIndex = 4;
            size = new Size(6, 15);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x404, 0x2d5);
            this.ClientSize = size;
            this.Controls.Add(this.dgTmpOVFcProExp);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.dgTmpOVCli);
            this.Controls.Add(this.cmbSalir);
            this.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Name = "frmFcProfExp1";
            this.Text = "Facturas Proforma Exportaci\x00f3n";
            this.WindowState = FormWindowState.Maximized;
            this.dgTmpOVCli.EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.dgTmpOVFcProExp.EndInit();
            this.ResumeLayout(false);
        }

        private void rbAereo_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbAereo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.btnIngresar.Focus();
            }
        }

        private void rbCourier_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbCourier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.btnIngresar.Focus();
            }
        }

        private void rbMaritimo_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbMaritimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.btnIngresar.Focus();
            }
        }

        private void rbTerrestre_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbTerrestre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.btnIngresar.Focus();
            }
        }

        internal virtual Button btnIngresar
        {
            get
            {
                return this._btnIngresar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnIngresar != null)
                {
                    this._btnIngresar.Click -= new EventHandler(this.btnIngresar_Click);
                }
                this._btnIngresar = value;
                if (this._btnIngresar != null)
                {
                    this._btnIngresar.Click += new EventHandler(this.btnIngresar_Click);
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

        internal virtual DataGrid dgTmpOVCli
        {
            get
            {
                return this._dgTmpOVCli;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dgTmpOVCli != null)
                {
                    this._dgTmpOVCli.ChangeUICues -= new UICuesEventHandler(this.dgTmpOVCli_ChangeUICues);
                    this._dgTmpOVCli.Navigate -= new NavigateEventHandler(this.dgTmpOVCli_Navigate);
                    this._dgTmpOVCli.Click -= new EventHandler(this.dgTmpOVCli_Click);
                }
                this._dgTmpOVCli = value;
                if (this._dgTmpOVCli != null)
                {
                    this._dgTmpOVCli.ChangeUICues += new UICuesEventHandler(this.dgTmpOVCli_ChangeUICues);
                    this._dgTmpOVCli.Navigate += new NavigateEventHandler(this.dgTmpOVCli_Navigate);
                    this._dgTmpOVCli.Click += new EventHandler(this.dgTmpOVCli_Click);
                }
            }
        }

        internal virtual DataGrid dgTmpOVFcProExp
        {
            get
            {
                return this._dgTmpOVFcProExp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dgTmpOVFcProExp != null)
                {
                    this._dgTmpOVFcProExp.DoubleClick -= new EventHandler(this.dgTmpOVFcProExp_DoubleClick);
                    this._dgTmpOVFcProExp.Navigate -= new NavigateEventHandler(this.dgTmpOVFcProExp_Navigate);
                }
                this._dgTmpOVFcProExp = value;
                if (this._dgTmpOVFcProExp != null)
                {
                    this._dgTmpOVFcProExp.DoubleClick += new EventHandler(this.dgTmpOVFcProExp_DoubleClick);
                    this._dgTmpOVFcProExp.Navigate += new NavigateEventHandler(this.dgTmpOVFcProExp_Navigate);
                }
            }
        }

        internal virtual TextBox editFlete
        {
            get
            {
                return this._editFlete;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editFlete != null)
                {
                    this._editFlete.TextChanged -= new EventHandler(this.editFlete_TextChanged);
                    this._editFlete.KeyPress -= new KeyPressEventHandler(this.editCantEti_KeyPress);
                }
                this._editFlete = value;
                if (this._editFlete != null)
                {
                    this._editFlete.TextChanged += new EventHandler(this.editFlete_TextChanged);
                    this._editFlete.KeyPress += new KeyPressEventHandler(this.editCantEti_KeyPress);
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

        internal virtual RadioButton rbAereo
        {
            get
            {
                return this._rbAereo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbAereo != null)
                {
                    this._rbAereo.CheckedChanged -= new EventHandler(this.rbAereo_CheckedChanged);
                    this._rbAereo.KeyPress -= new KeyPressEventHandler(this.rbAereo_KeyPress);
                }
                this._rbAereo = value;
                if (this._rbAereo != null)
                {
                    this._rbAereo.CheckedChanged += new EventHandler(this.rbAereo_CheckedChanged);
                    this._rbAereo.KeyPress += new KeyPressEventHandler(this.rbAereo_KeyPress);
                }
            }
        }

        internal virtual RadioButton rbCourier
        {
            get
            {
                return this._rbCourier;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbCourier != null)
                {
                    this._rbCourier.KeyPress -= new KeyPressEventHandler(this.rbCourier_KeyPress);
                    this._rbCourier.CheckedChanged -= new EventHandler(this.rbCourier_CheckedChanged);
                }
                this._rbCourier = value;
                if (this._rbCourier != null)
                {
                    this._rbCourier.KeyPress += new KeyPressEventHandler(this.rbCourier_KeyPress);
                    this._rbCourier.CheckedChanged += new EventHandler(this.rbCourier_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbMaritimo
        {
            get
            {
                return this._rbMaritimo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbMaritimo != null)
                {
                    this._rbMaritimo.KeyPress -= new KeyPressEventHandler(this.rbMaritimo_KeyPress);
                    this._rbMaritimo.CheckedChanged -= new EventHandler(this.rbMaritimo_CheckedChanged);
                }
                this._rbMaritimo = value;
                if (this._rbMaritimo != null)
                {
                    this._rbMaritimo.KeyPress += new KeyPressEventHandler(this.rbMaritimo_KeyPress);
                    this._rbMaritimo.CheckedChanged += new EventHandler(this.rbMaritimo_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbTerrestre
        {
            get
            {
                return this._rbTerrestre;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbTerrestre != null)
                {
                    this._rbTerrestre.KeyPress -= new KeyPressEventHandler(this.rbTerrestre_KeyPress);
                    this._rbTerrestre.CheckedChanged -= new EventHandler(this.rbTerrestre_CheckedChanged);
                }
                this._rbTerrestre = value;
                if (this._rbTerrestre != null)
                {
                    this._rbTerrestre.KeyPress += new KeyPressEventHandler(this.rbTerrestre_KeyPress);
                    this._rbTerrestre.CheckedChanged += new EventHandler(this.rbTerrestre_CheckedChanged);
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

        internal virtual TextBox txtMoneda
        {
            get
            {
                return this._txtMoneda;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtMoneda != null)
                {
                }
                this._txtMoneda = value;
                if (this._txtMoneda != null)
                {
                }
            }
        }

        internal virtual TextBox txtNomAlmacen
        {
            get
            {
                return this._txtNomAlmacen;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtNomAlmacen != null)
                {
                }
                this._txtNomAlmacen = value;
                if (this._txtNomAlmacen != null)
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

