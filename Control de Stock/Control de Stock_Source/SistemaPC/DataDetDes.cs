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
    public class DataDetDes : DataSet
    {
        private DataRelation relationSC010100detdes;
        private detdesDataTable tabledetdes;
        private hdrdesDataTable tablehdrdes;
        private SC010100DataTable tableSC010100;

        public DataDetDes()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DataDetDes(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["detdes"] != null)
                {
                    this.Tables.Add(new detdesDataTable(dataSet.Tables["detdes"]));
                }
                if (dataSet.Tables["SC010100"] != null)
                {
                    this.Tables.Add(new SC010100DataTable(dataSet.Tables["SC010100"]));
                }
                if (dataSet.Tables["hdrdes"] != null)
                {
                    this.Tables.Add(new hdrdesDataTable(dataSet.Tables["hdrdes"]));
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
            DataDetDes des = (DataDetDes) base.Clone();
            des.InitVars();
            return des;
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
            this.DataSetName = "DataDetDes";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DataDetDes.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tabledetdes = new detdesDataTable();
            this.Tables.Add(this.tabledetdes);
            this.tableSC010100 = new SC010100DataTable();
            this.Tables.Add(this.tableSC010100);
            this.tablehdrdes = new hdrdesDataTable();
            this.Tables.Add(this.tablehdrdes);
            ForeignKeyConstraint constraint = new ForeignKeyConstraint("SC010100detdes", new DataColumn[] { this.tableSC010100.SC01001Column }, new DataColumn[] { this.tabledetdes.itnbrColumn });
            this.tabledetdes.Constraints.Add(constraint);
            constraint.AcceptRejectRule = AcceptRejectRule.None;
            constraint.DeleteRule = Rule.Cascade;
            constraint.UpdateRule = Rule.Cascade;
            this.relationSC010100detdes = new DataRelation("SC010100detdes", new DataColumn[] { this.tableSC010100.SC01001Column }, new DataColumn[] { this.tabledetdes.itnbrColumn }, false);
            this.Relations.Add(this.relationSC010100detdes);
        }

        internal void InitVars()
        {
            this.tabledetdes = (detdesDataTable) this.Tables["detdes"];
            if (this.tabledetdes != null)
            {
                this.tabledetdes.InitVars();
            }
            this.tableSC010100 = (SC010100DataTable) this.Tables["SC010100"];
            if (this.tableSC010100 != null)
            {
                this.tableSC010100.InitVars();
            }
            this.tablehdrdes = (hdrdesDataTable) this.Tables["hdrdes"];
            if (this.tablehdrdes != null)
            {
                this.tablehdrdes.InitVars();
            }
            this.relationSC010100detdes = this.Relations["SC010100detdes"];
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["detdes"] != null)
            {
                this.Tables.Add(new detdesDataTable(dataSet.Tables["detdes"]));
            }
            if (dataSet.Tables["SC010100"] != null)
            {
                this.Tables.Add(new SC010100DataTable(dataSet.Tables["SC010100"]));
            }
            if (dataSet.Tables["hdrdes"] != null)
            {
                this.Tables.Add(new hdrdesDataTable(dataSet.Tables["hdrdes"]));
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

        private bool ShouldSerializedetdes()
        {
            return false;
        }

        private bool ShouldSerializehdrdes()
        {
            return false;
        }

        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        private bool ShouldSerializeSC010100()
        {
            return false;
        }

        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public detdesDataTable detdes
        {
            get
            {
                return this.tabledetdes;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public hdrdesDataTable hdrdes
        {
            get
            {
                return this.tablehdrdes;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SC010100DataTable SC010100
        {
            get
            {
                return this.tableSC010100;
            }
        }

        [DebuggerStepThrough]
        public class detdesDataTable : DataTable, IEnumerable
        {
            private DataColumn columncntqty;
            private DataColumn columncolnb;
            private DataColumn columndatexp;
            private DataColumn columnexpqty;
            private DataColumn columnflagb;
            private DataColumn columnitnbr;
            private DataColumn columnlignb;
            private DataColumn columnordnb;
            private DataColumn columnpacklist;
            private DataColumn columnpurind;

            public event DataDetDes.detdesRowChangeEventHandler detdesRowChanged;

            public event DataDetDes.detdesRowChangeEventHandler detdesRowChanging;

            public event DataDetDes.detdesRowChangeEventHandler detdesRowDeleted;

            public event DataDetDes.detdesRowChangeEventHandler detdesRowDeleting;

            internal detdesDataTable() : base("detdes")
            {
                this.InitClass();
            }

            internal detdesDataTable(DataTable table) : base(table.TableName)
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

            public void AdddetdesRow(DataDetDes.detdesRow row)
            {
                this.Rows.Add(row);
            }

            public DataDetDes.detdesRow AdddetdesRow(string purind, DateTime datexp, double colnb, decimal ordnb, int lignb, DataDetDes.SC010100Row parentSC010100RowBySC010100detdes, decimal expqty, decimal cntqty, string flagb, string packlist)
            {
                DataDetDes.detdesRow row = (DataDetDes.detdesRow) this.NewRow();
                row.ItemArray = new object[] { purind, datexp, colnb, ordnb, lignb, RuntimeHelpers.GetObjectValue(parentSC010100RowBySC010100detdes[0]), expqty, cntqty, flagb, packlist };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataDetDes.detdesDataTable table = (DataDetDes.detdesDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataDetDes.detdesDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataDetDes.detdesRow);
            }

            private void InitClass()
            {
                this.columnpurind = new DataColumn("purind", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnpurind);
                this.columndatexp = new DataColumn("datexp", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columndatexp);
                this.columncolnb = new DataColumn("colnb", typeof(double), null, MappingType.Element);
                this.Columns.Add(this.columncolnb);
                this.columnordnb = new DataColumn("ordnb", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnordnb);
                this.columnlignb = new DataColumn("lignb", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnlignb);
                this.columnitnbr = new DataColumn("itnbr", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnitnbr);
                this.columnexpqty = new DataColumn("expqty", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnexpqty);
                this.columncntqty = new DataColumn("cntqty", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columncntqty);
                this.columnflagb = new DataColumn("flagb", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnflagb);
                this.columnpacklist = new DataColumn("packlist", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnpacklist);
            }

            internal void InitVars()
            {
                this.columnpurind = this.Columns["purind"];
                this.columndatexp = this.Columns["datexp"];
                this.columncolnb = this.Columns["colnb"];
                this.columnordnb = this.Columns["ordnb"];
                this.columnlignb = this.Columns["lignb"];
                this.columnitnbr = this.Columns["itnbr"];
                this.columnexpqty = this.Columns["expqty"];
                this.columncntqty = this.Columns["cntqty"];
                this.columnflagb = this.Columns["flagb"];
                this.columnpacklist = this.Columns["packlist"];
            }

            public DataDetDes.detdesRow NewdetdesRow()
            {
                return (DataDetDes.detdesRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataDetDes.detdesRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.detdesRowChangedEvent != null) && (this.detdesRowChangedEvent != null))
                {
                    this.detdesRowChangedEvent(this, new DataDetDes.detdesRowChangeEvent((DataDetDes.detdesRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.detdesRowChangingEvent != null) && (this.detdesRowChangingEvent != null))
                {
                    this.detdesRowChangingEvent(this, new DataDetDes.detdesRowChangeEvent((DataDetDes.detdesRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.detdesRowDeletedEvent != null) && (this.detdesRowDeletedEvent != null))
                {
                    this.detdesRowDeletedEvent(this, new DataDetDes.detdesRowChangeEvent((DataDetDes.detdesRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.detdesRowDeletingEvent != null) && (this.detdesRowDeletingEvent != null))
                {
                    this.detdesRowDeletingEvent(this, new DataDetDes.detdesRowChangeEvent((DataDetDes.detdesRow) e.Row, e.Action));
                }
            }

            public void RemovedetdesRow(DataDetDes.detdesRow row)
            {
                this.Rows.Remove(row);
            }

            internal DataColumn cntqtyColumn
            {
                get
                {
                    return this.columncntqty;
                }
            }

            internal DataColumn colnbColumn
            {
                get
                {
                    return this.columncolnb;
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

            internal DataColumn datexpColumn
            {
                get
                {
                    return this.columndatexp;
                }
            }

            internal DataColumn expqtyColumn
            {
                get
                {
                    return this.columnexpqty;
                }
            }

            internal DataColumn flagbColumn
            {
                get
                {
                    return this.columnflagb;
                }
            }

            public DataDetDes.detdesRow this[int index]
            {
                get
                {
                    return (DataDetDes.detdesRow) this.Rows[index];
                }
            }

            internal DataColumn itnbrColumn
            {
                get
                {
                    return this.columnitnbr;
                }
            }

            internal DataColumn lignbColumn
            {
                get
                {
                    return this.columnlignb;
                }
            }

            internal DataColumn ordnbColumn
            {
                get
                {
                    return this.columnordnb;
                }
            }

            internal DataColumn packlistColumn
            {
                get
                {
                    return this.columnpacklist;
                }
            }

            internal DataColumn purindColumn
            {
                get
                {
                    return this.columnpurind;
                }
            }
        }

        [DebuggerStepThrough]
        public class detdesRow : DataRow
        {
            private DataDetDes.detdesDataTable tabledetdes;

            internal detdesRow(DataRowBuilder rb) : base(rb)
            {
                this.tabledetdes = (DataDetDes.detdesDataTable) this.Table;
            }

            public bool IscntqtyNull()
            {
                return this.IsNull(this.tabledetdes.cntqtyColumn);
            }

            public bool IscolnbNull()
            {
                return this.IsNull(this.tabledetdes.colnbColumn);
            }

            public bool IsdatexpNull()
            {
                return this.IsNull(this.tabledetdes.datexpColumn);
            }

            public bool IsexpqtyNull()
            {
                return this.IsNull(this.tabledetdes.expqtyColumn);
            }

            public bool IsflagbNull()
            {
                return this.IsNull(this.tabledetdes.flagbColumn);
            }

            public bool IsitnbrNull()
            {
                return this.IsNull(this.tabledetdes.itnbrColumn);
            }

            public bool IslignbNull()
            {
                return this.IsNull(this.tabledetdes.lignbColumn);
            }

            public bool IsordnbNull()
            {
                return this.IsNull(this.tabledetdes.ordnbColumn);
            }

            public bool IspacklistNull()
            {
                return this.IsNull(this.tabledetdes.packlistColumn);
            }

            public bool IspurindNull()
            {
                return this.IsNull(this.tabledetdes.purindColumn);
            }

            public void SetcntqtyNull()
            {
                this[this.tabledetdes.cntqtyColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetcolnbNull()
            {
                this[this.tabledetdes.colnbColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetdatexpNull()
            {
                this[this.tabledetdes.datexpColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetexpqtyNull()
            {
                this[this.tabledetdes.expqtyColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetflagbNull()
            {
                this[this.tabledetdes.flagbColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetitnbrNull()
            {
                this[this.tabledetdes.itnbrColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetlignbNull()
            {
                this[this.tabledetdes.lignbColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetordnbNull()
            {
                this[this.tabledetdes.ordnbColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetpacklistNull()
            {
                this[this.tabledetdes.packlistColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetpurindNull()
            {
                this[this.tabledetdes.purindColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal cntqty
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tabledetdes.cntqtyColumn]);
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
                    this[this.tabledetdes.cntqtyColumn] = value;
                }
            }

            public double colnb
            {
                get
                {
                    double num;
                    try
                    {
                        num = DoubleType.FromObject(this[this.tabledetdes.colnbColumn]);
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
                    this[this.tabledetdes.colnbColumn] = value;
                }
            }

            public DateTime datexp
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = DateType.FromObject(this[this.tabledetdes.datexpColumn]);
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
                    this[this.tabledetdes.datexpColumn] = value;
                }
            }

            public decimal expqty
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tabledetdes.expqtyColumn]);
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
                    this[this.tabledetdes.expqtyColumn] = value;
                }
            }

            public string flagb
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tabledetdes.flagbColumn]);
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
                    this[this.tabledetdes.flagbColumn] = value;
                }
            }

            public string itnbr
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tabledetdes.itnbrColumn]);
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
                    this[this.tabledetdes.itnbrColumn] = value;
                }
            }

            public int lignb
            {
                get
                {
                    int num;
                    try
                    {
                        num = IntegerType.FromObject(this[this.tabledetdes.lignbColumn]);
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
                    this[this.tabledetdes.lignbColumn] = value;
                }
            }

            public decimal ordnb
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tabledetdes.ordnbColumn]);
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
                    this[this.tabledetdes.ordnbColumn] = value;
                }
            }

            public string packlist
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tabledetdes.packlistColumn]);
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
                    this[this.tabledetdes.packlistColumn] = value;
                }
            }

            public string purind
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tabledetdes.purindColumn]);
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
                    this[this.tabledetdes.purindColumn] = value;
                }
            }

            public SistemaPC.DataDetDes.SC010100Row SC010100Row
            {
                get
                {
                    return (SistemaPC.DataDetDes.SC010100Row) this.GetParentRow(this.Table.ParentRelations["SC010100detdes"]);
                }
                set
                {
                    this.SetParentRow(value, this.Table.ParentRelations["SC010100detdes"]);
                }
            }
        }

        [DebuggerStepThrough]
        public class detdesRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataDetDes.detdesRow eventRow;

            public detdesRowChangeEvent(DataDetDes.detdesRow row, DataRowAction action)
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

            public DataDetDes.detdesRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void detdesRowChangeEventHandler(object sender, DataDetDes.detdesRowChangeEvent e);

        [DebuggerStepThrough]
        public class hdrdesDataTable : DataTable, IEnumerable
        {
            private DataColumn columnactivity;
            private DataColumn columnapplic;
            private DataColumn columncompbuy;
            private DataColumn columndatexp;
            private DataColumn columnflaga;
            private DataColumn columnpacklist;
            private DataColumn columnpurind;
            private DataColumn columnrecipien;
            private DataColumn columnsender;
            private DataColumn columntrind;

            public event DataDetDes.hdrdesRowChangeEventHandler hdrdesRowChanged;

            public event DataDetDes.hdrdesRowChangeEventHandler hdrdesRowChanging;

            public event DataDetDes.hdrdesRowChangeEventHandler hdrdesRowDeleted;

            public event DataDetDes.hdrdesRowChangeEventHandler hdrdesRowDeleting;

            internal hdrdesDataTable() : base("hdrdes")
            {
                this.InitClass();
            }

            internal hdrdesDataTable(DataTable table) : base(table.TableName)
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

            public void AddhdrdesRow(DataDetDes.hdrdesRow row)
            {
                this.Rows.Add(row);
            }

            public DataDetDes.hdrdesRow AddhdrdesRow(string trind, string purind, DateTime datexp, string flaga, string packlist, string compbuy, string sender, string recipien, string applic, string activity)
            {
                DataDetDes.hdrdesRow row = (DataDetDes.hdrdesRow) this.NewRow();
                row.ItemArray = new object[] { trind, purind, datexp, flaga, packlist, compbuy, sender, recipien, applic, activity };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataDetDes.hdrdesDataTable table = (DataDetDes.hdrdesDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataDetDes.hdrdesDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataDetDes.hdrdesRow);
            }

            private void InitClass()
            {
                this.columntrind = new DataColumn("trind", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columntrind);
                this.columnpurind = new DataColumn("purind", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnpurind);
                this.columndatexp = new DataColumn("datexp", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columndatexp);
                this.columnflaga = new DataColumn("flaga", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnflaga);
                this.columnpacklist = new DataColumn("packlist", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnpacklist);
                this.columncompbuy = new DataColumn("compbuy", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columncompbuy);
                this.columnsender = new DataColumn("sender", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnsender);
                this.columnrecipien = new DataColumn("recipien", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnrecipien);
                this.columnapplic = new DataColumn("applic", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnapplic);
                this.columnactivity = new DataColumn("activity", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnactivity);
                this.Constraints.Add(new UniqueConstraint("DataDetDesKey2", new DataColumn[] { this.columndatexp, this.columnpacklist }, false));
            }

            internal void InitVars()
            {
                this.columntrind = this.Columns["trind"];
                this.columnpurind = this.Columns["purind"];
                this.columndatexp = this.Columns["datexp"];
                this.columnflaga = this.Columns["flaga"];
                this.columnpacklist = this.Columns["packlist"];
                this.columncompbuy = this.Columns["compbuy"];
                this.columnsender = this.Columns["sender"];
                this.columnrecipien = this.Columns["recipien"];
                this.columnapplic = this.Columns["applic"];
                this.columnactivity = this.Columns["activity"];
            }

            public DataDetDes.hdrdesRow NewhdrdesRow()
            {
                return (DataDetDes.hdrdesRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataDetDes.hdrdesRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.hdrdesRowChangedEvent != null) && (this.hdrdesRowChangedEvent != null))
                {
                    this.hdrdesRowChangedEvent(this, new DataDetDes.hdrdesRowChangeEvent((DataDetDes.hdrdesRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.hdrdesRowChangingEvent != null) && (this.hdrdesRowChangingEvent != null))
                {
                    this.hdrdesRowChangingEvent(this, new DataDetDes.hdrdesRowChangeEvent((DataDetDes.hdrdesRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.hdrdesRowDeletedEvent != null) && (this.hdrdesRowDeletedEvent != null))
                {
                    this.hdrdesRowDeletedEvent(this, new DataDetDes.hdrdesRowChangeEvent((DataDetDes.hdrdesRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.hdrdesRowDeletingEvent != null) && (this.hdrdesRowDeletingEvent != null))
                {
                    this.hdrdesRowDeletingEvent(this, new DataDetDes.hdrdesRowChangeEvent((DataDetDes.hdrdesRow) e.Row, e.Action));
                }
            }

            public void RemovehdrdesRow(DataDetDes.hdrdesRow row)
            {
                this.Rows.Remove(row);
            }

            internal DataColumn activityColumn
            {
                get
                {
                    return this.columnactivity;
                }
            }

            internal DataColumn applicColumn
            {
                get
                {
                    return this.columnapplic;
                }
            }

            internal DataColumn compbuyColumn
            {
                get
                {
                    return this.columncompbuy;
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

            internal DataColumn datexpColumn
            {
                get
                {
                    return this.columndatexp;
                }
            }

            internal DataColumn flagaColumn
            {
                get
                {
                    return this.columnflaga;
                }
            }

            public DataDetDes.hdrdesRow this[int index]
            {
                get
                {
                    return (DataDetDes.hdrdesRow) this.Rows[index];
                }
            }

            internal DataColumn packlistColumn
            {
                get
                {
                    return this.columnpacklist;
                }
            }

            internal DataColumn purindColumn
            {
                get
                {
                    return this.columnpurind;
                }
            }

            internal DataColumn recipienColumn
            {
                get
                {
                    return this.columnrecipien;
                }
            }

            internal DataColumn senderColumn
            {
                get
                {
                    return this.columnsender;
                }
            }

            internal DataColumn trindColumn
            {
                get
                {
                    return this.columntrind;
                }
            }
        }

        [DebuggerStepThrough]
        public class hdrdesRow : DataRow
        {
            private DataDetDes.hdrdesDataTable tablehdrdes;

            internal hdrdesRow(DataRowBuilder rb) : base(rb)
            {
                this.tablehdrdes = (DataDetDes.hdrdesDataTable) this.Table;
            }

            public bool IsactivityNull()
            {
                return this.IsNull(this.tablehdrdes.activityColumn);
            }

            public bool IsapplicNull()
            {
                return this.IsNull(this.tablehdrdes.applicColumn);
            }

            public bool IscompbuyNull()
            {
                return this.IsNull(this.tablehdrdes.compbuyColumn);
            }

            public bool IsdatexpNull()
            {
                return this.IsNull(this.tablehdrdes.datexpColumn);
            }

            public bool IsflagaNull()
            {
                return this.IsNull(this.tablehdrdes.flagaColumn);
            }

            public bool IspacklistNull()
            {
                return this.IsNull(this.tablehdrdes.packlistColumn);
            }

            public bool IspurindNull()
            {
                return this.IsNull(this.tablehdrdes.purindColumn);
            }

            public bool IsrecipienNull()
            {
                return this.IsNull(this.tablehdrdes.recipienColumn);
            }

            public bool IssenderNull()
            {
                return this.IsNull(this.tablehdrdes.senderColumn);
            }

            public bool IstrindNull()
            {
                return this.IsNull(this.tablehdrdes.trindColumn);
            }

            public void SetactivityNull()
            {
                this[this.tablehdrdes.activityColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetapplicNull()
            {
                this[this.tablehdrdes.applicColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetcompbuyNull()
            {
                this[this.tablehdrdes.compbuyColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetdatexpNull()
            {
                this[this.tablehdrdes.datexpColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetflagaNull()
            {
                this[this.tablehdrdes.flagaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetpacklistNull()
            {
                this[this.tablehdrdes.packlistColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetpurindNull()
            {
                this[this.tablehdrdes.purindColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetrecipienNull()
            {
                this[this.tablehdrdes.recipienColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetsenderNull()
            {
                this[this.tablehdrdes.senderColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SettrindNull()
            {
                this[this.tablehdrdes.trindColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string activity
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablehdrdes.activityColumn]);
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
                    this[this.tablehdrdes.activityColumn] = value;
                }
            }

            public string applic
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablehdrdes.applicColumn]);
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
                    this[this.tablehdrdes.applicColumn] = value;
                }
            }

            public string compbuy
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablehdrdes.compbuyColumn]);
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
                    this[this.tablehdrdes.compbuyColumn] = value;
                }
            }

            public DateTime datexp
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = DateType.FromObject(this[this.tablehdrdes.datexpColumn]);
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
                    this[this.tablehdrdes.datexpColumn] = value;
                }
            }

            public string flaga
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablehdrdes.flagaColumn]);
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
                    this[this.tablehdrdes.flagaColumn] = value;
                }
            }

            public string packlist
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablehdrdes.packlistColumn]);
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
                    this[this.tablehdrdes.packlistColumn] = value;
                }
            }

            public string purind
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablehdrdes.purindColumn]);
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
                    this[this.tablehdrdes.purindColumn] = value;
                }
            }

            public string recipien
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablehdrdes.recipienColumn]);
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
                    this[this.tablehdrdes.recipienColumn] = value;
                }
            }

            public string sender
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablehdrdes.senderColumn]);
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
                    this[this.tablehdrdes.senderColumn] = value;
                }
            }

            public string trind
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablehdrdes.trindColumn]);
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
                    this[this.tablehdrdes.trindColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class hdrdesRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataDetDes.hdrdesRow eventRow;

            public hdrdesRowChangeEvent(DataDetDes.hdrdesRow row, DataRowAction action)
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

            public DataDetDes.hdrdesRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void hdrdesRowChangeEventHandler(object sender, DataDetDes.hdrdesRowChangeEvent e);

        [DebuggerStepThrough]
        public class SC010100DataTable : DataTable, IEnumerable
        {
            private DataColumn columnSC01001;
            private DataColumn columnSC01002;
            private DataColumn columnSC01003;
            private DataColumn columnSC01004;
            private DataColumn columnSC01005;
            private DataColumn columnSC01006;
            private DataColumn columnSC01007;
            private DataColumn columnSC01008;
            private DataColumn columnSC01009;
            private DataColumn columnSC01010;
            private DataColumn columnSC01011;
            private DataColumn columnSC01012;
            private DataColumn columnSC01013;
            private DataColumn columnSC01014;
            private DataColumn columnSC01015;
            private DataColumn columnSC01016;
            private DataColumn columnSC01017;
            private DataColumn columnSC01018;
            private DataColumn columnSC01019;
            private DataColumn columnSC01020;
            private DataColumn columnSC01021;
            private DataColumn columnSC01022;
            private DataColumn columnSC01023;
            private DataColumn columnSC01024;
            private DataColumn columnSC01025;
            private DataColumn columnSC01026;
            private DataColumn columnSC01027;
            private DataColumn columnSC01028;
            private DataColumn columnSC01029;
            private DataColumn columnSC01030;
            private DataColumn columnSC01031;
            private DataColumn columnSC01032;
            private DataColumn columnSC01033;
            private DataColumn columnSC01034;
            private DataColumn columnSC01035;
            private DataColumn columnSC01036;
            private DataColumn columnSC01037;
            private DataColumn columnSC01038;
            private DataColumn columnSC01039;
            private DataColumn columnSC01040;
            private DataColumn columnSC01041;
            private DataColumn columnSC01042;
            private DataColumn columnSC01043;
            private DataColumn columnSC01044;
            private DataColumn columnSC01045;
            private DataColumn columnSC01046;
            private DataColumn columnSC01047;
            private DataColumn columnSC01048;
            private DataColumn columnSC01049;
            private DataColumn columnSC01050;
            private DataColumn columnSC01051;
            private DataColumn columnSC01052;
            private DataColumn columnSC01053;
            private DataColumn columnSC01054;
            private DataColumn columnSC01055;
            private DataColumn columnSC01056;
            private DataColumn columnSC01057;
            private DataColumn columnSC01058;
            private DataColumn columnSC01059;
            private DataColumn columnSC01060;
            private DataColumn columnSC01061;
            private DataColumn columnSC01062;
            private DataColumn columnSC01063;
            private DataColumn columnSC01064;
            private DataColumn columnSC01065;
            private DataColumn columnSC01066;
            private DataColumn columnSC01067;
            private DataColumn columnSC01068;
            private DataColumn columnSC01069;
            private DataColumn columnSC01070;
            private DataColumn columnSC01071;
            private DataColumn columnSC01072;
            private DataColumn columnSC01073;
            private DataColumn columnSC01074;
            private DataColumn columnSC01075;
            private DataColumn columnSC01076;
            private DataColumn columnSC01077;
            private DataColumn columnSC01078;
            private DataColumn columnSC01079;
            private DataColumn columnSC01080;
            private DataColumn columnSC01081;
            private DataColumn columnSC01082;
            private DataColumn columnSC01083;
            private DataColumn columnSC01084;
            private DataColumn columnSC01085;
            private DataColumn columnSC01086;
            private DataColumn columnSC01087;
            private DataColumn columnSC01088;
            private DataColumn columnSC01089;
            private DataColumn columnSC01090;
            private DataColumn columnSC01091;
            private DataColumn columnSC01092;
            private DataColumn columnSC01093;
            private DataColumn columnSC01094;
            private DataColumn columnSC01095;
            private DataColumn columnSC01096;
            private DataColumn columnSC01097;
            private DataColumn columnSC01098;
            private DataColumn columnSC01099;
            private DataColumn columnSC01100;
            private DataColumn columnSC01101;
            private DataColumn columnSC01102;
            private DataColumn columnSC01103;
            private DataColumn columnSC01104;
            private DataColumn columnSC01105;
            private DataColumn columnSC01106;
            private DataColumn columnSC01107;
            private DataColumn columnSC01108;
            private DataColumn columnSC01109;
            private DataColumn columnSC01110;
            private DataColumn columnSC01111;
            private DataColumn columnSC01112;
            private DataColumn columnSC01113;
            private DataColumn columnSC01114;
            private DataColumn columnSC01115;
            private DataColumn columnSC01116;
            private DataColumn columnSC01117;
            private DataColumn columnSC01118;
            private DataColumn columnSC01119;
            private DataColumn columnSC01120;
            private DataColumn columnSC01121;
            private DataColumn columnSC01122;
            private DataColumn columnSC01123;
            private DataColumn columnSC01124;
            private DataColumn columnSC01125;
            private DataColumn columnSC01126;
            private DataColumn columnSC01127;
            private DataColumn columnSC01128;
            private DataColumn columnSC01129;
            private DataColumn columnSC01130;
            private DataColumn columnSC01131;
            private DataColumn columnSC01132;
            private DataColumn columnSC01133;
            private DataColumn columnSC01134;
            private DataColumn columnSC01135;
            private DataColumn columnSC01136;
            private DataColumn columnSC01137;
            private DataColumn columnSC01138;
            private DataColumn columnSC01139;
            private DataColumn columnSC01140;
            private DataColumn columnSC01141;
            private DataColumn columnSC01142;
            private DataColumn columnSC01143;
            private DataColumn columnSC01144;
            private DataColumn columnSC01145;
            private DataColumn columnSC01146;
            private DataColumn columnSC01147;
            private DataColumn columnSC01148;
            private DataColumn columnSC01149;
            private DataColumn columnSC01150;
            private DataColumn columnSC01151;
            private DataColumn columnSC01152;
            private DataColumn columnSC01153;
            private DataColumn columnSC01154;
            private DataColumn columnSC01155;
            private DataColumn columnSC01156;
            private DataColumn columnSC01157;
            private DataColumn columnSC01158;
            private DataColumn columnSC01159;
            private DataColumn columnSC01160;
            private DataColumn columnSC01161;
            private DataColumn columnSC01162;
            private DataColumn columnSC01163;
            private DataColumn columnSC01164;
            private DataColumn columnSC01165;
            private DataColumn columnSC01166;
            private DataColumn columnSC01167;
            private DataColumn columnSC01168;
            private DataColumn columnSC01169;
            private DataColumn columnSC01170;
            private DataColumn columnSC01171;
            private DataColumn columnSC01172;
            private DataColumn columnSC01173;
            private DataColumn columnSC01174;
            private DataColumn columnSC01175;
            private DataColumn columnSC01176;
            private DataColumn columnSC01177;
            private DataColumn columnSC01178;
            private DataColumn columnSC01179;
            private DataColumn columnSC01180;
            private DataColumn columnSC01181;
            private DataColumn columnSC01182;
            private DataColumn columnSC01183;
            private DataColumn columnSC01184;
            private DataColumn columnSC01185;
            private DataColumn columnSC01186;
            private DataColumn columnSC01187;
            private DataColumn columnSC01188;

            public event DataDetDes.SC010100RowChangeEventHandler SC010100RowChanged;

            public event DataDetDes.SC010100RowChangeEventHandler SC010100RowChanging;

            public event DataDetDes.SC010100RowChangeEventHandler SC010100RowDeleted;

            public event DataDetDes.SC010100RowChangeEventHandler SC010100RowDeleting;

            internal SC010100DataTable() : base("SC010100")
            {
                this.InitClass();
            }

            internal SC010100DataTable(DataTable table) : base(table.TableName)
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

            public void AddSC010100Row(DataDetDes.SC010100Row row)
            {
                this.Rows.Add(row);
            }

            public DataDetDes.SC010100Row AddSC010100Row(string SC01001, string SC01002, string SC01003, decimal SC01004, decimal SC01005, DateTime SC01006, decimal SC01007, decimal SC01008, decimal SC01009, string SC01010, string SC01011, string SC01012, string SC01013, string SC01014, string SC01015, string SC01016, string SC01017, string SC01018, string SC01019, string SC01020, int SC01021, string SC01022, string SC01023, string SC01024, string SC01025, string SC01026, string SC01027, string SC01028, string SC01029, string SC01030, int SC01031, string SC01032, int SC01033, int SC01034, string SC01035, string SC01036, string SC01037, string SC01038, string SC01039, decimal SC01040, decimal SC01041, decimal SC01042, decimal SC01043, decimal SC01044, decimal SC01045, decimal SC01046, string SC01047, DateTime SC01048, DateTime SC01049, DateTime SC01050, DateTime SC01051, decimal SC01052, decimal SC01053, decimal SC01054, decimal SC01055, string SC01056, decimal SC01057, string SC01058, string SC01059, string SC01060, decimal SC01061, int SC01062, decimal SC01063, decimal SC01064, int SC01065, int SC01066, string SC01067, int SC01068, decimal SC01069, decimal SC01070, decimal SC01071, decimal SC01072, decimal SC01073, string SC01074, string SC01075, string SC01076, decimal SC01077, decimal SC01078, decimal SC01079, decimal SC01080, decimal SC01081, decimal SC01082, decimal SC01083, decimal SC01084, decimal SC01085, decimal SC01086, decimal SC01087, decimal SC01088, string SC01089, int SC01090, int SC01091, DateTime SC01092, string SC01093, string SC01094, int SC01095, int SC01096, int SC01097, decimal SC01098, decimal SC01099, string SC01100, int SC01101, string SC01102, string SC01103, int SC01104, int SC01105, decimal SC01106, string SC01107, decimal SC01108, decimal SC01109, decimal SC01110, decimal SC01111, decimal SC01112, decimal SC01113, string SC01114, string SC01115, DateTime SC01116, string SC01117, DateTime SC01118, DateTime SC01119, string SC01120, DateTime SC01121, DateTime SC01122, DateTime SC01123, DateTime SC01124, DateTime SC01125, string SC01126, int SC01127, string SC01128, int SC01129, string SC01130, string SC01131, string SC01132, int SC01133, int SC01134, int SC01135, int SC01136, int SC01137, string SC01138, decimal SC01139, decimal SC01140, decimal SC01141, decimal SC01142, decimal SC01143, int SC01144, int SC01145, decimal SC01146, string SC01147, decimal SC01148, decimal SC01149, string SC01150, int SC01151, string SC01152, decimal SC01153, decimal SC01154, decimal SC01155, string SC01156, decimal SC01157, decimal SC01158, decimal SC01159, string SC01160, string SC01161, string SC01162, string SC01163, string SC01164, string SC01165, string SC01166, string SC01167, string SC01168, string SC01169, string SC01170, string SC01171, string SC01172, string SC01173, string SC01174, string SC01175, string SC01176, string SC01177, string SC01178, string SC01179, string SC01180, decimal SC01181, decimal SC01182, string SC01183, string SC01184, string SC01185, string SC01186, string SC01187, string SC01188)
            {
                DataDetDes.SC010100Row row = (DataDetDes.SC010100Row) this.NewRow();
                row.ItemArray = new object[] { 
                    SC01001, SC01002, SC01003, SC01004, SC01005, SC01006, SC01007, SC01008, SC01009, SC01010, SC01011, SC01012, SC01013, SC01014, SC01015, SC01016, 
                    SC01017, SC01018, SC01019, SC01020, SC01021, SC01022, SC01023, SC01024, SC01025, SC01026, SC01027, SC01028, SC01029, SC01030, SC01031, SC01032, 
                    SC01033, SC01034, SC01035, SC01036, SC01037, SC01038, SC01039, SC01040, SC01041, SC01042, SC01043, SC01044, SC01045, SC01046, SC01047, SC01048, 
                    SC01049, SC01050, SC01051, SC01052, SC01053, SC01054, SC01055, SC01056, SC01057, SC01058, SC01059, SC01060, SC01061, SC01062, SC01063, SC01064, 
                    SC01065, SC01066, SC01067, SC01068, SC01069, SC01070, SC01071, SC01072, SC01073, SC01074, SC01075, SC01076, SC01077, SC01078, SC01079, SC01080, 
                    SC01081, SC01082, SC01083, SC01084, SC01085, SC01086, SC01087, SC01088, SC01089, SC01090, SC01091, SC01092, SC01093, SC01094, SC01095, SC01096, 
                    SC01097, SC01098, SC01099, SC01100, SC01101, SC01102, SC01103, SC01104, SC01105, SC01106, SC01107, SC01108, SC01109, SC01110, SC01111, SC01112, 
                    SC01113, SC01114, SC01115, SC01116, SC01117, SC01118, SC01119, SC01120, SC01121, SC01122, SC01123, SC01124, SC01125, SC01126, SC01127, SC01128, 
                    SC01129, SC01130, SC01131, SC01132, SC01133, SC01134, SC01135, SC01136, SC01137, SC01138, SC01139, SC01140, SC01141, SC01142, SC01143, SC01144, 
                    SC01145, SC01146, SC01147, SC01148, SC01149, SC01150, SC01151, SC01152, SC01153, SC01154, SC01155, SC01156, SC01157, SC01158, SC01159, SC01160, 
                    SC01161, SC01162, SC01163, SC01164, SC01165, SC01166, SC01167, SC01168, SC01169, SC01170, SC01171, SC01172, SC01173, SC01174, SC01175, SC01176, 
                    SC01177, SC01178, SC01179, SC01180, SC01181, SC01182, SC01183, SC01184, SC01185, SC01186, SC01187, SC01188
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataDetDes.SC010100DataTable table = (DataDetDes.SC010100DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataDetDes.SC010100DataTable();
            }

            public DataDetDes.SC010100Row FindBySC01001(string SC01001)
            {
                return (DataDetDes.SC010100Row) this.Rows.Find(new object[] { SC01001 });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataDetDes.SC010100Row);
            }

            private void InitClass()
            {
                this.columnSC01001 = new DataColumn("SC01001", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01001);
                this.columnSC01002 = new DataColumn("SC01002", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01002);
                this.columnSC01003 = new DataColumn("SC01003", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01003);
                this.columnSC01004 = new DataColumn("SC01004", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01004);
                this.columnSC01005 = new DataColumn("SC01005", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01005);
                this.columnSC01006 = new DataColumn("SC01006", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnSC01006);
                this.columnSC01007 = new DataColumn("SC01007", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01007);
                this.columnSC01008 = new DataColumn("SC01008", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01008);
                this.columnSC01009 = new DataColumn("SC01009", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01009);
                this.columnSC01010 = new DataColumn("SC01010", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01010);
                this.columnSC01011 = new DataColumn("SC01011", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01011);
                this.columnSC01012 = new DataColumn("SC01012", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01012);
                this.columnSC01013 = new DataColumn("SC01013", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01013);
                this.columnSC01014 = new DataColumn("SC01014", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01014);
                this.columnSC01015 = new DataColumn("SC01015", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01015);
                this.columnSC01016 = new DataColumn("SC01016", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01016);
                this.columnSC01017 = new DataColumn("SC01017", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01017);
                this.columnSC01018 = new DataColumn("SC01018", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01018);
                this.columnSC01019 = new DataColumn("SC01019", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01019);
                this.columnSC01020 = new DataColumn("SC01020", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01020);
                this.columnSC01021 = new DataColumn("SC01021", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01021);
                this.columnSC01022 = new DataColumn("SC01022", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01022);
                this.columnSC01023 = new DataColumn("SC01023", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01023);
                this.columnSC01024 = new DataColumn("SC01024", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01024);
                this.columnSC01025 = new DataColumn("SC01025", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01025);
                this.columnSC01026 = new DataColumn("SC01026", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01026);
                this.columnSC01027 = new DataColumn("SC01027", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01027);
                this.columnSC01028 = new DataColumn("SC01028", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01028);
                this.columnSC01029 = new DataColumn("SC01029", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01029);
                this.columnSC01030 = new DataColumn("SC01030", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01030);
                this.columnSC01031 = new DataColumn("SC01031", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01031);
                this.columnSC01032 = new DataColumn("SC01032", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01032);
                this.columnSC01033 = new DataColumn("SC01033", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01033);
                this.columnSC01034 = new DataColumn("SC01034", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01034);
                this.columnSC01035 = new DataColumn("SC01035", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01035);
                this.columnSC01036 = new DataColumn("SC01036", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01036);
                this.columnSC01037 = new DataColumn("SC01037", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01037);
                this.columnSC01038 = new DataColumn("SC01038", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01038);
                this.columnSC01039 = new DataColumn("SC01039", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01039);
                this.columnSC01040 = new DataColumn("SC01040", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01040);
                this.columnSC01041 = new DataColumn("SC01041", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01041);
                this.columnSC01042 = new DataColumn("SC01042", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01042);
                this.columnSC01043 = new DataColumn("SC01043", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01043);
                this.columnSC01044 = new DataColumn("SC01044", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01044);
                this.columnSC01045 = new DataColumn("SC01045", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01045);
                this.columnSC01046 = new DataColumn("SC01046", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01046);
                this.columnSC01047 = new DataColumn("SC01047", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01047);
                this.columnSC01048 = new DataColumn("SC01048", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnSC01048);
                this.columnSC01049 = new DataColumn("SC01049", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnSC01049);
                this.columnSC01050 = new DataColumn("SC01050", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnSC01050);
                this.columnSC01051 = new DataColumn("SC01051", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnSC01051);
                this.columnSC01052 = new DataColumn("SC01052", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01052);
                this.columnSC01053 = new DataColumn("SC01053", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01053);
                this.columnSC01054 = new DataColumn("SC01054", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01054);
                this.columnSC01055 = new DataColumn("SC01055", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01055);
                this.columnSC01056 = new DataColumn("SC01056", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01056);
                this.columnSC01057 = new DataColumn("SC01057", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01057);
                this.columnSC01058 = new DataColumn("SC01058", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01058);
                this.columnSC01059 = new DataColumn("SC01059", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01059);
                this.columnSC01060 = new DataColumn("SC01060", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01060);
                this.columnSC01061 = new DataColumn("SC01061", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01061);
                this.columnSC01062 = new DataColumn("SC01062", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01062);
                this.columnSC01063 = new DataColumn("SC01063", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01063);
                this.columnSC01064 = new DataColumn("SC01064", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01064);
                this.columnSC01065 = new DataColumn("SC01065", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01065);
                this.columnSC01066 = new DataColumn("SC01066", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01066);
                this.columnSC01067 = new DataColumn("SC01067", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01067);
                this.columnSC01068 = new DataColumn("SC01068", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01068);
                this.columnSC01069 = new DataColumn("SC01069", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01069);
                this.columnSC01070 = new DataColumn("SC01070", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01070);
                this.columnSC01071 = new DataColumn("SC01071", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01071);
                this.columnSC01072 = new DataColumn("SC01072", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01072);
                this.columnSC01073 = new DataColumn("SC01073", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01073);
                this.columnSC01074 = new DataColumn("SC01074", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01074);
                this.columnSC01075 = new DataColumn("SC01075", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01075);
                this.columnSC01076 = new DataColumn("SC01076", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01076);
                this.columnSC01077 = new DataColumn("SC01077", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01077);
                this.columnSC01078 = new DataColumn("SC01078", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01078);
                this.columnSC01079 = new DataColumn("SC01079", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01079);
                this.columnSC01080 = new DataColumn("SC01080", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01080);
                this.columnSC01081 = new DataColumn("SC01081", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01081);
                this.columnSC01082 = new DataColumn("SC01082", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01082);
                this.columnSC01083 = new DataColumn("SC01083", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01083);
                this.columnSC01084 = new DataColumn("SC01084", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01084);
                this.columnSC01085 = new DataColumn("SC01085", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01085);
                this.columnSC01086 = new DataColumn("SC01086", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01086);
                this.columnSC01087 = new DataColumn("SC01087", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01087);
                this.columnSC01088 = new DataColumn("SC01088", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01088);
                this.columnSC01089 = new DataColumn("SC01089", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01089);
                this.columnSC01090 = new DataColumn("SC01090", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01090);
                this.columnSC01091 = new DataColumn("SC01091", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01091);
                this.columnSC01092 = new DataColumn("SC01092", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnSC01092);
                this.columnSC01093 = new DataColumn("SC01093", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01093);
                this.columnSC01094 = new DataColumn("SC01094", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01094);
                this.columnSC01095 = new DataColumn("SC01095", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01095);
                this.columnSC01096 = new DataColumn("SC01096", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01096);
                this.columnSC01097 = new DataColumn("SC01097", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01097);
                this.columnSC01098 = new DataColumn("SC01098", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01098);
                this.columnSC01099 = new DataColumn("SC01099", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01099);
                this.columnSC01100 = new DataColumn("SC01100", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01100);
                this.columnSC01101 = new DataColumn("SC01101", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01101);
                this.columnSC01102 = new DataColumn("SC01102", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01102);
                this.columnSC01103 = new DataColumn("SC01103", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01103);
                this.columnSC01104 = new DataColumn("SC01104", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01104);
                this.columnSC01105 = new DataColumn("SC01105", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01105);
                this.columnSC01106 = new DataColumn("SC01106", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01106);
                this.columnSC01107 = new DataColumn("SC01107", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01107);
                this.columnSC01108 = new DataColumn("SC01108", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01108);
                this.columnSC01109 = new DataColumn("SC01109", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01109);
                this.columnSC01110 = new DataColumn("SC01110", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01110);
                this.columnSC01111 = new DataColumn("SC01111", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01111);
                this.columnSC01112 = new DataColumn("SC01112", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01112);
                this.columnSC01113 = new DataColumn("SC01113", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01113);
                this.columnSC01114 = new DataColumn("SC01114", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01114);
                this.columnSC01115 = new DataColumn("SC01115", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01115);
                this.columnSC01116 = new DataColumn("SC01116", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnSC01116);
                this.columnSC01117 = new DataColumn("SC01117", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01117);
                this.columnSC01118 = new DataColumn("SC01118", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnSC01118);
                this.columnSC01119 = new DataColumn("SC01119", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnSC01119);
                this.columnSC01120 = new DataColumn("SC01120", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01120);
                this.columnSC01121 = new DataColumn("SC01121", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnSC01121);
                this.columnSC01122 = new DataColumn("SC01122", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnSC01122);
                this.columnSC01123 = new DataColumn("SC01123", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnSC01123);
                this.columnSC01124 = new DataColumn("SC01124", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnSC01124);
                this.columnSC01125 = new DataColumn("SC01125", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnSC01125);
                this.columnSC01126 = new DataColumn("SC01126", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01126);
                this.columnSC01127 = new DataColumn("SC01127", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01127);
                this.columnSC01128 = new DataColumn("SC01128", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01128);
                this.columnSC01129 = new DataColumn("SC01129", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01129);
                this.columnSC01130 = new DataColumn("SC01130", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01130);
                this.columnSC01131 = new DataColumn("SC01131", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01131);
                this.columnSC01132 = new DataColumn("SC01132", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01132);
                this.columnSC01133 = new DataColumn("SC01133", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01133);
                this.columnSC01134 = new DataColumn("SC01134", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01134);
                this.columnSC01135 = new DataColumn("SC01135", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01135);
                this.columnSC01136 = new DataColumn("SC01136", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01136);
                this.columnSC01137 = new DataColumn("SC01137", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01137);
                this.columnSC01138 = new DataColumn("SC01138", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01138);
                this.columnSC01139 = new DataColumn("SC01139", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01139);
                this.columnSC01140 = new DataColumn("SC01140", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01140);
                this.columnSC01141 = new DataColumn("SC01141", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01141);
                this.columnSC01142 = new DataColumn("SC01142", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01142);
                this.columnSC01143 = new DataColumn("SC01143", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01143);
                this.columnSC01144 = new DataColumn("SC01144", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01144);
                this.columnSC01145 = new DataColumn("SC01145", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01145);
                this.columnSC01146 = new DataColumn("SC01146", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01146);
                this.columnSC01147 = new DataColumn("SC01147", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01147);
                this.columnSC01148 = new DataColumn("SC01148", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01148);
                this.columnSC01149 = new DataColumn("SC01149", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01149);
                this.columnSC01150 = new DataColumn("SC01150", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01150);
                this.columnSC01151 = new DataColumn("SC01151", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnSC01151);
                this.columnSC01152 = new DataColumn("SC01152", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01152);
                this.columnSC01153 = new DataColumn("SC01153", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01153);
                this.columnSC01154 = new DataColumn("SC01154", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01154);
                this.columnSC01155 = new DataColumn("SC01155", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01155);
                this.columnSC01156 = new DataColumn("SC01156", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01156);
                this.columnSC01157 = new DataColumn("SC01157", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01157);
                this.columnSC01158 = new DataColumn("SC01158", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01158);
                this.columnSC01159 = new DataColumn("SC01159", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01159);
                this.columnSC01160 = new DataColumn("SC01160", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01160);
                this.columnSC01161 = new DataColumn("SC01161", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01161);
                this.columnSC01162 = new DataColumn("SC01162", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01162);
                this.columnSC01163 = new DataColumn("SC01163", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01163);
                this.columnSC01164 = new DataColumn("SC01164", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01164);
                this.columnSC01165 = new DataColumn("SC01165", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01165);
                this.columnSC01166 = new DataColumn("SC01166", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01166);
                this.columnSC01167 = new DataColumn("SC01167", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01167);
                this.columnSC01168 = new DataColumn("SC01168", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01168);
                this.columnSC01169 = new DataColumn("SC01169", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01169);
                this.columnSC01170 = new DataColumn("SC01170", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01170);
                this.columnSC01171 = new DataColumn("SC01171", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01171);
                this.columnSC01172 = new DataColumn("SC01172", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01172);
                this.columnSC01173 = new DataColumn("SC01173", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01173);
                this.columnSC01174 = new DataColumn("SC01174", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01174);
                this.columnSC01175 = new DataColumn("SC01175", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01175);
                this.columnSC01176 = new DataColumn("SC01176", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01176);
                this.columnSC01177 = new DataColumn("SC01177", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01177);
                this.columnSC01178 = new DataColumn("SC01178", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01178);
                this.columnSC01179 = new DataColumn("SC01179", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01179);
                this.columnSC01180 = new DataColumn("SC01180", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01180);
                this.columnSC01181 = new DataColumn("SC01181", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01181);
                this.columnSC01182 = new DataColumn("SC01182", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC01182);
                this.columnSC01183 = new DataColumn("SC01183", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01183);
                this.columnSC01184 = new DataColumn("SC01184", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01184);
                this.columnSC01185 = new DataColumn("SC01185", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01185);
                this.columnSC01186 = new DataColumn("SC01186", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01186);
                this.columnSC01187 = new DataColumn("SC01187", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01187);
                this.columnSC01188 = new DataColumn("SC01188", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC01188);
                this.Constraints.Add(new UniqueConstraint("DataDetDesKey1", new DataColumn[] { this.columnSC01001 }, true));
                this.columnSC01001.AllowDBNull = false;
                this.columnSC01001.Unique = true;
                this.columnSC01002.AllowDBNull = false;
                this.columnSC01003.AllowDBNull = false;
                this.columnSC01004.AllowDBNull = false;
                this.columnSC01005.AllowDBNull = false;
                this.columnSC01006.AllowDBNull = false;
                this.columnSC01007.AllowDBNull = false;
                this.columnSC01008.AllowDBNull = false;
                this.columnSC01009.AllowDBNull = false;
                this.columnSC01010.AllowDBNull = false;
                this.columnSC01011.AllowDBNull = false;
                this.columnSC01012.AllowDBNull = false;
                this.columnSC01013.AllowDBNull = false;
                this.columnSC01014.AllowDBNull = false;
                this.columnSC01015.AllowDBNull = false;
                this.columnSC01016.AllowDBNull = false;
                this.columnSC01017.AllowDBNull = false;
                this.columnSC01018.AllowDBNull = false;
                this.columnSC01019.AllowDBNull = false;
                this.columnSC01020.AllowDBNull = false;
                this.columnSC01021.AllowDBNull = false;
                this.columnSC01022.AllowDBNull = false;
                this.columnSC01023.AllowDBNull = false;
                this.columnSC01024.AllowDBNull = false;
                this.columnSC01025.AllowDBNull = false;
                this.columnSC01026.AllowDBNull = false;
                this.columnSC01027.AllowDBNull = false;
                this.columnSC01028.AllowDBNull = false;
                this.columnSC01029.AllowDBNull = false;
                this.columnSC01030.AllowDBNull = false;
                this.columnSC01031.AllowDBNull = false;
                this.columnSC01032.AllowDBNull = false;
                this.columnSC01033.AllowDBNull = false;
                this.columnSC01034.AllowDBNull = false;
                this.columnSC01035.AllowDBNull = false;
                this.columnSC01036.AllowDBNull = false;
                this.columnSC01037.AllowDBNull = false;
                this.columnSC01038.AllowDBNull = false;
                this.columnSC01039.AllowDBNull = false;
                this.columnSC01040.AllowDBNull = false;
                this.columnSC01041.AllowDBNull = false;
                this.columnSC01042.AllowDBNull = false;
                this.columnSC01043.AllowDBNull = false;
                this.columnSC01044.AllowDBNull = false;
                this.columnSC01045.AllowDBNull = false;
                this.columnSC01046.AllowDBNull = false;
                this.columnSC01047.AllowDBNull = false;
                this.columnSC01048.AllowDBNull = false;
                this.columnSC01049.AllowDBNull = false;
                this.columnSC01050.AllowDBNull = false;
                this.columnSC01051.AllowDBNull = false;
                this.columnSC01052.AllowDBNull = false;
                this.columnSC01053.AllowDBNull = false;
                this.columnSC01054.AllowDBNull = false;
                this.columnSC01055.AllowDBNull = false;
                this.columnSC01056.AllowDBNull = false;
                this.columnSC01057.AllowDBNull = false;
                this.columnSC01058.AllowDBNull = false;
                this.columnSC01059.AllowDBNull = false;
                this.columnSC01060.AllowDBNull = false;
                this.columnSC01061.AllowDBNull = false;
                this.columnSC01062.AllowDBNull = false;
                this.columnSC01063.AllowDBNull = false;
                this.columnSC01064.AllowDBNull = false;
                this.columnSC01065.AllowDBNull = false;
                this.columnSC01066.AllowDBNull = false;
                this.columnSC01067.AllowDBNull = false;
                this.columnSC01068.AllowDBNull = false;
                this.columnSC01069.AllowDBNull = false;
                this.columnSC01070.AllowDBNull = false;
                this.columnSC01071.AllowDBNull = false;
                this.columnSC01072.AllowDBNull = false;
                this.columnSC01073.AllowDBNull = false;
                this.columnSC01074.AllowDBNull = false;
                this.columnSC01075.AllowDBNull = false;
                this.columnSC01076.AllowDBNull = false;
                this.columnSC01077.AllowDBNull = false;
                this.columnSC01078.AllowDBNull = false;
                this.columnSC01079.AllowDBNull = false;
                this.columnSC01080.AllowDBNull = false;
                this.columnSC01081.AllowDBNull = false;
                this.columnSC01082.AllowDBNull = false;
                this.columnSC01083.AllowDBNull = false;
                this.columnSC01084.AllowDBNull = false;
                this.columnSC01085.AllowDBNull = false;
                this.columnSC01086.AllowDBNull = false;
                this.columnSC01087.AllowDBNull = false;
                this.columnSC01088.AllowDBNull = false;
                this.columnSC01089.AllowDBNull = false;
                this.columnSC01090.AllowDBNull = false;
                this.columnSC01091.AllowDBNull = false;
                this.columnSC01092.AllowDBNull = false;
                this.columnSC01093.AllowDBNull = false;
                this.columnSC01094.AllowDBNull = false;
                this.columnSC01095.AllowDBNull = false;
                this.columnSC01096.AllowDBNull = false;
                this.columnSC01097.AllowDBNull = false;
                this.columnSC01098.AllowDBNull = false;
                this.columnSC01099.AllowDBNull = false;
                this.columnSC01100.AllowDBNull = false;
                this.columnSC01101.AllowDBNull = false;
                this.columnSC01102.AllowDBNull = false;
                this.columnSC01103.AllowDBNull = false;
                this.columnSC01104.AllowDBNull = false;
                this.columnSC01105.AllowDBNull = false;
                this.columnSC01106.AllowDBNull = false;
                this.columnSC01107.AllowDBNull = false;
                this.columnSC01108.AllowDBNull = false;
                this.columnSC01109.AllowDBNull = false;
                this.columnSC01110.AllowDBNull = false;
                this.columnSC01111.AllowDBNull = false;
                this.columnSC01112.AllowDBNull = false;
                this.columnSC01113.AllowDBNull = false;
                this.columnSC01114.AllowDBNull = false;
                this.columnSC01115.AllowDBNull = false;
                this.columnSC01116.AllowDBNull = false;
                this.columnSC01117.AllowDBNull = false;
                this.columnSC01118.AllowDBNull = false;
                this.columnSC01119.AllowDBNull = false;
                this.columnSC01120.AllowDBNull = false;
                this.columnSC01121.AllowDBNull = false;
                this.columnSC01122.AllowDBNull = false;
                this.columnSC01123.AllowDBNull = false;
                this.columnSC01124.AllowDBNull = false;
                this.columnSC01125.AllowDBNull = false;
                this.columnSC01126.AllowDBNull = false;
                this.columnSC01127.AllowDBNull = false;
                this.columnSC01128.AllowDBNull = false;
                this.columnSC01129.AllowDBNull = false;
                this.columnSC01130.AllowDBNull = false;
                this.columnSC01131.AllowDBNull = false;
                this.columnSC01132.AllowDBNull = false;
                this.columnSC01133.AllowDBNull = false;
                this.columnSC01134.AllowDBNull = false;
                this.columnSC01135.AllowDBNull = false;
                this.columnSC01136.AllowDBNull = false;
                this.columnSC01137.AllowDBNull = false;
                this.columnSC01138.AllowDBNull = false;
                this.columnSC01139.AllowDBNull = false;
                this.columnSC01140.AllowDBNull = false;
                this.columnSC01141.AllowDBNull = false;
                this.columnSC01142.AllowDBNull = false;
                this.columnSC01143.AllowDBNull = false;
                this.columnSC01144.AllowDBNull = false;
                this.columnSC01145.AllowDBNull = false;
                this.columnSC01146.AllowDBNull = false;
                this.columnSC01147.AllowDBNull = false;
                this.columnSC01148.AllowDBNull = false;
                this.columnSC01149.AllowDBNull = false;
                this.columnSC01150.AllowDBNull = false;
                this.columnSC01151.AllowDBNull = false;
                this.columnSC01152.AllowDBNull = false;
                this.columnSC01153.AllowDBNull = false;
                this.columnSC01154.AllowDBNull = false;
                this.columnSC01155.AllowDBNull = false;
                this.columnSC01156.AllowDBNull = false;
                this.columnSC01157.AllowDBNull = false;
                this.columnSC01158.AllowDBNull = false;
                this.columnSC01159.AllowDBNull = false;
                this.columnSC01160.AllowDBNull = false;
                this.columnSC01161.AllowDBNull = false;
                this.columnSC01162.AllowDBNull = false;
                this.columnSC01163.AllowDBNull = false;
                this.columnSC01164.AllowDBNull = false;
                this.columnSC01165.AllowDBNull = false;
                this.columnSC01166.AllowDBNull = false;
                this.columnSC01167.AllowDBNull = false;
                this.columnSC01168.AllowDBNull = false;
                this.columnSC01169.AllowDBNull = false;
                this.columnSC01170.AllowDBNull = false;
                this.columnSC01171.AllowDBNull = false;
                this.columnSC01172.AllowDBNull = false;
                this.columnSC01173.AllowDBNull = false;
                this.columnSC01174.AllowDBNull = false;
                this.columnSC01175.AllowDBNull = false;
                this.columnSC01176.AllowDBNull = false;
                this.columnSC01177.AllowDBNull = false;
                this.columnSC01178.AllowDBNull = false;
                this.columnSC01179.AllowDBNull = false;
                this.columnSC01180.AllowDBNull = false;
                this.columnSC01181.AllowDBNull = false;
                this.columnSC01182.AllowDBNull = false;
                this.columnSC01183.AllowDBNull = false;
                this.columnSC01184.AllowDBNull = false;
                this.columnSC01185.AllowDBNull = false;
                this.columnSC01186.AllowDBNull = false;
                this.columnSC01187.AllowDBNull = false;
                this.columnSC01188.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnSC01001 = this.Columns["SC01001"];
                this.columnSC01002 = this.Columns["SC01002"];
                this.columnSC01003 = this.Columns["SC01003"];
                this.columnSC01004 = this.Columns["SC01004"];
                this.columnSC01005 = this.Columns["SC01005"];
                this.columnSC01006 = this.Columns["SC01006"];
                this.columnSC01007 = this.Columns["SC01007"];
                this.columnSC01008 = this.Columns["SC01008"];
                this.columnSC01009 = this.Columns["SC01009"];
                this.columnSC01010 = this.Columns["SC01010"];
                this.columnSC01011 = this.Columns["SC01011"];
                this.columnSC01012 = this.Columns["SC01012"];
                this.columnSC01013 = this.Columns["SC01013"];
                this.columnSC01014 = this.Columns["SC01014"];
                this.columnSC01015 = this.Columns["SC01015"];
                this.columnSC01016 = this.Columns["SC01016"];
                this.columnSC01017 = this.Columns["SC01017"];
                this.columnSC01018 = this.Columns["SC01018"];
                this.columnSC01019 = this.Columns["SC01019"];
                this.columnSC01020 = this.Columns["SC01020"];
                this.columnSC01021 = this.Columns["SC01021"];
                this.columnSC01022 = this.Columns["SC01022"];
                this.columnSC01023 = this.Columns["SC01023"];
                this.columnSC01024 = this.Columns["SC01024"];
                this.columnSC01025 = this.Columns["SC01025"];
                this.columnSC01026 = this.Columns["SC01026"];
                this.columnSC01027 = this.Columns["SC01027"];
                this.columnSC01028 = this.Columns["SC01028"];
                this.columnSC01029 = this.Columns["SC01029"];
                this.columnSC01030 = this.Columns["SC01030"];
                this.columnSC01031 = this.Columns["SC01031"];
                this.columnSC01032 = this.Columns["SC01032"];
                this.columnSC01033 = this.Columns["SC01033"];
                this.columnSC01034 = this.Columns["SC01034"];
                this.columnSC01035 = this.Columns["SC01035"];
                this.columnSC01036 = this.Columns["SC01036"];
                this.columnSC01037 = this.Columns["SC01037"];
                this.columnSC01038 = this.Columns["SC01038"];
                this.columnSC01039 = this.Columns["SC01039"];
                this.columnSC01040 = this.Columns["SC01040"];
                this.columnSC01041 = this.Columns["SC01041"];
                this.columnSC01042 = this.Columns["SC01042"];
                this.columnSC01043 = this.Columns["SC01043"];
                this.columnSC01044 = this.Columns["SC01044"];
                this.columnSC01045 = this.Columns["SC01045"];
                this.columnSC01046 = this.Columns["SC01046"];
                this.columnSC01047 = this.Columns["SC01047"];
                this.columnSC01048 = this.Columns["SC01048"];
                this.columnSC01049 = this.Columns["SC01049"];
                this.columnSC01050 = this.Columns["SC01050"];
                this.columnSC01051 = this.Columns["SC01051"];
                this.columnSC01052 = this.Columns["SC01052"];
                this.columnSC01053 = this.Columns["SC01053"];
                this.columnSC01054 = this.Columns["SC01054"];
                this.columnSC01055 = this.Columns["SC01055"];
                this.columnSC01056 = this.Columns["SC01056"];
                this.columnSC01057 = this.Columns["SC01057"];
                this.columnSC01058 = this.Columns["SC01058"];
                this.columnSC01059 = this.Columns["SC01059"];
                this.columnSC01060 = this.Columns["SC01060"];
                this.columnSC01061 = this.Columns["SC01061"];
                this.columnSC01062 = this.Columns["SC01062"];
                this.columnSC01063 = this.Columns["SC01063"];
                this.columnSC01064 = this.Columns["SC01064"];
                this.columnSC01065 = this.Columns["SC01065"];
                this.columnSC01066 = this.Columns["SC01066"];
                this.columnSC01067 = this.Columns["SC01067"];
                this.columnSC01068 = this.Columns["SC01068"];
                this.columnSC01069 = this.Columns["SC01069"];
                this.columnSC01070 = this.Columns["SC01070"];
                this.columnSC01071 = this.Columns["SC01071"];
                this.columnSC01072 = this.Columns["SC01072"];
                this.columnSC01073 = this.Columns["SC01073"];
                this.columnSC01074 = this.Columns["SC01074"];
                this.columnSC01075 = this.Columns["SC01075"];
                this.columnSC01076 = this.Columns["SC01076"];
                this.columnSC01077 = this.Columns["SC01077"];
                this.columnSC01078 = this.Columns["SC01078"];
                this.columnSC01079 = this.Columns["SC01079"];
                this.columnSC01080 = this.Columns["SC01080"];
                this.columnSC01081 = this.Columns["SC01081"];
                this.columnSC01082 = this.Columns["SC01082"];
                this.columnSC01083 = this.Columns["SC01083"];
                this.columnSC01084 = this.Columns["SC01084"];
                this.columnSC01085 = this.Columns["SC01085"];
                this.columnSC01086 = this.Columns["SC01086"];
                this.columnSC01087 = this.Columns["SC01087"];
                this.columnSC01088 = this.Columns["SC01088"];
                this.columnSC01089 = this.Columns["SC01089"];
                this.columnSC01090 = this.Columns["SC01090"];
                this.columnSC01091 = this.Columns["SC01091"];
                this.columnSC01092 = this.Columns["SC01092"];
                this.columnSC01093 = this.Columns["SC01093"];
                this.columnSC01094 = this.Columns["SC01094"];
                this.columnSC01095 = this.Columns["SC01095"];
                this.columnSC01096 = this.Columns["SC01096"];
                this.columnSC01097 = this.Columns["SC01097"];
                this.columnSC01098 = this.Columns["SC01098"];
                this.columnSC01099 = this.Columns["SC01099"];
                this.columnSC01100 = this.Columns["SC01100"];
                this.columnSC01101 = this.Columns["SC01101"];
                this.columnSC01102 = this.Columns["SC01102"];
                this.columnSC01103 = this.Columns["SC01103"];
                this.columnSC01104 = this.Columns["SC01104"];
                this.columnSC01105 = this.Columns["SC01105"];
                this.columnSC01106 = this.Columns["SC01106"];
                this.columnSC01107 = this.Columns["SC01107"];
                this.columnSC01108 = this.Columns["SC01108"];
                this.columnSC01109 = this.Columns["SC01109"];
                this.columnSC01110 = this.Columns["SC01110"];
                this.columnSC01111 = this.Columns["SC01111"];
                this.columnSC01112 = this.Columns["SC01112"];
                this.columnSC01113 = this.Columns["SC01113"];
                this.columnSC01114 = this.Columns["SC01114"];
                this.columnSC01115 = this.Columns["SC01115"];
                this.columnSC01116 = this.Columns["SC01116"];
                this.columnSC01117 = this.Columns["SC01117"];
                this.columnSC01118 = this.Columns["SC01118"];
                this.columnSC01119 = this.Columns["SC01119"];
                this.columnSC01120 = this.Columns["SC01120"];
                this.columnSC01121 = this.Columns["SC01121"];
                this.columnSC01122 = this.Columns["SC01122"];
                this.columnSC01123 = this.Columns["SC01123"];
                this.columnSC01124 = this.Columns["SC01124"];
                this.columnSC01125 = this.Columns["SC01125"];
                this.columnSC01126 = this.Columns["SC01126"];
                this.columnSC01127 = this.Columns["SC01127"];
                this.columnSC01128 = this.Columns["SC01128"];
                this.columnSC01129 = this.Columns["SC01129"];
                this.columnSC01130 = this.Columns["SC01130"];
                this.columnSC01131 = this.Columns["SC01131"];
                this.columnSC01132 = this.Columns["SC01132"];
                this.columnSC01133 = this.Columns["SC01133"];
                this.columnSC01134 = this.Columns["SC01134"];
                this.columnSC01135 = this.Columns["SC01135"];
                this.columnSC01136 = this.Columns["SC01136"];
                this.columnSC01137 = this.Columns["SC01137"];
                this.columnSC01138 = this.Columns["SC01138"];
                this.columnSC01139 = this.Columns["SC01139"];
                this.columnSC01140 = this.Columns["SC01140"];
                this.columnSC01141 = this.Columns["SC01141"];
                this.columnSC01142 = this.Columns["SC01142"];
                this.columnSC01143 = this.Columns["SC01143"];
                this.columnSC01144 = this.Columns["SC01144"];
                this.columnSC01145 = this.Columns["SC01145"];
                this.columnSC01146 = this.Columns["SC01146"];
                this.columnSC01147 = this.Columns["SC01147"];
                this.columnSC01148 = this.Columns["SC01148"];
                this.columnSC01149 = this.Columns["SC01149"];
                this.columnSC01150 = this.Columns["SC01150"];
                this.columnSC01151 = this.Columns["SC01151"];
                this.columnSC01152 = this.Columns["SC01152"];
                this.columnSC01153 = this.Columns["SC01153"];
                this.columnSC01154 = this.Columns["SC01154"];
                this.columnSC01155 = this.Columns["SC01155"];
                this.columnSC01156 = this.Columns["SC01156"];
                this.columnSC01157 = this.Columns["SC01157"];
                this.columnSC01158 = this.Columns["SC01158"];
                this.columnSC01159 = this.Columns["SC01159"];
                this.columnSC01160 = this.Columns["SC01160"];
                this.columnSC01161 = this.Columns["SC01161"];
                this.columnSC01162 = this.Columns["SC01162"];
                this.columnSC01163 = this.Columns["SC01163"];
                this.columnSC01164 = this.Columns["SC01164"];
                this.columnSC01165 = this.Columns["SC01165"];
                this.columnSC01166 = this.Columns["SC01166"];
                this.columnSC01167 = this.Columns["SC01167"];
                this.columnSC01168 = this.Columns["SC01168"];
                this.columnSC01169 = this.Columns["SC01169"];
                this.columnSC01170 = this.Columns["SC01170"];
                this.columnSC01171 = this.Columns["SC01171"];
                this.columnSC01172 = this.Columns["SC01172"];
                this.columnSC01173 = this.Columns["SC01173"];
                this.columnSC01174 = this.Columns["SC01174"];
                this.columnSC01175 = this.Columns["SC01175"];
                this.columnSC01176 = this.Columns["SC01176"];
                this.columnSC01177 = this.Columns["SC01177"];
                this.columnSC01178 = this.Columns["SC01178"];
                this.columnSC01179 = this.Columns["SC01179"];
                this.columnSC01180 = this.Columns["SC01180"];
                this.columnSC01181 = this.Columns["SC01181"];
                this.columnSC01182 = this.Columns["SC01182"];
                this.columnSC01183 = this.Columns["SC01183"];
                this.columnSC01184 = this.Columns["SC01184"];
                this.columnSC01185 = this.Columns["SC01185"];
                this.columnSC01186 = this.Columns["SC01186"];
                this.columnSC01187 = this.Columns["SC01187"];
                this.columnSC01188 = this.Columns["SC01188"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataDetDes.SC010100Row(builder);
            }

            public DataDetDes.SC010100Row NewSC010100Row()
            {
                return (DataDetDes.SC010100Row) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.SC010100RowChangedEvent != null) && (this.SC010100RowChangedEvent != null))
                {
                    this.SC010100RowChangedEvent(this, new DataDetDes.SC010100RowChangeEvent((DataDetDes.SC010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.SC010100RowChangingEvent != null) && (this.SC010100RowChangingEvent != null))
                {
                    this.SC010100RowChangingEvent(this, new DataDetDes.SC010100RowChangeEvent((DataDetDes.SC010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.SC010100RowDeletedEvent != null) && (this.SC010100RowDeletedEvent != null))
                {
                    this.SC010100RowDeletedEvent(this, new DataDetDes.SC010100RowChangeEvent((DataDetDes.SC010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.SC010100RowDeletingEvent != null) && (this.SC010100RowDeletingEvent != null))
                {
                    this.SC010100RowDeletingEvent(this, new DataDetDes.SC010100RowChangeEvent((DataDetDes.SC010100Row) e.Row, e.Action));
                }
            }

            public void RemoveSC010100Row(DataDetDes.SC010100Row row)
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

            public DataDetDes.SC010100Row this[int index]
            {
                get
                {
                    return (DataDetDes.SC010100Row) this.Rows[index];
                }
            }

            internal DataColumn SC01001Column
            {
                get
                {
                    return this.columnSC01001;
                }
            }

            internal DataColumn SC01002Column
            {
                get
                {
                    return this.columnSC01002;
                }
            }

            internal DataColumn SC01003Column
            {
                get
                {
                    return this.columnSC01003;
                }
            }

            internal DataColumn SC01004Column
            {
                get
                {
                    return this.columnSC01004;
                }
            }

            internal DataColumn SC01005Column
            {
                get
                {
                    return this.columnSC01005;
                }
            }

            internal DataColumn SC01006Column
            {
                get
                {
                    return this.columnSC01006;
                }
            }

            internal DataColumn SC01007Column
            {
                get
                {
                    return this.columnSC01007;
                }
            }

            internal DataColumn SC01008Column
            {
                get
                {
                    return this.columnSC01008;
                }
            }

            internal DataColumn SC01009Column
            {
                get
                {
                    return this.columnSC01009;
                }
            }

            internal DataColumn SC01010Column
            {
                get
                {
                    return this.columnSC01010;
                }
            }

            internal DataColumn SC01011Column
            {
                get
                {
                    return this.columnSC01011;
                }
            }

            internal DataColumn SC01012Column
            {
                get
                {
                    return this.columnSC01012;
                }
            }

            internal DataColumn SC01013Column
            {
                get
                {
                    return this.columnSC01013;
                }
            }

            internal DataColumn SC01014Column
            {
                get
                {
                    return this.columnSC01014;
                }
            }

            internal DataColumn SC01015Column
            {
                get
                {
                    return this.columnSC01015;
                }
            }

            internal DataColumn SC01016Column
            {
                get
                {
                    return this.columnSC01016;
                }
            }

            internal DataColumn SC01017Column
            {
                get
                {
                    return this.columnSC01017;
                }
            }

            internal DataColumn SC01018Column
            {
                get
                {
                    return this.columnSC01018;
                }
            }

            internal DataColumn SC01019Column
            {
                get
                {
                    return this.columnSC01019;
                }
            }

            internal DataColumn SC01020Column
            {
                get
                {
                    return this.columnSC01020;
                }
            }

            internal DataColumn SC01021Column
            {
                get
                {
                    return this.columnSC01021;
                }
            }

            internal DataColumn SC01022Column
            {
                get
                {
                    return this.columnSC01022;
                }
            }

            internal DataColumn SC01023Column
            {
                get
                {
                    return this.columnSC01023;
                }
            }

            internal DataColumn SC01024Column
            {
                get
                {
                    return this.columnSC01024;
                }
            }

            internal DataColumn SC01025Column
            {
                get
                {
                    return this.columnSC01025;
                }
            }

            internal DataColumn SC01026Column
            {
                get
                {
                    return this.columnSC01026;
                }
            }

            internal DataColumn SC01027Column
            {
                get
                {
                    return this.columnSC01027;
                }
            }

            internal DataColumn SC01028Column
            {
                get
                {
                    return this.columnSC01028;
                }
            }

            internal DataColumn SC01029Column
            {
                get
                {
                    return this.columnSC01029;
                }
            }

            internal DataColumn SC01030Column
            {
                get
                {
                    return this.columnSC01030;
                }
            }

            internal DataColumn SC01031Column
            {
                get
                {
                    return this.columnSC01031;
                }
            }

            internal DataColumn SC01032Column
            {
                get
                {
                    return this.columnSC01032;
                }
            }

            internal DataColumn SC01033Column
            {
                get
                {
                    return this.columnSC01033;
                }
            }

            internal DataColumn SC01034Column
            {
                get
                {
                    return this.columnSC01034;
                }
            }

            internal DataColumn SC01035Column
            {
                get
                {
                    return this.columnSC01035;
                }
            }

            internal DataColumn SC01036Column
            {
                get
                {
                    return this.columnSC01036;
                }
            }

            internal DataColumn SC01037Column
            {
                get
                {
                    return this.columnSC01037;
                }
            }

            internal DataColumn SC01038Column
            {
                get
                {
                    return this.columnSC01038;
                }
            }

            internal DataColumn SC01039Column
            {
                get
                {
                    return this.columnSC01039;
                }
            }

            internal DataColumn SC01040Column
            {
                get
                {
                    return this.columnSC01040;
                }
            }

            internal DataColumn SC01041Column
            {
                get
                {
                    return this.columnSC01041;
                }
            }

            internal DataColumn SC01042Column
            {
                get
                {
                    return this.columnSC01042;
                }
            }

            internal DataColumn SC01043Column
            {
                get
                {
                    return this.columnSC01043;
                }
            }

            internal DataColumn SC01044Column
            {
                get
                {
                    return this.columnSC01044;
                }
            }

            internal DataColumn SC01045Column
            {
                get
                {
                    return this.columnSC01045;
                }
            }

            internal DataColumn SC01046Column
            {
                get
                {
                    return this.columnSC01046;
                }
            }

            internal DataColumn SC01047Column
            {
                get
                {
                    return this.columnSC01047;
                }
            }

            internal DataColumn SC01048Column
            {
                get
                {
                    return this.columnSC01048;
                }
            }

            internal DataColumn SC01049Column
            {
                get
                {
                    return this.columnSC01049;
                }
            }

            internal DataColumn SC01050Column
            {
                get
                {
                    return this.columnSC01050;
                }
            }

            internal DataColumn SC01051Column
            {
                get
                {
                    return this.columnSC01051;
                }
            }

            internal DataColumn SC01052Column
            {
                get
                {
                    return this.columnSC01052;
                }
            }

            internal DataColumn SC01053Column
            {
                get
                {
                    return this.columnSC01053;
                }
            }

            internal DataColumn SC01054Column
            {
                get
                {
                    return this.columnSC01054;
                }
            }

            internal DataColumn SC01055Column
            {
                get
                {
                    return this.columnSC01055;
                }
            }

            internal DataColumn SC01056Column
            {
                get
                {
                    return this.columnSC01056;
                }
            }

            internal DataColumn SC01057Column
            {
                get
                {
                    return this.columnSC01057;
                }
            }

            internal DataColumn SC01058Column
            {
                get
                {
                    return this.columnSC01058;
                }
            }

            internal DataColumn SC01059Column
            {
                get
                {
                    return this.columnSC01059;
                }
            }

            internal DataColumn SC01060Column
            {
                get
                {
                    return this.columnSC01060;
                }
            }

            internal DataColumn SC01061Column
            {
                get
                {
                    return this.columnSC01061;
                }
            }

            internal DataColumn SC01062Column
            {
                get
                {
                    return this.columnSC01062;
                }
            }

            internal DataColumn SC01063Column
            {
                get
                {
                    return this.columnSC01063;
                }
            }

            internal DataColumn SC01064Column
            {
                get
                {
                    return this.columnSC01064;
                }
            }

            internal DataColumn SC01065Column
            {
                get
                {
                    return this.columnSC01065;
                }
            }

            internal DataColumn SC01066Column
            {
                get
                {
                    return this.columnSC01066;
                }
            }

            internal DataColumn SC01067Column
            {
                get
                {
                    return this.columnSC01067;
                }
            }

            internal DataColumn SC01068Column
            {
                get
                {
                    return this.columnSC01068;
                }
            }

            internal DataColumn SC01069Column
            {
                get
                {
                    return this.columnSC01069;
                }
            }

            internal DataColumn SC01070Column
            {
                get
                {
                    return this.columnSC01070;
                }
            }

            internal DataColumn SC01071Column
            {
                get
                {
                    return this.columnSC01071;
                }
            }

            internal DataColumn SC01072Column
            {
                get
                {
                    return this.columnSC01072;
                }
            }

            internal DataColumn SC01073Column
            {
                get
                {
                    return this.columnSC01073;
                }
            }

            internal DataColumn SC01074Column
            {
                get
                {
                    return this.columnSC01074;
                }
            }

            internal DataColumn SC01075Column
            {
                get
                {
                    return this.columnSC01075;
                }
            }

            internal DataColumn SC01076Column
            {
                get
                {
                    return this.columnSC01076;
                }
            }

            internal DataColumn SC01077Column
            {
                get
                {
                    return this.columnSC01077;
                }
            }

            internal DataColumn SC01078Column
            {
                get
                {
                    return this.columnSC01078;
                }
            }

            internal DataColumn SC01079Column
            {
                get
                {
                    return this.columnSC01079;
                }
            }

            internal DataColumn SC01080Column
            {
                get
                {
                    return this.columnSC01080;
                }
            }

            internal DataColumn SC01081Column
            {
                get
                {
                    return this.columnSC01081;
                }
            }

            internal DataColumn SC01082Column
            {
                get
                {
                    return this.columnSC01082;
                }
            }

            internal DataColumn SC01083Column
            {
                get
                {
                    return this.columnSC01083;
                }
            }

            internal DataColumn SC01084Column
            {
                get
                {
                    return this.columnSC01084;
                }
            }

            internal DataColumn SC01085Column
            {
                get
                {
                    return this.columnSC01085;
                }
            }

            internal DataColumn SC01086Column
            {
                get
                {
                    return this.columnSC01086;
                }
            }

            internal DataColumn SC01087Column
            {
                get
                {
                    return this.columnSC01087;
                }
            }

            internal DataColumn SC01088Column
            {
                get
                {
                    return this.columnSC01088;
                }
            }

            internal DataColumn SC01089Column
            {
                get
                {
                    return this.columnSC01089;
                }
            }

            internal DataColumn SC01090Column
            {
                get
                {
                    return this.columnSC01090;
                }
            }

            internal DataColumn SC01091Column
            {
                get
                {
                    return this.columnSC01091;
                }
            }

            internal DataColumn SC01092Column
            {
                get
                {
                    return this.columnSC01092;
                }
            }

            internal DataColumn SC01093Column
            {
                get
                {
                    return this.columnSC01093;
                }
            }

            internal DataColumn SC01094Column
            {
                get
                {
                    return this.columnSC01094;
                }
            }

            internal DataColumn SC01095Column
            {
                get
                {
                    return this.columnSC01095;
                }
            }

            internal DataColumn SC01096Column
            {
                get
                {
                    return this.columnSC01096;
                }
            }

            internal DataColumn SC01097Column
            {
                get
                {
                    return this.columnSC01097;
                }
            }

            internal DataColumn SC01098Column
            {
                get
                {
                    return this.columnSC01098;
                }
            }

            internal DataColumn SC01099Column
            {
                get
                {
                    return this.columnSC01099;
                }
            }

            internal DataColumn SC01100Column
            {
                get
                {
                    return this.columnSC01100;
                }
            }

            internal DataColumn SC01101Column
            {
                get
                {
                    return this.columnSC01101;
                }
            }

            internal DataColumn SC01102Column
            {
                get
                {
                    return this.columnSC01102;
                }
            }

            internal DataColumn SC01103Column
            {
                get
                {
                    return this.columnSC01103;
                }
            }

            internal DataColumn SC01104Column
            {
                get
                {
                    return this.columnSC01104;
                }
            }

            internal DataColumn SC01105Column
            {
                get
                {
                    return this.columnSC01105;
                }
            }

            internal DataColumn SC01106Column
            {
                get
                {
                    return this.columnSC01106;
                }
            }

            internal DataColumn SC01107Column
            {
                get
                {
                    return this.columnSC01107;
                }
            }

            internal DataColumn SC01108Column
            {
                get
                {
                    return this.columnSC01108;
                }
            }

            internal DataColumn SC01109Column
            {
                get
                {
                    return this.columnSC01109;
                }
            }

            internal DataColumn SC01110Column
            {
                get
                {
                    return this.columnSC01110;
                }
            }

            internal DataColumn SC01111Column
            {
                get
                {
                    return this.columnSC01111;
                }
            }

            internal DataColumn SC01112Column
            {
                get
                {
                    return this.columnSC01112;
                }
            }

            internal DataColumn SC01113Column
            {
                get
                {
                    return this.columnSC01113;
                }
            }

            internal DataColumn SC01114Column
            {
                get
                {
                    return this.columnSC01114;
                }
            }

            internal DataColumn SC01115Column
            {
                get
                {
                    return this.columnSC01115;
                }
            }

            internal DataColumn SC01116Column
            {
                get
                {
                    return this.columnSC01116;
                }
            }

            internal DataColumn SC01117Column
            {
                get
                {
                    return this.columnSC01117;
                }
            }

            internal DataColumn SC01118Column
            {
                get
                {
                    return this.columnSC01118;
                }
            }

            internal DataColumn SC01119Column
            {
                get
                {
                    return this.columnSC01119;
                }
            }

            internal DataColumn SC01120Column
            {
                get
                {
                    return this.columnSC01120;
                }
            }

            internal DataColumn SC01121Column
            {
                get
                {
                    return this.columnSC01121;
                }
            }

            internal DataColumn SC01122Column
            {
                get
                {
                    return this.columnSC01122;
                }
            }

            internal DataColumn SC01123Column
            {
                get
                {
                    return this.columnSC01123;
                }
            }

            internal DataColumn SC01124Column
            {
                get
                {
                    return this.columnSC01124;
                }
            }

            internal DataColumn SC01125Column
            {
                get
                {
                    return this.columnSC01125;
                }
            }

            internal DataColumn SC01126Column
            {
                get
                {
                    return this.columnSC01126;
                }
            }

            internal DataColumn SC01127Column
            {
                get
                {
                    return this.columnSC01127;
                }
            }

            internal DataColumn SC01128Column
            {
                get
                {
                    return this.columnSC01128;
                }
            }

            internal DataColumn SC01129Column
            {
                get
                {
                    return this.columnSC01129;
                }
            }

            internal DataColumn SC01130Column
            {
                get
                {
                    return this.columnSC01130;
                }
            }

            internal DataColumn SC01131Column
            {
                get
                {
                    return this.columnSC01131;
                }
            }

            internal DataColumn SC01132Column
            {
                get
                {
                    return this.columnSC01132;
                }
            }

            internal DataColumn SC01133Column
            {
                get
                {
                    return this.columnSC01133;
                }
            }

            internal DataColumn SC01134Column
            {
                get
                {
                    return this.columnSC01134;
                }
            }

            internal DataColumn SC01135Column
            {
                get
                {
                    return this.columnSC01135;
                }
            }

            internal DataColumn SC01136Column
            {
                get
                {
                    return this.columnSC01136;
                }
            }

            internal DataColumn SC01137Column
            {
                get
                {
                    return this.columnSC01137;
                }
            }

            internal DataColumn SC01138Column
            {
                get
                {
                    return this.columnSC01138;
                }
            }

            internal DataColumn SC01139Column
            {
                get
                {
                    return this.columnSC01139;
                }
            }

            internal DataColumn SC01140Column
            {
                get
                {
                    return this.columnSC01140;
                }
            }

            internal DataColumn SC01141Column
            {
                get
                {
                    return this.columnSC01141;
                }
            }

            internal DataColumn SC01142Column
            {
                get
                {
                    return this.columnSC01142;
                }
            }

            internal DataColumn SC01143Column
            {
                get
                {
                    return this.columnSC01143;
                }
            }

            internal DataColumn SC01144Column
            {
                get
                {
                    return this.columnSC01144;
                }
            }

            internal DataColumn SC01145Column
            {
                get
                {
                    return this.columnSC01145;
                }
            }

            internal DataColumn SC01146Column
            {
                get
                {
                    return this.columnSC01146;
                }
            }

            internal DataColumn SC01147Column
            {
                get
                {
                    return this.columnSC01147;
                }
            }

            internal DataColumn SC01148Column
            {
                get
                {
                    return this.columnSC01148;
                }
            }

            internal DataColumn SC01149Column
            {
                get
                {
                    return this.columnSC01149;
                }
            }

            internal DataColumn SC01150Column
            {
                get
                {
                    return this.columnSC01150;
                }
            }

            internal DataColumn SC01151Column
            {
                get
                {
                    return this.columnSC01151;
                }
            }

            internal DataColumn SC01152Column
            {
                get
                {
                    return this.columnSC01152;
                }
            }

            internal DataColumn SC01153Column
            {
                get
                {
                    return this.columnSC01153;
                }
            }

            internal DataColumn SC01154Column
            {
                get
                {
                    return this.columnSC01154;
                }
            }

            internal DataColumn SC01155Column
            {
                get
                {
                    return this.columnSC01155;
                }
            }

            internal DataColumn SC01156Column
            {
                get
                {
                    return this.columnSC01156;
                }
            }

            internal DataColumn SC01157Column
            {
                get
                {
                    return this.columnSC01157;
                }
            }

            internal DataColumn SC01158Column
            {
                get
                {
                    return this.columnSC01158;
                }
            }

            internal DataColumn SC01159Column
            {
                get
                {
                    return this.columnSC01159;
                }
            }

            internal DataColumn SC01160Column
            {
                get
                {
                    return this.columnSC01160;
                }
            }

            internal DataColumn SC01161Column
            {
                get
                {
                    return this.columnSC01161;
                }
            }

            internal DataColumn SC01162Column
            {
                get
                {
                    return this.columnSC01162;
                }
            }

            internal DataColumn SC01163Column
            {
                get
                {
                    return this.columnSC01163;
                }
            }

            internal DataColumn SC01164Column
            {
                get
                {
                    return this.columnSC01164;
                }
            }

            internal DataColumn SC01165Column
            {
                get
                {
                    return this.columnSC01165;
                }
            }

            internal DataColumn SC01166Column
            {
                get
                {
                    return this.columnSC01166;
                }
            }

            internal DataColumn SC01167Column
            {
                get
                {
                    return this.columnSC01167;
                }
            }

            internal DataColumn SC01168Column
            {
                get
                {
                    return this.columnSC01168;
                }
            }

            internal DataColumn SC01169Column
            {
                get
                {
                    return this.columnSC01169;
                }
            }

            internal DataColumn SC01170Column
            {
                get
                {
                    return this.columnSC01170;
                }
            }

            internal DataColumn SC01171Column
            {
                get
                {
                    return this.columnSC01171;
                }
            }

            internal DataColumn SC01172Column
            {
                get
                {
                    return this.columnSC01172;
                }
            }

            internal DataColumn SC01173Column
            {
                get
                {
                    return this.columnSC01173;
                }
            }

            internal DataColumn SC01174Column
            {
                get
                {
                    return this.columnSC01174;
                }
            }

            internal DataColumn SC01175Column
            {
                get
                {
                    return this.columnSC01175;
                }
            }

            internal DataColumn SC01176Column
            {
                get
                {
                    return this.columnSC01176;
                }
            }

            internal DataColumn SC01177Column
            {
                get
                {
                    return this.columnSC01177;
                }
            }

            internal DataColumn SC01178Column
            {
                get
                {
                    return this.columnSC01178;
                }
            }

            internal DataColumn SC01179Column
            {
                get
                {
                    return this.columnSC01179;
                }
            }

            internal DataColumn SC01180Column
            {
                get
                {
                    return this.columnSC01180;
                }
            }

            internal DataColumn SC01181Column
            {
                get
                {
                    return this.columnSC01181;
                }
            }

            internal DataColumn SC01182Column
            {
                get
                {
                    return this.columnSC01182;
                }
            }

            internal DataColumn SC01183Column
            {
                get
                {
                    return this.columnSC01183;
                }
            }

            internal DataColumn SC01184Column
            {
                get
                {
                    return this.columnSC01184;
                }
            }

            internal DataColumn SC01185Column
            {
                get
                {
                    return this.columnSC01185;
                }
            }

            internal DataColumn SC01186Column
            {
                get
                {
                    return this.columnSC01186;
                }
            }

            internal DataColumn SC01187Column
            {
                get
                {
                    return this.columnSC01187;
                }
            }

            internal DataColumn SC01188Column
            {
                get
                {
                    return this.columnSC01188;
                }
            }
        }

        [DebuggerStepThrough]
        public class SC010100Row : DataRow
        {
            private DataDetDes.SC010100DataTable tableSC010100;

            internal SC010100Row(DataRowBuilder rb) : base(rb)
            {
                this.tableSC010100 = (DataDetDes.SC010100DataTable) this.Table;
            }

            public DataDetDes.detdesRow[] GetdetdesRows()
            {
                return (DataDetDes.detdesRow[]) this.GetChildRows(this.Table.ChildRelations["SC010100detdes"]);
            }

            public string SC01001
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01001Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01001Column] = value;
                }
            }

            public string SC01002
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01002Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01002Column] = value;
                }
            }

            public string SC01003
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01003Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01003Column] = value;
                }
            }

            public decimal SC01004
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01004Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01004Column] = value;
                }
            }

            public decimal SC01005
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01005Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01005Column] = value;
                }
            }

            public DateTime SC01006
            {
                get
                {
                    return DateType.FromObject(this[this.tableSC010100.SC01006Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01006Column] = value;
                }
            }

            public decimal SC01007
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01007Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01007Column] = value;
                }
            }

            public decimal SC01008
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01008Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01008Column] = value;
                }
            }

            public decimal SC01009
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01009Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01009Column] = value;
                }
            }

            public string SC01010
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01010Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01010Column] = value;
                }
            }

            public string SC01011
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01011Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01011Column] = value;
                }
            }

            public string SC01012
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01012Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01012Column] = value;
                }
            }

            public string SC01013
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01013Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01013Column] = value;
                }
            }

            public string SC01014
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01014Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01014Column] = value;
                }
            }

            public string SC01015
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01015Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01015Column] = value;
                }
            }

            public string SC01016
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01016Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01016Column] = value;
                }
            }

            public string SC01017
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01017Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01017Column] = value;
                }
            }

            public string SC01018
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01018Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01018Column] = value;
                }
            }

            public string SC01019
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01019Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01019Column] = value;
                }
            }

            public string SC01020
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01020Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01020Column] = value;
                }
            }

            public int SC01021
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01021Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01021Column] = value;
                }
            }

            public string SC01022
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01022Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01022Column] = value;
                }
            }

            public string SC01023
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01023Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01023Column] = value;
                }
            }

            public string SC01024
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01024Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01024Column] = value;
                }
            }

            public string SC01025
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01025Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01025Column] = value;
                }
            }

            public string SC01026
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01026Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01026Column] = value;
                }
            }

            public string SC01027
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01027Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01027Column] = value;
                }
            }

            public string SC01028
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01028Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01028Column] = value;
                }
            }

            public string SC01029
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01029Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01029Column] = value;
                }
            }

            public string SC01030
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01030Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01030Column] = value;
                }
            }

            public int SC01031
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01031Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01031Column] = value;
                }
            }

            public string SC01032
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01032Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01032Column] = value;
                }
            }

            public int SC01033
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01033Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01033Column] = value;
                }
            }

            public int SC01034
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01034Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01034Column] = value;
                }
            }

            public string SC01035
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01035Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01035Column] = value;
                }
            }

            public string SC01036
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01036Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01036Column] = value;
                }
            }

            public string SC01037
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01037Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01037Column] = value;
                }
            }

            public string SC01038
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01038Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01038Column] = value;
                }
            }

            public string SC01039
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01039Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01039Column] = value;
                }
            }

            public decimal SC01040
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01040Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01040Column] = value;
                }
            }

            public decimal SC01041
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01041Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01041Column] = value;
                }
            }

            public decimal SC01042
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01042Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01042Column] = value;
                }
            }

            public decimal SC01043
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01043Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01043Column] = value;
                }
            }

            public decimal SC01044
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01044Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01044Column] = value;
                }
            }

            public decimal SC01045
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01045Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01045Column] = value;
                }
            }

            public decimal SC01046
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01046Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01046Column] = value;
                }
            }

            public string SC01047
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01047Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01047Column] = value;
                }
            }

            public DateTime SC01048
            {
                get
                {
                    return DateType.FromObject(this[this.tableSC010100.SC01048Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01048Column] = value;
                }
            }

            public DateTime SC01049
            {
                get
                {
                    return DateType.FromObject(this[this.tableSC010100.SC01049Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01049Column] = value;
                }
            }

            public DateTime SC01050
            {
                get
                {
                    return DateType.FromObject(this[this.tableSC010100.SC01050Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01050Column] = value;
                }
            }

            public DateTime SC01051
            {
                get
                {
                    return DateType.FromObject(this[this.tableSC010100.SC01051Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01051Column] = value;
                }
            }

            public decimal SC01052
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01052Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01052Column] = value;
                }
            }

            public decimal SC01053
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01053Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01053Column] = value;
                }
            }

            public decimal SC01054
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01054Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01054Column] = value;
                }
            }

            public decimal SC01055
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01055Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01055Column] = value;
                }
            }

            public string SC01056
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01056Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01056Column] = value;
                }
            }

            public decimal SC01057
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01057Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01057Column] = value;
                }
            }

            public string SC01058
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01058Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01058Column] = value;
                }
            }

            public string SC01059
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01059Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01059Column] = value;
                }
            }

            public string SC01060
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01060Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01060Column] = value;
                }
            }

            public decimal SC01061
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01061Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01061Column] = value;
                }
            }

            public int SC01062
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01062Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01062Column] = value;
                }
            }

            public decimal SC01063
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01063Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01063Column] = value;
                }
            }

            public decimal SC01064
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01064Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01064Column] = value;
                }
            }

            public int SC01065
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01065Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01065Column] = value;
                }
            }

            public int SC01066
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01066Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01066Column] = value;
                }
            }

            public string SC01067
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01067Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01067Column] = value;
                }
            }

            public int SC01068
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01068Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01068Column] = value;
                }
            }

            public decimal SC01069
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01069Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01069Column] = value;
                }
            }

            public decimal SC01070
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01070Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01070Column] = value;
                }
            }

            public decimal SC01071
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01071Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01071Column] = value;
                }
            }

            public decimal SC01072
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01072Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01072Column] = value;
                }
            }

            public decimal SC01073
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01073Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01073Column] = value;
                }
            }

            public string SC01074
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01074Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01074Column] = value;
                }
            }

            public string SC01075
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01075Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01075Column] = value;
                }
            }

            public string SC01076
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01076Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01076Column] = value;
                }
            }

            public decimal SC01077
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01077Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01077Column] = value;
                }
            }

            public decimal SC01078
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01078Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01078Column] = value;
                }
            }

            public decimal SC01079
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01079Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01079Column] = value;
                }
            }

            public decimal SC01080
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01080Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01080Column] = value;
                }
            }

            public decimal SC01081
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01081Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01081Column] = value;
                }
            }

            public decimal SC01082
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01082Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01082Column] = value;
                }
            }

            public decimal SC01083
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01083Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01083Column] = value;
                }
            }

            public decimal SC01084
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01084Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01084Column] = value;
                }
            }

            public decimal SC01085
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01085Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01085Column] = value;
                }
            }

            public decimal SC01086
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01086Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01086Column] = value;
                }
            }

            public decimal SC01087
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01087Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01087Column] = value;
                }
            }

            public decimal SC01088
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01088Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01088Column] = value;
                }
            }

            public string SC01089
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01089Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01089Column] = value;
                }
            }

            public int SC01090
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01090Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01090Column] = value;
                }
            }

            public int SC01091
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01091Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01091Column] = value;
                }
            }

            public DateTime SC01092
            {
                get
                {
                    return DateType.FromObject(this[this.tableSC010100.SC01092Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01092Column] = value;
                }
            }

            public string SC01093
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01093Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01093Column] = value;
                }
            }

            public string SC01094
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01094Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01094Column] = value;
                }
            }

            public int SC01095
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01095Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01095Column] = value;
                }
            }

            public int SC01096
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01096Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01096Column] = value;
                }
            }

            public int SC01097
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01097Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01097Column] = value;
                }
            }

            public decimal SC01098
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01098Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01098Column] = value;
                }
            }

            public decimal SC01099
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01099Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01099Column] = value;
                }
            }

            public string SC01100
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01100Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01100Column] = value;
                }
            }

            public int SC01101
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01101Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01101Column] = value;
                }
            }

            public string SC01102
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01102Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01102Column] = value;
                }
            }

            public string SC01103
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01103Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01103Column] = value;
                }
            }

            public int SC01104
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01104Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01104Column] = value;
                }
            }

            public int SC01105
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01105Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01105Column] = value;
                }
            }

            public decimal SC01106
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01106Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01106Column] = value;
                }
            }

            public string SC01107
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01107Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01107Column] = value;
                }
            }

            public decimal SC01108
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01108Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01108Column] = value;
                }
            }

            public decimal SC01109
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01109Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01109Column] = value;
                }
            }

            public decimal SC01110
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01110Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01110Column] = value;
                }
            }

            public decimal SC01111
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01111Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01111Column] = value;
                }
            }

            public decimal SC01112
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01112Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01112Column] = value;
                }
            }

            public decimal SC01113
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01113Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01113Column] = value;
                }
            }

            public string SC01114
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01114Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01114Column] = value;
                }
            }

            public string SC01115
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01115Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01115Column] = value;
                }
            }

            public DateTime SC01116
            {
                get
                {
                    return DateType.FromObject(this[this.tableSC010100.SC01116Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01116Column] = value;
                }
            }

            public string SC01117
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01117Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01117Column] = value;
                }
            }

            public DateTime SC01118
            {
                get
                {
                    return DateType.FromObject(this[this.tableSC010100.SC01118Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01118Column] = value;
                }
            }

            public DateTime SC01119
            {
                get
                {
                    return DateType.FromObject(this[this.tableSC010100.SC01119Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01119Column] = value;
                }
            }

            public string SC01120
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01120Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01120Column] = value;
                }
            }

            public DateTime SC01121
            {
                get
                {
                    return DateType.FromObject(this[this.tableSC010100.SC01121Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01121Column] = value;
                }
            }

            public DateTime SC01122
            {
                get
                {
                    return DateType.FromObject(this[this.tableSC010100.SC01122Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01122Column] = value;
                }
            }

            public DateTime SC01123
            {
                get
                {
                    return DateType.FromObject(this[this.tableSC010100.SC01123Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01123Column] = value;
                }
            }

            public DateTime SC01124
            {
                get
                {
                    return DateType.FromObject(this[this.tableSC010100.SC01124Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01124Column] = value;
                }
            }

            public DateTime SC01125
            {
                get
                {
                    return DateType.FromObject(this[this.tableSC010100.SC01125Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01125Column] = value;
                }
            }

            public string SC01126
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01126Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01126Column] = value;
                }
            }

            public int SC01127
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01127Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01127Column] = value;
                }
            }

            public string SC01128
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01128Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01128Column] = value;
                }
            }

            public int SC01129
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01129Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01129Column] = value;
                }
            }

            public string SC01130
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01130Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01130Column] = value;
                }
            }

            public string SC01131
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01131Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01131Column] = value;
                }
            }

            public string SC01132
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01132Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01132Column] = value;
                }
            }

            public int SC01133
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01133Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01133Column] = value;
                }
            }

            public int SC01134
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01134Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01134Column] = value;
                }
            }

            public int SC01135
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01135Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01135Column] = value;
                }
            }

            public int SC01136
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01136Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01136Column] = value;
                }
            }

            public int SC01137
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01137Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01137Column] = value;
                }
            }

            public string SC01138
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01138Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01138Column] = value;
                }
            }

            public decimal SC01139
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01139Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01139Column] = value;
                }
            }

            public decimal SC01140
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01140Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01140Column] = value;
                }
            }

            public decimal SC01141
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01141Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01141Column] = value;
                }
            }

            public decimal SC01142
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01142Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01142Column] = value;
                }
            }

            public decimal SC01143
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01143Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01143Column] = value;
                }
            }

            public int SC01144
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01144Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01144Column] = value;
                }
            }

            public int SC01145
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01145Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01145Column] = value;
                }
            }

            public decimal SC01146
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01146Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01146Column] = value;
                }
            }

            public string SC01147
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01147Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01147Column] = value;
                }
            }

            public decimal SC01148
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01148Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01148Column] = value;
                }
            }

            public decimal SC01149
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01149Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01149Column] = value;
                }
            }

            public string SC01150
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01150Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01150Column] = value;
                }
            }

            public int SC01151
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableSC010100.SC01151Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01151Column] = value;
                }
            }

            public string SC01152
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01152Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01152Column] = value;
                }
            }

            public decimal SC01153
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01153Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01153Column] = value;
                }
            }

            public decimal SC01154
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01154Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01154Column] = value;
                }
            }

            public decimal SC01155
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01155Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01155Column] = value;
                }
            }

            public string SC01156
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01156Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01156Column] = value;
                }
            }

            public decimal SC01157
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01157Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01157Column] = value;
                }
            }

            public decimal SC01158
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01158Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01158Column] = value;
                }
            }

            public decimal SC01159
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01159Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01159Column] = value;
                }
            }

            public string SC01160
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01160Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01160Column] = value;
                }
            }

            public string SC01161
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01161Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01161Column] = value;
                }
            }

            public string SC01162
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01162Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01162Column] = value;
                }
            }

            public string SC01163
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01163Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01163Column] = value;
                }
            }

            public string SC01164
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01164Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01164Column] = value;
                }
            }

            public string SC01165
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01165Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01165Column] = value;
                }
            }

            public string SC01166
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01166Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01166Column] = value;
                }
            }

            public string SC01167
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01167Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01167Column] = value;
                }
            }

            public string SC01168
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01168Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01168Column] = value;
                }
            }

            public string SC01169
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01169Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01169Column] = value;
                }
            }

            public string SC01170
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01170Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01170Column] = value;
                }
            }

            public string SC01171
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01171Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01171Column] = value;
                }
            }

            public string SC01172
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01172Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01172Column] = value;
                }
            }

            public string SC01173
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01173Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01173Column] = value;
                }
            }

            public string SC01174
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01174Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01174Column] = value;
                }
            }

            public string SC01175
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01175Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01175Column] = value;
                }
            }

            public string SC01176
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01176Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01176Column] = value;
                }
            }

            public string SC01177
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01177Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01177Column] = value;
                }
            }

            public string SC01178
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01178Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01178Column] = value;
                }
            }

            public string SC01179
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01179Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01179Column] = value;
                }
            }

            public string SC01180
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01180Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01180Column] = value;
                }
            }

            public decimal SC01181
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01181Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01181Column] = value;
                }
            }

            public decimal SC01182
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC010100.SC01182Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01182Column] = value;
                }
            }

            public string SC01183
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01183Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01183Column] = value;
                }
            }

            public string SC01184
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01184Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01184Column] = value;
                }
            }

            public string SC01185
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01185Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01185Column] = value;
                }
            }

            public string SC01186
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01186Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01186Column] = value;
                }
            }

            public string SC01187
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01187Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01187Column] = value;
                }
            }

            public string SC01188
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC010100.SC01188Column]);
                }
                set
                {
                    this[this.tableSC010100.SC01188Column] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class SC010100RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataDetDes.SC010100Row eventRow;

            public SC010100RowChangeEvent(DataDetDes.SC010100Row row, DataRowAction action)
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

            public DataDetDes.SC010100Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SC010100RowChangeEventHandler(object sender, DataDetDes.SC010100RowChangeEvent e);
    }
}

