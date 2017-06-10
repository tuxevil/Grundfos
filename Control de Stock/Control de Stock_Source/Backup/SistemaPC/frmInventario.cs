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

    public class frmInventario : Form
    {
        [AccessedThroughProperty("cmbConsInv")]
        private Button _cmbConsInv;
        [AccessedThroughProperty("cmbGenDifInv")]
        private Button _cmbGenDifInv;
        [AccessedThroughProperty("cmbRepDifInv")]
        private Button _cmbRepDifInv;
        [AccessedThroughProperty("cmbRepInvFis")]
        private Button _cmbRepInvFis;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        private IContainer components;

        public frmInventario()
        {
            base.Load += new EventHandler(this.frmInventario_Load);
            base.Closed += new EventHandler(this.frmInventario_Closed);
            this.InitializeComponent();
        }

        private void cmbConsInv_Click(object sender, EventArgs e)
        {
            frmConsInv inv = new frmConsInv();
            this.Hide();
            inv.Show();
        }

        private void cmbGenDifInv_Click(object sender, EventArgs e)
        {
            frmGenDifInv inv = new frmGenDifInv();
            this.Hide();
            inv.Show();
        }

        private void cmbRepDifInv_Click(object sender, EventArgs e)
        {
            frmRepDifInv inv = new frmRepDifInv();
            this.Hide();
            inv.Show();
        }

        private void cmbRepInvFis_Click(object sender, EventArgs e)
        {
            frmRepInvFis fis = new frmRepInvFis();
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

        private void frmInventario_Closed(object sender, EventArgs e)
        {
            new frmMenuPpal().Show();
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(Application.StartupPath + @"\configu.txt");
            Variables.gServer = reader.ReadLine();
            reader.Close();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmInventario));
            this.GroupBox1 = new GroupBox();
            this.cmbRepDifInv = new Button();
            this.cmbSalir = new Button();
            this.cmbRepInvFis = new Button();
            this.cmbGenDifInv = new Button();
            this.cmbConsInv = new Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            this.GroupBox1.Anchor = AnchorStyles.None;
            this.GroupBox1.Controls.Add(this.cmbConsInv);
            this.GroupBox1.Controls.Add(this.cmbGenDifInv);
            this.GroupBox1.Controls.Add(this.cmbRepInvFis);
            this.GroupBox1.Controls.Add(this.cmbRepDifInv);
            this.GroupBox1.Controls.Add(this.cmbSalir);
            this.GroupBox1.Font = new Font("Arial", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Point point = new Point(0xe0, 0x98);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            Size size = new Size(0x130, 240);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Toma de Inventarios";
            this.cmbRepDifInv.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x18, 0x70);
            this.cmbRepDifInv.Location = point;
            this.cmbRepDifInv.Name = "cmbRepDifInv";
            size = new Size(120, 0x30);
            this.cmbRepDifInv.Size = size;
            this.cmbRepDifInv.TabIndex = 2;
            this.cmbRepDifInv.Text = "Rep.&Diferencias  Inventario";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            this.cmbSalir.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x58, 0xb0);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(120, 0x30);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 4;
            this.cmbSalir.Text = "&Salir";
            this.cmbRepInvFis.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x18, 0x30);
            this.cmbRepInvFis.Location = point;
            this.cmbRepInvFis.Name = "cmbRepInvFis";
            size = new Size(120, 0x30);
            this.cmbRepInvFis.Size = size;
            this.cmbRepInvFis.TabIndex = 0;
            this.cmbRepInvFis.Text = "Rep. Inventario &F\x00edsico";
            this.cmbGenDifInv.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 0x30);
            this.cmbGenDifInv.Location = point;
            this.cmbGenDifInv.Name = "cmbGenDifInv";
            size = new Size(120, 0x30);
            this.cmbGenDifInv.Size = size;
            this.cmbGenDifInv.TabIndex = 1;
            this.cmbGenDifInv.Text = "&Generar Dif. Inventario";
            this.cmbConsInv.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 0x70);
            this.cmbConsInv.Location = point;
            this.cmbConsInv.Name = "cmbConsInv";
            size = new Size(120, 0x30);
            this.cmbConsInv.Size = size;
            this.cmbConsInv.TabIndex = 3;
            this.cmbConsInv.Text = "&Consulta Inventario";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.GroupBox1);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmInventario";
            this.Text = "Toma de Inventarios";
            this.WindowState = FormWindowState.Maximized;
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        internal virtual Button cmbConsInv
        {
            get
            {
                return this._cmbConsInv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbConsInv != null)
                {
                    this._cmbConsInv.Click -= new EventHandler(this.cmbConsInv_Click);
                }
                this._cmbConsInv = value;
                if (this._cmbConsInv != null)
                {
                    this._cmbConsInv.Click += new EventHandler(this.cmbConsInv_Click);
                }
            }
        }

        internal virtual Button cmbGenDifInv
        {
            get
            {
                return this._cmbGenDifInv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbGenDifInv != null)
                {
                    this._cmbGenDifInv.Click -= new EventHandler(this.cmbGenDifInv_Click);
                }
                this._cmbGenDifInv = value;
                if (this._cmbGenDifInv != null)
                {
                    this._cmbGenDifInv.Click += new EventHandler(this.cmbGenDifInv_Click);
                }
            }
        }

        internal virtual Button cmbRepDifInv
        {
            get
            {
                return this._cmbRepDifInv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbRepDifInv != null)
                {
                    this._cmbRepDifInv.Click -= new EventHandler(this.cmbRepDifInv_Click);
                }
                this._cmbRepDifInv = value;
                if (this._cmbRepDifInv != null)
                {
                    this._cmbRepDifInv.Click += new EventHandler(this.cmbRepDifInv_Click);
                }
            }
        }

        internal virtual Button cmbRepInvFis
        {
            get
            {
                return this._cmbRepInvFis;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbRepInvFis != null)
                {
                    this._cmbRepInvFis.Click -= new EventHandler(this.cmbRepInvFis_Click);
                }
                this._cmbRepInvFis = value;
                if (this._cmbRepInvFis != null)
                {
                    this._cmbRepInvFis.Click += new EventHandler(this.cmbRepInvFis_Click);
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

