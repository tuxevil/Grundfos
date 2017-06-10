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

    public class frmConsultaOV : Form
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
        [AccessedThroughProperty("editNroOCCli")]
        private TextBox _editNroOCCli;
        [AccessedThroughProperty("editNroOV")]
        private TextBox _editNroOV;
        [AccessedThroughProperty("editNroRM")]
        private TextBox _editNroRM;
        [AccessedThroughProperty("editSucRM")]
        private TextBox _editSucRM;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("Label5")]
        private Label _Label5;
        [AccessedThroughProperty("Label6")]
        private Label _Label6;
        [AccessedThroughProperty("Label7")]
        private Label _Label7;
        [AccessedThroughProperty("Label9")]
        private Label _Label9;
        private IContainer components;

        public frmConsultaOV()
        {
            base.Closed += new EventHandler(this.frmConsultaOV_Closed);
            base.Load += new EventHandler(this.frmConsultaOV_Load);
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
                Interaction.MsgBox("Debe ingresar desde fecha o.venta", 0x10, "Operador");
                this.dtpDesdeFechaOV.Checked = true;
            }
            else if (this.dtpDesdeFechaOV.Checked & !this.dtpHastaFechaOV.Checked)
            {
                Interaction.MsgBox("Debe ingresar hasta fecha o.venta", 0x10, "Operador");
                this.dtpHastaFechaOV.Checked = true;
            }
            else if (!this.dtpDesdeFechaEnt.Checked & this.dtpHastaFechaEnt.Checked)
            {
                Interaction.MsgBox("Debe ingresar desde fecha entrega", 0x10, "Operador");
                this.dtpDesdeFechaEnt.Checked = true;
            }
            else if (this.dtpDesdeFechaEnt.Checked & !this.dtpHastaFechaEnt.Checked)
            {
                Interaction.MsgBox("Debe ingresar hasta fecha entrega", 0x10, "Operador");
                this.dtpHastaFechaEnt.Checked = true;
            }
            else if ((StringType.StrCmp(this.editCodCli.Text, Strings.Space(0), false) != 0) && (StringType.StrCmp(this.editDescCli.Text, Strings.Space(0), false) == 0))
            {
                Interaction.MsgBox("Cliente inexistente", 0x10, "Operador");
                this.editCodCli.Focus();
            }
            else if ((StringType.StrCmp(this.editSucRM.Text, Strings.Space(0), false) != 0) && !Information.IsNumeric(this.editSucRM.Text))
            {
                Interaction.MsgBox("Sucursal debe ser num\x00e9rica", 0x10, "Operador");
                this.editSucRM.Focus();
            }
            else if ((StringType.StrCmp(this.editNroRM.Text, Strings.Space(0), false) != 0) && !Information.IsNumeric(this.editNroRM.Text))
            {
                Interaction.MsgBox("Nro.Remito debe ser num\x00e9rico", 0x10, "Operador");
                this.editNroRM.Focus();
            }
            else if ((StringType.StrCmp(this.editSucRM.Text, Strings.Space(0), false) != 0) & (StringType.StrCmp(this.editNroRM.Text, Strings.Space(0), false) == 0))
            {
                Interaction.MsgBox("Debe ingresar Nro.Remito", 0x10, "Operador");
                this.editNroRM.Focus();
            }
            else if ((StringType.StrCmp(this.editSucRM.Text, Strings.Space(0), false) == 0) & (StringType.StrCmp(this.editNroRM.Text, Strings.Space(0), false) != 0))
            {
                Interaction.MsgBox("Debe ingresar Sucursal del Remito", 0x10, "Operador");
                this.editSucRM.Focus();
            }
            else
            {
                SqlConnection connection;
                SqlConnection connection2;
                this.dtpDesdeFechaOV.Enabled = false;
                this.dtpHastaFechaOV.Enabled = false;
                this.dtpDesdeFechaEnt.Enabled = false;
                this.dtpHastaFechaEnt.Enabled = false;
                this.editCodCli.Enabled = false;
                this.editNroOV.Enabled = false;
                this.editNroOCCli.Enabled = false;
                this.editSucRM.Enabled = false;
                this.editNroRM.Enabled = false;
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
                if (StringType.StrCmp(this.editNroOV.Text, Strings.Space(0), false) != 0)
                {
                    Variables.gNroOVCons = Strings.Format(Conversion.Val(this.editNroOV.Text), "0000000000");
                }
                else
                {
                    Variables.gNroOVCons = "";
                }
                Variables.gNroOCCons = this.editNroOCCli.Text;
                if ((StringType.StrCmp(this.editSucRM.Text, Strings.Space(0), false) != 0) & (StringType.StrCmp(this.editNroRM.Text, Strings.Space(0), false) != 0))
                {
                    Variables.gNroRemito = Strings.Format(IntegerType.FromString(this.editSucRM.Text), "0000") + "-" + Strings.Format(LongType.FromString(this.editNroRM.Text), "00000000");
                }
                else
                {
                    Variables.gNroRemito = "";
                }
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
                    if (this.dtpDesdeFechaOV.Checked & this.dtpHastaFechaOV.Checked)
                    {
                        str = str + " and OR01015>='" + Strings.Format(DateType.FromString(Variables.gDesdeFechaOV), "MM/dd/yyyy") + "' and OR01015<='" + Strings.Format(DateType.FromString(Variables.gHastaFechaOV), "MM/dd/yyyy") + "'";
                    }
                    if (this.dtpDesdeFechaEnt.Checked & this.dtpHastaFechaEnt.Checked)
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
                    SqlDataAdapter adapter2 = new SqlDataAdapter();
                    adapter2.SelectCommand = command2;
                    connection.Open();
                    adapter2.Fill(dataSet, "OR010100");
                    long num4 = dataSet.Tables["OR010100"].Rows.Count - 1;
                    for (num = 0L; num <= num4; num += 1L)
                    {
                        row = dataSet.Tables["OR010100"].Rows[(int) num];
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
                                command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT NroOV FROM PrepPed where NroOV='", row["OR01001"]), "' and FechaPrep='"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR19009"]), "MM/dd/yyyy")), "' and FechaContFinal is null")), connection2);
                                reader = command.ExecuteReader();
                                if (reader.Read())
                                {
                                    str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpConsOV (NroOV,TipoOV,Cliente,NomCli,OCompra,CodMetEnt,DescMetEnt,LugarEnt,FechaOV,FechaEnt,FechaPrep,Remito,CodEstado,Estado) values ('", row["OR01001"]), "',"), row["OR01002"]), ",'"), row["OR01004"]), "','"), row["SL01002"]), "','"), row["OR01072"]), "',"), row["OR01014"]), ",'"), row["SL23004"]), "','"), Strings.Trim(StringType.FromObject(row["OR04003"]))), " "), Strings.Trim(StringType.FromObject(row["OR04004"]))), " "), Strings.Trim(StringType.FromObject(row["OR04005"]))), " "), Strings.Trim(StringType.FromObject(row["OR04008"]))), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR19009"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR19011"]), "MM/dd/yyyy")), "','"), row["OR01023"]), "',2,'Pendiente Control Final')"));
                                    reader.Close();
                                    command4 = new SqlCommand(str4, connection2);
                                    num2 = command4.ExecuteNonQuery();
                                }
                                else
                                {
                                    reader.Close();
                                }
                                command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT NroOV FROM PrepPed where NroOV='", row["OR01001"]), "' and FechaPrep='"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR19009"]), "MM/dd/yyyy")), "' and not FechaContFinal is null and FechaExp is null")), connection2);
                                reader = command.ExecuteReader();
                                if (reader.Read())
                                {
                                    str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpConsOV (NroOV,TipoOV,Cliente,NomCli,OCompra,CodMetEnt,DescMetEnt,LugarEnt,FechaOV,FechaEnt,FechaPrep,Remito,CodEstado,Estado) values ('", row["OR01001"]), "',"), row["OR01002"]), ",'"), row["OR01004"]), "','"), row["SL01002"]), "','"), row["OR01072"]), "',"), row["OR01014"]), ",'"), row["SL23004"]), "','"), Strings.Trim(StringType.FromObject(row["OR04003"]))), " "), Strings.Trim(StringType.FromObject(row["OR04004"]))), " "), Strings.Trim(StringType.FromObject(row["OR04005"]))), " "), Strings.Trim(StringType.FromObject(row["OR04008"]))), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR19009"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR19011"]), "MM/dd/yyyy")), "','"), row["OR01023"]), "',3,'Pendiente de Expedici\x00f3n')"));
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
                                        str4 = str4 + "4,'Expedido')";
                                    }
                                    else
                                    {
                                        str4 = str4 + "6,'Recepci\x00f3n Conformada')";
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
                                    str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj((StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpConsOV (NroOV,TipoOV,Cliente,NomCli,OCompra,CodMetEnt,DescMetEnt,LugarEnt,FechaOV,FechaEnt,FechaPrep,Remito,CodEstado,Estado) values ('", row["OR01001"]), "',"), row["OR01002"]), ",'"), row["OR01004"]), "','"), row["SL01002"]), "','"), row["OR01072"]), "',"), row["OR01014"]), ",'"), row["SL23004"]), "','"), Strings.Trim(StringType.FromObject(row["OR04003"]))), " "), Strings.Trim(StringType.FromObject(row["OR04004"]))), " "), Strings.Trim(StringType.FromObject(row["OR04005"]))), " "), Strings.Trim(StringType.FromObject(row["OR04008"]))), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01015"]), "MM/dd/yyyy")), "',")) + "Null,'" + Strings.Format(RuntimeHelpers.GetObjectValue(reader["FechaPrep"]), "MM/dd/yyyy") + "',") + "'", row["OR01023"]), "',")) + "5,'Prep.Pend.Imp.Doc.Exp.')";
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
                    if (this.dtpDesdeFechaOV.Checked & this.dtpHastaFechaOV.Checked)
                    {
                        str = str + " and OR20015>='" + Strings.Format(DateType.FromString(Variables.gDesdeFechaOV), "MM/dd/yyyy") + "' and OR20015<='" + Strings.Format(DateType.FromString(Variables.gHastaFechaOV), "MM/dd/yyyy") + "'";
                    }
                    if (this.dtpDesdeFechaEnt.Checked & this.dtpHastaFechaEnt.Checked)
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
                    SqlDataAdapter adapter3 = new SqlDataAdapter();
                    adapter3.SelectCommand = command2;
                    adapter3.Fill(dataSet, "OR200100");
                    long num3 = dataSet.Tables["OR200100"].Rows.Count - 1;
                    for (num = 0L; num <= num3; num += 1L)
                    {
                        row = dataSet.Tables["OR200100"].Rows[(int) num];
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
                                command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT NroOV FROM PrepPed where NroOV='", row["OR20001"]), "' and FechaContFinal is null")), connection2);
                                reader = command.ExecuteReader();
                                if (reader.Read())
                                {
                                    str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpConsOV (NroOV,TipoOV,Cliente,NomCli,OCompra,CodMetEnt,DescMetEnt,LugarEnt,FechaOV,FechaEnt,FechaPrep,Remito,CodEstado,Estado) values ('", row["OR20001"]), "',"), row["OR20002"]), ",'"), row["OR20004"]), "','"), row["SL01002"]), "','"), row["OR20072"]), "',"), row["OR20014"]), ",'"), row["SL23004"]), "','"), Strings.Trim(StringType.FromObject(row["OR22003"]))), " "), Strings.Trim(StringType.FromObject(row["OR22004"]))), " "), Strings.Trim(StringType.FromObject(row["OR22005"]))), " "), Strings.Trim(StringType.FromObject(row["OR22008"]))), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR20015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR23009"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR23011"]), "MM/dd/yyyy")), "','"), row["OR20023"]), "',2,'Pendiente Control Final')"));
                                    reader.Close();
                                    command4 = new SqlCommand(str4, connection2);
                                    num2 = command4.ExecuteNonQuery();
                                }
                                else
                                {
                                    reader.Close();
                                }
                                command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT NroOV FROM PrepPed where NroOV='", row["OR20001"]), "' and not FechaContFinal is null and FechaExp is null")), connection2);
                                reader = command.ExecuteReader();
                                if (reader.Read())
                                {
                                    str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpConsOV (NroOV,TipoOV,Cliente,NomCli,OCompra,CodMetEnt,DescMetEnt,LugarEnt,FechaOV,FechaEnt,FechaPrep,Remito,CodEstado,Estado) values ('", row["OR20001"]), "',"), row["OR20002"]), ",'"), row["OR20004"]), "','"), row["SL01002"]), "','"), row["OR20072"]), "',"), row["OR20014"]), ",'"), row["SL23004"]), "','"), Strings.Trim(StringType.FromObject(row["OR22003"]))), " "), Strings.Trim(StringType.FromObject(row["OR22004"]))), " "), Strings.Trim(StringType.FromObject(row["OR22005"]))), " "), Strings.Trim(StringType.FromObject(row["OR22008"]))), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR20015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR23009"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR23011"]), "MM/dd/yyyy")), "','"), row["OR20023"]), "',3,'Pendiente de Expedici\x00f3n')"));
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
                                        str4 = str4 + "4,'Expedido')";
                                    }
                                    else
                                    {
                                        str4 = str4 + "6,'Recepci\x00f3n Conformada')";
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
                                    str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj((StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpConsOV (NroOV,TipoOV,Cliente,NomCli,OCompra,CodMetEnt,DescMetEnt,LugarEnt,FechaOV,FechaEnt,FechaPrep,Remito,CodEstado,Estado) values ('", row["OR20001"]), "',"), row["OR20002"]), ",'"), row["OR20004"]), "','"), row["SL01002"]), "','"), row["OR20072"]), "',"), row["OR20014"]), ",'"), row["SL23004"]), "','"), Strings.Trim(StringType.FromObject(row["OR22003"]))), " "), Strings.Trim(StringType.FromObject(row["OR22004"]))), " "), Strings.Trim(StringType.FromObject(row["OR22005"]))), " "), Strings.Trim(StringType.FromObject(row["OR22008"]))), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR20015"]), "MM/dd/yyyy")), "',")) + "Null,'" + Strings.Format(RuntimeHelpers.GetObjectValue(reader["FechaPrep"]), "MM/dd/yyyy")) + "','", row["OR20023"]), "',")) + "5,'Prep.Pend.Imp.Doc.Exp.')";
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
                    this.dtpDesdeFechaOV.Enabled = true;
                    this.dtpHastaFechaOV.Enabled = true;
                    this.dtpDesdeFechaEnt.Enabled = true;
                    this.dtpHastaFechaEnt.Enabled = true;
                    this.editCodCli.Enabled = true;
                    this.editSucRM.Enabled = true;
                    this.editNroRM.Enabled = true;
                    this.cmbAceptar.Enabled = true;
                    this.cmbSalir.Enabled = true;
                    ProjectData.ClearProjectError();
                    return;
                    ProjectData.ClearProjectError();
                }
                frmConsultaOV1 aov = new frmConsultaOV1();
                this.Hide();
                aov.Show();
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
                this.editCodCli.Focus();
            }
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
                this.editNroOV.Focus();
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
                        Interaction.MsgBox("Cliente inexistente", 0x40, "Operador");
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
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                    this.Close();
                    ProjectData.ClearProjectError();
                }
            }
        }

        private void editCodCli_TextChanged(object sender, EventArgs e)
        {
        }

        private void editNroOCCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editSucRM.Focus();
            }
        }

        private void editNroOCCli_TextChanged(object sender, EventArgs e)
        {
        }

        private void editNroOV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editNroOCCli.Focus();
            }
        }

        private void editNroOV_TextChanged(object sender, EventArgs e)
        {
        }

        private void editNroRM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void editNroRM_TextChanged(object sender, EventArgs e)
        {
        }

        private void editSucRM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editNroRM.Focus();
            }
        }

        private void editSucRM_TextChanged(object sender, EventArgs e)
        {
        }

        ~frmConsultaOV()
        {
        }

        private void frmConsultaOV_Closed(object sender, EventArgs e)
        {
            if (StringType.StrCmp(Variables.gMenuOV, "L", false) == 0)
            {
                new frmMenuOV().Show();
            }
            else
            {
                new frmMenuOVExp().Show();
            }
        }

        private void frmConsultaOV_Load(object sender, EventArgs e)
        {
            this.dtpDesdeFechaOV.Value = DateAndTime.get_Now();
            this.dtpHastaFechaOV.Value = DateAndTime.get_Now();
            this.dtpDesdeFechaEnt.Value = DateAndTime.get_Now();
            this.dtpHastaFechaEnt.Value = DateAndTime.get_Now();
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
            this.Label2 = new Label();
            this.editNroOV = new TextBox();
            this.Label7 = new Label();
            this.editNroOCCli = new TextBox();
            this.editSucRM = new TextBox();
            this.editNroRM = new TextBox();
            this.Label9 = new Label();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            Point point = new Point(0x188, 0x130);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 0x10;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0x120, 0x130);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 0x11;
            this.cmbSalir.Text = "&Salir";
            point = new Point(0x100, 0x10);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(120, 0x10);
            this.Label3.Size = size;
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Hasta Fecha O.Venta:";
            point = new Point(0x10, 0x10);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(120, 0x10);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Desde Fecha O.Venta:";
            point = new Point(0x100, 0x30);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(120, 0x10);
            this.Label4.Size = size;
            this.Label4.TabIndex = 6;
            this.Label4.Text = "Hasta Fecha Entrega:";
            point = new Point(0x10, 0x30);
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
            point = new Point(0x10, 0x58);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(0x1d8, 0x60);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 8;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Cliente";
            this.btnBusqNom.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(240, 0x1d);
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
            size = new Size(0x68, 20);
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
            this.Label2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 200);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(80, 0x17);
            this.Label2.Size = size;
            this.Label2.TabIndex = 9;
            this.Label2.Text = "Nro.O.Venta:";
            this.editNroOV.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x88, 200);
            this.editNroOV.Location = point;
            this.editNroOV.MaxLength = 10;
            this.editNroOV.Name = "editNroOV";
            size = new Size(0x70, 20);
            this.editNroOV.Size = size;
            this.editNroOV.TabIndex = 10;
            this.editNroOV.Text = "";
            this.Label7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0xe8);
            this.Label7.Location = point;
            this.Label7.Name = "Label7";
            size = new Size(120, 0x17);
            this.Label7.Size = size;
            this.Label7.TabIndex = 11;
            this.Label7.Text = "Nro.O.Compra Cliente:";
            this.editNroOCCli.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x88, 0xe8);
            this.editNroOCCli.Location = point;
            this.editNroOCCli.MaxLength = 20;
            this.editNroOCCli.Name = "editNroOCCli";
            size = new Size(0xe0, 20);
            this.editNroOCCli.Size = size;
            this.editNroOCCli.TabIndex = 12;
            this.editNroOCCli.Text = "";
            this.editSucRM.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x88, 0x108);
            this.editSucRM.Location = point;
            this.editSucRM.MaxLength = 4;
            this.editSucRM.Name = "editSucRM";
            size = new Size(0x30, 20);
            this.editSucRM.Size = size;
            this.editSucRM.TabIndex = 14;
            this.editSucRM.Text = "";
            this.editNroRM.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0xc0, 0x108);
            this.editNroRM.Location = point;
            this.editNroRM.MaxLength = 14;
            this.editNroRM.Name = "editNroRM";
            size = new Size(0xa8, 20);
            this.editNroRM.Size = size;
            this.editNroRM.TabIndex = 15;
            this.editNroRM.Text = "";
            this.Label9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x108);
            this.Label9.Location = point;
            this.Label9.Name = "Label9";
            size = new Size(80, 0x10);
            this.Label9.Size = size;
            this.Label9.TabIndex = 13;
            this.Label9.Text = "N\x00b0 Remito:";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.editSucRM);
            this.Controls.Add(this.editNroRM);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.editNroOCCli);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.editNroOV);
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
            this.Name = "frmConsultaOV";
            this.Text = "Consulta Ordenes de Venta";
            this.WindowState = FormWindowState.Maximized;
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
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
                }
                this._dtpHastaFechaEnt = value;
                if (this._dtpHastaFechaEnt != null)
                {
                    this._dtpHastaFechaEnt.KeyPress += new KeyPressEventHandler(this.dtpHastaFechaEnt_KeyPress);
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

        internal virtual TextBox editNroOCCli
        {
            get
            {
                return this._editNroOCCli;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editNroOCCli != null)
                {
                    this._editNroOCCli.KeyPress -= new KeyPressEventHandler(this.editNroOCCli_KeyPress);
                    this._editNroOCCli.TextChanged -= new EventHandler(this.editNroOCCli_TextChanged);
                }
                this._editNroOCCli = value;
                if (this._editNroOCCli != null)
                {
                    this._editNroOCCli.KeyPress += new KeyPressEventHandler(this.editNroOCCli_KeyPress);
                    this._editNroOCCli.TextChanged += new EventHandler(this.editNroOCCli_TextChanged);
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
                }
                this._editNroOV = value;
                if (this._editNroOV != null)
                {
                    this._editNroOV.KeyPress += new KeyPressEventHandler(this.editNroOV_KeyPress);
                    this._editNroOV.TextChanged += new EventHandler(this.editNroOV_TextChanged);
                }
            }
        }

        internal virtual TextBox editNroRM
        {
            get
            {
                return this._editNroRM;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editNroRM != null)
                {
                    this._editNroRM.KeyPress -= new KeyPressEventHandler(this.editNroRM_KeyPress);
                    this._editNroRM.TextChanged -= new EventHandler(this.editNroRM_TextChanged);
                }
                this._editNroRM = value;
                if (this._editNroRM != null)
                {
                    this._editNroRM.KeyPress += new KeyPressEventHandler(this.editNroRM_KeyPress);
                    this._editNroRM.TextChanged += new EventHandler(this.editNroRM_TextChanged);
                }
            }
        }

        internal virtual TextBox editSucRM
        {
            get
            {
                return this._editSucRM;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editSucRM != null)
                {
                    this._editSucRM.KeyPress -= new KeyPressEventHandler(this.editSucRM_KeyPress);
                    this._editSucRM.TextChanged -= new EventHandler(this.editSucRM_TextChanged);
                }
                this._editSucRM = value;
                if (this._editSucRM != null)
                {
                    this._editSucRM.KeyPress += new KeyPressEventHandler(this.editSucRM_KeyPress);
                    this._editSucRM.TextChanged += new EventHandler(this.editSucRM_TextChanged);
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

        internal virtual Label Label7
        {
            get
            {
                return this._Label7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label7 != null)
                {
                }
                this._Label7 = value;
                if (this._Label7 != null)
                {
                }
            }
        }

        internal virtual Label Label9
        {
            get
            {
                return this._Label9;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label9 != null)
                {
                }
                this._Label9 = value;
                if (this._Label9 != null)
                {
                }
            }
        }
    }
}

