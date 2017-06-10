namespace SistemaPC
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Windows.Forms;
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

    public class frmRepOCConfPend1 : Form
    {
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("CrystalReportViewer1")]
        private CrystalReportViewer _CrystalReportViewer1;
        public SqlDataAdapter AdapDetDes;
        public SqlDataAdapter AdapPC01;
        public SqlDataAdapter AdapPC03;
        public SqlDataAdapter AdapPL01;
        public SqlDataAdapter AdapPL23;
        public SqlDataAdapter AdapSL01;
        public SqlDataAdapter AdapTmp;
        public SqlDataAdapter AdapTmp1;
        private IContainer components;
        public DataSet DS;
        public DataSet DS1;
        public ReportDocument Informe;

        public frmRepOCConfPend1()
        {
            base.Closed += new EventHandler(this.frmRepOCConfPend1_Closed);
            base.Load += new EventHandler(this.frmRepOCConfPend1_Load);
            this.Informe = new ReportDocument();
            this.DS = new DataSet();
            this.DS1 = new DataSet();
            this.InitializeComponent();
            bool flag = false;
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
            string str4 = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=edibar;persist security info=False;packet size=4096";
            this.DS.Clear();
            this.DS1.Clear();
            string selectCommandText = "SELECT PC01001,PC01003,PC01004,PC01014,PC01015,PC01016,PC03001,PC03005,PC03006,PC03007,PC03010,PC03011,PC03016,SL01001,SL01002,PL01001,PL01002,PL23003,PL23004,ordnb,lignb FROM dbo.PC010100 inner join PC030100 on PC01001=PC03001 inner join PL010100 on PC01003=PL01001 left outer join SL010100 on PC01004=SL01001 inner join PL230100 on PC01014=PL23003 LEFT OUTER JOIN edibar.dbo.detdes ON PC030100.PC03001 = edibar.dbo.detdes.ordnb AND PC030100.PC03002 = edibar.dbo.detdes.lignb where PC01001>'0000014500' and PC03011<PC03010 and PC03029='1' and PL23001='2' and PL23002='00'";
            if (StringType.StrCmp(Variables.gCodProv, "", false) != 0)
            {
                selectCommandText = selectCommandText + " and PC01003='" + Variables.gCodProv + "'";
            }
            if (StringType.StrCmp(Variables.gCodMetEnt, "", false) != 0)
            {
                selectCommandText = selectCommandText + " and PC01014=" + Variables.gCodMetEnt;
            }
            if (StringType.StrCmp(Variables.gCodAlmacen, "", false) != 0)
            {
                selectCommandText = selectCommandText + " and PC03035='" + Variables.gCodAlmacen + "'";
            }
            if (Variables.gNoDespachado)
            {
                selectCommandText = selectCommandText + " and edibar.dbo.detdes.ordnb is null";
            }
            this.AdapPC01 = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.AdapPC01.Fill(this.DS1, "PC010100");
            string connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            flag = true;
            SqlCommand command = new SqlCommand("delete " + Variables.gTermi + "TmpOCConfPend", connection);
            int num2 = command.ExecuteNonQuery();
            int num3 = this.DS1.Tables["PC010100"].Rows.Count - 1;
            for (int i = 0; i <= num3; i++)
            {
                DataRow row = this.DS1.Tables["PC010100"].Rows[i];
                if (DateAndTime.DateDiff(4, DateType.FromObject(row["PC01016"]), DateType.FromObject(row["PC03016"]), 1, 1) >= Variables.gDiasDif)
                {
                    selectCommandText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpOCConfPend (CodProv,NomProv,NroOC,FechaOC,FEntSolic,FEntConf,Codigo,Descripcion,Cantidad,FormaDesp,Destinatario,EnTransito) values ('", row["PC01003"]), "','"), row["PL01002"]), "','"), row["PC01001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["PC01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["PC01016"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["PC03016"]), "MM/dd/yyyy")), "','"), row["PC03005"]), "','"), Strings.Trim(StringType.FromObject(row["PC03006"]))), " "), Strings.Trim(StringType.FromObject(row["PC03007"]))), "',"), ObjectType.SubObj(row["PC03010"], row["PC03011"])), ",'"), row["PL23004"]), "',"));
                    if (ObjectType.ObjTst(row["PC01004"], "+", false) == 0)
                    {
                        selectCommandText = selectCommandText + "'BGA',";
                    }
                    else
                    {
                        selectCommandText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(selectCommandText + "'", row["SL01002"]), "',"));
                    }
                    if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["ordnb"])))
                    {
                        selectCommandText = selectCommandText + "'N')";
                    }
                    else
                    {
                        selectCommandText = selectCommandText + "'S')";
                    }
                    command = new SqlCommand(selectCommandText, connection);
                    try
                    {
                        command.ExecuteNonQuery();
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
            }
            connection.Close();
            flag = false;
            selectCommandText = "select * from " + Variables.gTermi + "TmpOCConfPend as PC1TmpOCConfPend";
            this.AdapTmp = new SqlDataAdapter(selectCommandText, connectionString);
            this.AdapTmp.Fill(this.DS, "PC1TmpOCConfPend");
            this.Informe.Load(Application.StartupPath + @"\repocconfpend.rpt");
            this.Informe.SetDataSource(this.DS);
            FormulaFieldDefinitions definitions = this.Informe.get_DataDefinition().get_FormulaFields();
            FormulaFieldDefinition definition = definitions.get_Item("almacen");
            if (StringType.StrCmp(Variables.gCodAlmacen, Strings.Space(0), false) != 0)
            {
                definition.set_Text("'Almacen: " + Strings.Trim(Variables.gNomAlmacen) + "'");
            }
            else
            {
                definition.set_Text("'Todos los almacenes'");
            }
            FormulaFieldDefinition definition2 = definitions.get_Item("formadesp");
            if (StringType.StrCmp(Variables.gCodMetEnt, Strings.Space(0), false) != 0)
            {
                definition2.set_Text("'Forma Despacho: " + Strings.Trim(Variables.gDescMetEnt) + "'");
            }
            else
            {
                definition2.set_Text("'Todos las formas de despacho'");
            }
            definitions.get_Item("diasdif").set_Text("'" + Strings.Format(Variables.gDiasDif, "###0") + "'");
            FormulaFieldDefinition definition4 = definitions.get_Item("nodesp");
            if (Variables.gNoDespachado)
            {
                definition4.set_Text("'Solamente los items con tr\x00e1nsito no registrado'");
            }
            else
            {
                definition4.set_Text("'Items despachados y no despachados'");
            }
            this.CrystalReportViewer1.set_ShowGroupTreeButton(true);
            this.CrystalReportViewer1.set_ReportSource(this.Informe);
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
        }

        private void CrystalReportViewer1_ReportRefresh(object source, ViewerEventArgs e)
        {
            bool flag = false;
            this.cmbSalir.Enabled = false;
            this.Informe.Close();
            this.DS.Clear();
            this.DS1.Clear();
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
            string str4 = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=edibar;persist security info=False;packet size=4096";
            this.DS.Clear();
            this.DS1.Clear();
            string selectCommandText = "SELECT PC01001,PC01003,PC01004,PC01014,PC01015,PC01016,PC03001,PC03005,PC03006,PC03007,PC03010,PC03011,PC03016,SL01001,SL01002,PL01001,PL01002,PL23003,PL23004,ordnb,lignb FROM dbo.PC010100 inner join PC030100 on PC01001=PC03001 inner join PL010100 on PC01003=PL01001 left outer join SL010100 on PC01004=SL01001 inner join PL230100 on PC01014=PL23003 LEFT OUTER JOIN edibar.dbo.detdes ON PC030100.PC03001 = edibar.dbo.detdes.ordnb AND PC030100.PC03002 = edibar.dbo.detdes.lignb where PC01001>'0000014500' and PC03011<PC03010 and PC03029='1' and PL23001='2' and PL23002='00'";
            if (StringType.StrCmp(Variables.gCodProv, "", false) != 0)
            {
                selectCommandText = selectCommandText + " and PC01003='" + Variables.gCodProv + "'";
            }
            if (StringType.StrCmp(Variables.gCodMetEnt, "", false) != 0)
            {
                selectCommandText = selectCommandText + " and PC01014=" + Variables.gCodMetEnt;
            }
            if (StringType.StrCmp(Variables.gCodAlmacen, "", false) != 0)
            {
                selectCommandText = selectCommandText + " and PC03035='" + Variables.gCodAlmacen + "'";
            }
            if (Variables.gNoDespachado)
            {
                selectCommandText = selectCommandText + " and edibar.dbo.detdes.ordnb is null";
            }
            this.AdapPC01 = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.AdapPC01.Fill(this.DS1, "PC010100");
            string connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            flag = true;
            SqlCommand command = new SqlCommand("delete " + Variables.gTermi + "TmpOCConfPend", connection);
            int num2 = command.ExecuteNonQuery();
            int num3 = this.DS1.Tables["PC010100"].Rows.Count - 1;
            for (int i = 0; i <= num3; i++)
            {
                DataRow row = this.DS1.Tables["PC010100"].Rows[i];
                if (DateAndTime.DateDiff(4, DateType.FromObject(row["PC01016"]), DateType.FromObject(row["PC03016"]), 1, 1) >= Variables.gDiasDif)
                {
                    selectCommandText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpOCConfPend (CodProv,NomProv,NroOC,FechaOC,FEntSolic,FEntConf,Codigo,Descripcion,Cantidad,FormaDesp,Destinatario,EnTransito) values ('", row["PC01003"]), "','"), row["PL01002"]), "','"), row["PC01001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["PC01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["PC01016"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["PC03016"]), "MM/dd/yyyy")), "','"), row["PC03005"]), "','"), Strings.Trim(StringType.FromObject(row["PC03006"]))), " "), Strings.Trim(StringType.FromObject(row["PC03007"]))), "',"), ObjectType.SubObj(row["PC03010"], row["PC03011"])), ",'"), row["PL23004"]), "',"));
                    if (ObjectType.ObjTst(row["PC01004"], "+", false) == 0)
                    {
                        selectCommandText = selectCommandText + "'BGA',";
                    }
                    else
                    {
                        selectCommandText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(selectCommandText + "'", row["SL01002"]), "',"));
                    }
                    if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["ordnb"])))
                    {
                        selectCommandText = selectCommandText + "'N')";
                    }
                    else
                    {
                        selectCommandText = selectCommandText + "'S')";
                    }
                    command = new SqlCommand(selectCommandText, connection);
                    try
                    {
                        command.ExecuteNonQuery();
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
            }
            connection.Close();
            flag = false;
            selectCommandText = "select * from " + Variables.gTermi + "TmpOCConfPend as PC1TmpOCConfPend";
            this.AdapTmp = new SqlDataAdapter(selectCommandText, connectionString);
            this.AdapTmp.Fill(this.DS, "PC1TmpOCConfPend");
            this.Informe.Load(Application.StartupPath + @"\repocconfpend.rpt");
            this.Informe.SetDataSource(this.DS);
            FormulaFieldDefinitions definitions = this.Informe.get_DataDefinition().get_FormulaFields();
            FormulaFieldDefinition definition = definitions.get_Item("almacen");
            if (StringType.StrCmp(Variables.gCodAlmacen, Strings.Space(0), false) != 0)
            {
                definition.set_Text("'Almacen: " + Strings.Trim(Variables.gNomAlmacen) + "'");
            }
            else
            {
                definition.set_Text("'Todos los almacenes'");
            }
            FormulaFieldDefinition definition2 = definitions.get_Item("formadesp");
            if (StringType.StrCmp(Variables.gCodMetEnt, Strings.Space(0), false) != 0)
            {
                definition2.set_Text("'Forma Despacho: " + Strings.Trim(Variables.gDescMetEnt) + "'");
            }
            else
            {
                definition2.set_Text("'Todos las formas de despacho'");
            }
            definitions.get_Item("diasdif").set_Text("'" + Strings.Format(Variables.gDiasDif, "###0") + "'");
            FormulaFieldDefinition definition4 = definitions.get_Item("nodesp");
            if (Variables.gNoDespachado)
            {
                definition4.set_Text("'Solamente los items no despachados'");
            }
            else
            {
                definition4.set_Text("'Items despachados y no despachados'");
            }
            this.CrystalReportViewer1.set_ShowGroupTreeButton(true);
            this.CrystalReportViewer1.set_ReportSource(this.Informe);
            this.CrystalReportViewer1.Refresh();
            this.cmbSalir.Enabled = true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        ~frmRepOCConfPend1()
        {
        }

        private void frmRepOCConfPend1_Closed(object sender, EventArgs e)
        {
        }

        private void frmRepOCConfPend1_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRepOCConfPend1));
            this.cmbSalir = new Button();
            this.CrystalReportViewer1 = new CrystalReportViewer();
            this.SuspendLayout();
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            Point point = new Point(0x390, 0x2a0);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            Size size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 3;
            this.cmbSalir.Text = "&Salir";
            this.CrystalReportViewer1.set_ActiveViewIndex(-1);
            this.CrystalReportViewer1.set_DisplayGroupTree(false);
            point = new Point(8, 8);
            this.CrystalReportViewer1.Location = point;
            this.CrystalReportViewer1.Name = "CrystalReportViewer1";
            this.CrystalReportViewer1.set_ReportSource(null);
            size = new Size(0x3f0, 640);
            this.CrystalReportViewer1.Size = size;
            this.CrystalReportViewer1.TabIndex = 0x36;
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.CrystalReportViewer1);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmRepOCConfPend1";
            this.Text = "Reporte O.Compra Confirmadas Pendientes";
            this.WindowState = FormWindowState.Maximized;
            this.ResumeLayout(false);
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

        internal virtual CrystalReportViewer CrystalReportViewer1
        {
            get
            {
                return this._CrystalReportViewer1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._CrystalReportViewer1 != null)
                {
                    this._CrystalReportViewer1.remove_ReportRefresh(new RefreshEventHandler(this, (IntPtr) this.CrystalReportViewer1_ReportRefresh));
                    this._CrystalReportViewer1.Load -= new EventHandler(this.CrystalReportViewer1_Load);
                }
                this._CrystalReportViewer1 = value;
                if (this._CrystalReportViewer1 != null)
                {
                    this._CrystalReportViewer1.add_ReportRefresh(new RefreshEventHandler(this, (IntPtr) this.CrystalReportViewer1_ReportRefresh));
                    this._CrystalReportViewer1.Load += new EventHandler(this.CrystalReportViewer1_Load);
                }
            }
        }
    }
}

