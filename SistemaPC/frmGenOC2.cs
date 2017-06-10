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

    public class frmGenOC2 : Form
    {
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("CrystalReportViewer1")]
        private CrystalReportViewer _CrystalReportViewer1;
        public SqlDataAdapter Adap1;
        public SqlDataAdapter Adap2;
        private IContainer components;
        public DataSet DS;
        public DataSet DS1;
        public DataSet DS2;
        public ReportDocument Informe;
        public SqlDataAdapter xAdap;
        public SqlDataAdapter xAdap1;

        public frmGenOC2()
        {
            base.Closed += new EventHandler(this.frmGenOC2_Closed);
            base.Load += new EventHandler(this.frmGenOC2_Load);
            base.Click += new EventHandler(this.frmGenOC2_Click);
            this.Informe = new ReportDocument();
            this.DS = new DataSet();
            this.DS1 = new DataSet();
            this.DS2 = new DataSet();
            this.InitializeComponent();
            try
            {
                SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * from " + Variables.gTermi + "TmpOCompra as PC1TmpOCompra where Seleccion=1", connection);
                command.CommandTimeout = 500;
                this.Adap1 = new SqlDataAdapter();
                this.Adap1.SelectCommand = command;
                this.DS.Clear();
                this.Adap1.Fill(this.DS, "PC1TmpOCompra");
                this.Informe.Load(Application.StartupPath + @"\GenOCompra.rpt");
                this.Informe.SetDataSource(this.DS);
                connection.Close();
                FormulaFieldDefinition definition = this.Informe.DataDefinition.FormulaFields["almacen"];
                definition.Text = "'Almacen: " + Strings.Trim(Variables.gAlmacen1) + "'";
                this.CrystalReportViewer1.ReportSource = this.Informe;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                ProjectData.ClearProjectError();
            }
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

        ~frmGenOC2()
        {
        }

        private void frmGenOC2_Click(object sender, EventArgs e)
        {
        }

        private void frmGenOC2_Closed(object sender, EventArgs e)
        {
            new frmGenOC1().Show();
        }

        private void frmGenOC2_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmGenOC2));
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
            size = new Size(0x404, 0x2f1);
            this.ClientSize = size;
            this.Controls.Add(this.CrystalReportViewer1);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmGenOC2";
            this.Text = "Generaci\x00f3n Ordenes de Compra";
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

