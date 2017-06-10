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

    public class frmRepRMDesp1 : Form
    {
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("CrystalReportViewer1")]
        private CrystalReportViewer _CrystalReportViewer1;
        public SqlDataAdapter AdapSC01;
        public SqlDataAdapter AdapSY24;
        public SqlDataAdapter AdapTmp;
        private IContainer components;
        public DataSet DS;
        public ReportDocument Informe;

        public frmRepRMDesp1()
        {
            base.Closed += new EventHandler(this.frmRepRMDesp1_Closed);
            base.Load += new EventHandler(this.frmRepRMDesp1_Load);
            base.Click += new EventHandler(this.frmRepRMDesp1_Click);
            base.Leave += new EventHandler(this.frmRepRMDesp1_Leave);
            this.Informe = new ReportDocument();
            this.DS = new DataSet();
            this.InitializeComponent();
            try
            {
                SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
                connection.Open();
                string str = "SELECT distinct NroOV,Cliente,NomCli,OCompra,LugarEnt,MetEnvio,NroRemito,Bultos,PesoBruto,PesoNeto,Volumen,FechaExp,HoraExp from PrepPed where not NroRemito is null and not FechaExp is null";
                if (!((StringType.StrCmp(Variables.gDesde, "", false) == 0) & (StringType.StrCmp(Variables.gHasta, "", false) == 0)))
                {
                    if ((StringType.StrCmp(Variables.gDesde, "", false) != 0) & (StringType.StrCmp(Variables.gHasta, "", false) == 0))
                    {
                        str = str + " and FechaExp>='" + Strings.Format(DateType.FromString(Variables.gDesde), "MM/dd/yyyy") + "'";
                    }
                    else if ((StringType.StrCmp(Variables.gDesde, "", false) == 0) & (StringType.StrCmp(Variables.gHasta, "", false) != 0))
                    {
                        str = str + " and FechaExp<='" + Strings.Format(DateType.FromString(Variables.gHasta), "MM/dd/yyyy") + "'";
                    }
                    else if ((StringType.StrCmp(Variables.gDesde, "", false) != 0) & (StringType.StrCmp(Variables.gHasta, "", false) != 0))
                    {
                        str = (str + " and FechaExp>='" + Strings.Format(DateType.FromString(Variables.gDesde), "MM/dd/yyyy") + "'") + " and FechaExp<='" + Strings.Format(DateType.FromString(Variables.gHasta), "MM/dd/yyyy") + "'";
                    }
                }
                SqlCommand command = new SqlCommand(str + " and MetEnvio in (select MetEnvio from " + Variables.gTermi + "TmpMetEnvio where Seleccion=1)", connection);
                command.CommandTimeout = 500;
                this.AdapTmp = new SqlDataAdapter();
                this.AdapTmp.SelectCommand = command;
                this.DS.Clear();
                this.AdapTmp.Fill(this.DS, "PrepPed");
                this.Informe.Load(Application.StartupPath + @"\reprmdesp.rpt");
                this.Informe.SetDataSource(this.DS);
                connection.Close();
                FormulaFieldDefinitions formulaFields = this.Informe.DataDefinition.FormulaFields;
                FormulaFieldDefinition definition = formulaFields["desdefecha"];
                if (StringType.StrCmp(Variables.gDesde, Strings.Space(0), false) != 0)
                {
                    definition.Text = "'" + Strings.Format(DateType.FromString(Variables.gDesde), "dd/MM/yyyy") + "'";
                }
                else
                {
                    definition.Text = "''";
                }
                FormulaFieldDefinition definition2 = formulaFields["hastafecha"];
                if (StringType.StrCmp(Variables.gHasta, Strings.Space(0), false) != 0)
                {
                    definition2.Text = "'" + Strings.Format(DateType.FromString(Variables.gHasta), "dd/MM/yyyy") + "'";
                }
                else
                {
                    definition2.Text = "''";
                }
                this.CrystalReportViewer1.ReportSource = this.Informe;
                this.CrystalReportViewer1.Zoom(1);
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

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
        }

        private void CrystalReportViewer1_ReportRefresh(object source, ViewerEventArgs e)
        {
            this.cmbSalir.Enabled = false;
            this.Informe.Close();
            SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
            connection.Open();
            string str3 = "SELECT distinct NroOV,Cliente,NomCli,OCompra,LugarEnt,MetEnvio,NroRemito,Bultos,PesoBruto,PesoNeto,Volumen,FechaExp,HoraExp from PrepPed where not NroRemito is null and not FechaExp is null";
            if (!((StringType.StrCmp(Variables.gDesde, "", false) == 0) & (StringType.StrCmp(Variables.gHasta, "", false) == 0)))
            {
                if ((StringType.StrCmp(Variables.gDesde, "", false) != 0) & (StringType.StrCmp(Variables.gHasta, "", false) == 0))
                {
                    str3 = str3 + " and FechaExp>='" + Strings.Format(DateType.FromString(Variables.gDesde), "MM/dd/yyyy") + "'";
                }
                else if ((StringType.StrCmp(Variables.gDesde, "", false) == 0) & (StringType.StrCmp(Variables.gHasta, "", false) != 0))
                {
                    str3 = str3 + " and FechaExp<='" + Strings.Format(DateType.FromString(Variables.gHasta), "MM/dd/yyyy") + "'";
                }
                else if ((StringType.StrCmp(Variables.gDesde, "", false) != 0) & (StringType.StrCmp(Variables.gHasta, "", false) != 0))
                {
                    str3 = (str3 + " and FechaExp>='" + Strings.Format(DateType.FromString(Variables.gDesde), "MM/dd/yyyy") + "'") + " and FechaExp<='" + Strings.Format(DateType.FromString(Variables.gHasta), "MM/dd/yyyy") + "'";
                }
            }
            SqlCommand command = new SqlCommand(str3 + " and MetEnvio in (select MetEnvio from " + Variables.gTermi + "TmpMetEnvio where Seleccion=1)", connection);
            command.CommandTimeout = 500;
            this.AdapTmp = new SqlDataAdapter();
            this.AdapTmp.SelectCommand = command;
            this.DS.Clear();
            this.AdapTmp.Fill(this.DS, "PrepPed");
            this.Informe.Load(Application.StartupPath + @"\reprmdesp.rpt");
            this.Informe.SetDataSource(this.DS);
            connection.Close();
            FormulaFieldDefinitions formulaFields = this.Informe.DataDefinition.FormulaFields;
            FormulaFieldDefinition definition = formulaFields["desdefecha"];
            if (StringType.StrCmp(Variables.gDesde, Strings.Space(0), false) != 0)
            {
                definition.Text = "'" + Strings.Format(DateType.FromString(Variables.gDesde), "dd/MM/yyyy HH:mm:ss") + "'";
            }
            else
            {
                definition.Text = "''";
            }
            FormulaFieldDefinition definition2 = formulaFields["hastafecha"];
            if (StringType.StrCmp(Variables.gHasta, Strings.Space(0), false) != 0)
            {
                definition2.Text = "'" + Strings.Format(DateType.FromString(Variables.gHasta), "dd/MM/yyyy HH:mm:ss") + "'";
            }
            else
            {
                definition2.Text = "''";
            }
            this.CrystalReportViewer1.ReportSource = this.Informe;
            this.CrystalReportViewer1.Zoom(1);
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

        ~frmRepRMDesp1()
        {
        }

        private void frmRepRMDesp1_Click(object sender, EventArgs e)
        {
        }

        private void frmRepRMDesp1_Closed(object sender, EventArgs e)
        {
            new frmRepRMDesp().Show();
        }

        private void frmRepRMDesp1_Leave(object sender, EventArgs e)
        {
        }

        private void frmRepRMDesp1_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRepRMDesp1));
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
            this.Name = "frmRepRMDesp1";
            this.Text = "Reporte Remitos Despachados";
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

