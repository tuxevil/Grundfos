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

    public class frmConsEns : Form
    {
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("editNroOE")]
        private TextBox _editNroOE;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        public SqlDataAdapter Adap;
        public SqlDataAdapter Adap1;
        private IContainer components;
        public DataSet DS1;
        public DataSet DS2;

        public frmConsEns()
        {
            base.Closed += new EventHandler(this.frmConsEns_Closed);
            this.DS1 = new DataSet();
            this.DS2 = new DataSet();
            this.InitializeComponent();
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            if (StringType.StrCmp(this.editNroOE.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe indicar o.ensamblado a consultar", 0x10, "Operador");
                this.editNroOE.Focus();
            }
            else
            {
                string str3;
                string str4;
                this.editNroOE.Enabled = false;
                this.cmbAceptar.Enabled = false;
                this.cmbSalir.Enabled = false;
                Variables.gNroOE = Strings.Format(Conversion.Val(this.editNroOE.Text), "0000000000");
                SqlConnection connection2 = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096");
                connection2.Open();
                SqlCommand command = new SqlCommand("delete " + Variables.gTermi + "TmpGesEns", connection2);
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
                SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=True;packet size=4096");
                connection.Open();
                command = new SqlCommand("SELECT DISTINCT OR010100.OR01001,OR010100.OR01015,OR010100.OR01016,OR030100.OR03002,OR030100.OR03005,OR030100.OR03006,OR030100.OR03007,OR030100.OR03011,OR030100.OR03012,OR190100.OR19011,OR040100.OR04002,OR040100.OR04003,OR040100.OR04004,OR040100.OR04005,OR040100.OR04008 FROM dbo.OR010100 INNER JOIN dbo.OR030100 on OR010100.OR01001=OR030100.OR03001 LEFT OUTER JOIN dbo.OR040100 on OR010100.OR01001=OR040100.OR04001 LEFT OUTER JOIN dbo.OR190100 on OR030100.OR03001=OR190100.OR19001 and OR030100.OR03002=OR190100.OR19002 where OR010100.OR01001='" + Variables.gNroOE + "' and OR010100.OR01002=6 and OR030100.OR03003='000'", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpGesEns (NroOE,FechaOE,FechaEnt,FechaEnsReal,NroLinea,Codigo,Descripcion,CantOE,CantArmado,Cliente,NroOV,Observaciones,TiempoAsig,Obs) values ('", reader["OR01001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR01015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR01016"]), "MM/dd/yyyy")), "',"));
                    if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(reader["OR19011"])))
                    {
                        str4 = str4 + "'" + Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR19011"]), "MM/dd/yyyy") + "',";
                    }
                    else
                    {
                        str4 = str4 + "Null,";
                    }
                    str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(str4 + "'", reader["OR03002"]), "','"), reader["OR03005"]), "','"), Strings.Trim(StringType.FromObject(reader["OR03006"]))), " "), Strings.Trim(StringType.FromObject(reader["OR03007"]))), "',"), ObjectType.MulObj(reader["OR03011"], -1)), ","), ObjectType.MulObj(reader["OR03012"], -1)), ","));
                    if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR04002"])), "0", false) == 0)
                    {
                        str4 = str4 + "'',";
                    }
                    else
                    {
                        str4 = str4 + "'" + Strings.Trim(StringType.FromObject(reader["OR04002"])) + "',";
                    }
                    if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR04003"])), "0", false) == 0)
                    {
                        str4 = str4 + "'',";
                    }
                    else
                    {
                        str4 = str4 + "'" + Strings.Mid(Strings.Trim(StringType.FromObject(reader["OR04003"])), 1, 10) + "',";
                    }
                    if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR04004"])), "0", false) == 0)
                    {
                        str3 = "";
                    }
                    else
                    {
                        str3 = Strings.Trim(StringType.FromObject(reader["OR04004"])) + " ";
                    }
                    if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR04005"])), "0", false) == 0)
                    {
                        str3 = str3 + "";
                    }
                    else
                    {
                        str3 = str3 + Strings.Trim(StringType.FromObject(reader["OR04005"]));
                    }
                    str4 = str4 + "'" + str3 + "',";
                    if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR04008"])), "0", false) == 0)
                    {
                        str4 = str4 + "'','')";
                    }
                    else
                    {
                        str4 = str4 + "'" + Strings.Trim(StringType.FromObject(reader["OR04008"])) + "','')";
                    }
                    command = new SqlCommand(str4, connection2);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception6)
                    {
                        ProjectData.SetProjectError(exception6);
                        Exception exception2 = exception6;
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
                command = new SqlCommand("SELECT DISTINCT OR200100.OR20001,OR200100.OR20015,OR200100.OR20016,OR210100.OR21002,OR210100.OR21005,OR210100.OR21006,OR210100.OR21007,OR210100.OR21011,OR210100.OR21012,OR230100.OR23011,OR220100.OR22002,OR220100.OR22003,OR220100.OR22004,OR220100.OR22005,OR220100.OR22008 FROM dbo.OR200100 INNER JOIN dbo.OR210100 on OR200100.OR20001=OR210100.OR21001 LEFT OUTER JOIN dbo.OR220100 on OR200100.OR20001=OR220100.OR22001 LEFT OUTER JOIN dbo.OR230100 on OR210100.OR21001=OR230100.OR23001 and OR210100.OR21002=OR230100.OR23002 where OR200100.OR20001='" + Variables.gNroOE + "' and OR200100.OR20002=6 and OR210100.OR21003='000'", connection);
                command.CommandTimeout = 500;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into " + Variables.gTermi + "TmpGesEns (NroOE,FechaOE,FechaEnt,FechaEnsReal,NroLinea,Codigo,Descripcion,CantOE,CantArmado,Cliente,NroOV,Observaciones,TiempoAsig,Obs) values ('", reader["OR20001"]), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR20015"]), "MM/dd/yyyy")), "','"), Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR20016"]), "MM/dd/yyyy")), "',"));
                    if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(reader["OR23011"])))
                    {
                        str4 = str4 + "'" + Strings.Format(RuntimeHelpers.GetObjectValue(reader["OR23011"]), "MM/dd/yyyy") + "',";
                    }
                    else
                    {
                        str4 = str4 + "Null,";
                    }
                    str4 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(str4 + "'", reader["OR21002"]), "','"), reader["OR21005"]), "','"), Strings.Trim(StringType.FromObject(reader["OR21006"]))), " "), Strings.Trim(StringType.FromObject(reader["OR21007"]))), "',"), ObjectType.MulObj(reader["OR21011"], -1)), ","), ObjectType.MulObj(reader["OR21012"], -1)), ","));
                    if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR22002"])), "0", false) == 0)
                    {
                        str4 = str4 + "'',";
                    }
                    else
                    {
                        str4 = str4 + "'" + Strings.Trim(StringType.FromObject(reader["OR22002"])) + "',";
                    }
                    if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR22003"])), "0", false) == 0)
                    {
                        str4 = str4 + "'',";
                    }
                    else
                    {
                        str4 = str4 + "'" + Strings.Mid(Strings.Trim(StringType.FromObject(reader["OR22003"])), 1, 10) + "',";
                    }
                    if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR22004"])), "0", false) == 0)
                    {
                        str3 = "";
                    }
                    else
                    {
                        str3 = Strings.Trim(StringType.FromObject(reader["OR22004"])) + " ";
                    }
                    if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR22005"])), "0", false) == 0)
                    {
                        str3 = str3 + "";
                    }
                    else
                    {
                        str3 = str3 + Strings.Trim(StringType.FromObject(reader["OR22005"]));
                    }
                    str4 = str4 + "'" + str3 + "',";
                    if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR22008"])), "0", false) == 0)
                    {
                        str4 = str4 + "'','')";
                    }
                    else
                    {
                        str4 = str4 + "'" + Strings.Trim(StringType.FromObject(reader["OR22008"])) + "','')";
                    }
                    command = new SqlCommand(str4, connection2);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception7)
                    {
                        ProjectData.SetProjectError(exception7);
                        Exception exception3 = exception7;
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
                command = new SqlCommand("SELECT NroOE,NroLinea from " + Variables.gTermi + "TmpGesEns", connection2);
                command.CommandTimeout = 500;
                this.Adap1 = new SqlDataAdapter();
                this.Adap1.SelectCommand = command;
                this.DS2.Clear();
                this.Adap1.Fill(this.DS2, Variables.gTermi + "TmpGesEns");
                int num3 = this.DS2.Tables[Variables.gTermi + "TmpGesEns"].Rows.Count - 1;
                for (int i = 0; i <= num3; i++)
                {
                    DataRow row2 = this.DS2.Tables[Variables.gTermi + "TmpGesEns"].Rows[i];
                    string str2 = StringType.FromObject(row2["NroOE"]);
                    string str = StringType.FromObject(row2["NroLinea"]);
                    command = new SqlCommand("SELECT OpRecoleccion,OpArmado,OpPrueba,OpEmbalaje,TRecoleccion,TArmado,TPrueba,TEmbalaje FROM dbo.GesEns where NroOE='" + str2 + "' and NroLinea='" + str + "'", connection2);
                    command.CommandTimeout = 500;
                    this.Adap = new SqlDataAdapter();
                    this.Adap.SelectCommand = command;
                    this.DS1.Clear();
                    this.Adap.Fill(this.DS1, "GesEns");
                    if (this.DS1.Tables["GesEns"].Rows.Count != 0)
                    {
                        DataRow row = this.DS1.Tables["GesEns"].Rows[0];
                        command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("update " + Variables.gTermi + "TmpGesEns set OpRecoleccion='", row["OpRecoleccion"]), "',OpArmado='"), row["OpArmado"]), "',OpPrueba='"), row["OpPrueba"]), "',OpEmbalaje='"), row["OpEmbalaje"]), "',TRecoleccion="), row["TRecoleccion"]), ",TArmado="), row["TArmado"]), ",TPrueba="), row["TPrueba"]), ",TEmbalaje="), row["TEmbalaje"]), " where NroOE='"), str2), "' and NroLinea='"), str), "'")), connection2);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception exception8)
                        {
                            ProjectData.SetProjectError(exception8);
                            Exception exception4 = exception8;
                            Interaction.MsgBox("Se ha producido el siguiente error:" + exception4.Message, 0, null);
                            reader.Close();
                            connection.Close();
                            connection2.Close();
                            ProjectData.ClearProjectError();
                            return;
                            ProjectData.ClearProjectError();
                        }
                    }
                }
                command = new SqlCommand("update " + Variables.gTermi + "TmpGesEns set Obs='OBS'where (NroOE in (select NroOE from GesEnsObs)) and (NroLinea in (select NroLinea from GesEnsObs))", connection2);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception exception9)
                {
                    ProjectData.SetProjectError(exception9);
                    Exception exception5 = exception9;
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception5.Message, 0, null);
                    reader.Close();
                    connection.Close();
                    connection2.Close();
                    ProjectData.ClearProjectError();
                    return;
                    ProjectData.ClearProjectError();
                }
                connection2.Close();
                connection.Close();
                frmConsEns1 ens = new frmConsEns1();
                this.Hide();
                ens.Show();
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

        private void editNroOE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        ~frmConsEns()
        {
        }

        private void frmConsEns_Closed(object sender, EventArgs e)
        {
            new frmMenuEns().Show();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.Label2 = new Label();
            this.editNroOE = new TextBox();
            this.SuspendLayout();
            Point point = new Point(0x188, 0x10);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 2;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0x120, 0x10);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 3;
            this.cmbSalir.Text = "&Salir";
            this.Label2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x18);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x70, 0x17);
            this.Label2.Size = size;
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Nro.O.Ensamblado:";
            this.editNroOE.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x88, 0x18);
            this.editNroOE.Location = point;
            this.editNroOE.MaxLength = 10;
            this.editNroOE.Name = "editNroOE";
            size = new Size(0x70, 20);
            this.editNroOE.Size = size;
            this.editNroOE.TabIndex = 1;
            this.editNroOE.Text = "";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.editNroOE);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Name = "frmConsEns";
            this.Text = "Consulta Ordenes de Ensamblado";
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
                }
                this._editNroOE = value;
                if (this._editNroOE != null)
                {
                    this._editNroOE.KeyPress += new KeyPressEventHandler(this.editNroOE_KeyPress);
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
    }
}

