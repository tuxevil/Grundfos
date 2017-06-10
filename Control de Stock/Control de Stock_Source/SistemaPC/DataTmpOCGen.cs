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
    public class DataTmpOCGen : DataSet
    {
        private PC1TmpOCGenDataTable tablePC1TmpOCGen;

        public DataTmpOCGen()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DataTmpOCGen(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["PC1TmpOCGen"] != null)
                {
                    this.Tables.Add(new PC1TmpOCGenDataTable(dataSet.Tables["PC1TmpOCGen"]));
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
            DataTmpOCGen gen = (DataTmpOCGen) base.Clone();
            gen.InitVars();
            return gen;
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
            this.DataSetName = "DataTmpOCGen";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DataTmpOCGen.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tablePC1TmpOCGen = new PC1TmpOCGenDataTable();
            this.Tables.Add(this.tablePC1TmpOCGen);
        }

        internal void InitVars()
        {
            this.tablePC1TmpOCGen = (PC1TmpOCGenDataTable) this.Tables["PC1TmpOCGen"];
            if (this.tablePC1TmpOCGen != null)
            {
                this.tablePC1TmpOCGen.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["PC1TmpOCGen"] != null)
            {
                this.Tables.Add(new PC1TmpOCGenDataTable(dataSet.Tables["PC1TmpOCGen"]));
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

        private bool ShouldSerializePC1TmpOCGen()
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
        public PC1TmpOCGenDataTable PC1TmpOCGen
        {
            get
            {
                return this.tablePC1TmpOCGen;
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpOCGenDataTable : DataTable, IEnumerable
        {
            private DataColumn columnCodProv;
            private DataColumn columnFecEntOC;
            private DataColumn columnNomProv;
            private DataColumn columnNroOC;

            public event DataTmpOCGen.PC1TmpOCGenRowChangeEventHandler PC1TmpOCGenRowChanged;

            public event DataTmpOCGen.PC1TmpOCGenRowChangeEventHandler PC1TmpOCGenRowChanging;

            public event DataTmpOCGen.PC1TmpOCGenRowChangeEventHandler PC1TmpOCGenRowDeleted;

            public event DataTmpOCGen.PC1TmpOCGenRowChangeEventHandler PC1TmpOCGenRowDeleting;

            internal PC1TmpOCGenDataTable() : base("PC1TmpOCGen")
            {
                this.InitClass();
            }

            internal PC1TmpOCGenDataTable(DataTable table) : base(table.TableName)
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

            public void AddPC1TmpOCGenRow(DataTmpOCGen.PC1TmpOCGenRow row)
            {
                this.Rows.Add(row);
            }

            public DataTmpOCGen.PC1TmpOCGenRow AddPC1TmpOCGenRow(string NroOC, string CodProv, string NomProv, DateTime FecEntOC)
            {
                DataTmpOCGen.PC1TmpOCGenRow row = (DataTmpOCGen.PC1TmpOCGenRow) this.NewRow();
                row.ItemArray = new object[] { NroOC, CodProv, NomProv, FecEntOC };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataTmpOCGen.PC1TmpOCGenDataTable table = (DataTmpOCGen.PC1TmpOCGenDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataTmpOCGen.PC1TmpOCGenDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataTmpOCGen.PC1TmpOCGenRow);
            }

            private void InitClass()
            {
                this.columnNroOC = new DataColumn("NroOC", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOC);
                this.columnCodProv = new DataColumn("CodProv", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodProv);
                this.columnNomProv = new DataColumn("NomProv", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNomProv);
                this.columnFecEntOC = new DataColumn("FecEntOC", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFecEntOC);
                this.columnNroOC.AllowDBNull = false;
                this.columnCodProv.AllowDBNull = false;
                this.columnNomProv.AllowDBNull = false;
                this.columnFecEntOC.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnNroOC = this.Columns["NroOC"];
                this.columnCodProv = this.Columns["CodProv"];
                this.columnNomProv = this.Columns["NomProv"];
                this.columnFecEntOC = this.Columns["FecEntOC"];
            }

            public DataTmpOCGen.PC1TmpOCGenRow NewPC1TmpOCGenRow()
            {
                return (DataTmpOCGen.PC1TmpOCGenRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataTmpOCGen.PC1TmpOCGenRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpOCGenRowChangedEvent != null) && (this.PC1TmpOCGenRowChangedEvent != null))
                {
                    this.PC1TmpOCGenRowChangedEvent(this, new DataTmpOCGen.PC1TmpOCGenRowChangeEvent((DataTmpOCGen.PC1TmpOCGenRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpOCGenRowChangingEvent != null) && (this.PC1TmpOCGenRowChangingEvent != null))
                {
                    this.PC1TmpOCGenRowChangingEvent(this, new DataTmpOCGen.PC1TmpOCGenRowChangeEvent((DataTmpOCGen.PC1TmpOCGenRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpOCGenRowDeletedEvent != null) && (this.PC1TmpOCGenRowDeletedEvent != null))
                {
                    this.PC1TmpOCGenRowDeletedEvent(this, new DataTmpOCGen.PC1TmpOCGenRowChangeEvent((DataTmpOCGen.PC1TmpOCGenRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpOCGenRowDeletingEvent != null) && (this.PC1TmpOCGenRowDeletingEvent != null))
                {
                    this.PC1TmpOCGenRowDeletingEvent(this, new DataTmpOCGen.PC1TmpOCGenRowChangeEvent((DataTmpOCGen.PC1TmpOCGenRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpOCGenRow(DataTmpOCGen.PC1TmpOCGenRow row)
            {
                this.Rows.Remove(row);
            }

            internal DataColumn CodProvColumn
            {
                get
                {
                    return this.columnCodProv;
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

            internal DataColumn FecEntOCColumn
            {
                get
                {
                    return this.columnFecEntOC;
                }
            }

            public DataTmpOCGen.PC1TmpOCGenRow this[int index]
            {
                get
                {
                    return (DataTmpOCGen.PC1TmpOCGenRow) this.Rows[index];
                }
            }

            internal DataColumn NomProvColumn
            {
                get
                {
                    return this.columnNomProv;
                }
            }

            internal DataColumn NroOCColumn
            {
                get
                {
                    return this.columnNroOC;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpOCGenRow : DataRow
        {
            private DataTmpOCGen.PC1TmpOCGenDataTable tablePC1TmpOCGen;

            internal PC1TmpOCGenRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpOCGen = (DataTmpOCGen.PC1TmpOCGenDataTable) this.Table;
            }

            public string CodProv
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCGen.CodProvColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCGen.CodProvColumn] = value;
                }
            }

            public DateTime FecEntOC
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpOCGen.FecEntOCColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCGen.FecEntOCColumn] = value;
                }
            }

            public string NomProv
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCGen.NomProvColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCGen.NomProvColumn] = value;
                }
            }

            public string NroOC
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCGen.NroOCColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCGen.NroOCColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpOCGenRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataTmpOCGen.PC1TmpOCGenRow eventRow;

            public PC1TmpOCGenRowChangeEvent(DataTmpOCGen.PC1TmpOCGenRow row, DataRowAction action)
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

            public DataTmpOCGen.PC1TmpOCGenRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpOCGenRowChangeEventHandler(object sender, DataTmpOCGen.PC1TmpOCGenRowChangeEvent e);
    }
}

