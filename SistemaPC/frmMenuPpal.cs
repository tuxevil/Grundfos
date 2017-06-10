namespace SistemaPC
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class frmMenuPpal : Form
    {
        [AccessedThroughProperty("cmbInventario")]
        private Button _cmbInventario;
        [AccessedThroughProperty("cmbMenuEns")]
        private Button _cmbMenuEns;
        [AccessedThroughProperty("cmbMenuExp")]
        private Button _cmbMenuExp;
        [AccessedThroughProperty("cmbMenuOV")]
        private Button _cmbMenuOV;
        [AccessedThroughProperty("cmbMenuOVExp")]
        private Button _cmbMenuOVExp;
        [AccessedThroughProperty("cmbPrepPed")]
        private Button _cmbPrepPed;
        [AccessedThroughProperty("cmbRecepcion")]
        private Button _cmbRecepcion;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("cmbTerminales")]
        private Button _cmbTerminales;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        private IContainer components;

        public frmMenuPpal()
        {
            base.Load += new EventHandler(this.frmMenuPpal_Load);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");
            this.InitializeComponent();
        }

        private void cmbDiscrepanciasOC_Click(object sender, EventArgs e)
        {
            frmMenuOCompra compra = new frmMenuOCompra();
            this.Hide();
            compra.Show();
        }

        private void cmbInventario_Click(object sender, EventArgs e)
        {
            frmInventario inventario = new frmInventario();
            this.Hide();
            inventario.Show();
        }

        private void cmbMenuEns_Click(object sender, EventArgs e)
        {
            frmMenuEns ens = new frmMenuEns();
            this.Hide();
            ens.Show();
        }

        private void cmbMenuExp_Click(object sender, EventArgs e)
        {
            frmMenuExp exp = new frmMenuExp();
            this.Hide();
            exp.Show();
        }

        private void cmbMenuOV_Click(object sender, EventArgs e)
        {
            frmMenuOV uov = new frmMenuOV();
            this.Hide();
            uov.Show();
        }

        private void cmbMenuOVExp_Click(object sender, EventArgs e)
        {
            frmMenuOVExp exp = new frmMenuOVExp();
            this.Hide();
            exp.Show();
        }

        private void cmbPrepPed_Click(object sender, EventArgs e)
        {
            frmPrepPed ped = new frmPrepPed();
            this.Hide();
            ped.Show();
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbTerminales_Click(object sender, EventArgs e)
        {
            frmTerminales terminales = new frmTerminales();
            this.Hide();
            terminales.Show();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmMenuPpal_Load(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(Application.StartupPath + @"\configu.txt");
            Variables.gServer = reader.ReadLine();
            Variables.gPathTxt = reader.ReadLine();
            Variables.gTermi = reader.ReadLine();
            reader.Close();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmMenuPpal));
            this.GroupBox1 = new GroupBox();
            this.cmbMenuOVExp = new Button();
            this.cmbInventario = new Button();
            this.cmbMenuEns = new Button();
            this.cmbPrepPed = new Button();
            this.cmbTerminales = new Button();
            this.cmbRecepcion = new Button();
            this.cmbSalir = new Button();
            this.cmbMenuOV = new Button();
            this.cmbMenuExp = new Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            this.GroupBox1.Anchor = AnchorStyles.None;
            this.GroupBox1.Controls.Add(this.cmbMenuExp);
            this.GroupBox1.Controls.Add(this.cmbMenuOVExp);
            this.GroupBox1.Controls.Add(this.cmbInventario);
            this.GroupBox1.Controls.Add(this.cmbMenuEns);
            this.GroupBox1.Controls.Add(this.cmbPrepPed);
            this.GroupBox1.Controls.Add(this.cmbTerminales);
            this.GroupBox1.Controls.Add(this.cmbRecepcion);
            this.GroupBox1.Controls.Add(this.cmbSalir);
            this.GroupBox1.Controls.Add(this.cmbMenuOV);
            this.GroupBox1.Font = new Font("Arial", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Point point = new Point(0x150, 0x98);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            Size size = new Size(0x130, 400);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Men\x00fa Principal";
            this.cmbMenuOVExp.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x18, 120);
            this.cmbMenuOVExp.Location = point;
            this.cmbMenuOVExp.Name = "cmbMenuOVExp";
            size = new Size(120, 0x30);
            this.cmbMenuOVExp.Size = size;
            this.cmbMenuOVExp.TabIndex = 2;
            this.cmbMenuOVExp.Text = "OV &Exportaci\x00f3n";
            this.cmbInventario.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x18, 0x108);
            this.cmbInventario.Location = point;
            this.cmbInventario.Name = "cmbInventario";
            size = new Size(120, 0x30);
            this.cmbInventario.Size = size;
            this.cmbInventario.TabIndex = 6;
            this.cmbInventario.Text = "Toma de &Inventarios";
            this.cmbMenuEns.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x18, 0xc0);
            this.cmbMenuEns.Location = point;
            this.cmbMenuEns.Name = "cmbMenuEns";
            size = new Size(120, 0x30);
            this.cmbMenuEns.Size = size;
            this.cmbMenuEns.TabIndex = 4;
            this.cmbMenuEns.Text = "&Ensamblados";
            this.cmbPrepPed.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 120);
            this.cmbPrepPed.Location = point;
            this.cmbPrepPed.Name = "cmbPrepPed";
            size = new Size(120, 0x30);
            this.cmbPrepPed.Size = size;
            this.cmbPrepPed.TabIndex = 3;
            this.cmbPrepPed.Text = "&Prep.Pedidos";
            this.cmbTerminales.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 0x108);
            this.cmbTerminales.Location = point;
            this.cmbTerminales.Name = "cmbTerminales";
            size = new Size(120, 0x30);
            this.cmbTerminales.Size = size;
            this.cmbTerminales.TabIndex = 7;
            this.cmbTerminales.Text = "&Terminales";
            this.cmbRecepcion.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x18, 0x30);
            this.cmbRecepcion.Location = point;
            this.cmbRecepcion.Name = "cmbRecepcion";
            size = new Size(120, 0x30);
            this.cmbRecepcion.Size = size;
            this.cmbRecepcion.TabIndex = 0;
            this.cmbRecepcion.Text = "&O.Compra";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            this.cmbSalir.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x60, 0x150);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(120, 0x30);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 8;
            this.cmbSalir.Text = "&Salir";
            this.cmbMenuOV.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 0x30);
            this.cmbMenuOV.Location = point;
            this.cmbMenuOV.Name = "cmbMenuOV";
            size = new Size(120, 0x30);
            this.cmbMenuOV.Size = size;
            this.cmbMenuOV.TabIndex = 1;
            this.cmbMenuOV.Text = "O&V Locales";
            this.cmbMenuExp.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 0xc0);
            this.cmbMenuExp.Location = point;
            this.cmbMenuExp.Name = "cmbMenuExp";
            size = new Size(120, 0x30);
            this.cmbMenuExp.Size = size;
            this.cmbMenuExp.TabIndex = 5;
            this.cmbMenuExp.Text = "E&xpedici\x00f3n";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x404, 0x2f1);
            this.ClientSize = size;
            this.Controls.Add(this.GroupBox1);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmMenuPpal";
            this.Text = "Control de Stock";
            this.WindowState = FormWindowState.Maximized;
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        [STAThread]
        public static void Main()
        {
            Application.Run(new frmMenuPpal());
        }

        internal virtual Button cmbInventario
        {
            get
            {
                return this._cmbInventario;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbInventario != null)
                {
                    this._cmbInventario.Click -= new EventHandler(this.cmbInventario_Click);
                }
                this._cmbInventario = value;
                if (this._cmbInventario != null)
                {
                    this._cmbInventario.Click += new EventHandler(this.cmbInventario_Click);
                }
            }
        }

        internal virtual Button cmbMenuEns
        {
            get
            {
                return this._cmbMenuEns;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbMenuEns != null)
                {
                    this._cmbMenuEns.Click -= new EventHandler(this.cmbMenuEns_Click);
                }
                this._cmbMenuEns = value;
                if (this._cmbMenuEns != null)
                {
                    this._cmbMenuEns.Click += new EventHandler(this.cmbMenuEns_Click);
                }
            }
        }

        internal virtual Button cmbMenuExp
        {
            get
            {
                return this._cmbMenuExp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbMenuExp != null)
                {
                    this._cmbMenuExp.Click -= new EventHandler(this.cmbMenuExp_Click);
                }
                this._cmbMenuExp = value;
                if (this._cmbMenuExp != null)
                {
                    this._cmbMenuExp.Click += new EventHandler(this.cmbMenuExp_Click);
                }
            }
        }

        internal virtual Button cmbMenuOV
        {
            get
            {
                return this._cmbMenuOV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbMenuOV != null)
                {
                    this._cmbMenuOV.Click -= new EventHandler(this.cmbMenuOV_Click);
                }
                this._cmbMenuOV = value;
                if (this._cmbMenuOV != null)
                {
                    this._cmbMenuOV.Click += new EventHandler(this.cmbMenuOV_Click);
                }
            }
        }

        internal virtual Button cmbMenuOVExp
        {
            get
            {
                return this._cmbMenuOVExp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbMenuOVExp != null)
                {
                    this._cmbMenuOVExp.Click -= new EventHandler(this.cmbMenuOVExp_Click);
                }
                this._cmbMenuOVExp = value;
                if (this._cmbMenuOVExp != null)
                {
                    this._cmbMenuOVExp.Click += new EventHandler(this.cmbMenuOVExp_Click);
                }
            }
        }

        internal virtual Button cmbPrepPed
        {
            get
            {
                return this._cmbPrepPed;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbPrepPed != null)
                {
                    this._cmbPrepPed.Click -= new EventHandler(this.cmbPrepPed_Click);
                }
                this._cmbPrepPed = value;
                if (this._cmbPrepPed != null)
                {
                    this._cmbPrepPed.Click += new EventHandler(this.cmbPrepPed_Click);
                }
            }
        }

        internal virtual Button cmbRecepcion
        {
            get
            {
                return this._cmbRecepcion;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbRecepcion != null)
                {
                    this._cmbRecepcion.Click -= new EventHandler(this.cmbDiscrepanciasOC_Click);
                }
                this._cmbRecepcion = value;
                if (this._cmbRecepcion != null)
                {
                    this._cmbRecepcion.Click += new EventHandler(this.cmbDiscrepanciasOC_Click);
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

        internal virtual Button cmbTerminales
        {
            get
            {
                return this._cmbTerminales;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbTerminales != null)
                {
                    this._cmbTerminales.Click -= new EventHandler(this.cmbTerminales_Click);
                }
                this._cmbTerminales = value;
                if (this._cmbTerminales != null)
                {
                    this._cmbTerminales.Click += new EventHandler(this.cmbTerminales_Click);
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
    }
}

