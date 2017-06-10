namespace SistemaPC
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmRepEnsXFecha : Form
    {
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dtpFechaDesde")]
        private DateTimePicker _dtpFechaDesde;
        [AccessedThroughProperty("dtpFechaHasta")]
        private DateTimePicker _dtpFechaHasta;
        [AccessedThroughProperty("editNroOE")]
        private TextBox _editNroOE;
        [AccessedThroughProperty("editNroOV")]
        private TextBox _editNroOV;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("Label5")]
        private Label _Label5;
        [AccessedThroughProperty("rbPorGrupoProd")]
        private RadioButton _rbPorGrupoProd;
        [AccessedThroughProperty("rbPorProd")]
        private RadioButton _rbPorProd;
        private IContainer components;

        public frmRepEnsXFecha()
        {
            base.Closed += new EventHandler(this.frmRepEnsXFecha_Closed);
            base.Load += new EventHandler(this.frmRepEnsXFecha_Load);
            this.InitializeComponent();
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            if (!this.dtpFechaDesde.Checked & this.dtpFechaHasta.Checked)
            {
                Interaction.MsgBox("Debe ingresar ambas fechas o ninguna", 0x10, "Operador");
                this.dtpFechaDesde.Checked = true;
            }
            else if (this.dtpFechaDesde.Checked & !this.dtpFechaHasta.Checked)
            {
                Interaction.MsgBox("Debe ingresar ambas fechas o ninguna", 0x10, "Operador");
                this.dtpFechaHasta.Checked = true;
            }
            else if (!this.rbPorProd.Checked & !this.rbPorGrupoProd.Checked)
            {
                Interaction.MsgBox("Debe seleccionar tipo", 0x10, "Operador");
                this.rbPorProd.Focus();
            }
            else
            {
                SqlDataAdapter adapter;
                DataRow row;
                string str;
                string str2;
                this.dtpFechaDesde.Enabled = false;
                this.dtpFechaHasta.Enabled = false;
                this.editNroOE.Enabled = false;
                this.editNroOV.Enabled = false;
                this.cmbAceptar.Enabled = false;
                this.cmbSalir.Enabled = false;
                if (this.dtpFechaDesde.Checked)
                {
                    Variables.gDesde = StringType.FromDate(this.dtpFechaDesde.Value);
                }
                else
                {
                    Variables.gDesde = "";
                }
                if (this.dtpFechaHasta.Checked)
                {
                    Variables.gHasta = StringType.FromDate(this.dtpFechaHasta.Value);
                }
                else
                {
                    Variables.gHasta = "";
                }
                if (StringType.StrCmp(this.editNroOE.Text, Strings.Space(0), false) != 0)
                {
                    Variables.gNroOE = Strings.Format(Conversion.Val(this.editNroOE.Text), "0000000000");
                }
                else
                {
                    Variables.gNroOE = "";
                }
                if (StringType.StrCmp(this.editNroOV.Text, Strings.Space(0), false) != 0)
                {
                    Variables.gNroOV = this.editNroOV.Text;
                }
                else
                {
                    Variables.gNroOV = "";
                }
                if (this.rbPorProd.Checked)
                {
                    Variables.gTipoList = "1";
                }
                else
                {
                    Variables.gTipoList = "2";
                }
                DataSet dataSet = new DataSet();
                SqlConnection connection2 = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096");
                connection2.Open();
                SqlCommand command = new SqlCommand("delete " + Variables.gTermi + "TmpRepGesEns", connection2);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                    connection2.Close();
                    ProjectData.ClearProjectError();
                    return;
                    ProjectData.ClearProjectError();
                }
                string connectionString = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=True;packet size=4096";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string cmdText = "SELECT DISTINCT OR010100.OR01001,OR010100.OR01015,OR010100.OR01016,OR030100.OR03002,OR030100.OR03005,OR030100.OR03006,OR030100.OR03007,OR030100.OR03011,OR030100.OR03012,OR190100.OR19011,OR040100.OR04002,OR040100.OR04003,OR040100.OR04004,OR040100.OR04005,OR040100.OR04008 FROM dbo.OR010100 INNER JOIN dbo.OR030100 on OR010100.OR01001=OR030100.OR03001 LEFT OUTER JOIN dbo.OR040100 on OR010100.OR01001=OR040100.OR04001 LEFT OUTER JOIN dbo.OR190100 on OR030100.OR03001=OR190100.OR19001 and OR030100.OR03002=OR190100.OR19002 where OR010100.OR01002=6 and OR030100.OR03003='000' and OR190100.OR19003='000' ";
                if (this.dtpFechaDesde.Checked & this.dtpFechaHasta.Checked)
                {
                    cmdText = cmdText + " and OR190100.OR19011>='" + Strings.Format(DateType.FromString(Variables.gDesde), "MM/dd/yyyy") + "' and OR190100.OR19011<='" + Strings.Format(DateType.FromString(Variables.gHasta), "MM/dd/yyyy") + "'";
                }
                if (StringType.StrCmp(Variables.gNroOE, "", false) != 0)
                {
                    cmdText = cmdText + " and OR010100.OR01001='" + Variables.gNroOE + "'";
                }
                if (StringType.StrCmp(Variables.gNroOV, "", false) != 0)
                {
                    cmdText = cmdText + " and rtrim(OR040100.OR04003)='" + Variables.gNroOV + "'";
                }
                command = new SqlCommand(cmdText, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    adapter = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("Select SC01128,SY24003 from SC010100 inner join SY240100 on SC01128=SY24002 where SC01001='", reader["OR03005"]), "' and SY24001='II'")), connectionString);
                    dataSet.Clear();
                    adapter.Fill(dataSet, "SC010100");
                    if (dataSet.Tables["SC010100"].Rows.Count != 0)
                    {
                        row = dataSet.Tables["SC010100"].Rows[0];
                        str = StringType.FromObject(row["SC01128"]);
                        str2 = StringType.FromObject(row["SY24003"]);
                    }
                    else
                    {
                        str = "";
                        str2 = "";
                    }
                    cmdText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpRepGesEns (NroOE,FechaOE,FechaEnt,FechaEnsReal,NroLinea,Codigo,Descripcion,Grupo,NomGrupo,CantOE,CantArmado,Cliente,NroOV,Obs) values ('", reader["OR01001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR01016"]), "MM/dd/yyyy")), "',"));
                    if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(reader["OR19011"])))
                    {
                        cmdText = cmdText + "'" + Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR19011"]), "MM/dd/yyyy") + "',";
                    }
                    else
                    {
                        cmdText = cmdText + "Null,";
                    }
                    cmdText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(cmdText + "'", reader["OR03002"]), "','"), reader["OR03005"]), "','"), Strings.Trim(StringType.FromObject(reader["OR03006"]))), " "), Strings.Trim(StringType.FromObject(reader["OR03007"]))), "','"), str), "','"), str2), "',"), ObjectType.MulObj(reader["OR03011"], -1)), ","), ObjectType.MulObj(reader["OR03012"], -1)), ","));
                    if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR04002"])), "0", false) == 0)
                    {
                        cmdText = cmdText + "'',";
                    }
                    else
                    {
                        cmdText = cmdText + "'" + Strings.Trim(StringType.FromObject(reader["OR04002"])) + "',";
                    }
                    if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR04003"])), "0", false) == 0)
                    {
                        cmdText = cmdText + "'','')";
                    }
                    else
                    {
                        cmdText = cmdText + "'" + Strings.Format(Conversion.Val(Strings.Mid(StringType.FromObject(reader["OR04003"]), 1, 10)), "0000000000") + "','')";
                    }
                    command = new SqlCommand(cmdText, connection2);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception4)
                    {
                        ProjectData.SetProjectError(exception4);
                        Exception exception2 = exception4;
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, 0, null);
                        reader.Close();
                        connection.Close();
                        connection2.Close();
                        ProjectData.ClearProjectError();
                        return;
                        ProjectData.ClearProjectError();
                    }
                }
                reader.Close();
                cmdText = "SELECT DISTINCT OR200100.OR20001,OR200100.OR20015,OR200100.OR20016,OR210100.OR21002,OR210100.OR21005,OR210100.OR21006,OR210100.OR21007,OR210100.OR21011,OR210100.OR21012,OR230100.OR23011,OR220100.OR22002,OR220100.OR22003,OR220100.OR22004,OR220100.OR22005,OR220100.OR22008 FROM dbo.OR200100 INNER JOIN dbo.OR210100 on OR200100.OR20001=OR210100.OR21001 LEFT OUTER JOIN dbo.OR220100 on OR200100.OR20001=OR220100.OR22001 LEFT OUTER JOIN dbo.OR230100 on OR210100.OR21001=OR230100.OR23001 and OR210100.OR21002=OR230100.OR23002 and OR210100.OR21065=OR230100.OR23034 where OR200100.OR20002=6 and OR210100.OR21003='000' and OR230100.OR23003='000' ";
                if (this.dtpFechaDesde.Checked & this.dtpFechaHasta.Checked)
                {
                    cmdText = cmdText + " and OR230100.OR23011>='" + Strings.Format(DateType.FromString(Variables.gDesde), "MM/dd/yyyy") + "' and OR230100.OR23011<='" + Strings.Format(DateType.FromString(Variables.gHasta), "MM/dd/yyyy") + "'";
                }
                if (StringType.StrCmp(Variables.gNroOE, "", false) != 0)
                {
                    cmdText = cmdText + " and OR200100.OR20001='" + Variables.gNroOE + "'";
                }
                if (StringType.StrCmp(Variables.gNroOV, "", false) != 0)
                {
                    cmdText = cmdText + " and rtrim(OR220100.OR22003)='" + Variables.gNroOV + "'";
                }
                command = new SqlCommand(cmdText, connection);
                command.CommandTimeout = 500;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    adapter = new SqlDataAdapter(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("Select SC01128,SY24003 from SC010100 inner join SY240100 on SC01128=SY24002 where SC01001='", reader["OR21005"]), "' and SY24001='II'")), connectionString);
                    dataSet.Clear();
                    adapter.Fill(dataSet, "SC010100");
                    if (dataSet.Tables["SC010100"].Rows.Count != 0)
                    {
                        row = dataSet.Tables["SC010100"].Rows[0];
                        str = StringType.FromObject(row["SC01128"]);
                        str2 = StringType.FromObject(row["SY24003"]);
                    }
                    else
                    {
                        str = "";
                        str2 = "";
                    }
                    cmdText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpRepGesEns (NroOE,FechaOE,FechaEnt,FechaEnsReal,NroLinea,Codigo,Descripcion,Grupo,NomGrupo,CantOE,CantArmado,Cliente,NroOV,Obs) values ('", reader["OR20001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR20015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR20016"]), "MM/dd/yyyy")), "',"));
                    if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(reader["OR23011"])))
                    {
                        cmdText = cmdText + "'" + Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR23011"]), "MM/dd/yyyy") + "',";
                    }
                    else
                    {
                        cmdText = cmdText + "Null,";
                    }
                    cmdText = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(cmdText + "'", reader["OR21002"]), "','"), reader["OR21005"]), "','"), Strings.Trim(StringType.FromObject(reader["OR21006"]))), " "), Strings.Trim(StringType.FromObject(reader["OR21007"]))), "','"), str), "','"), str2), "',"), ObjectType.MulObj(reader["OR21011"], -1)), ","), ObjectType.MulObj(reader["OR21012"], -1)), ","));
                    if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR22002"])), "0", false) == 0)
                    {
                        cmdText = cmdText + "'',";
                    }
                    else
                    {
                        cmdText = cmdText + "'" + Strings.Trim(StringType.FromObject(reader["OR22002"])) + "',";
                    }
                    if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR22003"])), "0", false) == 0)
                    {
                        cmdText = cmdText + "'','')";
                    }
                    else
                    {
                        cmdText = cmdText + "'" + Strings.Format(Conversion.Val(Strings.Mid(StringType.FromObject(reader["OR22003"]), 1, 10)), "0000000000") + "','')";
                    }
                    command = new SqlCommand(cmdText, connection2);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception5)
                    {
                        ProjectData.SetProjectError(exception5);
                        Exception exception3 = exception5;
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception3.Message, 0, null);
                        reader.Close();
                        connection.Close();
                        connection2.Close();
                        ProjectData.ClearProjectError();
                        return;
                        ProjectData.ClearProjectError();
                    }
                }
                reader.Close();
                connection2.Close();
                connection.Close();
                frmRepEnsXFecha1 fecha = new frmRepEnsXFecha1();
                this.Hide();
                fecha.Show();
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

        private void dtpFechaDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.dtpFechaHasta.Focus();
            }
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtpFechaDesde.Checked)
            {
                this.dtpFechaHasta.Checked = true;
            }
        }

        private void dtpFechaHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editNroOE.Focus();
            }
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtpFechaHasta.Checked)
            {
                this.dtpFechaDesde.Checked = true;
            }
        }

        private void editNroOE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editNroOV.Focus();
            }
        }

        private void editNroOE_TextChanged(object sender, EventArgs e)
        {
        }

        private void editNroOV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.rbPorProd.Focus();
            }
        }

        private void editNroOV_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void editNroOV_TextChanged(object sender, EventArgs e)
        {
        }

        ~frmRepEnsXFecha()
        {
        }

        private void frmRepEnsXFecha_Closed(object sender, EventArgs e)
        {
            new frmMenuEns().Show();
        }

        private void frmRepEnsXFecha_Load(object sender, EventArgs e)
        {
            this.dtpFechaDesde.Value = DateAndTime.get_Now();
            this.dtpFechaHasta.Value = DateAndTime.get_Now();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.Label2 = new Label();
            this.Label1 = new Label();
            this.Label3 = new Label();
            this.dtpFechaDesde = new DateTimePicker();
            this.dtpFechaHasta = new DateTimePicker();
            this.Label4 = new Label();
            this.editNroOE = new TextBox();
            this.Label5 = new Label();
            this.editNroOV = new TextBox();
            this.rbPorProd = new RadioButton();
            this.rbPorGrupoProd = new RadioButton();
            this.SuspendLayout();
            Point point = new Point(0x148, 0x148);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 11;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0xe0, 0x148);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 12;
            this.cmbSalir.Text = "&Salir";
            this.Label2.Font = new Font("Arial", 12f, FontStyle.Underline | FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0xa8, 0x60);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x138, 20);
            this.Label2.Size = size;
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Reporte Ensamblados por Fecha";
            this.Label2.TextAlign = ContentAlignment.MiddleCenter;
            point = new Point(160, 0x90);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(200, 0x10);
            this.Label1.Size = size;
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Desde Fecha Ensamblado Real:";
            point = new Point(160, 0xb0);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(200, 0x10);
            this.Label3.Size = size;
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Hasta Fecha Ensamblado Real:";
            this.dtpFechaDesde.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaDesde.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaDesde.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaDesde.Format = DateTimePickerFormat.Short;
            point = new Point(0x170, 0x90);
            this.dtpFechaDesde.Location = point;
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.ShowCheckBox = true;
            size = new Size(0x70, 0x16);
            this.dtpFechaDesde.Size = size;
            this.dtpFechaDesde.TabIndex = 2;
            DateTime time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpFechaDesde.Value = time;
            this.dtpFechaHasta.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaHasta.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaHasta.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpFechaHasta.Format = DateTimePickerFormat.Short;
            point = new Point(0x170, 0xb0);
            this.dtpFechaHasta.Location = point;
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.ShowCheckBox = true;
            size = new Size(0x70, 0x16);
            this.dtpFechaHasta.Size = size;
            this.dtpFechaHasta.TabIndex = 4;
            time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpFechaHasta.Value = time;
            this.Label4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0xd0);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(200, 0x17);
            this.Label4.Size = size;
            this.Label4.TabIndex = 5;
            this.Label4.Text = "Nro.Orden de Ensamblado:";
            this.editNroOE.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x170, 0xd0);
            this.editNroOE.Location = point;
            this.editNroOE.MaxLength = 10;
            this.editNroOE.Name = "editNroOE";
            size = new Size(0x70, 20);
            this.editNroOE.Size = size;
            this.editNroOE.TabIndex = 6;
            this.editNroOE.Text = "";
            this.Label5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 240);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size(200, 0x17);
            this.Label5.Size = size;
            this.Label5.TabIndex = 7;
            this.Label5.Text = "Nro.Orden de Venta:";
            this.editNroOV.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x170, 240);
            this.editNroOV.Location = point;
            this.editNroOV.MaxLength = 10;
            this.editNroOV.Name = "editNroOV";
            size = new Size(0x70, 20);
            this.editNroOV.Size = size;
            this.editNroOV.TabIndex = 8;
            this.editNroOV.Text = "";
            this.rbPorProd.Checked = true;
            point = new Point(160, 280);
            this.rbPorProd.Location = point;
            this.rbPorProd.Name = "rbPorProd";
            size = new Size(120, 0x20);
            this.rbPorProd.Size = size;
            this.rbPorProd.TabIndex = 9;
            this.rbPorProd.TabStop = true;
            this.rbPorProd.Text = "Por Producto";
            point = new Point(0x138, 280);
            this.rbPorGrupoProd.Location = point;
            this.rbPorGrupoProd.Name = "rbPorGrupoProd";
            size = new Size(0xa8, 0x20);
            this.rbPorGrupoProd.Size = size;
            this.rbPorGrupoProd.TabIndex = 10;
            this.rbPorGrupoProd.Text = "Por Grupo de Producto";
            size = new Size(6, 15);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.rbPorGrupoProd);
            this.Controls.Add(this.rbPorProd);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.editNroOV);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.editNroOE);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Name = "frmRepEnsXFecha";
            this.Text = "Reporte Ensamblados por Fecha";
            this.WindowState = FormWindowState.Maximized;
            this.ResumeLayout(false);
        }

        private void rbPorGrupoProd_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbPorGrupoProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void rbPorProd_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbPorProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        internal virtual Button cmbAceptar
        {
            get
            {
                return this._cmbAceptar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbAceptar != null)
                {
                    this._cmbAceptar.Click -= new EventHandler(this.cmbAceptar_Click);
                }
                this._cmbAceptar = value;
                if (this._cmbAceptar != null)
                {
                    this._cmbAceptar.Click += new EventHandler(this.cmbAceptar_Click);
                }
            }
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

        internal virtual DateTimePicker dtpFechaDesde
        {
            get
            {
                return this._dtpFechaDesde;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpFechaDesde != null)
                {
                    this._dtpFechaDesde.KeyPress -= new KeyPressEventHandler(this.dtpFechaDesde_KeyPress);
                    this._dtpFechaDesde.ValueChanged -= new EventHandler(this.dtpFechaDesde_ValueChanged);
                }
                this._dtpFechaDesde = value;
                if (this._dtpFechaDesde != null)
                {
                    this._dtpFechaDesde.KeyPress += new KeyPressEventHandler(this.dtpFechaDesde_KeyPress);
                    this._dtpFechaDesde.ValueChanged += new EventHandler(this.dtpFechaDesde_ValueChanged);
                }
            }
        }

        internal virtual DateTimePicker dtpFechaHasta
        {
            get
            {
                return this._dtpFechaHasta;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpFechaHasta != null)
                {
                    this._dtpFechaHasta.KeyPress -= new KeyPressEventHandler(this.dtpFechaHasta_KeyPress);
                    this._dtpFechaHasta.ValueChanged -= new EventHandler(this.dtpFechaHasta_ValueChanged);
                }
                this._dtpFechaHasta = value;
                if (this._dtpFechaHasta != null)
                {
                    this._dtpFechaHasta.KeyPress += new KeyPressEventHandler(this.dtpFechaHasta_KeyPress);
                    this._dtpFechaHasta.ValueChanged += new EventHandler(this.dtpFechaHasta_ValueChanged);
                }
            }
        }

        internal virtual TextBox editNroOE
        {
            get
            {
                return this._editNroOE;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editNroOE != null)
                {
                    this._editNroOE.KeyPress -= new KeyPressEventHandler(this.editNroOE_KeyPress);
                    this._editNroOE.TextChanged -= new EventHandler(this.editNroOE_TextChanged);
                }
                this._editNroOE = value;
                if (this._editNroOE != null)
                {
                    this._editNroOE.KeyPress += new KeyPressEventHandler(this.editNroOE_KeyPress);
                    this._editNroOE.TextChanged += new EventHandler(this.editNroOE_TextChanged);
                }
            }
        }

        internal virtual TextBox editNroOV
        {
            get
            {
                return this._editNroOV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editNroOV != null)
                {
                    this._editNroOV.KeyPress -= new KeyPressEventHandler(this.editNroOV_KeyPress);
                    this._editNroOV.TextChanged -= new EventHandler(this.editNroOV_TextChanged);
                    this._editNroOV.KeyUp -= new KeyEventHandler(this.editNroOV_KeyUp);
                }
                this._editNroOV = value;
                if (this._editNroOV != null)
                {
                    this._editNroOV.KeyPress += new KeyPressEventHandler(this.editNroOV_KeyPress);
                    this._editNroOV.TextChanged += new EventHandler(this.editNroOV_TextChanged);
                    this._editNroOV.KeyUp += new KeyEventHandler(this.editNroOV_KeyUp);
                }
            }
        }

        internal virtual Label Label1
        {
            get
            {
                return this._Label1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label1 != null)
                {
                }
                this._Label1 = value;
                if (this._Label1 != null)
                {
                }
            }
        }

        internal virtual Label Label2
        {
            get
            {
                return this._Label2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label2 != null)
                {
                }
                this._Label2 = value;
                if (this._Label2 != null)
                {
                }
            }
        }

        internal virtual Label Label3
        {
            get
            {
                return this._Label3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label3 != null)
                {
                }
                this._Label3 = value;
                if (this._Label3 != null)
                {
                }
            }
        }

        internal virtual Label Label4
        {
            get
            {
                return this._Label4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label4 != null)
                {
                }
                this._Label4 = value;
                if (this._Label4 != null)
                {
                }
            }
        }

        internal virtual Label Label5
        {
            get
            {
                return this._Label5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label5 != null)
                {
                }
                this._Label5 = value;
                if (this._Label5 != null)
                {
                }
            }
        }

        internal virtual RadioButton rbPorGrupoProd
        {
            get
            {
                return this._rbPorGrupoProd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbPorGrupoProd != null)
                {
                    this._rbPorGrupoProd.KeyPress -= new KeyPressEventHandler(this.rbPorGrupoProd_KeyPress);
                    this._rbPorGrupoProd.CheckedChanged -= new EventHandler(this.rbPorGrupoProd_CheckedChanged);
                }
                this._rbPorGrupoProd = value;
                if (this._rbPorGrupoProd != null)
                {
                    this._rbPorGrupoProd.KeyPress += new KeyPressEventHandler(this.rbPorGrupoProd_KeyPress);
                    this._rbPorGrupoProd.CheckedChanged += new EventHandler(this.rbPorGrupoProd_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbPorProd
        {
            get
            {
                return this._rbPorProd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbPorProd != null)
                {
                    this._rbPorProd.KeyPress -= new KeyPressEventHandler(this.rbPorProd_KeyPress);
                    this._rbPorProd.CheckedChanged -= new EventHandler(this.rbPorProd_CheckedChanged);
                }
                this._rbPorProd = value;
                if (this._rbPorProd != null)
                {
                    this._rbPorProd.KeyPress += new KeyPressEventHandler(this.rbPorProd_KeyPress);
                    this._rbPorProd.CheckedChanged += new EventHandler(this.rbPorProd_CheckedChanged);
                }
            }
        }
    }
}

