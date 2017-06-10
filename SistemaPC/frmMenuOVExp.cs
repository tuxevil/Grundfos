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

    public class frmMenuOVExp : Form
    {
        [AccessedThroughProperty("cmbConsultaOV")]
        private Button _cmbConsultaOV;
        [AccessedThroughProperty("cmbFcProfExp")]
        private Button _cmbFcProfExp;
        [AccessedThroughProperty("cmbRepOVExp")]
        private Button _cmbRepOVExp;
        [AccessedThroughProperty("cmbRepRegPedExp")]
        private Button _cmbRepRegPedExp;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        private IContainer components;

        public frmMenuOVExp()
        {
            base.Load += new EventHandler(this.frmMenuOVExp_Load);
            base.Closed += new EventHandler(this.frmMenuOVExp_Closed);
            this.InitializeComponent();
        }

        private void cmbConsultaOV_Click(object sender, EventArgs e)
        {
            Variables.gMenuOV = "E";
            frmConsultaOV aov = new frmConsultaOV();
            this.Hide();
            aov.Show();
        }

        private void cmbFcProfExp_Click(object sender, EventArgs e)
        {
            frmFcProfExp exp = new frmFcProfExp();
            this.Hide();
            exp.Show();
        }

        private void cmbRepOVExp_Click(object sender, EventArgs e)
        {
            frmRepOVExp exp = new frmRepOVExp();
            this.Hide();
            exp.Show();
        }

        private void cmbRepRegPedExp_Click(object sender, EventArgs e)
        {
            frmRepRegPedExp exp = new frmRepRegPedExp();
            this.Hide();
            exp.Show();
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

        private void frmMenuOVExp_Closed(object sender, EventArgs e)
        {
            new frmMenuPpal().Show();
        }

        private void frmMenuOVExp_Load(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(Application.StartupPath + @"\configu.txt");
            Variables.gServer = reader.ReadLine();
            reader.Close();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmMenuOVExp));
            this.GroupBox1 = new GroupBox();
            this.cmbFcProfExp = new Button();
            this.cmbRepRegPedExp = new Button();
            this.cmbRepOVExp = new Button();
            this.cmbConsultaOV = new Button();
            this.cmbSalir = new Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            this.GroupBox1.Anchor = AnchorStyles.None;
            this.GroupBox1.Controls.Add(this.cmbFcProfExp);
            this.GroupBox1.Controls.Add(this.cmbRepRegPedExp);
            this.GroupBox1.Controls.Add(this.cmbRepOVExp);
            this.GroupBox1.Controls.Add(this.cmbConsultaOV);
            this.GroupBox1.Controls.Add(this.cmbSalir);
            this.GroupBox1.Font = new Font("Arial", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Point point = new Point(0xe0, 0x98);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            Size size = new Size(0x138, 0x108);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Ordenes de Venta Exportaci\x00f3n";
            this.cmbFcProfExp.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 120);
            this.cmbFcProfExp.Location = point;
            this.cmbFcProfExp.Name = "cmbFcProfExp";
            size = new Size(120, 0x30);
            this.cmbFcProfExp.Size = size;
            this.cmbFcProfExp.TabIndex = 3;
            this.cmbFcProfExp.Text = "&Fact.Proforma Exportaci\x00f3n";
            this.cmbRepRegPedExp.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x18, 120);
            this.cmbRepRegPedExp.Location = point;
            this.cmbRepRegPedExp.Name = "cmbRepRegPedExp";
            size = new Size(120, 0x30);
            this.cmbRepRegPedExp.Size = size;
            this.cmbRepRegPedExp.TabIndex = 2;
            this.cmbRepRegPedExp.Text = "&Registro Ped. Exportaci\x00f3n";
            this.cmbRepOVExp.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 0x30);
            this.cmbRepOVExp.Location = point;
            this.cmbRepOVExp.Name = "cmbRepOVExp";
            size = new Size(120, 0x30);
            this.cmbRepOVExp.Size = size;
            this.cmbRepOVExp.TabIndex = 1;
            this.cmbRepOVExp.Text = "O.Venta &Exportaci\x00f3n";
            this.cmbConsultaOV.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x18, 0x30);
            this.cmbConsultaOV.Location = point;
            this.cmbConsultaOV.Name = "cmbConsultaOV";
            size = new Size(120, 0x30);
            this.cmbConsultaOV.Size = size;
            this.cmbConsultaOV.TabIndex = 0;
            this.cmbConsultaOV.Text = "&Consulta O.Venta";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            this.cmbSalir.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x58, 0xc0);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(120, 0x30);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 4;
            this.cmbSalir.Text = "&Salir";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.GroupBox1);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmMenuOVExp";
            this.Text = "Ordenes de Venta Exportaci\x00f3n";
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

        internal virtual Button cmbFcProfExp
        {
            get
            {
                return this._cmbFcProfExp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbFcProfExp != null)
                {
                    this._cmbFcProfExp.Click -= new EventHandler(this.cmbFcProfExp_Click);
                }
                this._cmbFcProfExp = value;
                if (this._cmbFcProfExp != null)
                {
                    this._cmbFcProfExp.Click += new EventHandler(this.cmbFcProfExp_Click);
                }
            }
        }

        internal virtual Button cmbRepOVExp
        {
            get
            {
                return this._cmbRepOVExp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbRepOVExp != null)
                {
                    this._cmbRepOVExp.Click -= new EventHandler(this.cmbRepOVExp_Click);
                }
                this._cmbRepOVExp = value;
                if (this._cmbRepOVExp != null)
                {
                    this._cmbRepOVExp.Click += new EventHandler(this.cmbRepOVExp_Click);
                }
            }
        }

        internal virtual Button cmbRepRegPedExp
        {
            get
            {
                return this._cmbRepRegPedExp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbRepRegPedExp != null)
                {
                    this._cmbRepRegPedExp.Click -= new EventHandler(this.cmbRepRegPedExp_Click);
                }
                this._cmbRepRegPedExp = value;
                if (this._cmbRepRegPedExp != null)
                {
                    this._cmbRepRegPedExp.Click += new EventHandler(this.cmbRepRegPedExp_Click);
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

