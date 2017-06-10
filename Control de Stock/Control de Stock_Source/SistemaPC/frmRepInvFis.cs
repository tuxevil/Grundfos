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

    public class frmRepInvFis : Form
    {
        [AccessedThroughProperty("btnBusqNomDesde")]
        private Button _btnBusqNomDesde;
        [AccessedThroughProperty("btnBusqNomHasta")]
        private Button _btnBusqNomHasta;
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dtpFechaInv")]
        private DateTimePicker _dtpFechaInv;
        [AccessedThroughProperty("dtpFechaLec")]
        private DateTimePicker _dtpFechaLec;
        [AccessedThroughProperty("editCodProdDesde")]
        private TextBox _editCodProdDesde;
        [AccessedThroughProperty("editCodProdHasta")]
        private TextBox _editCodProdHasta;
        [AccessedThroughProperty("editDescProdDesde1")]
        private TextBox _editDescProdDesde1;
        [AccessedThroughProperty("editDescProdDesde2")]
        private TextBox _editDescProdDesde2;
        [AccessedThroughProperty("editDescProdHasta1")]
        private TextBox _editDescProdHasta1;
        [AccessedThroughProperty("editDescProdHasta2")]
        private TextBox _editDescProdHasta2;
        [AccessedThroughProperty("editOperario")]
        private TextBox _editOperario;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("Label6")]
        private Label _Label6;
        public SqlDataAdapter AdapAlmacen1;
        public SqlDataAdapter AdapAlmacen2;
        private IContainer components;
        public DataSet DS;

        public frmRepInvFis()
        {
            base.Closed += new EventHandler(this.frmRepInvFis_Closed);
            base.Load += new EventHandler(this.frmRepInvFis_Load);
            this.DS = new DataSet();
            this.InitializeComponent();
        }

        private void btnBusqNomDesde_Click(object sender, EventArgs e)
        {
            new frmBusqProdxDesc().ShowDialog();
            if (StringType.StrCmp(Variables.gCodProd, "", false) == 0)
            {
                this.editCodProdDesde.Text = "";
                this.editDescProdDesde1.Text = "";
                this.editDescProdDesde2.Text = "";
            }
            else
            {
                this.editCodProdDesde.Text = Variables.gCodProd;
                this.editDescProdDesde1.Text = Variables.gDescProd1;
                this.editDescProdDesde2.Text = Variables.gDescProd2;
            }
        }

        private void btnBusqNomHasta_Click(object sender, EventArgs e)
        {
            new frmBusqProdxDesc().ShowDialog();
            if (StringType.StrCmp(Variables.gCodProd, "", false) == 0)
            {
                this.editCodProdHasta.Text = "";
                this.editDescProdHasta1.Text = "";
                this.editDescProdHasta2.Text = "";
            }
            else
            {
                this.editCodProdHasta.Text = Variables.gCodProd;
                this.editDescProdHasta1.Text = Variables.gDescProd1;
                this.editDescProdHasta2.Text = Variables.gDescProd2;
            }
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            this.dtpFechaInv.Enabled = false;
            this.editOperario.Enabled = false;
            this.editCodProdDesde.Enabled = false;
            this.editCodProdHasta.Enabled = false;
            this.dtpFechaLec.Enabled = false;
            this.cmbAceptar.Enabled = false;
            this.cmbSalir.Enabled = false;
            Variables.gFechaInv = this.dtpFechaInv.Value;
            if (StringType.StrCmp(this.editOperario.Text, Strings.Space(0), false) != 0)
            {
                Variables.gOperario = this.editOperario.Text;
            }
            else
            {
                Variables.gOperario = "";
            }
            if (StringType.StrCmp(this.editCodProdDesde.Text, Strings.Space(0), false) != 0)
            {
                Variables.gCodProdDesde = this.editCodProdDesde.Text;
                Variables.gDescProdDesde1 = this.editDescProdDesde1.Text;
                Variables.gDescProdDesde2 = this.editDescProdDesde2.Text;
            }
            else
            {
                Variables.gCodProdDesde = "";
                Variables.gDescProdDesde1 = "";
                Variables.gDescProdDesde2 = "";
            }
            if (StringType.StrCmp(this.editCodProdHasta.Text, Strings.Space(0), false) != 0)
            {
                Variables.gCodProdHasta = this.editCodProdHasta.Text;
                Variables.gDescProdHasta1 = this.editDescProdHasta1.Text;
                Variables.gDescProdHasta2 = this.editDescProdHasta2.Text;
            }
            else
            {
                Variables.gCodProdHasta = "";
                Variables.gDescProdHasta1 = "";
                Variables.gDescProdHasta2 = "";
            }
            if (this.dtpFechaLec.Checked)
            {
                Variables.gFechaLec = StringType.FromDate(this.dtpFechaLec.Value);
            }
            else
            {
                Variables.gFechaLec = "";
            }
            frmRepInvFis1 fis = new frmRepInvFis1();
            this.Hide();
            fis.Show();
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

        private void dtpFechaInv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editOperario.Focus();
            }
        }

        private void dtpFechaLec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void editCodProdDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editCodProdHasta.Focus();
            }
        }

        private void editCodProdDesde_LostFocus(object sender, EventArgs e)
        {
            bool flag = false;
            if (StringType.StrCmp(this.editCodProdDesde.Text, Strings.Space(0), false) != 0)
            {
                SqlConnection connection;
                try
                {
                    connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
                    connection.Open();
                    flag = true;
                    SqlDataReader reader = new SqlCommand("SELECT SC01001,SC01002,SC01003 FROM SC010100 where SC01001='" + this.editCodProdDesde.Text + "'", connection).ExecuteReader();
                    if (reader.Read())
                    {
                        this.editDescProdDesde1.Text = StringType.FromObject(reader["SC01002"]);
                        this.editDescProdDesde2.Text = StringType.FromObject(reader["SC01003"]);
                        reader.Close();
                    }
                    else
                    {
                        Interaction.MsgBox("Producto desde inexistente", 0x40, "Operador");
                        this.editDescProdDesde1.Text = "";
                        this.editDescProdDesde2.Text = "";
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

        private void editCodProdHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.dtpFechaLec.Focus();
            }
        }

        private void editCodProdHasta_LostFocus(object sender, EventArgs e)
        {
            bool flag = false;
            if (StringType.StrCmp(this.editCodProdHasta.Text, Strings.Space(0), false) != 0)
            {
                SqlConnection connection;
                try
                {
                    connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
                    connection.Open();
                    flag = true;
                    SqlDataReader reader = new SqlCommand("SELECT SC01001,SC01002,SC01003 FROM SC010100 where SC01001='" + this.editCodProdHasta.Text + "'", connection).ExecuteReader();
                    if (reader.Read())
                    {
                        this.editDescProdHasta1.Text = StringType.FromObject(reader["SC01002"]);
                        this.editDescProdHasta2.Text = StringType.FromObject(reader["SC01003"]);
                        reader.Close();
                    }
                    else
                    {
                        Interaction.MsgBox("Producto hasta inexistente", 0x40, "Operador");
                        this.editDescProdHasta1.Text = "";
                        this.editDescProdHasta2.Text = "";
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

        private void editOperario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editCodProdDesde.Focus();
            }
        }

        ~frmRepInvFis()
        {
        }

        private void frmRepInvFis_Closed(object sender, EventArgs e)
        {
            new frmInventario().Show();
        }

        private void frmRepInvFis_Load(object sender, EventArgs e)
        {
            this.dtpFechaInv.Value = DateAndTime.get_Now();
            this.dtpFechaLec.Value = DateAndTime.get_Now();
            this.dtpFechaLec.Checked = false;
            this.dtpFechaInv.Focus();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRepInvFis));
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.Label1 = new Label();
            this.dtpFechaInv = new DateTimePicker();
            this.dtpFechaLec = new DateTimePicker();
            this.Label3 = new Label();
            this.Label2 = new Label();
            this.btnBusqNomDesde = new Button();
            this.Label6 = new Label();
            this.editCodProdDesde = new TextBox();
            this.editDescProdDesde1 = new TextBox();
            this.editDescProdDesde2 = new TextBox();
            this.editDescProdHasta2 = new TextBox();
            this.btnBusqNomHasta = new Button();
            this.Label4 = new Label();
            this.editCodProdHasta = new TextBox();
            this.editDescProdHasta1 = new TextBox();
            this.editOperario = new TextBox();
            this.SuspendLayout();
            Point point = new Point(0x170, 0x150);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 0x10;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0x108, 0x150);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 0x11;
            this.cmbSalir.Text = "&Salir";
            this.Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x18);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x80, 0x10);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Fecha Inventario:";
            this.dtpFechaInv.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaInv.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaInv.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaInv.Format = DateTimePickerFormat.Short;
            point = new Point(160, 0x18);
            this.dtpFechaInv.Location = point;
            this.dtpFechaInv.Name = "dtpFechaInv";
            size = new Size(0x70, 0x16);
            this.dtpFechaInv.Size = size;
            this.dtpFechaInv.TabIndex = 1;
            DateTime time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpFechaInv.Value = time;
            this.dtpFechaLec.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaLec.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaLec.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaLec.Format = DateTimePickerFormat.Short;
            point = new Point(160, 0x120);
            this.dtpFechaLec.Location = point;
            this.dtpFechaLec.Name = "dtpFechaLec";
            this.dtpFechaLec.ShowCheckBox = true;
            size = new Size(0x70, 0x16);
            this.dtpFechaLec.Size = size;
            this.dtpFechaLec.TabIndex = 15;
            time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpFechaLec.Value = time;
            this.Label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x120);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(120, 0x10);
            this.Label3.Size = size;
            this.Label3.TabIndex = 14;
            this.Label3.Text = "Fecha Lectura:";
            this.Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x38);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(120, 0x10);
            this.Label2.Size = size;
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Operario:";
            this.btnBusqNomDesde.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x138, 0x58);
            this.btnBusqNomDesde.Location = point;
            this.btnBusqNomDesde.Name = "btnBusqNomDesde";
            size = new Size(0x98, 0x17);
            this.btnBusqNomDesde.Size = size;
            this.btnBusqNomDesde.TabIndex = 6;
            this.btnBusqNomDesde.Text = "&B\x00fasq. por Descripci\x00f3n";
            this.Label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x58);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(0x88, 0x17);
            this.Label6.Size = size;
            this.Label6.TabIndex = 4;
            this.Label6.Text = "Desde Producto:";
            this.editCodProdDesde.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x58);
            this.editCodProdDesde.Location = point;
            this.editCodProdDesde.MaxLength = 0x23;
            this.editCodProdDesde.Name = "editCodProdDesde";
            size = new Size(0x90, 0x16);
            this.editCodProdDesde.Size = size;
            this.editCodProdDesde.TabIndex = 5;
            this.editCodProdDesde.Text = "";
            this.editDescProdDesde1.BackColor = SystemColors.Window;
            this.editDescProdDesde1.Enabled = false;
            this.editDescProdDesde1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 120);
            this.editDescProdDesde1.Location = point;
            this.editDescProdDesde1.MaxLength = 0x19;
            this.editDescProdDesde1.Name = "editDescProdDesde1";
            size = new Size(0x130, 0x16);
            this.editDescProdDesde1.Size = size;
            this.editDescProdDesde1.TabIndex = 7;
            this.editDescProdDesde1.Text = "";
            this.editDescProdDesde2.BackColor = SystemColors.Window;
            this.editDescProdDesde2.Enabled = false;
            this.editDescProdDesde2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x98);
            this.editDescProdDesde2.Location = point;
            this.editDescProdDesde2.MaxLength = 0x19;
            this.editDescProdDesde2.Name = "editDescProdDesde2";
            size = new Size(0x130, 0x16);
            this.editDescProdDesde2.Size = size;
            this.editDescProdDesde2.TabIndex = 8;
            this.editDescProdDesde2.Text = "";
            this.editDescProdHasta2.BackColor = SystemColors.Window;
            this.editDescProdHasta2.Enabled = false;
            this.editDescProdHasta2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x100);
            this.editDescProdHasta2.Location = point;
            this.editDescProdHasta2.MaxLength = 0x19;
            this.editDescProdHasta2.Name = "editDescProdHasta2";
            size = new Size(0x130, 0x16);
            this.editDescProdHasta2.Size = size;
            this.editDescProdHasta2.TabIndex = 13;
            this.editDescProdHasta2.Text = "";
            this.btnBusqNomHasta.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x138, 0xc0);
            this.btnBusqNomHasta.Location = point;
            this.btnBusqNomHasta.Name = "btnBusqNomHasta";
            size = new Size(0x98, 0x17);
            this.btnBusqNomHasta.Size = size;
            this.btnBusqNomHasta.TabIndex = 11;
            this.btnBusqNomHasta.Text = "&B\x00fasq. por Descripci\x00f3n";
            this.Label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0xc0);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(0x70, 0x17);
            this.Label4.Size = size;
            this.Label4.TabIndex = 9;
            this.Label4.Text = "Hasta Producto:";
            this.editCodProdHasta.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0xc0);
            this.editCodProdHasta.Location = point;
            this.editCodProdHasta.MaxLength = 0x23;
            this.editCodProdHasta.Name = "editCodProdHasta";
            size = new Size(0x90, 0x16);
            this.editCodProdHasta.Size = size;
            this.editCodProdHasta.TabIndex = 10;
            this.editCodProdHasta.Text = "";
            this.editDescProdHasta1.BackColor = SystemColors.Window;
            this.editDescProdHasta1.Enabled = false;
            this.editDescProdHasta1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0xe0);
            this.editDescProdHasta1.Location = point;
            this.editDescProdHasta1.MaxLength = 0x19;
            this.editDescProdHasta1.Name = "editDescProdHasta1";
            size = new Size(0x130, 0x16);
            this.editDescProdHasta1.Size = size;
            this.editDescProdHasta1.TabIndex = 12;
            this.editDescProdHasta1.Text = "";
            this.editOperario.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.editOperario.ForeColor = SystemColors.WindowText;
            point = new Point(160, 0x38);
            this.editOperario.Location = point;
            this.editOperario.MaxLength = 3;
            this.editOperario.Name = "editOperario";
            size = new Size(0x38, 0x16);
            this.editOperario.Size = size;
            this.editOperario.TabIndex = 3;
            this.editOperario.Text = "";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.editOperario);
            this.Controls.Add(this.editDescProdHasta2);
            this.Controls.Add(this.btnBusqNomHasta);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.editCodProdHasta);
            this.Controls.Add(this.editDescProdHasta1);
            this.Controls.Add(this.editDescProdDesde2);
            this.Controls.Add(this.btnBusqNomDesde);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.editCodProdDesde);
            this.Controls.Add(this.editDescProdDesde1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.dtpFechaLec);
            this.Controls.Add(this.dtpFechaInv);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmRepInvFis";
            this.Text = "Reporte Inventario F\x00edsico";
            this.WindowState = FormWindowState.Maximized;
            this.ResumeLayout(false);
        }

        private void Label2_Click(object sender, EventArgs e)
        {
        }

        internal virtual Button btnBusqNomDesde
        {
            get
            {
                return this._btnBusqNomDesde;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnBusqNomDesde != null)
                {
                    this._btnBusqNomDesde.Click -= new EventHandler(this.btnBusqNomDesde_Click);
                }
                this._btnBusqNomDesde = value;
                if (this._btnBusqNomDesde != null)
                {
                    this._btnBusqNomDesde.Click += new EventHandler(this.btnBusqNomDesde_Click);
                }
            }
        }

        internal virtual Button btnBusqNomHasta
        {
            get
            {
                return this._btnBusqNomHasta;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnBusqNomHasta != null)
                {
                    this._btnBusqNomHasta.Click -= new EventHandler(this.btnBusqNomHasta_Click);
                }
                this._btnBusqNomHasta = value;
                if (this._btnBusqNomHasta != null)
                {
                    this._btnBusqNomHasta.Click += new EventHandler(this.btnBusqNomHasta_Click);
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

        internal virtual DateTimePicker dtpFechaInv
        {
            get
            {
                return this._dtpFechaInv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpFechaInv != null)
                {
                    this._dtpFechaInv.KeyPress -= new KeyPressEventHandler(this.dtpFechaInv_KeyPress);
                }
                this._dtpFechaInv = value;
                if (this._dtpFechaInv != null)
                {
                    this._dtpFechaInv.KeyPress += new KeyPressEventHandler(this.dtpFechaInv_KeyPress);
                }
            }
        }

        internal virtual DateTimePicker dtpFechaLec
        {
            get
            {
                return this._dtpFechaLec;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpFechaLec != null)
                {
                    this._dtpFechaLec.KeyPress -= new KeyPressEventHandler(this.dtpFechaLec_KeyPress);
                }
                this._dtpFechaLec = value;
                if (this._dtpFechaLec != null)
                {
                    this._dtpFechaLec.KeyPress += new KeyPressEventHandler(this.dtpFechaLec_KeyPress);
                }
            }
        }

        internal virtual TextBox editCodProdDesde
        {
            get
            {
                return this._editCodProdDesde;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editCodProdDesde != null)
                {
                    this._editCodProdDesde.LostFocus -= new EventHandler(this.editCodProdDesde_LostFocus);
                    this._editCodProdDesde.KeyPress -= new KeyPressEventHandler(this.editCodProdDesde_KeyPress);
                }
                this._editCodProdDesde = value;
                if (this._editCodProdDesde != null)
                {
                    this._editCodProdDesde.LostFocus += new EventHandler(this.editCodProdDesde_LostFocus);
                    this._editCodProdDesde.KeyPress += new KeyPressEventHandler(this.editCodProdDesde_KeyPress);
                }
            }
        }

        internal virtual TextBox editCodProdHasta
        {
            get
            {
                return this._editCodProdHasta;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editCodProdHasta != null)
                {
                    this._editCodProdHasta.LostFocus -= new EventHandler(this.editCodProdHasta_LostFocus);
                    this._editCodProdHasta.KeyPress -= new KeyPressEventHandler(this.editCodProdHasta_KeyPress);
                }
                this._editCodProdHasta = value;
                if (this._editCodProdHasta != null)
                {
                    this._editCodProdHasta.LostFocus += new EventHandler(this.editCodProdHasta_LostFocus);
                    this._editCodProdHasta.KeyPress += new KeyPressEventHandler(this.editCodProdHasta_KeyPress);
                }
            }
        }

        internal virtual TextBox editDescProdDesde1
        {
            get
            {
                return this._editDescProdDesde1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editDescProdDesde1 != null)
                {
                }
                this._editDescProdDesde1 = value;
                if (this._editDescProdDesde1 != null)
                {
                }
            }
        }

        internal virtual TextBox editDescProdDesde2
        {
            get
            {
                return this._editDescProdDesde2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editDescProdDesde2 != null)
                {
                }
                this._editDescProdDesde2 = value;
                if (this._editDescProdDesde2 != null)
                {
                }
            }
        }

        internal virtual TextBox editDescProdHasta1
        {
            get
            {
                return this._editDescProdHasta1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editDescProdHasta1 != null)
                {
                }
                this._editDescProdHasta1 = value;
                if (this._editDescProdHasta1 != null)
                {
                }
            }
        }

        internal virtual TextBox editDescProdHasta2
        {
            get
            {
                return this._editDescProdHasta2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editDescProdHasta2 != null)
                {
                }
                this._editDescProdHasta2 = value;
                if (this._editDescProdHasta2 != null)
                {
                }
            }
        }

        internal virtual TextBox editOperario
        {
            get
            {
                return this._editOperario;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editOperario != null)
                {
                    this._editOperario.KeyPress -= new KeyPressEventHandler(this.editOperario_KeyPress);
                }
                this._editOperario = value;
                if (this._editOperario != null)
                {
                    this._editOperario.KeyPress += new KeyPressEventHandler(this.editOperario_KeyPress);
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
                    this._Label2.Click -= new EventHandler(this.Label2_Click);
                }
                this._Label2 = value;
                if (this._Label2 != null)
                {
                    this._Label2.Click += new EventHandler(this.Label2_Click);
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

