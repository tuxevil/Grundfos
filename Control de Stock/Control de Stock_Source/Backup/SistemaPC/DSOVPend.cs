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

    [Serializable, ToolboxItem(true), DebuggerStepThrough, DesignerCategory("code")]
    public class DSOVPend : DataSet
    {
        private PC1TmpOVPendDataTable tablePC1TmpOVPend;

        public DSOVPend()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DSOVPend(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["PC1TmpOVPend"] != null)
                {
                    this.Tables.Add(new PC1TmpOVPendDataTable(dataSet.Tables["PC1TmpOVPend"]));
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
            DSOVPend pend = (DSOVPend) base.Clone();
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
            this.DataSetName = "DSOVPend";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DSOVPend.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tablePC1TmpOVPend = new PC1TmpOVPendDataTable();
            this.Tables.Add(this.tablePC1TmpOVPend);
        }

        internal void InitVars()
        {
            this.tablePC1TmpOVPend = (PC1TmpOVPendDataTable) this.Tables["PC1TmpOVPend"];
            if (this.tablePC1TmpOVPend != null)
            {
                this.tablePC1TmpOVPend.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["PC1TmpOVPend"] != null)
            {
                this.Tables.Add(new PC1TmpOVPendDataTable(dataSet.Tables["PC1TmpOVPend"]));
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

        private bool ShouldSerializePC1TmpOVPend()
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
        public PC1TmpOVPendDataTable PC1TmpOVPend
        {
            get
            {
                return this.tablePC1TmpOVPend;
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpOVPendDataTable : DataTable, IEnumerable
        {
            private DataColumn columnCantidad;
            private DataColumn columnCantOC;
            private DataColumn columnCliente;
            private DataColumn columnCodProd;
            private DataColumn columnDesc1;
            private DataColumn columnDesc2;
            private DataColumn columnEntBloq;
            private DataColumn columnEntParc;
            private DataColumn columnExcLimCre;
            private DataColumn columnFechaEnt;
            private DataColumn columnFechaOC;
            private DataColumn columnFechaOV;
            private DataColumn columnNomCli;
            private DataColumn columnNroOV;
            private DataColumn columnOCompra;
            private DataColumn columnRefCli;
            private DataColumn columnReserva;
            private DataColumn columnStockComp;
            private DataColumn columnStockFisico;

            public event DSOVPend.PC1TmpOVPendRowChangeEventHandler PC1TmpOVPendRowChanged;

            public event DSOVPend.PC1TmpOVPendRowChangeEventHandler PC1TmpOVPendRowChanging;

            public event DSOVPend.PC1TmpOVPendRowChangeEventHandler PC1TmpOVPendRowDeleted;

            public event DSOVPend.PC1TmpOVPendRowChangeEventHandler PC1TmpOVPendRowDeleting;

            internal PC1TmpOVPendDataTable() : base("PC1TmpOVPend")
            {
                this.InitClass();
            }

            internal PC1TmpOVPendDataTable(DataTable table) : base(table.TableName)
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

            public void AddPC1TmpOVPendRow(DSOVPend.PC1TmpOVPendRow row)
            {
                this.Rows.Add(row);
            }

            public DSOVPend.PC1TmpOVPendRow AddPC1TmpOVPendRow(string Cliente, string NomCli, string EntBloq, string ExcLimCre, string NroOV, DateTime FechaOV, DateTime FechaEnt, int Reserva, string RefCli, string OCompra, string CodProd, string Desc1, string Desc2, decimal Cantidad, decimal StockFisico, decimal StockComp, DateTime FechaOC, decimal CantOC, string EntParc)
            {
                DSOVPend.PC1TmpOVPendRow row = (DSOVPend.PC1TmpOVPendRow) this.NewRow();
                row.ItemArray = new object[] { 
                    Cliente, NomCli, EntBloq, ExcLimCre, NroOV, FechaOV, FechaEnt, Reserva, RefCli, OCompra, CodProd, Desc1, Desc2, Cantidad, StockFisico, StockComp, 
                    FechaOC, CantOC, EntParc
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DSOVPend.PC1TmpOVPendDataTable table = (DSOVPend.PC1TmpOVPendDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DSOVPend.PC1TmpOVPendDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DSOVPend.PC1TmpOVPendRow);
            }

            private void InitClass()
            {
                this.columnCliente = new DataColumn("Cliente", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCliente);
                this.columnNomCli = new DataColumn("NomCli", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNomCli);
                this.columnEntBloq = new DataColumn("EntBloq", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnEntBloq);
                this.columnExcLimCre = new DataColumn("ExcLimCre", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnExcLimCre);
                this.columnNroOV = new DataColumn("NroOV", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOV);
                this.columnFechaOV = new DataColumn("FechaOV", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaOV);
                this.columnFechaEnt = new DataColumn("FechaEnt", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaEnt);
                this.columnReserva = new DataColumn("Reserva", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnReserva);
                this.columnRefCli = new DataColumn("RefCli", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnRefCli);
                this.columnOCompra = new DataColumn("OCompra", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOCompra);
                this.columnCodProd = new DataColumn("CodProd", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodProd);
                this.columnDesc1 = new DataColumn("Desc1", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDesc1);
                this.columnDesc2 = new DataColumn("Desc2", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDesc2);
                this.columnCantidad = new DataColumn("Cantidad", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantidad);
                this.columnStockFisico = new DataColumn("StockFisico", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnStockFisico);
                this.columnStockComp = new DataColumn("StockComp", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnStockComp);
                this.columnFechaOC = new DataColumn("FechaOC", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaOC);
                this.columnCantOC = new DataColumn("CantOC", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantOC);
                this.columnEntParc = new DataColumn("EntParc", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnEntParc);
                this.columnCliente.AllowDBNull = false;
                this.columnNomCli.AllowDBNull = false;
                this.columnEntBloq.AllowDBNull = false;
                this.columnExcLimCre.AllowDBNull = false;
                this.columnNroOV.AllowDBNull = false;
                this.columnFechaOV.AllowDBNull = false;
                this.columnFechaEnt.AllowDBNull = false;
                this.columnReserva.AllowDBNull = false;
                this.columnRefCli.AllowDBNull = false;
                this.columnOCompra.AllowDBNull = false;
                this.columnCodProd.AllowDBNull = false;
                this.columnDesc1.AllowDBNull = false;
                this.columnDesc2.AllowDBNull = false;
                this.columnCantidad.AllowDBNull = false;
                this.columnStockFisico.AllowDBNull = false;
                this.columnStockComp.AllowDBNull = false;
                this.columnEntParc.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnCliente = this.Columns["Cliente"];
                this.columnNomCli = this.Columns["NomCli"];
                this.columnEntBloq = this.Columns["EntBloq"];
                this.columnExcLimCre = this.Columns["ExcLimCre"];
                this.columnNroOV = this.Columns["NroOV"];
                this.columnFechaOV = this.Columns["FechaOV"];
                this.columnFechaEnt = this.Columns["FechaEnt"];
                this.columnReserva = this.Columns["Reserva"];
                this.columnRefCli = this.Columns["RefCli"];
                this.columnOCompra = this.Columns["OCompra"];
                this.columnCodProd = this.Columns["CodProd"];
                this.columnDesc1 = this.Columns["Desc1"];
                this.columnDesc2 = this.Columns["Desc2"];
                this.columnCantidad = this.Columns["Cantidad"];
                this.columnStockFisico = this.Columns["StockFisico"];
                this.columnStockComp = this.Columns["StockComp"];
                this.columnFechaOC = this.Columns["FechaOC"];
                this.columnCantOC = this.Columns["CantOC"];
                this.columnEntParc = this.Columns["EntParc"];
            }

            public DSOVPend.PC1TmpOVPendRow NewPC1TmpOVPendRow()
            {
                return (DSOVPend.PC1TmpOVPendRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DSOVPend.PC1TmpOVPendRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpOVPendRowChangedEvent != null) && (this.PC1TmpOVPendRowChangedEvent != null))
                {
                    this.PC1TmpOVPendRowChangedEvent(this, new DSOVPend.PC1TmpOVPendRowChangeEvent((DSOVPend.PC1TmpOVPendRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpOVPendRowChangingEvent != null) && (this.PC1TmpOVPendRowChangingEvent != null))
                {
                    this.PC1TmpOVPendRowChangingEvent(this, new DSOVPend.PC1TmpOVPendRowChangeEvent((DSOVPend.PC1TmpOVPendRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpOVPendRowDeletedEvent != null) && (this.PC1TmpOVPendRowDeletedEvent != null))
                {
                    this.PC1TmpOVPendRowDeletedEvent(this, new DSOVPend.PC1TmpOVPendRowChangeEvent((DSOVPend.PC1TmpOVPendRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpOVPendRowDeletingEvent != null) && (this.PC1TmpOVPendRowDeletingEvent != null))
                {
                    this.PC1TmpOVPendRowDeletingEvent(this, new DSOVPend.PC1TmpOVPendRowChangeEvent((DSOVPend.PC1TmpOVPendRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpOVPendRow(DSOVPend.PC1TmpOVPendRow row)
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

            internal DataColumn ClienteColumn
            {
                get
                {
                    return this.columnCliente;
                }
            }

            internal DataColumn CodProdColumn
            {
                get
                {
                    return this.columnCodProd;
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

            internal DataColumn EntBloqColumn
            {
                get
                {
                    return this.columnEntBloq;
                }
            }

            internal DataColumn EntParcColumn
            {
                get
                {
                    return this.columnEntParc;
                }
            }

            internal DataColumn ExcLimCreColumn
            {
                get
                {
                    return this.columnExcLimCre;
                }
            }

            internal DataColumn FechaEntColumn
            {
                get
                {
                    return this.columnFechaEnt;
                }
            }

            internal DataColumn FechaOCColumn
            {
                get
                {
                    return this.columnFechaOC;
                }
            }

            internal DataColumn FechaOVColumn
            {
                get
                {
                    return this.columnFechaOV;
                }
            }

            public DSOVPend.PC1TmpOVPendRow this[int index]
            {
                get
                {
                    return (DSOVPend.PC1TmpOVPendRow) this.Rows[index];
                }
            }

            internal DataColumn NomCliColumn
            {
                get
                {
                    return this.columnNomCli;
                }
            }

            internal DataColumn NroOVColumn
            {
                get
                {
                    return this.columnNroOV;
                }
            }

            internal DataColumn OCompraColumn
            {
                get
                {
                    return this.columnOCompra;
                }
            }

            internal DataColumn RefCliColumn
            {
                get
                {
                    return this.columnRefCli;
                }
            }

            internal DataColumn ReservaColumn
            {
                get
                {
                    return this.columnReserva;
                }
            }

            internal DataColumn StockCompColumn
            {
                get
                {
                    return this.columnStockComp;
                }
            }

            internal DataColumn StockFisicoColumn
            {
                get
                {
                    return this.columnStockFisico;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpOVPendRow : DataRow
        {
            private DSOVPend.PC1TmpOVPendDataTable tablePC1TmpOVPend;

            internal PC1TmpOVPendRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpOVPend = (DSOVPend.PC1TmpOVPendDataTable) this.Table;
            }

            public bool IsCantOCNull()
            {
                return this.IsNull(this.tablePC1TmpOVPend.CantOCColumn);
            }

            public bool IsFechaOCNull()
            {
                return this.IsNull(this.tablePC1TmpOVPend.FechaOCColumn);
            }

            public void SetCantOCNull()
            {
                this[this.tablePC1TmpOVPend.CantOCColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFechaOCNull()
            {
                this[this.tablePC1TmpOVPend.FechaOCColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal Cantidad
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOVPend.CantidadColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVPend.CantidadColumn] = value;
                }
            }

            public decimal CantOC
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tablePC1TmpOVPend.CantOCColumn]);
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
                    this[this.tablePC1TmpOVPend.CantOCColumn] = value;
                }
            }

            public string Cliente
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVPend.ClienteColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVPend.ClienteColumn] = value;
                }
            }

            public string CodProd
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVPend.CodProdColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVPend.CodProdColumn] = value;
                }
            }

            public string Desc1
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVPend.Desc1Column]);
                }
                set
                {
                    this[this.tablePC1TmpOVPend.Desc1Column] = value;
                }
            }

            public string Desc2
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVPend.Desc2Column]);
                }
                set
                {
                    this[this.tablePC1TmpOVPend.Desc2Column] = value;
                }
            }

            public string EntBloq
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVPend.EntBloqColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVPend.EntBloqColumn] = value;
                }
            }

            public string EntParc
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVPend.EntParcColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVPend.EntParcColumn] = value;
                }
            }

            public string ExcLimCre
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVPend.ExcLimCreColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVPend.ExcLimCreColumn] = value;
                }
            }

            public DateTime FechaEnt
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpOVPend.FechaEntColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVPend.FechaEntColumn] = value;
                }
            }

            public DateTime FechaOC
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = DateType.FromObject(this[this.tablePC1TmpOVPend.FechaOCColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        InvalidCastException innerException = exception1;
                        throw new StrongTypingException("Cannot get value because it is DBNull.", innerException);
                        ProjectData.ClearProjectError();
                    }
                    return time;
                }
                set
                {
                    this[this.tablePC1TmpOVPend.FechaOCColumn] = value;
                }
            }

            public DateTime FechaOV
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpOVPend.FechaOVColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVPend.FechaOVColumn] = value;
                }
            }

            public string NomCli
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVPend.NomCliColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVPend.NomCliColumn] = value;
                }
            }

            public string NroOV
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVPend.NroOVColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVPend.NroOVColumn] = value;
                }
            }

            public string OCompra
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVPend.OCompraColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVPend.OCompraColumn] = value;
                }
            }

            public string RefCli
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVPend.RefCliColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVPend.RefCliColumn] = value;
                }
            }

            public int Reserva
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC1TmpOVPend.ReservaColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVPend.ReservaColumn] = value;
                }
            }

            public decimal StockComp
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOVPend.StockCompColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVPend.StockCompColumn] = value;
                }
            }

            public decimal StockFisico
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOVPend.StockFisicoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVPend.StockFisicoColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpOVPendRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DSOVPend.PC1TmpOVPendRow eventRow;

            public PC1TmpOVPendRowChangeEvent(DSOVPend.PC1TmpOVPendRow row, DataRowAction action)
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

            public DSOVPend.PC1TmpOVPendRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpOVPendRowChangeEventHandler(object sender, DSOVPend.PC1TmpOVPendRowChangeEvent e);
    }
}

