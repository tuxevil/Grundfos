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

    public class frmMenuExp : Form
    {
        [AccessedThroughProperty("cmbRepProdPendExp")]
        private Button _cmbRepProdPendExp;
        [AccessedThroughProperty("cmbRMCont")]
        private Button _cmbRMCont;
        [AccessedThroughProperty("cmbRMDesp")]
        private Button _cmbRMDesp;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        private IContainer components;

        public frmMenuExp()
        {
            base.Load += new EventHandler(this.frmMenuExp_Load);
            base.Closed += new EventHandler(this.frmMenuExp_Closed);
            this.InitializeComponent();
        }

        private void cmbRepProdPendExp_Click(object sender, EventArgs e)
        {
            frmRepProdPendExp exp = new frmRepProdPendExp();
            this.Hide();
            exp.Show();
        }

        private void cmbRMCont_Click(object sender, EventArgs e)
        {
            frmRepRMControlados controlados = new frmRepRMControlados();
            this.Hide();
            controlados.Show();
        }

        private void cmbRMDesp_Click(object sender, EventArgs e)
        {
            frmRepRMDesp desp = new frmRepRMDesp();
            this.Hide();
            desp.Show();
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

        private void frmMenuExp_Closed(object sender, EventArgs e)
        {
            new frmMenuPpal().Show();
        }

        private void frmMenuExp_Load(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(Application.StartupPath + @"\configu.txt");
            Variables.gServer = reader.ReadLine();
            reader.Close();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmMenuExp));
            this.GroupBox1 = new GroupBox();
            this.cmbRMCont = new Button();
            this.cmbRMDesp = new Button();
            this.cmbRepProdPendExp = new Button();
            this.cmbSalir = new Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            this.GroupBox1.Anchor = AnchorStyles.None;
            this.GroupBox1.Controls.Add(this.cmbRMCont);
            this.GroupBox1.Controls.Add(this.cmbRMDesp);
            this.GroupBox1.Controls.Add(this.cmbRepProdPendExp);
            this.GroupBox1.Controls.Add(this.cmbSalir);
            this.GroupBox1.Font = new Font("Arial", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Point point = new Point(0xe0, 0xd0);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            Size size = new Size(0x130, 0xb8);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Expedici\x00f3n";
            this.cmbRMCont.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 40);
            this.cmbRMCont.Location = point;
            this.cmbRMCont.Name = "cmbRMCont";
            size = new Size(120, 0x30);
            this.cmbRMCont.Size = size;
            this.cmbRMCont.TabIndex = 1;
            this.cmbRMCont.Text = "R&emitos Controlados";
            this.cmbRMDesp.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x18, 0x70);
            this.cmbRMDesp.Location = point;
            this.cmbRMDesp.Name = "cmbRMDesp";
            size = new Size(120, 0x30);
            this.cmbRMDesp.Size = size;
            this.cmbRMDesp.TabIndex = 2;
            this.cmbRMDesp.Text = "&Remitos Despachados";
            this.cmbRepProdPendExp.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x18, 40);
            this.cmbRepProdPendExp.Location = point;
            this.cmbRepProdPendExp.Name = "cmbRepProdPendExp";
            size = new Size(120, 0x30);
            this.cmbRepProdPendExp.Size = size;
            this.cmbRepProdPendExp.TabIndex = 0;
            this.cmbRepProdPendExp.Text = "&Productos Pend.Control";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            this.cmbSalir.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 0x70);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(120, 0x30);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 3;
            this.cmbSalir.Text = "&Salir";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.GroupBox1);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmMenuExp";
            this.Text = "Expedici\x00f3n";
            this.WindowState = FormWindowState.Maximized;
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        internal virtual Button cmbRepProdPendExp
        {
            get
            {
                return this._cmbRepProdPendExp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbRepProdPendExp != null)
                {
                    this._cmbRepProdPendExp.Click -= new EventHandler(this.cmbRepProdPendExp_Click);
                }
                this._cmbRepProdPendExp = value;
                if (this._cmbRepProdPendExp != null)
                {
                    this._cmbRepProdPendExp.Click += new EventHandler(this.cmbRepProdPendExp_Click);
                }
            }
        }

        internal virtual Button cmbRMCont
        {
            get
            {
                return this._cmbRMCont;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbRMCont != null)
                {
                    this._cmbRMCont.Click -= new EventHandler(this.cmbRMCont_Click);
                }
                this._cmbRMCont = value;
                if (this._cmbRMCont != null)
                {
                    this._cmbRMCont.Click += new EventHandler(this.cmbRMCont_Click);
                }
            }
        }

        internal virtual Button cmbRMDesp
        {
            get
            {
                return this._cmbRMDesp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbRMDesp != null)
                {
                    this._cmbRMDesp.Click -= new EventHandler(this.cmbRMDesp_Click);
                }
                this._cmbRMDesp = value;
                if (this._cmbRMDesp != null)
                {
                    this._cmbRMDesp.Click += new EventHandler(this.cmbRMDesp_Click);
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

