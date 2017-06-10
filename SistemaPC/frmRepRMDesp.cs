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

    public class frmRepRMDesp : Form
    {
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dgMetEnvio")]
        private DataGrid _dgMetEnvio;
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
        public SqlDataAdapter AdapTmp;
        public SqlCommandBuilder CB;
        private IContainer components;
        public DataSet DS;

        public frmRepRMDesp()
        {
            base.Closed += new EventHandler(this.frmRepRMDesp_Closed);
            base.Load += new EventHandler(this.frmRepRMDesp_Load);
            this.DS = new DataSet();
            this.InitializeComponent();
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            SqlConnection connection;
            bool flag = false;
            try
            {
                connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096");
                connection.Open();
                flag = true;
                bool flag2 = false;
                int num3 = this.DS.Tables[Variables.gTermi + "TmpMetEnvio"].Rows.Count - 1;
                for (int i = 0; i <= num3; i++)
                {
                    int num2;
                    if (ObjectType.ObjTst(this.dgMetEnvio[i, 0], true, false) == 0)
                    {
                        flag2 = true;
                        SqlCommand command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("update " + Variables.gTermi + "TmpMetEnvio set Seleccion=1 where MetEnvio='", this.dgMetEnvio[i, 1]), "'")), connection);
                        num2 = command.ExecuteNonQuery();
                    }
                    else
                    {
                        num2 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("update " + Variables.gTermi + "TmpMetEnvio set Seleccion=0 where MetEnvio='", this.dgMetEnvio[i, 1]), "'")), connection).ExecuteNonQuery();
                    }
                }
                connection.Close();
                flag = false;
                if (!flag2)
                {
                    Interaction.MsgBox("Debe seleccionar alg\x00fan m\x00e9todo de env\x00edo", MsgBoxStyle.Critical, "Operador");
                    return;
                }
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
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                this.Close();
                ProjectData.ClearProjectError();
            }
            this.dtpFechaDesde.Enabled = false;
            this.dtpFechaHasta.Enabled = false;
            this.cmbAceptar.Enabled = false;
            this.cmbSalir.Enabled = false;
            if (this.dtpFechaDesde.Checked)
            {
                Variables.gDesde = StringType.FromDate(this.dtpFechaDesde.Value);
            }
            else
            {
                Variables.gDesde = "";
            }
            if (this.dtpFechaHasta.Checked)
            {
                Variables.gHasta = StringType.FromDate(this.dtpFechaHasta.Value);
            }
            else
            {
                Variables.gHasta = "";
            }
            frmRepRMDesp1 desp = new frmRepRMDesp1();
            this.Hide();
            desp.Show();
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgMetEnvio_Click(object sender, EventArgs e)
        {
            int num2 = this.DS.Tables[Variables.gTermi + "TmpMetEnvio"].Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (this.dgMetEnvio.IsSelected(i))
                {
                    if (ObjectType.ObjTst(this.dgMetEnvio[i, 0], false, false) == 0)
                    {
                        this.dgMetEnvio[i, 0] = true;
                    }
                    else
                    {
                        this.dgMetEnvio[i, 0] = false;
                    }
                    this.dgMetEnvio.UnSelect(i);
                }
            }
        }

        private void dgMetEnvio_Navigate(object sender, NavigateEventArgs ne)
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

        private void dtpFechaDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.dtpFechaHasta.Focus();
            }
        }

        private void dtpFechaHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        ~frmRepRMDesp()
        {
        }

        private void frmRepRMDesp_Closed(object sender, EventArgs e)
        {
            new frmMenuExp().Show();
        }

        private void frmRepRMDesp_Load(object sender, EventArgs e)
        {
            this.dtpFechaDesde.Value = DateAndTime.Now;
            this.dtpFechaHasta.Value = DateAndTime.Now;
            string connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            string str4 = connectionString;
            SqlConnection connection2 = new SqlConnection(connectionString);
            connection2.Open();
            SqlCommand command = new SqlCommand("delete " + Variables.gTermi + "TmpMetEnvio", connection2);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                connection2.Close();
                ProjectData.ClearProjectError();
                return;
                ProjectData.ClearProjectError();
            }
            SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=True;packet size=4096");
            connection.Open();
            string cmdText = "SELECT SL23003+'-'+SL23004 as MetEnv,SL23003 FROM dbo.SL230100 where SL23001='2' and SL23002='00' order by MetEnv";
            command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpMetEnvio (MetEnvio,Seleccion) values ('", reader["MetEnv"]), "',1)")), connection2);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception exception3)
                {
                    ProjectData.SetProjectError(exception3);
                    Exception exception2 = exception3;
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, MsgBoxStyle.OKOnly, null);
                    reader.Close();
                    connection.Close();
                    connection2.Close();
                    ProjectData.ClearProjectError();
                    return;
                    ProjectData.ClearProjectError();
                }
            }
            reader.Close();
            connection.Close();
            connection2.Close();
            connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            string selectCommandText = "select * from " + Variables.gTermi + "TmpMetEnvio order by MetEnvio";
            this.AdapTmp = new SqlDataAdapter(selectCommandText, connectionString);
            this.CB = new SqlCommandBuilder(this.AdapTmp);
            this.AdapTmp.Fill(this.DS, Variables.gTermi + "TmpMetEnvio");
            this.dgMetEnvio.DataSource = this.DS.Tables[Variables.gTermi + "TmpMetEnvio"];
            DataGridTableStyle table = new DataGridTableStyle();
            table.MappingName = Variables.gTermi + "TmpMetEnvio";
            DataGridTextBoxColumn column = new DataGridTextBoxColumn();
            DataGridBoolColumn column2 = new DataGridBoolColumn();
            DataGridBoolColumn column4 = column2;
            column4.HeaderText = "Sel.";
            column4.MappingName = "Seleccion";
            column4.Width = 0x23;
            column4 = null;
            table.GridColumnStyles.Add(column2);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column3 = column;
            column3.HeaderText = "Metodo Env\x00edo";
            column3.MappingName = "MetEnvio";
            column3.ReadOnly = true;
            column3.Width = 390;
            column3 = null;
            table.GridColumnStyles.Add(column);
            this.dgMetEnvio.TableStyles.Add(table);
            this.dgMetEnvio.Refresh();
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
            this.dgMetEnvio = new DataGrid();
            this.dgMetEnvio.BeginInit();
            this.SuspendLayout();
            Point point = new Point(0x268, 0x1f0);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 5;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0x268, 440);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 6;
            this.cmbSalir.Text = "&Salir";
            this.Label2.Font = new Font("Arial", 12f, FontStyle.Underline | FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0xa8, 0x60);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x138, 20);
            this.Label2.Size = size;
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Reporte Remitos Despachados";
            this.Label2.TextAlign = ContentAlignment.MiddleCenter;
            point = new Point(160, 0x90);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(200, 0x10);
            this.Label1.Size = size;
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Desde Fecha/Hora Expedici\x00f3n:";
            point = new Point(160, 0xb0);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(200, 0x10);
            this.Label3.Size = size;
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Hasta Fecha/Hora Expedici\x00f3n:";
            this.dtpFechaDesde.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaDesde.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaDesde.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaDesde.Format = DateTimePickerFormat.Custom;
            point = new Point(0x170, 0x90);
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
            this.dtpFechaHasta.Format = DateTimePickerFormat.Custom;
            point = new Point(0x170, 0xb0);
            this.dtpFechaHasta.Location = point;
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.ShowCheckBox = true;
            size = new Size(0x70, 0x16);
            this.dtpFechaHasta.Size = size;
            this.dtpFechaHasta.TabIndex = 4;
            time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpFechaHasta.Value = time;
            this.dgMetEnvio.CaptionFont = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dgMetEnvio.CaptionText = "M\x00e9todos de Env\x00edo";
            this.dgMetEnvio.DataMember = "";
            this.dgMetEnvio.HeaderForeColor = SystemColors.ControlText;
            point = new Point(0x60, 0xd8);
            this.dgMetEnvio.Location = point;
            this.dgMetEnvio.Name = "dgMetEnvio";
            size = new Size(0x1d8, 0x138);
            this.dgMetEnvio.Size = size;
            this.dgMetEnvio.TabIndex = 7;
            size = new Size(6, 15);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.dgMetEnvio);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Name = "frmRepRMDesp";
            this.Text = "Reporte Remitos Despachados";
            this.WindowState = FormWindowState.Maximized;
            this.dgMetEnvio.EndInit();
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

        internal virtual DataGrid dgMetEnvio
        {
            get
            {
                return this._dgMetEnvio;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dgMetEnvio != null)
                {
                    this._dgMetEnvio.Click -= new EventHandler(this.dgMetEnvio_Click);
                    this._dgMetEnvio.Navigate -= new NavigateEventHandler(this.dgMetEnvio_Navigate);
                }
                this._dgMetEnvio = value;
                if (this._dgMetEnvio != null)
                {
                    this._dgMetEnvio.Click += new EventHandler(this.dgMetEnvio_Click);
                    this._dgMetEnvio.Navigate += new NavigateEventHandler(this.dgMetEnvio_Navigate);
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
                }
                this._dtpFechaDesde = value;
                if (this._dtpFechaDesde != null)
                {
                    this._dtpFechaDesde.KeyPress += new KeyPressEventHandler(this.dtpFechaDesde_KeyPress);
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
                }
                this._dtpFechaHasta = value;
                if (this._dtpFechaHasta != null)
                {
                    this._dtpFechaHasta.KeyPress += new KeyPressEventHandler(this.dtpFechaHasta_KeyPress);
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

