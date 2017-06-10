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

    public class frmRepOVExp1 : Form
    {
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("CrystalReportViewer1")]
        private CrystalReportViewer _CrystalReportViewer1;
        public SqlDataAdapter AdapOR01;
        public SqlDataAdapter AdapOR03;
        public SqlDataAdapter AdapPC03;
        public SqlDataAdapter AdapPL23;
        public SqlDataAdapter AdapSC23;
        public SqlDataAdapter AdapSL01;
        public SqlDataAdapter AdapTmp;
        private IContainer components;
        public DataSet DS;
        public DataSet DS1;
        public ReportDocument Informe;

        public frmRepOVExp1()
        {
            base.Closed += new EventHandler(this.frmRepOVExp1_Closed);
            base.Load += new EventHandler(this.frmRepOVExp1_Load);
            base.Click += new EventHandler(this.frmRepOVExp1_Click);
            this.Informe = new ReportDocument();
            this.DS = new DataSet();
            this.DS1 = new DataSet();
            this.InitializeComponent();
            try
            {
                bool flag = false;
                string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
                this.DS.Clear();
                this.DS1.Clear();
                string selectCommandText = "SELECT OR01001,OR01004,OR01014,OR01016,OR01050,OR01072 from OR010100 where OR01002<>6";
                if ((StringType.StrCmp(Variables.gAlmacen1, "", false) != 0) & (StringType.StrCmp(Variables.gAlmacen2, "", false) != 0))
                {
                    selectCommandText = selectCommandText + " and (OR01050='" + Variables.gAlmacen1 + "' or OR01050='" + Variables.gAlmacen2 + "')";
                }
                else if (StringType.StrCmp(Variables.gAlmacen1, "", false) != 0)
                {
                    selectCommandText = selectCommandText + " and OR01050='" + Variables.gAlmacen1 + "'";
                }
                else if (StringType.StrCmp(Variables.gAlmacen2, "", false) != 0)
                {
                    selectCommandText = selectCommandText + " and OR01050='" + Variables.gAlmacen2 + "'";
                }
                if (StringType.StrCmp(Variables.gCodCli, "", false) != 0)
                {
                    selectCommandText = selectCommandText + " and OR01004='" + Variables.gCodCli + "'";
                }
                else
                {
                    selectCommandText = selectCommandText + " and ((OR01004>='600000' and OR01004<='699000') or OR01004='00WARREXPO')";
                }
                this.AdapOR01 = new SqlDataAdapter(selectCommandText, selectConnectionString);
                selectCommandText = "SELECT OR03001,OR03005,OR03006,OR03007,OR03011,OR03012,OR03019,OR03067,OR03068 FROM dbo.OR030100 where OR03011-OR03012<>0";
                this.AdapOR03 = new SqlDataAdapter(selectCommandText, selectConnectionString);
                if (Variables.gOVaListar == 1)
                {
                    selectCommandText = "SELECT SL01001,SL01002 from SL010100";
                }
                else if (Variables.gOVaListar == 2)
                {
                    selectCommandText = "SELECT SL01001,SL01002 from SL010100 where SL01060='1'";
                }
                else if (Variables.gOVaListar == 3)
                {
                    selectCommandText = "SELECT SL01001,SL01002 from SL010100 where SL01075='1'";
                }
                this.AdapSL01 = new SqlDataAdapter(selectCommandText, selectConnectionString);
                selectCommandText = "SELECT SC23001,SC23002 FROM dbo.SC230100";
                this.AdapSC23 = new SqlDataAdapter(selectCommandText, selectConnectionString);
                selectCommandText = "SELECT PC03001,PC03002,PC03029 FROM dbo.PC030100";
                this.AdapPC03 = new SqlDataAdapter(selectCommandText, selectConnectionString);
                this.AdapOR01.Fill(this.DS, "OR010100");
                this.AdapOR03.Fill(this.DS, "OR030100");
                this.AdapSL01.Fill(this.DS, "SL010100");
                this.AdapSC23.Fill(this.DS, "SC230100");
                this.AdapPC03.Fill(this.DS, "PC030100");
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
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
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
                if (Variables.gOrdenList == 1)
                {
                    this.Informe.Load(Application.StartupPath + @"\repovexp1.rpt");
                }
                else if (Variables.gOrdenList == 2)
                {
                    this.Informe.Load(Application.StartupPath + @"\repovexp2.rpt");
                }
                this.Informe.SetDataSource(this.DS);
                FormulaFieldDefinitions definitions = this.Informe.get_DataDefinition().get_FormulaFields();
                definitions.get_Item("tipo").set_Text("'" + Variables.gTipoList + "'");
                if (Variables.gOrdenList == 1)
                {
                    definitions.get_Item("orden").set_Text("'Ordenado por Orden de Compra Cliente'");
                }
                else if (Variables.gOrdenList == 2)
                {
                    definitions.get_Item("orden").set_Text("'Ordenado por Fecha Confirmada'");
                }
                this.CrystalReportViewer1.set_ReportSource(this.Informe);
            }
            catch (Exception exception3)
            {
                ProjectData.SetProjectError(exception3);
                Exception exception2 = exception3;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, 0, null);
                ProjectData.ClearProjectError();
            }
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
            DataSet dataSet = new DataSet();
            this.cmbSalir.Enabled = false;
            this.Informe.Close();
            try
            {
                bool flag = false;
                string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
                dataSet.Clear();
                this.DS1.Clear();
                string selectCommandText = "SELECT OR01001,OR01004,OR01014,OR01016,OR01050,OR01072 from OR010100 where OR01002<>6";
                if ((StringType.StrCmp(Variables.gAlmacen1, "", false) != 0) & (StringType.StrCmp(Variables.gAlmacen2, "", false) != 0))
                {
                    selectCommandText = selectCommandText + " and (OR01050='" + Variables.gAlmacen1 + "' or OR01050='" + Variables.gAlmacen2 + "')";
                }
                else if (StringType.StrCmp(Variables.gAlmacen1, "", false) != 0)
                {
                    selectCommandText = selectCommandText + " and OR01050='" + Variables.gAlmacen1 + "'";
                }
                else if (StringType.StrCmp(Variables.gAlmacen2, "", false) != 0)
                {
                    selectCommandText = selectCommandText + " and OR01050='" + Variables.gAlmacen2 + "'";
                }
                if (StringType.StrCmp(Variables.gCodCli, "", false) != 0)
                {
                    selectCommandText = selectCommandText + " and OR01004='" + Variables.gCodCli + "'";
                }
                else
                {
                    selectCommandText = selectCommandText + " and ((OR01004>='600000' and OR01004<='699000') or OR01004='00WARREXPO')";
                }
                this.AdapOR01 = new SqlDataAdapter(selectCommandText, selectConnectionString);
                selectCommandText = "SELECT OR03001,OR03005,OR03006,OR03007,OR03011,OR03012,OR03019,OR03067,OR03068 FROM dbo.OR030100 where OR03011-OR03012<>0";
                this.AdapOR03 = new SqlDataAdapter(selectCommandText, selectConnectionString);
                if (Variables.gOVaListar == 1)
                {
                    selectCommandText = "SELECT SL01001,SL01002 from SL010100";
                }
                else if (Variables.gOVaListar == 2)
                {
                    selectCommandText = "SELECT SL01001,SL01002 from SL010100 where SL01060='1'";
                }
                else if (Variables.gOVaListar == 3)
                {
                    selectCommandText = "SELECT SL01001,SL01002 from SL010100 where SL01075='1'";
                }
                this.AdapSL01 = new SqlDataAdapter(selectCommandText, selectConnectionString);
                selectCommandText = "SELECT SC23001,SC23002 FROM dbo.SC230100";
                this.AdapSC23 = new SqlDataAdapter(selectCommandText, selectConnectionString);
                selectCommandText = "SELECT PC03001,PC03002,PC03029 FROM dbo.PC030100";
                this.AdapPC03 = new SqlDataAdapter(selectCommandText, selectConnectionString);
                this.AdapOR01.Fill(dataSet, "OR010100");
                this.AdapOR03.Fill(dataSet, "OR030100");
                this.AdapSL01.Fill(dataSet, "SL010100");
                this.AdapSC23.Fill(dataSet, "SC230100");
                this.AdapPC03.Fill(dataSet, "PC030100");
                selectCommandText = "SELECT PL23003,PL23004 FROM dbo.PL230100 where PL23001='2' and PL23002='00'";
                this.AdapPL23 = new SqlDataAdapter(selectCommandText, selectConnectionString);
                this.AdapPL23.Fill(this.DS1, "PL230100");
                string connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                flag = true;
                SqlCommand command = new SqlCommand("delete " + Variables.gTermi + "TmpFormaDesp", connection);
                int num2 = command.ExecuteNonQuery();
                long num3 = this.DS1.Tables["PL230100"].Rows.Count - 1;
                for (long i = 0L; i <= num3; i += 1L)
                {
                    DataRow row = this.DS1.Tables["PL230100"].Rows[(int) i];
                    command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpFormaDesp (Codigo,Descripcion) values (", row["PL23003"]), ",'"), row["PL23004"]), "')")), connection);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        Exception exception = exception1;
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
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
                new SqlDataAdapter("select * from " + Variables.gTermi + "TmpFormaDesp as PC1TmpFormaDesp", connectionString).Fill(dataSet, "PC1TmpFormaDesp");
                if (Variables.gOrdenList == 1)
                {
                    this.Informe.Load(Application.StartupPath + @"\repovexp1.rpt");
                }
                else if (Variables.gOrdenList == 2)
                {
                    this.Informe.Load(Application.StartupPath + @"\repovexp2.rpt");
                }
                this.Informe.SetDataSource(dataSet);
                FormulaFieldDefinitions definitions = this.Informe.get_DataDefinition().get_FormulaFields();
                definitions.get_Item("tipo").set_Text("'" + Variables.gTipoList + "'");
                if (Variables.gOrdenList == 1)
                {
                    definitions.get_Item("orden").set_Text("'Ordenado por Orden de Compra Cliente'");
                }
                else if (Variables.gOrdenList == 2)
                {
                    definitions.get_Item("orden").set_Text("'Ordenado por Fecha Confirmada'");
                }
                this.CrystalReportViewer1.set_ReportSource(this.Informe);
                this.CrystalReportViewer1.Refresh();
                this.cmbSalir.Enabled = true;
            }
            catch (Exception exception3)
            {
                ProjectData.SetProjectError(exception3);
                Exception exception2 = exception3;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, 0, null);
                ProjectData.ClearProjectError();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        ~frmRepOVExp1()
        {
        }

        private void frmRepOVExp1_Click(object sender, EventArgs e)
        {
        }

        private void frmRepOVExp1_Closed(object sender, EventArgs e)
        {
            new frmRepOVExp().Show();
        }

        private void frmRepOVExp1_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRepOVExp1));
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
            this.CrystalReportViewer1.set_ActiveViewIndex(-1);
            this.CrystalReportViewer1.set_DisplayBackgroundEdge(false);
            this.CrystalReportViewer1.set_DisplayGroupTree(false);
            point = new Point(8, 8);
            this.CrystalReportViewer1.Location = point;
            this.CrystalReportViewer1.Name = "CrystalReportViewer1";
            this.CrystalReportViewer1.set_ReportSource(null);
            size = new Size(0x3f0, 640);
            this.CrystalReportViewer1.Size = size;
            this.CrystalReportViewer1.TabIndex = 0x36;
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x404, 0x2f1);
            this.ClientSize = size;
            this.Controls.Add(this.CrystalReportViewer1);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmRepOVExp1";
            this.Text = "Reporte O.Venta Exportaci\x00f3n";
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
                    this._CrystalReportViewer1.remove_ReportRefresh(new RefreshEventHandler(this, (IntPtr) this.CrystalReportViewer1_ReportRefresh));
                    this._CrystalReportViewer1.Load -= new EventHandler(this.CrystalReportViewer1_Load);
                }
                this._CrystalReportViewer1 = value;
                if (this._CrystalReportViewer1 != null)
                {
                    this._CrystalReportViewer1.add_ReportRefresh(new RefreshEventHandler(this, (IntPtr) this.CrystalReportViewer1_ReportRefresh));
                    this._CrystalReportViewer1.Load += new EventHandler(this.CrystalReportViewer1_Load);
                }
            }
        }
    }
}

