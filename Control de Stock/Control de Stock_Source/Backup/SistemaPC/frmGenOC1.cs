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

    public class frmGenOC1 : Form
    {
        [AccessedThroughProperty("btnCancelar")]
        private Button _btnCancelar;
        [AccessedThroughProperty("btnModificar")]
        private Button _btnModificar;
        [AccessedThroughProperty("chkDeselTodo")]
        private CheckBox _chkDeselTodo;
        [AccessedThroughProperty("chkSelTodo")]
        private CheckBox _chkSelTodo;
        [AccessedThroughProperty("cmbEliminar")]
        private Button _cmbEliminar;
        [AccessedThroughProperty("cmbGenOC")]
        private Button _cmbGenOC;
        [AccessedThroughProperty("cmbListado")]
        private Button _cmbListado;
        [AccessedThroughProperty("cmbListadoOCGen")]
        private Button _cmbListadoOCGen;
        [AccessedThroughProperty("cmbModificar")]
        private Button _cmbModificar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dgTmpOCompra")]
        private DataGrid _dgTmpOCompra;
        [AccessedThroughProperty("dtpFechaEntOC01")]
        private DateTimePicker _dtpFechaEntOC01;
        [AccessedThroughProperty("dtpFechaEntOC02")]
        private DateTimePicker _dtpFechaEntOC02;
        [AccessedThroughProperty("dtpFechaEntOC03")]
        private DateTimePicker _dtpFechaEntOC03;
        [AccessedThroughProperty("editCodProv")]
        private TextBox _editCodProv;
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
        [AccessedThroughProperty("txtAlmacen")]
        private TextBox _txtAlmacen;
        [AccessedThroughProperty("txtMetEnv01")]
        private TextBox _txtMetEnv01;
        [AccessedThroughProperty("txtMetEnv02")]
        private TextBox _txtMetEnv02;
        [AccessedThroughProperty("txtMetEnv03")]
        private TextBox _txtMetEnv03;
        [AccessedThroughProperty("txtNomProv")]
        private TextBox _txtNomProv;
        public SqlDataAdapter AdapTmpOCompra;
        public SqlCommandBuilder CB;
        private IContainer components;
        public DataSet DS;
        public DataSet DS1;
        public string mCodAduana;
        public DateTime mFechaImp;
        public string mPaisOrigen;
        public long TotReg;
        public long xID;

        public frmGenOC1()
        {
            base.Load += new EventHandler(this.frmGenOC1_Load);
            base.Closed += new EventHandler(this.frmGenOC1_Closed);
            this.DS = new DataSet();
            this.DS1 = new DataSet();
            this.InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            int num2 = this.DS.Tables[Variables.gTermi + "TmpOCompra"].Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (ObjectType.ObjTst(this.dgTmpOCompra[i, 0], true, false) == 0)
                {
                    this.dgTmpOCompra[i, 0] = false;
                }
            }
            this.GroupBox1.Visible = false;
            this.cmbModificar.Enabled = true;
            this.cmbEliminar.Enabled = true;
            this.cmbGenOC.Enabled = true;
            this.cmbListado.Enabled = true;
            this.cmbListadoOCGen.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (StringType.StrCmp(this.editCodProv.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe ingresar Proveedor", 0x10, "Operador");
                this.editCodProv.Focus();
            }
            else if (StringType.StrCmp(this.txtNomProv.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe ingresar Proveedor", 0x10, "Operador");
                this.editCodProv.Focus();
            }
            else
            {
                SqlConnection connection;
                string str4;
                this.AdapTmpOCompra.Update(this.DS, Variables.gTermi + "TmpOCompra");
                this.DS.Tables[Variables.gTermi + "TmpOCompra"].AcceptChanges();
                try
                {
                    str4 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                    connection = new SqlConnection(str4);
                    connection.Open();
                    flag = true;
                    int num3 = this.DS.Tables[Variables.gTermi + "TmpOCompra"].Rows.Count - 1;
                    for (int i = 0; i <= num3; i++)
                    {
                        if (ObjectType.ObjTst(this.dgTmpOCompra[i, 0], true, false) == 0)
                        {
                            int num2 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(("update " + Variables.gTermi + "TmpOCompra set CodProv='" + this.editCodProv.Text + "',NomProv='" + this.txtNomProv.Text + "',FecEntOC01='" + Strings.Format(this.dtpFechaEntOC01.Value, "MM/dd/yyyy") + "',FecEntOC02='" + Strings.Format(this.dtpFechaEntOC02.Value, "MM/dd/yyyy") + "',FecEntOC03='" + Strings.Format(this.dtpFechaEntOC03.Value, "MM/dd/yyyy")) + "',Seleccion=0 where Codigo='", this.dgTmpOCompra[i, 1]), "'")), connection).ExecuteNonQuery();
                        }
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
                string selectCommandText = "select * from " + Variables.gTermi + "TmpOCompra order by CodProv";
                this.AdapTmpOCompra = new SqlDataAdapter(selectCommandText, str4);
                this.CB = new SqlCommandBuilder(this.AdapTmpOCompra);
                this.DS.Clear();
                this.AdapTmpOCompra.Fill(this.DS, Variables.gTermi + "TmpOCompra");
                this.TotReg = this.DS.Tables[Variables.gTermi + "TmpOCompra"].Rows.Count;
                this.dgTmpOCompra.DataSource = this.DS.Tables[Variables.gTermi + "TmpOCompra"];
                this.dgTmpOCompra.Refresh();
                this.GroupBox1.Visible = false;
                this.cmbModificar.Enabled = true;
                this.cmbEliminar.Enabled = true;
                this.cmbGenOC.Enabled = true;
                this.cmbListado.Enabled = true;
                this.cmbListadoOCGen.Enabled = true;
            }
        }

        private void chkDeselTodo_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = false;
            if (this.chkDeselTodo.Checked)
            {
                SqlConnection connection;
                string str4;
                this.AdapTmpOCompra.Update(this.DS, Variables.gTermi + "TmpOCompra");
                this.DS.Tables[Variables.gTermi + "TmpOCompra"].AcceptChanges();
                try
                {
                    str4 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                    connection = new SqlConnection(str4);
                    connection.Open();
                    flag = true;
                    int num = new SqlCommand("update " + Variables.gTermi + "TmpOCompra set Seleccion=0", connection).ExecuteNonQuery();
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
                string selectCommandText = "select * from " + Variables.gTermi + "TmpOCompra order by CodProv";
                this.AdapTmpOCompra = new SqlDataAdapter(selectCommandText, str4);
                this.CB = new SqlCommandBuilder(this.AdapTmpOCompra);
                this.DS.Clear();
                this.AdapTmpOCompra.Fill(this.DS, Variables.gTermi + "TmpOCompra");
                this.TotReg = this.DS.Tables[Variables.gTermi + "TmpOCompra"].Rows.Count;
                this.dgTmpOCompra.DataSource = this.DS.Tables[Variables.gTermi + "TmpOCompra"];
                this.dgTmpOCompra.Refresh();
                this.dgTmpOCompra.Refresh();
                this.chkDeselTodo.Checked = false;
            }
        }

        private void chkSelTodo_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = false;
            if (this.chkSelTodo.Checked)
            {
                SqlConnection connection;
                string str4;
                this.AdapTmpOCompra.Update(this.DS, Variables.gTermi + "TmpOCompra");
                this.DS.Tables[Variables.gTermi + "TmpOCompra"].AcceptChanges();
                try
                {
                    str4 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                    connection = new SqlConnection(str4);
                    connection.Open();
                    flag = true;
                    int num = new SqlCommand("update " + Variables.gTermi + "TmpOCompra set Seleccion=1", connection).ExecuteNonQuery();
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
                string selectCommandText = "select * from " + Variables.gTermi + "TmpOCompra order by CodProv";
                this.AdapTmpOCompra = new SqlDataAdapter(selectCommandText, str4);
                this.CB = new SqlCommandBuilder(this.AdapTmpOCompra);
                this.DS.Clear();
                this.AdapTmpOCompra.Fill(this.DS, Variables.gTermi + "TmpOCompra");
                this.TotReg = this.DS.Tables[Variables.gTermi + "TmpOCompra"].Rows.Count;
                this.dgTmpOCompra.DataSource = this.DS.Tables[Variables.gTermi + "TmpOCompra"];
                this.dgTmpOCompra.Refresh();
                this.dgTmpOCompra.Refresh();
                this.chkSelTodo.Checked = false;
            }
        }

        private void cmbEliminar_Click(object sender, EventArgs e)
        {
            int num;
            bool flag2 = false;
            int num4 = this.DS.Tables[Variables.gTermi + "TmpOCompra"].Rows.Count - 1;
            for (num = 0; num <= num4; num++)
            {
                if (ObjectType.ObjTst(this.dgTmpOCompra[num, 0], true, false) == 0)
                {
                    flag2 = true;
                    break;
                }
            }
            if (!flag2)
            {
                Interaction.MsgBox("Debe seleccionar productos a eliminar", 0x10, "Operador");
            }
            else
            {
                this.AdapTmpOCompra.Update(this.DS, Variables.gTermi + "TmpOCompra");
                this.DS.Tables[Variables.gTermi + "TmpOCompra"].AcceptChanges();
                bool flag = false;
                this.GroupBox1.Visible = false;
                this.cmbModificar.Enabled = false;
                this.cmbEliminar.Enabled = false;
                this.cmbGenOC.Enabled = false;
                this.cmbListado.Enabled = false;
                this.cmbListadoOCGen.Enabled = false;
                if (Interaction.MsgBox("Desea eliminar estos productos?", 4, "Operador") == 6)
                {
                    SqlConnection connection;
                    string str4;
                    try
                    {
                        str4 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                        connection = new SqlConnection(str4);
                        connection.Open();
                        flag = true;
                        int num2 = new SqlCommand("delete " + Variables.gTermi + "TmpOCompra where Seleccion=1", connection).ExecuteNonQuery();
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
                    string selectCommandText = "select * from " + Variables.gTermi + "TmpOCompra order by CodProv";
                    this.AdapTmpOCompra = new SqlDataAdapter(selectCommandText, str4);
                    this.CB = new SqlCommandBuilder(this.AdapTmpOCompra);
                    this.DS.Clear();
                    this.AdapTmpOCompra.Fill(this.DS, Variables.gTermi + "TmpOCompra");
                    this.TotReg = this.DS.Tables[Variables.gTermi + "TmpOCompra"].Rows.Count;
                    this.dgTmpOCompra.DataSource = this.DS.Tables[Variables.gTermi + "TmpOCompra"];
                    this.dgTmpOCompra.Refresh();
                    this.dgTmpOCompra.Refresh();
                }
                else
                {
                    int num3 = this.DS.Tables[Variables.gTermi + "TmpOCompra"].Rows.Count - 1;
                    for (num = 0; num <= num3; num++)
                    {
                        if (ObjectType.ObjTst(this.dgTmpOCompra[num, 0], true, false) == 0)
                        {
                            this.dgTmpOCompra[num, 0] = false;
                        }
                    }
                }
                this.GroupBox1.Visible = false;
                this.cmbModificar.Enabled = true;
                this.cmbEliminar.Enabled = true;
                this.cmbGenOC.Enabled = true;
                this.cmbListado.Enabled = true;
                this.cmbListadoOCGen.Enabled = true;
            }
        }

        private void cmbGenOC_Click(object sender, EventArgs e)
        {
            bool flag = false;
            int num2 = this.DS.Tables[Variables.gTermi + "TmpOCompra"].Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (ObjectType.ObjTst(this.dgTmpOCompra[i, 0], true, false) == 0)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Interaction.MsgBox("Debe seleccionar productos a generar o.compra", 0x10, "Operador");
            }
            else
            {
                this.GroupBox1.Visible = false;
                this.cmbModificar.Enabled = false;
                this.cmbEliminar.Enabled = false;
                this.cmbGenOC.Enabled = false;
                this.cmbListado.Enabled = false;
                this.cmbListadoOCGen.Enabled = false;
                this.AdapTmpOCompra.Update(this.DS, Variables.gTermi + "TmpOCompra");
                this.DS.Tables[Variables.gTermi + "TmpOCompra"].AcceptChanges();
                this.GenOC();
                string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
                string selectCommandText = "select * from " + Variables.gTermi + "TmpOCompra order by CodProv";
                this.AdapTmpOCompra = new SqlDataAdapter(selectCommandText, selectConnectionString);
                this.CB = new SqlCommandBuilder(this.AdapTmpOCompra);
                this.DS.Clear();
                this.AdapTmpOCompra.Fill(this.DS, Variables.gTermi + "TmpOCompra");
                this.TotReg = this.DS.Tables[Variables.gTermi + "TmpOCompra"].Rows.Count;
                this.dgTmpOCompra.DataSource = this.DS.Tables[Variables.gTermi + "TmpOCompra"];
                this.dgTmpOCompra.Refresh();
                this.GroupBox1.Visible = false;
                this.cmbModificar.Enabled = true;
                this.cmbEliminar.Enabled = true;
                this.cmbGenOC.Enabled = true;
                this.cmbListado.Enabled = true;
                this.cmbListadoOCGen.Enabled = true;
            }
        }

        private void cmbListado_Click(object sender, EventArgs e)
        {
            bool flag = false;
            int num2 = this.DS.Tables[Variables.gTermi + "TmpOCompra"].Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (ObjectType.ObjTst(this.dgTmpOCompra[i, 0], true, false) == 0)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Interaction.MsgBox("Debe seleccionar productos a listar", 0x10, "Operador");
            }
            else
            {
                this.AdapTmpOCompra.Update(this.DS, Variables.gTermi + "TmpOCompra");
                this.DS.Tables[Variables.gTermi + "TmpOCompra"].AcceptChanges();
                this.GroupBox1.Visible = false;
                this.cmbModificar.Enabled = false;
                this.cmbEliminar.Enabled = false;
                this.cmbGenOC.Enabled = false;
                this.cmbListado.Enabled = false;
                this.cmbListadoOCGen.Enabled = false;
                frmGenOC2 noc = new frmGenOC2();
                this.Hide();
                noc.Show();
                this.GroupBox1.Visible = false;
                this.cmbModificar.Enabled = true;
                this.cmbEliminar.Enabled = true;
                this.cmbGenOC.Enabled = true;
                this.cmbListado.Enabled = true;
                this.cmbListadoOCGen.Enabled = true;
            }
        }

        private void cmbListadoOCGen_Click(object sender, EventArgs e)
        {
            this.GroupBox1.Visible = false;
            this.cmbModificar.Enabled = false;
            this.cmbEliminar.Enabled = false;
            this.cmbGenOC.Enabled = false;
            this.cmbListado.Enabled = false;
            this.cmbListadoOCGen.Enabled = false;
            frmGenOC3 noc = new frmGenOC3();
            this.Hide();
            noc.Show();
            this.GroupBox1.Visible = false;
            this.cmbModificar.Enabled = true;
            this.cmbEliminar.Enabled = true;
            this.cmbGenOC.Enabled = true;
            this.cmbListado.Enabled = true;
            this.cmbListadoOCGen.Enabled = true;
        }

        private void cmbModificar_Click(object sender, EventArgs e)
        {
            bool flag = false;
            int num2 = this.DS.Tables[Variables.gTermi + "TmpOCompra"].Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (ObjectType.ObjTst(this.dgTmpOCompra[i, 0], true, false) == 0)
                {
                    flag = true;
                    this.editCodProv.Text = StringType.FromObject(this.dgTmpOCompra[i, 2]);
                    this.txtNomProv.Text = StringType.FromObject(this.dgTmpOCompra[i, 3]);
                    this.txtMetEnv01.Text = StringType.FromObject(this.dgTmpOCompra[i, 7]);
                    this.dtpFechaEntOC01.Value = DateType.FromObject(this.dgTmpOCompra[i, 9]);
                    this.txtMetEnv02.Text = StringType.FromObject(this.dgTmpOCompra[i, 10]);
                    this.dtpFechaEntOC02.Value = DateType.FromObject(this.dgTmpOCompra[i, 12]);
                    this.txtMetEnv03.Text = StringType.FromObject(this.dgTmpOCompra[i, 13]);
                    this.dtpFechaEntOC03.Value = DateType.FromObject(this.dgTmpOCompra[i, 15]);
                    this.GroupBox1.Visible = true;
                    this.cmbModificar.Enabled = false;
                    this.cmbEliminar.Enabled = false;
                    this.cmbGenOC.Enabled = false;
                    this.cmbListado.Enabled = false;
                    this.cmbListadoOCGen.Enabled = false;
                    this.editCodProv.Focus();
                    break;
                }
            }
            if (!flag)
            {
                Interaction.MsgBox("Debe seleccionar productos a modificar", 0x10, "Operador");
            }
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgTmpOCompra_ChangeUICues(object sender, UICuesEventArgs e)
        {
        }

        private void dgTmpOCompra_Click(object sender, EventArgs e)
        {
            int num2 = this.DS.Tables[Variables.gTermi + "TmpOCompra"].Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (this.dgTmpOCompra.IsSelected(i))
                {
                    if (ObjectType.ObjTst(this.dgTmpOCompra[i, 0], false, false) == 0)
                    {
                        this.dgTmpOCompra[i, 0] = true;
                    }
                    else
                    {
                        this.dgTmpOCompra[i, 0] = false;
                    }
                    this.dgTmpOCompra.UnSelect(i);
                }
            }
        }

        private void dgTmpOCompra_DoubleClick(object sender, EventArgs e)
        {
        }

        private void dgTmpOCompra_Navigate(object sender, NavigateEventArgs ne)
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

        private void editCodProv_LostFocus(object sender, EventArgs e)
        {
            bool flag = false;
            if (StringType.StrCmp(this.editCodProv.Text, Strings.Space(0), false) != 0)
            {
                SqlConnection connection;
                try
                {
                    connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
                    connection.Open();
                    flag = true;
                    SqlDataReader reader = new SqlCommand("SELECT PL01002 FROM PL010100 where PL01001='" + this.editCodProv.Text + "'", connection).ExecuteReader();
                    if (reader.Read())
                    {
                        this.txtNomProv.Text = StringType.FromObject(reader["PL01002"]);
                        reader.Close();
                    }
                    else
                    {
                        Interaction.MsgBox("Proveedor inexistente", 0x40, "Operador");
                        this.txtNomProv.Text = "";
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

        private void editCodProv_TextChanged(object sender, EventArgs e)
        {
        }

        ~frmGenOC1()
        {
        }

        private void frmGenOC1_Closed(object sender, EventArgs e)
        {
            new frmMenuOCompra().Show();
        }

        private void frmGenOC1_Load(object sender, EventArgs e)
        {
            this.txtAlmacen.Text = Variables.gAlmacen1;
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            string selectCommandText = "select * from " + Variables.gTermi + "TmpOCompra order by CodProv";
            this.AdapTmpOCompra = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.CB = new SqlCommandBuilder(this.AdapTmpOCompra);
            this.AdapTmpOCompra.Fill(this.DS, Variables.gTermi + "TmpOCompra");
            this.TotReg = this.DS.Tables[Variables.gTermi + "TmpOCompra"].Rows.Count;
            this.dgTmpOCompra.DataSource = this.DS.Tables[Variables.gTermi + "TmpOCompra"];
            DataGridTableStyle table = new DataGridTableStyle();
            table.MappingName = Variables.gTermi + "TmpOCompra";
            DataGridTextBoxColumn column = new DataGridTextBoxColumn();
            DataGridBoolColumn column2 = new DataGridBoolColumn();
            DataGridBoolColumn column29 = column2;
            column29.HeaderText = "Sel.";
            column29.MappingName = "Seleccion";
            column29.Width = 0x23;
            column29 = null;
            table.GridColumnStyles.Add(column2);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column28 = column;
            column28.HeaderText = "C\x00f3digo";
            column28.MappingName = "Codigo";
            column28.ReadOnly = true;
            column28.Width = 60;
            column28 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column27 = column;
            column27.HeaderText = "Cod.Prov.";
            column27.MappingName = "CodProv";
            column27.ReadOnly = true;
            column27.Width = 60;
            column27 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column26 = column;
            column26.HeaderText = "Proveedor";
            column26.MappingName = "NomProv";
            column26.ReadOnly = true;
            column26.Width = 150;
            column26 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column25 = column;
            column25.HeaderText = "Producto";
            column25.MappingName = "Descripcion";
            column25.ReadOnly = true;
            column25.Width = 150;
            column25 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column24 = column;
            column24.HeaderText = "P.Cpra.";
            column24.MappingName = "PropCpra";
            column24.Width = 50;
            column24.ReadOnly = true;
            column24.Format = "######0";
            column24 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column23 = column;
            column23.HeaderText = "P.Cpra.PV";
            column23.MappingName = "PropCpraPV";
            column23.Width = 60;
            column23.ReadOnly = true;
            column23.Format = "######0";
            column23 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column22 = column;
            column22.HeaderText = "Met.Envio";
            column22.MappingName = "DescMetEnv01";
            column22.ReadOnly = true;
            column22.Width = 90;
            column22 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column21 = column;
            column21.HeaderText = "P.Cpra.";
            column21.MappingName = "CantMetEnv01";
            column21.Width = 50;
            column21.ReadOnly = false;
            column21.Format = "######0";
            column21 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column20 = column;
            column20.HeaderText = "F.Ent OC";
            column20.MappingName = "FecEntOC01";
            column20.ReadOnly = true;
            column20.Format = "dd/MM/yyyy";
            column20.Width = 70;
            column20 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column19 = column;
            column19.HeaderText = "Met.Envio";
            column19.MappingName = "DescMetEnv02";
            column19.ReadOnly = true;
            column19.Width = 90;
            column19 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column18 = column;
            column18.HeaderText = "P.Cpra.";
            column18.MappingName = "CantMetEnv02";
            column18.Width = 50;
            column18.ReadOnly = false;
            column18.Format = "######0";
            column18 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column17 = column;
            column17.HeaderText = "F.Ent OC";
            column17.MappingName = "FecEntOC02";
            column17.ReadOnly = true;
            column17.Format = "dd/MM/yyyy";
            column17.Width = 70;
            column17 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column16 = column;
            column16.HeaderText = "Met.Envio";
            column16.MappingName = "DescMetEnv03";
            column16.ReadOnly = true;
            column16.Width = 90;
            column16 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column15 = column;
            column15.HeaderText = "P.Cpra.";
            column15.MappingName = "CantMetEnv03";
            column15.Width = 50;
            column15.ReadOnly = false;
            column15.Format = "######0";
            column15 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column14 = column;
            column14.HeaderText = "F.Ent OC";
            column14.MappingName = "FecEntOC03";
            column14.ReadOnly = true;
            column14.Format = "dd/MM/yyyy";
            column14.Width = 70;
            column14 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column13 = column;
            column13.HeaderText = "Prom.Vtas.";
            column13.MappingName = "PromVtas";
            column13.ReadOnly = true;
            column13.Width = 60;
            column13.Format = "######0";
            column13 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column12 = column;
            column12.HeaderText = "N.Repos.";
            column12.MappingName = "NivelRepos";
            column12.ReadOnly = true;
            column12.Width = 60;
            column12.Format = "######0";
            column12 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column11 = column;
            column11.HeaderText = "N.Repos.PV";
            column11.MappingName = "NivelReposPV";
            column11.ReadOnly = true;
            column11.Width = 70;
            column11.Format = "######0";
            column11 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column10 = column;
            column10.HeaderText = "Stock";
            column10.MappingName = "StockAl";
            column10.ReadOnly = true;
            column10.Width = 50;
            column10.Format = "######0";
            column10 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column9 = column;
            column9.HeaderText = "OV";
            column9.MappingName = "OV";
            column9.ReadOnly = true;
            column9.Width = 50;
            column9.Format = "######0";
            column9 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column8 = column;
            column8.HeaderText = "OC Pend.";
            column8.MappingName = "OCPend";
            column8.ReadOnly = true;
            column8.Width = 60;
            column8.Format = "######0";
            column8 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column7 = column;
            column7.HeaderText = "OV Res.";
            column7.MappingName = "OVRes";
            column7.ReadOnly = true;
            column7.Width = 50;
            column7.Format = "######0";
            column7 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column6 = column;
            column6.HeaderText = "LOC";
            column6.MappingName = "LoteOptCpra";
            column6.ReadOnly = true;
            column6.Width = 50;
            column6.Format = "######0";
            column6 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column5 = column;
            column5.HeaderText = "CMP";
            column5.MappingName = "CantMinPed";
            column5.ReadOnly = true;
            column5.Width = 50;
            column5.Format = "######0";
            column5 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column4 = column;
            column4.HeaderText = "C\x00f3d.Reemp.";
            column4.MappingName = "CodReemplazo";
            column4.ReadOnly = true;
            column4.Width = 60;
            column4 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column3 = column;
            column3.HeaderText = "Fec.Reemp.";
            column3.MappingName = "FecReemp";
            column3.ReadOnly = true;
            column3.Width = 70;
            column3.Format = "dd/MM/yyyy";
            column3.NullText = "";
            column3 = null;
            table.GridColumnStyles.Add(column);
            this.dgTmpOCompra.TableStyles.Add(table);
            this.dgTmpOCompra.Refresh();
        }

        private void GenOC()
        {
            SqlConnection connection;
            SqlConnection connection2;
            bool flag2 = false;
            bool flag = false;
            try
            {
                StreamWriter writer;
                DataRow row;
                int num;
                string str;
                int num2;
                long num3;
                long num4;
                string str4;
                int num5;
                connection2 = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096");
                connection2.Open();
                flag2 = true;
                connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
                connection.Open();
                string cmdText = "select * from PC010100 (TABLOCKX)";
                SqlCommand command = new SqlCommand(cmdText, connection);
                command.CommandTimeout = 120;
                command.ExecuteNonQuery();
                cmdText = "SELECT PC01001 from PC010100 where CONVERT(numeric, PC01001) < 300000 order by PC01001 desc";
                command = new SqlCommand(cmdText, connection);
                command.CommandTimeout = 120;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    num4 = (long) Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(reader["PC01001"])));
                }
                else
                {
                    num4 = 0L;
                }
                reader.Close();
                command = new SqlCommand("SELECT * from " + Variables.gTermi + "TmpOCompra where Seleccion=1 and CantMetEnv01<>0 order by CodProv", connection2);
                command.CommandTimeout = 500;
                this.DS1.Clear();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(this.DS1, Variables.gTermi + "TmpOCompra");
                string str2 = "";
                int num8 = this.DS1.Tables[Variables.gTermi + "TmpOCompra"].Rows.Count - 1;
                for (num = 0; num <= num8; num++)
                {
                    row = this.DS1.Tables[Variables.gTermi + "TmpOCompra"].Rows[num];
                    if (ObjectType.ObjTst(str2, row["CodProv"], false) != 0)
                    {
                        str2 = StringType.FromObject(row["CodProv"]);
                        command = new SqlCommand("Select PL14002 from PL140100 where PL14001='" + str2 + "'", connection);
                        reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            str4 = StringType.FromObject(reader["PL14002"]);
                        }
                        else
                        {
                            str4 = "";
                        }
                        reader.Close();
                        num3 = 5L;
                        num4 += 1L;
                        num2 = 0;
                        command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(("insert into " + Variables.gTermi + "TmpOCGen (NroOC,CodProv,NomProv,FecEntOC) values ('" + Strings.Format(num4, "0000000000")) + "','", row["CodProv"]), "','"), row["NomProv"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FecEntOC01"]), "MM/dd/yyyy")), "')")), connection2);
                        num5 = command.ExecuteNonQuery();
                    }
                    else
                    {
                        num3 += 5L;
                        if (num2 == 20)
                        {
                            num3 = 5L;
                            num4 += 1L;
                            num2 = 0;
                            num5 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(("insert into " + Variables.gTermi + "TmpOCGen (NroOC,CodProv,NomProv,FecEntOC) values ('" + Strings.Format(num4, "0000000000")) + "','", row["CodProv"]), "','"), row["NomProv"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FecEntOC01"]), "MM/dd/yyyy")), "')")), connection2).ExecuteNonQuery();
                        }
                    }
                    str = (((((StringType.FromObject(ObjectType.StrCatObj(StringType.FromObject(ObjectType.StrCatObj(StringType.FromObject(ObjectType.StrCatObj(Strings.Format(num4, "0000000000") + "1" + Strings.Format(num3, "000000"), ObjectType.AddObj(row["Codigo"], Strings.Space(0x23 - Strings.Len(RuntimeHelpers.GetObjectValue(row["Codigo"])))))) + Strings.Format(RuntimeHelpers.GetObjectValue(row["CantMetEnv01"]), "00000000000.00000000"), ObjectType.AddObj(row["CodProv"], Strings.Space(10 - Strings.Len(RuntimeHelpers.GetObjectValue(row["CodProv"])))))) + Strings.Format(DateAndTime.get_Now(), "ddMMyyyy") + Strings.Format(RuntimeHelpers.GetObjectValue(row["FecEntOC01"]), "ddMMyyyy"), row["CodMetEnv01"])) + Strings.Mid(Variables.gAlmacen1, 1, 2) + Strings.Space(6 - Strings.Len(Strings.Mid(Variables.gAlmacen1, 1, 2)))) + str4 + Strings.Space(2 - Strings.Len(str4))) + Strings.Space(0x23) + Strings.Space(0x23)) + Strings.Space(0x23) + Strings.Space(0x23)) + Strings.Space(0x23) + Strings.Space(10)) + Strings.Space(12) + "\r" + "\n";
                    writer = new StreamWriter(Variables.gPathTxt + @"\genocompra.prn", true);
                    writer.Write(str);
                    writer.Close();
                    num2++;
                }
                command = new SqlCommand("SELECT * from " + Variables.gTermi + "TmpOCompra where Seleccion=1 and CantMetEnv02<>0 order by CodProv", connection2);
                command.CommandTimeout = 500;
                this.DS1.Clear();
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(this.DS1, Variables.gTermi + "TmpOCompra");
                str2 = "";
                int num7 = this.DS1.Tables[Variables.gTermi + "TmpOCompra"].Rows.Count - 1;
                for (num = 0; num <= num7; num++)
                {
                    row = this.DS1.Tables[Variables.gTermi + "TmpOCompra"].Rows[num];
                    if (ObjectType.ObjTst(str2, row["CodProv"], false) != 0)
                    {
                        str2 = StringType.FromObject(row["CodProv"]);
                        command = new SqlCommand("Select PL14002 from PL140100 where PL14001='" + str2 + "'", connection);
                        reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            str4 = StringType.FromObject(reader["PL14002"]);
                        }
                        else
                        {
                            str4 = "";
                        }
                        reader.Close();
                        num3 = 5L;
                        num4 += 1L;
                        num2 = 0;
                        command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(("insert into " + Variables.gTermi + "TmpOCGen (NroOC,CodProv,NomProv,FecEntOC) values ('" + Strings.Format(num4, "0000000000")) + "','", row["CodProv"]), "','"), row["NomProv"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FecEntOC02"]), "MM/dd/yyyy")), "')")), connection2);
                        num5 = command.ExecuteNonQuery();
                    }
                    else
                    {
                        num3 += 5L;
                        if (num2 == 20)
                        {
                            num3 = 5L;
                            num4 += 1L;
                            num2 = 0;
                            num5 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(("insert into " + Variables.gTermi + "TmpOCGen (NroOC,CodProv,NomProv,FecEntOC) values ('" + Strings.Format(num4, "0000000000")) + "','", row["CodProv"]), "','"), row["NomProv"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FecEntOC02"]), "MM/dd/yyyy")), "')")), connection2).ExecuteNonQuery();
                        }
                    }
                    str = (((((StringType.FromObject(ObjectType.StrCatObj(StringType.FromObject(ObjectType.StrCatObj(StringType.FromObject(ObjectType.StrCatObj(Strings.Format(num4, "0000000000") + "1" + Strings.Format(num3, "000000"), ObjectType.AddObj(row["Codigo"], Strings.Space(0x23 - Strings.Len(RuntimeHelpers.GetObjectValue(row["Codigo"])))))) + Strings.Format(RuntimeHelpers.GetObjectValue(row["CantMetEnv02"]), "00000000000.00000000"), ObjectType.AddObj(row["CodProv"], Strings.Space(10 - Strings.Len(RuntimeHelpers.GetObjectValue(row["CodProv"])))))) + Strings.Format(DateAndTime.get_Now(), "ddMMyyyy") + Strings.Format(RuntimeHelpers.GetObjectValue(row["FecEntOC02"]), "ddMMyyyy"), row["CodMetEnv02"])) + Strings.Mid(Variables.gAlmacen1, 1, 2) + Strings.Space(6 - Strings.Len(Strings.Mid(Variables.gAlmacen1, 1, 2)))) + str4 + Strings.Space(2 - Strings.Len(str4))) + Strings.Space(0x23) + Strings.Space(0x23)) + Strings.Space(0x23) + Strings.Space(0x23)) + Strings.Space(0x23) + Strings.Space(10)) + Strings.Space(12) + "\r" + "\n";
                    writer = new StreamWriter(Variables.gPathTxt + @"\genocompra.prn", true);
                    writer.Write(str);
                    writer.Close();
                    num2++;
                }
                command = new SqlCommand("SELECT * from " + Variables.gTermi + "TmpOCompra where Seleccion=1 and CantMetEnv03<>0 order by CodProv", connection2);
                command.CommandTimeout = 500;
                this.DS1.Clear();
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(this.DS1, Variables.gTermi + "TmpOCompra");
                str2 = "";
                int num6 = this.DS1.Tables[Variables.gTermi + "TmpOCompra"].Rows.Count - 1;
                for (num = 0; num <= num6; num++)
                {
                    row = this.DS1.Tables[Variables.gTermi + "TmpOCompra"].Rows[num];
                    if (ObjectType.ObjTst(str2, row["CodProv"], false) != 0)
                    {
                        str2 = StringType.FromObject(row["CodProv"]);
                        command = new SqlCommand("Select PL14002 from PL140100 where PL14001='" + str2 + "'", connection);
                        reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            str4 = StringType.FromObject(reader["PL14002"]);
                        }
                        else
                        {
                            str4 = "";
                        }
                        reader.Close();
                        num3 = 5L;
                        num4 += 1L;
                        num2 = 0;
                        command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(("insert into " + Variables.gTermi + "TmpOCGen (NroOC,CodProv,NomProv,FecEntOC) values ('" + Strings.Format(num4, "0000000000")) + "','", row["CodProv"]), "','"), row["NomProv"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FecEntOC03"]), "MM/dd/yyyy")), "')")), connection2);
                        num5 = command.ExecuteNonQuery();
                    }
                    else
                    {
                        num3 += 5L;
                        if (num2 == 20)
                        {
                            num3 = 5L;
                            num4 += 1L;
                            num2 = 0;
                            num5 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(("insert into " + Variables.gTermi + "TmpOCGen (NroOC,CodProv,NomProv,FecEntOC) values ('" + Strings.Format(num4, "0000000000")) + "','", row["CodProv"]), "','"), row["NomProv"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FecEntOC03"]), "MM/dd/yyyy")), "')")), connection2).ExecuteNonQuery();
                        }
                    }
                    str = (((((StringType.FromObject(ObjectType.StrCatObj(StringType.FromObject(ObjectType.StrCatObj(StringType.FromObject(ObjectType.StrCatObj(Strings.Format(num4, "0000000000") + "1" + Strings.Format(num3, "000000"), ObjectType.AddObj(row["Codigo"], Strings.Space(0x23 - Strings.Len(RuntimeHelpers.GetObjectValue(row["Codigo"])))))) + Strings.Format(RuntimeHelpers.GetObjectValue(row["CantMetEnv03"]), "00000000000.00000000"), ObjectType.AddObj(row["CodProv"], Strings.Space(10 - Strings.Len(RuntimeHelpers.GetObjectValue(row["CodProv"])))))) + Strings.Format(DateAndTime.get_Now(), "ddMMyyyy") + Strings.Format(RuntimeHelpers.GetObjectValue(row["FecEntOC03"]), "ddMMyyyy"), row["CodMetEnv03"])) + Strings.Mid(Variables.gAlmacen1, 1, 2) + Strings.Space(6 - Strings.Len(Strings.Mid(Variables.gAlmacen1, 1, 2)))) + str4 + Strings.Space(2 - Strings.Len(str4))) + Strings.Space(0x23) + Strings.Space(0x23)) + Strings.Space(0x23) + Strings.Space(0x23)) + Strings.Space(0x23) + Strings.Space(10)) + Strings.Space(12) + "\r" + "\n";
                    writer = new StreamWriter(Variables.gPathTxt + @"\genocompra.prn", true);
                    writer.Write(str);
                    writer.Close();
                    num2++;
                }
                new SqlCommand("delete " + Variables.gTermi + "TmpOCompra where Seleccion=1", connection2).ExecuteNonQuery();
                connection2.Close();
                flag2 = false;
                connection.Close();
                flag = false;
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

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmGenOC1));
            this.cmbListado = new Button();
            this.cmbSalir = new Button();
            this.dgTmpOCompra = new DataGrid();
            this.GroupBox1 = new GroupBox();
            this.dtpFechaEntOC03 = new DateTimePicker();
            this.Label3 = new Label();
            this.Label5 = new Label();
            this.txtMetEnv03 = new TextBox();
            this.dtpFechaEntOC02 = new DateTimePicker();
            this.Label1 = new Label();
            this.Label2 = new Label();
            this.txtMetEnv02 = new TextBox();
            this.dtpFechaEntOC01 = new DateTimePicker();
            this.btnCancelar = new Button();
            this.btnModificar = new Button();
            this.Label7 = new Label();
            this.Label6 = new Label();
            this.txtMetEnv01 = new TextBox();
            this.txtNomProv = new TextBox();
            this.Label4 = new Label();
            this.editCodProv = new TextBox();
            this.cmbModificar = new Button();
            this.txtAlmacen = new TextBox();
            this.Label8 = new Label();
            this.cmbGenOC = new Button();
            this.chkSelTodo = new CheckBox();
            this.chkDeselTodo = new CheckBox();
            this.cmbListadoOCGen = new Button();
            this.cmbEliminar = new Button();
            this.dgTmpOCompra.BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            Point point = new Point(0x200, 0x220);
            this.cmbListado.Location = point;
            this.cmbListado.Name = "cmbListado";
            Size size = new Size(0x60, 40);
            this.cmbListado.Size = size;
            this.cmbListado.TabIndex = 7;
            this.cmbListado.Text = "&Listado";
            point = new Point(0x338, 0x220);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 11;
            this.cmbSalir.Text = "&Salir";
            this.dgTmpOCompra.CaptionFont = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dgTmpOCompra.CaptionText = "Propuestas de Compra";
            this.dgTmpOCompra.DataMember = "";
            this.dgTmpOCompra.HeaderForeColor = SystemColors.ControlText;
            point = new Point(8, 40);
            this.dgTmpOCompra.Location = point;
            this.dgTmpOCompra.Name = "dgTmpOCompra";
            size = new Size(0x3f8, 0x1f0);
            this.dgTmpOCompra.Size = size;
            this.dgTmpOCompra.TabIndex = 2;
            this.GroupBox1.Controls.Add(this.dtpFechaEntOC03);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.txtMetEnv03);
            this.GroupBox1.Controls.Add(this.dtpFechaEntOC02);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.txtMetEnv02);
            this.GroupBox1.Controls.Add(this.dtpFechaEntOC01);
            this.GroupBox1.Controls.Add(this.btnCancelar);
            this.GroupBox1.Controls.Add(this.btnModificar);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.txtMetEnv01);
            this.GroupBox1.Controls.Add(this.txtNomProv);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.editCodProv);
            point = new Point(8, 0x250);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(0x2c0, 0x80);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 10;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Visible = false;
            this.dtpFechaEntOC03.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaEntOC03.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaEntOC03.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaEntOC03.Format = DateTimePickerFormat.Custom;
            point = new Point(0x1a0, 0x60);
            this.dtpFechaEntOC03.Location = point;
            this.dtpFechaEntOC03.Name = "dtpFechaEntOC03";
            size = new Size(0x60, 20);
            this.dtpFechaEntOC03.Size = size;
            this.dtpFechaEntOC03.TabIndex = 14;
            DateTime time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpFechaEntOC03.Value = time;
            point = new Point(320, 0x60);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x58, 0x10);
            this.Label3.Size = size;
            this.Label3.TabIndex = 13;
            this.Label3.Text = "Fecha Ent. OC:";
            point = new Point(8, 0x60);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size(80, 0x10);
            this.Label5.Size = size;
            this.Label5.TabIndex = 11;
            this.Label5.Text = "M\x00e9todo Envio:";
            this.txtMetEnv03.BackColor = SystemColors.Window;
            this.txtMetEnv03.Enabled = false;
            point = new Point(0x60, 0x60);
            this.txtMetEnv03.Location = point;
            this.txtMetEnv03.MaxLength = 30;
            this.txtMetEnv03.Name = "txtMetEnv03";
            size = new Size(0xd0, 20);
            this.txtMetEnv03.Size = size;
            this.txtMetEnv03.TabIndex = 12;
            this.txtMetEnv03.Text = "";
            this.dtpFechaEntOC02.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaEntOC02.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaEntOC02.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaEntOC02.Format = DateTimePickerFormat.Custom;
            point = new Point(0x1a0, 0x48);
            this.dtpFechaEntOC02.Location = point;
            this.dtpFechaEntOC02.Name = "dtpFechaEntOC02";
            size = new Size(0x60, 20);
            this.dtpFechaEntOC02.Size = size;
            this.dtpFechaEntOC02.TabIndex = 10;
            time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpFechaEntOC02.Value = time;
            point = new Point(320, 0x48);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x58, 0x10);
            this.Label1.Size = size;
            this.Label1.TabIndex = 9;
            this.Label1.Text = "Fecha Ent. OC:";
            point = new Point(8, 0x48);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(80, 0x10);
            this.Label2.Size = size;
            this.Label2.TabIndex = 7;
            this.Label2.Text = "M\x00e9todo Envio:";
            this.txtMetEnv02.BackColor = SystemColors.Window;
            this.txtMetEnv02.Enabled = false;
            point = new Point(0x60, 0x48);
            this.txtMetEnv02.Location = point;
            this.txtMetEnv02.MaxLength = 30;
            this.txtMetEnv02.Name = "txtMetEnv02";
            size = new Size(0xd0, 20);
            this.txtMetEnv02.Size = size;
            this.txtMetEnv02.TabIndex = 8;
            this.txtMetEnv02.Text = "";
            this.dtpFechaEntOC01.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaEntOC01.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaEntOC01.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaEntOC01.Format = DateTimePickerFormat.Custom;
            point = new Point(0x1a0, 0x30);
            this.dtpFechaEntOC01.Location = point;
            this.dtpFechaEntOC01.Name = "dtpFechaEntOC01";
            size = new Size(0x60, 20);
            this.dtpFechaEntOC01.Size = size;
            this.dtpFechaEntOC01.TabIndex = 6;
            time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpFechaEntOC01.Value = time;
            point = new Point(0x248, 0x38);
            this.btnCancelar.Location = point;
            this.btnCancelar.Name = "btnCancelar";
            size = new Size(0x60, 0x18);
            this.btnCancelar.Size = size;
            this.btnCancelar.TabIndex = 0x10;
            this.btnCancelar.Text = "&Cancelar";
            point = new Point(0x248, 0x58);
            this.btnModificar.Location = point;
            this.btnModificar.Name = "btnModificar";
            size = new Size(0x60, 0x18);
            this.btnModificar.Size = size;
            this.btnModificar.TabIndex = 15;
            this.btnModificar.Text = "&Modificar";
            point = new Point(320, 0x30);
            this.Label7.Location = point;
            this.Label7.Name = "Label7";
            size = new Size(0x58, 0x10);
            this.Label7.Size = size;
            this.Label7.TabIndex = 5;
            this.Label7.Text = "Fecha Ent. OC:";
            point = new Point(8, 0x30);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(80, 0x10);
            this.Label6.Size = size;
            this.Label6.TabIndex = 3;
            this.Label6.Text = "M\x00e9todo Envio:";
            this.txtMetEnv01.BackColor = SystemColors.Window;
            this.txtMetEnv01.Enabled = false;
            point = new Point(0x60, 0x30);
            this.txtMetEnv01.Location = point;
            this.txtMetEnv01.MaxLength = 30;
            this.txtMetEnv01.Name = "txtMetEnv01";
            size = new Size(0xd0, 20);
            this.txtMetEnv01.Size = size;
            this.txtMetEnv01.TabIndex = 4;
            this.txtMetEnv01.Text = "";
            this.txtNomProv.BackColor = SystemColors.Window;
            this.txtNomProv.Enabled = false;
            point = new Point(0xb8, 0x18);
            this.txtNomProv.Location = point;
            this.txtNomProv.MaxLength = 0x23;
            this.txtNomProv.Name = "txtNomProv";
            size = new Size(0x1f0, 20);
            this.txtNomProv.Size = size;
            this.txtNomProv.TabIndex = 2;
            this.txtNomProv.Text = "";
            point = new Point(8, 0x18);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(0x48, 0x10);
            this.Label4.Size = size;
            this.Label4.TabIndex = 0;
            this.Label4.Text = "Proveedor:";
            this.editCodProv.BackColor = SystemColors.Window;
            point = new Point(0x60, 0x18);
            this.editCodProv.Location = point;
            this.editCodProv.MaxLength = 10;
            this.editCodProv.Name = "editCodProv";
            size = new Size(80, 20);
            this.editCodProv.Size = size;
            this.editCodProv.TabIndex = 1;
            this.editCodProv.Text = "";
            point = new Point(0x130, 0x220);
            this.cmbModificar.Location = point;
            this.cmbModificar.Name = "cmbModificar";
            size = new Size(0x60, 40);
            this.cmbModificar.Size = size;
            this.cmbModificar.TabIndex = 5;
            this.cmbModificar.Text = "&Modificar";
            this.txtAlmacen.BackColor = SystemColors.Window;
            this.txtAlmacen.Enabled = false;
            this.txtAlmacen.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x68, 8);
            this.txtAlmacen.Location = point;
            this.txtAlmacen.MaxLength = 0x2d;
            this.txtAlmacen.Name = "txtAlmacen";
            size = new Size(0x220, 0x16);
            this.txtAlmacen.Size = size;
            this.txtAlmacen.TabIndex = 1;
            this.txtAlmacen.Text = "";
            this.Label8.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 8);
            this.Label8.Location = point;
            this.Label8.Name = "Label8";
            size = new Size(80, 0x10);
            this.Label8.Size = size;
            this.Label8.TabIndex = 0;
            this.Label8.Text = "Almacen:";
            point = new Point(0x268, 0x220);
            this.cmbGenOC.Location = point;
            this.cmbGenOC.Name = "cmbGenOC";
            size = new Size(0x60, 40);
            this.cmbGenOC.Size = size;
            this.cmbGenOC.TabIndex = 8;
            this.cmbGenOC.Text = "&Generar O.Compra";
            point = new Point(8, 0x228);
            this.chkSelTodo.Location = point;
            this.chkSelTodo.Name = "chkSelTodo";
            size = new Size(0x70, 0x18);
            this.chkSelTodo.Size = size;
            this.chkSelTodo.TabIndex = 3;
            this.chkSelTodo.Text = "Seleccionar todo";
            point = new Point(0x80, 0x228);
            this.chkDeselTodo.Location = point;
            this.chkDeselTodo.Name = "chkDeselTodo";
            size = new Size(0x80, 0x18);
            this.chkDeselTodo.Size = size;
            this.chkDeselTodo.TabIndex = 4;
            this.chkDeselTodo.Text = "Deseleccionar todo";
            point = new Point(720, 0x220);
            this.cmbListadoOCGen.Location = point;
            this.cmbListadoOCGen.Name = "cmbListadoOCGen";
            size = new Size(0x60, 40);
            this.cmbListadoOCGen.Size = size;
            this.cmbListadoOCGen.TabIndex = 9;
            this.cmbListadoOCGen.Text = "Listado &OC Generadas";
            point = new Point(0x198, 0x220);
            this.cmbEliminar.Location = point;
            this.cmbEliminar.Name = "cmbEliminar";
            size = new Size(0x60, 40);
            this.cmbEliminar.Size = size;
            this.cmbEliminar.TabIndex = 6;
            this.cmbEliminar.Text = "&Eliminar";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            size = new Size(0x3f8, 710);
            this.ClientSize = size;
            this.Controls.Add(this.cmbEliminar);
            this.Controls.Add(this.cmbListadoOCGen);
            this.Controls.Add(this.chkDeselTodo);
            this.Controls.Add(this.chkSelTodo);
            this.Controls.Add(this.cmbGenOC);
            this.Controls.Add(this.txtAlmacen);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.cmbModificar);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.dgTmpOCompra);
            this.Controls.Add(this.cmbSalir);
            this.Controls.Add(this.cmbListado);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmGenOC1";
            this.Text = "Generaci\x00f3n Ordenes de Compra";
            this.WindowState = FormWindowState.Maximized;
            this.dgTmpOCompra.EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
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

        internal virtual CheckBox chkDeselTodo
        {
            get
            {
                return this._chkDeselTodo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._chkDeselTodo != null)
                {
                    this._chkDeselTodo.CheckedChanged -= new EventHandler(this.chkDeselTodo_CheckedChanged);
                }
                this._chkDeselTodo = value;
                if (this._chkDeselTodo != null)
                {
                    this._chkDeselTodo.CheckedChanged += new EventHandler(this.chkDeselTodo_CheckedChanged);
                }
            }
        }

        internal virtual CheckBox chkSelTodo
        {
            get
            {
                return this._chkSelTodo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._chkSelTodo != null)
                {
                    this._chkSelTodo.CheckedChanged -= new EventHandler(this.chkSelTodo_CheckedChanged);
                }
                this._chkSelTodo = value;
                if (this._chkSelTodo != null)
                {
                    this._chkSelTodo.CheckedChanged += new EventHandler(this.chkSelTodo_CheckedChanged);
                }
            }
        }

        internal virtual Button cmbEliminar
        {
            get
            {
                return this._cmbEliminar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbEliminar != null)
                {
                    this._cmbEliminar.Click -= new EventHandler(this.cmbEliminar_Click);
                }
                this._cmbEliminar = value;
                if (this._cmbEliminar != null)
                {
                    this._cmbEliminar.Click += new EventHandler(this.cmbEliminar_Click);
                }
            }
        }

        internal virtual Button cmbGenOC
        {
            get
            {
                return this._cmbGenOC;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbGenOC != null)
                {
                    this._cmbGenOC.Click -= new EventHandler(this.cmbGenOC_Click);
                }
                this._cmbGenOC = value;
                if (this._cmbGenOC != null)
                {
                    this._cmbGenOC.Click += new EventHandler(this.cmbGenOC_Click);
                }
            }
        }

        internal virtual Button cmbListado
        {
            get
            {
                return this._cmbListado;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbListado != null)
                {
                    this._cmbListado.Click -= new EventHandler(this.cmbListado_Click);
                }
                this._cmbListado = value;
                if (this._cmbListado != null)
                {
                    this._cmbListado.Click += new EventHandler(this.cmbListado_Click);
                }
            }
        }

        internal virtual Button cmbListadoOCGen
        {
            get
            {
                return this._cmbListadoOCGen;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbListadoOCGen != null)
                {
                    this._cmbListadoOCGen.Click -= new EventHandler(this.cmbListadoOCGen_Click);
                }
                this._cmbListadoOCGen = value;
                if (this._cmbListadoOCGen != null)
                {
                    this._cmbListadoOCGen.Click += new EventHandler(this.cmbListadoOCGen_Click);
                }
            }
        }

        internal virtual Button cmbModificar
        {
            get
            {
                return this._cmbModificar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbModificar != null)
                {
                    this._cmbModificar.Click -= new EventHandler(this.cmbModificar_Click);
                }
                this._cmbModificar = value;
                if (this._cmbModificar != null)
                {
                    this._cmbModificar.Click += new EventHandler(this.cmbModificar_Click);
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

        internal virtual DataGrid dgTmpOCompra
        {
            get
            {
                return this._dgTmpOCompra;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dgTmpOCompra != null)
                {
                    this._dgTmpOCompra.ChangeUICues -= new UICuesEventHandler(this.dgTmpOCompra_ChangeUICues);
                    this._dgTmpOCompra.Navigate -= new NavigateEventHandler(this.dgTmpOCompra_Navigate);
                    this._dgTmpOCompra.Click -= new EventHandler(this.dgTmpOCompra_Click);
                    this._dgTmpOCompra.DoubleClick -= new EventHandler(this.dgTmpOCompra_DoubleClick);
                }
                this._dgTmpOCompra = value;
                if (this._dgTmpOCompra != null)
                {
                    this._dgTmpOCompra.ChangeUICues += new UICuesEventHandler(this.dgTmpOCompra_ChangeUICues);
                    this._dgTmpOCompra.Navigate += new NavigateEventHandler(this.dgTmpOCompra_Navigate);
                    this._dgTmpOCompra.Click += new EventHandler(this.dgTmpOCompra_Click);
                    this._dgTmpOCompra.DoubleClick += new EventHandler(this.dgTmpOCompra_DoubleClick);
                }
            }
        }

        internal virtual DateTimePicker dtpFechaEntOC01
        {
            get
            {
                return this._dtpFechaEntOC01;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpFechaEntOC01 != null)
                {
                }
                this._dtpFechaEntOC01 = value;
                if (this._dtpFechaEntOC01 != null)
                {
                }
            }
        }

        internal virtual DateTimePicker dtpFechaEntOC02
        {
            get
            {
                return this._dtpFechaEntOC02;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpFechaEntOC02 != null)
                {
                }
                this._dtpFechaEntOC02 = value;
                if (this._dtpFechaEntOC02 != null)
                {
                }
            }
        }

        internal virtual DateTimePicker dtpFechaEntOC03
        {
            get
            {
                return this._dtpFechaEntOC03;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpFechaEntOC03 != null)
                {
                }
                this._dtpFechaEntOC03 = value;
                if (this._dtpFechaEntOC03 != null)
                {
                }
            }
        }

        internal virtual TextBox editCodProv
        {
            get
            {
                return this._editCodProv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editCodProv != null)
                {
                    this._editCodProv.LostFocus -= new EventHandler(this.editCodProv_LostFocus);
                    this._editCodProv.TextChanged -= new EventHandler(this.editCodProv_TextChanged);
                }
                this._editCodProv = value;
                if (this._editCodProv != null)
                {
                    this._editCodProv.LostFocus += new EventHandler(this.editCodProv_LostFocus);
                    this._editCodProv.TextChanged += new EventHandler(this.editCodProv_TextChanged);
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

        internal virtual TextBox txtAlmacen
        {
            get
            {
                return this._txtAlmacen;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtAlmacen != null)
                {
                }
                this._txtAlmacen = value;
                if (this._txtAlmacen != null)
                {
                }
            }
        }

        internal virtual TextBox txtMetEnv01
        {
            get
            {
                return this._txtMetEnv01;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtMetEnv01 != null)
                {
                }
                this._txtMetEnv01 = value;
                if (this._txtMetEnv01 != null)
                {
                }
            }
        }

        internal virtual TextBox txtMetEnv02
        {
            get
            {
                return this._txtMetEnv02;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtMetEnv02 != null)
                {
                }
                this._txtMetEnv02 = value;
                if (this._txtMetEnv02 != null)
                {
                }
            }
        }

        internal virtual TextBox txtMetEnv03
        {
            get
            {
                return this._txtMetEnv03;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtMetEnv03 != null)
                {
                }
                this._txtMetEnv03 = value;
                if (this._txtMetEnv03 != null)
                {
                }
            }
        }

        internal virtual TextBox txtNomProv
        {
            get
            {
                return this._txtNomProv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtNomProv != null)
                {
                }
                this._txtNomProv = value;
                if (this._txtNomProv != null)
                {
                }
            }
        }
    }
}

