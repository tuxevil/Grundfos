namespace SistemaPC
{
    using Microsoft.VisualBasic;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmConsInv : Form
    {
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("rbConsFecUltInv")]
        private RadioButton _rbConsFecUltInv;
        [AccessedThroughProperty("rbConsPosSinInv")]
        private RadioButton _rbConsPosSinInv;
        public SqlDataAdapter Adap;
        public SqlDataAdapter Adap1;
        private IContainer components;
        public DataSet DS1;
        public DataSet DS2;

        public frmConsInv()
        {
            base.Closed += new EventHandler(this.frmConsInv_Closed);
            base.Load += new EventHandler(this.frmConsInv_Load);
            this.DS1 = new DataSet();
            this.DS2 = new DataSet();
            this.InitializeComponent();
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            if (!this.rbConsPosSinInv.Checked & !this.rbConsFecUltInv.Checked)
            {
                Interaction.MsgBox("Debe indicar tipo de consulta", MsgBoxStyle.Critical, "Operador");
                this.rbConsPosSinInv.Focus();
            }
            else
            {
                this.rbConsPosSinInv.Enabled = false;
                this.rbConsFecUltInv.Enabled = false;
                this.cmbAceptar.Enabled = false;
                this.cmbSalir.Enabled = false;
                if (this.rbConsPosSinInv.Checked)
                {
                    frmConsInv1 inv = new frmConsInv1();
                    this.Hide();
                    inv.Show();
                }
                else if (this.rbConsFecUltInv.Checked)
                {
                    frmConsInv2 inv2 = new frmConsInv2();
                    this.Hide();
                    inv2.Show();
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

        ~frmConsInv()
        {
        }

        private void frmConsInv_Closed(object sender, EventArgs e)
        {
            new frmInventario().Show();
        }

        private void frmConsInv_Load(object sender, EventArgs e)
        {
            this.rbConsPosSinInv.Checked = true;
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.rbConsPosSinInv = new RadioButton();
            this.rbConsFecUltInv = new RadioButton();
            this.SuspendLayout();
            Point point = new Point(0x148, 0x18);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 2;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0xe0, 0x18);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 3;
            this.cmbSalir.Text = "&Salir";
            point = new Point(0x10, 0x10);
            this.rbConsPosSinInv.Location = point;
            this.rbConsPosSinInv.Name = "rbConsPosSinInv";
            size = new Size(0xc0, 0x20);
            this.rbConsPosSinInv.Size = size;
            this.rbConsPosSinInv.TabIndex = 0;
            this.rbConsPosSinInv.Text = "Posiciones sin inventariar";
            point = new Point(0x10, 0x38);
            this.rbConsFecUltInv.Location = point;
            this.rbConsFecUltInv.Name = "rbConsFecUltInv";
            size = new Size(0xc0, 0x20);
            this.rbConsFecUltInv.Size = size;
            this.rbConsFecUltInv.TabIndex = 1;
            this.rbConsFecUltInv.Text = "Fecha \x00faltimo inventario";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.rbConsFecUltInv);
            this.Controls.Add(this.rbConsPosSinInv);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Name = "frmConsInv";
            this.Text = "Consultas de Inventario";
            this.WindowState = FormWindowState.Maximized;
            this.ResumeLayout(false);
        }

        private void rbConsFecUltInv_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbConsFecUltInv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void rbConsPosSinInv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
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

        internal virtual RadioButton rbConsFecUltInv
        {
            get
            {
                return this._rbConsFecUltInv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbConsFecUltInv != null)
                {
                    this._rbConsFecUltInv.KeyPress -= new KeyPressEventHandler(this.rbConsFecUltInv_KeyPress);
                    this._rbConsFecUltInv.CheckedChanged -= new EventHandler(this.rbConsFecUltInv_CheckedChanged);
                }
                this._rbConsFecUltInv = value;
                if (this._rbConsFecUltInv != null)
                {
                    this._rbConsFecUltInv.KeyPress += new KeyPressEventHandler(this.rbConsFecUltInv_KeyPress);
                    this._rbConsFecUltInv.CheckedChanged += new EventHandler(this.rbConsFecUltInv_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbConsPosSinInv
        {
            get
            {
                return this._rbConsPosSinInv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbConsPosSinInv != null)
                {
                    this._rbConsPosSinInv.KeyPress -= new KeyPressEventHandler(this.rbConsPosSinInv_KeyPress);
                }
                this._rbConsPosSinInv = value;
                if (this._rbConsPosSinInv != null)
                {
                    this._rbConsPosSinInv.KeyPress += new KeyPressEventHandler(this.rbConsPosSinInv_KeyPress);
                }
            }
        }
    }
}

