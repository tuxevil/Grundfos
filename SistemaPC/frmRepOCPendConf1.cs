namespace SistemaPC
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Windows.Forms;
    using Microsoft.VisualBasic;
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

    public class frmRepOCPendConf1 : Form
    {
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("CrystalReportViewer1")]
        private CrystalReportViewer _CrystalReportViewer1;
        public SqlDataAdapter AdapPC01;
        public SqlDataAdapter AdapPC03;
        public SqlDataAdapter AdapPL01;
        public SqlDataAdapter AdapPL23;
        public SqlDataAdapter AdapSL01;
        public SqlDataAdapter AdapTmp;
        private IContainer components;
        public DataSet DS;
        public DataSet DS1;
        public ReportDocument Informe;

        public frmRepOCPendConf1()
        {
            base.Closed += new EventHandler(this.frmRepOCPendConf1_Closed);
            base.Load += new EventHandler(this.frmRepOCPendConf1_Load);
            this.Informe = new ReportDocument();
            this.DS = new DataSet();
            this.DS1 = new DataSet();
            this.InitializeComponent();
            bool flag = false;
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
            this.DS.Clear();
            this.DS1.Clear();
            string selectCommandText = "SELECT PC01001,PC01003,PC01004,PC01014,PC01015,PC01016 FROM dbo.PC010100";
            if (StringType.StrCmp(Variables.gCodProv, "", false) != 0)
            {
                selectCommandText = selectCommandText + " where PC01003='" + Variables.gCodProv + "'";
                if (StringType.StrCmp(Variables.gCodMetEnt, "", false) != 0)
                {
                    selectCommandText = selectCommandText + " and PC01014=" + Variables.gCodMetEnt;
                }
            }
            else if (StringType.StrCmp(Variables.gCodMetEnt, "", false) != 0)
            {
                selectCommandText = selectCommandText + " where PC01014=" + Variables.gCodMetEnt;
            }
            this.AdapPC01 = new SqlDataAdapter(selectCommandText, selectConnectionString);
            selectCommandText = "SELECT PC03001,PC03005,PC03006,PC03007,PC03010,PC03011 FROM dbo.PC030100 where PC03011<PC03010 and PC03029=''";
            if (StringType.StrCmp(Variables.gCodAlmacen, "", false) != 0)
            {
                selectCommandText = selectCommandText + " and PC03035='" + Variables.gCodAlmacen + "'";
            }
            this.AdapPC03 = new SqlDataAdapter(selectCommandText, selectConnectionString);
            selectCommandText = "SELECT SL01001,SL01002 FROM dbo.SL010100";
            this.AdapSL01 = new SqlDataAdapter(selectCommandText, selectConnectionString);
            selectCommandText = "SELECT PL01001,PL01002 FROM dbo.PL010100";
            this.AdapPL01 = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.AdapPC01.Fill(this.DS, "PC010100");
            this.AdapPC03.Fill(this.DS, "PC030100");
            this.AdapSL01.Fill(this.DS, "SL010100");
            this.AdapPL01.Fill(this.DS, "PL010100");
            selectCommandText = "SELECT PL23003,PL23004 FROM dbo.PL230100 where PL23001='2' and PL23002='00'";
            this.AdapPL23 = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.AdapPL23.Fill(this.DS1, "PL230100");
            string connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            flag = true;
            SqlCommand command = new SqlCommand("delete " + Variables.gTermi + "TmpFormaDesp", connection);
            int num2 = command.ExecuteNonQuery();
            int num3 = this.DS1.Tables["PL230100"].Rows.Count - 1;
            for (int i = 0; i <= num3; i++)
            {
                DataRow row = this.DS1.Tables["PL230100"].Rows[i];
                command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpFormaDesp (Codigo,Descripcion) values (", row["PL23003"]), ",'"), row["PL23004"]), "')")), connection);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                    if (flag)
                    {
                        connection.Close();
                        flag = false;
                    }
                    ProjectData.ClearProjectError();
                    return;
                    ProjectData.ClearProjectError();
                }
            }
            connection.Close();
            flag = false;
            selectCommandText = "select * from " + Variables.gTermi + "TmpFormaDesp as PC1TmpFormaDesp";
            this.AdapTmp = new SqlDataAdapter(selectCommandText, connectionString);
            this.AdapTmp.Fill(this.DS, "PC1TmpFormaDesp");
            this.Informe.Load(Application.StartupPath + @"\repocpendconf.rpt");
            this.Informe.SetDataSource(this.DS);
            FormulaFieldDefinitions formulaFields = this.Informe.DataDefinition.FormulaFields;
            FormulaFieldDefinition definition = formulaFields["almacen"];
            if (StringType.StrCmp(Variables.gCodAlmacen, Strings.Space(0), false) != 0)
            {
                definition.Text = "'Almacen: " + Strings.Trim(Variables.gNomAlmacen) + "'";
            }
            else
            {
                definition.Text = "'Todos los almacenes'";
            }
            FormulaFieldDefinition definition2 = formulaFields["formadesp"];
            if (StringType.StrCmp(Variables.gCodMetEnt, Strings.Space(0), false) != 0)
            {
                definition2.Text = "'Forma Despacho: " + Strings.Trim(Variables.gDescMetEnt) + "'";
            }
            else
            {
                definition2.Text = "'Todos las formas de despacho'";
            }
            this.CrystalReportViewer1.ShowGroupTreeButton = true;
            this.CrystalReportViewer1.ReportSource = this.Informe;
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
        }

        private void CrystalReportViewer1_ReportRefresh(object source, ViewerEventArgs e)
        {
            bool flag = false;
            this.cmbSalir.Enabled = false;
            this.Informe.Close();
            this.DS.Clear();
            this.DS1.Clear();
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
            string selectCommandText = "SELECT PC01001,PC01003,PC01004,PC01014,PC01015,PC01016 FROM dbo.PC010100";
            if (StringType.StrCmp(Variables.gCodProv, "", false) != 0)
            {
                selectCommandText = selectCommandText + " where PC01003='" + Variables.gCodProv + "'";
                if (StringType.StrCmp(Variables.gCodMetEnt, "", false) != 0)
                {
                    selectCommandText = selectCommandText + " and PC01014=" + Variables.gCodMetEnt;
                }
            }
            else if (StringType.StrCmp(Variables.gCodMetEnt, "", false) != 0)
            {
                selectCommandText = selectCommandText + " where PC01014=" + Variables.gCodMetEnt;
            }
            this.AdapPC01 = new SqlDataAdapter(selectCommandText, selectConnectionString);
            selectCommandText = "SELECT PC03001,PC03005,PC03006,PC03007,PC03010,PC03011 FROM dbo.PC030100 where PC03011<PC03010 and PC03029=''";
            if (StringType.StrCmp(Variables.gCodAlmacen, "", false) != 0)
            {
                selectCommandText = selectCommandText + " and PC03035='" + Variables.gCodAlmacen + "'";
            }
            this.AdapPC03 = new SqlDataAdapter(selectCommandText, selectConnectionString);
            selectCommandText = "SELECT SL01001,SL01002 FROM dbo.SL010100";
            this.AdapSL01 = new SqlDataAdapter(selectCommandText, selectConnectionString);
            selectCommandText = "SELECT PL01001,PL01002 FROM dbo.PL010100";
            this.AdapPL01 = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.AdapPC01.Fill(this.DS, "PC010100");
            this.AdapPC03.Fill(this.DS, "PC030100");
            this.AdapSL01.Fill(this.DS, "SL010100");
            this.AdapPL01.Fill(this.DS, "PL010100");
            selectCommandText = "SELECT PL23003,PL23004 FROM dbo.PL230100 where PL23001='2' and PL23002='00'";
            this.AdapPL23 = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.AdapPL23.Fill(this.DS1, "PL230100");
            string connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            flag = true;
            SqlCommand command = new SqlCommand("delete " + Variables.gTermi + "TmpFormaDesp", connection);
            int num2 = command.ExecuteNonQuery();
            int num3 = this.DS1.Tables["PL230100"].Rows.Count - 1;
            for (int i = 0; i <= num3; i++)
            {
                DataRow row = this.DS1.Tables["PL230100"].Rows[i];
                command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpFormaDesp (Codigo,Descripcion) values (", row["PL23003"]), ",'"), row["PL23004"]), "')")), connection);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                    if (flag)
                    {
                        connection.Close();
                        flag = false;
                    }
                    ProjectData.ClearProjectError();
                    return;
                    ProjectData.ClearProjectError();
                }
            }
            connection.Close();
            flag = false;
            selectCommandText = "select * from " + Variables.gTermi + "TmpFormaDesp as PC1TmpFormaDesp";
            this.AdapTmp = new SqlDataAdapter(selectCommandText, connectionString);
            this.AdapTmp.Fill(this.DS, "PC1TmpFormaDesp");
            this.Informe.Load(Application.StartupPath + @"\repocpendconf.rpt");
            this.Informe.SetDataSource(this.DS);
            FormulaFieldDefinitions formulaFields = this.Informe.DataDefinition.FormulaFields;
            FormulaFieldDefinition definition = formulaFields["almacen"];
            if (StringType.StrCmp(Variables.gCodAlmacen, Strings.Space(0), false) != 0)
            {
                definition.Text = "'Almacen: " + Strings.Trim(Variables.gNomAlmacen) + "'";
            }
            else
            {
                definition.Text = "'Todos los almacenes'";
            }
            FormulaFieldDefinition definition2 = formulaFields["formadesp"];
            if (StringType.StrCmp(Variables.gCodMetEnt, Strings.Space(0), false) != 0)
            {
                definition2.Text = "'Forma Despacho: " + Strings.Trim(Variables.gDescMetEnt) + "'";
            }
            else
            {
                definition2.Text = "'Todos las formas de despacho'";
            }
            this.CrystalReportViewer1.ShowGroupTreeButton = true;
            this.CrystalReportViewer1.ReportSource = this.Informe;
            this.CrystalReportViewer1.Refresh();
            this.cmbSalir.Enabled = true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        ~frmRepOCPendConf1()
        {
        }

        private void frmRepOCPendConf1_Closed(object sender, EventArgs e)
        {
        }

        private void frmRepOCPendConf1_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRepOCPendConf1));
            this.cmbSalir = new Button();
            this.CrystalReportViewer1 = new CrystalReportViewer();
            this.SuspendLayout();
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            Point point = new Point(0x390, 0x2a0);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            Size size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 3;
            this.cmbSalir.Text = "&Salir";
            this.CrystalReportViewer1.ActiveViewIndex = -1;
            this.CrystalReportViewer1.DisplayGroupTree = false;
            point = new Point(8, 8);
            this.CrystalReportViewer1.Location = point;
            this.CrystalReportViewer1.Name = "CrystalReportViewer1";
            this.CrystalReportViewer1.ReportSource = null;
            size = new Size(0x3f0, 640);
            this.CrystalReportViewer1.Size = size;
            this.CrystalReportViewer1.TabIndex = 0x36;
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x404, 0x2d5);
            this.ClientSize = size;
            this.Controls.Add(this.CrystalReportViewer1);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmRepOCPendConf1";
            this.Text = "Reporte O.Compra Pendientes de Confirmaci\x00f3n";
            this.WindowState = FormWindowState.Maximized;
            this.ResumeLayout(false);
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

        internal virtual CrystalReportViewer CrystalReportViewer1
        {
            get
            {
                return this._CrystalReportViewer1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._CrystalReportViewer1 != null)
                {
                    this._CrystalReportViewer1.ReportRefresh -= new CrystalDecisions.Windows.Forms.RefreshEventHandler(this.CrystalReportViewer1_ReportRefresh);
                    this._CrystalReportViewer1.Load -= new EventHandler(this.CrystalReportViewer1_Load);
                }
                this._CrystalReportViewer1 = value;
                if (this._CrystalReportViewer1 != null)
                {
                    this._CrystalReportViewer1.ReportRefresh += new CrystalDecisions.Windows.Forms.RefreshEventHandler(this.CrystalReportViewer1_ReportRefresh);
                    this._CrystalReportViewer1.Load += new EventHandler(this.CrystalReportViewer1_Load);
                }
            }
        }
    }
}

