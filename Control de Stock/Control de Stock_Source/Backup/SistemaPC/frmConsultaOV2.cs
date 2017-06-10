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

    public class frmConsultaOV2 : Form
    {
        [AccessedThroughProperty("btnNovedades")]
        private Button _btnNovedades;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("CrystalReportViewer1")]
        private CrystalReportViewer _CrystalReportViewer1;
        public SqlDataAdapter AdapOR01;
        public SqlDataAdapter AdapOR03;
        public SqlDataAdapter AdapProdPend;
        public SqlDataAdapter AdapSC03;
        public SqlDataAdapter AdapSL01;
        private IContainer components;
        public DataSet DS;
        public DataSet DS19;
        public DataSet DS20;
        public ReportDocument Informe;

        public frmConsultaOV2()
        {
            base.Closed += new EventHandler(this.frmConsultaOV2_Closed);
            base.Load += new EventHandler(this.frmConsultaOV2_Load);
            base.Click += new EventHandler(this.frmConsultaOV2_Click);
            this.Informe = new ReportDocument();
            this.DS = new DataSet();
            this.DS19 = new DataSet();
            this.DS20 = new DataSet();
            this.InitializeComponent();
            try
            {
                SqlCommand command;
                string connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                if ((Variables.gCodEstado == 1) | (Variables.gCodEstado == 4))
                {
                    command = new SqlCommand("SELECT * from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend", connection);
                    command.CommandTimeout = 500;
                    this.AdapOR01 = new SqlDataAdapter();
                    this.AdapOR01.SelectCommand = command;
                    this.DS.Clear();
                    this.AdapOR01.Fill(this.DS, "PC1TmpOVPend");
                    this.Informe.Load(Application.StartupPath + @"\ConsultaOVPendEnt.rpt");
                    this.Informe.SetDataSource(this.DS);
                    connection.Close();
                    FormulaFieldDefinition definition = this.Informe.get_DataDefinition().get_FormulaFields().get_Item("Titulo");
                    if (Variables.gCodEstado == 1)
                    {
                        definition.set_Text("'Consulta Ordenes de Venta - Estado Pendiente de Entrega'");
                    }
                    else
                    {
                        definition.set_Text("'Consulta Ordenes de Venta - Estado Preparado pend.imp.doc.exp.'");
                    }
                    this.CrystalReportViewer1.set_ReportSource(this.Informe);
                }
                if (Variables.gCodEstado == 2)
                {
                    this.AdapProdPend = new SqlDataAdapter("Select NroOV,NroLinea,EstLinea,Codigo,Desc1,Desc2,CantOrden,CantPrep,FechaPrep,NroRemito,Cliente,NomCli,OCompra,FechaOV from PrepPed where NroOV='" + Variables.gNroOV + "' and Expedicion='N' and Producto=0", connectionString);
                    this.AdapProdPend.Fill(this.DS, "PrepPed");
                    this.Informe.Load(Application.StartupPath + @"\ConsultaOVPendExp.rpt");
                    this.Informe.SetDataSource(this.DS);
                    this.CrystalReportViewer1.set_ReportSource(this.Informe);
                }
                if ((Variables.gCodEstado == 3) | (Variables.gCodEstado == 5))
                {
                    command = new SqlCommand("SELECT * from " + Variables.gTermi + "TmpOVExped as PC1TmpOVExped", connection);
                    command.CommandTimeout = 500;
                    this.AdapOR01 = new SqlDataAdapter();
                    this.AdapOR01.SelectCommand = command;
                    this.DS.Clear();
                    this.AdapOR01.Fill(this.DS, "PC1TmpOVExped");
                    this.Informe.Load(Application.StartupPath + @"\ConsultaOVExped.rpt");
                    this.Informe.SetDataSource(this.DS);
                    connection.Close();
                    FormulaFieldDefinition definition2 = this.Informe.get_DataDefinition().get_FormulaFields().get_Item("Titulo");
                    if (Variables.gCodEstado == 3)
                    {
                        definition2.set_Text("'Consulta Ordenes de Venta - Estado Expedido'");
                    }
                    else
                    {
                        definition2.set_Text("'Consulta Ordenes de Venta - Estado Recepci\x00f3n Conformada'");
                    }
                    this.CrystalReportViewer1.set_ReportSource(this.Informe);
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                ProjectData.ClearProjectError();
            }
        }

        private void btnNovedades_Click(object sender, EventArgs e)
        {
            new frmConsultaOV3().ShowDialog();
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
            SqlDataAdapter adapter3;
            SqlCommand command;
            DataRow row;
            DataRow row2;
            long num;
            long num2;
            SqlDataReader reader;
            int num3;
            SqlCommand command3;
            SqlCommand command5;
            string str5;
            DataSet dataSet = new DataSet();
            this.cmbSalir.Enabled = false;
            this.Informe.Close();
            string connectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
            SqlConnection connection = new SqlConnection(connectionString);
            string str9 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            SqlConnection connection2 = new SqlConnection(str9);
            connection2.Open();
            if ((Variables.gCodEstado == 1) | (Variables.gCodEstado == 4))
            {
                command5 = new SqlCommand("delete " + Variables.gTermi + "TmpOVPend", connection2);
                num3 = command5.ExecuteNonQuery();
                string str = "SELECT SL01001,SL01002,SL01060,SL01075,OR01001,OR01015,OR01016,OR01091,OR01018,OR01072,OR03005,OR03006,OR03007,OR03011,OR03012,sum(SC03003) as SC03003,sum(SC03004+SC03005) as StkComp,OR010100.OR01079 FROM dbo.SL010100,dbo.OR010100,dbo.OR030100,dbo.SC030100 where OR010100.OR01002<>6 and OR03011-OR03012<>0 ";
                command3 = new SqlCommand(((str + "and SC03002='01' and OR01050='01'") + " and OR01001='" + Variables.gNroOV + "'") + " and OR01001=OR03001 and OR01004=SL01001 and OR03005=SC03001" + " group by SL01001,SL01002,SL01060,SL01075,OR01001,OR01015,OR01016,OR01091,OR01018,OR01072,OR03005,OR03006,OR03007,OR03011,OR03012,OR010100.OR01079", connection);
                command3.CommandTimeout = 500;
                SqlDataAdapter adapter5 = new SqlDataAdapter();
                adapter5.SelectCommand = command3;
                connection.Open();
                adapter5.Fill(dataSet, "SC030100");
                long num10 = dataSet.Tables["SC030100"].Rows.Count - 1;
                for (num = 0L; num <= num10; num += 1L)
                {
                    row = dataSet.Tables["SC030100"].Rows[(int) num];
                    if (ObjectType.ObjTst(row["StkComp"], row["SC03003"], false) > 0)
                    {
                        command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT PC03043,PC03044,PC03016 FROM dbo.PC030100 where PC03005='", row["OR03005"]), "' and PC03043<PC03044 and PC03029=1 ")) + "and PC03035='01' order by PC03016", connection);
                        reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            str5 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpOVPend (Cliente,NomCli,EntBloq,ExcLimCre,NroOV,FechaOV,FechaEnt,Reserva,RefCli,OCompra,CodProd,Desc1,Desc2,Cantidad,StockFisico,StockComp,FechaOC,CantOC,EntParc) values ('", row["SL01001"]), "','"), row["SL01002"]), "','"), row["SL01060"]), "','"), row["SL01075"]), "','"), row["OR01001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01016"]), "MM/dd/yyyy")), "',"), row["OR01091"]), ",'"), row["OR01018"]), "','"), row["OR01072"]), "','"), row["OR03005"]), "','"), row["OR03006"]), "','"), row["OR03007"]), "',"), ObjectType.SubObj(row["OR03011"], row["OR03012"])), ","), row["SC03003"]), ","), row["StkComp"]), ",'"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["PC03016"]), "MM/dd/yyyy")), "',"), ObjectType.SubObj(reader["PC03044"], reader["PC03043"])), ",'"), row["OR01079"]), "')"));
                            reader.Close();
                            command5 = new SqlCommand(str5, connection2);
                        }
                        else
                        {
                            reader.Close();
                            command5 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpOVPend (Cliente,NomCli,EntBloq,ExcLimCre,NroOV,FechaOV,FechaEnt,Reserva,RefCli,OCompra,CodProd,Desc1,Desc2,Cantidad,StockFisico,StockComp,EntParc) values ('", row["SL01001"]), "','"), row["SL01002"]), "','"), row["SL01060"]), "','"), row["SL01075"]), "','"), row["OR01001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01016"]), "MM/dd/yyyy")), "',"), row["OR01091"]), ",'"), row["OR01018"]), "','"), row["OR01072"]), "','"), row["OR03005"]), "','"), row["OR03006"]), "','"), row["OR03007"]), "',"), ObjectType.SubObj(row["OR03011"], row["OR03012"])), ","), row["SC03003"]), ","), row["StkComp"]), ",'"), row["OR01079"]), "')")), connection2);
                        }
                    }
                    else if (ObjectType.ObjTst(row["StkComp"], row["SC03003"], false) == 0)
                    {
                        command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT OR010100.OR01016,OR030100.OR03011,OR030100.OR03012 FROM dbo.OR030100,OR010100 where OR03005='", row["OR03005"]), "' and OR03012<OR03011 and OR01002=6 and OR03001=OR01001 order by OR01016")), connection);
                        reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            str5 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpOVPend (Cliente,NomCli,EntBloq,ExcLimCre,NroOV,FechaOV,FechaEnt,Reserva,RefCli,OCompra,CodProd,Desc1,Desc2,Cantidad,StockFisico,StockComp,FechaOC,CantOC,EntParc) values ('", row["SL01001"]), "','"), row["SL01002"]), "','"), row["SL01060"]), "','"), row["SL01075"]), "','"), row["OR01001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01016"]), "MM/dd/yyyy")), "',"), row["OR01091"]), ",'"), row["OR01018"]), "','"), row["OR01072"]), "','"), row["OR03005"]), "','"), row["OR03006"]), "','"), row["OR03007"]), "',"), ObjectType.SubObj(row["OR03011"], row["OR03012"])), ","), row["SC03003"]), ","), row["StkComp"]), ",'"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR01016"]), "MM/dd/yyyy")), "',"), ObjectType.SubObj(reader["OR03011"], reader["OR03012"])), ",'"), row["OR01079"]), "')"));
                            reader.Close();
                            command5 = new SqlCommand(str5, connection2);
                        }
                        else
                        {
                            reader.Close();
                            command5 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpOVPend (Cliente,NomCli,EntBloq,ExcLimCre,NroOV,FechaOV,FechaEnt,Reserva,RefCli,OCompra,CodProd,Desc1,Desc2,Cantidad,StockFisico,StockComp,EntParc) values ('", row["SL01001"]), "','"), row["SL01002"]), "','"), row["SL01060"]), "','"), row["SL01075"]), "','"), row["OR01001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01016"]), "MM/dd/yyyy")), "',"), row["OR01091"]), ",'"), row["OR01018"]), "','"), row["OR01072"]), "','"), row["OR03005"]), "','"), row["OR03006"]), "','"), row["OR03007"]), "',"), ObjectType.SubObj(row["OR03011"], row["OR03012"])), ","), row["SC03003"]), ","), row["StkComp"]), ",'"), row["OR01079"]), "')")), connection2);
                        }
                    }
                    else
                    {
                        command5 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpOVPend (Cliente,NomCli,EntBloq,ExcLimCre,NroOV,FechaOV,FechaEnt,Reserva,RefCli,OCompra,CodProd,Desc1,Desc2,Cantidad,StockFisico,StockComp,EntParc) values ('", row["SL01001"]), "','"), row["SL01002"]), "','"), row["SL01060"]), "','"), row["SL01075"]), "','"), row["OR01001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01016"]), "MM/dd/yyyy")), "',"), row["OR01091"]), ",'"), row["OR01018"]), "','"), row["OR01072"]), "','"), row["OR03005"]), "','"), row["OR03006"]), "','"), row["OR03007"]), "',"), ObjectType.SubObj(row["OR03011"], row["OR03012"])), ","), row["SC03003"]), ","), row["StkComp"]), ",'"), row["OR01079"]), "')")), connection2);
                    }
                    try
                    {
                        num3 = command5.ExecuteNonQuery();
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
                    connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    command3 = new SqlCommand("SELECT * from " + Variables.gTermi + "TmpOVPend as PC1TmpOVPend", connection);
                    command3.CommandTimeout = 500;
                    this.AdapOR01 = new SqlDataAdapter();
                    this.AdapOR01.SelectCommand = command3;
                    dataSet.Clear();
                    this.AdapOR01.Fill(dataSet, "PC1TmpOVPend");
                    this.Informe.Load(Application.StartupPath + @"\ConsultaOVPendEnt.rpt");
                    this.Informe.SetDataSource(dataSet);
                    connection.Close();
                    FormulaFieldDefinition definition = this.Informe.get_DataDefinition().get_FormulaFields().get_Item("Titulo");
                    if (Variables.gCodEstado == 1)
                    {
                        definition.set_Text("'Consulta Ordenes de Venta - Estado Pendiente de Entrega'");
                    }
                    else
                    {
                        definition.set_Text("'Consulta Ordenes de Venta - Estado Preparado pend.imp.doc.exp.'");
                    }
                    this.CrystalReportViewer1.set_ReportSource(this.Informe);
                    this.CrystalReportViewer1.Refresh();
                    this.cmbSalir.Enabled = true;
                }
                catch (Exception exception7)
                {
                    ProjectData.SetProjectError(exception7);
                    Exception exception2 = exception7;
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, 0, null);
                    ProjectData.ClearProjectError();
                }
            }
            if (Variables.gCodEstado == 2)
            {
                if (Variables.gCodEstado == 2)
                {
                    SqlCommand command2;
                    SqlDataAdapter adapter2 = new SqlDataAdapter("select * from PrepPed where NroOV='" + Variables.gNroOV + "' and Expedicion='N' and NroRemito is null", str9);
                    adapter2.Fill(dataSet, "PrepPed");
                    if (dataSet.Tables["PrepPed"].Rows.Count != 0)
                    {
                        long num9 = dataSet.Tables["PrepPed"].Rows.Count - 1;
                        for (num = 0L; num <= num9; num += 1L)
                        {
                            row = dataSet.Tables["PrepPed"].Rows[(int) num];
                            adapter3 = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR19012 from OR190100 where OR19001='", row["NroOV"]), "' and OR19002='"), row["NroLinea"]), "' and OR19003='"), row["EstLinea"]), "' and OR19011='"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FechaPrep"]), "MM/dd/yyyy")), "' and OR19012<>'' order by OR19012")), connectionString);
                            this.DS19.Clear();
                            adapter3.Fill(this.DS19, "OR190100");
                            if (this.DS19.Tables["OR190100"].Rows.Count != 0)
                            {
                                long num8 = this.DS19.Tables["OR190100"].Rows.Count - 1;
                                num2 = 0L;
                                while (num2 <= num8)
                                {
                                    row2 = this.DS19.Tables["OR190100"].Rows[(int) num2];
                                    command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("Select NroRemito from PrepPed where NroOV='", row["NroOV"]), "' and NroLinea='"), row["NroLinea"]), "' and EstLinea='"), row["EstLinea"]), "' and NroRemito='"), row2["OR19012"]), "'")), connection2);
                                    reader = command.ExecuteReader();
                                    if (reader.Read())
                                    {
                                        reader.Close();
                                    }
                                    else
                                    {
                                        reader.Close();
                                        try
                                        {
                                            command2 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("update PrepPed set NroRemito='", row2["OR19012"]), "' where NroOV='"), row["NroOV"]), "' and NroLinea='"), row["NroLinea"]), "' and TipoLinea="), row["TipoLinea"]), " and EstLinea='"), row["EstLinea"]), "' and NroRemito is null")), connection2);
                                            num3 = command2.ExecuteNonQuery();
                                        }
                                        catch (Exception exception8)
                                        {
                                            ProjectData.SetProjectError(exception8);
                                            Exception exception3 = exception8;
                                            Interaction.MsgBox("Se ha producido el siguiente error:" + exception3.Message, 0, null);
                                            connection.Close();
                                            connection2.Close();
                                            this.Close();
                                            ProjectData.ClearProjectError();
                                        }
                                        goto Label_167A;
                                    }
                                    num2 += 1L;
                                }
                            }
                            else
                            {
                                adapter3 = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR23012 from OR230100 where OR23001='", row["NroOV"]), "' and OR23002='"), row["NroLinea"]), "' and OR23003='"), row["EstLinea"]), "' and OR23011='"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FechaPrep"]), "MM/dd/yyyy")), "' and OR23012<>'' order by OR23012")), connectionString);
                                this.DS20.Clear();
                                adapter3.Fill(this.DS20, "OR230100");
                                if (this.DS20.Tables["OR230100"].Rows.Count != 0)
                                {
                                    long num7 = this.DS20.Tables["OR230100"].Rows.Count - 1;
                                    num2 = 0L;
                                    while (num2 <= num7)
                                    {
                                        row2 = this.DS20.Tables["OR230100"].Rows[(int) num2];
                                        command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("Select NroRemito from PrepPed where NroOV='", row["NroOV"]), "' and NroLinea='"), row["NroLinea"]), "' and TipoLinea="), row["TipoLinea"]), " and EstLinea='"), row["EstLinea"]), "' and NroRemito='"), row2["OR23012"]), "'")), connection2);
                                        reader = command.ExecuteReader();
                                        if (reader.Read())
                                        {
                                            reader.Close();
                                        }
                                        else
                                        {
                                            reader.Close();
                                            try
                                            {
                                                command2 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("update PrepPed set NroRemito='", row2["OR23012"]), "' where NroOV='"), row["NroOV"]), "' and NroLinea='"), row["NroLinea"]), "' and TipoLinea="), row["TipoLinea"]), " and EstLinea='"), row["EstLinea"]), "' and NroRemito is null")), connection2);
                                                num3 = command2.ExecuteNonQuery();
                                            }
                                            catch (Exception exception9)
                                            {
                                                ProjectData.SetProjectError(exception9);
                                                Exception exception4 = exception9;
                                                Interaction.MsgBox("Se ha producido el siguiente error:" + exception4.Message, 0, null);
                                                connection.Close();
                                                connection2.Close();
                                                this.Close();
                                                ProjectData.ClearProjectError();
                                            }
                                            goto Label_167A;
                                        }
                                        num2 += 1L;
                                    }
                                }
                            }
                        Label_167A:;
                        }
                    }
                    new SqlDataAdapter("select NroOV from PrepPed where NroOV='" + Variables.gNroOV + "' and Expedicion='N' and Producto=0 group by NroOV", str9).Fill(dataSet, "PrepPed");
                    if (dataSet.Tables["PrepPed"].Rows.Count != 0)
                    {
                        long num6 = dataSet.Tables["PrepPed"].Rows.Count - 1;
                        for (num = 0L; num <= num6; num += 1L)
                        {
                            row = dataSet.Tables["PrepPed"].Rows[(int) num];
                            adapter3 = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR01015,OR01072 from OR010100 where OR01001='", row["NroOV"]), "'")), connectionString);
                            this.DS19.Clear();
                            adapter3.Fill(this.DS19, "OR190100");
                            if (this.DS19.Tables["OR190100"].Rows.Count != 0)
                            {
                                row2 = this.DS19.Tables["OR190100"].Rows[0];
                                try
                                {
                                    command2 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("update PrepPed set OCompra='", row2["OR01072"]), "',FechaOV='"), Strings.Format(RuntimeHelpers.GetObjectValue(row2["OR01015"]), "MM/dd/yyyy")), "' where NroOV='"), row["NroOV"]), "'")), connection2);
                                    num3 = command2.ExecuteNonQuery();
                                }
                                catch (Exception exception10)
                                {
                                    ProjectData.SetProjectError(exception10);
                                    Exception exception5 = exception10;
                                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception5.Message, 0, null);
                                    connection.Close();
                                    connection2.Close();
                                    this.Close();
                                    ProjectData.ClearProjectError();
                                }
                            }
                            else
                            {
                                adapter3 = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR20015,OR20072 from OR200100 where OR20001='", row["NroOV"]), "'")), connectionString);
                                this.DS20.Clear();
                                adapter3.Fill(this.DS20, "OR230100");
                                if (this.DS20.Tables["OR230100"].Rows.Count != 0)
                                {
                                    row2 = this.DS20.Tables["OR230100"].Rows[0];
                                    try
                                    {
                                        num3 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("update PrepPed set OCompra='", row2["OR20072"]), "',FechaOV='"), Strings.Format(RuntimeHelpers.GetObjectValue(row2["OR20015"]), "MM/dd/yyyy")), "' where NroOV='"), row["NroOV"]), "'")), connection2).ExecuteNonQuery();
                                    }
                                    catch (Exception exception11)
                                    {
                                        ProjectData.SetProjectError(exception11);
                                        Exception exception6 = exception11;
                                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception6.Message, 0, null);
                                        connection.Close();
                                        connection2.Close();
                                        this.Close();
                                        ProjectData.ClearProjectError();
                                    }
                                }
                            }
                        }
                    }
                }
                connection.Close();
                connection2.Close();
                this.AdapProdPend = new SqlDataAdapter("Select NroOV,NroLinea,EstLinea,Codigo,Desc1,Desc2,CantOrden,CantPrep,FechaPrep,NroRemito,Cliente,NomCli,OCompra,FechaOV from PrepPed where NroOV='" + Variables.gNroOV + "' and Expedicion='N' and Producto=0", connectionString);
                this.AdapProdPend.Fill(dataSet, "PrepPed");
                this.Informe.Load(Application.StartupPath + @"\ConsultaOVPendExp.rpt");
                this.Informe.SetDataSource(dataSet);
                this.CrystalReportViewer1.set_ReportSource(this.Informe);
                this.CrystalReportViewer1.Refresh();
                this.cmbSalir.Enabled = true;
            }
            if ((Variables.gCodEstado == 3) | (Variables.gCodEstado == 5))
            {
                command5 = new SqlCommand("delete " + Variables.gTermi + "TmpOVExped", connection2);
                num3 = command5.ExecuteNonQuery();
                reader = new SqlCommand("Select Fecha from RecConfCliOV where NroOV='" + Variables.gNroOV + "'", connection2).ExecuteReader();
                if (reader.Read())
                {
                    Variables.gFechaRecConfCli = StringType.FromObject(reader["Fecha"]);
                    reader.Close();
                }
                else
                {
                    Variables.gFechaRecConfCli = "";
                    reader.Close();
                }
                adapter3 = new SqlDataAdapter("select OR19012,OR19034,OR01057,OR01058,OR01059,OR01060,OR03005,OR03006,OR03007,OR19030 from OR190100,OR010100,OR030100 where OR19001=OR01001 and OR19001=OR03001 AND OR19002=OR03002 AND OR19003=OR03003 and OR19001='" + Variables.gNroOV + "' and OR01002='" + StringType.FromInteger(Variables.gTipoOV) + "' and OR19011='" + Strings.Format(DateType.FromString(Variables.gFechaPrep), "MM/dd/yyyy") + "' and OR19012<>''", connectionString);
                this.DS19.Clear();
                adapter3.Fill(this.DS19, "OR190100");
                if (this.DS19.Tables["OR190100"].Rows.Count != 0)
                {
                    long num5 = this.DS19.Tables["OR190100"].Rows.Count - 1;
                    for (num2 = 0L; num2 <= num5; num2 += 1L)
                    {
                        row2 = this.DS19.Tables["OR190100"].Rows[(int) num2];
                        str5 = ((((((((("insert into " + Variables.gTermi + "TmpOVExped (NroOV,TipoOV,Cliente,NomCli,OCompra,CodMetEnt,DescMetEnt,LugarEnt,FechaOV,FechaEnt,FechaPrep,FechaExp,FechaRecConfCli,NroRemito,NroFactura,PesoNeto,PesoBruto,Volumen,Bultos,CodProd,Desc1,Desc2,Cantidad) values ('" + Variables.gNroOV + "'," + StringType.FromInteger(Variables.gTipoOV)) + ",'" + Variables.gCliente) + "','" + Variables.gNomCli) + "','" + Variables.gNroOC + "'," + Variables.gCodMetEnt) + ",'" + Variables.gDescMetEnt) + "','" + Variables.gLugarEnt) + "','" + Strings.Format(Variables.gFechaOV, "MM/dd/yyyy")) + "','" + Strings.Format(DateType.FromString(Variables.gFechaEntOV), "MM/dd/yyyy")) + "','" + Strings.Format(DateType.FromString(Variables.gFechaPrep), "MM/dd/yyyy")) + "','" + Strings.Format(DateType.FromString(Variables.gFechaExp), "MM/dd/yyyy") + "',";
                        if (StringType.StrCmp(Variables.gFechaRecConfCli, Strings.Space(0), false) != 0)
                        {
                            str5 = str5 + "'" + Strings.Format(DateType.FromString(Variables.gFechaRecConfCli), "MM/dd/yyyy") + "',";
                        }
                        else
                        {
                            str5 = str5 + "Null,";
                        }
                        str5 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(str5 + "'", row2["OR19012"]), "','"), row2["OR19034"]), "',"), row2["OR01057"]), ","), row2["OR01058"]), ","), row2["OR01059"]), ","), row2["OR01060"]), ",'"), row2["OR03005"]), "','"), row2["OR03006"]), "','"), row2["OR03007"]), "',"), row2["OR19030"]), ")"));
                        reader.Close();
                        command5 = new SqlCommand(str5, connection2);
                        num3 = command5.ExecuteNonQuery();
                    }
                }
                else
                {
                    adapter3 = new SqlDataAdapter("select OR23012,OR23034,OR20057,OR20058,OR20059,OR20060,OR21005,OR21006,OR21007,OR23030 from OR230100,OR200100,OR210100 where OR23001=OR20001 and OR23001=OR21001 AND OR23002=OR21002 AND OR23003=OR21003 and OR23001='" + Variables.gNroOV + "' and OR20002='" + StringType.FromInteger(Variables.gTipoOV) + "' and OR23011='" + Strings.Format(DateType.FromString(Variables.gFechaPrep), "MM/dd/yyyy") + "' and OR23012<>''", connectionString);
                    this.DS20.Clear();
                    adapter3.Fill(this.DS20, "OR200100");
                    if (this.DS20.Tables["OR200100"].Rows.Count != 0)
                    {
                        long num4 = this.DS20.Tables["OR200100"].Rows.Count - 1;
                        for (num2 = 0L; num2 <= num4; num2 += 1L)
                        {
                            row2 = this.DS20.Tables["OR200100"].Rows[(int) num2];
                            str5 = ((((((((("insert into " + Variables.gTermi + "TmpOVExped (NroOV,TipoOV,Cliente,NomCli,OCompra,CodMetEnt,DescMetEnt,LugarEnt,FechaOV,FechaEnt,FechaPrep,FechaExp,FechaRecConfCli,NroRemito,NroFactura,PesoNeto,PesoBruto,Volumen,Bultos,CodProd,Desc1,Desc2,Cantidad) values ('" + Variables.gNroOV + "'," + StringType.FromInteger(Variables.gTipoOV)) + ",'" + Variables.gCliente) + "','" + Variables.gNomCli) + "','" + Variables.gNroOC + "'," + Variables.gCodMetEnt) + ",'" + Variables.gDescMetEnt) + "','" + Variables.gLugarEnt) + "','" + Strings.Format(Variables.gFechaOV, "MM/dd/yyyy")) + "','" + Strings.Format(DateType.FromString(Variables.gFechaEntOV), "MM/dd/yyyy")) + "','" + Strings.Format(DateType.FromString(Variables.gFechaPrep), "MM/dd/yyyy")) + "','" + Strings.Format(DateType.FromString(Variables.gFechaExp), "MM/dd/yyyy") + "',";
                            if (StringType.StrCmp(Variables.gFechaRecConfCli, Strings.Space(0), false) != 0)
                            {
                                str5 = str5 + "'" + Strings.Format(DateType.FromString(Variables.gFechaRecConfCli), "MM/dd/yyyy") + "',";
                            }
                            else
                            {
                                str5 = str5 + "Null,";
                            }
                            str5 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(str5 + "'", row2["OR23012"]), "','"), row2["OR23034"]), "',"), row2["OR20057"]), ","), row2["OR20058"]), ","), row2["OR20059"]), ","), row2["OR20060"]), ",'"), row2["OR21005"]), "','"), row2["OR21006"]), "','"), row2["OR21007"]), "',"), row2["OR23030"]), ")"));
                            reader.Close();
                            num3 = new SqlCommand(str5, connection2).ExecuteNonQuery();
                        }
                    }
                }
                connection.Close();
                connection2.Close();
                command3 = new SqlCommand("SELECT * from " + Variables.gTermi + "TmpOVExped as PC1TmpOVExped", connection);
                command3.CommandTimeout = 500;
                this.AdapOR01 = new SqlDataAdapter();
                this.AdapOR01.SelectCommand = command3;
                dataSet.Clear();
                this.AdapOR01.Fill(dataSet, "PC1TmpOVExped");
                this.Informe.Load(Application.StartupPath + @"\ConsultaOVExped.rpt");
                this.Informe.SetDataSource(dataSet);
                connection.Close();
                FormulaFieldDefinition definition2 = this.Informe.get_DataDefinition().get_FormulaFields().get_Item("Titulo");
                if (Variables.gCodEstado == 3)
                {
                    definition2.set_Text("'Consulta Ordenes de Venta - Estado Expedido'");
                }
                else
                {
                    definition2.set_Text("'Consulta Ordenes de Venta - Estado Recepci\x00f3n Conformada'");
                }
                this.CrystalReportViewer1.set_ReportSource(this.Informe);
                this.CrystalReportViewer1.Refresh();
                this.cmbSalir.Enabled = true;
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

        ~frmConsultaOV2()
        {
        }

        private void frmConsultaOV2_Click(object sender, EventArgs e)
        {
        }

        private void frmConsultaOV2_Closed(object sender, EventArgs e)
        {
            new frmConsultaOV1().Show();
        }

        private void frmConsultaOV2_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmConsultaOV2));
            this.cmbSalir = new Button();
            this.CrystalReportViewer1 = new CrystalReportViewer();
            this.btnNovedades = new Button();
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
            this.CrystalReportViewer1.set_DisplayGroupTree(false);
            point = new Point(8, 8);
            this.CrystalReportViewer1.Location = point;
            this.CrystalReportViewer1.Name = "CrystalReportViewer1";
            this.CrystalReportViewer1.set_ReportSource(null);
            this.CrystalReportViewer1.set_ShowGroupTreeButton(false);
            size = new Size(0x3f0, 640);
            this.CrystalReportViewer1.Size = size;
            this.CrystalReportViewer1.TabIndex = 0x36;
            this.btnNovedades.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x318, 0x2a0);
            this.btnNovedades.Location = point;
            this.btnNovedades.Name = "btnNovedades";
            size = new Size(0x60, 40);
            this.btnNovedades.Size = size;
            this.btnNovedades.TabIndex = 0x37;
            this.btnNovedades.Text = "&Novedades";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x404, 0x2f1);
            this.ClientSize = size;
            this.Controls.Add(this.btnNovedades);
            this.Controls.Add(this.CrystalReportViewer1);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmConsultaOV2";
            this.Text = "Consulta Ordenes de Venta";
            this.WindowState = FormWindowState.Maximized;
            this.ResumeLayout(false);
        }

        internal virtual Button btnNovedades
        {
            get
            {
                return this._btnNovedades;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnNovedades != null)
                {
                    this._btnNovedades.Click -= new EventHandler(this.btnNovedades_Click);
                }
                this._btnNovedades = value;
                if (this._btnNovedades != null)
                {
                    this._btnNovedades.Click += new EventHandler(this.btnNovedades_Click);
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

