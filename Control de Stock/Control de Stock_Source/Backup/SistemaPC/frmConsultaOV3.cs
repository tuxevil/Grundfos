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

    public class frmConsultaOV3 : Form
    {
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("CrystalReportViewer1")]
        private CrystalReportViewer _CrystalReportViewer1;
        public SqlDataAdapter AdapOR01;
        public SqlDataAdapter AdapOR03;
        public SqlDataAdapter AdapProdPend;
        public SqlDataAdapter AdapSC03;
        public SqlDataAdapter AdapSL01;
        private IContainer components;
        public DataSet DS;
        public DataSet DS19;
        public DataSet DS20;
        public ReportDocument Informe;

        public frmConsultaOV3()
        {
            base.Load += new EventHandler(this.frmConsultaOV3_Load);
            this.Informe = new ReportDocument();
            this.DS = new DataSet();
            this.DS19 = new DataSet();
            this.DS20 = new DataSet();
            this.InitializeComponent();
            try
            {
                SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * from NovedadesOV where NroOV='" + Variables.gNroOV + "'", connection);
                command.CommandTimeout = 500;
                this.AdapOR01 = new SqlDataAdapter();
                this.AdapOR01.SelectCommand = command;
                this.DS.Clear();
                this.AdapOR01.Fill(this.DS, "NovedadesOV");
                this.Informe.Load(Application.StartupPath + @"\ConsultaOVNov.rpt");
                this.Informe.SetDataSource(this.DS);
                connection.Close();
                this.CrystalReportViewer1.set_ReportSource(this.Informe);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                ProjectData.ClearProjectError();
            }
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CrystalReportViewer1_ReportRefresh(object source, ViewerEventArgs e)
        {
            DataSet dataSet = new DataSet();
            this.cmbSalir.Enabled = false;
            this.Informe.Close();
            SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
            connection.Open();
            SqlCommand command3 = new SqlCommand("SELECT * from NovedadesOV where NroOV='" + Variables.gNroOV + "'", connection);
            command3.CommandTimeout = 500;
            this.AdapOR01 = new SqlDataAdapter();
            this.AdapOR01.SelectCommand = command3;
            dataSet.Clear();
            this.AdapOR01.Fill(dataSet, "NovedadesOV");
            this.Informe.Load(Application.StartupPath + @"\ConsultaOVNov.rpt");
            this.Informe.SetDataSource(dataSet);
            connection.Close();
            this.CrystalReportViewer1.set_ReportSource(this.Informe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        ~frmConsultaOV3()
        {
        }

        private void frmConsultaOV3_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmConsultaOV3));
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
            this.CrystalReportViewer1.set_ShowGroupTreeButton(false);
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
            this.Name = "frmConsultaOV3";
            this.Text = "Consulta Ordenes de Venta - Novedades";
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
                }
                this._CrystalReportViewer1 = value;
                if (this._CrystalReportViewer1 != null)
                {
                    this._CrystalReportViewer1.add_ReportRefresh(new RefreshEventHandler(this, (IntPtr) this.CrystalReportViewer1_ReportRefresh));
                }
            }
        }
    }
}

