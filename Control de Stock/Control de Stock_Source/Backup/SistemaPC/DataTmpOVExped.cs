namespace SistemaPC
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Schema;

    [Serializable, DesignerCategory("code"), DebuggerStepThrough, ToolboxItem(true)]
    public class DataTmpOVExped : DataSet
    {
        private PC1TmpOVExpedDataTable tablePC1TmpOVExped;

        public DataTmpOVExped()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DataTmpOVExped(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["PC1TmpOVExped"] != null)
                {
                    this.Tables.Add(new PC1TmpOVExpedDataTable(dataSet.Tables["PC1TmpOVExped"]));
                }
                this.DataSetName = dataSet.DataSetName;
                this.Prefix = dataSet.Prefix;
                this.Namespace = dataSet.Namespace;
                this.Locale = dataSet.Locale;
                this.CaseSensitive = dataSet.CaseSensitive;
                this.EnforceConstraints = dataSet.EnforceConstraints;
                this.Merge(dataSet, false, MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                this.InitClass();
            }
            this.GetSerializationData(info, context);
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        public override DataSet Clone()
        {
            DataTmpOVExped exped = (DataTmpOVExped) base.Clone();
            exped.InitVars();
            return exped;
        }

        protected override XmlSchema GetSchemaSerializable()
        {
            MemoryStream w = new MemoryStream();
            this.WriteXmlSchema(new XmlTextWriter(w, null));
            w.Position = 0L;
            return XmlSchema.Read(new XmlTextReader(w), null);
        }

        private void InitClass()
        {
            this.DataSetName = "DataTmpOVExped";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DataTmpOVExped.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tablePC1TmpOVExped = new PC1TmpOVExpedDataTable();
            this.Tables.Add(this.tablePC1TmpOVExped);
        }

        internal void InitVars()
        {
            this.tablePC1TmpOVExped = (PC1TmpOVExpedDataTable) this.Tables["PC1TmpOVExped"];
            if (this.tablePC1TmpOVExped != null)
            {
                this.tablePC1TmpOVExped.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["PC1TmpOVExped"] != null)
            {
                this.Tables.Add(new PC1TmpOVExpedDataTable(dataSet.Tables["PC1TmpOVExped"]));
            }
            this.DataSetName = dataSet.DataSetName;
            this.Prefix = dataSet.Prefix;
            this.Namespace = dataSet.Namespace;
            this.Locale = dataSet.Locale;
            this.CaseSensitive = dataSet.CaseSensitive;
            this.EnforceConstraints = dataSet.EnforceConstraints;
            this.Merge(dataSet, false, MissingSchemaAction.Add);
            this.InitVars();
        }

        private void SchemaChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Remove)
            {
                this.InitVars();
            }
        }

        private bool ShouldSerializePC1TmpOVExped()
        {
            return false;
        }

        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PC1TmpOVExpedDataTable PC1TmpOVExped
        {
            get
            {
                return this.tablePC1TmpOVExped;
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpOVExpedDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBultos;
            private DataColumn columnCantidad;
            private DataColumn columnCliente;
            private DataColumn columnCodMetEnt;
            private DataColumn columnCodProd;
            private DataColumn columnDesc1;
            private DataColumn columnDesc2;
            private DataColumn columnDescMetEnt;
            private DataColumn columnFechaEnt;
            private DataColumn columnFechaExp;
            private DataColumn columnFechaOV;
            private DataColumn columnFechaPrep;
            private DataColumn columnFechaRecConfCli;
            private DataColumn columnLugarEnt;
            private DataColumn columnNomCli;
            private DataColumn columnNroFactura;
            private DataColumn columnNroOV;
            private DataColumn columnNroRemito;
            private DataColumn columnOCompra;
            private DataColumn columnPesoBruto;
            private DataColumn columnPesoNeto;
            private DataColumn columnTipoOV;
            private DataColumn columnVolumen;

            public event DataTmpOVExped.PC1TmpOVExpedRowChangeEventHandler PC1TmpOVExpedRowChanged;

            public event DataTmpOVExped.PC1TmpOVExpedRowChangeEventHandler PC1TmpOVExpedRowChanging;

            public event DataTmpOVExped.PC1TmpOVExpedRowChangeEventHandler PC1TmpOVExpedRowDeleted;

            public event DataTmpOVExped.PC1TmpOVExpedRowChangeEventHandler PC1TmpOVExpedRowDeleting;

            internal PC1TmpOVExpedDataTable() : base("PC1TmpOVExped")
            {
                this.InitClass();
            }

            internal PC1TmpOVExpedDataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if (StringType.StrCmp(table.Locale.ToString(), table.DataSet.Locale.ToString(), false) != 0)
                {
                    this.Locale = table.Locale;
                }
                if (StringType.StrCmp(table.Namespace, table.DataSet.Namespace, false) != 0)
                {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }

            public void AddPC1TmpOVExpedRow(DataTmpOVExped.PC1TmpOVExpedRow row)
            {
                this.Rows.Add(row);
            }

            public DataTmpOVExped.PC1TmpOVExpedRow AddPC1TmpOVExpedRow(string NroOV, int TipoOV, string Cliente, string NomCli, string OCompra, int CodMetEnt, string DescMetEnt, string LugarEnt, DateTime FechaOV, DateTime FechaEnt, DateTime FechaPrep, DateTime FechaExp, DateTime FechaRecConfCli, string NroRemito, string NroFactura, decimal PesoNeto, decimal PesoBruto, decimal Volumen, decimal Bultos, string CodProd, string Desc1, string Desc2, decimal Cantidad)
            {
                DataTmpOVExped.PC1TmpOVExpedRow row = (DataTmpOVExped.PC1TmpOVExpedRow) this.NewRow();
                row.ItemArray = new object[] { 
                    NroOV, TipoOV, Cliente, NomCli, OCompra, CodMetEnt, DescMetEnt, LugarEnt, FechaOV, FechaEnt, FechaPrep, FechaExp, FechaRecConfCli, NroRemito, NroFactura, PesoNeto, 
                    PesoBruto, Volumen, Bultos, CodProd, Desc1, Desc2, Cantidad
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataTmpOVExped.PC1TmpOVExpedDataTable table = (DataTmpOVExped.PC1TmpOVExpedDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataTmpOVExped.PC1TmpOVExpedDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataTmpOVExped.PC1TmpOVExpedRow);
            }

            private void InitClass()
            {
                this.columnNroOV = new DataColumn("NroOV", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOV);
                this.columnTipoOV = new DataColumn("TipoOV", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnTipoOV);
                this.columnCliente = new DataColumn("Cliente", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCliente);
                this.columnNomCli = new DataColumn("NomCli", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNomCli);
                this.columnOCompra = new DataColumn("OCompra", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOCompra);
                this.columnCodMetEnt = new DataColumn("CodMetEnt", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnCodMetEnt);
                this.columnDescMetEnt = new DataColumn("DescMetEnt", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDescMetEnt);
                this.columnLugarEnt = new DataColumn("LugarEnt", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnLugarEnt);
                this.columnFechaOV = new DataColumn("FechaOV", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaOV);
                this.columnFechaEnt = new DataColumn("FechaEnt", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaEnt);
                this.columnFechaPrep = new DataColumn("FechaPrep", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaPrep);
                this.columnFechaExp = new DataColumn("FechaExp", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaExp);
                this.columnFechaRecConfCli = new DataColumn("FechaRecConfCli", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaRecConfCli);
                this.columnNroRemito = new DataColumn("NroRemito", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroRemito);
                this.columnNroFactura = new DataColumn("NroFactura", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroFactura);
                this.columnPesoNeto = new DataColumn("PesoNeto", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPesoNeto);
                this.columnPesoBruto = new DataColumn("PesoBruto", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPesoBruto);
                this.columnVolumen = new DataColumn("Volumen", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnVolumen);
                this.columnBultos = new DataColumn("Bultos", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnBultos);
                this.columnCodProd = new DataColumn("CodProd", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodProd);
                this.columnDesc1 = new DataColumn("Desc1", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDesc1);
                this.columnDesc2 = new DataColumn("Desc2", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDesc2);
                this.columnCantidad = new DataColumn("Cantidad", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantidad);
                this.columnNroOV.AllowDBNull = false;
                this.columnTipoOV.AllowDBNull = false;
                this.columnCliente.AllowDBNull = false;
                this.columnNomCli.AllowDBNull = false;
                this.columnOCompra.AllowDBNull = false;
                this.columnCodMetEnt.AllowDBNull = false;
                this.columnDescMetEnt.AllowDBNull = false;
                this.columnLugarEnt.AllowDBNull = false;
                this.columnFechaOV.AllowDBNull = false;
                this.columnFechaEnt.AllowDBNull = false;
                this.columnNroRemito.AllowDBNull = false;
                this.columnNroFactura.AllowDBNull = false;
                this.columnCodProd.AllowDBNull = false;
                this.columnDesc1.AllowDBNull = false;
                this.columnDesc2.AllowDBNull = false;
                this.columnCantidad.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnNroOV = this.Columns["NroOV"];
                this.columnTipoOV = this.Columns["TipoOV"];
                this.columnCliente = this.Columns["Cliente"];
                this.columnNomCli = this.Columns["NomCli"];
                this.columnOCompra = this.Columns["OCompra"];
                this.columnCodMetEnt = this.Columns["CodMetEnt"];
                this.columnDescMetEnt = this.Columns["DescMetEnt"];
                this.columnLugarEnt = this.Columns["LugarEnt"];
                this.columnFechaOV = this.Columns["FechaOV"];
                this.columnFechaEnt = this.Columns["FechaEnt"];
                this.columnFechaPrep = this.Columns["FechaPrep"];
                this.columnFechaExp = this.Columns["FechaExp"];
                this.columnFechaRecConfCli = this.Columns["FechaRecConfCli"];
                this.columnNroRemito = this.Columns["NroRemito"];
                this.columnNroFactura = this.Columns["NroFactura"];
                this.columnPesoNeto = this.Columns["PesoNeto"];
                this.columnPesoBruto = this.Columns["PesoBruto"];
                this.columnVolumen = this.Columns["Volumen"];
                this.columnBultos = this.Columns["Bultos"];
                this.columnCodProd = this.Columns["CodProd"];
                this.columnDesc1 = this.Columns["Desc1"];
                this.columnDesc2 = this.Columns["Desc2"];
                this.columnCantidad = this.Columns["Cantidad"];
            }

            public DataTmpOVExped.PC1TmpOVExpedRow NewPC1TmpOVExpedRow()
            {
                return (DataTmpOVExped.PC1TmpOVExpedRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataTmpOVExped.PC1TmpOVExpedRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpOVExpedRowChangedEvent != null) && (this.PC1TmpOVExpedRowChangedEvent != null))
                {
                    this.PC1TmpOVExpedRowChangedEvent(this, new DataTmpOVExped.PC1TmpOVExpedRowChangeEvent((DataTmpOVExped.PC1TmpOVExpedRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpOVExpedRowChangingEvent != null) && (this.PC1TmpOVExpedRowChangingEvent != null))
                {
                    this.PC1TmpOVExpedRowChangingEvent(this, new DataTmpOVExped.PC1TmpOVExpedRowChangeEvent((DataTmpOVExped.PC1TmpOVExpedRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpOVExpedRowDeletedEvent != null) && (this.PC1TmpOVExpedRowDeletedEvent != null))
                {
                    this.PC1TmpOVExpedRowDeletedEvent(this, new DataTmpOVExped.PC1TmpOVExpedRowChangeEvent((DataTmpOVExped.PC1TmpOVExpedRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpOVExpedRowDeletingEvent != null) && (this.PC1TmpOVExpedRowDeletingEvent != null))
                {
                    this.PC1TmpOVExpedRowDeletingEvent(this, new DataTmpOVExped.PC1TmpOVExpedRowChangeEvent((DataTmpOVExped.PC1TmpOVExpedRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpOVExpedRow(DataTmpOVExped.PC1TmpOVExpedRow row)
            {
                this.Rows.Remove(row);
            }

            internal DataColumn BultosColumn
            {
                get
                {
                    return this.columnBultos;
                }
            }

            internal DataColumn CantidadColumn
            {
                get
                {
                    return this.columnCantidad;
                }
            }

            internal DataColumn ClienteColumn
            {
                get
                {
                    return this.columnCliente;
                }
            }

            internal DataColumn CodMetEntColumn
            {
                get
                {
                    return this.columnCodMetEnt;
                }
            }

            internal DataColumn CodProdColumn
            {
                get
                {
                    return this.columnCodProd;
                }
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            internal DataColumn Desc1Column
            {
                get
                {
                    return this.columnDesc1;
                }
            }

            internal DataColumn Desc2Column
            {
                get
                {
                    return this.columnDesc2;
                }
            }

            internal DataColumn DescMetEntColumn
            {
                get
                {
                    return this.columnDescMetEnt;
                }
            }

            internal DataColumn FechaEntColumn
            {
                get
                {
                    return this.columnFechaEnt;
                }
            }

            internal DataColumn FechaExpColumn
            {
                get
                {
                    return this.columnFechaExp;
                }
            }

            internal DataColumn FechaOVColumn
            {
                get
                {
                    return this.columnFechaOV;
                }
            }

            internal DataColumn FechaPrepColumn
            {
                get
                {
                    return this.columnFechaPrep;
                }
            }

            internal DataColumn FechaRecConfCliColumn
            {
                get
                {
                    return this.columnFechaRecConfCli;
                }
            }

            public DataTmpOVExped.PC1TmpOVExpedRow this[int index]
            {
                get
                {
                    return (DataTmpOVExped.PC1TmpOVExpedRow) this.Rows[index];
                }
            }

            internal DataColumn LugarEntColumn
            {
                get
                {
                    return this.columnLugarEnt;
                }
            }

            internal DataColumn NomCliColumn
            {
                get
                {
                    return this.columnNomCli;
                }
            }

            internal DataColumn NroFacturaColumn
            {
                get
                {
                    return this.columnNroFactura;
                }
            }

            internal DataColumn NroOVColumn
            {
                get
                {
                    return this.columnNroOV;
                }
            }

            internal DataColumn NroRemitoColumn
            {
                get
                {
                    return this.columnNroRemito;
                }
            }

            internal DataColumn OCompraColumn
            {
                get
                {
                    return this.columnOCompra;
                }
            }

            internal DataColumn PesoBrutoColumn
            {
                get
                {
                    return this.columnPesoBruto;
                }
            }

            internal DataColumn PesoNetoColumn
            {
                get
                {
                    return this.columnPesoNeto;
                }
            }

            internal DataColumn TipoOVColumn
            {
                get
                {
                    return this.columnTipoOV;
                }
            }

            internal DataColumn VolumenColumn
            {
                get
                {
                    return this.columnVolumen;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpOVExpedRow : DataRow
        {
            private DataTmpOVExped.PC1TmpOVExpedDataTable tablePC1TmpOVExped;

            internal PC1TmpOVExpedRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpOVExped = (DataTmpOVExped.PC1TmpOVExpedDataTable) this.Table;
            }

            public bool IsBultosNull()
            {
                return this.IsNull(this.tablePC1TmpOVExped.BultosColumn);
            }

            public bool IsFechaExpNull()
            {
                return this.IsNull(this.tablePC1TmpOVExped.FechaExpColumn);
            }

            public bool IsFechaPrepNull()
            {
                return this.IsNull(this.tablePC1TmpOVExped.FechaPrepColumn);
            }

            public bool IsFechaRecConfCliNull()
            {
                return this.IsNull(this.tablePC1TmpOVExped.FechaRecConfCliColumn);
            }

            public bool IsPesoBrutoNull()
            {
                return this.IsNull(this.tablePC1TmpOVExped.PesoBrutoColumn);
            }

            public bool IsPesoNetoNull()
            {
                return this.IsNull(this.tablePC1TmpOVExped.PesoNetoColumn);
            }

            public bool IsVolumenNull()
            {
                return this.IsNull(this.tablePC1TmpOVExped.VolumenColumn);
            }

            public void SetBultosNull()
            {
                this[this.tablePC1TmpOVExped.BultosColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFechaExpNull()
            {
                this[this.tablePC1TmpOVExped.FechaExpColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFechaPrepNull()
            {
                this[this.tablePC1TmpOVExped.FechaPrepColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFechaRecConfCliNull()
            {
                this[this.tablePC1TmpOVExped.FechaRecConfCliColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPesoBrutoNull()
            {
                this[this.tablePC1TmpOVExped.PesoBrutoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPesoNetoNull()
            {
                this[this.tablePC1TmpOVExped.PesoNetoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVolumenNull()
            {
                this[this.tablePC1TmpOVExped.VolumenColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal Bultos
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tablePC1TmpOVExped.BultosColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("Cannot get value because it is DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return num;
                }
                set
                {
                    this[this.tablePC1TmpOVExped.BultosColumn] = value;
                }
            }

            public decimal Cantidad
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOVExped.CantidadColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVExped.CantidadColumn] = value;
                }
            }

            public string Cliente
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVExped.ClienteColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVExped.ClienteColumn] = value;
                }
            }

            public int CodMetEnt
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC1TmpOVExped.CodMetEntColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVExped.CodMetEntColumn] = value;
                }
            }

            public string CodProd
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVExped.CodProdColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVExped.CodProdColumn] = value;
                }
            }

            public string Desc1
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVExped.Desc1Column]);
                }
                set
                {
                    this[this.tablePC1TmpOVExped.Desc1Column] = value;
                }
            }

            public string Desc2
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVExped.Desc2Column]);
                }
                set
                {
                    this[this.tablePC1TmpOVExped.Desc2Column] = value;
                }
            }

            public string DescMetEnt
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVExped.DescMetEntColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVExped.DescMetEntColumn] = value;
                }
            }

            public DateTime FechaEnt
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpOVExped.FechaEntColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVExped.FechaEntColumn] = value;
                }
            }

            public DateTime FechaExp
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = DateType.FromObject(this[this.tablePC1TmpOVExped.FechaExpColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("Cannot get value because it is DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return time;
                }
                set
                {
                    this[this.tablePC1TmpOVExped.FechaExpColumn] = value;
                }
            }

            public DateTime FechaOV
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpOVExped.FechaOVColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVExped.FechaOVColumn] = value;
                }
            }

            public DateTime FechaPrep
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = DateType.FromObject(this[this.tablePC1TmpOVExped.FechaPrepColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("Cannot get value because it is DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return time;
                }
                set
                {
                    this[this.tablePC1TmpOVExped.FechaPrepColumn] = value;
                }
            }

            public DateTime FechaRecConfCli
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = DateType.FromObject(this[this.tablePC1TmpOVExped.FechaRecConfCliColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("Cannot get value because it is DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return time;
                }
                set
                {
                    this[this.tablePC1TmpOVExped.FechaRecConfCliColumn] = value;
                }
            }

            public string LugarEnt
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVExped.LugarEntColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVExped.LugarEntColumn] = value;
                }
            }

            public string NomCli
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVExped.NomCliColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVExped.NomCliColumn] = value;
                }
            }

            public string NroFactura
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVExped.NroFacturaColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVExped.NroFacturaColumn] = value;
                }
            }

            public string NroOV
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVExped.NroOVColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVExped.NroOVColumn] = value;
                }
            }

            public string NroRemito
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVExped.NroRemitoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVExped.NroRemitoColumn] = value;
                }
            }

            public string OCompra
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVExped.OCompraColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVExped.OCompraColumn] = value;
                }
            }

            public decimal PesoBruto
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tablePC1TmpOVExped.PesoBrutoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("Cannot get value because it is DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return num;
                }
                set
                {
                    this[this.tablePC1TmpOVExped.PesoBrutoColumn] = value;
                }
            }

            public decimal PesoNeto
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tablePC1TmpOVExped.PesoNetoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("Cannot get value because it is DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return num;
                }
                set
                {
                    this[this.tablePC1TmpOVExped.PesoNetoColumn] = value;
                }
            }

            public int TipoOV
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC1TmpOVExped.TipoOVColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVExped.TipoOVColumn] = value;
                }
            }

            public decimal Volumen
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tablePC1TmpOVExped.VolumenColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("Cannot get value because it is DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return num;
                }
                set
                {
                    this[this.tablePC1TmpOVExped.VolumenColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpOVExpedRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataTmpOVExped.PC1TmpOVExpedRow eventRow;

            public PC1TmpOVExpedRowChangeEvent(DataTmpOVExped.PC1TmpOVExpedRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public DataTmpOVExped.PC1TmpOVExpedRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpOVExpedRowChangeEventHandler(object sender, DataTmpOVExped.PC1TmpOVExpedRowChangeEvent e);
    }
}

