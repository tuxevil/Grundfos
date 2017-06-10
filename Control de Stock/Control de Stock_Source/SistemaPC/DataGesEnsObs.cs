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

    [Serializable, DesignerCategory("code"), DebuggerStepThrough, ToolboxItem(true)]
    public class DataGesEnsObs : DataSet
    {
        private GesEnsObsDataTable tableGesEnsObs;
        private PC1TmpCalendarioDataTable tablePC1TmpCalendario;
        private PC1TmpCalendarioStkCompDataTable tablePC1TmpCalendarioStkComp;

        public DataGesEnsObs()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DataGesEnsObs(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["GesEnsObs"] != null)
                {
                    this.Tables.Add(new GesEnsObsDataTable(dataSet.Tables["GesEnsObs"]));
                }
                if (dataSet.Tables["PC1TmpCalendarioStkComp"] != null)
                {
                    this.Tables.Add(new PC1TmpCalendarioStkCompDataTable(dataSet.Tables["PC1TmpCalendarioStkComp"]));
                }
                if (dataSet.Tables["PC1TmpCalendario"] != null)
                {
                    this.Tables.Add(new PC1TmpCalendarioDataTable(dataSet.Tables["PC1TmpCalendario"]));
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
            DataGesEnsObs obs = (DataGesEnsObs) base.Clone();
            obs.InitVars();
            return obs;
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
            this.DataSetName = "DataGesEnsObs";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DataGesEnsObs.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableGesEnsObs = new GesEnsObsDataTable();
            this.Tables.Add(this.tableGesEnsObs);
            this.tablePC1TmpCalendarioStkComp = new PC1TmpCalendarioStkCompDataTable();
            this.Tables.Add(this.tablePC1TmpCalendarioStkComp);
            this.tablePC1TmpCalendario = new PC1TmpCalendarioDataTable();
            this.Tables.Add(this.tablePC1TmpCalendario);
        }

        internal void InitVars()
        {
            this.tableGesEnsObs = (GesEnsObsDataTable) this.Tables["GesEnsObs"];
            if (this.tableGesEnsObs != null)
            {
                this.tableGesEnsObs.InitVars();
            }
            this.tablePC1TmpCalendarioStkComp = (PC1TmpCalendarioStkCompDataTable) this.Tables["PC1TmpCalendarioStkComp"];
            if (this.tablePC1TmpCalendarioStkComp != null)
            {
                this.tablePC1TmpCalendarioStkComp.InitVars();
            }
            this.tablePC1TmpCalendario = (PC1TmpCalendarioDataTable) this.Tables["PC1TmpCalendario"];
            if (this.tablePC1TmpCalendario != null)
            {
                this.tablePC1TmpCalendario.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["GesEnsObs"] != null)
            {
                this.Tables.Add(new GesEnsObsDataTable(dataSet.Tables["GesEnsObs"]));
            }
            if (dataSet.Tables["PC1TmpCalendarioStkComp"] != null)
            {
                this.Tables.Add(new PC1TmpCalendarioStkCompDataTable(dataSet.Tables["PC1TmpCalendarioStkComp"]));
            }
            if (dataSet.Tables["PC1TmpCalendario"] != null)
            {
                this.Tables.Add(new PC1TmpCalendarioDataTable(dataSet.Tables["PC1TmpCalendario"]));
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

        private bool ShouldSerializeGesEnsObs()
        {
            return false;
        }

        private bool ShouldSerializePC1TmpCalendario()
        {
            return false;
        }

        private bool ShouldSerializePC1TmpCalendarioStkComp()
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
        public GesEnsObsDataTable GesEnsObs
        {
            get
            {
                return this.tableGesEnsObs;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public PC1TmpCalendarioDataTable PC1TmpCalendario
        {
            get
            {
                return this.tablePC1TmpCalendario;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public PC1TmpCalendarioStkCompDataTable PC1TmpCalendarioStkComp
        {
            get
            {
                return this.tablePC1TmpCalendarioStkComp;
            }
        }

        [DebuggerStepThrough]
        public class GesEnsObsDataTable : DataTable, IEnumerable
        {
            private DataColumn columnFecha;
            private DataColumn columnIDObs;
            private DataColumn columnNroLinea;
            private DataColumn columnNroOE;
            private DataColumn columnObservaciones;

            public event DataGesEnsObs.GesEnsObsRowChangeEventHandler GesEnsObsRowChanged;

            public event DataGesEnsObs.GesEnsObsRowChangeEventHandler GesEnsObsRowChanging;

            public event DataGesEnsObs.GesEnsObsRowChangeEventHandler GesEnsObsRowDeleted;

            public event DataGesEnsObs.GesEnsObsRowChangeEventHandler GesEnsObsRowDeleting;

            internal GesEnsObsDataTable() : base("GesEnsObs")
            {
                this.InitClass();
            }

            internal GesEnsObsDataTable(DataTable table) : base(table.TableName)
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

            public void AddGesEnsObsRow(DataGesEnsObs.GesEnsObsRow row)
            {
                this.Rows.Add(row);
            }

            public DataGesEnsObs.GesEnsObsRow AddGesEnsObsRow(string NroOE, string NroLinea, string Observaciones, DateTime Fecha)
            {
                DataGesEnsObs.GesEnsObsRow row = (DataGesEnsObs.GesEnsObsRow) this.NewRow();
                row.ItemArray = new object[] { NroOE, NroLinea, null, Observaciones, Fecha };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataGesEnsObs.GesEnsObsDataTable table = (DataGesEnsObs.GesEnsObsDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataGesEnsObs.GesEnsObsDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataGesEnsObs.GesEnsObsRow);
            }

            private void InitClass()
            {
                this.columnNroOE = new DataColumn("NroOE", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOE);
                this.columnNroLinea = new DataColumn("NroLinea", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroLinea);
                this.columnIDObs = new DataColumn("IDObs", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnIDObs);
                this.columnObservaciones = new DataColumn("Observaciones", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnObservaciones);
                this.columnFecha = new DataColumn("Fecha", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFecha);
                this.columnNroOE.AllowDBNull = false;
                this.columnNroLinea.AllowDBNull = false;
                this.columnIDObs.AutoIncrement = true;
                this.columnIDObs.AllowDBNull = false;
                this.columnIDObs.ReadOnly = true;
                this.columnObservaciones.AllowDBNull = false;
                this.columnFecha.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnNroOE = this.Columns["NroOE"];
                this.columnNroLinea = this.Columns["NroLinea"];
                this.columnIDObs = this.Columns["IDObs"];
                this.columnObservaciones = this.Columns["Observaciones"];
                this.columnFecha = this.Columns["Fecha"];
            }

            public DataGesEnsObs.GesEnsObsRow NewGesEnsObsRow()
            {
                return (DataGesEnsObs.GesEnsObsRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataGesEnsObs.GesEnsObsRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.GesEnsObsRowChangedEvent != null) && (this.GesEnsObsRowChangedEvent != null))
                {
                    this.GesEnsObsRowChangedEvent(this, new DataGesEnsObs.GesEnsObsRowChangeEvent((DataGesEnsObs.GesEnsObsRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.GesEnsObsRowChangingEvent != null) && (this.GesEnsObsRowChangingEvent != null))
                {
                    this.GesEnsObsRowChangingEvent(this, new DataGesEnsObs.GesEnsObsRowChangeEvent((DataGesEnsObs.GesEnsObsRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.GesEnsObsRowDeletedEvent != null) && (this.GesEnsObsRowDeletedEvent != null))
                {
                    this.GesEnsObsRowDeletedEvent(this, new DataGesEnsObs.GesEnsObsRowChangeEvent((DataGesEnsObs.GesEnsObsRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.GesEnsObsRowDeletingEvent != null) && (this.GesEnsObsRowDeletingEvent != null))
                {
                    this.GesEnsObsRowDeletingEvent(this, new DataGesEnsObs.GesEnsObsRowChangeEvent((DataGesEnsObs.GesEnsObsRow) e.Row, e.Action));
                }
            }

            public void RemoveGesEnsObsRow(DataGesEnsObs.GesEnsObsRow row)
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

            public DataGesEnsObs.GesEnsObsRow this[int index]
            {
                get
                {
                    return (DataGesEnsObs.GesEnsObsRow) this.Rows[index];
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

            internal DataColumn ObservacionesColumn
            {
                get
                {
                    return this.columnObservaciones;
                }
            }
        }

        [DebuggerStepThrough]
        public class GesEnsObsRow : DataRow
        {
            private DataGesEnsObs.GesEnsObsDataTable tableGesEnsObs;

            internal GesEnsObsRow(DataRowBuilder rb) : base(rb)
            {
                this.tableGesEnsObs = (DataGesEnsObs.GesEnsObsDataTable) this.Table;
            }

            public DateTime Fecha
            {
                get
                {
                    return DateType.FromObject(this[this.tableGesEnsObs.FechaColumn]);
                }
                set
                {
                    this[this.tableGesEnsObs.FechaColumn] = value;
                }
            }

            public decimal IDObs
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableGesEnsObs.IDObsColumn]);
                }
                set
                {
                    this[this.tableGesEnsObs.IDObsColumn] = value;
                }
            }

            public string NroLinea
            {
                get
                {
                    return StringType.FromObject(this[this.tableGesEnsObs.NroLineaColumn]);
                }
                set
                {
                    this[this.tableGesEnsObs.NroLineaColumn] = value;
                }
            }

            public string NroOE
            {
                get
                {
                    return StringType.FromObject(this[this.tableGesEnsObs.NroOEColumn]);
                }
                set
                {
                    this[this.tableGesEnsObs.NroOEColumn] = value;
                }
            }

            public string Observaciones
            {
                get
                {
                    return StringType.FromObject(this[this.tableGesEnsObs.ObservacionesColumn]);
                }
                set
                {
                    this[this.tableGesEnsObs.ObservacionesColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class GesEnsObsRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataGesEnsObs.GesEnsObsRow eventRow;

            public GesEnsObsRowChangeEvent(DataGesEnsObs.GesEnsObsRow row, DataRowAction action)
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

            public DataGesEnsObs.GesEnsObsRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void GesEnsObsRowChangeEventHandler(object sender, DataGesEnsObs.GesEnsObsRowChangeEvent e);

        [DebuggerStepThrough]
        public class PC1TmpCalendarioDataTable : DataTable, IEnumerable
        {
            private DataColumn columnAlmacen;
            private DataColumn columnAsignadoA;
            private DataColumn columnCantidad;
            private DataColumn columnCliente;
            private DataColumn columnCodigo;
            private DataColumn columnDescripcion;
            private DataColumn columnFechaEnt;
            private DataColumn columnHoras;
            private DataColumn columnListaRec;
            private DataColumn columnNroLinea;
            private DataColumn columnNroOA;
            private DataColumn columnObs;
            private DataColumn columnObservaciones;
            private DataColumn columnReqEsp;
            private DataColumn columnSinStock;

            public event DataGesEnsObs.PC1TmpCalendarioRowChangeEventHandler PC1TmpCalendarioRowChanged;

            public event DataGesEnsObs.PC1TmpCalendarioRowChangeEventHandler PC1TmpCalendarioRowChanging;

            public event DataGesEnsObs.PC1TmpCalendarioRowChangeEventHandler PC1TmpCalendarioRowDeleted;

            public event DataGesEnsObs.PC1TmpCalendarioRowChangeEventHandler PC1TmpCalendarioRowDeleting;

            internal PC1TmpCalendarioDataTable() : base("PC1TmpCalendario")
            {
                this.InitClass();
            }

            internal PC1TmpCalendarioDataTable(DataTable table) : base(table.TableName)
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

            public void AddPC1TmpCalendarioRow(DataGesEnsObs.PC1TmpCalendarioRow row)
            {
                this.Rows.Add(row);
            }

            public DataGesEnsObs.PC1TmpCalendarioRow AddPC1TmpCalendarioRow(DateTime FechaEnt, string Cliente, string ListaRec, string NroOA, string NroLinea, string Codigo, string Descripcion, string Almacen, decimal Cantidad, string AsignadoA, string Observaciones, string ReqEsp, string Horas, bool SinStock, bool Obs)
            {
                DataGesEnsObs.PC1TmpCalendarioRow row = (DataGesEnsObs.PC1TmpCalendarioRow) this.NewRow();
                row.ItemArray = new object[] { FechaEnt, Cliente, ListaRec, NroOA, NroLinea, Codigo, Descripcion, Almacen, Cantidad, AsignadoA, Observaciones, ReqEsp, Horas, SinStock, Obs };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataGesEnsObs.PC1TmpCalendarioDataTable table = (DataGesEnsObs.PC1TmpCalendarioDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataGesEnsObs.PC1TmpCalendarioDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataGesEnsObs.PC1TmpCalendarioRow);
            }

            private void InitClass()
            {
                this.columnFechaEnt = new DataColumn("FechaEnt", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaEnt);
                this.columnCliente = new DataColumn("Cliente", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCliente);
                this.columnListaRec = new DataColumn("ListaRec", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnListaRec);
                this.columnNroOA = new DataColumn("NroOA", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOA);
                this.columnNroLinea = new DataColumn("NroLinea", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroLinea);
                this.columnCodigo = new DataColumn("Codigo", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodigo);
                this.columnDescripcion = new DataColumn("Descripcion", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDescripcion);
                this.columnAlmacen = new DataColumn("Almacen", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnAlmacen);
                this.columnCantidad = new DataColumn("Cantidad", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantidad);
                this.columnAsignadoA = new DataColumn("AsignadoA", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnAsignadoA);
                this.columnObservaciones = new DataColumn("Observaciones", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnObservaciones);
                this.columnReqEsp = new DataColumn("ReqEsp", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnReqEsp);
                this.columnHoras = new DataColumn("Horas", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnHoras);
                this.columnSinStock = new DataColumn("SinStock", typeof(bool), null, MappingType.Element);
                this.Columns.Add(this.columnSinStock);
                this.columnObs = new DataColumn("Obs", typeof(bool), null, MappingType.Element);
                this.Columns.Add(this.columnObs);
                this.columnFechaEnt.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnFechaEnt = this.Columns["FechaEnt"];
                this.columnCliente = this.Columns["Cliente"];
                this.columnListaRec = this.Columns["ListaRec"];
                this.columnNroOA = this.Columns["NroOA"];
                this.columnNroLinea = this.Columns["NroLinea"];
                this.columnCodigo = this.Columns["Codigo"];
                this.columnDescripcion = this.Columns["Descripcion"];
                this.columnAlmacen = this.Columns["Almacen"];
                this.columnCantidad = this.Columns["Cantidad"];
                this.columnAsignadoA = this.Columns["AsignadoA"];
                this.columnObservaciones = this.Columns["Observaciones"];
                this.columnReqEsp = this.Columns["ReqEsp"];
                this.columnHoras = this.Columns["Horas"];
                this.columnSinStock = this.Columns["SinStock"];
                this.columnObs = this.Columns["Obs"];
            }

            public DataGesEnsObs.PC1TmpCalendarioRow NewPC1TmpCalendarioRow()
            {
                return (DataGesEnsObs.PC1TmpCalendarioRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataGesEnsObs.PC1TmpCalendarioRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpCalendarioRowChangedEvent != null) && (this.PC1TmpCalendarioRowChangedEvent != null))
                {
                    this.PC1TmpCalendarioRowChangedEvent(this, new DataGesEnsObs.PC1TmpCalendarioRowChangeEvent((DataGesEnsObs.PC1TmpCalendarioRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpCalendarioRowChangingEvent != null) && (this.PC1TmpCalendarioRowChangingEvent != null))
                {
                    this.PC1TmpCalendarioRowChangingEvent(this, new DataGesEnsObs.PC1TmpCalendarioRowChangeEvent((DataGesEnsObs.PC1TmpCalendarioRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpCalendarioRowDeletedEvent != null) && (this.PC1TmpCalendarioRowDeletedEvent != null))
                {
                    this.PC1TmpCalendarioRowDeletedEvent(this, new DataGesEnsObs.PC1TmpCalendarioRowChangeEvent((DataGesEnsObs.PC1TmpCalendarioRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpCalendarioRowDeletingEvent != null) && (this.PC1TmpCalendarioRowDeletingEvent != null))
                {
                    this.PC1TmpCalendarioRowDeletingEvent(this, new DataGesEnsObs.PC1TmpCalendarioRowChangeEvent((DataGesEnsObs.PC1TmpCalendarioRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpCalendarioRow(DataGesEnsObs.PC1TmpCalendarioRow row)
            {
                this.Rows.Remove(row);
            }

            internal DataColumn AlmacenColumn
            {
                get
                {
                    return this.columnAlmacen;
                }
            }

            internal DataColumn AsignadoAColumn
            {
                get
                {
                    return this.columnAsignadoA;
                }
            }

            internal DataColumn CantidadColumn
            {
                get
                {
                    return this.columnCantidad;
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

            internal DataColumn FechaEntColumn
            {
                get
                {
                    return this.columnFechaEnt;
                }
            }

            internal DataColumn HorasColumn
            {
                get
                {
                    return this.columnHoras;
                }
            }

            public DataGesEnsObs.PC1TmpCalendarioRow this[int index]
            {
                get
                {
                    return (DataGesEnsObs.PC1TmpCalendarioRow) this.Rows[index];
                }
            }

            internal DataColumn ListaRecColumn
            {
                get
                {
                    return this.columnListaRec;
                }
            }

            internal DataColumn NroLineaColumn
            {
                get
                {
                    return this.columnNroLinea;
                }
            }

            internal DataColumn NroOAColumn
            {
                get
                {
                    return this.columnNroOA;
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

            internal DataColumn ReqEspColumn
            {
                get
                {
                    return this.columnReqEsp;
                }
            }

            internal DataColumn SinStockColumn
            {
                get
                {
                    return this.columnSinStock;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpCalendarioRow : DataRow
        {
            private DataGesEnsObs.PC1TmpCalendarioDataTable tablePC1TmpCalendario;

            internal PC1TmpCalendarioRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpCalendario = (DataGesEnsObs.PC1TmpCalendarioDataTable) this.Table;
            }

            public bool IsAlmacenNull()
            {
                return this.IsNull(this.tablePC1TmpCalendario.AlmacenColumn);
            }

            public bool IsAsignadoANull()
            {
                return this.IsNull(this.tablePC1TmpCalendario.AsignadoAColumn);
            }

            public bool IsCantidadNull()
            {
                return this.IsNull(this.tablePC1TmpCalendario.CantidadColumn);
            }

            public bool IsClienteNull()
            {
                return this.IsNull(this.tablePC1TmpCalendario.ClienteColumn);
            }

            public bool IsCodigoNull()
            {
                return this.IsNull(this.tablePC1TmpCalendario.CodigoColumn);
            }

            public bool IsDescripcionNull()
            {
                return this.IsNull(this.tablePC1TmpCalendario.DescripcionColumn);
            }

            public bool IsHorasNull()
            {
                return this.IsNull(this.tablePC1TmpCalendario.HorasColumn);
            }

            public bool IsListaRecNull()
            {
                return this.IsNull(this.tablePC1TmpCalendario.ListaRecColumn);
            }

            public bool IsNroLineaNull()
            {
                return this.IsNull(this.tablePC1TmpCalendario.NroLineaColumn);
            }

            public bool IsNroOANull()
            {
                return this.IsNull(this.tablePC1TmpCalendario.NroOAColumn);
            }

            public bool IsObservacionesNull()
            {
                return this.IsNull(this.tablePC1TmpCalendario.ObservacionesColumn);
            }

            public bool IsObsNull()
            {
                return this.IsNull(this.tablePC1TmpCalendario.ObsColumn);
            }

            public bool IsReqEspNull()
            {
                return this.IsNull(this.tablePC1TmpCalendario.ReqEspColumn);
            }

            public bool IsSinStockNull()
            {
                return this.IsNull(this.tablePC1TmpCalendario.SinStockColumn);
            }

            public void SetAlmacenNull()
            {
                this[this.tablePC1TmpCalendario.AlmacenColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetAsignadoANull()
            {
                this[this.tablePC1TmpCalendario.AsignadoAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetCantidadNull()
            {
                this[this.tablePC1TmpCalendario.CantidadColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetClienteNull()
            {
                this[this.tablePC1TmpCalendario.ClienteColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetCodigoNull()
            {
                this[this.tablePC1TmpCalendario.CodigoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDescripcionNull()
            {
                this[this.tablePC1TmpCalendario.DescripcionColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetHorasNull()
            {
                this[this.tablePC1TmpCalendario.HorasColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetListaRecNull()
            {
                this[this.tablePC1TmpCalendario.ListaRecColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNroLineaNull()
            {
                this[this.tablePC1TmpCalendario.NroLineaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNroOANull()
            {
                this[this.tablePC1TmpCalendario.NroOAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetObservacionesNull()
            {
                this[this.tablePC1TmpCalendario.ObservacionesColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetObsNull()
            {
                this[this.tablePC1TmpCalendario.ObsColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetReqEspNull()
            {
                this[this.tablePC1TmpCalendario.ReqEspColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSinStockNull()
            {
                this[this.tablePC1TmpCalendario.SinStockColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string Almacen
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpCalendario.AlmacenColumn]);
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
                    this[this.tablePC1TmpCalendario.AlmacenColumn] = value;
                }
            }

            public string AsignadoA
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpCalendario.AsignadoAColumn]);
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
                    this[this.tablePC1TmpCalendario.AsignadoAColumn] = value;
                }
            }

            public decimal Cantidad
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tablePC1TmpCalendario.CantidadColumn]);
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
                    this[this.tablePC1TmpCalendario.CantidadColumn] = value;
                }
            }

            public string Cliente
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpCalendario.ClienteColumn]);
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
                    this[this.tablePC1TmpCalendario.ClienteColumn] = value;
                }
            }

            public string Codigo
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpCalendario.CodigoColumn]);
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
                    this[this.tablePC1TmpCalendario.CodigoColumn] = value;
                }
            }

            public string Descripcion
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpCalendario.DescripcionColumn]);
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
                    this[this.tablePC1TmpCalendario.DescripcionColumn] = value;
                }
            }

            public DateTime FechaEnt
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpCalendario.FechaEntColumn]);
                }
                set
                {
                    this[this.tablePC1TmpCalendario.FechaEntColumn] = value;
                }
            }

            public string Horas
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpCalendario.HorasColumn]);
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
                    this[this.tablePC1TmpCalendario.HorasColumn] = value;
                }
            }

            public string ListaRec
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpCalendario.ListaRecColumn]);
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
                    this[this.tablePC1TmpCalendario.ListaRecColumn] = value;
                }
            }

            public string NroLinea
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpCalendario.NroLineaColumn]);
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
                    this[this.tablePC1TmpCalendario.NroLineaColumn] = value;
                }
            }

            public string NroOA
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpCalendario.NroOAColumn]);
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
                    this[this.tablePC1TmpCalendario.NroOAColumn] = value;
                }
            }

            public bool Obs
            {
                get
                {
                    bool flag;
                    try
                    {
                        flag = BooleanType.FromObject(this[this.tablePC1TmpCalendario.ObsColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return flag;
                }
                set
                {
                    this[this.tablePC1TmpCalendario.ObsColumn] = value;
                }
            }

            public string Observaciones
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpCalendario.ObservacionesColumn]);
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
                    this[this.tablePC1TmpCalendario.ObservacionesColumn] = value;
                }
            }

            public string ReqEsp
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpCalendario.ReqEspColumn]);
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
                    this[this.tablePC1TmpCalendario.ReqEspColumn] = value;
                }
            }

            public bool SinStock
            {
                get
                {
                    bool flag;
                    try
                    {
                        flag = BooleanType.FromObject(this[this.tablePC1TmpCalendario.SinStockColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("No se puede obtener el valor porque es DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return flag;
                }
                set
                {
                    this[this.tablePC1TmpCalendario.SinStockColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpCalendarioRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataGesEnsObs.PC1TmpCalendarioRow eventRow;

            public PC1TmpCalendarioRowChangeEvent(DataGesEnsObs.PC1TmpCalendarioRow row, DataRowAction action)
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

            public DataGesEnsObs.PC1TmpCalendarioRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpCalendarioRowChangeEventHandler(object sender, DataGesEnsObs.PC1TmpCalendarioRowChangeEvent e);

        [DebuggerStepThrough]
        public class PC1TmpCalendarioStkCompDataTable : DataTable, IEnumerable
        {
            private DataColumn columnCantidad;
            private DataColumn columnCantOC;
            private DataColumn columnCodComp;
            private DataColumn columnDescComp;
            private DataColumn columnFechaOC;
            private DataColumn columnNroLinea;
            private DataColumn columnNroOA;
            private DataColumn columnStkComprometido;
            private DataColumn columnStkFisico;

            public event DataGesEnsObs.PC1TmpCalendarioStkCompRowChangeEventHandler PC1TmpCalendarioStkCompRowChanged;

            public event DataGesEnsObs.PC1TmpCalendarioStkCompRowChangeEventHandler PC1TmpCalendarioStkCompRowChanging;

            public event DataGesEnsObs.PC1TmpCalendarioStkCompRowChangeEventHandler PC1TmpCalendarioStkCompRowDeleted;

            public event DataGesEnsObs.PC1TmpCalendarioStkCompRowChangeEventHandler PC1TmpCalendarioStkCompRowDeleting;

            internal PC1TmpCalendarioStkCompDataTable() : base("PC1TmpCalendarioStkComp")
            {
                this.InitClass();
            }

            internal PC1TmpCalendarioStkCompDataTable(DataTable table) : base(table.TableName)
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

            public void AddPC1TmpCalendarioStkCompRow(DataGesEnsObs.PC1TmpCalendarioStkCompRow row)
            {
                this.Rows.Add(row);
            }

            public DataGesEnsObs.PC1TmpCalendarioStkCompRow AddPC1TmpCalendarioStkCompRow(string NroOA, string NroLinea, string CodComp, string DescComp, decimal Cantidad, decimal StkFisico, decimal StkComprometido, DateTime FechaOC, decimal CantOC)
            {
                DataGesEnsObs.PC1TmpCalendarioStkCompRow row = (DataGesEnsObs.PC1TmpCalendarioStkCompRow) this.NewRow();
                row.ItemArray = new object[] { NroOA, NroLinea, CodComp, DescComp, Cantidad, StkFisico, StkComprometido, FechaOC, CantOC };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataGesEnsObs.PC1TmpCalendarioStkCompDataTable table = (DataGesEnsObs.PC1TmpCalendarioStkCompDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataGesEnsObs.PC1TmpCalendarioStkCompDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataGesEnsObs.PC1TmpCalendarioStkCompRow);
            }

            private void InitClass()
            {
                this.columnNroOA = new DataColumn("NroOA", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOA);
                this.columnNroLinea = new DataColumn("NroLinea", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroLinea);
                this.columnCodComp = new DataColumn("CodComp", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodComp);
                this.columnDescComp = new DataColumn("DescComp", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDescComp);
                this.columnCantidad = new DataColumn("Cantidad", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantidad);
                this.columnStkFisico = new DataColumn("StkFisico", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnStkFisico);
                this.columnStkComprometido = new DataColumn("StkComprometido", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnStkComprometido);
                this.columnFechaOC = new DataColumn("FechaOC", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaOC);
                this.columnCantOC = new DataColumn("CantOC", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantOC);
                this.columnNroOA.AllowDBNull = false;
                this.columnNroLinea.AllowDBNull = false;
                this.columnCodComp.AllowDBNull = false;
                this.columnDescComp.AllowDBNull = false;
                this.columnCantidad.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnNroOA = this.Columns["NroOA"];
                this.columnNroLinea = this.Columns["NroLinea"];
                this.columnCodComp = this.Columns["CodComp"];
                this.columnDescComp = this.Columns["DescComp"];
                this.columnCantidad = this.Columns["Cantidad"];
                this.columnStkFisico = this.Columns["StkFisico"];
                this.columnStkComprometido = this.Columns["StkComprometido"];
                this.columnFechaOC = this.Columns["FechaOC"];
                this.columnCantOC = this.Columns["CantOC"];
            }

            public DataGesEnsObs.PC1TmpCalendarioStkCompRow NewPC1TmpCalendarioStkCompRow()
            {
                return (DataGesEnsObs.PC1TmpCalendarioStkCompRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataGesEnsObs.PC1TmpCalendarioStkCompRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpCalendarioStkCompRowChangedEvent != null) && (this.PC1TmpCalendarioStkCompRowChangedEvent != null))
                {
                    this.PC1TmpCalendarioStkCompRowChangedEvent(this, new DataGesEnsObs.PC1TmpCalendarioStkCompRowChangeEvent((DataGesEnsObs.PC1TmpCalendarioStkCompRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpCalendarioStkCompRowChangingEvent != null) && (this.PC1TmpCalendarioStkCompRowChangingEvent != null))
                {
                    this.PC1TmpCalendarioStkCompRowChangingEvent(this, new DataGesEnsObs.PC1TmpCalendarioStkCompRowChangeEvent((DataGesEnsObs.PC1TmpCalendarioStkCompRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpCalendarioStkCompRowDeletedEvent != null) && (this.PC1TmpCalendarioStkCompRowDeletedEvent != null))
                {
                    this.PC1TmpCalendarioStkCompRowDeletedEvent(this, new DataGesEnsObs.PC1TmpCalendarioStkCompRowChangeEvent((DataGesEnsObs.PC1TmpCalendarioStkCompRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpCalendarioStkCompRowDeletingEvent != null) && (this.PC1TmpCalendarioStkCompRowDeletingEvent != null))
                {
                    this.PC1TmpCalendarioStkCompRowDeletingEvent(this, new DataGesEnsObs.PC1TmpCalendarioStkCompRowChangeEvent((DataGesEnsObs.PC1TmpCalendarioStkCompRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpCalendarioStkCompRow(DataGesEnsObs.PC1TmpCalendarioStkCompRow row)
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

            internal DataColumn CantOCColumn
            {
                get
                {
                    return this.columnCantOC;
                }
            }

            internal DataColumn CodCompColumn
            {
                get
                {
                    return this.columnCodComp;
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

            internal DataColumn DescCompColumn
            {
                get
                {
                    return this.columnDescComp;
                }
            }

            internal DataColumn FechaOCColumn
            {
                get
                {
                    return this.columnFechaOC;
                }
            }

            public DataGesEnsObs.PC1TmpCalendarioStkCompRow this[int index]
            {
                get
                {
                    return (DataGesEnsObs.PC1TmpCalendarioStkCompRow) this.Rows[index];
                }
            }

            internal DataColumn NroLineaColumn
            {
                get
                {
                    return this.columnNroLinea;
                }
            }

            internal DataColumn NroOAColumn
            {
                get
                {
                    return this.columnNroOA;
                }
            }

            internal DataColumn StkComprometidoColumn
            {
                get
                {
                    return this.columnStkComprometido;
                }
            }

            internal DataColumn StkFisicoColumn
            {
                get
                {
                    return this.columnStkFisico;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpCalendarioStkCompRow : DataRow
        {
            private DataGesEnsObs.PC1TmpCalendarioStkCompDataTable tablePC1TmpCalendarioStkComp;

            internal PC1TmpCalendarioStkCompRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpCalendarioStkComp = (DataGesEnsObs.PC1TmpCalendarioStkCompDataTable) this.Table;
            }

            public bool IsCantOCNull()
            {
                return this.IsNull(this.tablePC1TmpCalendarioStkComp.CantOCColumn);
            }

            public bool IsFechaOCNull()
            {
                return this.IsNull(this.tablePC1TmpCalendarioStkComp.FechaOCColumn);
            }

            public bool IsStkComprometidoNull()
            {
                return this.IsNull(this.tablePC1TmpCalendarioStkComp.StkComprometidoColumn);
            }

            public bool IsStkFisicoNull()
            {
                return this.IsNull(this.tablePC1TmpCalendarioStkComp.StkFisicoColumn);
            }

            public void SetCantOCNull()
            {
                this[this.tablePC1TmpCalendarioStkComp.CantOCColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFechaOCNull()
            {
                this[this.tablePC1TmpCalendarioStkComp.FechaOCColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetStkComprometidoNull()
            {
                this[this.tablePC1TmpCalendarioStkComp.StkComprometidoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetStkFisicoNull()
            {
                this[this.tablePC1TmpCalendarioStkComp.StkFisicoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal Cantidad
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpCalendarioStkComp.CantidadColumn]);
                }
                set
                {
                    this[this.tablePC1TmpCalendarioStkComp.CantidadColumn] = value;
                }
            }

            public decimal CantOC
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tablePC1TmpCalendarioStkComp.CantOCColumn]);
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
                    this[this.tablePC1TmpCalendarioStkComp.CantOCColumn] = value;
                }
            }

            public string CodComp
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpCalendarioStkComp.CodCompColumn]);
                }
                set
                {
                    this[this.tablePC1TmpCalendarioStkComp.CodCompColumn] = value;
                }
            }

            public string DescComp
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpCalendarioStkComp.DescCompColumn]);
                }
                set
                {
                    this[this.tablePC1TmpCalendarioStkComp.DescCompColumn] = value;
                }
            }

            public DateTime FechaOC
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = DateType.FromObject(this[this.tablePC1TmpCalendarioStkComp.FechaOCColumn]);
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
                    this[this.tablePC1TmpCalendarioStkComp.FechaOCColumn] = value;
                }
            }

            public string NroLinea
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpCalendarioStkComp.NroLineaColumn]);
                }
                set
                {
                    this[this.tablePC1TmpCalendarioStkComp.NroLineaColumn] = value;
                }
            }

            public string NroOA
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpCalendarioStkComp.NroOAColumn]);
                }
                set
                {
                    this[this.tablePC1TmpCalendarioStkComp.NroOAColumn] = value;
                }
            }

            public decimal StkComprometido
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tablePC1TmpCalendarioStkComp.StkComprometidoColumn]);
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
                    this[this.tablePC1TmpCalendarioStkComp.StkComprometidoColumn] = value;
                }
            }

            public decimal StkFisico
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tablePC1TmpCalendarioStkComp.StkFisicoColumn]);
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
                    this[this.tablePC1TmpCalendarioStkComp.StkFisicoColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpCalendarioStkCompRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataGesEnsObs.PC1TmpCalendarioStkCompRow eventRow;

            public PC1TmpCalendarioStkCompRowChangeEvent(DataGesEnsObs.PC1TmpCalendarioStkCompRow row, DataRowAction action)
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

            public DataGesEnsObs.PC1TmpCalendarioStkCompRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpCalendarioStkCompRowChangeEventHandler(object sender, DataGesEnsObs.PC1TmpCalendarioStkCompRowChangeEvent e);
    }
}

