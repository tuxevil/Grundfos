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

    public class frmPrepPed1 : Form
    {
        [AccessedThroughProperty("btnActualizar")]
        private Button _btnActualizar;
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dgPrepPed")]
        private DataGrid _dgPrepPed;
        [AccessedThroughProperty("editNroOV")]
        private TextBox _editNroOV;
        [AccessedThroughProperty("editTipoOV")]
        private TextBox _editTipoOV;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("Label6")]
        private Label _Label6;
        public SqlDataAdapter Adap;
        public SqlDataAdapter Adap1;
        private IContainer components;
        public DataSet DS;
        public DataSet DS1;
        public DataSet DS19;
        public DataSet DS2;
        public DataSet DS20;
        public string mImpreso;
        public bool mNoExiste;

        public frmPrepPed1()
        {
            base.Load += new EventHandler(this.frmPrepPed1_Load);
            base.Closed += new EventHandler(this.frmPrepPed1_Closed);
            this.DS = new DataSet();
            this.DS1 = new DataSet();
            this.DS2 = new DataSet();
            this.DS19 = new DataSet();
            this.DS20 = new DataSet();
            this.InitializeComponent();
        }

        private void ActTmp()
        {
            DataRow row;
            DataRow row2;
            int num;
            string str3;
            string connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
            string selectConnectionString = connectionString;
            SqlConnection connection2 = new SqlConnection(connectionString);
            connection2.Open();
            SqlCommand command = new SqlCommand("delete " + Variables.gTermi + "TmpEAPrepPed", connection2);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                connection2.Close();
                ProjectData.ClearProjectError();
                return;
                ProjectData.ClearProjectError();
            }
            connectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=True;packet size=4096";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string cmdText = "SELECT DISTINCT OR010100.OR01014,SL230100.SL23004,OR010100.OR01001,OR010100.OR01002,OR010100.OR01016,OR010100.OR01079,SL010100.SL01002,OR010100.OR01005,OR010100.OR01006 FROM dbo.OR010100,dbo.OR030100,dbo.SL010100,dbo.SL230100 where (OR010100.OR01002=1 or OR010100.OR01002=2 or OR010100.OR01002=4 or OR010100.OR01002=5) and OR030100.OR03011-OR030100.OR03012<>0 AND OR010100.OR01004=SL010100.SL01001 AND OR010100.OR01001=OR030100.OR03001 and SL010100.SL01060=0 and OR010100.OR01091=0 and OR01050='01' and OR010100.OR01014=SL230100.SL23003 and SL230100.SL23001='2' and SL230100.SL23002='00' and OR030100.OR03034=0";
            if (StringType.StrCmp(Variables.gDesde, "", false) == 0)
            {
                cmdText = cmdText + " and OR010100.OR01016<='" + Strings.Format(DateType.FromString(Variables.gHasta), "MM/dd/yyyy") + "'";
            }
            else
            {
                cmdText = cmdText + " and OR010100.OR01016>='" + Strings.Format(DateType.FromString(Variables.gDesde), "MM/dd/yyyy") + "' and OR010100.OR01016<='" + Strings.Format(DateType.FromString(Variables.gHasta), "MM/dd/yyyy") + "'";
            }
            command = new SqlCommand(cmdText + " and OR01021='' and OR01023='' order by SL230100.SL23004,OR010100.OR01001", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmdText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpEAPrepPed (CodMetEnt,DescMetEnt,NroOV,TipoOV,FechaEnt,DespParcial,LineasOV,LineasConStk,LineasPrep,Cliente,Observa1,Observa2,Impreso,Color) values (", reader["OR01014"]), ",'"), reader["SL23004"]), "','"), reader["OR01001"]), "',"), reader["OR01002"]), ",'"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR01016"]), "MM/dd/yyyy")), "',"));
                if (ObjectType.ObjTst(reader["OR01079"], 0, false) == 0)
                {
                    cmdText = cmdText + "'S',0,0,0,";
                }
                else
                {
                    cmdText = cmdText + "'N',0,0,0,";
                }
                command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(cmdText + "'", reader["SL01002"]), "','"), reader["OR01005"]), "','"), reader["OR01006"]), "','N',' ')")), connection2);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception exception14)
                {
                    ProjectData.SetProjectError(exception14);
                    Exception exception2 = exception14;
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, 0, null);
                    reader.Close();
                    connection.Close();
                    connection2.Close();
                    ProjectData.ClearProjectError();
                    return;
                    ProjectData.ClearProjectError();
                }
            }
            reader.Close();
            cmdText = "SELECT DISTINCT OR010100.OR01014,SL230100.SL23004,OR010100.OR01001,OR010100.OR01002,OR010100.OR01016,OR010100.OR01079,SL010100.SL01002,OR010100.OR01005,OR010100.OR01006 FROM dbo.OR010100,dbo.OR030100,dbo.SL010100,dbo.SL230100 where OR010100.OR01002=6 and OR030100.OR03011-OR030100.OR03012<>0 AND OR010100.OR01004='INTR04' and OR010100.OR01004=SL010100.SL01001 AND OR010100.OR01001=OR030100.OR03001 and SL010100.SL01060=0 and OR010100.OR01091=0 and OR01050='01' and OR010100.OR01014=SL230100.SL23003 and SL230100.SL23001='2' and SL230100.SL23002='00' and OR030100.OR03034=0";
            if (StringType.StrCmp(Variables.gDesde, "", false) == 0)
            {
                cmdText = cmdText + " and OR010100.OR01016<='" + Strings.Format(DateType.FromString(Variables.gHasta), "MM/dd/yyyy") + "'";
            }
            else
            {
                cmdText = cmdText + " and OR010100.OR01016>='" + Strings.Format(DateType.FromString(Variables.gDesde), "MM/dd/yyyy") + "' and OR010100.OR01016<='" + Strings.Format(DateType.FromString(Variables.gHasta), "MM/dd/yyyy") + "'";
            }
            command = new SqlCommand(cmdText + " and OR01021='' and OR01023='' order by SL230100.SL23004,OR010100.OR01001", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmdText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpEAPrepPed (CodMetEnt,DescMetEnt,NroOV,TipoOV,FechaEnt,DespParcial,LineasOV,LineasConStk,LineasPrep,Cliente,Observa1,Observa2,Impreso,Color) values (", reader["OR01014"]), ",'"), reader["SL23004"]), "','"), reader["OR01001"]), "',"), reader["OR01002"]), ",'"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR01016"]), "MM/dd/yyyy")), "',"));
                if (ObjectType.ObjTst(reader["OR01079"], 0, false) == 0)
                {
                    cmdText = cmdText + "'S',0,0,0,";
                }
                else
                {
                    cmdText = cmdText + "'N',0,0,0,";
                }
                command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(cmdText + "'", reader["SL01002"]), "','"), reader["OR01005"]), "','"), reader["OR01006"]), "','N',' ')")), connection2);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception exception15)
                {
                    ProjectData.SetProjectError(exception15);
                    Exception exception3 = exception15;
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception3.Message, 0, null);
                    reader.Close();
                    connection.Close();
                    connection2.Close();
                    ProjectData.ClearProjectError();
                    return;
                    ProjectData.ClearProjectError();
                }
            }
            reader.Close();
            command = new SqlCommand("SELECT NroOV,TipoOV from " + Variables.gTermi + "TmpEAPrepPed", connection2);
            command.CommandTimeout = 500;
            this.Adap1 = new SqlDataAdapter();
            this.Adap1.SelectCommand = command;
            this.DS2.Clear();
            this.Adap1.Fill(this.DS2, Variables.gTermi + "TmpEAPrepPed");
            int num24 = this.DS2.Tables[Variables.gTermi + "TmpEAPrepPed"].Rows.Count - 1;
            int num2 = 0;
            while (num2 <= num24)
            {
                string str;
                row2 = this.DS2.Tables[Variables.gTermi + "TmpEAPrepPed"].Rows[num2];
                str3 = StringType.FromObject(row2["NroOV"]);
                double num10 = 0.0;
                bool flag = true;
                int num11 = 0;
                int num14 = 0;
                int num7 = 0;
                int num3 = 0;
                int num5 = 0;
                cmdText = "SELECT SC030100.SC03001,SC030100.SC03003,OR03002,OR03003,OR030100.OR03011,OR030100.OR03012,OR010100.OR01079 FROM dbo.OR030100,OR010100,SC030100 where OR03001='" + str3 + "' and OR03011-OR03012<>0 and OR030100.OR03005=SC030100.SC03001 and OR030100.OR03046=SC030100.SC03002 and SC030100.SC03002='01' and OR030100.OR03001=OR010100.OR01001 and OR030100.OR03034=0 order by OR03002,OR03003";
                command = new SqlCommand(cmdText, connection);
                command.CommandTimeout = 500;
                this.Adap = new SqlDataAdapter();
                this.Adap.SelectCommand = command;
                this.DS1.Clear();
                this.Adap.Fill(this.DS1, "SC030100");
                int num23 = this.DS1.Tables["SC030100"].Rows.Count - 1;
                for (num = 0; num <= num23; num++)
                {
                    SqlDataReader reader2;
                    double num9;
                    double num13;
                    row = this.DS1.Tables["SC030100"].Rows[num];
                    if (ObjectType.ObjTst(row["OR03003"], "000", false) == 0)
                    {
                        num14++;
                        num10 = DoubleType.FromObject(row["SC03003"]);
                        num13 = 0.0;
                        num9 = DoubleType.FromObject(ObjectType.SubObj(row["OR03011"], row["OR03012"]));
                        str = StringType.FromObject(row["OR01079"]);
                        num7++;
                        cmdText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT sum(SC030100.SC03003) as Stock FROM dbo.SC030100 where SC03001='", row["SC03001"]), "' and SC03002<>'01' and SC03002<>'02'"));
                        command = new SqlCommand(cmdText, connection);
                        reader2 = command.ExecuteReader();
                        if (reader2.Read() && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(reader2["Stock"])))
                        {
                            num13 = DoubleType.FromObject(ObjectType.AddObj(num13, reader2["Stock"]));
                        }
                        reader2.Close();
                        if (num10 == 0.0)
                        {
                            num11++;
                        }
                        if (num10 < num9)
                        {
                            flag = false;
                        }
                        else if (num10 >= num9)
                        {
                            num3++;
                        }
                        if ((num10 + num13) >= num9)
                        {
                            num5++;
                        }
                    }
                    else
                    {
                        string str2 = StringType.FromObject(row["OR03002"]);
                        str = StringType.FromObject(row["OR01079"]);
                        int num12 = 0;
                        int num15 = 0;
                        int num4 = 0;
                        int num6 = 0;
                        while (BooleanType.FromObject(ObjectType.BitAndObj(ObjectType.ObjTst(row["OR03002"], str2, false) == 0, num <= (this.DS1.Tables["SC030100"].Rows.Count - 1))))
                        {
                            num15++;
                            num10 = DoubleType.FromObject(row["SC03003"]);
                            num13 = 0.0;
                            num9 = DoubleType.FromObject(ObjectType.SubObj(row["OR03011"], row["OR03012"]));
                            cmdText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT sum(SC030100.SC03003) as Stock FROM dbo.SC030100 where SC03001='", row["SC03001"]), "' and SC03002<>'01' and SC03002<>'02'"));
                            command = new SqlCommand(cmdText, connection);
                            reader2 = command.ExecuteReader();
                            if (reader2.Read() && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(reader2["Stock"])))
                            {
                                num13 = DoubleType.FromObject(ObjectType.AddObj(num13, reader2["Stock"]));
                            }
                            if (num10 == 0.0)
                            {
                                num12++;
                            }
                            if (num10 < num9)
                            {
                                flag = false;
                            }
                            else if (num10 >= num9)
                            {
                                num4++;
                            }
                            if ((num10 + num13) >= num9)
                            {
                                num6++;
                            }
                            reader2.Close();
                            num++;
                            if (num <= (this.DS1.Tables["SC030100"].Rows.Count - 1))
                            {
                                row = this.DS1.Tables["SC030100"].Rows[num];
                            }
                        }
                        if (num15 == num12)
                        {
                            num11++;
                        }
                        if (num15 == num4)
                        {
                            num3++;
                        }
                        num14++;
                        num7++;
                        num--;
                    }
                }
                if (num14 == num11)
                {
                    command = new SqlCommand("delete " + Variables.gTermi + "TmpEAPrepPed where NroOV='" + str3 + "'", connection2);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception16)
                    {
                        ProjectData.SetProjectError(exception16);
                        Exception exception4 = exception16;
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception4.Message, 0, null);
                        reader.Close();
                        connection.Close();
                        connection2.Close();
                        ProjectData.ClearProjectError();
                        return;
                        ProjectData.ClearProjectError();
                    }
                }
                else if (!flag & (DoubleType.FromString(str) == 1.0))
                {
                    command = new SqlCommand("delete " + Variables.gTermi + "TmpEAPrepPed where NroOV='" + str3 + "'", connection2);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception17)
                    {
                        ProjectData.SetProjectError(exception17);
                        Exception exception5 = exception17;
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception5.Message, 0, null);
                        reader.Close();
                        connection.Close();
                        connection2.Close();
                        ProjectData.ClearProjectError();
                        return;
                        ProjectData.ClearProjectError();
                    }
                }
                else
                {
                    if (num7 == num3)
                    {
                        cmdText = StringType.FromObject(ObjectType.StrCatObj(((("update " + Variables.gTermi + "TmpEAPrepPed set DespParcial=' ',LineasOV=") + StringType.FromInteger(num7) + ",LineasConStk=") + StringType.FromInteger(num3) + ",Color='V' where NroOV='") + str3 + "' and TipoOV=", row2["TipoOV"]));
                    }
                    else if (num3 == 0)
                    {
                        if (num7 == num5)
                        {
                            cmdText = StringType.FromObject(ObjectType.StrCatObj(((("update " + Variables.gTermi + "TmpEAPrepPed set DespParcial='S',LineasOV=") + StringType.FromInteger(num7) + ",LineasConStk=") + StringType.FromInteger(num3) + ",Color='R' where NroOV='") + str3 + "' and TipoOV=", row2["TipoOV"]));
                        }
                        else if (num5 == 0)
                        {
                            cmdText = StringType.FromObject(ObjectType.StrCatObj(((("update " + Variables.gTermi + "TmpEAPrepPed set DespParcial='N',LineasOV=") + StringType.FromInteger(num7) + ",LineasConStk=") + StringType.FromInteger(num3) + ",Color='R' where NroOV='") + str3 + "' and TipoOV=", row2["TipoOV"]));
                        }
                        else if ((num7 != num5) & (num5 != 0))
                        {
                            cmdText = StringType.FromObject(ObjectType.StrCatObj(((("update " + Variables.gTermi + "TmpEAPrepPed set DespParcial='N',LineasOV=") + StringType.FromInteger(num7) + ",LineasConStk=") + StringType.FromInteger(num3) + ",Color='R' where NroOV='") + str3 + "' and TipoOV=", row2["TipoOV"]));
                        }
                    }
                    else if ((num7 != num3) & (num3 != 0))
                    {
                        if (num7 == num5)
                        {
                            cmdText = StringType.FromObject(ObjectType.StrCatObj(((("update " + Variables.gTermi + "TmpEAPrepPed set DespParcial='S',LineasOV=") + StringType.FromInteger(num7) + ",LineasConStk=") + StringType.FromInteger(num3) + ",Color='A' where NroOV='") + str3 + "' and TipoOV=", row2["TipoOV"]));
                        }
                        else if (num5 == 0)
                        {
                            cmdText = StringType.FromObject(ObjectType.StrCatObj(((("update " + Variables.gTermi + "TmpEAPrepPed set DespParcial='N',LineasOV=") + StringType.FromInteger(num7) + ",LineasConStk=") + StringType.FromInteger(num3) + ",Color='A' where NroOV='") + str3 + "' and TipoOV=", row2["TipoOV"]));
                        }
                        else if ((num7 != num5) & (num5 != 0))
                        {
                            cmdText = StringType.FromObject(ObjectType.StrCatObj(((("update " + Variables.gTermi + "TmpEAPrepPed set DespParcial='N',LineasOV=") + StringType.FromInteger(num7) + ",LineasConStk=") + StringType.FromInteger(num3) + ",Color='A' where NroOV='") + str3 + "' and TipoOV=", row2["TipoOV"]));
                        }
                    }
                    command = new SqlCommand(cmdText, connection2);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception18)
                    {
                        ProjectData.SetProjectError(exception18);
                        Exception exception6 = exception18;
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception6.Message, 0, null);
                        reader.Close();
                        connection.Close();
                        connection2.Close();
                        ProjectData.ClearProjectError();
                        return;
                        ProjectData.ClearProjectError();
                    }
                }
                num2++;
            }
            this.DS1.Clear();
            string selectCommandText = "select * from PrepPed where Expedicion='N' and NroRemito is null";
            new SqlDataAdapter(selectCommandText, selectConnectionString).Fill(this.DS1, "PrepPed");
            if (this.DS1.Tables["PrepPed"].Rows.Count != 0)
            {
                int num22 = this.DS1.Tables["PrepPed"].Rows.Count - 1;
                num = 0;
                while (num <= num22)
                {
                    SqlCommand command2;
                    int num16;
                    row = this.DS1.Tables["PrepPed"].Rows[num];
                    SqlDataAdapter adapter2 = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR19012 from OR190100 where OR19001='", row["NroOV"]), "' and OR19002='"), row["NroLinea"]), "' and OR19003='"), row["EstLinea"]), "' and OR19011='"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FechaPrep"]), "MM/dd/yyyy")), "' and OR19012<>'' order by OR19012")), connectionString);
                    this.DS19.Clear();
                    adapter2.Fill(this.DS19, "OR190100");
                    if (this.DS19.Tables["OR190100"].Rows.Count != 0)
                    {
                        int num21 = this.DS19.Tables["OR190100"].Rows.Count - 1;
                        num2 = 0;
                        while (num2 <= num21)
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
                                    num16 = command2.ExecuteNonQuery();
                                }
                                catch (Exception exception19)
                                {
                                    ProjectData.SetProjectError(exception19);
                                    Exception exception7 = exception19;
                                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception7.Message, 0, null);
                                    this.cmbAceptar.Enabled = true;
                                    this.cmbSalir.Enabled = true;
                                    connection2.Close();
                                    this.cmbAceptar.Focus();
                                    ProjectData.ClearProjectError();
                                    return;
                                    ProjectData.ClearProjectError();
                                }
                            }
                            num2++;
                        }
                    }
                    else
                    {
                        string str5;
                        if (ObjectType.ObjTst(row["Producto"], 1, false) == 0)
                        {
                            command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR19012 from OR190100 where OR19001='", row["NroOV"]), "' and OR19002='"), row["NroLinea"]), "' and OR19003<>'000' and OR19011='"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FechaPrep"]), "MM/dd/yyyy")), "' and OR19012<>'' order by OR19012")), connection);
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                try
                                {
                                    str5 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("update PrepPed set NroRemito='", reader["OR19012"]), "' where NroOV='"), row["NroOV"]), "' and NroLinea='"), row["NroLinea"]), "' and TipoLinea="), row["TipoLinea"]), " and EstLinea='"), row["EstLinea"]), "' and NroRemito is null"));
                                    reader.Close();
                                    command2 = new SqlCommand(str5, connection2);
                                    num16 = command2.ExecuteNonQuery();
                                }
                                catch (Exception exception20)
                                {
                                    ProjectData.SetProjectError(exception20);
                                    Exception exception8 = exception20;
                                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception8.Message, 0, null);
                                    this.cmbAceptar.Enabled = true;
                                    this.cmbSalir.Enabled = true;
                                    connection2.Close();
                                    this.cmbAceptar.Focus();
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
                        else
                        {
                            adapter2 = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR23012 from OR230100 where OR23001='", row["NroOV"]), "' and OR23002='"), row["NroLinea"]), "' and OR23003='"), row["EstLinea"]), "' and OR23011='"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FechaPrep"]), "MM/dd/yyyy")), "' and OR23012<>'' order by OR23012")), connectionString);
                            this.DS20.Clear();
                            adapter2.Fill(this.DS20, "OR230100");
                            if (this.DS20.Tables["OR230100"].Rows.Count != 0)
                            {
                                int num20 = this.DS20.Tables["OR230100"].Rows.Count - 1;
                                num2 = 0;
                                while (num2 <= num20)
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
                                            num16 = command2.ExecuteNonQuery();
                                        }
                                        catch (Exception exception21)
                                        {
                                            ProjectData.SetProjectError(exception21);
                                            Exception exception9 = exception21;
                                            Interaction.MsgBox("Se ha producido el siguiente error:" + exception9.Message, 0, null);
                                            this.cmbAceptar.Enabled = true;
                                            this.cmbSalir.Enabled = true;
                                            connection2.Close();
                                            this.cmbAceptar.Focus();
                                            ProjectData.ClearProjectError();
                                            return;
                                            ProjectData.ClearProjectError();
                                        }
                                    }
                                    num2++;
                                }
                            }
                            else if (ObjectType.ObjTst(row["Producto"], 1, false) == 0)
                            {
                                reader = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR23012 from OR230100 where OR23001='", row["NroOV"]), "' and OR23002='"), row["NroLinea"]), "' and OR23003<>'000' and OR23011='"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FechaPrep"]), "MM/dd/yyyy")), "' and OR23012<>'' order by OR23012")), connection).ExecuteReader();
                                if (reader.Read())
                                {
                                    try
                                    {
                                        str5 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("update PrepPed set NroRemito='", reader["OR23012"]), "' where NroOV='"), row["NroOV"]), "' and NroLinea='"), row["NroLinea"]), "' and TipoLinea="), row["TipoLinea"]), " and EstLinea='"), row["EstLinea"]), "' and NroRemito is null"));
                                        reader.Close();
                                        num16 = new SqlCommand(str5, connection2).ExecuteNonQuery();
                                    }
                                    catch (Exception exception22)
                                    {
                                        ProjectData.SetProjectError(exception22);
                                        Exception exception10 = exception22;
                                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception10.Message, 0, null);
                                        this.cmbAceptar.Enabled = true;
                                        this.cmbSalir.Enabled = true;
                                        connection2.Close();
                                        this.cmbAceptar.Focus();
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
                        }
                    }
                    num++;
                }
            }
            command = new SqlCommand("SELECT NroOV,TipoOV from " + Variables.gTermi + "TmpEAPrepPed", connection2);
            command.CommandTimeout = 500;
            this.Adap1 = new SqlDataAdapter();
            this.Adap1.SelectCommand = command;
            this.DS2.Clear();
            this.Adap1.Fill(this.DS2, Variables.gTermi + "TmpEAPrepPed");
            int num19 = this.DS2.Tables[Variables.gTermi + "TmpEAPrepPed"].Rows.Count - 1;
            for (num2 = 0; num2 <= num19; num2++)
            {
                row2 = this.DS2.Tables[Variables.gTermi + "TmpEAPrepPed"].Rows[num2];
                str3 = StringType.FromObject(row2["NroOV"]);
                int num8 = 0;
                command = new SqlCommand("SELECT distinct NroLinea FROM dbo.PrepPed where NroOV='" + str3 + "' and (NroRemito is null or NroOV=NroRemito)", connection2);
                command.CommandTimeout = 500;
                this.Adap = new SqlDataAdapter();
                this.Adap.SelectCommand = command;
                this.DS1.Clear();
                this.Adap.Fill(this.DS1, "PrepPed");
                int num18 = this.DS1.Tables["PrepPed"].Rows.Count - 1;
                for (num = 0; num <= num18; num++)
                {
                    row = this.DS1.Tables["PrepPed"].Rows[num];
                    num8++;
                }
                if (num8 != 0)
                {
                    command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj((("update " + Variables.gTermi + "TmpEAPrepPed set LineasPrep=") + StringType.FromInteger(num8) + " where NroOV='") + str3 + "' and TipoOV=", row2["TipoOV"])), connection2);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception23)
                    {
                        ProjectData.SetProjectError(exception23);
                        Exception exception11 = exception23;
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception11.Message, 0, null);
                        reader.Close();
                        connection.Close();
                        connection2.Close();
                        ProjectData.ClearProjectError();
                        return;
                        ProjectData.ClearProjectError();
                    }
                }
            }
            command = new SqlCommand("delete " + Variables.gTermi + "TmpEAPrepPed where LineasOV=LineasPrep", connection2);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception exception24)
            {
                ProjectData.SetProjectError(exception24);
                Exception exception12 = exception24;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception12.Message, 0, null);
                reader.Close();
                connection.Close();
                connection2.Close();
                ProjectData.ClearProjectError();
                return;
                ProjectData.ClearProjectError();
            }
            command = new SqlCommand("SELECT NroOV,TipoOV from " + Variables.gTermi + "TmpEAPrepPed", connection2);
            command.CommandTimeout = 500;
            this.Adap1 = new SqlDataAdapter();
            this.Adap1.SelectCommand = command;
            this.DS2.Clear();
            this.Adap1.Fill(this.DS2, Variables.gTermi + "TmpEAPrepPed");
            int num17 = this.DS2.Tables[Variables.gTermi + "TmpEAPrepPed"].Rows.Count - 1;
            for (num2 = 0; num2 <= num17; num2++)
            {
                row2 = this.DS2.Tables[Variables.gTermi + "TmpEAPrepPed"].Rows[num2];
                str3 = StringType.FromObject(row2["NroOV"]);
                command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj("SELECT * FROM dbo.ImpEAPrePed where NroOV='" + str3 + "' and TipoOV=", row2["TipoOV"])), connection2);
                command.CommandTimeout = 500;
                this.Adap = new SqlDataAdapter();
                this.Adap.SelectCommand = command;
                this.DS1.Clear();
                this.Adap.Fill(this.DS1, "ImpEAPrePed");
                if (this.DS1.Tables["ImpEAPrePed"].Rows.Count != 0)
                {
                    command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(("update " + Variables.gTermi + "TmpEAPrepPed set Impreso='S',Color='N' where NroOV='") + str3 + "' and TipoOV=", row2["TipoOV"])), connection2);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception25)
                    {
                        ProjectData.SetProjectError(exception25);
                        Exception exception13 = exception25;
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception13.Message, 0, null);
                        reader.Close();
                        connection.Close();
                        connection2.Close();
                        ProjectData.ClearProjectError();
                        return;
                        ProjectData.ClearProjectError();
                    }
                }
            }
            connection2.Close();
            connection.Close();
        }

        private void btnActualizar_ChangeUICues(object sender, UICuesEventArgs e)
        {
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.btnActualizar.Enabled = false;
            this.cmbSalir.Enabled = false;
            this.cmbAceptar.Enabled = false;
            this.ActTmp();
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from " + Variables.gTermi + "TmpEAPrepPed order by DescMetEnt,FechaEnt,NroOV,TipoOV", selectConnectionString);
            this.DS.Clear();
            adapter.Fill(this.DS, Variables.gTermi + "TmpEAPrepPed");
            this.dgPrepPed.DataSource = this.DS.Tables[Variables.gTermi + "TmpEAPrepPed"];
            this.dgPrepPed.Refresh();
            Variables.gNroOV = StringType.FromInteger(0);
            this.btnActualizar.Enabled = true;
            this.cmbSalir.Enabled = true;
            this.cmbAceptar.Enabled = true;
            this.dgPrepPed.Focus();
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            if (DoubleType.FromString(Variables.gNroOV) == 0.0)
            {
                Interaction.MsgBox("Debe seleccionar O.Venta", 0x10, "Operador");
                this.dgPrepPed.Focus();
            }
            else if ((StringType.StrCmp(this.mImpreso, "S", false) == 0) && (Interaction.MsgBox("De esta O.Venta ya se imprimieron etiquetas, desea imprimir etiquetas nuevamente?", 4, "Operador") == 7))
            {
                this.dgPrepPed.Focus();
            }
            else
            {
                SqlDataAdapter adapter;
                SqlConnection connection2;
                DataRow row;
                string str3;
                this.cmbSalir.Enabled = false;
                SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=True;packet size=4096");
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT OR01005,OR01006,OR01016,OR01021,OR01023 FROM dbo.OR010100 where OR01001='" + Variables.gNroOV + "' and OR01002=" + StringType.FromInteger(Variables.gTipoOV) + " and OR01021='' and OR01023=''", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Variables.gFechaEnt = DateType.FromObject(reader["OR01016"]);
                    Variables.gObserva1 = StringType.FromObject(reader["OR01005"]);
                    Variables.gObserva2 = StringType.FromObject(reader["OR01006"]);
                    reader.Close();
                }
                else
                {
                    reader.Close();
                    connection.Close();
                    Interaction.MsgBox("Esta O.Venta no se puede preparar", 0x40, "Operador");
                    this.dgPrepPed.Enabled = true;
                    this.cmbSalir.Enabled = true;
                    this.dgPrepPed.Focus();
                    return;
                }
                if (this.mNoExiste)
                {
                    str3 = "SELECT OR030100.OR03001,OR030100.OR03002,OR030100.OR03003,OR030100.OR03004,OR030100.OR03005,OR030100.OR03006,OR030100.OR03007,OR030100.OR03011,OR030100.OR03012,OR030100.OR03034,OR030100.OR03046,SC030100.SC03003,SC030100.SC03013,SL230100.SL23004,SL010100.SL01002 FROM dbo.OR010100,dbo.OR030100,SC030100,dbo.SL010100,dbo.SL230100 where OR03001='" + Variables.gNroOV + "' and OR030100.OR03005=SC030100.SC03001 and OR030100.OR03046=SC030100.SC03002 and SC030100.SC03002='01' and OR010100.OR01004=SL010100.SL01001 AND OR010100.OR01001=OR030100.OR03001 and OR010100.OR01014=SL230100.SL23003 and SL230100.SL23001='2' and SL230100.SL23002='00'";
                }
                else
                {
                    str3 = "SELECT OR030100.OR03001,OR030100.OR03002,OR030100.OR03003,OR030100.OR03004,OR030100.OR03005,OR030100.OR03006,OR030100.OR03007,OR030100.OR03011,OR030100.OR03012,OR030100.OR03034,OR030100.OR03046,SC030100.SC03003,SC030100.SC03013,SL230100.SL23004,SL010100.SL01002 FROM dbo.OR010100,dbo.OR030100,SC030100,dbo.SL010100,dbo.SL230100 where OR03001='" + Variables.gNroOV + "' and OR03011-OR03012<>0 and OR030100.OR03005=SC030100.SC03001 and OR030100.OR03046=SC030100.SC03002 and SC030100.SC03002='01' and OR010100.OR01004=SL010100.SL01001 AND OR010100.OR01001=OR030100.OR03001 and OR010100.OR01014=SL230100.SL23003 and SL230100.SL23001='2' and SL230100.SL23002='00'";
                }
                command = new SqlCommand(str3, connection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int num3;
                    Variables.gDescMetEnt = StringType.FromObject(reader["SL23004"]);
                    Variables.gCliente = StringType.FromObject(reader["SL01002"]);
                    connection2 = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096");
                    connection2.Open();
                    SqlCommand command2 = new SqlCommand("delete " + Variables.gTermi + "TmpPrepPed", connection2);
                    try
                    {
                        num3 = command2.ExecuteNonQuery();
                    }
                    catch (Exception exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        Exception exception = exception1;
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                        reader.Close();
                        connection.Close();
                        connection2.Close();
                        ProjectData.ClearProjectError();
                        return;
                        ProjectData.ClearProjectError();
                    }
                    reader.Close();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        str3 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(("insert into " + Variables.gTermi + "TmpPrepPed (NroOV,NroLinea,TipoLinea,EstLinea,Codigo,Desc1,Desc2,Almacen,CantOrden,CantPrep,Stock,Producto,Estante,Stock03,Stock04,Stock05,Stock06,Stock07,Stock08,Stock09) values ('" + Variables.gNroOV) + "','", reader["OR03002"]), "',"), reader["OR03004"]), ",'"), reader["OR03003"]), "','"), reader["OR03005"]), "','"), reader["OR03006"]), "','"), reader["OR03007"]), "','"), reader["OR03046"]), "',"));
                        if (ObjectType.ObjTst(reader["OR03004"], 0, false) == 0)
                        {
                            str3 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(str3, ObjectType.SubObj(reader["OR03011"], reader["OR03012"])), ",0,"));
                        }
                        else if (ObjectType.ObjTst(reader["OR03004"], 1, false) == 0)
                        {
                            str3 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(str3, ObjectType.SubObj(reader["OR03011"], reader["OR03012"])), ","), ObjectType.SubObj(reader["OR03011"], reader["OR03012"])), ","));
                        }
                        command2 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(str3, reader["SC03003"]), ",")), reader["OR03034"]), ",")) + "'", reader["SC03013"]), "',0,0,0,0,0,0,0)")), connection2);
                        try
                        {
                            num3 = command2.ExecuteNonQuery();
                        }
                        catch (Exception exception5)
                        {
                            ProjectData.SetProjectError(exception5);
                            Exception exception2 = exception5;
                            Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, 0, null);
                            reader.Close();
                            connection.Close();
                            connection2.Close();
                            ProjectData.ClearProjectError();
                            return;
                            ProjectData.ClearProjectError();
                        }
                    }
                    reader.Close();
                    command = new SqlCommand("SELECT * from " + Variables.gTermi + "TmpPrepPed order by Codigo", connection2);
                    command.CommandTimeout = 500;
                    adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(this.DS, Variables.gTermi + "TmpPrepPed");
                    int num5 = this.DS.Tables[Variables.gTermi + "TmpPrepPed"].Rows.Count - 1;
                    for (int j = 0; j <= num5; j++)
                    {
                        row = this.DS.Tables[Variables.gTermi + "TmpPrepPed"].Rows[j];
                        command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT SC030100.SC03002,SC030100.SC03003 FROM dbo.SC030100 where SC03001='", row["Codigo"]), "' and SC03002<>'01' and SC03002<>'02'")), connection);
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string str2 = StringType.FromObject(reader["SC03002"]);
                            if (DoubleType.FromString(str2) > 9.0)
                            {
                                break;
                            }
                            if (ObjectType.ObjTst(reader["SC03003"], 0, false) != 0)
                            {
                                command2 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(("update " + Variables.gTermi + "TmpPrepPed set Stock") + str2 + "=", reader["SC03003"]), " where Codigo='"), row["Codigo"]), "'")), connection2);
                                try
                                {
                                    num3 = command2.ExecuteNonQuery();
                                }
                                catch (Exception exception6)
                                {
                                    ProjectData.SetProjectError(exception6);
                                    Exception exception3 = exception6;
                                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception3.Message, 0, null);
                                    reader.Close();
                                    connection.Close();
                                    connection2.Close();
                                    ProjectData.ClearProjectError();
                                    return;
                                    ProjectData.ClearProjectError();
                                }
                            }
                        }
                        reader.Close();
                    }
                }
                else
                {
                    reader.Close();
                    connection.Close();
                    Interaction.MsgBox("Nro.O.Venta inexistente", 0x40, "Operador");
                    this.dgPrepPed.Enabled = true;
                    this.cmbSalir.Enabled = true;
                    this.dgPrepPed.Focus();
                    return;
                }
                command = new SqlCommand("SELECT NroOV,NroLinea from " + Variables.gTermi + "TmpPrepPed", connection2);
                command.CommandTimeout = 500;
                this.Adap1 = new SqlDataAdapter();
                this.Adap1.SelectCommand = command;
                this.DS2.Clear();
                this.Adap1.Fill(this.DS2, Variables.gTermi + "TmpPrepPed");
                int num4 = this.DS2.Tables[Variables.gTermi + "TmpPrepPed"].Rows.Count - 1;
                for (int i = 0; i <= num4; i++)
                {
                    DataRow row2 = this.DS2.Tables[Variables.gTermi + "TmpPrepPed"].Rows[i];
                    command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT sum(CantPrep) as CantPrep FROM dbo.PrepPed where NroOV='", row2["NroOV"]), "' and NroLinea='"), row2["NroLinea"]), "' and NroRemito is null")), connection2);
                    command.CommandTimeout = 500;
                    adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    this.DS1.Clear();
                    adapter.Fill(this.DS1, "PrepPed");
                    if (this.DS1.Tables["PrepPed"].Rows.Count != 0)
                    {
                        row = this.DS1.Tables["PrepPed"].Rows[0];
                        if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["CantPrep"])))
                        {
                            command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("update " + Variables.gTermi + "TmpPrepPed set CantPrep=", row["CantPrep"]), " where NroOV='"), row2["NroOV"]), "' and NroLinea='"), row2["NroLinea"]), "'")), connection2);
                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            catch (Exception exception7)
                            {
                                ProjectData.SetProjectError(exception7);
                                Exception exception4 = exception7;
                                Interaction.MsgBox("Se ha producido el siguiente error:" + exception4.Message, 0, null);
                                reader.Close();
                                connection.Close();
                                connection2.Close();
                                ProjectData.ClearProjectError();
                                return;
                                ProjectData.ClearProjectError();
                            }
                        }
                    }
                }
                connection2.Close();
                connection.Close();
                new frmPrepPed2().ShowDialog();
                string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT * from " + Variables.gTermi + "TmpEAPrepPed order by DescMetEnt,FechaEnt,NroOV,TipoOV", selectConnectionString);
                this.DS.Clear();
                adapter2.Fill(this.DS, Variables.gTermi + "TmpEAPrepPed");
                this.dgPrepPed.DataSource = this.DS.Tables[Variables.gTermi + "TmpEAPrepPed"];
                this.dgPrepPed.Refresh();
                this.cmbSalir.Enabled = true;
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
            if (this.DS.Tables[Variables.gTermi + "TmpEAPrepPed"].Rows.Count != 0)
            {
                this.mImpreso = StringType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 0]);
                Variables.gCodMetEnt = StringType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 1]);
                Variables.gDescMetEnt = StringType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 2]);
                Variables.gNroOV = StringType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 3]);
                Variables.gTipoOV = IntegerType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 4]);
                Variables.gFechaEnt = DateType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 5]);
                Variables.gCliente = StringType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 10]);
                Variables.gObserva1 = StringType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 11]);
                Variables.gObserva2 = StringType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 12]);
                Variables.gColor = StringType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 13]);
                this.mNoExiste = false;
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

        private void editNroOV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editTipoOV.Focus();
            }
        }

        private void editNroOV_LostFocus(object sender, EventArgs e)
        {
        }

        private void editNroOV_TextChanged(object sender, EventArgs e)
        {
        }

        private void editTipoOV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.dgPrepPed.Focus();
            }
        }

        private void editTipoOV_LostFocus(object sender, EventArgs e)
        {
            bool flag = false;
            if ((StringType.StrCmp(this.editNroOV.Text, Strings.Space(0), false) != 0) & (StringType.StrCmp(this.editTipoOV.Text, Strings.Space(0), false) != 0))
            {
                this.editNroOV.Text = Strings.Format(Conversion.Val(this.editNroOV.Text), "0000000000");
                int num2 = this.DS.Tables[Variables.gTermi + "TmpEAPrepPed"].Rows.Count - 1;
                for (int i = 0; i <= num2; i++)
                {
                    DataRow row = this.DS.Tables[Variables.gTermi + "TmpEAPrepPed"].Rows[i];
                    if (BooleanType.FromObject(ObjectType.BitAndObj(ObjectType.ObjTst(row["NroOV"], this.editNroOV.Text, false) == 0, ObjectType.ObjTst(row["TipoOV"], this.editTipoOV.Text, false) == 0)))
                    {
                        this.dgPrepPed.CurrentRowIndex = i;
                        this.dgPrepPed.Select(i);
                        this.mImpreso = StringType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 0]);
                        Variables.gCodMetEnt = StringType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 1]);
                        Variables.gDescMetEnt = StringType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 2]);
                        Variables.gNroOV = StringType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 3]);
                        Variables.gTipoOV = IntegerType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 4]);
                        Variables.gFechaEnt = DateType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 5]);
                        Variables.gCliente = StringType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 10]);
                        Variables.gObserva1 = StringType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 11]);
                        Variables.gObserva2 = StringType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 12]);
                        Variables.gColor = StringType.FromObject(this.dgPrepPed[this.dgPrepPed.CurrentCell.RowNumber, 13]);
                        flag = true;
                        this.mNoExiste = false;
                        break;
                    }
                }
                if (!flag)
                {
                    this.mNoExiste = true;
                    this.mImpreso = "N";
                    Variables.gNroOV = this.editNroOV.Text;
                    Variables.gTipoOV = IntegerType.FromString(this.editTipoOV.Text);
                    Variables.gColor = " ";
                    this.cmbAceptar.Focus();
                }
            }
        }

        private void editTipoOV_TextAlignChanged(object sender, EventArgs e)
        {
        }

        private void editTipoOV_TextChanged(object sender, EventArgs e)
        {
        }

        private void EstablecerColores(PaintRowEventArgs args)
        {
            object objectValue = RuntimeHelpers.GetObjectValue(this.dgPrepPed[args.RowNumber, 13]);
            object obj3 = objectValue;
            if (ObjectType.ObjTst(obj3, "N", false) == 0)
            {
                args.ForeColor = Brushes.Black;
            }
            else if (ObjectType.ObjTst(obj3, "R", false) == 0)
            {
                args.ForeColor = Brushes.Red;
            }
            else if (ObjectType.ObjTst(obj3, "V", false) == 0)
            {
                args.ForeColor = Brushes.Green;
            }
            else if (ObjectType.ObjTst(obj3, "A", false) == 0)
            {
                args.ForeColor = Brushes.Blue;
            }
        }

        ~frmPrepPed1()
        {
        }

        private void frmPrepPed1_Closed(object sender, EventArgs e)
        {
            new frmPrepPed().Show();
        }

        private void frmPrepPed1_Load(object sender, EventArgs e)
        {
            this.ActTmp();
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
            new SqlDataAdapter("SELECT * from " + Variables.gTermi + "TmpEAPrepPed order by DescMetEnt,FechaEnt,NroOV,TipoOV", selectConnectionString).Fill(this.DS, Variables.gTermi + "TmpEAPrepPed");
            this.dgPrepPed.DataSource = this.DS.Tables[Variables.gTermi + "TmpEAPrepPed"];
            DataGridTableStyle table = new DataGridTableStyle();
            table.MappingName = Variables.gTermi + "TmpEAPrepPed";
            CustomDataGridTextBoxColumn column = new CustomDataGridTextBoxColumn();
            CustomDataGridTextBoxColumn column15 = column;
            column15.HeaderText = "Prep.";
            column15.MappingName = "Impreso";
            column15.Alignment = HorizontalAlignment.Center;
            column15.Width = 40;
            column15 = null;
            column.PaintRow += new CustomDataGridTextBoxColumn.PaintRowEventHandler(this.EstablecerColores);
            table.GridColumnStyles.Add(column);
            column = new CustomDataGridTextBoxColumn();
            CustomDataGridTextBoxColumn column14 = column;
            column14.HeaderText = "";
            column14.MappingName = "CodMetEnt";
            column14.Width = 0;
            column14 = null;
            column.PaintRow += new CustomDataGridTextBoxColumn.PaintRowEventHandler(this.EstablecerColores);
            table.GridColumnStyles.Add(column);
            column = new CustomDataGridTextBoxColumn();
            CustomDataGridTextBoxColumn column13 = column;
            column13.HeaderText = "M\x00e9todo Entrega";
            column13.MappingName = "DescMetEnt";
            column13.Width = 140;
            column13 = null;
            column.PaintRow += new CustomDataGridTextBoxColumn.PaintRowEventHandler(this.EstablecerColores);
            table.GridColumnStyles.Add(column);
            column = new CustomDataGridTextBoxColumn();
            CustomDataGridTextBoxColumn column12 = column;
            column12.HeaderText = "N\x00b0 OV";
            column12.MappingName = "NroOV";
            column12.Width = 70;
            column12 = null;
            column.PaintRow += new CustomDataGridTextBoxColumn.PaintRowEventHandler(this.EstablecerColores);
            table.GridColumnStyles.Add(column);
            column = new CustomDataGridTextBoxColumn();
            CustomDataGridTextBoxColumn column11 = column;
            column11.HeaderText = "Tipo OV";
            column11.MappingName = "TipoOV";
            column11.Width = 70;
            column11 = null;
            column.PaintRow += new CustomDataGridTextBoxColumn.PaintRowEventHandler(this.EstablecerColores);
            table.GridColumnStyles.Add(column);
            column = new CustomDataGridTextBoxColumn();
            CustomDataGridTextBoxColumn column10 = column;
            column10.HeaderText = "F.Entrega";
            column10.MappingName = "FechaEnt";
            column10.Format = "dd/MM/yyyy";
            column10.Width = 70;
            column10 = null;
            column.PaintRow += new CustomDataGridTextBoxColumn.PaintRowEventHandler(this.EstablecerColores);
            table.GridColumnStyles.Add(column);
            column = new CustomDataGridTextBoxColumn();
            CustomDataGridTextBoxColumn column9 = column;
            column9.HeaderText = "Stk Ot.Al.";
            column9.MappingName = "DespParcial";
            column9.Alignment = HorizontalAlignment.Center;
            column9.Width = 70;
            column9 = null;
            column.PaintRow += new CustomDataGridTextBoxColumn.PaintRowEventHandler(this.EstablecerColores);
            table.GridColumnStyles.Add(column);
            column = new CustomDataGridTextBoxColumn();
            CustomDataGridTextBoxColumn column8 = column;
            column8.HeaderText = "L\x00edneas OV";
            column8.MappingName = "LineasOV";
            column8.Format = "##0";
            column8.Width = 70;
            column8 = null;
            column.PaintRow += new CustomDataGridTextBoxColumn.PaintRowEventHandler(this.EstablecerColores);
            table.GridColumnStyles.Add(column);
            column = new CustomDataGridTextBoxColumn();
            CustomDataGridTextBoxColumn column7 = column;
            column7.HeaderText = "L\x00edneas con Stk";
            column7.MappingName = "LineasConStk";
            column7.Format = "##0";
            column7.Width = 70;
            column7 = null;
            column.PaintRow += new CustomDataGridTextBoxColumn.PaintRowEventHandler(this.EstablecerColores);
            table.GridColumnStyles.Add(column);
            column = new CustomDataGridTextBoxColumn();
            CustomDataGridTextBoxColumn column6 = column;
            column6.HeaderText = "L\x00edneas Prep.";
            column6.MappingName = "LineasPrep";
            column6.Format = "##0";
            column6.Width = 70;
            column6 = null;
            column.PaintRow += new CustomDataGridTextBoxColumn.PaintRowEventHandler(this.EstablecerColores);
            table.GridColumnStyles.Add(column);
            column = new CustomDataGridTextBoxColumn();
            CustomDataGridTextBoxColumn column5 = column;
            column5.HeaderText = "Cliente";
            column5.MappingName = "Cliente";
            column5.Width = 220;
            column5 = null;
            column.PaintRow += new CustomDataGridTextBoxColumn.PaintRowEventHandler(this.EstablecerColores);
            table.GridColumnStyles.Add(column);
            column = new CustomDataGridTextBoxColumn();
            CustomDataGridTextBoxColumn column4 = column;
            column4.HeaderText = "Observaciones";
            column4.MappingName = "Observa1";
            column4.Width = 210;
            column4 = null;
            column.PaintRow += new CustomDataGridTextBoxColumn.PaintRowEventHandler(this.EstablecerColores);
            table.GridColumnStyles.Add(column);
            column = new CustomDataGridTextBoxColumn();
            CustomDataGridTextBoxColumn column3 = column;
            column3.HeaderText = "Observaciones";
            column3.MappingName = "Observa2";
            column3.Width = 210;
            column3 = null;
            column.PaintRow += new CustomDataGridTextBoxColumn.PaintRowEventHandler(this.EstablecerColores);
            table.GridColumnStyles.Add(column);
            column = new CustomDataGridTextBoxColumn();
            CustomDataGridTextBoxColumn column2 = column;
            column2.HeaderText = "";
            column2.MappingName = "Color";
            column2.Width = 0;
            column2 = null;
            column.PaintRow += new CustomDataGridTextBoxColumn.PaintRowEventHandler(this.EstablecerColores);
            table.GridColumnStyles.Add(column);
            this.dgPrepPed.TableStyles.Add(table);
            this.dgPrepPed.Refresh();
            Variables.gNroOV = StringType.FromInteger(0);
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmPrepPed1));
            this.cmbSalir = new Button();
            this.dgPrepPed = new DataGrid();
            this.cmbAceptar = new Button();
            this.btnActualizar = new Button();
            this.Label6 = new Label();
            this.editNroOV = new TextBox();
            this.editTipoOV = new TextBox();
            this.Label1 = new Label();
            this.Label2 = new Label();
            this.Label3 = new Label();
            this.Label4 = new Label();
            this.dgPrepPed.BeginInit();
            this.SuspendLayout();
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            this.cmbSalir.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Point point = new Point(920, 0x270);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            Size size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 3;
            this.cmbSalir.Text = "&Salir";
            this.dgPrepPed.CaptionFont = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dgPrepPed.CaptionText = "Ordenes de Venta";
            this.dgPrepPed.DataMember = "";
            this.dgPrepPed.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dgPrepPed.HeaderFont = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dgPrepPed.HeaderForeColor = SystemColors.ControlText;
            point = new Point(8, 8);
            this.dgPrepPed.Location = point;
            this.dgPrepPed.Name = "dgPrepPed";
            this.dgPrepPed.ReadOnly = true;
            size = new Size(0x3f0, 600);
            this.dgPrepPed.Size = size;
            this.dgPrepPed.TabIndex = 0;
            this.cmbAceptar.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(920, 0x2a0);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 1;
            this.cmbAceptar.Text = "&Aceptar";
            this.btnActualizar.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0xb8, 0x270);
            this.btnActualizar.Location = point;
            this.btnActualizar.Name = "btnActualizar";
            size = new Size(0x60, 40);
            this.btnActualizar.Size = size;
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "A&ctualizar";
            this.Label6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x268);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(80, 0x17);
            this.Label6.Size = size;
            this.Label6.TabIndex = 4;
            this.Label6.Text = "Nro.O.Venta:";
            this.editNroOV.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 640);
            this.editNroOV.Location = point;
            this.editNroOV.MaxLength = 10;
            this.editNroOV.Name = "editNroOV";
            size = new Size(0x70, 20);
            this.editNroOV.Size = size;
            this.editNroOV.TabIndex = 5;
            this.editNroOV.Text = "";
            this.editTipoOV.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x80, 640);
            this.editTipoOV.Location = point;
            this.editTipoOV.MaxLength = 1;
            this.editTipoOV.Name = "editTipoOV";
            size = new Size(40, 20);
            this.editTipoOV.Size = size;
            this.editTipoOV.TabIndex = 6;
            this.editTipoOV.Text = "";
            point = new Point(0x130, 0x268);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0xc0, 0x18);
            this.Label1.Size = size;
            this.Label1.TabIndex = 7;
            this.Label1.Text = "Negro =  Etiqueta ya impresa";
            this.Label2.ForeColor = Color.Green;
            point = new Point(0x1f8, 0x268);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x160, 0x18);
            this.Label2.Size = size;
            this.Label2.TabIndex = 8;
            this.Label2.Text = "Verde = Se pueden preparar todas las l\x00edneas de la Orden";
            this.Label3.ForeColor = Color.Blue;
            point = new Point(0x130, 640);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x1a0, 0x18);
            this.Label3.Size = size;
            this.Label3.TabIndex = 9;
            this.Label3.Text = "Azul = Solo se pueden preparar algunas l\x00edneas de la Orden";
            this.Label4.ForeColor = Color.Red;
            point = new Point(0x130, 0x298);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(0x200, 0x18);
            this.Label4.Size = size;
            this.Label4.TabIndex = 10;
            this.Label4.Text = "Rojo = NO IMPRIMIR ETIQUETA.  No se puede preparar ninguna  l\x00ednea de la Orden";
            size = new Size(6, 15);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x404, 0x2f1);
            this.ClientSize = size;
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.editTipoOV);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.editNroOV);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.dgPrepPed);
            this.Controls.Add(this.cmbSalir);
            this.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmPrepPed1";
            this.Text = "Preparaci\x00f3n de Pedidos";
            this.WindowState = FormWindowState.Maximized;
            this.dgPrepPed.EndInit();
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
                    this._btnActualizar.ChangeUICues -= new UICuesEventHandler(this.btnActualizar_ChangeUICues);
                }
                this._btnActualizar = value;
                if (this._btnActualizar != null)
                {
                    this._btnActualizar.Click += new EventHandler(this.btnActualizar_Click);
                    this._btnActualizar.ChangeUICues += new UICuesEventHandler(this.btnActualizar_ChangeUICues);
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

        internal virtual DataGrid dgPrepPed
        {
            get
            {
                return this._dgPrepPed;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dgPrepPed != null)
                {
                    this._dgPrepPed.ChangeUICues -= new UICuesEventHandler(this.dgPrepPed_ChangeUICues);
                    this._dgPrepPed.Navigate -= new NavigateEventHandler(this.dgPrepPed_Navigate);
                    this._dgPrepPed.Click -= new EventHandler(this.dgPrepPed_Click);
                }
                this._dgPrepPed = value;
                if (this._dgPrepPed != null)
                {
                    this._dgPrepPed.ChangeUICues += new UICuesEventHandler(this.dgPrepPed_ChangeUICues);
                    this._dgPrepPed.Navigate += new NavigateEventHandler(this.dgPrepPed_Navigate);
                    this._dgPrepPed.Click += new EventHandler(this.dgPrepPed_Click);
                }
            }
        }

        internal virtual TextBox editNroOV
        {
            get
            {
                return this._editNroOV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editNroOV != null)
                {
                    this._editNroOV.KeyPress -= new KeyPressEventHandler(this.editNroOV_KeyPress);
                    this._editNroOV.TextChanged -= new EventHandler(this.editNroOV_TextChanged);
                    this._editNroOV.LostFocus -= new EventHandler(this.editNroOV_LostFocus);
                }
                this._editNroOV = value;
                if (this._editNroOV != null)
                {
                    this._editNroOV.KeyPress += new KeyPressEventHandler(this.editNroOV_KeyPress);
                    this._editNroOV.TextChanged += new EventHandler(this.editNroOV_TextChanged);
                    this._editNroOV.LostFocus += new EventHandler(this.editNroOV_LostFocus);
                }
            }
        }

        internal virtual TextBox editTipoOV
        {
            get
            {
                return this._editTipoOV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editTipoOV != null)
                {
                    this._editTipoOV.TextAlignChanged -= new EventHandler(this.editTipoOV_TextAlignChanged);
                    this._editTipoOV.LostFocus -= new EventHandler(this.editTipoOV_LostFocus);
                    this._editTipoOV.KeyPress -= new KeyPressEventHandler(this.editTipoOV_KeyPress);
                    this._editTipoOV.TextChanged -= new EventHandler(this.editTipoOV_TextChanged);
                }
                this._editTipoOV = value;
                if (this._editTipoOV != null)
                {
                    this._editTipoOV.TextAlignChanged += new EventHandler(this.editTipoOV_TextAlignChanged);
                    this._editTipoOV.LostFocus += new EventHandler(this.editTipoOV_LostFocus);
                    this._editTipoOV.KeyPress += new KeyPressEventHandler(this.editTipoOV_KeyPress);
                    this._editTipoOV.TextChanged += new EventHandler(this.editTipoOV_TextChanged);
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

        internal virtual Label Label4
        {
            get
            {
                return this._Label4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label4 != null)
                {
                }
                this._Label4 = value;
                if (this._Label4 != null)
                {
                }
            }
        }

        internal virtual Label Label6
        {
            get
            {
                return this._Label6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label6 != null)
                {
                }
                this._Label6 = value;
                if (this._Label6 != null)
                {
                }
            }
        }
    }
}

