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

    public class frmRepOCPend1 : Form
    {
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("CrystalReportViewer1")]
        private CrystalReportViewer _CrystalReportViewer1;
        public SqlDataAdapter AdapDetDes;
        public SqlDataAdapter AdapOCPend;
        public SqlDataAdapter AdapTmp;
        private IContainer components;
        public DataSet DS;
        public DataSet DS1;
        public DataSet DSTmp;
        public ReportDocument Informe;

        public frmRepOCPend1()
        {
            string str;
            base.Closed += new EventHandler(this.frmRepOCPend1_Closed);
            base.Load += new EventHandler(this.frmRepOCPend1_Load);
            this.DS = new DataSet();
            this.DS1 = new DataSet();
            this.DSTmp = new DataSet();
            this.Informe = new ReportDocument();
            this.InitializeComponent();
            bool flag = false;
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
            if (StringType.StrCmp(Variables.gDesde, Strings.Space(0), false) == 0)
            {
                str = "Select PC03001,PC03002,PC03005,PC03006,PC03007,PC03010,PC03011,PC03016 from PC030100 where PC03010-PC03011<>0 and PC03010<>0";
                if (StringType.StrCmp(Variables.gAlmacen1, Strings.Space(0), false) != 0)
                {
                    str = str + " and PC03035='" + Strings.Mid(Variables.gAlmacen1, 1, 2) + "'";
                    if (StringType.StrCmp(Variables.gAlmacen2, Strings.Space(0), false) != 0)
                    {
                        str = str + " and PC03035='" + Strings.Mid(Variables.gAlmacen2, 1, 2) + "'";
                    }
                }
                else if (StringType.StrCmp(Variables.gAlmacen2, Strings.Space(0), false) != 0)
                {
                    str = str + " and PC03035='" + Strings.Mid(Variables.gAlmacen2, 1, 2) + "'";
                }
                if (StringType.StrCmp(Variables.gCodProd, "", false) != 0)
                {
                    str = str + " and PC03005='" + Variables.gCodProd + "'";
                }
                str = str + " order by PC03001,PC03016,PC03002";
            }
            else
            {
                str = "Select PC03001,PC03002,PC03005,PC03006,PC03007,PC03010,PC03011,PC03016 from PC030100 where PC03010-PC03011<>0 and PC03010<>0 and PC03016>='" + Strings.Format(DateType.FromString(Variables.gDesde), "MM/dd/yyyy") + "' and PC03016<='" + Strings.Format(DateType.FromString(Variables.gHasta), "MM/dd/yyyy") + "'";
                if (StringType.StrCmp(Variables.gAlmacen1, Strings.Space(0), false) != 0)
                {
                    if (StringType.StrCmp(Variables.gAlmacen2, Strings.Space(0), false) != 0)
                    {
                        str = (str + " and (PC03035='" + Strings.Mid(Variables.gAlmacen1, 1, 2) + "'") + " or PC03035='" + Strings.Mid(Variables.gAlmacen2, 1, 2) + "')";
                    }
                    else
                    {
                        str = str + " and PC03035='" + Strings.Mid(Variables.gAlmacen1, 1, 2) + "'";
                    }
                }
                else if (StringType.StrCmp(Variables.gAlmacen2, Strings.Space(0), false) != 0)
                {
                    str = str + " and PC03035='" + Strings.Mid(Variables.gAlmacen2, 1, 2) + "'";
                }
                if (StringType.StrCmp(Variables.gCodProd, "", false) != 0)
                {
                    str = str + " and PC03005='" + Variables.gCodProd + "'";
                }
                str = str + " order by PC03001,PC03016,PC03002";
            }
            this.DS.Clear();
            this.AdapOCPend = new SqlDataAdapter(str, selectConnectionString);
            this.AdapOCPend.Fill(this.DS, "PC030100");
            string str3 = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=edibar;persist security info=False;packet size=4096";
            str = "Select distinct detdes.colnb,detdes.ordnb,detdes.lignb,detdes.datexp,detinv.invno,detinv.stamp,detinv.desqty,hdrdes.trind from detdes left outer join detinv on detdes.ordnb=detinv.purno and detdes.lignb=detinv.purlin inner join hdrdes on detdes.packlist=hdrdes.packlist where detdes.cntqty=0";
            if (StringType.StrCmp(Variables.gCodProd, "", false) != 0)
            {
                str = str + " and detdes.itnbr='" + Variables.gCodProd + "'";
            }
            this.AdapDetDes = new SqlDataAdapter(str, str3);
            this.DS1.Clear();
            this.AdapDetDes.Fill(this.DS1, "detdes");
            string connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            flag = true;
            SqlCommand command = new SqlCommand("delete " + Variables.gTermi + "TmpDetDes", connection);
            int num2 = command.ExecuteNonQuery();
            int num3 = this.DS1.Tables["detdes"].Rows.Count - 1;
            for (int i = 0; i <= num3; i++)
            {
                DataRow row = this.DS1.Tables["detdes"].Rows[i];
                str = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj((("insert into " + Variables.gTermi + "TmpDetDes (NroOC,NroLinea,NroBulto,PackList,FechaPL,NroFC,FechaFC,EnTransito) values ('" + Strings.Format(RuntimeHelpers.GetObjectValue(row["ordnb"]), "0000000000")) + "','" + Strings.Format(RuntimeHelpers.GetObjectValue(row["lignb"]), "000000")) + "','", row["colnb"]), "','"), row["trind"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["datexp"]), "MM/dd/yyyy")), "',"));
                if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["invno"])))
                {
                    str = str + "'',";
                }
                else
                {
                    str = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(str + "'", row["invno"]), "',"));
                }
                if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["stamp"])))
                {
                    str = str + "'',";
                }
                else
                {
                    str = str + "'" + Strings.Format(DateType.FromString(Strings.Mid(StringType.FromObject(row["stamp"]), 1, 10)), "MM/dd/yyyy") + "',";
                }
                if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["desqty"])))
                {
                    str = str + "0)";
                }
                else
                {
                    str = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(str, row["desqty"]), ")"));
                }
                command = new SqlCommand(str, connection);
                try
                {
                    command.ExecuteNonQuery();
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
            }
            str = "select * from " + Variables.gTermi + "TmpDetDes as PC1TmpDetDes";
            this.AdapTmp = new SqlDataAdapter(str, connectionString);
            this.AdapTmp.Fill(this.DS, "PC1TmpDetDes");
            if (Variables.gOrdenList == 1)
            {
                this.Informe.Load(Application.StartupPath + @"\repocpend.rpt");
            }
            else
            {
                this.Informe.Load(Application.StartupPath + @"\repocpend1.rpt");
            }
            this.Informe.SetDataSource(this.DS);
            connection.Close();
            flag = false;
            FormulaFieldDefinitions formulaFields = this.Informe.DataDefinition.FormulaFields;
            FormulaFieldDefinition definition = formulaFields["desde"];
            if (StringType.StrCmp(Variables.gDesde, Strings.Space(0), false) == 0)
            {
                definition.Text = "'" + Variables.gDesde + "'";
            }
            else
            {
                definition.Text = "'" + Strings.Format(DateType.FromString(Variables.gDesde), "dd/MM/yyyy") + "'";
            }
            FormulaFieldDefinition definition2 = formulaFields["hasta"];
            if (StringType.StrCmp(Variables.gHasta, Strings.Space(0), false) == 0)
            {
                definition2.Text = "'" + Variables.gHasta + "'";
            }
            else
            {
                definition2.Text = "'" + Strings.Format(DateType.FromString(Variables.gHasta), "dd/MM/yyyy") + "'";
            }
            FormulaFieldDefinition definition3 = formulaFields["almacen"];
            if (StringType.StrCmp(Variables.gAlmacen1, Strings.Space(0), false) != 0)
            {
                if (StringType.StrCmp(Variables.gAlmacen2, Strings.Space(0), false) != 0)
                {
                    definition3.Text = "'Almacenes: " + Strings.Trim(Variables.gAlmacen1) + "-" + Strings.Trim(Variables.gAlmacen2) + "'";
                }
                else
                {
                    definition3.Text = "'Almacen: " + Strings.Trim(Variables.gAlmacen1) + "'";
                }
            }
            else if (StringType.StrCmp(Variables.gAlmacen2, Strings.Space(0), false) != 0)
            {
                definition3.Text = "'Almacen: " + Strings.Trim(Variables.gAlmacen2) + "'";
            }
            else
            {
                definition3.Text = "'Todos los almacenes'";
            }
            this.CrystalReportViewer1.ReportSource = this.Informe;
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
            string str;
            bool flag = false;
            this.cmbSalir.Enabled = false;
            this.Informe.Close();
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
            if (StringType.StrCmp(Variables.gDesde, Strings.Space(0), false) == 0)
            {
                str = "Select PC03001,PC03002,PC03005,PC03006,PC03007,PC03010,PC03011,PC03016 from PC030100 where PC03010-PC03011<>0 and PC03010<>0";
                if (StringType.StrCmp(Variables.gAlmacen1, Strings.Space(0), false) != 0)
                {
                    str = str + " and PC03035='" + Strings.Mid(Variables.gAlmacen1, 1, 2) + "'";
                    if (StringType.StrCmp(Variables.gAlmacen2, Strings.Space(0), false) != 0)
                    {
                        str = str + " and PC03035='" + Strings.Mid(Variables.gAlmacen2, 1, 2) + "'";
                    }
                }
                else if (StringType.StrCmp(Variables.gAlmacen2, Strings.Space(0), false) != 0)
                {
                    str = str + " and PC03035='" + Strings.Mid(Variables.gAlmacen2, 1, 2) + "'";
                }
                if (StringType.StrCmp(Variables.gCodProd, "", false) != 0)
                {
                    str = str + " and PC03005='" + Variables.gCodProd + "'";
                }
                str = str + " order by PC03001,PC03016,PC03002";
            }
            else
            {
                str = "Select PC03001,PC03002,PC03005,PC03006,PC03007,PC03010,PC03011,PC03016 from PC030100 where PC03010-PC03011<>0 and PC03010<>0 and PC03016>='" + Strings.Format(DateType.FromString(Variables.gDesde), "MM/dd/yyyy") + "' and PC03016<='" + Strings.Format(DateType.FromString(Variables.gHasta), "MM/dd/yyyy") + "'";
                if (StringType.StrCmp(Variables.gAlmacen1, Strings.Space(0), false) != 0)
                {
                    if (StringType.StrCmp(Variables.gAlmacen2, Strings.Space(0), false) != 0)
                    {
                        str = (str + " and (PC03035='" + Strings.Mid(Variables.gAlmacen1, 1, 2) + "'") + " or PC03035='" + Strings.Mid(Variables.gAlmacen2, 1, 2) + "')";
                    }
                    else
                    {
                        str = str + " and PC03035='" + Strings.Mid(Variables.gAlmacen1, 1, 2) + "'";
                    }
                }
                else if (StringType.StrCmp(Variables.gAlmacen2, Strings.Space(0), false) != 0)
                {
                    str = str + " and PC03035='" + Strings.Mid(Variables.gAlmacen2, 1, 2) + "'";
                }
                if (StringType.StrCmp(Variables.gCodProd, "", false) != 0)
                {
                    str = str + " and PC03005='" + Variables.gCodProd + "'";
                }
                str = str + " order by PC03001,PC03016,PC03002";
            }
            this.DS.Clear();
            this.AdapOCPend = new SqlDataAdapter(str, selectConnectionString);
            this.AdapOCPend.Fill(this.DS, "PC030100");
            string str3 = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=edibar;persist security info=False;packet size=4096";
            str = "Select distinct detdes.colnb,detdes.ordnb,detdes.lignb,detdes.datexp,detinv.invno,detinv.stamp,detinv.desqty,hdrdes.trind from detdes left outer join detinv on detdes.ordnb=detinv.purno and detdes.lignb=detinv.purlin inner join hdrdes on detdes.packlist=hdrdes.packlist where detdes.cntqty=0";
            if (StringType.StrCmp(Variables.gCodProd, "", false) != 0)
            {
                str = str + " and detdes.itnbr='" + Variables.gCodProd + "'";
            }
            this.AdapDetDes = new SqlDataAdapter(str, str3);
            this.DS1.Clear();
            this.AdapDetDes.Fill(this.DS1, "detdes");
            string connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            flag = true;
            SqlCommand command = new SqlCommand("delete " + Variables.gTermi + "TmpDetDes", connection);
            int num2 = command.ExecuteNonQuery();
            int num3 = this.DS1.Tables["detdes"].Rows.Count - 1;
            for (int i = 0; i <= num3; i++)
            {
                DataRow row = this.DS1.Tables["detdes"].Rows[i];
                str = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj((("insert into " + Variables.gTermi + "TmpDetDes (NroOC,NroLinea,NroBulto,PackList,FechaPL,NroFC,FechaFC,EnTransito) values ('" + Strings.Format(RuntimeHelpers.GetObjectValue(row["ordnb"]), "0000000000")) + "','" + Strings.Format(RuntimeHelpers.GetObjectValue(row["lignb"]), "000000")) + "','", row["colnb"]), "','"), row["trind"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["datexp"]), "MM/dd/yyyy")), "',"));
                if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["invno"])))
                {
                    str = str + "'',";
                }
                else
                {
                    str = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(str + "'", row["invno"]), "',"));
                }
                if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["stamp"])))
                {
                    str = str + "'',";
                }
                else
                {
                    str = str + "'" + Strings.Format(DateType.FromString(Strings.Mid(StringType.FromObject(row["stamp"]), 1, 10)), "MM/dd/yyyy") + "',";
                }
                if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["desqty"])))
                {
                    str = str + "0)";
                }
                else
                {
                    str = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(str, row["desqty"]), ")"));
                }
                command = new SqlCommand(str, connection);
                try
                {
                    command.ExecuteNonQuery();
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
            }
            str = "select * from " + Variables.gTermi + "TmpDetDes as PC1TmpDetDes";
            this.AdapTmp = new SqlDataAdapter(str, connectionString);
            this.AdapTmp.Fill(this.DS, "PC1TmpDetDes");
            if (Variables.gOrdenList == 1)
            {
                this.Informe.Load(Application.StartupPath + @"\repocpend.rpt");
            }
            else
            {
                this.Informe.Load(Application.StartupPath + @"\repocpend1.rpt");
            }
            this.Informe.SetDataSource(this.DS);
            connection.Close();
            flag = false;
            FormulaFieldDefinitions formulaFields = this.Informe.DataDefinition.FormulaFields;
            FormulaFieldDefinition definition = formulaFields["desde"];
            if (StringType.StrCmp(Variables.gDesde, Strings.Space(0), false) == 0)
            {
                definition.Text = "'" + Variables.gDesde + "'";
            }
            else
            {
                definition.Text = "'" + Strings.Format(DateType.FromString(Variables.gDesde), "dd/MM/yyyy") + "'";
            }
            FormulaFieldDefinition definition2 = formulaFields["hasta"];
            if (StringType.StrCmp(Variables.gHasta, Strings.Space(0), false) == 0)
            {
                definition2.Text = "'" + Variables.gHasta + "'";
            }
            else
            {
                definition2.Text = "'" + Strings.Format(DateType.FromString(Variables.gHasta), "dd/MM/yyyy") + "'";
            }
            FormulaFieldDefinition definition3 = formulaFields["almacen"];
            if (StringType.StrCmp(Variables.gAlmacen1, Strings.Space(0), false) != 0)
            {
                if (StringType.StrCmp(Variables.gAlmacen2, Strings.Space(0), false) != 0)
                {
                    definition3.Text = "'Almacenes: " + Strings.Trim(Variables.gAlmacen1) + "-" + Strings.Trim(Variables.gAlmacen2) + "'";
                }
                else
                {
                    definition3.Text = "'Almacen: " + Strings.Trim(Variables.gAlmacen1) + "'";
                }
            }
            else if (StringType.StrCmp(Variables.gAlmacen2, Strings.Space(0), false) != 0)
            {
                definition3.Text = "'Almacen: " + Strings.Trim(Variables.gAlmacen2) + "'";
            }
            else
            {
                definition3.Text = "'Todos los almacenes'";
            }
            this.CrystalReportViewer1.ReportSource = this.Informe;
            this.CrystalReportViewer1.Refresh();
            this.cmbSalir.Enabled = true;
        }

        private void CrystalReportViewer1_Resize(object sender, EventArgs e)
        {
        }

        private void CrystalReportViewer1_ViewZoom(object source, ZoomEventArgs e)
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

        ~frmRepOCPend1()
        {
        }

        private void frmRepOCPend1_Closed(object sender, EventArgs e)
        {
            new frmRepOCPend().Show();
        }

        private void frmRepOCPend1_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRepOCPend1));
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
            this.CrystalReportViewer1.ActiveViewIndex = -1;
            this.CrystalReportViewer1.DisplayGroupTree = false;
            point = new Point(8, 8);
            this.CrystalReportViewer1.Location = point;
            this.CrystalReportViewer1.Name = "CrystalReportViewer1";
            this.CrystalReportViewer1.ReportSource = null;
            size = new Size(0x3f0, 640);
            this.CrystalReportViewer1.Size = size;
            this.CrystalReportViewer1.TabIndex = 0x36;
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x404, 0x2f1);
            this.ClientSize = size;
            this.Controls.Add(this.CrystalReportViewer1);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmRepOCPend1";
            this.Text = "Reporte O.Compra Pendientes";
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
                    this._CrystalReportViewer1.ReportRefresh -= new CrystalDecisions.Windows.Forms.RefreshEventHandler(this.CrystalReportViewer1_ReportRefresh);
                    this._CrystalReportViewer1.ViewZoom -= new ZoomEventHandler(this.CrystalReportViewer1_ViewZoom);
                    this._CrystalReportViewer1.Resize -= new EventHandler(this.CrystalReportViewer1_Resize);
                    this._CrystalReportViewer1.Load -= new EventHandler(this.CrystalReportViewer1_Load);
                }
                this._CrystalReportViewer1 = value;
                if (this._CrystalReportViewer1 != null)
                {
                    this._CrystalReportViewer1.ReportRefresh += new CrystalDecisions.Windows.Forms.RefreshEventHandler(this.CrystalReportViewer1_ReportRefresh);
                    this._CrystalReportViewer1.ViewZoom += new ZoomEventHandler(this.CrystalReportViewer1_ViewZoom);
                    this._CrystalReportViewer1.Resize += new EventHandler(this.CrystalReportViewer1_Resize);
                    this._CrystalReportViewer1.Load += new EventHandler(this.CrystalReportViewer1_Load);
                }
            }
        }
    }
}

