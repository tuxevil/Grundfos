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

    public class frmRecOCManual1 : Form
    {
        [AccessedThroughProperty("btnAgregar")]
        private Button _btnAgregar;
        [AccessedThroughProperty("btnCancelar")]
        private Button _btnCancelar;
        [AccessedThroughProperty("btnModif")]
        private Button _btnModif;
        [AccessedThroughProperty("btnModificar")]
        private Button _btnModificar;
        [AccessedThroughProperty("cmbReclamosOC")]
        private Button _cmbReclamosOC;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dgTmpOCManual")]
        private DataGrid _dgTmpOCManual;
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
        [AccessedThroughProperty("Label10")]
        private Label _Label10;
        [AccessedThroughProperty("Label11")]
        private Label _Label11;
        [AccessedThroughProperty("Label12")]
        private Label _Label12;
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
        [AccessedThroughProperty("txtCodAduana")]
        private TextBox _txtCodAduana;
        [AccessedThroughProperty("txtCodigo")]
        private TextBox _txtCodigo;
        [AccessedThroughProperty("txtDesc1")]
        private TextBox _txtDesc1;
        [AccessedThroughProperty("txtDesc2")]
        private TextBox _txtDesc2;
        [AccessedThroughProperty("txtDescAdu")]
        private TextBox _txtDescAdu;
        [AccessedThroughProperty("txtDespacho")]
        private TextBox _txtDespacho;
        [AccessedThroughProperty("txtFechaImp")]
        private TextBox _txtFechaImp;
        [AccessedThroughProperty("txtFechaRec")]
        private TextBox _txtFechaRec;
        [AccessedThroughProperty("txtProveedor")]
        private TextBox _txtProveedor;
        public SqlDataAdapter AdapTmpOCManual;
        private IContainer components;
        public DataSet DS;
        public DataSet DS1;
        public DateTime mFecEntOPend;
        public string mPaisOrigen;
        public string mTipo;
        public long TotReg;

        public frmRecOCManual1()
        {
            base.Load += new EventHandler(this.frmRecOCManual1_Load);
            base.Closed += new EventHandler(this.frmRecOCManual1_Closed);
            this.DS = new DataSet();
            this.DS1 = new DataSet();
            this.InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.mTipo = "A";
            this.editNroOC.Text = "";
            this.editNroLinea.Text = "";
            this.txtCodigo.Text = "";
            this.txtCantPend.Text = "0";
            this.editCantRec.Text = "";
            this.txtDesc1.Text = "";
            this.txtDesc2.Text = "";
            this.mPaisOrigen = "";
            this.editNroOC.Enabled = true;
            this.editNroLinea.Enabled = true;
            this.txtCodigo.Enabled = true;
            this.txtCantPend.Enabled = false;
            this.editCantRec.Enabled = true;
            this.btnAgregar.Enabled = false;
            this.Label9.Visible = false;
            this.dtpFechaEntOPend.Visible = false;
            this.GroupBox1.Text = "Agregar";
            this.GroupBox1.Visible = true;
            this.editNroOC.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            string selectCommandText = "select * from " + Variables.gTermi + "TmpOCManual where CantRec=0 order by NroOC,NroLinea";
            this.AdapTmpOCManual = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.DS.Tables.Clear();
            this.AdapTmpOCManual.Fill(this.DS, Variables.gTermi + "TmpOCManual");
            this.dgTmpOCManual.DataSource = this.DS.Tables[Variables.gTermi + "TmpOCManual"];
            this.dgTmpOCManual.Refresh();
            this.Label9.Visible = false;
            this.dtpFechaEntOPend.Visible = false;
            this.GroupBox1.Visible = false;
            this.btnAgregar.Enabled = true;
            this.btnModif.Enabled = false;
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            this.mTipo = "M";
            this.editNroOC.Enabled = false;
            this.editNroLinea.Enabled = false;
            this.txtCodigo.Enabled = false;
            this.txtCantPend.Enabled = false;
            this.editCantRec.Enabled = true;
            this.btnModif.Enabled = false;
            this.GroupBox1.Text = "Modificar";
            this.GroupBox1.Visible = true;
            this.editCantRec.Focus();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            SqlConnection connection2;
            int num9;
            string str7;
            bool flag = false;
            bool flag2 = false;
            if (StringType.StrCmp(this.mTipo, "A", false) == 0)
            {
                if (StringType.StrCmp(this.editNroOC.Text, Strings.Space(0), false) == 0)
                {
                    Interaction.MsgBox("Debe ingresar Nro.OC", 0x10, "Operador");
                    this.editNroOC.Focus();
                    return;
                }
                if (!Information.IsNumeric(this.editNroOC.Text))
                {
                    Interaction.MsgBox("Nro.OC inv\x00e1lido", 0x10, "Operador");
                    this.editNroOC.Focus();
                    return;
                }
                if (StringType.StrCmp(this.editNroLinea.Text, Strings.Space(0), false) == 0)
                {
                    Interaction.MsgBox("Debe ingresar L\x00ednea", 0x10, "Operador");
                    this.editNroLinea.Focus();
                    return;
                }
                if (!Information.IsNumeric(this.editNroLinea.Text))
                {
                    Interaction.MsgBox("L\x00ednea inv\x00e1lido", 0x10, "Operador");
                    this.editNroLinea.Focus();
                    return;
                }
                if (StringType.StrCmp(this.txtCodigo.Text, Strings.Space(0), false) == 0)
                {
                    Interaction.MsgBox("Debe ingresar Producto", 0x10, "Operador");
                    this.txtCodigo.Focus();
                    return;
                }
                if (StringType.StrCmp(this.txtDesc1.Text, Strings.Space(0), false) == 0)
                {
                    Interaction.MsgBox("Producto inexistente", 0x10, "Operador");
                    this.txtCodigo.Focus();
                    return;
                }
                if (StringType.StrCmp(this.editCantRec.Text, Strings.Space(0), false) == 0)
                {
                    Interaction.MsgBox("Debe ingresar Cantidad Recibida", 0x10, "Operador");
                    this.editCantRec.Focus();
                    return;
                }
                if (!Information.IsNumeric(this.editCantRec.Text))
                {
                    Interaction.MsgBox("Cantidad Recibida inv\x00e1lida", 0x10, "Operador");
                    this.editCantRec.Focus();
                    return;
                }
            }
            else if (StringType.StrCmp(this.mTipo, "M", false) == 0)
            {
                if (StringType.StrCmp(this.editCantRec.Text, Strings.Space(0), false) == 0)
                {
                    Interaction.MsgBox("Debe ingresar Cantidad Recibida", 0x10, "Operador");
                    this.editCantRec.Focus();
                    return;
                }
                if (!Information.IsNumeric(this.editCantRec.Text))
                {
                    Interaction.MsgBox("Cantidad Recibida inv\x00e1lida", 0x10, "Operador");
                    this.editCantRec.Focus();
                    return;
                }
            }
            if (StringType.StrCmp(this.mTipo, "A", false) == 0)
            {
                try
                {
                    str7 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                    connection2 = new SqlConnection(str7);
                    connection2.Open();
                    flag2 = true;
                    command = new SqlCommand(((((((((("insert into Reclamos (NroBulto,NroOC,NroLinea,Codigo,Desc1,Desc2,CantPend,CantRec,FechaRec,Aceptar,Despacho,FechaImp,CodAduana,PaisOrigen,PackList) values('','" + this.editNroOC.Text + "','" + this.editNroLinea.Text) + "','" + this.txtCodigo.Text) + "','" + this.txtDesc1.Text) + "','" + this.txtDesc2.Text + "'," + this.txtCantPend.Text + "," + this.editCantRec.Text) + ",'" + Strings.Format(Variables.gFechaRec, "MM/dd/yyyy")) + "',0,'" + Variables.gDespacho) + "','" + Strings.Format(Variables.gFechaImp, "MM/dd/yyyy")) + "','" + Variables.gCodAduana) + "','" + this.mPaisOrigen) + "','')", connection2);
                    num9 = command.ExecuteNonQuery();
                    connection2.Close();
                    flag2 = false;
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
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
            if (StringType.StrCmp(this.mTipo, "M", false) == 0)
            {
                SqlConnection connection;
                try
                {
                    double num3;
                    double num4;
                    string str2;
                    string str3;
                    string str4;
                    double num5;
                    double num7;
                    double num8;
                    str7 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                    connection2 = new SqlConnection(str7);
                    connection2.Open();
                    flag2 = true;
                    connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=True;packet size=4096");
                    connection.Open();
                    flag = true;
                    string str = (((((((this.editNroOC.Text + this.editNroLinea.Text) + this.txtCodigo.Text + Strings.Space(0x23 - Strings.Len(this.txtCodigo.Text))) + Strings.Format(Conversion.Val(this.editCantRec.Text), "00000000000.00000000") + Strings.Format(Variables.gFechaRec, "ddMMyyyy")) + Variables.gDespacho + Strings.Space(0x19 - Strings.Len(Variables.gDespacho))) + Strings.Format(Variables.gFechaImp, "ddMMyyyy")) + this.mPaisOrigen + Strings.Space(11 - Strings.Len(this.mPaisOrigen))) + Variables.gCodAduana + Strings.Space(10 - Strings.Len(Variables.gCodAduana))) + Strings.Format(this.dtpFechaEntOPend.Value, "ddMMyyyy") + "\r" + "\n";
                    StreamWriter writer = new StreamWriter(Variables.gPathTxt + @"\ocompra.prn", true);
                    writer.Write(str);
                    writer.Close();
                    command = new SqlCommand("SELECT SC03058,SC03060 FROM dbo.SC030100 where SC03001='" + this.txtCodigo.Text + "' and SC03002='01'", connection);
                    SqlDataReader reader = command.ExecuteReader();
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
                    command = new SqlCommand((((((("insert into MercRec (NroOC,NroLinea,Codigo,CantRec,FechaRec,Despacho,CostoUnitLoc,CostoUnitExp,PrecioCpra,MonedaCpra,DescMonedaCpra,SobreCostoLoc,SobreCostoExp,PrecioUnitProv,PackList) values ('" + this.editNroOC.Text + "','" + str4) + "','" + this.txtCodigo.Text + "'," + this.editCantRec.Text) + ",'" + Strings.Format(Variables.gFechaRec, "MM/dd/yyyy")) + "','" + Variables.gDespacho + "'," + StringType.FromDouble(num4) + "," + StringType.FromDouble(num3) + "," + StringType.FromDouble(num5)) + ",'" + str3) + "','" + str2 + "'," + StringType.FromDouble(num8) + "," + StringType.FromDouble(num7)) + ",0,'')", connection2);
                    num9 = command.ExecuteNonQuery();
                    string cmdText = "update " + Variables.gTermi + "TmpOCManual set CantRec=" + this.editCantRec.Text + "where NroOC='" + this.editNroOC.Text + "' and NroLinea='" + this.editNroLinea.Text + "'";
                    reader.Close();
                    command = new SqlCommand(cmdText, connection2);
                    num9 = command.ExecuteNonQuery();
                    if (StringType.StrCmp(this.editCantRec.Text, this.txtCantPend.Text, false) != 0)
                    {
                        num9 = new SqlCommand(((((((((("insert into Reclamos (NroBulto,NroOC,NroLinea,Codigo,Desc1,Desc2,CantPend,CantRec,FechaRec,Aceptar,Despacho,FechaImp,CodAduana,PaisOrigen,PackList) values('','" + this.editNroOC.Text + "','" + this.editNroLinea.Text) + "','" + this.txtCodigo.Text) + "','" + this.txtDesc1.Text) + "','" + this.txtDesc2.Text + "'," + this.txtCantPend.Text + "," + this.editCantRec.Text) + ",'" + Strings.Format(Variables.gFechaRec, "MM/dd/yyyy")) + "',0,'" + Variables.gDespacho) + "','" + Strings.Format(Variables.gFechaImp, "MM/dd/yyyy")) + "','" + Variables.gCodAduana) + "','" + this.mPaisOrigen) + "','')", connection2).ExecuteNonQuery();
                    }
                    connection2.Close();
                    flag2 = false;
                    connection.Close();
                    flag = false;
                }
                catch (Exception exception3)
                {
                    ProjectData.SetProjectError(exception3);
                    Exception exception2 = exception3;
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, 0, null);
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
            string selectCommandText = "select * from " + Variables.gTermi + "TmpOCManual where CantRec=0 order by NroOC,NroLinea";
            this.AdapTmpOCManual = new SqlDataAdapter(selectCommandText, str7);
            this.DS.Tables.Clear();
            this.AdapTmpOCManual.Fill(this.DS, Variables.gTermi + "TmpOCManual");
            this.dgTmpOCManual.DataSource = this.DS.Tables[Variables.gTermi + "TmpOCManual"];
            this.dgTmpOCManual.Refresh();
            this.Label9.Visible = false;
            this.dtpFechaEntOPend.Visible = false;
            this.GroupBox1.Visible = false;
            this.btnAgregar.Enabled = true;
            this.btnModif.Enabled = false;
        }

        private void cmbReclamosOC_Click(object sender, EventArgs e)
        {
            new frmReclamosOCManual().ShowDialog();
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgTmpOCManual_Click(object sender, EventArgs e)
        {
            if (this.DS.Tables[Variables.gTermi + "TmpOCManual"].Rows.Count != 0)
            {
                this.editNroOC.Text = StringType.FromObject(this.dgTmpOCManual[this.dgTmpOCManual.CurrentCell.RowNumber, 0]);
                this.editNroLinea.Text = StringType.FromObject(this.dgTmpOCManual[this.dgTmpOCManual.CurrentCell.RowNumber, 1]);
                this.txtCodigo.Text = StringType.FromObject(this.dgTmpOCManual[this.dgTmpOCManual.CurrentCell.RowNumber, 2]);
                this.txtCantPend.Text = Strings.Format(RuntimeHelpers.GetObjectValue(this.dgTmpOCManual[this.dgTmpOCManual.CurrentCell.RowNumber, 3]), "######0");
                this.editCantRec.Text = Strings.Format(RuntimeHelpers.GetObjectValue(this.dgTmpOCManual[this.dgTmpOCManual.CurrentCell.RowNumber, 3]), "######0");
                this.txtDesc1.Text = StringType.FromObject(this.dgTmpOCManual[this.dgTmpOCManual.CurrentCell.RowNumber, 5]);
                this.txtDesc2.Text = StringType.FromObject(this.dgTmpOCManual[this.dgTmpOCManual.CurrentCell.RowNumber, 6]);
                this.mPaisOrigen = StringType.FromObject(this.dgTmpOCManual[this.dgTmpOCManual.CurrentCell.RowNumber, 7]);
                this.btnModif.Enabled = true;
                this.btnAgregar.Enabled = false;
            }
        }

        private void dgTmpOCManual_DoubleClick(object sender, EventArgs e)
        {
        }

        private void dgTmpOCManual_Navigate(object sender, NavigateEventArgs ne)
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
            if ((StringType.StrCmp(this.editCantRec.Text, this.txtCantPend.Text, false) != 0) & (StringType.StrCmp(this.txtCantPend.Text, "0", false) != 0))
            {
                this.mFecEntOPend = DateAndTime.get_Now();
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
                this.txtCodigo.Focus();
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

        private void editNroOC_TextChanged(object sender, EventArgs e)
        {
        }

        ~frmRecOCManual1()
        {
        }

        private void frmRecOCManual1_Closed(object sender, EventArgs e)
        {
            new frmMenuOCompra().Show();
        }

        private void frmRecOCManual1_Load(object sender, EventArgs e)
        {
            bool flag;
            bool flag2;
            SqlConnection connection;
            SqlConnection connection2;
            string str3;
            this.txtFechaRec.Text = Strings.Format(Variables.gFechaRec, "dd/MM/yyyy");
            this.txtProveedor.Text = Variables.gNomProv;
            this.txtDespacho.Text = Variables.gDespacho;
            this.txtFechaImp.Text = Strings.Format(Variables.gFechaImp, "dd/MM/yyyy");
            this.txtCodAduana.Text = Variables.gCodAduana;
            this.txtDescAdu.Text = Variables.gNomAduana;
            try
            {
                connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
                connection.Open();
                flag = true;
                str3 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
                connection2 = new SqlConnection(str3);
                connection2.Open();
                flag2 = true;
                int num2 = new SqlCommand("delete " + Variables.gTermi + "TmpOCManual", connection2).ExecuteNonQuery();
                SqlCommand command = new SqlCommand("SELECT PC01001,PC03002,PC03005,PC03006,PC03007,PC03010-PC03011 as CantOC,SC01067 FROM dbo.PC010100 inner join PC030100 on PC010100.PC01001=PC030100.PC03001 inner join SC010100 on PC030100.PC03005=SC010100.SC01001 where PC01003='" + Variables.gCodProv + "' and PC03010-PC03011<>0", connection);
                command.CommandTimeout = 500;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(this.DS1, "PC010100");
                long num3 = this.DS1.Tables["PC010100"].Rows.Count - 1;
                for (long i = 0L; i <= num3; i += 1L)
                {
                    DataRow row = this.DS1.Tables["PC010100"].Rows[(int) i];
                    command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpOCManual (NroOC,NroLinea,Codigo,Desc1,Desc2,CantOC,CantRec,PaisOrigen) values ('", row["PC01001"]), "','"), row["PC03002"]), "','"), row["PC03005"]), "','"), row["PC03006"]), "','"), row["PC03007"]), "',"), row["CantOC"]), ",0,'"), row["SC01067"]), "')")), connection2);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        Exception exception = exception1;
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
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
                connection.Close();
                flag = false;
                connection2.Close();
                flag2 = false;
            }
            catch (Exception exception3)
            {
                ProjectData.SetProjectError(exception3);
                Exception exception2 = exception3;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, 0, null);
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
            string selectCommandText = "select * from " + Variables.gTermi + "TmpOCManual where CantRec=0 order by NroOC,NroLinea";
            this.AdapTmpOCManual = new SqlDataAdapter(selectCommandText, str3);
            this.AdapTmpOCManual.Fill(this.DS, Variables.gTermi + "TmpOCManual");
            this.dgTmpOCManual.DataSource = this.DS.Tables[Variables.gTermi + "TmpOCManual"];
            DataGridTableStyle table = new DataGridTableStyle();
            table.MappingName = Variables.gTermi + "TmpOCManual";
            DataGridTextBoxColumn column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column9 = column;
            column9.HeaderText = "Nro.OC";
            column9.MappingName = "NroOC";
            column9.Width = 80;
            column9 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column8 = column;
            column8.HeaderText = "L\x00ednea";
            column8.MappingName = "NroLinea";
            column8.Width = 0x37;
            column8.NullText = "";
            column8 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column7 = column;
            column7.HeaderText = "C\x00f3digo";
            column7.MappingName = "Codigo";
            column7.Width = 80;
            column7 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column6 = column;
            column6.HeaderText = "Cant.OC";
            column6.MappingName = "CantOC";
            column6.Width = 50;
            column6.Alignment = HorizontalAlignment.Center;
            column6.Format = "######0";
            column6.NullText = "";
            column6 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column5 = column;
            column5.HeaderText = "Cant.Rec.";
            column5.MappingName = "CantRec";
            column5.Alignment = HorizontalAlignment.Center;
            column5.Width = 60;
            column5.Format = "######0";
            column5 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column4 = column;
            column4.HeaderText = "Descripci\x00f3n";
            column4.MappingName = "Desc1";
            column4.Width = 250;
            column4.NullText = "";
            column4 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column3 = column;
            column3.HeaderText = "Descripci\x00f3n";
            column3.MappingName = "Desc2";
            column3.Width = 250;
            column3.NullText = "";
            column3 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column2 = column;
            column2.HeaderText = "";
            column2.MappingName = "PaisOrigen";
            column2.Width = 0;
            column2.NullText = "";
            column2 = null;
            table.GridColumnStyles.Add(column);
            this.dgTmpOCManual.TableStyles.Add(table);
            this.dgTmpOCManual.Refresh();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRecOCManual1));
            this.cmbSalir = new Button();
            this.dgTmpOCManual = new DataGrid();
            this.GroupBox1 = new GroupBox();
            this.dtpFechaEntOPend = new DateTimePicker();
            this.Label9 = new Label();
            this.btnCancelar = new Button();
            this.btnModificar = new Button();
            this.Label7 = new Label();
            this.editCantRec = new TextBox();
            this.Label6 = new Label();
            this.txtCantPend = new TextBox();
            this.txtDesc1 = new TextBox();
            this.Label4 = new Label();
            this.txtCodigo = new TextBox();
            this.Label3 = new Label();
            this.editNroLinea = new TextBox();
            this.Label2 = new Label();
            this.editNroOC = new TextBox();
            this.cmbReclamosOC = new Button();
            this.txtFechaRec = new TextBox();
            this.Label8 = new Label();
            this.Label5 = new Label();
            this.txtProveedor = new TextBox();
            this.Label10 = new Label();
            this.txtDespacho = new TextBox();
            this.Label11 = new Label();
            this.txtFechaImp = new TextBox();
            this.Label12 = new Label();
            this.txtCodAduana = new TextBox();
            this.txtDescAdu = new TextBox();
            this.btnAgregar = new Button();
            this.btnModif = new Button();
            this.txtDesc2 = new TextBox();
            this.dgTmpOCManual.BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            Point point = new Point(0x1a8, 520);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            Size size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 3;
            this.cmbSalir.Text = "&Salir";
            this.dgTmpOCManual.CaptionFont = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dgTmpOCManual.CaptionText = "Recepci\x00f3n O.Compra Manual";
            this.dgTmpOCManual.DataMember = "";
            this.dgTmpOCManual.HeaderForeColor = SystemColors.ControlText;
            point = new Point(80, 0x48);
            this.dgTmpOCManual.Location = point;
            this.dgTmpOCManual.Name = "dgTmpOCManual";
            this.dgTmpOCManual.ReadOnly = true;
            size = new Size(0x368, 440);
            this.dgTmpOCManual.Size = size;
            this.dgTmpOCManual.TabIndex = 0;
            this.GroupBox1.Controls.Add(this.txtDesc2);
            this.GroupBox1.Controls.Add(this.dtpFechaEntOPend);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.btnCancelar);
            this.GroupBox1.Controls.Add(this.btnModificar);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.editCantRec);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.txtCantPend);
            this.GroupBox1.Controls.Add(this.txtDesc1);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.txtCodigo);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.editNroLinea);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.editNroOC);
            point = new Point(80, 0x240);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(0x368, 0x90);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Visible = false;
            this.dtpFechaEntOPend.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaEntOPend.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaEntOPend.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaEntOPend.Format = DateTimePickerFormat.Short;
            point = new Point(480, 0x70);
            this.dtpFechaEntOPend.Location = point;
            this.dtpFechaEntOPend.Name = "dtpFechaEntOPend";
            size = new Size(0x60, 20);
            this.dtpFechaEntOPend.Size = size;
            this.dtpFechaEntOPend.TabIndex = 0x13;
            DateTime time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpFechaEntOPend.Value = time;
            this.dtpFechaEntOPend.Visible = false;
            point = new Point(0x170, 0x70);
            this.Label9.Location = point;
            this.Label9.Name = "Label9";
            size = new Size(0x68, 0x10);
            this.Label9.Size = size;
            this.Label9.TabIndex = 0x12;
            this.Label9.Text = "F.Ent.O.Pendiente:";
            this.Label9.Visible = false;
            point = new Point(0x2e8, 80);
            this.btnCancelar.Location = point;
            this.btnCancelar.Name = "btnCancelar";
            size = new Size(0x60, 0x18);
            this.btnCancelar.Size = size;
            this.btnCancelar.TabIndex = 0x11;
            this.btnCancelar.Text = "&Cancelar";
            point = new Point(0x2e8, 0x70);
            this.btnModificar.Location = point;
            this.btnModificar.Name = "btnModificar";
            size = new Size(0x60, 0x18);
            this.btnModificar.Size = size;
            this.btnModificar.TabIndex = 0x10;
            this.btnModificar.Text = "&Aceptar";
            point = new Point(0xb8, 0x70);
            this.Label7.Location = point;
            this.Label7.Name = "Label7";
            size = new Size(80, 0x10);
            this.Label7.Size = size;
            this.Label7.TabIndex = 14;
            this.Label7.Text = "Cant.Recibida:";
            point = new Point(0x110, 0x70);
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
            point = new Point(0x60, 0x70);
            this.txtCantPend.Location = point;
            this.txtCantPend.MaxLength = 7;
            this.txtCantPend.Name = "txtCantPend";
            size = new Size(80, 20);
            this.txtCantPend.Size = size;
            this.txtCantPend.TabIndex = 13;
            this.txtCantPend.Text = "";
            this.txtCantPend.TextAlign = HorizontalAlignment.Right;
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
            point = new Point(0x60, 0x38);
            this.txtCodigo.Location = point;
            this.txtCodigo.MaxLength = 8;
            this.txtCodigo.Name = "txtCodigo";
            size = new Size(80, 20);
            this.txtCodigo.Size = size;
            this.txtCodigo.TabIndex = 9;
            this.txtCodigo.Text = "";
            point = new Point(200, 0x18);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x30, 0x10);
            this.Label3.Size = size;
            this.Label3.TabIndex = 4;
            this.Label3.Text = "L\x00ednea:";
            this.editNroLinea.BackColor = SystemColors.Window;
            point = new Point(0x100, 0x18);
            this.editNroLinea.Location = point;
            this.editNroLinea.MaxLength = 6;
            this.editNroLinea.Name = "editNroLinea";
            size = new Size(0x48, 20);
            this.editNroLinea.Size = size;
            this.editNroLinea.TabIndex = 5;
            this.editNroLinea.Text = "";
            point = new Point(0x10, 0x18);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x38, 0x10);
            this.Label2.Size = size;
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Nro.OC:";
            this.editNroOC.BackColor = SystemColors.Window;
            point = new Point(0x60, 0x18);
            this.editNroOC.Location = point;
            this.editNroOC.MaxLength = 10;
            this.editNroOC.Name = "editNroOC";
            size = new Size(0x60, 20);
            this.editNroOC.Size = size;
            this.editNroOC.TabIndex = 3;
            this.editNroOC.Text = "";
            point = new Point(0x130, 520);
            this.cmbReclamosOC.Location = point;
            this.cmbReclamosOC.Name = "cmbReclamosOC";
            size = new Size(0x60, 40);
            this.cmbReclamosOC.Size = size;
            this.cmbReclamosOC.TabIndex = 4;
            this.cmbReclamosOC.Text = "&Reclamos";
            this.txtFechaRec.BackColor = SystemColors.Window;
            this.txtFechaRec.Enabled = false;
            this.txtFechaRec.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x88, 8);
            this.txtFechaRec.Location = point;
            this.txtFechaRec.MaxLength = 10;
            this.txtFechaRec.Name = "txtFechaRec";
            size = new Size(0x60, 0x16);
            this.txtFechaRec.Size = size;
            this.txtFechaRec.TabIndex = 0x39;
            this.txtFechaRec.Text = "";
            this.Label8.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 8);
            this.Label8.Location = point;
            this.Label8.Name = "Label8";
            size = new Size(120, 0x10);
            this.Label8.Size = size;
            this.Label8.TabIndex = 0x3a;
            this.Label8.Text = "Fecha Recepci\x00f3n:";
            this.Label5.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0xf8, 8);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size(0x48, 0x10);
            this.Label5.Size = size;
            this.Label5.TabIndex = 60;
            this.Label5.Text = "Proveedor:";
            this.txtProveedor.BackColor = SystemColors.Window;
            this.txtProveedor.Enabled = false;
            this.txtProveedor.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x148, 8);
            this.txtProveedor.Location = point;
            this.txtProveedor.MaxLength = 0x23;
            this.txtProveedor.Name = "txtProveedor";
            size = new Size(0x2a0, 0x16);
            this.txtProveedor.Size = size;
            this.txtProveedor.TabIndex = 0x3b;
            this.txtProveedor.Text = "";
            this.Label10.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 40);
            this.Label10.Location = point;
            this.Label10.Name = "Label10";
            size = new Size(0x70, 0x10);
            this.Label10.Size = size;
            this.Label10.TabIndex = 0x3d;
            this.Label10.Text = "Despacho:";
            this.txtDespacho.BackColor = SystemColors.Window;
            this.txtDespacho.Enabled = false;
            this.txtDespacho.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x88, 40);
            this.txtDespacho.Location = point;
            this.txtDespacho.MaxLength = 0x19;
            this.txtDespacho.Name = "txtDespacho";
            size = new Size(160, 0x16);
            this.txtDespacho.Size = size;
            this.txtDespacho.TabIndex = 0x3e;
            this.txtDespacho.Text = "";
            this.Label11.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x138, 40);
            this.Label11.Location = point;
            this.Label11.Name = "Label11";
            size = new Size(0x70, 0x10);
            this.Label11.Size = size;
            this.Label11.TabIndex = 0x3f;
            this.Label11.Text = "Fecha Imp.:";
            this.txtFechaImp.BackColor = SystemColors.Window;
            this.txtFechaImp.Enabled = false;
            this.txtFechaImp.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x1a8, 40);
            this.txtFechaImp.Location = point;
            this.txtFechaImp.MaxLength = 10;
            this.txtFechaImp.Name = "txtFechaImp";
            size = new Size(0x60, 0x16);
            this.txtFechaImp.Size = size;
            this.txtFechaImp.TabIndex = 0x40;
            this.txtFechaImp.Text = "";
            this.Label12.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x218, 40);
            this.Label12.Location = point;
            this.Label12.Name = "Label12";
            size = new Size(0x70, 0x10);
            this.Label12.Size = size;
            this.Label12.TabIndex = 0x41;
            this.Label12.Text = "C\x00f3digo Aduana:";
            this.txtCodAduana.BackColor = SystemColors.Window;
            this.txtCodAduana.Enabled = false;
            this.txtCodAduana.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x298, 40);
            this.txtCodAduana.Location = point;
            this.txtCodAduana.MaxLength = 10;
            this.txtCodAduana.Name = "txtCodAduana";
            size = new Size(40, 0x16);
            this.txtCodAduana.Size = size;
            this.txtCodAduana.TabIndex = 0x42;
            this.txtCodAduana.Text = "";
            this.txtDescAdu.BackColor = SystemColors.Window;
            this.txtDescAdu.Enabled = false;
            this.txtDescAdu.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x2c8, 40);
            this.txtDescAdu.Location = point;
            this.txtDescAdu.MaxLength = 0x19;
            this.txtDescAdu.Name = "txtDescAdu";
            size = new Size(160, 0x16);
            this.txtDescAdu.Size = size;
            this.txtDescAdu.TabIndex = 0x43;
            this.txtDescAdu.Text = "";
            point = new Point(80, 520);
            this.btnAgregar.Location = point;
            this.btnAgregar.Name = "btnAgregar";
            size = new Size(0x60, 40);
            this.btnAgregar.Size = size;
            this.btnAgregar.TabIndex = 0x44;
            this.btnAgregar.Text = "A&gregar";
            this.btnModif.Enabled = false;
            point = new Point(0xc0, 520);
            this.btnModif.Location = point;
            this.btnModif.Name = "btnModif";
            size = new Size(0x60, 40);
            this.btnModif.Size = size;
            this.btnModif.TabIndex = 0x45;
            this.btnModif.Text = "&Modificar";
            this.txtDesc2.BackColor = SystemColors.Window;
            this.txtDesc2.Enabled = false;
            point = new Point(0xb8, 80);
            this.txtDesc2.Location = point;
            this.txtDesc2.MaxLength = 0x19;
            this.txtDesc2.Name = "txtDesc2";
            size = new Size(0x1f0, 20);
            this.txtDesc2.Size = size;
            this.txtDesc2.TabIndex = 20;
            this.txtDesc2.Text = "";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            size = new Size(0x404, 0x2f1);
            this.ClientSize = size;
            this.Controls.Add(this.btnModif);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.txtCodAduana);
            this.Controls.Add(this.txtDescAdu);
            this.Controls.Add(this.txtFechaImp);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.txtDespacho);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.txtProveedor);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.txtFechaRec);
            this.Controls.Add(this.cmbReclamosOC);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.dgTmpOCManual);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmRecOCManual1";
            this.Text = "Recepci\x00f3n O.Compra Manual";
            this.WindowState = FormWindowState.Maximized;
            this.dgTmpOCManual.EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void Label9_Click(object sender, EventArgs e)
        {
        }

        private void txtCantPend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editCantRec.Focus();
            }
        }

        private void txtCantPend_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editCantRec.Focus();
            }
        }

        private void txtCodigo_LostFocus(object sender, EventArgs e)
        {
            bool flag = false;
            if (StringType.StrCmp(this.txtCodigo.Text, Strings.Space(0), false) != 0)
            {
                SqlConnection connection;
                try
                {
                    connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
                    connection.Open();
                    flag = true;
                    SqlDataReader reader = new SqlCommand("SELECT SC01001,SC01002,SC01003 FROM SC010100 where SC01001='" + this.txtCodigo.Text + "'", connection).ExecuteReader();
                    if (reader.Read())
                    {
                        this.txtDesc1.Text = StringType.FromObject(reader["SC01002"]);
                        this.txtDesc2.Text = StringType.FromObject(reader["SC01003"]);
                        reader.Close();
                    }
                    else
                    {
                        Interaction.MsgBox("Producto inexistente", 0x40, "Operador");
                        this.txtDesc1.Text = "";
                        this.txtDesc2.Text = "";
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

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
        }

        internal virtual Button btnAgregar
        {
            get
            {
                return this._btnAgregar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnAgregar != null)
                {
                    this._btnAgregar.Click -= new EventHandler(this.btnAgregar_Click);
                }
                this._btnAgregar = value;
                if (this._btnAgregar != null)
                {
                    this._btnAgregar.Click += new EventHandler(this.btnAgregar_Click);
                }
            }
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

        internal virtual Button btnModif
        {
            get
            {
                return this._btnModif;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnModif != null)
                {
                    this._btnModif.Click -= new EventHandler(this.btnModif_Click);
                }
                this._btnModif = value;
                if (this._btnModif != null)
                {
                    this._btnModif.Click += new EventHandler(this.btnModif_Click);
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

        internal virtual DataGrid dgTmpOCManual
        {
            get
            {
                return this._dgTmpOCManual;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dgTmpOCManual != null)
                {
                    this._dgTmpOCManual.Navigate -= new NavigateEventHandler(this.dgTmpOCManual_Navigate);
                    this._dgTmpOCManual.Click -= new EventHandler(this.dgTmpOCManual_Click);
                    this._dgTmpOCManual.DoubleClick -= new EventHandler(this.dgTmpOCManual_DoubleClick);
                }
                this._dgTmpOCManual = value;
                if (this._dgTmpOCManual != null)
                {
                    this._dgTmpOCManual.Navigate += new NavigateEventHandler(this.dgTmpOCManual_Navigate);
                    this._dgTmpOCManual.Click += new EventHandler(this.dgTmpOCManual_Click);
                    this._dgTmpOCManual.DoubleClick += new EventHandler(this.dgTmpOCManual_DoubleClick);
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
                    this._editNroOC.KeyPress -= new KeyPressEventHandler(this.editNroOC_KeyPress);
                    this._editNroOC.TextChanged -= new EventHandler(this.editNroOC_TextChanged);
                    this._editNroOC.LostFocus -= new EventHandler(this.editNroOC_LostFocus);
                }
                this._editNroOC = value;
                if (this._editNroOC != null)
                {
                    this._editNroOC.KeyPress += new KeyPressEventHandler(this.editNroOC_KeyPress);
                    this._editNroOC.TextChanged += new EventHandler(this.editNroOC_TextChanged);
                    this._editNroOC.LostFocus += new EventHandler(this.editNroOC_LostFocus);
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

        internal virtual Label Label10
        {
            get
            {
                return this._Label10;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label10 != null)
                {
                }
                this._Label10 = value;
                if (this._Label10 != null)
                {
                }
            }
        }

        internal virtual Label Label11
        {
            get
            {
                return this._Label11;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label11 != null)
                {
                }
                this._Label11 = value;
                if (this._Label11 != null)
                {
                }
            }
        }

        internal virtual Label Label12
        {
            get
            {
                return this._Label12;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label12 != null)
                {
                }
                this._Label12 = value;
                if (this._Label12 != null)
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
                    this._txtCantPend.KeyPress -= new KeyPressEventHandler(this.txtCantPend_KeyPress);
                    this._txtCantPend.TextChanged -= new EventHandler(this.txtCantPend_TextChanged);
                }
                this._txtCantPend = value;
                if (this._txtCantPend != null)
                {
                    this._txtCantPend.KeyPress += new KeyPressEventHandler(this.txtCantPend_KeyPress);
                    this._txtCantPend.TextChanged += new EventHandler(this.txtCantPend_TextChanged);
                }
            }
        }

        internal virtual TextBox txtCodAduana
        {
            get
            {
                return this._txtCodAduana;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtCodAduana != null)
                {
                }
                this._txtCodAduana = value;
                if (this._txtCodAduana != null)
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
                    this._txtCodigo.LostFocus -= new EventHandler(this.txtCodigo_LostFocus);
                    this._txtCodigo.KeyPress -= new KeyPressEventHandler(this.txtCodigo_KeyPress);
                    this._txtCodigo.TextChanged -= new EventHandler(this.txtCodigo_TextChanged);
                }
                this._txtCodigo = value;
                if (this._txtCodigo != null)
                {
                    this._txtCodigo.LostFocus += new EventHandler(this.txtCodigo_LostFocus);
                    this._txtCodigo.KeyPress += new KeyPressEventHandler(this.txtCodigo_KeyPress);
                    this._txtCodigo.TextChanged += new EventHandler(this.txtCodigo_TextChanged);
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

        internal virtual TextBox txtDescAdu
        {
            get
            {
                return this._txtDescAdu;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtDescAdu != null)
                {
                }
                this._txtDescAdu = value;
                if (this._txtDescAdu != null)
                {
                }
            }
        }

        internal virtual TextBox txtDespacho
        {
            get
            {
                return this._txtDespacho;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtDespacho != null)
                {
                }
                this._txtDespacho = value;
                if (this._txtDespacho != null)
                {
                }
            }
        }

        internal virtual TextBox txtFechaImp
        {
            get
            {
                return this._txtFechaImp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtFechaImp != null)
                {
                }
                this._txtFechaImp = value;
                if (this._txtFechaImp != null)
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

        internal virtual TextBox txtProveedor
        {
            get
            {
                return this._txtProveedor;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtProveedor != null)
                {
                }
                this._txtProveedor = value;
                if (this._txtProveedor != null)
                {
                }
            }
        }
    }
}

