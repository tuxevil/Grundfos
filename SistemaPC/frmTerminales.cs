namespace SistemaPC
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Common;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmTerminales : Form
    {
        [AccessedThroughProperty("btnAdd")]
        private Button _btnAdd;
        [AccessedThroughProperty("btnCancel")]
        private Button _btnCancel;
        [AccessedThroughProperty("btnDelete")]
        private Button _btnDelete;
        [AccessedThroughProperty("btnLast")]
        private Button _btnLast;
        [AccessedThroughProperty("btnListado")]
        private Button _btnListado;
        [AccessedThroughProperty("btnNavFirst")]
        private Button _btnNavFirst;
        [AccessedThroughProperty("btnNavNext")]
        private Button _btnNavNext;
        [AccessedThroughProperty("btnNavPrev")]
        private Button _btnNavPrev;
        [AccessedThroughProperty("btnSalir")]
        private Button _btnSalir;
        [AccessedThroughProperty("btnUpdate")]
        private Button _btnUpdate;
        [AccessedThroughProperty("btnUpdTodo")]
        private Button _btnUpdTodo;
        [AccessedThroughProperty("editCodigo")]
        private TextBox _editCodigo;
        [AccessedThroughProperty("lblCodigo")]
        private Label _lblCodigo;
        [AccessedThroughProperty("lblNavLocation")]
        private Label _lblNavLocation;
        [AccessedThroughProperty("objDataTermi")]
        private DataTermi _objDataTermi;
        [AccessedThroughProperty("OleDbConnection1")]
        private OleDbConnection _OleDbConnection1;
        [AccessedThroughProperty("OleDbDataAdapter1")]
        private OleDbDataAdapter _OleDbDataAdapter1;
        [AccessedThroughProperty("OleDbDeleteCommand1")]
        private OleDbCommand _OleDbDeleteCommand1;
        [AccessedThroughProperty("OleDbInsertCommand1")]
        private OleDbCommand _OleDbInsertCommand1;
        [AccessedThroughProperty("OleDbSelectCommand1")]
        private OleDbCommand _OleDbSelectCommand1;
        [AccessedThroughProperty("OleDbUpdateCommand1")]
        private OleDbCommand _OleDbUpdateCommand1;
        private IContainer components;

        public frmTerminales()
        {
            base.Load += new EventHandler(this.frmTerminales_Load);
            base.Closed += new EventHandler(this.frmTerminales_Closed);
            this.InitializeComponent();
        }

        private void BorraTmp()
        {
            SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
            connection.Open();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpInventario' and type='U') DROP table " + this.editCodigo.Text + "TmpInventario", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpOVPend' and type='U') DROP table " + this.editCodigo.Text + "TmpOVPend", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpConsOV' and type='U') DROP table " + this.editCodigo.Text + "TmpConsOV", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpOVExped' and type='U') DROP table " + this.editCodigo.Text + "TmpOVExped", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpGesEns' and type='U') DROP table " + this.editCodigo.Text + "TmpGesEns", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpOCompra' and type='U') DROP table " + this.editCodigo.Text + "TmpOCompra", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpOCGen' and type='U') DROP table " + this.editCodigo.Text + "TmpOCGen", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpCalendario' and type='U') DROP table " + this.editCodigo.Text + "TmpCalendario", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpCalendarioStkComp' and type='U') DROP table " + this.editCodigo.Text + "TmpCalendarioStkComp", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpDetDes' and type='U') DROP table " + this.editCodigo.Text + "TmpDetDes", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpFormaDesp' and type='U') DROP table " + this.editCodigo.Text + "TmpFormaDesp", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpRepGesEns' and type='U') DROP table " + this.editCodigo.Text + "TmpRepGesEns", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpRegPedExp' and type='U') DROP table " + this.editCodigo.Text + "TmpRegPedExp", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpOVCli' and type='U') DROP table " + this.editCodigo.Text + "TmpOVCli", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpOVFcProExp' and type='U') DROP table " + this.editCodigo.Text + "TmpOVFcProExp", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpCodReemp' and type='U') DROP table " + this.editCodigo.Text + "TmpCodReemp", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpOCompraExp' and type='U') DROP table " + this.editCodigo.Text + "TmpOCompraExp", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpOCConfPend' and type='U') DROP table " + this.editCodigo.Text + "TmpOCConfPend", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpOCManual' and type='U') DROP table " + this.editCodigo.Text + "TmpOCManual", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpItemFcProExp' and type='U') DROP table " + this.editCodigo.Text + "TmpItemFcProExp", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpMetEnvio' and type='U') DROP table " + this.editCodigo.Text + "TmpMetEnvio", connection).ExecuteNonQuery();
            connection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.BindingContext[this.objDataTermi, "Terminales"].EndCurrentEdit();
                this.BindingContext[this.objDataTermi, "Terminales"].AddNew();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                MessageBox.Show(exception.Message);
                ProjectData.ClearProjectError();
            }
            this.objDataTermi_PositionChanged();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.BindingContext[this.objDataTermi, "Terminales"].EndCurrentEdit();
                this.BindingContext[this.objDataTermi, "Terminales"].AddNew();
                this.editCodigo.Enabled = true;
                this.editCodigo.Focus();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                MessageBox.Show(exception.Message);
                ProjectData.ClearProjectError();
            }
            this.objDataTermi_PositionChanged();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.BindingContext[this.objDataTermi, "Terminales"].CancelCurrentEdit();
            this.objDataTermi_PositionChanged();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.BindingContext[this.objDataTermi, "Terminales"].CancelCurrentEdit();
            this.objDataTermi_PositionChanged();
            this.editCodigo.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.BindingContext[this.objDataTermi, "Terminales"].Count > 0)
            {
                this.BindingContext[this.objDataTermi, "Terminales"].RemoveAt(this.BindingContext[this.objDataTermi, "Terminales"].Position);
                this.objDataTermi_PositionChanged();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if ((this.BindingContext[this.objDataTermi, "Terminales"].Count > 0) && (Interaction.MsgBox("Desea eliminar este registro?", MsgBoxStyle.Critical | MsgBoxStyle.YesNo, "Operador") == MsgBoxResult.Yes))
            {
                this.editCodigo.Text = Strings.UCase(Strings.Trim(this.editCodigo.Text));
                this.BorraTmp();
                this.BindingContext[this.objDataTermi, "Terminales"].RemoveAt(this.BindingContext[this.objDataTermi, "Terminales"].Position);
                try
                {
                    this.UpdateDataSet();
                    this.editCodigo.Enabled = false;
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    MessageBox.Show(exception.Message);
                    ProjectData.ClearProjectError();
                }
                this.objDataTermi_PositionChanged();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this.BindingContext[this.objDataTermi, "Terminales"].Position = this.objDataTermi.Tables["Terminales"].Rows.Count - 1;
            this.objDataTermi_PositionChanged();
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            frmTerminales1 terminales = new frmTerminales1();
            Cursor current = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            this.Hide();
            terminales.Show();
        }

        private void btnNavFirst_Click(object sender, EventArgs e)
        {
            this.BindingContext[this.objDataTermi, "Terminales"].Position = 0;
            this.objDataTermi_PositionChanged();
        }

        private void btnNavNext_Click(object sender, EventArgs e)
        {
            this.BindingContext[this.objDataTermi, "Terminales"].Position++;
            this.objDataTermi_PositionChanged();
        }

        private void btnNavPrev_Click(object sender, EventArgs e)
        {
            this.BindingContext[this.objDataTermi, "Terminales"].Position--;
            this.objDataTermi_PositionChanged();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.UpdateDataSet();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                MessageBox.Show(exception.Message);
                ProjectData.ClearProjectError();
            }
            this.objDataTermi_PositionChanged();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (StringType.StrCmp(this.editCodigo.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe ingresar terminal", MsgBoxStyle.Critical, "Operador");
                this.editCodigo.Focus();
            }
            else
            {
                this.editCodigo.Text = Strings.UCase(Strings.Trim(this.editCodigo.Text));
                this.btnAdd.Enabled = false;
                this.btnDelete.Enabled = false;
                this.btnUpdate.Enabled = false;
                this.btnUpdTodo.Enabled = false;
                this.btnCancel.Enabled = false;
                this.btnListado.Enabled = false;
                this.CreaTmp();
                try
                {
                    this.UpdateDataSet();
                    this.editCodigo.Enabled = false;
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    MessageBox.Show(exception.Message);
                    ProjectData.ClearProjectError();
                }
                this.objDataTermi_PositionChanged();
                this.btnAdd.Enabled = true;
                this.btnDelete.Enabled = true;
                this.btnUpdate.Enabled = true;
                this.btnUpdTodo.Enabled = true;
                this.btnCancel.Enabled = true;
                this.btnListado.Enabled = true;
            }
        }

        private void btnUpdTodo_Click(object sender, EventArgs e)
        {
            this.BindingContext[this.objDataTermi, "Terminales"].Position = 0;
            this.objDataTermi_PositionChanged();
            this.btnAdd.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.btnUpdTodo.Enabled = false;
            this.btnCancel.Enabled = false;
            this.btnListado.Enabled = false;
            while (1 != 0)
            {
                this.editCodigo.Text = Strings.UCase(Strings.Trim(this.editCodigo.Text));
                this.CreaTmp();
                this.BindingContext[this.objDataTermi, "Terminales"].Position++;
                this.objDataTermi_PositionChanged();
                if (this.BindingContext[this.objDataTermi, "Terminales"].Position == (this.objDataTermi.Tables["Terminales"].Rows.Count - 1))
                {
                    break;
                }
            }
            this.editCodigo.Text = Strings.UCase(Strings.Trim(this.editCodigo.Text));
            this.CreaTmp();
            this.BindingContext[this.objDataTermi, "Terminales"].Position = 0;
            this.objDataTermi_PositionChanged();
            this.btnAdd.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnUpdate.Enabled = true;
            this.btnUpdTodo.Enabled = true;
            this.btnCancel.Enabled = true;
            this.btnListado.Enabled = true;
        }

        private void CreaTmp()
        {
            SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
            connection.Open();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpInventario' and type='U') DROP table " + this.editCodigo.Text + "TmpInventario", connection).ExecuteNonQuery();
            new SqlCommand(((((("create table dbo." + this.editCodigo.Text + "TmpInventario(") + "Almacen varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Posicion varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "Codigo varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Desc1 varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "Desc2 varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "Cantidad numeric(20,8) not null,") + "PosSist varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "CantSist numeric(20,8) null,") + "Aceptar bit not null," + "Rechazar bit not null)", connection).ExecuteNonQuery();
            new SqlCommand("ALTER TABLE " + this.editCodigo.Text + "TmpInventario WITH NOCHECK ADD CONSTRAINT [PK_" + this.editCodigo.Text + "TmpInventario] PRIMARY KEY  CLUSTERED ([Almacen],[Posicion],[Codigo])  ON [PRIMARY] ", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpOVPend' and type='U') DROP table " + this.editCodigo.Text + "TmpOVPend", connection).ExecuteNonQuery();
            new SqlCommand((((((((((("create table dbo." + this.editCodigo.Text) + "TmpOVPend(" + "Cliente char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "NomCli varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "EntBloq varchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "ExcLimCre varchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "NroOV char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "FechaOV datetime not null," + "FechaEnt datetime not null,") + "Reserva int not null," + "RefCli varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "OCompra varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "CodProd varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "Desc1 varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Desc2 varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "Cantidad numeric(20,8) not null," + "StockFisico numeric(20,8) not null,") + "StockComp numeric(20,8) not null," + "FechaOC datetime null,") + "CantOC numeric(20,8) null," + "EntParc char(1) COLLATE SQL_Latin1_General_CP1_CI_AS not null)", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpPrepPed' and type='U') DROP table " + this.editCodigo.Text + "TmpPrepPed", connection).ExecuteNonQuery();
            new SqlCommand((((((((((("create table dbo." + this.editCodigo.Text + "TmpPrepPed(") + "NroOV char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "NroLinea char(6) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "TipoLinea int not null," + "EstLinea char(3) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "Codigo varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Desc1 varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "Desc2 varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "Almacen varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "CantOrden numeric(20,8) not null," + "CantPrep numeric(20,8) not null,") + "Stock numeric(20,8) null," + "Producto numeric(1,0) null,") + "Estante varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "Stock03 numeric(20,8) null,") + "Stock04 numeric(20,8) null," + "Stock05 numeric(20,8) null,") + "Stock06 numeric(20,8) null," + "Stock07 numeric(20,8) null,") + "Stock08 numeric(20,8) null," + "Stock09 numeric(20,8) null)", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpEAPrepPed' and type='U') DROP table " + this.editCodigo.Text + "TmpEAPrepPed", connection).ExecuteNonQuery();
            new SqlCommand(((((((("create table dbo." + this.editCodigo.Text + "TmpEAPrepPed(") + "CodMetEnt int null," + "DescMetEnt varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "NroOV char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "TipoOV int not null,") + "FechaEnt datetime not null," + "DespParcial char(1) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "LineasOV numeric(3,0) not null," + "LineasConStk numeric(3,0) not null,") + "LineasPrep numeric(3,0) not null," + "Cliente varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "Observa1 varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Observa2 varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "Impreso char(1) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Color char(1) COLLATE SQL_Latin1_General_CP1_CI_AS not null)", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpConsOV' and type='U') DROP table " + this.editCodigo.Text + "TmpConsOV", connection).ExecuteNonQuery();
            new SqlCommand((((((((("create table dbo." + this.editCodigo.Text) + "TmpConsOV(" + "NroOV char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "TipoOV int not null," + "Cliente char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "NomCli varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "OCompra varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "CodMetEnt int not null," + "DescMetEnt varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "LugarEnt varchar(140) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "FechaOV datetime not null,") + "FechaEnt datetime null," + "FechaPrep datetime null,") + "FechaExp datetime null," + "Remito varchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "CodEstado numeric(1,0) not null," + "Estado char(25) COLLATE SQL_Latin1_General_CP1_CI_AS null)", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpOVExped' and type='U') DROP table " + this.editCodigo.Text + "TmpOVExped", connection).ExecuteNonQuery();
            new SqlCommand((((((((((((("create table dbo." + this.editCodigo.Text) + "TmpOVExped(" + "NroOV char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "TipoOV int not null," + "Cliente char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "NomCli varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "OCompra varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "CodMetEnt int not null," + "DescMetEnt varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "LugarEnt varchar(140) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "FechaOV datetime not null,") + "FechaEnt datetime not null," + "FechaPrep datetime null,") + "FechaExp datetime null," + "FechaRecConfCli datetime null,") + "NroRemito varchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "NroFactura varchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "PesoNeto numeric(18,8) null," + "PesoBruto numeric(18,8) null,") + "Volumen numeric(18,8) null," + "Bultos numeric(18,8) null,") + "CodProd varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Desc1 varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "Desc2 varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Cantidad numeric(20,8) not null)", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpGesEns' and type='U') DROP table " + this.editCodigo.Text + "TmpGesEns", connection).ExecuteNonQuery();
            new SqlCommand(((((((((((("create table dbo." + this.editCodigo.Text + "TmpGesEns(") + "NroOE char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "FechaOE datetime not null,") + "FechaEnt datetime not null," + "FechaEnsReal datetime null,") + "NroLinea char(6) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Codigo varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "Descripcion varchar(51) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "CantOE numeric(20,8) not null,") + "CantArmado numeric(20,8) not null," + "Cliente varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "NroOV char(10) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "Observaciones varchar(71) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "TiempoAsig varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "OpRecoleccion varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "OpArmado varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "OpPrueba varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "OpEmbalaje varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "TRecoleccion numeric(5,0) null,") + "TArmado numeric(5,0) null," + "TPrueba numeric(5,0) null,") + "TEmbalaje numeric(5,0) null," + "Obs varchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS not null)", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpOCompra' and type='U') DROP table " + this.editCodigo.Text + "TmpOCompra", connection).ExecuteNonQuery();
            new SqlCommand(((((((((((((((((("create table dbo." + this.editCodigo.Text) + "TmpOCompra(" + "Codigo varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "Descripcion varchar(51) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "NivelRepos numeric(20,8) not null,") + "StockAl numeric(20,8) not null," + "OV numeric(20,8) not null,") + "OCPend numeric(20,8) not null," + "OVRes numeric(20,8) not null,") + "LoteOptCpra numeric(20,8) not null," + "CantMinPed numeric(20,8) not null,") + "CodReemplazo varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "FecReemp datetime null,") + "PropCpra numeric(20,8) not null," + "PromVtas numeric(20,8) not null,") + "NivelReposPV numeric(20,8) not null," + "PropCpraPV numeric(20,8) not null,") + "CodProv varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "NomProv varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "CodMetEnv01 varchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "DescMetEnv01 varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "CantMetEnv01 numeric(20,8) not null," + "FecEntOC01 datetime not null,") + "CodMetEnv02 varchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "DescMetEnv02 varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "CantMetEnv02 numeric(20,8) not null," + "FecEntOC02 datetime not null,") + "CodMetEnv03 varchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "DescMetEnv03 varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "CantMetEnv03 numeric(20,8) not null," + "FecEntOC03 datetime not null,") + "Seleccion bit not null," + "PrecioCpra numeric(28,8) not null,") + "CodMoneda varchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Moneda varchar(3) COLLATE SQL_Latin1_General_CP1_CI_AS not null)", connection).ExecuteNonQuery();
            new SqlCommand("ALTER TABLE " + this.editCodigo.Text + "TmpOCompra WITH NOCHECK ADD CONSTRAINT [PK_" + this.editCodigo.Text + "TmpOCompra] PRIMARY KEY  CLUSTERED ([Codigo])  ON [PRIMARY] ", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpOCGen' and type='U') DROP table " + this.editCodigo.Text + "TmpOCGen", connection).ExecuteNonQuery();
            new SqlCommand((("create table dbo." + this.editCodigo.Text + "TmpOCGen(") + "NroOC char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "CodProv varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "NomProv varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "FecEntOC datetime not null)", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpCalendario' and type='U') DROP table " + this.editCodigo.Text + "TmpCalendario", connection).ExecuteNonQuery();
            new SqlCommand((((((((("create table dbo." + this.editCodigo.Text) + "TmpCalendario(" + "FechaEnt datetime not null,") + "Cliente varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "ListaRec varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "NroOA char(10) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "NroLinea char(6) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "Codigo varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "Descripcion varchar(51) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "Almacen varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "Cantidad numeric(20,8) null,") + "AsignadoA varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "Observaciones varchar(71) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "ReqEsp varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "Horas varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "SinStock bit null," + "Obs bit null)", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpCalendarioStkComp' and type='U') DROP table " + this.editCodigo.Text + "TmpCalendarioStkComp", connection).ExecuteNonQuery();
            new SqlCommand(((((("create table dbo." + this.editCodigo.Text) + "TmpCalendarioStkComp(" + "NroOA char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "NroLinea char(6) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "CodComp varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "DescComp varchar(51) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Cantidad numeric(20,8) not null,") + "StkFisico numeric(20,8) null," + "StkComprometido numeric(20,8) null,") + "FechaOC datetime null," + "CantOC numeric(20,8) null)", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpDetDes' and type='U') DROP table " + this.editCodigo.Text + "TmpDetDes", connection).ExecuteNonQuery();
            new SqlCommand((((("create table dbo." + this.editCodigo.Text + "TmpDetDes(") + "NroOC char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "NroLinea char(6) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "NroBulto char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "PackList char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "FechaPL datetime not null," + "NroFC char(10) not null,") + "FechaFC datetime not null," + "EnTransito numeric(8,3) not null)", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpFormaDesp' and type='U') DROP table " + this.editCodigo.Text + "TmpFormaDesp", connection).ExecuteNonQuery();
            new SqlCommand(("create table dbo." + this.editCodigo.Text + "TmpFormaDesp(") + "Codigo int not null," + "Descripcion varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS not null)", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpRepGesEns' and type='U') DROP table " + this.editCodigo.Text + "TmpRepGesEns", connection).ExecuteNonQuery();
            new SqlCommand((((((((((((("create table dbo." + this.editCodigo.Text + "TmpRepGesEns(") + "NroOE char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "FechaOE datetime not null,") + "FechaEnt datetime not null," + "FechaEnsReal datetime null,") + "NroLinea char(6) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Codigo varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "Descripcion varchar(51) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "Grupo varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "NomGrupo varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "CantOE numeric(20,8) not null,") + "CantArmado numeric(20,8) not null," + "Cliente varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "NroOV char(10) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "Observaciones varchar(71) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "TiempoAsig varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "OpRecoleccion varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "OpArmado varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "OpPrueba varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "OpEmbalaje varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "TRecoleccion numeric(5,0) null,") + "TArmado numeric(5,0) null," + "TPrueba numeric(5,0) null,") + "TEmbalaje numeric(5,0) null," + "Obs varchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS not null)", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpRegPedExp' and type='U') DROP table " + this.editCodigo.Text + "TmpRegPedExp", connection).ExecuteNonQuery();
            new SqlCommand(((((((("create table dbo." + this.editCodigo.Text + "TmpRegPedExp(") + "Tipo int not null," + "Cliente varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "NomCli varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "OCCliente varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "NroOV char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "NroOCProv char(10) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "NomProv varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "FEntPed datetime not null,") + "FEntConf datetime not null," + "PaisDest varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "Moneda varchar(3) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "MontoOV numeric(28,8) null,") + "ImpAFac numeric(28,8) null," + "FormaDesp varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS null)", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpOVCli' and type='U') DROP table " + this.editCodigo.Text + "TmpOVCli", connection).ExecuteNonQuery();
            new SqlCommand(((("create table dbo." + this.editCodigo.Text + "TmpOVCli(") + "NroOV char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Almacen varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "NomAlmacen varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Moneda varchar(3) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "CondPago char(30) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "CondEnt char(30) COLLATE SQL_Latin1_General_CP1_CI_AS null)", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpOVFcProExp' and type='U') DROP table " + this.editCodigo.Text + "TmpOVFcProExp", connection).ExecuteNonQuery();
            new SqlCommand((((("create table dbo." + this.editCodigo.Text + "TmpOVFcProExp(") + "NroOV char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Almacen varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "NomAlmacen varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Flete numeric(10,2) not null,") + "Tipo char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Moneda varchar(3) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "CondPago char(30) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "CondEnt char(30) COLLATE SQL_Latin1_General_CP1_CI_AS null)", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpCodReemp' and type='U') DROP table " + this.editCodigo.Text + "TmpCodReemp", connection).ExecuteNonQuery();
            new SqlCommand(("create table dbo." + this.editCodigo.Text + "TmpCodReemp(") + "Codigo varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "CodReemplazo varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null)", connection).ExecuteNonQuery();
            new SqlCommand("CREATE  INDEX [IX_" + this.editCodigo.Text + "TmpCodReemp] ON [dbo].[" + this.editCodigo.Text + "TmpCodReemp]([CodReemplazo]) ON [PRIMARY]", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpOCompraExp' and type='U') DROP table " + this.editCodigo.Text + "TmpOCompraExp", connection).ExecuteNonQuery();
            new SqlCommand((((("create table dbo." + this.editCodigo.Text) + "TmpOCompraExp(" + "NroLinea char(6) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "Codigo varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Descripcion varchar(51) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "CantidadOV numeric(20,8) not null," + "CodProv varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "NomProv varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Seleccion bit not null)", connection).ExecuteNonQuery();
            new SqlCommand("ALTER TABLE " + this.editCodigo.Text + "TmpOCompraExp WITH NOCHECK ADD CONSTRAINT [PK_" + this.editCodigo.Text + "TmpOCompraExp] PRIMARY KEY  CLUSTERED ([NroLinea])  ON [PRIMARY] ", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpOCConfPend' and type='U') DROP table " + this.editCodigo.Text + "TmpOCConfPend", connection).ExecuteNonQuery();
            new SqlCommand((((((("create table dbo." + this.editCodigo.Text + "TmpOCConfPend(") + "CodProv varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "NomProv varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "NroOC char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "FechaOC datetime not null,") + "FEntSolic datetime not null," + "FEntConf datetime null,") + "Codigo varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Descripcion varchar(51) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "Cantidad numeric(20,8) not null," + "FormaDesp varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "Destinatario varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "EnTransito char(1) COLLATE SQL_Latin1_General_CP1_CI_AS null)", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpOCManual' and type='U') DROP table " + this.editCodigo.Text + "TmpOCManual", connection).ExecuteNonQuery();
            new SqlCommand((((("create table dbo." + this.editCodigo.Text + "TmpOCManual(") + "NroOC char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "NroLinea char(6) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "Codigo varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Desc1 varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS null,") + "Desc2 varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS null," + "CantOC numeric(20,8) not null,") + "CantRec numeric(20,8) not null," + "PaisOrigen char(11) COLLATE SQL_Latin1_General_CP1_CI_AS null)", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpItemFcProExp' and type='U') DROP table " + this.editCodigo.Text + "TmpItemFcProExp", connection).ExecuteNonQuery();
            new SqlCommand((((("create table dbo." + this.editCodigo.Text + "TmpItemFcProExp(") + "NroOV char(10) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Linea char(6) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "Codigo varchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Descripcion varchar(51) COLLATE SQL_Latin1_General_CP1_CI_AS not null,") + "Cantidad numeric(20,8) not null," + "FechaConf datetime not null,") + "PrecioUnit numeric(28,8) not null," + "Seleccion bit not null)", connection).ExecuteNonQuery();
            new SqlCommand("ALTER TABLE " + this.editCodigo.Text + "TmpItemFcProExp WITH NOCHECK ADD CONSTRAINT [PK_" + this.editCodigo.Text + "TmpItemFcProExp] PRIMARY KEY  CLUSTERED ([NroOV],[Linea])  ON [PRIMARY] ", connection).ExecuteNonQuery();
            new SqlCommand("if exists (select * from sysobjects where name='" + this.editCodigo.Text + "TmpMetEnvio' and type='U') DROP table " + this.editCodigo.Text + "TmpMetEnvio", connection).ExecuteNonQuery();
            new SqlCommand(("create table dbo." + this.editCodigo.Text + "TmpMetEnvio(") + "MetEnvio char(33) COLLATE SQL_Latin1_General_CP1_CI_AS not null," + "Seleccion bit not null)", connection).ExecuteNonQuery();
            connection.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void editCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.btnUpdate.Focus();
            }
        }

        private void editCodigo_TextChanged(object sender, EventArgs e)
        {
        }

        public void FillDataSet(DataTermi dataSet)
        {
            dataSet.EnforceConstraints = false;
            try
            {
                this.OleDbConnection1.Open();
                this.OleDbDataAdapter1.Fill(dataSet);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                throw exception;
                ProjectData.ClearProjectError();
            }
            finally
            {
                dataSet.EnforceConstraints = true;
                this.OleDbConnection1.Close();
            }
        }

        private void frmTerminales_Closed(object sender, EventArgs e)
        {
            new frmMenuPpal().Show();
        }

        private void frmTerminales_Load(object sender, EventArgs e)
        {
            try
            {
                this.OleDbConnection1.ConnectionString = "User ID=teleprinter;Password=tele;Data Source=" + Variables.gServer + ";Tag with column collation when possible=False;Initial Catalog=Colector;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=SQLOLEDB.1;Use Encryption for Data=False;Packet Size=4096";
                this.OleDbDataAdapter1.SelectCommand.CommandText = "Select * from Terminales order by Codigo";
                this.LoadDataSet();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                MessageBox.Show(exception.Message);
                ProjectData.ClearProjectError();
            }
            this.objDataTermi_PositionChanged();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.OleDbDataAdapter1 = new OleDbDataAdapter();
            this.objDataTermi = new DataTermi();
            this.lblCodigo = new Label();
            this.editCodigo = new TextBox();
            this.btnNavFirst = new Button();
            this.btnNavPrev = new Button();
            this.lblNavLocation = new Label();
            this.btnNavNext = new Button();
            this.btnLast = new Button();
            this.btnListado = new Button();
            this.btnSalir = new Button();
            this.btnUpdate = new Button();
            this.btnAdd = new Button();
            this.btnDelete = new Button();
            this.btnCancel = new Button();
            this.btnUpdTodo = new Button();
            this.OleDbConnection1 = new OleDbConnection();
            this.OleDbSelectCommand1 = new OleDbCommand();
            this.OleDbInsertCommand1 = new OleDbCommand();
            this.OleDbUpdateCommand1 = new OleDbCommand();
            this.OleDbDeleteCommand1 = new OleDbCommand();
            this.objDataTermi.BeginInit();
            this.SuspendLayout();
            this.OleDbDataAdapter1.DeleteCommand = this.OleDbDeleteCommand1;
            this.OleDbDataAdapter1.InsertCommand = this.OleDbInsertCommand1;
            this.OleDbDataAdapter1.SelectCommand = this.OleDbSelectCommand1;
            this.OleDbDataAdapter1.TableMappings.AddRange(new DataTableMapping[] { new DataTableMapping("Table", "Terminales", new DataColumnMapping[] { new DataColumnMapping("Codigo", "Codigo") }) });
            this.OleDbDataAdapter1.UpdateCommand = this.OleDbUpdateCommand1;
            this.objDataTermi.DataSetName = "DataTermi";
            this.objDataTermi.Locale = new CultureInfo("es-AR");
            this.lblCodigo.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Point point = new Point(8, 0x10);
            this.lblCodigo.Location = point;
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Terminal";
            this.editCodigo.BackColor = SystemColors.Window;
            this.editCodigo.DataBindings.Add(new Binding("Text", this.objDataTermi, "Terminales.Codigo"));
            this.editCodigo.Enabled = false;
            this.editCodigo.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(120, 0x10);
            this.editCodigo.Location = point;
            this.editCodigo.MaxLength = 6;
            this.editCodigo.Name = "editCodigo";
            this.editCodigo.TabIndex = 1;
            this.editCodigo.Text = "";
            this.btnNavFirst.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x60);
            this.btnNavFirst.Location = point;
            this.btnNavFirst.Name = "btnNavFirst";
            Size size = new Size(40, 0x17);
            this.btnNavFirst.Size = size;
            this.btnNavFirst.TabIndex = 11;
            this.btnNavFirst.Text = "<<";
            this.btnNavPrev.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x30, 0x60);
            this.btnNavPrev.Location = point;
            this.btnNavPrev.Name = "btnNavPrev";
            size = new Size(0x23, 0x17);
            this.btnNavPrev.Size = size;
            this.btnNavPrev.TabIndex = 12;
            this.btnNavPrev.Text = "<";
            this.lblNavLocation.BackColor = Color.White;
            this.lblNavLocation.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x58, 0x60);
            this.lblNavLocation.Location = point;
            this.lblNavLocation.Name = "lblNavLocation";
            size = new Size(0x198, 0x17);
            this.lblNavLocation.Size = size;
            this.lblNavLocation.TabIndex = 13;
            this.lblNavLocation.Text = "Sin registros";
            this.lblNavLocation.TextAlign = ContentAlignment.MiddleCenter;
            this.btnNavNext.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x1f8, 0x60);
            this.btnNavNext.Location = point;
            this.btnNavNext.Name = "btnNavNext";
            size = new Size(0x23, 0x17);
            this.btnNavNext.Size = size;
            this.btnNavNext.TabIndex = 14;
            this.btnNavNext.Text = ">";
            this.btnLast.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x218, 0x60);
            this.btnLast.Location = point;
            this.btnLast.Name = "btnLast";
            size = new Size(40, 0x17);
            this.btnLast.Size = size;
            this.btnLast.TabIndex = 15;
            this.btnLast.Text = ">>";
            this.btnListado.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x1a8, 0x38);
            this.btnListado.Location = point;
            this.btnListado.Name = "btnListado";
            size = new Size(0x48, 0x17);
            this.btnListado.Size = size;
            this.btnListado.TabIndex = 9;
            this.btnListado.Text = "&Listado";
            this.btnSalir.DialogResult = DialogResult.Cancel;
            this.btnSalir.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x1f8, 0x38);
            this.btnSalir.Location = point;
            this.btnSalir.Name = "btnSalir";
            size = new Size(0x48, 0x17);
            this.btnSalir.Size = size;
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "&Salir";
            this.btnUpdate.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0xa8, 0x38);
            this.btnUpdate.Location = point;
            this.btnUpdate.Name = "btnUpdate";
            size = new Size(80, 0x17);
            this.btnUpdate.Size = size;
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Act&ualizar";
            this.btnAdd.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x38);
            this.btnAdd.Location = point;
            this.btnAdd.Name = "btnAdd";
            size = new Size(0x48, 0x17);
            this.btnAdd.Size = size;
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "&Agregar";
            this.btnDelete.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x58, 0x38);
            this.btnDelete.Location = point;
            this.btnDelete.Name = "btnDelete";
            size = new Size(0x48, 0x17);
            this.btnDelete.Size = size;
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "&Eliminar";
            this.btnCancel.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x158, 0x38);
            this.btnCancel.Location = point;
            this.btnCancel.Name = "btnCancel";
            size = new Size(0x48, 0x17);
            this.btnCancel.Size = size;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancelar";
            this.btnUpdTodo.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x100, 0x38);
            this.btnUpdTodo.Location = point;
            this.btnUpdTodo.Name = "btnUpdTodo";
            size = new Size(80, 0x17);
            this.btnUpdTodo.Size = size;
            this.btnUpdTodo.TabIndex = 7;
            this.btnUpdTodo.Text = "Act. &Todo";
            this.OleDbConnection1.ConnectionString = "User ID=Teleprinter;Data Source=SERVERSQL;Tag with column collation when possible=False;Initial Catalog=Colector;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=\"SQLOLEDB.1\";Workstation ID=MARISA;Use Encryption for Data=False;Packet Size=4096";
            this.OleDbSelectCommand1.CommandText = "SELECT Codigo FROM dbo.Terminales";
            this.OleDbSelectCommand1.Connection = this.OleDbConnection1;
            this.OleDbInsertCommand1.CommandText = "INSERT INTO dbo.Terminales(Codigo) VALUES (?); SELECT Codigo FROM dbo.Terminales WHERE (Codigo = ?)";
            this.OleDbInsertCommand1.Connection = this.OleDbConnection1;
            this.OleDbInsertCommand1.Parameters.Add(new OleDbParameter("Codigo", OleDbType.VarChar, 6, "Codigo"));
            this.OleDbInsertCommand1.Parameters.Add(new OleDbParameter("Select_Codigo", OleDbType.VarChar, 6, "Codigo"));
            this.OleDbUpdateCommand1.CommandText = "UPDATE dbo.Terminales SET Codigo = ? WHERE (Codigo = ?); SELECT Codigo FROM dbo.Terminales WHERE (Codigo = ?)";
            this.OleDbUpdateCommand1.Connection = this.OleDbConnection1;
            this.OleDbUpdateCommand1.Parameters.Add(new OleDbParameter("Codigo", OleDbType.VarChar, 6, "Codigo"));
            this.OleDbUpdateCommand1.Parameters.Add(new OleDbParameter("Original_Codigo", OleDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "Codigo", DataRowVersion.Original, null));
            this.OleDbUpdateCommand1.Parameters.Add(new OleDbParameter("Select_Codigo", OleDbType.VarChar, 6, "Codigo"));
            this.OleDbDeleteCommand1.CommandText = "DELETE FROM dbo.Terminales WHERE (Codigo = ?)";
            this.OleDbDeleteCommand1.Connection = this.OleDbConnection1;
            this.OleDbDeleteCommand1.Parameters.Add(new OleDbParameter("Original_Codigo", OleDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "Codigo", DataRowVersion.Original, null));
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.btnSalir;
            size = new Size(600, 0xdf);
            this.ClientSize = size;
            this.Controls.Add(this.btnUpdTodo);
            this.Controls.Add(this.btnListado);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.editCodigo);
            this.Controls.Add(this.btnNavFirst);
            this.Controls.Add(this.btnNavPrev);
            this.Controls.Add(this.lblNavLocation);
            this.Controls.Add(this.btnNavNext);
            this.Controls.Add(this.btnLast);
            this.Name = "frmTerminales";
            this.Text = "Terminales";
            this.WindowState = FormWindowState.Maximized;
            this.objDataTermi.EndInit();
            this.ResumeLayout(false);
        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {
        }

        private void lblNavLocation_Click(object sender, EventArgs e)
        {
        }

        public void LoadDataSet()
        {
            DataTermi dataSet = new DataTermi();
            try
            {
                this.FillDataSet(dataSet);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                throw exception;
                ProjectData.ClearProjectError();
            }
            try
            {
                this.objDataTermi.Clear();
                this.objDataTermi.Merge(dataSet);
            }
            catch (Exception exception3)
            {
                ProjectData.SetProjectError(exception3);
                Exception exception2 = exception3;
                throw exception2;
                ProjectData.ClearProjectError();
            }
        }

        private void objDataTermi_PositionChanged()
        {
            this.lblNavLocation.Text = ((this.BindingContext[this.objDataTermi, "Terminales"].Position + 1)).ToString() + " de  " + this.BindingContext[this.objDataTermi, "Terminales"].Count.ToString();
        }

        public void UpdateDataSet()
        {
            DataTermi changedRows = new DataTermi();
            this.BindingContext[this.objDataTermi, "Terminales"].EndCurrentEdit();
            changedRows = (DataTermi) this.objDataTermi.GetChanges();
            if (changedRows != null)
            {
                try
                {
                    this.UpdateDataSource(changedRows);
                    this.objDataTermi.Merge(changedRows);
                    this.objDataTermi.AcceptChanges();
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    throw exception;
                    ProjectData.ClearProjectError();
                }
            }
        }

        public void UpdateDataSource(DataTermi ChangedRows)
        {
            try
            {
                if (ChangedRows != null)
                {
                    this.OleDbConnection1.Open();
                    this.OleDbDataAdapter1.Update(ChangedRows);
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                throw exception;
                ProjectData.ClearProjectError();
            }
            finally
            {
                this.OleDbConnection1.Close();
            }
        }

        internal virtual Button btnAdd
        {
            get
            {
                return this._btnAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnAdd != null)
                {
                    this._btnAdd.Click -= new EventHandler(this.btnAdd_Click_1);
                }
                this._btnAdd = value;
                if (this._btnAdd != null)
                {
                    this._btnAdd.Click += new EventHandler(this.btnAdd_Click_1);
                }
            }
        }

        internal virtual Button btnCancel
        {
            get
            {
                return this._btnCancel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnCancel != null)
                {
                    this._btnCancel.Click -= new EventHandler(this.btnCancel_Click_1);
                }
                this._btnCancel = value;
                if (this._btnCancel != null)
                {
                    this._btnCancel.Click += new EventHandler(this.btnCancel_Click_1);
                }
            }
        }

        internal virtual Button btnDelete
        {
            get
            {
                return this._btnDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnDelete != null)
                {
                    this._btnDelete.Click -= new EventHandler(this.btnDelete_Click_1);
                }
                this._btnDelete = value;
                if (this._btnDelete != null)
                {
                    this._btnDelete.Click += new EventHandler(this.btnDelete_Click_1);
                }
            }
        }

        internal virtual Button btnLast
        {
            get
            {
                return this._btnLast;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnLast != null)
                {
                    this._btnLast.Click -= new EventHandler(this.btnLast_Click);
                }
                this._btnLast = value;
                if (this._btnLast != null)
                {
                    this._btnLast.Click += new EventHandler(this.btnLast_Click);
                }
            }
        }

        internal virtual Button btnListado
        {
            get
            {
                return this._btnListado;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnListado != null)
                {
                    this._btnListado.Click -= new EventHandler(this.btnListado_Click);
                }
                this._btnListado = value;
                if (this._btnListado != null)
                {
                    this._btnListado.Click += new EventHandler(this.btnListado_Click);
                }
            }
        }

        internal virtual Button btnNavFirst
        {
            get
            {
                return this._btnNavFirst;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnNavFirst != null)
                {
                    this._btnNavFirst.Click -= new EventHandler(this.btnNavFirst_Click);
                }
                this._btnNavFirst = value;
                if (this._btnNavFirst != null)
                {
                    this._btnNavFirst.Click += new EventHandler(this.btnNavFirst_Click);
                }
            }
        }

        internal virtual Button btnNavNext
        {
            get
            {
                return this._btnNavNext;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnNavNext != null)
                {
                    this._btnNavNext.Click -= new EventHandler(this.btnNavNext_Click);
                }
                this._btnNavNext = value;
                if (this._btnNavNext != null)
                {
                    this._btnNavNext.Click += new EventHandler(this.btnNavNext_Click);
                }
            }
        }

        internal virtual Button btnNavPrev
        {
            get
            {
                return this._btnNavPrev;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnNavPrev != null)
                {
                    this._btnNavPrev.Click -= new EventHandler(this.btnNavPrev_Click);
                }
                this._btnNavPrev = value;
                if (this._btnNavPrev != null)
                {
                    this._btnNavPrev.Click += new EventHandler(this.btnNavPrev_Click);
                }
            }
        }

        internal virtual Button btnSalir
        {
            get
            {
                return this._btnSalir;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnSalir != null)
                {
                    this._btnSalir.Click -= new EventHandler(this.btnSalir_Click);
                }
                this._btnSalir = value;
                if (this._btnSalir != null)
                {
                    this._btnSalir.Click += new EventHandler(this.btnSalir_Click);
                }
            }
        }

        internal virtual Button btnUpdate
        {
            get
            {
                return this._btnUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnUpdate != null)
                {
                    this._btnUpdate.Click -= new EventHandler(this.btnUpdate_Click_1);
                }
                this._btnUpdate = value;
                if (this._btnUpdate != null)
                {
                    this._btnUpdate.Click += new EventHandler(this.btnUpdate_Click_1);
                }
            }
        }

        internal virtual Button btnUpdTodo
        {
            get
            {
                return this._btnUpdTodo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnUpdTodo != null)
                {
                    this._btnUpdTodo.Click -= new EventHandler(this.btnUpdTodo_Click);
                }
                this._btnUpdTodo = value;
                if (this._btnUpdTodo != null)
                {
                    this._btnUpdTodo.Click += new EventHandler(this.btnUpdTodo_Click);
                }
            }
        }

        internal virtual TextBox editCodigo
        {
            get
            {
                return this._editCodigo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editCodigo != null)
                {
                    this._editCodigo.KeyPress -= new KeyPressEventHandler(this.editCodigo_KeyPress);
                    this._editCodigo.TextChanged -= new EventHandler(this.editCodigo_TextChanged);
                }
                this._editCodigo = value;
                if (this._editCodigo != null)
                {
                    this._editCodigo.KeyPress += new KeyPressEventHandler(this.editCodigo_KeyPress);
                    this._editCodigo.TextChanged += new EventHandler(this.editCodigo_TextChanged);
                }
            }
        }

        internal virtual Label lblCodigo
        {
            get
            {
                return this._lblCodigo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._lblCodigo != null)
                {
                    this._lblCodigo.Click -= new EventHandler(this.lblCodigo_Click);
                }
                this._lblCodigo = value;
                if (this._lblCodigo != null)
                {
                    this._lblCodigo.Click += new EventHandler(this.lblCodigo_Click);
                }
            }
        }

        internal virtual Label lblNavLocation
        {
            get
            {
                return this._lblNavLocation;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._lblNavLocation != null)
                {
                    this._lblNavLocation.Click -= new EventHandler(this.lblNavLocation_Click);
                }
                this._lblNavLocation = value;
                if (this._lblNavLocation != null)
                {
                    this._lblNavLocation.Click += new EventHandler(this.lblNavLocation_Click);
                }
            }
        }

        internal virtual DataTermi objDataTermi
        {
            get
            {
                return this._objDataTermi;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._objDataTermi != null)
                {
                }
                this._objDataTermi = value;
                if (this._objDataTermi != null)
                {
                }
            }
        }

        internal virtual OleDbConnection OleDbConnection1
        {
            get
            {
                return this._OleDbConnection1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._OleDbConnection1 != null)
                {
                }
                this._OleDbConnection1 = value;
                if (this._OleDbConnection1 != null)
                {
                }
            }
        }

        internal virtual OleDbDataAdapter OleDbDataAdapter1
        {
            get
            {
                return this._OleDbDataAdapter1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._OleDbDataAdapter1 != null)
                {
                }
                this._OleDbDataAdapter1 = value;
                if (this._OleDbDataAdapter1 != null)
                {
                }
            }
        }

        internal virtual OleDbCommand OleDbDeleteCommand1
        {
            get
            {
                return this._OleDbDeleteCommand1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._OleDbDeleteCommand1 != null)
                {
                }
                this._OleDbDeleteCommand1 = value;
                if (this._OleDbDeleteCommand1 != null)
                {
                }
            }
        }

        internal virtual OleDbCommand OleDbInsertCommand1
        {
            get
            {
                return this._OleDbInsertCommand1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._OleDbInsertCommand1 != null)
                {
                }
                this._OleDbInsertCommand1 = value;
                if (this._OleDbInsertCommand1 != null)
                {
                }
            }
        }

        internal virtual OleDbCommand OleDbSelectCommand1
        {
            get
            {
                return this._OleDbSelectCommand1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._OleDbSelectCommand1 != null)
                {
                }
                this._OleDbSelectCommand1 = value;
                if (this._OleDbSelectCommand1 != null)
                {
                }
            }
        }

        internal virtual OleDbCommand OleDbUpdateCommand1
        {
            get
            {
                return this._OleDbUpdateCommand1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._OleDbUpdateCommand1 != null)
                {
                }
                this._OleDbUpdateCommand1 = value;
                if (this._OleDbUpdateCommand1 != null)
                {
                }
            }
        }
    }
}

