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

    public class frmFcProfExp : Form
    {
        [AccessedThroughProperty("btnBusqNom")]
        private Button _btnBusqNom;
        [AccessedThroughProperty("chkFcProfIng")]
        private CheckBox _chkFcProfIng;
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("editCodCli")]
        private TextBox _editCodCli;
        [AccessedThroughProperty("editDescCli")]
        private TextBox _editDescCli;
        [AccessedThroughProperty("Label6")]
        private Label _Label6;
        private IContainer components;

        public frmFcProfExp()
        {
            base.Closed += new EventHandler(this.frmFcProfExp_Closed);
            base.Load += new EventHandler(this.frmFcProfExp_Load);
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

        private void chkFcProfIng_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkFcProfIng_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            DataSet set = new DataSet();
            DataSet dataSet = new DataSet();
            DataSet set3 = new DataSet();
            if (StringType.StrCmp(this.editCodCli.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe indicar Cliente", 0x10, "Operador");
                this.editCodCli.Focus();
            }
            else if (StringType.StrCmp(this.editDescCli.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Cliente inexistente", 0x10, "Operador");
                this.editCodCli.Focus();
            }
            else
            {
                this.editCodCli.Enabled = false;
                this.cmbAceptar.Enabled = false;
                this.cmbSalir.Enabled = false;
                Variables.gCodCli = this.editCodCli.Text;
                Variables.gNomCli = this.editDescCli.Text;
                Variables.gFcProfIng = this.chkFcProfIng.Checked;
                string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
                SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
                connection.Open();
                SqlCommand command = new SqlCommand("delete " + Variables.gTermi + "TmpOVFcProExp", connection);
                int num3 = command.ExecuteNonQuery();
                command = new SqlCommand("delete " + Variables.gTermi + "TmpOVCli", connection);
                num3 = command.ExecuteNonQuery();
                command = new SqlCommand("delete " + Variables.gTermi + "TmpItemFcProExp", connection);
                num3 = command.ExecuteNonQuery();
                SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT OR01001,OR01050,SC23002,SY14002,SL230100.SL23004 as CondPago,SL230100_1.SL23004 as CondEnt FROM dbo.OR010100 inner join SC230100 on OR010100.OR01050=SC230100.SC23001 inner join SY140100 on OR010100.OR01028=SY140100.SY14001 inner join SL230100 on OR010100.OR01012=SL230100.SL23003 inner join SL230100 as SL230100_1 on OR010100.OR01013=SL230100_1.SL23003 where OR01004='" + Variables.gCodCli + "' and OR01002<>6 and SL230100.SL23001='0' and SL230100.SL23002='00' and SL230100_1.SL23001='1' and SL230100_1.SL23002='00'", selectConnectionString);
                dataSet.Clear();
                adapter2.Fill(dataSet, "OR010100");
                if (dataSet.Tables["OR010100"].Rows.Count == 0)
                {
                    Interaction.MsgBox("No hay \x00f3rdenes de venta para este cliente", 0x10, "Operador");
                    this.editCodCli.Text = "";
                    this.editDescCli.Text = "";
                    this.editCodCli.Enabled = true;
                    this.cmbAceptar.Enabled = true;
                    this.cmbSalir.Enabled = true;
                    this.editCodCli.Focus();
                    connection.Close();
                }
                else
                {
                    long num5 = dataSet.Tables["OR010100"].Rows.Count - 1;
                    for (long i = 0L; i <= num5; i += 1L)
                    {
                        DataRow row = dataSet.Tables["OR010100"].Rows[(int) i];
                        command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpOVCli (NroOV,Almacen,NomAlmacen,Moneda,CondPago,CondEnt) values ('", row["OR01001"]), "','"), row["OR01050"]), "','"), row["SC23002"]), "','"), row["SY14002"]), "','"), row["CondPago"]), "','"), row["CondEnt"]), "')")), connection);
                        try
                        {
                            command.ExecuteNonQuery();
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
                        SqlDataAdapter adapter3 = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT OR03001,OR03002,OR03005,OR03006,OR03007,OR03008,OR03011,OR03019 FROM dbo.OR030100 where OR03001='", row["OR01001"]), "'")), selectConnectionString);
                        set3.Clear();
                        adapter3.Fill(set3, "OR030100");
                        long num4 = set3.Tables["OR030100"].Rows.Count - 1;
                        for (long j = 0L; j <= num4; j += 1L)
                        {
                            DataRow row2 = set3.Tables["OR030100"].Rows[(int) j];
                            command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpItemFcProExp (NroOV,Linea,Codigo,Descripcion,Cantidad,FechaConf,PrecioUnit,Seleccion) values ('", row2["OR03001"]), "','"), row2["OR03002"]), "','"), row2["OR03005"]), "','"), Strings.Trim(StringType.FromObject(row2["OR03006"]))), " "), Strings.Trim(StringType.FromObject(row2["OR03007"]))), "',"), row2["OR03011"]), ",'"), Strings.Format(RuntimeHelpers.GetObjectValue(row2["OR03019"]), "MM/dd/yyyy")), "',"), row2["OR03008"]), ",0)")), connection);
                            try
                            {
                                command.ExecuteNonQuery();
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
                        }
                    }
                    connection.Close();
                    frmFcProfExp1 exp = new frmFcProfExp1();
                    this.Hide();
                    exp.Show();
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

        private void editCodCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.chkFcProfIng.Focus();
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

        ~frmFcProfExp()
        {
        }

        private void frmFcProfExp_Closed(object sender, EventArgs e)
        {
            new frmMenuOVExp().Show();
        }

        private void frmFcProfExp_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.btnBusqNom = new Button();
            this.Label6 = new Label();
            this.editCodCli = new TextBox();
            this.editDescCli = new TextBox();
            this.chkFcProfIng = new CheckBox();
            this.SuspendLayout();
            Point point = new Point(0x250, 0x48);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 4;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(480, 0x48);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 5;
            this.cmbSalir.Text = "&Salir";
            this.btnBusqNom.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(240, 0x10);
            this.btnBusqNom.Location = point;
            this.btnBusqNom.Name = "btnBusqNom";
            size = new Size(0x98, 0x17);
            this.btnBusqNom.Size = size;
            this.btnBusqNom.TabIndex = 6;
            this.btnBusqNom.Text = "&Busqueda por Nombre";
            this.Label6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x10);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(80, 0x17);
            this.Label6.Size = size;
            this.Label6.TabIndex = 0;
            this.Label6.Text = "Cliente:";
            this.editCodCli.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(120, 0x10);
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
            point = new Point(120, 0x30);
            this.editDescCli.Location = point;
            this.editDescCli.MaxLength = 0x23;
            this.editDescCli.Name = "editDescCli";
            size = new Size(0x150, 20);
            this.editDescCli.Size = size;
            this.editDescCli.TabIndex = 2;
            this.editDescCli.Text = "";
            point = new Point(8, 0x58);
            this.chkFcProfIng.Location = point;
            this.chkFcProfIng.Name = "chkFcProfIng";
            size = new Size(0xc0, 0x20);
            this.chkFcProfIng.Size = size;
            this.chkFcProfIng.TabIndex = 3;
            this.chkFcProfIng.Text = "Factura Proforma en Ingl\x00e9s";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.chkFcProfIng);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Controls.Add(this.editDescCli);
            this.Controls.Add(this.btnBusqNom);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.editCodCli);
            this.Name = "frmFcProfExp";
            this.Text = "Facturas Proforma Exportaci\x00f3n";
            this.WindowState = FormWindowState.Maximized;
            this.ResumeLayout(false);
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

        internal virtual CheckBox chkFcProfIng
        {
            get
            {
                return this._chkFcProfIng;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._chkFcProfIng != null)
                {
                    this._chkFcProfIng.KeyPress -= new KeyPressEventHandler(this.chkFcProfIng_KeyPress);
                    this._chkFcProfIng.CheckedChanged -= new EventHandler(this.chkFcProfIng_CheckedChanged);
                }
                this._chkFcProfIng = value;
                if (this._chkFcProfIng != null)
                {
                    this._chkFcProfIng.KeyPress += new KeyPressEventHandler(this.chkFcProfIng_KeyPress);
                    this._chkFcProfIng.CheckedChanged += new EventHandler(this.chkFcProfIng_CheckedChanged);
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
    }
}

