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

    public class frmSelecDesp : Form
    {
        [AccessedThroughProperty("cbPackList")]
        private ComboBox _cbPackList;
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        public SqlDataAdapter Adap;
        public SqlDataAdapter AdapDespacho;
        public SqlCommandBuilder CB;
        private IContainer components;
        public DataSet DS;

        public frmSelecDesp()
        {
            base.Load += new EventHandler(this.frmSelecDesp_Load);
            this.DS = new DataSet();
            this.InitializeComponent();
        }

        private void cbPackList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            if (BooleanType.FromObject(ObjectType.BitAndObj(StringType.StrCmp(this.cbPackList.Text, Strings.Space(0), false) == 0, ObjectType.ObjTst(this.cbPackList.SelectedValue, Strings.Space(0), false) == 0)))
            {
                Interaction.MsgBox("Debe seleccionar packing list", 0x10, "Operador");
                this.cbPackList.Focus();
            }
            else
            {
                this.cbPackList.Enabled = false;
                this.cmbAceptar.Enabled = false;
                Variables.gPackList = StringType.FromObject(this.cbPackList.SelectedValue);
                this.Close();
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

        ~frmSelecDesp()
        {
        }

        private void frmSelecDesp_Load(object sender, EventArgs e)
        {
            bool flag = false;
            try
            {
                string str;
                string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
                if (StringType.StrCmp(Variables.gOpc, "D", false) == 0)
                {
                    str = "select distinct (rtrim(PackList) + ' - ' + rtrim(NroPL)) as PLComp,PackList from Bultos order by rtrim(PackList) + ' - ' + rtrim(NroPL)";
                }
                else if (StringType.StrCmp(Variables.gOpc, "B", false) == 0)
                {
                    str = "select distinct (rtrim(PackList) + ' - ' + rtrim(NroPL)) as PLComp,PackList from Bultos order by rtrim(PackList) + ' - ' + rtrim(NroPL)";
                }
                this.AdapDespacho = new SqlDataAdapter(str, selectConnectionString);
                this.DS.Tables.Clear();
                this.AdapDespacho.Fill(this.DS, "Bultos");
                this.cbPackList.DataSource = this.DS.Tables["Bultos"];
                this.cbPackList.DisplayMember = "PLComp";
                this.cbPackList.ValueMember = "PackList";
                this.cbPackList.Refresh();
                new SqlConnection(selectConnectionString).Open();
                flag = true;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                if (flag)
                {
                    SqlConnection connection;
                    connection.Close();
                    flag = false;
                }
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                this.Close();
                ProjectData.ClearProjectError();
            }
            this.cbPackList.Text = "";
            this.cbPackList.SelectedValue = "";
            this.cbPackList.Focus();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.Label2 = new Label();
            this.cbPackList = new ComboBox();
            this.SuspendLayout();
            Point point = new Point(0x128, 0x40);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 8;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0xc0, 0x40);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 9;
            this.cmbSalir.Text = "&Salir";
            this.Label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 20);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x58, 0x10);
            this.Label2.Size = size;
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Packing List:";
            this.cbPackList.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x70, 0x10);
            this.cbPackList.Location = point;
            this.cbPackList.Name = "cbPackList";
            size = new Size(0x120, 0x18);
            this.cbPackList.Size = size;
            this.cbPackList.TabIndex = 5;
            this.cbPackList.Text = "ComboBox1";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.cbPackList);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Name = "frmSelecDesp";
            this.Text = "Selecci\x00f3n Packing List";
            this.WindowState = FormWindowState.Maximized;
            this.ResumeLayout(false);
        }

        internal virtual ComboBox cbPackList
        {
            get
            {
                return this._cbPackList;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._cbPackList != null)
                {
                    this._cbPackList.KeyPress -= new KeyPressEventHandler(this.cbPackList_KeyPress);
                }
                this._cbPackList = value;
                if (this._cbPackList != null)
                {
                    this._cbPackList.KeyPress += new KeyPressEventHandler(this.cbPackList_KeyPress);
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

