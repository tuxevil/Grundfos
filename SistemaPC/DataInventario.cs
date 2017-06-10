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

    [Serializable, DesignerCategory("code"), ToolboxItem(true), DebuggerStepThrough]
    public class DataInventario : DataSet
    {
        private InventarioDataTable tableInventario;

        public DataInventario()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DataInventario(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["Inventario"] != null)
                {
                    this.Tables.Add(new InventarioDataTable(dataSet.Tables["Inventario"]));
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
            DataInventario inventario = (DataInventario) base.Clone();
            inventario.InitVars();
            return inventario;
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
            this.DataSetName = "DataInventario";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DataInventario.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableInventario = new InventarioDataTable();
            this.Tables.Add(this.tableInventario);
        }

        internal void InitVars()
        {
            this.tableInventario = (InventarioDataTable) this.Tables["Inventario"];
            if (this.tableInventario != null)
            {
                this.tableInventario.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["Inventario"] != null)
            {
                this.Tables.Add(new InventarioDataTable(dataSet.Tables["Inventario"]));
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

        private bool ShouldSerializeInventario()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public InventarioDataTable Inventario
        {
            get
            {
                return this.tableInventario;
            }
        }

        [DebuggerStepThrough]
        public class InventarioDataTable : DataTable, IEnumerable
        {
            private DataColumn columnCantidad;
            private DataColumn columnCodigo;
            private DataColumn columnColector;
            private DataColumn columnDesc1;
            private DataColumn columnDesc2;
            private DataColumn columnFecha;
            private DataColumn columnFechaInv;
            private DataColumn columnHora;
            private DataColumn columnOperador;
            private DataColumn columnPosicion;

            public event DataInventario.InventarioRowChangeEventHandler InventarioRowChanged;

            public event DataInventario.InventarioRowChangeEventHandler InventarioRowChanging;

            public event DataInventario.InventarioRowChangeEventHandler InventarioRowDeleted;

            public event DataInventario.InventarioRowChangeEventHandler InventarioRowDeleting;

            internal InventarioDataTable() : base("Inventario")
            {
                this.InitClass();
            }

            internal InventarioDataTable(DataTable table) : base(table.TableName)
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

            public void AddInventarioRow(DataInventario.InventarioRow row)
            {
                this.Rows.Add(row);
            }

            public DataInventario.InventarioRow AddInventarioRow(string Operador, string Colector, DateTime FechaInv, string Posicion, string Codigo, string Desc1, string Desc2, decimal Cantidad, DateTime Fecha, string Hora)
            {
                DataInventario.InventarioRow row = (DataInventario.InventarioRow) this.NewRow();
                row.ItemArray = new object[] { Operador, Colector, FechaInv, Posicion, Codigo, Desc1, Desc2, Cantidad, Fecha, Hora };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataInventario.InventarioDataTable table = (DataInventario.InventarioDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataInventario.InventarioDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataInventario.InventarioRow);
            }

            private void InitClass()
            {
                this.columnOperador = new DataColumn("Operador", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOperador);
                this.columnColector = new DataColumn("Colector", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnColector);
                this.columnFechaInv = new DataColumn("FechaInv", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaInv);
                this.columnPosicion = new DataColumn("Posicion", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPosicion);
                this.columnCodigo = new DataColumn("Codigo", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodigo);
                this.columnDesc1 = new DataColumn("Desc1", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDesc1);
                this.columnDesc2 = new DataColumn("Desc2", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDesc2);
                this.columnCantidad = new DataColumn("Cantidad", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantidad);
                this.columnFecha = new DataColumn("Fecha", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFecha);
                this.columnHora = new DataColumn("Hora", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnHora);
                this.columnOperador.AllowDBNull = false;
                this.columnColector.AllowDBNull = false;
                this.columnFechaInv.AllowDBNull = false;
                this.columnPosicion.AllowDBNull = false;
                this.columnCodigo.AllowDBNull = false;
                this.columnCantidad.AllowDBNull = false;
                this.columnFecha.AllowDBNull = false;
                this.columnHora.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnOperador = this.Columns["Operador"];
                this.columnColector = this.Columns["Colector"];
                this.columnFechaInv = this.Columns["FechaInv"];
                this.columnPosicion = this.Columns["Posicion"];
                this.columnCodigo = this.Columns["Codigo"];
                this.columnDesc1 = this.Columns["Desc1"];
                this.columnDesc2 = this.Columns["Desc2"];
                this.columnCantidad = this.Columns["Cantidad"];
                this.columnFecha = this.Columns["Fecha"];
                this.columnHora = this.Columns["Hora"];
            }

            public DataInventario.InventarioRow NewInventarioRow()
            {
                return (DataInventario.InventarioRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataInventario.InventarioRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.InventarioRowChangedEvent != null) && (this.InventarioRowChangedEvent != null))
                {
                    this.InventarioRowChangedEvent(this, new DataInventario.InventarioRowChangeEvent((DataInventario.InventarioRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.InventarioRowChangingEvent != null) && (this.InventarioRowChangingEvent != null))
                {
                    this.InventarioRowChangingEvent(this, new DataInventario.InventarioRowChangeEvent((DataInventario.InventarioRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.InventarioRowDeletedEvent != null) && (this.InventarioRowDeletedEvent != null))
                {
                    this.InventarioRowDeletedEvent(this, new DataInventario.InventarioRowChangeEvent((DataInventario.InventarioRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.InventarioRowDeletingEvent != null) && (this.InventarioRowDeletingEvent != null))
                {
                    this.InventarioRowDeletingEvent(this, new DataInventario.InventarioRowChangeEvent((DataInventario.InventarioRow) e.Row, e.Action));
                }
            }

            public void RemoveInventarioRow(DataInventario.InventarioRow row)
            {
                this.Rows.Remove(row);
            }

            internal DataColumn CantidadColumn
            {
                get
                {
                    return this.columnCantidad;
                }
            }

            internal DataColumn CodigoColumn
            {
                get
                {
                    return this.columnCodigo;
                }
            }

            internal DataColumn ColectorColumn
            {
                get
                {
                    return this.columnColector;
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

            internal DataColumn FechaColumn
            {
                get
                {
                    return this.columnFecha;
                }
            }

            internal DataColumn FechaInvColumn
            {
                get
                {
                    return this.columnFechaInv;
                }
            }

            internal DataColumn HoraColumn
            {
                get
                {
                    return this.columnHora;
                }
            }

            public DataInventario.InventarioRow this[int index]
            {
                get
                {
                    return (DataInventario.InventarioRow) this.Rows[index];
                }
            }

            internal DataColumn OperadorColumn
            {
                get
                {
                    return this.columnOperador;
                }
            }

            internal DataColumn PosicionColumn
            {
                get
                {
                    return this.columnPosicion;
                }
            }
        }

        [DebuggerStepThrough]
        public class InventarioRow : DataRow
        {
            private DataInventario.InventarioDataTable tableInventario;

            internal InventarioRow(DataRowBuilder rb) : base(rb)
            {
                this.tableInventario = (DataInventario.InventarioDataTable) this.Table;
            }

            public bool IsDesc1Null()
            {
                return this.IsNull(this.tableInventario.Desc1Column);
            }

            public bool IsDesc2Null()
            {
                return this.IsNull(this.tableInventario.Desc2Column);
            }

            public void SetDesc1Null()
            {
                this[this.tableInventario.Desc1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDesc2Null()
            {
                this[this.tableInventario.Desc2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal Cantidad
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableInventario.CantidadColumn]);
                }
                set
                {
                    this[this.tableInventario.CantidadColumn] = value;
                }
            }

            public string Codigo
            {
                get
                {
                    return StringType.FromObject(this[this.tableInventario.CodigoColumn]);
                }
                set
                {
                    this[this.tableInventario.CodigoColumn] = value;
                }
            }

            public string Colector
            {
                get
                {
                    return StringType.FromObject(this[this.tableInventario.ColectorColumn]);
                }
                set
                {
                    this[this.tableInventario.ColectorColumn] = value;
                }
            }

            public string Desc1
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tableInventario.Desc1Column]);
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
                    this[this.tableInventario.Desc1Column] = value;
                }
            }

            public string Desc2
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tableInventario.Desc2Column]);
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
                    this[this.tableInventario.Desc2Column] = value;
                }
            }

            public DateTime Fecha
            {
                get
                {
                    return DateType.FromObject(this[this.tableInventario.FechaColumn]);
                }
                set
                {
                    this[this.tableInventario.FechaColumn] = value;
                }
            }

            public DateTime FechaInv
            {
                get
                {
                    return DateType.FromObject(this[this.tableInventario.FechaInvColumn]);
                }
                set
                {
                    this[this.tableInventario.FechaInvColumn] = value;
                }
            }

            public string Hora
            {
                get
                {
                    return StringType.FromObject(this[this.tableInventario.HoraColumn]);
                }
                set
                {
                    this[this.tableInventario.HoraColumn] = value;
                }
            }

            public string Operador
            {
                get
                {
                    return StringType.FromObject(this[this.tableInventario.OperadorColumn]);
                }
                set
                {
                    this[this.tableInventario.OperadorColumn] = value;
                }
            }

            public string Posicion
            {
                get
                {
                    return StringType.FromObject(this[this.tableInventario.PosicionColumn]);
                }
                set
                {
                    this[this.tableInventario.PosicionColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class InventarioRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataInventario.InventarioRow eventRow;

            public InventarioRowChangeEvent(DataInventario.InventarioRow row, DataRowAction action)
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

            public DataInventario.InventarioRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void InventarioRowChangeEventHandler(object sender, DataInventario.InventarioRowChangeEvent e);
    }
}

