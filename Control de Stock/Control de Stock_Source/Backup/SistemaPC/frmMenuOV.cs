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

    public class frmMenuOV : Form
    {
        [AccessedThroughProperty("cmbConsultaOV")]
        private Button _cmbConsultaOV;
        [AccessedThroughProperty("cmbRepOVPend")]
        private Button _cmbRepOVPend;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        private IContainer components;

        public frmMenuOV()
        {
            base.Load += new EventHandler(this.frmMenuOV_Load);
            base.Closed += new EventHandler(this.frmMenuOV_Closed);
            this.InitializeComponent();
        }

        private void cmbConsultaOV_Click(object sender, EventArgs e)
        {
            Variables.gMenuOV = "L";
            frmConsultaOV aov = new frmConsultaOV();
            this.Hide();
            aov.Show();
        }

        private void cmbRepOVPend_Click(object sender, EventArgs e)
        {
            frmRepOVPend pend = new frmRepOVPend();
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

        private void frmMenuOV_Closed(object sender, EventArgs e)
        {
            new frmMenuPpal().Show();
        }

        private void frmMenuOV_Load(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(Application.StartupPath + @"\configu.txt");
            Variables.gServer = reader.ReadLine();
            reader.Close();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmMenuOV));
            this.GroupBox1 = new GroupBox();
            this.cmbConsultaOV = new Button();
            this.cmbRepOVPend = new Button();
            this.cmbSalir = new Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            this.GroupBox1.Anchor = AnchorStyles.None;
            this.GroupBox1.Controls.Add(this.cmbConsultaOV);
            this.GroupBox1.Controls.Add(this.cmbRepOVPend);
            this.GroupBox1.Controls.Add(this.cmbSalir);
            this.GroupBox1.Font = new Font("Arial", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Point point = new Point(0xe0, 0xc0);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            Size size = new Size(0x130, 0xc0);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Ordenes de Venta Locales";
            this.cmbConsultaOV.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 40);
            this.cmbConsultaOV.Location = point;
            this.cmbConsultaOV.Name = "cmbConsultaOV";
            size = new Size(120, 0x30);
            this.cmbConsultaOV.Size = size;
            this.cmbConsultaOV.TabIndex = 1;
            this.cmbConsultaOV.Text = "&Consulta O.Venta";
            this.cmbRepOVPend.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x18, 40);
            this.cmbRepOVPend.Location = point;
            this.cmbRepOVPend.Name = "cmbRepOVPend";
            size = new Size(120, 0x30);
            this.cmbRepOVPend.Size = size;
            this.cmbRepOVPend.TabIndex = 0;
            this.cmbRepOVPend.Text = "O.&Venta Pendientes";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            this.cmbSalir.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x60, 0x70);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(120, 0x30);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 2;
            this.cmbSalir.Text = "&Salir";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.GroupBox1);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmMenuOV";
            this.Text = "Ordenes de Venta Locales";
            this.WindowState = FormWindowState.Maximized;
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        internal virtual Button cmbConsultaOV
        {
            get
            {
                return this._cmbConsultaOV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbConsultaOV != null)
                {
                    this._cmbConsultaOV.Click -= new EventHandler(this.cmbConsultaOV_Click);
                }
                this._cmbConsultaOV = value;
                if (this._cmbConsultaOV != null)
                {
                    this._cmbConsultaOV.Click += new EventHandler(this.cmbConsultaOV_Click);
                }
            }
        }

        internal virtual Button cmbRepOVPend
        {
            get
            {
                return this._cmbRepOVPend;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbRepOVPend != null)
                {
                    this._cmbRepOVPend.Click -= new EventHandler(this.cmbRepOVPend_Click);
                }
                this._cmbRepOVPend = value;
                if (this._cmbRepOVPend != null)
                {
                    this._cmbRepOVPend.Click += new EventHandler(this.cmbRepOVPend_Click);
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
                    this._GroupBox1.Enter -= new EventHandler(this.GroupBox1_Enter);
                }
                this._GroupBox1 = value;
                if (this._GroupBox1 != null)
                {
                    this._GroupBox1.Enter += new EventHandler(this.GroupBox1_Enter);
                }
            }
        }
    }
}

