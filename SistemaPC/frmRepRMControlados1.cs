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

    public class frmRepRMControlados1 : Form
    {
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("CrystalReportViewer1")]
        private CrystalReportViewer _CrystalReportViewer1;
        public SqlDataAdapter AdapProdPend;
        private IContainer components;
        public DataSet DS;
        public DataSet DS19;
        public DataSet DS20;
        public ReportDocument Informe;

        public frmRepRMControlados1()
        {
            base.Closed += new EventHandler(this.frmRepRMControlados1_Closed);
            base.Load += new EventHandler(this.frmRepRMControlados1_Load);
            this.Informe = new ReportDocument();
            this.DS = new DataSet();
            this.DS19 = new DataSet();
            this.DS20 = new DataSet();
            this.InitializeComponent();
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            this.AdapProdPend = new SqlDataAdapter("Select NroOV,NroLinea,EstLinea,Codigo,Desc1,Desc2,CantOrden,CantPrep,FechaPrep,NroRemito,Cliente,NomCli,OCompra,FechaOV from PrepPed where ContFinal='S' and Expedicion='N'", selectConnectionString);
            this.AdapProdPend.Fill(this.DS, "PrepPed");
            if (Variables.gOrdenProdPend == 1)
            {
                this.CrystalReportViewer1.ShowGroupTreeButton = true;
                this.Informe.Load(Application.StartupPath + @"\reprmcont.rpt");
            }
            else if (Variables.gOrdenProdPend == 2)
            {
                this.CrystalReportViewer1.ShowGroupTreeButton = false;
                this.Informe.Load(Application.StartupPath + @"\reprmcont2.rpt");
            }
            else if (Variables.gOrdenProdPend == 3)
            {
                this.CrystalReportViewer1.ShowGroupTreeButton = true;
                this.Informe.Load(Application.StartupPath + @"\reprmcont3.rpt");
            }
            else if (Variables.gOrdenProdPend == 4)
            {
                this.CrystalReportViewer1.ShowGroupTreeButton = false;
                this.Informe.Load(Application.StartupPath + @"\reprmcont4.rpt");
            }
            else if (Variables.gOrdenProdPend == 5)
            {
                this.CrystalReportViewer1.ShowGroupTreeButton = false;
                this.Informe.Load(Application.StartupPath + @"\reprmcont5.rpt");
            }
            this.Informe.SetDataSource(this.DS);
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
            SqlDataAdapter adapter2;
            SqlCommand command2;
            DataRow row;
            DataRow row2;
            int num;
            int num3;
            this.cmbSalir.Enabled = false;
            this.Informe.Close();
            string connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            SqlConnection connection2 = new SqlConnection(connectionString);
            connection2.Open();
            string str6 = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
            SqlConnection connection = new SqlConnection(str6);
            connection.Open();
            this.DS.Clear();
            string selectCommandText = "select * from PrepPed where ContFinal='S' and NroRemito is null";
            new SqlDataAdapter(selectCommandText, connectionString).Fill(this.DS, "PrepPed");
            if (this.DS.Tables["PrepPed"].Rows.Count != 0)
            {
                int num7 = this.DS.Tables["PrepPed"].Rows.Count - 1;
                for (num = 0; num <= num7; num++)
                {
                    SqlCommand command;
                    int num2;
                    SqlDataReader reader;
                    row = this.DS.Tables["PrepPed"].Rows[num];
                    adapter2 = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR19012 from OR190100 where OR19001='", row["NroOV"]), "' and OR19002='"), row["NroLinea"]), "' and OR19003='"), row["EstLinea"]), "' and OR19011='"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FechaPrep"]), "MM/dd/yyyy")), "' and OR19012<>'' order by OR19012")), str6);
                    this.DS19.Clear();
                    adapter2.Fill(this.DS19, "OR190100");
                    if (this.DS19.Tables["OR190100"].Rows.Count != 0)
                    {
                        int num6 = this.DS19.Tables["OR190100"].Rows.Count - 1;
                        num2 = 0;
                        while (num2 <= num6)
                        {
                            row2 = this.DS19.Tables["OR190100"].Rows[num2];
                            command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("Select NroRemito from PrepPed where NroOV='", row["NroOV"]), "' and NroLinea='"), row["NroLinea"]), "' and EstLinea='"), row["EstLinea"]), "' and NroRemito='"), row2["OR19012"]), "'")), connection2);
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                reader.Close();
                            }
                            else
                            {
                                reader.Close();
                                try
                                {
                                    command2 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("update PrepPed set NroRemito='", row2["OR19012"]), "' where NroOV='"), row["NroOV"]), "' and NroLinea='"), row["NroLinea"]), "' and TipoLinea="), row["TipoLinea"]), " and EstLinea='"), row["EstLinea"]), "' and NroRemito is null")), connection2);
                                    num3 = command2.ExecuteNonQuery();
                                }
                                catch (Exception exception1)
                                {
                                    ProjectData.SetProjectError(exception1);
                                    Exception exception = exception1;
                                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                                    connection2.Close();
                                    connection.Close();
                                    this.Close();
                                    ProjectData.ClearProjectError();
                                }
                                break;
                            }
                            num2++;
                        }
                    }
                    else if (ObjectType.ObjTst(row["Producto"], 1, false) == 0)
                    {
                        command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR19012 from OR190100 where OR19001='", row["NroOV"]), "' and OR19002='"), row["NroLinea"]), "' and OR19003<>'000' and OR19011='"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FechaPrep"]), "MM/dd/yyyy")), "' and OR19012<>'' order by OR19012")), connection);
                        reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            try
                            {
                                string cmdText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("update PrepPed set NroRemito='", reader["OR19012"]), "' where NroOV='"), row["NroOV"]), "' and NroLinea='"), row["NroLinea"]), "' and TipoLinea="), row["TipoLinea"]), " and EstLinea='"), row["EstLinea"]), "' and NroRemito is null"));
                                reader.Close();
                                command2 = new SqlCommand(cmdText, connection2);
                                num3 = command2.ExecuteNonQuery();
                            }
                            catch (Exception exception6)
                            {
                                ProjectData.SetProjectError(exception6);
                                Exception exception2 = exception6;
                                Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, MsgBoxStyle.OKOnly, null);
                                this.cmbSalir.Enabled = true;
                                connection2.Close();
                                connection.Close();
                                this.Close();
                                ProjectData.ClearProjectError();
                            }
                        }
                        else
                        {
                            reader.Close();
                        }
                    }
                    else
                    {
                        adapter2 = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR23012 from OR230100 where OR23001='", row["NroOV"]), "' and OR23002='"), row["NroLinea"]), "' and OR23003='"), row["EstLinea"]), "' and OR23011='"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FechaPrep"]), "MM/dd/yyyy")), "' and OR23012<>'' order by OR23012")), str6);
                        this.DS20.Clear();
                        adapter2.Fill(this.DS20, "OR230100");
                        if (this.DS20.Tables["OR230100"].Rows.Count != 0)
                        {
                            int num5 = this.DS20.Tables["OR230100"].Rows.Count - 1;
                            for (num2 = 0; num2 <= num5; num2++)
                            {
                                row2 = this.DS20.Tables["OR230100"].Rows[num2];
                                reader = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("Select NroRemito from PrepPed where NroOV='", row["NroOV"]), "' and NroLinea='"), row["NroLinea"]), "' and TipoLinea="), row["TipoLinea"]), " and EstLinea='"), row["EstLinea"]), "' and NroRemito='"), row2["OR23012"]), "'")), connection2).ExecuteReader();
                                if (reader.Read())
                                {
                                    reader.Close();
                                }
                                else
                                {
                                    reader.Close();
                                    try
                                    {
                                        command2 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("update PrepPed set NroRemito='", row2["OR23012"]), "' where NroOV='"), row["NroOV"]), "' and NroLinea='"), row["NroLinea"]), "' and TipoLinea="), row["TipoLinea"]), " and EstLinea='"), row["EstLinea"]), "' and NroRemito is null")), connection2);
                                        num3 = command2.ExecuteNonQuery();
                                    }
                                    catch (Exception exception7)
                                    {
                                        ProjectData.SetProjectError(exception7);
                                        Exception exception3 = exception7;
                                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception3.Message, MsgBoxStyle.OKOnly, null);
                                        connection2.Close();
                                        this.Close();
                                        ProjectData.ClearProjectError();
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            selectCommandText = "select NroOV from PrepPed where ContFinal='S' and Expedicion='N' group by NroOV";
            new SqlDataAdapter(selectCommandText, connectionString).Fill(this.DS, "PrepPed");
            if (this.DS.Tables["PrepPed"].Rows.Count != 0)
            {
                int num4 = this.DS.Tables["PrepPed"].Rows.Count - 1;
                for (num = 0; num <= num4; num++)
                {
                    row = this.DS.Tables["PrepPed"].Rows[num];
                    adapter2 = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR01015,OR01072 from OR010100 where OR01001='", row["NroOV"]), "'")), str6);
                    this.DS19.Clear();
                    adapter2.Fill(this.DS19, "OR190100");
                    if (this.DS19.Tables["OR190100"].Rows.Count != 0)
                    {
                        row2 = this.DS19.Tables["OR190100"].Rows[0];
                        try
                        {
                            command2 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("update PrepPed set OCompra='", row2["OR01072"]), "',FechaOV='"), Strings.Format(RuntimeHelpers.GetObjectValue(row2["OR01015"]), "MM/dd/yyyy")), "' where NroOV='"), row["NroOV"]), "'")), connection2);
                            num3 = command2.ExecuteNonQuery();
                        }
                        catch (Exception exception8)
                        {
                            ProjectData.SetProjectError(exception8);
                            Exception exception4 = exception8;
                            Interaction.MsgBox("Se ha producido el siguiente error:" + exception4.Message, MsgBoxStyle.OKOnly, null);
                            connection2.Close();
                            this.Close();
                            ProjectData.ClearProjectError();
                        }
                    }
                    else
                    {
                        adapter2 = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR20015,OR20072 from OR200100 where OR20001='", row["NroOV"]), "'")), str6);
                        this.DS20.Clear();
                        adapter2.Fill(this.DS20, "OR230100");
                        if (this.DS20.Tables["OR230100"].Rows.Count != 0)
                        {
                            row2 = this.DS20.Tables["OR230100"].Rows[0];
                            try
                            {
                                num3 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("update PrepPed set OCompra='", row2["OR20072"]), "',FechaOV='"), Strings.Format(RuntimeHelpers.GetObjectValue(row2["OR20015"]), "MM/dd/yyyy")), "' where NroOV='"), row["NroOV"]), "'")), connection2).ExecuteNonQuery();
                            }
                            catch (Exception exception9)
                            {
                                ProjectData.SetProjectError(exception9);
                                Exception exception5 = exception9;
                                Interaction.MsgBox("Se ha producido el siguiente error:" + exception5.Message, MsgBoxStyle.OKOnly, null);
                                connection2.Close();
                                this.Close();
                                ProjectData.ClearProjectError();
                            }
                        }
                    }
                }
            }
            connection2.Close();
            connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            this.AdapProdPend = new SqlDataAdapter("Select NroOV,NroLinea,EstLinea,Codigo,Desc1,Desc2,CantOrden,CantPrep,FechaPrep,NroRemito,Cliente,NomCli,OCompra,FechaOV from PrepPed where ContFinal='S' and Expedicion='N'", connectionString);
            this.DS.Clear();
            this.AdapProdPend.Fill(this.DS, "PrepPed");
            if (Variables.gOrdenProdPend == 1)
            {
                this.CrystalReportViewer1.ShowGroupTreeButton = true;
                this.Informe.Load(Application.StartupPath + @"\reprmcont.rpt");
            }
            else if (Variables.gOrdenProdPend == 2)
            {
                this.CrystalReportViewer1.ShowGroupTreeButton = false;
                this.Informe.Load(Application.StartupPath + @"\reprmcont2.rpt");
            }
            else if (Variables.gOrdenProdPend == 3)
            {
                this.CrystalReportViewer1.ShowGroupTreeButton = true;
                this.Informe.Load(Application.StartupPath + @"\reprmcont3.rpt");
            }
            else if (Variables.gOrdenProdPend == 4)
            {
                this.CrystalReportViewer1.ShowGroupTreeButton = false;
                this.Informe.Load(Application.StartupPath + @"\reprmcont4.rpt");
            }
            else if (Variables.gOrdenProdPend == 5)
            {
                this.CrystalReportViewer1.ShowGroupTreeButton = false;
                this.Informe.Load(Application.StartupPath + @"\reprmcont5.rpt");
            }
            this.Informe.SetDataSource(this.DS);
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

        ~frmRepRMControlados1()
        {
        }

        private void frmRepRMControlados1_Closed(object sender, EventArgs e)
        {
            new frmRepRMControlados().Show();
        }

        private void frmRepRMControlados1_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRepRMControlados1));
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
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.CrystalReportViewer1);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmRepRMControlados1";
            this.Text = "Reporte Remitos Controlados";
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

