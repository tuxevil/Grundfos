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
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmGenOCExp : Form
    {
        [AccessedThroughProperty("btnCancelar")]
        private Button _btnCancelar;
        [AccessedThroughProperty("btnContinuar")]
        private Button _btnContinuar;
        [AccessedThroughProperty("cbProveedor")]
        private ComboBox _cbProveedor;
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dtpFechaOC")]
        private DateTimePicker _dtpFechaOC;
        [AccessedThroughProperty("editNroOV")]
        private TextBox _editNroOV;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
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
        [AccessedThroughProperty("Label7")]
        private Label _Label7;
        [AccessedThroughProperty("txtCliente")]
        private TextBox _txtCliente;
        [AccessedThroughProperty("txtDirEnt1")]
        private TextBox _txtDirEnt1;
        [AccessedThroughProperty("txtDirEnt2")]
        private TextBox _txtDirEnt2;
        [AccessedThroughProperty("txtDirEnt3")]
        private TextBox _txtDirEnt3;
        [AccessedThroughProperty("txtDirEnt4")]
        private TextBox _txtDirEnt4;
        [AccessedThroughProperty("txtDirEnt5")]
        private TextBox _txtDirEnt5;
        [AccessedThroughProperty("txtFechaEntDes")]
        private TextBox _txtFechaEntDes;
        [AccessedThroughProperty("txtMetEnv")]
        private TextBox _txtMetEnv;
        [AccessedThroughProperty("txtNomCli")]
        private TextBox _txtNomCli;
        [AccessedThroughProperty("txtNomMetEnv")]
        private TextBox _txtNomMetEnv;
        public SqlDataAdapter AdapProveedor;
        private IContainer components;
        public DataSet DS;
        public bool gErrorAct;

        public frmGenOCExp()
        {
            base.Closed += new EventHandler(this.frmGenOCExp_Closed);
            base.Load += new EventHandler(this.frmGenOCExp_Load);
            this.DS = new DataSet();
            this.InitializeComponent();
        }

        private void ActTmp()
        {
            DataSet dataSet = new DataSet();
            SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
            connection.Open();
            SqlConnection connection2 = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
            connection2.Open();
            int num3 = new SqlCommand("delete " + Variables.gTermi + "TmpOCompraExp", connection2).ExecuteNonQuery();
            SqlCommand command3 = new SqlCommand("delete " + Variables.gTermi + "TmpOCGen", connection2);
            num3 = command3.ExecuteNonQuery();
            SqlCommand command2 = new SqlCommand("Select OR01016,OR01004,SL01002,OR01014,PL23004,OR04002,OR04003,OR04004,OR04005,OR04008,OR01050 from OR010100 left outer join OR040100 on OR010100.OR01001=OR040100.OR04001 inner join SL010100 on OR010100.OR01004=SL010100.SL01001 inner join PL230100 on OR010100.OR01014=convert(int,PL230100.PL23003) where OR01001='" + this.editNroOV.Text + "' and PL23001='2' and PL23002='00'", connection);
            command2.CommandTimeout = 900;
            dataSet.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command2;
            adapter.Fill(dataSet, "OR010100");
            if (dataSet.Tables["OR010100"].Rows.Count == 0)
            {
                Interaction.MsgBox("O.Venta inexistente", MsgBoxStyle.Critical, "Operador");
                this.gErrorAct = true;
                connection.Close();
                connection2.Close();
                this.editNroOV.Text = "";
                this.editNroOV.Enabled = true;
                this.cbProveedor.Enabled = true;
                this.cbProveedor.Text = "";
                this.cbProveedor.SelectedValue = "";
                this.editNroOV.Focus();
            }
            else
            {
                DataRow row = dataSet.Tables["OR010100"].Rows[0];
                this.dtpFechaOC.Value = DateType.FromObject(row["OR01016"]);
                this.txtCliente.Text = StringType.FromObject(row["OR01004"]);
                this.txtNomCli.Text = StringType.FromObject(row["SL01002"]);
                this.txtMetEnv.Text = StringType.FromObject(row["OR01014"]);
                this.txtNomMetEnv.Text = StringType.FromObject(row["PL23004"]);
                this.txtDirEnt1.Text = StringType.FromObject(row["OR04002"]);
                this.txtDirEnt2.Text = StringType.FromObject(row["OR04003"]);
                this.txtDirEnt3.Text = StringType.FromObject(row["OR04004"]);
                this.txtDirEnt4.Text = StringType.FromObject(row["OR04005"]);
                this.txtDirEnt5.Text = StringType.FromObject(row["OR04008"]);
                this.txtFechaEntDes.Text = StringType.FromObject(row["OR01016"]);
                Variables.gAlmacen1 = StringType.FromObject(row["OR01050"]);
                command2 = new SqlCommand("SELECT OR03002,OR03005,OR03006,OR03007,OR03011 FROM OR030100  WHERE OR030100.OR03001='" + this.editNroOV.Text + "'", connection);
                command2.CommandTimeout = 900;
                dataSet.Clear();
                SqlDataAdapter adapter2 = new SqlDataAdapter();
                adapter2.SelectCommand = command2;
                adapter2.Fill(dataSet, "OR030100");
                long num4 = dataSet.Tables["OR030100"].Rows.Count - 1;
                for (long i = 0L; i <= num4; i += 1L)
                {
                    row = dataSet.Tables["OR030100"].Rows[(int) i];
                    string str3 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpOCompraExp (NroLinea,Codigo,Descripcion,CantidadOV,CodProv,NomProv,Seleccion) values ('", row["OR03002"]), "','"), row["OR03005"]), "','"), Strings.Trim(StringType.FromObject(row["OR03006"]))), " "), Strings.Trim(StringType.FromObject(row["OR03007"]))), "',"), row["OR03011"]), ",")) + "'", this.cbProveedor.SelectedValue), "',"));
                    int num2 = Strings.InStr(this.cbProveedor.Text, "-", CompareMethod.Text);
                    command3 = new SqlCommand(str3 + "'" + Strings.Mid(this.cbProveedor.Text, num2 + 1) + "',0)", connection2);
                    try
                    {
                        num3 = command3.ExecuteNonQuery();
                    }
                    catch (Exception exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        Exception exception = exception1;
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                        this.gErrorAct = true;
                        connection.Close();
                        connection2.Close();
                        ProjectData.ClearProjectError();
                        return;
                        ProjectData.ClearProjectError();
                    }
                }
                connection.Close();
                connection2.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.GroupBox1.Visible = false;
            this.editNroOV.Enabled = true;
            this.cbProveedor.Enabled = true;
            this.cbProveedor.Text = "";
            this.cbProveedor.SelectedValue = "";
            this.cmbAceptar.Enabled = true;
            this.cmbSalir.Enabled = true;
            this.editNroOV.Text = "";
            this.cbProveedor.Text = "";
            this.cbProveedor.SelectedValue = "";
            this.editNroOV.Focus();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Variables.gNroOV = this.editNroOV.Text;
            Variables.gFechaEntOC = StringType.FromDate(this.dtpFechaOC.Value);
            Variables.gCliente = this.txtCliente.Text;
            Variables.gNomCli = this.txtNomCli.Text;
            Variables.gCodMetEnt = this.txtMetEnv.Text;
            Variables.gDescMetEnt = this.txtNomMetEnv.Text;
            Variables.gDirEnt1 = this.txtDirEnt1.Text;
            Variables.gDirEnt2 = this.txtDirEnt2.Text;
            Variables.gDirEnt3 = this.txtDirEnt3.Text;
            Variables.gDirEnt4 = this.txtDirEnt4.Text;
            Variables.gDirEnt5 = this.txtDirEnt5.Text;
            frmGenOCExp1 exp = new frmGenOCExp1();
            this.Hide();
            exp.Show();
        }

        private void cbProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            if (StringType.StrCmp(this.editNroOV.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe ingresar Nro. O.Venta", MsgBoxStyle.Critical, "Operador");
                this.editNroOV.Focus();
            }
            else if (!Information.IsNumeric(this.editNroOV.Text))
            {
                Interaction.MsgBox("Nro. O.Venta debe ser num\x00e9rico", MsgBoxStyle.Critical, "Operador");
                this.editNroOV.Focus();
            }
            else if (ObjectType.ObjTst(this.cbProveedor.SelectedValue, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe seleccionar Proveedor", MsgBoxStyle.Critical, "Operador");
                this.cbProveedor.Focus();
            }
            else
            {
                this.editNroOV.Enabled = false;
                this.cbProveedor.Enabled = false;
                this.cmbAceptar.Enabled = false;
                this.cmbSalir.Enabled = false;
                this.editNroOV.Text = Strings.Format(Conversion.Val(this.editNroOV.Text), "0000000000");
                this.gErrorAct = false;
                this.ActTmp();
                if (this.gErrorAct)
                {
                    this.editNroOV.Enabled = true;
                    this.cbProveedor.Enabled = true;
                    this.cbProveedor.Text = "";
                    this.cbProveedor.SelectedValue = "";
                    this.cmbAceptar.Enabled = true;
                    this.cmbSalir.Enabled = true;
                }
                else
                {
                    this.GroupBox1.Visible = true;
                    this.dtpFechaOC.Focus();
                }
            }
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void dtpFechaOC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.btnContinuar.Focus();
            }
        }

        private void dtpFechaOC_ValueChanged(object sender, EventArgs e)
        {
        }

        private void editCodProv_TextChanged(object sender, EventArgs e)
        {
        }

        private void editNroOV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cbProveedor.Focus();
            }
        }

        private void editNroOV_TextChanged(object sender, EventArgs e)
        {
        }

        ~frmGenOCExp()
        {
        }

        private void frmGenOCExp_Closed(object sender, EventArgs e)
        {
            new frmMenuOCompra().Show();
        }

        private void frmGenOCExp_Load(object sender, EventArgs e)
        {
            try
            {
                string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
                string selectCommandText = "SELECT ltrim(PL01001)+'-'+ltrim(PL01002) as NomProv,PL01001 FROM dbo.PL010100 order by ltrim(PL01001)+'-'+ltrim(PL01002)";
                this.AdapProveedor = new SqlDataAdapter(selectCommandText, selectConnectionString);
                this.AdapProveedor.Fill(this.DS, "PL010100");
                this.cbProveedor.DataSource = this.DS.Tables["PL010100"];
                this.cbProveedor.DisplayMember = "NomProv";
                this.cbProveedor.ValueMember = "PL01001";
                this.cbProveedor.Refresh();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                this.Close();
                ProjectData.ClearProjectError();
            }
            this.cbProveedor.Text = "";
            this.cbProveedor.SelectedValue = "";
            this.editNroOV.Focus();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmGenOCExp));
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.Label3 = new Label();
            this.editNroOV = new TextBox();
            this.GroupBox1 = new GroupBox();
            this.txtFechaEntDes = new TextBox();
            this.Label6 = new Label();
            this.txtDirEnt5 = new TextBox();
            this.txtDirEnt4 = new TextBox();
            this.txtDirEnt3 = new TextBox();
            this.txtDirEnt2 = new TextBox();
            this.txtDirEnt1 = new TextBox();
            this.Label5 = new Label();
            this.txtMetEnv = new TextBox();
            this.txtNomMetEnv = new TextBox();
            this.btnCancelar = new Button();
            this.btnContinuar = new Button();
            this.Label1 = new Label();
            this.Label2 = new Label();
            this.txtCliente = new TextBox();
            this.Label4 = new Label();
            this.dtpFechaOC = new DateTimePicker();
            this.txtNomCli = new TextBox();
            this.cbProveedor = new ComboBox();
            this.Label7 = new Label();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            Point point = new Point(0x298, 40);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 4;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(560, 40);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 5;
            this.cmbSalir.Text = "&Salir";
            this.Label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x18);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x60, 0x17);
            this.Label3.Size = size;
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Nro.O.Venta:";
            this.editNroOV.BackColor = SystemColors.Window;
            this.editNroOV.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x68, 0x18);
            this.editNroOV.Location = point;
            this.editNroOV.MaxLength = 10;
            this.editNroOV.Name = "editNroOV";
            size = new Size(0x70, 0x16);
            this.editNroOV.Size = size;
            this.editNroOV.TabIndex = 1;
            this.editNroOV.Text = "";
            this.GroupBox1.Controls.Add(this.txtFechaEntDes);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.txtDirEnt5);
            this.GroupBox1.Controls.Add(this.txtDirEnt4);
            this.GroupBox1.Controls.Add(this.txtDirEnt3);
            this.GroupBox1.Controls.Add(this.txtDirEnt2);
            this.GroupBox1.Controls.Add(this.txtDirEnt1);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.txtMetEnv);
            this.GroupBox1.Controls.Add(this.txtNomMetEnv);
            this.GroupBox1.Controls.Add(this.btnCancelar);
            this.GroupBox1.Controls.Add(this.btnContinuar);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.txtCliente);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.dtpFechaOC);
            this.GroupBox1.Controls.Add(this.txtNomCli);
            this.GroupBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(8, 0x68);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(0x2f0, 0x138);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 6;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Datos Orden de Compra Exportaci\x00f3n";
            this.GroupBox1.Visible = false;
            this.txtFechaEntDes.BackColor = SystemColors.Window;
            this.txtFechaEntDes.Enabled = false;
            this.txtFechaEntDes.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x98, 0xf8);
            this.txtFechaEntDes.Location = point;
            this.txtFechaEntDes.MaxLength = 10;
            this.txtFechaEntDes.Name = "txtFechaEntDes";
            size = new Size(80, 0x16);
            this.txtFechaEntDes.Size = size;
            this.txtFechaEntDes.TabIndex = 15;
            this.txtFechaEntDes.Text = "";
            this.Label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0xf8);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(0x88, 0x10);
            this.Label6.Size = size;
            this.Label6.TabIndex = 14;
            this.Label6.Text = "Fecha Ent. Deseada:";
            this.txtDirEnt5.BackColor = SystemColors.Window;
            this.txtDirEnt5.Enabled = false;
            this.txtDirEnt5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x98, 0xd8);
            this.txtDirEnt5.Location = point;
            this.txtDirEnt5.MaxLength = 0x23;
            this.txtDirEnt5.Name = "txtDirEnt5";
            size = new Size(0x1f0, 0x16);
            this.txtDirEnt5.Size = size;
            this.txtDirEnt5.TabIndex = 13;
            this.txtDirEnt5.Text = "";
            this.txtDirEnt4.BackColor = SystemColors.Window;
            this.txtDirEnt4.Enabled = false;
            this.txtDirEnt4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x98, 0xc0);
            this.txtDirEnt4.Location = point;
            this.txtDirEnt4.MaxLength = 0x23;
            this.txtDirEnt4.Name = "txtDirEnt4";
            size = new Size(0x1f0, 0x16);
            this.txtDirEnt4.Size = size;
            this.txtDirEnt4.TabIndex = 12;
            this.txtDirEnt4.Text = "";
            this.txtDirEnt3.BackColor = SystemColors.Window;
            this.txtDirEnt3.Enabled = false;
            this.txtDirEnt3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x98, 0xa8);
            this.txtDirEnt3.Location = point;
            this.txtDirEnt3.MaxLength = 0x23;
            this.txtDirEnt3.Name = "txtDirEnt3";
            size = new Size(0x1f0, 0x16);
            this.txtDirEnt3.Size = size;
            this.txtDirEnt3.TabIndex = 11;
            this.txtDirEnt3.Text = "";
            this.txtDirEnt2.BackColor = SystemColors.Window;
            this.txtDirEnt2.Enabled = false;
            this.txtDirEnt2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x98, 0x90);
            this.txtDirEnt2.Location = point;
            this.txtDirEnt2.MaxLength = 0x23;
            this.txtDirEnt2.Name = "txtDirEnt2";
            size = new Size(0x1f0, 0x16);
            this.txtDirEnt2.Size = size;
            this.txtDirEnt2.TabIndex = 10;
            this.txtDirEnt2.Text = "";
            this.txtDirEnt1.BackColor = SystemColors.Window;
            this.txtDirEnt1.Enabled = false;
            this.txtDirEnt1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x98, 120);
            this.txtDirEnt1.Location = point;
            this.txtDirEnt1.MaxLength = 0x23;
            this.txtDirEnt1.Name = "txtDirEnt1";
            size = new Size(0x1f0, 0x16);
            this.txtDirEnt1.Size = size;
            this.txtDirEnt1.TabIndex = 9;
            this.txtDirEnt1.Text = "";
            this.Label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 120);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size(120, 0x10);
            this.Label5.Size = size;
            this.Label5.TabIndex = 8;
            this.Label5.Text = "Direcci\x00f3n Entrega:";
            this.txtMetEnv.BackColor = SystemColors.Window;
            this.txtMetEnv.Enabled = false;
            this.txtMetEnv.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x98, 0x58);
            this.txtMetEnv.Location = point;
            this.txtMetEnv.MaxLength = 2;
            this.txtMetEnv.Name = "txtMetEnv";
            size = new Size(0x20, 0x16);
            this.txtMetEnv.Size = size;
            this.txtMetEnv.TabIndex = 6;
            this.txtMetEnv.Text = "";
            this.txtNomMetEnv.BackColor = SystemColors.Window;
            this.txtNomMetEnv.Enabled = false;
            this.txtNomMetEnv.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0xc0, 0x58);
            this.txtNomMetEnv.Location = point;
            this.txtNomMetEnv.MaxLength = 30;
            this.txtNomMetEnv.Name = "txtNomMetEnv";
            size = new Size(0x1c8, 0x16);
            this.txtNomMetEnv.Size = size;
            this.txtNomMetEnv.TabIndex = 7;
            this.txtNomMetEnv.Text = "";
            this.btnCancelar.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x210, 0x100);
            this.btnCancelar.Location = point;
            this.btnCancelar.Name = "btnCancelar";
            size = new Size(0x60, 40);
            this.btnCancelar.Size = size;
            this.btnCancelar.TabIndex = 0x11;
            this.btnCancelar.Text = "&Cancelar";
            this.btnContinuar.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(640, 0x100);
            this.btnContinuar.Location = point;
            this.btnContinuar.Name = "btnContinuar";
            size = new Size(0x60, 40);
            this.btnContinuar.Size = size;
            this.btnContinuar.TabIndex = 0x10;
            this.btnContinuar.Text = "C&ontinuar";
            this.Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x18);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x80, 0x10);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Fecha Entrega OC:";
            this.Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x58);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(120, 0x10);
            this.Label2.Size = size;
            this.Label2.TabIndex = 5;
            this.Label2.Text = "M\x00e9todo Env\x00edo:";
            this.txtCliente.BackColor = SystemColors.Window;
            this.txtCliente.Enabled = false;
            this.txtCliente.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x98, 0x38);
            this.txtCliente.Location = point;
            this.txtCliente.MaxLength = 10;
            this.txtCliente.Name = "txtCliente";
            size = new Size(80, 0x16);
            this.txtCliente.Size = size;
            this.txtCliente.TabIndex = 3;
            this.txtCliente.Text = "";
            this.Label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x38);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(120, 0x10);
            this.Label4.Size = size;
            this.Label4.TabIndex = 2;
            this.Label4.Text = "Cliente:";
            this.dtpFechaOC.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaOC.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaOC.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaOC.Format = DateTimePickerFormat.Short;
            point = new Point(0x98, 0x18);
            this.dtpFechaOC.Location = point;
            this.dtpFechaOC.Name = "dtpFechaOC";
            size = new Size(0x70, 0x16);
            this.dtpFechaOC.Size = size;
            this.dtpFechaOC.TabIndex = 1;
            DateTime time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpFechaOC.Value = time;
            this.txtNomCli.BackColor = SystemColors.Window;
            this.txtNomCli.Enabled = false;
            this.txtNomCli.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(240, 0x38);
            this.txtNomCli.Location = point;
            this.txtNomCli.MaxLength = 0x23;
            this.txtNomCli.Name = "txtNomCli";
            size = new Size(0x1f0, 0x16);
            this.txtNomCli.Size = size;
            this.txtNomCli.TabIndex = 4;
            this.txtNomCli.Text = "";
            this.cbProveedor.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x68, 0x38);
            this.cbProveedor.Location = point;
            this.cbProveedor.Name = "cbProveedor";
            size = new Size(440, 0x18);
            this.cbProveedor.Size = size;
            this.cbProveedor.TabIndex = 3;
            this.cbProveedor.Text = "ComboBox1";
            this.Label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x40);
            this.Label7.Location = point;
            this.Label7.Name = "Label7";
            size = new Size(0x58, 0x10);
            this.Label7.Size = size;
            this.Label7.TabIndex = 2;
            this.Label7.Text = "Proveedor:";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            size = new Size(0x324, 0x242);
            this.ClientSize = size;
            this.Controls.Add(this.cbProveedor);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.editNroOV);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmGenOCExp";
            this.Text = "Generaci\x00f3n Ordenes de Compra Exportaci\x00f3n";
            this.WindowState = FormWindowState.Maximized;
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        internal virtual Button btnCancelar
        {
            get
            {
                return this._btnCancelar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnCancelar != null)
                {
                    this._btnCancelar.Click -= new EventHandler(this.btnCancelar_Click);
                }
                this._btnCancelar = value;
                if (this._btnCancelar != null)
                {
                    this._btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
                }
            }
        }

        internal virtual Button btnContinuar
        {
            get
            {
                return this._btnContinuar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnContinuar != null)
                {
                    this._btnContinuar.Click -= new EventHandler(this.btnModificar_Click);
                }
                this._btnContinuar = value;
                if (this._btnContinuar != null)
                {
                    this._btnContinuar.Click += new EventHandler(this.btnModificar_Click);
                }
            }
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
                    this._cbProveedor.KeyPress -= new KeyPressEventHandler(this.cbProveedor_KeyPress);
                    this._cbProveedor.SelectedIndexChanged -= new EventHandler(this.cbProveedor_SelectedIndexChanged);
                }
                this._cbProveedor = value;
                if (this._cbProveedor != null)
                {
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

        internal virtual DateTimePicker dtpFechaOC
        {
            get
            {
                return this._dtpFechaOC;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpFechaOC != null)
                {
                    this._dtpFechaOC.ValueChanged -= new EventHandler(this.dtpFechaOC_ValueChanged);
                    this._dtpFechaOC.KeyPress -= new KeyPressEventHandler(this.dtpFechaOC_KeyPress);
                }
                this._dtpFechaOC = value;
                if (this._dtpFechaOC != null)
                {
                    this._dtpFechaOC.ValueChanged += new EventHandler(this.dtpFechaOC_ValueChanged);
                    this._dtpFechaOC.KeyPress += new KeyPressEventHandler(this.dtpFechaOC_KeyPress);
                }
            }
        }

        internal virtual TextBox editNroOV
        {
            get
            {
                return this._editNroOV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editNroOV != null)
                {
                    this._editNroOV.KeyPress -= new KeyPressEventHandler(this.editNroOV_KeyPress);
                    this._editNroOV.TextChanged -= new EventHandler(this.editNroOV_TextChanged);
                }
                this._editNroOV = value;
                if (this._editNroOV != null)
                {
                    this._editNroOV.KeyPress += new KeyPressEventHandler(this.editNroOV_KeyPress);
                    this._editNroOV.TextChanged += new EventHandler(this.editNroOV_TextChanged);
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

        internal virtual Label Label7
        {
            get
            {
                return this._Label7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label7 != null)
                {
                }
                this._Label7 = value;
                if (this._Label7 != null)
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
                    this._txtCliente.TextChanged -= new EventHandler(this.editCodProv_TextChanged);
                }
                this._txtCliente = value;
                if (this._txtCliente != null)
                {
                    this._txtCliente.TextChanged += new EventHandler(this.editCodProv_TextChanged);
                }
            }
        }

        internal virtual TextBox txtDirEnt1
        {
            get
            {
                return this._txtDirEnt1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtDirEnt1 != null)
                {
                }
                this._txtDirEnt1 = value;
                if (this._txtDirEnt1 != null)
                {
                }
            }
        }

        internal virtual TextBox txtDirEnt2
        {
            get
            {
                return this._txtDirEnt2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtDirEnt2 != null)
                {
                }
                this._txtDirEnt2 = value;
                if (this._txtDirEnt2 != null)
                {
                }
            }
        }

        internal virtual TextBox txtDirEnt3
        {
            get
            {
                return this._txtDirEnt3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtDirEnt3 != null)
                {
                }
                this._txtDirEnt3 = value;
                if (this._txtDirEnt3 != null)
                {
                }
            }
        }

        internal virtual TextBox txtDirEnt4
        {
            get
            {
                return this._txtDirEnt4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtDirEnt4 != null)
                {
                }
                this._txtDirEnt4 = value;
                if (this._txtDirEnt4 != null)
                {
                }
            }
        }

        internal virtual TextBox txtDirEnt5
        {
            get
            {
                return this._txtDirEnt5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtDirEnt5 != null)
                {
                }
                this._txtDirEnt5 = value;
                if (this._txtDirEnt5 != null)
                {
                }
            }
        }

        internal virtual TextBox txtFechaEntDes
        {
            get
            {
                return this._txtFechaEntDes;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtFechaEntDes != null)
                {
                }
                this._txtFechaEntDes = value;
                if (this._txtFechaEntDes != null)
                {
                }
            }
        }

        internal virtual TextBox txtMetEnv
        {
            get
            {
                return this._txtMetEnv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtMetEnv != null)
                {
                }
                this._txtMetEnv = value;
                if (this._txtMetEnv != null)
                {
                }
            }
        }

        internal virtual TextBox txtNomCli
        {
            get
            {
                return this._txtNomCli;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtNomCli != null)
                {
                }
                this._txtNomCli = value;
                if (this._txtNomCli != null)
                {
                }
            }
        }

        internal virtual TextBox txtNomMetEnv
        {
            get
            {
                return this._txtNomMetEnv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtNomMetEnv != null)
                {
                }
                this._txtNomMetEnv = value;
                if (this._txtNomMetEnv != null)
                {
                }
            }
        }
    }
}

