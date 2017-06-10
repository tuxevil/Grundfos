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

    public class frmRepRegPedExp1 : Form
    {
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("CrystalReportViewer1")]
        private CrystalReportViewer _CrystalReportViewer1;
        public SqlDataAdapter AdapOR01;
        public SqlDataAdapter AdapOR03;
        public SqlDataAdapter AdapSC03;
        public SqlDataAdapter AdapSL01;
        private IContainer components;
        public DataSet DS;
        public ReportDocument Informe;

        public frmRepRegPedExp1()
        {
            base.Closed += new EventHandler(this.frmRepRegPedExp1_Closed);
            base.Load += new EventHandler(this.frmRepRegPedExp1_Load);
            base.Click += new EventHandler(this.frmRepRegPedExp1_Click);
            this.Informe = new ReportDocument();
            this.DS = new DataSet();
            this.InitializeComponent();
            try
            {
                SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * from " + Variables.gTermi + "TmpRegPedExp as PC1TmpRegPedExp", connection);
                command.CommandTimeout = 500;
                this.AdapOR01 = new SqlDataAdapter();
                this.AdapOR01.SelectCommand = command;
                this.DS.Clear();
                this.AdapOR01.Fill(this.DS, "PC1TmpRegPedExp");
                this.Informe.Load(Application.StartupPath + @"\repregpedexp.rpt");
                this.Informe.SetDataSource(this.DS);
                connection.Close();
                FormulaFieldDefinitions definitions = this.Informe.get_DataDefinition().get_FormulaFields();
                FormulaFieldDefinition definition = definitions.get_Item("desdefechaent");
                if (StringType.StrCmp(Variables.gDesdeFechaEnt, Strings.Space(0), false) != 0)
                {
                    definition.set_Text("'" + Strings.Format(DateType.FromString(Variables.gDesdeFechaEnt), "dd/MM/yyyy") + "'");
                }
                else
                {
                    definition.set_Text("''");
                }
                FormulaFieldDefinition definition2 = definitions.get_Item("hastafechaent");
                if (StringType.StrCmp(Variables.gHastaFechaEnt, Strings.Space(0), false) != 0)
                {
                    definition2.set_Text("'" + Strings.Format(DateType.FromString(Variables.gHastaFechaEnt), "dd/MM/yyyy") + "'");
                }
                else
                {
                    definition2.set_Text("''");
                }
                this.CrystalReportViewer1.set_ReportSource(this.Informe);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
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
            DataRow row;
            long num;
            SqlDataReader reader;
            string str4;
            DataSet dataSet = new DataSet();
            this.cmbSalir.Enabled = false;
            this.Informe.Close();
            SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
            SqlConnection connection2 = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
            connection2.Open();
            SqlCommand command4 = new SqlCommand("delete " + Variables.gTermi + "TmpRegPedExp", connection2);
            int num2 = command4.ExecuteNonQuery();
            string str = "SELECT OR01001,OR01004,OR01016,OR01024,OR01072,OR03019,sum((OR03011-OR03012)*OR03008) as ImpAFac,OR04005,SL01002,PL23004,SY14002 FROM dbo.OR010100 inner join OR030100 on OR010100.OR01001=OR030100.OR03001 inner join OR040100 on OR010100.OR01001=OR040100.OR04001 inner join SL010100 on OR010100.OR01004=SL010100.SL01001 inner join PL230100 on OR010100.OR01014=convert(int,PL230100.PL23003)  inner join SY140100 on OR010100.OR01028=SY140100.SY14001 where OR010100.OR01002<>6 and OR03011-OR03012<>0 and ((OR01004>='600000' and OR01004<='699000') or OR01004='00WARREXPO')";
            if ((StringType.StrCmp(Variables.gDesdeFechaEnt, "", false) != 0) & (StringType.StrCmp(Variables.gHastaFechaEnt, "", false) != 0))
            {
                str = str + " and OR03019>='" + Strings.Format(DateType.FromString(Variables.gDesdeFechaEnt), "MM/dd/yyyy") + "' and OR03019<='" + Strings.Format(DateType.FromString(Variables.gHastaFechaEnt), "MM/dd/yyyy") + "'";
            }
            SqlCommand command2 = new SqlCommand(str + " and PL23001='2' and PL23002='00'" + " group by OR01001,OR01004,OR01016,OR01024,OR01072,OR03019,OR04005,SL01002,PL23004,SY14002", connection);
            command2.CommandTimeout = 500;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command2;
            connection.Open();
            adapter.Fill(dataSet, "OR010100");
            long num4 = dataSet.Tables["OR010100"].Rows.Count - 1;
            for (num = 0L; num <= num4; num += 1L)
            {
                row = dataSet.Tables["OR010100"].Rows[(int) num];
                SqlCommand command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT PC01001,PL01002 FROM dbo.PC010100 inner join PL010100 on PC010100.PC01003=PL010100.PL01001 where PC01017='ORDEN VENT", row["OR01001"]), "'")), connection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpRegPedExp (Tipo,Cliente,NomCli,OCCliente,NroOV,NroOCProv,NomProv,FEntPed,FEntConf,PaisDest,Moneda,MontoOV,ImpAFac,FormaDesp) values (1,'", row["OR01004"]), "','"), row["SL01002"]), "','"), row["OR01072"]), "','"), row["OR01001"]), "','"), reader["PC01001"]), "','"), reader["PL01002"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01016"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR03019"]), "MM/dd/yyyy")), "','"), row["OR04005"]), "','"), row["SY14002"]), "',"), row["OR01024"]), ","), row["ImpAFac"]), ",'"), row["PL23004"]), "')"));
                    reader.Close();
                    command4 = new SqlCommand(str4, connection2);
                }
                else
                {
                    reader.Close();
                    command4 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpRegPedExp (Tipo,Cliente,NomCli,OCCliente,NroOV,NroOCProv,NomProv,FEntPed,FEntConf,PaisDest,Moneda,MontoOV,ImpAFac,FormaDesp) values (1,'", row["OR01004"]), "','"), row["SL01002"]), "','"), row["OR01072"]), "','"), row["OR01001"]), "','','','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01016"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR03019"]), "MM/dd/yyyy")), "','"), row["OR04005"]), "','"), row["SY14002"]), "',"), row["OR01024"]), ","), row["ImpAFac"]), ",'"), row["PL23004"]), "')")), connection2);
                }
                try
                {
                    num2 = command4.ExecuteNonQuery();
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                    connection.Close();
                    connection2.Close();
                    this.Close();
                    ProjectData.ClearProjectError();
                    return;
                    ProjectData.ClearProjectError();
                }
            }
            str = "SELECT OR20001,OR20004,OR20016,OR20024,OR20072,OR21019,sum((OR21011-OR21012)*OR21008) as ImpAFac,OR22005,SL01002,PL23004,SY14002 FROM dbo.OR200100 inner join OR210100 on OR200100.OR20001=OR210100.OR21001 inner join OR220100 on OR200100.OR20001=OR220100.OR22001 inner join SL010100 on OR200100.OR20004=SL010100.SL01001 inner join PL230100 on OR200100.OR20014=convert(int,PL230100.PL23003)  inner join SY140100 on OR200100.OR20028=SY140100.SY14001 where OR200100.OR20002<>6 and OR21011-OR21012<>0 and ((OR20004>='600000' and OR20004<='699000') or OR20004='00WARREXPO')";
            if ((StringType.StrCmp(Variables.gDesdeFechaEnt, "", false) != 0) & (StringType.StrCmp(Variables.gHastaFechaEnt, "", false) != 0))
            {
                str = str + " and OR21019>='" + Strings.Format(DateType.FromString(Variables.gDesdeFechaEnt), "MM/dd/yyyy") + "' and OR21019<='" + Strings.Format(DateType.FromString(Variables.gHastaFechaEnt), "MM/dd/yyyy") + "'";
            }
            command2 = new SqlCommand(str + " and PL23001='2' and PL23002='00'" + " group by OR20001,OR20004,OR20016,OR20024,OR20072,OR21019,OR22005,SL01002,PL23004,SY14002", connection);
            command2.CommandTimeout = 500;
            SqlDataAdapter adapter2 = new SqlDataAdapter();
            adapter2.SelectCommand = command2;
            adapter2.Fill(dataSet, "OR200100");
            long num3 = dataSet.Tables["OR200100"].Rows.Count - 1;
            for (num = 0L; num <= num3; num += 1L)
            {
                row = dataSet.Tables["OR200100"].Rows[(int) num];
                reader = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT PC01001,PL01002 FROM dbo.PC010100 inner join PL010100 on PC010100.PC01003=PL010100.PL01001 where PC01017='ORDEN VENT", row["OR20001"]), "'")), connection).ExecuteReader();
                if (reader.Read())
                {
                    str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpRegPedExp (Tipo,Cliente,NomCli,OCCliente,NroOV,NroOCProv,NomProv,FEntPed,FEntConf,PaisDest,Moneda,MontoOV,ImpAFac,FormaDesp) values (2,'", row["OR20004"]), "','"), row["SL01002"]), "','"), row["OR20072"]), "','"), row["OR20001"]), "','"), reader["PC01001"]), "','"), reader["PL01002"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR20016"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR21019"]), "MM/dd/yyyy")), "','"), row["OR22005"]), "','"), row["SY14002"]), "',"), row["OR20024"]), ","), row["ImpAFac"]), ",'"), row["PL23004"]), "')"));
                    reader.Close();
                    command4 = new SqlCommand(str4, connection2);
                }
                else
                {
                    reader.Close();
                    command4 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpRegPedExp (Tipo,Cliente,NomCli,OCCliente,NroOV,NroOCProv,NomProv,FEntPed,FEntConf,PaisDest,Moneda,MontoOV,ImpAFac,FormaDesp) values (2,'", row["OR20004"]), "','"), row["SL01002"]), "','"), row["OR20072"]), "','"), row["OR20001"]), "','','','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR20016"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR21019"]), "MM/dd/yyyy")), "','"), row["OR22005"]), "','"), row["SY14002"]), "',"), row["OR20024"]), ","), row["ImpAFac"]), ",'"), row["PL23004"]), "')")), connection2);
                }
                try
                {
                    num2 = command4.ExecuteNonQuery();
                }
                catch (Exception exception4)
                {
                    ProjectData.SetProjectError(exception4);
                    Exception exception2 = exception4;
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, 0, null);
                    connection.Close();
                    connection2.Close();
                    this.Close();
                    ProjectData.ClearProjectError();
                    return;
                    ProjectData.ClearProjectError();
                }
            }
            connection.Close();
            connection2.Close();
            try
            {
                connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
                connection.Open();
                command2 = new SqlCommand("SELECT * from " + Variables.gTermi + "TmpRegPedExp as PC1TmpRegPedExp", connection);
                command2.CommandTimeout = 500;
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = command2;
                dataSet.Clear();
                adapter.Fill(dataSet, "PC1TmpRegPedExp");
                this.Informe.Load(Application.StartupPath + @"\repregpedexp.rpt");
                this.Informe.SetDataSource(dataSet);
                connection.Close();
                FormulaFieldDefinitions definitions = this.Informe.get_DataDefinition().get_FormulaFields();
                FormulaFieldDefinition definition = definitions.get_Item("desdefechaent");
                if (StringType.StrCmp(Variables.gDesdeFechaEnt, Strings.Space(0), false) != 0)
                {
                    definition.set_Text("'" + Strings.Format(DateType.FromString(Variables.gDesdeFechaEnt), "dd/MM/yyyy") + "'");
                }
                else
                {
                    definition.set_Text("''");
                }
                FormulaFieldDefinition definition2 = definitions.get_Item("hastafechaent");
                if (StringType.StrCmp(Variables.gHastaFechaEnt, Strings.Space(0), false) != 0)
                {
                    definition2.set_Text("'" + Strings.Format(DateType.FromString(Variables.gHastaFechaEnt), "dd/MM/yyyy") + "'");
                }
                else
                {
                    definition2.set_Text("''");
                }
                this.CrystalReportViewer1.set_ReportSource(this.Informe);
                this.CrystalReportViewer1.Refresh();
                this.cmbSalir.Enabled = true;
            }
            catch (Exception exception5)
            {
                ProjectData.SetProjectError(exception5);
                Exception exception3 = exception5;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception3.Message, 0, null);
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

        ~frmRepRegPedExp1()
        {
        }

        private void frmRepRegPedExp1_Click(object sender, EventArgs e)
        {
        }

        private void frmRepRegPedExp1_Closed(object sender, EventArgs e)
        {
            new frmRepRegPedExp().Show();
        }

        private void frmRepRegPedExp1_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRepRegPedExp1));
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
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.CrystalReportViewer1);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmRepRegPedExp1";
            this.Text = "Reporte Registro Pedidos Exportaci\x00f3n";
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
                    this._CrystalReportViewer1.remove_ReportRefresh(new RefreshEventHandler(this, (IntPtr) this.CrystalReportViewer1_ReportRefresh));
                }
                this._CrystalReportViewer1 = value;
                if (this._CrystalReportViewer1 != null)
                {
                    this._CrystalReportViewer1.Load += new EventHandler(this.CrystalReportViewer1_Load);
                    this._CrystalReportViewer1.add_ReportRefresh(new RefreshEventHandler(this, (IntPtr) this.CrystalReportViewer1_ReportRefresh));
                }
            }
        }
    }
}

