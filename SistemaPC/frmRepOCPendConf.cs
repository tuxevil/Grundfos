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

    public class frmRepOCPendConf : Form
    {
        [AccessedThroughProperty("cbAlmacen")]
        private ComboBox _cbAlmacen;
        [AccessedThroughProperty("cbMetEnv")]
        private ComboBox _cbMetEnv;
        [AccessedThroughProperty("cbProveedor")]
        private ComboBox _cbProveedor;
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        public SqlDataAdapter AdapAlmacen;
        public SqlDataAdapter AdapMetEnv;
        public SqlDataAdapter AdapProveedor;
        private IContainer components;
        public DataSet DS;

        public frmRepOCPendConf()
        {
            base.Closed += new EventHandler(this.frmRepOCPendConf_Closed);
            base.Load += new EventHandler(this.frmRepOCPendConf_Load);
            this.DS = new DataSet();
            this.InitializeComponent();
        }

        private void cbAlmacen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cbMetEnv.Focus();
            }
        }

        private void cbAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbMetEnv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void cbMetEnv_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cbAlmacen.Focus();
            }
        }

        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            this.cmbAceptar.Enabled = false;
            this.cmbSalir.Enabled = false;
            if (StringType.StrCmp(this.cbProveedor.Text, Strings.Space(0), false) != 0)
            {
                Variables.gCodProv = StringType.FromObject(this.cbProveedor.SelectedValue);
                Variables.gNomProv = this.cbProveedor.Text;
            }
            else
            {
                Variables.gCodProv = "";
                Variables.gNomProv = "";
            }
            if (StringType.StrCmp(this.cbAlmacen.Text, Strings.Space(0), false) != 0)
            {
                Variables.gCodAlmacen = StringType.FromObject(this.cbAlmacen.SelectedValue);
                Variables.gNomAlmacen = this.cbAlmacen.Text;
            }
            else
            {
                Variables.gCodAlmacen = "";
                Variables.gNomAlmacen = "";
            }
            if (StringType.StrCmp(this.cbMetEnv.Text, Strings.Space(0), false) != 0)
            {
                Variables.gCodMetEnt = StringType.FromObject(this.cbMetEnv.SelectedValue);
                Variables.gDescMetEnt = this.cbMetEnv.Text;
            }
            else
            {
                Variables.gCodMetEnt = "";
                Variables.gDescMetEnt = "";
            }
            new frmRepOCPendConf1().ShowDialog();
            this.cmbAceptar.Enabled = true;
            this.cmbSalir.Enabled = true;
            this.cbProveedor.Text = "";
            this.cbProveedor.SelectedValue = "";
            this.cbAlmacen.Text = "";
            this.cbAlmacen.SelectedValue = "";
            this.cbMetEnv.Text = "";
            this.cbMetEnv.SelectedValue = "";
            this.cbProveedor.Text = "";
            this.cbProveedor.SelectedValue = "";
            this.cbMetEnv.Text = "";
            this.cbMetEnv.SelectedValue = "";
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

        ~frmRepOCPendConf()
        {
        }

        private void frmRepOCPendConf_Closed(object sender, EventArgs e)
        {
            new frmMenuOCompra().Show();
        }

        private void frmRepOCPendConf_Load(object sender, EventArgs e)
        {
            bool flag = false;
            try
            {
                string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
                string selectCommandText = "SELECT distinct LTRIM(PC01003) + '-' + LTRIM(PL01002) AS NomProv,PC01003 FROM dbo.PC010100 inner join PL010100 on PC01003=PL01001 inner join PC030100 on PC01001=PC03001 where PC03010-PC03011<>0 and PC03029=''";
                this.AdapProveedor = new SqlDataAdapter(selectCommandText, selectConnectionString);
                this.AdapProveedor.Fill(this.DS, "PC010100");
                this.cbProveedor.DataSource = this.DS.Tables["PC010100"];
                this.cbProveedor.DisplayMember = "NomProv";
                this.cbProveedor.ValueMember = "PC01003";
                this.cbProveedor.Refresh();
                selectCommandText = "select ltrim(SC23001) + '-' + ltrim(SC23002) as NomAlmacen,SC23001 from SC230100 order by SC23001";
                this.AdapAlmacen = new SqlDataAdapter(selectCommandText, selectConnectionString);
                this.DS.Tables.Clear();
                this.AdapAlmacen.Fill(this.DS, "SC230100");
                this.cbAlmacen.DataSource = this.DS.Tables["SC230100"];
                this.cbAlmacen.DisplayMember = "NomAlmacen";
                this.cbAlmacen.ValueMember = "SC23001";
                this.cbAlmacen.Refresh();
                selectCommandText = "SELECT ltrim(PL23003) + '-' + ltrim(PL23004) as NomMetEnv,PL23003 FROM dbo.PL230100 where PL23001='2' and PL23002='00'";
                this.AdapMetEnv = new SqlDataAdapter(selectCommandText, selectConnectionString);
                this.AdapMetEnv.Fill(this.DS, "PL230100");
                this.cbMetEnv.DataSource = this.DS.Tables["PL230100"];
                this.cbMetEnv.DisplayMember = "NomMetEnv";
                this.cbMetEnv.ValueMember = "PL23003";
                this.cbMetEnv.Refresh();
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
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                this.Close();
                ProjectData.ClearProjectError();
            }
            this.cbProveedor.Text = "";
            this.cbProveedor.SelectedValue = "";
            this.cbAlmacen.Text = "";
            this.cbAlmacen.SelectedValue = "";
            this.cbMetEnv.Text = "";
            this.cbMetEnv.SelectedValue = "";
            this.cbProveedor.Focus();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRepOCPendConf));
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.cbAlmacen = new ComboBox();
            this.Label4 = new Label();
            this.cbProveedor = new ComboBox();
            this.Label2 = new Label();
            this.cbMetEnv = new ComboBox();
            this.Label1 = new Label();
            this.SuspendLayout();
            this.cmbAceptar.BackColor = SystemColors.Control;
            Point point = new Point(0x1f8, 0x88);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 6;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(400, 0x88);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 7;
            this.cmbSalir.Text = "&Salir";
            this.cbAlmacen.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x30);
            this.cbAlmacen.Location = point;
            this.cbAlmacen.Name = "cbAlmacen";
            size = new Size(440, 0x18);
            this.cbAlmacen.Size = size;
            this.cbAlmacen.TabIndex = 3;
            this.cbAlmacen.Text = "ComboBox2";
            this.Label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x38);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(120, 0x10);
            this.Label4.Size = size;
            this.Label4.TabIndex = 2;
            this.Label4.Text = "Almac\x00e9n:";
            this.cbProveedor.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 8);
            this.cbProveedor.Location = point;
            this.cbProveedor.Name = "cbProveedor";
            size = new Size(440, 0x18);
            this.cbProveedor.Size = size;
            this.cbProveedor.TabIndex = 1;
            this.cbProveedor.Text = "ComboBox1";
            this.Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x10);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(120, 0x10);
            this.Label2.Size = size;
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Proveedor:";
            this.cbMetEnv.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x58);
            this.cbMetEnv.Location = point;
            this.cbMetEnv.Name = "cbMetEnv";
            size = new Size(440, 0x18);
            this.cbMetEnv.Size = size;
            this.cbMetEnv.TabIndex = 5;
            this.cbMetEnv.Text = "ComboBox3";
            this.Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x60);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(120, 0x10);
            this.Label1.Size = size;
            this.Label1.TabIndex = 4;
            this.Label1.Text = "M\x00e9todo de Env\x00edo:";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.BackColor = SystemColors.Control;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.cbMetEnv);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cbAlmacen);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.cbProveedor);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmRepOCPendConf";
            this.Text = "Reporte O.Compra Pendientes de Confirmaci\x00f3n";
            this.WindowState = FormWindowState.Maximized;
            this.ResumeLayout(false);
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

        internal virtual ComboBox cbMetEnv
        {
            get
            {
                return this._cbMetEnv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cbMetEnv != null)
                {
                    this._cbMetEnv.KeyPress -= new KeyPressEventHandler(this.cbMetEnv_KeyPress);
                    this._cbMetEnv.SelectedIndexChanged -= new EventHandler(this.cbMetEnv_SelectedIndexChanged);
                }
                this._cbMetEnv = value;
                if (this._cbMetEnv != null)
                {
                    this._cbMetEnv.KeyPress += new KeyPressEventHandler(this.cbMetEnv_KeyPress);
                    this._cbMetEnv.SelectedIndexChanged += new EventHandler(this.cbMetEnv_SelectedIndexChanged);
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
    }
}

