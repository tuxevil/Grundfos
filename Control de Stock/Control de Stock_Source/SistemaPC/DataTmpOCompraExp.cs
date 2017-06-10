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
    public class DataTmpOCompraExp : DataSet
    {
        private PC1TmpOCompraExpDataTable tablePC1TmpOCompraExp;

        public DataTmpOCompraExp()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DataTmpOCompraExp(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["PC1TmpOCompraExp"] != null)
                {
                    this.Tables.Add(new PC1TmpOCompraExpDataTable(dataSet.Tables["PC1TmpOCompraExp"]));
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
            DataTmpOCompraExp exp = (DataTmpOCompraExp) base.Clone();
            exp.InitVars();
            return exp;
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
            this.DataSetName = "DataTmpOCompraExp";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DataTmpOCompraExp.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tablePC1TmpOCompraExp = new PC1TmpOCompraExpDataTable();
            this.Tables.Add(this.tablePC1TmpOCompraExp);
        }

        internal void InitVars()
        {
            this.tablePC1TmpOCompraExp = (PC1TmpOCompraExpDataTable) this.Tables["PC1TmpOCompraExp"];
            if (this.tablePC1TmpOCompraExp != null)
            {
                this.tablePC1TmpOCompraExp.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["PC1TmpOCompraExp"] != null)
            {
                this.Tables.Add(new PC1TmpOCompraExpDataTable(dataSet.Tables["PC1TmpOCompraExp"]));
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

        private bool ShouldSerializePC1TmpOCompraExp()
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
        public PC1TmpOCompraExpDataTable PC1TmpOCompraExp
        {
            get
            {
                return this.tablePC1TmpOCompraExp;
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpOCompraExpDataTable : DataTable, IEnumerable
        {
            private DataColumn columnCantidadOV;
            private DataColumn columnCodigo;
            private DataColumn columnCodProv;
            private DataColumn columnDescripcion;
            private DataColumn columnNomProv;
            private DataColumn columnNroLinea;
            private DataColumn columnSeleccion;

            public event DataTmpOCompraExp.PC1TmpOCompraExpRowChangeEventHandler PC1TmpOCompraExpRowChanged;

            public event DataTmpOCompraExp.PC1TmpOCompraExpRowChangeEventHandler PC1TmpOCompraExpRowChanging;

            public event DataTmpOCompraExp.PC1TmpOCompraExpRowChangeEventHandler PC1TmpOCompraExpRowDeleted;

            public event DataTmpOCompraExp.PC1TmpOCompraExpRowChangeEventHandler PC1TmpOCompraExpRowDeleting;

            internal PC1TmpOCompraExpDataTable() : base("PC1TmpOCompraExp")
            {
                this.InitClass();
            }

            internal PC1TmpOCompraExpDataTable(DataTable table) : base(table.TableName)
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

            public void AddPC1TmpOCompraExpRow(DataTmpOCompraExp.PC1TmpOCompraExpRow row)
            {
                this.Rows.Add(row);
            }

            public DataTmpOCompraExp.PC1TmpOCompraExpRow AddPC1TmpOCompraExpRow(string NroLinea, string Codigo, string Descripcion, decimal CantidadOV, string CodProv, string NomProv, bool Seleccion)
            {
                DataTmpOCompraExp.PC1TmpOCompraExpRow row = (DataTmpOCompraExp.PC1TmpOCompraExpRow) this.NewRow();
                row.ItemArray = new object[] { NroLinea, Codigo, Descripcion, CantidadOV, CodProv, NomProv, Seleccion };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataTmpOCompraExp.PC1TmpOCompraExpDataTable table = (DataTmpOCompraExp.PC1TmpOCompraExpDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataTmpOCompraExp.PC1TmpOCompraExpDataTable();
            }

            public DataTmpOCompraExp.PC1TmpOCompraExpRow FindByCodigo(string Codigo)
            {
                return (DataTmpOCompraExp.PC1TmpOCompraExpRow) this.Rows.Find(new object[] { Codigo });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataTmpOCompraExp.PC1TmpOCompraExpRow);
            }

            private void InitClass()
            {
                this.columnNroLinea = new DataColumn("NroLinea", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroLinea);
                this.columnCodigo = new DataColumn("Codigo", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodigo);
                this.columnDescripcion = new DataColumn("Descripcion", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDescripcion);
                this.columnCantidadOV = new DataColumn("CantidadOV", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantidadOV);
                this.columnCodProv = new DataColumn("CodProv", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodProv);
                this.columnNomProv = new DataColumn("NomProv", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNomProv);
                this.columnSeleccion = new DataColumn("Seleccion", typeof(bool), null, MappingType.Element);
                this.Columns.Add(this.columnSeleccion);
                this.Constraints.Add(new UniqueConstraint("DataTmpOCompraExpKey1", new DataColumn[] { this.columnCodigo }, true));
                this.columnNroLinea.AllowDBNull = false;
                this.columnCodigo.AllowDBNull = false;
                this.columnCodigo.Unique = true;
                this.columnCantidadOV.AllowDBNull = false;
                this.columnCodProv.AllowDBNull = false;
                this.columnNomProv.AllowDBNull = false;
                this.columnSeleccion.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnNroLinea = this.Columns["NroLinea"];
                this.columnCodigo = this.Columns["Codigo"];
                this.columnDescripcion = this.Columns["Descripcion"];
                this.columnCantidadOV = this.Columns["CantidadOV"];
                this.columnCodProv = this.Columns["CodProv"];
                this.columnNomProv = this.Columns["NomProv"];
                this.columnSeleccion = this.Columns["Seleccion"];
            }

            public DataTmpOCompraExp.PC1TmpOCompraExpRow NewPC1TmpOCompraExpRow()
            {
                return (DataTmpOCompraExp.PC1TmpOCompraExpRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataTmpOCompraExp.PC1TmpOCompraExpRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpOCompraExpRowChangedEvent != null) && (this.PC1TmpOCompraExpRowChangedEvent != null))
                {
                    this.PC1TmpOCompraExpRowChangedEvent(this, new DataTmpOCompraExp.PC1TmpOCompraExpRowChangeEvent((DataTmpOCompraExp.PC1TmpOCompraExpRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpOCompraExpRowChangingEvent != null) && (this.PC1TmpOCompraExpRowChangingEvent != null))
                {
                    this.PC1TmpOCompraExpRowChangingEvent(this, new DataTmpOCompraExp.PC1TmpOCompraExpRowChangeEvent((DataTmpOCompraExp.PC1TmpOCompraExpRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpOCompraExpRowDeletedEvent != null) && (this.PC1TmpOCompraExpRowDeletedEvent != null))
                {
                    this.PC1TmpOCompraExpRowDeletedEvent(this, new DataTmpOCompraExp.PC1TmpOCompraExpRowChangeEvent((DataTmpOCompraExp.PC1TmpOCompraExpRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpOCompraExpRowDeletingEvent != null) && (this.PC1TmpOCompraExpRowDeletingEvent != null))
                {
                    this.PC1TmpOCompraExpRowDeletingEvent(this, new DataTmpOCompraExp.PC1TmpOCompraExpRowChangeEvent((DataTmpOCompraExp.PC1TmpOCompraExpRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpOCompraExpRow(DataTmpOCompraExp.PC1TmpOCompraExpRow row)
            {
                this.Rows.Remove(row);
            }

            internal DataColumn CantidadOVColumn
            {
                get
                {
                    return this.columnCantidadOV;
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

            public DataTmpOCompraExp.PC1TmpOCompraExpRow this[int index]
            {
                get
                {
                    return (DataTmpOCompraExp.PC1TmpOCompraExpRow) this.Rows[index];
                }
            }

            internal DataColumn NomProvColumn
            {
                get
                {
                    return this.columnNomProv;
                }
            }

            internal DataColumn NroLineaColumn
            {
                get
                {
                    return this.columnNroLinea;
                }
            }

            internal DataColumn SeleccionColumn
            {
                get
                {
                    return this.columnSeleccion;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpOCompraExpRow : DataRow
        {
            private DataTmpOCompraExp.PC1TmpOCompraExpDataTable tablePC1TmpOCompraExp;

            internal PC1TmpOCompraExpRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpOCompraExp = (DataTmpOCompraExp.PC1TmpOCompraExpDataTable) this.Table;
            }

            public bool IsDescripcionNull()
            {
                return this.IsNull(this.tablePC1TmpOCompraExp.DescripcionColumn);
            }

            public void SetDescripcionNull()
            {
                this[this.tablePC1TmpOCompraExp.DescripcionColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal CantidadOV
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOCompraExp.CantidadOVColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompraExp.CantidadOVColumn] = value;
                }
            }

            public string Codigo
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCompraExp.CodigoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompraExp.CodigoColumn] = value;
                }
            }

            public string CodProv
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCompraExp.CodProvColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompraExp.CodProvColumn] = value;
                }
            }

            public string Descripcion
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpOCompraExp.DescripcionColumn]);
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
                    this[this.tablePC1TmpOCompraExp.DescripcionColumn] = value;
                }
            }

            public string NomProv
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCompraExp.NomProvColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompraExp.NomProvColumn] = value;
                }
            }

            public string NroLinea
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCompraExp.NroLineaColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompraExp.NroLineaColumn] = value;
                }
            }

            public bool Seleccion
            {
                get
                {
                    return BooleanType.FromObject(this[this.tablePC1TmpOCompraExp.SeleccionColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompraExp.SeleccionColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpOCompraExpRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataTmpOCompraExp.PC1TmpOCompraExpRow eventRow;

            public PC1TmpOCompraExpRowChangeEvent(DataTmpOCompraExp.PC1TmpOCompraExpRow row, DataRowAction action)
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

            public DataTmpOCompraExp.PC1TmpOCompraExpRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpOCompraExpRowChangeEventHandler(object sender, DataTmpOCompraExp.PC1TmpOCompraExpRowChangeEvent e);
    }
}

