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
    public class DSDifInv : DataSet
    {
        private PC1TmpInventarioDataTable tablePC1TmpInventario;
        private RepDifInvDataTable tableRepDifInv;

        public DSDifInv()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DSDifInv(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["RepDifInv"] != null)
                {
                    this.Tables.Add(new RepDifInvDataTable(dataSet.Tables["RepDifInv"]));
                }
                if (dataSet.Tables["PC1TmpInventario"] != null)
                {
                    this.Tables.Add(new PC1TmpInventarioDataTable(dataSet.Tables["PC1TmpInventario"]));
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
            DSDifInv inv = (DSDifInv) base.Clone();
            inv.InitVars();
            return inv;
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
            this.DataSetName = "DSDifInv";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DSDifInv.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableRepDifInv = new RepDifInvDataTable();
            this.Tables.Add(this.tableRepDifInv);
            this.tablePC1TmpInventario = new PC1TmpInventarioDataTable();
            this.Tables.Add(this.tablePC1TmpInventario);
        }

        internal void InitVars()
        {
            this.tableRepDifInv = (RepDifInvDataTable) this.Tables["RepDifInv"];
            if (this.tableRepDifInv != null)
            {
                this.tableRepDifInv.InitVars();
            }
            this.tablePC1TmpInventario = (PC1TmpInventarioDataTable) this.Tables["PC1TmpInventario"];
            if (this.tablePC1TmpInventario != null)
            {
                this.tablePC1TmpInventario.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["RepDifInv"] != null)
            {
                this.Tables.Add(new RepDifInvDataTable(dataSet.Tables["RepDifInv"]));
            }
            if (dataSet.Tables["PC1TmpInventario"] != null)
            {
                this.Tables.Add(new PC1TmpInventarioDataTable(dataSet.Tables["PC1TmpInventario"]));
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

        private bool ShouldSerializePC1TmpInventario()
        {
            return false;
        }

        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        private bool ShouldSerializeRepDifInv()
        {
            return false;
        }

        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public PC1TmpInventarioDataTable PC1TmpInventario
        {
            get
            {
                return this.tablePC1TmpInventario;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public RepDifInvDataTable RepDifInv
        {
            get
            {
                return this.tableRepDifInv;
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpInventarioDataTable : DataTable, IEnumerable
        {
            private DataColumn columnAceptar;
            private DataColumn columnAlmacen;
            private DataColumn columnCantidad;
            private DataColumn columnCantSist;
            private DataColumn columnCodigo;
            private DataColumn columnDesc1;
            private DataColumn columnDesc2;
            private DataColumn columnPosicion;
            private DataColumn columnPosSist;
            private DataColumn columnRechazar;

            public event DSDifInv.PC1TmpInventarioRowChangeEventHandler PC1TmpInventarioRowChanged;

            public event DSDifInv.PC1TmpInventarioRowChangeEventHandler PC1TmpInventarioRowChanging;

            public event DSDifInv.PC1TmpInventarioRowChangeEventHandler PC1TmpInventarioRowDeleted;

            public event DSDifInv.PC1TmpInventarioRowChangeEventHandler PC1TmpInventarioRowDeleting;

            internal PC1TmpInventarioDataTable() : base("PC1TmpInventario")
            {
                this.InitClass();
            }

            internal PC1TmpInventarioDataTable(DataTable table) : base(table.TableName)
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

            public void AddPC1TmpInventarioRow(DSDifInv.PC1TmpInventarioRow row)
            {
                this.Rows.Add(row);
            }

            public DSDifInv.PC1TmpInventarioRow AddPC1TmpInventarioRow(string Almacen, string Posicion, string Codigo, string Desc1, string Desc2, decimal Cantidad, string PosSist, decimal CantSist, bool Aceptar, bool Rechazar)
            {
                DSDifInv.PC1TmpInventarioRow row = (DSDifInv.PC1TmpInventarioRow) this.NewRow();
                row.ItemArray = new object[] { Almacen, Posicion, Codigo, Desc1, Desc2, Cantidad, PosSist, CantSist, Aceptar, Rechazar };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DSDifInv.PC1TmpInventarioDataTable table = (DSDifInv.PC1TmpInventarioDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DSDifInv.PC1TmpInventarioDataTable();
            }

            public DSDifInv.PC1TmpInventarioRow FindByAlmacenPosicionCodigo(string Almacen, string Posicion, string Codigo)
            {
                return (DSDifInv.PC1TmpInventarioRow) this.Rows.Find(new object[] { Almacen, Posicion, Codigo });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DSDifInv.PC1TmpInventarioRow);
            }

            private void InitClass()
            {
                this.columnAlmacen = new DataColumn("Almacen", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnAlmacen);
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
                this.columnPosSist = new DataColumn("PosSist", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPosSist);
                this.columnCantSist = new DataColumn("CantSist", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantSist);
                this.columnAceptar = new DataColumn("Aceptar", typeof(bool), null, MappingType.Element);
                this.Columns.Add(this.columnAceptar);
                this.columnRechazar = new DataColumn("Rechazar", typeof(bool), null, MappingType.Element);
                this.Columns.Add(this.columnRechazar);
                this.Constraints.Add(new UniqueConstraint("DSDifInvKey1", new DataColumn[] { this.columnAlmacen, this.columnPosicion, this.columnCodigo }, true));
                this.columnAlmacen.AllowDBNull = false;
                this.columnPosicion.AllowDBNull = false;
                this.columnCodigo.AllowDBNull = false;
                this.columnCantidad.AllowDBNull = false;
                this.columnPosSist.AllowDBNull = false;
                this.columnAceptar.AllowDBNull = false;
                this.columnRechazar.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnAlmacen = this.Columns["Almacen"];
                this.columnPosicion = this.Columns["Posicion"];
                this.columnCodigo = this.Columns["Codigo"];
                this.columnDesc1 = this.Columns["Desc1"];
                this.columnDesc2 = this.Columns["Desc2"];
                this.columnCantidad = this.Columns["Cantidad"];
                this.columnPosSist = this.Columns["PosSist"];
                this.columnCantSist = this.Columns["CantSist"];
                this.columnAceptar = this.Columns["Aceptar"];
                this.columnRechazar = this.Columns["Rechazar"];
            }

            public DSDifInv.PC1TmpInventarioRow NewPC1TmpInventarioRow()
            {
                return (DSDifInv.PC1TmpInventarioRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DSDifInv.PC1TmpInventarioRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpInventarioRowChangedEvent != null) && (this.PC1TmpInventarioRowChangedEvent != null))
                {
                    this.PC1TmpInventarioRowChangedEvent(this, new DSDifInv.PC1TmpInventarioRowChangeEvent((DSDifInv.PC1TmpInventarioRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpInventarioRowChangingEvent != null) && (this.PC1TmpInventarioRowChangingEvent != null))
                {
                    this.PC1TmpInventarioRowChangingEvent(this, new DSDifInv.PC1TmpInventarioRowChangeEvent((DSDifInv.PC1TmpInventarioRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpInventarioRowDeletedEvent != null) && (this.PC1TmpInventarioRowDeletedEvent != null))
                {
                    this.PC1TmpInventarioRowDeletedEvent(this, new DSDifInv.PC1TmpInventarioRowChangeEvent((DSDifInv.PC1TmpInventarioRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpInventarioRowDeletingEvent != null) && (this.PC1TmpInventarioRowDeletingEvent != null))
                {
                    this.PC1TmpInventarioRowDeletingEvent(this, new DSDifInv.PC1TmpInventarioRowChangeEvent((DSDifInv.PC1TmpInventarioRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpInventarioRow(DSDifInv.PC1TmpInventarioRow row)
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

            internal DataColumn AlmacenColumn
            {
                get
                {
                    return this.columnAlmacen;
                }
            }

            internal DataColumn CantidadColumn
            {
                get
                {
                    return this.columnCantidad;
                }
            }

            internal DataColumn CantSistColumn
            {
                get
                {
                    return this.columnCantSist;
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

            public DSDifInv.PC1TmpInventarioRow this[int index]
            {
                get
                {
                    return (DSDifInv.PC1TmpInventarioRow) this.Rows[index];
                }
            }

            internal DataColumn PosicionColumn
            {
                get
                {
                    return this.columnPosicion;
                }
            }

            internal DataColumn PosSistColumn
            {
                get
                {
                    return this.columnPosSist;
                }
            }

            internal DataColumn RechazarColumn
            {
                get
                {
                    return this.columnRechazar;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpInventarioRow : DataRow
        {
            private DSDifInv.PC1TmpInventarioDataTable tablePC1TmpInventario;

            internal PC1TmpInventarioRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpInventario = (DSDifInv.PC1TmpInventarioDataTable) this.Table;
            }

            public bool IsCantSistNull()
            {
                return this.IsNull(this.tablePC1TmpInventario.CantSistColumn);
            }

            public bool IsDesc1Null()
            {
                return this.IsNull(this.tablePC1TmpInventario.Desc1Column);
            }

            public bool IsDesc2Null()
            {
                return this.IsNull(this.tablePC1TmpInventario.Desc2Column);
            }

            public void SetCantSistNull()
            {
                this[this.tablePC1TmpInventario.CantSistColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDesc1Null()
            {
                this[this.tablePC1TmpInventario.Desc1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDesc2Null()
            {
                this[this.tablePC1TmpInventario.Desc2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public bool Aceptar
            {
                get
                {
                    return BooleanType.FromObject(this[this.tablePC1TmpInventario.AceptarColumn]);
                }
                set
                {
                    this[this.tablePC1TmpInventario.AceptarColumn] = value;
                }
            }

            public string Almacen
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpInventario.AlmacenColumn]);
                }
                set
                {
                    this[this.tablePC1TmpInventario.AlmacenColumn] = value;
                }
            }

            public decimal Cantidad
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpInventario.CantidadColumn]);
                }
                set
                {
                    this[this.tablePC1TmpInventario.CantidadColumn] = value;
                }
            }

            public decimal CantSist
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tablePC1TmpInventario.CantSistColumn]);
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
                    this[this.tablePC1TmpInventario.CantSistColumn] = value;
                }
            }

            public string Codigo
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpInventario.CodigoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpInventario.CodigoColumn] = value;
                }
            }

            public string Desc1
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpInventario.Desc1Column]);
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
                    this[this.tablePC1TmpInventario.Desc1Column] = value;
                }
            }

            public string Desc2
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpInventario.Desc2Column]);
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
                    this[this.tablePC1TmpInventario.Desc2Column] = value;
                }
            }

            public string Posicion
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpInventario.PosicionColumn]);
                }
                set
                {
                    this[this.tablePC1TmpInventario.PosicionColumn] = value;
                }
            }

            public string PosSist
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpInventario.PosSistColumn]);
                }
                set
                {
                    this[this.tablePC1TmpInventario.PosSistColumn] = value;
                }
            }

            public bool Rechazar
            {
                get
                {
                    return BooleanType.FromObject(this[this.tablePC1TmpInventario.RechazarColumn]);
                }
                set
                {
                    this[this.tablePC1TmpInventario.RechazarColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpInventarioRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DSDifInv.PC1TmpInventarioRow eventRow;

            public PC1TmpInventarioRowChangeEvent(DSDifInv.PC1TmpInventarioRow row, DataRowAction action)
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

            public DSDifInv.PC1TmpInventarioRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpInventarioRowChangeEventHandler(object sender, DSDifInv.PC1TmpInventarioRowChangeEvent e);

        [DebuggerStepThrough]
        public class RepDifInvDataTable : DataTable, IEnumerable
        {
            private DataColumn columnAceptar;
            private DataColumn columnAlmacen;
            private DataColumn columnCantidad;
            private DataColumn columnCantSist;
            private DataColumn columnCodigo;
            private DataColumn columnDesc1;
            private DataColumn columnDesc2;
            private DataColumn columnDesdeRack;
            private DataColumn columnFechaInv;
            private DataColumn columnHastaRack;
            private DataColumn columnPosicion;
            private DataColumn columnPosSist;
            private DataColumn columnRechazar;

            public event DSDifInv.RepDifInvRowChangeEventHandler RepDifInvRowChanged;

            public event DSDifInv.RepDifInvRowChangeEventHandler RepDifInvRowChanging;

            public event DSDifInv.RepDifInvRowChangeEventHandler RepDifInvRowDeleted;

            public event DSDifInv.RepDifInvRowChangeEventHandler RepDifInvRowDeleting;

            internal RepDifInvDataTable() : base("RepDifInv")
            {
                this.InitClass();
            }

            internal RepDifInvDataTable(DataTable table) : base(table.TableName)
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

            public void AddRepDifInvRow(DSDifInv.RepDifInvRow row)
            {
                this.Rows.Add(row);
            }

            public DSDifInv.RepDifInvRow AddRepDifInvRow(DateTime FechaInv, string DesdeRack, string HastaRack, string Almacen, string Posicion, string Codigo, string Desc1, string Desc2, decimal Cantidad, string PosSist, decimal CantSist, bool Aceptar, bool Rechazar)
            {
                DSDifInv.RepDifInvRow row = (DSDifInv.RepDifInvRow) this.NewRow();
                row.ItemArray = new object[] { FechaInv, DesdeRack, HastaRack, Almacen, Posicion, Codigo, Desc1, Desc2, Cantidad, PosSist, CantSist, Aceptar, Rechazar };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DSDifInv.RepDifInvDataTable table = (DSDifInv.RepDifInvDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DSDifInv.RepDifInvDataTable();
            }

            public DSDifInv.RepDifInvRow FindByFechaInvDesdeRackHastaRackAlmacenPosicionCodigo(DateTime FechaInv, string DesdeRack, string HastaRack, string Almacen, string Posicion, string Codigo)
            {
                return (DSDifInv.RepDifInvRow) this.Rows.Find(new object[] { FechaInv, DesdeRack, HastaRack, Almacen, Posicion, Codigo });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DSDifInv.RepDifInvRow);
            }

            private void InitClass()
            {
                this.columnFechaInv = new DataColumn("FechaInv", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaInv);
                this.columnDesdeRack = new DataColumn("DesdeRack", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDesdeRack);
                this.columnHastaRack = new DataColumn("HastaRack", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnHastaRack);
                this.columnAlmacen = new DataColumn("Almacen", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnAlmacen);
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
                this.columnPosSist = new DataColumn("PosSist", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPosSist);
                this.columnCantSist = new DataColumn("CantSist", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantSist);
                this.columnAceptar = new DataColumn("Aceptar", typeof(bool), null, MappingType.Element);
                this.Columns.Add(this.columnAceptar);
                this.columnRechazar = new DataColumn("Rechazar", typeof(bool), null, MappingType.Element);
                this.Columns.Add(this.columnRechazar);
                this.Constraints.Add(new UniqueConstraint("DSDifInvKey2", new DataColumn[] { this.columnFechaInv, this.columnDesdeRack, this.columnHastaRack, this.columnAlmacen, this.columnPosicion, this.columnCodigo }, true));
                this.columnFechaInv.AllowDBNull = false;
                this.columnDesdeRack.AllowDBNull = false;
                this.columnHastaRack.AllowDBNull = false;
                this.columnAlmacen.AllowDBNull = false;
                this.columnPosicion.AllowDBNull = false;
                this.columnCodigo.AllowDBNull = false;
                this.columnCantidad.AllowDBNull = false;
                this.columnPosSist.AllowDBNull = false;
                this.columnCantSist.AllowDBNull = false;
                this.columnAceptar.AllowDBNull = false;
                this.columnRechazar.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnFechaInv = this.Columns["FechaInv"];
                this.columnDesdeRack = this.Columns["DesdeRack"];
                this.columnHastaRack = this.Columns["HastaRack"];
                this.columnAlmacen = this.Columns["Almacen"];
                this.columnPosicion = this.Columns["Posicion"];
                this.columnCodigo = this.Columns["Codigo"];
                this.columnDesc1 = this.Columns["Desc1"];
                this.columnDesc2 = this.Columns["Desc2"];
                this.columnCantidad = this.Columns["Cantidad"];
                this.columnPosSist = this.Columns["PosSist"];
                this.columnCantSist = this.Columns["CantSist"];
                this.columnAceptar = this.Columns["Aceptar"];
                this.columnRechazar = this.Columns["Rechazar"];
            }

            public DSDifInv.RepDifInvRow NewRepDifInvRow()
            {
                return (DSDifInv.RepDifInvRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DSDifInv.RepDifInvRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.RepDifInvRowChangedEvent != null) && (this.RepDifInvRowChangedEvent != null))
                {
                    this.RepDifInvRowChangedEvent(this, new DSDifInv.RepDifInvRowChangeEvent((DSDifInv.RepDifInvRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.RepDifInvRowChangingEvent != null) && (this.RepDifInvRowChangingEvent != null))
                {
                    this.RepDifInvRowChangingEvent(this, new DSDifInv.RepDifInvRowChangeEvent((DSDifInv.RepDifInvRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.RepDifInvRowDeletedEvent != null) && (this.RepDifInvRowDeletedEvent != null))
                {
                    this.RepDifInvRowDeletedEvent(this, new DSDifInv.RepDifInvRowChangeEvent((DSDifInv.RepDifInvRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.RepDifInvRowDeletingEvent != null) && (this.RepDifInvRowDeletingEvent != null))
                {
                    this.RepDifInvRowDeletingEvent(this, new DSDifInv.RepDifInvRowChangeEvent((DSDifInv.RepDifInvRow) e.Row, e.Action));
                }
            }

            public void RemoveRepDifInvRow(DSDifInv.RepDifInvRow row)
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

            internal DataColumn AlmacenColumn
            {
                get
                {
                    return this.columnAlmacen;
                }
            }

            internal DataColumn CantidadColumn
            {
                get
                {
                    return this.columnCantidad;
                }
            }

            internal DataColumn CantSistColumn
            {
                get
                {
                    return this.columnCantSist;
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

            internal DataColumn DesdeRackColumn
            {
                get
                {
                    return this.columnDesdeRack;
                }
            }

            internal DataColumn FechaInvColumn
            {
                get
                {
                    return this.columnFechaInv;
                }
            }

            internal DataColumn HastaRackColumn
            {
                get
                {
                    return this.columnHastaRack;
                }
            }

            public DSDifInv.RepDifInvRow this[int index]
            {
                get
                {
                    return (DSDifInv.RepDifInvRow) this.Rows[index];
                }
            }

            internal DataColumn PosicionColumn
            {
                get
                {
                    return this.columnPosicion;
                }
            }

            internal DataColumn PosSistColumn
            {
                get
                {
                    return this.columnPosSist;
                }
            }

            internal DataColumn RechazarColumn
            {
                get
                {
                    return this.columnRechazar;
                }
            }
        }

        [DebuggerStepThrough]
        public class RepDifInvRow : DataRow
        {
            private DSDifInv.RepDifInvDataTable tableRepDifInv;

            internal RepDifInvRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRepDifInv = (DSDifInv.RepDifInvDataTable) this.Table;
            }

            public bool IsDesc1Null()
            {
                return this.IsNull(this.tableRepDifInv.Desc1Column);
            }

            public bool IsDesc2Null()
            {
                return this.IsNull(this.tableRepDifInv.Desc2Column);
            }

            public void SetDesc1Null()
            {
                this[this.tableRepDifInv.Desc1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDesc2Null()
            {
                this[this.tableRepDifInv.Desc2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public bool Aceptar
            {
                get
                {
                    return BooleanType.FromObject(this[this.tableRepDifInv.AceptarColumn]);
                }
                set
                {
                    this[this.tableRepDifInv.AceptarColumn] = value;
                }
            }

            public string Almacen
            {
                get
                {
                    return StringType.FromObject(this[this.tableRepDifInv.AlmacenColumn]);
                }
                set
                {
                    this[this.tableRepDifInv.AlmacenColumn] = value;
                }
            }

            public decimal Cantidad
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableRepDifInv.CantidadColumn]);
                }
                set
                {
                    this[this.tableRepDifInv.CantidadColumn] = value;
                }
            }

            public decimal CantSist
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableRepDifInv.CantSistColumn]);
                }
                set
                {
                    this[this.tableRepDifInv.CantSistColumn] = value;
                }
            }

            public string Codigo
            {
                get
                {
                    return StringType.FromObject(this[this.tableRepDifInv.CodigoColumn]);
                }
                set
                {
                    this[this.tableRepDifInv.CodigoColumn] = value;
                }
            }

            public string Desc1
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tableRepDifInv.Desc1Column]);
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
                    this[this.tableRepDifInv.Desc1Column] = value;
                }
            }

            public string Desc2
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tableRepDifInv.Desc2Column]);
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
                    this[this.tableRepDifInv.Desc2Column] = value;
                }
            }

            public string DesdeRack
            {
                get
                {
                    return StringType.FromObject(this[this.tableRepDifInv.DesdeRackColumn]);
                }
                set
                {
                    this[this.tableRepDifInv.DesdeRackColumn] = value;
                }
            }

            public DateTime FechaInv
            {
                get
                {
                    return DateType.FromObject(this[this.tableRepDifInv.FechaInvColumn]);
                }
                set
                {
                    this[this.tableRepDifInv.FechaInvColumn] = value;
                }
            }

            public string HastaRack
            {
                get
                {
                    return StringType.FromObject(this[this.tableRepDifInv.HastaRackColumn]);
                }
                set
                {
                    this[this.tableRepDifInv.HastaRackColumn] = value;
                }
            }

            public string Posicion
            {
                get
                {
                    return StringType.FromObject(this[this.tableRepDifInv.PosicionColumn]);
                }
                set
                {
                    this[this.tableRepDifInv.PosicionColumn] = value;
                }
            }

            public string PosSist
            {
                get
                {
                    return StringType.FromObject(this[this.tableRepDifInv.PosSistColumn]);
                }
                set
                {
                    this[this.tableRepDifInv.PosSistColumn] = value;
                }
            }

            public bool Rechazar
            {
                get
                {
                    return BooleanType.FromObject(this[this.tableRepDifInv.RechazarColumn]);
                }
                set
                {
                    this[this.tableRepDifInv.RechazarColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class RepDifInvRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DSDifInv.RepDifInvRow eventRow;

            public RepDifInvRowChangeEvent(DSDifInv.RepDifInvRow row, DataRowAction action)
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

            public DSDifInv.RepDifInvRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RepDifInvRowChangeEventHandler(object sender, DSDifInv.RepDifInvRowChangeEvent e);
    }
}

