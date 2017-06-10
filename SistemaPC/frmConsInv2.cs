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
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmConsInv2 : Form
    {
        [AccessedThroughProperty("btnBusqNom")]
        private Button _btnBusqNom;
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbContinuar")]
        private Button _cmbContinuar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("editCodProd")]
        private TextBox _editCodProd;
        [AccessedThroughProperty("editDescProd1")]
        private TextBox _editDescProd1;
        [AccessedThroughProperty("editDescProd2")]
        private TextBox _editDescProd2;
        [AccessedThroughProperty("editPosicion")]
        private TextBox _editPosicion;
        [AccessedThroughProperty("editRack")]
        private TextBox _editRack;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("Label6")]
        private Label _Label6;
        [AccessedThroughProperty("lblFecUltInv")]
        private Label _lblFecUltInv;
        [AccessedThroughProperty("txtFecUltInv")]
        private TextBox _txtFecUltInv;
        public SqlDataAdapter AdapAlmacen1;
        public SqlDataAdapter AdapAlmacen2;
        private IContainer components;
        public DataSet DS;

        public frmConsInv2()
        {
            base.Closed += new EventHandler(this.frmConsInv2_Closed);
            this.DS = new DataSet();
            this.InitializeComponent();
        }

        private void btnBusqNom_Click(object sender, EventArgs e)
        {
            new frmBusqProdxDesc().ShowDialog();
            if (StringType.StrCmp(Variables.gCodProd, "", false) == 0)
            {
                this.editCodProd.Text = "";
                this.editDescProd1.Text = "";
                this.editDescProd2.Text = "";
            }
            else
            {
                this.editCodProd.Text = Variables.gCodProd;
                this.editDescProd1.Text = Variables.gDescProd1;
                this.editDescProd2.Text = Variables.gDescProd2;
            }
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            DataSet set = new DataSet();
            if (((StringType.StrCmp(this.editRack.Text, Strings.Space(0), false) == 0) & (StringType.StrCmp(this.editPosicion.Text, Strings.Space(0), false) == 0)) & (StringType.StrCmp(this.editCodProd.Text, Strings.Space(0), false) == 0))
            {
                Interaction.MsgBox("Debe indicar rack o posicion o producto a consultar", MsgBoxStyle.Critical, "Operador");
                this.editRack.Focus();
            }
            else
            {
                SqlConnection connection;
                this.editRack.Enabled = false;
                this.editPosicion.Enabled = false;
                this.editCodProd.Enabled = false;
                this.cmbAceptar.Enabled = false;
                this.cmbSalir.Enabled = false;
                try
                {
                    connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096");
                    connection.Open();
                    string str = "SELECT FechaInv FROM Inventario where ";
                    if (StringType.StrCmp(this.editRack.Text, Strings.Space(0), false) != 0)
                    {
                        if (Strings.Len(Strings.Trim(this.editRack.Text)) == 2)
                        {
                            str = str + "substring(Posicion,3,2)='" + Strings.Trim(this.editRack.Text) + "'";
                        }
                        else
                        {
                            str = str + "substring(Posicion,3,1)='" + Strings.Trim(this.editRack.Text) + "'";
                        }
                    }
                    else if (StringType.StrCmp(this.editPosicion.Text, Strings.Space(0), false) != 0)
                    {
                        str = str + "Posicion='" + this.editPosicion.Text + "'";
                    }
                    else if (StringType.StrCmp(this.editCodProd.Text, Strings.Space(0), false) != 0)
                    {
                        str = str + "Codigo='" + this.editCodProd.Text + "'";
                    }
                    SqlDataReader reader = new SqlCommand(str + " order by FechaInv desc", connection).ExecuteReader();
                    if (!reader.Read())
                    {
                        reader.Close();
                        connection.Close();
                        Interaction.MsgBox("No hay datos", MsgBoxStyle.Critical, "Operador");
                        this.editRack.Enabled = true;
                        this.editPosicion.Enabled = true;
                        this.editCodProd.Enabled = true;
                        this.editRack.Text = "";
                        this.editPosicion.Text = "";
                        this.editCodProd.Text = "";
                        this.editDescProd1.Text = "";
                        this.editDescProd2.Text = "";
                        this.cmbSalir.Enabled = true;
                        this.cmbAceptar.Enabled = true;
                        this.GroupBox1.Visible = false;
                        this.editRack.Focus();
                        return;
                    }
                    this.txtFecUltInv.Text = Strings.Format(RuntimeHelpers.GetObjectValue(reader["FechaInv"]), "dd/MM/yyyy");
                    reader.Close();
                    connection.Close();
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                    connection.Close();
                    this.cmbAceptar.Enabled = true;
                    this.cmbSalir.Enabled = true;
                    ProjectData.ClearProjectError();
                    return;
                    ProjectData.ClearProjectError();
                }
                this.GroupBox1.Visible = true;
                this.cmbContinuar.Focus();
            }
        }

        private void cmbContinuar_Click(object sender, EventArgs e)
        {
            this.editRack.Enabled = true;
            this.editPosicion.Enabled = true;
            this.editCodProd.Enabled = true;
            this.editRack.Text = "";
            this.editPosicion.Text = "";
            this.editCodProd.Text = "";
            this.editDescProd1.Text = "";
            this.editDescProd2.Text = "";
            this.cmbSalir.Enabled = true;
            this.cmbAceptar.Enabled = true;
            this.GroupBox1.Visible = false;
            this.editRack.Focus();
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

        private void editCodProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void editCodProd_LostFocus(object sender, EventArgs e)
        {
            bool flag = false;
            if (StringType.StrCmp(this.editCodProd.Text, Strings.Space(0), false) != 0)
            {
                SqlConnection connection;
                try
                {
                    connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096");
                    connection.Open();
                    flag = true;
                    SqlDataReader reader = new SqlCommand("SELECT SC01001,SC01002,SC01003 FROM SC010100 where SC01001='" + this.editCodProd.Text + "'", connection).ExecuteReader();
                    if (reader.Read())
                    {
                        this.editDescProd1.Text = StringType.FromObject(reader["SC01002"]);
                        this.editDescProd2.Text = StringType.FromObject(reader["SC01003"]);
                        reader.Close();
                    }
                    else
                    {
                        Interaction.MsgBox("Producto hasta inexistente", MsgBoxStyle.Information, "Operador");
                        this.editDescProd1.Text = "";
                        this.editDescProd2.Text = "";
                        reader.Close();
                        return;
                    }
                    connection.Close();
                    flag = false;
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    if (flag)
                    {
                        connection.Close();
                        flag = false;
                    }
                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, MsgBoxStyle.OKOnly, null);
                    this.Close();
                    ProjectData.ClearProjectError();
                }
            }
        }

        private void editCodProd_TextChanged(object sender, EventArgs e)
        {
        }

        private void editPosicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editCodProd.Focus();
            }
        }

        private void editPosicion_TextChanged(object sender, EventArgs e)
        {
        }

        private void editRack_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.editPosicion.Focus();
            }
        }

        private void editRack_TextChanged(object sender, EventArgs e)
        {
        }

        ~frmConsInv2()
        {
        }

        private void frmConsInv2_Closed(object sender, EventArgs e)
        {
            new frmConsInv().Show();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmConsInv2));
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.Label2 = new Label();
            this.Label6 = new Label();
            this.editPosicion = new TextBox();
            this.editDescProd2 = new TextBox();
            this.btnBusqNom = new Button();
            this.Label4 = new Label();
            this.editCodProd = new TextBox();
            this.editDescProd1 = new TextBox();
            this.editRack = new TextBox();
            this.lblFecUltInv = new Label();
            this.cmbContinuar = new Button();
            this.GroupBox1 = new GroupBox();
            this.txtFecUltInv = new TextBox();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            Point point = new Point(0x170, 0xb8);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 0x10;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0x108, 0xb8);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 0x11;
            this.cmbSalir.Text = "&Salir";
            this.Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x10);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(120, 0x10);
            this.Label2.Size = size;
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Rack:";
            this.Label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x30);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(0x88, 0x17);
            this.Label6.Size = size;
            this.Label6.TabIndex = 4;
            this.Label6.Text = "Posici\x00f3n:";
            this.editPosicion.BackColor = SystemColors.Window;
            this.editPosicion.CharacterCasing = CharacterCasing.Upper;
            this.editPosicion.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x30);
            this.editPosicion.Location = point;
            this.editPosicion.MaxLength = 6;
            this.editPosicion.Name = "editPosicion";
            size = new Size(0x68, 0x16);
            this.editPosicion.Size = size;
            this.editPosicion.TabIndex = 5;
            this.editPosicion.Text = "";
            this.editDescProd2.BackColor = SystemColors.Window;
            this.editDescProd2.Enabled = false;
            this.editDescProd2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x90);
            this.editDescProd2.Location = point;
            this.editDescProd2.MaxLength = 0x19;
            this.editDescProd2.Name = "editDescProd2";
            size = new Size(0x130, 0x16);
            this.editDescProd2.Size = size;
            this.editDescProd2.TabIndex = 13;
            this.editDescProd2.Text = "";
            this.btnBusqNom.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x138, 80);
            this.btnBusqNom.Location = point;
            this.btnBusqNom.Name = "btnBusqNom";
            size = new Size(0x98, 0x17);
            this.btnBusqNom.Size = size;
            this.btnBusqNom.TabIndex = 11;
            this.btnBusqNom.Text = "&B\x00fasq. por Descripci\x00f3n";
            this.Label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 80);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(0x70, 0x17);
            this.Label4.Size = size;
            this.Label4.TabIndex = 9;
            this.Label4.Text = "Producto:";
            this.editCodProd.BackColor = SystemColors.Window;
            this.editCodProd.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 80);
            this.editCodProd.Location = point;
            this.editCodProd.MaxLength = 0x23;
            this.editCodProd.Name = "editCodProd";
            size = new Size(0x90, 0x16);
            this.editCodProd.Size = size;
            this.editCodProd.TabIndex = 10;
            this.editCodProd.Text = "";
            this.editDescProd1.BackColor = SystemColors.Window;
            this.editDescProd1.Enabled = false;
            this.editDescProd1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x70);
            this.editDescProd1.Location = point;
            this.editDescProd1.MaxLength = 0x19;
            this.editDescProd1.Name = "editDescProd1";
            size = new Size(0x130, 0x16);
            this.editDescProd1.Size = size;
            this.editDescProd1.TabIndex = 12;
            this.editDescProd1.Text = "";
            this.editRack.BackColor = SystemColors.Window;
            this.editRack.CharacterCasing = CharacterCasing.Upper;
            this.editRack.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(160, 0x10);
            this.editRack.Location = point;
            this.editRack.MaxLength = 2;
            this.editRack.Name = "editRack";
            size = new Size(40, 0x16);
            this.editRack.Size = size;
            this.editRack.TabIndex = 3;
            this.editRack.Text = "";
            this.lblFecUltInv.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x20);
            this.lblFecUltInv.Location = point;
            this.lblFecUltInv.Name = "lblFecUltInv";
            size = new Size(160, 0x10);
            this.lblFecUltInv.Size = size;
            this.lblFecUltInv.TabIndex = 14;
            this.lblFecUltInv.Text = "Fecha Ultimo Inventario:";
            point = new Point(0x148, 0x18);
            this.cmbContinuar.Location = point;
            this.cmbContinuar.Name = "cmbContinuar";
            size = new Size(0x60, 40);
            this.cmbContinuar.Size = size;
            this.cmbContinuar.TabIndex = 0x12;
            this.cmbContinuar.Text = "&Continuar";
            this.GroupBox1.Controls.Add(this.txtFecUltInv);
            this.GroupBox1.Controls.Add(this.lblFecUltInv);
            this.GroupBox1.Controls.Add(this.cmbContinuar);
            point = new Point(8, 240);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(0x1c8, 0x48);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 0x13;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Visible = false;
            this.txtFecUltInv.BackColor = SystemColors.Window;
            this.txtFecUltInv.CharacterCasing = CharacterCasing.Upper;
            this.txtFecUltInv.Enabled = false;
            this.txtFecUltInv.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0xb0, 0x20);
            this.txtFecUltInv.Location = point;
            this.txtFecUltInv.MaxLength = 6;
            this.txtFecUltInv.Name = "txtFecUltInv";
            size = new Size(0x68, 0x16);
            this.txtFecUltInv.Size = size;
            this.txtFecUltInv.TabIndex = 0x13;
            this.txtFecUltInv.Text = "";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.editRack);
            this.Controls.Add(this.editDescProd2);
            this.Controls.Add(this.btnBusqNom);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.editCodProd);
            this.Controls.Add(this.editDescProd1);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.editPosicion);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmConsInv2";
            this.Text = "Consulta Inventario - Fecha \x00faltimo inventario";
            this.WindowState = FormWindowState.Maximized;
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        internal virtual Button btnBusqNom
        {
            get
            {
                return this._btnBusqNom;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._btnBusqNom != null)
                {
                    this._btnBusqNom.Click -= new EventHandler(this.btnBusqNom_Click);
                }
                this._btnBusqNom = value;
                if (this._btnBusqNom != null)
                {
                    this._btnBusqNom.Click += new EventHandler(this.btnBusqNom_Click);
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

        internal virtual Button cmbContinuar
        {
            get
            {
                return this._cmbContinuar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cmbContinuar != null)
                {
                    this._cmbContinuar.Click -= new EventHandler(this.cmbContinuar_Click);
                }
                this._cmbContinuar = value;
                if (this._cmbContinuar != null)
                {
                    this._cmbContinuar.Click += new EventHandler(this.cmbContinuar_Click);
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

        internal virtual TextBox editCodProd
        {
            get
            {
                return this._editCodProd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editCodProd != null)
                {
                    this._editCodProd.TextChanged -= new EventHandler(this.editCodProd_TextChanged);
                    this._editCodProd.LostFocus -= new EventHandler(this.editCodProd_LostFocus);
                    this._editCodProd.KeyPress -= new KeyPressEventHandler(this.editCodProd_KeyPress);
                }
                this._editCodProd = value;
                if (this._editCodProd != null)
                {
                    this._editCodProd.TextChanged += new EventHandler(this.editCodProd_TextChanged);
                    this._editCodProd.LostFocus += new EventHandler(this.editCodProd_LostFocus);
                    this._editCodProd.KeyPress += new KeyPressEventHandler(this.editCodProd_KeyPress);
                }
            }
        }

        internal virtual TextBox editDescProd1
        {
            get
            {
                return this._editDescProd1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editDescProd1 != null)
                {
                }
                this._editDescProd1 = value;
                if (this._editDescProd1 != null)
                {
                }
            }
        }

        internal virtual TextBox editDescProd2
        {
            get
            {
                return this._editDescProd2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editDescProd2 != null)
                {
                }
                this._editDescProd2 = value;
                if (this._editDescProd2 != null)
                {
                }
            }
        }

        internal virtual TextBox editPosicion
        {
            get
            {
                return this._editPosicion;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editPosicion != null)
                {
                    this._editPosicion.TextChanged -= new EventHandler(this.editPosicion_TextChanged);
                    this._editPosicion.KeyPress -= new KeyPressEventHandler(this.editPosicion_KeyPress);
                }
                this._editPosicion = value;
                if (this._editPosicion != null)
                {
                    this._editPosicion.TextChanged += new EventHandler(this.editPosicion_TextChanged);
                    this._editPosicion.KeyPress += new KeyPressEventHandler(this.editPosicion_KeyPress);
                }
            }
        }

        internal virtual TextBox editRack
        {
            get
            {
                return this._editRack;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._editRack != null)
                {
                    this._editRack.TextChanged -= new EventHandler(this.editRack_TextChanged);
                    this._editRack.KeyPress -= new KeyPressEventHandler(this.editRack_KeyPress);
                }
                this._editRack = value;
                if (this._editRack != null)
                {
                    this._editRack.TextChanged += new EventHandler(this.editRack_TextChanged);
                    this._editRack.KeyPress += new KeyPressEventHandler(this.editRack_KeyPress);
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

        internal virtual Label Label6
        {
            get
            {
                return this._Label6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._Label6 != null)
                {
                }
                this._Label6 = value;
                if (this._Label6 != null)
                {
                }
            }
        }

        internal virtual Label lblFecUltInv
        {
            get
            {
                return this._lblFecUltInv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._lblFecUltInv != null)
                {
                }
                this._lblFecUltInv = value;
                if (this._lblFecUltInv != null)
                {
                }
            }
        }

        internal virtual TextBox txtFecUltInv
        {
            get
            {
                return this._txtFecUltInv;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtFecUltInv != null)
                {
                }
                this._txtFecUltInv = value;
                if (this._txtFecUltInv != null)
                {
                }
            }
        }
    }
}

