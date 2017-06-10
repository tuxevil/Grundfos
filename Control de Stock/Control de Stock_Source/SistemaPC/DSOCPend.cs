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
    public class DSOCPend : DataSet
    {
        private PC030100DataTable tablePC030100;
        private PC1TmpDetDesDataTable tablePC1TmpDetDes;

        public DSOCPend()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DSOCPend(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["PC030100"] != null)
                {
                    this.Tables.Add(new PC030100DataTable(dataSet.Tables["PC030100"]));
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
            DSOCPend pend = (DSOCPend) base.Clone();
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
            this.DataSetName = "DSOCPend";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DSOCPend.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tablePC030100 = new PC030100DataTable();
            this.Tables.Add(this.tablePC030100);
            this.tablePC1TmpDetDes = new PC1TmpDetDesDataTable();
            this.Tables.Add(this.tablePC1TmpDetDes);
        }

        internal void InitVars()
        {
            this.tablePC030100 = (PC030100DataTable) this.Tables["PC030100"];
            if (this.tablePC030100 != null)
            {
                this.tablePC030100.InitVars();
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
            if (dataSet.Tables["PC030100"] != null)
            {
                this.Tables.Add(new PC030100DataTable(dataSet.Tables["PC030100"]));
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

        private bool ShouldSerializePC030100()
        {
            return false;
        }

        private bool ShouldSerializePC1TmpDetDes()
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

            public event DSOCPend.PC030100RowChangeEventHandler PC030100RowChanged;

            public event DSOCPend.PC030100RowChangeEventHandler PC030100RowChanging;

            public event DSOCPend.PC030100RowChangeEventHandler PC030100RowDeleted;

            public event DSOCPend.PC030100RowChangeEventHandler PC030100RowDeleting;

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

            public void AddPC030100Row(DSOCPend.PC030100Row row)
            {
                this.Rows.Add(row);
            }

            public DSOCPend.PC030100Row AddPC030100Row(string PC03001, string PC03002, string PC03003, int PC03004, string PC03005, string PC03006, string PC03007, decimal PC03008, int PC03009, decimal PC03010, decimal PC03011, decimal PC03012, string PC03013, string PC03014, decimal PC03015, DateTime PC03016, DateTime PC03017, decimal PC03018, decimal PC03019, string PC03020, int PC03021, string PC03022, int PC03023, DateTime PC03024, decimal PC03025, string PC03026, string PC03027, string PC03028, string PC03029, DateTime PC03030, DateTime PC03031, decimal PC03032, decimal PC03033, decimal PC03034, string PC03035, string PC03036, string PC03037, decimal PC03038, string PC03039, string PC03040, string PC03041, decimal PC03042, decimal PC03043, decimal PC03044, string PC03045, decimal PC03046, decimal PC03047, string PC03048, decimal PC03049, string PC03050, string PC03051, string PC03052, string PC03053, decimal PC03054, string PC03055, int PC03056, string PC03057, decimal PC03058, decimal PC03059, string PC03060, int PC03061, decimal PC03062)
            {
                DSOCPend.PC030100Row row = (DSOCPend.PC030100Row) this.NewRow();
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
                DSOCPend.PC030100DataTable table = (DSOCPend.PC030100DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DSOCPend.PC030100DataTable();
            }

            public DSOCPend.PC030100Row FindByPC03001PC03002PC03003(string PC03001, string PC03002, string PC03003)
            {
                return (DSOCPend.PC030100Row) this.Rows.Find(new object[] { PC03001, PC03002, PC03003 });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DSOCPend.PC030100Row);
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
                this.Constraints.Add(new UniqueConstraint("DSOCPendKey1", new DataColumn[] { this.columnPC03001, this.columnPC03002, this.columnPC03003 }, true));
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

            public DSOCPend.PC030100Row NewPC030100Row()
            {
                return (DSOCPend.PC030100Row) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DSOCPend.PC030100Row(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC030100RowChangedEvent != null) && (this.PC030100RowChangedEvent != null))
                {
                    this.PC030100RowChangedEvent(this, new DSOCPend.PC030100RowChangeEvent((DSOCPend.PC030100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC030100RowChangingEvent != null) && (this.PC030100RowChangingEvent != null))
                {
                    this.PC030100RowChangingEvent(this, new DSOCPend.PC030100RowChangeEvent((DSOCPend.PC030100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC030100RowDeletedEvent != null) && (this.PC030100RowDeletedEvent != null))
                {
                    this.PC030100RowDeletedEvent(this, new DSOCPend.PC030100RowChangeEvent((DSOCPend.PC030100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC030100RowDeletingEvent != null) && (this.PC030100RowDeletingEvent != null))
                {
                    this.PC030100RowDeletingEvent(this, new DSOCPend.PC030100RowChangeEvent((DSOCPend.PC030100Row) e.Row, e.Action));
                }
            }

            public void RemovePC030100Row(DSOCPend.PC030100Row row)
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

            public DSOCPend.PC030100Row this[int index]
            {
                get
                {
                    return (DSOCPend.PC030100Row) this.Rows[index];
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
            private DSOCPend.PC030100DataTable tablePC030100;

            internal PC030100Row(DataRowBuilder rb) : base(rb)
            {
                this.tablePC030100 = (DSOCPend.PC030100DataTable) this.Table;
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
            private DSOCPend.PC030100Row eventRow;

            public PC030100RowChangeEvent(DSOCPend.PC030100Row row, DataRowAction action)
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

            public DSOCPend.PC030100Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC030100RowChangeEventHandler(object sender, DSOCPend.PC030100RowChangeEvent e);

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

            public event DSOCPend.PC1TmpDetDesRowChangeEventHandler PC1TmpDetDesRowChanged;

            public event DSOCPend.PC1TmpDetDesRowChangeEventHandler PC1TmpDetDesRowChanging;

            public event DSOCPend.PC1TmpDetDesRowChangeEventHandler PC1TmpDetDesRowDeleted;

            public event DSOCPend.PC1TmpDetDesRowChangeEventHandler PC1TmpDetDesRowDeleting;

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

            public void AddPC1TmpDetDesRow(DSOCPend.PC1TmpDetDesRow row)
            {
                this.Rows.Add(row);
            }

            public DSOCPend.PC1TmpDetDesRow AddPC1TmpDetDesRow(string NroOC, string NroLinea, string NroBulto, string PackList, DateTime FechaPL, string NroFC, DateTime FechaFC, decimal EnTransito)
            {
                DSOCPend.PC1TmpDetDesRow row = (DSOCPend.PC1TmpDetDesRow) this.NewRow();
                row.ItemArray = new object[] { NroOC, NroLinea, NroBulto, PackList, FechaPL, NroFC, FechaFC, EnTransito };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DSOCPend.PC1TmpDetDesDataTable table = (DSOCPend.PC1TmpDetDesDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DSOCPend.PC1TmpDetDesDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DSOCPend.PC1TmpDetDesRow);
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

            public DSOCPend.PC1TmpDetDesRow NewPC1TmpDetDesRow()
            {
                return (DSOCPend.PC1TmpDetDesRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DSOCPend.PC1TmpDetDesRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpDetDesRowChangedEvent != null) && (this.PC1TmpDetDesRowChangedEvent != null))
                {
                    this.PC1TmpDetDesRowChangedEvent(this, new DSOCPend.PC1TmpDetDesRowChangeEvent((DSOCPend.PC1TmpDetDesRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpDetDesRowChangingEvent != null) && (this.PC1TmpDetDesRowChangingEvent != null))
                {
                    this.PC1TmpDetDesRowChangingEvent(this, new DSOCPend.PC1TmpDetDesRowChangeEvent((DSOCPend.PC1TmpDetDesRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpDetDesRowDeletedEvent != null) && (this.PC1TmpDetDesRowDeletedEvent != null))
                {
                    this.PC1TmpDetDesRowDeletedEvent(this, new DSOCPend.PC1TmpDetDesRowChangeEvent((DSOCPend.PC1TmpDetDesRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpDetDesRowDeletingEvent != null) && (this.PC1TmpDetDesRowDeletingEvent != null))
                {
                    this.PC1TmpDetDesRowDeletingEvent(this, new DSOCPend.PC1TmpDetDesRowChangeEvent((DSOCPend.PC1TmpDetDesRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpDetDesRow(DSOCPend.PC1TmpDetDesRow row)
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

            public DSOCPend.PC1TmpDetDesRow this[int index]
            {
                get
                {
                    return (DSOCPend.PC1TmpDetDesRow) this.Rows[index];
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
            private DSOCPend.PC1TmpDetDesDataTable tablePC1TmpDetDes;

            internal PC1TmpDetDesRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpDetDes = (DSOCPend.PC1TmpDetDesDataTable) this.Table;
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
            private DSOCPend.PC1TmpDetDesRow eventRow;

            public PC1TmpDetDesRowChangeEvent(DSOCPend.PC1TmpDetDesRow row, DataRowAction action)
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

            public DSOCPend.PC1TmpDetDesRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpDetDesRowChangeEventHandler(object sender, DSOCPend.PC1TmpDetDesRowChangeEvent e);
    }
}

