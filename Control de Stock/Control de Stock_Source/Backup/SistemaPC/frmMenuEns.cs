namespace SistemaPC
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmMenuEns : Form
    {
        [AccessedThroughProperty("cmbConsEns")]
        private Button _cmbConsEns;
        [AccessedThroughProperty("cmbEtiqRetStock")]
        private Button _cmbEtiqRetStock;
        [AccessedThroughProperty("cmbRepEnsXFecha")]
        private Button _cmbRepEnsXFecha;
        [AccessedThroughProperty("cmbRepOAPend")]
        private Button _cmbRepOAPend;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        private IContainer components;

        public frmMenuEns()
        {
            base.Load += new EventHandler(this.frmMenuEns_Load);
            base.Closed += new EventHandler(this.frmMenuEns_Closed);
            this.InitializeComponent();
        }

        private void cmbConsEns_Click(object sender, EventArgs e)
        {
            frmConsEns ens = new frmConsEns();
            this.Hide();
            ens.Show();
        }

        private void cmbEtiqRetStock_Click(object sender, EventArgs e)
        {
            frmEtiqRetStkOE koe = new frmEtiqRetStkOE();
            this.Hide();
            koe.Show();
        }

        private void cmbRepEnsXFecha_Click(object sender, EventArgs e)
        {
            frmRepEnsXFecha fecha = new frmRepEnsXFecha();
            this.Hide();
            fecha.Show();
        }

        private void cmbRepOAPend_Click(object sender, EventArgs e)
        {
            frmRepOAPend pend = new frmRepOAPend();
            this.Hide();
            pend.Show();
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

        private void frmMenuEns_Closed(object sender, EventArgs e)
        {
            new frmMenuPpal().Show();
        }

        private void frmMenuEns_Load(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(Application.StartupPath + @"\configu.txt");
            Variables.gServer = reader.ReadLine();
            reader.Close();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmMenuEns));
            this.GroupBox1 = new GroupBox();
            this.cmbConsEns = new Button();
            this.cmbRepEnsXFecha = new Button();
            this.cmbSalir = new Button();
            this.cmbRepOAPend = new Button();
            this.cmbEtiqRetStock = new Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            this.GroupBox1.Anchor = AnchorStyles.None;
            this.GroupBox1.Controls.Add(this.cmbEtiqRetStock);
            this.GroupBox1.Controls.Add(this.cmbConsEns);
            this.GroupBox1.Controls.Add(this.cmbRepEnsXFecha);
            this.GroupBox1.Controls.Add(this.cmbSalir);
            this.GroupBox1.Controls.Add(this.cmbRepOAPend);
            this.GroupBox1.Font = new Font("Arial", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Point point = new Point(0xe0, 0x98);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            Size size = new Size(0x130, 0x108);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Ordenes de Ensamblado";
            this.cmbConsEns.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 120);
            this.cmbConsEns.Location = point;
            this.cmbConsEns.Name = "cmbConsEns";
            size = new Size(120, 0x30);
            this.cmbConsEns.Size = size;
            this.cmbConsEns.TabIndex = 3;
            this.cmbConsEns.Text = "C&onsulta Ensamblado";
            this.cmbRepEnsXFecha.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x18, 120);
            this.cmbRepEnsXFecha.Location = point;
            this.cmbRepEnsXFecha.Name = "cmbRepEnsXFecha";
            size = new Size(120, 0x30);
            this.cmbRepEnsXFecha.Size = size;
            this.cmbRepEnsXFecha.TabIndex = 2;
            this.cmbRepEnsXFecha.Text = "&Ensamblados x Fecha";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            this.cmbSalir.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x58, 0xc0);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(120, 0x30);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 4;
            this.cmbSalir.Text = "&Salir";
            this.cmbRepOAPend.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x18, 0x30);
            this.cmbRepOAPend.Location = point;
            this.cmbRepOAPend.Name = "cmbRepOAPend";
            size = new Size(120, 0x30);
            this.cmbRepOAPend.Size = size;
            this.cmbRepOAPend.TabIndex = 0;
            this.cmbRepOAPend.Text = "&Calendario de Armados";
            this.cmbEtiqRetStock.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 0x30);
            this.cmbEtiqRetStock.Location = point;
            this.cmbEtiqRetStock.Name = "cmbEtiqRetStock";
            size = new Size(120, 0x30);
            this.cmbEtiqRetStock.Size = size;
            this.cmbEtiqRetStock.TabIndex = 1;
            this.cmbEtiqRetStock.Text = "Etiqueta &Retiro Stock";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.GroupBox1);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmMenuEns";
            this.Text = "Ordenes de Ensamblado";
            this.WindowState = FormWindowState.Maximized;
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        internal virtual Button cmbConsEns
        {
            get
            {
                return this._cmbConsEns;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbConsEns != null)
                {
                    this._cmbConsEns.Click -= new EventHandler(this.cmbConsEns_Click);
                }
                this._cmbConsEns = value;
                if (this._cmbConsEns != null)
                {
                    this._cmbConsEns.Click += new EventHandler(this.cmbConsEns_Click);
                }
            }
        }

        internal virtual Button cmbEtiqRetStock
        {
            get
            {
                return this._cmbEtiqRetStock;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbEtiqRetStock != null)
                {
                    this._cmbEtiqRetStock.Click -= new EventHandler(this.cmbEtiqRetStock_Click);
                }
                this._cmbEtiqRetStock = value;
                if (this._cmbEtiqRetStock != null)
                {
                    this._cmbEtiqRetStock.Click += new EventHandler(this.cmbEtiqRetStock_Click);
                }
            }
        }

        internal virtual Button cmbRepEnsXFecha
        {
            get
            {
                return this._cmbRepEnsXFecha;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbRepEnsXFecha != null)
                {
                    this._cmbRepEnsXFecha.Click -= new EventHandler(this.cmbRepEnsXFecha_Click);
                }
                this._cmbRepEnsXFecha = value;
                if (this._cmbRepEnsXFecha != null)
                {
                    this._cmbRepEnsXFecha.Click += new EventHandler(this.cmbRepEnsXFecha_Click);
                }
            }
        }

        internal virtual Button cmbRepOAPend
        {
            get
            {
                return this._cmbRepOAPend;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbRepOAPend != null)
                {
                    this._cmbRepOAPend.Click -= new EventHandler(this.cmbRepOAPend_Click);
                }
                this._cmbRepOAPend = value;
                if (this._cmbRepOAPend != null)
                {
                    this._cmbRepOAPend.Click += new EventHandler(this.cmbRepOAPend_Click);
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

