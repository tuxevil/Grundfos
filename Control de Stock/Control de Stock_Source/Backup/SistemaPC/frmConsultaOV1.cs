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
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmConsultaOV1 : Form
    {
        [AccessedThroughProperty("btnActualizar")]
        private Button _btnActualizar;
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dgOV")]
        private DataGrid _dgOV;
        public SqlDataAdapter Adap;
        public SqlDataAdapter Adap1;
        private IContainer components;
        public DataSet DS;
        public DataSet DS1;
        public DataSet DS19;
        public DataSet DS2;
        public DataSet DS20;

        public frmConsultaOV1()
        {
            base.Load += new EventHandler(this.frmConsultaOV1_Load);
            base.Closed += new EventHandler(this.frmConsultaOV1_Closed);
            this.DS = new DataSet();
            this.DS1 = new DataSet();
            this.DS2 = new DataSet();
            this.DS19 = new DataSet();
            this.DS20 = new DataSet();
            this.InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            SqlConnection connection;
            SqlConnection connection2;
            DataSet dataSet = new DataSet();
            try
            {
                SqlCommand command;
                DataRow row;
                long num;
                SqlDataReader reader;
                string str4;
                connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
                connection2 = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
                connection2.Open();
                SqlCommand command4 = new SqlCommand("delete " + Variables.gTermi + "TmpConsOV", connection2);
                int num2 = command4.ExecuteNonQuery();
                string str = "SELECT distinct OR01001,OR01002,OR01004,SL01002,OR01072,OR01014,SL23004,OR04003,OR04004,OR04005,OR04008,OR01015,OR01023,OR19009,OR19011 FROM OR010100 INNER JOIN OR040100 ON OR010100.OR01001 = OR040100.OR04001 LEFT OUTER JOIN OR190100 ON OR010100.OR01001 = OR190100.OR19001 INNER JOIN SL010100 ON OR010100.OR01004 = SL010100.SL01001 INNER JOIN SL230100 ON OR010100.OR01014 = SL230100.SL23003 where OR01002<6 and OR190100.OR19003='000'";
                if ((StringType.StrCmp(Variables.gDesdeFechaOV, Strings.Space(0), false) != 0) & (StringType.StrCmp(Variables.gHastaFechaOV, Strings.Space(0), false) != 0))
                {
                    str = str + " and OR01015>='" + Strings.Format(DateType.FromString(Variables.gDesdeFechaOV), "MM/dd/yyyy") + "' and OR01015<='" + Strings.Format(DateType.FromString(Variables.gHastaFechaOV), "MM/dd/yyyy") + "'";
                }
                if ((StringType.StrCmp(Variables.gDesdeFechaEnt, Strings.Space(0), false) != 0) & (StringType.StrCmp(Variables.gHastaFechaEnt, Strings.Space(0), false) != 0))
                {
                    str = str + " and OR19009>='" + Strings.Format(DateType.FromString(Variables.gDesdeFechaEnt), "MM/dd/yyyy") + "' and OR19009<='" + Strings.Format(DateType.FromString(Variables.gHastaFechaEnt), "MM/dd/yyyy") + "'";
                }
                if (StringType.StrCmp(Variables.gCodCli, Strings.Space(0), false) != 0)
                {
                    str = str + " and OR01004='" + Variables.gCodCli + "'";
                }
                if (StringType.StrCmp(Variables.gNroOVCons, Strings.Space(0), false) != 0)
                {
                    str = str + " and OR01001='" + Variables.gNroOVCons + "'";
                }
                if (StringType.StrCmp(Variables.gNroOCCons, Strings.Space(0), false) != 0)
                {
                    str = str + " and OR01072='" + Variables.gNroOCCons + "'";
                }
                if (StringType.StrCmp(Variables.gNroRemito, Strings.Space(0), false) != 0)
                {
                    str = str + " and OR01023='" + Variables.gNroRemito + "'";
                }
                SqlCommand command2 = new SqlCommand(str + " and SL23001='2' and SL23002='00'", connection);
                command2.CommandTimeout = 500;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command2;
                connection.Open();
                adapter.Fill(this.DS1, "OR010100");
                long num4 = this.DS1.Tables["OR010100"].Rows.Count - 1;
                for (num = 0L; num <= num4; num += 1L)
                {
                    row = this.DS1.Tables["OR010100"].Rows[(int) num];
                    command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT NroOV FROM PrepPed where NroOV='", row["OR01001"]), "'")), connection2);
                    reader = command.ExecuteReader();
                    if (!reader.Read())
                    {
                        str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpConsOV (NroOV,TipoOV,Cliente,NomCli,OCompra,CodMetEnt,DescMetEnt,LugarEnt,FechaOV,FechaEnt,Remito,CodEstado,Estado) values ('", row["OR01001"]), "',"), row["OR01002"]), ",'"), row["OR01004"]), "','"), row["SL01002"]), "','"), row["OR01072"]), "',"), row["OR01014"]), ",'"), row["SL23004"]), "','"), Strings.Trim(StringType.FromObject(row["OR04003"]))), " "), Strings.Trim(StringType.FromObject(row["OR04004"]))), " "), Strings.Trim(StringType.FromObject(row["OR04005"]))), " "), Strings.Trim(StringType.FromObject(row["OR04008"]))), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01015"]), "MM/dd/yyyy")), "',"));
                        if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["OR19009"])))
                        {
                            str4 = str4 + "'" + Strings.Format(RuntimeHelpers.GetObjectValue(row["OR19009"]), "MM/dd/yyyy") + "',";
                        }
                        else
                        {
                            str4 = str4 + "Null,";
                        }
                        str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(str4 + "'", row["OR01023"]), "',")) + "1,'Pendiente de Entrega')";
                        reader.Close();
                        command4 = new SqlCommand(str4, connection2);
                        num2 = command4.ExecuteNonQuery();
                    }
                    else
                    {
                        reader.Close();
                        if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["OR19009"])))
                        {
                            command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT NroOV FROM PrepPed where NroOV='", row["OR01001"]), "' and FechaPrep='"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR19009"]), "MM/dd/yyyy")), "' and FechaExp is null")), connection2);
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpConsOV (NroOV,TipoOV,Cliente,NomCli,OCompra,CodMetEnt,DescMetEnt,LugarEnt,FechaOV,FechaEnt,FechaPrep,Remito,CodEstado,Estado) values ('", row["OR01001"]), "',"), row["OR01002"]), ",'"), row["OR01004"]), "','"), row["SL01002"]), "','"), row["OR01072"]), "',"), row["OR01014"]), ",'"), row["SL23004"]), "','"), Strings.Trim(StringType.FromObject(row["OR04003"]))), " "), Strings.Trim(StringType.FromObject(row["OR04004"]))), " "), Strings.Trim(StringType.FromObject(row["OR04005"]))), " "), Strings.Trim(StringType.FromObject(row["OR04008"]))), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR19009"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR19011"]), "MM/dd/yyyy")), "','"), row["OR01023"]), "',2,'Pendiente de Expedici\x00f3n')"));
                                reader.Close();
                                command4 = new SqlCommand(str4, connection2);
                                num2 = command4.ExecuteNonQuery();
                            }
                            else
                            {
                                reader.Close();
                            }
                            command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("Select Fecha from RecConfCliOV where NroOV='", row["OR01001"]), "'")), connection2);
                            reader = command.ExecuteReader();
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
                            command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT NroOV,FechaExp FROM PrepPed where NroOV='", row["OR01001"]), "' and FechaPrep='"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR19009"]), "MM/dd/yyyy")), "' and not FechaExp is null")), connection2);
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpConsOV (NroOV,TipoOV,Cliente,NomCli,OCompra,CodMetEnt,DescMetEnt,LugarEnt,FechaOV,FechaEnt,FechaPrep,FechaExp,Remito,CodEstado,Estado) values ('", row["OR01001"]), "',"), row["OR01002"]), ",'"), row["OR01004"]), "','"), row["SL01002"]), "','"), row["OR01072"]), "',"), row["OR01014"]), ",'"), row["SL23004"]), "','"), Strings.Trim(StringType.FromObject(row["OR04003"]))), " "), Strings.Trim(StringType.FromObject(row["OR04004"]))), " "), Strings.Trim(StringType.FromObject(row["OR04005"]))), " "), Strings.Trim(StringType.FromObject(row["OR04008"]))), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR19009"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR19011"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["FechaExp"]), "MM/dd/yyyy")), "',")) + "'", row["OR01023"]), "',"));
                                if (StringType.StrCmp(Variables.gFechaRecConfCli, "", false) == 0)
                                {
                                    str4 = str4 + "3,'Expedido')";
                                }
                                else
                                {
                                    str4 = str4 + "5,'Recepci\x00f3n Conformada')";
                                }
                                reader.Close();
                                command4 = new SqlCommand(str4, connection2);
                                num2 = command4.ExecuteNonQuery();
                            }
                            else
                            {
                                reader.Close();
                            }
                        }
                        else
                        {
                            command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT NroOV,FechaPrep FROM PrepPed where NroOV='", row["OR01001"]), "'")), connection2);
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj((StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpConsOV (NroOV,TipoOV,Cliente,NomCli,OCompra,CodMetEnt,DescMetEnt,LugarEnt,FechaOV,FechaEnt,FechaPrep,Remito,CodEstado,Estado) values ('", row["OR01001"]), "',"), row["OR01002"]), ",'"), row["OR01004"]), "','"), row["SL01002"]), "','"), row["OR01072"]), "',"), row["OR01014"]), ",'"), row["SL23004"]), "','"), Strings.Trim(StringType.FromObject(row["OR04003"]))), " "), Strings.Trim(StringType.FromObject(row["OR04004"]))), " "), Strings.Trim(StringType.FromObject(row["OR04005"]))), " "), Strings.Trim(StringType.FromObject(row["OR04008"]))), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01015"]), "MM/dd/yyyy")), "',")) + "Null,'" + Strings.Format(RuntimeHelpers.GetObjectValue(reader["FechaPrep"]), "MM/dd/yyyy") + "',") + "'", row["OR01023"]), "',")) + "4,'Prep.Pend.Imp.Doc.Exp.')";
                                reader.Close();
                                command4 = new SqlCommand(str4, connection2);
                                num2 = command4.ExecuteNonQuery();
                            }
                            else
                            {
                                reader.Close();
                            }
                        }
                    }
                }
                str = "SELECT distinct OR20001,OR20002,OR20004,SL01002,OR20072,OR20014,SL23004,OR22003,OR22004,OR22005,OR22008,OR20015,OR20023,OR23009,OR23011 from OR200100,OR220100,OR230100,SL010100,SL230100 where OR20002<6 and OR230100.OR23003='000'";
                if ((StringType.StrCmp(Variables.gDesdeFechaOV, Strings.Space(0), false) != 0) & (StringType.StrCmp(Variables.gHastaFechaOV, Strings.Space(0), false) != 0))
                {
                    str = str + " and OR20015>='" + Strings.Format(DateType.FromString(Variables.gDesdeFechaOV), "MM/dd/yyyy") + "' and OR20015<='" + Strings.Format(DateType.FromString(Variables.gHastaFechaOV), "MM/dd/yyyy") + "'";
                }
                if ((StringType.StrCmp(Variables.gDesdeFechaEnt, Strings.Space(0), false) != 0) & (StringType.StrCmp(Variables.gHastaFechaEnt, Strings.Space(0), false) != 0))
                {
                    str = str + " and OR23009>='" + Strings.Format(DateType.FromString(Variables.gDesdeFechaEnt), "MM/dd/yyyy") + "' and OR23009<='" + Strings.Format(DateType.FromString(Variables.gHastaFechaEnt), "MM/dd/yyyy") + "'";
                }
                if (StringType.StrCmp(Variables.gCodCli, Strings.Space(0), false) != 0)
                {
                    str = str + " and OR20004='" + Variables.gCodCli + "'";
                }
                if (StringType.StrCmp(Variables.gNroOVCons, Strings.Space(0), false) != 0)
                {
                    str = str + " and OR20001='" + Variables.gNroOVCons + "'";
                }
                if (StringType.StrCmp(Variables.gNroOCCons, Strings.Space(0), false) != 0)
                {
                    str = str + " and OR20072='" + Variables.gNroOCCons + "'";
                }
                if (StringType.StrCmp(Variables.gNroRemito, Strings.Space(0), false) != 0)
                {
                    str = str + " and OR20023='" + Variables.gNroRemito + "'";
                }
                command2 = new SqlCommand(str + " and OR20001=OR22001 and OR20001=OR23001 and OR20004=SL01001 and OR20014=SL23003 and SL23001='2' and SL23002='00'", connection);
                command2.CommandTimeout = 500;
                SqlDataAdapter adapter2 = new SqlDataAdapter();
                adapter2.SelectCommand = command2;
                adapter2.Fill(this.DS2, "OR200100");
                long num3 = this.DS2.Tables["OR200100"].Rows.Count - 1;
                for (num = 0L; num <= num3; num += 1L)
                {
                    row = this.DS2.Tables["OR200100"].Rows[(int) num];
                    command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT NroOV FROM PrepPed where NroOV='", row["OR20001"]), "'")), connection2);
                    reader = command.ExecuteReader();
                    if (!reader.Read())
                    {
                        str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpConsOV (NroOV,TipoOV,Cliente,NomCli,OCompra,CodMetEnt,DescMetEnt,LugarEnt,FechaOV,FechaEnt,Remito,CodEstado,Estado) values ('", row["OR20001"]), "',"), row["OR20002"]), ",'"), row["OR20004"]), "','"), row["SL01002"]), "','"), row["OR20072"]), "',"), row["OR20014"]), ",'"), row["SL23004"]), "','"), Strings.Trim(StringType.FromObject(row["OR22003"]))), " "), Strings.Trim(StringType.FromObject(row["OR22004"]))), " "), Strings.Trim(StringType.FromObject(row["OR22005"]))), " "), Strings.Trim(StringType.FromObject(row["OR22008"]))), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR20015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR23009"]), "MM/dd/yyyy")), "','"), row["OR20023"]), "',1,'Pendiente de Entrega')"));
                        reader.Close();
                        command4 = new SqlCommand(str4, connection2);
                        num2 = command4.ExecuteNonQuery();
                    }
                    else
                    {
                        reader.Close();
                        if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["OR23009"])))
                        {
                            command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT NroOV FROM PrepPed where NroOV='", row["OR20001"]), "' and FechaExp is null")), connection2);
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpConsOV (NroOV,TipoOV,Cliente,NomCli,OCompra,CodMetEnt,DescMetEnt,LugarEnt,FechaOV,FechaEnt,FechaPrep,Remito,CodEstado,Estado) values ('", row["OR20001"]), "',"), row["OR20002"]), ",'"), row["OR20004"]), "','"), row["SL01002"]), "','"), row["OR20072"]), "',"), row["OR20014"]), ",'"), row["SL23004"]), "','"), Strings.Trim(StringType.FromObject(row["OR22003"]))), " "), Strings.Trim(StringType.FromObject(row["OR22004"]))), " "), Strings.Trim(StringType.FromObject(row["OR22005"]))), " "), Strings.Trim(StringType.FromObject(row["OR22008"]))), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR20015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR23009"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR23011"]), "MM/dd/yyyy")), "','"), row["OR20023"]), "',2,'Pendiente de Expedici\x00f3n')"));
                                reader.Close();
                                command4 = new SqlCommand(str4, connection2);
                                num2 = command4.ExecuteNonQuery();
                            }
                            else
                            {
                                reader.Close();
                            }
                            command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("Select Fecha from RecConfCliOV where NroOV='", row["OR20001"]), "'")), connection2);
                            reader = command.ExecuteReader();
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
                            command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT NroOV,FechaExp FROM PrepPed where NroOV='", row["OR20001"]), "' and not FechaExp is null")), connection2);
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpConsOV (NroOV,TipoOV,Cliente,NomCli,OCompra,CodMetEnt,DescMetEnt,LugarEnt,FechaOV,FechaEnt,FechaPrep,FechaExp,Remito,CodEstado,Estado) values ('", row["OR20001"]), "',"), row["OR20002"]), ",'"), row["OR20004"]), "','"), row["SL01002"]), "','"), row["OR20072"]), "',"), row["OR20014"]), ",'"), row["SL23004"]), "','"), Strings.Trim(StringType.FromObject(row["OR22003"]))), " "), Strings.Trim(StringType.FromObject(row["OR22004"]))), " "), Strings.Trim(StringType.FromObject(row["OR22005"]))), " "), Strings.Trim(StringType.FromObject(row["OR22008"]))), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR20015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR23009"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR23011"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["FechaExp"]), "MM/dd/yyyy")), "','"), row["OR20023"]), "',"));
                                if (StringType.StrCmp(Variables.gFechaRecConfCli, "", false) == 0)
                                {
                                    str4 = str4 + "3,'Expedido')";
                                }
                                else
                                {
                                    str4 = str4 + "5,'Recepci\x00f3n Conformada')";
                                }
                                reader.Close();
                                command4 = new SqlCommand(str4, connection2);
                                num2 = command4.ExecuteNonQuery();
                            }
                            else
                            {
                                reader.Close();
                            }
                        }
                        else
                        {
                            reader = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT NroOV,FechaPrep FROM PrepPed where NroOV='", row["OR20001"]), "'")), connection2).ExecuteReader();
                            if (reader.Read())
                            {
                                str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj((StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpConsOV (NroOV,TipoOV,Cliente,NomCli,OCompra,CodMetEnt,DescMetEnt,LugarEnt,FechaOV,FechaEnt,FechaPrep,Remito,CodEstado,Estado) values ('", row["OR20001"]), "',"), row["OR20002"]), ",'"), row["OR20004"]), "','"), row["SL01002"]), "','"), row["OR20072"]), "',"), row["OR20014"]), ",'"), row["SL23004"]), "','"), Strings.Trim(StringType.FromObject(row["OR22003"]))), " "), Strings.Trim(StringType.FromObject(row["OR22004"]))), " "), Strings.Trim(StringType.FromObject(row["OR22005"]))), " "), Strings.Trim(StringType.FromObject(row["OR22008"]))), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR20015"]), "MM/dd/yyyy")), "',")) + "Null,'" + Strings.Format(RuntimeHelpers.GetObjectValue(reader["FechaPrep"]), "MM/dd/yyyy")) + "','", row["OR20023"]), "',")) + "4,'Prep.Pend.Imp.Doc.Exp.')";
                                reader.Close();
                                num2 = new SqlCommand(str4, connection2).ExecuteNonQuery();
                            }
                            else
                            {
                                reader.Close();
                            }
                        }
                    }
                }
                connection.Close();
                connection2.Close();
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
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
            SqlDataAdapter adapter3 = new SqlDataAdapter("SELECT distinct * from " + Variables.gTermi + "TmpConsOV order by FechaExp,FechaPrep,FechaEnt,FechaOV", selectConnectionString);
            dataSet.Clear();
            adapter3.Fill(dataSet, Variables.gTermi + "TmpConsOV");
            this.dgOV.DataSource = dataSet.Tables[Variables.gTermi + "TmpConsOV"];
            this.dgOV.Refresh();
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            if (StringType.StrCmp(Variables.gNroOV, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe seleccionar O.Venta", 0x10, "Operador");
                this.dgOV.Focus();
            }
            else
            {
                SqlDataAdapter adapter2;
                SqlCommand command;
                DataRow row;
                DataRow row2;
                int num;
                int num2;
                SqlDataReader reader;
                int num3;
                SqlCommand command5;
                string str5;
                this.dgOV.Enabled = false;
                this.cmbSalir.Enabled = false;
                this.cmbAceptar.Enabled = false;
                this.btnActualizar.Enabled = false;
                string connectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
                SqlConnection connection = new SqlConnection(connectionString);
                string str9 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
                SqlConnection connection2 = new SqlConnection(str9);
                connection2.Open();
                if ((Variables.gCodEstado == 1) | (Variables.gCodEstado == 4))
                {
                    command5 = new SqlCommand("delete " + Variables.gTermi + "TmpOVPend", connection2);
                    num3 = command5.ExecuteNonQuery();
                    string str3 = "SELECT SL01001,SL01002,SL01060,SL01075,OR01001,OR01015,OR01016,OR01091,OR01018,OR01072,OR03005,OR03006,OR03007,OR03011,OR03012,sum(SC03003) as SC03003,sum(SC03004+SC03005) as StkComp,OR010100.OR01079 FROM dbo.SL010100,dbo.OR010100,dbo.OR030100,dbo.SC030100 where OR010100.OR01002<>6 and OR03011-OR03012<>0 ";
                    str3 = str3 + "and SC03002='01' and OR01050='01'";
                    SqlCommand command4 = new SqlCommand((str3 + " and OR01001='" + Variables.gNroOV + "' and OR01002='" + StringType.FromInteger(Variables.gTipoOV) + "'") + " and OR01001=OR03001 and OR01004=SL01001 and OR03005=SC03001" + " group by SL01001,SL01002,SL01060,SL01075,OR01001,OR01015,OR01016,OR01091,OR01018,OR01072,OR03005,OR03006,OR03007,OR03011,OR03012,OR010100.OR01079", connection);
                    command4.CommandTimeout = 500;
                    SqlDataAdapter adapter3 = new SqlDataAdapter();
                    adapter3.SelectCommand = command4;
                    connection.Open();
                    adapter3.Fill(this.DS, "SC030100");
                    int num10 = this.DS.Tables["SC030100"].Rows.Count - 1;
                    for (num = 0; num <= num10; num++)
                    {
                        row = this.DS.Tables["SC030100"].Rows[num];
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
                            this.dgOV.Enabled = true;
                            this.cmbSalir.Enabled = true;
                            this.cmbAceptar.Enabled = true;
                            this.btnActualizar.Enabled = true;
                            ProjectData.ClearProjectError();
                            return;
                            ProjectData.ClearProjectError();
                        }
                    }
                    connection.Close();
                    connection2.Close();
                }
                if (Variables.gCodEstado == 2)
                {
                    SqlCommand command2;
                    SqlDataAdapter adapter = new SqlDataAdapter("select * from PrepPed where NroOV='" + Variables.gNroOV + "' and Expedicion='N' and NroRemito is null", str9);
                    adapter.Fill(this.DS, "PrepPed");
                    if (this.DS.Tables["PrepPed"].Rows.Count != 0)
                    {
                        int num9 = this.DS.Tables["PrepPed"].Rows.Count - 1;
                        for (num = 0; num <= num9; num++)
                        {
                            row = this.DS.Tables["PrepPed"].Rows[num];
                            adapter2 = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR19012 from OR190100 where OR19001='", row["NroOV"]), "' and OR19002='"), row["NroLinea"]), "' and OR19003='"), row["EstLinea"]), "' and OR19011='"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FechaPrep"]), "MM/dd/yyyy")), "' and OR19012<>'' order by OR19012")), connectionString);
                            this.DS19.Clear();
                            adapter2.Fill(this.DS19, "OR190100");
                            if (this.DS19.Tables["OR190100"].Rows.Count != 0)
                            {
                                int num8 = this.DS19.Tables["OR190100"].Rows.Count - 1;
                                num2 = 0;
                                while (num2 <= num8)
                                {
                                    row2 = this.DS19.Tables["OR190100"].Rows[num2];
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
                                        catch (Exception exception6)
                                        {
                                            ProjectData.SetProjectError(exception6);
                                            Exception exception2 = exception6;
                                            Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, 0, null);
                                            this.dgOV.Enabled = true;
                                            this.cmbSalir.Enabled = true;
                                            this.cmbAceptar.Enabled = true;
                                            this.btnActualizar.Enabled = true;
                                            connection.Close();
                                            connection2.Close();
                                            ProjectData.ClearProjectError();
                                            return;
                                            ProjectData.ClearProjectError();
                                        }
                                        break;
                                    }
                                    num2++;
                                }
                            }
                            else
                            {
                                adapter2 = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR23012 from OR230100 where OR23001='", row["NroOV"]), "' and OR23002='"), row["NroLinea"]), "' and OR23003='"), row["EstLinea"]), "' and OR23011='"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FechaPrep"]), "MM/dd/yyyy")), "' and OR23012<>'' order by OR23012")), connectionString);
                                this.DS20.Clear();
                                adapter2.Fill(this.DS20, "OR230100");
                                if (this.DS20.Tables["OR230100"].Rows.Count != 0)
                                {
                                    int num7 = this.DS20.Tables["OR230100"].Rows.Count - 1;
                                    num2 = 0;
                                    while (num2 <= num7)
                                    {
                                        row2 = this.DS20.Tables["OR230100"].Rows[num2];
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
                                            catch (Exception exception7)
                                            {
                                                ProjectData.SetProjectError(exception7);
                                                Exception exception3 = exception7;
                                                Interaction.MsgBox("Se ha producido el siguiente error:" + exception3.Message, 0, null);
                                                this.dgOV.Enabled = true;
                                                this.cmbSalir.Enabled = true;
                                                this.cmbAceptar.Enabled = true;
                                                this.btnActualizar.Enabled = true;
                                                connection.Close();
                                                connection2.Close();
                                                ProjectData.ClearProjectError();
                                                return;
                                                ProjectData.ClearProjectError();
                                            }
                                            break;
                                        }
                                        num2++;
                                    }
                                }
                            }
                        }
                    }
                    new SqlDataAdapter("select NroOV from PrepPed where NroOV='" + Variables.gNroOV + "' and Expedicion='N' and Producto=0 group by NroOV", str9).Fill(this.DS, "PrepPed");
                    if (this.DS.Tables["PrepPed"].Rows.Count != 0)
                    {
                        int num6 = this.DS.Tables["PrepPed"].Rows.Count - 1;
                        for (num = 0; num <= num6; num++)
                        {
                            row = this.DS.Tables["PrepPed"].Rows[num];
                            adapter2 = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR01015,OR01072 from OR010100 where OR01001='", row["NroOV"]), "'")), connectionString);
                            this.DS19.Clear();
                            adapter2.Fill(this.DS19, "OR190100");
                            if (this.DS19.Tables["OR190100"].Rows.Count != 0)
                            {
                                row2 = this.DS19.Tables["OR190100"].Rows[0];
                                try
                                {
                                    command2 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("update PrepPed set OCompra='", row2["OR01072"]), "',FechaOV='"), Strings.Format(RuntimeHelpers.GetObjectValue(row2["OR01015"]), "MM/dd/yyyy")), "' where NroOV='"), row["NroOV"]), "'")), connection2);
                                    num3 = command2.ExecuteNonQuery();
                                }
                                catch (Exception exception8)
                                {
                                    ProjectData.SetProjectError(exception8);
                                    Exception exception4 = exception8;
                                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception4.Message, 0, null);
                                    this.dgOV.Enabled = true;
                                    this.cmbSalir.Enabled = true;
                                    this.cmbAceptar.Enabled = true;
                                    this.btnActualizar.Enabled = true;
                                    connection.Close();
                                    connection2.Close();
                                    ProjectData.ClearProjectError();
                                    return;
                                    ProjectData.ClearProjectError();
                                }
                            }
                            else
                            {
                                adapter2 = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR20015,OR20072 from OR200100 where OR20001='", row["NroOV"]), "'")), connectionString);
                                this.DS20.Clear();
                                adapter2.Fill(this.DS20, "OR230100");
                                if (this.DS20.Tables["OR230100"].Rows.Count != 0)
                                {
                                    row2 = this.DS20.Tables["OR230100"].Rows[0];
                                    try
                                    {
                                        num3 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("update PrepPed set OCompra='", row2["OR20072"]), "',FechaOV='"), Strings.Format(RuntimeHelpers.GetObjectValue(row2["OR20015"]), "MM/dd/yyyy")), "' where NroOV='"), row["NroOV"]), "'")), connection2).ExecuteNonQuery();
                                    }
                                    catch (Exception exception9)
                                    {
                                        ProjectData.SetProjectError(exception9);
                                        Exception exception5 = exception9;
                                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception5.Message, 0, null);
                                        this.dgOV.Enabled = true;
                                        this.cmbSalir.Enabled = true;
                                        this.cmbAceptar.Enabled = true;
                                        this.btnActualizar.Enabled = true;
                                        connection.Close();
                                        connection2.Close();
                                        ProjectData.ClearProjectError();
                                        return;
                                        ProjectData.ClearProjectError();
                                    }
                                }
                            }
                        }
                    }
                    connection.Close();
                    connection2.Close();
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
                    adapter2 = new SqlDataAdapter("select OR19012,OR19034,OR01057,OR01058,OR01059,OR01060,OR03005,OR03006,OR03007,OR19030 from OR190100,OR010100,OR030100 where OR19001=OR01001 and OR19001=OR03001 AND OR19002=OR03002 AND OR19003=OR03003 and OR19001='" + Variables.gNroOV + "' and OR01002='" + StringType.FromInteger(Variables.gTipoOV) + "' and OR19011='" + Strings.Format(DateType.FromString(Variables.gFechaPrep), "MM/dd/yyyy") + "' and OR19012<>''", connectionString);
                    this.DS19.Clear();
                    adapter2.Fill(this.DS19, "OR190100");
                    if (this.DS19.Tables["OR190100"].Rows.Count != 0)
                    {
                        int num5 = this.DS19.Tables["OR190100"].Rows.Count - 1;
                        for (num2 = 0; num2 <= num5; num2++)
                        {
                            row2 = this.DS19.Tables["OR190100"].Rows[num2];
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
                        adapter2 = new SqlDataAdapter("select OR23012,OR23034,OR20057,OR20058,OR20059,OR20060,OR21005,OR21006,OR21007,OR23030 from OR230100,OR200100,OR210100 where OR23001=OR20001 and OR23001=OR21001 AND OR23002=OR21002 AND OR23003=OR21003 and OR23001='" + Variables.gNroOV + "' and OR20002='" + StringType.FromInteger(Variables.gTipoOV) + "' and OR23011='" + Strings.Format(DateType.FromString(Variables.gFechaPrep), "MM/dd/yyyy") + "' and OR23012<>''", connectionString);
                        this.DS20.Clear();
                        adapter2.Fill(this.DS20, "OR200100");
                        if (this.DS20.Tables["OR200100"].Rows.Count != 0)
                        {
                            int num4 = this.DS20.Tables["OR200100"].Rows.Count - 1;
                            for (num2 = 0; num2 <= num4; num2++)
                            {
                                row2 = this.DS20.Tables["OR200100"].Rows[num2];
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
                }
                frmConsultaOV2 aov = new frmConsultaOV2();
                this.Hide();
                aov.Show();
            }
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgPrepPed_ChangeUICues(object sender, UICuesEventArgs e)
        {
        }

        private void dgPrepPed_Click(object sender, EventArgs e)
        {
            if (this.DS.Tables[Variables.gTermi + "TmpConsOV"].Rows.Count != 0)
            {
                Variables.gNroOV = StringType.FromObject(this.dgOV[this.dgOV.CurrentCell.RowNumber, 0]);
                Variables.gTipoOV = IntegerType.FromObject(this.dgOV[this.dgOV.CurrentCell.RowNumber, 1]);
                Variables.gCliente = StringType.FromObject(this.dgOV[this.dgOV.CurrentCell.RowNumber, 2]);
                Variables.gNomCli = StringType.FromObject(this.dgOV[this.dgOV.CurrentCell.RowNumber, 3]);
                Variables.gNroOC = StringType.FromObject(this.dgOV[this.dgOV.CurrentCell.RowNumber, 4]);
                Variables.gCodMetEnt = StringType.FromObject(this.dgOV[this.dgOV.CurrentCell.RowNumber, 5]);
                Variables.gDescMetEnt = StringType.FromObject(this.dgOV[this.dgOV.CurrentCell.RowNumber, 6]);
                Variables.gFechaOV = DateType.FromObject(this.dgOV[this.dgOV.CurrentCell.RowNumber, 7]);
                if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.dgOV[this.dgOV.CurrentCell.RowNumber, 8])))
                {
                    Variables.gFechaEntOV = "";
                }
                else
                {
                    Variables.gFechaEntOV = StringType.FromObject(this.dgOV[this.dgOV.CurrentCell.RowNumber, 8]);
                }
                if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.dgOV[this.dgOV.CurrentCell.RowNumber, 9])))
                {
                    Variables.gFechaPrep = "";
                }
                else
                {
                    Variables.gFechaPrep = StringType.FromObject(this.dgOV[this.dgOV.CurrentCell.RowNumber, 9]);
                }
                if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.dgOV[this.dgOV.CurrentCell.RowNumber, 10])))
                {
                    Variables.gFechaExp = "";
                }
                else
                {
                    Variables.gFechaExp = StringType.FromObject(this.dgOV[this.dgOV.CurrentCell.RowNumber, 10]);
                }
                Variables.gNroRemito = StringType.FromObject(this.dgOV[this.dgOV.CurrentCell.RowNumber, 11]);
                Variables.gCodEstado = IntegerType.FromObject(this.dgOV[this.dgOV.CurrentCell.RowNumber, 12]);
                Variables.gEstado = StringType.FromObject(this.dgOV[this.dgOV.CurrentCell.RowNumber, 13]);
                Variables.gLugarEnt = StringType.FromObject(this.dgOV[this.dgOV.CurrentCell.RowNumber, 14]);
            }
        }

        private void dgPrepPed_Navigate(object sender, NavigateEventArgs ne)
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

        ~frmConsultaOV1()
        {
        }

        private void frmConsultaOV1_Closed(object sender, EventArgs e)
        {
            new frmConsultaOV().Show();
        }

        private void frmConsultaOV1_Load(object sender, EventArgs e)
        {
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
            new SqlDataAdapter("SELECT distinct * from " + Variables.gTermi + "TmpConsOV order by FechaExp,FechaPrep,FechaEnt,FechaOV", selectConnectionString).Fill(this.DS, Variables.gTermi + "TmpConsOV");
            this.dgOV.DataSource = this.DS.Tables[Variables.gTermi + "TmpConsOV"];
            DataGridTableStyle table = new DataGridTableStyle();
            table.MappingName = Variables.gTermi + "TmpConsOV";
            DataGridTextBoxColumn column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column16 = column;
            column16.HeaderText = "N\x00b0 OV";
            column16.MappingName = "NroOV";
            column16.Width = 70;
            column16 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column15 = column;
            column15.HeaderText = "Tipo OV";
            column15.MappingName = "TipoOV";
            column15.Alignment = HorizontalAlignment.Center;
            column15.Width = 50;
            column15 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column14 = column;
            column14.HeaderText = "";
            column14.MappingName = "Cliente";
            column14.Width = 0;
            column14 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column13 = column;
            column13.HeaderText = "Cliente";
            column13.MappingName = "NomCli";
            column13.Width = 180;
            column13 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column12 = column;
            column12.HeaderText = "O.Compra";
            column12.MappingName = "OCompra";
            column12.Width = 100;
            column12 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column11 = column;
            column11.HeaderText = "";
            column11.MappingName = "CodMetEnt";
            column11.Width = 0;
            column11 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column10 = column;
            column10.HeaderText = "M\x00e9todo Entrega";
            column10.MappingName = "DescMetEnt";
            column10.Width = 130;
            column10 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column9 = column;
            column9.HeaderText = "Fecha OV";
            column9.MappingName = "FechaOV";
            column9.Format = "dd/MM/yyyy";
            column9.Width = 0x41;
            column9 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column8 = column;
            column8.HeaderText = "F.Prev.Ent.";
            column8.MappingName = "FechaEnt";
            column8.Format = "dd/MM/yyyy";
            column8.NullText = "";
            column8.Width = 0x41;
            column8 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column7 = column;
            column7.HeaderText = "Fecha Prep.";
            column7.MappingName = "FechaPrep";
            column7.Format = "dd/MM/yyyy";
            column7.NullText = "";
            column7.Width = 0x41;
            column7 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column6 = column;
            column6.HeaderText = "Fecha Exp.";
            column6.MappingName = "FechaExp";
            column6.Format = "dd/MM/yyyy";
            column6.NullText = "";
            column6.Width = 0x41;
            column6 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column5 = column;
            column5.HeaderText = "Remito";
            column5.MappingName = "Remito";
            column5.NullText = "";
            column5.Width = 0x55;
            column5 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column4 = column;
            column4.HeaderText = "";
            column4.MappingName = "CodEstado";
            column4.Width = 0;
            column4 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column3 = column;
            column3.HeaderText = "Estado";
            column3.MappingName = "Estado";
            column3.Width = 150;
            column3 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column2 = column;
            column2.HeaderText = "Lugar de Entrega";
            column2.MappingName = "LugarEnt";
            column2.Width = 400;
            column2 = null;
            table.GridColumnStyles.Add(column);
            this.dgOV.TableStyles.Add(table);
            this.dgOV.Refresh();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmConsultaOV1));
            this.cmbSalir = new Button();
            this.dgOV = new DataGrid();
            this.cmbAceptar = new Button();
            this.btnActualizar = new Button();
            this.dgOV.BeginInit();
            this.SuspendLayout();
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            this.cmbSalir.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Point point = new Point(0x328, 0x270);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            Size size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 3;
            this.cmbSalir.Text = "&Salir";
            this.dgOV.CaptionFont = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dgOV.CaptionText = "Ordenes de Venta";
            this.dgOV.DataMember = "";
            this.dgOV.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dgOV.HeaderFont = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dgOV.HeaderForeColor = SystemColors.ControlText;
            point = new Point(8, 0x10);
            this.dgOV.Location = point;
            this.dgOV.Name = "dgOV";
            this.dgOV.ReadOnly = true;
            size = new Size(0x3f0, 0x250);
            this.dgOV.Size = size;
            this.dgOV.TabIndex = 0;
            this.cmbAceptar.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(920, 0x270);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 1;
            this.cmbAceptar.Text = "&Aceptar";
            this.btnActualizar.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x270);
            this.btnActualizar.Location = point;
            this.btnActualizar.Name = "btnActualizar";
            size = new Size(0x60, 40);
            this.btnActualizar.Size = size;
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "A&ctualizar";
            size = new Size(6, 15);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x2d5);
            this.ClientSize = size;
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.dgOV);
            this.Controls.Add(this.cmbSalir);
            this.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmConsultaOV1";
            this.Text = "Consulta Ordenes de Venta";
            this.WindowState = FormWindowState.Maximized;
            this.dgOV.EndInit();
            this.ResumeLayout(false);
        }

        internal virtual Button btnActualizar
        {
            get
            {
                return this._btnActualizar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnActualizar != null)
                {
                    this._btnActualizar.Click -= new EventHandler(this.btnActualizar_Click);
                }
                this._btnActualizar = value;
                if (this._btnActualizar != null)
                {
                    this._btnActualizar.Click += new EventHandler(this.btnActualizar_Click);
                }
            }
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

        internal virtual DataGrid dgOV
        {
            get
            {
                return this._dgOV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dgOV != null)
                {
                    this._dgOV.Click -= new EventHandler(this.dgPrepPed_Click);
                    this._dgOV.ChangeUICues -= new UICuesEventHandler(this.dgPrepPed_ChangeUICues);
                    this._dgOV.Navigate -= new NavigateEventHandler(this.dgPrepPed_Navigate);
                }
                this._dgOV = value;
                if (this._dgOV != null)
                {
                    this._dgOV.Click += new EventHandler(this.dgPrepPed_Click);
                    this._dgOV.ChangeUICues += new UICuesEventHandler(this.dgPrepPed_ChangeUICues);
                    this._dgOV.Navigate += new NavigateEventHandler(this.dgPrepPed_Navigate);
                }
            }
        }
    }
}

