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

    public class frmFcProfExp3 : Form
    {
        [AccessedThroughProperty("chkDeselTodo")]
        private CheckBox _chkDeselTodo;
        [AccessedThroughProperty("chkSelTodo")]
        private CheckBox _chkSelTodo;
        [AccessedThroughProperty("cmbModificar")]
        private Button _cmbModificar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dgTmpItemFcProExp")]
        private DataGrid _dgTmpItemFcProExp;
        [AccessedThroughProperty("Label8")]
        private Label _Label8;
        [AccessedThroughProperty("Label9")]
        private Label _Label9;
        [AccessedThroughProperty("txtNomCli")]
        private TextBox _txtNomCli;
        [AccessedThroughProperty("txtNroOV")]
        private TextBox _txtNroOV;
        public SqlDataAdapter AdapTmpItemFcProExp;
        public SqlCommandBuilder CB;
        private IContainer components;
        public DataSet DS;
        public DataSet DS1;
        public string mCodAduana;
        public DateTime mFechaImp;
        public string mPaisOrigen;
        public long TotReg;
        public long xID;

        public frmFcProfExp3()
        {
            base.Load += new EventHandler(this.frmFcProfExp3_Load);
            this.DS = new DataSet();
            this.DS1 = new DataSet();
            this.InitializeComponent();
        }

        private void chkDeselTodo_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = false;
            if (this.chkDeselTodo.Checked)
            {
                SqlConnection connection;
                string str4;
                this.AdapTmpItemFcProExp.Update(this.DS, Variables.gTermi + "TmpItemFcProExp");
                this.DS.Tables[Variables.gTermi + "TmpItemFcProExp"].AcceptChanges();
                try
                {
                    str4 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                    connection = new SqlConnection(str4);
                    connection.Open();
                    flag = true;
                    int num = new SqlCommand("update " + Variables.gTermi + "TmpItemFcProExp set Seleccion=0 where NroOV='" + Variables.gNroOV + "'", connection).ExecuteNonQuery();
                    connection.Close();
                    flag = false;
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    if (flag)
                    {
                        connection.Close();
                        flag = false;
                    }
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                    this.Close();
                    ProjectData.ClearProjectError();
                }
                string selectCommandText = "select * from " + Variables.gTermi + "TmpItemFcProExp where NroOV='" + Variables.gNroOV + "' order by Linea";
                this.AdapTmpItemFcProExp = new SqlDataAdapter(selectCommandText, str4);
                this.CB = new SqlCommandBuilder(this.AdapTmpItemFcProExp);
                this.DS.Clear();
                this.AdapTmpItemFcProExp.Fill(this.DS, Variables.gTermi + "TmpItemFcProExp");
                this.TotReg = this.DS.Tables[Variables.gTermi + "TmpItemFcProExp"].Rows.Count;
                this.dgTmpItemFcProExp.DataSource = this.DS.Tables[Variables.gTermi + "TmpItemFcProExp"];
                this.dgTmpItemFcProExp.Refresh();
                this.chkDeselTodo.Checked = false;
            }
        }

        private void chkSelTodo_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = false;
            if (this.chkSelTodo.Checked)
            {
                SqlConnection connection;
                string str4;
                this.AdapTmpItemFcProExp.Update(this.DS, Variables.gTermi + "TmpItemFcProExp");
                this.DS.Tables[Variables.gTermi + "TmpItemFcProExp"].AcceptChanges();
                try
                {
                    str4 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                    connection = new SqlConnection(str4);
                    connection.Open();
                    flag = true;
                    int num = new SqlCommand("update " + Variables.gTermi + "TmpItemFcProExp set Seleccion=1 where NroOV='" + Variables.gNroOV + "'", connection).ExecuteNonQuery();
                    connection.Close();
                    flag = false;
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    if (flag)
                    {
                        connection.Close();
                        flag = false;
                    }
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                    this.Close();
                    ProjectData.ClearProjectError();
                }
                string selectCommandText = "select * from " + Variables.gTermi + "TmpItemFcProExp where NroOV='" + Variables.gNroOV + "' order by Linea";
                this.AdapTmpItemFcProExp = new SqlDataAdapter(selectCommandText, str4);
                this.CB = new SqlCommandBuilder(this.AdapTmpItemFcProExp);
                this.DS.Clear();
                this.AdapTmpItemFcProExp.Fill(this.DS, Variables.gTermi + "TmpItemFcProExp");
                this.TotReg = this.DS.Tables[Variables.gTermi + "TmpItemFcProExp"].Rows.Count;
                this.dgTmpItemFcProExp.DataSource = this.DS.Tables[Variables.gTermi + "TmpItemFcProExp"];
                this.dgTmpItemFcProExp.Refresh();
                this.dgTmpItemFcProExp.Refresh();
                this.chkSelTodo.Checked = false;
            }
        }

        private void cmbModificar_Click(object sender, EventArgs e)
        {
            SqlConnection connection;
            bool flag2;
            bool flag = false;
            this.AdapTmpItemFcProExp.Update(this.DS, Variables.gTermi + "TmpItemFcProExp");
            this.DS.Tables[Variables.gTermi + "TmpItemFcProExp"].AcceptChanges();
            try
            {
                connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096");
                connection.Open();
                flag = true;
                flag2 = false;
                int num3 = this.DS.Tables[Variables.gTermi + "TmpItemFcProExp"].Rows.Count - 1;
                for (int i = 0; i <= num3; i++)
                {
                    if (ObjectType.ObjTst(this.dgTmpItemFcProExp[i, 0], true, false) == 0)
                    {
                        flag2 = true;
                        int num2 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(("update " + Variables.gTermi + "TmpItemFcProExp set Seleccion=1 where NroOV='") + Variables.gNroOV + "' and Linea='", this.dgTmpItemFcProExp[i, 1]), "'")), connection).ExecuteNonQuery();
                    }
                }
                connection.Close();
                flag = false;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                if (flag)
                {
                    connection.Close();
                    flag = false;
                }
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                this.Close();
                ProjectData.ClearProjectError();
            }
            if (!flag2)
            {
                Variables.gSalir = true;
            }
            else
            {
                Variables.gSalir = false;
            }
            this.Close();
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            Variables.gSalir = true;
            this.Close();
        }

        private void dgTmpItemFcProExp_Click(object sender, EventArgs e)
        {
            int num2 = this.DS.Tables[Variables.gTermi + "TmpItemFcProExp"].Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (this.dgTmpItemFcProExp.IsSelected(i))
                {
                    if (ObjectType.ObjTst(this.dgTmpItemFcProExp[i, 0], false, false) == 0)
                    {
                        this.dgTmpItemFcProExp[i, 0] = true;
                    }
                    else
                    {
                        this.dgTmpItemFcProExp[i, 0] = false;
                    }
                    this.dgTmpItemFcProExp.UnSelect(i);
                }
            }
        }

        private void dgTmpItemFcProExp_Navigate(object sender, NavigateEventArgs ne)
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

        ~frmFcProfExp3()
        {
        }

        private void frmFcProfExp3_Load(object sender, EventArgs e)
        {
            this.txtNroOV.Text = Variables.gNroOV;
            this.txtNomCli.Text = Variables.gNomCli;
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            string selectCommandText = "select * from " + Variables.gTermi + "TmpItemFcProExp where NroOV='" + Variables.gNroOV + "' order by Linea";
            this.AdapTmpItemFcProExp = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.CB = new SqlCommandBuilder(this.AdapTmpItemFcProExp);
            this.AdapTmpItemFcProExp.Fill(this.DS, Variables.gTermi + "TmpItemFcProExp");
            this.dgTmpItemFcProExp.DataSource = this.DS.Tables[Variables.gTermi + "TmpItemFcProExp"];
            DataGridTableStyle table = new DataGridTableStyle();
            table.MappingName = Variables.gTermi + "TmpItemFcProExp";
            DataGridTextBoxColumn column = new DataGridTextBoxColumn();
            DataGridBoolColumn column2 = new DataGridBoolColumn();
            DataGridBoolColumn column9 = column2;
            column9.HeaderText = "Sel.";
            column9.MappingName = "Seleccion";
            column9.Width = 0x23;
            column9 = null;
            table.GridColumnStyles.Add(column2);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column8 = column;
            column8.HeaderText = "L\x00ednea";
            column8.MappingName = "Linea";
            column8.ReadOnly = true;
            column8.Width = 60;
            column8 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column7 = column;
            column7.HeaderText = "C\x00f3digo";
            column7.MappingName = "Codigo";
            column7.ReadOnly = true;
            column7.Width = 70;
            column7 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column6 = column;
            column6.HeaderText = "Producto";
            column6.MappingName = "Descripcion";
            column6.ReadOnly = true;
            column6.Width = 250;
            column6 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column5 = column;
            column5.HeaderText = "Cantidad OV";
            column5.MappingName = "CantidadOV";
            column5.Width = 70;
            column5.ReadOnly = false;
            column5.Format = "######0";
            column5 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column4 = column;
            column4.HeaderText = "Fecha Conf.";
            column4.MappingName = "FechaConf";
            column4.ReadOnly = true;
            column4.Width = 80;
            column4 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column3 = column;
            column3.HeaderText = "Precio Unit.";
            column3.MappingName = "PrecioUnit";
            column3.ReadOnly = true;
            column3.Width = 80;
            column3 = null;
            table.GridColumnStyles.Add(column);
            this.dgTmpItemFcProExp.TableStyles.Add(table);
            this.dgTmpItemFcProExp.Refresh();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.cmbSalir = new Button();
            this.dgTmpItemFcProExp = new DataGrid();
            this.txtNomCli = new TextBox();
            this.Label8 = new Label();
            this.Label9 = new Label();
            this.txtNroOV = new TextBox();
            this.chkDeselTodo = new CheckBox();
            this.chkSelTodo = new CheckBox();
            this.cmbModificar = new Button();
            this.dgTmpItemFcProExp.BeginInit();
            this.SuspendLayout();
            Point point = new Point(920, 0x220);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            Size size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 11;
            this.cmbSalir.Text = "&Salir";
            this.dgTmpItemFcProExp.CaptionFont = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dgTmpItemFcProExp.CaptionText = "Productos";
            this.dgTmpItemFcProExp.DataMember = "";
            this.dgTmpItemFcProExp.HeaderForeColor = SystemColors.ControlText;
            point = new Point(8, 40);
            this.dgTmpItemFcProExp.Location = point;
            this.dgTmpItemFcProExp.Name = "dgTmpItemFcProExp";
            size = new Size(0x3f8, 0x1e8);
            this.dgTmpItemFcProExp.Size = size;
            this.dgTmpItemFcProExp.TabIndex = 2;
            this.txtNomCli.BackColor = SystemColors.Window;
            this.txtNomCli.Enabled = false;
            this.txtNomCli.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x148, 8);
            this.txtNomCli.Location = point;
            this.txtNomCli.MaxLength = 0x23;
            this.txtNomCli.Name = "txtNomCli";
            size = new Size(0x1e8, 0x16);
            this.txtNomCli.Size = size;
            this.txtNomCli.TabIndex = 1;
            this.txtNomCli.Text = "";
            this.Label8.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0xe8, 8);
            this.Label8.Location = point;
            this.Label8.Name = "Label8";
            size = new Size(80, 0x10);
            this.Label8.Size = size;
            this.Label8.TabIndex = 0;
            this.Label8.Text = "Cliente:";
            this.Label9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 8);
            this.Label9.Location = point;
            this.Label9.Name = "Label9";
            size = new Size(0x60, 0x17);
            this.Label9.Size = size;
            this.Label9.TabIndex = 12;
            this.Label9.Text = "Nro.O.Venta:";
            this.txtNroOV.BackColor = SystemColors.Window;
            this.txtNroOV.Enabled = false;
            this.txtNroOV.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x70, 8);
            this.txtNroOV.Location = point;
            this.txtNroOV.MaxLength = 10;
            this.txtNroOV.Name = "txtNroOV";
            size = new Size(0x70, 0x16);
            this.txtNroOV.Size = size;
            this.txtNroOV.TabIndex = 13;
            this.txtNroOV.Text = "";
            point = new Point(0x80, 0x228);
            this.chkDeselTodo.Location = point;
            this.chkDeselTodo.Name = "chkDeselTodo";
            size = new Size(0x80, 0x18);
            this.chkDeselTodo.Size = size;
            this.chkDeselTodo.TabIndex = 15;
            this.chkDeselTodo.Text = "Deseleccionar todo";
            point = new Point(8, 0x228);
            this.chkSelTodo.Location = point;
            this.chkSelTodo.Name = "chkSelTodo";
            size = new Size(0x70, 0x18);
            this.chkSelTodo.Size = size;
            this.chkSelTodo.TabIndex = 14;
            this.chkSelTodo.Text = "Seleccionar todo";
            point = new Point(0x330, 0x220);
            this.cmbModificar.Location = point;
            this.cmbModificar.Name = "cmbModificar";
            size = new Size(0x60, 40);
            this.cmbModificar.Size = size;
            this.cmbModificar.TabIndex = 0x10;
            this.cmbModificar.Text = "&Aceptar";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            size = new Size(0x404, 0x2f1);
            this.ClientSize = size;
            this.Controls.Add(this.cmbModificar);
            this.Controls.Add(this.chkDeselTodo);
            this.Controls.Add(this.chkSelTodo);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.txtNroOV);
            this.Controls.Add(this.txtNomCli);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.dgTmpItemFcProExp);
            this.Controls.Add(this.cmbSalir);
            this.Name = "frmFcProfExp3";
            this.Text = "Facturas Proforma Exportaci\x00f3n";
            this.WindowState = FormWindowState.Maximized;
            this.dgTmpItemFcProExp.EndInit();
            this.ResumeLayout(false);
        }

        internal virtual CheckBox chkDeselTodo
        {
            get
            {
                return this._chkDeselTodo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._chkDeselTodo != null)
                {
                    this._chkDeselTodo.CheckedChanged -= new EventHandler(this.chkDeselTodo_CheckedChanged);
                }
                this._chkDeselTodo = value;
                if (this._chkDeselTodo != null)
                {
                    this._chkDeselTodo.CheckedChanged += new EventHandler(this.chkDeselTodo_CheckedChanged);
                }
            }
        }

        internal virtual CheckBox chkSelTodo
        {
            get
            {
                return this._chkSelTodo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._chkSelTodo != null)
                {
                    this._chkSelTodo.CheckedChanged -= new EventHandler(this.chkSelTodo_CheckedChanged);
                }
                this._chkSelTodo = value;
                if (this._chkSelTodo != null)
                {
                    this._chkSelTodo.CheckedChanged += new EventHandler(this.chkSelTodo_CheckedChanged);
                }
            }
        }

        internal virtual Button cmbModificar
        {
            get
            {
                return this._cmbModificar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbModificar != null)
                {
                    this._cmbModificar.Click -= new EventHandler(this.cmbModificar_Click);
                }
                this._cmbModificar = value;
                if (this._cmbModificar != null)
                {
                    this._cmbModificar.Click += new EventHandler(this.cmbModificar_Click);
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

        internal virtual DataGrid dgTmpItemFcProExp
        {
            get
            {
                return this._dgTmpItemFcProExp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dgTmpItemFcProExp != null)
                {
                    this._dgTmpItemFcProExp.Navigate -= new NavigateEventHandler(this.dgTmpItemFcProExp_Navigate);
                    this._dgTmpItemFcProExp.Click -= new EventHandler(this.dgTmpItemFcProExp_Click);
                }
                this._dgTmpItemFcProExp = value;
                if (this._dgTmpItemFcProExp != null)
                {
                    this._dgTmpItemFcProExp.Navigate += new NavigateEventHandler(this.dgTmpItemFcProExp_Navigate);
                    this._dgTmpItemFcProExp.Click += new EventHandler(this.dgTmpItemFcProExp_Click);
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

        internal virtual Label Label9
        {
            get
            {
                return this._Label9;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label9 != null)
                {
                }
                this._Label9 = value;
                if (this._Label9 != null)
                {
                }
            }
        }

        internal virtual TextBox txtNomCli
        {
            get
            {
                return this._txtNomCli;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtNomCli != null)
                {
                }
                this._txtNomCli = value;
                if (this._txtNomCli != null)
                {
                }
            }
        }

        internal virtual TextBox txtNroOV
        {
            get
            {
                return this._txtNroOV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtNroOV != null)
                {
                }
                this._txtNroOV = value;
                if (this._txtNroOV != null)
                {
                }
            }
        }
    }
}

