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

    public class frmRepOVPend1 : Form
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

        public frmRepOVPend1()
        {
            base.Closed += new EventHandler(this.frmRepOVPend1_Closed);
            base.Load += new EventHandler(this.frmRepOVPend1_Load);
            base.Click += new EventHandler(this.frmRepOVPend1_Click);
            this.Informe = new ReportDocument();
            this.DS = new DataSet();
            this.InitializeComponent();
            try
            {
                string str;
                SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
                connection.Open();
                if (Variables.gOVaListar == 1)
                {
                    str = "SELECT * from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend";
                }
                else if (Variables.gOVaListar == 2)
                {
                    str = "SELECT * from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend where NroOV in (select NroOV from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend where Cantidad>StockFisico and ((FechaOC>FechaEnt and not FechaOC is null) or FechaOC is null))";
                }
                else if (Variables.gOVaListar == 3)
                {
                    str = "SELECT * from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend where EntBloq=1";
                }
                else if (Variables.gOVaListar == 4)
                {
                    str = "SELECT * from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend where ExcLimCre=1";
                }
                else if (Variables.gOVaListar == 5)
                {
                    str = "SELECT * from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend where NroOV not in (select NroOV from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend where Cantidad>StockFisico)";
                }
                else if (Variables.gOVaListar == 6)
                {
                    str = "SELECT * from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend where NroOV in (select NroOV from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend where Cantidad>StockFisico and StockFisico<>0 and EntParc=1)";
                }
                SqlCommand command = new SqlCommand(str, connection);
                command.CommandTimeout = 500;
                this.AdapOR01 = new SqlDataAdapter();
                this.AdapOR01.SelectCommand = command;
                this.DS.Clear();
                this.AdapOR01.Fill(this.DS, "PC1TmpOVPend");
                if (Variables.gOrdenList == 1)
                {
                    this.Informe.Load(Application.StartupPath + @"\repovpend1.rpt");
                }
                else if (Variables.gOrdenList == 2)
                {
                    this.Informe.Load(Application.StartupPath + @"\repovpend.rpt");
                }
                else if (Variables.gOrdenList == 3)
                {
                    this.Informe.Load(Application.StartupPath + @"\repovpend3.rpt");
                }
                this.Informe.SetDataSource(this.DS);
                connection.Close();
                FormulaFieldDefinitions definitions = this.Informe.get_DataDefinition().get_FormulaFields();
                FormulaFieldDefinition definition = definitions.get_Item("desdefechaov");
                if (StringType.StrCmp(Variables.gDesdeFechaOV, Strings.Space(0), false) != 0)
                {
                    definition.set_Text("'" + Strings.Format(DateType.FromString(Variables.gDesdeFechaOV), "dd/MM/yyyy") + "'");
                }
                else
                {
                    definition.set_Text("''");
                }
                FormulaFieldDefinition definition2 = definitions.get_Item("hastafechaov");
                if (StringType.StrCmp(Variables.gHastaFechaOV, Strings.Space(0), false) != 0)
                {
                    definition2.set_Text("'" + Strings.Format(DateType.FromString(Variables.gHastaFechaOV), "dd/MM/yyyy") + "'");
                }
                else
                {
                    definition2.set_Text("''");
                }
                FormulaFieldDefinition definition3 = definitions.get_Item("desdefechaent");
                if (StringType.StrCmp(Variables.gDesdeFechaEnt, Strings.Space(0), false) != 0)
                {
                    definition3.set_Text("'" + Strings.Format(DateType.FromString(Variables.gDesdeFechaEnt), "dd/MM/yyyy") + "'");
                }
                else
                {
                    definition3.set_Text("''");
                }
                FormulaFieldDefinition definition4 = definitions.get_Item("hastafechaent");
                if (StringType.StrCmp(Variables.gHastaFechaEnt, Strings.Space(0), false) != 0)
                {
                    definition4.set_Text("'" + Strings.Format(DateType.FromString(Variables.gHastaFechaEnt), "dd/MM/yyyy") + "'");
                }
                else
                {
                    definition4.set_Text("''");
                }
                definitions.get_Item("tipo").set_Text("'" + Variables.gTipoList + "'");
                if (Variables.gOrdenList == 1)
                {
                    definitions.get_Item("orden").set_Text("'Ordenado por Fecha de Entrega Prevista'");
                }
                else if (Variables.gOrdenList == 2)
                {
                    definitions.get_Item("orden").set_Text("'Ordenado por N\x00b0 de Cliente'");
                }
                else if (Variables.gOrdenList == 3)
                {
                    definitions.get_Item("orden").set_Text("'Ordenado por Fecha de Orden de Venta'");
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
            DataSet dataSet = new DataSet();
            this.cmbSalir.Enabled = false;
            this.Informe.Close();
            SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
            SqlConnection connection2 = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
            connection2.Open();
            SqlCommand command4 = new SqlCommand("delete " + Variables.gTermi + "TmpOVPend", connection2);
            int num2 = command4.ExecuteNonQuery();
            string cmdText = "SELECT SL01001,SL01002,SL01060,SL01075,OR01001,OR01015,OR01016,OR01091,OR01018,OR01072,OR03005,OR03006,OR03007,OR03011,OR03012,sum(SC03003) as SC03003,sum(SC03004+SC03005) as StkComp,OR010100.OR01079 FROM dbo.SL010100,dbo.OR010100,dbo.OR030100,dbo.SC030100 where OR010100.OR01002<>6 and OR03011-OR03012<>0 ";
            if (StringType.StrCmp(Variables.gAlmacen1, "01", false) == 0)
            {
                cmdText = cmdText + "and SC03002='01' and OR01050='01'";
            }
            else
            {
                cmdText = cmdText + "and SC03002='02' and OR01050='02'";
            }
            if ((StringType.StrCmp(Variables.gDesdeFechaOV, Strings.Space(0), false) != 0) & (StringType.StrCmp(Variables.gHastaFechaOV, Strings.Space(0), false) != 0))
            {
                cmdText = cmdText + " and OR01015>='" + Strings.Format(DateType.FromString(Variables.gDesdeFechaOV), "MM/dd/yyyy") + "' and OR01015<='" + Strings.Format(DateType.FromString(Variables.gHastaFechaOV), "MM/dd/yyyy") + "'";
            }
            if ((StringType.StrCmp(Variables.gDesdeFechaEnt, Strings.Space(0), false) != 0) & (StringType.StrCmp(Variables.gHastaFechaEnt, Strings.Space(0), false) != 0))
            {
                cmdText = cmdText + " and OR01016>='" + Strings.Format(DateType.FromString(Variables.gDesdeFechaEnt), "MM/dd/yyyy") + "' and OR01016<='" + Strings.Format(DateType.FromString(Variables.gHastaFechaEnt), "MM/dd/yyyy") + "'";
            }
            if (StringType.StrCmp(Variables.gCodCli, Strings.Space(0), false) != 0)
            {
                cmdText = cmdText + " and OR01004='" + Variables.gCodCli + "'";
            }
            cmdText = cmdText + " and OR01001=OR03001 and OR01004=SL01001 and OR03005=SC03001" + " group by SL01001,SL01002,SL01060,SL01075,OR01001,OR01015,OR01016,OR01091,OR01018,OR01072,OR03005,OR03006,OR03007,OR03011,OR03012,OR010100.OR01079";
            SqlCommand command2 = new SqlCommand(cmdText, connection);
            command2.CommandTimeout = 500;
            SqlDataAdapter adapter3 = new SqlDataAdapter();
            adapter3.SelectCommand = command2;
            connection.Open();
            adapter3.Fill(dataSet, "SC030100");
            long num3 = dataSet.Tables["SC030100"].Rows.Count - 1;
            for (long i = 0L; i <= num3; i += 1L)
            {
                SqlDataReader reader;
                string str4;
                DataRow row = dataSet.Tables["SC030100"].Rows[(int) i];
                if (ObjectType.ObjTst(row["StkComp"], row["SC03003"], false) > 0)
                {
                    cmdText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT PC03043,PC03044,PC03016 FROM dbo.PC030100 where PC03005='", row["OR03005"]), "' and PC03043<PC03044 and PC03029=1 "));
                    if (StringType.StrCmp(Variables.gAlmacen1, "01", false) == 0)
                    {
                        cmdText = cmdText + "and PC03035='01' order by PC03016";
                    }
                    else
                    {
                        cmdText = cmdText + "and PC03035='02' order by PC03016";
                    }
                    SqlCommand command = new SqlCommand(cmdText, connection);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpOVPend (Cliente,NomCli,EntBloq,ExcLimCre,NroOV,FechaOV,FechaEnt,Reserva,RefCli,OCompra,CodProd,Desc1,Desc2,Cantidad,StockFisico,StockComp,FechaOC,CantOC,EntParc) values ('", row["SL01001"]), "','"), row["SL01002"]), "','"), row["SL01060"]), "','"), row["SL01075"]), "','"), row["OR01001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01016"]), "MM/dd/yyyy")), "',"), row["OR01091"]), ",'"), row["OR01018"]), "','"), row["OR01072"]), "','"), row["OR03005"]), "','"), row["OR03006"]), "','"), row["OR03007"]), "',"), ObjectType.SubObj(row["OR03011"], row["OR03012"])), ","), row["SC03003"]), ","), row["StkComp"]), ",'"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["PC03016"]), "MM/dd/yyyy")), "',"), ObjectType.SubObj(reader["PC03044"], reader["PC03043"])), ",'"), row["OR01079"]), "')"));
                        reader.Close();
                        command4 = new SqlCommand(str4, connection2);
                    }
                    else
                    {
                        reader.Close();
                        command4 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpOVPend (Cliente,NomCli,EntBloq,ExcLimCre,NroOV,FechaOV,FechaEnt,Reserva,RefCli,OCompra,CodProd,Desc1,Desc2,Cantidad,StockFisico,StockComp,EntParc) values ('", row["SL01001"]), "','"), row["SL01002"]), "','"), row["SL01060"]), "','"), row["SL01075"]), "','"), row["OR01001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01016"]), "MM/dd/yyyy")), "',"), row["OR01091"]), ",'"), row["OR01018"]), "','"), row["OR01072"]), "','"), row["OR03005"]), "','"), row["OR03006"]), "','"), row["OR03007"]), "',"), ObjectType.SubObj(row["OR03011"], row["OR03012"])), ","), row["SC03003"]), ","), row["StkComp"]), ",'"), row["OR01079"]), "')")), connection2);
                    }
                }
                else if (ObjectType.ObjTst(row["StkComp"], row["SC03003"], false) == 0)
                {
                    cmdText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT OR010100.OR01016,OR030100.OR03011,OR030100.OR03012 FROM dbo.OR030100,OR010100 where OR03005='", row["OR03005"]), "' and OR03012<OR03011 and OR01002=6 and OR03001=OR01001 order by OR01016"));
                    reader = new SqlCommand(cmdText, connection).ExecuteReader();
                    if (reader.Read())
                    {
                        str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpOVPend (Cliente,NomCli,EntBloq,ExcLimCre,NroOV,FechaOV,FechaEnt,Reserva,RefCli,OCompra,CodProd,Desc1,Desc2,Cantidad,StockFisico,StockComp,FechaOC,CantOC,EntParc) values ('", row["SL01001"]), "','"), row["SL01002"]), "','"), row["SL01060"]), "','"), row["SL01075"]), "','"), row["OR01001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01016"]), "MM/dd/yyyy")), "',"), row["OR01091"]), ",'"), row["OR01018"]), "','"), row["OR01072"]), "','"), row["OR03005"]), "','"), row["OR03006"]), "','"), row["OR03007"]), "',"), ObjectType.SubObj(row["OR03011"], row["OR03012"])), ","), row["SC03003"]), ","), row["StkComp"]), ",'"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR01016"]), "MM/dd/yyyy")), "',"), ObjectType.SubObj(reader["OR03011"], reader["OR03012"])), ",'"), row["OR01079"]), "')"));
                        reader.Close();
                        command4 = new SqlCommand(str4, connection2);
                    }
                    else
                    {
                        reader.Close();
                        command4 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpOVPend (Cliente,NomCli,EntBloq,ExcLimCre,NroOV,FechaOV,FechaEnt,Reserva,RefCli,OCompra,CodProd,Desc1,Desc2,Cantidad,StockFisico,StockComp,EntParc) values ('", row["SL01001"]), "','"), row["SL01002"]), "','"), row["SL01060"]), "','"), row["SL01075"]), "','"), row["OR01001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01016"]), "MM/dd/yyyy")), "',"), row["OR01091"]), ",'"), row["OR01018"]), "','"), row["OR01072"]), "','"), row["OR03005"]), "','"), row["OR03006"]), "','"), row["OR03007"]), "',"), ObjectType.SubObj(row["OR03011"], row["OR03012"])), ","), row["SC03003"]), ","), row["StkComp"]), ",'"), row["OR01079"]), "')")), connection2);
                    }
                }
                else
                {
                    command4 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpOVPend (Cliente,NomCli,EntBloq,ExcLimCre,NroOV,FechaOV,FechaEnt,Reserva,RefCli,OCompra,CodProd,Desc1,Desc2,Cantidad,StockFisico,StockComp,EntParc) values ('", row["SL01001"]), "','"), row["SL01002"]), "','"), row["SL01060"]), "','"), row["SL01075"]), "','"), row["OR01001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01016"]), "MM/dd/yyyy")), "',"), row["OR01091"]), ",'"), row["OR01018"]), "','"), row["OR01072"]), "','"), row["OR03005"]), "','"), row["OR03006"]), "','"), row["OR03007"]), "',"), ObjectType.SubObj(row["OR03011"], row["OR03012"])), ","), row["SC03003"]), ","), row["StkComp"]), ",'"), row["OR01079"]), "')")), connection2);
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
                }
            }
            connection.Close();
            connection2.Close();
            try
            {
                connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
                connection.Open();
                if (Variables.gOVaListar == 1)
                {
                    cmdText = "SELECT * from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend";
                }
                else if (Variables.gOVaListar == 2)
                {
                    cmdText = "SELECT * from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend where NroOV in (select NroOV from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend where Cantidad>StockFisico and ((FechaOC>FechaEnt and not FechaOC is null) or FechaOC is null))";
                }
                else if (Variables.gOVaListar == 3)
                {
                    cmdText = "SELECT * from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend where EntBloq=1";
                }
                else if (Variables.gOVaListar == 4)
                {
                    cmdText = "SELECT * from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend where ExcLimCre=1";
                }
                else if (Variables.gOVaListar == 5)
                {
                    cmdText = "SELECT * from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend where NroOV not in (select NroOV from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend where Cantidad>StockFisico)";
                }
                else if (Variables.gOVaListar == 6)
                {
                    cmdText = "SELECT * from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend where NroOV in (select NroOV from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend where Cantidad>StockFisico and StockFisico<>0 and EntParc=1)";
                }
                command2 = new SqlCommand(cmdText, connection);
                command2.CommandTimeout = 500;
                this.AdapOR01 = new SqlDataAdapter();
                this.AdapOR01.SelectCommand = command2;
                dataSet.Clear();
                this.AdapOR01.Fill(dataSet, "PC1TmpOVPend");
                if (Variables.gOrdenList == 1)
                {
                    this.Informe.Load(Application.StartupPath + @"\repovpend1.rpt");
                }
                else if (Variables.gOrdenList == 2)
                {
                    this.Informe.Load(Application.StartupPath + @"\repovpend.rpt");
                }
                else if (Variables.gOrdenList == 3)
                {
                    this.Informe.Load(Application.StartupPath + @"\repovpend3.rpt");
                }
                this.Informe.SetDataSource(dataSet);
                connection.Close();
                FormulaFieldDefinitions definitions = this.Informe.get_DataDefinition().get_FormulaFields();
                FormulaFieldDefinition definition = definitions.get_Item("desdefechaov");
                if (StringType.StrCmp(Variables.gDesdeFechaOV, Strings.Space(0), false) != 0)
                {
                    definition.set_Text("'" + Strings.Format(DateType.FromString(Variables.gDesdeFechaOV), "dd/MM/yyyy") + "'");
                }
                else
                {
                    definition.set_Text("''");
                }
                FormulaFieldDefinition definition2 = definitions.get_Item("hastafechaov");
                if (StringType.StrCmp(Variables.gHastaFechaOV, Strings.Space(0), false) != 0)
                {
                    definition2.set_Text("'" + Strings.Format(DateType.FromString(Variables.gHastaFechaOV), "dd/MM/yyyy") + "'");
                }
                else
                {
                    definition2.set_Text("''");
                }
                FormulaFieldDefinition definition3 = definitions.get_Item("desdefechaent");
                if (StringType.StrCmp(Variables.gDesdeFechaEnt, Strings.Space(0), false) != 0)
                {
                    definition3.set_Text("'" + Strings.Format(DateType.FromString(Variables.gDesdeFechaEnt), "dd/MM/yyyy") + "'");
                }
                else
                {
                    definition3.set_Text("''");
                }
                FormulaFieldDefinition definition4 = definitions.get_Item("hastafechaent");
                if (StringType.StrCmp(Variables.gHastaFechaEnt, Strings.Space(0), false) != 0)
                {
                    definition4.set_Text("'" + Strings.Format(DateType.FromString(Variables.gHastaFechaEnt), "dd/MM/yyyy") + "'");
                }
                else
                {
                    definition4.set_Text("''");
                }
                definitions.get_Item("tipo").set_Text("'" + Variables.gTipoList + "'");
                if (Variables.gOrdenList == 1)
                {
                    definitions.get_Item("orden").set_Text("'Ordenado por Fecha de Entrega Prevista'");
                }
                else if (Variables.gOrdenList == 2)
                {
                    definitions.get_Item("orden").set_Text("'Ordenado por N\x00b0 de Cliente'");
                }
                else if (Variables.gOrdenList == 3)
                {
                    definitions.get_Item("orden").set_Text("'Ordenado por Fecha de Orden de Venta'");
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

        ~frmRepOVPend1()
        {
        }

        private void frmRepOVPend1_Click(object sender, EventArgs e)
        {
        }

        private void frmRepOVPend1_Closed(object sender, EventArgs e)
        {
            new frmRepOVPend().Show();
        }

        private void frmRepOVPend1_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRepOVPend1));
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
            this.Name = "frmRepOVPend1";
            this.Text = "Reporte O.Venta Pendientes";
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

