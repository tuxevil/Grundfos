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

    public class frmBusqProdxDesc : Form
    {
        [AccessedThroughProperty("btnAceptar")]
        private Button _btnAceptar;
        [AccessedThroughProperty("btnCancel")]
        private Button _btnCancel;
        [AccessedThroughProperty("dgProductos")]
        private DataGrid _dgProductos;
        [AccessedThroughProperty("editDescProd")]
        private TextBox _editDescProd;
        [AccessedThroughProperty("lblDescripcion")]
        private Label _lblDescripcion;
        public SqlDataAdapter AdapProd;
        private IContainer components;
        public DataSet DS;

        public frmBusqProdxDesc()
        {
            base.Load += new EventHandler(this.frmBusqProdxDesc_Load);
            base.LocationChanged += new EventHandler(this.frmBusqProdxDesc_LocationChanged);
            base.Closed += new EventHandler(this.frmBusqProdxDesc_Closed);
            this.DS = new DataSet();
            this.InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.editDescProd.Text = Strings.UCase(this.editDescProd.Text);
            try
            {
                string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
                string selectCommandText = "select SC01001,SC01002,SC01003 from SC010100 where upper(SC01002) like '%" + this.editDescProd.Text + "%' order by SC01002";
                this.AdapProd = new SqlDataAdapter(selectCommandText, selectConnectionString);
                this.DS.Tables.Clear();
                this.AdapProd.Fill(this.DS, "SC010100");
                this.dgProductos.DataSource = this.DS.Tables["SC010100"];
                this.dgProductos.Refresh();
                this.dgProductos.Focus();
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
            Variables.gCodProd = "";
            Variables.gDescProd1 = "";
            Variables.gDescProd2 = "";
            this.Close();
        }

        private void dgProductos_Click(object sender, EventArgs e)
        {
            if (this.DS.Tables["SC010100"].Rows.Count != 0)
            {
                Variables.gCodProd = Strings.Trim(StringType.FromObject(this.dgProductos[this.dgProductos.CurrentCell.RowNumber, 0]));
                Variables.gDescProd1 = Strings.Trim(StringType.FromObject(this.dgProductos[this.dgProductos.CurrentCell.RowNumber, 1]));
                Variables.gDescProd2 = Strings.Trim(StringType.FromObject(this.dgProductos[this.dgProductos.CurrentCell.RowNumber, 2]));
                this.Close();
            }
        }

        private void dgProductos_Navigate(object sender, NavigateEventArgs ne)
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

        private void editDescProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.btnAceptar.Focus();
            }
        }

        private void frmBusqProdxDesc_Closed(object sender, EventArgs e)
        {
        }

        private void frmBusqProdxDesc_Load(object sender, EventArgs e)
        {
            DataGridTableStyle table = new DataGridTableStyle();
            table.MappingName = "SC010100";
            DataGridTextBoxColumn column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column2 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column5 = column2;
            column5.HeaderText = "C\x00f3digo";
            column5.MappingName = "SC01001";
            column5.Width = 70;
            column5 = null;
            table.GridColumnStyles.Add(column2);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column4 = column;
            column4.HeaderText = "Descripci\x00f3n";
            column4.MappingName = "SC01002";
            column4.Width = 300;
            column4 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column3 = column;
            column3.HeaderText = "Descripci\x00f3n";
            column3.MappingName = "SC01003";
            column3.Width = 300;
            column3 = null;
            table.GridColumnStyles.Add(column);
            this.dgProductos.TableStyles.Add(table);
            this.dgProductos.Refresh();
        }

        private void frmBusqProdxDesc_LocationChanged(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.dgProductos = new DataGrid();
            this.lblDescripcion = new Label();
            this.editDescProd = new TextBox();
            this.btnAceptar = new Button();
            this.btnCancel = new Button();
            this.dgProductos.BeginInit();
            this.SuspendLayout();
            this.dgProductos.CaptionFont = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dgProductos.CaptionText = "Productos";
            this.dgProductos.DataMember = "";
            this.dgProductos.HeaderForeColor = SystemColors.ControlText;
            Point point = new Point(8, 0x68);
            this.dgProductos.Location = point;
            this.dgProductos.Name = "dgProductos";
            this.dgProductos.ReadOnly = true;
            Size size = new Size(0x1b0, 0x100);
            this.dgProductos.Size = size;
            this.dgProductos.TabIndex = 4;
            this.lblDescripcion.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x20);
            this.lblDescripcion.Location = point;
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Descripci\x00f3n";
            this.editDescProd.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x90, 0x20);
            this.editDescProd.Location = point;
            this.editDescProd.MaxLength = 0x23;
            this.editDescProd.Name = "editDescProd";
            size = new Size(0x100, 0x16);
            this.editDescProd.Size = size;
            this.editDescProd.TabIndex = 1;
            this.editDescProd.Text = "";
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
            this.Controls.Add(this.editDescProd);
            this.Controls.Add(this.dgProductos);
            this.Name = "frmBusqProdxDesc";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "B\x00fasqueda de Productos por Descripci\x00f3n";
            this.dgProductos.EndInit();
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

        internal virtual DataGrid dgProductos
        {
            get
            {
                return this._dgProductos;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dgProductos != null)
                {
                    this._dgProductos.Click -= new EventHandler(this.dgProductos_Click);
                    this._dgProductos.Navigate -= new NavigateEventHandler(this.dgProductos_Navigate);
                }
                this._dgProductos = value;
                if (this._dgProductos != null)
                {
                    this._dgProductos.Click += new EventHandler(this.dgProductos_Click);
                    this._dgProductos.Navigate += new NavigateEventHandler(this.dgProductos_Navigate);
                }
            }
        }

        internal virtual TextBox editDescProd
        {
            get
            {
                return this._editDescProd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editDescProd != null)
                {
                    this._editDescProd.KeyPress -= new KeyPressEventHandler(this.editDescProd_KeyPress);
                }
                this._editDescProd = value;
                if (this._editDescProd != null)
                {
                    this._editDescProd.KeyPress += new KeyPressEventHandler(this.editDescProd_KeyPress);
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

