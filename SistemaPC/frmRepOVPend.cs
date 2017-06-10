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
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmRepOVPend : Form
    {
        [AccessedThroughProperty("btnBusqNom")]
        private Button _btnBusqNom;
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dtpDesdeFechaEnt")]
        private DateTimePicker _dtpDesdeFechaEnt;
        [AccessedThroughProperty("dtpDesdeFechaOV")]
        private DateTimePicker _dtpDesdeFechaOV;
        [AccessedThroughProperty("dtpHastaFechaEnt")]
        private DateTimePicker _dtpHastaFechaEnt;
        [AccessedThroughProperty("dtpHastaFechaOV")]
        private DateTimePicker _dtpHastaFechaOV;
        [AccessedThroughProperty("editCodCli")]
        private TextBox _editCodCli;
        [AccessedThroughProperty("editDescCli")]
        private TextBox _editDescCli;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;
        [AccessedThroughProperty("GroupBox3")]
        private GroupBox _GroupBox3;
        [AccessedThroughProperty("GroupBox4")]
        private GroupBox _GroupBox4;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("Label5")]
        private Label _Label5;
        [AccessedThroughProperty("Label6")]
        private Label _Label6;
        [AccessedThroughProperty("rbAlmacen01")]
        private RadioButton _rbAlmacen01;
        [AccessedThroughProperty("rbAlmacen02")]
        private RadioButton _rbAlmacen02;
        [AccessedThroughProperty("rbCliBloq")]
        private RadioButton _rbCliBloq;
        [AccessedThroughProperty("rbCliExc")]
        private RadioButton _rbCliExc;
        [AccessedThroughProperty("rbConStock")]
        private RadioButton _rbConStock;
        [AccessedThroughProperty("rbNoEntParc")]
        private RadioButton _rbNoEntParc;
        [AccessedThroughProperty("rbOrdenCliente")]
        private RadioButton _rbOrdenCliente;
        [AccessedThroughProperty("rbOrdenFechaEnt")]
        private RadioButton _rbOrdenFechaEnt;
        [AccessedThroughProperty("rbOrdenFechaOV")]
        private RadioButton _rbOrdenFechaOV;
        [AccessedThroughProperty("rbPlazoEnt")]
        private RadioButton _rbPlazoEnt;
        [AccessedThroughProperty("rbTodas")]
        private RadioButton _rbTodas;
        private IContainer components;

        public frmRepOVPend()
        {
            base.Closed += new EventHandler(this.frmRepOVPend_Closed);
            base.Load += new EventHandler(this.frmRepOVPend_Load);
            this.InitializeComponent();
        }

        private void btnBusqNom_Click(object sender, EventArgs e)
        {
            new frmBusqClixNom().ShowDialog();
            if (DoubleType.FromString(Variables.gCodCli) == 0.0)
            {
                this.editCodCli.Text = "";
            }
            else
            {
                this.editCodCli.Text = Variables.gCodCli;
            }
            this.editDescCli.Text = Variables.gNomCli;
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            if (!this.dtpDesdeFechaOV.Checked & this.dtpHastaFechaOV.Checked)
            {
                Interaction.MsgBox("Debe ingresar desde fecha o.venta", MsgBoxStyle.Critical, "Operador");
                this.dtpDesdeFechaOV.Checked = true;
            }
            else if (this.dtpDesdeFechaOV.Checked & !this.dtpHastaFechaOV.Checked)
            {
                Interaction.MsgBox("Debe ingresar hasta fecha o.venta", MsgBoxStyle.Critical, "Operador");
                this.dtpHastaFechaOV.Checked = true;
            }
            else if (!this.dtpDesdeFechaEnt.Checked & this.dtpHastaFechaEnt.Checked)
            {
                Interaction.MsgBox("Debe ingresar desde fecha entrega", MsgBoxStyle.Critical, "Operador");
                this.dtpDesdeFechaEnt.Checked = true;
            }
            else if (this.dtpDesdeFechaEnt.Checked & !this.dtpHastaFechaEnt.Checked)
            {
                Interaction.MsgBox("Debe ingresar hasta fecha entrega", MsgBoxStyle.Critical, "Operador");
                this.dtpHastaFechaEnt.Checked = true;
            }
            else if ((StringType.StrCmp(this.editCodCli.Text, Strings.Space(0), false) != 0) && (StringType.StrCmp(this.editDescCli.Text, Strings.Space(0), false) == 0))
            {
                Interaction.MsgBox("Cliente inexistente", MsgBoxStyle.Critical, "Operador");
                this.editCodCli.Focus();
            }
            else if (((((!this.rbTodas.Checked & !this.rbPlazoEnt.Checked) & !this.rbCliBloq.Checked) & !this.rbCliExc.Checked) & !this.rbConStock.Checked) & !this.rbNoEntParc.Checked)
            {
                Interaction.MsgBox("Debe indicar Ordenes de Venta a listar", MsgBoxStyle.Critical, "Operador");
                this.rbTodas.Checked = true;
            }
            else if ((!this.rbOrdenFechaEnt.Checked & !this.rbOrdenCliente.Checked) & !this.rbOrdenFechaOV.Checked)
            {
                Interaction.MsgBox("Debe indicar orden del reporte", MsgBoxStyle.Critical, "Operador");
                this.rbOrdenFechaEnt.Checked = true;
            }
            else
            {
                this.dtpDesdeFechaOV.Enabled = false;
                this.dtpHastaFechaOV.Enabled = false;
                this.dtpDesdeFechaEnt.Enabled = false;
                this.dtpHastaFechaEnt.Enabled = false;
                this.editCodCli.Enabled = false;
                this.rbTodas.Enabled = false;
                this.rbPlazoEnt.Enabled = false;
                this.rbCliBloq.Enabled = false;
                this.rbCliExc.Enabled = false;
                this.rbConStock.Enabled = false;
                this.rbNoEntParc.Enabled = false;
                this.cmbAceptar.Enabled = false;
                this.cmbSalir.Enabled = false;
                if (this.dtpDesdeFechaOV.Checked)
                {
                    Variables.gDesdeFechaOV = StringType.FromDate(this.dtpDesdeFechaOV.Value);
                }
                else
                {
                    Variables.gDesdeFechaOV = "";
                }
                if (this.dtpHastaFechaOV.Checked)
                {
                    Variables.gHastaFechaOV = StringType.FromDate(this.dtpHastaFechaOV.Value);
                }
                else
                {
                    Variables.gHastaFechaOV = "";
                }
                if (this.dtpDesdeFechaEnt.Checked)
                {
                    Variables.gDesdeFechaEnt = StringType.FromDate(this.dtpDesdeFechaEnt.Value);
                }
                else
                {
                    Variables.gDesdeFechaEnt = "";
                }
                if (this.dtpHastaFechaEnt.Checked)
                {
                    Variables.gHastaFechaEnt = StringType.FromDate(this.dtpHastaFechaEnt.Value);
                }
                else
                {
                    Variables.gHastaFechaEnt = "";
                }
                Variables.gCodCli = this.editCodCli.Text;
                Variables.gNomCli = this.editDescCli.Text;
                if (this.rbOrdenFechaEnt.Checked)
                {
                    Variables.gOrdenList = 1;
                }
                else if (this.rbOrdenCliente.Checked)
                {
                    Variables.gOrdenList = 2;
                }
                else if (this.rbOrdenFechaOV.Checked)
                {
                    Variables.gOrdenList = 3;
                }
                if (this.rbAlmacen01.Checked)
                {
                    Variables.gAlmacen1 = "01";
                }
                else
                {
                    Variables.gAlmacen1 = "02";
                }
                if (this.rbTodas.Checked)
                {
                    if (this.rbAlmacen01.Checked)
                    {
                        Variables.gTipoList = "Todas las Ordenes de Venta - Almac\x00e9n 01";
                    }
                    else
                    {
                        Variables.gTipoList = "Todas las Ordenes de Venta - Almac\x00e9n 02";
                    }
                    Variables.gOVaListar = 1;
                }
                else if (this.rbPlazoEnt.Checked)
                {
                    if (this.rbAlmacen01.Checked)
                    {
                        Variables.gTipoList = "Ordenes de Venta que no se puede cumplir plazo de entrega - Almac\x00e9n 01";
                    }
                    else
                    {
                        Variables.gTipoList = "Ordenes de Venta que no se puede cumplir plazo de entrega - Almac\x00e9n 02";
                    }
                    Variables.gOVaListar = 2;
                }
                else if (this.rbCliBloq.Checked)
                {
                    if (this.rbAlmacen01.Checked)
                    {
                        Variables.gTipoList = "Ordenes de Venta de clientes bloqueados - Almac\x00e9n 01";
                    }
                    else
                    {
                        Variables.gTipoList = "Ordenes de Venta de clientes bloqueados - Almac\x00e9n 02";
                    }
                    Variables.gOVaListar = 3;
                }
                else if (this.rbCliExc.Checked)
                {
                    if (this.rbAlmacen01.Checked)
                    {
                        Variables.gTipoList = "Ordenes de Venta de clientes excedidos en l\x00edmite de cr\x00e9dito - Almac\x00e9n 01";
                    }
                    else
                    {
                        Variables.gTipoList = "Ordenes de Venta de clientes excedidos en l\x00edmite de cr\x00e9dito - Almac\x00e9n 02";
                    }
                    Variables.gOVaListar = 4;
                }
                else if (this.rbConStock.Checked)
                {
                    if (this.rbAlmacen01.Checked)
                    {
                        Variables.gTipoList = "Ordenes de Venta con stock para todas sus l\x00edneas - Almac\x00e9n 01";
                    }
                    else
                    {
                        Variables.gTipoList = "Ordenes de Venta con stock para todas sus l\x00edneas - Almac\x00e9n 02";
                    }
                    Variables.gOVaListar = 5;
                }
                else if (this.rbNoEntParc.Checked)
                {
                    if (this.rbAlmacen01.Checked)
                    {
                        Variables.gTipoList = "Ordenes de Venta que no permiten entregas parciales y se podr\x00edan entregar parcialmente - Almac\x00e9n 01";
                    }
                    else
                    {
                        Variables.gTipoList = "Ordenes de Venta que no permiten entregas parciales y se podr\x00edan entregar parcialmente - Almac\x00e9n 02";
                    }
                    Variables.gOVaListar = 6;
                }
                SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
                SqlConnection connection2 = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
                connection2.Open();
                SqlCommand command4 = new SqlCommand("delete " + Variables.gTermi + "TmpOVPend", connection2);
                int num2 = command4.ExecuteNonQuery();
                string cmdText = "SELECT SL01001,SL01002,SL01060,SL01075,OR01001,OR01015,OR01016,OR01091,OR01018,OR01072,OR03005,OR03006,OR03007,OR03011,OR03012,sum(SC03003) as SC03003,sum(SC03004+SC03005) as StkComp,OR010100.OR01079 FROM dbo.SL010100,dbo.OR010100,dbo.OR030100,dbo.SC030100 where OR010100.OR01002<>6 and OR03011-OR03012<>0 ";
                if (this.rbAlmacen01.Checked)
                {
                    cmdText = cmdText + "and SC03002='01' and OR01050='01'";
                }
                else
                {
                    cmdText = cmdText + "and SC03002='02' and OR01050='02'";
                }
                if (this.dtpDesdeFechaOV.Checked & this.dtpHastaFechaOV.Checked)
                {
                    cmdText = cmdText + " and OR01015>='" + Strings.Format(DateType.FromString(Variables.gDesdeFechaOV), "MM/dd/yyyy") + "' and OR01015<='" + Strings.Format(DateType.FromString(Variables.gHastaFechaOV), "MM/dd/yyyy") + "'";
                }
                if (this.dtpDesdeFechaEnt.Checked & this.dtpHastaFechaEnt.Checked)
                {
                    cmdText = cmdText + " and OR01016>='" + Strings.Format(DateType.FromString(Variables.gDesdeFechaEnt), "MM/dd/yyyy") + "' and OR01016<='" + Strings.Format(DateType.FromString(Variables.gHastaFechaEnt), "MM/dd/yyyy") + "'";
                }
                if (StringType.StrCmp(Variables.gCodCli, Strings.Space(0), false) != 0)
                {
                    cmdText = cmdText + " and OR01004='" + Variables.gCodCli + "'";
                }
                SqlCommand command2 = new SqlCommand(cmdText + " and OR01001=OR03001 and OR01004=SL01001 and OR03005=SC03001 and OR030100.OR03034=0 " + " group by SL01001,SL01002,SL01060,SL01075,OR01001,OR01015,OR01016,OR01091,OR01018,OR01072,OR03005,OR03006,OR03007,OR03011,OR03012,OR010100.OR01079", connection);
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
                        if (this.rbAlmacen01.Checked)
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
                        reader = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT OR010100.OR01016,OR030100.OR03011,OR030100.OR03012 FROM dbo.OR030100,OR010100 where OR03005='", row["OR03005"]), "' and OR03012>OR03011 and OR01002=6 and OR03001=OR01001 order by OR01016")), connection).ExecuteReader();
                        if (reader.Read())
                        {
                            str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpOVPend (Cliente,NomCli,EntBloq,ExcLimCre,NroOV,FechaOV,FechaEnt,Reserva,RefCli,OCompra,CodProd,Desc1,Desc2,Cantidad,StockFisico,StockComp,FechaOC,CantOC,EntParc) values ('", row["SL01001"]), "','"), row["SL01002"]), "','"), row["SL01060"]), "','"), row["SL01075"]), "','"), row["OR01001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01016"]), "MM/dd/yyyy")), "',"), row["OR01091"]), ",'"), row["OR01018"]), "','"), row["OR01072"]), "','"), row["OR03005"]), "','"), row["OR03006"]), "','"), row["OR03007"]), "',"), ObjectType.SubObj(row["OR03011"], row["OR03012"])), ","), row["SC03003"]), ","), row["StkComp"]), ",'"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR01016"]), "MM/dd/yyyy")), "',"), ObjectType.SubObj(reader["OR03012"], reader["OR03011"])), ",'"), row["OR01079"]), "')"));
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
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                        connection.Close();
                        connection2.Close();
                        this.dtpDesdeFechaOV.Enabled = true;
                        this.dtpHastaFechaOV.Enabled = true;
                        this.dtpDesdeFechaEnt.Enabled = true;
                        this.dtpHastaFechaEnt.Enabled = true;
                        this.rbTodas.Enabled = true;
                        this.rbPlazoEnt.Enabled = true;
                        this.rbCliBloq.Enabled = true;
                        this.rbCliExc.Enabled = true;
                        this.rbConStock.Enabled = true;
                        this.rbNoEntParc.Enabled = true;
                        this.editCodCli.Enabled = true;
                        this.cmbAceptar.Enabled = true;
                        this.cmbSalir.Enabled = true;
                        ProjectData.ClearProjectError();
                        return;
                        ProjectData.ClearProjectError();
                    }
                }
                connection.Close();
                connection2.Close();
                frmRepOVPend1 pend = new frmRepOVPend1();
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

        private void dtpDesdeFechaEnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.dtpHastaFechaEnt.Focus();
            }
        }

        private void dtpDesdeFechaOV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.dtpHastaFechaOV.Focus();
            }
        }

        private void dtpHastaFechaEnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.rbAlmacen01.Focus();
            }
        }

        private void dtpHastaFechaEnt_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtpHastaFechaOV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.dtpDesdeFechaEnt.Focus();
            }
        }

        private void editCodCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.rbTodas.Focus();
            }
        }

        private void editCodCli_LostFocus(object sender, EventArgs e)
        {
            bool flag = false;
            if (StringType.StrCmp(this.editCodCli.Text, Strings.Space(0), false) != 0)
            {
                SqlConnection connection;
                try
                {
                    connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
                    connection.Open();
                    flag = true;
                    SqlDataReader reader = new SqlCommand("SELECT SL01001,SL01002 FROM SL010100 where SL01001='" + this.editCodCli.Text + "'", connection).ExecuteReader();
                    if (reader.Read())
                    {
                        this.editDescCli.Text = StringType.FromObject(reader["SL01002"]);
                        reader.Close();
                    }
                    else
                    {
                        Interaction.MsgBox("Cliente inexistente", MsgBoxStyle.Information, "Operador");
                        this.editDescCli.Text = "";
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
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                    this.Close();
                    ProjectData.ClearProjectError();
                }
            }
        }

        private void editCodCli_TextChanged(object sender, EventArgs e)
        {
        }

        ~frmRepOVPend()
        {
        }

        private void frmRepOVPend_Closed(object sender, EventArgs e)
        {
            new frmMenuOV().Show();
        }

        private void frmRepOVPend_Load(object sender, EventArgs e)
        {
            this.dtpDesdeFechaOV.Value = DateAndTime.Now;
            this.dtpHastaFechaOV.Value = DateAndTime.Now;
            this.dtpDesdeFechaEnt.Value = DateAndTime.Now;
            this.dtpHastaFechaEnt.Value = DateAndTime.Now;
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.Label3 = new Label();
            this.Label1 = new Label();
            this.Label4 = new Label();
            this.Label5 = new Label();
            this.GroupBox1 = new GroupBox();
            this.btnBusqNom = new Button();
            this.Label6 = new Label();
            this.editCodCli = new TextBox();
            this.editDescCli = new TextBox();
            this.dtpDesdeFechaOV = new DateTimePicker();
            this.dtpHastaFechaOV = new DateTimePicker();
            this.dtpDesdeFechaEnt = new DateTimePicker();
            this.dtpHastaFechaEnt = new DateTimePicker();
            this.GroupBox2 = new GroupBox();
            this.rbNoEntParc = new RadioButton();
            this.rbConStock = new RadioButton();
            this.rbCliExc = new RadioButton();
            this.rbCliBloq = new RadioButton();
            this.rbPlazoEnt = new RadioButton();
            this.rbTodas = new RadioButton();
            this.GroupBox3 = new GroupBox();
            this.rbAlmacen02 = new RadioButton();
            this.rbAlmacen01 = new RadioButton();
            this.GroupBox4 = new GroupBox();
            this.rbOrdenFechaOV = new RadioButton();
            this.rbOrdenCliente = new RadioButton();
            this.rbOrdenFechaEnt = new RadioButton();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            Point point = new Point(0x1f8, 560);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 12;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0x1f8, 0x1f8);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 13;
            this.cmbSalir.Text = "&Salir";
            point = new Point(0x100, 0x18);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(120, 0x10);
            this.Label3.Size = size;
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Hasta Fecha O.Venta:";
            point = new Point(0x10, 0x18);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(120, 0x10);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Desde Fecha O.Venta:";
            point = new Point(0x100, 0x38);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(120, 0x10);
            this.Label4.Size = size;
            this.Label4.TabIndex = 6;
            this.Label4.Text = "Hasta Fecha Entrega:";
            point = new Point(0x10, 0x38);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size(120, 0x10);
            this.Label5.Size = size;
            this.Label5.TabIndex = 4;
            this.Label5.Text = "Desde Fecha Entrega:";
            this.GroupBox1.Controls.Add(this.btnBusqNom);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.editCodCli);
            this.GroupBox1.Controls.Add(this.editDescCli);
            this.GroupBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x90);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(0x1d8, 0x60);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 9;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Cliente";
            this.btnBusqNom.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0xf8, 0x1d);
            this.btnBusqNom.Location = point;
            this.btnBusqNom.Name = "btnBusqNom";
            size = new Size(0x98, 0x17);
            this.btnBusqNom.Size = size;
            this.btnBusqNom.TabIndex = 3;
            this.btnBusqNom.Text = "&Busqueda por Nombre";
            this.Label6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x1d);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(80, 0x17);
            this.Label6.Size = size;
            this.Label6.TabIndex = 0;
            this.Label6.Text = "Cliente:";
            this.editCodCli.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(120, 0x1d);
            this.editCodCli.Location = point;
            this.editCodCli.MaxLength = 10;
            this.editCodCli.Name = "editCodCli";
            size = new Size(0x70, 20);
            this.editCodCli.Size = size;
            this.editCodCli.TabIndex = 1;
            this.editCodCli.Text = "";
            this.editDescCli.BackColor = SystemColors.Window;
            this.editDescCli.Enabled = false;
            this.editDescCli.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(120, 0x3d);
            this.editDescCli.Location = point;
            this.editDescCli.MaxLength = 0x23;
            this.editDescCli.Name = "editDescCli";
            size = new Size(0x150, 20);
            this.editDescCli.Size = size;
            this.editDescCli.TabIndex = 2;
            this.editDescCli.Text = "";
            this.dtpDesdeFechaOV.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpDesdeFechaOV.Checked = false;
            this.dtpDesdeFechaOV.CustomFormat = "dd/MM/yyyy";
            this.dtpDesdeFechaOV.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpDesdeFechaOV.Format = DateTimePickerFormat.Short;
            point = new Point(0x88, 0x10);
            this.dtpDesdeFechaOV.Location = point;
            this.dtpDesdeFechaOV.Name = "dtpDesdeFechaOV";
            this.dtpDesdeFechaOV.ShowCheckBox = true;
            size = new Size(0x70, 0x16);
            this.dtpDesdeFechaOV.Size = size;
            this.dtpDesdeFechaOV.TabIndex = 1;
            DateTime time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpDesdeFechaOV.Value = time;
            this.dtpHastaFechaOV.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpHastaFechaOV.Checked = false;
            this.dtpHastaFechaOV.CustomFormat = "dd/MM/yyyy";
            this.dtpHastaFechaOV.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpHastaFechaOV.Format = DateTimePickerFormat.Short;
            point = new Point(0x178, 0x10);
            this.dtpHastaFechaOV.Location = point;
            this.dtpHastaFechaOV.Name = "dtpHastaFechaOV";
            this.dtpHastaFechaOV.ShowCheckBox = true;
            size = new Size(0x70, 0x16);
            this.dtpHastaFechaOV.Size = size;
            this.dtpHastaFechaOV.TabIndex = 3;
            time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpHastaFechaOV.Value = time;
            this.dtpDesdeFechaEnt.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpDesdeFechaEnt.Checked = false;
            this.dtpDesdeFechaEnt.CustomFormat = "dd/MM/yyyy";
            this.dtpDesdeFechaEnt.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpDesdeFechaEnt.Format = DateTimePickerFormat.Short;
            point = new Point(0x88, 0x30);
            this.dtpDesdeFechaEnt.Location = point;
            this.dtpDesdeFechaEnt.Name = "dtpDesdeFechaEnt";
            this.dtpDesdeFechaEnt.ShowCheckBox = true;
            size = new Size(0x70, 0x16);
            this.dtpDesdeFechaEnt.Size = size;
            this.dtpDesdeFechaEnt.TabIndex = 5;
            time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpDesdeFechaEnt.Value = time;
            this.dtpHastaFechaEnt.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpHastaFechaEnt.Checked = false;
            this.dtpHastaFechaEnt.CustomFormat = "dd/MM/yyyy";
            this.dtpHastaFechaEnt.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpHastaFechaEnt.Format = DateTimePickerFormat.Short;
            point = new Point(0x178, 0x30);
            this.dtpHastaFechaEnt.Location = point;
            this.dtpHastaFechaEnt.Name = "dtpHastaFechaEnt";
            this.dtpHastaFechaEnt.ShowCheckBox = true;
            size = new Size(0x70, 0x16);
            this.dtpHastaFechaEnt.Size = size;
            this.dtpHastaFechaEnt.TabIndex = 7;
            time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpHastaFechaEnt.Value = time;
            this.GroupBox2.Controls.Add(this.rbNoEntParc);
            this.GroupBox2.Controls.Add(this.rbConStock);
            this.GroupBox2.Controls.Add(this.rbCliExc);
            this.GroupBox2.Controls.Add(this.rbCliBloq);
            this.GroupBox2.Controls.Add(this.rbPlazoEnt);
            this.GroupBox2.Controls.Add(this.rbTodas);
            this.GroupBox2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0xf8);
            this.GroupBox2.Location = point;
            this.GroupBox2.Name = "GroupBox2";
            size = new Size(0x1d8, 0xe0);
            this.GroupBox2.Size = size;
            this.GroupBox2.TabIndex = 10;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Ordenes de Venta a Listar";
            this.rbNoEntParc.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0xb8);
            this.rbNoEntParc.Location = point;
            this.rbNoEntParc.Name = "rbNoEntParc";
            size = new Size(0x198, 0x18);
            this.rbNoEntParc.Size = size;
            this.rbNoEntParc.TabIndex = 5;
            this.rbNoEntParc.Text = "Que no permiten entregas parciales y se podr\x00edan entregar parcialmente";
            this.rbConStock.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x98);
            this.rbConStock.Location = point;
            this.rbConStock.Name = "rbConStock";
            size = new Size(200, 0x18);
            this.rbConStock.Size = size;
            this.rbConStock.TabIndex = 4;
            this.rbConStock.Text = "Con Stock para todas las l\x00edneas";
            this.rbCliExc.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 120);
            this.rbCliExc.Location = point;
            this.rbCliExc.Name = "rbCliExc";
            size = new Size(0x110, 0x18);
            this.rbCliExc.Size = size;
            this.rbCliExc.TabIndex = 3;
            this.rbCliExc.Text = "Con Clientes con l\x00edmite de cr\x00e9dito excedido";
            this.rbCliBloq.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x58);
            this.rbCliBloq.Location = point;
            this.rbCliBloq.Name = "rbCliBloq";
            size = new Size(0x98, 0x18);
            this.rbCliBloq.Size = size;
            this.rbCliBloq.TabIndex = 2;
            this.rbCliBloq.Text = "Con Clientes bloqueados";
            this.rbPlazoEnt.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x38);
            this.rbPlazoEnt.Location = point;
            this.rbPlazoEnt.Name = "rbPlazoEnt";
            size = new Size(280, 0x18);
            this.rbPlazoEnt.Size = size;
            this.rbPlazoEnt.TabIndex = 1;
            this.rbPlazoEnt.Text = "Que no se puede cumplir plazo de entrega";
            this.rbTodas.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x18);
            this.rbTodas.Location = point;
            this.rbTodas.Name = "rbTodas";
            size = new Size(0x98, 0x18);
            this.rbTodas.Size = size;
            this.rbTodas.TabIndex = 0;
            this.rbTodas.Text = "Todas";
            this.GroupBox3.Controls.Add(this.rbAlmacen02);
            this.GroupBox3.Controls.Add(this.rbAlmacen01);
            this.GroupBox3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x58);
            this.GroupBox3.Location = point;
            this.GroupBox3.Name = "GroupBox3";
            size = new Size(0x1d8, 0x30);
            this.GroupBox3.Size = size;
            this.GroupBox3.TabIndex = 8;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Almac\x00e9n";
            this.rbAlmacen02.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0xac, 0x11);
            this.rbAlmacen02.Location = point;
            this.rbAlmacen02.Name = "rbAlmacen02";
            size = new Size(0x80, 0x18);
            this.rbAlmacen02.Size = size;
            this.rbAlmacen02.TabIndex = 1;
            this.rbAlmacen02.Text = "Almac\x00e9n 02";
            this.rbAlmacen01.Checked = true;
            this.rbAlmacen01.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x11);
            this.rbAlmacen01.Location = point;
            this.rbAlmacen01.Name = "rbAlmacen01";
            size = new Size(0x80, 0x18);
            this.rbAlmacen01.Size = size;
            this.rbAlmacen01.TabIndex = 0;
            this.rbAlmacen01.TabStop = true;
            this.rbAlmacen01.Text = "Almac\x00e9n 01";
            this.GroupBox4.Controls.Add(this.rbOrdenFechaOV);
            this.GroupBox4.Controls.Add(this.rbOrdenCliente);
            this.GroupBox4.Controls.Add(this.rbOrdenFechaEnt);
            this.GroupBox4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x10, 480);
            this.GroupBox4.Location = point;
            this.GroupBox4.Name = "GroupBox4";
            size = new Size(0xd0, 120);
            this.GroupBox4.Size = size;
            this.GroupBox4.TabIndex = 11;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Orden Reporte";
            this.rbOrdenFechaOV.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x58);
            this.rbOrdenFechaOV.Location = point;
            this.rbOrdenFechaOV.Name = "rbOrdenFechaOV";
            size = new Size(0xa8, 0x18);
            this.rbOrdenFechaOV.Size = size;
            this.rbOrdenFechaOV.TabIndex = 2;
            this.rbOrdenFechaOV.Text = "Fecha O.Venta";
            this.rbOrdenCliente.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x38);
            this.rbOrdenCliente.Location = point;
            this.rbOrdenCliente.Name = "rbOrdenCliente";
            size = new Size(0xa8, 0x18);
            this.rbOrdenCliente.Size = size;
            this.rbOrdenCliente.TabIndex = 1;
            this.rbOrdenCliente.Text = "N\x00b0 Cliente";
            this.rbOrdenFechaEnt.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x18);
            this.rbOrdenFechaEnt.Location = point;
            this.rbOrdenFechaEnt.Name = "rbOrdenFechaEnt";
            size = new Size(0xa8, 0x18);
            this.rbOrdenFechaEnt.Size = size;
            this.rbOrdenFechaEnt.TabIndex = 0;
            this.rbOrdenFechaEnt.Text = "Fecha Entrega Prevista";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x340, 0x2bd);
            this.ClientSize = size;
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.dtpHastaFechaEnt);
            this.Controls.Add(this.dtpDesdeFechaEnt);
            this.Controls.Add(this.dtpHastaFechaOV);
            this.Controls.Add(this.dtpDesdeFechaOV);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Name = "frmRepOVPend";
            this.Text = "Reporte O.Venta Pendientes";
            this.WindowState = FormWindowState.Maximized;
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbAlmacen01_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbAlmacen01_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editCodCli.Focus();
            }
        }

        private void rbAlmacen02_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbAlmacen02_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editCodCli.Focus();
            }
        }

        private void rbCliBloq_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbCliBloq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                if (this.rbCliBloq.Checked)
                {
                    this.cmbAceptar.Focus();
                }
                else
                {
                    this.rbCliExc.Focus();
                }
            }
        }

        private void rbCliExc_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbCliExc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                if (this.rbCliExc.Checked)
                {
                    this.cmbAceptar.Focus();
                }
                else
                {
                    this.rbConStock.Focus();
                }
            }
        }

        private void rbConStock_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbConStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                if (this.rbConStock.Checked)
                {
                    this.cmbAceptar.Focus();
                }
                else
                {
                    this.rbNoEntParc.Focus();
                }
            }
        }

        private void rbNoEntParc_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbNoEntParc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.rbOrdenFechaEnt.Focus();
            }
        }

        private void rbOrdenCliente_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbOrdenCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void rbOrdenFechaEnt_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbOrdenFechaEnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void rbOrdenFechaOV_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbOrdenFechaOV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void rbPlazoEnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                if (this.rbPlazoEnt.Checked)
                {
                    this.cmbAceptar.Focus();
                }
                else
                {
                    this.rbCliBloq.Focus();
                }
            }
        }

        private void rbTodas_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbTodas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                if (this.rbTodas.Checked)
                {
                    this.cmbAceptar.Focus();
                }
                else
                {
                    this.rbPlazoEnt.Focus();
                }
            }
        }

        internal virtual Button btnBusqNom
        {
            get
            {
                return this._btnBusqNom;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnBusqNom != null)
                {
                    this._btnBusqNom.Click -= new EventHandler(this.btnBusqNom_Click);
                }
                this._btnBusqNom = value;
                if (this._btnBusqNom != null)
                {
                    this._btnBusqNom.Click += new EventHandler(this.btnBusqNom_Click);
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

        internal virtual DateTimePicker dtpDesdeFechaEnt
        {
            get
            {
                return this._dtpDesdeFechaEnt;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpDesdeFechaEnt != null)
                {
                    this._dtpDesdeFechaEnt.KeyPress -= new KeyPressEventHandler(this.dtpDesdeFechaEnt_KeyPress);
                }
                this._dtpDesdeFechaEnt = value;
                if (this._dtpDesdeFechaEnt != null)
                {
                    this._dtpDesdeFechaEnt.KeyPress += new KeyPressEventHandler(this.dtpDesdeFechaEnt_KeyPress);
                }
            }
        }

        internal virtual DateTimePicker dtpDesdeFechaOV
        {
            get
            {
                return this._dtpDesdeFechaOV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpDesdeFechaOV != null)
                {
                    this._dtpDesdeFechaOV.KeyPress -= new KeyPressEventHandler(this.dtpDesdeFechaOV_KeyPress);
                }
                this._dtpDesdeFechaOV = value;
                if (this._dtpDesdeFechaOV != null)
                {
                    this._dtpDesdeFechaOV.KeyPress += new KeyPressEventHandler(this.dtpDesdeFechaOV_KeyPress);
                }
            }
        }

        internal virtual DateTimePicker dtpHastaFechaEnt
        {
            get
            {
                return this._dtpHastaFechaEnt;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpHastaFechaEnt != null)
                {
                    this._dtpHastaFechaEnt.KeyPress -= new KeyPressEventHandler(this.dtpHastaFechaEnt_KeyPress);
                    this._dtpHastaFechaEnt.ValueChanged -= new EventHandler(this.dtpHastaFechaEnt_ValueChanged);
                }
                this._dtpHastaFechaEnt = value;
                if (this._dtpHastaFechaEnt != null)
                {
                    this._dtpHastaFechaEnt.KeyPress += new KeyPressEventHandler(this.dtpHastaFechaEnt_KeyPress);
                    this._dtpHastaFechaEnt.ValueChanged += new EventHandler(this.dtpHastaFechaEnt_ValueChanged);
                }
            }
        }

        internal virtual DateTimePicker dtpHastaFechaOV
        {
            get
            {
                return this._dtpHastaFechaOV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpHastaFechaOV != null)
                {
                    this._dtpHastaFechaOV.KeyPress -= new KeyPressEventHandler(this.dtpHastaFechaOV_KeyPress);
                }
                this._dtpHastaFechaOV = value;
                if (this._dtpHastaFechaOV != null)
                {
                    this._dtpHastaFechaOV.KeyPress += new KeyPressEventHandler(this.dtpHastaFechaOV_KeyPress);
                }
            }
        }

        internal virtual TextBox editCodCli
        {
            get
            {
                return this._editCodCli;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editCodCli != null)
                {
                    this._editCodCli.KeyPress -= new KeyPressEventHandler(this.editCodCli_KeyPress);
                    this._editCodCli.LostFocus -= new EventHandler(this.editCodCli_LostFocus);
                    this._editCodCli.TextChanged -= new EventHandler(this.editCodCli_TextChanged);
                }
                this._editCodCli = value;
                if (this._editCodCli != null)
                {
                    this._editCodCli.KeyPress += new KeyPressEventHandler(this.editCodCli_KeyPress);
                    this._editCodCli.LostFocus += new EventHandler(this.editCodCli_LostFocus);
                    this._editCodCli.TextChanged += new EventHandler(this.editCodCli_TextChanged);
                }
            }
        }

        internal virtual TextBox editDescCli
        {
            get
            {
                return this._editDescCli;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editDescCli != null)
                {
                }
                this._editDescCli = value;
                if (this._editDescCli != null)
                {
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
                    this._GroupBox2.Enter -= new EventHandler(this.GroupBox2_Enter);
                }
                this._GroupBox2 = value;
                if (this._GroupBox2 != null)
                {
                    this._GroupBox2.Enter += new EventHandler(this.GroupBox2_Enter);
                }
            }
        }

        internal virtual GroupBox GroupBox3
        {
            get
            {
                return this._GroupBox3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._GroupBox3 != null)
                {
                }
                this._GroupBox3 = value;
                if (this._GroupBox3 != null)
                {
                }
            }
        }

        internal virtual GroupBox GroupBox4
        {
            get
            {
                return this._GroupBox4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._GroupBox4 != null)
                {
                }
                this._GroupBox4 = value;
                if (this._GroupBox4 != null)
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

        internal virtual Label Label5
        {
            get
            {
                return this._Label5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label5 != null)
                {
                }
                this._Label5 = value;
                if (this._Label5 != null)
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

        internal virtual RadioButton rbAlmacen01
        {
            get
            {
                return this._rbAlmacen01;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbAlmacen01 != null)
                {
                    this._rbAlmacen01.KeyPress -= new KeyPressEventHandler(this.rbAlmacen01_KeyPress);
                    this._rbAlmacen01.CheckedChanged -= new EventHandler(this.rbAlmacen01_CheckedChanged);
                }
                this._rbAlmacen01 = value;
                if (this._rbAlmacen01 != null)
                {
                    this._rbAlmacen01.KeyPress += new KeyPressEventHandler(this.rbAlmacen01_KeyPress);
                    this._rbAlmacen01.CheckedChanged += new EventHandler(this.rbAlmacen01_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbAlmacen02
        {
            get
            {
                return this._rbAlmacen02;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbAlmacen02 != null)
                {
                    this._rbAlmacen02.KeyPress -= new KeyPressEventHandler(this.rbAlmacen02_KeyPress);
                    this._rbAlmacen02.CheckedChanged -= new EventHandler(this.rbAlmacen02_CheckedChanged);
                }
                this._rbAlmacen02 = value;
                if (this._rbAlmacen02 != null)
                {
                    this._rbAlmacen02.KeyPress += new KeyPressEventHandler(this.rbAlmacen02_KeyPress);
                    this._rbAlmacen02.CheckedChanged += new EventHandler(this.rbAlmacen02_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbCliBloq
        {
            get
            {
                return this._rbCliBloq;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbCliBloq != null)
                {
                    this._rbCliBloq.KeyPress -= new KeyPressEventHandler(this.rbCliBloq_KeyPress);
                    this._rbCliBloq.CheckedChanged -= new EventHandler(this.rbCliBloq_CheckedChanged);
                }
                this._rbCliBloq = value;
                if (this._rbCliBloq != null)
                {
                    this._rbCliBloq.KeyPress += new KeyPressEventHandler(this.rbCliBloq_KeyPress);
                    this._rbCliBloq.CheckedChanged += new EventHandler(this.rbCliBloq_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbCliExc
        {
            get
            {
                return this._rbCliExc;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbCliExc != null)
                {
                    this._rbCliExc.KeyPress -= new KeyPressEventHandler(this.rbCliExc_KeyPress);
                    this._rbCliExc.CheckedChanged -= new EventHandler(this.rbCliExc_CheckedChanged);
                }
                this._rbCliExc = value;
                if (this._rbCliExc != null)
                {
                    this._rbCliExc.KeyPress += new KeyPressEventHandler(this.rbCliExc_KeyPress);
                    this._rbCliExc.CheckedChanged += new EventHandler(this.rbCliExc_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbConStock
        {
            get
            {
                return this._rbConStock;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbConStock != null)
                {
                    this._rbConStock.KeyPress -= new KeyPressEventHandler(this.rbConStock_KeyPress);
                    this._rbConStock.CheckedChanged -= new EventHandler(this.rbConStock_CheckedChanged);
                }
                this._rbConStock = value;
                if (this._rbConStock != null)
                {
                    this._rbConStock.KeyPress += new KeyPressEventHandler(this.rbConStock_KeyPress);
                    this._rbConStock.CheckedChanged += new EventHandler(this.rbConStock_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbNoEntParc
        {
            get
            {
                return this._rbNoEntParc;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbNoEntParc != null)
                {
                    this._rbNoEntParc.KeyPress -= new KeyPressEventHandler(this.rbNoEntParc_KeyPress);
                    this._rbNoEntParc.CheckedChanged -= new EventHandler(this.rbNoEntParc_CheckedChanged);
                }
                this._rbNoEntParc = value;
                if (this._rbNoEntParc != null)
                {
                    this._rbNoEntParc.KeyPress += new KeyPressEventHandler(this.rbNoEntParc_KeyPress);
                    this._rbNoEntParc.CheckedChanged += new EventHandler(this.rbNoEntParc_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbOrdenCliente
        {
            get
            {
                return this._rbOrdenCliente;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbOrdenCliente != null)
                {
                    this._rbOrdenCliente.KeyPress -= new KeyPressEventHandler(this.rbOrdenCliente_KeyPress);
                    this._rbOrdenCliente.CheckedChanged -= new EventHandler(this.rbOrdenCliente_CheckedChanged);
                }
                this._rbOrdenCliente = value;
                if (this._rbOrdenCliente != null)
                {
                    this._rbOrdenCliente.KeyPress += new KeyPressEventHandler(this.rbOrdenCliente_KeyPress);
                    this._rbOrdenCliente.CheckedChanged += new EventHandler(this.rbOrdenCliente_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbOrdenFechaEnt
        {
            get
            {
                return this._rbOrdenFechaEnt;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbOrdenFechaEnt != null)
                {
                    this._rbOrdenFechaEnt.KeyPress -= new KeyPressEventHandler(this.rbOrdenFechaEnt_KeyPress);
                    this._rbOrdenFechaEnt.CheckedChanged -= new EventHandler(this.rbOrdenFechaEnt_CheckedChanged);
                }
                this._rbOrdenFechaEnt = value;
                if (this._rbOrdenFechaEnt != null)
                {
                    this._rbOrdenFechaEnt.KeyPress += new KeyPressEventHandler(this.rbOrdenFechaEnt_KeyPress);
                    this._rbOrdenFechaEnt.CheckedChanged += new EventHandler(this.rbOrdenFechaEnt_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbOrdenFechaOV
        {
            get
            {
                return this._rbOrdenFechaOV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbOrdenFechaOV != null)
                {
                    this._rbOrdenFechaOV.KeyPress -= new KeyPressEventHandler(this.rbOrdenFechaOV_KeyPress);
                    this._rbOrdenFechaOV.CheckedChanged -= new EventHandler(this.rbOrdenFechaOV_CheckedChanged);
                }
                this._rbOrdenFechaOV = value;
                if (this._rbOrdenFechaOV != null)
                {
                    this._rbOrdenFechaOV.KeyPress += new KeyPressEventHandler(this.rbOrdenFechaOV_KeyPress);
                    this._rbOrdenFechaOV.CheckedChanged += new EventHandler(this.rbOrdenFechaOV_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbPlazoEnt
        {
            get
            {
                return this._rbPlazoEnt;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbPlazoEnt != null)
                {
                    this._rbPlazoEnt.KeyPress -= new KeyPressEventHandler(this.rbPlazoEnt_KeyPress);
                    this._rbPlazoEnt.CheckedChanged -= new EventHandler(this.RadioButton1_CheckedChanged);
                }
                this._rbPlazoEnt = value;
                if (this._rbPlazoEnt != null)
                {
                    this._rbPlazoEnt.KeyPress += new KeyPressEventHandler(this.rbPlazoEnt_KeyPress);
                    this._rbPlazoEnt.CheckedChanged += new EventHandler(this.RadioButton1_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbTodas
        {
            get
            {
                return this._rbTodas;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbTodas != null)
                {
                    this._rbTodas.KeyPress -= new KeyPressEventHandler(this.rbTodas_KeyPress);
                    this._rbTodas.CheckedChanged -= new EventHandler(this.rbTodas_CheckedChanged);
                }
                this._rbTodas = value;
                if (this._rbTodas != null)
                {
                    this._rbTodas.KeyPress += new KeyPressEventHandler(this.rbTodas_KeyPress);
                    this._rbTodas.CheckedChanged += new EventHandler(this.rbTodas_CheckedChanged);
                }
            }
        }
    }
}

