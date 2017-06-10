namespace SistemaPC
{
    using DateCalc;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmPrepPed : Form
    {
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dtpFechaDesde")]
        private DateTimePicker _dtpFechaDesde;
        [AccessedThroughProperty("dtpFechaHasta")]
        private DateTimePicker _dtpFechaHasta;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        private IContainer components;

        public frmPrepPed()
        {
            base.Closed += new EventHandler(this.frmPrepPed_Closed);
            base.Load += new EventHandler(this.frmPrepPed_Load);
            this.InitializeComponent();
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            if (this.dtpFechaDesde.Checked & !this.dtpFechaHasta.Checked)
            {
                Interaction.MsgBox("Debe seleccionar desde y hasta fecha entrega", MsgBoxStyle.Critical, "Operador");
                this.dtpFechaHasta.Focus();
            }
            else if (!this.dtpFechaDesde.Checked & this.dtpFechaHasta.Checked)
            {
                Interaction.MsgBox("Debe seleccionar desde y hasta fecha entrega", MsgBoxStyle.Critical, "Operador");
                this.dtpFechaDesde.Focus();
            }
            else
            {
                this.dtpFechaDesde.Enabled = false;
                this.dtpFechaHasta.Enabled = false;
                this.cmbAceptar.Enabled = false;
                this.cmbSalir.Enabled = false;
                if (this.dtpFechaDesde.Checked & this.dtpFechaHasta.Checked)
                {
                    Variables.gDesde = StringType.FromDate(this.dtpFechaDesde.Value);
                    Variables.gHasta = StringType.FromDate(this.dtpFechaHasta.Value);
                }
                else
                {
                    Variables.gDesde = "";
                    DateTime now = DateAndTime.Now;
                    CalcDates dates = new CalcDatesClass();
                    short daysToDue = 0;
                    string dayCountType = "H";
                    string company = "01";
                    dates.WeekDate(ref daysToDue, ref now, ref dayCountType, ref company);
                    Variables.gHasta = StringType.FromDate(dates.MidDate);
                }
                frmPrepPed1 ped = new frmPrepPed1();
                this.Hide();
                ped.Show();
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

        private void dtpFechaDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.dtpFechaHasta.Focus();
            }
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtpFechaHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
        }

        ~frmPrepPed()
        {
        }

        private void frmPrepPed_Closed(object sender, EventArgs e)
        {
            new frmMenuPpal().Show();
        }

        private void frmPrepPed_Load(object sender, EventArgs e)
        {
            this.dtpFechaDesde.Value = DateAndTime.Now;
            this.dtpFechaHasta.Value = DateAndTime.Now;
            this.dtpFechaDesde.Checked = false;
            this.dtpFechaHasta.Checked = false;
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.Label2 = new Label();
            this.Label1 = new Label();
            this.Label3 = new Label();
            this.dtpFechaDesde = new DateTimePicker();
            this.dtpFechaHasta = new DateTimePicker();
            this.SuspendLayout();
            Point point = new Point(0x148, 0xd8);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 5;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0xe0, 0xd8);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 6;
            this.cmbSalir.Text = "&Salir";
            this.Label2.Font = new Font("Arial", 12f, FontStyle.Underline | FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0xb0, 0x60);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x128, 20);
            this.Label2.Size = size;
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Preparaci\x00f3n de Pedidos";
            this.Label2.TextAlign = ContentAlignment.MiddleCenter;
            point = new Point(0xb8, 0x94);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x90, 0x10);
            this.Label1.Size = size;
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Desde Fecha Entrega:";
            point = new Point(0xb8, 180);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x90, 0x10);
            this.Label3.Size = size;
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Hasta Fecha Entrega:";
            this.dtpFechaDesde.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaDesde.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaDesde.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaDesde.Format = DateTimePickerFormat.Short;
            point = new Point(0x148, 0x90);
            this.dtpFechaDesde.Location = point;
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.ShowCheckBox = true;
            size = new Size(0x70, 0x16);
            this.dtpFechaDesde.Size = size;
            this.dtpFechaDesde.TabIndex = 2;
            DateTime time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpFechaDesde.Value = time;
            this.dtpFechaHasta.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaHasta.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaHasta.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaHasta.Format = DateTimePickerFormat.Short;
            point = new Point(0x148, 0xb0);
            this.dtpFechaHasta.Location = point;
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.ShowCheckBox = true;
            size = new Size(0x70, 0x16);
            this.dtpFechaHasta.Size = size;
            this.dtpFechaHasta.TabIndex = 4;
            time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpFechaHasta.Value = time;
            size = new Size(6, 15);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Name = "frmPrepPed";
            this.Text = "Preparaci\x00f3n de Pedidos";
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

        internal virtual DateTimePicker dtpFechaDesde
        {
            get
            {
                return this._dtpFechaDesde;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpFechaDesde != null)
                {
                    this._dtpFechaDesde.KeyPress -= new KeyPressEventHandler(this.dtpFechaDesde_KeyPress);
                    this._dtpFechaDesde.ValueChanged -= new EventHandler(this.dtpFechaDesde_ValueChanged);
                }
                this._dtpFechaDesde = value;
                if (this._dtpFechaDesde != null)
                {
                    this._dtpFechaDesde.KeyPress += new KeyPressEventHandler(this.dtpFechaDesde_KeyPress);
                    this._dtpFechaDesde.ValueChanged += new EventHandler(this.dtpFechaDesde_ValueChanged);
                }
            }
        }

        internal virtual DateTimePicker dtpFechaHasta
        {
            get
            {
                return this._dtpFechaHasta;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpFechaHasta != null)
                {
                    this._dtpFechaHasta.KeyPress -= new KeyPressEventHandler(this.dtpFechaHasta_KeyPress);
                    this._dtpFechaHasta.ValueChanged -= new EventHandler(this.dtpFechaHasta_ValueChanged);
                }
                this._dtpFechaHasta = value;
                if (this._dtpFechaHasta != null)
                {
                    this._dtpFechaHasta.KeyPress += new KeyPressEventHandler(this.dtpFechaHasta_KeyPress);
                    this._dtpFechaHasta.ValueChanged += new EventHandler(this.dtpFechaHasta_ValueChanged);
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

