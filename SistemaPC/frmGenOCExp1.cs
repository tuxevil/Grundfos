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

    public class frmGenOCExp1 : Form
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
        [AccessedThroughProperty("editCodProv")]
        private TextBox _editCodProv;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("Label8")]
        private Label _Label8;
        [AccessedThroughProperty("Label9")]
        private Label _Label9;
        [AccessedThroughProperty("txtNomCli")]
        private TextBox _txtNomCli;
        [AccessedThroughProperty("txtNomProv")]
        private TextBox _txtNomProv;
        [AccessedThroughProperty("txtNroOV")]
        private TextBox _txtNroOV;
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

        public frmGenOCExp1()
        {
            base.Load += new EventHandler(this.frmGenOCExp1_Load);
            base.Closed += new EventHandler(this.frmGenOCExp1_Closed);
            this.DS = new DataSet();
            this.DS1 = new DataSet();
            this.InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            int num2 = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].Rows.Count - 1;
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
                Interaction.MsgBox("Debe ingresar Proveedor", MsgBoxStyle.Critical, "Operador");
                this.editCodProv.Focus();
            }
            else if (StringType.StrCmp(this.txtNomProv.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe ingresar Proveedor", MsgBoxStyle.Critical, "Operador");
                this.editCodProv.Focus();
            }
            else
            {
                SqlConnection connection;
                string str4;
                this.AdapTmpOCompra.Update(this.DS, Variables.gTermi + "TmpOCompraExp");
                this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].AcceptChanges();
                try
                {
                    str4 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                    connection = new SqlConnection(str4);
                    connection.Open();
                    flag = true;
                    int num3 = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].Rows.Count - 1;
                    for (int i = 0; i <= num3; i++)
                    {
                        if (ObjectType.ObjTst(this.dgTmpOCompra[i, 0], true, false) == 0)
                        {
                            int num2 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(("update " + Variables.gTermi + "TmpOCompraExp set CodProv='" + this.editCodProv.Text + "',NomProv='" + this.txtNomProv.Text) + "', Seleccion=0 where NroLinea='", this.dgTmpOCompra[i, 1]), "'")), connection).ExecuteNonQuery();
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
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                    this.Close();
                    ProjectData.ClearProjectError();
                }
                string selectCommandText = "select * from " + Variables.gTermi + "TmpOCompraExp order by NroLinea";
                this.AdapTmpOCompra = new SqlDataAdapter(selectCommandText, str4);
                this.CB = new SqlCommandBuilder(this.AdapTmpOCompra);
                this.DS.Clear();
                this.AdapTmpOCompra.Fill(this.DS, Variables.gTermi + "TmpOCompraExp");
                this.TotReg = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].Rows.Count;
                this.dgTmpOCompra.DataSource = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"];
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
                this.AdapTmpOCompra.Update(this.DS, Variables.gTermi + "TmpOCompraExp");
                this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].AcceptChanges();
                try
                {
                    str4 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                    connection = new SqlConnection(str4);
                    connection.Open();
                    flag = true;
                    int num = new SqlCommand("update " + Variables.gTermi + "TmpOCompraExp set Seleccion=0", connection).ExecuteNonQuery();
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
                string selectCommandText = "select * from " + Variables.gTermi + "TmpOCompraExp order by NroLinea";
                this.AdapTmpOCompra = new SqlDataAdapter(selectCommandText, str4);
                this.CB = new SqlCommandBuilder(this.AdapTmpOCompra);
                this.DS.Clear();
                this.AdapTmpOCompra.Fill(this.DS, Variables.gTermi + "TmpOCompraExp");
                this.TotReg = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].Rows.Count;
                this.dgTmpOCompra.DataSource = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"];
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
                this.AdapTmpOCompra.Update(this.DS, Variables.gTermi + "TmpOCompraExp");
                this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].AcceptChanges();
                try
                {
                    str4 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                    connection = new SqlConnection(str4);
                    connection.Open();
                    flag = true;
                    int num = new SqlCommand("update " + Variables.gTermi + "TmpOCompraExp set Seleccion=1", connection).ExecuteNonQuery();
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
                string selectCommandText = "select * from " + Variables.gTermi + "TmpOCompraExp order by NroLinea";
                this.AdapTmpOCompra = new SqlDataAdapter(selectCommandText, str4);
                this.CB = new SqlCommandBuilder(this.AdapTmpOCompra);
                this.DS.Clear();
                this.AdapTmpOCompra.Fill(this.DS, Variables.gTermi + "TmpOCompraExp");
                this.TotReg = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].Rows.Count;
                this.dgTmpOCompra.DataSource = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"];
                this.dgTmpOCompra.Refresh();
                this.dgTmpOCompra.Refresh();
                this.chkSelTodo.Checked = false;
            }
        }

        private void cmbEliminar_Click(object sender, EventArgs e)
        {
            int num;
            bool flag2 = false;
            int num4 = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].Rows.Count - 1;
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
                Interaction.MsgBox("Debe seleccionar productos a eliminar", MsgBoxStyle.Critical, "Operador");
            }
            else
            {
                bool flag = false;
                this.GroupBox1.Visible = false;
                this.cmbModificar.Enabled = false;
                this.cmbEliminar.Enabled = false;
                this.cmbGenOC.Enabled = false;
                this.cmbListado.Enabled = false;
                this.cmbListadoOCGen.Enabled = false;
                if (Interaction.MsgBox("Desea eliminar estos productos?", MsgBoxStyle.YesNo, "Operador") == MsgBoxResult.Yes)
                {
                    SqlConnection connection;
                    string str4;
                    try
                    {
                        str4 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096";
                        connection = new SqlConnection(str4);
                        connection.Open();
                        flag = true;
                        int num2 = new SqlCommand("delete " + Variables.gTermi + "TmpOCompraExp where Seleccion=1", connection).ExecuteNonQuery();
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
                    string selectCommandText = "select * from " + Variables.gTermi + "TmpOCompraExp order by NroLinea";
                    this.AdapTmpOCompra = new SqlDataAdapter(selectCommandText, str4);
                    this.CB = new SqlCommandBuilder(this.AdapTmpOCompra);
                    this.DS.Clear();
                    this.AdapTmpOCompra.Fill(this.DS, Variables.gTermi + "TmpOCompraExp");
                    this.TotReg = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].Rows.Count;
                    this.dgTmpOCompra.DataSource = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"];
                    this.dgTmpOCompra.Refresh();
                    this.dgTmpOCompra.Refresh();
                }
                else
                {
                    int num3 = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].Rows.Count - 1;
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
            int num2 = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].Rows.Count - 1;
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
                Interaction.MsgBox("Debe seleccionar productos a generar o.compra", MsgBoxStyle.Critical, "Operador");
            }
            else
            {
                this.AdapTmpOCompra.Update(this.DS, Variables.gTermi + "TmpOCompraExp");
                this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].AcceptChanges();
                this.GroupBox1.Visible = false;
                this.cmbModificar.Enabled = false;
                this.cmbEliminar.Enabled = false;
                this.cmbGenOC.Enabled = false;
                this.cmbListado.Enabled = false;
                this.cmbListadoOCGen.Enabled = false;
                this.GenOC();
                string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
                string selectCommandText = "select * from " + Variables.gTermi + "TmpOCompraExp order by NroLinea";
                this.AdapTmpOCompra = new SqlDataAdapter(selectCommandText, selectConnectionString);
                this.CB = new SqlCommandBuilder(this.AdapTmpOCompra);
                this.DS.Clear();
                this.AdapTmpOCompra.Fill(this.DS, Variables.gTermi + "TmpOCompraExp");
                this.dgTmpOCompra.DataSource = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"];
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
            int num2 = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].Rows.Count - 1;
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
                Interaction.MsgBox("Debe seleccionar productos a listar", MsgBoxStyle.Critical, "Operador");
            }
            else
            {
                this.AdapTmpOCompra.Update(this.DS, Variables.gTermi + "TmpOCompraExp");
                this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].AcceptChanges();
                this.GroupBox1.Visible = false;
                this.cmbModificar.Enabled = false;
                this.cmbEliminar.Enabled = false;
                this.cmbGenOC.Enabled = false;
                this.cmbListado.Enabled = false;
                this.cmbListadoOCGen.Enabled = false;
                frmGenOCExp2 exp = new frmGenOCExp2();
                this.Hide();
                exp.Show();
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
            this.AdapTmpOCompra.Update(this.DS, Variables.gTermi + "TmpOCompraExp");
            this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].AcceptChanges();
            frmGenOCExp3 exp = new frmGenOCExp3();
            this.Hide();
            exp.Show();
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
            int num2 = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (ObjectType.ObjTst(this.dgTmpOCompra[i, 0], true, false) == 0)
                {
                    flag = true;
                    this.editCodProv.Text = StringType.FromObject(this.dgTmpOCompra[i, 5]);
                    this.txtNomProv.Text = StringType.FromObject(this.dgTmpOCompra[i, 6]);
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
                Interaction.MsgBox("Debe seleccionar productos a modificar", MsgBoxStyle.Critical, "Operador");
            }
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgTmpOCompra_Click(object sender, EventArgs e)
        {
            int num2 = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].Rows.Count - 1;
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

        private void editCodProv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.btnModificar.Focus();
            }
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
                        Interaction.MsgBox("Proveedor inexistente", MsgBoxStyle.Information, "Operador");
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
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                    this.Close();
                    ProjectData.ClearProjectError();
                }
            }
        }

        private void editCodProv_TextChanged(object sender, EventArgs e)
        {
        }

        ~frmGenOCExp1()
        {
        }

        private void frmGenOCExp1_Closed(object sender, EventArgs e)
        {
            new frmGenOCExp().Show();
        }

        private void frmGenOCExp1_Load(object sender, EventArgs e)
        {
            this.txtNroOV.Text = Variables.gNroOV;
            this.txtNomCli.Text = Variables.gNomCli;
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            string selectCommandText = "select * from " + Variables.gTermi + "TmpOCompraExp order by NroLinea";
            this.AdapTmpOCompra = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.CB = new SqlCommandBuilder(this.AdapTmpOCompra);
            this.AdapTmpOCompra.Fill(this.DS, Variables.gTermi + "TmpOCompraExp");
            this.TotReg = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"].Rows.Count;
            this.dgTmpOCompra.DataSource = this.DS.Tables[Variables.gTermi + "TmpOCompraExp"];
            DataGridTableStyle table = new DataGridTableStyle();
            table.MappingName = Variables.gTermi + "TmpOCompraExp";
            DataGridTextBoxColumn column = new DataGridTextBoxColumn();
            DataGridBoolColumn column2 = new DataGridBoolColumn();
            DataGridBoolColumn column9 = column2;
            column9.HeaderText = "Sel.";
            column9.MappingName = "Seleccion";
            column9.Width = 0x23;
            column9 = null;
            table.GridColumnStyles.Add(column2);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column8 = column;
            column8.HeaderText = "L\x00ednea";
            column8.MappingName = "NroLinea";
            column8.ReadOnly = true;
            column8.Width = 60;
            column8 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column7 = column;
            column7.HeaderText = "C\x00f3digo";
            column7.MappingName = "Codigo";
            column7.ReadOnly = true;
            column7.Width = 70;
            column7 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column6 = column;
            column6.HeaderText = "Producto";
            column6.MappingName = "Descripcion";
            column6.ReadOnly = true;
            column6.Width = 250;
            column6 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column5 = column;
            column5.HeaderText = "Cantidad OV";
            column5.MappingName = "CantidadOV";
            column5.Width = 70;
            column5.ReadOnly = false;
            column5.Format = "######0";
            column5 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column4 = column;
            column4.HeaderText = "Cod.Prov.";
            column4.MappingName = "CodProv";
            column4.ReadOnly = true;
            column4.Width = 60;
            column4 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column3 = column;
            column3.HeaderText = "Proveedor";
            column3.MappingName = "NomProv";
            column3.ReadOnly = true;
            column3.Width = 250;
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
                long num4;
                connection2 = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096");
                connection2.Open();
                flag2 = true;
                connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
                connection.Open();
                string cmdText = "select * from PC010100 (TABLOCKX)";
                SqlCommand command = new SqlCommand(cmdText, connection);
                command.CommandTimeout = 120;
                command.ExecuteNonQuery();
                cmdText = "SELECT PC01001 from PC010100 where CONVERT(numeric, PC01001) > 3000000 and CONVERT(numeric, PC01001)<3999999 order by PC01001 desc";
                command = new SqlCommand(cmdText, connection);
                command.CommandTimeout = 120;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    num4 = (long) Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(reader["PC01001"])));
                }
                else
                {
                    num4 = 0x2dc6c0L;
                }
                reader.Close();
                command = new SqlCommand("SELECT * from " + Variables.gTermi + "TmpOCompraExp where Seleccion=1 and CantidadOV<>0 order by NroLinea", connection2);
                command.CommandTimeout = 500;
                this.DS1.Clear();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(this.DS1, Variables.gTermi + "TmpOCompraExp");
                string str2 = "";
                int num6 = this.DS1.Tables[Variables.gTermi + "TmpOCompraExp"].Rows.Count - 1;
                for (int i = 0; i <= num6; i++)
                {
                    DataRow row = this.DS1.Tables[Variables.gTermi + "TmpOCompraExp"].Rows[i];
                    if (ObjectType.ObjTst(str2, row["CodProv"], false) != 0)
                    {
                        str2 = StringType.FromObject(row["CodProv"]);
                        num4 += 1L;
                        int num5 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(("insert into " + Variables.gTermi + "TmpOCGen (NroOC,CodProv,NomProv,FecEntOC) values ('" + Strings.Format(num4, "0000000000")) + "','", row["CodProv"]), "','"), row["NomProv"]), "','"), Strings.Format(DateType.FromString(Variables.gFechaEntOC), "MM/dd/yyyy")), "')")), connection2).ExecuteNonQuery();
                    }
                    string str = (((((((((StringType.FromObject(ObjectType.StrCatObj(StringType.FromObject(ObjectType.StrCatObj(StringType.FromObject(ObjectType.StrCatObj(Strings.Format(num4, "0000000000") + "3", row["NroLinea"])), ObjectType.AddObj(row["Codigo"], Strings.Space(0x23 - Strings.Len(RuntimeHelpers.GetObjectValue(row["Codigo"])))))) + Strings.Format(RuntimeHelpers.GetObjectValue(row["CantidadOV"]), "00000000000.00000000"), ObjectType.AddObj(row["CodProv"], Strings.Space(10 - Strings.Len(RuntimeHelpers.GetObjectValue(row["CodProv"])))))) + Strings.Format(DateAndTime.Now, "ddMMyyyy")) + Strings.Format(DateType.FromString(Variables.gFechaEntOC), "ddMMyyyy") + Strings.Format(Conversion.Val(Variables.gCodMetEnt), "00")) + Strings.Mid(Variables.gAlmacen1, 1, 2) + Strings.Space(6 - Strings.Len(Strings.Mid(Variables.gAlmacen1, 1, 2)))) + Strings.Space(2)) + Strings.Trim(Variables.gDirEnt1) + Strings.Space(0x23 - Strings.Len(Strings.Trim(Variables.gDirEnt1)))) + Strings.Trim(Variables.gDirEnt2) + Strings.Space(0x23 - Strings.Len(Strings.Trim(Variables.gDirEnt2)))) + Strings.Trim(Variables.gDirEnt3) + Strings.Space(0x23 - Strings.Len(Strings.Trim(Variables.gDirEnt3)))) + Strings.Trim(Variables.gDirEnt4) + Strings.Space(0x23 - Strings.Len(Strings.Trim(Variables.gDirEnt4)))) + Strings.Trim(Variables.gDirEnt5) + Strings.Space(0x23 - Strings.Len(Strings.Trim(Variables.gDirEnt5)))) + Strings.Trim(Variables.gCliente) + Strings.Space(10 - Strings.Len(Strings.Trim(Variables.gCliente)));
                    str = str + this.txtNroOV.Text + "-3" + "\r" + "\n";
                    StreamWriter writer = new StreamWriter(Variables.gPathTxt + @"\genocexp.prn", true);
                    writer.Write(str);
                    writer.Close();
                }
                new SqlCommand("delete " + Variables.gTermi + "TmpOCompraExp where Seleccion=1", connection2).ExecuteNonQuery();
                connection2.Close();
                flag2 = false;
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

        private void GroupBox1_Enter(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmGenOCExp1));
            this.cmbListado = new Button();
            this.cmbSalir = new Button();
            this.dgTmpOCompra = new DataGrid();
            this.GroupBox1 = new GroupBox();
            this.btnCancelar = new Button();
            this.btnModificar = new Button();
            this.txtNomProv = new TextBox();
            this.Label4 = new Label();
            this.editCodProv = new TextBox();
            this.cmbModificar = new Button();
            this.txtNomCli = new TextBox();
            this.Label8 = new Label();
            this.cmbGenOC = new Button();
            this.cmbListadoOCGen = new Button();
            this.cmbEliminar = new Button();
            this.Label9 = new Label();
            this.txtNroOV = new TextBox();
            this.chkDeselTodo = new CheckBox();
            this.chkSelTodo = new CheckBox();
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
            this.dgTmpOCompra.CaptionText = "Productos";
            this.dgTmpOCompra.DataMember = "";
            this.dgTmpOCompra.HeaderForeColor = SystemColors.ControlText;
            point = new Point(8, 40);
            this.dgTmpOCompra.Location = point;
            this.dgTmpOCompra.Name = "dgTmpOCompra";
            size = new Size(0x3f8, 0x1e8);
            this.dgTmpOCompra.Size = size;
            this.dgTmpOCompra.TabIndex = 2;
            this.GroupBox1.Controls.Add(this.btnCancelar);
            this.GroupBox1.Controls.Add(this.btnModificar);
            this.GroupBox1.Controls.Add(this.txtNomProv);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.editCodProv);
            point = new Point(8, 0x250);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(0x2c0, 0x60);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 10;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Visible = false;
            point = new Point(480, 0x38);
            this.btnCancelar.Location = point;
            this.btnCancelar.Name = "btnCancelar";
            size = new Size(0x60, 0x18);
            this.btnCancelar.Size = size;
            this.btnCancelar.TabIndex = 0x10;
            this.btnCancelar.Text = "&Cancelar";
            point = new Point(0x248, 0x38);
            this.btnModificar.Location = point;
            this.btnModificar.Name = "btnModificar";
            size = new Size(0x60, 0x18);
            this.btnModificar.Size = size;
            this.btnModificar.TabIndex = 15;
            this.btnModificar.Text = "&Modificar";
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
            this.txtNomCli.BackColor = SystemColors.Window;
            this.txtNomCli.Enabled = false;
            this.txtNomCli.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x148, 8);
            this.txtNomCli.Location = point;
            this.txtNomCli.MaxLength = 0x23;
            this.txtNomCli.Name = "txtNomCli";
            size = new Size(0x1e8, 0x16);
            this.txtNomCli.Size = size;
            this.txtNomCli.TabIndex = 1;
            this.txtNomCli.Text = "";
            this.Label8.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0xe8, 8);
            this.Label8.Location = point;
            this.Label8.Name = "Label8";
            size = new Size(80, 0x10);
            this.Label8.Size = size;
            this.Label8.TabIndex = 0;
            this.Label8.Text = "Cliente:";
            point = new Point(0x268, 0x220);
            this.cmbGenOC.Location = point;
            this.cmbGenOC.Name = "cmbGenOC";
            size = new Size(0x60, 40);
            this.cmbGenOC.Size = size;
            this.cmbGenOC.TabIndex = 8;
            this.cmbGenOC.Text = "&Generar O.Compra";
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
            this.Label9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 8);
            this.Label9.Location = point;
            this.Label9.Name = "Label9";
            size = new Size(0x60, 0x17);
            this.Label9.Size = size;
            this.Label9.TabIndex = 12;
            this.Label9.Text = "Nro.O.Venta:";
            this.txtNroOV.BackColor = SystemColors.Window;
            this.txtNroOV.Enabled = false;
            this.txtNroOV.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x70, 8);
            this.txtNroOV.Location = point;
            this.txtNroOV.MaxLength = 10;
            this.txtNroOV.Name = "txtNroOV";
            size = new Size(0x70, 0x16);
            this.txtNroOV.Size = size;
            this.txtNroOV.TabIndex = 13;
            this.txtNroOV.Text = "";
            point = new Point(0x80, 0x228);
            this.chkDeselTodo.Location = point;
            this.chkDeselTodo.Name = "chkDeselTodo";
            size = new Size(0x80, 0x18);
            this.chkDeselTodo.Size = size;
            this.chkDeselTodo.TabIndex = 15;
            this.chkDeselTodo.Text = "Deseleccionar todo";
            point = new Point(8, 0x228);
            this.chkSelTodo.Location = point;
            this.chkSelTodo.Name = "chkSelTodo";
            size = new Size(0x70, 0x18);
            this.chkSelTodo.Size = size;
            this.chkSelTodo.TabIndex = 14;
            this.chkSelTodo.Text = "Seleccionar todo";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            size = new Size(0x380, 0x2ce);
            this.ClientSize = size;
            this.Controls.Add(this.chkDeselTodo);
            this.Controls.Add(this.chkSelTodo);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.txtNroOV);
            this.Controls.Add(this.cmbEliminar);
            this.Controls.Add(this.cmbListadoOCGen);
            this.Controls.Add(this.cmbGenOC);
            this.Controls.Add(this.txtNomCli);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.cmbModificar);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.dgTmpOCompra);
            this.Controls.Add(this.cmbSalir);
            this.Controls.Add(this.cmbListado);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmGenOCExp1";
            this.Text = "Generaci\x00f3n Ordenes de Compra Exportaci\x00f3n";
            this.WindowState = FormWindowState.Maximized;
            this.dgTmpOCompra.EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void Label8_Click(object sender, EventArgs e)
        {
        }

        private void txtAlmacen_TextChanged(object sender, EventArgs e)
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
                    this._dgTmpOCompra.Navigate -= new NavigateEventHandler(this.dgTmpOCompra_Navigate);
                    this._dgTmpOCompra.Click -= new EventHandler(this.dgTmpOCompra_Click);
                    this._dgTmpOCompra.DoubleClick -= new EventHandler(this.dgTmpOCompra_DoubleClick);
                }
                this._dgTmpOCompra = value;
                if (this._dgTmpOCompra != null)
                {
                    this._dgTmpOCompra.Navigate += new NavigateEventHandler(this.dgTmpOCompra_Navigate);
                    this._dgTmpOCompra.Click += new EventHandler(this.dgTmpOCompra_Click);
                    this._dgTmpOCompra.DoubleClick += new EventHandler(this.dgTmpOCompra_DoubleClick);
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
                    this._editCodProv.KeyPress -= new KeyPressEventHandler(this.editCodProv_KeyPress);
                }
                this._editCodProv = value;
                if (this._editCodProv != null)
                {
                    this._editCodProv.LostFocus += new EventHandler(this.editCodProv_LostFocus);
                    this._editCodProv.TextChanged += new EventHandler(this.editCodProv_TextChanged);
                    this._editCodProv.KeyPress += new KeyPressEventHandler(this.editCodProv_KeyPress);
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
                    this._GroupBox1.Enter -= new EventHandler(this.GroupBox1_Enter);
                }
                this._GroupBox1 = value;
                if (this._GroupBox1 != null)
                {
                    this._GroupBox1.Enter += new EventHandler(this.GroupBox1_Enter);
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
                    this._Label8.Click -= new EventHandler(this.Label8_Click);
                }
                this._Label8 = value;
                if (this._Label8 != null)
                {
                    this._Label8.Click += new EventHandler(this.Label8_Click);
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

        internal virtual TextBox txtNomCli
        {
            get
            {
                return this._txtNomCli;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtNomCli != null)
                {
                    this._txtNomCli.TextChanged -= new EventHandler(this.txtAlmacen_TextChanged);
                }
                this._txtNomCli = value;
                if (this._txtNomCli != null)
                {
                    this._txtNomCli.TextChanged += new EventHandler(this.txtAlmacen_TextChanged);
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

        internal virtual TextBox txtNroOV
        {
            get
            {
                return this._txtNroOV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtNroOV != null)
                {
                }
                this._txtNroOV = value;
                if (this._txtNroOV != null)
                {
                }
            }
        }
    }
}

