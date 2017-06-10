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
    using System.IO;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmDiscrepanciasOC : Form
    {
        [AccessedThroughProperty("btnCancelar")]
        private Button _btnCancelar;
        [AccessedThroughProperty("btnModificar")]
        private Button _btnModificar;
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbReclamosOC")]
        private Button _cmbReclamosOC;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dgRecepcion")]
        private DataGrid _dgRecepcion;
        [AccessedThroughProperty("dtpFechaEntOPend")]
        private DateTimePicker _dtpFechaEntOPend;
        [AccessedThroughProperty("editCantRec")]
        private TextBox _editCantRec;
        [AccessedThroughProperty("editNroLinea")]
        private TextBox _editNroLinea;
        [AccessedThroughProperty("editNroOC")]
        private TextBox _editNroOC;
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
        [AccessedThroughProperty("Label8")]
        private Label _Label8;
        [AccessedThroughProperty("Label9")]
        private Label _Label9;
        [AccessedThroughProperty("txtCantPend")]
        private TextBox _txtCantPend;
        [AccessedThroughProperty("txtCodigo")]
        private TextBox _txtCodigo;
        [AccessedThroughProperty("txtDesc1")]
        private TextBox _txtDesc1;
        [AccessedThroughProperty("txtDesc2")]
        private TextBox _txtDesc2;
        [AccessedThroughProperty("txtFechaRec")]
        private TextBox _txtFechaRec;
        [AccessedThroughProperty("txtNroBulto")]
        private TextBox _txtNroBulto;
        [AccessedThroughProperty("txtPackList")]
        private TextBox _txtPackList;
        public SqlDataAdapter AdapRecepcion;
        private IContainer components;
        public DataSet DS;
        public string mCodAduana;
        public DateTime mFecEntOPend;
        public DateTime mFechaImp;
        public long mID;
        public string mPaisOrigen;
        public long TotReg;

        public frmDiscrepanciasOC()
        {
            base.Load += new EventHandler(this.frmDiscrepanciasOC_Load);
            base.Closed += new EventHandler(this.frmDiscrepanciasOC_Closed);
            this.DS = new DataSet();
            this.InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            SqlConnection connection;
            bool flag = false;
            try
            {
                this.AdapRecepcion.Update(this.DS, "Recepcion");
                this.DS.Tables["Recepcion"].AcceptChanges();
                string connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                connection = new SqlConnection(connectionString);
                connection.Open();
                flag = true;
                int num = new SqlCommand("update Recepcion set Aceptar=0 where ID=" + StringType.FromLong(this.mID), connection).ExecuteNonQuery();
                connection.Close();
                flag = false;
                string selectCommandText = "select * from Recepcion where PackList='" + Variables.gPackList + "' and Rechazar=0 and Aceptar=0";
                this.AdapRecepcion = new SqlDataAdapter(selectCommandText, connectionString);
                SqlCommandBuilder builder = new SqlCommandBuilder(this.AdapRecepcion);
                this.DS.Tables.Clear();
                this.AdapRecepcion.Fill(this.DS, "Recepcion");
                this.TotReg = this.DS.Tables["Recepcion"].Rows.Count;
                this.dgRecepcion.DataSource = this.DS.Tables["Recepcion"];
                this.dgRecepcion.Refresh();
                this.GroupBox1.Visible = false;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                if (flag)
                {
                    connection.Close();
                    flag = false;
                }
                ProjectData.ClearProjectError();
                return;
                ProjectData.ClearProjectError();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool flag = false;
            bool flag2 = false;
            if ((StringType.StrCmp(this.editNroOC.Text, Strings.Space(0), false) != 0) && !Information.IsNumeric(this.editNroOC.Text))
            {
                Interaction.MsgBox("Nro.OC inv\x00e1lido", 0x10, "Operador");
                this.editNroOC.Focus();
            }
            else if ((StringType.StrCmp(this.editNroLinea.Text, Strings.Space(0), false) != 0) && !Information.IsNumeric(this.editNroLinea.Text))
            {
                Interaction.MsgBox("Nro.L\x00ednea inv\x00e1lido", 0x10, "Operador");
                this.editNroLinea.Focus();
            }
            else if ((StringType.StrCmp(this.editCantRec.Text, Strings.Space(0), false) != 0) && !Information.IsNumeric(this.editCantRec.Text))
            {
                Interaction.MsgBox("Cantidad Recibida inv\x00e1lida", 0x10, "Operador");
                this.editCantRec.Focus();
            }
            else
            {
                SqlConnection connection;
                SqlConnection connection2;
                try
                {
                    SqlCommandBuilder builder;
                    int num9;
                    string str5;
                    string str6;
                    connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=True;packet size=4096");
                    connection.Open();
                    flag = true;
                    string connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                    connection2 = new SqlConnection(connectionString);
                    connection2.Open();
                    flag2 = true;
                    SqlCommand command = new SqlCommand("SELECT PC03001,PC03002,PC03005,PC03006,PC03007,PC03010,PC03011,PC03016 FROM dbo.PC030100 where PC03001='" + this.editNroOC.Text + "' and PC03002='" + this.editNroLinea.Text + "' and PC03010<>0 and PC03010-PC03011<>0", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        double num3;
                        double num4;
                        string str2;
                        string str3;
                        double num5;
                        double num7;
                        double num8;
                        string str = ((((((StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(this.editNroOC.Text, reader["PC03002"]), Strings.Space(6 - Strings.Len(RuntimeHelpers.GetObjectValue(reader["PC03002"]))))) + this.txtCodigo.Text + Strings.Space(0x23 - Strings.Len(this.txtCodigo.Text))) + Strings.Format(Conversion.Val(this.editCantRec.Text), "00000000000.00000000") + Strings.Format(DateType.FromString(this.txtFechaRec.Text), "ddMMyyyy")) + Variables.gDespacho + Strings.Space(0x19 - Strings.Len(Variables.gDespacho))) + Strings.Format(this.mFechaImp, "ddMMyyyy")) + this.mPaisOrigen + Strings.Space(11 - Strings.Len(this.mPaisOrigen))) + this.mCodAduana + Strings.Space(10 - Strings.Len(this.mCodAduana))) + Strings.Format(this.dtpFechaEntOPend.Value, "ddMMyyyy") + "\r" + "\n";
                        double num2 = DoubleType.FromObject(ObjectType.SubObj(reader["PC03010"], reader["PC03011"]));
                        string str4 = StringType.FromObject(reader["PC03002"]);
                        reader.Close();
                        StreamWriter writer = new StreamWriter(Variables.gPathTxt + @"\ocompra.prn", true);
                        writer.Write(str);
                        writer.Close();
                        command = new SqlCommand("SELECT SC03058,SC03060 FROM dbo.SC030100 where SC03001='" + this.txtCodigo.Text + "' and SC03002='01'", connection);
                        reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            num4 = DoubleType.FromObject(reader["SC03058"]);
                            num8 = DoubleType.FromObject(reader["SC03060"]);
                        }
                        else
                        {
                            num4 = 0.0;
                            num8 = 0.0;
                        }
                        reader.Close();
                        command = new SqlCommand("SELECT SC03058,SC03060 FROM dbo.SC030100 where SC03001='" + this.txtCodigo.Text + "' and SC03002='02'", connection);
                        reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            num3 = DoubleType.FromObject(reader["SC03058"]);
                            num7 = DoubleType.FromObject(reader["SC03060"]);
                        }
                        else
                        {
                            num3 = 0.0;
                            num7 = 0.0;
                        }
                        reader.Close();
                        command = new SqlCommand("SELECT SC01055,SC01056,SYCD010 FROM dbo.SC010100,SYCD0100 where SC01001='" + this.txtCodigo.Text + "' and SC01056=SYCD001", connection);
                        reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            num5 = DoubleType.FromObject(reader["SC01055"]);
                            str3 = StringType.FromObject(reader["SC01056"]);
                            str2 = StringType.FromObject(reader["SYCD010"]);
                        }
                        else
                        {
                            num5 = 0.0;
                            str3 = "";
                            str2 = "";
                        }
                        reader.Close();
                        command = new SqlCommand((((((("insert into MercRec (NroOC,NroLinea,Codigo,CantRec,FechaRec,Despacho,CostoUnitLoc,CostoUnitExp,PrecioCpra,MonedaCpra,DescMonedaCpra,SobreCostoLoc,SobreCostoExp,PrecioUnitProv,PackList) values ('" + this.editNroOC.Text + "','" + str4) + "','" + this.txtCodigo.Text + "'," + this.editCantRec.Text) + ",'" + Strings.Format(DateType.FromString(this.txtFechaRec.Text), "MM/dd/yyyy")) + "','" + Variables.gDespacho + "'," + StringType.FromDouble(num4) + "," + StringType.FromDouble(num3) + "," + StringType.FromDouble(num5)) + ",'" + str3) + "','" + str2 + "'," + StringType.FromDouble(num8) + "," + StringType.FromDouble(num7)) + ",0,'" + Variables.gPackList + "')", connection2);
                        num9 = command.ExecuteNonQuery();
                        this.AdapRecepcion.Update(this.DS, "Recepcion");
                        this.DS.Tables["Recepcion"].AcceptChanges();
                        str5 = "update Recepcion set NroOC='" + this.editNroOC.Text + "',NroLinea='" + this.editNroLinea.Text + "',CantPend=" + StringType.FromDouble(num2) + ",CantRec=" + this.editCantRec.Text + "where ID=" + StringType.FromLong(this.mID);
                        reader.Close();
                        command = new SqlCommand(str5, connection2);
                        num9 = command.ExecuteNonQuery();
                        if (DoubleType.FromString(this.editCantRec.Text) != num2)
                        {
                            command = new SqlCommand("insert into Reclamos select NroBulto,NroOC,NroLinea,Codigo,Desc1,Desc2,CantPend,CantRec,FechaRec,0,Despacho,FechaImp,CodAduana,PaisOrigen,PackList from Recepcion where ID=" + StringType.FromLong(this.mID), connection2);
                            num9 = command.ExecuteNonQuery();
                        }
                        str6 = "select * from Recepcion where PackList='" + Variables.gPackList + "' and Rechazar=0 and Aceptar=0";
                        this.AdapRecepcion = new SqlDataAdapter(str6, connectionString);
                        builder = new SqlCommandBuilder(this.AdapRecepcion);
                        this.DS.Tables.Clear();
                        this.AdapRecepcion.Fill(this.DS, "Recepcion");
                        this.TotReg = this.DS.Tables["Recepcion"].Rows.Count;
                        this.dgRecepcion.DataSource = this.DS.Tables["Recepcion"];
                        this.dgRecepcion.Refresh();
                        this.GroupBox1.Visible = false;
                    }
                    else
                    {
                        if (Interaction.MsgBox("Nro.OC - L\x00ednea inexistente en Scala, genera Reclamo?", 4, "Operador") == 6)
                        {
                            this.AdapRecepcion.Update(this.DS, "Recepcion");
                            this.DS.Tables["Recepcion"].AcceptChanges();
                            str5 = "update Recepcion set NroOC='" + this.editNroOC.Text + "',NroLinea='" + this.editNroLinea.Text + "',CantRec=" + this.editCantRec.Text + "where ID=" + StringType.FromLong(this.mID);
                            reader.Close();
                            command = new SqlCommand(str5, connection2);
                            num9 = command.ExecuteNonQuery();
                            num9 = new SqlCommand("insert into Reclamos select NroBulto,NroOC,NroLinea,Codigo,Desc1,Desc2,CantPend,CantRec,FechaRec,0,Despacho,FechaImp,CodAduana,PaisOrigen,PackList from Recepcion where ID=" + StringType.FromLong(this.mID), connection2).ExecuteNonQuery();
                            str6 = "select * from Recepcion where PackList='" + Variables.gPackList + "' and Rechazar=0 and Aceptar=0";
                            this.AdapRecepcion = new SqlDataAdapter(str6, connectionString);
                            builder = new SqlCommandBuilder(this.AdapRecepcion);
                            this.DS.Tables.Clear();
                            this.AdapRecepcion.Fill(this.DS, "Recepcion");
                            this.TotReg = this.DS.Tables["Recepcion"].Rows.Count;
                            this.dgRecepcion.DataSource = this.DS.Tables["Recepcion"];
                            this.dgRecepcion.Refresh();
                            this.GroupBox1.Visible = false;
                        }
                        else
                        {
                            this.editNroOC.Focus();
                        }
                        return;
                        connection.Close();
                        flag = false;
                        connection2.Close();
                        flag2 = false;
                    }
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                    if (flag)
                    {
                        connection.Close();
                        flag = false;
                    }
                    if (flag2)
                    {
                        connection2.Close();
                        flag2 = false;
                    }
                    ProjectData.ClearProjectError();
                    return;
                    ProjectData.ClearProjectError();
                }
            }
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            this.AdapRecepcion.Update(this.DS, "Recepcion");
            this.DS.Tables["Recepcion"].AcceptChanges();
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            string selectCommandText = "select * from Recepcion where PackList='" + Variables.gPackList + "' and Rechazar=0 and Aceptar=0";
            this.AdapRecepcion = new SqlDataAdapter(selectCommandText, selectConnectionString);
            SqlCommandBuilder builder = new SqlCommandBuilder(this.AdapRecepcion);
            this.DS.Tables.Clear();
            this.AdapRecepcion.Fill(this.DS, "Recepcion");
            this.TotReg = this.DS.Tables["Recepcion"].Rows.Count;
            this.dgRecepcion.DataSource = this.DS.Tables["Recepcion"];
            this.dgRecepcion.Refresh();
        }

        private void cmbReclamosOC_Click(object sender, EventArgs e)
        {
            frmReclamosOC soc = new frmReclamosOC();
            this.Hide();
            soc.Show();
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgRecepcion_Click(object sender, EventArgs e)
        {
        }

        private void dgRecepcion_DoubleClick(object sender, EventArgs e)
        {
            if (ObjectType.ObjTst(this.dgRecepcion[this.dgRecepcion.CurrentCell], false, false) == 0)
            {
                this.dgRecepcion[this.dgRecepcion.CurrentCell] = true;
                if (this.dgRecepcion.CurrentCell.ColumnNumber == 0)
                {
                    this.dgRecepcion[this.dgRecepcion.CurrentCell.RowNumber, 1] = false;
                }
                else if (this.dgRecepcion.CurrentCell.ColumnNumber == 1)
                {
                    this.dgRecepcion[this.dgRecepcion.CurrentCell.RowNumber, 0] = false;
                    this.txtNroBulto.Text = StringType.FromObject(this.dgRecepcion[this.dgRecepcion.CurrentCell.RowNumber, 2]);
                    this.editNroOC.Text = StringType.FromObject(this.dgRecepcion[this.dgRecepcion.CurrentCell.RowNumber, 3]);
                    this.editNroLinea.Text = StringType.FromObject(this.dgRecepcion[this.dgRecepcion.CurrentCell.RowNumber, 4]);
                    this.txtCodigo.Text = StringType.FromObject(this.dgRecepcion[this.dgRecepcion.CurrentCell.RowNumber, 5]);
                    this.txtCantPend.Text = Strings.Format(RuntimeHelpers.GetObjectValue(this.dgRecepcion[this.dgRecepcion.CurrentCell.RowNumber, 6]), "######0");
                    this.editCantRec.Text = Strings.Format(RuntimeHelpers.GetObjectValue(this.dgRecepcion[this.dgRecepcion.CurrentCell.RowNumber, 7]), "######0");
                    this.txtFechaRec.Text = StringType.FromObject(this.dgRecepcion[this.dgRecepcion.CurrentCell.RowNumber, 8]);
                    this.txtDesc1.Text = StringType.FromObject(this.dgRecepcion[this.dgRecepcion.CurrentCell.RowNumber, 9]);
                    if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.dgRecepcion[this.dgRecepcion.CurrentCell.RowNumber, 10])))
                    {
                        this.txtDesc2.Text = "";
                    }
                    else
                    {
                        this.txtDesc2.Text = StringType.FromObject(this.dgRecepcion[this.dgRecepcion.CurrentCell.RowNumber, 10]);
                    }
                    Variables.gDespacho = StringType.FromObject(this.dgRecepcion[this.dgRecepcion.CurrentCell.RowNumber, 11]);
                    this.mFechaImp = DateType.FromObject(this.dgRecepcion[this.dgRecepcion.CurrentCell.RowNumber, 12]);
                    this.mCodAduana = StringType.FromObject(this.dgRecepcion[this.dgRecepcion.CurrentCell.RowNumber, 13]);
                    this.mPaisOrigen = StringType.FromObject(this.dgRecepcion[this.dgRecepcion.CurrentCell.RowNumber, 14]);
                    this.mID = LongType.FromObject(this.dgRecepcion[this.dgRecepcion.CurrentCell.RowNumber, 15]);
                    this.GroupBox1.Visible = true;
                    this.editNroOC.Focus();
                }
            }
            else
            {
                this.dgRecepcion[this.dgRecepcion.CurrentCell] = false;
            }
        }

        private void dgRecepcion_Navigate(object sender, NavigateEventArgs ne)
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

        private void dtpFechaEntOPend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.btnModificar.Focus();
            }
        }

        private void dtpFechaEntOPend_ValueChanged(object sender, EventArgs e)
        {
        }

        private void editCantRec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.btnModificar.Focus();
            }
        }

        private void editCantRec_LostFocus(object sender, EventArgs e)
        {
            if (StringType.StrCmp(this.editCantRec.Text, this.txtCantPend.Text, false) != 0)
            {
                SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=edibar;persist security info=True;packet size=4096");
                connection.Open();
                SqlDataReader reader = new SqlCommand("SELECT datexp from detdes where ordnb=" + StringType.FromLong(LongType.FromString(this.editNroOC.Text)) + " and lignb=" + StringType.FromLong(LongType.FromString(this.editNroLinea.Text)) + " and itnbr='" + this.txtCodigo.Text + "' and cntqty=0 order by datexp", connection).ExecuteReader();
                if (reader.Read())
                {
                    this.mFecEntOPend = DateType.FromObject(reader["datexp"]);
                    reader.Close();
                }
                else
                {
                    this.mFecEntOPend = DateAndTime.get_Now();
                    reader.Close();
                }
                this.dtpFechaEntOPend.Value = this.mFecEntOPend;
                this.Label9.Visible = true;
                this.dtpFechaEntOPend.Visible = true;
                this.dtpFechaEntOPend.Focus();
            }
            else
            {
                this.mFecEntOPend = DateAndTime.get_Now();
                this.dtpFechaEntOPend.Value = this.mFecEntOPend;
                this.Label9.Visible = false;
                this.dtpFechaEntOPend.Visible = false;
            }
        }

        private void editCantRec_TextChanged(object sender, EventArgs e)
        {
        }

        private void editNroLinea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editCantRec.Focus();
            }
        }

        private void editNroLinea_LostFocus(object sender, EventArgs e)
        {
            if ((StringType.StrCmp(this.editNroLinea.Text, Strings.Space(0), false) != 0) && Information.IsNumeric(this.editNroLinea.Text))
            {
                this.editNroLinea.Text = Strings.Format(Conversion.Val(this.editNroLinea.Text), "000000");
            }
        }

        private void editNroLinea_TextChanged(object sender, EventArgs e)
        {
        }

        private void editNroOC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editNroLinea.Focus();
            }
        }

        private void editNroOC_LostFocus(object sender, EventArgs e)
        {
            if ((StringType.StrCmp(this.editNroOC.Text, Strings.Space(0), false) != 0) && Information.IsNumeric(this.editNroOC.Text))
            {
                this.editNroOC.Text = Strings.Format(Conversion.Val(this.editNroOC.Text), "0000000000");
            }
        }

        ~frmDiscrepanciasOC()
        {
        }

        private void frmDiscrepanciasOC_Closed(object sender, EventArgs e)
        {
            new frmMenuOCompra().Show();
        }

        private void frmDiscrepanciasOC_Load(object sender, EventArgs e)
        {
            this.txtPackList.Text = Variables.gPackList;
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            string selectCommandText = "select * from Recepcion where PackList='" + Variables.gPackList + "' and Rechazar=0 and Aceptar=0";
            this.AdapRecepcion = new SqlDataAdapter(selectCommandText, selectConnectionString);
            SqlCommandBuilder builder = new SqlCommandBuilder(this.AdapRecepcion);
            this.AdapRecepcion.Fill(this.DS, "Recepcion");
            this.TotReg = this.DS.Tables["Recepcion"].Rows.Count;
            this.dgRecepcion.DataSource = this.DS.Tables["Recepcion"];
            DataGridTableStyle table = new DataGridTableStyle();
            table.MappingName = "Recepcion";
            DataGridTextBoxColumn column = new DataGridTextBoxColumn();
            DataGridBoolColumn column2 = new DataGridBoolColumn();
            DataGridBoolColumn column18 = column2;
            column18.HeaderText = "Rech.";
            column18.MappingName = "Rechazar";
            column18.Width = 0x23;
            column18 = null;
            table.GridColumnStyles.Add(column2);
            column2 = new DataGridBoolColumn();
            DataGridBoolColumn column17 = column2;
            column17.HeaderText = "Acep.";
            column17.MappingName = "Aceptar";
            column17.Width = 0x23;
            column17 = null;
            table.GridColumnStyles.Add(column2);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column16 = column;
            column16.HeaderText = "Nro.Bulto";
            column16.MappingName = "NroBulto";
            column16.Width = 60;
            column16 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column15 = column;
            column15.HeaderText = "Nro.OC";
            column15.MappingName = "NroOC";
            column15.Width = 70;
            column15 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column14 = column;
            column14.HeaderText = "L\x00ednea";
            column14.MappingName = "NroLinea";
            column14.Width = 0x2d;
            column14.NullText = "";
            column14 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column13 = column;
            column13.HeaderText = "C\x00f3digo";
            column13.MappingName = "Codigo";
            column13.Width = 60;
            column13 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column12 = column;
            column12.HeaderText = "Cant.OC";
            column12.MappingName = "CantPend";
            column12.Width = 50;
            column12.Format = "######0";
            column12.NullText = "";
            column12 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column11 = column;
            column11.HeaderText = "Cant.Rec.";
            column11.MappingName = "CantRec";
            column11.Width = 60;
            column11.Format = "######0";
            column11 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column10 = column;
            column10.HeaderText = "F.Recepci\x00f3n";
            column10.MappingName = "FechaRec";
            column10.Format = "dd/MM/yyyy";
            column10.Width = 70;
            column10 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column9 = column;
            column9.HeaderText = "Descripci\x00f3n";
            column9.MappingName = "Desc1";
            column9.Width = 150;
            column9.NullText = "";
            column9 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column8 = column;
            column8.HeaderText = "Descripci\x00f3n";
            column8.MappingName = "Desc2";
            column8.Width = 150;
            column8.NullText = "";
            column8 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column7 = column;
            column7.HeaderText = "";
            column7.MappingName = "Despacho";
            column7.Width = 0;
            column7.NullText = "";
            column7 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column6 = column;
            column6.HeaderText = "";
            column6.MappingName = "FechaImp";
            column6.Width = 0;
            column6.Format = "dd/MM/yyyy";
            column6.NullText = "";
            column6 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column5 = column;
            column5.HeaderText = "";
            column5.MappingName = "CodAduana";
            column5.Width = 0;
            column5.NullText = "";
            column5 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column4 = column;
            column4.HeaderText = "";
            column4.MappingName = "PaisOrigen";
            column4.Width = 0;
            column4.NullText = "";
            column4 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column3 = column;
            column3.HeaderText = "";
            column3.MappingName = "ID";
            column3.Width = 0;
            column3 = null;
            table.GridColumnStyles.Add(column);
            this.dgRecepcion.TableStyles.Add(table);
            this.dgRecepcion.Refresh();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmDiscrepanciasOC));
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.dgRecepcion = new DataGrid();
            this.Label1 = new Label();
            this.txtNroBulto = new TextBox();
            this.GroupBox1 = new GroupBox();
            this.dtpFechaEntOPend = new DateTimePicker();
            this.Label9 = new Label();
            this.btnCancelar = new Button();
            this.btnModificar = new Button();
            this.Label7 = new Label();
            this.editCantRec = new TextBox();
            this.Label6 = new Label();
            this.txtCantPend = new TextBox();
            this.Label5 = new Label();
            this.txtFechaRec = new TextBox();
            this.txtDesc2 = new TextBox();
            this.txtDesc1 = new TextBox();
            this.Label4 = new Label();
            this.txtCodigo = new TextBox();
            this.Label3 = new Label();
            this.editNroLinea = new TextBox();
            this.Label2 = new Label();
            this.editNroOC = new TextBox();
            this.cmbReclamosOC = new Button();
            this.txtPackList = new TextBox();
            this.Label8 = new Label();
            this.dgRecepcion.BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            Point point = new Point(0x390, 0x2a0);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 2;
            this.cmbAceptar.Text = "&Aceptar";
            point = new Point(800, 0x2a0);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 3;
            this.cmbSalir.Text = "&Salir";
            this.dgRecepcion.CaptionFont = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dgRecepcion.CaptionText = "Discrepancias Recepci\x00f3n O.Compra";
            this.dgRecepcion.DataMember = "";
            this.dgRecepcion.HeaderForeColor = SystemColors.ControlText;
            point = new Point(8, 40);
            this.dgRecepcion.Location = point;
            this.dgRecepcion.Name = "dgRecepcion";
            this.dgRecepcion.ReadOnly = true;
            size = new Size(0x3f8, 0x200);
            this.dgRecepcion.Size = size;
            this.dgRecepcion.TabIndex = 0;
            point = new Point(0x10, 0x18);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x48, 0x10);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Nro.Bulto:";
            this.txtNroBulto.BackColor = SystemColors.Window;
            this.txtNroBulto.Enabled = false;
            point = new Point(0x60, 0x18);
            this.txtNroBulto.Location = point;
            this.txtNroBulto.MaxLength = 8;
            this.txtNroBulto.Name = "txtNroBulto";
            size = new Size(80, 20);
            this.txtNroBulto.Size = size;
            this.txtNroBulto.TabIndex = 1;
            this.txtNroBulto.Text = "";
            this.GroupBox1.Controls.Add(this.dtpFechaEntOPend);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.btnCancelar);
            this.GroupBox1.Controls.Add(this.btnModificar);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.editCantRec);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.txtCantPend);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.txtFechaRec);
            this.GroupBox1.Controls.Add(this.txtDesc2);
            this.GroupBox1.Controls.Add(this.txtDesc1);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.txtCodigo);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.editNroLinea);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.editNroOC);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.txtNroBulto);
            point = new Point(8, 560);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(0x300, 0x90);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Visible = false;
            this.dtpFechaEntOPend.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaEntOPend.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaEntOPend.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaEntOPend.Format = DateTimePickerFormat.Short;
            point = new Point(0x1a0, 0x70);
            this.dtpFechaEntOPend.Location = point;
            this.dtpFechaEntOPend.Name = "dtpFechaEntOPend";
            size = new Size(0x60, 20);
            this.dtpFechaEntOPend.Size = size;
            this.dtpFechaEntOPend.TabIndex = 0x13;
            DateTime time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpFechaEntOPend.Value = time;
            this.dtpFechaEntOPend.Visible = false;
            point = new Point(0x158, 0x70);
            this.Label9.Location = point;
            this.Label9.Name = "Label9";
            size = new Size(0x48, 0x10);
            this.Label9.Size = size;
            this.Label9.TabIndex = 0x12;
            this.Label9.Text = "F.Ent.O.Pend.:";
            this.Label9.Visible = false;
            point = new Point(0x220, 0x70);
            this.btnCancelar.Location = point;
            this.btnCancelar.Name = "btnCancelar";
            size = new Size(0x60, 0x18);
            this.btnCancelar.Size = size;
            this.btnCancelar.TabIndex = 0x11;
            this.btnCancelar.Text = "&Cancelar";
            point = new Point(0x290, 0x70);
            this.btnModificar.Location = point;
            this.btnModificar.Name = "btnModificar";
            size = new Size(0x60, 0x18);
            this.btnModificar.Size = size;
            this.btnModificar.TabIndex = 0x10;
            this.btnModificar.Text = "&Modificar";
            point = new Point(0xb8, 0x70);
            this.Label7.Location = point;
            this.Label7.Name = "Label7";
            size = new Size(0x38, 0x10);
            this.Label7.Size = size;
            this.Label7.TabIndex = 14;
            this.Label7.Text = "Cant.Rec.:";
            point = new Point(0xf8, 0x70);
            this.editCantRec.Location = point;
            this.editCantRec.MaxLength = 7;
            this.editCantRec.Name = "editCantRec";
            size = new Size(80, 20);
            this.editCantRec.Size = size;
            this.editCantRec.TabIndex = 15;
            this.editCantRec.Text = "";
            this.editCantRec.TextAlign = HorizontalAlignment.Right;
            point = new Point(0x10, 0x70);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(0x38, 0x10);
            this.Label6.Size = size;
            this.Label6.TabIndex = 12;
            this.Label6.Text = "Cant. OC:";
            this.txtCantPend.BackColor = SystemColors.Window;
            this.txtCantPend.Enabled = false;
            point = new Point(0x60, 0x70);
            this.txtCantPend.Location = point;
            this.txtCantPend.MaxLength = 7;
            this.txtCantPend.Name = "txtCantPend";
            size = new Size(80, 20);
            this.txtCantPend.Size = size;
            this.txtCantPend.TabIndex = 13;
            this.txtCantPend.Text = "";
            this.txtCantPend.TextAlign = HorizontalAlignment.Right;
            point = new Point(0x1e8, 0x18);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size(0x48, 0x10);
            this.Label5.Size = size;
            this.Label5.TabIndex = 6;
            this.Label5.Text = "F.Recepci\x00f3n:";
            this.txtFechaRec.BackColor = SystemColors.Window;
            this.txtFechaRec.Enabled = false;
            point = new Point(0x238, 0x18);
            this.txtFechaRec.Location = point;
            this.txtFechaRec.MaxLength = 10;
            this.txtFechaRec.Name = "txtFechaRec";
            size = new Size(0x60, 20);
            this.txtFechaRec.Size = size;
            this.txtFechaRec.TabIndex = 7;
            this.txtFechaRec.Text = "";
            this.txtDesc2.BackColor = SystemColors.Window;
            this.txtDesc2.Enabled = false;
            point = new Point(0xb8, 80);
            this.txtDesc2.Location = point;
            this.txtDesc2.MaxLength = 0x19;
            this.txtDesc2.Name = "txtDesc2";
            size = new Size(0x1f0, 20);
            this.txtDesc2.Size = size;
            this.txtDesc2.TabIndex = 11;
            this.txtDesc2.Text = "";
            this.txtDesc1.BackColor = SystemColors.Window;
            this.txtDesc1.Enabled = false;
            point = new Point(0xb8, 0x38);
            this.txtDesc1.Location = point;
            this.txtDesc1.MaxLength = 0x19;
            this.txtDesc1.Name = "txtDesc1";
            size = new Size(0x1f0, 20);
            this.txtDesc1.Size = size;
            this.txtDesc1.TabIndex = 10;
            this.txtDesc1.Text = "";
            point = new Point(0x10, 0x38);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(0x48, 0x10);
            this.Label4.Size = size;
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Producto:";
            this.txtCodigo.BackColor = SystemColors.Window;
            this.txtCodigo.Enabled = false;
            point = new Point(0x60, 0x38);
            this.txtCodigo.Location = point;
            this.txtCodigo.MaxLength = 8;
            this.txtCodigo.Name = "txtCodigo";
            size = new Size(80, 20);
            this.txtCodigo.Size = size;
            this.txtCodigo.TabIndex = 9;
            this.txtCodigo.Text = "";
            point = new Point(0x160, 0x18);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x30, 0x10);
            this.Label3.Size = size;
            this.Label3.TabIndex = 4;
            this.Label3.Text = "L\x00ednea:";
            point = new Point(0x198, 0x18);
            this.editNroLinea.Location = point;
            this.editNroLinea.MaxLength = 6;
            this.editNroLinea.Name = "editNroLinea";
            size = new Size(0x48, 20);
            this.editNroLinea.Size = size;
            this.editNroLinea.TabIndex = 5;
            this.editNroLinea.Text = "";
            point = new Point(0xb8, 0x18);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x38, 0x10);
            this.Label2.Size = size;
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Nro.OC:";
            point = new Point(0xf8, 0x18);
            this.editNroOC.Location = point;
            this.editNroOC.MaxLength = 10;
            this.editNroOC.Name = "editNroOC";
            size = new Size(0x60, 20);
            this.editNroOC.Size = size;
            this.editNroOC.TabIndex = 3;
            this.editNroOC.Text = "";
            point = new Point(0x358, 0x268);
            this.cmbReclamosOC.Location = point;
            this.cmbReclamosOC.Name = "cmbReclamosOC";
            size = new Size(0x60, 40);
            this.cmbReclamosOC.Size = size;
            this.cmbReclamosOC.TabIndex = 4;
            this.cmbReclamosOC.Text = "&Reclamos";
            this.txtPackList.BackColor = SystemColors.Window;
            this.txtPackList.Enabled = false;
            this.txtPackList.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(120, 8);
            this.txtPackList.Location = point;
            this.txtPackList.MaxLength = 10;
            this.txtPackList.Name = "txtPackList";
            size = new Size(0x98, 0x16);
            this.txtPackList.Size = size;
            this.txtPackList.TabIndex = 0x39;
            this.txtPackList.Text = "";
            this.Label8.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 8);
            this.Label8.Location = point;
            this.Label8.Name = "Label8";
            size = new Size(0x58, 0x10);
            this.Label8.Size = size;
            this.Label8.TabIndex = 0x38;
            this.Label8.Text = "Packing List:";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            size = new Size(920, 0x2cd);
            this.ClientSize = size;
            this.Controls.Add(this.txtPackList);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.cmbReclamosOC);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.dgRecepcion);
            this.Controls.Add(this.cmbSalir);
            this.Controls.Add(this.cmbAceptar);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmDiscrepanciasOC";
            this.Text = "Discrepancias Recepci\x00f3n O.Compra";
            this.WindowState = FormWindowState.Maximized;
            this.dgRecepcion.EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void Label9_Click(object sender, EventArgs e)
        {
        }

        internal virtual Button btnCancelar
        {
            get
            {
                return this._btnCancelar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnCancelar != null)
                {
                    this._btnCancelar.Click -= new EventHandler(this.btnCancelar_Click);
                }
                this._btnCancelar = value;
                if (this._btnCancelar != null)
                {
                    this._btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
                }
            }
        }

        internal virtual Button btnModificar
        {
            get
            {
                return this._btnModificar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnModificar != null)
                {
                    this._btnModificar.Click -= new EventHandler(this.btnModificar_Click);
                }
                this._btnModificar = value;
                if (this._btnModificar != null)
                {
                    this._btnModificar.Click += new EventHandler(this.btnModificar_Click);
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

        internal virtual Button cmbReclamosOC
        {
            get
            {
                return this._cmbReclamosOC;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbReclamosOC != null)
                {
                    this._cmbReclamosOC.Click -= new EventHandler(this.cmbReclamosOC_Click);
                }
                this._cmbReclamosOC = value;
                if (this._cmbReclamosOC != null)
                {
                    this._cmbReclamosOC.Click += new EventHandler(this.cmbReclamosOC_Click);
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

        internal virtual DataGrid dgRecepcion
        {
            get
            {
                return this._dgRecepcion;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dgRecepcion != null)
                {
                    this._dgRecepcion.DoubleClick -= new EventHandler(this.dgRecepcion_DoubleClick);
                    this._dgRecepcion.Navigate -= new NavigateEventHandler(this.dgRecepcion_Navigate);
                    this._dgRecepcion.Click -= new EventHandler(this.dgRecepcion_Click);
                }
                this._dgRecepcion = value;
                if (this._dgRecepcion != null)
                {
                    this._dgRecepcion.DoubleClick += new EventHandler(this.dgRecepcion_DoubleClick);
                    this._dgRecepcion.Navigate += new NavigateEventHandler(this.dgRecepcion_Navigate);
                    this._dgRecepcion.Click += new EventHandler(this.dgRecepcion_Click);
                }
            }
        }

        internal virtual DateTimePicker dtpFechaEntOPend
        {
            get
            {
                return this._dtpFechaEntOPend;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpFechaEntOPend != null)
                {
                    this._dtpFechaEntOPend.KeyPress -= new KeyPressEventHandler(this.dtpFechaEntOPend_KeyPress);
                    this._dtpFechaEntOPend.ValueChanged -= new EventHandler(this.dtpFechaEntOPend_ValueChanged);
                }
                this._dtpFechaEntOPend = value;
                if (this._dtpFechaEntOPend != null)
                {
                    this._dtpFechaEntOPend.KeyPress += new KeyPressEventHandler(this.dtpFechaEntOPend_KeyPress);
                    this._dtpFechaEntOPend.ValueChanged += new EventHandler(this.dtpFechaEntOPend_ValueChanged);
                }
            }
        }

        internal virtual TextBox editCantRec
        {
            get
            {
                return this._editCantRec;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editCantRec != null)
                {
                    this._editCantRec.KeyPress -= new KeyPressEventHandler(this.editCantRec_KeyPress);
                    this._editCantRec.TextChanged -= new EventHandler(this.editCantRec_TextChanged);
                    this._editCantRec.LostFocus -= new EventHandler(this.editCantRec_LostFocus);
                }
                this._editCantRec = value;
                if (this._editCantRec != null)
                {
                    this._editCantRec.KeyPress += new KeyPressEventHandler(this.editCantRec_KeyPress);
                    this._editCantRec.TextChanged += new EventHandler(this.editCantRec_TextChanged);
                    this._editCantRec.LostFocus += new EventHandler(this.editCantRec_LostFocus);
                }
            }
        }

        internal virtual TextBox editNroLinea
        {
            get
            {
                return this._editNroLinea;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editNroLinea != null)
                {
                    this._editNroLinea.KeyPress -= new KeyPressEventHandler(this.editNroLinea_KeyPress);
                    this._editNroLinea.TextChanged -= new EventHandler(this.editNroLinea_TextChanged);
                    this._editNroLinea.LostFocus -= new EventHandler(this.editNroLinea_LostFocus);
                }
                this._editNroLinea = value;
                if (this._editNroLinea != null)
                {
                    this._editNroLinea.KeyPress += new KeyPressEventHandler(this.editNroLinea_KeyPress);
                    this._editNroLinea.TextChanged += new EventHandler(this.editNroLinea_TextChanged);
                    this._editNroLinea.LostFocus += new EventHandler(this.editNroLinea_LostFocus);
                }
            }
        }

        internal virtual TextBox editNroOC
        {
            get
            {
                return this._editNroOC;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editNroOC != null)
                {
                    this._editNroOC.LostFocus -= new EventHandler(this.editNroOC_LostFocus);
                    this._editNroOC.KeyPress -= new KeyPressEventHandler(this.editNroOC_KeyPress);
                }
                this._editNroOC = value;
                if (this._editNroOC != null)
                {
                    this._editNroOC.LostFocus += new EventHandler(this.editNroOC_LostFocus);
                    this._editNroOC.KeyPress += new KeyPressEventHandler(this.editNroOC_KeyPress);
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

        internal virtual Label Label8
        {
            get
            {
                return this._Label8;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label8 != null)
                {
                }
                this._Label8 = value;
                if (this._Label8 != null)
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
                    this._Label9.Click -= new EventHandler(this.Label9_Click);
                }
                this._Label9 = value;
                if (this._Label9 != null)
                {
                    this._Label9.Click += new EventHandler(this.Label9_Click);
                }
            }
        }

        internal virtual TextBox txtCantPend
        {
            get
            {
                return this._txtCantPend;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtCantPend != null)
                {
                }
                this._txtCantPend = value;
                if (this._txtCantPend != null)
                {
                }
            }
        }

        internal virtual TextBox txtCodigo
        {
            get
            {
                return this._txtCodigo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtCodigo != null)
                {
                }
                this._txtCodigo = value;
                if (this._txtCodigo != null)
                {
                }
            }
        }

        internal virtual TextBox txtDesc1
        {
            get
            {
                return this._txtDesc1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtDesc1 != null)
                {
                }
                this._txtDesc1 = value;
                if (this._txtDesc1 != null)
                {
                }
            }
        }

        internal virtual TextBox txtDesc2
        {
            get
            {
                return this._txtDesc2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtDesc2 != null)
                {
                }
                this._txtDesc2 = value;
                if (this._txtDesc2 != null)
                {
                }
            }
        }

        internal virtual TextBox txtFechaRec
        {
            get
            {
                return this._txtFechaRec;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtFechaRec != null)
                {
                }
                this._txtFechaRec = value;
                if (this._txtFechaRec != null)
                {
                }
            }
        }

        internal virtual TextBox txtNroBulto
        {
            get
            {
                return this._txtNroBulto;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtNroBulto != null)
                {
                }
                this._txtNroBulto = value;
                if (this._txtNroBulto != null)
                {
                }
            }
        }

        internal virtual TextBox txtPackList
        {
            get
            {
                return this._txtPackList;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtPackList != null)
                {
                }
                this._txtPackList = value;
                if (this._txtPackList != null)
                {
                }
            }
        }
    }
}

