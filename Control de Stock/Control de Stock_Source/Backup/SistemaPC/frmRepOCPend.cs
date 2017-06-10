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

    public class frmRepOCPend : Form
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
        [AccessedThroughProperty("dtpDesde")]
        private DateTimePicker _dtpDesde;
        [AccessedThroughProperty("dtpHasta")]
        private DateTimePicker _dtpHasta;
        [AccessedThroughProperty("editCodProd")]
        private TextBox _editCodProd;
        [AccessedThroughProperty("editDescProd1")]
        private TextBox _editDescProd1;
        [AccessedThroughProperty("editDescProd2")]
        private TextBox _editDescProd2;
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
        [AccessedThroughProperty("Label6")]
        private Label _Label6;
        [AccessedThroughProperty("rbCodProd")]
        private RadioButton _rbCodProd;
        [AccessedThroughProperty("rbNroOC")]
        private RadioButton _rbNroOC;
        public SqlDataAdapter AdapAlmacen1;
        public SqlDataAdapter AdapAlmacen2;
        private IContainer components;
        public DataSet DS;

        public frmRepOCPend()
        {
            base.Closed += new EventHandler(this.frmRepOCPend_Closed);
            base.Load += new EventHandler(this.frmRepOCPend_Load);
            this.DS = new DataSet();
            this.InitializeComponent();
        }

        private void btnBusqNom_Click(object sender, EventArgs e)
        {
            new frmBusqProdxDesc().ShowDialog();
            if (StringType.StrCmp(Variables.gCodProd, "", false) == 0)
            {
                this.editCodProd.Text = "";
                this.editDescProd1.Text = "";
                this.editDescProd2.Text = "";
            }
            else
            {
                this.editCodProd.Text = Variables.gCodProd;
                this.editDescProd1.Text = Variables.gDescProd1;
                this.editDescProd2.Text = Variables.gDescProd2;
            }
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
                this.rbNroOC.Focus();
            }
        }

        private void cbAlmacen2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            if (!this.dtpDesde.Checked & this.dtpHasta.Checked)
            {
                Interaction.MsgBox("Debe ingresar ambas fechas o ninguna", 0x10, "Operador");
                this.dtpDesde.Checked = true;
            }
            else if (this.dtpDesde.Checked & !this.dtpHasta.Checked)
            {
                Interaction.MsgBox("Debe ingresar ambas fechas o ninguna", 0x10, "Operador");
                this.dtpHasta.Checked = true;
            }
            else
            {
                this.dtpDesde.Enabled = false;
                this.dtpHasta.Enabled = false;
                this.cmbAceptar.Enabled = false;
                this.cmbSalir.Enabled = false;
                if (this.dtpDesde.Checked)
                {
                    Variables.gDesde = StringType.FromDate(this.dtpDesde.Value);
                }
                else
                {
                    Variables.gDesde = "";
                }
                if (this.dtpHasta.Checked)
                {
                    Variables.gHasta = StringType.FromDate(this.dtpHasta.Value);
                }
                else
                {
                    Variables.gHasta = "";
                }
                if (StringType.StrCmp(this.cbAlmacen1.Text, Strings.Space(0), false) != 0)
                {
                    Variables.gAlmacen1 = this.cbAlmacen1.Text;
                }
                else
                {
                    Variables.gAlmacen1 = "";
                }
                if (StringType.StrCmp(this.cbAlmacen2.Text, Strings.Space(0), false) != 0)
                {
                    Variables.gAlmacen2 = this.cbAlmacen2.Text;
                }
                else
                {
                    Variables.gAlmacen2 = "";
                }
                if (this.rbNroOC.Checked)
                {
                    Variables.gOrdenList = 1;
                }
                else
                {
                    Variables.gOrdenList = 2;
                }
                if (StringType.StrCmp(this.editCodProd.Text, Strings.Space(0), false) != 0)
                {
                    Variables.gCodProd = this.editCodProd.Text;
                }
                else
                {
                    Variables.gCodProd = "";
                }
                frmRepOCPend1 pend = new frmRepOCPend1();
                this.Hide();
                pend.Show();
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

        private void dtpDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.dtpHasta.Focus();
            }
        }

        private void dtpHasta_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void dtpHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cbAlmacen1.Focus();
            }
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
        }

        private void editCodProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void editCodProd_LostFocus(object sender, EventArgs e)
        {
            bool flag = false;
            if (StringType.StrCmp(this.editCodProd.Text, Strings.Space(0), false) != 0)
            {
                SqlConnection connection;
                try
                {
                    connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
                    connection.Open();
                    flag = true;
                    SqlDataReader reader = new SqlCommand("SELECT SC01001,SC01002,SC01003 FROM SC010100 where SC01001='" + this.editCodProd.Text + "'", connection).ExecuteReader();
                    if (reader.Read())
                    {
                        this.editDescProd1.Text = StringType.FromObject(reader["SC01002"]);
                        this.editDescProd2.Text = StringType.FromObject(reader["SC01003"]);
                        reader.Close();
                    }
                    else
                    {
                        Interaction.MsgBox("Producto inexistente", 0x40, "Operador");
                        this.editDescProd1.Text = "";
                        this.editDescProd2.Text = "";
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

        private void editCodProd_TextChanged(object sender, EventArgs e)
        {
        }

        ~frmRepOCPend()
        {
        }

        private void frmRepOCPend_Closed(object sender, EventArgs e)
        {
            new frmMenuOCompra().Show();
        }

        private void frmRepOCPend_Load(object sender, EventArgs e)
        {
            this.dtpDesde.Value = DateAndTime.get_Now();
            this.dtpHasta.Value = DateAndTime.get_Now();
            bool flag = false;
            try
            {
                string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
                string selectCommandText = "select ltrim(SC23001)+'-'+ltrim(SC23002) as Almacen from SC230100 order by SC23001";
                this.AdapAlmacen1 = new SqlDataAdapter(selectCommandText, selectConnectionString);
                this.DS.Tables.Clear();
                this.AdapAlmacen1.Fill(this.DS, "SC230100-1");
                this.cbAlmacen1.DataSource = this.DS.Tables["SC230100-1"];
                this.cbAlmacen1.DisplayMember = "Almacen";
                this.cbAlmacen1.ValueMember = "Almacen";
                this.cbAlmacen1.Refresh();
                selectCommandText = "select ltrim(SC23001)+'-'+ltrim(SC23002) as Almacen from SC230100 order by SC23001";
                this.AdapAlmacen2 = new SqlDataAdapter(selectCommandText, selectConnectionString);
                this.AdapAlmacen2.Fill(this.DS, "SC230100-2");
                this.cbAlmacen2.DataSource = this.DS.Tables["SC230100-2"];
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
            this.dtpDesde.Focus();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRepOCPend));
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.Label1 = new Label();
            this.dtpDesde = new DateTimePicker();
            this.dtpHasta = new DateTimePicker();
            this.Label3 = new Label();
            this.Label2 = new Label();
            this.cbAlmacen1 = new ComboBox();
            this.cbAlmacen2 = new ComboBox();
            this.Label4 = new Label();
            this.GroupBox1 = new GroupBox();
            this.rbCodProd = new RadioButton();
            this.rbNroOC = new RadioButton();
            this.btnBusqNom = new Button();
            this.Label6 = new Label();
            this.editCodProd = new TextBox();
            this.editDescProd1 = new TextBox();
            this.editDescProd2 = new TextBox();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            Point point = new Point(0x170, 0x188);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 9;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0x108, 0x188);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 10;
            this.cmbSalir.Text = "&Salir";
            this.Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x18);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x80, 0x10);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Desde F.Esperada:";
            this.dtpDesde.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpDesde.CustomFormat = "dd/MM/yyyy";
            this.dtpDesde.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpDesde.Format = DateTimePickerFormat.Short;
            point = new Point(160, 0x18);
            this.dtpDesde.Location = point;
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.ShowCheckBox = true;
            size = new Size(0x70, 0x16);
            this.dtpDesde.Size = size;
            this.dtpDesde.TabIndex = 1;
            DateTime time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpDesde.Value = time;
            this.dtpHasta.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpHasta.CustomFormat = "dd/MM/yyyy";
            this.dtpHasta.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpHasta.Format = DateTimePickerFormat.Short;
            point = new Point(160, 0x38);
            this.dtpHasta.Location = point;
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.ShowCheckBox = true;
            size = new Size(0x70, 0x16);
            this.dtpHasta.Size = size;
            this.dtpHasta.TabIndex = 3;
            time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpHasta.Value = time;
            this.Label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x38);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(120, 0x10);
            this.Label3.Size = size;
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Hasta F.Esperada:";
            this.Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x68);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(120, 0x10);
            this.Label2.Size = size;
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Almac\x00e9n:";
            this.cbAlmacen1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x60);
            this.cbAlmacen1.Location = point;
            this.cbAlmacen1.Name = "cbAlmacen1";
            size = new Size(0x130, 0x18);
            this.cbAlmacen1.Size = size;
            this.cbAlmacen1.TabIndex = 5;
            this.cbAlmacen1.Text = "ComboBox1";
            this.cbAlmacen2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x88);
            this.cbAlmacen2.Location = point;
            this.cbAlmacen2.Name = "cbAlmacen2";
            size = new Size(0x130, 0x18);
            this.cbAlmacen2.Size = size;
            this.cbAlmacen2.TabIndex = 7;
            this.cbAlmacen2.Text = "ComboBox2";
            this.Label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x90);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(120, 0x10);
            this.Label4.Size = size;
            this.Label4.TabIndex = 6;
            this.Label4.Text = "Almac\x00e9n:";
            this.GroupBox1.Controls.Add(this.rbCodProd);
            this.GroupBox1.Controls.Add(this.rbNroOC);
            this.GroupBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0xb8);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(0xd8, 0x58);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 8;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Orden Reporte";
            this.rbCodProd.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x38);
            this.rbCodProd.Location = point;
            this.rbCodProd.Name = "rbCodProd";
            size = new Size(0xc0, 0x18);
            this.rbCodProd.Size = size;
            this.rbCodProd.TabIndex = 1;
            this.rbCodProd.Text = "C\x00f3d.Producto + F.Esperada";
            this.rbNroOC.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x18);
            this.rbNroOC.Location = point;
            this.rbNroOC.Name = "rbNroOC";
            size = new Size(0xa8, 0x18);
            this.rbNroOC.Size = size;
            this.rbNroOC.TabIndex = 0;
            this.rbNroOC.Text = "N\x00b0 O.Compra";
            this.btnBusqNom.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x138, 0x120);
            this.btnBusqNom.Location = point;
            this.btnBusqNom.Name = "btnBusqNom";
            size = new Size(0x98, 0x17);
            this.btnBusqNom.Size = size;
            this.btnBusqNom.TabIndex = 14;
            this.btnBusqNom.Text = "&B\x00fasq. por Descripci\x00f3n";
            this.Label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x120);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(80, 0x17);
            this.Label6.Size = size;
            this.Label6.TabIndex = 11;
            this.Label6.Text = "Producto:";
            this.editCodProd.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x120);
            this.editCodProd.Location = point;
            this.editCodProd.MaxLength = 0x23;
            this.editCodProd.Name = "editCodProd";
            size = new Size(0x90, 0x16);
            this.editCodProd.Size = size;
            this.editCodProd.TabIndex = 12;
            this.editCodProd.Text = "";
            this.editDescProd1.BackColor = SystemColors.Window;
            this.editDescProd1.Enabled = false;
            this.editDescProd1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 320);
            this.editDescProd1.Location = point;
            this.editDescProd1.MaxLength = 0x19;
            this.editDescProd1.Name = "editDescProd1";
            size = new Size(0x130, 0x16);
            this.editDescProd1.Size = size;
            this.editDescProd1.TabIndex = 13;
            this.editDescProd1.Text = "";
            this.editDescProd2.BackColor = SystemColors.Window;
            this.editDescProd2.Enabled = false;
            this.editDescProd2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x160);
            this.editDescProd2.Location = point;
            this.editDescProd2.MaxLength = 0x19;
            this.editDescProd2.Name = "editDescProd2";
            size = new Size(0x130, 0x16);
            this.editDescProd2.Size = size;
            this.editDescProd2.TabIndex = 15;
            this.editDescProd2.Text = "";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.editDescProd2);
            this.Controls.Add(this.btnBusqNom);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.editCodProd);
            this.Controls.Add(this.editDescProd1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.cbAlmacen2);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.cbAlmacen1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmRepOCPend";
            this.Text = "Reporte O.Compra Pendientes";
            this.WindowState = FormWindowState.Maximized;
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void Label2_Click(object sender, EventArgs e)
        {
        }

        private void rbCodProd_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbCodProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editCodProd.Focus();
            }
        }

        private void rbNroOC_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbNroOC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editCodProd.Focus();
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

        internal virtual DateTimePicker dtpDesde
        {
            get
            {
                return this._dtpDesde;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpDesde != null)
                {
                    this._dtpDesde.KeyPress -= new KeyPressEventHandler(this.dtpDesde_KeyPress);
                }
                this._dtpDesde = value;
                if (this._dtpDesde != null)
                {
                    this._dtpDesde.KeyPress += new KeyPressEventHandler(this.dtpDesde_KeyPress);
                }
            }
        }

        internal virtual DateTimePicker dtpHasta
        {
            get
            {
                return this._dtpHasta;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpHasta != null)
                {
                    this._dtpHasta.KeyDown -= new KeyEventHandler(this.dtpHasta_KeyDown);
                    this._dtpHasta.ValueChanged -= new EventHandler(this.dtpHasta_ValueChanged);
                    this._dtpHasta.KeyPress -= new KeyPressEventHandler(this.dtpHasta_KeyPress);
                }
                this._dtpHasta = value;
                if (this._dtpHasta != null)
                {
                    this._dtpHasta.KeyDown += new KeyEventHandler(this.dtpHasta_KeyDown);
                    this._dtpHasta.ValueChanged += new EventHandler(this.dtpHasta_ValueChanged);
                    this._dtpHasta.KeyPress += new KeyPressEventHandler(this.dtpHasta_KeyPress);
                }
            }
        }

        internal virtual TextBox editCodProd
        {
            get
            {
                return this._editCodProd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editCodProd != null)
                {
                    this._editCodProd.TextChanged -= new EventHandler(this.editCodProd_TextChanged);
                    this._editCodProd.LostFocus -= new EventHandler(this.editCodProd_LostFocus);
                    this._editCodProd.KeyPress -= new KeyPressEventHandler(this.editCodProd_KeyPress);
                }
                this._editCodProd = value;
                if (this._editCodProd != null)
                {
                    this._editCodProd.TextChanged += new EventHandler(this.editCodProd_TextChanged);
                    this._editCodProd.LostFocus += new EventHandler(this.editCodProd_LostFocus);
                    this._editCodProd.KeyPress += new KeyPressEventHandler(this.editCodProd_KeyPress);
                }
            }
        }

        internal virtual TextBox editDescProd1
        {
            get
            {
                return this._editDescProd1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editDescProd1 != null)
                {
                }
                this._editDescProd1 = value;
                if (this._editDescProd1 != null)
                {
                }
            }
        }

        internal virtual TextBox editDescProd2
        {
            get
            {
                return this._editDescProd2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editDescProd2 != null)
                {
                }
                this._editDescProd2 = value;
                if (this._editDescProd2 != null)
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

        internal virtual RadioButton rbCodProd
        {
            get
            {
                return this._rbCodProd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbCodProd != null)
                {
                    this._rbCodProd.KeyPress -= new KeyPressEventHandler(this.rbCodProd_KeyPress);
                    this._rbCodProd.CheckedChanged -= new EventHandler(this.rbCodProd_CheckedChanged);
                }
                this._rbCodProd = value;
                if (this._rbCodProd != null)
                {
                    this._rbCodProd.KeyPress += new KeyPressEventHandler(this.rbCodProd_KeyPress);
                    this._rbCodProd.CheckedChanged += new EventHandler(this.rbCodProd_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbNroOC
        {
            get
            {
                return this._rbNroOC;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbNroOC != null)
                {
                    this._rbNroOC.KeyPress -= new KeyPressEventHandler(this.rbNroOC_KeyPress);
                    this._rbNroOC.CheckedChanged -= new EventHandler(this.rbNroOC_CheckedChanged);
                }
                this._rbNroOC = value;
                if (this._rbNroOC != null)
                {
                    this._rbNroOC.KeyPress += new KeyPressEventHandler(this.rbNroOC_KeyPress);
                    this._rbNroOC.CheckedChanged += new EventHandler(this.rbNroOC_CheckedChanged);
                }
            }
        }
    }
}

