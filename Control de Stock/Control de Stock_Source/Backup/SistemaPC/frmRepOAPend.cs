namespace SistemaPC
{
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

    public class frmRepOAPend : Form
    {
        [AccessedThroughProperty("chkIntr01")]
        private CheckBox _chkIntr01;
        [AccessedThroughProperty("chkIntr02")]
        private CheckBox _chkIntr02;
        [AccessedThroughProperty("chkIntr03")]
        private CheckBox _chkIntr03;
        [AccessedThroughProperty("chkIntr04")]
        private CheckBox _chkIntr04;
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("rbFechaEnt")]
        private RadioButton _rbFechaEnt;
        [AccessedThroughProperty("rbNroOA")]
        private RadioButton _rbNroOA;
        private IContainer components;

        public frmRepOAPend()
        {
            base.Closed += new EventHandler(this.frmRepOAPend_Closed);
            base.Load += new EventHandler(this.frmRepOAPend_Load);
            this.InitializeComponent();
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
            this.cmbAceptar.Enabled = false;
            this.cmbSalir.Enabled = false;
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
                this.Label1.Text = StringType.FromObject(ObjectType.StrCatObj("Procesando ", row["OR03005"]));
                this.Label1.Refresh();
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
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                    connection.Close();
                    connection2.Close();
                    this.cmbAceptar.Enabled = true;
                    this.cmbSalir.Enabled = true;
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
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, 0, null);
                        connection.Close();
                        connection2.Close();
                        this.cmbAceptar.Enabled = true;
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
            this.Label1.Text = "Procesando fechas sin datos";
            this.Label1.Refresh();
            command3 = new SqlCommand("SELECT * from " + Variables.gTermi + "TmpCalendario order by FechaEnt", connection2);
            command3.CommandTimeout = 900;
            dataSet.Clear();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = command3;
            adapter.Fill(dataSet, Variables.gTermi + "TmpCalendario");
            if (dataSet.Tables[Variables.gTermi + "TmpCalendario"].Rows.Count != 0)
            {
                row = dataSet.Tables[Variables.gTermi + "TmpCalendario"].Rows[0];
                if (DateAndTime.Weekday(DateType.FromObject(row["FechaEnt"]), 1) > 1)
                {
                    time3 = DateAndTime.DateAdd(4, (double) ((DateAndTime.Weekday(DateType.FromObject(row["FechaEnt"]), 1) - 1) * -1), DateType.FromObject(row["FechaEnt"]));
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
                if (DateAndTime.Weekday(DateType.FromObject(row["FechaEnt"]), 1) < 7)
                {
                    time2 = DateAndTime.DateAdd(4, (double) (7 - DateAndTime.Weekday(DateType.FromObject(row["FechaEnt"]), 1)), DateType.FromObject(row["FechaEnt"]));
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
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception3.Message, 0, null);
                        connection.Close();
                        connection2.Close();
                        this.cmbAceptar.Enabled = true;
                        this.cmbSalir.Enabled = true;
                        ProjectData.ClearProjectError();
                        return;
                        ProjectData.ClearProjectError();
                    }
                }
                time3 = DateAndTime.DateAdd(4, 1.0, time3);
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
                this.Label1.Text = StringType.FromObject(ObjectType.StrCatObj("Procesando stock ", row["Codigo"]));
                this.Label1.Refresh();
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
                                Interaction.MsgBox("Se ha producido el siguiente error:" + exception4.Message, 0, null);
                                connection.Close();
                                connection2.Close();
                                this.cmbAceptar.Enabled = true;
                                this.cmbSalir.Enabled = true;
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
                                Interaction.MsgBox("Se ha producido el siguiente error:" + exception5.Message, 0, null);
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
                            Interaction.MsgBox("Se ha producido el siguiente error:" + exception6.Message, 0, null);
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
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception7.Message, 0, null);
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
            connection.Close();
            connection2.Close();
        }

        private void chkIntr01_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkIntr01_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.chkIntr02.Focus();
            }
        }

        private void chkIntr02_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkIntr02_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.chkIntr03.Focus();
            }
        }

        private void chkIntr03_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkIntr03_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.chkIntr04.Focus();
            }
        }

        private void chkIntr04_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkIntr04_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            if (!this.rbFechaEnt.Checked & !this.rbNroOA.Checked)
            {
                Interaction.MsgBox("Debe indicar ordenamiento del reporte", 0x10, "Operador");
                this.rbFechaEnt.Focus();
            }
            else
            {
                this.cmbAceptar.Enabled = false;
                this.cmbSalir.Enabled = false;
                if (this.rbFechaEnt.Checked)
                {
                    Variables.gIntr01 = this.chkIntr01.Checked;
                    Variables.gIntr02 = this.chkIntr02.Checked;
                    Variables.gIntr03 = this.chkIntr03.Checked;
                    Variables.gIntr04 = this.chkIntr04.Checked;
                    if (Variables.gIntr01)
                    {
                        Variables.gNomIntr01 = this.chkIntr01.Text;
                    }
                    else
                    {
                        Variables.gNomIntr01 = "";
                    }
                    if (Variables.gIntr02)
                    {
                        Variables.gNomIntr02 = this.chkIntr02.Text;
                    }
                    else
                    {
                        Variables.gNomIntr02 = "";
                    }
                    if (Variables.gIntr03)
                    {
                        Variables.gNomIntr03 = this.chkIntr03.Text;
                    }
                    else
                    {
                        Variables.gNomIntr03 = "";
                    }
                    if (Variables.gIntr04)
                    {
                        Variables.gNomIntr04 = this.chkIntr04.Text;
                    }
                    else
                    {
                        Variables.gNomIntr04 = "";
                    }
                    Variables.gOrdenOA = 1;
                    this.ActTmp();
                }
                else
                {
                    Variables.gOrdenOA = 2;
                }
                frmRepOAPend1 pend = new frmRepOAPend1();
                this.Hide();
                pend.Show();
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

        ~frmRepOAPend()
        {
        }

        private void frmRepOAPend_Closed(object sender, EventArgs e)
        {
            new frmMenuEns().Show();
        }

        private void frmRepOAPend_Load(object sender, EventArgs e)
        {
            SqlConnection connection;
            this.rbFechaEnt.Checked = true;
            this.chkIntr01.Checked = true;
            this.chkIntr02.Checked = true;
            this.chkIntr03.Checked = true;
            this.chkIntr04.Checked = true;
            this.GroupBox1.Visible = true;
            bool flag = false;
            try
            {
                connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
                connection.Open();
                flag = true;
                string cmdText = "SELECT SL01002 FROM SL010100 where SL01001='INTR01'";
                SqlDataReader reader = new SqlCommand(cmdText, connection).ExecuteReader();
                if (reader.Read())
                {
                    this.chkIntr01.Text = "INTR01 - " + Strings.Trim(StringType.FromObject(reader["SL01002"]));
                    reader.Close();
                }
                else
                {
                    this.chkIntr01.Text = "INTR01 - ";
                    reader.Close();
                    return;
                }
                cmdText = "SELECT SL01002 FROM SL010100 where SL01001='INTR02'";
                reader = new SqlCommand(cmdText, connection).ExecuteReader();
                if (reader.Read())
                {
                    this.chkIntr02.Text = "INTR02 - " + Strings.Trim(StringType.FromObject(reader["SL01002"]));
                    reader.Close();
                }
                else
                {
                    this.chkIntr02.Text = "INTR02 - ";
                    reader.Close();
                    return;
                }
                cmdText = "SELECT SL01002 FROM SL010100 where SL01001='INTR03'";
                reader = new SqlCommand(cmdText, connection).ExecuteReader();
                if (reader.Read())
                {
                    this.chkIntr03.Text = "INTR03 - " + Strings.Trim(StringType.FromObject(reader["SL01002"]));
                    reader.Close();
                }
                else
                {
                    this.chkIntr03.Text = "INTR03 - ";
                    reader.Close();
                    return;
                }
                cmdText = "SELECT SL01002 FROM SL010100 where SL01001='INTR04'";
                reader = new SqlCommand(cmdText, connection).ExecuteReader();
                if (reader.Read())
                {
                    this.chkIntr04.Text = "INTR04 - " + Strings.Trim(StringType.FromObject(reader["SL01002"]));
                    reader.Close();
                }
                else
                {
                    this.chkIntr04.Text = "INTR04 - ";
                    reader.Close();
                    return;
                }
                connection.Close();
                flag = false;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                if (flag)
                {
                    connection.Close();
                    flag = false;
                }
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                this.Close();
                ProjectData.ClearProjectError();
            }
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRepOAPend));
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.Label2 = new Label();
            this.GroupBox1 = new GroupBox();
            this.rbNroOA = new RadioButton();
            this.rbFechaEnt = new RadioButton();
            this.Label1 = new Label();
            this.GroupBox2 = new GroupBox();
            this.chkIntr04 = new CheckBox();
            this.chkIntr03 = new CheckBox();
            this.chkIntr02 = new CheckBox();
            this.chkIntr01 = new CheckBox();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            this.cmbAceptar.BackColor = SystemColors.Control;
            Point point = new Point(320, 400);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 2;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0xd8, 400);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 3;
            this.cmbSalir.Text = "&Salir";
            this.Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Underline | FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0xd8, 0x68);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0xd0, 20);
            this.Label2.Size = size;
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Calendario de Armado";
            this.Label2.TextAlign = ContentAlignment.MiddleCenter;
            this.GroupBox1.Controls.Add(this.rbNroOA);
            this.GroupBox1.Controls.Add(this.rbFechaEnt);
            this.GroupBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0xd8, 0x90);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(0xd0, 0x58);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Orden Reporte";
            this.rbNroOA.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x38);
            this.rbNroOA.Location = point;
            this.rbNroOA.Name = "rbNroOA";
            size = new Size(0xa8, 0x18);
            this.rbNroOA.Size = size;
            this.rbNroOA.TabIndex = 1;
            this.rbNroOA.Text = "N\x00b0 O.Armado";
            this.rbFechaEnt.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x18);
            this.rbFechaEnt.Location = point;
            this.rbFechaEnt.Name = "rbFechaEnt";
            size = new Size(0xa8, 0x18);
            this.rbFechaEnt.Size = size;
            this.rbFechaEnt.TabIndex = 0;
            this.rbFechaEnt.Text = "Fecha Entrega";
            this.Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0xd8, 0x1d0);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0xd0, 20);
            this.Label1.Size = size;
            this.Label1.TabIndex = 4;
            this.Label1.TextAlign = ContentAlignment.MiddleLeft;
            this.GroupBox2.Controls.Add(this.chkIntr04);
            this.GroupBox2.Controls.Add(this.chkIntr03);
            this.GroupBox2.Controls.Add(this.chkIntr02);
            this.GroupBox2.Controls.Add(this.chkIntr01);
            this.GroupBox2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x88, 240);
            this.GroupBox2.Location = point;
            this.GroupBox2.Name = "GroupBox2";
            size = new Size(0x170, 0x90);
            this.GroupBox2.Size = size;
            this.GroupBox2.TabIndex = 5;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Clientes";
            this.GroupBox2.Visible = false;
            this.chkIntr04.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x68);
            this.chkIntr04.Location = point;
            this.chkIntr04.Name = "chkIntr04";
            size = new Size(0x160, 0x18);
            this.chkIntr04.Size = size;
            this.chkIntr04.TabIndex = 3;
            this.chkIntr04.Text = "INTR04 - ";
            this.chkIntr03.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 80);
            this.chkIntr03.Location = point;
            this.chkIntr03.Name = "chkIntr03";
            size = new Size(0x160, 0x18);
            this.chkIntr03.Size = size;
            this.chkIntr03.TabIndex = 2;
            this.chkIntr03.Text = "INTR03 - ";
            this.chkIntr02.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x38);
            this.chkIntr02.Location = point;
            this.chkIntr02.Name = "chkIntr02";
            size = new Size(0x160, 0x18);
            this.chkIntr02.Size = size;
            this.chkIntr02.TabIndex = 1;
            this.chkIntr02.Text = "INTR02 - ";
            this.chkIntr01.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.chkIntr01.ForeColor = SystemColors.ControlText;
            point = new Point(8, 0x20);
            this.chkIntr01.Location = point;
            this.chkIntr01.Name = "chkIntr01";
            size = new Size(0x160, 0x18);
            this.chkIntr01.Size = size;
            this.chkIntr01.TabIndex = 0;
            this.chkIntr01.Text = "INTR01 - ";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.BackColor = SystemColors.Control;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmRepOAPend";
            this.Text = "Calendario de Armado";
            this.WindowState = FormWindowState.Maximized;
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void rbFechaEnt_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbFechaEnt.Checked)
            {
                this.GroupBox2.Visible = true;
                this.chkIntr01.Focus();
            }
            else
            {
                this.GroupBox2.Visible = false;
                this.rbNroOA.Focus();
            }
        }

        private void rbFechaEnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                if (this.rbFechaEnt.Checked)
                {
                    this.GroupBox2.Visible = true;
                    this.chkIntr01.Focus();
                }
                else
                {
                    this.GroupBox2.Visible = false;
                    this.rbNroOA.Focus();
                }
            }
        }

        private void rbNroOA_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbNroOA.Checked)
            {
                this.GroupBox2.Visible = false;
                this.cmbAceptar.Focus();
            }
            else
            {
                this.GroupBox2.Visible = true;
                this.chkIntr01.Focus();
            }
        }

        private void rbNroOA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                if (this.rbNroOA.Checked)
                {
                    this.GroupBox2.Visible = false;
                    this.cmbAceptar.Focus();
                }
                else
                {
                    this.GroupBox2.Visible = true;
                    this.chkIntr01.Focus();
                }
            }
        }

        internal virtual CheckBox chkIntr01
        {
            get
            {
                return this._chkIntr01;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._chkIntr01 != null)
                {
                    this._chkIntr01.KeyPress -= new KeyPressEventHandler(this.chkIntr01_KeyPress);
                    this._chkIntr01.CheckedChanged -= new EventHandler(this.chkIntr01_CheckedChanged);
                }
                this._chkIntr01 = value;
                if (this._chkIntr01 != null)
                {
                    this._chkIntr01.KeyPress += new KeyPressEventHandler(this.chkIntr01_KeyPress);
                    this._chkIntr01.CheckedChanged += new EventHandler(this.chkIntr01_CheckedChanged);
                }
            }
        }

        internal virtual CheckBox chkIntr02
        {
            get
            {
                return this._chkIntr02;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._chkIntr02 != null)
                {
                    this._chkIntr02.KeyPress -= new KeyPressEventHandler(this.chkIntr02_KeyPress);
                    this._chkIntr02.CheckedChanged -= new EventHandler(this.chkIntr02_CheckedChanged);
                }
                this._chkIntr02 = value;
                if (this._chkIntr02 != null)
                {
                    this._chkIntr02.KeyPress += new KeyPressEventHandler(this.chkIntr02_KeyPress);
                    this._chkIntr02.CheckedChanged += new EventHandler(this.chkIntr02_CheckedChanged);
                }
            }
        }

        internal virtual CheckBox chkIntr03
        {
            get
            {
                return this._chkIntr03;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._chkIntr03 != null)
                {
                    this._chkIntr03.KeyPress -= new KeyPressEventHandler(this.chkIntr03_KeyPress);
                    this._chkIntr03.CheckedChanged -= new EventHandler(this.chkIntr03_CheckedChanged);
                }
                this._chkIntr03 = value;
                if (this._chkIntr03 != null)
                {
                    this._chkIntr03.KeyPress += new KeyPressEventHandler(this.chkIntr03_KeyPress);
                    this._chkIntr03.CheckedChanged += new EventHandler(this.chkIntr03_CheckedChanged);
                }
            }
        }

        internal virtual CheckBox chkIntr04
        {
            get
            {
                return this._chkIntr04;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._chkIntr04 != null)
                {
                    this._chkIntr04.KeyPress -= new KeyPressEventHandler(this.chkIntr04_KeyPress);
                    this._chkIntr04.CheckedChanged -= new EventHandler(this.chkIntr04_CheckedChanged);
                }
                this._chkIntr04 = value;
                if (this._chkIntr04 != null)
                {
                    this._chkIntr04.KeyPress += new KeyPressEventHandler(this.chkIntr04_KeyPress);
                    this._chkIntr04.CheckedChanged += new EventHandler(this.chkIntr04_CheckedChanged);
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

        internal virtual GroupBox GroupBox1
        {
            get
            {
                return this._GroupBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._GroupBox1 != null)
                {
                }
                this._GroupBox1 = value;
                if (this._GroupBox1 != null)
                {
                }
            }
        }

        internal virtual GroupBox GroupBox2
        {
            get
            {
                return this._GroupBox2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._GroupBox2 != null)
                {
                }
                this._GroupBox2 = value;
                if (this._GroupBox2 != null)
                {
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

        internal virtual RadioButton rbFechaEnt
        {
            get
            {
                return this._rbFechaEnt;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbFechaEnt != null)
                {
                    this._rbFechaEnt.KeyPress -= new KeyPressEventHandler(this.rbFechaEnt_KeyPress);
                    this._rbFechaEnt.CheckedChanged -= new EventHandler(this.rbFechaEnt_CheckedChanged);
                }
                this._rbFechaEnt = value;
                if (this._rbFechaEnt != null)
                {
                    this._rbFechaEnt.KeyPress += new KeyPressEventHandler(this.rbFechaEnt_KeyPress);
                    this._rbFechaEnt.CheckedChanged += new EventHandler(this.rbFechaEnt_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbNroOA
        {
            get
            {
                return this._rbNroOA;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbNroOA != null)
                {
                    this._rbNroOA.KeyPress -= new KeyPressEventHandler(this.rbNroOA_KeyPress);
                    this._rbNroOA.CheckedChanged -= new EventHandler(this.rbNroOA_CheckedChanged);
                }
                this._rbNroOA = value;
                if (this._rbNroOA != null)
                {
                    this._rbNroOA.KeyPress += new KeyPressEventHandler(this.rbNroOA_KeyPress);
                    this._rbNroOA.CheckedChanged += new EventHandler(this.rbNroOA_CheckedChanged);
                }
            }
        }
    }
}

