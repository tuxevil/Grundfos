namespace SistemaPC
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmDifOCProv : Form
    {
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dtpDesdeFechaExp")]
        private DateTimePicker _dtpDesdeFechaExp;
        [AccessedThroughProperty("dtpHastaFechaExp")]
        private DateTimePicker _dtpHastaFechaExp;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        private IContainer components;

        public frmDifOCProv()
        {
            base.Closed += new EventHandler(this.frmDifOCProv_Closed);
            base.Load += new EventHandler(this.frmDifOCProv_Load);
            this.InitializeComponent();
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            this.dtpDesdeFechaExp.Enabled = false;
            this.dtpHastaFechaExp.Enabled = false;
            this.cmbAceptar.Enabled = false;
            this.cmbSalir.Enabled = false;
            Variables.gDesde = StringType.FromDate(this.dtpDesdeFechaExp.Value);
            Variables.gHasta = StringType.FromDate(this.dtpHastaFechaExp.Value);
            frmDifOCProv1 prov = new frmDifOCProv1();
            this.Hide();
            prov.Show();
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

        private void dtpDesdeFechaExp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.dtpHastaFechaExp.Focus();
            }
        }

        private void dtpHastaFechaExp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        ~frmDifOCProv()
        {
        }

        private void frmDifOCProv_Closed(object sender, EventArgs e)
        {
            new frmMenuOCompra().Show();
        }

        private void frmDifOCProv_Load(object sender, EventArgs e)
        {
            this.dtpDesdeFechaExp.Value = DateAndTime.Now;
            this.dtpHastaFechaExp.Value = DateAndTime.Now;
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.Label2 = new Label();
            this.Label1 = new Label();
            this.Label3 = new Label();
            this.dtpDesdeFechaExp = new DateTimePicker();
            this.dtpHastaFechaExp = new DateTimePicker();
            this.SuspendLayout();
            Point point = new Point(0x148, 0xe8);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 5;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0xe0, 0xe8);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 6;
            this.cmbSalir.Text = "&Salir";
            this.Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Underline | FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0xb0, 0x60);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x128, 20);
            this.Label2.Size = size;
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Reporte Diferencias O.Compra con Proveedor";
            this.Label2.TextAlign = ContentAlignment.MiddleCenter;
            point = new Point(0xd0, 0x94);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x88, 0x10);
            this.Label1.Size = size;
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Desde Fecha Expedici\x00f3n:";
            point = new Point(0xd0, 180);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x88, 0x10);
            this.Label3.Size = size;
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Hasta Fecha Expedici\x00f3n:";
            this.dtpDesdeFechaExp.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpDesdeFechaExp.Checked = false;
            this.dtpDesdeFechaExp.CustomFormat = "dd/MM/yyyy";
            this.dtpDesdeFechaExp.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpDesdeFechaExp.Format = DateTimePickerFormat.Short;
            point = new Point(0x160, 0x90);
            this.dtpDesdeFechaExp.Location = point;
            this.dtpDesdeFechaExp.Name = "dtpDesdeFechaExp";
            size = new Size(0x70, 0x16);
            this.dtpDesdeFechaExp.Size = size;
            this.dtpDesdeFechaExp.TabIndex = 2;
            DateTime time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpDesdeFechaExp.Value = time;
            this.dtpHastaFechaExp.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpHastaFechaExp.Checked = false;
            this.dtpHastaFechaExp.CustomFormat = "dd/MM/yyyy";
            this.dtpHastaFechaExp.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpHastaFechaExp.Format = DateTimePickerFormat.Short;
            point = new Point(0x160, 0xb0);
            this.dtpHastaFechaExp.Location = point;
            this.dtpHastaFechaExp.Name = "dtpHastaFechaExp";
            size = new Size(0x70, 0x16);
            this.dtpHastaFechaExp.Size = size;
            this.dtpHastaFechaExp.TabIndex = 4;
            time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpHastaFechaExp.Value = time;
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.dtpHastaFechaExp);
            this.Controls.Add(this.dtpDesdeFechaExp);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Name = "frmDifOCProv";
            this.Text = "Reporte Diferencias O.Compra con Proveedor";
            this.WindowState = FormWindowState.Maximized;
            this.ResumeLayout(false);
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

        internal virtual DateTimePicker dtpDesdeFechaExp
        {
            get
            {
                return this._dtpDesdeFechaExp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpDesdeFechaExp != null)
                {
                    this._dtpDesdeFechaExp.KeyPress -= new KeyPressEventHandler(this.dtpDesdeFechaExp_KeyPress);
                }
                this._dtpDesdeFechaExp = value;
                if (this._dtpDesdeFechaExp != null)
                {
                    this._dtpDesdeFechaExp.KeyPress += new KeyPressEventHandler(this.dtpDesdeFechaExp_KeyPress);
                }
            }
        }

        internal virtual DateTimePicker dtpHastaFechaExp
        {
            get
            {
                return this._dtpHastaFechaExp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpHastaFechaExp != null)
                {
                    this._dtpHastaFechaExp.KeyPress -= new KeyPressEventHandler(this.dtpHastaFechaExp_KeyPress);
                }
                this._dtpHastaFechaExp = value;
                if (this._dtpHastaFechaExp != null)
                {
                    this._dtpHastaFechaExp.KeyPress += new KeyPressEventHandler(this.dtpHastaFechaExp_KeyPress);
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
    }
}

