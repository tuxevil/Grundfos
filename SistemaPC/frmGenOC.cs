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

    public class frmGenOC : Form
    {
        [AccessedThroughProperty("cbAlmacen")]
        private ComboBox _cbAlmacen;
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dtpFechaOC")]
        private DateTimePicker _dtpFechaOC;
        [AccessedThroughProperty("editMesesNRNue")]
        private TextBox _editMesesNRNue;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("txtCodProd")]
        private TextBox _txtCodProd;
        public SqlDataAdapter AdapAlmacen;
        private IContainer components;
        public DataSet DS;

        public frmGenOC()
        {
            base.Closed += new EventHandler(this.frmGenOC_Closed);
            base.Load += new EventHandler(this.frmGenOC_Load);
            this.DS = new DataSet();
            this.InitializeComponent();
        }

        private void ActTmp()
        {
            DataSet dataSet = new DataSet();
            DataSet set2 = new DataSet();
            this.cmbAceptar.Enabled = false;
            this.cmbSalir.Enabled = false;
            SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
            connection.Open();
            SqlConnection connection2 = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
            connection2.Open();
            int num16 = new SqlCommand("delete " + Variables.gTermi + "TmpOCompra", connection2).ExecuteNonQuery();
            num16 = new SqlCommand("delete " + Variables.gTermi + "TmpOCGen", connection2).ExecuteNonQuery();
            SqlCommand command4 = new SqlCommand("delete " + Variables.gTermi + "TmpCodReemp", connection2);
            num16 = command4.ExecuteNonQuery();
            string str = "";
            string str10 = "";
            string str2 = "";
            string str11 = "";
            string str3 = "";
            string str12 = "";
            string cmdText = "SELECT PL23003,PL23004 FROM dbo.PL230100 where PL23001='2' and PL23002='00' and (PL23003='01' or PL23003='02' or PL23003='03') order by PL23003";
            SqlDataReader reader = new SqlCommand(cmdText, connection).ExecuteReader();
            if (reader.Read())
            {
                str = StringType.FromObject(reader["PL23003"]);
                str10 = StringType.FromObject(reader["PL23004"]);
            }
            if (reader.Read())
            {
                str2 = StringType.FromObject(reader["PL23003"]);
                str11 = StringType.FromObject(reader["PL23004"]);
            }
            if (reader.Read())
            {
                str3 = StringType.FromObject(reader["PL23003"]);
                str12 = StringType.FromObject(reader["PL23004"]);
            }
            reader.Close();
            cmdText = "SELECT SC01001,SC01089 FROM dbo.SC010100 where SC01089<>''";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandTimeout = 300;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                command4 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpCodReemp (Codigo,CodReemplazo) values ('", reader["SC01001"]), "','"), reader["SC01089"]), "')")), connection2);
                try
                {
                    num16 = command4.ExecuteNonQuery();
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                    connection.Close();
                    connection2.Close();
                    this.cmbAceptar.Enabled = true;
                    this.cmbSalir.Enabled = true;
                    ProjectData.ClearProjectError();
                    return;
                    ProjectData.ClearProjectError();
                }
            }
            reader.Close();
            SqlCommand command2 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT SC01001,SC01002,SC01003,SC03010,SC03003,SC03004,SC03005,SC03006,SC03011,SC03018,SC01089,SC01125,SC03022,PL01002,SC01055,SC01056,SY14002 FROM SC010100 INNER JOIN SC030100 ON SC010100.SC01001 = SC030100.SC03001 INNER JOIN PL010100 ON SC030100.SC03022 = PL010100.PL01001 INNER JOIN SY140100 ON SC010100.SC01056 = SY140100.SY14001 WHERE SC030100.SC03002 = '", this.cbAlmacen.SelectedValue), "'")), connection);
            command2.CommandTimeout = 900;
            dataSet.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command2;
            adapter.Fill(dataSet, "SC010100");
            this.Label1.Visible = true;
            this.Label1.Refresh();
            this.txtCodProd.Visible = true;
            long num17 = dataSet.Tables["SC010100"].Rows.Count - 1;
            for (long i = 0L; i <= num17; i += 1L)
            {
                double num13;
                double num14;
                double num15;
                DataRow row = dataSet.Tables["SC010100"].Rows[(int) i];
                this.txtCodProd.Text = StringType.FromObject(row["SC01001"]);
                this.txtCodProd.Refresh();
                string str5 = StringType.FromObject(row["SC01001"]);
                string str13 = Strings.Trim(StringType.FromObject(row["SC01002"])) + " " + Strings.Trim(StringType.FromObject(row["SC01003"]));
                double num5 = DoubleType.FromObject(row["SC03010"]);
                if (ObjectType.ObjTst(row["SC03003"], 0, false) < 0)
                {
                    num15 = 0.0;
                }
                else
                {
                    num15 = DoubleType.FromObject(row["SC03003"]);
                }
                double num9 = DoubleType.FromObject(ObjectType.AddObj(row["SC03004"], row["SC03005"]));
                double num8 = DoubleType.FromObject(row["SC03006"]);
                double num3 = DoubleType.FromObject(row["SC03011"]);
                double num2 = DoubleType.FromObject(row["SC03018"]);
                string sLeft = StringType.FromObject(row["SC01089"]);
                DateTime expression = DateType.FromObject(row["SC01125"]);
                string str7 = StringType.FromObject(row["SC03022"]);
                string str15 = StringType.FromObject(row["PL01002"]);
                double num11 = DoubleType.FromObject(row["SC01055"]);
                string str4 = StringType.FromObject(row["SC01056"]);
                string str14 = StringType.FromObject(row["SY14002"]);
                if (ObjectType.ObjTst(this.cbAlmacen.SelectedValue, "01", false) != 0)
                {
                    command = new SqlCommand("SELECT SC03003 as Stock FROM dbo.SC030100 where SC03001='" + str5 + "' and SC03002='01'", connection);
                    command.CommandTimeout = 300;
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        num15 = DoubleType.FromObject(ObjectType.AddObj(num15, reader["Stock"]));
                    }
                    reader.Close();
                }
                if (ObjectType.ObjTst(this.cbAlmacen.SelectedValue, "03", false) != 0)
                {
                    command = new SqlCommand("SELECT SC03003 as Stock FROM dbo.SC030100 where SC03001='" + str5 + "' and SC03002='03'", connection);
                    command.CommandTimeout = 300;
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        num15 = DoubleType.FromObject(ObjectType.AddObj(num15, reader["Stock"]));
                    }
                    reader.Close();
                }
                if (ObjectType.ObjTst(this.cbAlmacen.SelectedValue, "05", false) != 0)
                {
                    command = new SqlCommand("SELECT SC03003 as Stock FROM dbo.SC030100 where SC03001='" + str5 + "' and SC03002='05'", connection);
                    command.CommandTimeout = 300;
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        num15 = DoubleType.FromObject(ObjectType.AddObj(num15, reader["Stock"]));
                    }
                    reader.Close();
                }
                if (ObjectType.ObjTst(this.cbAlmacen.SelectedValue, "07", false) != 0)
                {
                    command = new SqlCommand("SELECT SC03003 as Stock FROM dbo.SC030100 where SC03001='" + str5 + "' and SC03002='07'", connection);
                    command.CommandTimeout = 300;
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        num15 = DoubleType.FromObject(ObjectType.AddObj(num15, reader["Stock"]));
                    }
                    reader.Close();
                }
                if (ObjectType.ObjTst(this.cbAlmacen.SelectedValue, "08", false) != 0)
                {
                    command = new SqlCommand("SELECT SC03003 as Stock FROM dbo.SC030100 where SC03001='" + str5 + "' and SC03002='08'", connection);
                    command.CommandTimeout = 300;
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        num15 = DoubleType.FromObject(ObjectType.AddObj(num15, reader["Stock"]));
                    }
                    reader.Close();
                }
                if (ObjectType.ObjTst(this.cbAlmacen.SelectedValue, "09", false) != 0)
                {
                    command = new SqlCommand("SELECT SC03003 as Stock FROM dbo.SC030100 where SC03001='" + str5 + "' and SC03002='09'", connection);
                    command.CommandTimeout = 300;
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        num15 = DoubleType.FromObject(ObjectType.AddObj(num15, reader["Stock"]));
                    }
                    reader.Close();
                }
                if (ObjectType.ObjTst(this.cbAlmacen.SelectedValue, "10", false) != 0)
                {
                    command = new SqlCommand("SELECT SC03003 as Stock FROM dbo.SC030100 where SC03001='" + str5 + "' and SC03002='10'", connection);
                    command.CommandTimeout = 300;
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        num15 = DoubleType.FromObject(ObjectType.AddObj(num15, reader["Stock"]));
                    }
                    reader.Close();
                }
                double num10 = 0.0;
                command = new SqlCommand("SELECT sum(OR03011-OR03012) as OVRes FROM dbo.OR030100,OR010100 where (OR01002=1 or OR01002=4 or OR01002=6) and OR01091=1 and OR03011-OR03012<>0 and OR03005='" + str5 + "' and OR01001=OR03001", connection);
                command.CommandTimeout = 300;
                reader = command.ExecuteReader();
                if (reader.Read() && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(reader["OVRes"])))
                {
                    num10 = DoubleType.FromObject(reader["OVRes"]);
                }
                reader.Close();
                double num12 = 0.0;
                command = new SqlCommand("SELECT sum(OR03011) as PromVtas FROM dbo.OR030100,OR010100 where (OR01002=1 or OR01002=4 or OR01002=6) and OR01091=0 and OR03005='" + str5 + "' and OR01001=OR03001 and OR01015>='" + Strings.Format(DateAndTime.DateAdd(DateInterval.Month, -3.0, DateAndTime.Now), "MM/dd/yyyy") + "' and OR01015<='" + Strings.Format(DateAndTime.Now, "MM/dd/yyyy") + "'", connection);
                command.CommandTimeout = 300;
                reader = command.ExecuteReader();
                if (reader.Read() && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(reader["PromVtas"])))
                {
                    num12 = DoubleType.FromObject(reader["PromVtas"]);
                }
                reader.Close();
                command = new SqlCommand("SELECT sum(OR21011) as PromVtas FROM dbo.OR210100,OR200100 where (OR20002=1 or OR20002=4 or OR20002=6) and OR20091=0 and OR21005='" + str5 + "' and OR20001=OR21001 and OR20015>='" + Strings.Format(DateAndTime.DateAdd(DateInterval.Month, -3.0, DateAndTime.Now), "MM/dd/yyyy") + "' and OR20015<='" + Strings.Format(DateAndTime.Now, "MM/dd/yyyy") + "'", connection);
                command.CommandTimeout = 300;
                reader = command.ExecuteReader();
                if (reader.Read() && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(reader["PromVtas"])))
                {
                    num12 = DoubleType.FromObject(ObjectType.AddObj(num12, reader["PromVtas"]));
                }
                reader.Close();
                num12 /= 3.0;
                double num7 = num12 * Variables.gMesesNRNue;
                if (num7 == 0.0)
                {
                    num7 = num5;
                }
                if (StringType.StrCmp(sLeft, " ", false) != 0)
                {
                    num13 = 0.0;
                    num14 = 0.0;
                    if (!(((((StringType.StrCmp(Strings.Format(expression, "yyyyMMdd"), Strings.Format(DateAndTime.Now, "yyyyMMdd"), false) < 0) & (num15 == 0.0)) & (num9 == 0.0)) & (num8 == 0.0)) & (num10 == 0.0)))
                    {
                        command4 = new SqlCommand((((((((((((((((("insert into " + Variables.gTermi + "TmpOCompra (Codigo,Descripcion,NivelRepos,StockAl,OV,OCPend,OVRes,LoteOptCpra,CantMinPed,CodReemplazo,FecReemp,PropCpra,PromVtas,NivelReposPV,PropCpraPV,CodProv,NomProv,CodMetEnv01,DescMetEnv01,CantMetEnv01,FecEntOC01,CodMetEnv02,DescMetEnv02,CantMetEnv02,FecEntOC02,CodMetEnv03,DescMetEnv03,CantMetEnv03,FecEntOC03,Seleccion,PrecioCpra,CodMoneda,Moneda) values ('" + str5) + "','" + str13 + "'," + StringType.FromDouble(num5) + "," + StringType.FromDouble(num15) + "," + StringType.FromDouble(num9) + "," + StringType.FromDouble(num8) + "," + StringType.FromDouble(num10) + "," + StringType.FromDouble(num3) + "," + StringType.FromDouble(num2)) + ",'" + sLeft) + "','" + Strings.Format(expression, "MM/dd/yyyy") + "'," + StringType.FromDouble(num13) + "," + StringType.FromDouble(num12) + "," + StringType.FromDouble(num7) + "," + StringType.FromDouble(num14)) + ",'" + str7) + "','" + str15) + "','" + str) + "','" + str10 + "'," + StringType.FromDouble(num13)) + ",'" + Strings.Format(DateType.FromString(Variables.gFechaOC), "MM/dd/yyyy")) + "','" + str2) + "','" + str11) + "',0,'" + Strings.Format(DateType.FromString(Variables.gFechaOC), "MM/dd/yyyy")) + "','" + str3) + "','" + str12) + "',0,'" + Strings.Format(DateType.FromString(Variables.gFechaOC), "MM/dd/yyyy") + "',0," + StringType.FromDouble(num11)) + ",'" + str4) + "','" + str14 + "')", connection2);
                        try
                        {
                            num16 = command4.ExecuteNonQuery();
                        }
                        catch (Exception exception4)
                        {
                            ProjectData.SetProjectError(exception4);
                            Exception exception2 = exception4;
                            Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, MsgBoxStyle.OKOnly, null);
                            connection.Close();
                            connection2.Close();
                            this.cmbAceptar.Enabled = true;
                            this.cmbSalir.Enabled = true;
                            ProjectData.ClearProjectError();
                            return;
                            ProjectData.ClearProjectError();
                        }
                    }
                    continue;
                }
                if (StringType.StrCmp(sLeft, " ", false) == 0)
                {
                    string str6 = str5;
                    while (1 != 0)
                    {
                        command = new SqlCommand("SELECT * FROM " + Variables.gTermi + "TmpCodReemp where CodReemplazo='" + str6 + "'", connection2);
                        command.CommandTimeout = 300;
                        reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            str6 = StringType.FromObject(reader["Codigo"]);
                            reader.Close();
                        }
                        else
                        {
                            reader.Close();
                            break;
                        }
                        command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT SC03010,SC03003,SC03004,SC03005,SC03006,SC03011,SC03018 FROM SC030100 where SC03001='" + str6 + "' and SC03002='", this.cbAlmacen.SelectedValue), "'")), connection);
                        command.CommandTimeout = 300;
                        reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            num15 = DoubleType.FromObject(ObjectType.AddObj(num15, reader["SC03003"]));
                            num9 = DoubleType.FromObject(ObjectType.AddObj(ObjectType.AddObj(num9, reader["SC03004"]), reader["SC03005"]));
                            num8 = DoubleType.FromObject(ObjectType.AddObj(num8, reader["SC03006"]));
                        }
                        reader.Close();
                        if (ObjectType.ObjTst(this.cbAlmacen.SelectedValue, "01", false) != 0)
                        {
                            command = new SqlCommand("SELECT SC03003 as Stock FROM dbo.SC030100 where SC03001='" + str6 + "' and SC03002='01'", connection);
                            command.CommandTimeout = 300;
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                num15 = DoubleType.FromObject(ObjectType.AddObj(num15, reader["Stock"]));
                            }
                            reader.Close();
                        }
                        if (ObjectType.ObjTst(this.cbAlmacen.SelectedValue, "03", false) != 0)
                        {
                            command = new SqlCommand("SELECT SC03003 as Stock FROM dbo.SC030100 where SC03001='" + str6 + "' and SC03002='03'", connection);
                            command.CommandTimeout = 300;
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                num15 = DoubleType.FromObject(ObjectType.AddObj(num15, reader["Stock"]));
                            }
                            reader.Close();
                        }
                        if (ObjectType.ObjTst(this.cbAlmacen.SelectedValue, "05", false) != 0)
                        {
                            command = new SqlCommand("SELECT SC03003 as Stock FROM dbo.SC030100 where SC03001='" + str6 + "' and SC03002='05'", connection);
                            command.CommandTimeout = 300;
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                num15 = DoubleType.FromObject(ObjectType.AddObj(num15, reader["Stock"]));
                            }
                            reader.Close();
                        }
                        if (ObjectType.ObjTst(this.cbAlmacen.SelectedValue, "07", false) != 0)
                        {
                            command = new SqlCommand("SELECT SC03003 as Stock FROM dbo.SC030100 where SC03001='" + str6 + "' and SC03002='07'", connection);
                            command.CommandTimeout = 300;
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                num15 = DoubleType.FromObject(ObjectType.AddObj(num15, reader["Stock"]));
                            }
                            reader.Close();
                        }
                        if (ObjectType.ObjTst(this.cbAlmacen.SelectedValue, "08", false) != 0)
                        {
                            command = new SqlCommand("SELECT SC03003 as Stock FROM dbo.SC030100 where SC03001='" + str6 + "' and SC03002='08'", connection);
                            command.CommandTimeout = 300;
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                num15 = DoubleType.FromObject(ObjectType.AddObj(num15, reader["Stock"]));
                            }
                            reader.Close();
                        }
                        if (ObjectType.ObjTst(this.cbAlmacen.SelectedValue, "09", false) != 0)
                        {
                            command = new SqlCommand("SELECT SC03003 as Stock FROM dbo.SC030100 where SC03001='" + str6 + "' and SC03002='09'", connection);
                            command.CommandTimeout = 300;
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                num15 = DoubleType.FromObject(ObjectType.AddObj(num15, reader["Stock"]));
                            }
                            reader.Close();
                        }
                        if (ObjectType.ObjTst(this.cbAlmacen.SelectedValue, "10", false) != 0)
                        {
                            command = new SqlCommand("SELECT SC03003 as Stock FROM dbo.SC030100 where SC03001='" + str6 + "' and SC03002='10'", connection);
                            command.CommandTimeout = 300;
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                num15 = DoubleType.FromObject(ObjectType.AddObj(num15, reader["Stock"]));
                            }
                            reader.Close();
                        }
                        command = new SqlCommand("SELECT sum(OR03011-OR03012) as OVRes FROM dbo.OR030100,OR010100 where (OR01002=1 or OR01002=4 or OR01002=6) and OR01091=1 and OR03011-OR03012<>0 and OR03005='" + str6 + "' and OR01001=OR03001", connection);
                        command.CommandTimeout = 300;
                        reader = command.ExecuteReader();
                        if (reader.Read() && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(reader["OVRes"])))
                        {
                            num10 = DoubleType.FromObject(ObjectType.AddObj(num10, reader["OVRes"]));
                        }
                        reader.Close();
                        num12 = 0.0;
                        command = new SqlCommand("SELECT sum(OR03011) as PromVtas FROM dbo.OR030100,OR010100 where (OR01002=1 or OR01002=4 or OR01002=6) and OR01091=0 and OR03005='" + str6 + "' and OR01001=OR03001 and OR01015>='" + Strings.Format(DateAndTime.DateAdd(DateInterval.Month, -3.0, DateAndTime.Now), "MM/dd/yyyy") + "' and OR01015<='" + Strings.Format(DateAndTime.Now, "MM/dd/yyyy") + "'", connection);
                        command.CommandTimeout = 300;
                        reader = command.ExecuteReader();
                        if (reader.Read() && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(reader["PromVtas"])))
                        {
                            num12 = DoubleType.FromObject(reader["PromVtas"]);
                        }
                        reader.Close();
                        command = new SqlCommand("SELECT sum(OR21011) as PromVtas FROM dbo.OR210100,OR200100 where (OR20002=1 or OR20002=4 or OR20002=6) and OR20091=0 and OR21005='" + str6 + "' and OR20001=OR21001 and OR20015>='" + Strings.Format(DateAndTime.DateAdd(DateInterval.Month, -3.0, DateAndTime.Now), "MM/dd/yyyy") + "' and OR20015<='" + Strings.Format(DateAndTime.Now, "MM/dd/yyyy") + "'", connection);
                        command.CommandTimeout = 300;
                        reader = command.ExecuteReader();
                        if (reader.Read() && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(reader["PromVtas"])))
                        {
                            num12 = DoubleType.FromObject(ObjectType.AddObj(num12, reader["PromVtas"]));
                        }
                        reader.Close();
                        num12 /= 3.0;
                        num7 = num12 * Variables.gMesesNRNue;
                        if (num7 == 0.0)
                        {
                            num7 = num5;
                        }
                    }
                    num13 = (((num5 - num15) + num9) - num8) - num10;
                    num14 = (((num7 - num15) + num9) - num8) - num10;
                    if (num13 > 0.0)
                    {
                        if ((num3 != 0.0) && (num3 > num13))
                        {
                            num13 = num3;
                        }
                        if (num2 != 0.0)
                        {
                            num13 = Math.Round((double) ((num13 / num2) + 0.49), 0) * num2;
                        }
                        command4 = new SqlCommand(((((((((((((((("insert into " + Variables.gTermi + "TmpOCompra (Codigo,Descripcion,NivelRepos,StockAl,OV,OCPend,OVRes,LoteOptCpra,CantMinPed,CodReemplazo,PropCpra,PromVtas,NivelReposPV,PropCpraPV,CodProv,NomProv,CodMetEnv01,DescMetEnv01,CantMetEnv01,FecEntOC01,CodMetEnv02,DescMetEnv02,CantMetEnv02,FecEntOC02,CodMetEnv03,DescMetEnv03,CantMetEnv03,FecEntOC03,Seleccion,PrecioCpra,CodMoneda,Moneda) values ('" + str5) + "','" + str13 + "'," + StringType.FromDouble(num5) + "," + StringType.FromDouble(num15) + "," + StringType.FromDouble(num9) + "," + StringType.FromDouble(num8) + "," + StringType.FromDouble(num10) + "," + StringType.FromDouble(num3) + "," + StringType.FromDouble(num2)) + ",'" + sLeft + "'," + StringType.FromDouble(num13) + "," + StringType.FromDouble(num12) + "," + StringType.FromDouble(num7) + "," + StringType.FromDouble(num14)) + ",'" + str7) + "','" + str15) + "','" + str) + "','" + str10 + "'," + StringType.FromDouble(num13)) + ",'" + Strings.Format(DateType.FromString(Variables.gFechaOC), "MM/dd/yyyy")) + "','" + str2) + "','" + str11) + "',0,'" + Strings.Format(DateType.FromString(Variables.gFechaOC), "MM/dd/yyyy")) + "','" + str3) + "','" + str12) + "',0,'" + Strings.Format(DateType.FromString(Variables.gFechaOC), "MM/dd/yyyy") + "',0," + StringType.FromDouble(num11)) + ",'" + str4) + "','" + str14 + "')", connection2);
                        try
                        {
                            num16 = command4.ExecuteNonQuery();
                        }
                        catch (Exception exception5)
                        {
                            ProjectData.SetProjectError(exception5);
                            Exception exception3 = exception5;
                            Interaction.MsgBox("Se ha producido el siguiente error:" + exception3.Message, MsgBoxStyle.OKOnly, null);
                            connection.Close();
                            connection2.Close();
                            this.cmbAceptar.Enabled = true;
                            this.cmbSalir.Enabled = true;
                            ProjectData.ClearProjectError();
                            return;
                            ProjectData.ClearProjectError();
                        }
                    }
                }
            }
            connection.Close();
            connection2.Close();
        }

        private void cbAlmacen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editMesesNRNue.Focus();
            }
        }

        private void cbAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            if (StringType.StrCmp(this.editMesesNRNue.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe ingresar meses para nivel de reposici\x00f3n", MsgBoxStyle.Critical, "Operador");
                this.editMesesNRNue.Focus();
            }
            else if (!Information.IsNumeric(this.editMesesNRNue.Text))
            {
                Interaction.MsgBox("Meses para nivel de reposici\x00f3n debe ser num\x00e9rico", MsgBoxStyle.Critical, "Operador");
                this.editMesesNRNue.Focus();
            }
            else
            {
                this.dtpFechaOC.Enabled = false;
                this.cmbAceptar.Enabled = false;
                this.cmbSalir.Enabled = false;
                Variables.gFechaOC = StringType.FromDate(this.dtpFechaOC.Value);
                if (StringType.StrCmp(this.cbAlmacen.Text, Strings.Space(0), false) != 0)
                {
                    Variables.gAlmacen1 = this.cbAlmacen.Text;
                }
                else
                {
                    Variables.gAlmacen1 = "";
                }
                Variables.gMesesNRNue = IntegerType.FromString(this.editMesesNRNue.Text);
                this.ActTmp();
                frmGenOC1 noc = new frmGenOC1();
                this.Hide();
                noc.Show();
            }
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void dtpFechaOC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cbAlmacen.Focus();
            }
        }

        private void editCodProv_TextChanged(object sender, EventArgs e)
        {
        }

        private void editMesesNRNue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        ~frmGenOC()
        {
        }

        private void frmGenOC_Closed(object sender, EventArgs e)
        {
            new frmMenuOCompra().Show();
        }

        private void frmGenOC_Load(object sender, EventArgs e)
        {
            this.dtpFechaOC.Value = DateAndTime.Now;
            bool flag = false;
            try
            {
                string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
                string selectCommandText = "select SC23001,ltrim(SC23001)+'-'+ltrim(SC23002) as Almacen from SC230100 order by SC23001";
                this.AdapAlmacen = new SqlDataAdapter(selectCommandText, selectConnectionString);
                this.DS.Tables.Clear();
                this.AdapAlmacen.Fill(this.DS, "SC230100-1");
                this.cbAlmacen.DataSource = this.DS.Tables["SC230100-1"];
                this.cbAlmacen.DisplayMember = "Almacen";
                this.cbAlmacen.ValueMember = "SC23001";
                this.cbAlmacen.Refresh();
                new SqlConnection(selectConnectionString).Open();
                flag = true;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                if (flag)
                {
                    SqlConnection connection;
                    connection.Close();
                    flag = false;
                }
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                this.Close();
                ProjectData.ClearProjectError();
            }
            this.cbAlmacen.Text = "";
            this.cbAlmacen.SelectedValue = "";
            this.dtpFechaOC.Focus();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmGenOC));
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.Label1 = new Label();
            this.dtpFechaOC = new DateTimePicker();
            this.Label2 = new Label();
            this.cbAlmacen = new ComboBox();
            this.txtCodProd = new TextBox();
            this.Label3 = new Label();
            this.Label4 = new Label();
            this.editMesesNRNue = new TextBox();
            this.SuspendLayout();
            Point point = new Point(0x160, 0x88);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 6;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0xf8, 0x88);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 7;
            this.cmbSalir.Text = "&Salir";
            this.Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x18);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x80, 0x10);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Fecha Entrega OC:";
            this.dtpFechaOC.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaOC.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaOC.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaOC.Format = DateTimePickerFormat.Short;
            point = new Point(160, 0x18);
            this.dtpFechaOC.Location = point;
            this.dtpFechaOC.Name = "dtpFechaOC";
            size = new Size(0x70, 0x16);
            this.dtpFechaOC.Size = size;
            this.dtpFechaOC.TabIndex = 1;
            DateTime time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpFechaOC.Value = time;
            this.Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x40);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(120, 0x10);
            this.Label2.Size = size;
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Almac\x00e9n:";
            this.cbAlmacen.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x38);
            this.cbAlmacen.Location = point;
            this.cbAlmacen.Name = "cbAlmacen";
            size = new Size(0x120, 0x18);
            this.cbAlmacen.Size = size;
            this.cbAlmacen.TabIndex = 3;
            this.cbAlmacen.Text = "ComboBox1";
            this.txtCodProd.BackColor = SystemColors.Window;
            this.txtCodProd.Enabled = false;
            point = new Point(0x90, 0xc0);
            this.txtCodProd.Location = point;
            this.txtCodProd.MaxLength = 0x23;
            this.txtCodProd.Name = "txtCodProd";
            size = new Size(0xb8, 20);
            this.txtCodProd.Size = size;
            this.txtCodProd.TabIndex = 9;
            this.txtCodProd.Text = "";
            this.txtCodProd.Visible = false;
            point = new Point(0x10, 0xc0);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(120, 0x18);
            this.Label3.Size = size;
            this.Label3.TabIndex = 8;
            this.Label3.Text = "Procesando producto:";
            this.Label3.Visible = false;
            this.Label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x60);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(0x80, 0x20);
            this.Label4.Size = size;
            this.Label4.TabIndex = 4;
            this.Label4.Text = "Meses para NR (promedio vtas.):";
            this.editMesesNRNue.BackColor = SystemColors.Window;
            this.editMesesNRNue.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x60);
            this.editMesesNRNue.Location = point;
            this.editMesesNRNue.MaxLength = 3;
            this.editMesesNRNue.Name = "editMesesNRNue";
            size = new Size(0x40, 0x16);
            this.editMesesNRNue.Size = size;
            this.editMesesNRNue.TabIndex = 5;
            this.editMesesNRNue.Text = "";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            size = new Size(0x324, 0x242);
            this.ClientSize = size;
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.editMesesNRNue);
            this.Controls.Add(this.txtCodProd);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.cbAlmacen);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.dtpFechaOC);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmGenOC";
            this.Text = "Generaci\x00f3n Ordenes de Compra";
            this.WindowState = FormWindowState.Maximized;
            this.ResumeLayout(false);
        }

        private void Label2_Click(object sender, EventArgs e)
        {
        }

        internal virtual ComboBox cbAlmacen
        {
            get
            {
                return this._cbAlmacen;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cbAlmacen != null)
                {
                    this._cbAlmacen.KeyPress -= new KeyPressEventHandler(this.cbAlmacen_KeyPress);
                    this._cbAlmacen.SelectedIndexChanged -= new EventHandler(this.cbAlmacen_SelectedIndexChanged);
                }
                this._cbAlmacen = value;
                if (this._cbAlmacen != null)
                {
                    this._cbAlmacen.KeyPress += new KeyPressEventHandler(this.cbAlmacen_KeyPress);
                    this._cbAlmacen.SelectedIndexChanged += new EventHandler(this.cbAlmacen_SelectedIndexChanged);
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

        internal virtual DateTimePicker dtpFechaOC
        {
            get
            {
                return this._dtpFechaOC;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpFechaOC != null)
                {
                    this._dtpFechaOC.KeyPress -= new KeyPressEventHandler(this.dtpFechaOC_KeyPress);
                }
                this._dtpFechaOC = value;
                if (this._dtpFechaOC != null)
                {
                    this._dtpFechaOC.KeyPress += new KeyPressEventHandler(this.dtpFechaOC_KeyPress);
                }
            }
        }

        internal virtual TextBox editMesesNRNue
        {
            get
            {
                return this._editMesesNRNue;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editMesesNRNue != null)
                {
                    this._editMesesNRNue.KeyPress -= new KeyPressEventHandler(this.editMesesNRNue_KeyPress);
                    this._editMesesNRNue.TextChanged -= new EventHandler(this.editCodProv_TextChanged);
                }
                this._editMesesNRNue = value;
                if (this._editMesesNRNue != null)
                {
                    this._editMesesNRNue.KeyPress += new KeyPressEventHandler(this.editMesesNRNue_KeyPress);
                    this._editMesesNRNue.TextChanged += new EventHandler(this.editCodProv_TextChanged);
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
                    this._Label2.Click -= new EventHandler(this.Label2_Click);
                }
                this._Label2 = value;
                if (this._Label2 != null)
                {
                    this._Label2.Click += new EventHandler(this.Label2_Click);
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

        internal virtual TextBox txtCodProd
        {
            get
            {
                return this._txtCodProd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtCodProd != null)
                {
                }
                this._txtCodProd = value;
                if (this._txtCodProd != null)
                {
                }
            }
        }
    }
}

