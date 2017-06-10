namespace SistemaPC
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmMenuOCompra : Form
    {
        [AccessedThroughProperty("cmbBorrarRecep")]
        private Button _cmbBorrarRecep;
        [AccessedThroughProperty("cmbDifOCProv")]
        private Button _cmbDifOCProv;
        [AccessedThroughProperty("cmbDiscrepanciasOC")]
        private Button _cmbDiscrepanciasOC;
        [AccessedThroughProperty("cmbGenOC")]
        private Button _cmbGenOC;
        [AccessedThroughProperty("cmbGenOCExp")]
        private Button _cmbGenOCExp;
        [AccessedThroughProperty("cmbRecepcion")]
        private Button _cmbRecepcion;
        [AccessedThroughProperty("cmbRecOCManual")]
        private Button _cmbRecOCManual;
        [AccessedThroughProperty("cmbRepOCConfPend")]
        private Button _cmbRepOCConfPend;
        [AccessedThroughProperty("cmbRepOCPend")]
        private Button _cmbRepOCPend;
        [AccessedThroughProperty("cmbRepOCPendConf")]
        private Button _cmbRepOCPendConf;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        private IContainer components;

        public frmMenuOCompra()
        {
            base.Load += new EventHandler(this.frmRecepcion_Load);
            base.Closed += new EventHandler(this.frmMenuOCompra_Closed);
            this.InitializeComponent();
        }

        private void cmbBorrarRecep_Click(object sender, EventArgs e)
        {
            Variables.gPackList = "";
            Variables.gOpc = "B";
            new frmSelecDesp().ShowDialog();
            if (StringType.StrCmp(Variables.gPackList, "", false) != 0)
            {
                frmBorrarRecep recep = new frmBorrarRecep();
                this.Hide();
                recep.Show();
            }
        }

        private void cmbDifOCProv_Click(object sender, EventArgs e)
        {
            frmDifOCProv prov = new frmDifOCProv();
            this.Hide();
            prov.Show();
        }

        private void cmbDiscrepanciasOC_Click(object sender, EventArgs e)
        {
            Variables.gPackList = "";
            Variables.gOpc = "D";
            new frmSelecDesp().ShowDialog();
            if (StringType.StrCmp(Variables.gPackList, "", false) != 0)
            {
                frmDiscrepanciasOC soc = new frmDiscrepanciasOC();
                Variables.gOrdenDisc = 0;
                this.Hide();
                soc.Show();
            }
        }

        private void cmbGenOC_Click(object sender, EventArgs e)
        {
            frmGenOC noc = new frmGenOC();
            this.Hide();
            noc.Show();
        }

        private void cmbGenOCExp_Click(object sender, EventArgs e)
        {
            frmGenOCExp exp = new frmGenOCExp();
            this.Hide();
            exp.Show();
        }

        private void cmbRecepcion_Click(object sender, EventArgs e)
        {
            frmRecepcionOC0 noc = new frmRecepcionOC0();
            this.Hide();
            noc.Show();
        }

        private void cmbRecOCManual_Click(object sender, EventArgs e)
        {
            frmRecOCManual manual = new frmRecOCManual();
            this.Hide();
            manual.Show();
        }

        private void cmbRepOCConfPend_Click(object sender, EventArgs e)
        {
            frmRepOCConfPend pend = new frmRepOCConfPend();
            this.Hide();
            pend.Show();
        }

        private void cmbRepOCPend_Click(object sender, EventArgs e)
        {
            frmRepOCPend pend = new frmRepOCPend();
            this.Hide();
            pend.Show();
        }

        private void cmbRepOCPendConf_Click(object sender, EventArgs e)
        {
            frmRepOCPendConf conf = new frmRepOCPendConf();
            this.Hide();
            conf.Show();
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

        private void frmMenuOCompra_Closed(object sender, EventArgs e)
        {
            new frmMenuPpal().Show();
        }

        private void frmRecepcion_Load(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(Application.StartupPath + @"\configu.txt");
            Variables.gServer = reader.ReadLine();
            reader.Close();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.GroupBox1 = new GroupBox();
            this.cmbGenOCExp = new Button();
            this.cmbRepOCPendConf = new Button();
            this.cmbRepOCConfPend = new Button();
            this.cmbGenOC = new Button();
            this.cmbDifOCProv = new Button();
            this.cmbRepOCPend = new Button();
            this.cmbRecepcion = new Button();
            this.cmbDiscrepanciasOC = new Button();
            this.cmbSalir = new Button();
            this.cmbBorrarRecep = new Button();
            this.cmbRecOCManual = new Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            this.GroupBox1.Anchor = AnchorStyles.None;
            this.GroupBox1.Controls.Add(this.cmbRecOCManual);
            this.GroupBox1.Controls.Add(this.cmbGenOCExp);
            this.GroupBox1.Controls.Add(this.cmbRepOCPendConf);
            this.GroupBox1.Controls.Add(this.cmbRepOCConfPend);
            this.GroupBox1.Controls.Add(this.cmbGenOC);
            this.GroupBox1.Controls.Add(this.cmbDifOCProv);
            this.GroupBox1.Controls.Add(this.cmbRepOCPend);
            this.GroupBox1.Controls.Add(this.cmbRecepcion);
            this.GroupBox1.Controls.Add(this.cmbDiscrepanciasOC);
            this.GroupBox1.Controls.Add(this.cmbSalir);
            this.GroupBox1.Controls.Add(this.cmbBorrarRecep);
            this.GroupBox1.Font = new Font("Arial", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Point point = new Point(240, 40);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            Size size = new Size(0x130, 0x1d4);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Men\x00fa O.Compra";
            this.cmbGenOCExp.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 0xc0);
            this.cmbGenOCExp.Location = point;
            this.cmbGenOCExp.Name = "cmbGenOCExp";
            size = new Size(120, 0x30);
            this.cmbGenOCExp.Size = size;
            this.cmbGenOCExp.TabIndex = 5;
            this.cmbGenOCExp.Text = "Generaci\x00f3n OC &Exportaci\x00f3n";
            this.cmbRepOCPendConf.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x18, 0x150);
            this.cmbRepOCPendConf.Location = point;
            this.cmbRepOCPendConf.Name = "cmbRepOCPendConf";
            size = new Size(120, 0x30);
            this.cmbRepOCPendConf.Size = size;
            this.cmbRepOCPendConf.TabIndex = 8;
            this.cmbRepOCPendConf.Text = "OC &Pend. Confirmaci\x00f3n";
            this.cmbRepOCConfPend.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 0x150);
            this.cmbRepOCConfPend.Location = point;
            this.cmbRepOCConfPend.Name = "cmbRepOCConfPend";
            size = new Size(120, 0x30);
            this.cmbRepOCConfPend.Size = size;
            this.cmbRepOCConfPend.TabIndex = 9;
            this.cmbRepOCConfPend.Text = "OC &Conf. Pendientes";
            this.cmbGenOC.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x18, 0xc0);
            this.cmbGenOC.Location = point;
            this.cmbGenOC.Name = "cmbGenOC";
            size = new Size(120, 0x30);
            this.cmbGenOC.Size = size;
            this.cmbGenOC.TabIndex = 4;
            this.cmbGenOC.Text = "&Generaci\x00f3n O.Compra";
            this.cmbDifOCProv.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x18, 0x108);
            this.cmbDifOCProv.Location = point;
            this.cmbDifOCProv.Name = "cmbDifOCProv";
            size = new Size(120, 0x30);
            this.cmbDifOCProv.Size = size;
            this.cmbDifOCProv.TabIndex = 6;
            this.cmbDifOCProv.Text = "Di&f. OC con Proveedor";
            this.cmbRepOCPend.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 0x108);
            this.cmbRepOCPend.Location = point;
            this.cmbRepOCPend.Name = "cmbRepOCPend";
            size = new Size(120, 0x30);
            this.cmbRepOCPend.Size = size;
            this.cmbRepOCPend.TabIndex = 7;
            this.cmbRepOCPend.Text = "&O.Compra Pendientes";
            this.cmbRecepcion.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x18, 0x30);
            this.cmbRecepcion.Location = point;
            this.cmbRecepcion.Name = "cmbRecepcion";
            size = new Size(120, 0x30);
            this.cmbRecepcion.Size = size;
            this.cmbRecepcion.TabIndex = 0;
            this.cmbRecepcion.Text = "&Recepci\x00f3n";
            this.cmbDiscrepanciasOC.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 0x30);
            this.cmbDiscrepanciasOC.Location = point;
            this.cmbDiscrepanciasOC.Name = "cmbDiscrepanciasOC";
            size = new Size(120, 0x30);
            this.cmbDiscrepanciasOC.Size = size;
            this.cmbDiscrepanciasOC.TabIndex = 1;
            this.cmbDiscrepanciasOC.Text = "&Discrepancias OC";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            this.cmbSalir.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x58, 0x198);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(120, 0x30);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 10;
            this.cmbSalir.Text = "&Salir";
            this.cmbBorrarRecep.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x18, 120);
            this.cmbBorrarRecep.Location = point;
            this.cmbBorrarRecep.Name = "cmbBorrarRecep";
            size = new Size(120, 0x30);
            this.cmbBorrarRecep.Size = size;
            this.cmbBorrarRecep.TabIndex = 2;
            this.cmbBorrarRecep.Text = "&Borrar Recepci\x00f3n";
            this.cmbRecOCManual.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 120);
            this.cmbRecOCManual.Location = point;
            this.cmbRecOCManual.Name = "cmbRecOCManual";
            size = new Size(120, 0x30);
            this.cmbRecOCManual.Size = size;
            this.cmbRecOCManual.TabIndex = 3;
            this.cmbRecOCManual.Text = "Recep. OC &Manual";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.GroupBox1);
            this.Name = "frmMenuOCompra";
            this.Text = "Men\x00fa O.Compra";
            this.WindowState = FormWindowState.Maximized;
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        internal virtual Button cmbBorrarRecep
        {
            get
            {
                return this._cmbBorrarRecep;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbBorrarRecep != null)
                {
                    this._cmbBorrarRecep.Click -= new EventHandler(this.cmbBorrarRecep_Click);
                }
                this._cmbBorrarRecep = value;
                if (this._cmbBorrarRecep != null)
                {
                    this._cmbBorrarRecep.Click += new EventHandler(this.cmbBorrarRecep_Click);
                }
            }
        }

        internal virtual Button cmbDifOCProv
        {
            get
            {
                return this._cmbDifOCProv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbDifOCProv != null)
                {
                    this._cmbDifOCProv.Click -= new EventHandler(this.cmbDifOCProv_Click);
                }
                this._cmbDifOCProv = value;
                if (this._cmbDifOCProv != null)
                {
                    this._cmbDifOCProv.Click += new EventHandler(this.cmbDifOCProv_Click);
                }
            }
        }

        internal virtual Button cmbDiscrepanciasOC
        {
            get
            {
                return this._cmbDiscrepanciasOC;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbDiscrepanciasOC != null)
                {
                    this._cmbDiscrepanciasOC.Click -= new EventHandler(this.cmbDiscrepanciasOC_Click);
                }
                this._cmbDiscrepanciasOC = value;
                if (this._cmbDiscrepanciasOC != null)
                {
                    this._cmbDiscrepanciasOC.Click += new EventHandler(this.cmbDiscrepanciasOC_Click);
                }
            }
        }

        internal virtual Button cmbGenOC
        {
            get
            {
                return this._cmbGenOC;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbGenOC != null)
                {
                    this._cmbGenOC.Click -= new EventHandler(this.cmbGenOC_Click);
                }
                this._cmbGenOC = value;
                if (this._cmbGenOC != null)
                {
                    this._cmbGenOC.Click += new EventHandler(this.cmbGenOC_Click);
                }
            }
        }

        internal virtual Button cmbGenOCExp
        {
            get
            {
                return this._cmbGenOCExp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbGenOCExp != null)
                {
                    this._cmbGenOCExp.Click -= new EventHandler(this.cmbGenOCExp_Click);
                }
                this._cmbGenOCExp = value;
                if (this._cmbGenOCExp != null)
                {
                    this._cmbGenOCExp.Click += new EventHandler(this.cmbGenOCExp_Click);
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
                    this._cmbRecepcion.Click -= new EventHandler(this.cmbRecepcion_Click);
                }
                this._cmbRecepcion = value;
                if (this._cmbRecepcion != null)
                {
                    this._cmbRecepcion.Click += new EventHandler(this.cmbRecepcion_Click);
                }
            }
        }

        internal virtual Button cmbRecOCManual
        {
            get
            {
                return this._cmbRecOCManual;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbRecOCManual != null)
                {
                    this._cmbRecOCManual.Click -= new EventHandler(this.cmbRecOCManual_Click);
                }
                this._cmbRecOCManual = value;
                if (this._cmbRecOCManual != null)
                {
                    this._cmbRecOCManual.Click += new EventHandler(this.cmbRecOCManual_Click);
                }
            }
        }

        internal virtual Button cmbRepOCConfPend
        {
            get
            {
                return this._cmbRepOCConfPend;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbRepOCConfPend != null)
                {
                    this._cmbRepOCConfPend.Click -= new EventHandler(this.cmbRepOCConfPend_Click);
                }
                this._cmbRepOCConfPend = value;
                if (this._cmbRepOCConfPend != null)
                {
                    this._cmbRepOCConfPend.Click += new EventHandler(this.cmbRepOCConfPend_Click);
                }
            }
        }

        internal virtual Button cmbRepOCPend
        {
            get
            {
                return this._cmbRepOCPend;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbRepOCPend != null)
                {
                    this._cmbRepOCPend.Click -= new EventHandler(this.cmbRepOCPend_Click);
                }
                this._cmbRepOCPend = value;
                if (this._cmbRepOCPend != null)
                {
                    this._cmbRepOCPend.Click += new EventHandler(this.cmbRepOCPend_Click);
                }
            }
        }

        internal virtual Button cmbRepOCPendConf
        {
            get
            {
                return this._cmbRepOCPendConf;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbRepOCPendConf != null)
                {
                    this._cmbRepOCPendConf.Click -= new EventHandler(this.cmbRepOCPendConf_Click);
                }
                this._cmbRepOCPendConf = value;
                if (this._cmbRepOCPendConf != null)
                {
                    this._cmbRepOCPendConf.Click += new EventHandler(this.cmbRepOCPendConf_Click);
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

