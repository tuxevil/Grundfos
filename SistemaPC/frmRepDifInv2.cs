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

    public class frmRepDifInv2 : Form
    {
        [AccessedThroughProperty("btnModificar")]
        private Button _btnModificar;
        [AccessedThroughProperty("cmbCancelar")]
        private Button _cmbCancelar;
        [AccessedThroughProperty("cmbLisDifInv")]
        private Button _cmbLisDifInv;
        [AccessedThroughProperty("cmbLisRechazados")]
        private Button _cmbLisRechazados;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dgTmpInventario")]
        private DataGrid _dgTmpInventario;
        [AccessedThroughProperty("editPosFisico")]
        private TextBox _editPosFisico;
        [AccessedThroughProperty("editStkFisico")]
        private TextBox _editStkFisico;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label10")]
        private Label _Label10;
        [AccessedThroughProperty("Label11")]
        private Label _Label11;
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
        [AccessedThroughProperty("txtCodAlmacen")]
        private TextBox _txtCodAlmacen;
        [AccessedThroughProperty("txtCodigo")]
        private TextBox _txtCodigo;
        [AccessedThroughProperty("txtDesc1")]
        private TextBox _txtDesc1;
        [AccessedThroughProperty("txtDesc2")]
        private TextBox _txtDesc2;
        [AccessedThroughProperty("txtDesdeRack")]
        private TextBox _txtDesdeRack;
        [AccessedThroughProperty("txtDiferencia")]
        private TextBox _txtDiferencia;
        [AccessedThroughProperty("txtFechaInv")]
        private TextBox _txtFechaInv;
        [AccessedThroughProperty("txtHastaRack")]
        private TextBox _txtHastaRack;
        [AccessedThroughProperty("txtNomAlmacen")]
        private TextBox _txtNomAlmacen;
        [AccessedThroughProperty("txtPosSistema")]
        private TextBox _txtPosSistema;
        [AccessedThroughProperty("txtReferencia")]
        private TextBox _txtReferencia;
        [AccessedThroughProperty("txtStkSistema")]
        private TextBox _txtStkSistema;
        public SqlDataAdapter AdapTmpInventario;
        public SqlCommandBuilder CB;
        private IContainer components;
        public DataSet DS;
        public string mCodAduana;
        public DateTime mFecEntOPend;
        public DateTime mFechaImp;
        public long mID;
        public string mPaisOrigen;
        public string mPosOrig;
        public long TotReg;

        public frmRepDifInv2()
        {
            base.Load += new EventHandler(this.frmRepDifInv2_Load);
            base.Closed += new EventHandler(this.frmRepDifInv2_Closed);
            this.DS = new DataSet();
            this.InitializeComponent();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (StringType.StrCmp(this.editPosFisico.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe indicar Posici\x00f3n F\x00edsica", MsgBoxStyle.Critical, "Operador");
                this.editPosFisico.Focus();
            }
            else if (StringType.StrCmp(this.editStkFisico.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Stock F\x00edsico inv\x00e1lido", MsgBoxStyle.Critical, "Operador");
                this.editStkFisico.Focus();
            }
            else if (!Information.IsNumeric(this.editStkFisico.Text))
            {
                Interaction.MsgBox("Stock F\x00edsico inv\x00e1lido", MsgBoxStyle.Critical, "Operador");
                this.editStkFisico.Focus();
            }
            else
            {
                SqlConnection connection;
                this.txtDiferencia.Text = Strings.Format(LongType.FromString(this.editStkFisico.Text) - LongType.FromString(this.txtStkSistema.Text), "######0");
                try
                {
                    StreamWriter writer;
                    string str;
                    string connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    flag = true;
                    SqlCommand command = new SqlCommand(("update " + Variables.gTermi + "TmpInventario set Cantidad=" + this.editStkFisico.Text + ",Posicion='" + this.editPosFisico.Text) + "',Aceptar=1 where Posicion='" + this.mPosOrig + "' and Codigo='" + this.txtCodigo.Text + "'", connection);
                    int num = command.ExecuteNonQuery();
                    num = new SqlCommand(("update RepDifInv set Cantidad=" + this.editStkFisico.Text + ",Posicion='" + this.editPosFisico.Text) + "',Aceptar=1 where FechaInv='" + Strings.Format(Variables.gFechaInv, "MM/dd/yyyy") + "' and DesdeRack='" + Variables.gDesdeRack + "' and HastaRack='" + Variables.gHastaRack + "' and Almacen='" + Variables.gCodAlmacen + "' and Posicion='" + this.mPosOrig + "' and Codigo='" + this.txtCodigo.Text + "'", connection).ExecuteNonQuery();
                    if (LongType.FromString(this.editStkFisico.Text) != LongType.FromString(this.txtStkSistema.Text))
                    {
                        str = Variables.gCodAlmacen + this.txtCodigo.Text + Strings.Space(0x23 - Strings.Len(this.txtCodigo.Text));
                        if (LongType.FromString(this.txtDiferencia.Text) < 0L)
                        {
                            str = str + Strings.Format(Conversion.Val(this.txtDiferencia.Text), "0000000000.00000000");
                        }
                        else
                        {
                            str = str + Strings.Format(Conversion.Val(this.txtDiferencia.Text), "00000000000.00000000");
                        }
                        str = str + "1";
                        str = str + Variables.gReferencia + Strings.Space(10 - Strings.Len(Variables.gReferencia)) + "\r" + "\n";
                        writer = new StreamWriter(Variables.gPathTxt + @"\ajustestk.prn", true);
                        writer.Write(str);
                        writer.Close();
                    }
                    if (StringType.StrCmp(this.editPosFisico.Text, this.txtPosSistema.Text, false) != 0)
                    {
                        str = this.txtCodigo.Text + Strings.Space(0x23 - Strings.Len(this.txtCodigo.Text)) + Variables.gCodAlmacen;
                        str = str + Strings.Trim(this.editPosFisico.Text) + Strings.Space(6 - Strings.Len(Strings.Trim(this.editPosFisico.Text))) + "\r" + "\n";
                        writer = new StreamWriter(Variables.gPathTxt + @"\campos.prn", true);
                        writer.Write(str);
                        writer.Close();
                    }
                    connection.Close();
                    flag = false;
                    string selectCommandText = "select Posicion,Codigo,Desc1,Desc2,Cantidad,PosSist,CantSist,Cantidad-CantSist as Dife,Rechazar,Aceptar from " + Variables.gTermi + "TmpInventario where Aceptar=0 order by Codigo,Posicion";
                    this.AdapTmpInventario = new SqlDataAdapter(selectCommandText, connectionString);
                    this.DS.Clear();
                    this.CB = new SqlCommandBuilder(this.AdapTmpInventario);
                    this.AdapTmpInventario.Fill(this.DS, Variables.gTermi + "TmpInventario");
                    this.dgTmpInventario.DataSource = this.DS.Tables[Variables.gTermi + "TmpInventario"];
                    this.dgTmpInventario.Refresh();
                    this.GroupBox1.Visible = false;
                    this.dgTmpInventario.Enabled = true;
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                    if (flag)
                    {
                        connection.Close();
                        flag = false;
                    }
                    this.GroupBox1.Visible = false;
                    this.dgTmpInventario.Enabled = true;
                    ProjectData.ClearProjectError();
                    return;
                    ProjectData.ClearProjectError();
                }
            }
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            this.AdapTmpInventario.Update(this.DS, Variables.gTermi + "TmpInventario");
            this.DS.Tables[Variables.gTermi + "TmpInventario"].AcceptChanges();
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            string selectCommandText = "select Codigo,Desc1,Desc2,Cantidad,CantSist,Cantidad-CantSist as Dife,Rechazar,Aceptar from " + Variables.gTermi + "TmpInventario order by Codigo";
            this.AdapTmpInventario = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.DS.Clear();
            SqlCommandBuilder builder = new SqlCommandBuilder(this.AdapTmpInventario);
            this.DS.Tables.Clear();
            this.AdapTmpInventario.Fill(this.DS, Variables.gTermi + "TmpInventario");
            this.TotReg = this.DS.Tables[Variables.gTermi + "TmpInventario"].Rows.Count;
            this.dgTmpInventario.DataSource = this.DS.Tables[Variables.gTermi + "TmpInventario"];
            this.dgTmpInventario.Refresh();
        }

        private void cmbCancelar_Click(object sender, EventArgs e)
        {
            SqlConnection connection;
            bool flag;
            try
            {
                connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096");
                connection.Open();
                flag = true;
                this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 1] = false;
                int num = new SqlCommand("update " + Variables.gTermi + "TmpInventario set Aceptar=0 where Posicion='" + this.mPosOrig + "' and Codigo='" + this.txtCodigo.Text + "'", connection).ExecuteNonQuery();
                connection.Close();
                flag = false;
                this.GroupBox1.Visible = false;
                this.dgTmpInventario.Enabled = true;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                if (flag)
                {
                    connection.Close();
                    flag = false;
                }
                this.GroupBox1.Visible = false;
                this.dgTmpInventario.Enabled = true;
                ProjectData.ClearProjectError();
                return;
                ProjectData.ClearProjectError();
            }
        }

        private void cmbLisDifInv_Click(object sender, EventArgs e)
        {
            Variables.gGenDifInv = false;
            new frmGenDifInv1().ShowDialog();
        }

        private void cmbLisRechazados_Click(object sender, EventArgs e)
        {
            new frmRepDifInv1().ShowDialog();
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgTmpInventario_DoubleClick(object sender, EventArgs e)
        {
            if (this.DS.Tables[Variables.gTermi + "TmpInventario"].Rows.Count != 0)
            {
                if (this.dgTmpInventario.CurrentCell.ColumnNumber == 0)
                {
                    SqlCommand command;
                    SqlConnection connection;
                    bool flag;
                    int num9;
                    if (ObjectType.ObjTst(this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 0], false, false) == 0)
                    {
                        this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 0] = true;
                        this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 1] = false;
                        this.txtCodigo.Text = StringType.FromObject(this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 2]);
                        this.mPosOrig = StringType.FromObject(this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 5]);
                        try
                        {
                            connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096");
                            connection.Open();
                            flag = true;
                            command = new SqlCommand("update " + Variables.gTermi + "TmpInventario set Rechazar=1,Aceptar=0 where Posicion='" + this.mPosOrig + "' and Codigo='" + this.txtCodigo.Text + "'", connection);
                            num9 = command.ExecuteNonQuery();
                            command = new SqlCommand("update RepDifInv set Rechazar=1,Aceptar=0 where FechaInv='" + Strings.Format(Variables.gFechaInv, "MM/dd/yyyy") + "' and DesdeRack='" + Variables.gDesdeRack + "' and HastaRack='" + Variables.gHastaRack + "' and Almacen='" + Variables.gCodAlmacen + "' and Posicion='" + this.mPosOrig + "' and Codigo='" + this.txtCodigo.Text + "'", connection);
                            num9 = command.ExecuteNonQuery();
                            connection.Close();
                            flag = false;
                        }
                        catch (Exception exception1)
                        {
                            ProjectData.SetProjectError(exception1);
                            Exception exception = exception1;
                            Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                            if (flag)
                            {
                                connection.Close();
                                flag = false;
                            }
                            ProjectData.ClearProjectError();
                            return;
                            ProjectData.ClearProjectError();
                        }
                        this.GroupBox1.Visible = false;
                    }
                    else
                    {
                        this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 0] = false;
                        this.txtCodigo.Text = StringType.FromObject(this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 2]);
                        this.mPosOrig = StringType.FromObject(this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 5]);
                        try
                        {
                            connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096");
                            connection.Open();
                            flag = true;
                            command = new SqlCommand("update " + Variables.gTermi + "TmpInventario set Rechazar=0 where Posicion='" + this.mPosOrig + "' and Codigo='" + this.txtCodigo.Text + "'", connection);
                            num9 = command.ExecuteNonQuery();
                            num9 = new SqlCommand("update RepDifInv set Rechazar=0 where FechaInv='" + Strings.Format(Variables.gFechaInv, "MM/dd/yyyy") + "' and DesdeRack='" + Variables.gDesdeRack + "' and HastaRack='" + Variables.gHastaRack + "' and Almacen='" + Variables.gCodAlmacen + "' and Posicion='" + this.mPosOrig + "' and Codigo='" + this.txtCodigo.Text + "'", connection).ExecuteNonQuery();
                            connection.Close();
                            flag = false;
                        }
                        catch (Exception exception3)
                        {
                            ProjectData.SetProjectError(exception3);
                            Exception exception2 = exception3;
                            Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, MsgBoxStyle.OKOnly, null);
                            if (flag)
                            {
                                connection.Close();
                                flag = false;
                            }
                            ProjectData.ClearProjectError();
                            return;
                            ProjectData.ClearProjectError();
                        }
                        this.GroupBox1.Visible = false;
                    }
                }
                if (this.dgTmpInventario.CurrentCell.ColumnNumber == 1)
                {
                    if (ObjectType.ObjTst(this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 1], false, false) == 0)
                    {
                        this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 1] = true;
                        this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 0] = false;
                        this.txtCodigo.Text = StringType.FromObject(this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 2]);
                        this.txtDesc1.Text = StringType.FromObject(this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 3]);
                        if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 4])))
                        {
                            this.txtDesc2.Text = "";
                        }
                        else
                        {
                            this.txtDesc2.Text = StringType.FromObject(this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 4]);
                        }
                        this.editPosFisico.Text = StringType.FromObject(this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 5]);
                        this.mPosOrig = StringType.FromObject(this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 5]);
                        this.txtPosSistema.Text = StringType.FromObject(this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 6]);
                        this.editStkFisico.Text = StringType.FromObject(this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 7]);
                        this.txtStkSistema.Text = StringType.FromObject(this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 8]);
                        this.txtDiferencia.Text = StringType.FromObject(this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 9]);
                        this.txtReferencia.Text = Variables.gReferencia;
                        this.dgTmpInventario.Enabled = false;
                        this.GroupBox1.Visible = true;
                        this.editPosFisico.Focus();
                    }
                    else
                    {
                        this.dgTmpInventario[this.dgTmpInventario.CurrentCell.RowNumber, 1] = false;
                        this.GroupBox1.Visible = false;
                    }
                }
            }
        }

        private void dgTmpInventario_Navigate(object sender, NavigateEventArgs ne)
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

        private void editPosFisico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editStkFisico.Focus();
            }
        }

        private void editPosFisico_TextChanged(object sender, EventArgs e)
        {
        }

        private void editStkFisico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.btnModificar.Focus();
            }
        }

        private void editStkFisico_LostFocus(object sender, EventArgs e)
        {
            if ((StringType.StrCmp(this.editStkFisico.Text, Strings.Space(0), false) != 0) && Information.IsNumeric(this.editStkFisico.Text))
            {
                this.txtDiferencia.Text = Strings.Format(LongType.FromString(this.editStkFisico.Text) - LongType.FromString(this.txtStkSistema.Text), "######0");
            }
        }

        private void editStkFisico_TextChanged(object sender, EventArgs e)
        {
        }

        ~frmRepDifInv2()
        {
        }

        private void frmRepDifInv2_Closed(object sender, EventArgs e)
        {
            new frmRepDifInv().Show();
        }

        private void frmRepDifInv2_Load(object sender, EventArgs e)
        {
            this.txtFechaInv.Text = Strings.Format(Variables.gFechaInv, "dd/MM/yyyy");
            this.txtCodAlmacen.Text = Variables.gCodAlmacen;
            this.txtNomAlmacen.Text = Variables.gNomAlmacen;
            this.txtDesdeRack.Text = Variables.gDesdeRack;
            this.txtHastaRack.Text = Variables.gHastaRack;
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            string selectCommandText = "select Posicion,Codigo,Desc1,Desc2,Cantidad,PosSist,CantSist,Cantidad-CantSist as Dife,Rechazar,Aceptar from " + Variables.gTermi + "TmpInventario where Aceptar=0 order by Codigo,Posicion";
            this.AdapTmpInventario = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.CB = new SqlCommandBuilder(this.AdapTmpInventario);
            this.AdapTmpInventario.Fill(this.DS, Variables.gTermi + "TmpInventario");
            this.dgTmpInventario.DataSource = this.DS.Tables[Variables.gTermi + "TmpInventario"];
            DataGridTableStyle table = new DataGridTableStyle();
            table.MappingName = Variables.gTermi + "TmpInventario";
            DataGridTextBoxColumn column = new DataGridTextBoxColumn();
            DataGridBoolColumn column2 = new DataGridBoolColumn();
            DataGridBoolColumn column12 = column2;
            column12.HeaderText = "Rechazar";
            column12.MappingName = "Rechazar";
            column12.Width = 60;
            column12 = null;
            table.GridColumnStyles.Add(column2);
            column2 = new DataGridBoolColumn();
            DataGridBoolColumn column11 = column2;
            column11.HeaderText = "Aceptar";
            column11.MappingName = "Aceptar";
            column11.Width = 60;
            column11 = null;
            table.GridColumnStyles.Add(column2);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column10 = column;
            column10.HeaderText = "C\x00f3digo";
            column10.MappingName = "Codigo";
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
            column7.HeaderText = "Pos.F\x00edsico";
            column7.MappingName = "Posicion";
            column7.Width = 70;
            column7.NullText = "";
            column7 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column6 = column;
            column6.HeaderText = "Pos.Sist.";
            column6.MappingName = "PosSist";
            column6.Width = 70;
            column6.NullText = "";
            column6 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column5 = column;
            column5.HeaderText = "Stk.F\x00edsico";
            column5.MappingName = "Cantidad";
            column5.Width = 70;
            column5.Format = "######0";
            column5.NullText = "";
            column5 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column4 = column;
            column4.HeaderText = "Stk.Sistema";
            column4.MappingName = "CantSist";
            column4.Width = 70;
            column4.Format = "######0";
            column4 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column3 = column;
            column3.HeaderText = "Diferencia";
            column3.MappingName = "Dife";
            column3.Width = 60;
            column3.Format = "######0";
            column3 = null;
            table.GridColumnStyles.Add(column);
            this.dgTmpInventario.TableStyles.Add(table);
            this.dgTmpInventario.Refresh();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRepDifInv2));
            this.cmbSalir = new Button();
            this.dgTmpInventario = new DataGrid();
            this.cmbLisRechazados = new Button();
            this.txtFechaInv = new TextBox();
            this.Label8 = new Label();
            this.Label1 = new Label();
            this.txtCodAlmacen = new TextBox();
            this.txtNomAlmacen = new TextBox();
            this.GroupBox1 = new GroupBox();
            this.cmbCancelar = new Button();
            this.txtReferencia = new TextBox();
            this.Label11 = new Label();
            this.Label3 = new Label();
            this.txtDiferencia = new TextBox();
            this.btnModificar = new Button();
            this.Label7 = new Label();
            this.txtStkSistema = new TextBox();
            this.Label6 = new Label();
            this.editStkFisico = new TextBox();
            this.txtDesc2 = new TextBox();
            this.txtDesc1 = new TextBox();
            this.Label4 = new Label();
            this.txtCodigo = new TextBox();
            this.Label2 = new Label();
            this.txtPosSistema = new TextBox();
            this.Label10 = new Label();
            this.editPosFisico = new TextBox();
            this.Label5 = new Label();
            this.txtHastaRack = new TextBox();
            this.Label9 = new Label();
            this.txtDesdeRack = new TextBox();
            this.cmbLisDifInv = new Button();
            this.dgTmpInventario.BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            Point point = new Point(0x390, 640);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            Size size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 3;
            this.cmbSalir.Text = "&Salir";
            this.dgTmpInventario.CaptionFont = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dgTmpInventario.CaptionText = "Inventario";
            this.dgTmpInventario.DataMember = "";
            this.dgTmpInventario.HeaderForeColor = SystemColors.ControlText;
            point = new Point(8, 40);
            this.dgTmpInventario.Location = point;
            this.dgTmpInventario.Name = "dgTmpInventario";
            this.dgTmpInventario.ReadOnly = true;
            size = new Size(0x3f8, 0x210);
            this.dgTmpInventario.Size = size;
            this.dgTmpInventario.TabIndex = 0;
            point = new Point(800, 0x260);
            this.cmbLisRechazados.Location = point;
            this.cmbLisRechazados.Name = "cmbLisRechazados";
            size = new Size(0x60, 40);
            this.cmbLisRechazados.Size = size;
            this.cmbLisRechazados.TabIndex = 4;
            this.cmbLisRechazados.Text = "Listado &Rechazados";
            this.txtFechaInv.BackColor = SystemColors.Window;
            this.txtFechaInv.Enabled = false;
            this.txtFechaInv.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(120, 8);
            this.txtFechaInv.Location = point;
            this.txtFechaInv.MaxLength = 10;
            this.txtFechaInv.Name = "txtFechaInv";
            size = new Size(0x88, 0x16);
            this.txtFechaInv.Size = size;
            this.txtFechaInv.TabIndex = 0x39;
            this.txtFechaInv.Text = "";
            this.Label8.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 8);
            this.Label8.Location = point;
            this.Label8.Name = "Label8";
            size = new Size(0x70, 0x10);
            this.Label8.Size = size;
            this.Label8.TabIndex = 0x38;
            this.Label8.Text = "Fecha Inventario:";
            this.Label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x110, 8);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x40, 0x10);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0x3a;
            this.Label1.Text = "Almac\x00e9n:";
            this.txtCodAlmacen.BackColor = SystemColors.Window;
            this.txtCodAlmacen.Enabled = false;
            this.txtCodAlmacen.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x150, 8);
            this.txtCodAlmacen.Location = point;
            this.txtCodAlmacen.MaxLength = 6;
            this.txtCodAlmacen.Name = "txtCodAlmacen";
            size = new Size(40, 0x16);
            this.txtCodAlmacen.Size = size;
            this.txtCodAlmacen.TabIndex = 0x44;
            this.txtCodAlmacen.Text = "";
            this.txtNomAlmacen.BackColor = SystemColors.Window;
            this.txtNomAlmacen.Enabled = false;
            this.txtNomAlmacen.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x180, 8);
            this.txtNomAlmacen.Location = point;
            this.txtNomAlmacen.MaxLength = 0;
            this.txtNomAlmacen.Name = "txtNomAlmacen";
            size = new Size(280, 0x16);
            this.txtNomAlmacen.Size = size;
            this.txtNomAlmacen.TabIndex = 0x45;
            this.txtNomAlmacen.Text = "";
            this.GroupBox1.Controls.Add(this.cmbCancelar);
            this.GroupBox1.Controls.Add(this.txtReferencia);
            this.GroupBox1.Controls.Add(this.Label11);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.txtDiferencia);
            this.GroupBox1.Controls.Add(this.btnModificar);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.txtStkSistema);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.editStkFisico);
            this.GroupBox1.Controls.Add(this.txtDesc2);
            this.GroupBox1.Controls.Add(this.txtDesc1);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.txtCodigo);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.txtPosSistema);
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.editPosFisico);
            point = new Point(8, 0x240);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(720, 0x90);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 70;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Visible = false;
            point = new Point(0x200, 0x68);
            this.cmbCancelar.Location = point;
            this.cmbCancelar.Name = "cmbCancelar";
            size = new Size(0x60, 0x18);
            this.cmbCancelar.Size = size;
            this.cmbCancelar.TabIndex = 0x16;
            this.cmbCancelar.Text = "&Cancelar";
            this.txtReferencia.BackColor = SystemColors.Window;
            this.txtReferencia.Enabled = false;
            point = new Point(0x60, 0x70);
            this.txtReferencia.Location = point;
            this.txtReferencia.MaxLength = 10;
            this.txtReferencia.Name = "txtReferencia";
            size = new Size(0xd0, 20);
            this.txtReferencia.Size = size;
            this.txtReferencia.TabIndex = 0x15;
            this.txtReferencia.Text = "";
            point = new Point(0x10, 0x70);
            this.Label11.Location = point;
            this.Label11.Name = "Label11";
            size = new Size(0x48, 0x10);
            this.Label11.Size = size;
            this.Label11.TabIndex = 20;
            this.Label11.Text = "Referencia:";
            point = new Point(0x160, 0x58);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x40, 0x10);
            this.Label3.Size = size;
            this.Label3.TabIndex = 0x12;
            this.Label3.Text = "Diferencia:";
            this.txtDiferencia.BackColor = SystemColors.Window;
            this.txtDiferencia.Enabled = false;
            point = new Point(0x1a0, 0x58);
            this.txtDiferencia.Location = point;
            this.txtDiferencia.MaxLength = 7;
            this.txtDiferencia.Name = "txtDiferencia";
            size = new Size(80, 20);
            this.txtDiferencia.Size = size;
            this.txtDiferencia.TabIndex = 0x13;
            this.txtDiferencia.Text = "";
            this.txtDiferencia.TextAlign = HorizontalAlignment.Right;
            point = new Point(0x268, 0x68);
            this.btnModificar.Location = point;
            this.btnModificar.Name = "btnModificar";
            size = new Size(0x60, 0x18);
            this.btnModificar.Size = size;
            this.btnModificar.TabIndex = 0x10;
            this.btnModificar.Text = "&Modificar";
            point = new Point(0xb8, 0x58);
            this.Label7.Location = point;
            this.Label7.Name = "Label7";
            size = new Size(0x48, 0x10);
            this.Label7.Size = size;
            this.Label7.TabIndex = 14;
            this.Label7.Text = "Stk.Sistema:";
            this.txtStkSistema.BackColor = SystemColors.Window;
            this.txtStkSistema.Enabled = false;
            point = new Point(0x108, 0x58);
            this.txtStkSistema.Location = point;
            this.txtStkSistema.MaxLength = 7;
            this.txtStkSistema.Name = "txtStkSistema";
            size = new Size(80, 20);
            this.txtStkSistema.Size = size;
            this.txtStkSistema.TabIndex = 15;
            this.txtStkSistema.Text = "";
            this.txtStkSistema.TextAlign = HorizontalAlignment.Right;
            point = new Point(0x10, 0x58);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(0x38, 0x10);
            this.Label6.Size = size;
            this.Label6.TabIndex = 12;
            this.Label6.Text = "Stk.F\x00edsico:";
            this.editStkFisico.BackColor = SystemColors.Window;
            point = new Point(0x60, 0x58);
            this.editStkFisico.Location = point;
            this.editStkFisico.MaxLength = 7;
            this.editStkFisico.Name = "editStkFisico";
            size = new Size(80, 20);
            this.editStkFisico.Size = size;
            this.editStkFisico.TabIndex = 13;
            this.editStkFisico.Text = "";
            this.editStkFisico.TextAlign = HorizontalAlignment.Right;
            this.txtDesc2.BackColor = SystemColors.Window;
            this.txtDesc2.Enabled = false;
            point = new Point(0xb8, 40);
            this.txtDesc2.Location = point;
            this.txtDesc2.MaxLength = 0x19;
            this.txtDesc2.Name = "txtDesc2";
            size = new Size(0x210, 20);
            this.txtDesc2.Size = size;
            this.txtDesc2.TabIndex = 11;
            this.txtDesc2.Text = "";
            this.txtDesc1.BackColor = SystemColors.Window;
            this.txtDesc1.Enabled = false;
            point = new Point(0xb8, 0x10);
            this.txtDesc1.Location = point;
            this.txtDesc1.MaxLength = 0x19;
            this.txtDesc1.Name = "txtDesc1";
            size = new Size(0x210, 20);
            this.txtDesc1.Size = size;
            this.txtDesc1.TabIndex = 10;
            this.txtDesc1.Text = "";
            point = new Point(0x10, 0x10);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(0x48, 0x10);
            this.Label4.Size = size;
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Producto:";
            this.txtCodigo.BackColor = SystemColors.Window;
            this.txtCodigo.Enabled = false;
            point = new Point(0x60, 0x10);
            this.txtCodigo.Location = point;
            this.txtCodigo.MaxLength = 8;
            this.txtCodigo.Name = "txtCodigo";
            size = new Size(80, 20);
            this.txtCodigo.Size = size;
            this.txtCodigo.TabIndex = 9;
            this.txtCodigo.Text = "";
            point = new Point(0xb8, 0x40);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x48, 0x10);
            this.Label2.Size = size;
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Pos.Sistema:";
            this.txtPosSistema.BackColor = SystemColors.Window;
            this.txtPosSistema.Enabled = false;
            point = new Point(0x108, 0x40);
            this.txtPosSistema.Location = point;
            this.txtPosSistema.MaxLength = 6;
            this.txtPosSistema.Name = "txtPosSistema";
            size = new Size(80, 20);
            this.txtPosSistema.Size = size;
            this.txtPosSistema.TabIndex = 3;
            this.txtPosSistema.Text = "";
            point = new Point(0x10, 0x40);
            this.Label10.Location = point;
            this.Label10.Name = "Label10";
            size = new Size(0x48, 0x10);
            this.Label10.Size = size;
            this.Label10.TabIndex = 0;
            this.Label10.Text = "Pos.F\x00edsico:";
            this.editPosFisico.BackColor = SystemColors.Window;
            point = new Point(0x60, 0x40);
            this.editPosFisico.Location = point;
            this.editPosFisico.MaxLength = 6;
            this.editPosFisico.Name = "editPosFisico";
            size = new Size(80, 20);
            this.editPosFisico.Size = size;
            this.editPosFisico.TabIndex = 1;
            this.editPosFisico.Text = "";
            this.Label5.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x330, 8);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size(80, 0x17);
            this.Label5.Size = size;
            this.Label5.TabIndex = 0x49;
            this.Label5.Text = "Hasta Rack:";
            this.txtHastaRack.BackColor = SystemColors.Window;
            this.txtHastaRack.Enabled = false;
            this.txtHastaRack.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x388, 8);
            this.txtHastaRack.Location = point;
            this.txtHastaRack.MaxLength = 2;
            this.txtHastaRack.Name = "txtHastaRack";
            size = new Size(40, 0x16);
            this.txtHastaRack.Size = size;
            this.txtHastaRack.TabIndex = 0x4a;
            this.txtHastaRack.Text = "";
            this.Label9.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x2a0, 8);
            this.Label9.Location = point;
            this.Label9.Name = "Label9";
            size = new Size(0x58, 0x17);
            this.Label9.Size = size;
            this.Label9.TabIndex = 0x47;
            this.Label9.Text = "Desde Rack:";
            this.txtDesdeRack.BackColor = SystemColors.Window;
            this.txtDesdeRack.Enabled = false;
            this.txtDesdeRack.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x300, 8);
            this.txtDesdeRack.Location = point;
            this.txtDesdeRack.MaxLength = 2;
            this.txtDesdeRack.Name = "txtDesdeRack";
            size = new Size(40, 0x16);
            this.txtDesdeRack.Size = size;
            this.txtDesdeRack.TabIndex = 0x48;
            this.txtDesdeRack.Text = "";
            point = new Point(800, 0x298);
            this.cmbLisDifInv.Location = point;
            this.cmbLisDifInv.Name = "cmbLisDifInv";
            size = new Size(0x60, 40);
            this.cmbLisDifInv.Size = size;
            this.cmbLisDifInv.TabIndex = 0x4b;
            this.cmbLisDifInv.Text = "Listado &Diferencias";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            size = new Size(0x404, 0x2f1);
            this.ClientSize = size;
            this.Controls.Add(this.cmbLisDifInv);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.txtHastaRack);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.txtDesdeRack);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.txtCodAlmacen);
            this.Controls.Add(this.txtNomAlmacen);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtFechaInv);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.cmbLisRechazados);
            this.Controls.Add(this.dgTmpInventario);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmRepDifInv2";
            this.Text = "Reporte Diferencias Inventario";
            this.WindowState = FormWindowState.Maximized;
            this.dgTmpInventario.EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
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

        internal virtual Button cmbCancelar
        {
            get
            {
                return this._cmbCancelar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbCancelar != null)
                {
                    this._cmbCancelar.Click -= new EventHandler(this.cmbCancelar_Click);
                }
                this._cmbCancelar = value;
                if (this._cmbCancelar != null)
                {
                    this._cmbCancelar.Click += new EventHandler(this.cmbCancelar_Click);
                }
            }
        }

        internal virtual Button cmbLisDifInv
        {
            get
            {
                return this._cmbLisDifInv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbLisDifInv != null)
                {
                    this._cmbLisDifInv.Click -= new EventHandler(this.cmbLisDifInv_Click);
                }
                this._cmbLisDifInv = value;
                if (this._cmbLisDifInv != null)
                {
                    this._cmbLisDifInv.Click += new EventHandler(this.cmbLisDifInv_Click);
                }
            }
        }

        internal virtual Button cmbLisRechazados
        {
            get
            {
                return this._cmbLisRechazados;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbLisRechazados != null)
                {
                    this._cmbLisRechazados.Click -= new EventHandler(this.cmbLisRechazados_Click);
                }
                this._cmbLisRechazados = value;
                if (this._cmbLisRechazados != null)
                {
                    this._cmbLisRechazados.Click += new EventHandler(this.cmbLisRechazados_Click);
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

        internal virtual DataGrid dgTmpInventario
        {
            get
            {
                return this._dgTmpInventario;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dgTmpInventario != null)
                {
                    this._dgTmpInventario.Navigate -= new NavigateEventHandler(this.dgTmpInventario_Navigate);
                    this._dgTmpInventario.DoubleClick -= new EventHandler(this.dgTmpInventario_DoubleClick);
                }
                this._dgTmpInventario = value;
                if (this._dgTmpInventario != null)
                {
                    this._dgTmpInventario.Navigate += new NavigateEventHandler(this.dgTmpInventario_Navigate);
                    this._dgTmpInventario.DoubleClick += new EventHandler(this.dgTmpInventario_DoubleClick);
                }
            }
        }

        internal virtual TextBox editPosFisico
        {
            get
            {
                return this._editPosFisico;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editPosFisico != null)
                {
                    this._editPosFisico.KeyPress -= new KeyPressEventHandler(this.editPosFisico_KeyPress);
                    this._editPosFisico.TextChanged -= new EventHandler(this.editPosFisico_TextChanged);
                }
                this._editPosFisico = value;
                if (this._editPosFisico != null)
                {
                    this._editPosFisico.KeyPress += new KeyPressEventHandler(this.editPosFisico_KeyPress);
                    this._editPosFisico.TextChanged += new EventHandler(this.editPosFisico_TextChanged);
                }
            }
        }

        internal virtual TextBox editStkFisico
        {
            get
            {
                return this._editStkFisico;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editStkFisico != null)
                {
                    this._editStkFisico.KeyPress -= new KeyPressEventHandler(this.editStkFisico_KeyPress);
                    this._editStkFisico.LostFocus -= new EventHandler(this.editStkFisico_LostFocus);
                    this._editStkFisico.TextChanged -= new EventHandler(this.editStkFisico_TextChanged);
                }
                this._editStkFisico = value;
                if (this._editStkFisico != null)
                {
                    this._editStkFisico.KeyPress += new KeyPressEventHandler(this.editStkFisico_KeyPress);
                    this._editStkFisico.LostFocus += new EventHandler(this.editStkFisico_LostFocus);
                    this._editStkFisico.TextChanged += new EventHandler(this.editStkFisico_TextChanged);
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
                }
                this._Label9 = value;
                if (this._Label9 != null)
                {
                }
            }
        }

        internal virtual TextBox txtCodAlmacen
        {
            get
            {
                return this._txtCodAlmacen;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtCodAlmacen != null)
                {
                }
                this._txtCodAlmacen = value;
                if (this._txtCodAlmacen != null)
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

        internal virtual TextBox txtDesdeRack
        {
            get
            {
                return this._txtDesdeRack;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtDesdeRack != null)
                {
                }
                this._txtDesdeRack = value;
                if (this._txtDesdeRack != null)
                {
                }
            }
        }

        internal virtual TextBox txtDiferencia
        {
            get
            {
                return this._txtDiferencia;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtDiferencia != null)
                {
                }
                this._txtDiferencia = value;
                if (this._txtDiferencia != null)
                {
                }
            }
        }

        internal virtual TextBox txtFechaInv
        {
            get
            {
                return this._txtFechaInv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtFechaInv != null)
                {
                }
                this._txtFechaInv = value;
                if (this._txtFechaInv != null)
                {
                }
            }
        }

        internal virtual TextBox txtHastaRack
        {
            get
            {
                return this._txtHastaRack;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtHastaRack != null)
                {
                }
                this._txtHastaRack = value;
                if (this._txtHastaRack != null)
                {
                }
            }
        }

        internal virtual TextBox txtNomAlmacen
        {
            get
            {
                return this._txtNomAlmacen;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtNomAlmacen != null)
                {
                }
                this._txtNomAlmacen = value;
                if (this._txtNomAlmacen != null)
                {
                }
            }
        }

        internal virtual TextBox txtPosSistema
        {
            get
            {
                return this._txtPosSistema;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtPosSistema != null)
                {
                }
                this._txtPosSistema = value;
                if (this._txtPosSistema != null)
                {
                }
            }
        }

        internal virtual TextBox txtReferencia
        {
            get
            {
                return this._txtReferencia;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtReferencia != null)
                {
                }
                this._txtReferencia = value;
                if (this._txtReferencia != null)
                {
                }
            }
        }

        internal virtual TextBox txtStkSistema
        {
            get
            {
                return this._txtStkSistema;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtStkSistema != null)
                {
                }
                this._txtStkSistema = value;
                if (this._txtStkSistema != null)
                {
                }
            }
        }
    }
}

