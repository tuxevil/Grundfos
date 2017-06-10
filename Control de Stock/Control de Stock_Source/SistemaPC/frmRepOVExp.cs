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

    public class frmRepOVExp : Form
    {
        [AccessedThroughProperty("btnBusqNom")]
        private Button _btnBusqNom;
        [AccessedThroughProperty("cbAlmacen1")]
        private ComboBox _cbAlmacen1;
        [AccessedThroughProperty("cbAlmacen2")]
        private ComboBox _cbAlmacen2;
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("editCodCli")]
        private TextBox _editCodCli;
        [AccessedThroughProperty("editDescCli")]
        private TextBox _editDescCli;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;
        [AccessedThroughProperty("GroupBox3")]
        private GroupBox _GroupBox3;
        [AccessedThroughProperty("GroupBox4")]
        private GroupBox _GroupBox4;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("Label6")]
        private Label _Label6;
        [AccessedThroughProperty("rbCliBloq")]
        private RadioButton _rbCliBloq;
        [AccessedThroughProperty("rbCliExc")]
        private RadioButton _rbCliExc;
        [AccessedThroughProperty("rbOrdenFechaConf")]
        private RadioButton _rbOrdenFechaConf;
        [AccessedThroughProperty("rbOrdenOCCliente")]
        private RadioButton _rbOrdenOCCliente;
        [AccessedThroughProperty("rbTodas")]
        private RadioButton _rbTodas;
        private IContainer components;

        public frmRepOVExp()
        {
            base.Closed += new EventHandler(this.frmRepOVExp_Closed);
            base.Load += new EventHandler(this.frmRepOVExp_Load);
            this.InitializeComponent();
        }

        private void btnBusqNom_Click(object sender, EventArgs e)
        {
            new frmBusqClixNom().ShowDialog();
            if (DoubleType.FromString(Variables.gCodCli) == 0.0)
            {
                this.editCodCli.Text = "";
            }
            else
            {
                this.editCodCli.Text = Variables.gCodCli;
            }
            this.editDescCli.Text = Variables.gNomCli;
        }

        private void cbAlmacen1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cbAlmacen2.Focus();
            }
        }

        private void cbAlmacen1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbAlmacen2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editCodCli.Focus();
            }
        }

        private void cbAlmacen2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            DataSet set = new DataSet();
            DataSet dataSet = new DataSet();
            if ((StringType.StrCmp(this.editCodCli.Text, Strings.Space(0), false) != 0) && (StringType.StrCmp(this.editDescCli.Text, Strings.Space(0), false) == 0))
            {
                Interaction.MsgBox("Cliente inexistente", 0x10, "Operador");
                this.editCodCli.Focus();
            }
            else if ((!this.rbTodas.Checked & !this.rbCliBloq.Checked) & !this.rbCliExc.Checked)
            {
                Interaction.MsgBox("Debe indicar Ordenes de Venta a listar", 0x10, "Operador");
                this.rbTodas.Checked = true;
            }
            else if (!this.rbOrdenOCCliente.Checked & !this.rbOrdenFechaConf.Checked)
            {
                Interaction.MsgBox("Debe indicar orden del reporte", 0x10, "Operador");
                this.rbOrdenOCCliente.Checked = true;
            }
            else
            {
                this.editCodCli.Enabled = false;
                this.rbTodas.Enabled = false;
                this.rbCliBloq.Enabled = false;
                this.rbCliExc.Enabled = false;
                this.cmbAceptar.Enabled = false;
                this.cmbSalir.Enabled = false;
                if (StringType.StrCmp(this.cbAlmacen1.Text, Strings.Space(0), false) != 0)
                {
                    Variables.gAlmacen1 = Strings.Mid(StringType.FromObject(this.cbAlmacen1.SelectedValue), 1, 2);
                }
                else
                {
                    Variables.gAlmacen1 = "";
                }
                if (StringType.StrCmp(this.cbAlmacen2.Text, Strings.Space(0), false) != 0)
                {
                    Variables.gAlmacen2 = Strings.Mid(StringType.FromObject(this.cbAlmacen2.SelectedValue), 1, 2);
                }
                else
                {
                    Variables.gAlmacen2 = "";
                }
                Variables.gCodCli = this.editCodCli.Text;
                Variables.gNomCli = this.editDescCli.Text;
                if (this.rbOrdenOCCliente.Checked)
                {
                    Variables.gOrdenList = 1;
                }
                else if (this.rbOrdenFechaConf.Checked)
                {
                    Variables.gOrdenList = 2;
                }
                if (this.rbTodas.Checked)
                {
                    if ((StringType.StrCmp(Variables.gAlmacen1, "", false) != 0) & (StringType.StrCmp(Variables.gAlmacen2, "", false) == 0))
                    {
                        Variables.gTipoList = "Todas las Ordenes de Venta - Almac\x00e9n " + this.cbAlmacen1.Text;
                    }
                    else if ((StringType.StrCmp(Variables.gAlmacen1, "", false) == 0) & (StringType.StrCmp(Variables.gAlmacen2, " ", false) != 0))
                    {
                        Variables.gTipoList = "Todas las Ordenes de Venta - Almac\x00e9n " + this.cbAlmacen2.Text;
                    }
                    else if ((StringType.StrCmp(Variables.gAlmacen1, "", false) != 0) & (StringType.StrCmp(Variables.gAlmacen2, " ", false) != 0))
                    {
                        Variables.gTipoList = "Todas las Ordenes de Venta - Almac\x00e9n " + this.cbAlmacen1.Text + " y Almac\x00e9n " + this.cbAlmacen2.Text;
                    }
                    else
                    {
                        Variables.gTipoList = "Todas las Ordenes de Venta - Todos los Almacenes";
                    }
                    Variables.gOVaListar = 1;
                }
                else if (this.rbCliBloq.Checked)
                {
                    if ((StringType.StrCmp(Variables.gAlmacen1, "", false) != 0) & (StringType.StrCmp(Variables.gAlmacen2, "", false) == 0))
                    {
                        Variables.gTipoList = "Ordenes de Venta de clientes bloqueados - Almac\x00e9n " + Variables.gAlmacen1;
                    }
                    else if ((StringType.StrCmp(Variables.gAlmacen1, "", false) == 0) & (StringType.StrCmp(Variables.gAlmacen2, " ", false) != 0))
                    {
                        Variables.gTipoList = "Ordenes de Venta de clientes bloqueados - Almac\x00e9n " + Variables.gAlmacen2;
                    }
                    else if ((StringType.StrCmp(Variables.gAlmacen1, "", false) != 0) & (StringType.StrCmp(Variables.gAlmacen2, " ", false) != 0))
                    {
                        Variables.gTipoList = "Ordenes de Venta de clientes bloqueados - Almac\x00e9n " + Variables.gAlmacen1 + " y Almac\x00e9n " + Variables.gAlmacen2;
                    }
                    else
                    {
                        Variables.gTipoList = "Ordenes de Venta de clientes bloqueados - Todos los Almacenes";
                    }
                    Variables.gOVaListar = 3;
                }
                else if (this.rbCliExc.Checked)
                {
                    if ((StringType.StrCmp(Variables.gAlmacen1, "", false) != 0) & (StringType.StrCmp(Variables.gAlmacen2, "", false) == 0))
                    {
                        Variables.gTipoList = "Ordenes de Venta de clientes excedidos en l\x00edmite de cr\x00e9dito - Almac\x00e9n " + Variables.gAlmacen1;
                    }
                    else if ((StringType.StrCmp(Variables.gAlmacen1, "", false) == 0) & (StringType.StrCmp(Variables.gAlmacen2, " ", false) != 0))
                    {
                        Variables.gTipoList = "Ordenes de Venta de clientes excedidos en l\x00edmite de cr\x00e9dito - Almac\x00e9n " + Variables.gAlmacen2;
                    }
                    else if ((StringType.StrCmp(Variables.gAlmacen1, "", false) != 0) & (StringType.StrCmp(Variables.gAlmacen2, " ", false) != 0))
                    {
                        Variables.gTipoList = "Ordenes de Venta de clientes excedidos en l\x00edmite de cr\x00e9dito - Almac\x00e9n " + Variables.gAlmacen1 + " y Almac\x00e9n " + Variables.gAlmacen2;
                    }
                    else
                    {
                        Variables.gTipoList = "Ordenes de Venta de clientes excedidos en l\x00edmite de cr\x00e9dito - Todos los Almacenes";
                    }
                    Variables.gOVaListar = 4;
                }
                string connectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlConnection connection2 = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
                connection2.Open();
                SqlCommand command = new SqlCommand("delete " + Variables.gTermi + "TmpFormaDesp", connection2);
                int num2 = command.ExecuteNonQuery();
                string selectCommandText = "SELECT PL23003,PL23004 FROM dbo.PL230100 where PL23001='2' and PL23002='00'";
                new SqlDataAdapter(selectCommandText, connectionString).Fill(dataSet, "PL230100");
                long num3 = dataSet.Tables["PL230100"].Rows.Count - 1;
                for (long i = 0L; i <= num3; i += 1L)
                {
                    DataRow row = dataSet.Tables["PL230100"].Rows[(int) i];
                    command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpFormaDesp (Codigo,Descripcion) values (", row["PL23003"]), ",'"), row["PL23004"]), "')")), connection2);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        Exception exception = exception1;
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                        connection2.Close();
                        ProjectData.ClearProjectError();
                        return;
                        ProjectData.ClearProjectError();
                    }
                }
                connection2.Close();
                frmRepOVExp1 exp = new frmRepOVExp1();
                this.Hide();
                exp.Show();
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

        private void editCodCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.rbTodas.Focus();
            }
        }

        private void editCodCli_LostFocus(object sender, EventArgs e)
        {
            bool flag = false;
            if (StringType.StrCmp(this.editCodCli.Text, Strings.Space(0), false) != 0)
            {
                SqlConnection connection;
                try
                {
                    connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
                    connection.Open();
                    flag = true;
                    SqlDataReader reader = new SqlCommand("SELECT SL01001,SL01002 FROM SL010100 where SL01001='" + this.editCodCli.Text + "'", connection).ExecuteReader();
                    if (reader.Read())
                    {
                        this.editDescCli.Text = StringType.FromObject(reader["SL01002"]);
                        reader.Close();
                    }
                    else
                    {
                        Interaction.MsgBox("Cliente inexistente", 0x40, "Operador");
                        this.editDescCli.Text = "";
                        reader.Close();
                        return;
                    }
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
            }
        }

        private void editCodCli_TextChanged(object sender, EventArgs e)
        {
        }

        ~frmRepOVExp()
        {
        }

        private void frmRepOVExp_Closed(object sender, EventArgs e)
        {
            new frmMenuOVExp().Show();
        }

        private void frmRepOVExp_Load(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            bool flag = false;
            try
            {
                string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
                string selectCommandText = "select ltrim(SC23001)+'-'+ltrim(SC23002) as Almacen from SC230100 order by SC23001";
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnectionString);
                dataSet.Tables.Clear();
                adapter.Fill(dataSet, "SC230100-1");
                this.cbAlmacen1.DataSource = dataSet.Tables["SC230100-1"];
                this.cbAlmacen1.DisplayMember = "Almacen";
                this.cbAlmacen1.ValueMember = "Almacen";
                this.cbAlmacen1.Refresh();
                selectCommandText = "select ltrim(SC23001)+'-'+ltrim(SC23002) as Almacen from SC230100 order by SC23001";
                new SqlDataAdapter(selectCommandText, selectConnectionString).Fill(dataSet, "SC230100-2");
                this.cbAlmacen2.DataSource = dataSet.Tables["SC230100-2"];
                this.cbAlmacen2.DisplayMember = "Almacen";
                this.cbAlmacen2.ValueMember = "Almacen";
                this.cbAlmacen2.Refresh();
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
            this.cbAlmacen1.Text = "";
            this.cbAlmacen1.SelectedValue = "";
            this.cbAlmacen2.Text = "";
            this.cbAlmacen2.SelectedValue = "";
            this.cbAlmacen1.Focus();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.GroupBox1 = new GroupBox();
            this.btnBusqNom = new Button();
            this.Label6 = new Label();
            this.editCodCli = new TextBox();
            this.editDescCli = new TextBox();
            this.GroupBox2 = new GroupBox();
            this.rbCliExc = new RadioButton();
            this.rbCliBloq = new RadioButton();
            this.rbTodas = new RadioButton();
            this.GroupBox3 = new GroupBox();
            this.cbAlmacen2 = new ComboBox();
            this.Label4 = new Label();
            this.cbAlmacen1 = new ComboBox();
            this.Label2 = new Label();
            this.GroupBox4 = new GroupBox();
            this.rbOrdenFechaConf = new RadioButton();
            this.rbOrdenOCCliente = new RadioButton();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            Point point = new Point(0x1f8, 0x178);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 12;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0x1f8, 320);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 13;
            this.cmbSalir.Text = "&Salir";
            this.GroupBox1.Controls.Add(this.btnBusqNom);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.editCodCli);
            this.GroupBox1.Controls.Add(this.editDescCli);
            this.GroupBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x60);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(0x1d8, 0x60);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 9;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Cliente";
            this.btnBusqNom.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0xf8, 0x1d);
            this.btnBusqNom.Location = point;
            this.btnBusqNom.Name = "btnBusqNom";
            size = new Size(0x98, 0x17);
            this.btnBusqNom.Size = size;
            this.btnBusqNom.TabIndex = 3;
            this.btnBusqNom.Text = "&Busqueda por Nombre";
            this.Label6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x1d);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(80, 0x17);
            this.Label6.Size = size;
            this.Label6.TabIndex = 0;
            this.Label6.Text = "Cliente:";
            this.editCodCli.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(120, 0x1d);
            this.editCodCli.Location = point;
            this.editCodCli.MaxLength = 10;
            this.editCodCli.Name = "editCodCli";
            size = new Size(0x70, 20);
            this.editCodCli.Size = size;
            this.editCodCli.TabIndex = 1;
            this.editCodCli.Text = "";
            this.editDescCli.BackColor = SystemColors.Window;
            this.editDescCli.Enabled = false;
            this.editDescCli.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(120, 0x3d);
            this.editDescCli.Location = point;
            this.editDescCli.MaxLength = 0x23;
            this.editDescCli.Name = "editDescCli";
            size = new Size(0x150, 20);
            this.editDescCli.Size = size;
            this.editDescCli.TabIndex = 2;
            this.editDescCli.Text = "";
            this.GroupBox2.Controls.Add(this.rbCliExc);
            this.GroupBox2.Controls.Add(this.rbCliBloq);
            this.GroupBox2.Controls.Add(this.rbTodas);
            this.GroupBox2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x10, 200);
            this.GroupBox2.Location = point;
            this.GroupBox2.Name = "GroupBox2";
            size = new Size(0x1d8, 0x68);
            this.GroupBox2.Size = size;
            this.GroupBox2.TabIndex = 10;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Ordenes de Venta a Listar";
            this.rbCliExc.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x48);
            this.rbCliExc.Location = point;
            this.rbCliExc.Name = "rbCliExc";
            size = new Size(0x110, 0x18);
            this.rbCliExc.Size = size;
            this.rbCliExc.TabIndex = 3;
            this.rbCliExc.Text = "Con Clientes con l\x00edmite de cr\x00e9dito excedido";
            this.rbCliBloq.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x30);
            this.rbCliBloq.Location = point;
            this.rbCliBloq.Name = "rbCliBloq";
            size = new Size(0x98, 0x18);
            this.rbCliBloq.Size = size;
            this.rbCliBloq.TabIndex = 2;
            this.rbCliBloq.Text = "Con Clientes bloqueados";
            this.rbTodas.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x18);
            this.rbTodas.Location = point;
            this.rbTodas.Name = "rbTodas";
            size = new Size(0x98, 0x18);
            this.rbTodas.Size = size;
            this.rbTodas.TabIndex = 0;
            this.rbTodas.Text = "Todas";
            this.GroupBox3.Controls.Add(this.cbAlmacen2);
            this.GroupBox3.Controls.Add(this.Label4);
            this.GroupBox3.Controls.Add(this.cbAlmacen1);
            this.GroupBox3.Controls.Add(this.Label2);
            this.GroupBox3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x10);
            this.GroupBox3.Location = point;
            this.GroupBox3.Name = "GroupBox3";
            size = new Size(0x1d8, 0x48);
            this.GroupBox3.Size = size;
            this.GroupBox3.TabIndex = 8;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Almac\x00e9n";
            this.cbAlmacen2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 40);
            this.cbAlmacen2.Location = point;
            this.cbAlmacen2.Name = "cbAlmacen2";
            size = new Size(0x120, 0x15);
            this.cbAlmacen2.Size = size;
            this.cbAlmacen2.TabIndex = 11;
            this.cbAlmacen2.Text = "ComboBox2";
            this.Label4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x30);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(120, 0x10);
            this.Label4.Size = size;
            this.Label4.TabIndex = 10;
            this.Label4.Text = "Almac\x00e9n:";
            this.cbAlmacen1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x10);
            this.cbAlmacen1.Location = point;
            this.cbAlmacen1.Name = "cbAlmacen1";
            size = new Size(0x120, 0x15);
            this.cbAlmacen1.Size = size;
            this.cbAlmacen1.TabIndex = 9;
            this.cbAlmacen1.Text = "ComboBox1";
            this.Label2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x18);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(120, 0x10);
            this.Label2.Size = size;
            this.Label2.TabIndex = 8;
            this.Label2.Text = "Almac\x00e9n:";
            this.GroupBox4.Controls.Add(this.rbOrdenFechaConf);
            this.GroupBox4.Controls.Add(this.rbOrdenOCCliente);
            this.GroupBox4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x138);
            this.GroupBox4.Location = point;
            this.GroupBox4.Name = "GroupBox4";
            size = new Size(0xd0, 0x58);
            this.GroupBox4.Size = size;
            this.GroupBox4.TabIndex = 11;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Orden Reporte";
            this.rbOrdenFechaConf.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x38);
            this.rbOrdenFechaConf.Location = point;
            this.rbOrdenFechaConf.Name = "rbOrdenFechaConf";
            size = new Size(0xa8, 0x18);
            this.rbOrdenFechaConf.Size = size;
            this.rbOrdenFechaConf.TabIndex = 2;
            this.rbOrdenFechaConf.Text = "Fecha Confirmada";
            this.rbOrdenOCCliente.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x18);
            this.rbOrdenOCCliente.Location = point;
            this.rbOrdenOCCliente.Name = "rbOrdenOCCliente";
            size = new Size(0xa8, 0x18);
            this.rbOrdenOCCliente.Size = size;
            this.rbOrdenOCCliente.TabIndex = 1;
            this.rbOrdenOCCliente.Text = "OC Cliente";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Name = "frmRepOVExp";
            this.Text = "Reporte O.Venta Exportaci\x00f3n";
            this.WindowState = FormWindowState.Maximized;
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void rbCliBloq_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbCliBloq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                if (this.rbCliBloq.Checked)
                {
                    this.cmbAceptar.Focus();
                }
                else
                {
                    this.rbCliExc.Focus();
                }
            }
        }

        private void rbCliExc_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbCliExc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                if (this.rbCliExc.Checked)
                {
                    this.cmbAceptar.Focus();
                }
                else
                {
                    this.rbOrdenOCCliente.Focus();
                }
            }
        }

        private void rbOrdenCliente_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbOrdenCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.rbOrdenFechaConf.Focus();
            }
        }

        private void rbOrdenFechaOV_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbOrdenFechaOV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void rbTodas_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbTodas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                if (this.rbTodas.Checked)
                {
                    this.cmbAceptar.Focus();
                }
                else
                {
                    this.rbCliBloq.Focus();
                }
            }
        }

        internal virtual Button btnBusqNom
        {
            get
            {
                return this._btnBusqNom;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnBusqNom != null)
                {
                    this._btnBusqNom.Click -= new EventHandler(this.btnBusqNom_Click);
                }
                this._btnBusqNom = value;
                if (this._btnBusqNom != null)
                {
                    this._btnBusqNom.Click += new EventHandler(this.btnBusqNom_Click);
                }
            }
        }

        internal virtual ComboBox cbAlmacen1
        {
            get
            {
                return this._cbAlmacen1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cbAlmacen1 != null)
                {
                    this._cbAlmacen1.KeyPress -= new KeyPressEventHandler(this.cbAlmacen1_KeyPress);
                    this._cbAlmacen1.SelectedIndexChanged -= new EventHandler(this.cbAlmacen1_SelectedIndexChanged);
                }
                this._cbAlmacen1 = value;
                if (this._cbAlmacen1 != null)
                {
                    this._cbAlmacen1.KeyPress += new KeyPressEventHandler(this.cbAlmacen1_KeyPress);
                    this._cbAlmacen1.SelectedIndexChanged += new EventHandler(this.cbAlmacen1_SelectedIndexChanged);
                }
            }
        }

        internal virtual ComboBox cbAlmacen2
        {
            get
            {
                return this._cbAlmacen2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cbAlmacen2 != null)
                {
                    this._cbAlmacen2.KeyPress -= new KeyPressEventHandler(this.cbAlmacen2_KeyPress);
                    this._cbAlmacen2.SelectedIndexChanged -= new EventHandler(this.cbAlmacen2_SelectedIndexChanged);
                }
                this._cbAlmacen2 = value;
                if (this._cbAlmacen2 != null)
                {
                    this._cbAlmacen2.KeyPress += new KeyPressEventHandler(this.cbAlmacen2_KeyPress);
                    this._cbAlmacen2.SelectedIndexChanged += new EventHandler(this.cbAlmacen2_SelectedIndexChanged);
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

        internal virtual TextBox editCodCli
        {
            get
            {
                return this._editCodCli;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editCodCli != null)
                {
                    this._editCodCli.KeyPress -= new KeyPressEventHandler(this.editCodCli_KeyPress);
                    this._editCodCli.LostFocus -= new EventHandler(this.editCodCli_LostFocus);
                    this._editCodCli.TextChanged -= new EventHandler(this.editCodCli_TextChanged);
                }
                this._editCodCli = value;
                if (this._editCodCli != null)
                {
                    this._editCodCli.KeyPress += new KeyPressEventHandler(this.editCodCli_KeyPress);
                    this._editCodCli.LostFocus += new EventHandler(this.editCodCli_LostFocus);
                    this._editCodCli.TextChanged += new EventHandler(this.editCodCli_TextChanged);
                }
            }
        }

        internal virtual TextBox editDescCli
        {
            get
            {
                return this._editDescCli;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editDescCli != null)
                {
                }
                this._editDescCli = value;
                if (this._editDescCli != null)
                {
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

        internal virtual GroupBox GroupBox3
        {
            get
            {
                return this._GroupBox3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._GroupBox3 != null)
                {
                }
                this._GroupBox3 = value;
                if (this._GroupBox3 != null)
                {
                }
            }
        }

        internal virtual GroupBox GroupBox4
        {
            get
            {
                return this._GroupBox4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._GroupBox4 != null)
                {
                }
                this._GroupBox4 = value;
                if (this._GroupBox4 != null)
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

        internal virtual RadioButton rbCliBloq
        {
            get
            {
                return this._rbCliBloq;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbCliBloq != null)
                {
                    this._rbCliBloq.KeyPress -= new KeyPressEventHandler(this.rbCliBloq_KeyPress);
                    this._rbCliBloq.CheckedChanged -= new EventHandler(this.rbCliBloq_CheckedChanged);
                }
                this._rbCliBloq = value;
                if (this._rbCliBloq != null)
                {
                    this._rbCliBloq.KeyPress += new KeyPressEventHandler(this.rbCliBloq_KeyPress);
                    this._rbCliBloq.CheckedChanged += new EventHandler(this.rbCliBloq_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbCliExc
        {
            get
            {
                return this._rbCliExc;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbCliExc != null)
                {
                    this._rbCliExc.KeyPress -= new KeyPressEventHandler(this.rbCliExc_KeyPress);
                    this._rbCliExc.CheckedChanged -= new EventHandler(this.rbCliExc_CheckedChanged);
                }
                this._rbCliExc = value;
                if (this._rbCliExc != null)
                {
                    this._rbCliExc.KeyPress += new KeyPressEventHandler(this.rbCliExc_KeyPress);
                    this._rbCliExc.CheckedChanged += new EventHandler(this.rbCliExc_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbOrdenFechaConf
        {
            get
            {
                return this._rbOrdenFechaConf;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbOrdenFechaConf != null)
                {
                    this._rbOrdenFechaConf.KeyPress -= new KeyPressEventHandler(this.rbOrdenFechaOV_KeyPress);
                    this._rbOrdenFechaConf.CheckedChanged -= new EventHandler(this.rbOrdenFechaOV_CheckedChanged);
                }
                this._rbOrdenFechaConf = value;
                if (this._rbOrdenFechaConf != null)
                {
                    this._rbOrdenFechaConf.KeyPress += new KeyPressEventHandler(this.rbOrdenFechaOV_KeyPress);
                    this._rbOrdenFechaConf.CheckedChanged += new EventHandler(this.rbOrdenFechaOV_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbOrdenOCCliente
        {
            get
            {
                return this._rbOrdenOCCliente;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbOrdenOCCliente != null)
                {
                    this._rbOrdenOCCliente.KeyPress -= new KeyPressEventHandler(this.rbOrdenCliente_KeyPress);
                    this._rbOrdenOCCliente.CheckedChanged -= new EventHandler(this.rbOrdenCliente_CheckedChanged);
                }
                this._rbOrdenOCCliente = value;
                if (this._rbOrdenOCCliente != null)
                {
                    this._rbOrdenOCCliente.KeyPress += new KeyPressEventHandler(this.rbOrdenCliente_KeyPress);
                    this._rbOrdenOCCliente.CheckedChanged += new EventHandler(this.rbOrdenCliente_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbTodas
        {
            get
            {
                return this._rbTodas;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbTodas != null)
                {
                    this._rbTodas.KeyPress -= new KeyPressEventHandler(this.rbTodas_KeyPress);
                    this._rbTodas.CheckedChanged -= new EventHandler(this.rbTodas_CheckedChanged);
                }
                this._rbTodas = value;
                if (this._rbTodas != null)
                {
                    this._rbTodas.KeyPress += new KeyPressEventHandler(this.rbTodas_KeyPress);
                    this._rbTodas.CheckedChanged += new EventHandler(this.rbTodas_CheckedChanged);
                }
            }
        }
    }
}

