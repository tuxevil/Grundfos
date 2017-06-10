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

    public class frmRepRegPedExp : Form
    {
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dtpDesdeFechaEnt")]
        private DateTimePicker _dtpDesdeFechaEnt;
        [AccessedThroughProperty("dtpHastaFechaEnt")]
        private DateTimePicker _dtpHastaFechaEnt;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("Label5")]
        private Label _Label5;
        private IContainer components;

        public frmRepRegPedExp()
        {
            base.Closed += new EventHandler(this.frmRepRegPedExp_Closed);
            base.Load += new EventHandler(this.frmRepRegPedExp_Load);
            this.InitializeComponent();
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            if (!this.dtpDesdeFechaEnt.Checked & this.dtpHastaFechaEnt.Checked)
            {
                Interaction.MsgBox("Debe ingresar desde fecha entrega", MsgBoxStyle.Critical, "Operador");
                this.dtpDesdeFechaEnt.Checked = true;
            }
            else if (this.dtpDesdeFechaEnt.Checked & !this.dtpHastaFechaEnt.Checked)
            {
                Interaction.MsgBox("Debe ingresar hasta fecha entrega", MsgBoxStyle.Critical, "Operador");
                this.dtpHastaFechaEnt.Checked = true;
            }
            else
            {
                DataRow row;
                long num;
                SqlDataReader reader;
                string str4;
                this.dtpDesdeFechaEnt.Enabled = false;
                this.dtpHastaFechaEnt.Enabled = false;
                this.cmbAceptar.Enabled = false;
                this.cmbSalir.Enabled = false;
                if (this.dtpDesdeFechaEnt.Checked)
                {
                    Variables.gDesdeFechaEnt = StringType.FromDate(this.dtpDesdeFechaEnt.Value);
                }
                else
                {
                    Variables.gDesdeFechaEnt = "";
                }
                if (this.dtpHastaFechaEnt.Checked)
                {
                    Variables.gHastaFechaEnt = StringType.FromDate(this.dtpHastaFechaEnt.Value);
                }
                else
                {
                    Variables.gHastaFechaEnt = "";
                }
                SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
                SqlConnection connection2 = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
                connection2.Open();
                SqlCommand command4 = new SqlCommand("delete " + Variables.gTermi + "TmpRegPedExp", connection2);
                int num2 = command4.ExecuteNonQuery();
                string str = "SELECT OR01001,OR01004,OR01016,OR01024,OR01072,OR03019,sum((OR03011-OR03012)*OR03008) as ImpAFac,OR04005,SL01002,PL23004,SY14002 FROM dbo.OR010100 inner join OR030100 on OR010100.OR01001=OR030100.OR03001 inner join OR040100 on OR010100.OR01001=OR040100.OR04001 inner join SL010100 on OR010100.OR01004=SL010100.SL01001 inner join PL230100 on OR010100.OR01014=convert(int,PL230100.PL23003)  inner join SY140100 on OR010100.OR01028=SY140100.SY14001 where OR010100.OR01002<>6 and OR03011-OR03012<>0 and ((OR01004>='600000' and OR01004<='699000') or OR01004='00WARREXPO')";
                if (this.dtpDesdeFechaEnt.Checked & this.dtpHastaFechaEnt.Checked)
                {
                    str = str + " and OR03019>='" + Strings.Format(DateType.FromString(Variables.gDesdeFechaEnt), "MM/dd/yyyy") + "' and OR03019<='" + Strings.Format(DateType.FromString(Variables.gHastaFechaEnt), "MM/dd/yyyy") + "'";
                }
                SqlCommand command2 = new SqlCommand(str + " and PL23001='2' and PL23002='00'" + " group by OR01001,OR01004,OR01016,OR01024,OR01072,OR03019,OR04005,SL01002,PL23004,SY14002", connection);
                command2.CommandTimeout = 500;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command2;
                connection.Open();
                adapter.Fill(dataSet, "OR010100");
                long num4 = dataSet.Tables["OR010100"].Rows.Count - 1;
                for (num = 0L; num <= num4; num += 1L)
                {
                    row = dataSet.Tables["OR010100"].Rows[(int) num];
                    SqlCommand command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT PC01001,PL01002 FROM dbo.PC010100 inner join PL010100 on PC010100.PC01003=PL010100.PL01001 where PC01017='ORDEN VENT", row["OR01001"]), "'")), connection);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpRegPedExp (Tipo,Cliente,NomCli,OCCliente,NroOV,NroOCProv,NomProv,FEntPed,FEntConf,PaisDest,Moneda,MontoOV,ImpAFac,FormaDesp) values (1,'", row["OR01004"]), "','"), row["SL01002"]), "','"), row["OR01072"]), "','"), row["OR01001"]), "','"), reader["PC01001"]), "','"), reader["PL01002"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01016"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR03019"]), "MM/dd/yyyy")), "','"), row["OR04005"]), "','"), row["SY14002"]), "',"), row["OR01024"]), ","), row["ImpAFac"]), ",'"), row["PL23004"]), "')"));
                        reader.Close();
                        command4 = new SqlCommand(str4, connection2);
                    }
                    else
                    {
                        reader.Close();
                        command4 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpRegPedExp (Tipo,Cliente,NomCli,OCCliente,NroOV,NroOCProv,NomProv,FEntPed,FEntConf,PaisDest,Moneda,MontoOV,ImpAFac,FormaDesp) values (1,'", row["OR01004"]), "','"), row["SL01002"]), "','"), row["OR01072"]), "','"), row["OR01001"]), "','','','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR01016"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR03019"]), "MM/dd/yyyy")), "','"), row["OR04005"]), "','"), row["SY14002"]), "',"), row["OR01024"]), ","), row["ImpAFac"]), ",'"), row["PL23004"]), "')")), connection2);
                    }
                    try
                    {
                        num2 = command4.ExecuteNonQuery();
                    }
                    catch (Exception exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        Exception exception = exception1;
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                        connection.Close();
                        connection2.Close();
                        this.dtpDesdeFechaEnt.Enabled = true;
                        this.dtpHastaFechaEnt.Enabled = true;
                        this.cmbAceptar.Enabled = true;
                        this.cmbSalir.Enabled = true;
                        ProjectData.ClearProjectError();
                        return;
                        ProjectData.ClearProjectError();
                    }
                }
                str = "SELECT OR20001,OR20004,OR20016,OR20024,OR20072,OR21019,sum((OR21011-OR21012)*OR21008) as ImpAFac,OR22005,SL01002,PL23004,SY14002 FROM dbo.OR200100 inner join OR210100 on OR200100.OR20001=OR210100.OR21001 inner join OR220100 on OR200100.OR20001=OR220100.OR22001 inner join SL010100 on OR200100.OR20004=SL010100.SL01001 inner join PL230100 on OR200100.OR20014=convert(int,PL230100.PL23003)  inner join SY140100 on OR200100.OR20028=SY140100.SY14001 where OR200100.OR20002<>6 and OR21011-OR21012<>0 and ((OR20004>='600000' and OR20004<='699000') or OR20004='00WARREXPO')";
                if (this.dtpDesdeFechaEnt.Checked & this.dtpHastaFechaEnt.Checked)
                {
                    str = str + " and OR21019>='" + Strings.Format(DateType.FromString(Variables.gDesdeFechaEnt), "MM/dd/yyyy") + "' and OR21019<='" + Strings.Format(DateType.FromString(Variables.gHastaFechaEnt), "MM/dd/yyyy") + "'";
                }
                command2 = new SqlCommand(str + " and PL23001='2' and PL23002='00'" + " group by OR20001,OR20004,OR20016,OR20024,OR20072,OR21019,OR22005,SL01002,PL23004,SY14002", connection);
                command2.CommandTimeout = 500;
                SqlDataAdapter adapter2 = new SqlDataAdapter();
                adapter2.SelectCommand = command2;
                adapter2.Fill(dataSet, "OR200100");
                long num3 = dataSet.Tables["OR200100"].Rows.Count - 1;
                for (num = 0L; num <= num3; num += 1L)
                {
                    row = dataSet.Tables["OR200100"].Rows[(int) num];
                    reader = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT PC01001,PL01002 FROM dbo.PC010100 inner join PL010100 on PC010100.PC01003=PL010100.PL01001 where PC01017='ORDEN VENT", row["OR20001"]), "'")), connection).ExecuteReader();
                    if (reader.Read())
                    {
                        str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpRegPedExp (Tipo,Cliente,NomCli,OCCliente,NroOV,NroOCProv,NomProv,FEntPed,FEntConf,PaisDest,Moneda,MontoOV,ImpAFac,FormaDesp) values (2,'", row["OR20004"]), "','"), row["SL01002"]), "','"), row["OR20072"]), "','"), row["OR20001"]), "','"), reader["PC01001"]), "','"), reader["PL01002"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR20016"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR21019"]), "MM/dd/yyyy")), "','"), row["OR22005"]), "','"), row["SY14002"]), "',"), row["OR20024"]), ","), row["ImpAFac"]), ",'"), row["PL23004"]), "')"));
                        reader.Close();
                        command4 = new SqlCommand(str4, connection2);
                    }
                    else
                    {
                        reader.Close();
                        command4 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpRegPedExp (Tipo,Cliente,NomCli,OCCliente,NroOV,NroOCProv,NomProv,FEntPed,FEntConf,PaisDest,Moneda,MontoOV,ImpAFac,FormaDesp) values (2,'", row["OR20004"]), "','"), row["SL01002"]), "','"), row["OR20072"]), "','"), row["OR20001"]), "','','','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR20016"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(row["OR21019"]), "MM/dd/yyyy")), "','"), row["OR22005"]), "','"), row["SY14002"]), "',"), row["OR20024"]), ","), row["ImpAFac"]), ",'"), row["PL23004"]), "')")), connection2);
                    }
                    try
                    {
                        num2 = command4.ExecuteNonQuery();
                    }
                    catch (Exception exception3)
                    {
                        ProjectData.SetProjectError(exception3);
                        Exception exception2 = exception3;
                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, MsgBoxStyle.OKOnly, null);
                        connection.Close();
                        connection2.Close();
                        this.dtpDesdeFechaEnt.Enabled = true;
                        this.dtpHastaFechaEnt.Enabled = true;
                        this.cmbAceptar.Enabled = true;
                        this.cmbSalir.Enabled = true;
                        ProjectData.ClearProjectError();
                        return;
                        ProjectData.ClearProjectError();
                    }
                }
                connection.Close();
                connection2.Close();
                frmRepRegPedExp1 exp = new frmRepRegPedExp1();
                this.Hide();
                exp.Show();
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

        private void dtpDesdeFechaEnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.dtpHastaFechaEnt.Focus();
            }
        }

        private void dtpHastaFechaEnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        ~frmRepRegPedExp()
        {
        }

        private void frmRepRegPedExp_Closed(object sender, EventArgs e)
        {
            new frmMenuOVExp().Show();
        }

        private void frmRepRegPedExp_Load(object sender, EventArgs e)
        {
            this.dtpDesdeFechaEnt.Value = DateAndTime.Now;
            this.dtpHastaFechaEnt.Value = DateAndTime.Now;
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.Label4 = new Label();
            this.Label5 = new Label();
            this.dtpDesdeFechaEnt = new DateTimePicker();
            this.dtpHastaFechaEnt = new DateTimePicker();
            this.SuspendLayout();
            Point point = new Point(0x158, 0x48);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 12;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0x158, 0x10);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 13;
            this.cmbSalir.Text = "&Salir";
            point = new Point(0x10, 80);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(0xb0, 0x10);
            this.Label4.Size = size;
            this.Label4.TabIndex = 6;
            this.Label4.Text = "Hasta Fecha Entrega Confirmada:";
            point = new Point(0x10, 0x30);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size(0xb8, 0x10);
            this.Label5.Size = size;
            this.Label5.TabIndex = 4;
            this.Label5.Text = "Desde Fecha Entrega Confirmada:";
            this.dtpDesdeFechaEnt.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpDesdeFechaEnt.Checked = false;
            this.dtpDesdeFechaEnt.CustomFormat = "dd/MM/yyyy";
            this.dtpDesdeFechaEnt.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpDesdeFechaEnt.Format = DateTimePickerFormat.Short;
            point = new Point(200, 40);
            this.dtpDesdeFechaEnt.Location = point;
            this.dtpDesdeFechaEnt.Name = "dtpDesdeFechaEnt";
            this.dtpDesdeFechaEnt.ShowCheckBox = true;
            size = new Size(0x70, 0x16);
            this.dtpDesdeFechaEnt.Size = size;
            this.dtpDesdeFechaEnt.TabIndex = 5;
            DateTime time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpDesdeFechaEnt.Value = time;
            this.dtpHastaFechaEnt.CalendarFont = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpHastaFechaEnt.Checked = false;
            this.dtpHastaFechaEnt.CustomFormat = "dd/MM/yyyy";
            this.dtpHastaFechaEnt.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dtpHastaFechaEnt.Format = DateTimePickerFormat.Short;
            point = new Point(200, 0x48);
            this.dtpHastaFechaEnt.Location = point;
            this.dtpHastaFechaEnt.Name = "dtpHastaFechaEnt";
            this.dtpHastaFechaEnt.ShowCheckBox = true;
            size = new Size(0x70, 0x16);
            this.dtpHastaFechaEnt.Size = size;
            this.dtpHastaFechaEnt.TabIndex = 7;
            time = new DateTime(0x7d5, 2, 15, 0, 0, 0, 0);
            this.dtpHastaFechaEnt.Value = time;
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.dtpHastaFechaEnt);
            this.Controls.Add(this.dtpDesdeFechaEnt);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Name = "frmRepRegPedExp";
            this.Text = "Reporte Registro Pedidos Exportaci\x00f3n";
            this.WindowState = FormWindowState.Maximized;
            this.ResumeLayout(false);
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

        internal virtual DateTimePicker dtpDesdeFechaEnt
        {
            get
            {
                return this._dtpDesdeFechaEnt;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpDesdeFechaEnt != null)
                {
                    this._dtpDesdeFechaEnt.KeyPress -= new KeyPressEventHandler(this.dtpDesdeFechaEnt_KeyPress);
                }
                this._dtpDesdeFechaEnt = value;
                if (this._dtpDesdeFechaEnt != null)
                {
                    this._dtpDesdeFechaEnt.KeyPress += new KeyPressEventHandler(this.dtpDesdeFechaEnt_KeyPress);
                }
            }
        }

        internal virtual DateTimePicker dtpHastaFechaEnt
        {
            get
            {
                return this._dtpHastaFechaEnt;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dtpHastaFechaEnt != null)
                {
                    this._dtpHastaFechaEnt.KeyPress -= new KeyPressEventHandler(this.dtpHastaFechaEnt_KeyPress);
                }
                this._dtpHastaFechaEnt = value;
                if (this._dtpHastaFechaEnt != null)
                {
                    this._dtpHastaFechaEnt.KeyPress += new KeyPressEventHandler(this.dtpHastaFechaEnt_KeyPress);
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
    }
}

