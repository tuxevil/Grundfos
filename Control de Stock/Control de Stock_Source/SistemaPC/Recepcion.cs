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
    public class Recepcion : DataSet
    {
        private RecepcionDataTable tableRecepcion;

        public Recepcion()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected Recepcion(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["Recepcion"] != null)
                {
                    this.Tables.Add(new RecepcionDataTable(dataSet.Tables["Recepcion"]));
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
            SistemaPC.Recepcion recepcion = (SistemaPC.Recepcion) base.Clone();
            recepcion.InitVars();
            return recepcion;
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
            this.DataSetName = "Recepcion";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/Recepcion.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableRecepcion = new RecepcionDataTable();
            this.Tables.Add(this.tableRecepcion);
        }

        internal void InitVars()
        {
            this.tableRecepcion = (RecepcionDataTable) this.Tables["Recepcion"];
            if (this.tableRecepcion != null)
            {
                this.tableRecepcion.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["Recepcion"] != null)
            {
                this.Tables.Add(new RecepcionDataTable(dataSet.Tables["Recepcion"]));
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

        private bool ShouldSerializeRecepcion()
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
        public RecepcionDataTable Recepcion
        {
            get
            {
                return this.tableRecepcion;
            }
        }

        [DebuggerStepThrough]
        public class RecepcionDataTable : DataTable, IEnumerable
        {
            private DataColumn columnAceptar;
            private DataColumn columnCantPend;
            private DataColumn columnCantRec;
            private DataColumn columnCodigo;
            private DataColumn columnDesc1;
            private DataColumn columnDesc2;
            private DataColumn columnFechaRec;
            private DataColumn columnID;
            private DataColumn columnNroBulto;
            private DataColumn columnNroLinea;
            private DataColumn columnNroOC;
            private DataColumn columnRechazar;
            private DataColumn columnRevisado;

            public event Recepcion.RecepcionRowChangeEventHandler RecepcionRowChanged;

            public event Recepcion.RecepcionRowChangeEventHandler RecepcionRowChanging;

            public event Recepcion.RecepcionRowChangeEventHandler RecepcionRowDeleted;

            public event Recepcion.RecepcionRowChangeEventHandler RecepcionRowDeleting;

            internal RecepcionDataTable() : base("Recepcion")
            {
                this.InitClass();
            }

            internal RecepcionDataTable(DataTable table) : base(table.TableName)
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

            public void AddRecepcionRow(Recepcion.RecepcionRow row)
            {
                this.Rows.Add(row);
            }

            public Recepcion.RecepcionRow AddRecepcionRow(string NroBulto, string NroOC, string NroLinea, string Codigo, string Desc1, string Desc2, decimal CantPend, decimal CantRec, DateTime FechaRec, bool Revisado, bool Rechazar, bool Aceptar)
            {
                Recepcion.RecepcionRow row = (Recepcion.RecepcionRow) this.NewRow();
                row.ItemArray = new object[] { null, NroBulto, NroOC, NroLinea, Codigo, Desc1, Desc2, CantPend, CantRec, FechaRec, Revisado, Rechazar, Aceptar };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                Recepcion.RecepcionDataTable table = (Recepcion.RecepcionDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new Recepcion.RecepcionDataTable();
            }

            public Recepcion.RecepcionRow FindByID(decimal ID)
            {
                return (Recepcion.RecepcionRow) this.Rows.Find(new object[] { ID });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(Recepcion.RecepcionRow);
            }

            private void InitClass()
            {
                this.columnID = new DataColumn("ID", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnID);
                this.columnNroBulto = new DataColumn("NroBulto", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroBulto);
                this.columnNroOC = new DataColumn("NroOC", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOC);
                this.columnNroLinea = new DataColumn("NroLinea", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroLinea);
                this.columnCodigo = new DataColumn("Codigo", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodigo);
                this.columnDesc1 = new DataColumn("Desc1", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDesc1);
                this.columnDesc2 = new DataColumn("Desc2", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDesc2);
                this.columnCantPend = new DataColumn("CantPend", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantPend);
                this.columnCantRec = new DataColumn("CantRec", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantRec);
                this.columnFechaRec = new DataColumn("FechaRec", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaRec);
                this.columnRevisado = new DataColumn("Revisado", typeof(bool), null, MappingType.Element);
                this.Columns.Add(this.columnRevisado);
                this.columnRechazar = new DataColumn("Rechazar", typeof(bool), null, MappingType.Element);
                this.Columns.Add(this.columnRechazar);
                this.columnAceptar = new DataColumn("Aceptar", typeof(bool), null, MappingType.Element);
                this.Columns.Add(this.columnAceptar);
                this.Constraints.Add(new UniqueConstraint("RecepcionKey1", new DataColumn[] { this.columnID }, true));
                this.columnID.AutoIncrement = true;
                this.columnID.AllowDBNull = false;
                this.columnID.ReadOnly = true;
                this.columnID.Unique = true;
                this.columnNroBulto.AllowDBNull = false;
                this.columnNroOC.AllowDBNull = false;
                this.columnCodigo.AllowDBNull = false;
                this.columnCantRec.AllowDBNull = false;
                this.columnFechaRec.AllowDBNull = false;
                this.columnRevisado.AllowDBNull = false;
                this.columnRechazar.AllowDBNull = false;
                this.columnAceptar.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnID = this.Columns["ID"];
                this.columnNroBulto = this.Columns["NroBulto"];
                this.columnNroOC = this.Columns["NroOC"];
                this.columnNroLinea = this.Columns["NroLinea"];
                this.columnCodigo = this.Columns["Codigo"];
                this.columnDesc1 = this.Columns["Desc1"];
                this.columnDesc2 = this.Columns["Desc2"];
                this.columnCantPend = this.Columns["CantPend"];
                this.columnCantRec = this.Columns["CantRec"];
                this.columnFechaRec = this.Columns["FechaRec"];
                this.columnRevisado = this.Columns["Revisado"];
                this.columnRechazar = this.Columns["Rechazar"];
                this.columnAceptar = this.Columns["Aceptar"];
            }

            public Recepcion.RecepcionRow NewRecepcionRow()
            {
                return (Recepcion.RecepcionRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new Recepcion.RecepcionRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.RecepcionRowChangedEvent != null) && (this.RecepcionRowChangedEvent != null))
                {
                    this.RecepcionRowChangedEvent(this, new Recepcion.RecepcionRowChangeEvent((Recepcion.RecepcionRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.RecepcionRowChangingEvent != null) && (this.RecepcionRowChangingEvent != null))
                {
                    this.RecepcionRowChangingEvent(this, new Recepcion.RecepcionRowChangeEvent((Recepcion.RecepcionRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.RecepcionRowDeletedEvent != null) && (this.RecepcionRowDeletedEvent != null))
                {
                    this.RecepcionRowDeletedEvent(this, new Recepcion.RecepcionRowChangeEvent((Recepcion.RecepcionRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.RecepcionRowDeletingEvent != null) && (this.RecepcionRowDeletingEvent != null))
                {
                    this.RecepcionRowDeletingEvent(this, new Recepcion.RecepcionRowChangeEvent((Recepcion.RecepcionRow) e.Row, e.Action));
                }
            }

            public void RemoveRecepcionRow(Recepcion.RecepcionRow row)
            {
                this.Rows.Remove(row);
            }

            internal DataColumn AceptarColumn
            {
                get
                {
                    return this.columnAceptar;
                }
            }

            internal DataColumn CantPendColumn
            {
                get
                {
                    return this.columnCantPend;
                }
            }

            internal DataColumn CantRecColumn
            {
                get
                {
                    return this.columnCantRec;
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

            internal DataColumn FechaRecColumn
            {
                get
                {
                    return this.columnFechaRec;
                }
            }

            internal DataColumn IDColumn
            {
                get
                {
                    return this.columnID;
                }
            }

            public Recepcion.RecepcionRow this[int index]
            {
                get
                {
                    return (Recepcion.RecepcionRow) this.Rows[index];
                }
            }

            internal DataColumn NroBultoColumn
            {
                get
                {
                    return this.columnNroBulto;
                }
            }

            internal DataColumn NroLineaColumn
            {
                get
                {
                    return this.columnNroLinea;
                }
            }

            internal DataColumn NroOCColumn
            {
                get
                {
                    return this.columnNroOC;
                }
            }

            internal DataColumn RechazarColumn
            {
                get
                {
                    return this.columnRechazar;
                }
            }

            internal DataColumn RevisadoColumn
            {
                get
                {
                    return this.columnRevisado;
                }
            }
        }

        [DebuggerStepThrough]
        public class RecepcionRow : DataRow
        {
            private Recepcion.RecepcionDataTable tableRecepcion;

            internal RecepcionRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRecepcion = (Recepcion.RecepcionDataTable) this.Table;
            }

            public bool IsCantPendNull()
            {
                return this.IsNull(this.tableRecepcion.CantPendColumn);
            }

            public bool IsDesc1Null()
            {
                return this.IsNull(this.tableRecepcion.Desc1Column);
            }

            public bool IsDesc2Null()
            {
                return this.IsNull(this.tableRecepcion.Desc2Column);
            }

            public bool IsNroLineaNull()
            {
                return this.IsNull(this.tableRecepcion.NroLineaColumn);
            }

            public void SetCantPendNull()
            {
                this[this.tableRecepcion.CantPendColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDesc1Null()
            {
                this[this.tableRecepcion.Desc1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDesc2Null()
            {
                this[this.tableRecepcion.Desc2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNroLineaNull()
            {
                this[this.tableRecepcion.NroLineaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public bool Aceptar
            {
                get
                {
                    return BooleanType.FromObject(this[this.tableRecepcion.AceptarColumn]);
                }
                set
                {
                    this[this.tableRecepcion.AceptarColumn] = value;
                }
            }

            public decimal CantPend
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tableRecepcion.CantPendColumn]);
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
                    this[this.tableRecepcion.CantPendColumn] = value;
                }
            }

            public decimal CantRec
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableRecepcion.CantRecColumn]);
                }
                set
                {
                    this[this.tableRecepcion.CantRecColumn] = value;
                }
            }

            public string Codigo
            {
                get
                {
                    return StringType.FromObject(this[this.tableRecepcion.CodigoColumn]);
                }
                set
                {
                    this[this.tableRecepcion.CodigoColumn] = value;
                }
            }

            public string Desc1
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tableRecepcion.Desc1Column]);
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
                    this[this.tableRecepcion.Desc1Column] = value;
                }
            }

            public string Desc2
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tableRecepcion.Desc2Column]);
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
                    this[this.tableRecepcion.Desc2Column] = value;
                }
            }

            public DateTime FechaRec
            {
                get
                {
                    return DateType.FromObject(this[this.tableRecepcion.FechaRecColumn]);
                }
                set
                {
                    this[this.tableRecepcion.FechaRecColumn] = value;
                }
            }

            public decimal ID
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableRecepcion.IDColumn]);
                }
                set
                {
                    this[this.tableRecepcion.IDColumn] = value;
                }
            }

            public string NroBulto
            {
                get
                {
                    return StringType.FromObject(this[this.tableRecepcion.NroBultoColumn]);
                }
                set
                {
                    this[this.tableRecepcion.NroBultoColumn] = value;
                }
            }

            public string NroLinea
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tableRecepcion.NroLineaColumn]);
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
                    this[this.tableRecepcion.NroLineaColumn] = value;
                }
            }

            public string NroOC
            {
                get
                {
                    return StringType.FromObject(this[this.tableRecepcion.NroOCColumn]);
                }
                set
                {
                    this[this.tableRecepcion.NroOCColumn] = value;
                }
            }

            public bool Rechazar
            {
                get
                {
                    return BooleanType.FromObject(this[this.tableRecepcion.RechazarColumn]);
                }
                set
                {
                    this[this.tableRecepcion.RechazarColumn] = value;
                }
            }

            public bool Revisado
            {
                get
                {
                    return BooleanType.FromObject(this[this.tableRecepcion.RevisadoColumn]);
                }
                set
                {
                    this[this.tableRecepcion.RevisadoColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class RecepcionRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private Recepcion.RecepcionRow eventRow;

            public RecepcionRowChangeEvent(Recepcion.RecepcionRow row, DataRowAction action)
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

            public Recepcion.RecepcionRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RecepcionRowChangeEventHandler(object sender, Recepcion.RecepcionRowChangeEvent e);
    }
}

