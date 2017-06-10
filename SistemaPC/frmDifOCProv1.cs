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

    public class frmDifOCProv1 : Form
    {
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("CrystalReportViewer1")]
        private CrystalReportViewer _CrystalReportViewer1;
        public SqlDataAdapter AdapHdrdes;
        public SqlDataAdapter AdapOCPend;
        public SqlDataAdapter AdapProd;
        private IContainer components;
        public DataSet DS;
        public ReportDocument Informe;

        public frmDifOCProv1()
        {
            base.Closed += new EventHandler(this.frmDifOCProv1_Closed);
            base.Load += new EventHandler(this.frmDifOCProv1_Load);
            this.Informe = new ReportDocument();
            this.DS = new DataSet();
            this.InitializeComponent();
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=edibar;persist security info=False;packet size=4096";
            string str3 = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
            string selectCommandText = "Select * from detdes where datexp>='" + Strings.Format(DateType.FromString(Variables.gDesde), "MM/dd/yyyy") + "' and datexp<='" + Strings.Format(DateType.FromString(Variables.gHasta), "MM/dd/yyyy") + "' and expqty<>cntqty";
            this.AdapOCPend = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.AdapOCPend.Fill(this.DS, "detdes");
            selectCommandText = "Select * from hdrdes where packlist in (Select packlist from detdes where datexp>='" + Strings.Format(DateType.FromString(Variables.gDesde), "MM/dd/yyyy") + "' and datexp<='" + Strings.Format(DateType.FromString(Variables.gHasta), "MM/dd/yyyy") + "' and expqty<>cntqty)";
            this.AdapHdrdes = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.AdapHdrdes.Fill(this.DS, "hdrdes");
            selectCommandText = "Select SC01001,SC01002,SC01003 from SC010100";
            this.AdapProd = new SqlDataAdapter(selectCommandText, str3);
            this.AdapProd.Fill(this.DS, "SC010100");
            this.Informe.Load(Application.StartupPath + @"\repdifocprov.rpt");
            this.Informe.SetDataSource(this.DS);
            FormulaFieldDefinitions formulaFields = this.Informe.DataDefinition.FormulaFields;
            FormulaFieldDefinition definition = formulaFields["desdefechaexp"];
            definition.Text = "'" + Strings.Format(DateType.FromString(Variables.gDesde), "dd/MM/yyyy") + "'";
            FormulaFieldDefinition definition2 = formulaFields["hastafechaexp"];
            definition2.Text = "'" + Strings.Format(DateType.FromString(Variables.gHasta), "dd/MM/yyyy") + "'";
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
            this.cmbSalir.Enabled = false;
            this.Informe.Close();
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=edibar;persist security info=False;packet size=4096";
            string str3 = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
            string selectCommandText = "Select * from detdes where datexp>='" + Strings.Format(DateType.FromString(Variables.gDesde), "MM/dd/yyyy") + "' and datexp<='" + Strings.Format(DateType.FromString(Variables.gHasta), "MM/dd/yyyy") + "' and expqty<>cntqty";
            this.AdapOCPend = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.DS.Clear();
            this.AdapOCPend.Fill(this.DS, "detdes");
            selectCommandText = "Select * from hdrdes where packlist in (Select packlist from detdes where datexp>='" + Strings.Format(DateType.FromString(Variables.gDesde), "MM/dd/yyyy") + "' and datexp<='" + Strings.Format(DateType.FromString(Variables.gHasta), "MM/dd/yyyy") + "' and expqty<>cntqty)";
            this.AdapHdrdes = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.AdapHdrdes.Fill(this.DS, "hdrdes");
            selectCommandText = "Select SC01001,SC01002,SC01003 from SC010100";
            this.AdapProd = new SqlDataAdapter(selectCommandText, str3);
            this.AdapProd.Fill(this.DS, "SC010100");
            this.Informe.Load(Application.StartupPath + @"\repdifocprov.rpt");
            this.Informe.SetDataSource(this.DS);
            FormulaFieldDefinitions formulaFields = this.Informe.DataDefinition.FormulaFields;
            FormulaFieldDefinition definition = formulaFields["desdefechaexp"];
            definition.Text = "'" + Strings.Format(DateType.FromString(Variables.gDesde), "dd/MM/yyyy") + "'";
            FormulaFieldDefinition definition2 = formulaFields["hastafechaexp"];
            definition2.Text = "'" + Strings.Format(DateType.FromString(Variables.gHasta), "dd/MM/yyyy") + "'";
            this.CrystalReportViewer1.ReportSource = this.Informe;
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

        ~frmDifOCProv1()
        {
        }

        private void frmDifOCProv1_Closed(object sender, EventArgs e)
        {
            new frmDifOCProv().Show();
        }

        private void frmDifOCProv1_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmDifOCProv1));
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
            this.CrystalReportViewer1.ShowGroupTreeButton = false;
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
            this.Name = "frmDifOCProv1";
            this.Text = "Reporte Diferencias O.Compra con Proveedor";
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
                    this._CrystalReportViewer1.Load -= new EventHandler(this.CrystalReportViewer1_Load);
                    this._CrystalReportViewer1.ReportRefresh -= new CrystalDecisions.Windows.Forms.RefreshEventHandler(this.CrystalReportViewer1_ReportRefresh);
                }
                this._CrystalReportViewer1 = value;
                if (this._CrystalReportViewer1 != null)
                {
                    this._CrystalReportViewer1.Load += new EventHandler(this.CrystalReportViewer1_Load);
                    this._CrystalReportViewer1.ReportRefresh += new CrystalDecisions.Windows.Forms.RefreshEventHandler(this.CrystalReportViewer1_ReportRefresh);
                }
            }
        }
    }
}

