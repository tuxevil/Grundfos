namespace SistemaPC
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Windows.Forms;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmFcProfExp2 : Form
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

        public frmFcProfExp2()
        {
            base.Closed += new EventHandler(this.frmFcProfExp2_Closed);
            base.Load += new EventHandler(this.frmFcProfExp2_Load);
            this.Informe = new ReportDocument();
            this.DS = new DataSet();
            this.InitializeComponent();
            DataSet dataSet = new DataSet();
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
            dataSet.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from OR010100 where OR01002<>6 and OR01004='" + Variables.gCodCli + "'", selectConnectionString);
            string selectCommandText = "SELECT * FROM dbo.OR040100";
            SqlDataAdapter adapter2 = new SqlDataAdapter(selectCommandText, selectConnectionString);
            SqlDataAdapter adapter3 = new SqlDataAdapter("SELECT * from SL010100 where SL01001='" + Variables.gCodCli + "'", selectConnectionString);
            adapter.Fill(dataSet, "OR010100");
            adapter2.Fill(dataSet, "OR040100");
            adapter3.Fill(dataSet, "SL010100");
            string str4 = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            new SqlDataAdapter("select * from " + Variables.gTermi + "TmpOVFcProExp as PC1TmpOVFcProExp", str4).Fill(dataSet, "PC1TmpOVFcProExp");
            new SqlDataAdapter("select * from " + Variables.gTermi + "TmpItemFcProExp as PC1TmpItemFcProExp where Seleccion=1", str4).Fill(dataSet, "PC1TmpItemFcProExp");
            if (!Variables.gFcProfIng)
            {
                this.Informe.Load(Application.StartupPath + @"\fcprofexp.rpt");
            }
            else
            {
                this.Informe.Load(Application.StartupPath + @"\fcprofexping.rpt");
            }
            this.Informe.SetDataSource(dataSet);
            this.CrystalReportViewer1.ReportSource = this.Informe;
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

        ~frmFcProfExp2()
        {
        }

        private void frmFcProfExp2_Closed(object sender, EventArgs e)
        {
            new frmFcProfExp().Show();
        }

        private void frmFcProfExp2_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmFcProfExp2));
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
            this.Name = "frmFcProfExp2";
            this.Text = "Facturas Proforma Exportaci\x00f3n";
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
                }
                this._CrystalReportViewer1 = value;
                if (this._CrystalReportViewer1 != null)
                {
                }
            }
        }
    }
}

