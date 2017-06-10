namespace SistemaPC
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmReclamosOC : Form
    {
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dgReclamos")]
        private DataGrid _dgReclamos;
        [AccessedThroughProperty("Label8")]
        private Label _Label8;
        [AccessedThroughProperty("txtPackList")]
        private TextBox _txtPackList;
        public SqlDataAdapter AdapReclamos;
        private IContainer components;
        public DataSet DS;
        public string mCodAduana;
        public string mDespacho;
        public DateTime mFechaImp;
        public long mID;
        public string mPaisOrigen;
        public long TotReg;

        public frmReclamosOC()
        {
            base.Load += new EventHandler(this.frmReclamosOC_Load);
            base.Closed += new EventHandler(this.frmReclamosOC_Closed);
            this.DS = new DataSet();
            this.InitializeComponent();
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            this.AdapReclamos.Update(this.DS, "Reclamos");
            this.DS.Tables["Reclamos"].AcceptChanges();
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            string selectCommandText = "select * from Reclamos where PackList='" + Variables.gPackList + "' and Aceptar=0";
            this.AdapReclamos = new SqlDataAdapter(selectCommandText, selectConnectionString);
            SqlCommandBuilder builder = new SqlCommandBuilder(this.AdapReclamos);
            this.DS.Tables.Clear();
            this.AdapReclamos.Fill(this.DS, "Reclamos");
            this.TotReg = this.DS.Tables["Reclamos"].Rows.Count;
            this.dgReclamos.DataSource = this.DS.Tables["Reclamos"];
            this.dgReclamos.Refresh();
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgRecepcion_DoubleClick(object sender, EventArgs e)
        {
            if (ObjectType.ObjTst(this.dgReclamos[this.dgReclamos.CurrentCell], false, false) == 0)
            {
                this.dgReclamos[this.dgReclamos.CurrentCell] = true;
            }
            else
            {
                this.dgReclamos[this.dgReclamos.CurrentCell] = false;
            }
        }

        private void dgReclamos_Navigate(object sender, NavigateEventArgs ne)
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

        ~frmReclamosOC()
        {
        }

        private void frmReclamosOC_Closed(object sender, EventArgs e)
        {
            new frmDiscrepanciasOC().Show();
        }

        private void frmReclamosOC_Load(object sender, EventArgs e)
        {
            this.txtPackList.Text = Variables.gPackList;
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            string selectCommandText = "select * from Reclamos where PackList='" + Variables.gPackList + "' and Aceptar=0";
            this.AdapReclamos = new SqlDataAdapter(selectCommandText, selectConnectionString);
            SqlCommandBuilder builder = new SqlCommandBuilder(this.AdapReclamos);
            this.AdapReclamos.Fill(this.DS, "Reclamos");
            this.TotReg = this.DS.Tables["Reclamos"].Rows.Count;
            this.dgReclamos.DataSource = this.DS.Tables["Reclamos"];
            DataGridTableStyle table = new DataGridTableStyle();
            table.MappingName = "Reclamos";
            DataGridTextBoxColumn column = new DataGridTextBoxColumn();
            DataGridBoolColumn column2 = new DataGridBoolColumn();
            DataGridBoolColumn column17 = column2;
            column17.HeaderText = "Acep.";
            column17.MappingName = "Aceptar";
            column17.Width = 0x23;
            column17 = null;
            table.GridColumnStyles.Add(column2);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column16 = column;
            column16.HeaderText = "Nro.Bulto";
            column16.MappingName = "NroBulto";
            column16.Width = 60;
            column16 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column15 = column;
            column15.HeaderText = "Nro.OC";
            column15.MappingName = "NroOC";
            column15.Width = 70;
            column15 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column14 = column;
            column14.HeaderText = "L\x00ednea";
            column14.MappingName = "NroLinea";
            column14.Width = 0x2d;
            column14.NullText = "";
            column14 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column13 = column;
            column13.HeaderText = "C\x00f3digo";
            column13.MappingName = "Codigo";
            column13.Width = 60;
            column13 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column12 = column;
            column12.HeaderText = "Cant.OC";
            column12.MappingName = "CantPend";
            column12.Width = 50;
            column12.Format = "######0";
            column12.NullText = "";
            column12 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column11 = column;
            column11.HeaderText = "Cant.Rec.";
            column11.MappingName = "CantRec";
            column11.Width = 60;
            column11.Format = "######0";
            column11 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column10 = column;
            column10.HeaderText = "F.Recepci\x00f3n";
            column10.MappingName = "FechaRec";
            column10.Format = "dd/MM/yyyy";
            column10.Width = 70;
            column10 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column9 = column;
            column9.HeaderText = "Descripci\x00f3n";
            column9.MappingName = "Desc1";
            column9.Width = 150;
            column9.NullText = "";
            column9 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column8 = column;
            column8.HeaderText = "Descripci\x00f3n";
            column8.MappingName = "Desc2";
            column8.Width = 150;
            column8.NullText = "";
            column8 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column7 = column;
            column7.HeaderText = "";
            column7.MappingName = "Despacho";
            column7.Width = 0;
            column7.NullText = "";
            column7 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column6 = column;
            column6.HeaderText = "";
            column6.MappingName = "FechaImp";
            column6.Width = 0;
            column6.Format = "dd/MM/yyyy";
            column6.NullText = "";
            column6 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column5 = column;
            column5.HeaderText = "";
            column5.MappingName = "CodAduana";
            column5.Width = 0;
            column5.NullText = "";
            column5 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column4 = column;
            column4.HeaderText = "";
            column4.MappingName = "PaisOrigen";
            column4.Width = 0;
            column4.NullText = "";
            column4 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column3 = column;
            column3.HeaderText = "";
            column3.MappingName = "ID";
            column3.Width = 0;
            column3 = null;
            table.GridColumnStyles.Add(column);
            this.dgReclamos.TableStyles.Add(table);
            this.dgReclamos.Refresh();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmReclamosOC));
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.dgReclamos = new DataGrid();
            this.txtPackList = new TextBox();
            this.Label8 = new Label();
            this.dgReclamos.BeginInit();
            this.SuspendLayout();
            Point point = new Point(0x390, 0x240);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 2;
            this.cmbAceptar.Text = "&Aceptar";
            point = new Point(800, 0x240);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 3;
            this.cmbSalir.Text = "&Salir";
            this.dgReclamos.CaptionFont = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dgReclamos.CaptionText = "Reclamos Recepci\x00f3n O.Compra";
            this.dgReclamos.DataMember = "";
            this.dgReclamos.HeaderForeColor = SystemColors.ControlText;
            point = new Point(8, 0x38);
            this.dgReclamos.Location = point;
            this.dgReclamos.Name = "dgReclamos";
            this.dgReclamos.ReadOnly = true;
            size = new Size(0x3f8, 0x1f0);
            this.dgReclamos.Size = size;
            this.dgReclamos.TabIndex = 0;
            this.txtPackList.BackColor = SystemColors.Window;
            this.txtPackList.Enabled = false;
            this.txtPackList.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x68, 0x10);
            this.txtPackList.Location = point;
            this.txtPackList.MaxLength = 10;
            this.txtPackList.Name = "txtPackList";
            size = new Size(0x98, 0x16);
            this.txtPackList.Size = size;
            this.txtPackList.TabIndex = 0x3b;
            this.txtPackList.Text = "";
            this.Label8.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x10);
            this.Label8.Location = point;
            this.Label8.Name = "Label8";
            size = new Size(0x58, 0x10);
            this.Label8.Size = size;
            this.Label8.TabIndex = 0x3a;
            this.Label8.Text = "Packing List:";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            size = new Size(0x404, 0x2d5);
            this.ClientSize = size;
            this.Controls.Add(this.txtPackList);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.dgReclamos);
            this.Controls.Add(this.cmbSalir);
            this.Controls.Add(this.cmbAceptar);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmReclamosOC";
            this.Text = "Reclamos Recepci\x00f3n O.Compra";
            this.WindowState = FormWindowState.Maximized;
            this.dgReclamos.EndInit();
            this.ResumeLayout(false);
        }

        private void Label1_Click(object sender, EventArgs e)
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

        internal virtual DataGrid dgReclamos
        {
            get
            {
                return this._dgReclamos;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dgReclamos != null)
                {
                    this._dgReclamos.Navigate -= new NavigateEventHandler(this.dgReclamos_Navigate);
                    this._dgReclamos.DoubleClick -= new EventHandler(this.dgRecepcion_DoubleClick);
                }
                this._dgReclamos = value;
                if (this._dgReclamos != null)
                {
                    this._dgReclamos.Navigate += new NavigateEventHandler(this.dgReclamos_Navigate);
                    this._dgReclamos.DoubleClick += new EventHandler(this.dgRecepcion_DoubleClick);
                }
            }
        }

        internal virtual Label Label8
        {
            get
            {
                return this._Label8;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label8 != null)
                {
                }
                this._Label8 = value;
                if (this._Label8 != null)
                {
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
                }
                this._txtPackList = value;
                if (this._txtPackList != null)
                {
                }
            }
        }
    }
}

