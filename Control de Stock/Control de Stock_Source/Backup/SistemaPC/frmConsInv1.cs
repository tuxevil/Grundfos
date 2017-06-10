namespace SistemaPC
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmConsInv1 : Form
    {
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("editCantMeses")]
        private TextBox _editCantMeses;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        public SqlDataAdapter Adap;
        public SqlDataAdapter Adap1;
        private IContainer components;
        public DataSet DS1;
        public DataSet DS2;

        public frmConsInv1()
        {
            base.Closed += new EventHandler(this.frmConsInv1_Closed);
            base.Load += new EventHandler(this.frmConsInv1_Load);
            this.DS1 = new DataSet();
            this.DS2 = new DataSet();
            this.InitializeComponent();
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            if (StringType.StrCmp(this.editCantMeses.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe indicar cantidad de meses", 0x10, "Operador");
                this.editCantMeses.Focus();
            }
            else
            {
                this.editCantMeses.Enabled = false;
                this.cmbAceptar.Enabled = false;
                this.cmbSalir.Enabled = false;
                Variables.gCantMeses = IntegerType.FromString(this.editCantMeses.Text);
                frmConsInv1_1 inv_ = new frmConsInv1_1();
                this.Hide();
                inv_.Show();
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

        private void editCantMeses_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        ~frmConsInv1()
        {
        }

        private void frmConsInv1_Closed(object sender, EventArgs e)
        {
            new frmConsInv().Show();
        }

        private void frmConsInv1_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.Label2 = new Label();
            this.editCantMeses = new TextBox();
            this.SuspendLayout();
            Point point = new Point(0x188, 0x10);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 2;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0x120, 0x10);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 3;
            this.cmbSalir.Text = "&Salir";
            this.Label2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x18);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x70, 0x17);
            this.Label2.Size = size;
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Cantidad de Meses:";
            this.editCantMeses.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x88, 0x18);
            this.editCantMeses.Location = point;
            this.editCantMeses.MaxLength = 3;
            this.editCantMeses.Name = "editCantMeses";
            size = new Size(0x38, 20);
            this.editCantMeses.Size = size;
            this.editCantMeses.TabIndex = 1;
            this.editCantMeses.Text = "";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.editCantMeses);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Name = "frmConsInv1";
            this.Text = "Consulta Inventario - Posiciones sin inventariar";
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

        internal virtual TextBox editCantMeses
        {
            get
            {
                return this._editCantMeses;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editCantMeses != null)
                {
                    this._editCantMeses.KeyPress -= new KeyPressEventHandler(this.editCantMeses_KeyPress);
                }
                this._editCantMeses = value;
                if (this._editCantMeses != null)
                {
                    this._editCantMeses.KeyPress += new KeyPressEventHandler(this.editCantMeses_KeyPress);
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
    }
}

