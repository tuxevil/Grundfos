namespace SistemaPC
{
    using DateCalc;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmEtiqRetStkOE : Form
    {
        [AccessedThroughProperty("btnCancelar")]
        private Button _btnCancelar;
        [AccessedThroughProperty("btnContinuar")]
        private Button _btnContinuar;
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("editNroOE")]
        private TextBox _editNroOE;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
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
        [AccessedThroughProperty("txtFechaEntPed")]
        private TextBox _txtFechaEntPed;
        [AccessedThroughProperty("txtNomCli")]
        private TextBox _txtNomCli;
        [AccessedThroughProperty("txtNroListaRec")]
        private TextBox _txtNroListaRec;
        [AccessedThroughProperty("txtNroOV")]
        private TextBox _txtNroOV;
        private IContainer components;

        public frmEtiqRetStkOE()
        {
            base.Closed += new EventHandler(this.frmEtiqRetStkOE_Closed);
            this.InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.GroupBox1.Visible = false;
            this.editNroOE.Enabled = true;
            this.editNroOE.Text = "";
            this.cmbSalir.Enabled = true;
            this.cmbAceptar.Enabled = true;
            this.editNroOE.Focus();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\PrepPed.txt"))
            {
                FileSystem.Kill(@"C:\PrepPed.txt");
            }
            int fileNumber = FileSystem.FreeFile();
            FileSystem.FileOpen(fileNumber, @"C:\PrepPed.txt", OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
            FileSystem.PrintLine(fileNumber, new object[] { "\x0002c0000" });
            FileSystem.PrintLine(fileNumber, new object[] { "\x0002e" });
            FileSystem.PrintLine(fileNumber, new object[] { "\x0002M1407" });
            FileSystem.PrintLine(fileNumber, new object[] { "\x0002a" });
            FileSystem.PrintLine(fileNumber, new object[] { "\x0002RN" });
            FileSystem.PrintLine(fileNumber, new object[] { "\x0002s" });
            FileSystem.PrintLine(fileNumber, new object[] { "\x0002V0" });
            FileSystem.PrintLine(fileNumber, new object[] { "\x0002O0110" });
            FileSystem.PrintLine(fileNumber, new object[] { "\x0002Kf0038" });
            FileSystem.PrintLine(fileNumber, new object[] { "\x0002L" });
            FileSystem.PrintLine(fileNumber, new object[] { "D11" });
            FileSystem.PrintLine(fileNumber, new object[] { "A0" });
            FileSystem.PrintLine(fileNumber, new object[] { "Q0001" });
            FileSystem.PrintLine(fileNumber, new object[] { "491100500140094Cliente: " });
            FileSystem.PrintLine(fileNumber, new object[] { "491100500860096" + this.txtNomCli.Text });
            FileSystem.PrintLine(fileNumber, new object[] { "491100500140120Fecha Entrega      : " + this.txtFechaEntPed.Text });
            FileSystem.PrintLine(fileNumber, new object[] { "491100500140146O.Venta Nro.        : " + this.txtNroOV.Text });
            FileSystem.PrintLine(fileNumber, new object[] { "491100700140186Lista Recogida Nro.  : " + this.txtNroListaRec.Text });
            FileSystem.PrintLine(fileNumber, new object[] { "491100700140226O.Ensamblado Nro.  : " + Variables.gNroOE });
            FileSystem.PrintLine(fileNumber, new object[] { "4e5509000140329A" + this.txtNroListaRec.Text + Variables.gNroOE });
            FileSystem.PrintLine(fileNumber, new object[] { "E" });
            FileSystem.FileClose(new int[] { fileNumber });
            Interaction.Shell(@"C:\PrepPed.bat", AppWinStyle.MinimizedFocus, false, -1);
            this.GroupBox1.Visible = false;
            this.editNroOE.Enabled = true;
            this.editNroOE.Text = "";
            this.cmbSalir.Enabled = true;
            this.cmbAceptar.Enabled = true;
            this.editNroOE.Focus();
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            if (StringType.StrCmp(this.editNroOE.Text, Strings.Space(0), false) == 0)
            {
                Interaction.MsgBox("Debe indicar o.ensamblado", MsgBoxStyle.Critical, "Operador");
                this.editNroOE.Focus();
            }
            else
            {
                this.editNroOE.Enabled = false;
                this.cmbAceptar.Enabled = false;
                this.cmbSalir.Enabled = false;
                Variables.gNroOE = Strings.Format(Conversion.Val(this.editNroOE.Text), "0000000000");
                SqlConnection connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=True;packet size=4096");
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT OR010100.OR01016,OR040100.OR04002,OR040100.OR04003 FROM dbo.OR010100 LEFT OUTER JOIN dbo.OR040100 on OR010100.OR01001=OR040100.OR04001 where OR010100.OR01001='" + Variables.gNroOE + "' and OR010100.OR01002=6", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (((int) -(reader.HasRows > false)) == 0)
                {
                    reader.Close();
                    connection.Close();
                    Interaction.MsgBox("O.ensamblado inexistente", MsgBoxStyle.Critical, "Operador");
                    this.editNroOE.Enabled = true;
                    this.cmbAceptar.Enabled = true;
                    this.cmbSalir.Enabled = true;
                    this.editNroOE.Text = "";
                    this.editNroOE.Focus();
                }
                else
                {
                    reader.Read();
                    CalcDates dates = new CalcDatesClass();
                    short daysToDue = 0;
                    string dayCountType = "H";
                    string company = "01";
                    dates.WeekDate(ref daysToDue, ref DateType.FromObject(reader["OR01016"]), ref dayCountType, ref company);
                    this.txtFechaEntPed.Text = Strings.Format(dates.MidDate, "dd/MM/yyyy");
                    if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR04002"])), "0", false) == 0)
                    {
                        this.txtNomCli.Text = "";
                    }
                    else
                    {
                        this.txtNomCli.Text = Strings.Trim(StringType.FromObject(reader["OR04002"]));
                    }
                    if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR04003"])), "0", false) == 0)
                    {
                        this.txtNroOV.Text = "";
                    }
                    else
                    {
                        this.txtNroOV.Text = Strings.Format(Conversion.Val(Strings.Mid(StringType.FromObject(reader["OR04003"]), 1, 10)), "0000000000");
                    }
                    reader.Close();
                    reader = new SqlCommand("SELECT DISTINCT OR030100.OR03051 FROM dbo.OR030100 where OR030100.OR03001='" + Variables.gNroOE + "'", connection).ExecuteReader();
                    if (((int) -(reader.HasRows > false)) == 0)
                    {
                        reader.Close();
                        connection.Close();
                        Interaction.MsgBox("O.ensamblado inexistente", MsgBoxStyle.Critical, "Operador");
                        this.editNroOE.Enabled = true;
                        this.cmbAceptar.Enabled = true;
                        this.cmbSalir.Enabled = true;
                        this.editNroOE.Text = "";
                        this.editNroOE.Focus();
                    }
                    else
                    {
                        reader.Read();
                        if (StringType.StrCmp(Strings.Trim(StringType.FromObject(reader["OR03051"])), "", false) == 0)
                        {
                            reader.Close();
                            connection.Close();
                            Interaction.MsgBox("Esta O.ensamblado no tiene lista de recogida generada", MsgBoxStyle.Critical, "Operador");
                            this.editNroOE.Enabled = true;
                            this.cmbAceptar.Enabled = true;
                            this.cmbSalir.Enabled = true;
                            this.editNroOE.Text = "";
                            this.editNroOE.Focus();
                        }
                        else
                        {
                            this.txtNroListaRec.Text = Strings.Trim(StringType.FromObject(reader["OR03051"]));
                            reader.Close();
                            connection.Close();
                            this.GroupBox1.Visible = true;
                            this.btnContinuar.Focus();
                        }
                    }
                }
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

        ~frmEtiqRetStkOE()
        {
        }

        private void frmEtiqRetStkOE_Closed(object sender, EventArgs e)
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
            this.GroupBox1 = new GroupBox();
            this.txtFechaEntPed = new TextBox();
            this.txtNroOV = new TextBox();
            this.btnCancelar = new Button();
            this.btnContinuar = new Button();
            this.Label1 = new Label();
            this.Label3 = new Label();
            this.Label4 = new Label();
            this.txtNomCli = new TextBox();
            this.txtNroListaRec = new TextBox();
            this.Label5 = new Label();
            this.GroupBox1.SuspendLayout();
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
            this.GroupBox1.Controls.Add(this.txtNroListaRec);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.txtFechaEntPed);
            this.GroupBox1.Controls.Add(this.txtNroOV);
            this.GroupBox1.Controls.Add(this.btnCancelar);
            this.GroupBox1.Controls.Add(this.btnContinuar);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.txtNomCli);
            this.GroupBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0x10, 80);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(0x2a0, 160);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 5;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Datos Orden de Ensamblado";
            this.GroupBox1.Visible = false;
            this.txtFechaEntPed.BackColor = SystemColors.Window;
            this.txtFechaEntPed.Enabled = false;
            this.txtFechaEntPed.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x98, 0x18);
            this.txtFechaEntPed.Location = point;
            this.txtFechaEntPed.MaxLength = 10;
            this.txtFechaEntPed.Name = "txtFechaEntPed";
            size = new Size(0x70, 0x16);
            this.txtFechaEntPed.Size = size;
            this.txtFechaEntPed.TabIndex = 0x12;
            this.txtFechaEntPed.Text = "";
            this.txtNroOV.BackColor = SystemColors.Window;
            this.txtNroOV.Enabled = false;
            this.txtNroOV.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x98, 0x58);
            this.txtNroOV.Location = point;
            this.txtNroOV.MaxLength = 10;
            this.txtNroOV.Name = "txtNroOV";
            size = new Size(0x70, 0x16);
            this.txtNroOV.Size = size;
            this.txtNroOV.TabIndex = 6;
            this.txtNroOV.Text = "";
            this.btnCancelar.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(440, 0x68);
            this.btnCancelar.Location = point;
            this.btnCancelar.Name = "btnCancelar";
            size = new Size(0x60, 40);
            this.btnCancelar.Size = size;
            this.btnCancelar.TabIndex = 0x11;
            this.btnCancelar.Text = "&Cancelar";
            this.btnContinuar.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x228, 0x68);
            this.btnContinuar.Location = point;
            this.btnContinuar.Name = "btnContinuar";
            size = new Size(0x60, 40);
            this.btnContinuar.Size = size;
            this.btnContinuar.TabIndex = 0x10;
            this.btnContinuar.Text = "&Imprimir";
            this.Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x18);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x80, 0x10);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Fecha Ent.Pedida:";
            this.Label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x58);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(120, 0x10);
            this.Label3.Size = size;
            this.Label3.TabIndex = 5;
            this.Label3.Text = "Nro. O.Venta:";
            this.Label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x38);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(120, 0x10);
            this.Label4.Size = size;
            this.Label4.TabIndex = 2;
            this.Label4.Text = "Cliente Asignado:";
            this.txtNomCli.BackColor = SystemColors.Window;
            this.txtNomCli.Enabled = false;
            this.txtNomCli.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x98, 0x38);
            this.txtNomCli.Location = point;
            this.txtNomCli.MaxLength = 0x23;
            this.txtNomCli.Name = "txtNomCli";
            size = new Size(0x1f0, 0x16);
            this.txtNomCli.Size = size;
            this.txtNomCli.TabIndex = 4;
            this.txtNomCli.Text = "";
            this.txtNroListaRec.BackColor = SystemColors.Window;
            this.txtNroListaRec.Enabled = false;
            this.txtNroListaRec.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x98, 120);
            this.txtNroListaRec.Location = point;
            this.txtNroListaRec.MaxLength = 6;
            this.txtNroListaRec.Name = "txtNroListaRec";
            size = new Size(0x58, 0x16);
            this.txtNroListaRec.Size = size;
            this.txtNroListaRec.TabIndex = 20;
            this.txtNroListaRec.Text = "";
            this.Label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 120);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size(0x88, 0x10);
            this.Label5.Size = size;
            this.Label5.TabIndex = 0x13;
            this.Label5.Text = "Nro. Lista Recogida:";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.editNroOE);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Name = "frmEtiqRetStkOE";
            this.Text = "Impresi\x00f3n Etiquetas para Retiro de Stock de Ordenes de Ensamblado";
            this.WindowState = FormWindowState.Maximized;
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        internal virtual Button btnCancelar
        {
            get
            {
                return this._btnCancelar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnCancelar != null)
                {
                    this._btnCancelar.Click -= new EventHandler(this.btnCancelar_Click);
                }
                this._btnCancelar = value;
                if (this._btnCancelar != null)
                {
                    this._btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
                }
            }
        }

        internal virtual Button btnContinuar
        {
            get
            {
                return this._btnContinuar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnContinuar != null)
                {
                    this._btnContinuar.Click -= new EventHandler(this.btnContinuar_Click);
                }
                this._btnContinuar = value;
                if (this._btnContinuar != null)
                {
                    this._btnContinuar.Click += new EventHandler(this.btnContinuar_Click);
                }
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

        internal virtual GroupBox GroupBox1
        {
            get
            {
                return this._GroupBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._GroupBox1 != null)
                {
                }
                this._GroupBox1 = value;
                if (this._GroupBox1 != null)
                {
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

        internal virtual TextBox txtFechaEntPed
        {
            get
            {
                return this._txtFechaEntPed;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtFechaEntPed != null)
                {
                }
                this._txtFechaEntPed = value;
                if (this._txtFechaEntPed != null)
                {
                }
            }
        }

        internal virtual TextBox txtNomCli
        {
            get
            {
                return this._txtNomCli;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtNomCli != null)
                {
                }
                this._txtNomCli = value;
                if (this._txtNomCli != null)
                {
                }
            }
        }

        internal virtual TextBox txtNroListaRec
        {
            get
            {
                return this._txtNroListaRec;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtNroListaRec != null)
                {
                }
                this._txtNroListaRec = value;
                if (this._txtNroListaRec != null)
                {
                }
            }
        }

        internal virtual TextBox txtNroOV
        {
            get
            {
                return this._txtNroOV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtNroOV != null)
                {
                }
                this._txtNroOV = value;
                if (this._txtNroOV != null)
                {
                }
            }
        }
    }
}

