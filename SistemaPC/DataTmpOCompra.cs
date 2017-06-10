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
    public class DataTmpOCompra : DataSet
    {
        private PC1TmpOCompraDataTable tablePC1TmpOCompra;

        public DataTmpOCompra()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DataTmpOCompra(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["PC1TmpOCompra"] != null)
                {
                    this.Tables.Add(new PC1TmpOCompraDataTable(dataSet.Tables["PC1TmpOCompra"]));
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
            DataTmpOCompra compra = (DataTmpOCompra) base.Clone();
            compra.InitVars();
            return compra;
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
            this.DataSetName = "DataTmpOCompra";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DataTmpOCompra.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tablePC1TmpOCompra = new PC1TmpOCompraDataTable();
            this.Tables.Add(this.tablePC1TmpOCompra);
        }

        internal void InitVars()
        {
            this.tablePC1TmpOCompra = (PC1TmpOCompraDataTable) this.Tables["PC1TmpOCompra"];
            if (this.tablePC1TmpOCompra != null)
            {
                this.tablePC1TmpOCompra.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["PC1TmpOCompra"] != null)
            {
                this.Tables.Add(new PC1TmpOCompraDataTable(dataSet.Tables["PC1TmpOCompra"]));
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

        private bool ShouldSerializePC1TmpOCompra()
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
        public PC1TmpOCompraDataTable PC1TmpOCompra
        {
            get
            {
                return this.tablePC1TmpOCompra;
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpOCompraDataTable : DataTable, IEnumerable
        {
            private DataColumn columnCantMetEnv01;
            private DataColumn columnCantMetEnv02;
            private DataColumn columnCantMetEnv03;
            private DataColumn columnCantMinPed;
            private DataColumn columnCodigo;
            private DataColumn columnCodMetEnv01;
            private DataColumn columnCodMetEnv02;
            private DataColumn columnCodMetEnv03;
            private DataColumn columnCodMoneda;
            private DataColumn columnCodProv;
            private DataColumn columnCodReemplazo;
            private DataColumn columnDescMetEnv01;
            private DataColumn columnDescMetEnv02;
            private DataColumn columnDescMetEnv03;
            private DataColumn columnDescripcion;
            private DataColumn columnFecEntOC01;
            private DataColumn columnFecEntOC02;
            private DataColumn columnFecEntOC03;
            private DataColumn columnFecReemp;
            private DataColumn columnLoteOptCpra;
            private DataColumn columnMoneda;
            private DataColumn columnNivelRepos;
            private DataColumn columnNomProv;
            private DataColumn columnOCPend;
            private DataColumn columnOV;
            private DataColumn columnOVRes;
            private DataColumn columnPrecioCpra;
            private DataColumn columnPropCpra;
            private DataColumn columnSeleccion;
            private DataColumn columnStockAl;

            public event DataTmpOCompra.PC1TmpOCompraRowChangeEventHandler PC1TmpOCompraRowChanged;

            public event DataTmpOCompra.PC1TmpOCompraRowChangeEventHandler PC1TmpOCompraRowChanging;

            public event DataTmpOCompra.PC1TmpOCompraRowChangeEventHandler PC1TmpOCompraRowDeleted;

            public event DataTmpOCompra.PC1TmpOCompraRowChangeEventHandler PC1TmpOCompraRowDeleting;

            internal PC1TmpOCompraDataTable() : base("PC1TmpOCompra")
            {
                this.InitClass();
            }

            internal PC1TmpOCompraDataTable(DataTable table) : base(table.TableName)
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

            public void AddPC1TmpOCompraRow(DataTmpOCompra.PC1TmpOCompraRow row)
            {
                this.Rows.Add(row);
            }

            public DataTmpOCompra.PC1TmpOCompraRow AddPC1TmpOCompraRow(string Codigo, string Descripcion, decimal NivelRepos, decimal StockAl, decimal OV, decimal OCPend, decimal OVRes, decimal LoteOptCpra, decimal CantMinPed, string CodReemplazo, DateTime FecReemp, decimal PropCpra, string CodProv, string NomProv, string CodMetEnv01, string DescMetEnv01, decimal CantMetEnv01, DateTime FecEntOC01, string CodMetEnv02, string DescMetEnv02, decimal CantMetEnv02, DateTime FecEntOC02, string CodMetEnv03, string DescMetEnv03, decimal CantMetEnv03, DateTime FecEntOC03, bool Seleccion, decimal PrecioCpra, string CodMoneda, string Moneda)
            {
                DataTmpOCompra.PC1TmpOCompraRow row = (DataTmpOCompra.PC1TmpOCompraRow) this.NewRow();
                row.ItemArray = new object[] { 
                    Codigo, Descripcion, NivelRepos, StockAl, OV, OCPend, OVRes, LoteOptCpra, CantMinPed, CodReemplazo, FecReemp, PropCpra, CodProv, NomProv, CodMetEnv01, DescMetEnv01, 
                    CantMetEnv01, FecEntOC01, CodMetEnv02, DescMetEnv02, CantMetEnv02, FecEntOC02, CodMetEnv03, DescMetEnv03, CantMetEnv03, FecEntOC03, Seleccion, PrecioCpra, CodMoneda, Moneda
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataTmpOCompra.PC1TmpOCompraDataTable table = (DataTmpOCompra.PC1TmpOCompraDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataTmpOCompra.PC1TmpOCompraDataTable();
            }

            public DataTmpOCompra.PC1TmpOCompraRow FindByCodigo(string Codigo)
            {
                return (DataTmpOCompra.PC1TmpOCompraRow) this.Rows.Find(new object[] { Codigo });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataTmpOCompra.PC1TmpOCompraRow);
            }

            private void InitClass()
            {
                this.columnCodigo = new DataColumn("Codigo", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodigo);
                this.columnDescripcion = new DataColumn("Descripcion", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDescripcion);
                this.columnNivelRepos = new DataColumn("NivelRepos", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnNivelRepos);
                this.columnStockAl = new DataColumn("StockAl", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnStockAl);
                this.columnOV = new DataColumn("OV", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOV);
                this.columnOCPend = new DataColumn("OCPend", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOCPend);
                this.columnOVRes = new DataColumn("OVRes", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOVRes);
                this.columnLoteOptCpra = new DataColumn("LoteOptCpra", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnLoteOptCpra);
                this.columnCantMinPed = new DataColumn("CantMinPed", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantMinPed);
                this.columnCodReemplazo = new DataColumn("CodReemplazo", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodReemplazo);
                this.columnFecReemp = new DataColumn("FecReemp", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFecReemp);
                this.columnPropCpra = new DataColumn("PropCpra", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPropCpra);
                this.columnCodProv = new DataColumn("CodProv", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodProv);
                this.columnNomProv = new DataColumn("NomProv", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNomProv);
                this.columnCodMetEnv01 = new DataColumn("CodMetEnv01", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodMetEnv01);
                this.columnDescMetEnv01 = new DataColumn("DescMetEnv01", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDescMetEnv01);
                this.columnCantMetEnv01 = new DataColumn("CantMetEnv01", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantMetEnv01);
                this.columnFecEntOC01 = new DataColumn("FecEntOC01", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFecEntOC01);
                this.columnCodMetEnv02 = new DataColumn("CodMetEnv02", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodMetEnv02);
                this.columnDescMetEnv02 = new DataColumn("DescMetEnv02", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDescMetEnv02);
                this.columnCantMetEnv02 = new DataColumn("CantMetEnv02", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantMetEnv02);
                this.columnFecEntOC02 = new DataColumn("FecEntOC02", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFecEntOC02);
                this.columnCodMetEnv03 = new DataColumn("CodMetEnv03", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodMetEnv03);
                this.columnDescMetEnv03 = new DataColumn("DescMetEnv03", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDescMetEnv03);
                this.columnCantMetEnv03 = new DataColumn("CantMetEnv03", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantMetEnv03);
                this.columnFecEntOC03 = new DataColumn("FecEntOC03", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFecEntOC03);
                this.columnSeleccion = new DataColumn("Seleccion", typeof(bool), null, MappingType.Element);
                this.Columns.Add(this.columnSeleccion);
                this.columnPrecioCpra = new DataColumn("PrecioCpra", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPrecioCpra);
                this.columnCodMoneda = new DataColumn("CodMoneda", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodMoneda);
                this.columnMoneda = new DataColumn("Moneda", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnMoneda);
                this.Constraints.Add(new UniqueConstraint("DataTmpOCompraKey1", new DataColumn[] { this.columnCodigo }, true));
                this.columnCodigo.AllowDBNull = false;
                this.columnCodigo.Unique = true;
                this.columnNivelRepos.AllowDBNull = false;
                this.columnStockAl.AllowDBNull = false;
                this.columnOV.AllowDBNull = false;
                this.columnOCPend.AllowDBNull = false;
                this.columnOVRes.AllowDBNull = false;
                this.columnLoteOptCpra.AllowDBNull = false;
                this.columnCantMinPed.AllowDBNull = false;
                this.columnCodReemplazo.AllowDBNull = false;
                this.columnPropCpra.AllowDBNull = false;
                this.columnCodProv.AllowDBNull = false;
                this.columnNomProv.AllowDBNull = false;
                this.columnCodMetEnv01.AllowDBNull = false;
                this.columnDescMetEnv01.AllowDBNull = false;
                this.columnCantMetEnv01.AllowDBNull = false;
                this.columnFecEntOC01.AllowDBNull = false;
                this.columnCodMetEnv02.AllowDBNull = false;
                this.columnDescMetEnv02.AllowDBNull = false;
                this.columnCantMetEnv02.AllowDBNull = false;
                this.columnFecEntOC02.AllowDBNull = false;
                this.columnCodMetEnv03.AllowDBNull = false;
                this.columnDescMetEnv03.AllowDBNull = false;
                this.columnCantMetEnv03.AllowDBNull = false;
                this.columnFecEntOC03.AllowDBNull = false;
                this.columnSeleccion.AllowDBNull = false;
                this.columnPrecioCpra.AllowDBNull = false;
                this.columnCodMoneda.AllowDBNull = false;
                this.columnMoneda.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnCodigo = this.Columns["Codigo"];
                this.columnDescripcion = this.Columns["Descripcion"];
                this.columnNivelRepos = this.Columns["NivelRepos"];
                this.columnStockAl = this.Columns["StockAl"];
                this.columnOV = this.Columns["OV"];
                this.columnOCPend = this.Columns["OCPend"];
                this.columnOVRes = this.Columns["OVRes"];
                this.columnLoteOptCpra = this.Columns["LoteOptCpra"];
                this.columnCantMinPed = this.Columns["CantMinPed"];
                this.columnCodReemplazo = this.Columns["CodReemplazo"];
                this.columnFecReemp = this.Columns["FecReemp"];
                this.columnPropCpra = this.Columns["PropCpra"];
                this.columnCodProv = this.Columns["CodProv"];
                this.columnNomProv = this.Columns["NomProv"];
                this.columnCodMetEnv01 = this.Columns["CodMetEnv01"];
                this.columnDescMetEnv01 = this.Columns["DescMetEnv01"];
                this.columnCantMetEnv01 = this.Columns["CantMetEnv01"];
                this.columnFecEntOC01 = this.Columns["FecEntOC01"];
                this.columnCodMetEnv02 = this.Columns["CodMetEnv02"];
                this.columnDescMetEnv02 = this.Columns["DescMetEnv02"];
                this.columnCantMetEnv02 = this.Columns["CantMetEnv02"];
                this.columnFecEntOC02 = this.Columns["FecEntOC02"];
                this.columnCodMetEnv03 = this.Columns["CodMetEnv03"];
                this.columnDescMetEnv03 = this.Columns["DescMetEnv03"];
                this.columnCantMetEnv03 = this.Columns["CantMetEnv03"];
                this.columnFecEntOC03 = this.Columns["FecEntOC03"];
                this.columnSeleccion = this.Columns["Seleccion"];
                this.columnPrecioCpra = this.Columns["PrecioCpra"];
                this.columnCodMoneda = this.Columns["CodMoneda"];
                this.columnMoneda = this.Columns["Moneda"];
            }

            public DataTmpOCompra.PC1TmpOCompraRow NewPC1TmpOCompraRow()
            {
                return (DataTmpOCompra.PC1TmpOCompraRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataTmpOCompra.PC1TmpOCompraRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpOCompraRowChangedEvent != null) && (this.PC1TmpOCompraRowChangedEvent != null))
                {
                    this.PC1TmpOCompraRowChangedEvent(this, new DataTmpOCompra.PC1TmpOCompraRowChangeEvent((DataTmpOCompra.PC1TmpOCompraRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpOCompraRowChangingEvent != null) && (this.PC1TmpOCompraRowChangingEvent != null))
                {
                    this.PC1TmpOCompraRowChangingEvent(this, new DataTmpOCompra.PC1TmpOCompraRowChangeEvent((DataTmpOCompra.PC1TmpOCompraRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpOCompraRowDeletedEvent != null) && (this.PC1TmpOCompraRowDeletedEvent != null))
                {
                    this.PC1TmpOCompraRowDeletedEvent(this, new DataTmpOCompra.PC1TmpOCompraRowChangeEvent((DataTmpOCompra.PC1TmpOCompraRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpOCompraRowDeletingEvent != null) && (this.PC1TmpOCompraRowDeletingEvent != null))
                {
                    this.PC1TmpOCompraRowDeletingEvent(this, new DataTmpOCompra.PC1TmpOCompraRowChangeEvent((DataTmpOCompra.PC1TmpOCompraRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpOCompraRow(DataTmpOCompra.PC1TmpOCompraRow row)
            {
                this.Rows.Remove(row);
            }

            internal DataColumn CantMetEnv01Column
            {
                get
                {
                    return this.columnCantMetEnv01;
                }
            }

            internal DataColumn CantMetEnv02Column
            {
                get
                {
                    return this.columnCantMetEnv02;
                }
            }

            internal DataColumn CantMetEnv03Column
            {
                get
                {
                    return this.columnCantMetEnv03;
                }
            }

            internal DataColumn CantMinPedColumn
            {
                get
                {
                    return this.columnCantMinPed;
                }
            }

            internal DataColumn CodigoColumn
            {
                get
                {
                    return this.columnCodigo;
                }
            }

            internal DataColumn CodMetEnv01Column
            {
                get
                {
                    return this.columnCodMetEnv01;
                }
            }

            internal DataColumn CodMetEnv02Column
            {
                get
                {
                    return this.columnCodMetEnv02;
                }
            }

            internal DataColumn CodMetEnv03Column
            {
                get
                {
                    return this.columnCodMetEnv03;
                }
            }

            internal DataColumn CodMonedaColumn
            {
                get
                {
                    return this.columnCodMoneda;
                }
            }

            internal DataColumn CodProvColumn
            {
                get
                {
                    return this.columnCodProv;
                }
            }

            internal DataColumn CodReemplazoColumn
            {
                get
                {
                    return this.columnCodReemplazo;
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

            internal DataColumn DescMetEnv01Column
            {
                get
                {
                    return this.columnDescMetEnv01;
                }
            }

            internal DataColumn DescMetEnv02Column
            {
                get
                {
                    return this.columnDescMetEnv02;
                }
            }

            internal DataColumn DescMetEnv03Column
            {
                get
                {
                    return this.columnDescMetEnv03;
                }
            }

            internal DataColumn DescripcionColumn
            {
                get
                {
                    return this.columnDescripcion;
                }
            }

            internal DataColumn FecEntOC01Column
            {
                get
                {
                    return this.columnFecEntOC01;
                }
            }

            internal DataColumn FecEntOC02Column
            {
                get
                {
                    return this.columnFecEntOC02;
                }
            }

            internal DataColumn FecEntOC03Column
            {
                get
                {
                    return this.columnFecEntOC03;
                }
            }

            internal DataColumn FecReempColumn
            {
                get
                {
                    return this.columnFecReemp;
                }
            }

            public DataTmpOCompra.PC1TmpOCompraRow this[int index]
            {
                get
                {
                    return (DataTmpOCompra.PC1TmpOCompraRow) this.Rows[index];
                }
            }

            internal DataColumn LoteOptCpraColumn
            {
                get
                {
                    return this.columnLoteOptCpra;
                }
            }

            internal DataColumn MonedaColumn
            {
                get
                {
                    return this.columnMoneda;
                }
            }

            internal DataColumn NivelReposColumn
            {
                get
                {
                    return this.columnNivelRepos;
                }
            }

            internal DataColumn NomProvColumn
            {
                get
                {
                    return this.columnNomProv;
                }
            }

            internal DataColumn OCPendColumn
            {
                get
                {
                    return this.columnOCPend;
                }
            }

            internal DataColumn OVColumn
            {
                get
                {
                    return this.columnOV;
                }
            }

            internal DataColumn OVResColumn
            {
                get
                {
                    return this.columnOVRes;
                }
            }

            internal DataColumn PrecioCpraColumn
            {
                get
                {
                    return this.columnPrecioCpra;
                }
            }

            internal DataColumn PropCpraColumn
            {
                get
                {
                    return this.columnPropCpra;
                }
            }

            internal DataColumn SeleccionColumn
            {
                get
                {
                    return this.columnSeleccion;
                }
            }

            internal DataColumn StockAlColumn
            {
                get
                {
                    return this.columnStockAl;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpOCompraRow : DataRow
        {
            private DataTmpOCompra.PC1TmpOCompraDataTable tablePC1TmpOCompra;

            internal PC1TmpOCompraRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpOCompra = (DataTmpOCompra.PC1TmpOCompraDataTable) this.Table;
            }

            public bool IsDescripcionNull()
            {
                return this.IsNull(this.tablePC1TmpOCompra.DescripcionColumn);
            }

            public bool IsFecReempNull()
            {
                return this.IsNull(this.tablePC1TmpOCompra.FecReempColumn);
            }

            public void SetDescripcionNull()
            {
                this[this.tablePC1TmpOCompra.DescripcionColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetFecReempNull()
            {
                this[this.tablePC1TmpOCompra.FecReempColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal CantMetEnv01
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOCompra.CantMetEnv01Column]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.CantMetEnv01Column] = value;
                }
            }

            public decimal CantMetEnv02
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOCompra.CantMetEnv02Column]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.CantMetEnv02Column] = value;
                }
            }

            public decimal CantMetEnv03
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOCompra.CantMetEnv03Column]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.CantMetEnv03Column] = value;
                }
            }

            public decimal CantMinPed
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOCompra.CantMinPedColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.CantMinPedColumn] = value;
                }
            }

            public string Codigo
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCompra.CodigoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.CodigoColumn] = value;
                }
            }

            public string CodMetEnv01
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCompra.CodMetEnv01Column]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.CodMetEnv01Column] = value;
                }
            }

            public string CodMetEnv02
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCompra.CodMetEnv02Column]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.CodMetEnv02Column] = value;
                }
            }

            public string CodMetEnv03
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCompra.CodMetEnv03Column]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.CodMetEnv03Column] = value;
                }
            }

            public string CodMoneda
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCompra.CodMonedaColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.CodMonedaColumn] = value;
                }
            }

            public string CodProv
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCompra.CodProvColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.CodProvColumn] = value;
                }
            }

            public string CodReemplazo
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCompra.CodReemplazoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.CodReemplazoColumn] = value;
                }
            }

            public string DescMetEnv01
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCompra.DescMetEnv01Column]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.DescMetEnv01Column] = value;
                }
            }

            public string DescMetEnv02
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCompra.DescMetEnv02Column]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.DescMetEnv02Column] = value;
                }
            }

            public string DescMetEnv03
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCompra.DescMetEnv03Column]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.DescMetEnv03Column] = value;
                }
            }

            public string Descripcion
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpOCompra.DescripcionColumn]);
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
                    this[this.tablePC1TmpOCompra.DescripcionColumn] = value;
                }
            }

            public DateTime FecEntOC01
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpOCompra.FecEntOC01Column]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.FecEntOC01Column] = value;
                }
            }

            public DateTime FecEntOC02
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpOCompra.FecEntOC02Column]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.FecEntOC02Column] = value;
                }
            }

            public DateTime FecEntOC03
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpOCompra.FecEntOC03Column]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.FecEntOC03Column] = value;
                }
            }

            public DateTime FecReemp
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = DateType.FromObject(this[this.tablePC1TmpOCompra.FecReempColumn]);
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
                    this[this.tablePC1TmpOCompra.FecReempColumn] = value;
                }
            }

            public decimal LoteOptCpra
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOCompra.LoteOptCpraColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.LoteOptCpraColumn] = value;
                }
            }

            public string Moneda
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCompra.MonedaColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.MonedaColumn] = value;
                }
            }

            public decimal NivelRepos
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOCompra.NivelReposColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.NivelReposColumn] = value;
                }
            }

            public string NomProv
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOCompra.NomProvColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.NomProvColumn] = value;
                }
            }

            public decimal OCPend
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOCompra.OCPendColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.OCPendColumn] = value;
                }
            }

            public decimal OV
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOCompra.OVColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.OVColumn] = value;
                }
            }

            public decimal OVRes
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOCompra.OVResColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.OVResColumn] = value;
                }
            }

            public decimal PrecioCpra
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOCompra.PrecioCpraColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.PrecioCpraColumn] = value;
                }
            }

            public decimal PropCpra
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOCompra.PropCpraColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.PropCpraColumn] = value;
                }
            }

            public bool Seleccion
            {
                get
                {
                    return BooleanType.FromObject(this[this.tablePC1TmpOCompra.SeleccionColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.SeleccionColumn] = value;
                }
            }

            public decimal StockAl
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOCompra.StockAlColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOCompra.StockAlColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpOCompraRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataTmpOCompra.PC1TmpOCompraRow eventRow;

            public PC1TmpOCompraRowChangeEvent(DataTmpOCompra.PC1TmpOCompraRow row, DataRowAction action)
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

            public DataTmpOCompra.PC1TmpOCompraRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpOCompraRowChangeEventHandler(object sender, DataTmpOCompra.PC1TmpOCompraRowChangeEvent e);
    }
}

