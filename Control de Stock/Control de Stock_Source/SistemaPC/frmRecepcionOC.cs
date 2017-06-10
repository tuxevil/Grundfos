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
    using System.IO;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class frmRecepcionOC : Form
    {
        [AccessedThroughProperty("cmbAceptar")]
        private Button _cmbAceptar;
        [AccessedThroughProperty("cmbSalir")]
        private Button _cmbSalir;
        [AccessedThroughProperty("dgBultos")]
        private DataGrid _dgBultos;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("txtPackList")]
        private TextBox _txtPackList;
        public SqlDataAdapter AdapBultos;
        private IContainer components;
        public DataSet DS;
        public long TotReg;

        public frmRecepcionOC()
        {
            base.Load += new EventHandler(this.frmRecepcionOC_Load);
            base.Closed += new EventHandler(this.frmBultosOC_Closed);
            this.DS = new DataSet();
            this.InitializeComponent();
        }

        private void cmbAceptar_ChangeUICues(object sender, UICuesEventArgs e)
        {
        }

        private void cmbAceptar_Click(object sender, EventArgs e)
        {
            SqlConnection connection;
            SqlConnection connection2;
            SqlConnection connection3;
            SqlTransaction transaction;
            bool flag = false;
            bool flag3 = false;
            bool flag2 = false;
            bool flag4 = false;
            this.dgBultos.Enabled = false;
            this.cmbAceptar.Enabled = false;
            this.cmbSalir.Enabled = false;
            try
            {
                SqlCommand command;
                DataRow row;
                int num;
                SqlDataReader reader;
                int num8;
                string str7;
                DataSet dataSet = new DataSet("PruebaSQL");
                connection2 = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096");
                connection2.Open();
                flag3 = true;
                connection3 = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=edibar;persist security info=True;packet size=4096");
                connection3.Open();
                flag4 = true;
                new SqlDataAdapter("select NroOC,NroLinea,Codigo,sum(CantRec) as CantRec from Bultos where PackList='" + Variables.gPackList + "' group by NroOC,NroLinea,Codigo", connection2).Fill(dataSet, "Bultos");
                transaction = connection2.BeginTransaction();
                flag = true;
                connection = new SqlConnection("data source=" + Variables.gServer + ";user id=scala;password=scala;initial catalog=scalaDB;persist security info=True;packet size=4096");
                connection.Open();
                flag2 = true;
                int num10 = dataSet.Tables["Bultos"].Rows.Count - 1;
                for (num = 0; num <= num10; num++)
                {
                    row = dataSet.Tables["Bultos"].Rows[num];
                    command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT SC01067 FROM dbo.SC010100 where SC01001='", row["Codigo"]), "'")), connection);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Variables.gPaisOrigen = StringType.FromObject(reader["SC01067"]);
                        reader.Close();
                    }
                    else
                    {
                        Variables.gPaisOrigen = "";
                        reader.Close();
                    }
                    command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT PC03001,PC03002,PC03005,PC03006,PC03007,PC03010,PC03011,PC03016 FROM dbo.PC030100 where PC03001='", row["NroOC"]), "' and PC03002='"), row["NroLinea"]), "' and PC03010<>0 and PC03010-PC03011<>0")), connection);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        if (ObjectType.ObjTst(row["CantRec"], ObjectType.SubObj(reader["PC03010"], reader["PC03011"]), false) == 0)
                        {
                            double num2;
                            double num3;
                            string str4;
                            string str5;
                            double num4;
                            double num6;
                            double num7;
                            string str3 = (((((StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(StringType.FromObject(row["NroOC"]), reader["PC03002"]), Strings.Space(6 - Strings.Len(RuntimeHelpers.GetObjectValue(reader["PC03002"]))))), row["Codigo"]), Strings.Space(0x23 - Strings.Len(RuntimeHelpers.GetObjectValue(row["Codigo"]))))) + Strings.Format(RuntimeHelpers.GetObjectValue(row["CantRec"]), "00000000000.00000000") + Strings.Format(DateAndTime.get_Now(), "ddMMyyyy")) + Variables.gDespacho + Strings.Space(0x19 - Strings.Len(Variables.gDespacho))) + Strings.Format(Variables.gFechaImp, "ddMMyyyy")) + Variables.gPaisOrigen + Strings.Space(11 - Strings.Len(Variables.gPaisOrigen))) + Variables.gCodAduana + Strings.Space(10 - Strings.Len(Variables.gCodAduana))) + Strings.Format(DateAndTime.get_Now(), "ddMMyyyy") + "\r" + "\n";
                            string str6 = StringType.FromObject(reader["PC03002"]);
                            reader.Close();
                            StreamWriter writer = new StreamWriter(Variables.gPathTxt + @"\ocompra.prn", true);
                            writer.Write(str3);
                            writer.Close();
                            command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT SC03058,SC03060 FROM dbo.SC030100 where SC03001='", row["Codigo"]), "' and SC03002='01'")), connection);
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                num3 = DoubleType.FromObject(reader["SC03058"]);
                                num7 = DoubleType.FromObject(reader["SC03060"]);
                            }
                            else
                            {
                                num3 = 0.0;
                                num7 = 0.0;
                            }
                            reader.Close();
                            command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT SC03058,SC03060 FROM dbo.SC030100 where SC03001='", row["Codigo"]), "' and SC03002='02'")), connection);
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                num2 = DoubleType.FromObject(reader["SC03058"]);
                                num6 = DoubleType.FromObject(reader["SC03060"]);
                            }
                            else
                            {
                                num2 = 0.0;
                                num6 = 0.0;
                            }
                            reader.Close();
                            command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT SC01055,SC01056,SYCD010 FROM dbo.SC010100,SYCD0100 where SC01001='", row["Codigo"]), "' and SC01056=SYCD001")), connection);
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                num4 = DoubleType.FromObject(reader["SC01055"]);
                                str5 = StringType.FromObject(reader["SC01056"]);
                                str4 = StringType.FromObject(reader["SYCD010"]);
                            }
                            else
                            {
                                num4 = 0.0;
                                str5 = "";
                                str4 = "";
                            }
                            reader.Close();
                            command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into MercRec (NroOC,NroLinea,Codigo,CantRec,FechaRec,Despacho,CostoUnitLoc,CostoUnitExp,PrecioCpra,MonedaCpra,DescMonedaCpra,SobreCostoLoc,SobreCostoExp,PrecioUnitProv,PackList) values ('", row["NroOC"]), "','"), str6), "','"), row["Codigo"]), "',"), row["CantRec"]), ",'"), Strings.Format(DateAndTime.get_Now(), "MM/dd/yyyy")), "','"), Variables.gDespacho), "',"), num3), ","), num2), ","), num4), ",'"), str5), "','"), str4), "',"), num7), ","), num6), ",0,'"), Variables.gPackList), "')")), connection2);
                            command.Transaction = transaction;
                            num8 = command.ExecuteNonQuery();
                        }
                        else
                        {
                            str7 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("insert into Recepcion select NroBulto,NroOC,NroLinea,Codigo,Desc1,Desc2,", ObjectType.SubObj(reader["PC03010"], reader["PC03011"])), ",CantRec,'"), Strings.Format(DateAndTime.get_Now(), "MM/dd/yyyy")), "',0,0,0,'"), Variables.gDespacho), "','"), Strings.Format(Variables.gFechaImp, "MM/dd/yyyy")), "','"), Variables.gCodAduana), "','"), Variables.gPaisOrigen), "','"), Variables.gPackList), "' from Bultos where PackList='"), Variables.gPackList), "' and NroOC='"), row["NroOC"]), "' and Codigo='"), row["Codigo"]), "'"));
                            reader.Close();
                            command = new SqlCommand(str7, connection2);
                            command.Transaction = transaction;
                            num8 = command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        str7 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj((((((("insert into Recepcion select NroBulto,NroOC,NroLinea,Codigo,Desc1,Desc2,0,CantRec,'" + Strings.Format(DateAndTime.get_Now(), "MM/dd/yyyy") + "',0,0,0,'") + Variables.gDespacho + "','") + Strings.Format(Variables.gFechaImp, "MM/dd/yyyy") + "','") + Variables.gCodAduana + "','") + Variables.gPaisOrigen + "','") + Variables.gPackList + "' from Bultos where PackList='") + Variables.gPackList + "' and NroOC='", row["NroOC"]), "' and Codigo='"), row["Codigo"]), "'"));
                        reader.Close();
                        command = new SqlCommand(str7, connection2);
                        command.Transaction = transaction;
                        num8 = command.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
                flag = false;
                str7 = "select * from Recepcion";
                dataSet.Clear();
                command = new SqlCommand(str7, connection2);
                new SqlDataAdapter(command).Fill(dataSet, "Recepcion");
                int num9 = dataSet.Tables["Recepcion"].Rows.Count - 1;
                for (num = 0; num <= num9; num++)
                {
                    row = dataSet.Tables["Recepcion"].Rows[num];
                    command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT * from detdes where colnb=", row["NroBulto"]), " and itnbr='"), row["Codigo"]), "' and ordnb<>"), row["NroOC"])), connection3);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string str2 = StringType.FromObject(reader["ordnb"]);
                        string str = StringType.FromObject(reader["lignb"]);
                        reader.Close();
                        command = new SqlCommand(StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj("SELECT * from Recepcion where NroBulto='", row["NroBulto"]), "' and Codigo='"), row["Codigo"]), "' and NroOC='"), Strings.Format(Conversion.Val(str2), "0000000000")), "'")), connection2);
                        reader = command.ExecuteReader();
                        if (!reader.Read())
                        {
                            reader.Close();
                            command = new SqlCommand("SELECT PC03001,PC03002,PC03005,PC03006,PC03007,PC03010,PC03011,PC03016 FROM dbo.PC030100 where PC03001='" + str2 + "' and PC03002='" + str + "' and PC03010<>0 and PC03010-PC03011<>0", connection);
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                str7 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(("insert into Recepcion select NroBulto,'" + Strings.Format(Conversion.Val(str2), "0000000000") + "','") + Strings.Format(Conversion.Val(str), "000000") + "',Codigo,Desc1,Desc2,", ObjectType.SubObj(reader["PC03010"], reader["PC03011"])), ",0,'"), Strings.Format(DateAndTime.get_Now(), "MM/dd/yyyy")), "',0,0,0,Despacho,FechaImp,CodAduana,PaisOrigen,PackList from Recepcion where NroOC='"), row["NroOC"]), "' and Codigo='"), row["Codigo"]), "' and NroBulto='"), row["NroBulto"]), "'"));
                                reader.Close();
                                command = new SqlCommand(str7, connection2);
                                num8 = command.ExecuteNonQuery();
                            }
                            else
                            {
                                str7 = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj((("insert into Recepcion select NroBulto,'" + Strings.Format(Conversion.Val(str2), "0000000000") + "','" + Strings.Format(Conversion.Val(str), "000000")) + "',Codigo,Desc1,Desc2,0,0,'") + Strings.Format(DateAndTime.get_Now(), "MM/dd/yyyy") + "',0,0,0,Despacho,FechaImp,CodAduana,PaisOrigen,PackList from Recepcion where NroOC='", row["NroOC"]), "' and Codigo='"), row["Codigo"]), "' and NroBulto='"), row["NroBulto"]), "'"));
                                reader.Close();
                                num8 = new SqlCommand(str7, connection2).ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            reader.Close();
                        }
                    }
                    else
                    {
                        reader.Close();
                    }
                }
                connection2.Close();
                flag3 = false;
                connection.Close();
                flag2 = false;
                connection3.Close();
                flag4 = false;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                if (flag)
                {
                    transaction.Rollback();
                    flag = false;
                }
                if (flag3)
                {
                    connection2.Close();
                    flag3 = false;
                }
                if (flag2)
                {
                    connection.Close();
                    flag2 = false;
                }
                if (flag4)
                {
                    connection3.Close();
                    flag4 = false;
                }
                this.dgBultos.Enabled = true;
                this.cmbAceptar.Enabled = true;
                this.cmbSalir.Enabled = true;
                ProjectData.ClearProjectError();
                return;
                ProjectData.ClearProjectError();
            }
            this.Close();
        }

        private void cmbSalir_Click(object sender, EventArgs e)
        {
            SqlConnection connection;
            bool flag = false;
            try
            {
                connection = new SqlConnection("data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=True;packet size=4096");
                connection.Open();
                flag = true;
                int num = new SqlCommand("delete Despachos where Despacho='" + Variables.gDespacho + "'", connection).ExecuteNonQuery();
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
                Interaction.MsgBox("Se ha producido el siguiente error:" + exception.Message, 0, null);
                this.Close();
                ProjectData.ClearProjectError();
            }
            this.Close();
        }

        private void dgBultos_Navigate(object sender, NavigateEventArgs ne)
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

        ~frmRecepcionOC()
        {
        }

        private void frmBultosOC_Closed(object sender, EventArgs e)
        {
            new frmRecepcionOC0().Show();
        }

        private void frmRecepcionOC_Load(object sender, EventArgs e)
        {
            this.txtPackList.Text = Variables.gPackList;
            string selectConnectionString = "data source=" + Variables.gServer + ";user id=teleprinter;password=tele;initial catalog=Colector;persist security info=False;packet size=4096";
            string selectCommandText = "select * from Bultos where PackList='" + Variables.gPackList + "' order by NroBulto";
            this.AdapBultos = new SqlDataAdapter(selectCommandText, selectConnectionString);
            SqlCommandBuilder builder = new SqlCommandBuilder(this.AdapBultos);
            this.AdapBultos.Fill(this.DS, "Bultos");
            this.TotReg = this.DS.Tables["Bultos"].Rows.Count;
            this.dgBultos.DataSource = this.DS.Tables["Bultos"];
            DataGridTableStyle table = new DataGridTableStyle();
            table.MappingName = "Bultos";
            DataGridTextBoxColumn column = new DataGridTextBoxColumn();
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column8 = column;
            column8.HeaderText = "Nro.Bulto";
            column8.MappingName = "NroBulto";
            column8.Width = 70;
            column8 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column7 = column;
            column7.HeaderText = "C\x00f3digo";
            column7.MappingName = "Codigo";
            column7.Width = 70;
            column7 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column6 = column;
            column6.HeaderText = "Descripci\x00f3n";
            column6.MappingName = "Desc1";
            column6.Width = 0xff;
            column6.NullText = "";
            column6 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column5 = column;
            column5.HeaderText = "Descripci\x00f3n";
            column5.MappingName = "Desc2";
            column5.Width = 0xeb;
            column5.NullText = "";
            column5 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column4 = column;
            column4.HeaderText = "Nro.OC";
            column4.MappingName = "NroOC";
            column4.Width = 70;
            column4 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column3 = column;
            column3.HeaderText = "L\x00ednea";
            column3.MappingName = "NroLinea";
            column3.Width = 0x2d;
            column3.NullText = "";
            column3 = null;
            table.GridColumnStyles.Add(column);
            column = new DataGridTextBoxColumn();
            DataGridTextBoxColumn column2 = column;
            column2.HeaderText = "Cant.Rec.";
            column2.MappingName = "CantRec";
            column2.Width = 60;
            column2.Format = "######0";
            column2 = null;
            table.GridColumnStyles.Add(column);
            this.dgBultos.TableStyles.Add(table);
            this.dgBultos.Refresh();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(frmRecepcionOC));
            this.cmbAceptar = new Button();
            this.cmbSalir = new Button();
            this.dgBultos = new DataGrid();
            this.Label2 = new Label();
            this.txtPackList = new TextBox();
            this.dgBultos.BeginInit();
            this.SuspendLayout();
            Point point = new Point(0x390, 0x2a0);
            this.cmbAceptar.Location = point;
            this.cmbAceptar.Name = "cmbAceptar";
            Size size = new Size(0x60, 40);
            this.cmbAceptar.Size = size;
            this.cmbAceptar.TabIndex = 2;
            this.cmbAceptar.Text = "&Aceptar";
            point = new Point(800, 0x2a0);
            this.cmbSalir.Location = point;
            this.cmbSalir.Name = "cmbSalir";
            size = new Size(0x60, 40);
            this.cmbSalir.Size = size;
            this.cmbSalir.TabIndex = 3;
            this.cmbSalir.Text = "&Salir";
            this.dgBultos.CaptionFont = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dgBultos.CaptionText = "Recepci\x00f3n O.Compra";
            this.dgBultos.DataMember = "";
            this.dgBultos.HeaderForeColor = SystemColors.ControlText;
            point = new Point(8, 0x30);
            this.dgBultos.Location = point;
            this.dgBultos.Name = "dgBultos";
            this.dgBultos.ReadOnly = true;
            size = new Size(0x3f8, 0x260);
            this.dgBultos.Size = size;
            this.dgBultos.TabIndex = 0x34;
            this.Label2.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 8);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x58, 0x10);
            this.Label2.Size = size;
            this.Label2.TabIndex = 0x35;
            this.Label2.Text = "Packing List:";
            this.txtPackList.BackColor = SystemColors.Window;
            this.txtPackList.Enabled = false;
            this.txtPackList.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x68, 8);
            this.txtPackList.Location = point;
            this.txtPackList.MaxLength = 10;
            this.txtPackList.Name = "txtPackList";
            size = new Size(0x98, 0x16);
            this.txtPackList.Size = size;
            this.txtPackList.TabIndex = 0x37;
            this.txtPackList.Text = "";
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            size = new Size(0x404, 0x2f1);
            this.ClientSize = size;
            this.Controls.Add(this.txtPackList);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.dgBultos);
            this.Controls.Add(this.cmbSalir);
            this.Controls.Add(this.cmbAceptar);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "frmRecepcionOC";
            this.Text = "Recepci\x00f3n O.Compra";
            this.WindowState = FormWindowState.Maximized;
            this.dgBultos.EndInit();
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
                    this._cmbAceptar.ChangeUICues -= new UICuesEventHandler(this.cmbAceptar_ChangeUICues);
                }
                this._cmbAceptar = value;
                if (this._cmbAceptar != null)
                {
                    this._cmbAceptar.Click += new EventHandler(this.cmbAceptar_Click);
                    this._cmbAceptar.ChangeUICues += new UICuesEventHandler(this.cmbAceptar_ChangeUICues);
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

        internal virtual DataGrid dgBultos
        {
            get
            {
                return this._dgBultos;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._dgBultos != null)
                {
                    this._dgBultos.Navigate -= new NavigateEventHandler(this.dgBultos_Navigate);
                }
                this._dgBultos = value;
                if (this._dgBultos != null)
                {
                    this._dgBultos.Navigate += new NavigateEventHandler(this.dgBultos_Navigate);
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

        internal virtual TextBox txtPackList
        {
            get
            {
                return this._txtPackList;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (this._txtPackList != null)
                {
                }
                this._txtPackList = value;
                if (this._txtPackList != null)
                {
                }
            }
        }
    }
}

