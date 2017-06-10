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

    public class frmRepDifInv : Form
    {
        [AccessedThroughProperty("cbAlmacen")]
        private ComboBox _cbAlmacen;
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dtpFechaInv")]
        private DateTimePicker _dtpFechaInv;
        [AccessedThroughProperty("editDesdeRack")]
        private TextBox _editDesdeRack;
        [AccessedThroughProperty("editHastaRack")]
        private TextBox _editHastaRack;
        [AccessedThroughProperty("editReferencia")]
        private TextBox _editReferencia;
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
        public SqlDataAdapter AdapAlmacen;
        private IContainer components;
        public DataSet DS;

        public frmRepDifInv()
        {
            base.Closed += new EventHandler(this.frmRepDifInv_Closed);
            base.Load += new EventHandler(this.frmRepDifInv_Load);
            this.DS = new DataSet();
            this.InitializeComponent();
        }

        private void cbAlmacen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editDesdeRack.Focus();
            }
        }

        private void cbAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            DataSet set2 = new DataSet();
            if (BooleanType.FromObject(ObjectType.BitAndObj(StringType.StrCmp(this.cbAlmacen.Text, Strings.Space(0), false) == 0, ObjectType.ObjTst(this.cbAlmacen.SelectedValue, Strings.Space(0), false) == 0)))
            {
                Interaction.MsgBox("Debe seleccionar almac\x00e9n", 0x10, "Operador");
                this.cbAlmacen.Focus();
            }
            else if (((StringType.StrCmp(this.editDesdeRack.Text, Strings.Space(0), false) == 0) & (StringType.StrCmp(this.editHastaRack.Text, Strings.Space(0), false) != 0)) | ((StringType.StrCmp(this.editDesdeRack.Text, Strings.Space(0), false) != 0) & (StringType.StrCmp(this.editHastaRack.Text, Strings.Space(0), false) == 0)))
            {
                Interaction.MsgBox("Debe indicar desde y hasta rack", 0x10, "Operador");
                this.editDesdeRack.Focus();
            }
            else if (StringType.StrCmp(this.editReferencia.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe ingresar referencia", 0x10, "Operador");
                this.editReferencia.Focus();
            }
            else
            {
                this.cmbAceptar.Enabled = false;
                this.cmbSalir.Enabled = false;
                Variables.gFechaInv = this.dtpFechaInv.Value;
                Variables.gCodAlmacen = StringType.FromObject(this.cbAlmacen.SelectedValue);
                Variables.gNomAlmacen = this.cbAlmacen.Text;
                Variables.gDesdeRack = Strings.Trim(this.editDesdeRack.Text);
                Variables.gHastaRack = Strings.Trim(this.editHastaRack.Text);
                Variables.gReferencia = Strings.Trim(this.editReferencia.Text);
                string connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                new SqlDataAdapter("SELECT * FROM dbo.RepDifInv where FechaInv='" + Strings.Format(Variables.gFechaInv, "MM/dd/yyyy") + "' and DesdeRack='" + Variables.gDesdeRack + "' and HastaRack='" + Variables.gHastaRack + "' and Almacen='" + Variables.gCodAlmacen + "'", connectionString).Fill(dataSet, "RepDifInv");
                if (dataSet.Tables["RepDifInv"].Rows.Count == 0)
                {
                    Interaction.MsgBox("No se gener\x00f3 diferencia de inventario sobre estos datos", 0x10, "Operador");
                    connection.Close();
                    this.cmbAceptar.Enabled = true;
                    this.cmbSalir.Enabled = true;
                    this.cmbAceptar.Focus();
                }
                else
                {
                    dataSet.Tables["RepDifInv"].Rows.Clear();
                    SqlCommand command3 = new SqlCommand("delete " + Variables.gTermi + "TmpInventario", connection);
                    int num2 = command3.ExecuteNonQuery();
                    command3 = new SqlCommand("insert into " + Variables.gTermi + "TmpInventario select Almacen,Posicion,Codigo,Desc1,Desc2,Cantidad,PosSist,CantSist,Aceptar,Rechazar from RepDifInv where FechaInv='" + Strings.Format(Variables.gFechaInv, "MM/dd/yyyy") + "' and DesdeRack='" + Variables.gDesdeRack + "' and HastaRack='" + Variables.gHastaRack + "' and Almacen='" + Variables.gCodAlmacen + "' and (Cantidad<>CantSist or Posicion<>PosSist)", connection);
                    try
                    {
                        num2 = command3.ExecuteNonQuery();
                    }
                    catch (Exception exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        Exception exception = exception1;
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                        connection.Close();
                        this.cmbAceptar.Enabled = true;
                        this.cmbSalir.Enabled = true;
                        ProjectData.ClearProjectError();
                        return;
                        ProjectData.ClearProjectError();
                    }
                    connection.Close();
                    frmRepDifInv2 inv = new frmRepDifInv2();
                    this.Hide();
                    inv.Show();
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

        private void dtpFechaInv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cbAlmacen.Focus();
            }
        }

        private void dtpFechaInv_ValueChanged(object sender, EventArgs e)
        {
        }

        private void editDesdeRack_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editHastaRack.Focus();
            }
        }

        private void editHastaRack_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editReferencia.Focus();
            }
        }

        private void editHastaRack_TextChanged(object sender, EventArgs e)
        {
        }

        private void editNroOE_TextChanged(object sender, EventArgs e)
        {
        }

        private void editReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void editReferencia_TextChanged(object sender, EventArgs e)
        {
        }

        ~frmRepDifInv()
        {
        }

        private void frmRepDifInv_Closed(object sender, EventArgs e)
        {
            new frmInventario().Show();
        }

        private void frmRepDifInv_Load(object sender, EventArgs e)
        {
            bool flag = false;
            this.dtpFechaInv.Value = DateAndTime.get_Now();
            try
            {
                string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
                string selectCommandText = "select SC23001,SC23002 from SC230100 order by SC23001";
                this.AdapAlmacen = new SqlDataAdapter(selectCommandText, selectConnectionString);
                this.DS.Tables.Clear();
                this.AdapAlmacen.Fill(this.DS, "SC230100");
                this.cbAlmacen.DataSource = this.DS.Tables["SC230100"];
                this.cbAlmacen.DisplayMember = "SC23002";
                this.cbAlmacen.ValueMember = "SC23001";
                this.cbAlmacen.Refresh();
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
            this.cbAlmacen.Text = "";
            this.cbAlmacen.SelectedValue = "";
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRepDifInv));
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.cbAlmacen = new ComboBox();
            this.Label4 = new Label();
            this.dtpFechaInv = new DateTimePicker();
            this.Label6 = new Label();
            this.Label2 = new Label();
            this.editDesdeRack = new TextBox();
            this.Label3 = new Label();
            this.editHastaRack = new TextBox();
            this.Label1 = new Label();
            this.editReferencia = new TextBox();
            this.SuspendLayout();
            this.cmbAceptar.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Point point = new Point(0x158, 200);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 10;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            this.cmbSalir.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(240, 200);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 11;
            this.cmbSalir.Text = "&Salir";
            this.cbAlmacen.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x30);
            this.cbAlmacen.Location = point;
            this.cbAlmacen.Name = "cbAlmacen";
            size = new Size(0x120, 0x18);
            this.cbAlmacen.Size = size;
            this.cbAlmacen.TabIndex = 3;
            this.cbAlmacen.Text = "ComboBox2";
            this.Label4.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x30);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(0x70, 0x10);
            this.Label4.Size = size;
            this.Label4.TabIndex = 2;
            this.Label4.Text = "Almac\x00e9n:";
            this.dtpFechaInv.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaInv.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaInv.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaInv.Format = DateTimePickerFormat.Short;
            point = new Point(160, 0x10);
            this.dtpFechaInv.Location = point;
            this.dtpFechaInv.Name = "dtpFechaInv";
            size = new Size(0x60, 0x16);
            this.dtpFechaInv.Size = size;
            this.dtpFechaInv.TabIndex = 1;
            DateTime time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpFechaInv.Value = time;
            this.Label6.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x10);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(0x70, 0x10);
            this.Label6.Size = size;
            this.Label6.TabIndex = 0;
            this.Label6.Text = "Fecha Inventario:";
            this.Label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x58);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x70, 0x17);
            this.Label2.Size = size;
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Desde Rack:";
            this.editDesdeRack.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x58);
            this.editDesdeRack.Location = point;
            this.editDesdeRack.MaxLength = 2;
            this.editDesdeRack.Name = "editDesdeRack";
            size = new Size(40, 0x16);
            this.editDesdeRack.Size = size;
            this.editDesdeRack.TabIndex = 5;
            this.editDesdeRack.Text = "";
            this.Label3.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 120);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x70, 0x17);
            this.Label3.Size = size;
            this.Label3.TabIndex = 6;
            this.Label3.Text = "Hasta Rack:";
            this.editHastaRack.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 120);
            this.editHastaRack.Location = point;
            this.editHastaRack.MaxLength = 2;
            this.editHastaRack.Name = "editHastaRack";
            size = new Size(40, 0x16);
            this.editHastaRack.Size = size;
            this.editHastaRack.TabIndex = 7;
            this.editHastaRack.Text = "";
            this.Label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x98);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x70, 0x17);
            this.Label1.Size = size;
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Referencia:";
            this.editReferencia.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x98);
            this.editReferencia.Location = point;
            this.editReferencia.MaxLength = 10;
            this.editReferencia.Name = "editReferencia";
            size = new Size(0xb8, 0x16);
            this.editReferencia.Size = size;
            this.editReferencia.TabIndex = 9;
            this.editReferencia.Text = "";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.editReferencia);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.editHastaRack);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.editDesdeRack);
            this.Controls.Add(this.dtpFechaInv);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.cbAlmacen);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmRepDifInv";
            this.Text = "Reporte Diferencias Inventario";
            this.WindowState = FormWindowState.Maximized;
            this.ResumeLayout(false);
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        internal virtual ComboBox cbAlmacen
        {
            get
            {
                return this._cbAlmacen;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cbAlmacen != null)
                {
                    this._cbAlmacen.KeyPress -= new KeyPressEventHandler(this.cbAlmacen_KeyPress);
                    this._cbAlmacen.SelectedIndexChanged -= new EventHandler(this.cbAlmacen_SelectedIndexChanged);
                }
                this._cbAlmacen = value;
                if (this._cbAlmacen != null)
                {
                    this._cbAlmacen.KeyPress += new KeyPressEventHandler(this.cbAlmacen_KeyPress);
                    this._cbAlmacen.SelectedIndexChanged += new EventHandler(this.cbAlmacen_SelectedIndexChanged);
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
                    this._dtpFechaInv.ValueChanged -= new EventHandler(this.dtpFechaInv_ValueChanged);
                }
                this._dtpFechaInv = value;
                if (this._dtpFechaInv != null)
                {
                    this._dtpFechaInv.KeyPress += new KeyPressEventHandler(this.dtpFechaInv_KeyPress);
                    this._dtpFechaInv.ValueChanged += new EventHandler(this.dtpFechaInv_ValueChanged);
                }
            }
        }

        internal virtual TextBox editDesdeRack
        {
            get
            {
                return this._editDesdeRack;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editDesdeRack != null)
                {
                    this._editDesdeRack.KeyPress -= new KeyPressEventHandler(this.editDesdeRack_KeyPress);
                    this._editDesdeRack.TextChanged -= new EventHandler(this.editNroOE_TextChanged);
                }
                this._editDesdeRack = value;
                if (this._editDesdeRack != null)
                {
                    this._editDesdeRack.KeyPress += new KeyPressEventHandler(this.editDesdeRack_KeyPress);
                    this._editDesdeRack.TextChanged += new EventHandler(this.editNroOE_TextChanged);
                }
            }
        }

        internal virtual TextBox editHastaRack
        {
            get
            {
                return this._editHastaRack;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editHastaRack != null)
                {
                    this._editHastaRack.KeyPress -= new KeyPressEventHandler(this.editHastaRack_KeyPress);
                    this._editHastaRack.TextChanged -= new EventHandler(this.editHastaRack_TextChanged);
                }
                this._editHastaRack = value;
                if (this._editHastaRack != null)
                {
                    this._editHastaRack.KeyPress += new KeyPressEventHandler(this.editHastaRack_KeyPress);
                    this._editHastaRack.TextChanged += new EventHandler(this.editHastaRack_TextChanged);
                }
            }
        }

        internal virtual TextBox editReferencia
        {
            get
            {
                return this._editReferencia;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editReferencia != null)
                {
                    this._editReferencia.KeyPress -= new KeyPressEventHandler(this.editReferencia_KeyPress);
                    this._editReferencia.TextChanged -= new EventHandler(this.editReferencia_TextChanged);
                }
                this._editReferencia = value;
                if (this._editReferencia != null)
                {
                    this._editReferencia.KeyPress += new KeyPressEventHandler(this.editReferencia_KeyPress);
                    this._editReferencia.TextChanged += new EventHandler(this.editReferencia_TextChanged);
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

