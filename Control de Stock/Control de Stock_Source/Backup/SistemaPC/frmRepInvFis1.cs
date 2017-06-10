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

    public class frmRepInvFis1 : Form
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

        public frmRepInvFis1()
        {
            base.Closed += new EventHandler(this.frmRepInvFis1_Closed);
            this.DS = new DataSet();
            this.DS1 = new DataSet();
            this.DSTmp = new DataSet();
            this.Informe = new ReportDocument();
            this.InitializeComponent();
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            string selectCommandText = "select * from Inventario where FechaInv='" + Strings.Format(Variables.gFechaInv, "MM/dd/yyyy") + "'";
            if (StringType.StrCmp(Variables.gOperario, Strings.Space(0), false) != 0)
            {
                selectCommandText = selectCommandText + " and Operador='" + Variables.gOperario + "'";
            }
            if ((StringType.StrCmp(Variables.gCodProdDesde, Strings.Space(0), false) != 0) & (StringType.StrCmp(Variables.gCodProdHasta, Strings.Space(0), false) != 0))
            {
                selectCommandText = selectCommandText + " and Codigo>='" + Variables.gCodProdDesde + "' and Codigo<='" + Variables.gCodProdHasta + "'";
            }
            if (StringType.StrCmp(Variables.gFechaLec, Strings.Space(0), false) != 0)
            {
                selectCommandText = selectCommandText + " and Fecha='" + Strings.Format(DateType.FromString(Variables.gFechaLec), "MM/dd/yyyy") + "'";
            }
            this.AdapTmp = new SqlDataAdapter(selectCommandText, selectConnectionString);
            this.AdapTmp.Fill(this.DS, "Inventario");
            this.Informe.Load(Application.StartupPath + @"\repinvfis.rpt");
            this.Informe.SetDataSource(this.DS);
            FormulaFieldDefinitions definitions = this.Informe.get_DataDefinition().get_FormulaFields();
            definitions.get_Item("fechainv").set_Text("'" + Strings.Format(Variables.gFechaInv, "dd/MM/yyyy") + "'");
            FormulaFieldDefinition definition2 = definitions.get_Item("operario");
            if (StringType.StrCmp(Variables.gOperario, Strings.Space(0), false) == 0)
            {
                definition2.set_Text("'Todos los operarios'");
            }
            else
            {
                definition2.set_Text("'Operario: " + Variables.gOperario + "'");
            }
            FormulaFieldDefinition definition3 = definitions.get_Item("productos");
            if ((StringType.StrCmp(Variables.gCodProdDesde, Strings.Space(0), false) == 0) & (StringType.StrCmp(Variables.gCodProdHasta, Strings.Space(0), false) == 0))
            {
                definition3.set_Text("'Todos los productos'");
            }
            else
            {
                definition3.set_Text("'Desde Producto: " + Variables.gCodProdDesde + "-" + Strings.Trim(Variables.gDescProdDesde1) + " " + Strings.Trim(Variables.gDescProdDesde2) + " Hasta Producto: " + Variables.gCodProdHasta + "-" + Strings.Trim(Variables.gDescProdHasta1) + " " + Strings.Trim(Variables.gDescProdHasta2) + "'");
            }
            FormulaFieldDefinition definition4 = definitions.get_Item("fechalec");
            if (StringType.StrCmp(Variables.gFechaLec, Strings.Space(0), false) == 0)
            {
                definition4.set_Text("'Todos las fechas de lectura'");
            }
            else
            {
                definition4.set_Text("'Fecha de Lectura: " + Strings.Format(DateType.FromString(Variables.gFechaLec), "dd/MM/yyyy") + "'");
            }
            this.CrystalReportViewer1.set_ReportSource(this.Informe);
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

        ~frmRepInvFis1()
        {
        }

        private void frmRepInvFis1_Closed(object sender, EventArgs e)
        {
            new frmRepInvFis().Show();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRepInvFis1));
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
            this.Name = "frmRepInvFis1";
            this.Text = "Reporte Inventario F\x00edsico";
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

