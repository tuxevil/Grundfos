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

    public class frmBusqClixNom : Form
    {
        [AccessedThroughProperty("btnAceptar")]
        private Button _btnAceptar;
        [AccessedThroughProperty("btnCancel")]
        private Button _btnCancel;
        [AccessedThroughProperty("dgClientes")]
        private DataGrid _dgClientes;
        [AccessedThroughProperty("editDescCli")]
        private TextBox _editDescCli;
        [AccessedThroughProperty("lblDescripcion")]
        private Label _lblDescripcion;
        public SqlDataAdapter AdapCli;
        private IContainer components;
        public DataSet DS;

        public frmBusqClixNom()
        {
            base.LocationChanged += new EventHandler(this.frmBusqClixNom_LocationChanged);
            base.Closed += new EventHandler(this.frmBusqClixNom_Closed);
            base.Load += new EventHandler(this.frmBusqClixNom_Load);
            this.DS = new DataSet();
            this.InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.editDescCli.Text = Strings.UCase(this.editDescCli.Text);
            try
            {
                string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
                string selectCommandText = "select SL01001,SL01002 from SL010100 where SL01002 like '%" + this.editDescCli.Text + "%' order by SL01002";
                this.AdapCli = new SqlDataAdapter(selectCommandText, selectConnectionString);
                this.DS.Tables.Clear();
                this.AdapCli.Fill(this.DS, "SL010100");
                this.dgClientes.DataSource = this.DS.Tables["SL010100"];
                this.dgClientes.Refresh();
                this.dgClientes.Focus();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                this.Close();
                ProjectData.ClearProjectError();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Variables.gCodCli = StringType.FromInteger(0);
            Variables.gNomCli = "";
            this.Close();
        }

        private void dgClientes_Click(object sender, EventArgs e)
        {
            if (this.DS.Tables["SL010100"].Rows.Count != 0)
            {
                Variables.gCodCli = Strings.Trim(StringType.FromObject(this.dgClientes[this.dgClientes.CurrentCell.RowNumber, 0]));
                Variables.gNomCli = Strings.Trim(StringType.FromObject(this.dgClientes[this.dgClientes.CurrentCell.RowNumber, 1]));
                this.Close();
            }
        }

        private void dgClientes_Navigate(object sender, NavigateEventArgs ne)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void editDescCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.btnAceptar.Focus();
            }
        }

        private void frmBusqClixNom_Closed(object sender, EventArgs e)
        {
        }

        private void frmBusqClixNom_Load(object sender, EventArgs e)
        {
            DataGridTableStyle table = new DataGridTableStyle();
            table.MappingName = "SL010100";
            DataGridTextBoxColumn column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column2 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column4 = column2;
            column4.HeaderText = "C\x00f3digo";
            column4.MappingName = "SL01001";
            column4.Width = 70;
            column4 = null;
            table.GridColumnStyles.Add(column2);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column3 = column;
            column3.HeaderText = "Nombre";
            column3.MappingName = "SL01002";
            column3.Width = 300;
            column3 = null;
            table.GridColumnStyles.Add(column);
            this.dgClientes.TableStyles.Add(table);
            this.dgClientes.Refresh();
        }

        private void frmBusqClixNom_LocationChanged(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.dgClientes = new DataGrid();
            this.lblDescripcion = new Label();
            this.editDescCli = new TextBox();
            this.btnAceptar = new Button();
            this.btnCancel = new Button();
            this.dgClientes.BeginInit();
            this.SuspendLayout();
            this.dgClientes.CaptionFont = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dgClientes.CaptionText = "Clientes";
            this.dgClientes.DataMember = "";
            this.dgClientes.HeaderForeColor = SystemColors.ControlText;
            Point point = new Point(8, 0x68);
            this.dgClientes.Location = point;
            this.dgClientes.Name = "dgClientes";
            this.dgClientes.ReadOnly = true;
            Size size = new Size(0x1b0, 0x100);
            this.dgClientes.Size = size;
            this.dgClientes.TabIndex = 4;
            this.lblDescripcion.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x20);
            this.lblDescripcion.Location = point;
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Nombre:";
            this.editDescCli.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x90, 0x20);
            this.editDescCli.Location = point;
            this.editDescCli.MaxLength = 0x23;
            this.editDescCli.Name = "editDescCli";
            size = new Size(0x100, 0x16);
            this.editDescCli.Size = size;
            this.editDescCli.TabIndex = 1;
            this.editDescCli.Text = "";
            this.btnAceptar.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x1a8, 0x30);
            this.btnAceptar.Location = point;
            this.btnAceptar.Name = "btnAceptar";
            size = new Size(80, 0x20);
            this.btnAceptar.Size = size;
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "&Aceptar";
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x1a8, 8);
            this.btnCancel.Location = point;
            this.btnCancel.Name = "btnCancel";
            size = new Size(80, 0x20);
            this.btnCancel.Size = size;
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancelar";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.btnCancel;
            size = new Size(0x220, 0x18d);
            this.ClientSize = size;
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.editDescCli);
            this.Controls.Add(this.dgClientes);
            this.Name = "frmBusqClixNom";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "B\x00fasqueda de Clientes por Nombre";
            this.dgClientes.EndInit();
            this.ResumeLayout(false);
        }

        internal virtual Button btnAceptar
        {
            get
            {
                return this._btnAceptar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnAceptar != null)
                {
                    this._btnAceptar.Click -= new EventHandler(this.btnAceptar_Click);
                }
                this._btnAceptar = value;
                if (this._btnAceptar != null)
                {
                    this._btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
                }
            }
        }

        internal virtual Button btnCancel
        {
            get
            {
                return this._btnCancel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnCancel != null)
                {
                    this._btnCancel.Click -= new EventHandler(this.btnCancel_Click);
                }
                this._btnCancel = value;
                if (this._btnCancel != null)
                {
                    this._btnCancel.Click += new EventHandler(this.btnCancel_Click);
                }
            }
        }

        internal virtual DataGrid dgClientes
        {
            get
            {
                return this._dgClientes;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dgClientes != null)
                {
                    this._dgClientes.Click -= new EventHandler(this.dgClientes_Click);
                    this._dgClientes.Navigate -= new NavigateEventHandler(this.dgClientes_Navigate);
                }
                this._dgClientes = value;
                if (this._dgClientes != null)
                {
                    this._dgClientes.Click += new EventHandler(this.dgClientes_Click);
                    this._dgClientes.Navigate += new NavigateEventHandler(this.dgClientes_Navigate);
                }
            }
        }

        internal virtual TextBox editDescCli
        {
            get
            {
                return this._editDescCli;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editDescCli != null)
                {
                    this._editDescCli.KeyPress -= new KeyPressEventHandler(this.editDescCli_KeyPress);
                }
                this._editDescCli = value;
                if (this._editDescCli != null)
                {
                    this._editDescCli.KeyPress += new KeyPressEventHandler(this.editDescCli_KeyPress);
                }
            }
        }

        internal virtual Label lblDescripcion
        {
            get
            {
                return this._lblDescripcion;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._lblDescripcion != null)
                {
                }
                this._lblDescripcion = value;
                if (this._lblDescripcion != null)
                {
                }
            }
        }
    }
}

