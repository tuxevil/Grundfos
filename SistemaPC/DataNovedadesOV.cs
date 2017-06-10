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

    [Serializable, ToolboxItem(true), DesignerCategory("code"), DebuggerStepThrough]
    public class DataNovedadesOV : DataSet
    {
        private NovedadesOVDataTable tableNovedadesOV;

        public DataNovedadesOV()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DataNovedadesOV(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["NovedadesOV"] != null)
                {
                    this.Tables.Add(new NovedadesOVDataTable(dataSet.Tables["NovedadesOV"]));
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
            DataNovedadesOV sov = (DataNovedadesOV) base.Clone();
            sov.InitVars();
            return sov;
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
            this.DataSetName = "DataNovedadesOV";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DataNovedadesOV.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableNovedadesOV = new NovedadesOVDataTable();
            this.Tables.Add(this.tableNovedadesOV);
        }

        internal void InitVars()
        {
            this.tableNovedadesOV = (NovedadesOVDataTable) this.Tables["NovedadesOV"];
            if (this.tableNovedadesOV != null)
            {
                this.tableNovedadesOV.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["NovedadesOV"] != null)
            {
                this.Tables.Add(new NovedadesOVDataTable(dataSet.Tables["NovedadesOV"]));
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

        private bool ShouldSerializeNovedadesOV()
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
        public NovedadesOVDataTable NovedadesOV
        {
            get
            {
                return this.tableNovedadesOV;
            }
        }

        [DebuggerStepThrough]
        public class NovedadesOVDataTable : DataTable, IEnumerable
        {
            private DataColumn columnFecha;
            private DataColumn columnIDObs;
            private DataColumn columnNroOV;
            private DataColumn columnObservaciones;

            public event DataNovedadesOV.NovedadesOVRowChangeEventHandler NovedadesOVRowChanged;

            public event DataNovedadesOV.NovedadesOVRowChangeEventHandler NovedadesOVRowChanging;

            public event DataNovedadesOV.NovedadesOVRowChangeEventHandler NovedadesOVRowDeleted;

            public event DataNovedadesOV.NovedadesOVRowChangeEventHandler NovedadesOVRowDeleting;

            internal NovedadesOVDataTable() : base("NovedadesOV")
            {
                this.InitClass();
            }

            internal NovedadesOVDataTable(DataTable table) : base(table.TableName)
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

            public void AddNovedadesOVRow(DataNovedadesOV.NovedadesOVRow row)
            {
                this.Rows.Add(row);
            }

            public DataNovedadesOV.NovedadesOVRow AddNovedadesOVRow(string NroOV, string Observaciones, DateTime Fecha)
            {
                DataNovedadesOV.NovedadesOVRow row = (DataNovedadesOV.NovedadesOVRow) this.NewRow();
                row.ItemArray = new object[] { NroOV, null, Observaciones, Fecha };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataNovedadesOV.NovedadesOVDataTable table = (DataNovedadesOV.NovedadesOVDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataNovedadesOV.NovedadesOVDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataNovedadesOV.NovedadesOVRow);
            }

            private void InitClass()
            {
                this.columnNroOV = new DataColumn("NroOV", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOV);
                this.columnIDObs = new DataColumn("IDObs", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnIDObs);
                this.columnObservaciones = new DataColumn("Observaciones", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnObservaciones);
                this.columnFecha = new DataColumn("Fecha", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFecha);
                this.columnNroOV.AllowDBNull = false;
                this.columnIDObs.AutoIncrement = true;
                this.columnIDObs.AllowDBNull = false;
                this.columnIDObs.ReadOnly = true;
                this.columnObservaciones.AllowDBNull = false;
                this.columnFecha.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnNroOV = this.Columns["NroOV"];
                this.columnIDObs = this.Columns["IDObs"];
                this.columnObservaciones = this.Columns["Observaciones"];
                this.columnFecha = this.Columns["Fecha"];
            }

            public DataNovedadesOV.NovedadesOVRow NewNovedadesOVRow()
            {
                return (DataNovedadesOV.NovedadesOVRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataNovedadesOV.NovedadesOVRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.NovedadesOVRowChangedEvent != null) && (this.NovedadesOVRowChangedEvent != null))
                {
                    this.NovedadesOVRowChangedEvent(this, new DataNovedadesOV.NovedadesOVRowChangeEvent((DataNovedadesOV.NovedadesOVRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.NovedadesOVRowChangingEvent != null) && (this.NovedadesOVRowChangingEvent != null))
                {
                    this.NovedadesOVRowChangingEvent(this, new DataNovedadesOV.NovedadesOVRowChangeEvent((DataNovedadesOV.NovedadesOVRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.NovedadesOVRowDeletedEvent != null) && (this.NovedadesOVRowDeletedEvent != null))
                {
                    this.NovedadesOVRowDeletedEvent(this, new DataNovedadesOV.NovedadesOVRowChangeEvent((DataNovedadesOV.NovedadesOVRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.NovedadesOVRowDeletingEvent != null) && (this.NovedadesOVRowDeletingEvent != null))
                {
                    this.NovedadesOVRowDeletingEvent(this, new DataNovedadesOV.NovedadesOVRowChangeEvent((DataNovedadesOV.NovedadesOVRow) e.Row, e.Action));
                }
            }

            public void RemoveNovedadesOVRow(DataNovedadesOV.NovedadesOVRow row)
            {
                this.Rows.Remove(row);
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            internal DataColumn FechaColumn
            {
                get
                {
                    return this.columnFecha;
                }
            }

            internal DataColumn IDObsColumn
            {
                get
                {
                    return this.columnIDObs;
                }
            }

            public DataNovedadesOV.NovedadesOVRow this[int index]
            {
                get
                {
                    return (DataNovedadesOV.NovedadesOVRow) this.Rows[index];
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
        }

        [DebuggerStepThrough]
        public class NovedadesOVRow : DataRow
        {
            private DataNovedadesOV.NovedadesOVDataTable tableNovedadesOV;

            internal NovedadesOVRow(DataRowBuilder rb) : base(rb)
            {
                this.tableNovedadesOV = (DataNovedadesOV.NovedadesOVDataTable) this.Table;
            }

            public DateTime Fecha
            {
                get
                {
                    return DateType.FromObject(this[this.tableNovedadesOV.FechaColumn]);
                }
                set
                {
                    this[this.tableNovedadesOV.FechaColumn] = value;
                }
            }

            public decimal IDObs
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableNovedadesOV.IDObsColumn]);
                }
                set
                {
                    this[this.tableNovedadesOV.IDObsColumn] = value;
                }
            }

            public string NroOV
            {
                get
                {
                    return StringType.FromObject(this[this.tableNovedadesOV.NroOVColumn]);
                }
                set
                {
                    this[this.tableNovedadesOV.NroOVColumn] = value;
                }
            }

            public string Observaciones
            {
                get
                {
                    return StringType.FromObject(this[this.tableNovedadesOV.ObservacionesColumn]);
                }
                set
                {
                    this[this.tableNovedadesOV.ObservacionesColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class NovedadesOVRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataNovedadesOV.NovedadesOVRow eventRow;

            public NovedadesOVRowChangeEvent(DataNovedadesOV.NovedadesOVRow row, DataRowAction action)
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

            public DataNovedadesOV.NovedadesOVRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void NovedadesOVRowChangeEventHandler(object sender, DataNovedadesOV.NovedadesOVRowChangeEvent e);
    }
}

