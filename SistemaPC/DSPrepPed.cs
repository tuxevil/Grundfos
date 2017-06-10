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

    [Serializable, DebuggerStepThrough, DesignerCategory("code"), ToolboxItem(true)]
    public class DSPrepPed : DataSet
    {
        private PrepPedDataTable tablePrepPed;

        public DSPrepPed()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DSPrepPed(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["PrepPed"] != null)
                {
                    this.Tables.Add(new PrepPedDataTable(dataSet.Tables["PrepPed"]));
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
            DSPrepPed ped = (DSPrepPed) base.Clone();
            ped.InitVars();
            return ped;
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
            this.DataSetName = "DSPrepPed";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DSPrepPed.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tablePrepPed = new PrepPedDataTable();
            this.Tables.Add(this.tablePrepPed);
        }

        internal void InitVars()
        {
            this.tablePrepPed = (PrepPedDataTable) this.Tables["PrepPed"];
            if (this.tablePrepPed != null)
            {
                this.tablePrepPed.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["PrepPed"] != null)
            {
                this.Tables.Add(new PrepPedDataTable(dataSet.Tables["PrepPed"]));
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

        private bool ShouldSerializePrepPed()
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
        public PrepPedDataTable PrepPed
        {
            get
            {
                return this.tablePrepPed;
            }
        }

        [DebuggerStepThrough]
        public class PrepPedDataTable : DataTable, IEnumerable
        {
            private DataColumn columnCantOrden;
            private DataColumn columnCantPrep;
            private DataColumn columnCliente;
            private DataColumn columnCodigo;
            private DataColumn columnDesc1;
            private DataColumn columnDesc2;
            private DataColumn columnEstLinea;
            private DataColumn columnExpedicion;
            private DataColumn columnFechaExp;
            private DataColumn columnFechaOV;
            private DataColumn columnFechaPrep;
            private DataColumn columnNomCli;
            private DataColumn columnNroLinea;
            private DataColumn columnNroOV;
            private DataColumn columnNroRemito;
            private DataColumn columnOCompra;
            private DataColumn columnProducto;
            private DataColumn columnTipoLinea;

            public event DSPrepPed.PrepPedRowChangeEventHandler PrepPedRowChanged;

            public event DSPrepPed.PrepPedRowChangeEventHandler PrepPedRowChanging;

            public event DSPrepPed.PrepPedRowChangeEventHandler PrepPedRowDeleted;

            public event DSPrepPed.PrepPedRowChangeEventHandler PrepPedRowDeleting;

            internal PrepPedDataTable() : base("PrepPed")
            {
                this.InitClass();
            }

            internal PrepPedDataTable(DataTable table) : base(table.TableName)
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

            public void AddPrepPedRow(DSPrepPed.PrepPedRow row)
            {
                this.Rows.Add(row);
            }

            public DSPrepPed.PrepPedRow AddPrepPedRow(string NroOV, string NroLinea, int TipoLinea, string EstLinea, string Codigo, string Desc1, string Desc2, decimal CantOrden, decimal CantPrep, DateTime FechaPrep, string Expedicion, string NroRemito, DateTime FechaExp, decimal Producto, string Cliente, string NomCli, string OCompra, DateTime FechaOV)
            {
                DSPrepPed.PrepPedRow row = (DSPrepPed.PrepPedRow) this.NewRow();
                row.ItemArray = new object[] { 
                    NroOV, NroLinea, TipoLinea, EstLinea, Codigo, Desc1, Desc2, CantOrden, CantPrep, FechaPrep, Expedicion, NroRemito, FechaExp, Producto, Cliente, NomCli, 
                    OCompra, FechaOV
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DSPrepPed.PrepPedDataTable table = (DSPrepPed.PrepPedDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DSPrepPed.PrepPedDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DSPrepPed.PrepPedRow);
            }

            private void InitClass()
            {
                this.columnNroOV = new DataColumn("NroOV", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOV);
                this.columnNroLinea = new DataColumn("NroLinea", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroLinea);
                this.columnTipoLinea = new DataColumn("TipoLinea", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnTipoLinea);
                this.columnEstLinea = new DataColumn("EstLinea", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnEstLinea);
                this.columnCodigo = new DataColumn("Codigo", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodigo);
                this.columnDesc1 = new DataColumn("Desc1", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDesc1);
                this.columnDesc2 = new DataColumn("Desc2", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDesc2);
                this.columnCantOrden = new DataColumn("CantOrden", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantOrden);
                this.columnCantPrep = new DataColumn("CantPrep", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantPrep);
                this.columnFechaPrep = new DataColumn("FechaPrep", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaPrep);
                this.columnExpedicion = new DataColumn("Expedicion", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnExpedicion);
                this.columnNroRemito = new DataColumn("NroRemito", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroRemito);
                this.columnFechaExp = new DataColumn("FechaExp", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaExp);
                this.columnProducto = new DataColumn("Producto", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnProducto);
                this.columnCliente = new DataColumn("Cliente", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCliente);
                this.columnNomCli = new DataColumn("NomCli", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNomCli);
                this.columnOCompra = new DataColumn("OCompra", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOCompra);
                this.columnFechaOV = new DataColumn("FechaOV", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaOV);
                this.columnNroOV.AllowDBNull = false;
                this.columnNroLinea.AllowDBNull = false;
                this.columnEstLinea.AllowDBNull = false;
                this.columnCodigo.AllowDBNull = false;
                this.columnCantOrden.AllowDBNull = false;
                this.columnCantPrep.AllowDBNull = false;
                this.columnFechaPrep.AllowDBNull = false;
                this.columnExpedicion.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnNroOV = this.Columns["NroOV"];
                this.columnNroLinea = this.Columns["NroLinea"];
                this.columnTipoLinea = this.Columns["TipoLinea"];
                this.columnEstLinea = this.Columns["EstLinea"];
                this.columnCodigo = this.Columns["Codigo"];
                this.columnDesc1 = this.Columns["Desc1"];
                this.columnDesc2 = this.Columns["Desc2"];
                this.columnCantOrden = this.Columns["CantOrden"];
                this.columnCantPrep = this.Columns["CantPrep"];
                this.columnFechaPrep = this.Columns["FechaPrep"];
                this.columnExpedicion = this.Columns["Expedicion"];
                this.columnNroRemito = this.Columns["NroRemito"];
                this.columnFechaExp = this.Columns["FechaExp"];
                this.columnProducto = this.Columns["Producto"];
                this.columnCliente = this.Columns["Cliente"];
                this.columnNomCli = this.Columns["NomCli"];
                this.columnOCompra = this.Columns["OCompra"];
                this.columnFechaOV = this.Columns["FechaOV"];
            }

            public DSPrepPed.PrepPedRow NewPrepPedRow()
            {
                return (DSPrepPed.PrepPedRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DSPrepPed.PrepPedRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PrepPedRowChangedEvent != null) && (this.PrepPedRowChangedEvent != null))
                {
                    this.PrepPedRowChangedEvent(this, new DSPrepPed.PrepPedRowChangeEvent((DSPrepPed.PrepPedRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PrepPedRowChangingEvent != null) && (this.PrepPedRowChangingEvent != null))
                {
                    this.PrepPedRowChangingEvent(this, new DSPrepPed.PrepPedRowChangeEvent((DSPrepPed.PrepPedRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PrepPedRowDeletedEvent != null) && (this.PrepPedRowDeletedEvent != null))
                {
                    this.PrepPedRowDeletedEvent(this, new DSPrepPed.PrepPedRowChangeEvent((DSPrepPed.PrepPedRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PrepPedRowDeletingEvent != null) && (this.PrepPedRowDeletingEvent != null))
                {
                    this.PrepPedRowDeletingEvent(this, new DSPrepPed.PrepPedRowChangeEvent((DSPrepPed.PrepPedRow) e.Row, e.Action));
                }
            }

            public void RemovePrepPedRow(DSPrepPed.PrepPedRow row)
            {
                this.Rows.Remove(row);
            }

            internal DataColumn CantOrdenColumn
            {
                get
                {
                    return this.columnCantOrden;
                }
            }

            internal DataColumn CantPrepColumn
            {
                get
                {
                    return this.columnCantPrep;
                }
            }

            internal DataColumn ClienteColumn
            {
                get
                {
                    return this.columnCliente;
                }
            }

            internal DataColumn CodigoColumn
            {
                get
                {
                    return this.columnCodigo;
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

            internal DataColumn EstLineaColumn
            {
                get
                {
                    return this.columnEstLinea;
                }
            }

            internal DataColumn ExpedicionColumn
            {
                get
                {
                    return this.columnExpedicion;
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

            public DSPrepPed.PrepPedRow this[int index]
            {
                get
                {
                    return (DSPrepPed.PrepPedRow) this.Rows[index];
                }
            }

            internal DataColumn NomCliColumn
            {
                get
                {
                    return this.columnNomCli;
                }
            }

            internal DataColumn NroLineaColumn
            {
                get
                {
                    return this.columnNroLinea;
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

            internal DataColumn ProductoColumn
            {
                get
                {
                    return this.columnProducto;
                }
            }

            internal DataColumn TipoLineaColumn
            {
                get
                {
                    return this.columnTipoLinea;
                }
            }
        }

        [DebuggerStepThrough]
        public class PrepPedRow : DataRow
        {
            private DSPrepPed.PrepPedDataTable tablePrepPed;

            internal PrepPedRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePrepPed = (DSPrepPed.PrepPedDataTable) this.Table;
            }

            public bool IsClienteNull()
            {
                return this.IsNull(this.tablePrepPed.ClienteColumn);
            }

            public bool IsDesc1Null()
            {
                return this.IsNull(this.tablePrepPed.Desc1Column);
            }

            public bool IsDesc2Null()
            {
                return this.IsNull(this.tablePrepPed.Desc2Column);
            }

            public bool IsFechaExpNull()
            {
                return this.IsNull(this.tablePrepPed.FechaExpColumn);
            }

            public bool IsFechaOVNull()
            {
                return this.IsNull(this.tablePrepPed.FechaOVColumn);
            }

            public bool IsNomCliNull()
            {
                return this.IsNull(this.tablePrepPed.NomCliColumn);
            }

            public bool IsNroRemitoNull()
            {
                return this.IsNull(this.tablePrepPed.NroRemitoColumn);
            }

            public bool IsOCompraNull()
            {
                return this.IsNull(this.tablePrepPed.OCompraColumn);
            }

            public bool IsProductoNull()
            {
                return this.IsNull(this.tablePrepPed.ProductoColumn);
            }

            public bool IsTipoLineaNull()
            {
                return this.IsNull(this.tablePrepPed.TipoLineaColumn);
            }

            public void SetClienteNull()
            {
                this[this.tablePrepPed.ClienteColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDesc1Null()
            {
                this[this.tablePrepPed.Desc1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDesc2Null()
            {
                this[this.tablePrepPed.Desc2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFechaExpNull()
            {
                this[this.tablePrepPed.FechaExpColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFechaOVNull()
            {
                this[this.tablePrepPed.FechaOVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNomCliNull()
            {
                this[this.tablePrepPed.NomCliColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNroRemitoNull()
            {
                this[this.tablePrepPed.NroRemitoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOCompraNull()
            {
                this[this.tablePrepPed.OCompraColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetProductoNull()
            {
                this[this.tablePrepPed.ProductoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTipoLineaNull()
            {
                this[this.tablePrepPed.TipoLineaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal CantOrden
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePrepPed.CantOrdenColumn]);
                }
                set
                {
                    this[this.tablePrepPed.CantOrdenColumn] = value;
                }
            }

            public decimal CantPrep
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePrepPed.CantPrepColumn]);
                }
                set
                {
                    this[this.tablePrepPed.CantPrepColumn] = value;
                }
            }

            public string Cliente
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePrepPed.ClienteColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("Cannot get value because it is DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePrepPed.ClienteColumn] = value;
                }
            }

            public string Codigo
            {
                get
                {
                    return StringType.FromObject(this[this.tablePrepPed.CodigoColumn]);
                }
                set
                {
                    this[this.tablePrepPed.CodigoColumn] = value;
                }
            }

            public string Desc1
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePrepPed.Desc1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("Cannot get value because it is DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePrepPed.Desc1Column] = value;
                }
            }

            public string Desc2
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePrepPed.Desc2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("Cannot get value because it is DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePrepPed.Desc2Column] = value;
                }
            }

            public string EstLinea
            {
                get
                {
                    return StringType.FromObject(this[this.tablePrepPed.EstLineaColumn]);
                }
                set
                {
                    this[this.tablePrepPed.EstLineaColumn] = value;
                }
            }

            public string Expedicion
            {
                get
                {
                    return StringType.FromObject(this[this.tablePrepPed.ExpedicionColumn]);
                }
                set
                {
                    this[this.tablePrepPed.ExpedicionColumn] = value;
                }
            }

            public DateTime FechaExp
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = DateType.FromObject(this[this.tablePrepPed.FechaExpColumn]);
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
                    this[this.tablePrepPed.FechaExpColumn] = value;
                }
            }

            public DateTime FechaOV
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = DateType.FromObject(this[this.tablePrepPed.FechaOVColumn]);
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
                    this[this.tablePrepPed.FechaOVColumn] = value;
                }
            }

            public DateTime FechaPrep
            {
                get
                {
                    return DateType.FromObject(this[this.tablePrepPed.FechaPrepColumn]);
                }
                set
                {
                    this[this.tablePrepPed.FechaPrepColumn] = value;
                }
            }

            public string NomCli
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePrepPed.NomCliColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("Cannot get value because it is DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePrepPed.NomCliColumn] = value;
                }
            }

            public string NroLinea
            {
                get
                {
                    return StringType.FromObject(this[this.tablePrepPed.NroLineaColumn]);
                }
                set
                {
                    this[this.tablePrepPed.NroLineaColumn] = value;
                }
            }

            public string NroOV
            {
                get
                {
                    return StringType.FromObject(this[this.tablePrepPed.NroOVColumn]);
                }
                set
                {
                    this[this.tablePrepPed.NroOVColumn] = value;
                }
            }

            public string NroRemito
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePrepPed.NroRemitoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("Cannot get value because it is DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePrepPed.NroRemitoColumn] = value;
                }
            }

            public string OCompra
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePrepPed.OCompraColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("Cannot get value because it is DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePrepPed.OCompraColumn] = value;
                }
            }

            public decimal Producto
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tablePrepPed.ProductoColumn]);
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
                    this[this.tablePrepPed.ProductoColumn] = value;
                }
            }

            public int TipoLinea
            {
                get
                {
                    int num;
                    try
                    {
                        num = IntegerType.FromObject(this[this.tablePrepPed.TipoLineaColumn]);
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
                    this[this.tablePrepPed.TipoLineaColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PrepPedRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DSPrepPed.PrepPedRow eventRow;

            public PrepPedRowChangeEvent(DSPrepPed.PrepPedRow row, DataRowAction action)
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

            public DSPrepPed.PrepPedRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PrepPedRowChangeEventHandler(object sender, DSPrepPed.PrepPedRowChangeEvent e);
    }
}

