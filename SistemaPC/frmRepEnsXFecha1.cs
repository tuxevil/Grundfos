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

    public class frmRepEnsXFecha1 : Form
    {
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("CrystalReportViewer1")]
        private CrystalReportViewer _CrystalReportViewer1;
        public SqlDataAdapter AdapSC01;
        public SqlDataAdapter AdapSY24;
        public SqlDataAdapter AdapTmp;
        private IContainer components;
        public DataSet DS;
        public ReportDocument Informe;

        public frmRepEnsXFecha1()
        {
            base.Closed += new EventHandler(this.frmRepEnsXFecha1_Closed);
            base.Load += new EventHandler(this.frmRepEnsXFecha1_Load);
            base.Click += new EventHandler(this.frmRepEnsXFecha1_Click);
            base.Leave += new EventHandler(this.frmRepEnsXFecha1_Leave);
            this.Informe = new ReportDocument();
            this.DS = new DataSet();
            this.InitializeComponent();
            try
            {
                SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * from " + Variables.gTermi + "TmpRepGesEns as PC1TmpRepGesEns", connection);
                command.CommandTimeout = 500;
                this.AdapTmp = new SqlDataAdapter();
                this.AdapTmp.SelectCommand = command;
                this.DS.Clear();
                this.AdapTmp.Fill(this.DS, "PC1TmpRepGesEns");
                if (StringType.StrCmp(Variables.gTipoList, "1", false) == 0)
                {
                    this.Informe.Load(Application.StartupPath + @"\repensxfecha.rpt");
                    this.Informe.SetDataSource(this.DS);
                    connection.Close();
                }
                else
                {
                    this.Informe.Load(Application.StartupPath + @"\repensxfechaxgrupo.rpt");
                    this.Informe.SetDataSource(this.DS);
                    connection.Close();
                }
                FormulaFieldDefinitions formulaFields = this.Informe.DataDefinition.FormulaFields;
                FormulaFieldDefinition definition = formulaFields["desdefecha"];
                if (StringType.StrCmp(Variables.gDesde, Strings.Space(0), false) != 0)
                {
                    definition.Text = "'" + Strings.Format(DateType.FromString(Variables.gDesde), "dd/MM/yyyy") + "'";
                }
                else
                {
                    definition.Text = "''";
                }
                FormulaFieldDefinition definition2 = formulaFields["hastafecha"];
                if (StringType.StrCmp(Variables.gHasta, Strings.Space(0), false) != 0)
                {
                    definition2.Text = "'" + Strings.Format(DateType.FromString(Variables.gHasta), "dd/MM/yyyy") + "'";
                }
                else
                {
                    definition2.Text = "''";
                }
                this.CrystalReportViewer1.ReportSource = this.Informe;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
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
            SqlDataAdapter adapter4;
            DataRow row;
            DataSet dataSet = new DataSet();
            this.cmbSalir.Enabled = false;
            this.Informe.Close();
            SqlConnection connection2 = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096");
            connection2.Open();
            SqlCommand command = new SqlCommand("delete " + Variables.gTermi + "TmpRepGesEns", connection2);
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
            string connectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=True;packet size=4096";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string cmdText = "SELECT DISTINCT OR010100.OR01001,OR010100.OR01015,OR010100.OR01016,OR030100.OR03002,OR030100.OR03005,OR030100.OR03006,OR030100.OR03007,OR030100.OR03011,OR030100.OR03012,OR190100.OR19011,OR040100.OR04002,OR040100.OR04003,OR040100.OR04004,OR040100.OR04005,OR040100.OR04008 FROM dbo.OR010100 INNER JOIN dbo.OR030100 on OR010100.OR01001=OR030100.OR03001 LEFT OUTER JOIN dbo.OR040100 on OR010100.OR01001=OR040100.OR04001 LEFT OUTER JOIN dbo.OR190100 on OR030100.OR03001=OR190100.OR19001 and OR030100.OR03002=OR190100.OR19002 where OR010100.OR01002=6 and OR030100.OR03003='000' and OR190100.OR19003='000' ";
            if ((StringType.StrCmp(Variables.gDesde, Strings.Space(0), false) != 0) & (StringType.StrCmp(Variables.gHasta, Strings.Space(0), false) != 0))
            {
                cmdText = cmdText + " and OR190100.OR19011>='" + Strings.Format(DateType.FromString(Variables.gDesde), "MM/dd/yyyy") + "' and OR190100.OR19011<='" + Strings.Format(DateType.FromString(Variables.gHasta), "MM/dd/yyyy") + "'";
            }
            if (StringType.StrCmp(Variables.gNroOE, "", false) != 0)
            {
                cmdText = cmdText + " and OR010100.OR01001='" + Variables.gNroOE + "'";
            }
            if (StringType.StrCmp(Variables.gNroOV, "", false) != 0)
            {
                cmdText = cmdText + " and rtrim(OR040100.OR04003)='" + Variables.gNroOV + "'";
            }
            command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                adapter4 = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("Select SC01128,SY24003 from SC010100 inner join SY240100 on SC01128=SY24002 where SC01001='", reader["OR03005"]), "' and SY24001='II'")), connectionString);
                dataSet.Clear();
                adapter4.Fill(dataSet, "SC010100");
                row = dataSet.Tables["SC010100"].Rows[0];
                cmdText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpRepGesEns (NroOE,FechaOE,FechaEnt,FechaEnsReal,NroLinea,Codigo,Descripcion,Grupo,NomGrupo,CantOE,CantArmado,Cliente,NroOV,Obs) values ('", reader["OR01001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR01016"]), "MM/dd/yyyy")), "',"));
                if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(reader["OR19011"])))
                {
                    cmdText = cmdText + "'" + Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR19011"]), "MM/dd/yyyy") + "',";
                }
                else
                {
                    cmdText = cmdText + "Null,";
                }
                cmdText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(cmdText + "'", reader["OR03002"]), "','"), reader["OR03005"]), "','"), Strings.Trim(StringType.FromObject(reader["OR03006"]))), " "), Strings.Trim(StringType.FromObject(reader["OR03007"]))), "','"), row["SC01128"]), "','"), row["SY24003"]), "',"), ObjectType.MulObj(reader["OR03011"], -1)), ","), ObjectType.MulObj(reader["OR03012"], -1)), ","));
                if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR04002"])), "0", false) == 0)
                {
                    cmdText = cmdText + "'',";
                }
                else
                {
                    cmdText = cmdText + "'" + Strings.Trim(StringType.FromObject(reader["OR04002"])) + "',";
                }
                if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR04003"])), "0", false) == 0)
                {
                    cmdText = cmdText + "'','')";
                }
                else
                {
                    cmdText = cmdText + "'" + Strings.Format(Conversion.Val(RuntimeHelpers.GetObjectValue(reader["OR04003"])), "0000000000") + "','')";
                }
                command = new SqlCommand(cmdText, connection2);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception exception5)
                {
                    ProjectData.SetProjectError(exception5);
                    Exception exception2 = exception5;
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
            cmdText = "SELECT DISTINCT OR200100.OR20001,OR200100.OR20015,OR200100.OR20016,OR210100.OR21002,OR210100.OR21005,OR210100.OR21006,OR210100.OR21007,OR210100.OR21011,OR210100.OR21012,OR230100.OR23011,OR220100.OR22002,OR220100.OR22003,OR220100.OR22004,OR220100.OR22005,OR220100.OR22008 FROM dbo.OR200100 INNER JOIN dbo.OR210100 on OR200100.OR20001=OR210100.OR21001 LEFT OUTER JOIN dbo.OR220100 on OR200100.OR20001=OR220100.OR22001 LEFT OUTER JOIN dbo.OR230100 on OR210100.OR21001=OR230100.OR23001 and OR210100.OR21002=OR230100.OR23002 and OR210100.OR21065=OR230100.OR23034 where OR200100.OR20002=6 and OR210100.OR21003='000' and OR230100.OR23003='000' ";
            if ((StringType.StrCmp(Variables.gDesde, Strings.Space(0), false) != 0) & (StringType.StrCmp(Variables.gHasta, Strings.Space(0), false) != 0))
            {
                cmdText = cmdText + " and OR230100.OR23011>='" + Strings.Format(DateType.FromString(Variables.gDesde), "MM/dd/yyyy") + "' and OR230100.OR23011<='" + Strings.Format(DateType.FromString(Variables.gHasta), "MM/dd/yyyy") + "'";
            }
            if (StringType.StrCmp(Variables.gNroOE, "", false) != 0)
            {
                cmdText = cmdText + " and OR200100.OR20001='" + Variables.gNroOE + "'";
            }
            if (StringType.StrCmp(Variables.gNroOV, "", false) != 0)
            {
                cmdText = cmdText + " and rtrim(OR220100.OR22003)='" + Variables.gNroOV + "'";
            }
            command = new SqlCommand(cmdText, connection);
            command.CommandTimeout = 500;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                adapter4 = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("Select SC01128,SY24003 from SC010100 inner join SY240100 on SC01128=SY24002 where SC01001='", reader["OR21005"]), "' and SY24001='II'")), connectionString);
                dataSet.Clear();
                adapter4.Fill(dataSet, "SC010100");
                row = dataSet.Tables["SC010100"].Rows[0];
                cmdText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpRepGesEns (NroOE,FechaOE,FechaEnt,FechaEnsReal,NroLinea,Codigo,Descripcion,Grupo,NomGrupo,CantOE,CantArmado,Cliente,NroOV,Obs) values ('", reader["OR20001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR20015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR20016"]), "MM/dd/yyyy")), "',"));
                if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(reader["OR23011"])))
                {
                    cmdText = cmdText + "'" + Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR23011"]), "MM/dd/yyyy") + "',";
                }
                else
                {
                    cmdText = cmdText + "Null,";
                }
                cmdText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(cmdText + "'", reader["OR21002"]), "','"), reader["OR21005"]), "','"), Strings.Trim(StringType.FromObject(reader["OR21006"]))), " "), Strings.Trim(StringType.FromObject(reader["OR21007"]))), "','"), row["SC01128"]), "','"), row["SY24003"]), "',"), ObjectType.MulObj(reader["OR21011"], -1)), ","), ObjectType.MulObj(reader["OR21012"], -1)), ","));
                if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR22002"])), "0", false) == 0)
                {
                    cmdText = cmdText + "'',";
                }
                else
                {
                    cmdText = cmdText + "'" + Strings.Trim(StringType.FromObject(reader["OR22002"])) + "',";
                }
                if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR22003"])), "0", false) == 0)
                {
                    cmdText = cmdText + "'','')";
                }
                else
                {
                    cmdText = cmdText + "'" + Strings.Format(Conversion.Val(RuntimeHelpers.GetObjectValue(reader["OR22003"])), "0000000000") + "','')";
                }
                command = new SqlCommand(cmdText, connection2);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception exception6)
                {
                    ProjectData.SetProjectError(exception6);
                    Exception exception3 = exception6;
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception3.Message, MsgBoxStyle.OKOnly, null);
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
            try
            {
                SqlConnection connection4 = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
                connection4.Open();
                SqlCommand command2 = new SqlCommand("SELECT * from " + Variables.gTermi + "TmpRepGesEns as PC1TmpRepGesEns", connection4);
                command2.CommandTimeout = 500;
                SqlDataAdapter adapter5 = new SqlDataAdapter();
                adapter5.SelectCommand = command2;
                dataSet.Clear();
                adapter5.Fill(dataSet, "PC1TmpRepGesEns");
                if (StringType.StrCmp(Variables.gTipoList, "1", false) == 0)
                {
                    this.Informe.Load(Application.StartupPath + @"\repensxfecha.rpt");
                    this.Informe.SetDataSource(dataSet);
                    connection4.Close();
                }
                else
                {
                    this.Informe.Load(Application.StartupPath + @"\repensxfechaxgrupo.rpt");
                    this.Informe.SetDataSource(dataSet);
                    connection4.Close();
                }
                FormulaFieldDefinitions formulaFields = this.Informe.DataDefinition.FormulaFields;
                FormulaFieldDefinition definition = formulaFields["desdefecha"];
                if (StringType.StrCmp(Variables.gDesde, Strings.Space(0), false) != 0)
                {
                    definition.Text = "'" + Strings.Format(DateType.FromString(Variables.gDesde), "dd/MM/yyyy") + "'";
                }
                else
                {
                    definition.Text = "''";
                }
                FormulaFieldDefinition definition2 = formulaFields["hastafecha"];
                if (StringType.StrCmp(Variables.gHasta, Strings.Space(0), false) != 0)
                {
                    definition2.Text = "'" + Strings.Format(DateType.FromString(Variables.gHasta), "dd/MM/yyyy") + "'";
                }
                else
                {
                    definition2.Text = "''";
                }
                this.CrystalReportViewer1.ReportSource = this.Informe;
                this.cmbSalir.Enabled = true;
            }
            catch (Exception exception7)
            {
                ProjectData.SetProjectError(exception7);
                Exception exception4 = exception7;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception4.Message, MsgBoxStyle.OKOnly, null);
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

        ~frmRepEnsXFecha1()
        {
        }

        private void frmRepEnsXFecha1_Click(object sender, EventArgs e)
        {
        }

        private void frmRepEnsXFecha1_Closed(object sender, EventArgs e)
        {
            new frmRepEnsXFecha().Show();
        }

        private void frmRepEnsXFecha1_Leave(object sender, EventArgs e)
        {
        }

        private void frmRepEnsXFecha1_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRepEnsXFecha1));
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
            this.CrystalReportViewer1.ShowGroupTreeButton = false;
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
            this.Name = "frmRepEnsXFecha1";
            this.Text = "Reporte Ensamblados por Fecha";
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
                    this._CrystalReportViewer1.Load -= new EventHandler(this.CrystalReportViewer1_Load);
                    this._CrystalReportViewer1.ReportRefresh -= new CrystalDecisions.Windows.Forms.RefreshEventHandler(this.CrystalReportViewer1_ReportRefresh);
                }
                this._CrystalReportViewer1 = value;
                if (this._CrystalReportViewer1 != null)
                {
                    this._CrystalReportViewer1.Load += new EventHandler(this.CrystalReportViewer1_Load);
                    this._CrystalReportViewer1.ReportRefresh += new CrystalDecisions.Windows.Forms.RefreshEventHandler(this.CrystalReportViewer1_ReportRefresh);
                }
            }
        }
    }
}

