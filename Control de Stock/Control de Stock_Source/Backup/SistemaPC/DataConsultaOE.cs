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
    public class DataConsultaOE : DataSet
    {
        private GesEnsObsDataTable tableGesEnsObs;
        private PC1TmpGesEnsDataTable tablePC1TmpGesEns;

        public DataConsultaOE()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DataConsultaOE(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["PC1TmpGesEns"] != null)
                {
                    this.Tables.Add(new PC1TmpGesEnsDataTable(dataSet.Tables["PC1TmpGesEns"]));
                }
                if (dataSet.Tables["GesEnsObs"] != null)
                {
                    this.Tables.Add(new GesEnsObsDataTable(dataSet.Tables["GesEnsObs"]));
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
            DataConsultaOE aoe = (DataConsultaOE) base.Clone();
            aoe.InitVars();
            return aoe;
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
            this.DataSetName = "DataConsultaOE";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DataConsultaOE.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tablePC1TmpGesEns = new PC1TmpGesEnsDataTable();
            this.Tables.Add(this.tablePC1TmpGesEns);
            this.tableGesEnsObs = new GesEnsObsDataTable();
            this.Tables.Add(this.tableGesEnsObs);
        }

        internal void InitVars()
        {
            this.tablePC1TmpGesEns = (PC1TmpGesEnsDataTable) this.Tables["PC1TmpGesEns"];
            if (this.tablePC1TmpGesEns != null)
            {
                this.tablePC1TmpGesEns.InitVars();
            }
            this.tableGesEnsObs = (GesEnsObsDataTable) this.Tables["GesEnsObs"];
            if (this.tableGesEnsObs != null)
            {
                this.tableGesEnsObs.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["PC1TmpGesEns"] != null)
            {
                this.Tables.Add(new PC1TmpGesEnsDataTable(dataSet.Tables["PC1TmpGesEns"]));
            }
            if (dataSet.Tables["GesEnsObs"] != null)
            {
                this.Tables.Add(new GesEnsObsDataTable(dataSet.Tables["GesEnsObs"]));
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

        private bool ShouldSerializePC1TmpGesEns()
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PC1TmpGesEnsDataTable PC1TmpGesEns
        {
            get
            {
                return this.tablePC1TmpGesEns;
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

            public event DataConsultaOE.GesEnsObsRowChangeEventHandler GesEnsObsRowChanged;

            public event DataConsultaOE.GesEnsObsRowChangeEventHandler GesEnsObsRowChanging;

            public event DataConsultaOE.GesEnsObsRowChangeEventHandler GesEnsObsRowDeleted;

            public event DataConsultaOE.GesEnsObsRowChangeEventHandler GesEnsObsRowDeleting;

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

            public void AddGesEnsObsRow(DataConsultaOE.GesEnsObsRow row)
            {
                this.Rows.Add(row);
            }

            public DataConsultaOE.GesEnsObsRow AddGesEnsObsRow(string NroOE, string NroLinea, string Observaciones, DateTime Fecha)
            {
                DataConsultaOE.GesEnsObsRow row = (DataConsultaOE.GesEnsObsRow) this.NewRow();
                row.ItemArray = new object[] { NroOE, NroLinea, null, Observaciones, Fecha };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataConsultaOE.GesEnsObsDataTable table = (DataConsultaOE.GesEnsObsDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataConsultaOE.GesEnsObsDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataConsultaOE.GesEnsObsRow);
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

            public DataConsultaOE.GesEnsObsRow NewGesEnsObsRow()
            {
                return (DataConsultaOE.GesEnsObsRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataConsultaOE.GesEnsObsRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.GesEnsObsRowChangedEvent != null) && (this.GesEnsObsRowChangedEvent != null))
                {
                    this.GesEnsObsRowChangedEvent(this, new DataConsultaOE.GesEnsObsRowChangeEvent((DataConsultaOE.GesEnsObsRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.GesEnsObsRowChangingEvent != null) && (this.GesEnsObsRowChangingEvent != null))
                {
                    this.GesEnsObsRowChangingEvent(this, new DataConsultaOE.GesEnsObsRowChangeEvent((DataConsultaOE.GesEnsObsRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.GesEnsObsRowDeletedEvent != null) && (this.GesEnsObsRowDeletedEvent != null))
                {
                    this.GesEnsObsRowDeletedEvent(this, new DataConsultaOE.GesEnsObsRowChangeEvent((DataConsultaOE.GesEnsObsRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.GesEnsObsRowDeletingEvent != null) && (this.GesEnsObsRowDeletingEvent != null))
                {
                    this.GesEnsObsRowDeletingEvent(this, new DataConsultaOE.GesEnsObsRowChangeEvent((DataConsultaOE.GesEnsObsRow) e.Row, e.Action));
                }
            }

            public void RemoveGesEnsObsRow(DataConsultaOE.GesEnsObsRow row)
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

            public DataConsultaOE.GesEnsObsRow this[int index]
            {
                get
                {
                    return (DataConsultaOE.GesEnsObsRow) this.Rows[index];
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
            private DataConsultaOE.GesEnsObsDataTable tableGesEnsObs;

            internal GesEnsObsRow(DataRowBuilder rb) : base(rb)
            {
                this.tableGesEnsObs = (DataConsultaOE.GesEnsObsDataTable) this.Table;
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
            private DataConsultaOE.GesEnsObsRow eventRow;

            public GesEnsObsRowChangeEvent(DataConsultaOE.GesEnsObsRow row, DataRowAction action)
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

            public DataConsultaOE.GesEnsObsRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void GesEnsObsRowChangeEventHandler(object sender, DataConsultaOE.GesEnsObsRowChangeEvent e);

        [DebuggerStepThrough]
        public class PC1TmpGesEnsDataTable : DataTable, IEnumerable
        {
            private DataColumn columnCantArmado;
            private DataColumn columnCantOE;
            private DataColumn columnCliente;
            private DataColumn columnCodigo;
            private DataColumn columnDescripcion;
            private DataColumn columnFechaEnsReal;
            private DataColumn columnFechaEnt;
            private DataColumn columnFechaOE;
            private DataColumn columnNroLinea;
            private DataColumn columnNroOE;
            private DataColumn columnNroOV;
            private DataColumn columnObs;
            private DataColumn columnObservaciones;
            private DataColumn columnOpArmado;
            private DataColumn columnOpEmbalaje;
            private DataColumn columnOpPrueba;
            private DataColumn columnOpRecoleccion;
            private DataColumn columnTArmado;
            private DataColumn columnTEmbalaje;
            private DataColumn columnTiempoAsig;
            private DataColumn columnTPrueba;
            private DataColumn columnTRecoleccion;

            public event DataConsultaOE.PC1TmpGesEnsRowChangeEventHandler PC1TmpGesEnsRowChanged;

            public event DataConsultaOE.PC1TmpGesEnsRowChangeEventHandler PC1TmpGesEnsRowChanging;

            public event DataConsultaOE.PC1TmpGesEnsRowChangeEventHandler PC1TmpGesEnsRowDeleted;

            public event DataConsultaOE.PC1TmpGesEnsRowChangeEventHandler PC1TmpGesEnsRowDeleting;

            internal PC1TmpGesEnsDataTable() : base("PC1TmpGesEns")
            {
                this.InitClass();
            }

            internal PC1TmpGesEnsDataTable(DataTable table) : base(table.TableName)
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

            public void AddPC1TmpGesEnsRow(DataConsultaOE.PC1TmpGesEnsRow row)
            {
                this.Rows.Add(row);
            }

            public DataConsultaOE.PC1TmpGesEnsRow AddPC1TmpGesEnsRow(string NroOE, DateTime FechaOE, DateTime FechaEnt, DateTime FechaEnsReal, string NroLinea, string Codigo, string Descripcion, decimal CantOE, decimal CantArmado, string Cliente, string NroOV, string Observaciones, string TiempoAsig, string OpRecoleccion, string OpArmado, string OpPrueba, string OpEmbalaje, decimal TRecoleccion, decimal TArmado, decimal TPrueba, decimal TEmbalaje, string Obs)
            {
                DataConsultaOE.PC1TmpGesEnsRow row = (DataConsultaOE.PC1TmpGesEnsRow) this.NewRow();
                row.ItemArray = new object[] { 
                    NroOE, FechaOE, FechaEnt, FechaEnsReal, NroLinea, Codigo, Descripcion, CantOE, CantArmado, Cliente, NroOV, Observaciones, TiempoAsig, OpRecoleccion, OpArmado, OpPrueba, 
                    OpEmbalaje, TRecoleccion, TArmado, TPrueba, TEmbalaje, Obs
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataConsultaOE.PC1TmpGesEnsDataTable table = (DataConsultaOE.PC1TmpGesEnsDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataConsultaOE.PC1TmpGesEnsDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataConsultaOE.PC1TmpGesEnsRow);
            }

            private void InitClass()
            {
                this.columnNroOE = new DataColumn("NroOE", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOE);
                this.columnFechaOE = new DataColumn("FechaOE", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaOE);
                this.columnFechaEnt = new DataColumn("FechaEnt", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaEnt);
                this.columnFechaEnsReal = new DataColumn("FechaEnsReal", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaEnsReal);
                this.columnNroLinea = new DataColumn("NroLinea", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroLinea);
                this.columnCodigo = new DataColumn("Codigo", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodigo);
                this.columnDescripcion = new DataColumn("Descripcion", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDescripcion);
                this.columnCantOE = new DataColumn("CantOE", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantOE);
                this.columnCantArmado = new DataColumn("CantArmado", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantArmado);
                this.columnCliente = new DataColumn("Cliente", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCliente);
                this.columnNroOV = new DataColumn("NroOV", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOV);
                this.columnObservaciones = new DataColumn("Observaciones", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnObservaciones);
                this.columnTiempoAsig = new DataColumn("TiempoAsig", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnTiempoAsig);
                this.columnOpRecoleccion = new DataColumn("OpRecoleccion", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOpRecoleccion);
                this.columnOpArmado = new DataColumn("OpArmado", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOpArmado);
                this.columnOpPrueba = new DataColumn("OpPrueba", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOpPrueba);
                this.columnOpEmbalaje = new DataColumn("OpEmbalaje", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOpEmbalaje);
                this.columnTRecoleccion = new DataColumn("TRecoleccion", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnTRecoleccion);
                this.columnTArmado = new DataColumn("TArmado", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnTArmado);
                this.columnTPrueba = new DataColumn("TPrueba", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnTPrueba);
                this.columnTEmbalaje = new DataColumn("TEmbalaje", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnTEmbalaje);
                this.columnObs = new DataColumn("Obs", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnObs);
                this.columnNroOE.AllowDBNull = false;
                this.columnFechaOE.AllowDBNull = false;
                this.columnFechaEnt.AllowDBNull = false;
                this.columnNroLinea.AllowDBNull = false;
                this.columnCodigo.AllowDBNull = false;
                this.columnCantOE.AllowDBNull = false;
                this.columnCantArmado.AllowDBNull = false;
                this.columnTRecoleccion.AllowDBNull = false;
                this.columnTArmado.AllowDBNull = false;
                this.columnTPrueba.AllowDBNull = false;
                this.columnTEmbalaje.AllowDBNull = false;
                this.columnObs.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnNroOE = this.Columns["NroOE"];
                this.columnFechaOE = this.Columns["FechaOE"];
                this.columnFechaEnt = this.Columns["FechaEnt"];
                this.columnFechaEnsReal = this.Columns["FechaEnsReal"];
                this.columnNroLinea = this.Columns["NroLinea"];
                this.columnCodigo = this.Columns["Codigo"];
                this.columnDescripcion = this.Columns["Descripcion"];
                this.columnCantOE = this.Columns["CantOE"];
                this.columnCantArmado = this.Columns["CantArmado"];
                this.columnCliente = this.Columns["Cliente"];
                this.columnNroOV = this.Columns["NroOV"];
                this.columnObservaciones = this.Columns["Observaciones"];
                this.columnTiempoAsig = this.Columns["TiempoAsig"];
                this.columnOpRecoleccion = this.Columns["OpRecoleccion"];
                this.columnOpArmado = this.Columns["OpArmado"];
                this.columnOpPrueba = this.Columns["OpPrueba"];
                this.columnOpEmbalaje = this.Columns["OpEmbalaje"];
                this.columnTRecoleccion = this.Columns["TRecoleccion"];
                this.columnTArmado = this.Columns["TArmado"];
                this.columnTPrueba = this.Columns["TPrueba"];
                this.columnTEmbalaje = this.Columns["TEmbalaje"];
                this.columnObs = this.Columns["Obs"];
            }

            public DataConsultaOE.PC1TmpGesEnsRow NewPC1TmpGesEnsRow()
            {
                return (DataConsultaOE.PC1TmpGesEnsRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataConsultaOE.PC1TmpGesEnsRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpGesEnsRowChangedEvent != null) && (this.PC1TmpGesEnsRowChangedEvent != null))
                {
                    this.PC1TmpGesEnsRowChangedEvent(this, new DataConsultaOE.PC1TmpGesEnsRowChangeEvent((DataConsultaOE.PC1TmpGesEnsRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpGesEnsRowChangingEvent != null) && (this.PC1TmpGesEnsRowChangingEvent != null))
                {
                    this.PC1TmpGesEnsRowChangingEvent(this, new DataConsultaOE.PC1TmpGesEnsRowChangeEvent((DataConsultaOE.PC1TmpGesEnsRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpGesEnsRowDeletedEvent != null) && (this.PC1TmpGesEnsRowDeletedEvent != null))
                {
                    this.PC1TmpGesEnsRowDeletedEvent(this, new DataConsultaOE.PC1TmpGesEnsRowChangeEvent((DataConsultaOE.PC1TmpGesEnsRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpGesEnsRowDeletingEvent != null) && (this.PC1TmpGesEnsRowDeletingEvent != null))
                {
                    this.PC1TmpGesEnsRowDeletingEvent(this, new DataConsultaOE.PC1TmpGesEnsRowChangeEvent((DataConsultaOE.PC1TmpGesEnsRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpGesEnsRow(DataConsultaOE.PC1TmpGesEnsRow row)
            {
                this.Rows.Remove(row);
            }

            internal DataColumn CantArmadoColumn
            {
                get
                {
                    return this.columnCantArmado;
                }
            }

            internal DataColumn CantOEColumn
            {
                get
                {
                    return this.columnCantOE;
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

            internal DataColumn FechaEnsRealColumn
            {
                get
                {
                    return this.columnFechaEnsReal;
                }
            }

            internal DataColumn FechaEntColumn
            {
                get
                {
                    return this.columnFechaEnt;
                }
            }

            internal DataColumn FechaOEColumn
            {
                get
                {
                    return this.columnFechaOE;
                }
            }

            public DataConsultaOE.PC1TmpGesEnsRow this[int index]
            {
                get
                {
                    return (DataConsultaOE.PC1TmpGesEnsRow) this.Rows[index];
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

            internal DataColumn NroOVColumn
            {
                get
                {
                    return this.columnNroOV;
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

            internal DataColumn OpArmadoColumn
            {
                get
                {
                    return this.columnOpArmado;
                }
            }

            internal DataColumn OpEmbalajeColumn
            {
                get
                {
                    return this.columnOpEmbalaje;
                }
            }

            internal DataColumn OpPruebaColumn
            {
                get
                {
                    return this.columnOpPrueba;
                }
            }

            internal DataColumn OpRecoleccionColumn
            {
                get
                {
                    return this.columnOpRecoleccion;
                }
            }

            internal DataColumn TArmadoColumn
            {
                get
                {
                    return this.columnTArmado;
                }
            }

            internal DataColumn TEmbalajeColumn
            {
                get
                {
                    return this.columnTEmbalaje;
                }
            }

            internal DataColumn TiempoAsigColumn
            {
                get
                {
                    return this.columnTiempoAsig;
                }
            }

            internal DataColumn TPruebaColumn
            {
                get
                {
                    return this.columnTPrueba;
                }
            }

            internal DataColumn TRecoleccionColumn
            {
                get
                {
                    return this.columnTRecoleccion;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpGesEnsRow : DataRow
        {
            private DataConsultaOE.PC1TmpGesEnsDataTable tablePC1TmpGesEns;

            internal PC1TmpGesEnsRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpGesEns = (DataConsultaOE.PC1TmpGesEnsDataTable) this.Table;
            }

            public bool IsClienteNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.ClienteColumn);
            }

            public bool IsDescripcionNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.DescripcionColumn);
            }

            public bool IsFechaEnsRealNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.FechaEnsRealColumn);
            }

            public bool IsNroOVNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.NroOVColumn);
            }

            public bool IsObservacionesNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.ObservacionesColumn);
            }

            public bool IsOpArmadoNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.OpArmadoColumn);
            }

            public bool IsOpEmbalajeNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.OpEmbalajeColumn);
            }

            public bool IsOpPruebaNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.OpPruebaColumn);
            }

            public bool IsOpRecoleccionNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.OpRecoleccionColumn);
            }

            public bool IsTiempoAsigNull()
            {
                return this.IsNull(this.tablePC1TmpGesEns.TiempoAsigColumn);
            }

            public void SetClienteNull()
            {
                this[this.tablePC1TmpGesEns.ClienteColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDescripcionNull()
            {
                this[this.tablePC1TmpGesEns.DescripcionColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFechaEnsRealNull()
            {
                this[this.tablePC1TmpGesEns.FechaEnsRealColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNroOVNull()
            {
                this[this.tablePC1TmpGesEns.NroOVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetObservacionesNull()
            {
                this[this.tablePC1TmpGesEns.ObservacionesColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOpArmadoNull()
            {
                this[this.tablePC1TmpGesEns.OpArmadoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOpEmbalajeNull()
            {
                this[this.tablePC1TmpGesEns.OpEmbalajeColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOpPruebaNull()
            {
                this[this.tablePC1TmpGesEns.OpPruebaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOpRecoleccionNull()
            {
                this[this.tablePC1TmpGesEns.OpRecoleccionColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTiempoAsigNull()
            {
                this[this.tablePC1TmpGesEns.TiempoAsigColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal CantArmado
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpGesEns.CantArmadoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.CantArmadoColumn] = value;
                }
            }

            public decimal CantOE
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpGesEns.CantOEColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.CantOEColumn] = value;
                }
            }

            public string Cliente
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpGesEns.ClienteColumn]);
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
                    this[this.tablePC1TmpGesEns.ClienteColumn] = value;
                }
            }

            public string Codigo
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpGesEns.CodigoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.CodigoColumn] = value;
                }
            }

            public string Descripcion
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpGesEns.DescripcionColumn]);
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
                    this[this.tablePC1TmpGesEns.DescripcionColumn] = value;
                }
            }

            public DateTime FechaEnsReal
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = DateType.FromObject(this[this.tablePC1TmpGesEns.FechaEnsRealColumn]);
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
                    this[this.tablePC1TmpGesEns.FechaEnsRealColumn] = value;
                }
            }

            public DateTime FechaEnt
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpGesEns.FechaEntColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.FechaEntColumn] = value;
                }
            }

            public DateTime FechaOE
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpGesEns.FechaOEColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.FechaOEColumn] = value;
                }
            }

            public string NroLinea
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpGesEns.NroLineaColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.NroLineaColumn] = value;
                }
            }

            public string NroOE
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpGesEns.NroOEColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.NroOEColumn] = value;
                }
            }

            public string NroOV
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpGesEns.NroOVColumn]);
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
                    this[this.tablePC1TmpGesEns.NroOVColumn] = value;
                }
            }

            public string Obs
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpGesEns.ObsColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.ObsColumn] = value;
                }
            }

            public string Observaciones
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpGesEns.ObservacionesColumn]);
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
                    this[this.tablePC1TmpGesEns.ObservacionesColumn] = value;
                }
            }

            public string OpArmado
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpGesEns.OpArmadoColumn]);
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
                    this[this.tablePC1TmpGesEns.OpArmadoColumn] = value;
                }
            }

            public string OpEmbalaje
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpGesEns.OpEmbalajeColumn]);
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
                    this[this.tablePC1TmpGesEns.OpEmbalajeColumn] = value;
                }
            }

            public string OpPrueba
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpGesEns.OpPruebaColumn]);
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
                    this[this.tablePC1TmpGesEns.OpPruebaColumn] = value;
                }
            }

            public string OpRecoleccion
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpGesEns.OpRecoleccionColumn]);
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
                    this[this.tablePC1TmpGesEns.OpRecoleccionColumn] = value;
                }
            }

            public decimal TArmado
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpGesEns.TArmadoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.TArmadoColumn] = value;
                }
            }

            public decimal TEmbalaje
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpGesEns.TEmbalajeColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.TEmbalajeColumn] = value;
                }
            }

            public string TiempoAsig
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpGesEns.TiempoAsigColumn]);
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
                    this[this.tablePC1TmpGesEns.TiempoAsigColumn] = value;
                }
            }

            public decimal TPrueba
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpGesEns.TPruebaColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.TPruebaColumn] = value;
                }
            }

            public decimal TRecoleccion
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpGesEns.TRecoleccionColumn]);
                }
                set
                {
                    this[this.tablePC1TmpGesEns.TRecoleccionColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpGesEnsRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataConsultaOE.PC1TmpGesEnsRow eventRow;

            public PC1TmpGesEnsRowChangeEvent(DataConsultaOE.PC1TmpGesEnsRow row, DataRowAction action)
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

            public DataConsultaOE.PC1TmpGesEnsRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpGesEnsRowChangeEventHandler(object sender, DataConsultaOE.PC1TmpGesEnsRowChangeEvent e);
    }
}

