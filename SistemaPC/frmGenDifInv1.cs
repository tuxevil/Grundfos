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

    public class frmGenDifInv1 : Form
    {
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("CrystalReportViewer1")]
        private CrystalReportViewer _CrystalReportViewer1;
        private IContainer components;

        public frmGenDifInv1()
        {
            base.Load += new EventHandler(this.frmGenDifInv1_Load);
            base.Closed += new EventHandler(this.frmGenDifInv1_Closed);
            this.InitializeComponent();
            ReportDocument document = new ReportDocument();
            DataSet dataSet = new DataSet();
            try
            {
                SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.RepDifInv where FechaInv='" + Strings.Format(Variables.gFechaInv, "MM/dd/yyyy") + "' and DesdeRack='" + Variables.gDesdeRack + "' and HastaRack='" + Variables.gHastaRack + "' and Almacen='" + Variables.gCodAlmacen + "' and (Cantidad<>CantSist or Posicion<>PosSist) and Aceptar=0", connection);
                command.CommandTimeout = 500;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                connection.Open();
                adapter.Fill(dataSet, "RepDifInv");
                document.Load(Application.StartupPath + @"\repdifinv.rpt");
                document.SetDataSource(dataSet);
                connection.Close();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                ProjectData.ClearProjectError();
            }
            FormulaFieldDefinitions formulaFields = document.DataDefinition.FormulaFields;
            FormulaFieldDefinition definition = formulaFields["FechaInv"];
            definition.Text = "'" + Strings.Format(Variables.gFechaInv, "dd/MM/yyyy") + "'";
            FormulaFieldDefinition definition2 = formulaFields["DesdeRack"];
            definition2.Text = "'" + Variables.gDesdeRack + "'";
            FormulaFieldDefinition definition3 = formulaFields["HastaRack"];
            definition3.Text = "'" + Variables.gHastaRack + "'";
            FormulaFieldDefinition definition4 = formulaFields["Almacen"];
            definition4.Text = "'" + Variables.gCodAlmacen + "-" + Variables.gNomAlmacen + "'";
            this.CrystalReportViewer1.ReportSource = document;
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
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

        ~frmGenDifInv1()
        {
        }

        private void frmGenDifInv1_Closed(object sender, EventArgs e)
        {
            if (Variables.gGenDifInv)
            {
                new frmGenDifInv().Show();
            }
        }

        private void frmGenDifInv1_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmGenDifInv1));
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
            this.Name = "frmGenDifInv1";
            this.Text = "Generaci\x00f3n Diferencias Inventario - Reporte Diferencias";
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
                }
                this._CrystalReportViewer1 = value;
                if (this._CrystalReportViewer1 != null)
                {
                    this._CrystalReportViewer1.Load += new EventHandler(this.CrystalReportViewer1_Load);
                }
            }
        }
    }
}

