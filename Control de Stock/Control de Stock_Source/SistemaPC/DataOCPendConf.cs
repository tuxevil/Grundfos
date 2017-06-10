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
    public class DataOCPendConf : DataSet
    {
        private PC010100DataTable tablePC010100;
        private PC030100DataTable tablePC030100;
        private PC1TmpDetDesDataTable tablePC1TmpDetDes;
        private PC1TmpFormaDespDataTable tablePC1TmpFormaDesp;
        private PL010100DataTable tablePL010100;
        private SL010100DataTable tableSL010100;

        public DataOCPendConf()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DataOCPendConf(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["PC010100"] != null)
                {
                    this.Tables.Add(new PC010100DataTable(dataSet.Tables["PC010100"]));
                }
                if (dataSet.Tables["PC030100"] != null)
                {
                    this.Tables.Add(new PC030100DataTable(dataSet.Tables["PC030100"]));
                }
                if (dataSet.Tables["PL010100"] != null)
                {
                    this.Tables.Add(new PL010100DataTable(dataSet.Tables["PL010100"]));
                }
                if (dataSet.Tables["SL010100"] != null)
                {
                    this.Tables.Add(new SL010100DataTable(dataSet.Tables["SL010100"]));
                }
                if (dataSet.Tables["PC1TmpFormaDesp"] != null)
                {
                    this.Tables.Add(new PC1TmpFormaDespDataTable(dataSet.Tables["PC1TmpFormaDesp"]));
                }
                if (dataSet.Tables["PC1TmpDetDes"] != null)
                {
                    this.Tables.Add(new PC1TmpDetDesDataTable(dataSet.Tables["PC1TmpDetDes"]));
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
            DataOCPendConf conf = (DataOCPendConf) base.Clone();
            conf.InitVars();
            return conf;
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
            this.DataSetName = "DataOCPendConf";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DataOCPendConf.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tablePC010100 = new PC010100DataTable();
            this.Tables.Add(this.tablePC010100);
            this.tablePC030100 = new PC030100DataTable();
            this.Tables.Add(this.tablePC030100);
            this.tablePL010100 = new PL010100DataTable();
            this.Tables.Add(this.tablePL010100);
            this.tableSL010100 = new SL010100DataTable();
            this.Tables.Add(this.tableSL010100);
            this.tablePC1TmpFormaDesp = new PC1TmpFormaDespDataTable();
            this.Tables.Add(this.tablePC1TmpFormaDesp);
            this.tablePC1TmpDetDes = new PC1TmpDetDesDataTable();
            this.Tables.Add(this.tablePC1TmpDetDes);
        }

        internal void InitVars()
        {
            this.tablePC010100 = (PC010100DataTable) this.Tables["PC010100"];
            if (this.tablePC010100 != null)
            {
                this.tablePC010100.InitVars();
            }
            this.tablePC030100 = (PC030100DataTable) this.Tables["PC030100"];
            if (this.tablePC030100 != null)
            {
                this.tablePC030100.InitVars();
            }
            this.tablePL010100 = (PL010100DataTable) this.Tables["PL010100"];
            if (this.tablePL010100 != null)
            {
                this.tablePL010100.InitVars();
            }
            this.tableSL010100 = (SL010100DataTable) this.Tables["SL010100"];
            if (this.tableSL010100 != null)
            {
                this.tableSL010100.InitVars();
            }
            this.tablePC1TmpFormaDesp = (PC1TmpFormaDespDataTable) this.Tables["PC1TmpFormaDesp"];
            if (this.tablePC1TmpFormaDesp != null)
            {
                this.tablePC1TmpFormaDesp.InitVars();
            }
            this.tablePC1TmpDetDes = (PC1TmpDetDesDataTable) this.Tables["PC1TmpDetDes"];
            if (this.tablePC1TmpDetDes != null)
            {
                this.tablePC1TmpDetDes.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["PC010100"] != null)
            {
                this.Tables.Add(new PC010100DataTable(dataSet.Tables["PC010100"]));
            }
            if (dataSet.Tables["PC030100"] != null)
            {
                this.Tables.Add(new PC030100DataTable(dataSet.Tables["PC030100"]));
            }
            if (dataSet.Tables["PL010100"] != null)
            {
                this.Tables.Add(new PL010100DataTable(dataSet.Tables["PL010100"]));
            }
            if (dataSet.Tables["SL010100"] != null)
            {
                this.Tables.Add(new SL010100DataTable(dataSet.Tables["SL010100"]));
            }
            if (dataSet.Tables["PC1TmpFormaDesp"] != null)
            {
                this.Tables.Add(new PC1TmpFormaDespDataTable(dataSet.Tables["PC1TmpFormaDesp"]));
            }
            if (dataSet.Tables["PC1TmpDetDes"] != null)
            {
                this.Tables.Add(new PC1TmpDetDesDataTable(dataSet.Tables["PC1TmpDetDes"]));
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

        private bool ShouldSerializePC010100()
        {
            return false;
        }

        private bool ShouldSerializePC030100()
        {
            return false;
        }

        private bool ShouldSerializePC1TmpDetDes()
        {
            return false;
        }

        private bool ShouldSerializePC1TmpFormaDesp()
        {
            return false;
        }

        private bool ShouldSerializePL010100()
        {
            return false;
        }

        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        private bool ShouldSerializeSL010100()
        {
            return false;
        }

        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public PC010100DataTable PC010100
        {
            get
            {
                return this.tablePC010100;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public PC030100DataTable PC030100
        {
            get
            {
                return this.tablePC030100;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public PC1TmpDetDesDataTable PC1TmpDetDes
        {
            get
            {
                return this.tablePC1TmpDetDes;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public PC1TmpFormaDespDataTable PC1TmpFormaDesp
        {
            get
            {
                return this.tablePC1TmpFormaDesp;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public PL010100DataTable PL010100
        {
            get
            {
                return this.tablePL010100;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public SL010100DataTable SL010100
        {
            get
            {
                return this.tableSL010100;
            }
        }

        [DebuggerStepThrough]
        public class PC010100DataTable : DataTable, IEnumerable
        {
            private DataColumn columnPC01001;
            private DataColumn columnPC01002;
            private DataColumn columnPC01003;
            private DataColumn columnPC01004;
            private DataColumn columnPC01005;
            private DataColumn columnPC01006;
            private DataColumn columnPC01007;
            private DataColumn columnPC01008;
            private DataColumn columnPC01009;
            private DataColumn columnPC01010;
            private DataColumn columnPC01011;
            private DataColumn columnPC01012;
            private DataColumn columnPC01013;
            private DataColumn columnPC01014;
            private DataColumn columnPC01015;
            private DataColumn columnPC01016;
            private DataColumn columnPC01017;
            private DataColumn columnPC01018;
            private DataColumn columnPC01019;
            private DataColumn columnPC01020;
            private DataColumn columnPC01021;
            private DataColumn columnPC01022;
            private DataColumn columnPC01023;
            private DataColumn columnPC01024;
            private DataColumn columnPC01025;
            private DataColumn columnPC01026;
            private DataColumn columnPC01027;
            private DataColumn columnPC01028;
            private DataColumn columnPC01029;
            private DataColumn columnPC01030;
            private DataColumn columnPC01031;
            private DataColumn columnPC01032;
            private DataColumn columnPC01033;
            private DataColumn columnPC01034;
            private DataColumn columnPC01035;
            private DataColumn columnPC01036;
            private DataColumn columnPC01037;
            private DataColumn columnPC01038;
            private DataColumn columnPC01039;
            private DataColumn columnPC01040;
            private DataColumn columnPC01041;
            private DataColumn columnPC01042;
            private DataColumn columnPC01043;
            private DataColumn columnPC01044;
            private DataColumn columnPC01045;
            private DataColumn columnPC01046;
            private DataColumn columnPC01047;
            private DataColumn columnPC01048;
            private DataColumn columnPC01049;
            private DataColumn columnPC01050;
            private DataColumn columnPC01051;
            private DataColumn columnPC01052;
            private DataColumn columnPC01053;
            private DataColumn columnPC01054;
            private DataColumn columnPC01055;
            private DataColumn columnPC01056;
            private DataColumn columnPC01057;
            private DataColumn columnPC01058;

            public event DataOCPendConf.PC010100RowChangeEventHandler PC010100RowChanged;

            public event DataOCPendConf.PC010100RowChangeEventHandler PC010100RowChanging;

            public event DataOCPendConf.PC010100RowChangeEventHandler PC010100RowDeleted;

            public event DataOCPendConf.PC010100RowChangeEventHandler PC010100RowDeleting;

            internal PC010100DataTable() : base("PC010100")
            {
                this.InitClass();
            }

            internal PC010100DataTable(DataTable table) : base(table.TableName)
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

            public void AddPC010100Row(DataOCPendConf.PC010100Row row)
            {
                this.Rows.Add(row);
            }

            public DataOCPendConf.PC010100Row AddPC010100Row(string PC01001, int PC01002, string PC01003, string PC01004, string PC01005, string PC01006, int PC01007, int PC01008, int PC01009, string PC01010, string PC01011, int PC01012, int PC01013, int PC01014, DateTime PC01015, DateTime PC01016, string PC01017, string PC01018, decimal PC01019, decimal PC01020, int PC01021, int PC01022, string PC01023, string PC01024, string PC01025, string PC01026, string PC01027, string PC01028, string PC01029, string PC01030, decimal PC01031, string PC01032, string PC01033, string PC01034, DateTime PC01035, DateTime PC01036, string PC01037, string PC01038, int PC01039, int PC01040, string PC01041, string PC01042, string PC01043, string PC01044, string PC01045, string PC01046, decimal PC01047, string PC01048, string PC01049, string PC01050, string PC01051, string PC01052, string PC01053, string PC01054, string PC01055, string PC01056, string PC01057, DateTime PC01058)
            {
                DataOCPendConf.PC010100Row row = (DataOCPendConf.PC010100Row) this.NewRow();
                row.ItemArray = new object[] { 
                    PC01001, PC01002, PC01003, PC01004, PC01005, PC01006, PC01007, PC01008, PC01009, PC01010, PC01011, PC01012, PC01013, PC01014, PC01015, PC01016, 
                    PC01017, PC01018, PC01019, PC01020, PC01021, PC01022, PC01023, PC01024, PC01025, PC01026, PC01027, PC01028, PC01029, PC01030, PC01031, PC01032, 
                    PC01033, PC01034, PC01035, PC01036, PC01037, PC01038, PC01039, PC01040, PC01041, PC01042, PC01043, PC01044, PC01045, PC01046, PC01047, PC01048, 
                    PC01049, PC01050, PC01051, PC01052, PC01053, PC01054, PC01055, PC01056, PC01057, PC01058
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataOCPendConf.PC010100DataTable table = (DataOCPendConf.PC010100DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataOCPendConf.PC010100DataTable();
            }

            public DataOCPendConf.PC010100Row FindByPC01001(string PC01001)
            {
                return (DataOCPendConf.PC010100Row) this.Rows.Find(new object[] { PC01001 });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataOCPendConf.PC010100Row);
            }

            private void InitClass()
            {
                this.columnPC01001 = new DataColumn("PC01001", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01001);
                this.columnPC01002 = new DataColumn("PC01002", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnPC01002);
                this.columnPC01003 = new DataColumn("PC01003", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01003);
                this.columnPC01004 = new DataColumn("PC01004", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01004);
                this.columnPC01005 = new DataColumn("PC01005", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01005);
                this.columnPC01006 = new DataColumn("PC01006", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01006);
                this.columnPC01007 = new DataColumn("PC01007", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnPC01007);
                this.columnPC01008 = new DataColumn("PC01008", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnPC01008);
                this.columnPC01009 = new DataColumn("PC01009", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnPC01009);
                this.columnPC01010 = new DataColumn("PC01010", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01010);
                this.columnPC01011 = new DataColumn("PC01011", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01011);
                this.columnPC01012 = new DataColumn("PC01012", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnPC01012);
                this.columnPC01013 = new DataColumn("PC01013", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnPC01013);
                this.columnPC01014 = new DataColumn("PC01014", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnPC01014);
                this.columnPC01015 = new DataColumn("PC01015", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnPC01015);
                this.columnPC01016 = new DataColumn("PC01016", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnPC01016);
                this.columnPC01017 = new DataColumn("PC01017", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01017);
                this.columnPC01018 = new DataColumn("PC01018", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01018);
                this.columnPC01019 = new DataColumn("PC01019", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC01019);
                this.columnPC01020 = new DataColumn("PC01020", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC01020);
                this.columnPC01021 = new DataColumn("PC01021", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnPC01021);
                this.columnPC01022 = new DataColumn("PC01022", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnPC01022);
                this.columnPC01023 = new DataColumn("PC01023", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01023);
                this.columnPC01024 = new DataColumn("PC01024", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01024);
                this.columnPC01025 = new DataColumn("PC01025", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01025);
                this.columnPC01026 = new DataColumn("PC01026", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01026);
                this.columnPC01027 = new DataColumn("PC01027", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01027);
                this.columnPC01028 = new DataColumn("PC01028", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01028);
                this.columnPC01029 = new DataColumn("PC01029", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01029);
                this.columnPC01030 = new DataColumn("PC01030", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01030);
                this.columnPC01031 = new DataColumn("PC01031", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC01031);
                this.columnPC01032 = new DataColumn("PC01032", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01032);
                this.columnPC01033 = new DataColumn("PC01033", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01033);
                this.columnPC01034 = new DataColumn("PC01034", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01034);
                this.columnPC01035 = new DataColumn("PC01035", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnPC01035);
                this.columnPC01036 = new DataColumn("PC01036", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnPC01036);
                this.columnPC01037 = new DataColumn("PC01037", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01037);
                this.columnPC01038 = new DataColumn("PC01038", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01038);
                this.columnPC01039 = new DataColumn("PC01039", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnPC01039);
                this.columnPC01040 = new DataColumn("PC01040", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnPC01040);
                this.columnPC01041 = new DataColumn("PC01041", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01041);
                this.columnPC01042 = new DataColumn("PC01042", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01042);
                this.columnPC01043 = new DataColumn("PC01043", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01043);
                this.columnPC01044 = new DataColumn("PC01044", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01044);
                this.columnPC01045 = new DataColumn("PC01045", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01045);
                this.columnPC01046 = new DataColumn("PC01046", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01046);
                this.columnPC01047 = new DataColumn("PC01047", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC01047);
                this.columnPC01048 = new DataColumn("PC01048", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01048);
                this.columnPC01049 = new DataColumn("PC01049", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01049);
                this.columnPC01050 = new DataColumn("PC01050", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01050);
                this.columnPC01051 = new DataColumn("PC01051", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01051);
                this.columnPC01052 = new DataColumn("PC01052", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01052);
                this.columnPC01053 = new DataColumn("PC01053", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01053);
                this.columnPC01054 = new DataColumn("PC01054", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01054);
                this.columnPC01055 = new DataColumn("PC01055", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01055);
                this.columnPC01056 = new DataColumn("PC01056", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01056);
                this.columnPC01057 = new DataColumn("PC01057", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC01057);
                this.columnPC01058 = new DataColumn("PC01058", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnPC01058);
                this.Constraints.Add(new UniqueConstraint("DataOCPendConfKey1", new DataColumn[] { this.columnPC01001 }, true));
                this.columnPC01001.AllowDBNull = false;
                this.columnPC01001.Unique = true;
                this.columnPC01002.AllowDBNull = false;
                this.columnPC01003.AllowDBNull = false;
                this.columnPC01004.AllowDBNull = false;
                this.columnPC01005.AllowDBNull = false;
                this.columnPC01006.AllowDBNull = false;
                this.columnPC01007.AllowDBNull = false;
                this.columnPC01008.AllowDBNull = false;
                this.columnPC01009.AllowDBNull = false;
                this.columnPC01010.AllowDBNull = false;
                this.columnPC01011.AllowDBNull = false;
                this.columnPC01012.AllowDBNull = false;
                this.columnPC01013.AllowDBNull = false;
                this.columnPC01014.AllowDBNull = false;
                this.columnPC01015.AllowDBNull = false;
                this.columnPC01016.AllowDBNull = false;
                this.columnPC01017.AllowDBNull = false;
                this.columnPC01018.AllowDBNull = false;
                this.columnPC01019.AllowDBNull = false;
                this.columnPC01020.AllowDBNull = false;
                this.columnPC01021.AllowDBNull = false;
                this.columnPC01022.AllowDBNull = false;
                this.columnPC01023.AllowDBNull = false;
                this.columnPC01024.AllowDBNull = false;
                this.columnPC01025.AllowDBNull = false;
                this.columnPC01026.AllowDBNull = false;
                this.columnPC01027.AllowDBNull = false;
                this.columnPC01028.AllowDBNull = false;
                this.columnPC01029.AllowDBNull = false;
                this.columnPC01030.AllowDBNull = false;
                this.columnPC01031.AllowDBNull = false;
                this.columnPC01032.AllowDBNull = false;
                this.columnPC01033.AllowDBNull = false;
                this.columnPC01034.AllowDBNull = false;
                this.columnPC01035.AllowDBNull = false;
                this.columnPC01036.AllowDBNull = false;
                this.columnPC01037.AllowDBNull = false;
                this.columnPC01038.AllowDBNull = false;
                this.columnPC01039.AllowDBNull = false;
                this.columnPC01040.AllowDBNull = false;
                this.columnPC01041.AllowDBNull = false;
                this.columnPC01042.AllowDBNull = false;
                this.columnPC01043.AllowDBNull = false;
                this.columnPC01044.AllowDBNull = false;
                this.columnPC01045.AllowDBNull = false;
                this.columnPC01046.AllowDBNull = false;
                this.columnPC01047.AllowDBNull = false;
                this.columnPC01048.AllowDBNull = false;
                this.columnPC01049.AllowDBNull = false;
                this.columnPC01050.AllowDBNull = false;
                this.columnPC01051.AllowDBNull = false;
                this.columnPC01052.AllowDBNull = false;
                this.columnPC01053.AllowDBNull = false;
                this.columnPC01054.AllowDBNull = false;
                this.columnPC01055.AllowDBNull = false;
                this.columnPC01056.AllowDBNull = false;
                this.columnPC01057.AllowDBNull = false;
                this.columnPC01058.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnPC01001 = this.Columns["PC01001"];
                this.columnPC01002 = this.Columns["PC01002"];
                this.columnPC01003 = this.Columns["PC01003"];
                this.columnPC01004 = this.Columns["PC01004"];
                this.columnPC01005 = this.Columns["PC01005"];
                this.columnPC01006 = this.Columns["PC01006"];
                this.columnPC01007 = this.Columns["PC01007"];
                this.columnPC01008 = this.Columns["PC01008"];
                this.columnPC01009 = this.Columns["PC01009"];
                this.columnPC01010 = this.Columns["PC01010"];
                this.columnPC01011 = this.Columns["PC01011"];
                this.columnPC01012 = this.Columns["PC01012"];
                this.columnPC01013 = this.Columns["PC01013"];
                this.columnPC01014 = this.Columns["PC01014"];
                this.columnPC01015 = this.Columns["PC01015"];
                this.columnPC01016 = this.Columns["PC01016"];
                this.columnPC01017 = this.Columns["PC01017"];
                this.columnPC01018 = this.Columns["PC01018"];
                this.columnPC01019 = this.Columns["PC01019"];
                this.columnPC01020 = this.Columns["PC01020"];
                this.columnPC01021 = this.Columns["PC01021"];
                this.columnPC01022 = this.Columns["PC01022"];
                this.columnPC01023 = this.Columns["PC01023"];
                this.columnPC01024 = this.Columns["PC01024"];
                this.columnPC01025 = this.Columns["PC01025"];
                this.columnPC01026 = this.Columns["PC01026"];
                this.columnPC01027 = this.Columns["PC01027"];
                this.columnPC01028 = this.Columns["PC01028"];
                this.columnPC01029 = this.Columns["PC01029"];
                this.columnPC01030 = this.Columns["PC01030"];
                this.columnPC01031 = this.Columns["PC01031"];
                this.columnPC01032 = this.Columns["PC01032"];
                this.columnPC01033 = this.Columns["PC01033"];
                this.columnPC01034 = this.Columns["PC01034"];
                this.columnPC01035 = this.Columns["PC01035"];
                this.columnPC01036 = this.Columns["PC01036"];
                this.columnPC01037 = this.Columns["PC01037"];
                this.columnPC01038 = this.Columns["PC01038"];
                this.columnPC01039 = this.Columns["PC01039"];
                this.columnPC01040 = this.Columns["PC01040"];
                this.columnPC01041 = this.Columns["PC01041"];
                this.columnPC01042 = this.Columns["PC01042"];
                this.columnPC01043 = this.Columns["PC01043"];
                this.columnPC01044 = this.Columns["PC01044"];
                this.columnPC01045 = this.Columns["PC01045"];
                this.columnPC01046 = this.Columns["PC01046"];
                this.columnPC01047 = this.Columns["PC01047"];
                this.columnPC01048 = this.Columns["PC01048"];
                this.columnPC01049 = this.Columns["PC01049"];
                this.columnPC01050 = this.Columns["PC01050"];
                this.columnPC01051 = this.Columns["PC01051"];
                this.columnPC01052 = this.Columns["PC01052"];
                this.columnPC01053 = this.Columns["PC01053"];
                this.columnPC01054 = this.Columns["PC01054"];
                this.columnPC01055 = this.Columns["PC01055"];
                this.columnPC01056 = this.Columns["PC01056"];
                this.columnPC01057 = this.Columns["PC01057"];
                this.columnPC01058 = this.Columns["PC01058"];
            }

            public DataOCPendConf.PC010100Row NewPC010100Row()
            {
                return (DataOCPendConf.PC010100Row) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataOCPendConf.PC010100Row(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC010100RowChangedEvent != null) && (this.PC010100RowChangedEvent != null))
                {
                    this.PC010100RowChangedEvent(this, new DataOCPendConf.PC010100RowChangeEvent((DataOCPendConf.PC010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC010100RowChangingEvent != null) && (this.PC010100RowChangingEvent != null))
                {
                    this.PC010100RowChangingEvent(this, new DataOCPendConf.PC010100RowChangeEvent((DataOCPendConf.PC010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC010100RowDeletedEvent != null) && (this.PC010100RowDeletedEvent != null))
                {
                    this.PC010100RowDeletedEvent(this, new DataOCPendConf.PC010100RowChangeEvent((DataOCPendConf.PC010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC010100RowDeletingEvent != null) && (this.PC010100RowDeletingEvent != null))
                {
                    this.PC010100RowDeletingEvent(this, new DataOCPendConf.PC010100RowChangeEvent((DataOCPendConf.PC010100Row) e.Row, e.Action));
                }
            }

            public void RemovePC010100Row(DataOCPendConf.PC010100Row row)
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

            public DataOCPendConf.PC010100Row this[int index]
            {
                get
                {
                    return (DataOCPendConf.PC010100Row) this.Rows[index];
                }
            }

            internal DataColumn PC01001Column
            {
                get
                {
                    return this.columnPC01001;
                }
            }

            internal DataColumn PC01002Column
            {
                get
                {
                    return this.columnPC01002;
                }
            }

            internal DataColumn PC01003Column
            {
                get
                {
                    return this.columnPC01003;
                }
            }

            internal DataColumn PC01004Column
            {
                get
                {
                    return this.columnPC01004;
                }
            }

            internal DataColumn PC01005Column
            {
                get
                {
                    return this.columnPC01005;
                }
            }

            internal DataColumn PC01006Column
            {
                get
                {
                    return this.columnPC01006;
                }
            }

            internal DataColumn PC01007Column
            {
                get
                {
                    return this.columnPC01007;
                }
            }

            internal DataColumn PC01008Column
            {
                get
                {
                    return this.columnPC01008;
                }
            }

            internal DataColumn PC01009Column
            {
                get
                {
                    return this.columnPC01009;
                }
            }

            internal DataColumn PC01010Column
            {
                get
                {
                    return this.columnPC01010;
                }
            }

            internal DataColumn PC01011Column
            {
                get
                {
                    return this.columnPC01011;
                }
            }

            internal DataColumn PC01012Column
            {
                get
                {
                    return this.columnPC01012;
                }
            }

            internal DataColumn PC01013Column
            {
                get
                {
                    return this.columnPC01013;
                }
            }

            internal DataColumn PC01014Column
            {
                get
                {
                    return this.columnPC01014;
                }
            }

            internal DataColumn PC01015Column
            {
                get
                {
                    return this.columnPC01015;
                }
            }

            internal DataColumn PC01016Column
            {
                get
                {
                    return this.columnPC01016;
                }
            }

            internal DataColumn PC01017Column
            {
                get
                {
                    return this.columnPC01017;
                }
            }

            internal DataColumn PC01018Column
            {
                get
                {
                    return this.columnPC01018;
                }
            }

            internal DataColumn PC01019Column
            {
                get
                {
                    return this.columnPC01019;
                }
            }

            internal DataColumn PC01020Column
            {
                get
                {
                    return this.columnPC01020;
                }
            }

            internal DataColumn PC01021Column
            {
                get
                {
                    return this.columnPC01021;
                }
            }

            internal DataColumn PC01022Column
            {
                get
                {
                    return this.columnPC01022;
                }
            }

            internal DataColumn PC01023Column
            {
                get
                {
                    return this.columnPC01023;
                }
            }

            internal DataColumn PC01024Column
            {
                get
                {
                    return this.columnPC01024;
                }
            }

            internal DataColumn PC01025Column
            {
                get
                {
                    return this.columnPC01025;
                }
            }

            internal DataColumn PC01026Column
            {
                get
                {
                    return this.columnPC01026;
                }
            }

            internal DataColumn PC01027Column
            {
                get
                {
                    return this.columnPC01027;
                }
            }

            internal DataColumn PC01028Column
            {
                get
                {
                    return this.columnPC01028;
                }
            }

            internal DataColumn PC01029Column
            {
                get
                {
                    return this.columnPC01029;
                }
            }

            internal DataColumn PC01030Column
            {
                get
                {
                    return this.columnPC01030;
                }
            }

            internal DataColumn PC01031Column
            {
                get
                {
                    return this.columnPC01031;
                }
            }

            internal DataColumn PC01032Column
            {
                get
                {
                    return this.columnPC01032;
                }
            }

            internal DataColumn PC01033Column
            {
                get
                {
                    return this.columnPC01033;
                }
            }

            internal DataColumn PC01034Column
            {
                get
                {
                    return this.columnPC01034;
                }
            }

            internal DataColumn PC01035Column
            {
                get
                {
                    return this.columnPC01035;
                }
            }

            internal DataColumn PC01036Column
            {
                get
                {
                    return this.columnPC01036;
                }
            }

            internal DataColumn PC01037Column
            {
                get
                {
                    return this.columnPC01037;
                }
            }

            internal DataColumn PC01038Column
            {
                get
                {
                    return this.columnPC01038;
                }
            }

            internal DataColumn PC01039Column
            {
                get
                {
                    return this.columnPC01039;
                }
            }

            internal DataColumn PC01040Column
            {
                get
                {
                    return this.columnPC01040;
                }
            }

            internal DataColumn PC01041Column
            {
                get
                {
                    return this.columnPC01041;
                }
            }

            internal DataColumn PC01042Column
            {
                get
                {
                    return this.columnPC01042;
                }
            }

            internal DataColumn PC01043Column
            {
                get
                {
                    return this.columnPC01043;
                }
            }

            internal DataColumn PC01044Column
            {
                get
                {
                    return this.columnPC01044;
                }
            }

            internal DataColumn PC01045Column
            {
                get
                {
                    return this.columnPC01045;
                }
            }

            internal DataColumn PC01046Column
            {
                get
                {
                    return this.columnPC01046;
                }
            }

            internal DataColumn PC01047Column
            {
                get
                {
                    return this.columnPC01047;
                }
            }

            internal DataColumn PC01048Column
            {
                get
                {
                    return this.columnPC01048;
                }
            }

            internal DataColumn PC01049Column
            {
                get
                {
                    return this.columnPC01049;
                }
            }

            internal DataColumn PC01050Column
            {
                get
                {
                    return this.columnPC01050;
                }
            }

            internal DataColumn PC01051Column
            {
                get
                {
                    return this.columnPC01051;
                }
            }

            internal DataColumn PC01052Column
            {
                get
                {
                    return this.columnPC01052;
                }
            }

            internal DataColumn PC01053Column
            {
                get
                {
                    return this.columnPC01053;
                }
            }

            internal DataColumn PC01054Column
            {
                get
                {
                    return this.columnPC01054;
                }
            }

            internal DataColumn PC01055Column
            {
                get
                {
                    return this.columnPC01055;
                }
            }

            internal DataColumn PC01056Column
            {
                get
                {
                    return this.columnPC01056;
                }
            }

            internal DataColumn PC01057Column
            {
                get
                {
                    return this.columnPC01057;
                }
            }

            internal DataColumn PC01058Column
            {
                get
                {
                    return this.columnPC01058;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC010100Row : DataRow
        {
            private DataOCPendConf.PC010100DataTable tablePC010100;

            internal PC010100Row(DataRowBuilder rb) : base(rb)
            {
                this.tablePC010100 = (DataOCPendConf.PC010100DataTable) this.Table;
            }

            public string PC01001
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01001Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01001Column] = value;
                }
            }

            public int PC01002
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC010100.PC01002Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01002Column] = value;
                }
            }

            public string PC01003
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01003Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01003Column] = value;
                }
            }

            public string PC01004
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01004Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01004Column] = value;
                }
            }

            public string PC01005
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01005Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01005Column] = value;
                }
            }

            public string PC01006
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01006Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01006Column] = value;
                }
            }

            public int PC01007
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC010100.PC01007Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01007Column] = value;
                }
            }

            public int PC01008
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC010100.PC01008Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01008Column] = value;
                }
            }

            public int PC01009
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC010100.PC01009Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01009Column] = value;
                }
            }

            public string PC01010
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01010Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01010Column] = value;
                }
            }

            public string PC01011
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01011Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01011Column] = value;
                }
            }

            public int PC01012
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC010100.PC01012Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01012Column] = value;
                }
            }

            public int PC01013
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC010100.PC01013Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01013Column] = value;
                }
            }

            public int PC01014
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC010100.PC01014Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01014Column] = value;
                }
            }

            public DateTime PC01015
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC010100.PC01015Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01015Column] = value;
                }
            }

            public DateTime PC01016
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC010100.PC01016Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01016Column] = value;
                }
            }

            public string PC01017
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01017Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01017Column] = value;
                }
            }

            public string PC01018
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01018Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01018Column] = value;
                }
            }

            public decimal PC01019
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC010100.PC01019Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01019Column] = value;
                }
            }

            public decimal PC01020
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC010100.PC01020Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01020Column] = value;
                }
            }

            public int PC01021
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC010100.PC01021Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01021Column] = value;
                }
            }

            public int PC01022
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC010100.PC01022Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01022Column] = value;
                }
            }

            public string PC01023
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01023Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01023Column] = value;
                }
            }

            public string PC01024
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01024Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01024Column] = value;
                }
            }

            public string PC01025
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01025Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01025Column] = value;
                }
            }

            public string PC01026
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01026Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01026Column] = value;
                }
            }

            public string PC01027
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01027Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01027Column] = value;
                }
            }

            public string PC01028
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01028Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01028Column] = value;
                }
            }

            public string PC01029
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01029Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01029Column] = value;
                }
            }

            public string PC01030
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01030Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01030Column] = value;
                }
            }

            public decimal PC01031
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC010100.PC01031Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01031Column] = value;
                }
            }

            public string PC01032
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01032Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01032Column] = value;
                }
            }

            public string PC01033
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01033Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01033Column] = value;
                }
            }

            public string PC01034
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01034Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01034Column] = value;
                }
            }

            public DateTime PC01035
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC010100.PC01035Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01035Column] = value;
                }
            }

            public DateTime PC01036
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC010100.PC01036Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01036Column] = value;
                }
            }

            public string PC01037
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01037Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01037Column] = value;
                }
            }

            public string PC01038
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01038Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01038Column] = value;
                }
            }

            public int PC01039
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC010100.PC01039Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01039Column] = value;
                }
            }

            public int PC01040
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC010100.PC01040Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01040Column] = value;
                }
            }

            public string PC01041
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01041Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01041Column] = value;
                }
            }

            public string PC01042
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01042Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01042Column] = value;
                }
            }

            public string PC01043
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01043Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01043Column] = value;
                }
            }

            public string PC01044
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01044Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01044Column] = value;
                }
            }

            public string PC01045
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01045Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01045Column] = value;
                }
            }

            public string PC01046
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01046Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01046Column] = value;
                }
            }

            public decimal PC01047
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC010100.PC01047Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01047Column] = value;
                }
            }

            public string PC01048
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01048Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01048Column] = value;
                }
            }

            public string PC01049
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01049Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01049Column] = value;
                }
            }

            public string PC01050
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01050Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01050Column] = value;
                }
            }

            public string PC01051
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01051Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01051Column] = value;
                }
            }

            public string PC01052
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01052Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01052Column] = value;
                }
            }

            public string PC01053
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01053Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01053Column] = value;
                }
            }

            public string PC01054
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01054Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01054Column] = value;
                }
            }

            public string PC01055
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01055Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01055Column] = value;
                }
            }

            public string PC01056
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01056Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01056Column] = value;
                }
            }

            public string PC01057
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC010100.PC01057Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01057Column] = value;
                }
            }

            public DateTime PC01058
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC010100.PC01058Column]);
                }
                set
                {
                    this[this.tablePC010100.PC01058Column] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC010100RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataOCPendConf.PC010100Row eventRow;

            public PC010100RowChangeEvent(DataOCPendConf.PC010100Row row, DataRowAction action)
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

            public DataOCPendConf.PC010100Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC010100RowChangeEventHandler(object sender, DataOCPendConf.PC010100RowChangeEvent e);

        [DebuggerStepThrough]
        public class PC030100DataTable : DataTable, IEnumerable
        {
            private DataColumn columnPC03001;
            private DataColumn columnPC03002;
            private DataColumn columnPC03003;
            private DataColumn columnPC03004;
            private DataColumn columnPC03005;
            private DataColumn columnPC03006;
            private DataColumn columnPC03007;
            private DataColumn columnPC03008;
            private DataColumn columnPC03009;
            private DataColumn columnPC03010;
            private DataColumn columnPC03011;
            private DataColumn columnPC03012;
            private DataColumn columnPC03013;
            private DataColumn columnPC03014;
            private DataColumn columnPC03015;
            private DataColumn columnPC03016;
            private DataColumn columnPC03017;
            private DataColumn columnPC03018;
            private DataColumn columnPC03019;
            private DataColumn columnPC03020;
            private DataColumn columnPC03021;
            private DataColumn columnPC03022;
            private DataColumn columnPC03023;
            private DataColumn columnPC03024;
            private DataColumn columnPC03025;
            private DataColumn columnPC03026;
            private DataColumn columnPC03027;
            private DataColumn columnPC03028;
            private DataColumn columnPC03029;
            private DataColumn columnPC03030;
            private DataColumn columnPC03031;
            private DataColumn columnPC03032;
            private DataColumn columnPC03033;
            private DataColumn columnPC03034;
            private DataColumn columnPC03035;
            private DataColumn columnPC03036;
            private DataColumn columnPC03037;
            private DataColumn columnPC03038;
            private DataColumn columnPC03039;
            private DataColumn columnPC03040;
            private DataColumn columnPC03041;
            private DataColumn columnPC03042;
            private DataColumn columnPC03043;
            private DataColumn columnPC03044;
            private DataColumn columnPC03045;
            private DataColumn columnPC03046;
            private DataColumn columnPC03047;
            private DataColumn columnPC03048;
            private DataColumn columnPC03049;
            private DataColumn columnPC03050;
            private DataColumn columnPC03051;
            private DataColumn columnPC03052;
            private DataColumn columnPC03053;
            private DataColumn columnPC03054;
            private DataColumn columnPC03055;
            private DataColumn columnPC03056;
            private DataColumn columnPC03057;
            private DataColumn columnPC03058;
            private DataColumn columnPC03059;
            private DataColumn columnPC03060;
            private DataColumn columnPC03061;
            private DataColumn columnPC03062;

            public event DataOCPendConf.PC030100RowChangeEventHandler PC030100RowChanged;

            public event DataOCPendConf.PC030100RowChangeEventHandler PC030100RowChanging;

            public event DataOCPendConf.PC030100RowChangeEventHandler PC030100RowDeleted;

            public event DataOCPendConf.PC030100RowChangeEventHandler PC030100RowDeleting;

            internal PC030100DataTable() : base("PC030100")
            {
                this.InitClass();
            }

            internal PC030100DataTable(DataTable table) : base(table.TableName)
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

            public void AddPC030100Row(DataOCPendConf.PC030100Row row)
            {
                this.Rows.Add(row);
            }

            public DataOCPendConf.PC030100Row AddPC030100Row(string PC03001, string PC03002, string PC03003, int PC03004, string PC03005, string PC03006, string PC03007, decimal PC03008, int PC03009, decimal PC03010, decimal PC03011, decimal PC03012, string PC03013, string PC03014, decimal PC03015, DateTime PC03016, DateTime PC03017, decimal PC03018, decimal PC03019, string PC03020, int PC03021, string PC03022, int PC03023, DateTime PC03024, decimal PC03025, string PC03026, string PC03027, string PC03028, string PC03029, DateTime PC03030, DateTime PC03031, decimal PC03032, decimal PC03033, decimal PC03034, string PC03035, string PC03036, string PC03037, decimal PC03038, string PC03039, string PC03040, string PC03041, decimal PC03042, decimal PC03043, decimal PC03044, string PC03045, decimal PC03046, decimal PC03047, string PC03048, decimal PC03049, string PC03050, string PC03051, string PC03052, string PC03053, decimal PC03054, string PC03055, int PC03056, string PC03057, decimal PC03058, decimal PC03059, string PC03060, int PC03061, decimal PC03062)
            {
                DataOCPendConf.PC030100Row row = (DataOCPendConf.PC030100Row) this.NewRow();
                row.ItemArray = new object[] { 
                    PC03001, PC03002, PC03003, PC03004, PC03005, PC03006, PC03007, PC03008, PC03009, PC03010, PC03011, PC03012, PC03013, PC03014, PC03015, PC03016, 
                    PC03017, PC03018, PC03019, PC03020, PC03021, PC03022, PC03023, PC03024, PC03025, PC03026, PC03027, PC03028, PC03029, PC03030, PC03031, PC03032, 
                    PC03033, PC03034, PC03035, PC03036, PC03037, PC03038, PC03039, PC03040, PC03041, PC03042, PC03043, PC03044, PC03045, PC03046, PC03047, PC03048, 
                    PC03049, PC03050, PC03051, PC03052, PC03053, PC03054, PC03055, PC03056, PC03057, PC03058, PC03059, PC03060, PC03061, PC03062
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataOCPendConf.PC030100DataTable table = (DataOCPendConf.PC030100DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataOCPendConf.PC030100DataTable();
            }

            public DataOCPendConf.PC030100Row FindByPC03001PC03002PC03003(string PC03001, string PC03002, string PC03003)
            {
                return (DataOCPendConf.PC030100Row) this.Rows.Find(new object[] { PC03001, PC03002, PC03003 });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataOCPendConf.PC030100Row);
            }

            private void InitClass()
            {
                this.columnPC03001 = new DataColumn("PC03001", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03001);
                this.columnPC03002 = new DataColumn("PC03002", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03002);
                this.columnPC03003 = new DataColumn("PC03003", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03003);
                this.columnPC03004 = new DataColumn("PC03004", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnPC03004);
                this.columnPC03005 = new DataColumn("PC03005", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03005);
                this.columnPC03006 = new DataColumn("PC03006", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03006);
                this.columnPC03007 = new DataColumn("PC03007", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03007);
                this.columnPC03008 = new DataColumn("PC03008", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03008);
                this.columnPC03009 = new DataColumn("PC03009", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnPC03009);
                this.columnPC03010 = new DataColumn("PC03010", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03010);
                this.columnPC03011 = new DataColumn("PC03011", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03011);
                this.columnPC03012 = new DataColumn("PC03012", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03012);
                this.columnPC03013 = new DataColumn("PC03013", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03013);
                this.columnPC03014 = new DataColumn("PC03014", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03014);
                this.columnPC03015 = new DataColumn("PC03015", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03015);
                this.columnPC03016 = new DataColumn("PC03016", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnPC03016);
                this.columnPC03017 = new DataColumn("PC03017", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnPC03017);
                this.columnPC03018 = new DataColumn("PC03018", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03018);
                this.columnPC03019 = new DataColumn("PC03019", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03019);
                this.columnPC03020 = new DataColumn("PC03020", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03020);
                this.columnPC03021 = new DataColumn("PC03021", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnPC03021);
                this.columnPC03022 = new DataColumn("PC03022", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03022);
                this.columnPC03023 = new DataColumn("PC03023", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnPC03023);
                this.columnPC03024 = new DataColumn("PC03024", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnPC03024);
                this.columnPC03025 = new DataColumn("PC03025", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03025);
                this.columnPC03026 = new DataColumn("PC03026", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03026);
                this.columnPC03027 = new DataColumn("PC03027", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03027);
                this.columnPC03028 = new DataColumn("PC03028", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03028);
                this.columnPC03029 = new DataColumn("PC03029", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03029);
                this.columnPC03030 = new DataColumn("PC03030", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnPC03030);
                this.columnPC03031 = new DataColumn("PC03031", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnPC03031);
                this.columnPC03032 = new DataColumn("PC03032", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03032);
                this.columnPC03033 = new DataColumn("PC03033", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03033);
                this.columnPC03034 = new DataColumn("PC03034", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03034);
                this.columnPC03035 = new DataColumn("PC03035", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03035);
                this.columnPC03036 = new DataColumn("PC03036", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03036);
                this.columnPC03037 = new DataColumn("PC03037", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03037);
                this.columnPC03038 = new DataColumn("PC03038", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03038);
                this.columnPC03039 = new DataColumn("PC03039", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03039);
                this.columnPC03040 = new DataColumn("PC03040", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03040);
                this.columnPC03041 = new DataColumn("PC03041", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03041);
                this.columnPC03042 = new DataColumn("PC03042", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03042);
                this.columnPC03043 = new DataColumn("PC03043", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03043);
                this.columnPC03044 = new DataColumn("PC03044", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03044);
                this.columnPC03045 = new DataColumn("PC03045", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03045);
                this.columnPC03046 = new DataColumn("PC03046", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03046);
                this.columnPC03047 = new DataColumn("PC03047", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03047);
                this.columnPC03048 = new DataColumn("PC03048", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03048);
                this.columnPC03049 = new DataColumn("PC03049", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03049);
                this.columnPC03050 = new DataColumn("PC03050", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03050);
                this.columnPC03051 = new DataColumn("PC03051", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03051);
                this.columnPC03052 = new DataColumn("PC03052", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03052);
                this.columnPC03053 = new DataColumn("PC03053", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03053);
                this.columnPC03054 = new DataColumn("PC03054", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03054);
                this.columnPC03055 = new DataColumn("PC03055", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03055);
                this.columnPC03056 = new DataColumn("PC03056", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnPC03056);
                this.columnPC03057 = new DataColumn("PC03057", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03057);
                this.columnPC03058 = new DataColumn("PC03058", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03058);
                this.columnPC03059 = new DataColumn("PC03059", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03059);
                this.columnPC03060 = new DataColumn("PC03060", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPC03060);
                this.columnPC03061 = new DataColumn("PC03061", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnPC03061);
                this.columnPC03062 = new DataColumn("PC03062", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPC03062);
                this.Constraints.Add(new UniqueConstraint("DataOCPendConfKey2", new DataColumn[] { this.columnPC03001, this.columnPC03002, this.columnPC03003 }, true));
                this.columnPC03001.AllowDBNull = false;
                this.columnPC03002.AllowDBNull = false;
                this.columnPC03003.AllowDBNull = false;
                this.columnPC03004.AllowDBNull = false;
                this.columnPC03005.AllowDBNull = false;
                this.columnPC03006.AllowDBNull = false;
                this.columnPC03007.AllowDBNull = false;
                this.columnPC03008.AllowDBNull = false;
                this.columnPC03009.AllowDBNull = false;
                this.columnPC03010.AllowDBNull = false;
                this.columnPC03011.AllowDBNull = false;
                this.columnPC03012.AllowDBNull = false;
                this.columnPC03013.AllowDBNull = false;
                this.columnPC03014.AllowDBNull = false;
                this.columnPC03015.AllowDBNull = false;
                this.columnPC03016.AllowDBNull = false;
                this.columnPC03017.AllowDBNull = false;
                this.columnPC03018.AllowDBNull = false;
                this.columnPC03019.AllowDBNull = false;
                this.columnPC03020.AllowDBNull = false;
                this.columnPC03021.AllowDBNull = false;
                this.columnPC03022.AllowDBNull = false;
                this.columnPC03023.AllowDBNull = false;
                this.columnPC03024.AllowDBNull = false;
                this.columnPC03025.AllowDBNull = false;
                this.columnPC03026.AllowDBNull = false;
                this.columnPC03027.AllowDBNull = false;
                this.columnPC03028.AllowDBNull = false;
                this.columnPC03029.AllowDBNull = false;
                this.columnPC03030.AllowDBNull = false;
                this.columnPC03031.AllowDBNull = false;
                this.columnPC03032.AllowDBNull = false;
                this.columnPC03033.AllowDBNull = false;
                this.columnPC03034.AllowDBNull = false;
                this.columnPC03035.AllowDBNull = false;
                this.columnPC03036.AllowDBNull = false;
                this.columnPC03037.AllowDBNull = false;
                this.columnPC03038.AllowDBNull = false;
                this.columnPC03039.AllowDBNull = false;
                this.columnPC03040.AllowDBNull = false;
                this.columnPC03041.AllowDBNull = false;
                this.columnPC03042.AllowDBNull = false;
                this.columnPC03043.AllowDBNull = false;
                this.columnPC03044.AllowDBNull = false;
                this.columnPC03045.AllowDBNull = false;
                this.columnPC03046.AllowDBNull = false;
                this.columnPC03047.AllowDBNull = false;
                this.columnPC03048.AllowDBNull = false;
                this.columnPC03049.AllowDBNull = false;
                this.columnPC03050.AllowDBNull = false;
                this.columnPC03051.AllowDBNull = false;
                this.columnPC03052.AllowDBNull = false;
                this.columnPC03053.AllowDBNull = false;
                this.columnPC03054.AllowDBNull = false;
                this.columnPC03055.AllowDBNull = false;
                this.columnPC03056.AllowDBNull = false;
                this.columnPC03057.AllowDBNull = false;
                this.columnPC03058.AllowDBNull = false;
                this.columnPC03059.AllowDBNull = false;
                this.columnPC03060.AllowDBNull = false;
                this.columnPC03061.AllowDBNull = false;
                this.columnPC03062.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnPC03001 = this.Columns["PC03001"];
                this.columnPC03002 = this.Columns["PC03002"];
                this.columnPC03003 = this.Columns["PC03003"];
                this.columnPC03004 = this.Columns["PC03004"];
                this.columnPC03005 = this.Columns["PC03005"];
                this.columnPC03006 = this.Columns["PC03006"];
                this.columnPC03007 = this.Columns["PC03007"];
                this.columnPC03008 = this.Columns["PC03008"];
                this.columnPC03009 = this.Columns["PC03009"];
                this.columnPC03010 = this.Columns["PC03010"];
                this.columnPC03011 = this.Columns["PC03011"];
                this.columnPC03012 = this.Columns["PC03012"];
                this.columnPC03013 = this.Columns["PC03013"];
                this.columnPC03014 = this.Columns["PC03014"];
                this.columnPC03015 = this.Columns["PC03015"];
                this.columnPC03016 = this.Columns["PC03016"];
                this.columnPC03017 = this.Columns["PC03017"];
                this.columnPC03018 = this.Columns["PC03018"];
                this.columnPC03019 = this.Columns["PC03019"];
                this.columnPC03020 = this.Columns["PC03020"];
                this.columnPC03021 = this.Columns["PC03021"];
                this.columnPC03022 = this.Columns["PC03022"];
                this.columnPC03023 = this.Columns["PC03023"];
                this.columnPC03024 = this.Columns["PC03024"];
                this.columnPC03025 = this.Columns["PC03025"];
                this.columnPC03026 = this.Columns["PC03026"];
                this.columnPC03027 = this.Columns["PC03027"];
                this.columnPC03028 = this.Columns["PC03028"];
                this.columnPC03029 = this.Columns["PC03029"];
                this.columnPC03030 = this.Columns["PC03030"];
                this.columnPC03031 = this.Columns["PC03031"];
                this.columnPC03032 = this.Columns["PC03032"];
                this.columnPC03033 = this.Columns["PC03033"];
                this.columnPC03034 = this.Columns["PC03034"];
                this.columnPC03035 = this.Columns["PC03035"];
                this.columnPC03036 = this.Columns["PC03036"];
                this.columnPC03037 = this.Columns["PC03037"];
                this.columnPC03038 = this.Columns["PC03038"];
                this.columnPC03039 = this.Columns["PC03039"];
                this.columnPC03040 = this.Columns["PC03040"];
                this.columnPC03041 = this.Columns["PC03041"];
                this.columnPC03042 = this.Columns["PC03042"];
                this.columnPC03043 = this.Columns["PC03043"];
                this.columnPC03044 = this.Columns["PC03044"];
                this.columnPC03045 = this.Columns["PC03045"];
                this.columnPC03046 = this.Columns["PC03046"];
                this.columnPC03047 = this.Columns["PC03047"];
                this.columnPC03048 = this.Columns["PC03048"];
                this.columnPC03049 = this.Columns["PC03049"];
                this.columnPC03050 = this.Columns["PC03050"];
                this.columnPC03051 = this.Columns["PC03051"];
                this.columnPC03052 = this.Columns["PC03052"];
                this.columnPC03053 = this.Columns["PC03053"];
                this.columnPC03054 = this.Columns["PC03054"];
                this.columnPC03055 = this.Columns["PC03055"];
                this.columnPC03056 = this.Columns["PC03056"];
                this.columnPC03057 = this.Columns["PC03057"];
                this.columnPC03058 = this.Columns["PC03058"];
                this.columnPC03059 = this.Columns["PC03059"];
                this.columnPC03060 = this.Columns["PC03060"];
                this.columnPC03061 = this.Columns["PC03061"];
                this.columnPC03062 = this.Columns["PC03062"];
            }

            public DataOCPendConf.PC030100Row NewPC030100Row()
            {
                return (DataOCPendConf.PC030100Row) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataOCPendConf.PC030100Row(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC030100RowChangedEvent != null) && (this.PC030100RowChangedEvent != null))
                {
                    this.PC030100RowChangedEvent(this, new DataOCPendConf.PC030100RowChangeEvent((DataOCPendConf.PC030100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC030100RowChangingEvent != null) && (this.PC030100RowChangingEvent != null))
                {
                    this.PC030100RowChangingEvent(this, new DataOCPendConf.PC030100RowChangeEvent((DataOCPendConf.PC030100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC030100RowDeletedEvent != null) && (this.PC030100RowDeletedEvent != null))
                {
                    this.PC030100RowDeletedEvent(this, new DataOCPendConf.PC030100RowChangeEvent((DataOCPendConf.PC030100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC030100RowDeletingEvent != null) && (this.PC030100RowDeletingEvent != null))
                {
                    this.PC030100RowDeletingEvent(this, new DataOCPendConf.PC030100RowChangeEvent((DataOCPendConf.PC030100Row) e.Row, e.Action));
                }
            }

            public void RemovePC030100Row(DataOCPendConf.PC030100Row row)
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

            public DataOCPendConf.PC030100Row this[int index]
            {
                get
                {
                    return (DataOCPendConf.PC030100Row) this.Rows[index];
                }
            }

            internal DataColumn PC03001Column
            {
                get
                {
                    return this.columnPC03001;
                }
            }

            internal DataColumn PC03002Column
            {
                get
                {
                    return this.columnPC03002;
                }
            }

            internal DataColumn PC03003Column
            {
                get
                {
                    return this.columnPC03003;
                }
            }

            internal DataColumn PC03004Column
            {
                get
                {
                    return this.columnPC03004;
                }
            }

            internal DataColumn PC03005Column
            {
                get
                {
                    return this.columnPC03005;
                }
            }

            internal DataColumn PC03006Column
            {
                get
                {
                    return this.columnPC03006;
                }
            }

            internal DataColumn PC03007Column
            {
                get
                {
                    return this.columnPC03007;
                }
            }

            internal DataColumn PC03008Column
            {
                get
                {
                    return this.columnPC03008;
                }
            }

            internal DataColumn PC03009Column
            {
                get
                {
                    return this.columnPC03009;
                }
            }

            internal DataColumn PC03010Column
            {
                get
                {
                    return this.columnPC03010;
                }
            }

            internal DataColumn PC03011Column
            {
                get
                {
                    return this.columnPC03011;
                }
            }

            internal DataColumn PC03012Column
            {
                get
                {
                    return this.columnPC03012;
                }
            }

            internal DataColumn PC03013Column
            {
                get
                {
                    return this.columnPC03013;
                }
            }

            internal DataColumn PC03014Column
            {
                get
                {
                    return this.columnPC03014;
                }
            }

            internal DataColumn PC03015Column
            {
                get
                {
                    return this.columnPC03015;
                }
            }

            internal DataColumn PC03016Column
            {
                get
                {
                    return this.columnPC03016;
                }
            }

            internal DataColumn PC03017Column
            {
                get
                {
                    return this.columnPC03017;
                }
            }

            internal DataColumn PC03018Column
            {
                get
                {
                    return this.columnPC03018;
                }
            }

            internal DataColumn PC03019Column
            {
                get
                {
                    return this.columnPC03019;
                }
            }

            internal DataColumn PC03020Column
            {
                get
                {
                    return this.columnPC03020;
                }
            }

            internal DataColumn PC03021Column
            {
                get
                {
                    return this.columnPC03021;
                }
            }

            internal DataColumn PC03022Column
            {
                get
                {
                    return this.columnPC03022;
                }
            }

            internal DataColumn PC03023Column
            {
                get
                {
                    return this.columnPC03023;
                }
            }

            internal DataColumn PC03024Column
            {
                get
                {
                    return this.columnPC03024;
                }
            }

            internal DataColumn PC03025Column
            {
                get
                {
                    return this.columnPC03025;
                }
            }

            internal DataColumn PC03026Column
            {
                get
                {
                    return this.columnPC03026;
                }
            }

            internal DataColumn PC03027Column
            {
                get
                {
                    return this.columnPC03027;
                }
            }

            internal DataColumn PC03028Column
            {
                get
                {
                    return this.columnPC03028;
                }
            }

            internal DataColumn PC03029Column
            {
                get
                {
                    return this.columnPC03029;
                }
            }

            internal DataColumn PC03030Column
            {
                get
                {
                    return this.columnPC03030;
                }
            }

            internal DataColumn PC03031Column
            {
                get
                {
                    return this.columnPC03031;
                }
            }

            internal DataColumn PC03032Column
            {
                get
                {
                    return this.columnPC03032;
                }
            }

            internal DataColumn PC03033Column
            {
                get
                {
                    return this.columnPC03033;
                }
            }

            internal DataColumn PC03034Column
            {
                get
                {
                    return this.columnPC03034;
                }
            }

            internal DataColumn PC03035Column
            {
                get
                {
                    return this.columnPC03035;
                }
            }

            internal DataColumn PC03036Column
            {
                get
                {
                    return this.columnPC03036;
                }
            }

            internal DataColumn PC03037Column
            {
                get
                {
                    return this.columnPC03037;
                }
            }

            internal DataColumn PC03038Column
            {
                get
                {
                    return this.columnPC03038;
                }
            }

            internal DataColumn PC03039Column
            {
                get
                {
                    return this.columnPC03039;
                }
            }

            internal DataColumn PC03040Column
            {
                get
                {
                    return this.columnPC03040;
                }
            }

            internal DataColumn PC03041Column
            {
                get
                {
                    return this.columnPC03041;
                }
            }

            internal DataColumn PC03042Column
            {
                get
                {
                    return this.columnPC03042;
                }
            }

            internal DataColumn PC03043Column
            {
                get
                {
                    return this.columnPC03043;
                }
            }

            internal DataColumn PC03044Column
            {
                get
                {
                    return this.columnPC03044;
                }
            }

            internal DataColumn PC03045Column
            {
                get
                {
                    return this.columnPC03045;
                }
            }

            internal DataColumn PC03046Column
            {
                get
                {
                    return this.columnPC03046;
                }
            }

            internal DataColumn PC03047Column
            {
                get
                {
                    return this.columnPC03047;
                }
            }

            internal DataColumn PC03048Column
            {
                get
                {
                    return this.columnPC03048;
                }
            }

            internal DataColumn PC03049Column
            {
                get
                {
                    return this.columnPC03049;
                }
            }

            internal DataColumn PC03050Column
            {
                get
                {
                    return this.columnPC03050;
                }
            }

            internal DataColumn PC03051Column
            {
                get
                {
                    return this.columnPC03051;
                }
            }

            internal DataColumn PC03052Column
            {
                get
                {
                    return this.columnPC03052;
                }
            }

            internal DataColumn PC03053Column
            {
                get
                {
                    return this.columnPC03053;
                }
            }

            internal DataColumn PC03054Column
            {
                get
                {
                    return this.columnPC03054;
                }
            }

            internal DataColumn PC03055Column
            {
                get
                {
                    return this.columnPC03055;
                }
            }

            internal DataColumn PC03056Column
            {
                get
                {
                    return this.columnPC03056;
                }
            }

            internal DataColumn PC03057Column
            {
                get
                {
                    return this.columnPC03057;
                }
            }

            internal DataColumn PC03058Column
            {
                get
                {
                    return this.columnPC03058;
                }
            }

            internal DataColumn PC03059Column
            {
                get
                {
                    return this.columnPC03059;
                }
            }

            internal DataColumn PC03060Column
            {
                get
                {
                    return this.columnPC03060;
                }
            }

            internal DataColumn PC03061Column
            {
                get
                {
                    return this.columnPC03061;
                }
            }

            internal DataColumn PC03062Column
            {
                get
                {
                    return this.columnPC03062;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC030100Row : DataRow
        {
            private DataOCPendConf.PC030100DataTable tablePC030100;

            internal PC030100Row(DataRowBuilder rb) : base(rb)
            {
                this.tablePC030100 = (DataOCPendConf.PC030100DataTable) this.Table;
            }

            public string PC03001
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03001Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03001Column] = value;
                }
            }

            public string PC03002
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03002Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03002Column] = value;
                }
            }

            public string PC03003
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03003Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03003Column] = value;
                }
            }

            public int PC03004
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC030100.PC03004Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03004Column] = value;
                }
            }

            public string PC03005
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03005Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03005Column] = value;
                }
            }

            public string PC03006
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03006Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03006Column] = value;
                }
            }

            public string PC03007
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03007Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03007Column] = value;
                }
            }

            public decimal PC03008
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03008Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03008Column] = value;
                }
            }

            public int PC03009
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC030100.PC03009Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03009Column] = value;
                }
            }

            public decimal PC03010
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03010Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03010Column] = value;
                }
            }

            public decimal PC03011
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03011Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03011Column] = value;
                }
            }

            public decimal PC03012
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03012Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03012Column] = value;
                }
            }

            public string PC03013
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03013Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03013Column] = value;
                }
            }

            public string PC03014
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03014Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03014Column] = value;
                }
            }

            public decimal PC03015
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03015Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03015Column] = value;
                }
            }

            public DateTime PC03016
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC030100.PC03016Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03016Column] = value;
                }
            }

            public DateTime PC03017
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC030100.PC03017Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03017Column] = value;
                }
            }

            public decimal PC03018
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03018Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03018Column] = value;
                }
            }

            public decimal PC03019
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03019Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03019Column] = value;
                }
            }

            public string PC03020
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03020Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03020Column] = value;
                }
            }

            public int PC03021
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC030100.PC03021Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03021Column] = value;
                }
            }

            public string PC03022
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03022Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03022Column] = value;
                }
            }

            public int PC03023
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC030100.PC03023Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03023Column] = value;
                }
            }

            public DateTime PC03024
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC030100.PC03024Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03024Column] = value;
                }
            }

            public decimal PC03025
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03025Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03025Column] = value;
                }
            }

            public string PC03026
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03026Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03026Column] = value;
                }
            }

            public string PC03027
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03027Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03027Column] = value;
                }
            }

            public string PC03028
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03028Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03028Column] = value;
                }
            }

            public string PC03029
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03029Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03029Column] = value;
                }
            }

            public DateTime PC03030
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC030100.PC03030Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03030Column] = value;
                }
            }

            public DateTime PC03031
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC030100.PC03031Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03031Column] = value;
                }
            }

            public decimal PC03032
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03032Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03032Column] = value;
                }
            }

            public decimal PC03033
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03033Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03033Column] = value;
                }
            }

            public decimal PC03034
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03034Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03034Column] = value;
                }
            }

            public string PC03035
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03035Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03035Column] = value;
                }
            }

            public string PC03036
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03036Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03036Column] = value;
                }
            }

            public string PC03037
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03037Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03037Column] = value;
                }
            }

            public decimal PC03038
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03038Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03038Column] = value;
                }
            }

            public string PC03039
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03039Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03039Column] = value;
                }
            }

            public string PC03040
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03040Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03040Column] = value;
                }
            }

            public string PC03041
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03041Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03041Column] = value;
                }
            }

            public decimal PC03042
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03042Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03042Column] = value;
                }
            }

            public decimal PC03043
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03043Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03043Column] = value;
                }
            }

            public decimal PC03044
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03044Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03044Column] = value;
                }
            }

            public string PC03045
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03045Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03045Column] = value;
                }
            }

            public decimal PC03046
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03046Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03046Column] = value;
                }
            }

            public decimal PC03047
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03047Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03047Column] = value;
                }
            }

            public string PC03048
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03048Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03048Column] = value;
                }
            }

            public decimal PC03049
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03049Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03049Column] = value;
                }
            }

            public string PC03050
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03050Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03050Column] = value;
                }
            }

            public string PC03051
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03051Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03051Column] = value;
                }
            }

            public string PC03052
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03052Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03052Column] = value;
                }
            }

            public string PC03053
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03053Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03053Column] = value;
                }
            }

            public decimal PC03054
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03054Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03054Column] = value;
                }
            }

            public string PC03055
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03055Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03055Column] = value;
                }
            }

            public int PC03056
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC030100.PC03056Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03056Column] = value;
                }
            }

            public string PC03057
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03057Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03057Column] = value;
                }
            }

            public decimal PC03058
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03058Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03058Column] = value;
                }
            }

            public decimal PC03059
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03059Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03059Column] = value;
                }
            }

            public string PC03060
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC030100.PC03060Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03060Column] = value;
                }
            }

            public int PC03061
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC030100.PC03061Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03061Column] = value;
                }
            }

            public decimal PC03062
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC030100.PC03062Column]);
                }
                set
                {
                    this[this.tablePC030100.PC03062Column] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC030100RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataOCPendConf.PC030100Row eventRow;

            public PC030100RowChangeEvent(DataOCPendConf.PC030100Row row, DataRowAction action)
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

            public DataOCPendConf.PC030100Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC030100RowChangeEventHandler(object sender, DataOCPendConf.PC030100RowChangeEvent e);

        [DebuggerStepThrough]
        public class PC1TmpDetDesDataTable : DataTable, IEnumerable
        {
            private DataColumn columnEnTransito;
            private DataColumn columnFechaFC;
            private DataColumn columnFechaPL;
            private DataColumn columnNroBulto;
            private DataColumn columnNroFC;
            private DataColumn columnNroLinea;
            private DataColumn columnNroOC;
            private DataColumn columnPackList;

            public event DataOCPendConf.PC1TmpDetDesRowChangeEventHandler PC1TmpDetDesRowChanged;

            public event DataOCPendConf.PC1TmpDetDesRowChangeEventHandler PC1TmpDetDesRowChanging;

            public event DataOCPendConf.PC1TmpDetDesRowChangeEventHandler PC1TmpDetDesRowDeleted;

            public event DataOCPendConf.PC1TmpDetDesRowChangeEventHandler PC1TmpDetDesRowDeleting;

            internal PC1TmpDetDesDataTable() : base("PC1TmpDetDes")
            {
                this.InitClass();
            }

            internal PC1TmpDetDesDataTable(DataTable table) : base(table.TableName)
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

            public void AddPC1TmpDetDesRow(DataOCPendConf.PC1TmpDetDesRow row)
            {
                this.Rows.Add(row);
            }

            public DataOCPendConf.PC1TmpDetDesRow AddPC1TmpDetDesRow(string NroOC, string NroLinea, string NroBulto, string PackList, DateTime FechaPL, string NroFC, DateTime FechaFC, decimal EnTransito)
            {
                DataOCPendConf.PC1TmpDetDesRow row = (DataOCPendConf.PC1TmpDetDesRow) this.NewRow();
                row.ItemArray = new object[] { NroOC, NroLinea, NroBulto, PackList, FechaPL, NroFC, FechaFC, EnTransito };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataOCPendConf.PC1TmpDetDesDataTable table = (DataOCPendConf.PC1TmpDetDesDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataOCPendConf.PC1TmpDetDesDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataOCPendConf.PC1TmpDetDesRow);
            }

            private void InitClass()
            {
                this.columnNroOC = new DataColumn("NroOC", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOC);
                this.columnNroLinea = new DataColumn("NroLinea", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroLinea);
                this.columnNroBulto = new DataColumn("NroBulto", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroBulto);
                this.columnPackList = new DataColumn("PackList", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPackList);
                this.columnFechaPL = new DataColumn("FechaPL", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaPL);
                this.columnNroFC = new DataColumn("NroFC", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroFC);
                this.columnFechaFC = new DataColumn("FechaFC", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaFC);
                this.columnEnTransito = new DataColumn("EnTransito", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnEnTransito);
                this.columnNroOC.AllowDBNull = false;
                this.columnNroLinea.AllowDBNull = false;
                this.columnNroBulto.AllowDBNull = false;
                this.columnPackList.AllowDBNull = false;
                this.columnFechaPL.AllowDBNull = false;
                this.columnNroFC.AllowDBNull = false;
                this.columnFechaFC.AllowDBNull = false;
                this.columnEnTransito.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnNroOC = this.Columns["NroOC"];
                this.columnNroLinea = this.Columns["NroLinea"];
                this.columnNroBulto = this.Columns["NroBulto"];
                this.columnPackList = this.Columns["PackList"];
                this.columnFechaPL = this.Columns["FechaPL"];
                this.columnNroFC = this.Columns["NroFC"];
                this.columnFechaFC = this.Columns["FechaFC"];
                this.columnEnTransito = this.Columns["EnTransito"];
            }

            public DataOCPendConf.PC1TmpDetDesRow NewPC1TmpDetDesRow()
            {
                return (DataOCPendConf.PC1TmpDetDesRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataOCPendConf.PC1TmpDetDesRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpDetDesRowChangedEvent != null) && (this.PC1TmpDetDesRowChangedEvent != null))
                {
                    this.PC1TmpDetDesRowChangedEvent(this, new DataOCPendConf.PC1TmpDetDesRowChangeEvent((DataOCPendConf.PC1TmpDetDesRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpDetDesRowChangingEvent != null) && (this.PC1TmpDetDesRowChangingEvent != null))
                {
                    this.PC1TmpDetDesRowChangingEvent(this, new DataOCPendConf.PC1TmpDetDesRowChangeEvent((DataOCPendConf.PC1TmpDetDesRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpDetDesRowDeletedEvent != null) && (this.PC1TmpDetDesRowDeletedEvent != null))
                {
                    this.PC1TmpDetDesRowDeletedEvent(this, new DataOCPendConf.PC1TmpDetDesRowChangeEvent((DataOCPendConf.PC1TmpDetDesRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpDetDesRowDeletingEvent != null) && (this.PC1TmpDetDesRowDeletingEvent != null))
                {
                    this.PC1TmpDetDesRowDeletingEvent(this, new DataOCPendConf.PC1TmpDetDesRowChangeEvent((DataOCPendConf.PC1TmpDetDesRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpDetDesRow(DataOCPendConf.PC1TmpDetDesRow row)
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

            internal DataColumn EnTransitoColumn
            {
                get
                {
                    return this.columnEnTransito;
                }
            }

            internal DataColumn FechaFCColumn
            {
                get
                {
                    return this.columnFechaFC;
                }
            }

            internal DataColumn FechaPLColumn
            {
                get
                {
                    return this.columnFechaPL;
                }
            }

            public DataOCPendConf.PC1TmpDetDesRow this[int index]
            {
                get
                {
                    return (DataOCPendConf.PC1TmpDetDesRow) this.Rows[index];
                }
            }

            internal DataColumn NroBultoColumn
            {
                get
                {
                    return this.columnNroBulto;
                }
            }

            internal DataColumn NroFCColumn
            {
                get
                {
                    return this.columnNroFC;
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

            internal DataColumn PackListColumn
            {
                get
                {
                    return this.columnPackList;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpDetDesRow : DataRow
        {
            private DataOCPendConf.PC1TmpDetDesDataTable tablePC1TmpDetDes;

            internal PC1TmpDetDesRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpDetDes = (DataOCPendConf.PC1TmpDetDesDataTable) this.Table;
            }

            public decimal EnTransito
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpDetDes.EnTransitoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpDetDes.EnTransitoColumn] = value;
                }
            }

            public DateTime FechaFC
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpDetDes.FechaFCColumn]);
                }
                set
                {
                    this[this.tablePC1TmpDetDes.FechaFCColumn] = value;
                }
            }

            public DateTime FechaPL
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpDetDes.FechaPLColumn]);
                }
                set
                {
                    this[this.tablePC1TmpDetDes.FechaPLColumn] = value;
                }
            }

            public string NroBulto
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpDetDes.NroBultoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpDetDes.NroBultoColumn] = value;
                }
            }

            public string NroFC
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpDetDes.NroFCColumn]);
                }
                set
                {
                    this[this.tablePC1TmpDetDes.NroFCColumn] = value;
                }
            }

            public string NroLinea
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpDetDes.NroLineaColumn]);
                }
                set
                {
                    this[this.tablePC1TmpDetDes.NroLineaColumn] = value;
                }
            }

            public string NroOC
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpDetDes.NroOCColumn]);
                }
                set
                {
                    this[this.tablePC1TmpDetDes.NroOCColumn] = value;
                }
            }

            public string PackList
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpDetDes.PackListColumn]);
                }
                set
                {
                    this[this.tablePC1TmpDetDes.PackListColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpDetDesRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataOCPendConf.PC1TmpDetDesRow eventRow;

            public PC1TmpDetDesRowChangeEvent(DataOCPendConf.PC1TmpDetDesRow row, DataRowAction action)
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

            public DataOCPendConf.PC1TmpDetDesRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpDetDesRowChangeEventHandler(object sender, DataOCPendConf.PC1TmpDetDesRowChangeEvent e);

        [DebuggerStepThrough]
        public class PC1TmpFormaDespDataTable : DataTable, IEnumerable
        {
            private DataColumn columnCodigo;
            private DataColumn columnDescripcion;

            public event DataOCPendConf.PC1TmpFormaDespRowChangeEventHandler PC1TmpFormaDespRowChanged;

            public event DataOCPendConf.PC1TmpFormaDespRowChangeEventHandler PC1TmpFormaDespRowChanging;

            public event DataOCPendConf.PC1TmpFormaDespRowChangeEventHandler PC1TmpFormaDespRowDeleted;

            public event DataOCPendConf.PC1TmpFormaDespRowChangeEventHandler PC1TmpFormaDespRowDeleting;

            internal PC1TmpFormaDespDataTable() : base("PC1TmpFormaDesp")
            {
                this.InitClass();
            }

            internal PC1TmpFormaDespDataTable(DataTable table) : base(table.TableName)
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

            public void AddPC1TmpFormaDespRow(DataOCPendConf.PC1TmpFormaDespRow row)
            {
                this.Rows.Add(row);
            }

            public DataOCPendConf.PC1TmpFormaDespRow AddPC1TmpFormaDespRow(int Codigo, string Descripcion)
            {
                DataOCPendConf.PC1TmpFormaDespRow row = (DataOCPendConf.PC1TmpFormaDespRow) this.NewRow();
                row.ItemArray = new object[] { Codigo, Descripcion };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataOCPendConf.PC1TmpFormaDespDataTable table = (DataOCPendConf.PC1TmpFormaDespDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataOCPendConf.PC1TmpFormaDespDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataOCPendConf.PC1TmpFormaDespRow);
            }

            private void InitClass()
            {
                this.columnCodigo = new DataColumn("Codigo", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnCodigo);
                this.columnDescripcion = new DataColumn("Descripcion", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDescripcion);
                this.columnCodigo.AllowDBNull = false;
                this.columnDescripcion.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnCodigo = this.Columns["Codigo"];
                this.columnDescripcion = this.Columns["Descripcion"];
            }

            public DataOCPendConf.PC1TmpFormaDespRow NewPC1TmpFormaDespRow()
            {
                return (DataOCPendConf.PC1TmpFormaDespRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataOCPendConf.PC1TmpFormaDespRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpFormaDespRowChangedEvent != null) && (this.PC1TmpFormaDespRowChangedEvent != null))
                {
                    this.PC1TmpFormaDespRowChangedEvent(this, new DataOCPendConf.PC1TmpFormaDespRowChangeEvent((DataOCPendConf.PC1TmpFormaDespRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpFormaDespRowChangingEvent != null) && (this.PC1TmpFormaDespRowChangingEvent != null))
                {
                    this.PC1TmpFormaDespRowChangingEvent(this, new DataOCPendConf.PC1TmpFormaDespRowChangeEvent((DataOCPendConf.PC1TmpFormaDespRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpFormaDespRowDeletedEvent != null) && (this.PC1TmpFormaDespRowDeletedEvent != null))
                {
                    this.PC1TmpFormaDespRowDeletedEvent(this, new DataOCPendConf.PC1TmpFormaDespRowChangeEvent((DataOCPendConf.PC1TmpFormaDespRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpFormaDespRowDeletingEvent != null) && (this.PC1TmpFormaDespRowDeletingEvent != null))
                {
                    this.PC1TmpFormaDespRowDeletingEvent(this, new DataOCPendConf.PC1TmpFormaDespRowChangeEvent((DataOCPendConf.PC1TmpFormaDespRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpFormaDespRow(DataOCPendConf.PC1TmpFormaDespRow row)
            {
                this.Rows.Remove(row);
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

            public DataOCPendConf.PC1TmpFormaDespRow this[int index]
            {
                get
                {
                    return (DataOCPendConf.PC1TmpFormaDespRow) this.Rows[index];
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpFormaDespRow : DataRow
        {
            private DataOCPendConf.PC1TmpFormaDespDataTable tablePC1TmpFormaDesp;

            internal PC1TmpFormaDespRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpFormaDesp = (DataOCPendConf.PC1TmpFormaDespDataTable) this.Table;
            }

            public int Codigo
            {
                get
                {
                    return IntegerType.FromObject(this[this.tablePC1TmpFormaDesp.CodigoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpFormaDesp.CodigoColumn] = value;
                }
            }

            public string Descripcion
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpFormaDesp.DescripcionColumn]);
                }
                set
                {
                    this[this.tablePC1TmpFormaDesp.DescripcionColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpFormaDespRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataOCPendConf.PC1TmpFormaDespRow eventRow;

            public PC1TmpFormaDespRowChangeEvent(DataOCPendConf.PC1TmpFormaDespRow row, DataRowAction action)
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

            public DataOCPendConf.PC1TmpFormaDespRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpFormaDespRowChangeEventHandler(object sender, DataOCPendConf.PC1TmpFormaDespRowChangeEvent e);

        [DebuggerStepThrough]
        public class PL010100DataTable : DataTable, IEnumerable
        {
            private DataColumn columnPL01001;
            private DataColumn columnPL01002;
            private DataColumn columnPL01003;
            private DataColumn columnPL01004;
            private DataColumn columnPL01005;
            private DataColumn columnPL01006;
            private DataColumn columnPL01007;
            private DataColumn columnPL01008;
            private DataColumn columnPL01009;
            private DataColumn columnPL01010;
            private DataColumn columnPL01011;
            private DataColumn columnPL01012;
            private DataColumn columnPL01013;
            private DataColumn columnPL01014;
            private DataColumn columnPL01015;
            private DataColumn columnPL01016;
            private DataColumn columnPL01017;
            private DataColumn columnPL01018;
            private DataColumn columnPL01019;
            private DataColumn columnPL01020;
            private DataColumn columnPL01021;
            private DataColumn columnPL01022;
            private DataColumn columnPL01023;
            private DataColumn columnPL01024;
            private DataColumn columnPL01025;
            private DataColumn columnPL01026;
            private DataColumn columnPL01027;
            private DataColumn columnPL01028;
            private DataColumn columnPL01029;
            private DataColumn columnPL01030;
            private DataColumn columnPL01031;
            private DataColumn columnPL01032;
            private DataColumn columnPL01033;
            private DataColumn columnPL01034;
            private DataColumn columnPL01035;
            private DataColumn columnPL01036;
            private DataColumn columnPL01037;
            private DataColumn columnPL01038;
            private DataColumn columnPL01039;
            private DataColumn columnPL01040;
            private DataColumn columnPL01041;
            private DataColumn columnPL01042;
            private DataColumn columnPL01043;
            private DataColumn columnPL01044;
            private DataColumn columnPL01045;
            private DataColumn columnPL01046;
            private DataColumn columnPL01047;
            private DataColumn columnPL01048;
            private DataColumn columnPL01049;
            private DataColumn columnPL01050;
            private DataColumn columnPL01051;
            private DataColumn columnPL01052;
            private DataColumn columnPL01053;
            private DataColumn columnPL01054;
            private DataColumn columnPL01055;
            private DataColumn columnPL01056;
            private DataColumn columnPL01057;
            private DataColumn columnPL01058;
            private DataColumn columnPL01059;
            private DataColumn columnPL01060;
            private DataColumn columnPL01061;
            private DataColumn columnPL01062;
            private DataColumn columnPL01063;
            private DataColumn columnPL01064;
            private DataColumn columnPL01065;
            private DataColumn columnPL01066;
            private DataColumn columnPL01067;
            private DataColumn columnPL01068;
            private DataColumn columnPL01069;
            private DataColumn columnPL01070;
            private DataColumn columnPL01071;
            private DataColumn columnPL01072;
            private DataColumn columnPL01073;
            private DataColumn columnPL01074;
            private DataColumn columnPL01075;
            private DataColumn columnPL01076;
            private DataColumn columnPL01077;

            public event DataOCPendConf.PL010100RowChangeEventHandler PL010100RowChanged;

            public event DataOCPendConf.PL010100RowChangeEventHandler PL010100RowChanging;

            public event DataOCPendConf.PL010100RowChangeEventHandler PL010100RowDeleted;

            public event DataOCPendConf.PL010100RowChangeEventHandler PL010100RowDeleting;

            internal PL010100DataTable() : base("PL010100")
            {
                this.InitClass();
            }

            internal PL010100DataTable(DataTable table) : base(table.TableName)
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

            public void AddPL010100Row(DataOCPendConf.PL010100Row row)
            {
                this.Rows.Add(row);
            }

            public DataOCPendConf.PL010100Row AddPL010100Row(string PL01001, string PL01002, string PL01003, string PL01004, string PL01005, string PL01006, string PL01007, string PL01008, string PL01009, string PL01010, string PL01011, string PL01012, string PL01013, string PL01014, string PL01015, string PL01016, string PL01017, string PL01018, string PL01019, string PL01020, string PL01021, string PL01022, string PL01023, string PL01024, string PL01025, string PL01026, string PL01027, string PL01028, string PL01029, string PL01030, string PL01031, string PL01032, string PL01033, string PL01034, DateTime PL01035, DateTime PL01036, string PL01037, string PL01038, string PL01039, string PL01040, string PL01041, string PL01042, string PL01043, string PL01044, string PL01045, string PL01046, string PL01047, string PL01048, string PL01049, string PL01050, string PL01051, string PL01052, string PL01053, string PL01054, string PL01055, string PL01056, string PL01057, string PL01058, string PL01059, string PL01060, string PL01061, string PL01062, string PL01063, string PL01064, string PL01065, string PL01066, string PL01067, string PL01068, string PL01069, string PL01070, string PL01071, string PL01072, string PL01073, string PL01074, string PL01075, string PL01076, string PL01077)
            {
                DataOCPendConf.PL010100Row row = (DataOCPendConf.PL010100Row) this.NewRow();
                row.ItemArray = new object[] { 
                    PL01001, PL01002, PL01003, PL01004, PL01005, PL01006, PL01007, PL01008, PL01009, PL01010, PL01011, PL01012, PL01013, PL01014, PL01015, PL01016, 
                    PL01017, PL01018, PL01019, PL01020, PL01021, PL01022, PL01023, PL01024, PL01025, PL01026, PL01027, PL01028, PL01029, PL01030, PL01031, PL01032, 
                    PL01033, PL01034, PL01035, PL01036, PL01037, PL01038, PL01039, PL01040, PL01041, PL01042, PL01043, PL01044, PL01045, PL01046, PL01047, PL01048, 
                    PL01049, PL01050, PL01051, PL01052, PL01053, PL01054, PL01055, PL01056, PL01057, PL01058, PL01059, PL01060, PL01061, PL01062, PL01063, PL01064, 
                    PL01065, PL01066, PL01067, PL01068, PL01069, PL01070, PL01071, PL01072, PL01073, PL01074, PL01075, PL01076, PL01077
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataOCPendConf.PL010100DataTable table = (DataOCPendConf.PL010100DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataOCPendConf.PL010100DataTable();
            }

            public DataOCPendConf.PL010100Row FindByPL01001(string PL01001)
            {
                return (DataOCPendConf.PL010100Row) this.Rows.Find(new object[] { PL01001 });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataOCPendConf.PL010100Row);
            }

            private void InitClass()
            {
                this.columnPL01001 = new DataColumn("PL01001", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01001);
                this.columnPL01002 = new DataColumn("PL01002", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01002);
                this.columnPL01003 = new DataColumn("PL01003", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01003);
                this.columnPL01004 = new DataColumn("PL01004", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01004);
                this.columnPL01005 = new DataColumn("PL01005", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01005);
                this.columnPL01006 = new DataColumn("PL01006", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01006);
                this.columnPL01007 = new DataColumn("PL01007", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01007);
                this.columnPL01008 = new DataColumn("PL01008", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01008);
                this.columnPL01009 = new DataColumn("PL01009", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01009);
                this.columnPL01010 = new DataColumn("PL01010", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01010);
                this.columnPL01011 = new DataColumn("PL01011", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01011);
                this.columnPL01012 = new DataColumn("PL01012", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01012);
                this.columnPL01013 = new DataColumn("PL01013", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01013);
                this.columnPL01014 = new DataColumn("PL01014", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01014);
                this.columnPL01015 = new DataColumn("PL01015", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01015);
                this.columnPL01016 = new DataColumn("PL01016", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01016);
                this.columnPL01017 = new DataColumn("PL01017", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01017);
                this.columnPL01018 = new DataColumn("PL01018", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01018);
                this.columnPL01019 = new DataColumn("PL01019", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01019);
                this.columnPL01020 = new DataColumn("PL01020", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01020);
                this.columnPL01021 = new DataColumn("PL01021", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01021);
                this.columnPL01022 = new DataColumn("PL01022", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01022);
                this.columnPL01023 = new DataColumn("PL01023", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01023);
                this.columnPL01024 = new DataColumn("PL01024", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01024);
                this.columnPL01025 = new DataColumn("PL01025", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01025);
                this.columnPL01026 = new DataColumn("PL01026", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01026);
                this.columnPL01027 = new DataColumn("PL01027", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01027);
                this.columnPL01028 = new DataColumn("PL01028", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01028);
                this.columnPL01029 = new DataColumn("PL01029", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01029);
                this.columnPL01030 = new DataColumn("PL01030", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01030);
                this.columnPL01031 = new DataColumn("PL01031", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01031);
                this.columnPL01032 = new DataColumn("PL01032", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01032);
                this.columnPL01033 = new DataColumn("PL01033", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01033);
                this.columnPL01034 = new DataColumn("PL01034", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01034);
                this.columnPL01035 = new DataColumn("PL01035", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnPL01035);
                this.columnPL01036 = new DataColumn("PL01036", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnPL01036);
                this.columnPL01037 = new DataColumn("PL01037", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01037);
                this.columnPL01038 = new DataColumn("PL01038", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01038);
                this.columnPL01039 = new DataColumn("PL01039", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01039);
                this.columnPL01040 = new DataColumn("PL01040", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01040);
                this.columnPL01041 = new DataColumn("PL01041", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01041);
                this.columnPL01042 = new DataColumn("PL01042", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01042);
                this.columnPL01043 = new DataColumn("PL01043", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01043);
                this.columnPL01044 = new DataColumn("PL01044", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01044);
                this.columnPL01045 = new DataColumn("PL01045", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01045);
                this.columnPL01046 = new DataColumn("PL01046", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01046);
                this.columnPL01047 = new DataColumn("PL01047", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01047);
                this.columnPL01048 = new DataColumn("PL01048", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01048);
                this.columnPL01049 = new DataColumn("PL01049", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01049);
                this.columnPL01050 = new DataColumn("PL01050", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01050);
                this.columnPL01051 = new DataColumn("PL01051", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01051);
                this.columnPL01052 = new DataColumn("PL01052", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01052);
                this.columnPL01053 = new DataColumn("PL01053", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01053);
                this.columnPL01054 = new DataColumn("PL01054", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01054);
                this.columnPL01055 = new DataColumn("PL01055", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01055);
                this.columnPL01056 = new DataColumn("PL01056", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01056);
                this.columnPL01057 = new DataColumn("PL01057", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01057);
                this.columnPL01058 = new DataColumn("PL01058", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01058);
                this.columnPL01059 = new DataColumn("PL01059", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01059);
                this.columnPL01060 = new DataColumn("PL01060", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01060);
                this.columnPL01061 = new DataColumn("PL01061", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01061);
                this.columnPL01062 = new DataColumn("PL01062", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01062);
                this.columnPL01063 = new DataColumn("PL01063", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01063);
                this.columnPL01064 = new DataColumn("PL01064", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01064);
                this.columnPL01065 = new DataColumn("PL01065", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01065);
                this.columnPL01066 = new DataColumn("PL01066", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01066);
                this.columnPL01067 = new DataColumn("PL01067", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01067);
                this.columnPL01068 = new DataColumn("PL01068", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01068);
                this.columnPL01069 = new DataColumn("PL01069", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01069);
                this.columnPL01070 = new DataColumn("PL01070", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01070);
                this.columnPL01071 = new DataColumn("PL01071", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01071);
                this.columnPL01072 = new DataColumn("PL01072", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01072);
                this.columnPL01073 = new DataColumn("PL01073", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01073);
                this.columnPL01074 = new DataColumn("PL01074", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01074);
                this.columnPL01075 = new DataColumn("PL01075", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01075);
                this.columnPL01076 = new DataColumn("PL01076", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01076);
                this.columnPL01077 = new DataColumn("PL01077", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnPL01077);
                this.Constraints.Add(new UniqueConstraint("DataOCPendConfKey4", new DataColumn[] { this.columnPL01001 }, true));
                this.columnPL01001.AllowDBNull = false;
                this.columnPL01001.Unique = true;
                this.columnPL01002.AllowDBNull = false;
                this.columnPL01003.AllowDBNull = false;
                this.columnPL01004.AllowDBNull = false;
                this.columnPL01005.AllowDBNull = false;
                this.columnPL01006.AllowDBNull = false;
                this.columnPL01007.AllowDBNull = false;
                this.columnPL01008.AllowDBNull = false;
                this.columnPL01009.AllowDBNull = false;
                this.columnPL01010.AllowDBNull = false;
                this.columnPL01011.AllowDBNull = false;
                this.columnPL01012.AllowDBNull = false;
                this.columnPL01013.AllowDBNull = false;
                this.columnPL01014.AllowDBNull = false;
                this.columnPL01015.AllowDBNull = false;
                this.columnPL01016.AllowDBNull = false;
                this.columnPL01017.AllowDBNull = false;
                this.columnPL01018.AllowDBNull = false;
                this.columnPL01019.AllowDBNull = false;
                this.columnPL01020.AllowDBNull = false;
                this.columnPL01021.AllowDBNull = false;
                this.columnPL01022.AllowDBNull = false;
                this.columnPL01023.AllowDBNull = false;
                this.columnPL01024.AllowDBNull = false;
                this.columnPL01025.AllowDBNull = false;
                this.columnPL01026.AllowDBNull = false;
                this.columnPL01027.AllowDBNull = false;
                this.columnPL01028.AllowDBNull = false;
                this.columnPL01029.AllowDBNull = false;
                this.columnPL01030.AllowDBNull = false;
                this.columnPL01031.AllowDBNull = false;
                this.columnPL01032.AllowDBNull = false;
                this.columnPL01033.AllowDBNull = false;
                this.columnPL01034.AllowDBNull = false;
                this.columnPL01035.AllowDBNull = false;
                this.columnPL01036.AllowDBNull = false;
                this.columnPL01037.AllowDBNull = false;
                this.columnPL01038.AllowDBNull = false;
                this.columnPL01039.AllowDBNull = false;
                this.columnPL01040.AllowDBNull = false;
                this.columnPL01041.AllowDBNull = false;
                this.columnPL01042.AllowDBNull = false;
                this.columnPL01043.AllowDBNull = false;
                this.columnPL01044.AllowDBNull = false;
                this.columnPL01045.AllowDBNull = false;
                this.columnPL01046.AllowDBNull = false;
                this.columnPL01047.AllowDBNull = false;
                this.columnPL01048.AllowDBNull = false;
                this.columnPL01049.AllowDBNull = false;
                this.columnPL01050.AllowDBNull = false;
                this.columnPL01051.AllowDBNull = false;
                this.columnPL01052.AllowDBNull = false;
                this.columnPL01053.AllowDBNull = false;
                this.columnPL01054.AllowDBNull = false;
                this.columnPL01055.AllowDBNull = false;
                this.columnPL01056.AllowDBNull = false;
                this.columnPL01057.AllowDBNull = false;
                this.columnPL01058.AllowDBNull = false;
                this.columnPL01059.AllowDBNull = false;
                this.columnPL01060.AllowDBNull = false;
                this.columnPL01061.AllowDBNull = false;
                this.columnPL01062.AllowDBNull = false;
                this.columnPL01063.AllowDBNull = false;
                this.columnPL01064.AllowDBNull = false;
                this.columnPL01065.AllowDBNull = false;
                this.columnPL01066.AllowDBNull = false;
                this.columnPL01067.AllowDBNull = false;
                this.columnPL01068.AllowDBNull = false;
                this.columnPL01069.AllowDBNull = false;
                this.columnPL01070.AllowDBNull = false;
                this.columnPL01071.AllowDBNull = false;
                this.columnPL01072.AllowDBNull = false;
                this.columnPL01073.AllowDBNull = false;
                this.columnPL01074.AllowDBNull = false;
                this.columnPL01075.AllowDBNull = false;
                this.columnPL01076.AllowDBNull = false;
                this.columnPL01077.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnPL01001 = this.Columns["PL01001"];
                this.columnPL01002 = this.Columns["PL01002"];
                this.columnPL01003 = this.Columns["PL01003"];
                this.columnPL01004 = this.Columns["PL01004"];
                this.columnPL01005 = this.Columns["PL01005"];
                this.columnPL01006 = this.Columns["PL01006"];
                this.columnPL01007 = this.Columns["PL01007"];
                this.columnPL01008 = this.Columns["PL01008"];
                this.columnPL01009 = this.Columns["PL01009"];
                this.columnPL01010 = this.Columns["PL01010"];
                this.columnPL01011 = this.Columns["PL01011"];
                this.columnPL01012 = this.Columns["PL01012"];
                this.columnPL01013 = this.Columns["PL01013"];
                this.columnPL01014 = this.Columns["PL01014"];
                this.columnPL01015 = this.Columns["PL01015"];
                this.columnPL01016 = this.Columns["PL01016"];
                this.columnPL01017 = this.Columns["PL01017"];
                this.columnPL01018 = this.Columns["PL01018"];
                this.columnPL01019 = this.Columns["PL01019"];
                this.columnPL01020 = this.Columns["PL01020"];
                this.columnPL01021 = this.Columns["PL01021"];
                this.columnPL01022 = this.Columns["PL01022"];
                this.columnPL01023 = this.Columns["PL01023"];
                this.columnPL01024 = this.Columns["PL01024"];
                this.columnPL01025 = this.Columns["PL01025"];
                this.columnPL01026 = this.Columns["PL01026"];
                this.columnPL01027 = this.Columns["PL01027"];
                this.columnPL01028 = this.Columns["PL01028"];
                this.columnPL01029 = this.Columns["PL01029"];
                this.columnPL01030 = this.Columns["PL01030"];
                this.columnPL01031 = this.Columns["PL01031"];
                this.columnPL01032 = this.Columns["PL01032"];
                this.columnPL01033 = this.Columns["PL01033"];
                this.columnPL01034 = this.Columns["PL01034"];
                this.columnPL01035 = this.Columns["PL01035"];
                this.columnPL01036 = this.Columns["PL01036"];
                this.columnPL01037 = this.Columns["PL01037"];
                this.columnPL01038 = this.Columns["PL01038"];
                this.columnPL01039 = this.Columns["PL01039"];
                this.columnPL01040 = this.Columns["PL01040"];
                this.columnPL01041 = this.Columns["PL01041"];
                this.columnPL01042 = this.Columns["PL01042"];
                this.columnPL01043 = this.Columns["PL01043"];
                this.columnPL01044 = this.Columns["PL01044"];
                this.columnPL01045 = this.Columns["PL01045"];
                this.columnPL01046 = this.Columns["PL01046"];
                this.columnPL01047 = this.Columns["PL01047"];
                this.columnPL01048 = this.Columns["PL01048"];
                this.columnPL01049 = this.Columns["PL01049"];
                this.columnPL01050 = this.Columns["PL01050"];
                this.columnPL01051 = this.Columns["PL01051"];
                this.columnPL01052 = this.Columns["PL01052"];
                this.columnPL01053 = this.Columns["PL01053"];
                this.columnPL01054 = this.Columns["PL01054"];
                this.columnPL01055 = this.Columns["PL01055"];
                this.columnPL01056 = this.Columns["PL01056"];
                this.columnPL01057 = this.Columns["PL01057"];
                this.columnPL01058 = this.Columns["PL01058"];
                this.columnPL01059 = this.Columns["PL01059"];
                this.columnPL01060 = this.Columns["PL01060"];
                this.columnPL01061 = this.Columns["PL01061"];
                this.columnPL01062 = this.Columns["PL01062"];
                this.columnPL01063 = this.Columns["PL01063"];
                this.columnPL01064 = this.Columns["PL01064"];
                this.columnPL01065 = this.Columns["PL01065"];
                this.columnPL01066 = this.Columns["PL01066"];
                this.columnPL01067 = this.Columns["PL01067"];
                this.columnPL01068 = this.Columns["PL01068"];
                this.columnPL01069 = this.Columns["PL01069"];
                this.columnPL01070 = this.Columns["PL01070"];
                this.columnPL01071 = this.Columns["PL01071"];
                this.columnPL01072 = this.Columns["PL01072"];
                this.columnPL01073 = this.Columns["PL01073"];
                this.columnPL01074 = this.Columns["PL01074"];
                this.columnPL01075 = this.Columns["PL01075"];
                this.columnPL01076 = this.Columns["PL01076"];
                this.columnPL01077 = this.Columns["PL01077"];
            }

            public DataOCPendConf.PL010100Row NewPL010100Row()
            {
                return (DataOCPendConf.PL010100Row) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataOCPendConf.PL010100Row(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PL010100RowChangedEvent != null) && (this.PL010100RowChangedEvent != null))
                {
                    this.PL010100RowChangedEvent(this, new DataOCPendConf.PL010100RowChangeEvent((DataOCPendConf.PL010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PL010100RowChangingEvent != null) && (this.PL010100RowChangingEvent != null))
                {
                    this.PL010100RowChangingEvent(this, new DataOCPendConf.PL010100RowChangeEvent((DataOCPendConf.PL010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PL010100RowDeletedEvent != null) && (this.PL010100RowDeletedEvent != null))
                {
                    this.PL010100RowDeletedEvent(this, new DataOCPendConf.PL010100RowChangeEvent((DataOCPendConf.PL010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PL010100RowDeletingEvent != null) && (this.PL010100RowDeletingEvent != null))
                {
                    this.PL010100RowDeletingEvent(this, new DataOCPendConf.PL010100RowChangeEvent((DataOCPendConf.PL010100Row) e.Row, e.Action));
                }
            }

            public void RemovePL010100Row(DataOCPendConf.PL010100Row row)
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

            public DataOCPendConf.PL010100Row this[int index]
            {
                get
                {
                    return (DataOCPendConf.PL010100Row) this.Rows[index];
                }
            }

            internal DataColumn PL01001Column
            {
                get
                {
                    return this.columnPL01001;
                }
            }

            internal DataColumn PL01002Column
            {
                get
                {
                    return this.columnPL01002;
                }
            }

            internal DataColumn PL01003Column
            {
                get
                {
                    return this.columnPL01003;
                }
            }

            internal DataColumn PL01004Column
            {
                get
                {
                    return this.columnPL01004;
                }
            }

            internal DataColumn PL01005Column
            {
                get
                {
                    return this.columnPL01005;
                }
            }

            internal DataColumn PL01006Column
            {
                get
                {
                    return this.columnPL01006;
                }
            }

            internal DataColumn PL01007Column
            {
                get
                {
                    return this.columnPL01007;
                }
            }

            internal DataColumn PL01008Column
            {
                get
                {
                    return this.columnPL01008;
                }
            }

            internal DataColumn PL01009Column
            {
                get
                {
                    return this.columnPL01009;
                }
            }

            internal DataColumn PL01010Column
            {
                get
                {
                    return this.columnPL01010;
                }
            }

            internal DataColumn PL01011Column
            {
                get
                {
                    return this.columnPL01011;
                }
            }

            internal DataColumn PL01012Column
            {
                get
                {
                    return this.columnPL01012;
                }
            }

            internal DataColumn PL01013Column
            {
                get
                {
                    return this.columnPL01013;
                }
            }

            internal DataColumn PL01014Column
            {
                get
                {
                    return this.columnPL01014;
                }
            }

            internal DataColumn PL01015Column
            {
                get
                {
                    return this.columnPL01015;
                }
            }

            internal DataColumn PL01016Column
            {
                get
                {
                    return this.columnPL01016;
                }
            }

            internal DataColumn PL01017Column
            {
                get
                {
                    return this.columnPL01017;
                }
            }

            internal DataColumn PL01018Column
            {
                get
                {
                    return this.columnPL01018;
                }
            }

            internal DataColumn PL01019Column
            {
                get
                {
                    return this.columnPL01019;
                }
            }

            internal DataColumn PL01020Column
            {
                get
                {
                    return this.columnPL01020;
                }
            }

            internal DataColumn PL01021Column
            {
                get
                {
                    return this.columnPL01021;
                }
            }

            internal DataColumn PL01022Column
            {
                get
                {
                    return this.columnPL01022;
                }
            }

            internal DataColumn PL01023Column
            {
                get
                {
                    return this.columnPL01023;
                }
            }

            internal DataColumn PL01024Column
            {
                get
                {
                    return this.columnPL01024;
                }
            }

            internal DataColumn PL01025Column
            {
                get
                {
                    return this.columnPL01025;
                }
            }

            internal DataColumn PL01026Column
            {
                get
                {
                    return this.columnPL01026;
                }
            }

            internal DataColumn PL01027Column
            {
                get
                {
                    return this.columnPL01027;
                }
            }

            internal DataColumn PL01028Column
            {
                get
                {
                    return this.columnPL01028;
                }
            }

            internal DataColumn PL01029Column
            {
                get
                {
                    return this.columnPL01029;
                }
            }

            internal DataColumn PL01030Column
            {
                get
                {
                    return this.columnPL01030;
                }
            }

            internal DataColumn PL01031Column
            {
                get
                {
                    return this.columnPL01031;
                }
            }

            internal DataColumn PL01032Column
            {
                get
                {
                    return this.columnPL01032;
                }
            }

            internal DataColumn PL01033Column
            {
                get
                {
                    return this.columnPL01033;
                }
            }

            internal DataColumn PL01034Column
            {
                get
                {
                    return this.columnPL01034;
                }
            }

            internal DataColumn PL01035Column
            {
                get
                {
                    return this.columnPL01035;
                }
            }

            internal DataColumn PL01036Column
            {
                get
                {
                    return this.columnPL01036;
                }
            }

            internal DataColumn PL01037Column
            {
                get
                {
                    return this.columnPL01037;
                }
            }

            internal DataColumn PL01038Column
            {
                get
                {
                    return this.columnPL01038;
                }
            }

            internal DataColumn PL01039Column
            {
                get
                {
                    return this.columnPL01039;
                }
            }

            internal DataColumn PL01040Column
            {
                get
                {
                    return this.columnPL01040;
                }
            }

            internal DataColumn PL01041Column
            {
                get
                {
                    return this.columnPL01041;
                }
            }

            internal DataColumn PL01042Column
            {
                get
                {
                    return this.columnPL01042;
                }
            }

            internal DataColumn PL01043Column
            {
                get
                {
                    return this.columnPL01043;
                }
            }

            internal DataColumn PL01044Column
            {
                get
                {
                    return this.columnPL01044;
                }
            }

            internal DataColumn PL01045Column
            {
                get
                {
                    return this.columnPL01045;
                }
            }

            internal DataColumn PL01046Column
            {
                get
                {
                    return this.columnPL01046;
                }
            }

            internal DataColumn PL01047Column
            {
                get
                {
                    return this.columnPL01047;
                }
            }

            internal DataColumn PL01048Column
            {
                get
                {
                    return this.columnPL01048;
                }
            }

            internal DataColumn PL01049Column
            {
                get
                {
                    return this.columnPL01049;
                }
            }

            internal DataColumn PL01050Column
            {
                get
                {
                    return this.columnPL01050;
                }
            }

            internal DataColumn PL01051Column
            {
                get
                {
                    return this.columnPL01051;
                }
            }

            internal DataColumn PL01052Column
            {
                get
                {
                    return this.columnPL01052;
                }
            }

            internal DataColumn PL01053Column
            {
                get
                {
                    return this.columnPL01053;
                }
            }

            internal DataColumn PL01054Column
            {
                get
                {
                    return this.columnPL01054;
                }
            }

            internal DataColumn PL01055Column
            {
                get
                {
                    return this.columnPL01055;
                }
            }

            internal DataColumn PL01056Column
            {
                get
                {
                    return this.columnPL01056;
                }
            }

            internal DataColumn PL01057Column
            {
                get
                {
                    return this.columnPL01057;
                }
            }

            internal DataColumn PL01058Column
            {
                get
                {
                    return this.columnPL01058;
                }
            }

            internal DataColumn PL01059Column
            {
                get
                {
                    return this.columnPL01059;
                }
            }

            internal DataColumn PL01060Column
            {
                get
                {
                    return this.columnPL01060;
                }
            }

            internal DataColumn PL01061Column
            {
                get
                {
                    return this.columnPL01061;
                }
            }

            internal DataColumn PL01062Column
            {
                get
                {
                    return this.columnPL01062;
                }
            }

            internal DataColumn PL01063Column
            {
                get
                {
                    return this.columnPL01063;
                }
            }

            internal DataColumn PL01064Column
            {
                get
                {
                    return this.columnPL01064;
                }
            }

            internal DataColumn PL01065Column
            {
                get
                {
                    return this.columnPL01065;
                }
            }

            internal DataColumn PL01066Column
            {
                get
                {
                    return this.columnPL01066;
                }
            }

            internal DataColumn PL01067Column
            {
                get
                {
                    return this.columnPL01067;
                }
            }

            internal DataColumn PL01068Column
            {
                get
                {
                    return this.columnPL01068;
                }
            }

            internal DataColumn PL01069Column
            {
                get
                {
                    return this.columnPL01069;
                }
            }

            internal DataColumn PL01070Column
            {
                get
                {
                    return this.columnPL01070;
                }
            }

            internal DataColumn PL01071Column
            {
                get
                {
                    return this.columnPL01071;
                }
            }

            internal DataColumn PL01072Column
            {
                get
                {
                    return this.columnPL01072;
                }
            }

            internal DataColumn PL01073Column
            {
                get
                {
                    return this.columnPL01073;
                }
            }

            internal DataColumn PL01074Column
            {
                get
                {
                    return this.columnPL01074;
                }
            }

            internal DataColumn PL01075Column
            {
                get
                {
                    return this.columnPL01075;
                }
            }

            internal DataColumn PL01076Column
            {
                get
                {
                    return this.columnPL01076;
                }
            }

            internal DataColumn PL01077Column
            {
                get
                {
                    return this.columnPL01077;
                }
            }
        }

        [DebuggerStepThrough]
        public class PL010100Row : DataRow
        {
            private DataOCPendConf.PL010100DataTable tablePL010100;

            internal PL010100Row(DataRowBuilder rb) : base(rb)
            {
                this.tablePL010100 = (DataOCPendConf.PL010100DataTable) this.Table;
            }

            public string PL01001
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01001Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01001Column] = value;
                }
            }

            public string PL01002
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01002Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01002Column] = value;
                }
            }

            public string PL01003
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01003Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01003Column] = value;
                }
            }

            public string PL01004
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01004Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01004Column] = value;
                }
            }

            public string PL01005
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01005Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01005Column] = value;
                }
            }

            public string PL01006
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01006Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01006Column] = value;
                }
            }

            public string PL01007
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01007Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01007Column] = value;
                }
            }

            public string PL01008
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01008Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01008Column] = value;
                }
            }

            public string PL01009
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01009Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01009Column] = value;
                }
            }

            public string PL01010
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01010Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01010Column] = value;
                }
            }

            public string PL01011
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01011Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01011Column] = value;
                }
            }

            public string PL01012
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01012Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01012Column] = value;
                }
            }

            public string PL01013
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01013Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01013Column] = value;
                }
            }

            public string PL01014
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01014Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01014Column] = value;
                }
            }

            public string PL01015
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01015Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01015Column] = value;
                }
            }

            public string PL01016
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01016Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01016Column] = value;
                }
            }

            public string PL01017
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01017Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01017Column] = value;
                }
            }

            public string PL01018
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01018Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01018Column] = value;
                }
            }

            public string PL01019
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01019Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01019Column] = value;
                }
            }

            public string PL01020
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01020Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01020Column] = value;
                }
            }

            public string PL01021
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01021Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01021Column] = value;
                }
            }

            public string PL01022
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01022Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01022Column] = value;
                }
            }

            public string PL01023
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01023Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01023Column] = value;
                }
            }

            public string PL01024
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01024Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01024Column] = value;
                }
            }

            public string PL01025
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01025Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01025Column] = value;
                }
            }

            public string PL01026
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01026Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01026Column] = value;
                }
            }

            public string PL01027
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01027Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01027Column] = value;
                }
            }

            public string PL01028
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01028Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01028Column] = value;
                }
            }

            public string PL01029
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01029Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01029Column] = value;
                }
            }

            public string PL01030
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01030Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01030Column] = value;
                }
            }

            public string PL01031
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01031Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01031Column] = value;
                }
            }

            public string PL01032
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01032Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01032Column] = value;
                }
            }

            public string PL01033
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01033Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01033Column] = value;
                }
            }

            public string PL01034
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01034Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01034Column] = value;
                }
            }

            public DateTime PL01035
            {
                get
                {
                    return DateType.FromObject(this[this.tablePL010100.PL01035Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01035Column] = value;
                }
            }

            public DateTime PL01036
            {
                get
                {
                    return DateType.FromObject(this[this.tablePL010100.PL01036Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01036Column] = value;
                }
            }

            public string PL01037
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01037Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01037Column] = value;
                }
            }

            public string PL01038
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01038Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01038Column] = value;
                }
            }

            public string PL01039
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01039Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01039Column] = value;
                }
            }

            public string PL01040
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01040Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01040Column] = value;
                }
            }

            public string PL01041
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01041Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01041Column] = value;
                }
            }

            public string PL01042
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01042Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01042Column] = value;
                }
            }

            public string PL01043
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01043Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01043Column] = value;
                }
            }

            public string PL01044
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01044Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01044Column] = value;
                }
            }

            public string PL01045
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01045Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01045Column] = value;
                }
            }

            public string PL01046
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01046Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01046Column] = value;
                }
            }

            public string PL01047
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01047Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01047Column] = value;
                }
            }

            public string PL01048
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01048Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01048Column] = value;
                }
            }

            public string PL01049
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01049Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01049Column] = value;
                }
            }

            public string PL01050
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01050Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01050Column] = value;
                }
            }

            public string PL01051
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01051Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01051Column] = value;
                }
            }

            public string PL01052
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01052Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01052Column] = value;
                }
            }

            public string PL01053
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01053Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01053Column] = value;
                }
            }

            public string PL01054
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01054Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01054Column] = value;
                }
            }

            public string PL01055
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01055Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01055Column] = value;
                }
            }

            public string PL01056
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01056Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01056Column] = value;
                }
            }

            public string PL01057
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01057Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01057Column] = value;
                }
            }

            public string PL01058
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01058Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01058Column] = value;
                }
            }

            public string PL01059
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01059Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01059Column] = value;
                }
            }

            public string PL01060
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01060Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01060Column] = value;
                }
            }

            public string PL01061
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01061Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01061Column] = value;
                }
            }

            public string PL01062
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01062Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01062Column] = value;
                }
            }

            public string PL01063
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01063Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01063Column] = value;
                }
            }

            public string PL01064
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01064Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01064Column] = value;
                }
            }

            public string PL01065
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01065Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01065Column] = value;
                }
            }

            public string PL01066
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01066Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01066Column] = value;
                }
            }

            public string PL01067
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01067Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01067Column] = value;
                }
            }

            public string PL01068
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01068Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01068Column] = value;
                }
            }

            public string PL01069
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01069Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01069Column] = value;
                }
            }

            public string PL01070
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01070Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01070Column] = value;
                }
            }

            public string PL01071
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01071Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01071Column] = value;
                }
            }

            public string PL01072
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01072Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01072Column] = value;
                }
            }

            public string PL01073
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01073Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01073Column] = value;
                }
            }

            public string PL01074
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01074Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01074Column] = value;
                }
            }

            public string PL01075
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01075Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01075Column] = value;
                }
            }

            public string PL01076
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01076Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01076Column] = value;
                }
            }

            public string PL01077
            {
                get
                {
                    return StringType.FromObject(this[this.tablePL010100.PL01077Column]);
                }
                set
                {
                    this[this.tablePL010100.PL01077Column] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PL010100RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataOCPendConf.PL010100Row eventRow;

            public PL010100RowChangeEvent(DataOCPendConf.PL010100Row row, DataRowAction action)
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

            public DataOCPendConf.PL010100Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PL010100RowChangeEventHandler(object sender, DataOCPendConf.PL010100RowChangeEvent e);

        [DebuggerStepThrough]
        public class SL010100DataTable : DataTable, IEnumerable
        {
            private DataColumn columnSL01001;
            private DataColumn columnSL01002;
            private DataColumn columnSL01003;
            private DataColumn columnSL01004;
            private DataColumn columnSL01005;
            private DataColumn columnSL01006;
            private DataColumn columnSL01007;
            private DataColumn columnSL01008;
            private DataColumn columnSL01009;
            private DataColumn columnSL01010;
            private DataColumn columnSL01011;
            private DataColumn columnSL01012;
            private DataColumn columnSL01013;
            private DataColumn columnSL01014;
            private DataColumn columnSL01015;
            private DataColumn columnSL01016;
            private DataColumn columnSL01017;
            private DataColumn columnSL01018;
            private DataColumn columnSL01019;
            private DataColumn columnSL01020;
            private DataColumn columnSL01021;
            private DataColumn columnSL01022;
            private DataColumn columnSL01023;
            private DataColumn columnSL01024;
            private DataColumn columnSL01025;
            private DataColumn columnSL01026;
            private DataColumn columnSL01027;
            private DataColumn columnSL01028;
            private DataColumn columnSL01029;
            private DataColumn columnSL01030;
            private DataColumn columnSL01031;
            private DataColumn columnSL01032;
            private DataColumn columnSL01033;
            private DataColumn columnSL01034;
            private DataColumn columnSL01035;
            private DataColumn columnSL01036;
            private DataColumn columnSL01037;
            private DataColumn columnSL01038;
            private DataColumn columnSL01039;
            private DataColumn columnSL01040;
            private DataColumn columnSL01041;
            private DataColumn columnSL01042;
            private DataColumn columnSL01043;
            private DataColumn columnSL01044;
            private DataColumn columnSL01045;
            private DataColumn columnSL01046;
            private DataColumn columnSL01047;
            private DataColumn columnSL01048;
            private DataColumn columnSL01049;
            private DataColumn columnSL01050;
            private DataColumn columnSL01051;
            private DataColumn columnSL01052;
            private DataColumn columnSL01053;
            private DataColumn columnSL01054;
            private DataColumn columnSL01055;
            private DataColumn columnSL01056;
            private DataColumn columnSL01057;
            private DataColumn columnSL01058;
            private DataColumn columnSL01059;
            private DataColumn columnSL01060;
            private DataColumn columnSL01061;
            private DataColumn columnSL01062;
            private DataColumn columnSL01063;
            private DataColumn columnSL01064;
            private DataColumn columnSL01065;
            private DataColumn columnSL01066;
            private DataColumn columnSL01067;
            private DataColumn columnSL01068;
            private DataColumn columnSL01069;
            private DataColumn columnSL01070;
            private DataColumn columnSL01071;
            private DataColumn columnSL01072;
            private DataColumn columnSL01073;
            private DataColumn columnSL01074;
            private DataColumn columnSL01075;
            private DataColumn columnSL01076;
            private DataColumn columnSL01077;
            private DataColumn columnSL01078;
            private DataColumn columnSL01079;
            private DataColumn columnSL01080;
            private DataColumn columnSL01081;
            private DataColumn columnSL01082;
            private DataColumn columnSL01083;
            private DataColumn columnSL01084;
            private DataColumn columnSL01085;
            private DataColumn columnSL01086;
            private DataColumn columnSL01087;
            private DataColumn columnSL01088;
            private DataColumn columnSL01089;
            private DataColumn columnSL01090;
            private DataColumn columnSL01091;
            private DataColumn columnSL01092;
            private DataColumn columnSL01093;
            private DataColumn columnSL01094;
            private DataColumn columnSL01095;
            private DataColumn columnSL01096;
            private DataColumn columnSL01097;
            private DataColumn columnSL01098;
            private DataColumn columnSL01099;
            private DataColumn columnSL01100;
            private DataColumn columnSL01101;
            private DataColumn columnSL01102;
            private DataColumn columnSL01103;
            private DataColumn columnSL01104;
            private DataColumn columnSL01105;
            private DataColumn columnSL01106;
            private DataColumn columnSL01107;
            private DataColumn columnSL01108;
            private DataColumn columnSL01109;
            private DataColumn columnSL01110;
            private DataColumn columnSL01111;
            private DataColumn columnSL01112;
            private DataColumn columnSL01113;
            private DataColumn columnSL01114;
            private DataColumn columnSL01115;
            private DataColumn columnSL01116;
            private DataColumn columnSL01117;
            private DataColumn columnSL01118;
            private DataColumn columnSL01119;
            private DataColumn columnSL01120;
            private DataColumn columnSL01121;
            private DataColumn columnSL01122;
            private DataColumn columnSL01123;
            private DataColumn columnSL01124;
            private DataColumn columnSL01125;
            private DataColumn columnSL01126;
            private DataColumn columnSL01127;
            private DataColumn columnSL01128;
            private DataColumn columnSL01129;

            public event DataOCPendConf.SL010100RowChangeEventHandler SL010100RowChanged;

            public event DataOCPendConf.SL010100RowChangeEventHandler SL010100RowChanging;

            public event DataOCPendConf.SL010100RowChangeEventHandler SL010100RowDeleted;

            public event DataOCPendConf.SL010100RowChangeEventHandler SL010100RowDeleting;

            internal SL010100DataTable() : base("SL010100")
            {
                this.InitClass();
            }

            internal SL010100DataTable(DataTable table) : base(table.TableName)
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

            public void AddSL010100Row(DataOCPendConf.SL010100Row row)
            {
                this.Rows.Add(row);
            }

            public DataOCPendConf.SL010100Row AddSL010100Row(string SL01001, string SL01002, string SL01003, string SL01004, string SL01005, string SL01006, string SL01007, string SL01008, string SL01009, string SL01010, string SL01011, string SL01012, string SL01013, string SL01014, string SL01015, string SL01016, string SL01017, string SL01018, string SL01019, string SL01020, string SL01021, string SL01022, string SL01023, string SL01024, string SL01025, string SL01026, string SL01027, string SL01028, string SL01029, string SL01030, string SL01031, string SL01032, string SL01033, string SL01034, string SL01035, string SL01036, string SL01037, string SL01038, string SL01039, string SL01040, string SL01041, string SL01042, string SL01043, string SL01044, string SL01045, string SL01046, string SL01047, string SL01048, string SL01049, DateTime SL01050, DateTime SL01051, string SL01052, string SL01053, string SL01054, string SL01055, string SL01056, string SL01057, string SL01058, string SL01059, string SL01060, string SL01061, string SL01062, string SL01063, string SL01064, string SL01065, string SL01066, string SL01067, string SL01068, string SL01069, string SL01070, string SL01071, string SL01072, string SL01073, string SL01074, string SL01075, string SL01076, string SL01077, string SL01078, string SL01079, string SL01080, string SL01081, string SL01082, string SL01083, string SL01084, string SL01085, string SL01086, string SL01087, string SL01088, string SL01089, string SL01090, string SL01091, string SL01092, string SL01093, string SL01094, string SL01095, string SL01096, string SL01097, string SL01098, string SL01099, string SL01100, string SL01101, string SL01102, string SL01103, string SL01104, string SL01105, string SL01106, string SL01107, string SL01108, string SL01109, string SL01110, string SL01111, string SL01112, string SL01113, string SL01114, string SL01115, string SL01116, string SL01117, string SL01118, string SL01119, string SL01120, string SL01121, string SL01122, string SL01123, string SL01124, string SL01125, string SL01126, string SL01127, string SL01128, string SL01129)
            {
                DataOCPendConf.SL010100Row row = (DataOCPendConf.SL010100Row) this.NewRow();
                row.ItemArray = new object[] { 
                    SL01001, SL01002, SL01003, SL01004, SL01005, SL01006, SL01007, SL01008, SL01009, SL01010, SL01011, SL01012, SL01013, SL01014, SL01015, SL01016, 
                    SL01017, SL01018, SL01019, SL01020, SL01021, SL01022, SL01023, SL01024, SL01025, SL01026, SL01027, SL01028, SL01029, SL01030, SL01031, SL01032, 
                    SL01033, SL01034, SL01035, SL01036, SL01037, SL01038, SL01039, SL01040, SL01041, SL01042, SL01043, SL01044, SL01045, SL01046, SL01047, SL01048, 
                    SL01049, SL01050, SL01051, SL01052, SL01053, SL01054, SL01055, SL01056, SL01057, SL01058, SL01059, SL01060, SL01061, SL01062, SL01063, SL01064, 
                    SL01065, SL01066, SL01067, SL01068, SL01069, SL01070, SL01071, SL01072, SL01073, SL01074, SL01075, SL01076, SL01077, SL01078, SL01079, SL01080, 
                    SL01081, SL01082, SL01083, SL01084, SL01085, SL01086, SL01087, SL01088, SL01089, SL01090, SL01091, SL01092, SL01093, SL01094, SL01095, SL01096, 
                    SL01097, SL01098, SL01099, SL01100, SL01101, SL01102, SL01103, SL01104, SL01105, SL01106, SL01107, SL01108, SL01109, SL01110, SL01111, SL01112, 
                    SL01113, SL01114, SL01115, SL01116, SL01117, SL01118, SL01119, SL01120, SL01121, SL01122, SL01123, SL01124, SL01125, SL01126, SL01127, SL01128, 
                    SL01129
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataOCPendConf.SL010100DataTable table = (DataOCPendConf.SL010100DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataOCPendConf.SL010100DataTable();
            }

            public DataOCPendConf.SL010100Row FindBySL01001(string SL01001)
            {
                return (DataOCPendConf.SL010100Row) this.Rows.Find(new object[] { SL01001 });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataOCPendConf.SL010100Row);
            }

            private void InitClass()
            {
                this.columnSL01001 = new DataColumn("SL01001", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01001);
                this.columnSL01002 = new DataColumn("SL01002", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01002);
                this.columnSL01003 = new DataColumn("SL01003", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01003);
                this.columnSL01004 = new DataColumn("SL01004", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01004);
                this.columnSL01005 = new DataColumn("SL01005", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01005);
                this.columnSL01006 = new DataColumn("SL01006", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01006);
                this.columnSL01007 = new DataColumn("SL01007", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01007);
                this.columnSL01008 = new DataColumn("SL01008", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01008);
                this.columnSL01009 = new DataColumn("SL01009", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01009);
                this.columnSL01010 = new DataColumn("SL01010", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01010);
                this.columnSL01011 = new DataColumn("SL01011", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01011);
                this.columnSL01012 = new DataColumn("SL01012", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01012);
                this.columnSL01013 = new DataColumn("SL01013", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01013);
                this.columnSL01014 = new DataColumn("SL01014", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01014);
                this.columnSL01015 = new DataColumn("SL01015", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01015);
                this.columnSL01016 = new DataColumn("SL01016", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01016);
                this.columnSL01017 = new DataColumn("SL01017", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01017);
                this.columnSL01018 = new DataColumn("SL01018", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01018);
                this.columnSL01019 = new DataColumn("SL01019", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01019);
                this.columnSL01020 = new DataColumn("SL01020", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01020);
                this.columnSL01021 = new DataColumn("SL01021", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01021);
                this.columnSL01022 = new DataColumn("SL01022", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01022);
                this.columnSL01023 = new DataColumn("SL01023", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01023);
                this.columnSL01024 = new DataColumn("SL01024", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01024);
                this.columnSL01025 = new DataColumn("SL01025", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01025);
                this.columnSL01026 = new DataColumn("SL01026", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01026);
                this.columnSL01027 = new DataColumn("SL01027", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01027);
                this.columnSL01028 = new DataColumn("SL01028", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01028);
                this.columnSL01029 = new DataColumn("SL01029", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01029);
                this.columnSL01030 = new DataColumn("SL01030", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01030);
                this.columnSL01031 = new DataColumn("SL01031", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01031);
                this.columnSL01032 = new DataColumn("SL01032", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01032);
                this.columnSL01033 = new DataColumn("SL01033", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01033);
                this.columnSL01034 = new DataColumn("SL01034", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01034);
                this.columnSL01035 = new DataColumn("SL01035", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01035);
                this.columnSL01036 = new DataColumn("SL01036", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01036);
                this.columnSL01037 = new DataColumn("SL01037", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01037);
                this.columnSL01038 = new DataColumn("SL01038", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01038);
                this.columnSL01039 = new DataColumn("SL01039", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01039);
                this.columnSL01040 = new DataColumn("SL01040", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01040);
                this.columnSL01041 = new DataColumn("SL01041", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01041);
                this.columnSL01042 = new DataColumn("SL01042", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01042);
                this.columnSL01043 = new DataColumn("SL01043", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01043);
                this.columnSL01044 = new DataColumn("SL01044", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01044);
                this.columnSL01045 = new DataColumn("SL01045", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01045);
                this.columnSL01046 = new DataColumn("SL01046", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01046);
                this.columnSL01047 = new DataColumn("SL01047", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01047);
                this.columnSL01048 = new DataColumn("SL01048", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01048);
                this.columnSL01049 = new DataColumn("SL01049", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01049);
                this.columnSL01050 = new DataColumn("SL01050", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnSL01050);
                this.columnSL01051 = new DataColumn("SL01051", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnSL01051);
                this.columnSL01052 = new DataColumn("SL01052", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01052);
                this.columnSL01053 = new DataColumn("SL01053", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01053);
                this.columnSL01054 = new DataColumn("SL01054", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01054);
                this.columnSL01055 = new DataColumn("SL01055", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01055);
                this.columnSL01056 = new DataColumn("SL01056", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01056);
                this.columnSL01057 = new DataColumn("SL01057", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01057);
                this.columnSL01058 = new DataColumn("SL01058", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01058);
                this.columnSL01059 = new DataColumn("SL01059", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01059);
                this.columnSL01060 = new DataColumn("SL01060", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01060);
                this.columnSL01061 = new DataColumn("SL01061", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01061);
                this.columnSL01062 = new DataColumn("SL01062", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01062);
                this.columnSL01063 = new DataColumn("SL01063", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01063);
                this.columnSL01064 = new DataColumn("SL01064", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01064);
                this.columnSL01065 = new DataColumn("SL01065", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01065);
                this.columnSL01066 = new DataColumn("SL01066", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01066);
                this.columnSL01067 = new DataColumn("SL01067", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01067);
                this.columnSL01068 = new DataColumn("SL01068", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01068);
                this.columnSL01069 = new DataColumn("SL01069", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01069);
                this.columnSL01070 = new DataColumn("SL01070", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01070);
                this.columnSL01071 = new DataColumn("SL01071", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01071);
                this.columnSL01072 = new DataColumn("SL01072", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01072);
                this.columnSL01073 = new DataColumn("SL01073", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01073);
                this.columnSL01074 = new DataColumn("SL01074", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01074);
                this.columnSL01075 = new DataColumn("SL01075", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01075);
                this.columnSL01076 = new DataColumn("SL01076", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01076);
                this.columnSL01077 = new DataColumn("SL01077", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01077);
                this.columnSL01078 = new DataColumn("SL01078", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01078);
                this.columnSL01079 = new DataColumn("SL01079", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01079);
                this.columnSL01080 = new DataColumn("SL01080", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01080);
                this.columnSL01081 = new DataColumn("SL01081", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01081);
                this.columnSL01082 = new DataColumn("SL01082", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01082);
                this.columnSL01083 = new DataColumn("SL01083", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01083);
                this.columnSL01084 = new DataColumn("SL01084", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01084);
                this.columnSL01085 = new DataColumn("SL01085", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01085);
                this.columnSL01086 = new DataColumn("SL01086", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01086);
                this.columnSL01087 = new DataColumn("SL01087", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01087);
                this.columnSL01088 = new DataColumn("SL01088", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01088);
                this.columnSL01089 = new DataColumn("SL01089", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01089);
                this.columnSL01090 = new DataColumn("SL01090", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01090);
                this.columnSL01091 = new DataColumn("SL01091", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01091);
                this.columnSL01092 = new DataColumn("SL01092", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01092);
                this.columnSL01093 = new DataColumn("SL01093", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01093);
                this.columnSL01094 = new DataColumn("SL01094", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01094);
                this.columnSL01095 = new DataColumn("SL01095", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01095);
                this.columnSL01096 = new DataColumn("SL01096", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01096);
                this.columnSL01097 = new DataColumn("SL01097", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01097);
                this.columnSL01098 = new DataColumn("SL01098", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01098);
                this.columnSL01099 = new DataColumn("SL01099", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01099);
                this.columnSL01100 = new DataColumn("SL01100", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01100);
                this.columnSL01101 = new DataColumn("SL01101", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01101);
                this.columnSL01102 = new DataColumn("SL01102", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01102);
                this.columnSL01103 = new DataColumn("SL01103", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01103);
                this.columnSL01104 = new DataColumn("SL01104", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01104);
                this.columnSL01105 = new DataColumn("SL01105", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01105);
                this.columnSL01106 = new DataColumn("SL01106", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01106);
                this.columnSL01107 = new DataColumn("SL01107", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01107);
                this.columnSL01108 = new DataColumn("SL01108", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01108);
                this.columnSL01109 = new DataColumn("SL01109", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01109);
                this.columnSL01110 = new DataColumn("SL01110", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01110);
                this.columnSL01111 = new DataColumn("SL01111", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01111);
                this.columnSL01112 = new DataColumn("SL01112", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01112);
                this.columnSL01113 = new DataColumn("SL01113", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01113);
                this.columnSL01114 = new DataColumn("SL01114", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01114);
                this.columnSL01115 = new DataColumn("SL01115", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01115);
                this.columnSL01116 = new DataColumn("SL01116", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01116);
                this.columnSL01117 = new DataColumn("SL01117", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01117);
                this.columnSL01118 = new DataColumn("SL01118", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01118);
                this.columnSL01119 = new DataColumn("SL01119", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01119);
                this.columnSL01120 = new DataColumn("SL01120", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01120);
                this.columnSL01121 = new DataColumn("SL01121", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01121);
                this.columnSL01122 = new DataColumn("SL01122", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01122);
                this.columnSL01123 = new DataColumn("SL01123", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01123);
                this.columnSL01124 = new DataColumn("SL01124", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01124);
                this.columnSL01125 = new DataColumn("SL01125", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01125);
                this.columnSL01126 = new DataColumn("SL01126", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01126);
                this.columnSL01127 = new DataColumn("SL01127", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01127);
                this.columnSL01128 = new DataColumn("SL01128", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01128);
                this.columnSL01129 = new DataColumn("SL01129", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSL01129);
                this.Constraints.Add(new UniqueConstraint("DataOCPendConfKey5", new DataColumn[] { this.columnSL01001 }, true));
                this.columnSL01001.AllowDBNull = false;
                this.columnSL01001.Unique = true;
                this.columnSL01002.AllowDBNull = false;
                this.columnSL01003.AllowDBNull = false;
                this.columnSL01004.AllowDBNull = false;
                this.columnSL01005.AllowDBNull = false;
                this.columnSL01006.AllowDBNull = false;
                this.columnSL01007.AllowDBNull = false;
                this.columnSL01008.AllowDBNull = false;
                this.columnSL01009.AllowDBNull = false;
                this.columnSL01010.AllowDBNull = false;
                this.columnSL01011.AllowDBNull = false;
                this.columnSL01012.AllowDBNull = false;
                this.columnSL01013.AllowDBNull = false;
                this.columnSL01014.AllowDBNull = false;
                this.columnSL01015.AllowDBNull = false;
                this.columnSL01016.AllowDBNull = false;
                this.columnSL01017.AllowDBNull = false;
                this.columnSL01018.AllowDBNull = false;
                this.columnSL01019.AllowDBNull = false;
                this.columnSL01020.AllowDBNull = false;
                this.columnSL01021.AllowDBNull = false;
                this.columnSL01022.AllowDBNull = false;
                this.columnSL01023.AllowDBNull = false;
                this.columnSL01024.AllowDBNull = false;
                this.columnSL01025.AllowDBNull = false;
                this.columnSL01026.AllowDBNull = false;
                this.columnSL01027.AllowDBNull = false;
                this.columnSL01028.AllowDBNull = false;
                this.columnSL01029.AllowDBNull = false;
                this.columnSL01030.AllowDBNull = false;
                this.columnSL01031.AllowDBNull = false;
                this.columnSL01032.AllowDBNull = false;
                this.columnSL01033.AllowDBNull = false;
                this.columnSL01034.AllowDBNull = false;
                this.columnSL01035.AllowDBNull = false;
                this.columnSL01036.AllowDBNull = false;
                this.columnSL01037.AllowDBNull = false;
                this.columnSL01038.AllowDBNull = false;
                this.columnSL01039.AllowDBNull = false;
                this.columnSL01040.AllowDBNull = false;
                this.columnSL01041.AllowDBNull = false;
                this.columnSL01042.AllowDBNull = false;
                this.columnSL01043.AllowDBNull = false;
                this.columnSL01044.AllowDBNull = false;
                this.columnSL01045.AllowDBNull = false;
                this.columnSL01046.AllowDBNull = false;
                this.columnSL01047.AllowDBNull = false;
                this.columnSL01048.AllowDBNull = false;
                this.columnSL01049.AllowDBNull = false;
                this.columnSL01050.AllowDBNull = false;
                this.columnSL01051.AllowDBNull = false;
                this.columnSL01052.AllowDBNull = false;
                this.columnSL01053.AllowDBNull = false;
                this.columnSL01054.AllowDBNull = false;
                this.columnSL01055.AllowDBNull = false;
                this.columnSL01056.AllowDBNull = false;
                this.columnSL01057.AllowDBNull = false;
                this.columnSL01058.AllowDBNull = false;
                this.columnSL01059.AllowDBNull = false;
                this.columnSL01060.AllowDBNull = false;
                this.columnSL01061.AllowDBNull = false;
                this.columnSL01062.AllowDBNull = false;
                this.columnSL01063.AllowDBNull = false;
                this.columnSL01064.AllowDBNull = false;
                this.columnSL01065.AllowDBNull = false;
                this.columnSL01066.AllowDBNull = false;
                this.columnSL01067.AllowDBNull = false;
                this.columnSL01068.AllowDBNull = false;
                this.columnSL01069.AllowDBNull = false;
                this.columnSL01070.AllowDBNull = false;
                this.columnSL01071.AllowDBNull = false;
                this.columnSL01072.AllowDBNull = false;
                this.columnSL01073.AllowDBNull = false;
                this.columnSL01074.AllowDBNull = false;
                this.columnSL01075.AllowDBNull = false;
                this.columnSL01076.AllowDBNull = false;
                this.columnSL01077.AllowDBNull = false;
                this.columnSL01078.AllowDBNull = false;
                this.columnSL01079.AllowDBNull = false;
                this.columnSL01080.AllowDBNull = false;
                this.columnSL01081.AllowDBNull = false;
                this.columnSL01082.AllowDBNull = false;
                this.columnSL01083.AllowDBNull = false;
                this.columnSL01084.AllowDBNull = false;
                this.columnSL01085.AllowDBNull = false;
                this.columnSL01086.AllowDBNull = false;
                this.columnSL01087.AllowDBNull = false;
                this.columnSL01088.AllowDBNull = false;
                this.columnSL01089.AllowDBNull = false;
                this.columnSL01090.AllowDBNull = false;
                this.columnSL01091.AllowDBNull = false;
                this.columnSL01092.AllowDBNull = false;
                this.columnSL01093.AllowDBNull = false;
                this.columnSL01094.AllowDBNull = false;
                this.columnSL01095.AllowDBNull = false;
                this.columnSL01096.AllowDBNull = false;
                this.columnSL01097.AllowDBNull = false;
                this.columnSL01098.AllowDBNull = false;
                this.columnSL01099.AllowDBNull = false;
                this.columnSL01100.AllowDBNull = false;
                this.columnSL01101.AllowDBNull = false;
                this.columnSL01102.AllowDBNull = false;
                this.columnSL01103.AllowDBNull = false;
                this.columnSL01104.AllowDBNull = false;
                this.columnSL01105.AllowDBNull = false;
                this.columnSL01106.AllowDBNull = false;
                this.columnSL01107.AllowDBNull = false;
                this.columnSL01108.AllowDBNull = false;
                this.columnSL01109.AllowDBNull = false;
                this.columnSL01110.AllowDBNull = false;
                this.columnSL01111.AllowDBNull = false;
                this.columnSL01112.AllowDBNull = false;
                this.columnSL01113.AllowDBNull = false;
                this.columnSL01114.AllowDBNull = false;
                this.columnSL01115.AllowDBNull = false;
                this.columnSL01116.AllowDBNull = false;
                this.columnSL01117.AllowDBNull = false;
                this.columnSL01118.AllowDBNull = false;
                this.columnSL01119.AllowDBNull = false;
                this.columnSL01120.AllowDBNull = false;
                this.columnSL01121.AllowDBNull = false;
                this.columnSL01122.AllowDBNull = false;
                this.columnSL01123.AllowDBNull = false;
                this.columnSL01124.AllowDBNull = false;
                this.columnSL01125.AllowDBNull = false;
                this.columnSL01126.AllowDBNull = false;
                this.columnSL01127.AllowDBNull = false;
                this.columnSL01128.AllowDBNull = false;
                this.columnSL01129.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnSL01001 = this.Columns["SL01001"];
                this.columnSL01002 = this.Columns["SL01002"];
                this.columnSL01003 = this.Columns["SL01003"];
                this.columnSL01004 = this.Columns["SL01004"];
                this.columnSL01005 = this.Columns["SL01005"];
                this.columnSL01006 = this.Columns["SL01006"];
                this.columnSL01007 = this.Columns["SL01007"];
                this.columnSL01008 = this.Columns["SL01008"];
                this.columnSL01009 = this.Columns["SL01009"];
                this.columnSL01010 = this.Columns["SL01010"];
                this.columnSL01011 = this.Columns["SL01011"];
                this.columnSL01012 = this.Columns["SL01012"];
                this.columnSL01013 = this.Columns["SL01013"];
                this.columnSL01014 = this.Columns["SL01014"];
                this.columnSL01015 = this.Columns["SL01015"];
                this.columnSL01016 = this.Columns["SL01016"];
                this.columnSL01017 = this.Columns["SL01017"];
                this.columnSL01018 = this.Columns["SL01018"];
                this.columnSL01019 = this.Columns["SL01019"];
                this.columnSL01020 = this.Columns["SL01020"];
                this.columnSL01021 = this.Columns["SL01021"];
                this.columnSL01022 = this.Columns["SL01022"];
                this.columnSL01023 = this.Columns["SL01023"];
                this.columnSL01024 = this.Columns["SL01024"];
                this.columnSL01025 = this.Columns["SL01025"];
                this.columnSL01026 = this.Columns["SL01026"];
                this.columnSL01027 = this.Columns["SL01027"];
                this.columnSL01028 = this.Columns["SL01028"];
                this.columnSL01029 = this.Columns["SL01029"];
                this.columnSL01030 = this.Columns["SL01030"];
                this.columnSL01031 = this.Columns["SL01031"];
                this.columnSL01032 = this.Columns["SL01032"];
                this.columnSL01033 = this.Columns["SL01033"];
                this.columnSL01034 = this.Columns["SL01034"];
                this.columnSL01035 = this.Columns["SL01035"];
                this.columnSL01036 = this.Columns["SL01036"];
                this.columnSL01037 = this.Columns["SL01037"];
                this.columnSL01038 = this.Columns["SL01038"];
                this.columnSL01039 = this.Columns["SL01039"];
                this.columnSL01040 = this.Columns["SL01040"];
                this.columnSL01041 = this.Columns["SL01041"];
                this.columnSL01042 = this.Columns["SL01042"];
                this.columnSL01043 = this.Columns["SL01043"];
                this.columnSL01044 = this.Columns["SL01044"];
                this.columnSL01045 = this.Columns["SL01045"];
                this.columnSL01046 = this.Columns["SL01046"];
                this.columnSL01047 = this.Columns["SL01047"];
                this.columnSL01048 = this.Columns["SL01048"];
                this.columnSL01049 = this.Columns["SL01049"];
                this.columnSL01050 = this.Columns["SL01050"];
                this.columnSL01051 = this.Columns["SL01051"];
                this.columnSL01052 = this.Columns["SL01052"];
                this.columnSL01053 = this.Columns["SL01053"];
                this.columnSL01054 = this.Columns["SL01054"];
                this.columnSL01055 = this.Columns["SL01055"];
                this.columnSL01056 = this.Columns["SL01056"];
                this.columnSL01057 = this.Columns["SL01057"];
                this.columnSL01058 = this.Columns["SL01058"];
                this.columnSL01059 = this.Columns["SL01059"];
                this.columnSL01060 = this.Columns["SL01060"];
                this.columnSL01061 = this.Columns["SL01061"];
                this.columnSL01062 = this.Columns["SL01062"];
                this.columnSL01063 = this.Columns["SL01063"];
                this.columnSL01064 = this.Columns["SL01064"];
                this.columnSL01065 = this.Columns["SL01065"];
                this.columnSL01066 = this.Columns["SL01066"];
                this.columnSL01067 = this.Columns["SL01067"];
                this.columnSL01068 = this.Columns["SL01068"];
                this.columnSL01069 = this.Columns["SL01069"];
                this.columnSL01070 = this.Columns["SL01070"];
                this.columnSL01071 = this.Columns["SL01071"];
                this.columnSL01072 = this.Columns["SL01072"];
                this.columnSL01073 = this.Columns["SL01073"];
                this.columnSL01074 = this.Columns["SL01074"];
                this.columnSL01075 = this.Columns["SL01075"];
                this.columnSL01076 = this.Columns["SL01076"];
                this.columnSL01077 = this.Columns["SL01077"];
                this.columnSL01078 = this.Columns["SL01078"];
                this.columnSL01079 = this.Columns["SL01079"];
                this.columnSL01080 = this.Columns["SL01080"];
                this.columnSL01081 = this.Columns["SL01081"];
                this.columnSL01082 = this.Columns["SL01082"];
                this.columnSL01083 = this.Columns["SL01083"];
                this.columnSL01084 = this.Columns["SL01084"];
                this.columnSL01085 = this.Columns["SL01085"];
                this.columnSL01086 = this.Columns["SL01086"];
                this.columnSL01087 = this.Columns["SL01087"];
                this.columnSL01088 = this.Columns["SL01088"];
                this.columnSL01089 = this.Columns["SL01089"];
                this.columnSL01090 = this.Columns["SL01090"];
                this.columnSL01091 = this.Columns["SL01091"];
                this.columnSL01092 = this.Columns["SL01092"];
                this.columnSL01093 = this.Columns["SL01093"];
                this.columnSL01094 = this.Columns["SL01094"];
                this.columnSL01095 = this.Columns["SL01095"];
                this.columnSL01096 = this.Columns["SL01096"];
                this.columnSL01097 = this.Columns["SL01097"];
                this.columnSL01098 = this.Columns["SL01098"];
                this.columnSL01099 = this.Columns["SL01099"];
                this.columnSL01100 = this.Columns["SL01100"];
                this.columnSL01101 = this.Columns["SL01101"];
                this.columnSL01102 = this.Columns["SL01102"];
                this.columnSL01103 = this.Columns["SL01103"];
                this.columnSL01104 = this.Columns["SL01104"];
                this.columnSL01105 = this.Columns["SL01105"];
                this.columnSL01106 = this.Columns["SL01106"];
                this.columnSL01107 = this.Columns["SL01107"];
                this.columnSL01108 = this.Columns["SL01108"];
                this.columnSL01109 = this.Columns["SL01109"];
                this.columnSL01110 = this.Columns["SL01110"];
                this.columnSL01111 = this.Columns["SL01111"];
                this.columnSL01112 = this.Columns["SL01112"];
                this.columnSL01113 = this.Columns["SL01113"];
                this.columnSL01114 = this.Columns["SL01114"];
                this.columnSL01115 = this.Columns["SL01115"];
                this.columnSL01116 = this.Columns["SL01116"];
                this.columnSL01117 = this.Columns["SL01117"];
                this.columnSL01118 = this.Columns["SL01118"];
                this.columnSL01119 = this.Columns["SL01119"];
                this.columnSL01120 = this.Columns["SL01120"];
                this.columnSL01121 = this.Columns["SL01121"];
                this.columnSL01122 = this.Columns["SL01122"];
                this.columnSL01123 = this.Columns["SL01123"];
                this.columnSL01124 = this.Columns["SL01124"];
                this.columnSL01125 = this.Columns["SL01125"];
                this.columnSL01126 = this.Columns["SL01126"];
                this.columnSL01127 = this.Columns["SL01127"];
                this.columnSL01128 = this.Columns["SL01128"];
                this.columnSL01129 = this.Columns["SL01129"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataOCPendConf.SL010100Row(builder);
            }

            public DataOCPendConf.SL010100Row NewSL010100Row()
            {
                return (DataOCPendConf.SL010100Row) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.SL010100RowChangedEvent != null) && (this.SL010100RowChangedEvent != null))
                {
                    this.SL010100RowChangedEvent(this, new DataOCPendConf.SL010100RowChangeEvent((DataOCPendConf.SL010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.SL010100RowChangingEvent != null) && (this.SL010100RowChangingEvent != null))
                {
                    this.SL010100RowChangingEvent(this, new DataOCPendConf.SL010100RowChangeEvent((DataOCPendConf.SL010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.SL010100RowDeletedEvent != null) && (this.SL010100RowDeletedEvent != null))
                {
                    this.SL010100RowDeletedEvent(this, new DataOCPendConf.SL010100RowChangeEvent((DataOCPendConf.SL010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.SL010100RowDeletingEvent != null) && (this.SL010100RowDeletingEvent != null))
                {
                    this.SL010100RowDeletingEvent(this, new DataOCPendConf.SL010100RowChangeEvent((DataOCPendConf.SL010100Row) e.Row, e.Action));
                }
            }

            public void RemoveSL010100Row(DataOCPendConf.SL010100Row row)
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

            public DataOCPendConf.SL010100Row this[int index]
            {
                get
                {
                    return (DataOCPendConf.SL010100Row) this.Rows[index];
                }
            }

            internal DataColumn SL01001Column
            {
                get
                {
                    return this.columnSL01001;
                }
            }

            internal DataColumn SL01002Column
            {
                get
                {
                    return this.columnSL01002;
                }
            }

            internal DataColumn SL01003Column
            {
                get
                {
                    return this.columnSL01003;
                }
            }

            internal DataColumn SL01004Column
            {
                get
                {
                    return this.columnSL01004;
                }
            }

            internal DataColumn SL01005Column
            {
                get
                {
                    return this.columnSL01005;
                }
            }

            internal DataColumn SL01006Column
            {
                get
                {
                    return this.columnSL01006;
                }
            }

            internal DataColumn SL01007Column
            {
                get
                {
                    return this.columnSL01007;
                }
            }

            internal DataColumn SL01008Column
            {
                get
                {
                    return this.columnSL01008;
                }
            }

            internal DataColumn SL01009Column
            {
                get
                {
                    return this.columnSL01009;
                }
            }

            internal DataColumn SL01010Column
            {
                get
                {
                    return this.columnSL01010;
                }
            }

            internal DataColumn SL01011Column
            {
                get
                {
                    return this.columnSL01011;
                }
            }

            internal DataColumn SL01012Column
            {
                get
                {
                    return this.columnSL01012;
                }
            }

            internal DataColumn SL01013Column
            {
                get
                {
                    return this.columnSL01013;
                }
            }

            internal DataColumn SL01014Column
            {
                get
                {
                    return this.columnSL01014;
                }
            }

            internal DataColumn SL01015Column
            {
                get
                {
                    return this.columnSL01015;
                }
            }

            internal DataColumn SL01016Column
            {
                get
                {
                    return this.columnSL01016;
                }
            }

            internal DataColumn SL01017Column
            {
                get
                {
                    return this.columnSL01017;
                }
            }

            internal DataColumn SL01018Column
            {
                get
                {
                    return this.columnSL01018;
                }
            }

            internal DataColumn SL01019Column
            {
                get
                {
                    return this.columnSL01019;
                }
            }

            internal DataColumn SL01020Column
            {
                get
                {
                    return this.columnSL01020;
                }
            }

            internal DataColumn SL01021Column
            {
                get
                {
                    return this.columnSL01021;
                }
            }

            internal DataColumn SL01022Column
            {
                get
                {
                    return this.columnSL01022;
                }
            }

            internal DataColumn SL01023Column
            {
                get
                {
                    return this.columnSL01023;
                }
            }

            internal DataColumn SL01024Column
            {
                get
                {
                    return this.columnSL01024;
                }
            }

            internal DataColumn SL01025Column
            {
                get
                {
                    return this.columnSL01025;
                }
            }

            internal DataColumn SL01026Column
            {
                get
                {
                    return this.columnSL01026;
                }
            }

            internal DataColumn SL01027Column
            {
                get
                {
                    return this.columnSL01027;
                }
            }

            internal DataColumn SL01028Column
            {
                get
                {
                    return this.columnSL01028;
                }
            }

            internal DataColumn SL01029Column
            {
                get
                {
                    return this.columnSL01029;
                }
            }

            internal DataColumn SL01030Column
            {
                get
                {
                    return this.columnSL01030;
                }
            }

            internal DataColumn SL01031Column
            {
                get
                {
                    return this.columnSL01031;
                }
            }

            internal DataColumn SL01032Column
            {
                get
                {
                    return this.columnSL01032;
                }
            }

            internal DataColumn SL01033Column
            {
                get
                {
                    return this.columnSL01033;
                }
            }

            internal DataColumn SL01034Column
            {
                get
                {
                    return this.columnSL01034;
                }
            }

            internal DataColumn SL01035Column
            {
                get
                {
                    return this.columnSL01035;
                }
            }

            internal DataColumn SL01036Column
            {
                get
                {
                    return this.columnSL01036;
                }
            }

            internal DataColumn SL01037Column
            {
                get
                {
                    return this.columnSL01037;
                }
            }

            internal DataColumn SL01038Column
            {
                get
                {
                    return this.columnSL01038;
                }
            }

            internal DataColumn SL01039Column
            {
                get
                {
                    return this.columnSL01039;
                }
            }

            internal DataColumn SL01040Column
            {
                get
                {
                    return this.columnSL01040;
                }
            }

            internal DataColumn SL01041Column
            {
                get
                {
                    return this.columnSL01041;
                }
            }

            internal DataColumn SL01042Column
            {
                get
                {
                    return this.columnSL01042;
                }
            }

            internal DataColumn SL01043Column
            {
                get
                {
                    return this.columnSL01043;
                }
            }

            internal DataColumn SL01044Column
            {
                get
                {
                    return this.columnSL01044;
                }
            }

            internal DataColumn SL01045Column
            {
                get
                {
                    return this.columnSL01045;
                }
            }

            internal DataColumn SL01046Column
            {
                get
                {
                    return this.columnSL01046;
                }
            }

            internal DataColumn SL01047Column
            {
                get
                {
                    return this.columnSL01047;
                }
            }

            internal DataColumn SL01048Column
            {
                get
                {
                    return this.columnSL01048;
                }
            }

            internal DataColumn SL01049Column
            {
                get
                {
                    return this.columnSL01049;
                }
            }

            internal DataColumn SL01050Column
            {
                get
                {
                    return this.columnSL01050;
                }
            }

            internal DataColumn SL01051Column
            {
                get
                {
                    return this.columnSL01051;
                }
            }

            internal DataColumn SL01052Column
            {
                get
                {
                    return this.columnSL01052;
                }
            }

            internal DataColumn SL01053Column
            {
                get
                {
                    return this.columnSL01053;
                }
            }

            internal DataColumn SL01054Column
            {
                get
                {
                    return this.columnSL01054;
                }
            }

            internal DataColumn SL01055Column
            {
                get
                {
                    return this.columnSL01055;
                }
            }

            internal DataColumn SL01056Column
            {
                get
                {
                    return this.columnSL01056;
                }
            }

            internal DataColumn SL01057Column
            {
                get
                {
                    return this.columnSL01057;
                }
            }

            internal DataColumn SL01058Column
            {
                get
                {
                    return this.columnSL01058;
                }
            }

            internal DataColumn SL01059Column
            {
                get
                {
                    return this.columnSL01059;
                }
            }

            internal DataColumn SL01060Column
            {
                get
                {
                    return this.columnSL01060;
                }
            }

            internal DataColumn SL01061Column
            {
                get
                {
                    return this.columnSL01061;
                }
            }

            internal DataColumn SL01062Column
            {
                get
                {
                    return this.columnSL01062;
                }
            }

            internal DataColumn SL01063Column
            {
                get
                {
                    return this.columnSL01063;
                }
            }

            internal DataColumn SL01064Column
            {
                get
                {
                    return this.columnSL01064;
                }
            }

            internal DataColumn SL01065Column
            {
                get
                {
                    return this.columnSL01065;
                }
            }

            internal DataColumn SL01066Column
            {
                get
                {
                    return this.columnSL01066;
                }
            }

            internal DataColumn SL01067Column
            {
                get
                {
                    return this.columnSL01067;
                }
            }

            internal DataColumn SL01068Column
            {
                get
                {
                    return this.columnSL01068;
                }
            }

            internal DataColumn SL01069Column
            {
                get
                {
                    return this.columnSL01069;
                }
            }

            internal DataColumn SL01070Column
            {
                get
                {
                    return this.columnSL01070;
                }
            }

            internal DataColumn SL01071Column
            {
                get
                {
                    return this.columnSL01071;
                }
            }

            internal DataColumn SL01072Column
            {
                get
                {
                    return this.columnSL01072;
                }
            }

            internal DataColumn SL01073Column
            {
                get
                {
                    return this.columnSL01073;
                }
            }

            internal DataColumn SL01074Column
            {
                get
                {
                    return this.columnSL01074;
                }
            }

            internal DataColumn SL01075Column
            {
                get
                {
                    return this.columnSL01075;
                }
            }

            internal DataColumn SL01076Column
            {
                get
                {
                    return this.columnSL01076;
                }
            }

            internal DataColumn SL01077Column
            {
                get
                {
                    return this.columnSL01077;
                }
            }

            internal DataColumn SL01078Column
            {
                get
                {
                    return this.columnSL01078;
                }
            }

            internal DataColumn SL01079Column
            {
                get
                {
                    return this.columnSL01079;
                }
            }

            internal DataColumn SL01080Column
            {
                get
                {
                    return this.columnSL01080;
                }
            }

            internal DataColumn SL01081Column
            {
                get
                {
                    return this.columnSL01081;
                }
            }

            internal DataColumn SL01082Column
            {
                get
                {
                    return this.columnSL01082;
                }
            }

            internal DataColumn SL01083Column
            {
                get
                {
                    return this.columnSL01083;
                }
            }

            internal DataColumn SL01084Column
            {
                get
                {
                    return this.columnSL01084;
                }
            }

            internal DataColumn SL01085Column
            {
                get
                {
                    return this.columnSL01085;
                }
            }

            internal DataColumn SL01086Column
            {
                get
                {
                    return this.columnSL01086;
                }
            }

            internal DataColumn SL01087Column
            {
                get
                {
                    return this.columnSL01087;
                }
            }

            internal DataColumn SL01088Column
            {
                get
                {
                    return this.columnSL01088;
                }
            }

            internal DataColumn SL01089Column
            {
                get
                {
                    return this.columnSL01089;
                }
            }

            internal DataColumn SL01090Column
            {
                get
                {
                    return this.columnSL01090;
                }
            }

            internal DataColumn SL01091Column
            {
                get
                {
                    return this.columnSL01091;
                }
            }

            internal DataColumn SL01092Column
            {
                get
                {
                    return this.columnSL01092;
                }
            }

            internal DataColumn SL01093Column
            {
                get
                {
                    return this.columnSL01093;
                }
            }

            internal DataColumn SL01094Column
            {
                get
                {
                    return this.columnSL01094;
                }
            }

            internal DataColumn SL01095Column
            {
                get
                {
                    return this.columnSL01095;
                }
            }

            internal DataColumn SL01096Column
            {
                get
                {
                    return this.columnSL01096;
                }
            }

            internal DataColumn SL01097Column
            {
                get
                {
                    return this.columnSL01097;
                }
            }

            internal DataColumn SL01098Column
            {
                get
                {
                    return this.columnSL01098;
                }
            }

            internal DataColumn SL01099Column
            {
                get
                {
                    return this.columnSL01099;
                }
            }

            internal DataColumn SL01100Column
            {
                get
                {
                    return this.columnSL01100;
                }
            }

            internal DataColumn SL01101Column
            {
                get
                {
                    return this.columnSL01101;
                }
            }

            internal DataColumn SL01102Column
            {
                get
                {
                    return this.columnSL01102;
                }
            }

            internal DataColumn SL01103Column
            {
                get
                {
                    return this.columnSL01103;
                }
            }

            internal DataColumn SL01104Column
            {
                get
                {
                    return this.columnSL01104;
                }
            }

            internal DataColumn SL01105Column
            {
                get
                {
                    return this.columnSL01105;
                }
            }

            internal DataColumn SL01106Column
            {
                get
                {
                    return this.columnSL01106;
                }
            }

            internal DataColumn SL01107Column
            {
                get
                {
                    return this.columnSL01107;
                }
            }

            internal DataColumn SL01108Column
            {
                get
                {
                    return this.columnSL01108;
                }
            }

            internal DataColumn SL01109Column
            {
                get
                {
                    return this.columnSL01109;
                }
            }

            internal DataColumn SL01110Column
            {
                get
                {
                    return this.columnSL01110;
                }
            }

            internal DataColumn SL01111Column
            {
                get
                {
                    return this.columnSL01111;
                }
            }

            internal DataColumn SL01112Column
            {
                get
                {
                    return this.columnSL01112;
                }
            }

            internal DataColumn SL01113Column
            {
                get
                {
                    return this.columnSL01113;
                }
            }

            internal DataColumn SL01114Column
            {
                get
                {
                    return this.columnSL01114;
                }
            }

            internal DataColumn SL01115Column
            {
                get
                {
                    return this.columnSL01115;
                }
            }

            internal DataColumn SL01116Column
            {
                get
                {
                    return this.columnSL01116;
                }
            }

            internal DataColumn SL01117Column
            {
                get
                {
                    return this.columnSL01117;
                }
            }

            internal DataColumn SL01118Column
            {
                get
                {
                    return this.columnSL01118;
                }
            }

            internal DataColumn SL01119Column
            {
                get
                {
                    return this.columnSL01119;
                }
            }

            internal DataColumn SL01120Column
            {
                get
                {
                    return this.columnSL01120;
                }
            }

            internal DataColumn SL01121Column
            {
                get
                {
                    return this.columnSL01121;
                }
            }

            internal DataColumn SL01122Column
            {
                get
                {
                    return this.columnSL01122;
                }
            }

            internal DataColumn SL01123Column
            {
                get
                {
                    return this.columnSL01123;
                }
            }

            internal DataColumn SL01124Column
            {
                get
                {
                    return this.columnSL01124;
                }
            }

            internal DataColumn SL01125Column
            {
                get
                {
                    return this.columnSL01125;
                }
            }

            internal DataColumn SL01126Column
            {
                get
                {
                    return this.columnSL01126;
                }
            }

            internal DataColumn SL01127Column
            {
                get
                {
                    return this.columnSL01127;
                }
            }

            internal DataColumn SL01128Column
            {
                get
                {
                    return this.columnSL01128;
                }
            }

            internal DataColumn SL01129Column
            {
                get
                {
                    return this.columnSL01129;
                }
            }
        }

        [DebuggerStepThrough]
        public class SL010100Row : DataRow
        {
            private DataOCPendConf.SL010100DataTable tableSL010100;

            internal SL010100Row(DataRowBuilder rb) : base(rb)
            {
                this.tableSL010100 = (DataOCPendConf.SL010100DataTable) this.Table;
            }

            public string SL01001
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01001Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01001Column] = value;
                }
            }

            public string SL01002
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01002Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01002Column] = value;
                }
            }

            public string SL01003
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01003Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01003Column] = value;
                }
            }

            public string SL01004
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01004Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01004Column] = value;
                }
            }

            public string SL01005
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01005Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01005Column] = value;
                }
            }

            public string SL01006
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01006Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01006Column] = value;
                }
            }

            public string SL01007
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01007Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01007Column] = value;
                }
            }

            public string SL01008
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01008Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01008Column] = value;
                }
            }

            public string SL01009
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01009Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01009Column] = value;
                }
            }

            public string SL01010
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01010Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01010Column] = value;
                }
            }

            public string SL01011
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01011Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01011Column] = value;
                }
            }

            public string SL01012
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01012Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01012Column] = value;
                }
            }

            public string SL01013
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01013Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01013Column] = value;
                }
            }

            public string SL01014
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01014Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01014Column] = value;
                }
            }

            public string SL01015
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01015Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01015Column] = value;
                }
            }

            public string SL01016
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01016Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01016Column] = value;
                }
            }

            public string SL01017
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01017Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01017Column] = value;
                }
            }

            public string SL01018
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01018Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01018Column] = value;
                }
            }

            public string SL01019
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01019Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01019Column] = value;
                }
            }

            public string SL01020
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01020Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01020Column] = value;
                }
            }

            public string SL01021
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01021Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01021Column] = value;
                }
            }

            public string SL01022
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01022Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01022Column] = value;
                }
            }

            public string SL01023
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01023Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01023Column] = value;
                }
            }

            public string SL01024
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01024Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01024Column] = value;
                }
            }

            public string SL01025
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01025Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01025Column] = value;
                }
            }

            public string SL01026
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01026Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01026Column] = value;
                }
            }

            public string SL01027
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01027Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01027Column] = value;
                }
            }

            public string SL01028
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01028Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01028Column] = value;
                }
            }

            public string SL01029
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01029Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01029Column] = value;
                }
            }

            public string SL01030
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01030Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01030Column] = value;
                }
            }

            public string SL01031
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01031Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01031Column] = value;
                }
            }

            public string SL01032
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01032Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01032Column] = value;
                }
            }

            public string SL01033
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01033Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01033Column] = value;
                }
            }

            public string SL01034
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01034Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01034Column] = value;
                }
            }

            public string SL01035
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01035Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01035Column] = value;
                }
            }

            public string SL01036
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01036Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01036Column] = value;
                }
            }

            public string SL01037
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01037Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01037Column] = value;
                }
            }

            public string SL01038
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01038Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01038Column] = value;
                }
            }

            public string SL01039
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01039Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01039Column] = value;
                }
            }

            public string SL01040
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01040Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01040Column] = value;
                }
            }

            public string SL01041
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01041Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01041Column] = value;
                }
            }

            public string SL01042
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01042Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01042Column] = value;
                }
            }

            public string SL01043
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01043Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01043Column] = value;
                }
            }

            public string SL01044
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01044Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01044Column] = value;
                }
            }

            public string SL01045
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01045Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01045Column] = value;
                }
            }

            public string SL01046
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01046Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01046Column] = value;
                }
            }

            public string SL01047
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01047Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01047Column] = value;
                }
            }

            public string SL01048
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01048Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01048Column] = value;
                }
            }

            public string SL01049
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01049Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01049Column] = value;
                }
            }

            public DateTime SL01050
            {
                get
                {
                    return DateType.FromObject(this[this.tableSL010100.SL01050Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01050Column] = value;
                }
            }

            public DateTime SL01051
            {
                get
                {
                    return DateType.FromObject(this[this.tableSL010100.SL01051Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01051Column] = value;
                }
            }

            public string SL01052
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01052Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01052Column] = value;
                }
            }

            public string SL01053
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01053Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01053Column] = value;
                }
            }

            public string SL01054
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01054Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01054Column] = value;
                }
            }

            public string SL01055
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01055Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01055Column] = value;
                }
            }

            public string SL01056
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01056Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01056Column] = value;
                }
            }

            public string SL01057
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01057Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01057Column] = value;
                }
            }

            public string SL01058
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01058Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01058Column] = value;
                }
            }

            public string SL01059
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01059Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01059Column] = value;
                }
            }

            public string SL01060
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01060Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01060Column] = value;
                }
            }

            public string SL01061
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01061Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01061Column] = value;
                }
            }

            public string SL01062
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01062Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01062Column] = value;
                }
            }

            public string SL01063
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01063Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01063Column] = value;
                }
            }

            public string SL01064
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01064Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01064Column] = value;
                }
            }

            public string SL01065
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01065Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01065Column] = value;
                }
            }

            public string SL01066
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01066Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01066Column] = value;
                }
            }

            public string SL01067
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01067Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01067Column] = value;
                }
            }

            public string SL01068
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01068Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01068Column] = value;
                }
            }

            public string SL01069
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01069Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01069Column] = value;
                }
            }

            public string SL01070
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01070Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01070Column] = value;
                }
            }

            public string SL01071
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01071Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01071Column] = value;
                }
            }

            public string SL01072
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01072Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01072Column] = value;
                }
            }

            public string SL01073
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01073Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01073Column] = value;
                }
            }

            public string SL01074
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01074Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01074Column] = value;
                }
            }

            public string SL01075
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01075Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01075Column] = value;
                }
            }

            public string SL01076
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01076Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01076Column] = value;
                }
            }

            public string SL01077
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01077Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01077Column] = value;
                }
            }

            public string SL01078
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01078Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01078Column] = value;
                }
            }

            public string SL01079
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01079Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01079Column] = value;
                }
            }

            public string SL01080
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01080Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01080Column] = value;
                }
            }

            public string SL01081
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01081Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01081Column] = value;
                }
            }

            public string SL01082
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01082Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01082Column] = value;
                }
            }

            public string SL01083
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01083Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01083Column] = value;
                }
            }

            public string SL01084
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01084Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01084Column] = value;
                }
            }

            public string SL01085
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01085Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01085Column] = value;
                }
            }

            public string SL01086
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01086Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01086Column] = value;
                }
            }

            public string SL01087
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01087Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01087Column] = value;
                }
            }

            public string SL01088
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01088Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01088Column] = value;
                }
            }

            public string SL01089
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01089Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01089Column] = value;
                }
            }

            public string SL01090
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01090Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01090Column] = value;
                }
            }

            public string SL01091
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01091Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01091Column] = value;
                }
            }

            public string SL01092
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01092Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01092Column] = value;
                }
            }

            public string SL01093
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01093Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01093Column] = value;
                }
            }

            public string SL01094
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01094Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01094Column] = value;
                }
            }

            public string SL01095
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01095Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01095Column] = value;
                }
            }

            public string SL01096
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01096Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01096Column] = value;
                }
            }

            public string SL01097
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01097Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01097Column] = value;
                }
            }

            public string SL01098
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01098Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01098Column] = value;
                }
            }

            public string SL01099
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01099Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01099Column] = value;
                }
            }

            public string SL01100
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01100Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01100Column] = value;
                }
            }

            public string SL01101
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01101Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01101Column] = value;
                }
            }

            public string SL01102
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01102Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01102Column] = value;
                }
            }

            public string SL01103
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01103Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01103Column] = value;
                }
            }

            public string SL01104
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01104Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01104Column] = value;
                }
            }

            public string SL01105
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01105Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01105Column] = value;
                }
            }

            public string SL01106
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01106Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01106Column] = value;
                }
            }

            public string SL01107
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01107Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01107Column] = value;
                }
            }

            public string SL01108
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01108Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01108Column] = value;
                }
            }

            public string SL01109
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01109Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01109Column] = value;
                }
            }

            public string SL01110
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01110Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01110Column] = value;
                }
            }

            public string SL01111
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01111Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01111Column] = value;
                }
            }

            public string SL01112
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01112Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01112Column] = value;
                }
            }

            public string SL01113
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01113Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01113Column] = value;
                }
            }

            public string SL01114
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01114Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01114Column] = value;
                }
            }

            public string SL01115
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01115Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01115Column] = value;
                }
            }

            public string SL01116
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01116Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01116Column] = value;
                }
            }

            public string SL01117
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01117Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01117Column] = value;
                }
            }

            public string SL01118
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01118Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01118Column] = value;
                }
            }

            public string SL01119
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01119Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01119Column] = value;
                }
            }

            public string SL01120
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01120Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01120Column] = value;
                }
            }

            public string SL01121
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01121Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01121Column] = value;
                }
            }

            public string SL01122
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01122Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01122Column] = value;
                }
            }

            public string SL01123
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01123Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01123Column] = value;
                }
            }

            public string SL01124
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01124Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01124Column] = value;
                }
            }

            public string SL01125
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01125Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01125Column] = value;
                }
            }

            public string SL01126
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01126Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01126Column] = value;
                }
            }

            public string SL01127
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01127Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01127Column] = value;
                }
            }

            public string SL01128
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01128Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01128Column] = value;
                }
            }

            public string SL01129
            {
                get
                {
                    return StringType.FromObject(this[this.tableSL010100.SL01129Column]);
                }
                set
                {
                    this[this.tableSL010100.SL01129Column] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class SL010100RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataOCPendConf.SL010100Row eventRow;

            public SL010100RowChangeEvent(DataOCPendConf.SL010100Row row, DataRowAction action)
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

            public DataOCPendConf.SL010100Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SL010100RowChangeEventHandler(object sender, DataOCPendConf.SL010100RowChangeEvent e);
    }
}

