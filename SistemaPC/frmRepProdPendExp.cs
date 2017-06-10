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

    public class frmRepProdPendExp : Form
    {
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("rbArticulo")]
        private RadioButton _rbArticulo;
        [AccessedThroughProperty("rbCliente")]
        private RadioButton _rbCliente;
        [AccessedThroughProperty("rbFechaOV")]
        private RadioButton _rbFechaOV;
        [AccessedThroughProperty("rbNroOV")]
        private RadioButton _rbNroOV;
        [AccessedThroughProperty("rbNroRemito")]
        private RadioButton _rbNroRemito;
        private IContainer components;
        public DataSet DS;
        public DataSet DS19;
        public DataSet DS20;

        public frmRepProdPendExp()
        {
            base.Closed += new EventHandler(this.frmRepProdPendExp_Closed);
            base.Load += new EventHandler(this.frmRepProdPendExp_Load);
            this.DS = new DataSet();
            this.DS19 = new DataSet();
            this.DS20 = new DataSet();
            this.InitializeComponent();
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            if ((((!this.rbArticulo.Checked & !this.rbNroOV.Checked) & !this.rbCliente.Checked) & !this.rbFechaOV.Checked) & !this.rbNroRemito.Checked)
            {
                Interaction.MsgBox("Debe indicar ordenamiento del reporte", MsgBoxStyle.Critical, "Operador");
                this.rbArticulo.Focus();
            }
            else
            {
                SqlDataAdapter adapter2;
                SqlCommand command2;
                DataRow row;
                DataRow row2;
                int num;
                int num3;
                this.cmbAceptar.Enabled = false;
                this.cmbSalir.Enabled = false;
                if (this.rbArticulo.Checked)
                {
                    Variables.gOrdenProdPend = 1;
                }
                else if (this.rbNroOV.Checked)
                {
                    Variables.gOrdenProdPend = 2;
                }
                else if (this.rbCliente.Checked)
                {
                    Variables.gOrdenProdPend = 3;
                }
                else if (this.rbFechaOV.Checked)
                {
                    Variables.gOrdenProdPend = 4;
                }
                else if (this.rbNroRemito.Checked)
                {
                    Variables.gOrdenProdPend = 5;
                }
                string connectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
                SqlConnection connection2 = new SqlConnection(connectionString);
                connection2.Open();
                string str6 = "data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=False;packet size=4096";
                SqlConnection connection = new SqlConnection(str6);
                connection.Open();
                string selectCommandText = "select * from PrepPed where ContFinal='N' and NroRemito is null";
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, connectionString);
                adapter.Fill(this.DS, "PrepPed");
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
                                        this.cmbAceptar.Enabled = true;
                                        this.cmbSalir.Enabled = true;
                                        connection2.Close();
                                        this.cmbAceptar.Focus();
                                        ProjectData.ClearProjectError();
                                        return;
                                        ProjectData.ClearProjectError();
                                    }
                                }
                                num2++;
                            }
                        }
                        else
                        {
                            string str2;
                            if (ObjectType.ObjTst(row["Producto"], 1, false) == 0)
                            {
                                command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR19012 from OR190100 where OR19001='", row["NroOV"]), "' and OR19002='"), row["NroLinea"]), "' and OR19003<>'000' and OR19011='"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FechaPrep"]), "MM/dd/yyyy")), "' and OR19012<>'' order by OR19012")), connection);
                                reader = command.ExecuteReader();
                                if (reader.Read())
                                {
                                    try
                                    {
                                        str2 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("update PrepPed set NroRemito='", reader["OR19012"]), "' where NroOV='"), row["NroOV"]), "' and NroLinea='"), row["NroLinea"]), "' and TipoLinea="), row["TipoLinea"]), " and EstLinea='"), row["EstLinea"]), "' and NroRemito is null"));
                                        reader.Close();
                                        command2 = new SqlCommand(str2, connection2);
                                        num3 = command2.ExecuteNonQuery();
                                    }
                                    catch (Exception exception7)
                                    {
                                        ProjectData.SetProjectError(exception7);
                                        Exception exception2 = exception7;
                                        Interaction.MsgBox("Se ha producido el siguiente error:" + exception2.Message, MsgBoxStyle.OKOnly, null);
                                        this.cmbAceptar.Enabled = true;
                                        this.cmbSalir.Enabled = true;
                                        connection2.Close();
                                        this.cmbAceptar.Focus();
                                        ProjectData.ClearProjectError();
                                        return;
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
                                        command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("Select NroRemito from PrepPed where NroOV='", row["NroOV"]), "' and NroLinea='"), row["NroLinea"]), "' and TipoLinea="), row["TipoLinea"]), " and EstLinea='"), row["EstLinea"]), "' and NroRemito='"), row2["OR23012"]), "'")), connection2);
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
                                                command2 = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("update PrepPed set NroRemito='", row2["OR23012"]), "' where NroOV='"), row["NroOV"]), "' and NroLinea='"), row["NroLinea"]), "' and TipoLinea="), row["TipoLinea"]), " and EstLinea='"), row["EstLinea"]), "' and NroRemito is null")), connection2);
                                                num3 = command2.ExecuteNonQuery();
                                            }
                                            catch (Exception exception8)
                                            {
                                                ProjectData.SetProjectError(exception8);
                                                Exception exception3 = exception8;
                                                Interaction.MsgBox("Se ha producido el siguiente error:" + exception3.Message, MsgBoxStyle.OKOnly, null);
                                                this.cmbAceptar.Enabled = true;
                                                this.cmbSalir.Enabled = true;
                                                connection2.Close();
                                                this.cmbAceptar.Focus();
                                                ProjectData.ClearProjectError();
                                                return;
                                                ProjectData.ClearProjectError();
                                            }
                                        }
                                    }
                                }
                                else if (ObjectType.ObjTst(row["Producto"], 1, false) == 0)
                                {
                                    reader = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("select OR23012 from OR230100 where OR23001='", row["NroOV"]), "' and OR23002='"), row["NroLinea"]), "' and OR23003<>'000' and OR23011='"), Strings.Format(RuntimeHelpers.GetObjectValue(row["FechaPrep"]), "MM/dd/yyyy")), "' and OR23012<>'' order by OR23012")), connection).ExecuteReader();
                                    if (reader.Read())
                                    {
                                        try
                                        {
                                            str2 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("update PrepPed set NroRemito='", reader["OR23012"]), "' where NroOV='"), row["NroOV"]), "' and NroLinea='"), row["NroLinea"]), "' and TipoLinea="), row["TipoLinea"]), " and EstLinea='"), row["EstLinea"]), "' and NroRemito is null"));
                                            reader.Close();
                                            command2 = new SqlCommand(str2, connection2);
                                            num3 = command2.ExecuteNonQuery();
                                        }
                                        catch (Exception exception9)
                                        {
                                            ProjectData.SetProjectError(exception9);
                                            Exception exception4 = exception9;
                                            Interaction.MsgBox("Se ha producido el siguiente error:" + exception4.Message, MsgBoxStyle.OKOnly, null);
                                            this.cmbAceptar.Enabled = true;
                                            this.cmbSalir.Enabled = true;
                                            connection2.Close();
                                            this.cmbAceptar.Focus();
                                            ProjectData.ClearProjectError();
                                            return;
                                            ProjectData.ClearProjectError();
                                        }
                                    }
                                    else
                                    {
                                        reader.Close();
                                    }
                                }
                            }
                        }
                    }
                }
                selectCommandText = "select NroOV from PrepPed where ContFinal='N' group by NroOV";
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
                            catch (Exception exception10)
                            {
                                ProjectData.SetProjectError(exception10);
                                Exception exception5 = exception10;
                                Interaction.MsgBox("Se ha producido el siguiente error:" + exception5.Message, MsgBoxStyle.OKOnly, null);
                                this.cmbAceptar.Enabled = true;
                                this.cmbSalir.Enabled = true;
                                connection2.Close();
                                this.cmbAceptar.Focus();
                                ProjectData.ClearProjectError();
                                return;
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
                                catch (Exception exception11)
                                {
                                    ProjectData.SetProjectError(exception11);
                                    Exception exception6 = exception11;
                                    Interaction.MsgBox("Se ha producido el siguiente error:" + exception6.Message, MsgBoxStyle.OKOnly, null);
                                    this.cmbAceptar.Enabled = true;
                                    this.cmbSalir.Enabled = true;
                                    connection2.Close();
                                    this.cmbAceptar.Focus();
                                    ProjectData.ClearProjectError();
                                    return;
                                    ProjectData.ClearProjectError();
                                }
                            }
                        }
                    }
                }
                connection2.Close();
                frmRepProdPendExp1 exp = new frmRepProdPendExp1();
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

        ~frmRepProdPendExp()
        {
        }

        private void frmRepProdPendExp_Closed(object sender, EventArgs e)
        {
            new frmMenuExp().Show();
        }

        private void frmRepProdPendExp_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRepProdPendExp));
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.Label2 = new Label();
            this.GroupBox1 = new GroupBox();
            this.rbNroRemito = new RadioButton();
            this.rbFechaOV = new RadioButton();
            this.rbCliente = new RadioButton();
            this.rbNroOV = new RadioButton();
            this.rbArticulo = new RadioButton();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            Point point = new Point(320, 360);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 2;
            this.cmbAceptar.Text = "&Aceptar";
            this.cmbSalir.DialogResult = DialogResult.Cancel;
            point = new Point(0xd8, 360);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 3;
            this.cmbSalir.Text = "&Salir";
            this.Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Underline | FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(160, 0x80);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x138, 20);
            this.Label2.Size = size;
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Reporte Productos Pendientes de Control Final";
            this.Label2.TextAlign = ContentAlignment.MiddleCenter;
            this.GroupBox1.Controls.Add(this.rbNroRemito);
            this.GroupBox1.Controls.Add(this.rbFechaOV);
            this.GroupBox1.Controls.Add(this.rbCliente);
            this.GroupBox1.Controls.Add(this.rbNroOV);
            this.GroupBox1.Controls.Add(this.rbArticulo);
            this.GroupBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(0xd8, 0xa8);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(200, 0xb8);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Orden Reporte";
            this.rbNroRemito.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x98);
            this.rbNroRemito.Location = point;
            this.rbNroRemito.Name = "rbNroRemito";
            size = new Size(0xa8, 0x18);
            this.rbNroRemito.Size = size;
            this.rbNroRemito.TabIndex = 4;
            this.rbNroRemito.Text = "N\x00b0 Remito";
            this.rbFechaOV.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 120);
            this.rbFechaOV.Location = point;
            this.rbFechaOV.Name = "rbFechaOV";
            size = new Size(0xa8, 0x18);
            this.rbFechaOV.Size = size;
            this.rbFechaOV.TabIndex = 3;
            this.rbFechaOV.Text = "Fecha O.Venta";
            this.rbCliente.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x58);
            this.rbCliente.Location = point;
            this.rbCliente.Name = "rbCliente";
            size = new Size(0xa8, 0x18);
            this.rbCliente.Size = size;
            this.rbCliente.TabIndex = 2;
            this.rbCliente.Text = "Cliente";
            this.rbNroOV.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x38);
            this.rbNroOV.Location = point;
            this.rbNroOV.Name = "rbNroOV";
            size = new Size(0xa8, 0x18);
            this.rbNroOV.Size = size;
            this.rbNroOV.TabIndex = 1;
            this.rbNroOV.Text = "N\x00b0 O.Venta";
            this.rbArticulo.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x10, 0x18);
            this.rbArticulo.Location = point;
            this.rbArticulo.Name = "rbArticulo";
            size = new Size(0xa8, 0x18);
            this.rbArticulo.Size = size;
            this.rbArticulo.TabIndex = 0;
            this.rbArticulo.Text = "Producto";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = this.cmbSalir;
            size = new Size(0x324, 0x249);
            this.ClientSize = size;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbAceptar);
            this.Controls.Add(this.cmbSalir);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmRepProdPendExp";
            this.Text = "Reporte Productos Pendientes de Control Final";
            this.WindowState = FormWindowState.Maximized;
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void rbArticulo_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void rbCliente_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void rbFechaOV_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbFechaOV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void rbNroOV_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbNroOV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.cmbAceptar.Focus();
            }
        }

        private void rbNroRemito_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbNroRemito_KeyPress(object sender, KeyPressEventArgs e)
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

        internal virtual RadioButton rbArticulo
        {
            get
            {
                return this._rbArticulo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbArticulo != null)
                {
                    this._rbArticulo.KeyPress -= new KeyPressEventHandler(this.rbArticulo_KeyPress);
                    this._rbArticulo.CheckedChanged -= new EventHandler(this.rbArticulo_CheckedChanged);
                }
                this._rbArticulo = value;
                if (this._rbArticulo != null)
                {
                    this._rbArticulo.KeyPress += new KeyPressEventHandler(this.rbArticulo_KeyPress);
                    this._rbArticulo.CheckedChanged += new EventHandler(this.rbArticulo_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbCliente
        {
            get
            {
                return this._rbCliente;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbCliente != null)
                {
                    this._rbCliente.KeyPress -= new KeyPressEventHandler(this.rbCliente_KeyPress);
                    this._rbCliente.CheckedChanged -= new EventHandler(this.rbCliente_CheckedChanged);
                }
                this._rbCliente = value;
                if (this._rbCliente != null)
                {
                    this._rbCliente.KeyPress += new KeyPressEventHandler(this.rbCliente_KeyPress);
                    this._rbCliente.CheckedChanged += new EventHandler(this.rbCliente_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbFechaOV
        {
            get
            {
                return this._rbFechaOV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbFechaOV != null)
                {
                    this._rbFechaOV.KeyPress -= new KeyPressEventHandler(this.rbFechaOV_KeyPress);
                    this._rbFechaOV.CheckedChanged -= new EventHandler(this.rbFechaOV_CheckedChanged);
                }
                this._rbFechaOV = value;
                if (this._rbFechaOV != null)
                {
                    this._rbFechaOV.KeyPress += new KeyPressEventHandler(this.rbFechaOV_KeyPress);
                    this._rbFechaOV.CheckedChanged += new EventHandler(this.rbFechaOV_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbNroOV
        {
            get
            {
                return this._rbNroOV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbNroOV != null)
                {
                    this._rbNroOV.KeyPress -= new KeyPressEventHandler(this.rbNroOV_KeyPress);
                    this._rbNroOV.CheckedChanged -= new EventHandler(this.rbNroOV_CheckedChanged);
                }
                this._rbNroOV = value;
                if (this._rbNroOV != null)
                {
                    this._rbNroOV.KeyPress += new KeyPressEventHandler(this.rbNroOV_KeyPress);
                    this._rbNroOV.CheckedChanged += new EventHandler(this.rbNroOV_CheckedChanged);
                }
            }
        }

        internal virtual RadioButton rbNroRemito
        {
            get
            {
                return this._rbNroRemito;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._rbNroRemito != null)
                {
                    this._rbNroRemito.KeyPress -= new KeyPressEventHandler(this.rbNroRemito_KeyPress);
                    this._rbNroRemito.CheckedChanged -= new EventHandler(this.rbNroRemito_CheckedChanged);
                }
                this._rbNroRemito = value;
                if (this._rbNroRemito != null)
                {
                    this._rbNroRemito.KeyPress += new KeyPressEventHandler(this.rbNroRemito_KeyPress);
                    this._rbNroRemito.CheckedChanged += new EventHandler(this.rbNroRemito_CheckedChanged);
                }
            }
        }
    }
}

