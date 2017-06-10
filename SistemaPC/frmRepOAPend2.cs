namespace SistemaPC
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Windows.Forms;
    using DateCalc;
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

    public class frmRepOAPend2 : Form
    {
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("cmbVolver")]
        private Button _cmbVolver;
        [AccessedThroughProperty("CrystalReportViewer1")]
        private CrystalReportViewer _CrystalReportViewer1;
        public SqlDataAdapter AdapObs;
        public SqlDataAdapter AdapOR01;
        public SqlDataAdapter AdapOR03;
        public SqlDataAdapter AdapPC03;
        public SqlDataAdapter AdapSC03;
        public SqlDataAdapter AdapSL01;
        public SqlDataAdapter AdapTmp;
        public SqlDataAdapter AdapTmp1;
        private IContainer components;
        public DataSet DS;
        public ReportDocument Informe;
        public bool mVolver;

        public frmRepOAPend2()
        {
            base.Load += new EventHandler(this.frmRepOAPend2_Load);
            base.Closed += new EventHandler(this.frmRepOAPend2_Closed);
            this.Informe = new ReportDocument();
            this.DS = new DataSet();
            this.InitializeComponent();
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            string selectCommandText = "SELECT * from " + Variables.gTermi + "TmpCalendario as PC1TmpCalendario where FechaEnt>='" + Strings.Format(DateTime.Now, "MM/dd/yyyy") + "'";
            this.AdapTmp = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.AdapTmp.Fill(this.DS, "PC1TmpCalendario");
            selectCommandText = "SELECT NroOE,NroLinea,Observaciones,Fecha FROM dbo.GesEnsObs";
            this.AdapObs = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.AdapObs.Fill(this.DS, "GesEnsObs");
            selectCommandText = "SELECT * from " + Variables.gTermi + "TmpCalendarioStkComp as PC1TmpCalendarioStkComp";
            this.AdapTmp1 = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.AdapTmp1.Fill(this.DS, "PC1TmpCalendarioStkComp");
            this.Informe.Load(Application.StartupPath + @"\repoapendcal.rpt");
            this.Informe.SetDataSource(this.DS);
            FormulaFieldDefinitions formulaFields = this.Informe.DataDefinition.FormulaFields;
            FormulaFieldDefinition definition = formulaFields["orden"];
            definition.Text = "'ordenado por Fecha Entrega'";
            FormulaFieldDefinition definition2 = formulaFields["Intr01"];
            definition2.Text = "'" + Variables.gNomIntr01 + "'";
            FormulaFieldDefinition definition3 = formulaFields["Intr02"];
            definition3.Text = "'" + Variables.gNomIntr02 + "'";
            FormulaFieldDefinition definition4 = formulaFields["Intr03"];
            definition4.Text = "'" + Variables.gNomIntr03 + "'";
            FormulaFieldDefinition definition5 = formulaFields["Intr04"];
            definition5.Text = "'" + Variables.gNomIntr04 + "'";
            this.CrystalReportViewer1.ShowGroupTreeButton = true;
            this.CrystalReportViewer1.ReportSource = this.Informe;
            this.CrystalReportViewer1.Zoom(1);
        }

        private void ActTmp()
        {
            DataRow row;
            long num;
            SqlDataReader reader;
            DateTime time2;
            DateTime time3;
            string str4;
            DataSet dataSet = new DataSet();
            DataSet set2 = new DataSet();
            this.cmbSalir.Enabled = false;
            this.cmbVolver.Enabled = false;
            SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
            connection.Open();
            SqlConnection connection2 = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
            connection2.Open();
            int num4 = new SqlCommand("delete " + Variables.gTermi + "TmpCalendario", connection2).ExecuteNonQuery();
            SqlCommand command4 = new SqlCommand("delete " + Variables.gTermi + "TmpCalendarioStkComp", connection2);
            num4 = command4.ExecuteNonQuery();
            string str = "SELECT OR01001,OR01004,OR01016,OR01050,OR03002,OR03005,OR03006,OR03007,OR03011,OR03012,OR03051,OR04002,OR04003,OR04004,OR04005,OR04008 FROM dbo.OR010100 inner join OR030100 on OR010100.OR01001=OR030100.OR03001 inner join OR040100 on OR010100.OR01001=OR040100.OR04001 where OR010100.OR01002=6 and OR010100.OR01091=0 and OR03011-OR03012<>0 and OR03034=1 and (";
            if (Variables.gIntr01)
            {
                str = str + "OR01004='INTR01' ";
                if (Variables.gIntr02)
                {
                    str = str + "or OR01004='INTR02' ";
                }
                if (Variables.gIntr03)
                {
                    str = str + "or OR01004='INTR03' ";
                }
                if (Variables.gIntr04)
                {
                    str = str + "or OR01004='INTR04' ";
                }
            }
            else if (Variables.gIntr02)
            {
                str = str + "OR01004='INTR02' ";
                if (Variables.gIntr03)
                {
                    str = str + "or OR01004='INTR03' ";
                }
                if (Variables.gIntr04)
                {
                    str = str + "or OR01004='INTR04' ";
                }
            }
            else if (Variables.gIntr03)
            {
                str = str + "OR01004='INTR03' ";
                if (Variables.gIntr04)
                {
                    str = str + "or OR01004='INTR04' ";
                }
            }
            else if (Variables.gIntr04)
            {
                str = str + "OR01004='INTR04' ";
            }
            SqlCommand command3 = new SqlCommand(str + ") order by OR010100.OR01016", connection);
            command3.CommandTimeout = 900;
            dataSet.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command3;
            adapter.Fill(dataSet, "OR010100");
            long num9 = dataSet.Tables["OR010100"].Rows.Count - 1;
            for (num = 0L; num <= num9; num += 1L)
            {
                row = dataSet.Tables["OR010100"].Rows[(int) num];
                str4 = "insert into " + Variables.gTermi + "TmpCalendario (FechaEnt,Cliente,ListaRec,NroOA,NroLinea,Codigo,Descripcion,Almacen,Cantidad,AsignadoA,Observaciones,ReqEsp,Horas,SinStock,Obs) values (";
                CalcDates dates = new CalcDatesClass();
                short daysToDue = 0;
                DataRow row3 = row;
                string str9 = "OR01016";
                DateTime currentDate = DateType.FromObject(row3[str9]);
                string dayCountType = "H";
                string company = "01";
                dates.WeekDate(ref daysToDue, ref currentDate, ref dayCountType, ref company);
                row3[str9] = currentDate;
                str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj((str4 + "'" + Strings.Format(dates.MidDate, "MM/dd/yyyy")) + "','", row["OR01004"]), "','"), row["OR03051"]), "','"), row["OR01001"]), "','"), row["OR03002"]), "','"), row["OR03005"]), "','"), row["OR03006"]), " "), row["OR03007"]), "','"), row["OR01050"]), "',"), ObjectType.SubObj(row["OR03011"], row["OR03012"])), ","));
                if (StringType.StrCmp(Strings.Trim(StringType.FromObject(row["OR04002"])), "0", false) == 0)
                {
                    str4 = str4 + "'',";
                }
                else
                {
                    str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(str4 + "'", row["OR04002"]), "',"));
                }
                if (StringType.StrCmp(Strings.Trim(StringType.FromObject(row["OR04003"])), "0", false) == 0)
                {
                    if (StringType.StrCmp(Strings.Trim(StringType.FromObject(row["OR04004"])), "0", false) == 0)
                    {
                        str4 = str4 + "'',";
                    }
                    else
                    {
                        str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(str4 + "'", row["OR04004"]), "',"));
                    }
                }
                else if (StringType.StrCmp(Strings.Trim(StringType.FromObject(row["OR04004"])), "0", false) == 0)
                {
                    str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(str4 + "'", row["OR04003"]), "',"));
                }
                else
                {
                    str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(str4 + "'", row["OR04003"]), " "), row["OR04004"]), "',"));
                }
                if (StringType.StrCmp(Strings.Trim(StringType.FromObject(row["OR04005"])), "0", false) == 0)
                {
                    str4 = str4 + "'',";
                }
                else
                {
                    str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(str4 + "'", row["OR04005"]), "',"));
                }
                command4 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(str4 + "'", row["OR04008"]), "',0,0)")), connection2);
                try
                {
                    num4 = command4.ExecuteNonQuery();
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                    connection.Close();
                    connection2.Close();
                    this.cmbSalir.Enabled = true;
                    this.cmbVolver.Enabled = true;
                    ProjectData.ClearProjectError();
                    return;
                    ProjectData.ClearProjectError();
                }
            }
            command3 = new SqlCommand("SELECT distinct NroOA from " + Variables.gTermi + "TmpCalendario", connection2);
            command3.CommandTimeout = 900;
            dataSet.Clear();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = command3;
            adapter.Fill(dataSet, Variables.gTermi + "TmpCalendario");
            long num7 = dataSet.Tables[Variables.gTermi + "TmpCalendario"].Rows.Count - 1;
            for (num = 0L; num <= num7; num += 1L)
            {
                row = dataSet.Tables[Variables.gTermi + "TmpCalendario"].Rows[(int) num];
                SqlCommand command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT * from GesEnsObs where NroOE='", row["NroOA"]), "'")), connection2);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    command4 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("update " + Variables.gTermi + "TmpCalendario set Obs=1 where NroOA='", row["NroOA"]), "'")), connection2);
                    try
                    {
                        num4 = command4.ExecuteNonQuery();
                    }
                    catch (Exception exception8)
                    {
                        ProjectData.SetProjectError(exception8);
                        Exception exception2 = exception8;
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, MsgBoxStyle.OKOnly, null);
                        connection.Close();
                        connection2.Close();
                        this.cmbSalir.Enabled = true;
                        ProjectData.ClearProjectError();
                        return;
                        ProjectData.ClearProjectError();
                    }
                }
                else
                {
                    reader.Close();
                }
            }
            command3 = new SqlCommand("SELECT * from " + Variables.gTermi + "TmpCalendario order by FechaEnt", connection2);
            command3.CommandTimeout = 900;
            dataSet.Clear();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = command3;
            adapter.Fill(dataSet, Variables.gTermi + "TmpCalendario");
            if (dataSet.Tables[Variables.gTermi + "TmpCalendario"].Rows.Count != 0)
            {
                row = dataSet.Tables[Variables.gTermi + "TmpCalendario"].Rows[0];
                if (DateAndTime.Weekday(DateType.FromObject(row["FechaEnt"]), FirstDayOfWeek.Sunday) > 1)
                {
                    time3 = DateAndTime.DateAdd(DateInterval.Day, (double) ((DateAndTime.Weekday(DateType.FromObject(row["FechaEnt"]), FirstDayOfWeek.Sunday) - 1) * -1), DateType.FromObject(row["FechaEnt"]));
                }
                else
                {
                    time3 = DateType.FromObject(row["FechaEnt"]);
                }
            }
            command3 = new SqlCommand("SELECT * from " + Variables.gTermi + "TmpCalendario order by FechaEnt desc", connection2);
            command3.CommandTimeout = 900;
            dataSet.Clear();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = command3;
            adapter.Fill(dataSet, Variables.gTermi + "TmpCalendario");
            if (dataSet.Tables[Variables.gTermi + "TmpCalendario"].Rows.Count != 0)
            {
                row = dataSet.Tables[Variables.gTermi + "TmpCalendario"].Rows[0];
                if (DateAndTime.Weekday(DateType.FromObject(row["FechaEnt"]), FirstDayOfWeek.Sunday) < 7)
                {
                    time2 = DateAndTime.DateAdd(DateInterval.Day, (double) (7 - DateAndTime.Weekday(DateType.FromObject(row["FechaEnt"]), FirstDayOfWeek.Sunday)), DateType.FromObject(row["FechaEnt"]));
                }
                else
                {
                    time2 = DateType.FromObject(row["FechaEnt"]);
                }
            }
            while (DateTime.Compare(time3, time2) <= 0)
            {
                SqlCommand command2 = new SqlCommand("SELECT * FROM " + Variables.gTermi + "TmpCalendario where FechaEnt='" + Strings.Format(time3, "MM/dd/yyyy") + "'", connection2);
                reader = command2.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                }
                else
                {
                    reader.Close();
                    reader = new SqlCommand("SELECT * FROM dbo.SYHO0100 where SYHO001='" + Strings.Format(time3, "MM/dd/yyyy") + "'", connection).ExecuteReader();
                    if (reader.Read())
                    {
                        command4 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj((("insert into " + Variables.gTermi + "TmpCalendario (FechaEnt,Observaciones) values (") + "'" + Strings.Format(time3, "MM/dd/yyyy") + "',") + "'", reader["SYHO002"]), "')")), connection2);
                        reader.Close();
                    }
                    else
                    {
                        command4 = new SqlCommand(("insert into " + Variables.gTermi + "TmpCalendario (FechaEnt) values (") + "'" + Strings.Format(time3, "MM/dd/yyyy") + "')", connection2);
                        reader.Close();
                    }
                    try
                    {
                        num4 = command4.ExecuteNonQuery();
                    }
                    catch (Exception exception9)
                    {
                        ProjectData.SetProjectError(exception9);
                        Exception exception3 = exception9;
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception3.Message, MsgBoxStyle.OKOnly, null);
                        connection.Close();
                        connection2.Close();
                        this.cmbSalir.Enabled = true;
                        this.cmbVolver.Enabled = true;
                        ProjectData.ClearProjectError();
                        return;
                        ProjectData.ClearProjectError();
                    }
                }
                time3 = DateAndTime.DateAdd(DateInterval.Day, 1.0, time3);
            }
            command3 = new SqlCommand("SELECT * from " + Variables.gTermi + "TmpCalendario where not Codigo is null order by NroOA,NroLinea", connection2);
            command3.CommandTimeout = 900;
            dataSet.Clear();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = command3;
            adapter.Fill(dataSet, Variables.gTermi + "TmpCalendario");
            long num6 = dataSet.Tables[Variables.gTermi + "TmpCalendario"].Rows.Count - 1;
            for (num = 0L; num <= num6; num += 1L)
            {
                row = dataSet.Tables[Variables.gTermi + "TmpCalendario"].Rows[(int) num];
                command3 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT OR03005,OR03006,OR03007,OR03011,OR03012,SC03003,SC03004,SC03005 FROM dbo.OR030100 inner join SC030100 on OR030100.OR03005=SC030100.SC03001 where OR03001='", row["NroOA"]), "' and OR03002='"), row["NroLinea"]), "' and OR03003<>'000' and SC03002='"), row["Almacen"]), "'")), connection);
                command3.CommandTimeout = 900;
                set2.Clear();
                SqlDataAdapter adapter2 = new SqlDataAdapter();
                adapter2.SelectCommand = command3;
                adapter2.Fill(set2, "OR030100");
                bool flag = false;
                long num5 = set2.Tables["OR030100"].Rows.Count - 1;
                for (long i = 0L; i <= num5; i += 1L)
                {
                    DataRow row2 = set2.Tables["OR030100"].Rows[(int) i];
                    if (BooleanType.FromObject(ObjectType.BitOrObj(ObjectType.ObjTst(row2["SC03003"], 0, false) <= 0, ObjectType.ObjTst(ObjectType.AddObj(row2["SC03004"], row2["SC03005"]), row2["SC03003"], false) > 0)))
                    {
                        flag = true;
                    }
                    if (ObjectType.ObjTst(ObjectType.AddObj(row2["SC03004"], row2["SC03005"]), row2["SC03003"], false) > 0)
                    {
                        reader = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT PC03043,PC03044,PC03016 FROM dbo.PC030100 where PC03005='", row2["OR03005"]), "' and PC03043<PC03044 and PC03029=1 ")) + "and PC03035='", row["Almacen"]), "' order by PC03016")), connection).ExecuteReader();
                        if (reader.Read())
                        {
                            str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpCalendarioStkComp (NroOA,NroLinea,CodComp,DescComp,Cantidad,StkFisico,StkComprometido,FechaOC,CantOC) values ('", row["NroOA"]), "','"), row["NroLinea"]), "','"), row2["OR03005"]), "','"), row2["OR03006"]), " "), row2["OR03007"]), "',"), ObjectType.SubObj(row2["OR03011"], row2["OR03012"])), ","), row2["SC03003"]), ","), ObjectType.AddObj(row2["SC03004"], row2["SC03005"])), ",'"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["PC03016"]), "MM/dd/yyyy")), "',"), ObjectType.SubObj(reader["PC03044"], reader["PC03043"])), ")"));
                            reader.Close();
                            command4 = new SqlCommand(str4, connection2);
                            try
                            {
                                num4 = command4.ExecuteNonQuery();
                            }
                            catch (Exception exception10)
                            {
                                ProjectData.SetProjectError(exception10);
                                Exception exception4 = exception10;
                                Interaction.MsgBox("Se ha producido el siguiente error:" + exception4.Message, MsgBoxStyle.OKOnly, null);
                                connection.Close();
                                connection2.Close();
                                this.cmbSalir.Enabled = true;
                                this.cmbVolver.Enabled = true;
                                ProjectData.ClearProjectError();
                                return;
                                ProjectData.ClearProjectError();
                            }
                        }
                        else
                        {
                            reader.Close();
                            command4 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpCalendarioStkComp (NroOA,NroLinea,CodComp,DescComp,Cantidad,StkFisico,StkComprometido) values ('", row["NroOA"]), "','"), row["NroLinea"]), "','"), row2["OR03005"]), "','"), row2["OR03006"]), " "), row2["OR03007"]), "',"), ObjectType.SubObj(row2["OR03011"], row2["OR03012"])), ","), row2["SC03003"]), ","), ObjectType.AddObj(row2["SC03004"], row2["SC03005"])), ")")), connection2);
                            try
                            {
                                num4 = command4.ExecuteNonQuery();
                            }
                            catch (Exception exception11)
                            {
                                ProjectData.SetProjectError(exception11);
                                Exception exception5 = exception11;
                                Interaction.MsgBox("Se ha producido el siguiente error:" + exception5.Message, MsgBoxStyle.OKOnly, null);
                                connection.Close();
                                connection2.Close();
                                this.cmbSalir.Enabled = true;
                                this.cmbVolver.Enabled = true;
                                ProjectData.ClearProjectError();
                                return;
                                ProjectData.ClearProjectError();
                            }
                        }
                    }
                    else
                    {
                        command4 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpCalendarioStkComp (NroOA,NroLinea,CodComp,DescComp,Cantidad,StkFisico,StkComprometido) values ('", row["NroOA"]), "','"), row["NroLinea"]), "','"), row2["OR03005"]), "','"), row2["OR03006"]), " "), row2["OR03007"]), "',"), ObjectType.SubObj(row2["OR03011"], row2["OR03012"])), ","), row2["SC03003"]), ","), ObjectType.AddObj(row2["SC03004"], row2["SC03005"])), ")")), connection2);
                        try
                        {
                            num4 = command4.ExecuteNonQuery();
                        }
                        catch (Exception exception12)
                        {
                            ProjectData.SetProjectError(exception12);
                            Exception exception6 = exception12;
                            Interaction.MsgBox("Se ha producido el siguiente error:" + exception6.Message, MsgBoxStyle.OKOnly, null);
                            connection.Close();
                            connection2.Close();
                            this.cmbSalir.Enabled = true;
                            this.cmbVolver.Enabled = true;
                            ProjectData.ClearProjectError();
                            return;
                            ProjectData.ClearProjectError();
                        }
                    }
                }
                if (flag)
                {
                    command4 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("update " + Variables.gTermi + "TmpCalendario set SinStock=1 where NroOA='", row["NroOA"]), "'")), connection2);
                    try
                    {
                        num4 = command4.ExecuteNonQuery();
                    }
                    catch (Exception exception13)
                    {
                        ProjectData.SetProjectError(exception13);
                        Exception exception7 = exception13;
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception7.Message, MsgBoxStyle.OKOnly, null);
                        connection.Close();
                        connection2.Close();
                        this.cmbSalir.Enabled = true;
                        this.cmbVolver.Enabled = true;
                        ProjectData.ClearProjectError();
                        return;
                        ProjectData.ClearProjectError();
                    }
                }
            }
            connection.Close();
            connection2.Close();
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            this.mVolver = false;
            this.Close();
        }

        private void cmbVolver_Click(object sender, EventArgs e)
        {
            this.mVolver = true;
            this.Close();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
        }

        private void CrystalReportViewer1_ReportRefresh(object source, ViewerEventArgs e)
        {
            this.cmbSalir.Enabled = false;
            this.Informe.Close();
            if (Variables.gOrdenOA == 1)
            {
                this.ActTmp();
            }
            this.DS.Clear();
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            string selectCommandText = "SELECT * from " + Variables.gTermi + "TmpCalendario as PC1TmpCalendario where FechaEnt<'" + Strings.Format(DateTime.Now, "MM/dd/yyyy") + "'";
            this.AdapTmp = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.AdapTmp.Fill(this.DS, "PC1TmpCalendario");
            selectCommandText = "SELECT NroOE,NroLinea,Observaciones,Fecha FROM dbo.GesEnsObs";
            this.AdapObs = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.AdapObs.Fill(this.DS, "GesEnsObs");
            selectCommandText = "SELECT * from " + Variables.gTermi + "TmpCalendarioStkComp as PC1TmpCalendarioStkComp";
            this.AdapTmp1 = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.AdapTmp1.Fill(this.DS, "PC1TmpCalendarioStkComp");
            this.Informe.Load(Application.StartupPath + @"\repoapendcal.rpt");
            this.Informe.SetDataSource(this.DS);
            FormulaFieldDefinition definition = this.Informe.DataDefinition.FormulaFields["orden"];
            definition.Text = "'ordenado por Fecha Entrega'";
            this.CrystalReportViewer1.ShowGroupTreeButton = true;
            this.CrystalReportViewer1.ReportSource = this.Informe;
            this.CrystalReportViewer1.Zoom(1);
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

        ~frmRepOAPend2()
        {
        }

        private void frmRepOAPend2_Closed(object sender, EventArgs e)
        {
            if (this.mVolver)
            {
                new frmRepOAPend1().Show();
            }
            else
            {
                new frmRepOAPend().Show();
            }
        }

        private void frmRepOAPend2_Load(object sender, EventArgs e)
        {
            this.mVolver = false;
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRepOAPend2));
            this.cmbSalir = new Button();
            this.CrystalReportViewer1 = new CrystalReportViewer();
            this.cmbVolver = new Button();
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
            this.cmbVolver.DialogResult = DialogResult.Cancel;
            point = new Point(0x328, 0x2a0);
            this.cmbVolver.Location = point;
            this.cmbVolver.Name = "cmbVolver";
            size = new Size(0x60, 40);
            this.cmbVolver.Size = size;
            this.cmbVolver.TabIndex = 0x37;
            this.cmbVolver.Text = "&Volver";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            this.CausesValidation = false;
            size = new Size(0x404, 0x2d5);
            this.ClientSize = size;
            this.Controls.Add(this.cmbVolver);
            this.Controls.Add(this.CrystalReportViewer1);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmRepOAPend2";
            this.Text = "Calendario de Armado";
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

        internal virtual Button cmbVolver
        {
            get
            {
                return this._cmbVolver;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbVolver != null)
                {
                    this._cmbVolver.Click -= new EventHandler(this.cmbVolver_Click);
                }
                this._cmbVolver = value;
                if (this._cmbVolver != null)
                {
                    this._cmbVolver.Click += new EventHandler(this.cmbVolver_Click);
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

