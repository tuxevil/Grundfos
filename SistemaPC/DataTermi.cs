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
    public class DataTermi : DataSet
    {
        private TerminalesDataTable tableTerminales;

        public DataTermi()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DataTermi(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["Terminales"] != null)
                {
                    this.Tables.Add(new TerminalesDataTable(dataSet.Tables["Terminales"]));
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
            DataTermi termi = (DataTermi) base.Clone();
            termi.InitVars();
            return termi;
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
            this.DataSetName = "DataTermi";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DataTermi.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableTerminales = new TerminalesDataTable();
            this.Tables.Add(this.tableTerminales);
        }

        internal void InitVars()
        {
            this.tableTerminales = (TerminalesDataTable) this.Tables["Terminales"];
            if (this.tableTerminales != null)
            {
                this.tableTerminales.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["Terminales"] != null)
            {
                this.Tables.Add(new TerminalesDataTable(dataSet.Tables["Terminales"]));
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

        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        private bool ShouldSerializeTerminales()
        {
            return false;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public TerminalesDataTable Terminales
        {
            get
            {
                return this.tableTerminales;
            }
        }

        [DebuggerStepThrough]
        public class TerminalesDataTable : DataTable, IEnumerable
        {
            private DataColumn columnCodigo;

            public event DataTermi.TerminalesRowChangeEventHandler TerminalesRowChanged;

            public event DataTermi.TerminalesRowChangeEventHandler TerminalesRowChanging;

            public event DataTermi.TerminalesRowChangeEventHandler TerminalesRowDeleted;

            public event DataTermi.TerminalesRowChangeEventHandler TerminalesRowDeleting;

            internal TerminalesDataTable() : base("Terminales")
            {
                this.InitClass();
            }

            internal TerminalesDataTable(DataTable table) : base(table.TableName)
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

            public void AddTerminalesRow(DataTermi.TerminalesRow row)
            {
                this.Rows.Add(row);
            }

            public DataTermi.TerminalesRow AddTerminalesRow(string Codigo)
            {
                DataTermi.TerminalesRow row = (DataTermi.TerminalesRow) this.NewRow();
                row.ItemArray = new object[] { Codigo };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataTermi.TerminalesDataTable table = (DataTermi.TerminalesDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataTermi.TerminalesDataTable();
            }

            public DataTermi.TerminalesRow FindByCodigo(string Codigo)
            {
                return (DataTermi.TerminalesRow) this.Rows.Find(new object[] { Codigo });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataTermi.TerminalesRow);
            }

            private void InitClass()
            {
                this.columnCodigo = new DataColumn("Codigo", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodigo);
                this.Constraints.Add(new UniqueConstraint("DataTermiKey1", new DataColumn[] { this.columnCodigo }, true));
                this.columnCodigo.AllowDBNull = false;
                this.columnCodigo.Unique = true;
            }

            internal void InitVars()
            {
                this.columnCodigo = this.Columns["Codigo"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataTermi.TerminalesRow(builder);
            }

            public DataTermi.TerminalesRow NewTerminalesRow()
            {
                return (DataTermi.TerminalesRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.TerminalesRowChangedEvent != null) && (this.TerminalesRowChangedEvent != null))
                {
                    this.TerminalesRowChangedEvent(this, new DataTermi.TerminalesRowChangeEvent((DataTermi.TerminalesRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.TerminalesRowChangingEvent != null) && (this.TerminalesRowChangingEvent != null))
                {
                    this.TerminalesRowChangingEvent(this, new DataTermi.TerminalesRowChangeEvent((DataTermi.TerminalesRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.TerminalesRowDeletedEvent != null) && (this.TerminalesRowDeletedEvent != null))
                {
                    this.TerminalesRowDeletedEvent(this, new DataTermi.TerminalesRowChangeEvent((DataTermi.TerminalesRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.TerminalesRowDeletingEvent != null) && (this.TerminalesRowDeletingEvent != null))
                {
                    this.TerminalesRowDeletingEvent(this, new DataTermi.TerminalesRowChangeEvent((DataTermi.TerminalesRow) e.Row, e.Action));
                }
            }

            public void RemoveTerminalesRow(DataTermi.TerminalesRow row)
            {
                this.Rows.Remove(row);
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

            public DataTermi.TerminalesRow this[int index]
            {
                get
                {
                    return (DataTermi.TerminalesRow) this.Rows[index];
                }
            }
        }

        [DebuggerStepThrough]
        public class TerminalesRow : DataRow
        {
            private DataTermi.TerminalesDataTable tableTerminales;

            internal TerminalesRow(DataRowBuilder rb) : base(rb)
            {
                this.tableTerminales = (DataTermi.TerminalesDataTable) this.Table;
            }

            public string Codigo
            {
                get
                {
                    return StringType.FromObject(this[this.tableTerminales.CodigoColumn]);
                }
                set
                {
                    this[this.tableTerminales.CodigoColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class TerminalesRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataTermi.TerminalesRow eventRow;

            public TerminalesRowChangeEvent(DataTermi.TerminalesRow row, DataRowAction action)
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

            public DataTermi.TerminalesRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void TerminalesRowChangeEventHandler(object sender, DataTermi.TerminalesRowChangeEvent e);
    }
}

