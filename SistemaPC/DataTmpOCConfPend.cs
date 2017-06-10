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
    public class DataTmpOCConfPend : DataSet
    {
        private PC1TmpOCConfPendDataTable tablePC1TmpOCConfPend;

        public DataTmpOCConfPend()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DataTmpOCConfPend(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["PC1TmpOCConfPend"] != null)
                {
                    this.Tables.Add(new PC1TmpOCConfPendDataTable(dataSet.Tables["PC1TmpOCConfPend"]));
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
            DataTmpOCConfPend pend = (DataTmpOCConfPend) base.Clone();
            pend.InitVars();
            return pend;
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
            this.DataSetName = "DataTmpOCConfPend";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DataTmpOCConfPend.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tablePC1TmpOCConfPend = new PC1TmpOCConfPendDataTable();
            this.Tables.Add(this.tablePC1TmpOCConfPend);
        }

        internal void InitVars()
        {
            this.tablePC1TmpOCConfPend = (PC1TmpOCConfPendDataTable) this.Tables["PC1TmpOCConfPend"];
            if (this.tablePC1TmpOCConfPend != null)
            {
                this.tablePC1TmpOCConfPend.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["PC1TmpOCConfPend"] != null)
            {
                this.Tables.Add(new PC1TmpOCConfPendDataTable(dataSet.Tables["PC1TmpOCConfPend"]));
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

        private bool ShouldSerializePC1TmpOCConfPend()
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
        public PC1TmpOCConfPendDataTable PC1TmpOCConfPend
        {
            get
            {
                return this.tablePC1TmpOCConfPend;
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpOCConfPendDataTable : DataTable, IEnumerable
        {
            private DataColumn columnCantidad;
            private DataColumn columnCodigo;
            private DataColumn columnCodProv;
            private DataColumn columnDescripcion;
            private DataColumn columnDestinatario;
            private DataColumn columnEnTransito;
            private DataColumn columnFechaOC;
            private DataColumn columnFEntConf;
            private DataColumn columnFEntSolic;
            private DataColumn columnFormaDesp;
            private DataColumn columnNomProv;
            private DataColumn columnNroOC;

            public event DataTmpOCConfPend.PC1TmpOCConfPendRowChangeEventHandler PC1TmpOCConfPendRowChanged;

            public event DataTmpOCConfPend.PC1TmpOCConfPendRowChangeEventHandler PC1TmpOCConfPendRowChanging;

            public event DataTmpOCConfPend.PC1TmpOCConfPendRowChangeEventHandler PC1TmpOCConfPendRowDeleted;

            public event DataTmpOCConfPend.PC1TmpOCConfPendRowChangeEventHandler PC1TmpOCConfPendRowDeleting;

            internal PC1TmpOCConfPendDataTable() : base("PC1TmpOCConfPend")
            {
                this.InitClass();
            }

            internal PC1TmpOCConfPendDataTable(DataTable table) : base(table.TableName)
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

            public void AddPC1TmpOCConfPendRow(DataTmpOCConfPend.PC1TmpOCConfPendRow row)
            {
                this.Rows.Add(row);
            }

            public DataTmpOCConfPend.PC1TmpOCConfPendRow AddPC1TmpOCConfPendRow(string CodProv, string NomProv, string NroOC, DateTime FechaOC, DateTime FEntSolic, DateTime FEntConf, string Codigo, string Descripcion, decimal Cantidad, string FormaDesp, string Destinatario, string EnTransito)
            {
                DataTmpOCConfPend.PC1TmpOCConfPendRow row = (DataTmpOCConfPend.PC1TmpOCConfPendRow) this.NewRow();
                row.ItemArray = new object[] { CodProv, NomProv, NroOC, FechaOC, FEntSolic, FEntConf, Codigo, Descripcion, Cantidad, FormaDesp, Destinatario, EnTransito };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataTmpOCConfPend.PC1TmpOCConfPendDataTable table = (DataTmpOCConfPend.PC1TmpOCConfPendDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataTmpOCConfPend.PC1TmpOCConfPendDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataTmpOCConfPend.PC1TmpOCConfPendRow);
            }

            private void InitClass()
            {
                this.columnCodProv = new DataColumn("CodProv", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodProv);
                this.columnNomProv = new DataColumn("NomProv", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNomProv);
                this.columnNroOC = new DataColumn("NroOC", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOC);
                this.columnFechaOC = new DataColumn("FechaOC", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaOC);
                this.columnFEntSolic = new DataColumn("FEntSolic", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFEntSolic);
                this.columnFEntConf = new DataColumn("FEntConf", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFEntConf);
                this.columnCodigo = new DataColumn("Codigo", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodigo);
                this.columnDescripcion = new DataColumn("Descripcion", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDescripcion);
                this.columnCantidad = new DataColumn("Cantidad", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantidad);
                this.columnFormaDesp = new DataColumn("FormaDesp", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnFormaDesp);
                this.columnDestinatario = new DataColumn("Destinatario", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDestinatario);
                this.columnEnTransito = new DataColumn("EnTransito", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnEnTransito);
                this.columnCodProv.AllowDBNull = false;
                this.columnNomProv.AllowDBNull = false;
                this.columnNroOC.AllowDBNull = false;
                this.columnFechaOC.AllowDBNull = false;
                this.columnFEntSolic.AllowDBNull = false;
                this.columnCodigo.AllowDBNull = false;
                this.columnCantidad.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnCodProv = this.Columns["CodProv"];
                this.columnNomProv = this.Columns["NomProv"];
                this.columnNroOC = this.Columns["NroOC"];
                this.columnFechaOC = this.Columns["FechaOC"];
                this.columnFEntSolic = this.Columns["FEntSolic"];
                this.columnFEntConf = this.Columns["FEntConf"];
                this.columnCodigo = this.Columns["Codigo"];
                this.columnDescripcion = this.Columns["Descripcion"];
                this.columnCantidad = this.Columns["Cantidad"];
                this.columnFormaDesp = this.Columns["FormaDesp"];
                this.columnDestinatario = this.Columns["Destinatario"];
                this.columnEnTransito = this.Columns["EnTransito"];
            }

            public DataTmpOCConfPend.PC1TmpOCConfPendRow NewPC1TmpOCConfPendRow()
            {
                return (DataTmpOCConfPend.PC1TmpOCConfPendRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataTmpOCConfPend.PC1TmpOCConfPendRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpOCConfPendRowChangedEvent != null) && (this.PC1TmpOCConfPendRowChangedEvent != null))
                {
                    this.PC1TmpOCConfPendRowChangedEvent(this, new DataTmpOCConfPend.PC1TmpOCConfPendRowChangeEvent((DataTmpOCConfPend.PC1TmpOCConfPendRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpOCConfPendRowChangingEvent != null) && (this.PC1TmpOCConfPendRowChangingEvent != null))
                {
                    this.PC1TmpOCConfPendRowChangingEvent(this, new DataTmpOCConfPend.PC1TmpOCConfPendRowChangeEvent((DataTmpOCConfPend.PC1TmpOCConfPendRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpOCConfPendRowDeletedEvent != null) && (this.PC1TmpOCConfPendRowDeletedEvent != null))
                {
                    this.PC1TmpOCConfPendRowDeletedEvent(this, new DataTmpOCConfPend.PC1TmpOCConfPendRowChangeEvent((DataTmpOCConfPend.PC1TmpOCConfPendRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpOCConfPendRowDeletingEvent != null) && (this.PC1TmpOCConfPendRowDeletingEvent != null))
                {
                    this.PC1TmpOCConfPendRowDeletingEvent(this, new DataTmpOCConfPend.PC1TmpOCConfPendRowChangeEvent((DataTmpOCConfPend.PC1TmpOCConfPendRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpOCConfPendRow(DataTmpOCConfPend.PC1TmpOCConfPendRow row)
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

            internal DataColumn DescripcionColumn
            {
                get
                {
                    return this.columnDescripcion;
                }
            }

            internal DataColumn DestinatarioColumn
            {
                get
                {
                    return this.columnDestinatario;
                }
            }

            internal DataColumn EnTransitoColumn
            {
                get
                {
                    return this.columnEnTransito;
                }
            }

            internal DataColumn FechaOCColumn
            {
                get
                {
                    return this.columnFechaOC;
                }
            }

            internal DataColumn FEntConfColumn
            {
                get
                {
                    return this.columnFEntConf;
                }
            }

            internal DataColumn FEntSolicColumn
            {
                get
                {
                    return this.columnFEntSolic;
                }
            }

            internal DataColumn FormaDespColumn
            {
                get
                {
                    return this.columnFormaDesp;
                }
            }

            public DataTmpOCConfPend.PC1TmpOCConfPendRow this[int index]
            {
                get
                {
                    return (DataTmpOCConfPend.PC1TmpOCConfPendRow) this.Rows[index];
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
        public class PC1TmpOCConfPendRow : DataRow
        {
            private DataTmpOCConfPend.PC1TmpOCConfPendDataTable tablePC1TmpOCConfPend;

            internal PC1TmpOCConfPendRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpOCConfPend = (DataTmpOCConfPend.PC1TmpOCConfPendDataTable) this.Table;
            }

            public bool IsDescripcionNull()
            {
                return this.IsNull(this.tablePC1TmpOCConfPend.DescripcionColumn);
            }

            public bool IsDestinatarioNull()
            {
                return this.IsNull(this.tablePC1TmpOCConfPend.DestinatarioColumn);
            }

            public bool IsEnTransitoNull()
            {
                return this.IsNull(this.tablePC1TmpOCConfPend.EnTransitoColumn);
            }

            public bool IsFEntConfNull()
            {
                return this.IsNull(this.tablePC1TmpOCConfPend.FEntConfColumn);
            }

            public bool IsFormaDespNull()
            {
                return this.IsNull(this.tablePC1TmpOCConfPend.FormaDespColumn);
            }

            public void SetDescripcionNull()
            {
                this[this.tablePC1TmpOCConfPend.DescripcionColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDestinatarioNull()
            {
                this[this.tablePC1TmpOCConfPend.DestinatarioColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetEnTransitoNull()
            {
                this[this.tablePC1TmpOCConfPend.EnTransitoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFEntConfNull()
            {
                this[this.tablePC1TmpOCConfPend.FEntConfColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFormaDespNull()
            {
                this[this.tablePC1TmpOCConfPend.FormaDespColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal Cantidad
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOCConfPend.CantidadColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCConfPend.CantidadColumn] = value;
                }
            }

            public string Codigo
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCConfPend.CodigoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCConfPend.CodigoColumn] = value;
                }
            }

            public string CodProv
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCConfPend.CodProvColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCConfPend.CodProvColumn] = value;
                }
            }

            public string Descripcion
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpOCConfPend.DescripcionColumn]);
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
                    this[this.tablePC1TmpOCConfPend.DescripcionColumn] = value;
                }
            }

            public string Destinatario
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpOCConfPend.DestinatarioColumn]);
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
                    this[this.tablePC1TmpOCConfPend.DestinatarioColumn] = value;
                }
            }

            public string EnTransito
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpOCConfPend.EnTransitoColumn]);
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
                    this[this.tablePC1TmpOCConfPend.EnTransitoColumn] = value;
                }
            }

            public DateTime FechaOC
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpOCConfPend.FechaOCColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCConfPend.FechaOCColumn] = value;
                }
            }

            public DateTime FEntConf
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = DateType.FromObject(this[this.tablePC1TmpOCConfPend.FEntConfColumn]);
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
                    this[this.tablePC1TmpOCConfPend.FEntConfColumn] = value;
                }
            }

            public DateTime FEntSolic
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpOCConfPend.FEntSolicColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCConfPend.FEntSolicColumn] = value;
                }
            }

            public string FormaDesp
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpOCConfPend.FormaDespColumn]);
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
                    this[this.tablePC1TmpOCConfPend.FormaDespColumn] = value;
                }
            }

            public string NomProv
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCConfPend.NomProvColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCConfPend.NomProvColumn] = value;
                }
            }

            public string NroOC
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCConfPend.NroOCColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCConfPend.NroOCColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpOCConfPendRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataTmpOCConfPend.PC1TmpOCConfPendRow eventRow;

            public PC1TmpOCConfPendRowChangeEvent(DataTmpOCConfPend.PC1TmpOCConfPendRow row, DataRowAction action)
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

            public DataTmpOCConfPend.PC1TmpOCConfPendRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpOCConfPendRowChangeEventHandler(object sender, DataTmpOCConfPend.PC1TmpOCConfPendRowChangeEvent e);
    }
}

