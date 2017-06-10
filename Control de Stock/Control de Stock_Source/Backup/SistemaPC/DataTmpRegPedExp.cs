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
    public class DataTmpRegPedExp : DataSet
    {
        private PC1TmpRegPedExpDataTable tablePC1TmpRegPedExp;

        public DataTmpRegPedExp()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DataTmpRegPedExp(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["PC1TmpRegPedExp"] != null)
                {
                    this.Tables.Add(new PC1TmpRegPedExpDataTable(dataSet.Tables["PC1TmpRegPedExp"]));
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
            DataTmpRegPedExp exp = (DataTmpRegPedExp) base.Clone();
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
            this.DataSetName = "DataTmpRegPedExp";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DataTmpRegPedExp.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tablePC1TmpRegPedExp = new PC1TmpRegPedExpDataTable();
            this.Tables.Add(this.tablePC1TmpRegPedExp);
        }

        internal void InitVars()
        {
            this.tablePC1TmpRegPedExp = (PC1TmpRegPedExpDataTable) this.Tables["PC1TmpRegPedExp"];
            if (this.tablePC1TmpRegPedExp != null)
            {
                this.tablePC1TmpRegPedExp.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["PC1TmpRegPedExp"] != null)
            {
                this.Tables.Add(new PC1TmpRegPedExpDataTable(dataSet.Tables["PC1TmpRegPedExp"]));
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

        private bool ShouldSerializePC1TmpRegPedExp()
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
        public PC1TmpRegPedExpDataTable PC1TmpRegPedExp
        {
            get
            {
                return this.tablePC1TmpRegPedExp;
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpRegPedExpDataTable : DataTable, IEnumerable
        {
            private DataColumn columnCliente;
            private DataColumn columnFEntConf;
            private DataColumn columnFEntPed;
            private DataColumn columnFormaDesp;
            private DataColumn columnImpAFac;
            private DataColumn columnMoneda;
            private DataColumn columnMontoOV;
            private DataColumn columnNomCli;
            private DataColumn columnNomProv;
            private DataColumn columnNroOCProv;
            private DataColumn columnNroOV;
            private DataColumn columnOCCliente;
            private DataColumn columnPaisDest;
            private DataColumn columnTipo;

            public event DataTmpRegPedExp.PC1TmpRegPedExpRowChangeEventHandler PC1TmpRegPedExpRowChanged;

            public event DataTmpRegPedExp.PC1TmpRegPedExpRowChangeEventHandler PC1TmpRegPedExpRowChanging;

            public event DataTmpRegPedExp.PC1TmpRegPedExpRowChangeEventHandler PC1TmpRegPedExpRowDeleted;

            public event DataTmpRegPedExp.PC1TmpRegPedExpRowChangeEventHandler PC1TmpRegPedExpRowDeleting;

            internal PC1TmpRegPedExpDataTable() : base("PC1TmpRegPedExp")
            {
                this.InitClass();
            }

            internal PC1TmpRegPedExpDataTable(DataTable table) : base(table.TableName)
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

            public void AddPC1TmpRegPedExpRow(DataTmpRegPedExp.PC1TmpRegPedExpRow row)
            {
                this.Rows.Add(row);
            }

            public DataTmpRegPedExp.PC1TmpRegPedExpRow AddPC1TmpRegPedExpRow(int Tipo, string Cliente, string NomCli, string OCCliente, string NroOV, string NroOCProv, string NomProv, DateTime FEntPed, DateTime FEntConf, string PaisDest, string Moneda, decimal MontoOV, decimal ImpAFac, string FormaDesp)
            {
                DataTmpRegPedExp.PC1TmpRegPedExpRow row = (DataTmpRegPedExp.PC1TmpRegPedExpRow) this.NewRow();
                row.ItemArray = new object[] { Tipo, Cliente, NomCli, OCCliente, NroOV, NroOCProv, NomProv, FEntPed, FEntConf, PaisDest, Moneda, MontoOV, ImpAFac, FormaDesp };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataTmpRegPedExp.PC1TmpRegPedExpDataTable table = (DataTmpRegPedExp.PC1TmpRegPedExpDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataTmpRegPedExp.PC1TmpRegPedExpDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataTmpRegPedExp.PC1TmpRegPedExpRow);
            }

            private void InitClass()
            {
                this.columnTipo = new DataColumn("Tipo", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnTipo);
                this.columnCliente = new DataColumn("Cliente", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCliente);
                this.columnNomCli = new DataColumn("NomCli", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNomCli);
                this.columnOCCliente = new DataColumn("OCCliente", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOCCliente);
                this.columnNroOV = new DataColumn("NroOV", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOV);
                this.columnNroOCProv = new DataColumn("NroOCProv", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOCProv);
                this.columnNomProv = new DataColumn("NomProv", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNomProv);
                this.columnFEntPed = new DataColumn("FEntPed", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFEntPed);
                this.columnFEntConf = new DataColumn("FEntConf", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFEntConf);
                this.columnPaisDest = new DataColumn("PaisDest", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPaisDest);
                this.columnMoneda = new DataColumn("Moneda", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnMoneda);
                this.columnMontoOV = new DataColumn("MontoOV", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnMontoOV);
                this.columnImpAFac = new DataColumn("ImpAFac", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnImpAFac);
                this.columnFormaDesp = new DataColumn("FormaDesp", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnFormaDesp);
                this.columnTipo.AllowDBNull = false;
                this.columnCliente.AllowDBNull = false;
                this.columnNomCli.AllowDBNull = false;
                this.columnNroOV.AllowDBNull = false;
                this.columnFEntPed.AllowDBNull = false;
                this.columnFEntConf.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnTipo = this.Columns["Tipo"];
                this.columnCliente = this.Columns["Cliente"];
                this.columnNomCli = this.Columns["NomCli"];
                this.columnOCCliente = this.Columns["OCCliente"];
                this.columnNroOV = this.Columns["NroOV"];
                this.columnNroOCProv = this.Columns["NroOCProv"];
                this.columnNomProv = this.Columns["NomProv"];
                this.columnFEntPed = this.Columns["FEntPed"];
                this.columnFEntConf = this.Columns["FEntConf"];
                this.columnPaisDest = this.Columns["PaisDest"];
                this.columnMoneda = this.Columns["Moneda"];
                this.columnMontoOV = this.Columns["MontoOV"];
                this.columnImpAFac = this.Columns["ImpAFac"];
                this.columnFormaDesp = this.Columns["FormaDesp"];
            }

            public DataTmpRegPedExp.PC1TmpRegPedExpRow NewPC1TmpRegPedExpRow()
            {
                return (DataTmpRegPedExp.PC1TmpRegPedExpRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataTmpRegPedExp.PC1TmpRegPedExpRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpRegPedExpRowChangedEvent != null) && (this.PC1TmpRegPedExpRowChangedEvent != null))
                {
                    this.PC1TmpRegPedExpRowChangedEvent(this, new DataTmpRegPedExp.PC1TmpRegPedExpRowChangeEvent((DataTmpRegPedExp.PC1TmpRegPedExpRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpRegPedExpRowChangingEvent != null) && (this.PC1TmpRegPedExpRowChangingEvent != null))
                {
                    this.PC1TmpRegPedExpRowChangingEvent(this, new DataTmpRegPedExp.PC1TmpRegPedExpRowChangeEvent((DataTmpRegPedExp.PC1TmpRegPedExpRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpRegPedExpRowDeletedEvent != null) && (this.PC1TmpRegPedExpRowDeletedEvent != null))
                {
                    this.PC1TmpRegPedExpRowDeletedEvent(this, new DataTmpRegPedExp.PC1TmpRegPedExpRowChangeEvent((DataTmpRegPedExp.PC1TmpRegPedExpRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpRegPedExpRowDeletingEvent != null) && (this.PC1TmpRegPedExpRowDeletingEvent != null))
                {
                    this.PC1TmpRegPedExpRowDeletingEvent(this, new DataTmpRegPedExp.PC1TmpRegPedExpRowChangeEvent((DataTmpRegPedExp.PC1TmpRegPedExpRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpRegPedExpRow(DataTmpRegPedExp.PC1TmpRegPedExpRow row)
            {
                this.Rows.Remove(row);
            }

            internal DataColumn ClienteColumn
            {
                get
                {
                    return this.columnCliente;
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

            internal DataColumn FEntConfColumn
            {
                get
                {
                    return this.columnFEntConf;
                }
            }

            internal DataColumn FEntPedColumn
            {
                get
                {
                    return this.columnFEntPed;
                }
            }

            internal DataColumn FormaDespColumn
            {
                get
                {
                    return this.columnFormaDesp;
                }
            }

            internal DataColumn ImpAFacColumn
            {
                get
                {
                    return this.columnImpAFac;
                }
            }

            public DataTmpRegPedExp.PC1TmpRegPedExpRow this[int index]
            {
                get
                {
                    return (DataTmpRegPedExp.PC1TmpRegPedExpRow) this.Rows[index];
                }
            }

            internal DataColumn MonedaColumn
            {
                get
                {
                    return this.columnMoneda;
                }
            }

            internal DataColumn MontoOVColumn
            {
                get
                {
                    return this.columnMontoOV;
                }
            }

            internal DataColumn NomCliColumn
            {
                get
                {
                    return this.columnNomCli;
                }
            }

            internal DataColumn NomProvColumn
            {
                get
                {
                    return this.columnNomProv;
                }
            }

            internal DataColumn NroOCProvColumn
            {
                get
                {
                    return this.columnNroOCProv;
                }
            }

            internal DataColumn NroOVColumn
            {
                get
                {
                    return this.columnNroOV;
                }
            }

            internal DataColumn OCClienteColumn
            {
                get
                {
                    return this.columnOCCliente;
                }
            }

            internal DataColumn PaisDestColumn
            {
                get
                {
                    return this.columnPaisDest;
                }
            }

            internal DataColumn TipoColumn
            {
                get
                {
                    return this.columnTipo;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpRegPedExpRow : DataRow
        {
            private DataTmpRegPedExp.PC1TmpRegPedExpDataTable tablePC1TmpRegPedExp;

            internal PC1TmpRegPedExpRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpRegPedExp = (DataTmpRegPedExp.PC1TmpRegPedExpDataTable) this.Table;
            }

            public bool IsFormaDespNull()
            {
                return this.IsNull(this.tablePC1TmpRegPedExp.FormaDespColumn);
            }

            public bool IsImpAFacNull()
            {
                return this.IsNull(this.tablePC1TmpRegPedExp.ImpAFacColumn);
            }

            public bool IsMonedaNull()
            {
                return this.IsNull(this.tablePC1TmpRegPedExp.MonedaColumn);
            }

            public bool IsMontoOVNull()
            {
                return this.IsNull(this.tablePC1TmpRegPedExp.MontoOVColumn);
            }

            public bool IsNomProvNull()
            {
                return this.IsNull(this.tablePC1TmpRegPedExp.NomProvColumn);
            }

            public bool IsNroOCProvNull()
            {
                return this.IsNull(this.tablePC1TmpRegPedExp.NroOCProvColumn);
            }

            public bool IsOCClienteNull()
            {
                return this.IsNull(this.tablePC1TmpRegPedExp.OCClienteColumn);
            }

            public bool IsPaisDestNull()
            {
                return this.IsNull(this.tablePC1TmpRegPedExp.PaisDestColumn);
            }

            public void SetFormaDespNull()
            {
                this[this.tablePC1TmpRegPedExp.FormaDespColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetImpAFacNull()
            {
                this[this.tablePC1TmpRegPedExp.ImpAFacColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMonedaNull()
            {
                this[this.tablePC1TmpRegPedExp.MonedaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMontoOVNull()
            {
                this[this.tablePC1TmpRegPedExp.MontoOVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNomProvNull()
            {
                this[this.tablePC1TmpRegPedExp.NomProvColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNroOCProvNull()
            {
                this[this.tablePC1TmpRegPedExp.NroOCProvColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOCClienteNull()
            {
                this[this.tablePC1TmpRegPedExp.OCClienteColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPaisDestNull()
            {
                this[this.tablePC1TmpRegPedExp.PaisDestColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string Cliente
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpRegPedExp.ClienteColumn]);
                }
                set
                {
                    this[this.tablePC1TmpRegPedExp.ClienteColumn] = value;
                }
            }

            public DateTime FEntConf
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpRegPedExp.FEntConfColumn]);
                }
                set
                {
                    this[this.tablePC1TmpRegPedExp.FEntConfColumn] = value;
                }
            }

            public DateTime FEntPed
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpRegPedExp.FEntPedColumn]);
                }
                set
                {
                    this[this.tablePC1TmpRegPedExp.FEntPedColumn] = value;
                }
            }

            public string FormaDesp
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpRegPedExp.FormaDespColumn]);
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
                    this[this.tablePC1TmpRegPedExp.FormaDespColumn] = value;
                }
            }

            public decimal ImpAFac
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tablePC1TmpRegPedExp.ImpAFacColumn]);
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
                    this[this.tablePC1TmpRegPedExp.ImpAFacColumn] = value;
                }
            }

            public string Moneda
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpRegPedExp.MonedaColumn]);
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
                    this[this.tablePC1TmpRegPedExp.MonedaColumn] = value;
                }
            }

            public decimal MontoOV
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = DecimalType.FromObject(this[this.tablePC1TmpRegPedExp.MontoOVColumn]);
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
                    this[this.tablePC1TmpRegPedExp.MontoOVColumn] = value;
                }
            }

            public string NomCli
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpRegPedExp.NomCliColumn]);
                }
                set
                {
                    this[this.tablePC1TmpRegPedExp.NomCliColumn] = value;
                }
            }

            public string NomProv
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpRegPedExp.NomProvColumn]);
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
                    this[this.tablePC1TmpRegPedExp.NomProvColumn] = value;
                }
            }

            public string NroOCProv
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpRegPedExp.NroOCProvColumn]);
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
                    this[this.tablePC1TmpRegPedExp.NroOCProvColumn] = value;
                }
            }

            public string NroOV
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpRegPedExp.NroOVColumn]);
                }
                set
                {
                    this[this.tablePC1TmpRegPedExp.NroOVColumn] = value;
                }
            }

            public string OCCliente
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpRegPedExp.OCClienteColumn]);
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
                    this[this.tablePC1TmpRegPedExp.OCClienteColumn] = value;
                }
            }

            public string PaisDest
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpRegPedExp.PaisDestColumn]);
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
                    this[this.tablePC1TmpRegPedExp.PaisDestColumn] = value;
                }
            }

            public int Tipo
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC1TmpRegPedExp.TipoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpRegPedExp.TipoColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpRegPedExpRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataTmpRegPedExp.PC1TmpRegPedExpRow eventRow;

            public PC1TmpRegPedExpRowChangeEvent(DataTmpRegPedExp.PC1TmpRegPedExpRow row, DataRowAction action)
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

            public DataTmpRegPedExp.PC1TmpRegPedExpRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpRegPedExpRowChangeEventHandler(object sender, DataTmpRegPedExp.PC1TmpRegPedExpRowChangeEvent e);
    }
}

