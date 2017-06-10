namespace SistemaPC
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmBorrarRecep : Form
    {
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("txtPackList")]
        private TextBox _txtPackList;
        private IContainer components;

        public frmBorrarRecep()
        {
            base.Load += new EventHandler(this.frmBorrarRecep_Load);
            base.Closed += new EventHandler(this.frmBorrarRecep_Closed);
            this.InitializeComponent();
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            DataSet set = new DataSet();
            bool flag2 = false;
            bool flag = false;
            this.cmbAceptar.Enabled = false;
            this.cmbSalir.Enabled = false;
            SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            flag = true;
            SqlCommand command = new SqlCommand("delete Bultos where PackList='" + Variables.gPackList + "'", connection);
            command.Transaction = transaction;
            int num2 = command.ExecuteNonQuery();
            transaction.Commit();
            flag = false;
            connection.Close();
            flag2 = false;
            this.Close();
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

        ~frmBorrarRecep()
        {
        }

        private void frmBorrarRecep_Closed(object sender, EventArgs e)
        {
            new frmMenuOCompra().Show();
        }

        private void frmBorrarRecep_Load(object sender, EventArgs e)
        {
            this.txtPackList.Text = Variables.gPackList;
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.txtPackList = new TextBox();
            this.Label1 = new Label();
            this.SuspendLayout();
            Point point = new Point(0x158, 0x40);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 2;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(240, 0x40);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 3;
            this.cmbSalir.Text = "&Salir";
            this.txtPackList.BackColor = SystemColors.Window;
            this.txtPackList.Enabled = false;
            this.txtPackList.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x70, 0x10);
            this.txtPackList.Location = point;
            this.txtPackList.MaxLength = 10;
            this.txtPackList.Name = "txtPackList";
            size = new Size(0x98, 0x16);
            this.txtPackList.Size = size;
            this.txtPackList.TabIndex = 0x39;
            this.txtPackList.Text = "";
            this.Label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x10);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x58, 0x10);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0x38;
            this.Label1.Text = "Packing List:";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.txtPackList);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Name = "frmBorrarRecep";
            this.Text = "Borrar Recepci\x00f3n O.Compra";
            this.WindowState = FormWindowState.Maximized;
            this.ResumeLayout(false);
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void txtPackList_TextChanged(object sender, EventArgs e)
        {
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
                    this._Label1.Click -= new EventHandler(this.Label1_Click);
                }
                this._Label1 = value;
                if (this._Label1 != null)
                {
                    this._Label1.Click += new EventHandler(this.Label1_Click);
                }
            }
        }

        internal virtual TextBox txtPackList
        {
            get
            {
                return this._txtPackList;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtPackList != null)
                {
                    this._txtPackList.TextChanged -= new EventHandler(this.txtPackList_TextChanged);
                }
                this._txtPackList = value;
                if (this._txtPackList != null)
                {
                    this._txtPackList.TextChanged += new EventHandler(this.txtPackList_TextChanged);
                }
            }
        }
    }
}

