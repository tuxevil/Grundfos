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

    [Serializable, ToolboxItem(true), DebuggerStepThrough, DesignerCategory("code")]
    public class DataTmpGesEns : DataSet
    {
        private PC1TmpGesEnsDataTable tablePC1TmpGesEns;
        private PC1TmpRepGesEnsDataTable tablePC1TmpRepGesEns;

        public DataTmpGesEns()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DataTmpGesEns(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["PC1TmpGesEns"] != null)
                {
                    this.Tables.Add(new PC1TmpGesEnsDataTable(dataSet.Tables["PC1TmpGesEns"]));
                }
                if (dataSet.Tables["PC1TmpRepGesEns"] != null)
                {
                    this.Tables.Add(new PC1TmpRepGesEnsDataTable(dataSet.Tables["PC1TmpRepGesEns"]));
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
            DataTmpGesEns ens = (DataTmpGesEns) base.Clone();
            ens.InitVars();
            return ens;
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
            this.DataSetName = "DataTmpGesEns";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DataTmpGesEns.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tablePC1TmpGesEns = new PC1TmpGesEnsDataTable();
            this.Tables.Add(this.tablePC1TmpGesEns);
            this.tablePC1TmpRepGesEns = new PC1TmpRepGesEnsDataTable();
            this.Tables.Add(this.tablePC1TmpRepGesEns);
        }

        internal void InitVars()
        {
            this.tablePC1TmpGesEns = (PC1TmpGesEnsDataTable) this.Tables["PC1TmpGesEns"];
            if (this.tablePC1TmpGesEns != null)
            {
                this.tablePC1TmpGesEns.InitVars();
            }
            this.tablePC1TmpRepGesEns = (PC1TmpRepGesEnsDataTable) this.Tables["PC1TmpRepGesEns"];
            if (this.tablePC1TmpRepGesEns != null)
            {
                this.tablePC1TmpRepGesEns.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["PC1TmpGesEns"] != null)
            {
                this.Tables.Add(new PC1TmpGesEnsDataTable(dataSet.Tables["PC1TmpGesEns"]));
            }
            if (dataSet.Tables["PC1TmpRepGesEns"] != null)
            {
                this.Tables.Add(new PC1TmpRepGesEnsDataTable(dataSet.Tables["PC1TmpRepGesEns"]));
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

        private bool ShouldSerializePC1TmpGesEns()
        {
            return false;
        }

        private bool ShouldSerializePC1TmpRepGesEns()
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
        public PC1TmpGesEnsDataTable PC1TmpGesEns
        {
            get
            {
                return this.tablePC1TmpGesEns;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public PC1TmpRepGesEnsDataTable PC1TmpRepGesEns
        {
            get
            {
                return this.tablePC1TmpRepGesEns;
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpGesEnsDataTable : DataTable, IEnumerable
        {
            private DataColumn columnCantArmado;
            private DataColumn columnCantOE;
            private DataColumn columnCliente;
            private DataColumn columnCodigo;
            private DataColumn columnDescripcion;
            private DataColumn columnFechaEnsReal;
            private DataColumn columnFechaEnt;
            private DataColumn columnFechaOE;
            private DataColumn columnNroLinea;
            private DataColumn columnNroOE;
            private DataColumn columnNroOV;
            private DataColumn columnObservaciones;
            private DataColumn columnOpArmado;
            private DataColumn columnOpEmbalaje;
            private DataColumn columnOpPrueba;
            private DataColumn columnOpRecoleccion;
            private DataColumn columnTiempoAsig;

            public event DataTmpGesEns.PC1TmpGesEnsRowChangeEventHandler PC1TmpGesEnsRowChanged;

            public event DataTmpGesEns.PC1TmpGesEnsRowChangeEventHandler PC1TmpGesEnsRowChanging;

            public event DataTmpGesEns.PC1TmpGesEnsRowChangeEventHandler PC1TmpGesEnsRowDeleted;

            public event DataTmpGesEns.PC1TmpGesEnsRowChangeEventHandler PC1TmpGesEnsRowDeleting;

            internal PC1TmpGesEnsDataTable() : base("PC1TmpGesEns")
            {
                this.InitClass();
            }

            internal PC1TmpGesEnsDataTable(DataTable table) : base(table.TableName)
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

            public void AddPC1TmpGesEnsRow(DataTmpGesEns.PC1TmpGesEnsRow row)
            {
                this.Rows.Add(row);
            }

            public DataTmpGesEns.PC1TmpGesEnsRow AddPC1TmpGesEnsRow(string NroOE, DateTime FechaOE, DateTime FechaEnt, DateTime FechaEnsReal, string NroLinea, string Codigo, string Descripcion, decimal CantOE, decimal CantArmado, string Cliente, string NroOV, string Observaciones, string TiempoAsig, string OpRecoleccion, string OpArmado, string OpPrueba, string OpEmbalaje)
            {
                DataTmpGesEns.PC1TmpGesEnsRow row = (DataTmpGesEns.PC1TmpGesEnsRow) this.NewRow();
                row.ItemArray = new object[] { 
                    NroOE, FechaOE, FechaEnt, FechaEnsReal, NroLinea, Codigo, Descripcion, CantOE, CantArmado, Cliente, NroOV, Observaciones, TiempoAsig, OpRecoleccion, OpArmado, OpPrueba, 
                    OpEmbalaje
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataTmpGesEns.PC1TmpGesEnsDataTable table = (DataTmpGesEns.PC1TmpGesEnsDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataTmpGesEns.PC1TmpGesEnsDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataTmpGesEns.PC1TmpGesEnsRow);
            }

            private void InitClass()
            {
                this.columnNroOE = new DataColumn("NroOE", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOE);
                this.columnFechaOE = new DataColumn("FechaOE", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaOE);
                this.columnFechaEnt = new DataColumn("FechaEnt", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaEnt);
                this.columnFechaEnsReal = new DataColumn("FechaEnsReal", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaEnsReal);
                this.columnNroLinea = new DataColumn("NroLinea", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroLinea);
                this.columnCodigo = new DataColumn("Codigo", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodigo);
                this.columnDescripcion = new DataColumn("Descripcion", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDescripcion);
                this.columnCantOE = new DataColumn("CantOE", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantOE);
                this.columnCantArmado = new DataColumn("CantArmado", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantArmado);
                this.columnCliente = new DataColumn("Cliente", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCliente);
                this.columnNroOV = new DataColumn("NroOV", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOV);
                this.columnObservaciones = new DataColumn("Observaciones", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnObservaciones);
                this.columnTiempoAsig = new DataColumn("TiempoAsig", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnTiempoAsig);
                this.columnOpRecoleccion = new DataColumn("OpRecoleccion", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOpRecoleccion);
                this.columnOpArmado = new DataColumn("OpArmado", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOpArmado);
                this.columnOpPrueba = new DataColumn("OpPrueba", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOpPrueba);
                this.columnOpEmbalaje = new DataColumn("OpEmbalaje", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOpEmbalaje);
                this.columnNroOE.AllowDBNull = false;
                this.columnFechaOE.AllowDBNull = false;
                this.columnFechaEnt.AllowDBNull = false;
                this.columnNroLinea.AllowDBNull = false;
                this.columnCodigo.AllowDBNull = false;
                this.columnCantOE.AllowDBNull = false;
                this.columnCantArmado.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnNroOE = this.Columns["NroOE"];
                this.columnFechaOE = this.Columns["FechaOE"];
                this.columnFechaEnt = this.Columns["FechaEnt"];
                this.columnFechaEnsReal = this.Columns["FechaEnsReal"];
                this.columnNroLinea = this.Columns["NroLinea"];
                this.columnCodigo = this.Columns["Codigo"];
                this.columnDescripcion = this.Columns["Descripcion"];
                this.columnCantOE = this.Columns["CantOE"];
                this.columnCantArmado = this.Columns["CantArmado"];
                this.columnCliente = this.Columns["Cliente"];
                this.columnNroOV = this.Columns["NroOV"];
                this.columnObservaciones = this.Columns["Observaciones"];
                this.columnTiempoAsig = this.Columns["TiempoAsig"];
                this.columnOpRecoleccion = this.Columns["OpRecoleccion"];
                this.columnOpArmado = this.Columns["OpArmado"];
                this.columnOpPrueba = this.Columns["OpPrueba"];
                this.columnOpEmbalaje = this.Columns["OpEmbalaje"];
            }

            public DataTmpGesEns.PC1TmpGesEnsRow NewPC1TmpGesEnsRow()
            {
                return (DataTmpGesEns.PC1TmpGesEnsRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataTmpGesEns.PC1TmpGesEnsRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpGesEnsRowChangedEvent != null) && (this.PC1TmpGesEnsRowChangedEvent != null))
                {
                    this.PC1TmpGesEnsRowChangedEvent(this, new DataTmpGesEns.PC1TmpGesEnsRowChangeEvent((DataTmpGesEns.PC1TmpGesEnsRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpGesEnsRowChangingEvent != null) && (this.PC1TmpGesEnsRowChangingEvent != null))
                {
                    this.PC1TmpGesEnsRowChangingEvent(this, new DataTmpGesEns.PC1TmpGesEnsRowChangeEvent((DataTmpGesEns.PC1TmpGesEnsRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpGesEnsRowDeletedEvent != null) && (this.PC1TmpGesEnsRowDeletedEvent != null))
                {
                    this.PC1TmpGesEnsRowDeletedEvent(this, new DataTmpGesEns.PC1TmpGesEnsRowChangeEvent((DataTmpGesEns.PC1TmpGesEnsRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpGesEnsRowDeletingEvent != null) && (this.PC1TmpGesEnsRowDeletingEvent != null))
                {
                    this.PC1TmpGesEnsRowDeletingEvent(this, new DataTmpGesEns.PC1TmpGesEnsRowChangeEvent((DataTmpGesEns.PC1TmpGesEnsRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpGesEnsRow(DataTmpGesEns.PC1TmpGesEnsRow row)
            {
                this.Rows.Remove(row);
            }

            internal DataColumn CantArmadoColumn
            {
                get
                {
                    return this.columnCantArmado;
                }
            }

            internal DataColumn CantOEColumn
            {
                get
                {
                    return this.columnCantOE;
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

            internal DataColumn DescripcionColumn
            {
                get
                {
                    return this.columnDescripcion;
                }
            }

            internal DataColumn FechaEnsRealColumn
            {
                get
                {
                    return this.columnFechaEnsReal;
                }
            }

            internal DataColumn FechaEntColumn
            {
                get
                {
                    return this.columnFechaEnt;
                }
            }

            internal DataColumn FechaOEColumn
            {
                get
                {
                    return this.columnFechaOE;
                }
            }

            public DataTmpGesEns.PC1TmpGesEnsRow this[int index]
            {
                get
                {
                    return (DataTmpGesEns.PC1TmpGesEnsRow) this.Rows[index];
                }
            }

            internal DataColumn NroLineaColumn
            {
                get
                {
                    return this.columnNroLinea;
                }
            }

            internal DataColumn NroOEColumn
            {
                get
                {
                    return this.columnNroOE;
                }
            }

            internal DataColumn NroOVColumn
            {
                get
                {
                    return this.columnNroOV;
                }
            }

            internal DataColumn ObservacionesColumn
            {
                get
                {
                    return this.columnObservaciones;
                }
            }

            internal DataColumn OpArmadoColumn
            {
                get
                {
                    return this.columnOpArmado;
                }
            }

            internal DataColumn OpEmbalajeColumn
            {
                get
                {
                    return this.columnOpEmbalaje;
                }
            }

            internal DataColumn OpPruebaColumn
            {
                get
                {
                    return this.columnOpPrueba;
                }
            }

            internal DataColumn OpRecoleccionColumn
            {
                get
                {
                    return this.columnOpRecoleccion;
                }
            }

            internal DataColumn TiempoAsigColumn
            {
                get
                {
                    return this.columnTiempoAsig;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpGesEnsRow : DataRow
        {
            private DataTmpGesEns.PC1TmpGesEnsDataTable tablePC1TmpGesEns;

            internal PC1TmpGesEnsRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpGesEns = (DataTmpGesEns.PC1TmpGesEnsDataTable) this.Table;
            }

            public bool IsClienteNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.ClienteColumn);
            }

            public bool IsDescripcionNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.DescripcionColumn);
            }

            public bool IsFechaEnsRealNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.FechaEnsRealColumn);
            }

            public bool IsNroOVNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.NroOVColumn);
            }

            public bool IsObservacionesNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.ObservacionesColumn);
            }

            public bool IsOpArmadoNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.OpArmadoColumn);
            }

            public bool IsOpEmbalajeNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.OpEmbalajeColumn);
            }

            public bool IsOpPruebaNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.OpPruebaColumn);
            }

            public bool IsOpRecoleccionNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.OpRecoleccionColumn);
            }

            public bool IsTiempoAsigNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.TiempoAsigColumn);
            }

            public void SetClienteNull()
            {
                this[this.tablePC1TmpGesEns.ClienteColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDescripcionNull()
            {
                this[this.tablePC1TmpGesEns.DescripcionColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFechaEnsRealNull()
            {
                this[this.tablePC1TmpGesEns.FechaEnsRealColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNroOVNull()
            {
                this[this.tablePC1TmpGesEns.NroOVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetObservacionesNull()
            {
                this[this.tablePC1TmpGesEns.ObservacionesColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOpArmadoNull()
            {
                this[this.tablePC1TmpGesEns.OpArmadoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOpEmbalajeNull()
            {
                this[this.tablePC1TmpGesEns.OpEmbalajeColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOpPruebaNull()
            {
                this[this.tablePC1TmpGesEns.OpPruebaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOpRecoleccionNull()
            {
                this[this.tablePC1TmpGesEns.OpRecoleccionColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTiempoAsigNull()
            {
                this[this.tablePC1TmpGesEns.TiempoAsigColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal CantArmado
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpGesEns.CantArmadoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.CantArmadoColumn] = value;
                }
            }

            public decimal CantOE
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpGesEns.CantOEColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.CantOEColumn] = value;
                }
            }

            public string Cliente
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpGesEns.ClienteColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePC1TmpGesEns.ClienteColumn] = value;
                }
            }

            public string Codigo
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpGesEns.CodigoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.CodigoColumn] = value;
                }
            }

            public string Descripcion
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpGesEns.DescripcionColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePC1TmpGesEns.DescripcionColumn] = value;
                }
            }

            public DateTime FechaEnsReal
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = DateType.FromObject(this[this.tablePC1TmpGesEns.FechaEnsRealColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return time;
                }
                set
                {
                    this[this.tablePC1TmpGesEns.FechaEnsRealColumn] = value;
                }
            }

            public DateTime FechaEnt
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpGesEns.FechaEntColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.FechaEntColumn] = value;
                }
            }

            public DateTime FechaOE
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpGesEns.FechaOEColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.FechaOEColumn] = value;
                }
            }

            public string NroLinea
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpGesEns.NroLineaColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.NroLineaColumn] = value;
                }
            }

            public string NroOE
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpGesEns.NroOEColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.NroOEColumn] = value;
                }
            }

            public string NroOV
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpGesEns.NroOVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePC1TmpGesEns.NroOVColumn] = value;
                }
            }

            public string Observaciones
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpGesEns.ObservacionesColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePC1TmpGesEns.ObservacionesColumn] = value;
                }
            }

            public string OpArmado
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpGesEns.OpArmadoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePC1TmpGesEns.OpArmadoColumn] = value;
                }
            }

            public string OpEmbalaje
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpGesEns.OpEmbalajeColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePC1TmpGesEns.OpEmbalajeColumn] = value;
                }
            }

            public string OpPrueba
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpGesEns.OpPruebaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePC1TmpGesEns.OpPruebaColumn] = value;
                }
            }

            public string OpRecoleccion
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpGesEns.OpRecoleccionColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePC1TmpGesEns.OpRecoleccionColumn] = value;
                }
            }

            public string TiempoAsig
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpGesEns.TiempoAsigColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePC1TmpGesEns.TiempoAsigColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpGesEnsRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataTmpGesEns.PC1TmpGesEnsRow eventRow;

            public PC1TmpGesEnsRowChangeEvent(DataTmpGesEns.PC1TmpGesEnsRow row, DataRowAction action)
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

            public DataTmpGesEns.PC1TmpGesEnsRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpGesEnsRowChangeEventHandler(object sender, DataTmpGesEns.PC1TmpGesEnsRowChangeEvent e);

        [DebuggerStepThrough]
        public class PC1TmpRepGesEnsDataTable : DataTable, IEnumerable
        {
            private DataColumn columnCantArmado;
            private DataColumn columnCantOE;
            private DataColumn columnCliente;
            private DataColumn columnCodigo;
            private DataColumn columnDescripcion;
            private DataColumn columnFechaEnsReal;
            private DataColumn columnFechaEnt;
            private DataColumn columnFechaOE;
            private DataColumn columnGrupo;
            private DataColumn columnNomGrupo;
            private DataColumn columnNroLinea;
            private DataColumn columnNroOE;
            private DataColumn columnNroOV;
            private DataColumn columnObs;
            private DataColumn columnObservaciones;
            private DataColumn columnOpArmado;
            private DataColumn columnOpEmbalaje;
            private DataColumn columnOpPrueba;
            private DataColumn columnOpRecoleccion;
            private DataColumn columnTArmado;
            private DataColumn columnTEmbalaje;
            private DataColumn columnTiempoAsig;
            private DataColumn columnTPrueba;
            private DataColumn columnTRecoleccion;

            public event DataTmpGesEns.PC1TmpRepGesEnsRowChangeEventHandler PC1TmpRepGesEnsRowChanged;

            public event DataTmpGesEns.PC1TmpRepGesEnsRowChangeEventHandler PC1TmpRepGesEnsRowChanging;

            public event DataTmpGesEns.PC1TmpRepGesEnsRowChangeEventHandler PC1TmpRepGesEnsRowDeleted;

            public event DataTmpGesEns.PC1TmpRepGesEnsRowChangeEventHandler PC1TmpRepGesEnsRowDeleting;

            internal PC1TmpRepGesEnsDataTable() : base("PC1TmpRepGesEns")
            {
                this.InitClass();
            }

            internal PC1TmpRepGesEnsDataTable(DataTable table) : base(table.TableName)
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

            public void AddPC1TmpRepGesEnsRow(DataTmpGesEns.PC1TmpRepGesEnsRow row)
            {
                this.Rows.Add(row);
            }

            public DataTmpGesEns.PC1TmpRepGesEnsRow AddPC1TmpRepGesEnsRow(string NroOE, DateTime FechaOE, DateTime FechaEnt, DateTime FechaEnsReal, string NroLinea, string Codigo, string Descripcion, string Grupo, string NomGrupo, decimal CantOE, decimal CantArmado, string Cliente, string NroOV, string Observaciones, string TiempoAsig, string OpRecoleccion, string OpArmado, string OpPrueba, string OpEmbalaje, decimal TRecoleccion, decimal TArmado, decimal TPrueba, decimal TEmbalaje, string Obs)
            {
                DataTmpGesEns.PC1TmpRepGesEnsRow row = (DataTmpGesEns.PC1TmpRepGesEnsRow) this.NewRow();
                row.ItemArray = new object[] { 
                    NroOE, FechaOE, FechaEnt, FechaEnsReal, NroLinea, Codigo, Descripcion, Grupo, NomGrupo, CantOE, CantArmado, Cliente, NroOV, Observaciones, TiempoAsig, OpRecoleccion, 
                    OpArmado, OpPrueba, OpEmbalaje, TRecoleccion, TArmado, TPrueba, TEmbalaje, Obs
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataTmpGesEns.PC1TmpRepGesEnsDataTable table = (DataTmpGesEns.PC1TmpRepGesEnsDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataTmpGesEns.PC1TmpRepGesEnsDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataTmpGesEns.PC1TmpRepGesEnsRow);
            }

            private void InitClass()
            {
                this.columnNroOE = new DataColumn("NroOE", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOE);
                this.columnFechaOE = new DataColumn("FechaOE", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaOE);
                this.columnFechaEnt = new DataColumn("FechaEnt", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaEnt);
                this.columnFechaEnsReal = new DataColumn("FechaEnsReal", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaEnsReal);
                this.columnNroLinea = new DataColumn("NroLinea", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroLinea);
                this.columnCodigo = new DataColumn("Codigo", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodigo);
                this.columnDescripcion = new DataColumn("Descripcion", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDescripcion);
                this.columnGrupo = new DataColumn("Grupo", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnGrupo);
                this.columnNomGrupo = new DataColumn("NomGrupo", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNomGrupo);
                this.columnCantOE = new DataColumn("CantOE", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantOE);
                this.columnCantArmado = new DataColumn("CantArmado", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantArmado);
                this.columnCliente = new DataColumn("Cliente", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCliente);
                this.columnNroOV = new DataColumn("NroOV", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOV);
                this.columnObservaciones = new DataColumn("Observaciones", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnObservaciones);
                this.columnTiempoAsig = new DataColumn("TiempoAsig", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnTiempoAsig);
                this.columnOpRecoleccion = new DataColumn("OpRecoleccion", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOpRecoleccion);
                this.columnOpArmado = new DataColumn("OpArmado", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOpArmado);
                this.columnOpPrueba = new DataColumn("OpPrueba", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOpPrueba);
                this.columnOpEmbalaje = new DataColumn("OpEmbalaje", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOpEmbalaje);
                this.columnTRecoleccion = new DataColumn("TRecoleccion", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnTRecoleccion);
                this.columnTArmado = new DataColumn("TArmado", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnTArmado);
                this.columnTPrueba = new DataColumn("TPrueba", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnTPrueba);
                this.columnTEmbalaje = new DataColumn("TEmbalaje", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnTEmbalaje);
                this.columnObs = new DataColumn("Obs", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnObs);
                this.columnNroOE.AllowDBNull = false;
                this.columnFechaOE.AllowDBNull = false;
                this.columnFechaEnt.AllowDBNull = false;
                this.columnNroLinea.AllowDBNull = false;
                this.columnCodigo.AllowDBNull = false;
                this.columnGrupo.AllowDBNull = false;
                this.columnNomGrupo.AllowDBNull = false;
                this.columnCantOE.AllowDBNull = false;
                this.columnCantArmado.AllowDBNull = false;
                this.columnObs.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnNroOE = this.Columns["NroOE"];
                this.columnFechaOE = this.Columns["FechaOE"];
                this.columnFechaEnt = this.Columns["FechaEnt"];
                this.columnFechaEnsReal = this.Columns["FechaEnsReal"];
                this.columnNroLinea = this.Columns["NroLinea"];
                this.columnCodigo = this.Columns["Codigo"];
                this.columnDescripcion = this.Columns["Descripcion"];
                this.columnGrupo = this.Columns["Grupo"];
                this.columnNomGrupo = this.Columns["NomGrupo"];
                this.columnCantOE = this.Columns["CantOE"];
                this.columnCantArmado = this.Columns["CantArmado"];
                this.columnCliente = this.Columns["Cliente"];
                this.columnNroOV = this.Columns["NroOV"];
                this.columnObservaciones = this.Columns["Observaciones"];
                this.columnTiempoAsig = this.Columns["TiempoAsig"];
                this.columnOpRecoleccion = this.Columns["OpRecoleccion"];
                this.columnOpArmado = this.Columns["OpArmado"];
                this.columnOpPrueba = this.Columns["OpPrueba"];
                this.columnOpEmbalaje = this.Columns["OpEmbalaje"];
                this.columnTRecoleccion = this.Columns["TRecoleccion"];
                this.columnTArmado = this.Columns["TArmado"];
                this.columnTPrueba = this.Columns["TPrueba"];
                this.columnTEmbalaje = this.Columns["TEmbalaje"];
                this.columnObs = this.Columns["Obs"];
            }

            public DataTmpGesEns.PC1TmpRepGesEnsRow NewPC1TmpRepGesEnsRow()
            {
                return (DataTmpGesEns.PC1TmpRepGesEnsRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataTmpGesEns.PC1TmpRepGesEnsRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpRepGesEnsRowChangedEvent != null) && (this.PC1TmpRepGesEnsRowChangedEvent != null))
                {
                    this.PC1TmpRepGesEnsRowChangedEvent(this, new DataTmpGesEns.PC1TmpRepGesEnsRowChangeEvent((DataTmpGesEns.PC1TmpRepGesEnsRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpRepGesEnsRowChangingEvent != null) && (this.PC1TmpRepGesEnsRowChangingEvent != null))
                {
                    this.PC1TmpRepGesEnsRowChangingEvent(this, new DataTmpGesEns.PC1TmpRepGesEnsRowChangeEvent((DataTmpGesEns.PC1TmpRepGesEnsRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpRepGesEnsRowDeletedEvent != null) && (this.PC1TmpRepGesEnsRowDeletedEvent != null))
                {
                    this.PC1TmpRepGesEnsRowDeletedEvent(this, new DataTmpGesEns.PC1TmpRepGesEnsRowChangeEvent((DataTmpGesEns.PC1TmpRepGesEnsRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpRepGesEnsRowDeletingEvent != null) && (this.PC1TmpRepGesEnsRowDeletingEvent != null))
                {
                    this.PC1TmpRepGesEnsRowDeletingEvent(this, new DataTmpGesEns.PC1TmpRepGesEnsRowChangeEvent((DataTmpGesEns.PC1TmpRepGesEnsRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpRepGesEnsRow(DataTmpGesEns.PC1TmpRepGesEnsRow row)
            {
                this.Rows.Remove(row);
            }

            internal DataColumn CantArmadoColumn
            {
                get
                {
                    return this.columnCantArmado;
                }
            }

            internal DataColumn CantOEColumn
            {
                get
                {
                    return this.columnCantOE;
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

            internal DataColumn DescripcionColumn
            {
                get
                {
                    return this.columnDescripcion;
                }
            }

            internal DataColumn FechaEnsRealColumn
            {
                get
                {
                    return this.columnFechaEnsReal;
                }
            }

            internal DataColumn FechaEntColumn
            {
                get
                {
                    return this.columnFechaEnt;
                }
            }

            internal DataColumn FechaOEColumn
            {
                get
                {
                    return this.columnFechaOE;
                }
            }

            internal DataColumn GrupoColumn
            {
                get
                {
                    return this.columnGrupo;
                }
            }

            public DataTmpGesEns.PC1TmpRepGesEnsRow this[int index]
            {
                get
                {
                    return (DataTmpGesEns.PC1TmpRepGesEnsRow) this.Rows[index];
                }
            }

            internal DataColumn NomGrupoColumn
            {
                get
                {
                    return this.columnNomGrupo;
                }
            }

            internal DataColumn NroLineaColumn
            {
                get
                {
                    return this.columnNroLinea;
                }
            }

            internal DataColumn NroOEColumn
            {
                get
                {
                    return this.columnNroOE;
                }
            }

            internal DataColumn NroOVColumn
            {
                get
                {
                    return this.columnNroOV;
                }
            }

            internal DataColumn ObsColumn
            {
                get
                {
                    return this.columnObs;
                }
            }

            internal DataColumn ObservacionesColumn
            {
                get
                {
                    return this.columnObservaciones;
                }
            }

            internal DataColumn OpArmadoColumn
            {
                get
                {
                    return this.columnOpArmado;
                }
            }

            internal DataColumn OpEmbalajeColumn
            {
                get
                {
                    return this.columnOpEmbalaje;
                }
            }

            internal DataColumn OpPruebaColumn
            {
                get
                {
                    return this.columnOpPrueba;
                }
            }

            internal DataColumn OpRecoleccionColumn
            {
                get
                {
                    return this.columnOpRecoleccion;
                }
            }

            internal DataColumn TArmadoColumn
            {
                get
                {
                    return this.columnTArmado;
                }
            }

            internal DataColumn TEmbalajeColumn
            {
                get
                {
                    return this.columnTEmbalaje;
                }
            }

            internal DataColumn TiempoAsigColumn
            {
                get
                {
                    return this.columnTiempoAsig;
                }
            }

            internal DataColumn TPruebaColumn
            {
                get
                {
                    return this.columnTPrueba;
                }
            }

            internal DataColumn TRecoleccionColumn
            {
                get
                {
                    return this.columnTRecoleccion;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpRepGesEnsRow : DataRow
        {
            private DataTmpGesEns.PC1TmpRepGesEnsDataTable tablePC1TmpRepGesEns;

            internal PC1TmpRepGesEnsRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpRepGesEns = (DataTmpGesEns.PC1TmpRepGesEnsDataTable) this.Table;
            }

            public bool IsClienteNull()
            {
                return this.IsNull(this.tablePC1TmpRepGesEns.ClienteColumn);
            }

            public bool IsDescripcionNull()
            {
                return this.IsNull(this.tablePC1TmpRepGesEns.DescripcionColumn);
            }

            public bool IsFechaEnsRealNull()
            {
                return this.IsNull(this.tablePC1TmpRepGesEns.FechaEnsRealColumn);
            }

            public bool IsNroOVNull()
            {
                return this.IsNull(this.tablePC1TmpRepGesEns.NroOVColumn);
            }

            public bool IsObservacionesNull()
            {
                return this.IsNull(this.tablePC1TmpRepGesEns.ObservacionesColumn);
            }

            public bool IsOpArmadoNull()
            {
                return this.IsNull(this.tablePC1TmpRepGesEns.OpArmadoColumn);
            }

            public bool IsOpEmbalajeNull()
            {
                return this.IsNull(this.tablePC1TmpRepGesEns.OpEmbalajeColumn);
            }

            public bool IsOpPruebaNull()
            {
                return this.IsNull(this.tablePC1TmpRepGesEns.OpPruebaColumn);
            }

            public bool IsOpRecoleccionNull()
            {
                return this.IsNull(this.tablePC1TmpRepGesEns.OpRecoleccionColumn);
            }

            public bool IsTArmadoNull()
            {
                return this.IsNull(this.tablePC1TmpRepGesEns.TArmadoColumn);
            }

            public bool IsTEmbalajeNull()
            {
                return this.IsNull(this.tablePC1TmpRepGesEns.TEmbalajeColumn);
            }

            public bool IsTiempoAsigNull()
            {
                return this.IsNull(this.tablePC1TmpRepGesEns.TiempoAsigColumn);
            }

            public bool IsTPruebaNull()
            {
                return this.IsNull(this.tablePC1TmpRepGesEns.TPruebaColumn);
            }

            public bool IsTRecoleccionNull()
            {
                return this.IsNull(this.tablePC1TmpRepGesEns.TRecoleccionColumn);
            }

            public void SetClienteNull()
            {
                this[this.tablePC1TmpRepGesEns.ClienteColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDescripcionNull()
            {
                this[this.tablePC1TmpRepGesEns.DescripcionColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFechaEnsRealNull()
            {
                this[this.tablePC1TmpRepGesEns.FechaEnsRealColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNroOVNull()
            {
                this[this.tablePC1TmpRepGesEns.NroOVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetObservacionesNull()
            {
                this[this.tablePC1TmpRepGesEns.ObservacionesColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOpArmadoNull()
            {
                this[this.tablePC1TmpRepGesEns.OpArmadoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOpEmbalajeNull()
            {
                this[this.tablePC1TmpRepGesEns.OpEmbalajeColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOpPruebaNull()
            {
                this[this.tablePC1TmpRepGesEns.OpPruebaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOpRecoleccionNull()
            {
                this[this.tablePC1TmpRepGesEns.OpRecoleccionColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTArmadoNull()
            {
                this[this.tablePC1TmpRepGesEns.TArmadoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTEmbalajeNull()
            {
                this[this.tablePC1TmpRepGesEns.TEmbalajeColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTiempoAsigNull()
            {
                this[this.tablePC1TmpRepGesEns.TiempoAsigColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTPruebaNull()
            {
                this[this.tablePC1TmpRepGesEns.TPruebaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTRecoleccionNull()
            {
                this[this.tablePC1TmpRepGesEns.TRecoleccionColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal CantArmado
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpRepGesEns.CantArmadoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.CantArmadoColumn] = value;
                }
            }

            public decimal CantOE
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpRepGesEns.CantOEColumn]);
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.CantOEColumn] = value;
                }
            }

            public string Cliente
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpRepGesEns.ClienteColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.ClienteColumn] = value;
                }
            }

            public string Codigo
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpRepGesEns.CodigoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.CodigoColumn] = value;
                }
            }

            public string Descripcion
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpRepGesEns.DescripcionColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.DescripcionColumn] = value;
                }
            }

            public DateTime FechaEnsReal
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = DateType.FromObject(this[this.tablePC1TmpRepGesEns.FechaEnsRealColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return time;
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.FechaEnsRealColumn] = value;
                }
            }

            public DateTime FechaEnt
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpRepGesEns.FechaEntColumn]);
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.FechaEntColumn] = value;
                }
            }

            public DateTime FechaOE
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpRepGesEns.FechaOEColumn]);
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.FechaOEColumn] = value;
                }
            }

            public string Grupo
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpRepGesEns.GrupoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.GrupoColumn] = value;
                }
            }

            public string NomGrupo
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpRepGesEns.NomGrupoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.NomGrupoColumn] = value;
                }
            }

            public string NroLinea
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpRepGesEns.NroLineaColumn]);
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.NroLineaColumn] = value;
                }
            }

            public string NroOE
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpRepGesEns.NroOEColumn]);
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.NroOEColumn] = value;
                }
            }

            public string NroOV
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpRepGesEns.NroOVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.NroOVColumn] = value;
                }
            }

            public string Obs
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpRepGesEns.ObsColumn]);
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.ObsColumn] = value;
                }
            }

            public string Observaciones
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpRepGesEns.ObservacionesColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.ObservacionesColumn] = value;
                }
            }

            public string OpArmado
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpRepGesEns.OpArmadoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.OpArmadoColumn] = value;
                }
            }

            public string OpEmbalaje
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpRepGesEns.OpEmbalajeColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.OpEmbalajeColumn] = value;
                }
            }

            public string OpPrueba
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpRepGesEns.OpPruebaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.OpPruebaColumn] = value;
                }
            }

            public string OpRecoleccion
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpRepGesEns.OpRecoleccionColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.OpRecoleccionColumn] = value;
                }
            }

            public decimal TArmado
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tablePC1TmpRepGesEns.TArmadoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return num;
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.TArmadoColumn] = value;
                }
            }

            public decimal TEmbalaje
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tablePC1TmpRepGesEns.TEmbalajeColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return num;
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.TEmbalajeColumn] = value;
                }
            }

            public string TiempoAsig
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpRepGesEns.TiempoAsigColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return str;
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.TiempoAsigColumn] = value;
                }
            }

            public decimal TPrueba
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tablePC1TmpRepGesEns.TPruebaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return num;
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.TPruebaColumn] = value;
                }
            }

            public decimal TRecoleccion
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tablePC1TmpRepGesEns.TRecoleccionColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return num;
                }
                set
                {
                    this[this.tablePC1TmpRepGesEns.TRecoleccionColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpRepGesEnsRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataTmpGesEns.PC1TmpRepGesEnsRow eventRow;

            public PC1TmpRepGesEnsRowChangeEvent(DataTmpGesEns.PC1TmpRepGesEnsRow row, DataRowAction action)
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

            public DataTmpGesEns.PC1TmpRepGesEnsRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpRepGesEnsRowChangeEventHandler(object sender, DataTmpGesEns.PC1TmpRepGesEnsRowChangeEvent e);
    }
}

