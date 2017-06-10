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
    public class DSOAPend : DataSet
    {
        private OR010100DataTable tableOR010100;
        private OR030100DataTable tableOR030100;
        private OR040100DataTable tableOR040100;

        public DSOAPend()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DSOAPend(SerializationInfo info, StreamingContext context)
        {
            string s = StringType.FromObject(info.GetValue("XmlSchema", typeof(string)));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["OR010100"] != null)
                {
                    this.Tables.Add(new OR010100DataTable(dataSet.Tables["OR010100"]));
                }
                if (dataSet.Tables["OR030100"] != null)
                {
                    this.Tables.Add(new OR030100DataTable(dataSet.Tables["OR030100"]));
                }
                if (dataSet.Tables["OR040100"] != null)
                {
                    this.Tables.Add(new OR040100DataTable(dataSet.Tables["OR040100"]));
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
            DSOAPend pend = (DSOAPend) base.Clone();
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
            this.DataSetName = "DSOAPend";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DSOAPend.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableOR010100 = new OR010100DataTable();
            this.Tables.Add(this.tableOR010100);
            this.tableOR030100 = new OR030100DataTable();
            this.Tables.Add(this.tableOR030100);
            this.tableOR040100 = new OR040100DataTable();
            this.Tables.Add(this.tableOR040100);
        }

        internal void InitVars()
        {
            this.tableOR010100 = (OR010100DataTable) this.Tables["OR010100"];
            if (this.tableOR010100 != null)
            {
                this.tableOR010100.InitVars();
            }
            this.tableOR030100 = (OR030100DataTable) this.Tables["OR030100"];
            if (this.tableOR030100 != null)
            {
                this.tableOR030100.InitVars();
            }
            this.tableOR040100 = (OR040100DataTable) this.Tables["OR040100"];
            if (this.tableOR040100 != null)
            {
                this.tableOR040100.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["OR010100"] != null)
            {
                this.Tables.Add(new OR010100DataTable(dataSet.Tables["OR010100"]));
            }
            if (dataSet.Tables["OR030100"] != null)
            {
                this.Tables.Add(new OR030100DataTable(dataSet.Tables["OR030100"]));
            }
            if (dataSet.Tables["OR040100"] != null)
            {
                this.Tables.Add(new OR040100DataTable(dataSet.Tables["OR040100"]));
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

        private bool ShouldSerializeOR010100()
        {
            return false;
        }

        private bool ShouldSerializeOR030100()
        {
            return false;
        }

        private bool ShouldSerializeOR040100()
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
        public OR010100DataTable OR010100
        {
            get
            {
                return this.tableOR010100;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OR030100DataTable OR030100
        {
            get
            {
                return this.tableOR030100;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public OR040100DataTable OR040100
        {
            get
            {
                return this.tableOR040100;
            }
        }

        [DebuggerStepThrough]
        public class OR010100DataTable : DataTable, IEnumerable
        {
            private DataColumn columnOR01001;
            private DataColumn columnOR01002;
            private DataColumn columnOR01003;
            private DataColumn columnOR01004;
            private DataColumn columnOR01005;
            private DataColumn columnOR01006;
            private DataColumn columnOR01007;
            private DataColumn columnOR01008;
            private DataColumn columnOR01009;
            private DataColumn columnOR01010;
            private DataColumn columnOR01011;
            private DataColumn columnOR01012;
            private DataColumn columnOR01013;
            private DataColumn columnOR01014;
            private DataColumn columnOR01015;
            private DataColumn columnOR01016;
            private DataColumn columnOR01017;
            private DataColumn columnOR01018;
            private DataColumn columnOR01019;
            private DataColumn columnOR01020;
            private DataColumn columnOR01021;
            private DataColumn columnOR01022;
            private DataColumn columnOR01023;
            private DataColumn columnOR01024;
            private DataColumn columnOR01025;
            private DataColumn columnOR01026;
            private DataColumn columnOR01027;
            private DataColumn columnOR01028;
            private DataColumn columnOR01029;
            private DataColumn columnOR01030;
            private DataColumn columnOR01031;
            private DataColumn columnOR01032;
            private DataColumn columnOR01033;
            private DataColumn columnOR01034;
            private DataColumn columnOR01035;
            private DataColumn columnOR01036;
            private DataColumn columnOR01037;
            private DataColumn columnOR01038;
            private DataColumn columnOR01039;
            private DataColumn columnOR01040;
            private DataColumn columnOR01041;
            private DataColumn columnOR01042;
            private DataColumn columnOR01043;
            private DataColumn columnOR01044;
            private DataColumn columnOR01045;
            private DataColumn columnOR01046;
            private DataColumn columnOR01047;
            private DataColumn columnOR01048;
            private DataColumn columnOR01049;
            private DataColumn columnOR01050;
            private DataColumn columnOR01051;
            private DataColumn columnOR01052;
            private DataColumn columnOR01053;
            private DataColumn columnOR01054;
            private DataColumn columnOR01055;
            private DataColumn columnOR01056;
            private DataColumn columnOR01057;
            private DataColumn columnOR01058;
            private DataColumn columnOR01059;
            private DataColumn columnOR01060;
            private DataColumn columnOR01061;
            private DataColumn columnOR01062;
            private DataColumn columnOR01063;
            private DataColumn columnOR01064;
            private DataColumn columnOR01065;
            private DataColumn columnOR01066;
            private DataColumn columnOR01067;
            private DataColumn columnOR01068;
            private DataColumn columnOR01069;
            private DataColumn columnOR01070;
            private DataColumn columnOR01071;
            private DataColumn columnOR01072;
            private DataColumn columnOR01073;
            private DataColumn columnOR01074;
            private DataColumn columnOR01075;
            private DataColumn columnOR01076;
            private DataColumn columnOR01077;
            private DataColumn columnOR01078;
            private DataColumn columnOR01079;
            private DataColumn columnOR01080;
            private DataColumn columnOR01081;
            private DataColumn columnOR01082;
            private DataColumn columnOR01083;
            private DataColumn columnOR01084;
            private DataColumn columnOR01085;
            private DataColumn columnOR01086;
            private DataColumn columnOR01087;
            private DataColumn columnOR01088;
            private DataColumn columnOR01089;
            private DataColumn columnOR01090;
            private DataColumn columnOR01091;
            private DataColumn columnOR01092;
            private DataColumn columnOR01093;
            private DataColumn columnOR01094;
            private DataColumn columnOR01095;
            private DataColumn columnOR01096;
            private DataColumn columnOR01097;
            private DataColumn columnOR01098;
            private DataColumn columnOR01099;
            private DataColumn columnOR01100;
            private DataColumn columnOR01101;
            private DataColumn columnOR01102;
            private DataColumn columnOR01103;
            private DataColumn columnOR01104;
            private DataColumn columnOR01105;
            private DataColumn columnOR01106;
            private DataColumn columnOR01107;
            private DataColumn columnOR01108;
            private DataColumn columnOR01109;
            private DataColumn columnOR01110;
            private DataColumn columnOR01111;
            private DataColumn columnOR01112;
            private DataColumn columnOR01113;
            private DataColumn columnOR01114;
            private DataColumn columnOR01115;
            private DataColumn columnOR01116;
            private DataColumn columnOR01117;
            private DataColumn columnOR01118;
            private DataColumn columnOR01119;
            private DataColumn columnOR01120;
            private DataColumn columnOR01121;
            private DataColumn columnOR01122;
            private DataColumn columnOR01123;
            private DataColumn columnOR01124;
            private DataColumn columnOR01125;
            private DataColumn columnOR01126;
            private DataColumn columnOR01127;
            private DataColumn columnOR01128;
            private DataColumn columnOR01129;
            private DataColumn columnOR01130;
            private DataColumn columnOR01131;
            private DataColumn columnOR01132;
            private DataColumn columnOR01133;
            private DataColumn columnOR01134;
            private DataColumn columnOR01135;
            private DataColumn columnOR01136;
            private DataColumn columnOR01137;
            private DataColumn columnOR01138;
            private DataColumn columnOR01139;
            private DataColumn columnOR01140;
            private DataColumn columnOR01141;
            private DataColumn columnOR01142;
            private DataColumn columnOR01143;
            private DataColumn columnOR01144;
            private DataColumn columnOR01145;
            private DataColumn columnOR01146;

            public event DSOAPend.OR010100RowChangeEventHandler OR010100RowChanged;

            public event DSOAPend.OR010100RowChangeEventHandler OR010100RowChanging;

            public event DSOAPend.OR010100RowChangeEventHandler OR010100RowDeleted;

            public event DSOAPend.OR010100RowChangeEventHandler OR010100RowDeleting;

            internal OR010100DataTable() : base("OR010100")
            {
                this.InitClass();
            }

            internal OR010100DataTable(DataTable table) : base(table.TableName)
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

            public void AddOR010100Row(DSOAPend.OR010100Row row)
            {
                this.Rows.Add(row);
            }

            public DSOAPend.OR010100Row AddOR010100Row(string OR01001, int OR01002, string OR01003, string OR01004, string OR01005, string OR01006, int OR01007, int OR01008, int OR01009, int OR01010, int OR01011, int OR01012, int OR01013, int OR01014, DateTime OR01015, DateTime OR01016, string OR01017, string OR01018, string OR01019, string OR01020, string OR01021, DateTime OR01022, string OR01023, decimal OR01024, string OR01025, int OR01026, int OR01027, int OR01028, int OR01029, int OR01030, int OR01031, int OR01032, int OR01033, decimal OR01034, decimal OR01035, decimal OR01036, decimal OR01037, string OR01038, DateTime OR01039, DateTime OR01040, decimal OR01041, decimal OR01042, decimal OR01043, decimal OR01044, string OR01045, decimal OR01046, string OR01047, decimal OR01048, string OR01049, string OR01050, string OR01051, string OR01052, string OR01053, string OR01054, string OR01055, string OR01056, decimal OR01057, decimal OR01058, decimal OR01059, decimal OR01060, decimal OR01061, string OR01062, decimal OR01063, decimal OR01064, int OR01065, string OR01066, decimal OR01067, string OR01068, string OR01069, string OR01070, int OR01071, string OR01072, string OR01073, DateTime OR01074, DateTime OR01075, string OR01076, DateTime OR01077, string OR01078, string OR01079, int OR01080, int OR01081, string OR01082, string OR01083, string OR01084, string OR01085, string OR01086, string OR01087, string OR01088, string OR01089, string OR01090, int OR01091, int OR01092, int OR01093, int OR01094, string OR01095, string OR01096, DateTime OR01097, string OR01098, string OR01099, int OR01100, string OR01101, int OR01102, string OR01103, string OR01104, string OR01105, string OR01106, string OR01107, string OR01108, string OR01109, decimal OR01110, string OR01111, decimal OR01112, string OR01113, decimal OR01114, string OR01115, int OR01116, string OR01117, string OR01118, string OR01119, string OR01120, string OR01121, string OR01122, string OR01123, string OR01124, string OR01125, string OR01126, decimal OR01127, string OR01128, string OR01129, string OR01130, DateTime OR01131, string OR01132, string OR01133, string OR01134, string OR01135, string OR01136, string OR01137, decimal OR01138, string OR01139, decimal OR01140, string OR01141, string OR01142, string OR01143, string OR01144, string OR01145, string OR01146)
            {
                DSOAPend.OR010100Row row = (DSOAPend.OR010100Row) this.NewRow();
                row.ItemArray = new object[] { 
                    OR01001, OR01002, OR01003, OR01004, OR01005, OR01006, OR01007, OR01008, OR01009, OR01010, OR01011, OR01012, OR01013, OR01014, OR01015, OR01016, 
                    OR01017, OR01018, OR01019, OR01020, OR01021, OR01022, OR01023, OR01024, OR01025, OR01026, OR01027, OR01028, OR01029, OR01030, OR01031, OR01032, 
                    OR01033, OR01034, OR01035, OR01036, OR01037, OR01038, OR01039, OR01040, OR01041, OR01042, OR01043, OR01044, OR01045, OR01046, OR01047, OR01048, 
                    OR01049, OR01050, OR01051, OR01052, OR01053, OR01054, OR01055, OR01056, OR01057, OR01058, OR01059, OR01060, OR01061, OR01062, OR01063, OR01064, 
                    OR01065, OR01066, OR01067, OR01068, OR01069, OR01070, OR01071, OR01072, OR01073, OR01074, OR01075, OR01076, OR01077, OR01078, OR01079, OR01080, 
                    OR01081, OR01082, OR01083, OR01084, OR01085, OR01086, OR01087, OR01088, OR01089, OR01090, OR01091, OR01092, OR01093, OR01094, OR01095, OR01096, 
                    OR01097, OR01098, OR01099, OR01100, OR01101, OR01102, OR01103, OR01104, OR01105, OR01106, OR01107, OR01108, OR01109, OR01110, OR01111, OR01112, 
                    OR01113, OR01114, OR01115, OR01116, OR01117, OR01118, OR01119, OR01120, OR01121, OR01122, OR01123, OR01124, OR01125, OR01126, OR01127, OR01128, 
                    OR01129, OR01130, OR01131, OR01132, OR01133, OR01134, OR01135, OR01136, OR01137, OR01138, OR01139, OR01140, OR01141, OR01142, OR01143, OR01144, 
                    OR01145, OR01146
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DSOAPend.OR010100DataTable table = (DSOAPend.OR010100DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DSOAPend.OR010100DataTable();
            }

            public DSOAPend.OR010100Row FindByOR01001(string OR01001)
            {
                return (DSOAPend.OR010100Row) this.Rows.Find(new object[] { OR01001 });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DSOAPend.OR010100Row);
            }

            private void InitClass()
            {
                this.columnOR01001 = new DataColumn("OR01001", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01001);
                this.columnOR01002 = new DataColumn("OR01002", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01002);
                this.columnOR01003 = new DataColumn("OR01003", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01003);
                this.columnOR01004 = new DataColumn("OR01004", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01004);
                this.columnOR01005 = new DataColumn("OR01005", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01005);
                this.columnOR01006 = new DataColumn("OR01006", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01006);
                this.columnOR01007 = new DataColumn("OR01007", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01007);
                this.columnOR01008 = new DataColumn("OR01008", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01008);
                this.columnOR01009 = new DataColumn("OR01009", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01009);
                this.columnOR01010 = new DataColumn("OR01010", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01010);
                this.columnOR01011 = new DataColumn("OR01011", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01011);
                this.columnOR01012 = new DataColumn("OR01012", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01012);
                this.columnOR01013 = new DataColumn("OR01013", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01013);
                this.columnOR01014 = new DataColumn("OR01014", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01014);
                this.columnOR01015 = new DataColumn("OR01015", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnOR01015);
                this.columnOR01016 = new DataColumn("OR01016", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnOR01016);
                this.columnOR01017 = new DataColumn("OR01017", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01017);
                this.columnOR01018 = new DataColumn("OR01018", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01018);
                this.columnOR01019 = new DataColumn("OR01019", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01019);
                this.columnOR01020 = new DataColumn("OR01020", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01020);
                this.columnOR01021 = new DataColumn("OR01021", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01021);
                this.columnOR01022 = new DataColumn("OR01022", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnOR01022);
                this.columnOR01023 = new DataColumn("OR01023", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01023);
                this.columnOR01024 = new DataColumn("OR01024", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01024);
                this.columnOR01025 = new DataColumn("OR01025", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01025);
                this.columnOR01026 = new DataColumn("OR01026", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01026);
                this.columnOR01027 = new DataColumn("OR01027", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01027);
                this.columnOR01028 = new DataColumn("OR01028", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01028);
                this.columnOR01029 = new DataColumn("OR01029", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01029);
                this.columnOR01030 = new DataColumn("OR01030", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01030);
                this.columnOR01031 = new DataColumn("OR01031", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01031);
                this.columnOR01032 = new DataColumn("OR01032", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01032);
                this.columnOR01033 = new DataColumn("OR01033", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01033);
                this.columnOR01034 = new DataColumn("OR01034", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01034);
                this.columnOR01035 = new DataColumn("OR01035", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01035);
                this.columnOR01036 = new DataColumn("OR01036", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01036);
                this.columnOR01037 = new DataColumn("OR01037", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01037);
                this.columnOR01038 = new DataColumn("OR01038", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01038);
                this.columnOR01039 = new DataColumn("OR01039", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnOR01039);
                this.columnOR01040 = new DataColumn("OR01040", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnOR01040);
                this.columnOR01041 = new DataColumn("OR01041", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01041);
                this.columnOR01042 = new DataColumn("OR01042", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01042);
                this.columnOR01043 = new DataColumn("OR01043", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01043);
                this.columnOR01044 = new DataColumn("OR01044", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01044);
                this.columnOR01045 = new DataColumn("OR01045", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01045);
                this.columnOR01046 = new DataColumn("OR01046", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01046);
                this.columnOR01047 = new DataColumn("OR01047", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01047);
                this.columnOR01048 = new DataColumn("OR01048", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01048);
                this.columnOR01049 = new DataColumn("OR01049", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01049);
                this.columnOR01050 = new DataColumn("OR01050", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01050);
                this.columnOR01051 = new DataColumn("OR01051", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01051);
                this.columnOR01052 = new DataColumn("OR01052", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01052);
                this.columnOR01053 = new DataColumn("OR01053", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01053);
                this.columnOR01054 = new DataColumn("OR01054", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01054);
                this.columnOR01055 = new DataColumn("OR01055", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01055);
                this.columnOR01056 = new DataColumn("OR01056", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01056);
                this.columnOR01057 = new DataColumn("OR01057", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01057);
                this.columnOR01058 = new DataColumn("OR01058", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01058);
                this.columnOR01059 = new DataColumn("OR01059", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01059);
                this.columnOR01060 = new DataColumn("OR01060", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01060);
                this.columnOR01061 = new DataColumn("OR01061", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01061);
                this.columnOR01062 = new DataColumn("OR01062", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01062);
                this.columnOR01063 = new DataColumn("OR01063", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01063);
                this.columnOR01064 = new DataColumn("OR01064", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01064);
                this.columnOR01065 = new DataColumn("OR01065", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01065);
                this.columnOR01066 = new DataColumn("OR01066", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01066);
                this.columnOR01067 = new DataColumn("OR01067", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01067);
                this.columnOR01068 = new DataColumn("OR01068", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01068);
                this.columnOR01069 = new DataColumn("OR01069", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01069);
                this.columnOR01070 = new DataColumn("OR01070", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01070);
                this.columnOR01071 = new DataColumn("OR01071", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01071);
                this.columnOR01072 = new DataColumn("OR01072", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01072);
                this.columnOR01073 = new DataColumn("OR01073", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01073);
                this.columnOR01074 = new DataColumn("OR01074", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnOR01074);
                this.columnOR01075 = new DataColumn("OR01075", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnOR01075);
                this.columnOR01076 = new DataColumn("OR01076", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01076);
                this.columnOR01077 = new DataColumn("OR01077", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnOR01077);
                this.columnOR01078 = new DataColumn("OR01078", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01078);
                this.columnOR01079 = new DataColumn("OR01079", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01079);
                this.columnOR01080 = new DataColumn("OR01080", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01080);
                this.columnOR01081 = new DataColumn("OR01081", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01081);
                this.columnOR01082 = new DataColumn("OR01082", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01082);
                this.columnOR01083 = new DataColumn("OR01083", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01083);
                this.columnOR01084 = new DataColumn("OR01084", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01084);
                this.columnOR01085 = new DataColumn("OR01085", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01085);
                this.columnOR01086 = new DataColumn("OR01086", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01086);
                this.columnOR01087 = new DataColumn("OR01087", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01087);
                this.columnOR01088 = new DataColumn("OR01088", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01088);
                this.columnOR01089 = new DataColumn("OR01089", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01089);
                this.columnOR01090 = new DataColumn("OR01090", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01090);
                this.columnOR01091 = new DataColumn("OR01091", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01091);
                this.columnOR01092 = new DataColumn("OR01092", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01092);
                this.columnOR01093 = new DataColumn("OR01093", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01093);
                this.columnOR01094 = new DataColumn("OR01094", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01094);
                this.columnOR01095 = new DataColumn("OR01095", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01095);
                this.columnOR01096 = new DataColumn("OR01096", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01096);
                this.columnOR01097 = new DataColumn("OR01097", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnOR01097);
                this.columnOR01098 = new DataColumn("OR01098", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01098);
                this.columnOR01099 = new DataColumn("OR01099", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01099);
                this.columnOR01100 = new DataColumn("OR01100", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01100);
                this.columnOR01101 = new DataColumn("OR01101", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01101);
                this.columnOR01102 = new DataColumn("OR01102", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01102);
                this.columnOR01103 = new DataColumn("OR01103", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01103);
                this.columnOR01104 = new DataColumn("OR01104", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01104);
                this.columnOR01105 = new DataColumn("OR01105", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01105);
                this.columnOR01106 = new DataColumn("OR01106", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01106);
                this.columnOR01107 = new DataColumn("OR01107", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01107);
                this.columnOR01108 = new DataColumn("OR01108", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01108);
                this.columnOR01109 = new DataColumn("OR01109", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01109);
                this.columnOR01110 = new DataColumn("OR01110", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01110);
                this.columnOR01111 = new DataColumn("OR01111", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01111);
                this.columnOR01112 = new DataColumn("OR01112", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01112);
                this.columnOR01113 = new DataColumn("OR01113", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01113);
                this.columnOR01114 = new DataColumn("OR01114", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01114);
                this.columnOR01115 = new DataColumn("OR01115", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01115);
                this.columnOR01116 = new DataColumn("OR01116", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR01116);
                this.columnOR01117 = new DataColumn("OR01117", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01117);
                this.columnOR01118 = new DataColumn("OR01118", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01118);
                this.columnOR01119 = new DataColumn("OR01119", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01119);
                this.columnOR01120 = new DataColumn("OR01120", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01120);
                this.columnOR01121 = new DataColumn("OR01121", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01121);
                this.columnOR01122 = new DataColumn("OR01122", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01122);
                this.columnOR01123 = new DataColumn("OR01123", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01123);
                this.columnOR01124 = new DataColumn("OR01124", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01124);
                this.columnOR01125 = new DataColumn("OR01125", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01125);
                this.columnOR01126 = new DataColumn("OR01126", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01126);
                this.columnOR01127 = new DataColumn("OR01127", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01127);
                this.columnOR01128 = new DataColumn("OR01128", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01128);
                this.columnOR01129 = new DataColumn("OR01129", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01129);
                this.columnOR01130 = new DataColumn("OR01130", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01130);
                this.columnOR01131 = new DataColumn("OR01131", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnOR01131);
                this.columnOR01132 = new DataColumn("OR01132", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01132);
                this.columnOR01133 = new DataColumn("OR01133", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01133);
                this.columnOR01134 = new DataColumn("OR01134", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01134);
                this.columnOR01135 = new DataColumn("OR01135", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01135);
                this.columnOR01136 = new DataColumn("OR01136", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01136);
                this.columnOR01137 = new DataColumn("OR01137", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01137);
                this.columnOR01138 = new DataColumn("OR01138", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01138);
                this.columnOR01139 = new DataColumn("OR01139", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01139);
                this.columnOR01140 = new DataColumn("OR01140", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR01140);
                this.columnOR01141 = new DataColumn("OR01141", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01141);
                this.columnOR01142 = new DataColumn("OR01142", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01142);
                this.columnOR01143 = new DataColumn("OR01143", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01143);
                this.columnOR01144 = new DataColumn("OR01144", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01144);
                this.columnOR01145 = new DataColumn("OR01145", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01145);
                this.columnOR01146 = new DataColumn("OR01146", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR01146);
                this.Constraints.Add(new UniqueConstraint("DSOAPendKey2", new DataColumn[] { this.columnOR01001 }, true));
                this.columnOR01001.AllowDBNull = false;
                this.columnOR01001.Unique = true;
                this.columnOR01002.AllowDBNull = false;
                this.columnOR01003.AllowDBNull = false;
                this.columnOR01004.AllowDBNull = false;
                this.columnOR01005.AllowDBNull = false;
                this.columnOR01006.AllowDBNull = false;
                this.columnOR01007.AllowDBNull = false;
                this.columnOR01008.AllowDBNull = false;
                this.columnOR01009.AllowDBNull = false;
                this.columnOR01010.AllowDBNull = false;
                this.columnOR01011.AllowDBNull = false;
                this.columnOR01012.AllowDBNull = false;
                this.columnOR01013.AllowDBNull = false;
                this.columnOR01014.AllowDBNull = false;
                this.columnOR01015.AllowDBNull = false;
                this.columnOR01016.AllowDBNull = false;
                this.columnOR01017.AllowDBNull = false;
                this.columnOR01018.AllowDBNull = false;
                this.columnOR01019.AllowDBNull = false;
                this.columnOR01020.AllowDBNull = false;
                this.columnOR01021.AllowDBNull = false;
                this.columnOR01022.AllowDBNull = false;
                this.columnOR01023.AllowDBNull = false;
                this.columnOR01024.AllowDBNull = false;
                this.columnOR01025.AllowDBNull = false;
                this.columnOR01026.AllowDBNull = false;
                this.columnOR01027.AllowDBNull = false;
                this.columnOR01028.AllowDBNull = false;
                this.columnOR01029.AllowDBNull = false;
                this.columnOR01030.AllowDBNull = false;
                this.columnOR01031.AllowDBNull = false;
                this.columnOR01032.AllowDBNull = false;
                this.columnOR01033.AllowDBNull = false;
                this.columnOR01034.AllowDBNull = false;
                this.columnOR01035.AllowDBNull = false;
                this.columnOR01036.AllowDBNull = false;
                this.columnOR01037.AllowDBNull = false;
                this.columnOR01038.AllowDBNull = false;
                this.columnOR01039.AllowDBNull = false;
                this.columnOR01040.AllowDBNull = false;
                this.columnOR01041.AllowDBNull = false;
                this.columnOR01042.AllowDBNull = false;
                this.columnOR01043.AllowDBNull = false;
                this.columnOR01044.AllowDBNull = false;
                this.columnOR01045.AllowDBNull = false;
                this.columnOR01046.AllowDBNull = false;
                this.columnOR01047.AllowDBNull = false;
                this.columnOR01048.AllowDBNull = false;
                this.columnOR01049.AllowDBNull = false;
                this.columnOR01050.AllowDBNull = false;
                this.columnOR01051.AllowDBNull = false;
                this.columnOR01052.AllowDBNull = false;
                this.columnOR01053.AllowDBNull = false;
                this.columnOR01054.AllowDBNull = false;
                this.columnOR01055.AllowDBNull = false;
                this.columnOR01056.AllowDBNull = false;
                this.columnOR01057.AllowDBNull = false;
                this.columnOR01058.AllowDBNull = false;
                this.columnOR01059.AllowDBNull = false;
                this.columnOR01060.AllowDBNull = false;
                this.columnOR01061.AllowDBNull = false;
                this.columnOR01062.AllowDBNull = false;
                this.columnOR01063.AllowDBNull = false;
                this.columnOR01064.AllowDBNull = false;
                this.columnOR01065.AllowDBNull = false;
                this.columnOR01066.AllowDBNull = false;
                this.columnOR01067.AllowDBNull = false;
                this.columnOR01068.AllowDBNull = false;
                this.columnOR01069.AllowDBNull = false;
                this.columnOR01070.AllowDBNull = false;
                this.columnOR01071.AllowDBNull = false;
                this.columnOR01072.AllowDBNull = false;
                this.columnOR01073.AllowDBNull = false;
                this.columnOR01074.AllowDBNull = false;
                this.columnOR01075.AllowDBNull = false;
                this.columnOR01076.AllowDBNull = false;
                this.columnOR01077.AllowDBNull = false;
                this.columnOR01078.AllowDBNull = false;
                this.columnOR01079.AllowDBNull = false;
                this.columnOR01080.AllowDBNull = false;
                this.columnOR01081.AllowDBNull = false;
                this.columnOR01082.AllowDBNull = false;
                this.columnOR01083.AllowDBNull = false;
                this.columnOR01084.AllowDBNull = false;
                this.columnOR01085.AllowDBNull = false;
                this.columnOR01086.AllowDBNull = false;
                this.columnOR01087.AllowDBNull = false;
                this.columnOR01088.AllowDBNull = false;
                this.columnOR01089.AllowDBNull = false;
                this.columnOR01090.AllowDBNull = false;
                this.columnOR01091.AllowDBNull = false;
                this.columnOR01092.AllowDBNull = false;
                this.columnOR01093.AllowDBNull = false;
                this.columnOR01094.AllowDBNull = false;
                this.columnOR01095.AllowDBNull = false;
                this.columnOR01096.AllowDBNull = false;
                this.columnOR01097.AllowDBNull = false;
                this.columnOR01098.AllowDBNull = false;
                this.columnOR01099.AllowDBNull = false;
                this.columnOR01100.AllowDBNull = false;
                this.columnOR01101.AllowDBNull = false;
                this.columnOR01102.AllowDBNull = false;
                this.columnOR01103.AllowDBNull = false;
                this.columnOR01104.AllowDBNull = false;
                this.columnOR01105.AllowDBNull = false;
                this.columnOR01106.AllowDBNull = false;
                this.columnOR01107.AllowDBNull = false;
                this.columnOR01108.AllowDBNull = false;
                this.columnOR01109.AllowDBNull = false;
                this.columnOR01110.AllowDBNull = false;
                this.columnOR01111.AllowDBNull = false;
                this.columnOR01112.AllowDBNull = false;
                this.columnOR01113.AllowDBNull = false;
                this.columnOR01114.AllowDBNull = false;
                this.columnOR01115.AllowDBNull = false;
                this.columnOR01116.AllowDBNull = false;
                this.columnOR01117.AllowDBNull = false;
                this.columnOR01118.AllowDBNull = false;
                this.columnOR01119.AllowDBNull = false;
                this.columnOR01120.AllowDBNull = false;
                this.columnOR01121.AllowDBNull = false;
                this.columnOR01122.AllowDBNull = false;
                this.columnOR01123.AllowDBNull = false;
                this.columnOR01124.AllowDBNull = false;
                this.columnOR01125.AllowDBNull = false;
                this.columnOR01126.AllowDBNull = false;
                this.columnOR01127.AllowDBNull = false;
                this.columnOR01128.AllowDBNull = false;
                this.columnOR01129.AllowDBNull = false;
                this.columnOR01130.AllowDBNull = false;
                this.columnOR01131.AllowDBNull = false;
                this.columnOR01132.AllowDBNull = false;
                this.columnOR01133.AllowDBNull = false;
                this.columnOR01134.AllowDBNull = false;
                this.columnOR01135.AllowDBNull = false;
                this.columnOR01136.AllowDBNull = false;
                this.columnOR01137.AllowDBNull = false;
                this.columnOR01138.AllowDBNull = false;
                this.columnOR01139.AllowDBNull = false;
                this.columnOR01140.AllowDBNull = false;
                this.columnOR01141.AllowDBNull = false;
                this.columnOR01142.AllowDBNull = false;
                this.columnOR01143.AllowDBNull = false;
                this.columnOR01144.AllowDBNull = false;
                this.columnOR01145.AllowDBNull = false;
                this.columnOR01146.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnOR01001 = this.Columns["OR01001"];
                this.columnOR01002 = this.Columns["OR01002"];
                this.columnOR01003 = this.Columns["OR01003"];
                this.columnOR01004 = this.Columns["OR01004"];
                this.columnOR01005 = this.Columns["OR01005"];
                this.columnOR01006 = this.Columns["OR01006"];
                this.columnOR01007 = this.Columns["OR01007"];
                this.columnOR01008 = this.Columns["OR01008"];
                this.columnOR01009 = this.Columns["OR01009"];
                this.columnOR01010 = this.Columns["OR01010"];
                this.columnOR01011 = this.Columns["OR01011"];
                this.columnOR01012 = this.Columns["OR01012"];
                this.columnOR01013 = this.Columns["OR01013"];
                this.columnOR01014 = this.Columns["OR01014"];
                this.columnOR01015 = this.Columns["OR01015"];
                this.columnOR01016 = this.Columns["OR01016"];
                this.columnOR01017 = this.Columns["OR01017"];
                this.columnOR01018 = this.Columns["OR01018"];
                this.columnOR01019 = this.Columns["OR01019"];
                this.columnOR01020 = this.Columns["OR01020"];
                this.columnOR01021 = this.Columns["OR01021"];
                this.columnOR01022 = this.Columns["OR01022"];
                this.columnOR01023 = this.Columns["OR01023"];
                this.columnOR01024 = this.Columns["OR01024"];
                this.columnOR01025 = this.Columns["OR01025"];
                this.columnOR01026 = this.Columns["OR01026"];
                this.columnOR01027 = this.Columns["OR01027"];
                this.columnOR01028 = this.Columns["OR01028"];
                this.columnOR01029 = this.Columns["OR01029"];
                this.columnOR01030 = this.Columns["OR01030"];
                this.columnOR01031 = this.Columns["OR01031"];
                this.columnOR01032 = this.Columns["OR01032"];
                this.columnOR01033 = this.Columns["OR01033"];
                this.columnOR01034 = this.Columns["OR01034"];
                this.columnOR01035 = this.Columns["OR01035"];
                this.columnOR01036 = this.Columns["OR01036"];
                this.columnOR01037 = this.Columns["OR01037"];
                this.columnOR01038 = this.Columns["OR01038"];
                this.columnOR01039 = this.Columns["OR01039"];
                this.columnOR01040 = this.Columns["OR01040"];
                this.columnOR01041 = this.Columns["OR01041"];
                this.columnOR01042 = this.Columns["OR01042"];
                this.columnOR01043 = this.Columns["OR01043"];
                this.columnOR01044 = this.Columns["OR01044"];
                this.columnOR01045 = this.Columns["OR01045"];
                this.columnOR01046 = this.Columns["OR01046"];
                this.columnOR01047 = this.Columns["OR01047"];
                this.columnOR01048 = this.Columns["OR01048"];
                this.columnOR01049 = this.Columns["OR01049"];
                this.columnOR01050 = this.Columns["OR01050"];
                this.columnOR01051 = this.Columns["OR01051"];
                this.columnOR01052 = this.Columns["OR01052"];
                this.columnOR01053 = this.Columns["OR01053"];
                this.columnOR01054 = this.Columns["OR01054"];
                this.columnOR01055 = this.Columns["OR01055"];
                this.columnOR01056 = this.Columns["OR01056"];
                this.columnOR01057 = this.Columns["OR01057"];
                this.columnOR01058 = this.Columns["OR01058"];
                this.columnOR01059 = this.Columns["OR01059"];
                this.columnOR01060 = this.Columns["OR01060"];
                this.columnOR01061 = this.Columns["OR01061"];
                this.columnOR01062 = this.Columns["OR01062"];
                this.columnOR01063 = this.Columns["OR01063"];
                this.columnOR01064 = this.Columns["OR01064"];
                this.columnOR01065 = this.Columns["OR01065"];
                this.columnOR01066 = this.Columns["OR01066"];
                this.columnOR01067 = this.Columns["OR01067"];
                this.columnOR01068 = this.Columns["OR01068"];
                this.columnOR01069 = this.Columns["OR01069"];
                this.columnOR01070 = this.Columns["OR01070"];
                this.columnOR01071 = this.Columns["OR01071"];
                this.columnOR01072 = this.Columns["OR01072"];
                this.columnOR01073 = this.Columns["OR01073"];
                this.columnOR01074 = this.Columns["OR01074"];
                this.columnOR01075 = this.Columns["OR01075"];
                this.columnOR01076 = this.Columns["OR01076"];
                this.columnOR01077 = this.Columns["OR01077"];
                this.columnOR01078 = this.Columns["OR01078"];
                this.columnOR01079 = this.Columns["OR01079"];
                this.columnOR01080 = this.Columns["OR01080"];
                this.columnOR01081 = this.Columns["OR01081"];
                this.columnOR01082 = this.Columns["OR01082"];
                this.columnOR01083 = this.Columns["OR01083"];
                this.columnOR01084 = this.Columns["OR01084"];
                this.columnOR01085 = this.Columns["OR01085"];
                this.columnOR01086 = this.Columns["OR01086"];
                this.columnOR01087 = this.Columns["OR01087"];
                this.columnOR01088 = this.Columns["OR01088"];
                this.columnOR01089 = this.Columns["OR01089"];
                this.columnOR01090 = this.Columns["OR01090"];
                this.columnOR01091 = this.Columns["OR01091"];
                this.columnOR01092 = this.Columns["OR01092"];
                this.columnOR01093 = this.Columns["OR01093"];
                this.columnOR01094 = this.Columns["OR01094"];
                this.columnOR01095 = this.Columns["OR01095"];
                this.columnOR01096 = this.Columns["OR01096"];
                this.columnOR01097 = this.Columns["OR01097"];
                this.columnOR01098 = this.Columns["OR01098"];
                this.columnOR01099 = this.Columns["OR01099"];
                this.columnOR01100 = this.Columns["OR01100"];
                this.columnOR01101 = this.Columns["OR01101"];
                this.columnOR01102 = this.Columns["OR01102"];
                this.columnOR01103 = this.Columns["OR01103"];
                this.columnOR01104 = this.Columns["OR01104"];
                this.columnOR01105 = this.Columns["OR01105"];
                this.columnOR01106 = this.Columns["OR01106"];
                this.columnOR01107 = this.Columns["OR01107"];
                this.columnOR01108 = this.Columns["OR01108"];
                this.columnOR01109 = this.Columns["OR01109"];
                this.columnOR01110 = this.Columns["OR01110"];
                this.columnOR01111 = this.Columns["OR01111"];
                this.columnOR01112 = this.Columns["OR01112"];
                this.columnOR01113 = this.Columns["OR01113"];
                this.columnOR01114 = this.Columns["OR01114"];
                this.columnOR01115 = this.Columns["OR01115"];
                this.columnOR01116 = this.Columns["OR01116"];
                this.columnOR01117 = this.Columns["OR01117"];
                this.columnOR01118 = this.Columns["OR01118"];
                this.columnOR01119 = this.Columns["OR01119"];
                this.columnOR01120 = this.Columns["OR01120"];
                this.columnOR01121 = this.Columns["OR01121"];
                this.columnOR01122 = this.Columns["OR01122"];
                this.columnOR01123 = this.Columns["OR01123"];
                this.columnOR01124 = this.Columns["OR01124"];
                this.columnOR01125 = this.Columns["OR01125"];
                this.columnOR01126 = this.Columns["OR01126"];
                this.columnOR01127 = this.Columns["OR01127"];
                this.columnOR01128 = this.Columns["OR01128"];
                this.columnOR01129 = this.Columns["OR01129"];
                this.columnOR01130 = this.Columns["OR01130"];
                this.columnOR01131 = this.Columns["OR01131"];
                this.columnOR01132 = this.Columns["OR01132"];
                this.columnOR01133 = this.Columns["OR01133"];
                this.columnOR01134 = this.Columns["OR01134"];
                this.columnOR01135 = this.Columns["OR01135"];
                this.columnOR01136 = this.Columns["OR01136"];
                this.columnOR01137 = this.Columns["OR01137"];
                this.columnOR01138 = this.Columns["OR01138"];
                this.columnOR01139 = this.Columns["OR01139"];
                this.columnOR01140 = this.Columns["OR01140"];
                this.columnOR01141 = this.Columns["OR01141"];
                this.columnOR01142 = this.Columns["OR01142"];
                this.columnOR01143 = this.Columns["OR01143"];
                this.columnOR01144 = this.Columns["OR01144"];
                this.columnOR01145 = this.Columns["OR01145"];
                this.columnOR01146 = this.Columns["OR01146"];
            }

            public DSOAPend.OR010100Row NewOR010100Row()
            {
                return (DSOAPend.OR010100Row) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DSOAPend.OR010100Row(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.OR010100RowChangedEvent != null) && (this.OR010100RowChangedEvent != null))
                {
                    this.OR010100RowChangedEvent(this, new DSOAPend.OR010100RowChangeEvent((DSOAPend.OR010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.OR010100RowChangingEvent != null) && (this.OR010100RowChangingEvent != null))
                {
                    this.OR010100RowChangingEvent(this, new DSOAPend.OR010100RowChangeEvent((DSOAPend.OR010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.OR010100RowDeletedEvent != null) && (this.OR010100RowDeletedEvent != null))
                {
                    this.OR010100RowDeletedEvent(this, new DSOAPend.OR010100RowChangeEvent((DSOAPend.OR010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.OR010100RowDeletingEvent != null) && (this.OR010100RowDeletingEvent != null))
                {
                    this.OR010100RowDeletingEvent(this, new DSOAPend.OR010100RowChangeEvent((DSOAPend.OR010100Row) e.Row, e.Action));
                }
            }

            public void RemoveOR010100Row(DSOAPend.OR010100Row row)
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

            public DSOAPend.OR010100Row this[int index]
            {
                get
                {
                    return (DSOAPend.OR010100Row) this.Rows[index];
                }
            }

            internal DataColumn OR01001Column
            {
                get
                {
                    return this.columnOR01001;
                }
            }

            internal DataColumn OR01002Column
            {
                get
                {
                    return this.columnOR01002;
                }
            }

            internal DataColumn OR01003Column
            {
                get
                {
                    return this.columnOR01003;
                }
            }

            internal DataColumn OR01004Column
            {
                get
                {
                    return this.columnOR01004;
                }
            }

            internal DataColumn OR01005Column
            {
                get
                {
                    return this.columnOR01005;
                }
            }

            internal DataColumn OR01006Column
            {
                get
                {
                    return this.columnOR01006;
                }
            }

            internal DataColumn OR01007Column
            {
                get
                {
                    return this.columnOR01007;
                }
            }

            internal DataColumn OR01008Column
            {
                get
                {
                    return this.columnOR01008;
                }
            }

            internal DataColumn OR01009Column
            {
                get
                {
                    return this.columnOR01009;
                }
            }

            internal DataColumn OR01010Column
            {
                get
                {
                    return this.columnOR01010;
                }
            }

            internal DataColumn OR01011Column
            {
                get
                {
                    return this.columnOR01011;
                }
            }

            internal DataColumn OR01012Column
            {
                get
                {
                    return this.columnOR01012;
                }
            }

            internal DataColumn OR01013Column
            {
                get
                {
                    return this.columnOR01013;
                }
            }

            internal DataColumn OR01014Column
            {
                get
                {
                    return this.columnOR01014;
                }
            }

            internal DataColumn OR01015Column
            {
                get
                {
                    return this.columnOR01015;
                }
            }

            internal DataColumn OR01016Column
            {
                get
                {
                    return this.columnOR01016;
                }
            }

            internal DataColumn OR01017Column
            {
                get
                {
                    return this.columnOR01017;
                }
            }

            internal DataColumn OR01018Column
            {
                get
                {
                    return this.columnOR01018;
                }
            }

            internal DataColumn OR01019Column
            {
                get
                {
                    return this.columnOR01019;
                }
            }

            internal DataColumn OR01020Column
            {
                get
                {
                    return this.columnOR01020;
                }
            }

            internal DataColumn OR01021Column
            {
                get
                {
                    return this.columnOR01021;
                }
            }

            internal DataColumn OR01022Column
            {
                get
                {
                    return this.columnOR01022;
                }
            }

            internal DataColumn OR01023Column
            {
                get
                {
                    return this.columnOR01023;
                }
            }

            internal DataColumn OR01024Column
            {
                get
                {
                    return this.columnOR01024;
                }
            }

            internal DataColumn OR01025Column
            {
                get
                {
                    return this.columnOR01025;
                }
            }

            internal DataColumn OR01026Column
            {
                get
                {
                    return this.columnOR01026;
                }
            }

            internal DataColumn OR01027Column
            {
                get
                {
                    return this.columnOR01027;
                }
            }

            internal DataColumn OR01028Column
            {
                get
                {
                    return this.columnOR01028;
                }
            }

            internal DataColumn OR01029Column
            {
                get
                {
                    return this.columnOR01029;
                }
            }

            internal DataColumn OR01030Column
            {
                get
                {
                    return this.columnOR01030;
                }
            }

            internal DataColumn OR01031Column
            {
                get
                {
                    return this.columnOR01031;
                }
            }

            internal DataColumn OR01032Column
            {
                get
                {
                    return this.columnOR01032;
                }
            }

            internal DataColumn OR01033Column
            {
                get
                {
                    return this.columnOR01033;
                }
            }

            internal DataColumn OR01034Column
            {
                get
                {
                    return this.columnOR01034;
                }
            }

            internal DataColumn OR01035Column
            {
                get
                {
                    return this.columnOR01035;
                }
            }

            internal DataColumn OR01036Column
            {
                get
                {
                    return this.columnOR01036;
                }
            }

            internal DataColumn OR01037Column
            {
                get
                {
                    return this.columnOR01037;
                }
            }

            internal DataColumn OR01038Column
            {
                get
                {
                    return this.columnOR01038;
                }
            }

            internal DataColumn OR01039Column
            {
                get
                {
                    return this.columnOR01039;
                }
            }

            internal DataColumn OR01040Column
            {
                get
                {
                    return this.columnOR01040;
                }
            }

            internal DataColumn OR01041Column
            {
                get
                {
                    return this.columnOR01041;
                }
            }

            internal DataColumn OR01042Column
            {
                get
                {
                    return this.columnOR01042;
                }
            }

            internal DataColumn OR01043Column
            {
                get
                {
                    return this.columnOR01043;
                }
            }

            internal DataColumn OR01044Column
            {
                get
                {
                    return this.columnOR01044;
                }
            }

            internal DataColumn OR01045Column
            {
                get
                {
                    return this.columnOR01045;
                }
            }

            internal DataColumn OR01046Column
            {
                get
                {
                    return this.columnOR01046;
                }
            }

            internal DataColumn OR01047Column
            {
                get
                {
                    return this.columnOR01047;
                }
            }

            internal DataColumn OR01048Column
            {
                get
                {
                    return this.columnOR01048;
                }
            }

            internal DataColumn OR01049Column
            {
                get
                {
                    return this.columnOR01049;
                }
            }

            internal DataColumn OR01050Column
            {
                get
                {
                    return this.columnOR01050;
                }
            }

            internal DataColumn OR01051Column
            {
                get
                {
                    return this.columnOR01051;
                }
            }

            internal DataColumn OR01052Column
            {
                get
                {
                    return this.columnOR01052;
                }
            }

            internal DataColumn OR01053Column
            {
                get
                {
                    return this.columnOR01053;
                }
            }

            internal DataColumn OR01054Column
            {
                get
                {
                    return this.columnOR01054;
                }
            }

            internal DataColumn OR01055Column
            {
                get
                {
                    return this.columnOR01055;
                }
            }

            internal DataColumn OR01056Column
            {
                get
                {
                    return this.columnOR01056;
                }
            }

            internal DataColumn OR01057Column
            {
                get
                {
                    return this.columnOR01057;
                }
            }

            internal DataColumn OR01058Column
            {
                get
                {
                    return this.columnOR01058;
                }
            }

            internal DataColumn OR01059Column
            {
                get
                {
                    return this.columnOR01059;
                }
            }

            internal DataColumn OR01060Column
            {
                get
                {
                    return this.columnOR01060;
                }
            }

            internal DataColumn OR01061Column
            {
                get
                {
                    return this.columnOR01061;
                }
            }

            internal DataColumn OR01062Column
            {
                get
                {
                    return this.columnOR01062;
                }
            }

            internal DataColumn OR01063Column
            {
                get
                {
                    return this.columnOR01063;
                }
            }

            internal DataColumn OR01064Column
            {
                get
                {
                    return this.columnOR01064;
                }
            }

            internal DataColumn OR01065Column
            {
                get
                {
                    return this.columnOR01065;
                }
            }

            internal DataColumn OR01066Column
            {
                get
                {
                    return this.columnOR01066;
                }
            }

            internal DataColumn OR01067Column
            {
                get
                {
                    return this.columnOR01067;
                }
            }

            internal DataColumn OR01068Column
            {
                get
                {
                    return this.columnOR01068;
                }
            }

            internal DataColumn OR01069Column
            {
                get
                {
                    return this.columnOR01069;
                }
            }

            internal DataColumn OR01070Column
            {
                get
                {
                    return this.columnOR01070;
                }
            }

            internal DataColumn OR01071Column
            {
                get
                {
                    return this.columnOR01071;
                }
            }

            internal DataColumn OR01072Column
            {
                get
                {
                    return this.columnOR01072;
                }
            }

            internal DataColumn OR01073Column
            {
                get
                {
                    return this.columnOR01073;
                }
            }

            internal DataColumn OR01074Column
            {
                get
                {
                    return this.columnOR01074;
                }
            }

            internal DataColumn OR01075Column
            {
                get
                {
                    return this.columnOR01075;
                }
            }

            internal DataColumn OR01076Column
            {
                get
                {
                    return this.columnOR01076;
                }
            }

            internal DataColumn OR01077Column
            {
                get
                {
                    return this.columnOR01077;
                }
            }

            internal DataColumn OR01078Column
            {
                get
                {
                    return this.columnOR01078;
                }
            }

            internal DataColumn OR01079Column
            {
                get
                {
                    return this.columnOR01079;
                }
            }

            internal DataColumn OR01080Column
            {
                get
                {
                    return this.columnOR01080;
                }
            }

            internal DataColumn OR01081Column
            {
                get
                {
                    return this.columnOR01081;
                }
            }

            internal DataColumn OR01082Column
            {
                get
                {
                    return this.columnOR01082;
                }
            }

            internal DataColumn OR01083Column
            {
                get
                {
                    return this.columnOR01083;
                }
            }

            internal DataColumn OR01084Column
            {
                get
                {
                    return this.columnOR01084;
                }
            }

            internal DataColumn OR01085Column
            {
                get
                {
                    return this.columnOR01085;
                }
            }

            internal DataColumn OR01086Column
            {
                get
                {
                    return this.columnOR01086;
                }
            }

            internal DataColumn OR01087Column
            {
                get
                {
                    return this.columnOR01087;
                }
            }

            internal DataColumn OR01088Column
            {
                get
                {
                    return this.columnOR01088;
                }
            }

            internal DataColumn OR01089Column
            {
                get
                {
                    return this.columnOR01089;
                }
            }

            internal DataColumn OR01090Column
            {
                get
                {
                    return this.columnOR01090;
                }
            }

            internal DataColumn OR01091Column
            {
                get
                {
                    return this.columnOR01091;
                }
            }

            internal DataColumn OR01092Column
            {
                get
                {
                    return this.columnOR01092;
                }
            }

            internal DataColumn OR01093Column
            {
                get
                {
                    return this.columnOR01093;
                }
            }

            internal DataColumn OR01094Column
            {
                get
                {
                    return this.columnOR01094;
                }
            }

            internal DataColumn OR01095Column
            {
                get
                {
                    return this.columnOR01095;
                }
            }

            internal DataColumn OR01096Column
            {
                get
                {
                    return this.columnOR01096;
                }
            }

            internal DataColumn OR01097Column
            {
                get
                {
                    return this.columnOR01097;
                }
            }

            internal DataColumn OR01098Column
            {
                get
                {
                    return this.columnOR01098;
                }
            }

            internal DataColumn OR01099Column
            {
                get
                {
                    return this.columnOR01099;
                }
            }

            internal DataColumn OR01100Column
            {
                get
                {
                    return this.columnOR01100;
                }
            }

            internal DataColumn OR01101Column
            {
                get
                {
                    return this.columnOR01101;
                }
            }

            internal DataColumn OR01102Column
            {
                get
                {
                    return this.columnOR01102;
                }
            }

            internal DataColumn OR01103Column
            {
                get
                {
                    return this.columnOR01103;
                }
            }

            internal DataColumn OR01104Column
            {
                get
                {
                    return this.columnOR01104;
                }
            }

            internal DataColumn OR01105Column
            {
                get
                {
                    return this.columnOR01105;
                }
            }

            internal DataColumn OR01106Column
            {
                get
                {
                    return this.columnOR01106;
                }
            }

            internal DataColumn OR01107Column
            {
                get
                {
                    return this.columnOR01107;
                }
            }

            internal DataColumn OR01108Column
            {
                get
                {
                    return this.columnOR01108;
                }
            }

            internal DataColumn OR01109Column
            {
                get
                {
                    return this.columnOR01109;
                }
            }

            internal DataColumn OR01110Column
            {
                get
                {
                    return this.columnOR01110;
                }
            }

            internal DataColumn OR01111Column
            {
                get
                {
                    return this.columnOR01111;
                }
            }

            internal DataColumn OR01112Column
            {
                get
                {
                    return this.columnOR01112;
                }
            }

            internal DataColumn OR01113Column
            {
                get
                {
                    return this.columnOR01113;
                }
            }

            internal DataColumn OR01114Column
            {
                get
                {
                    return this.columnOR01114;
                }
            }

            internal DataColumn OR01115Column
            {
                get
                {
                    return this.columnOR01115;
                }
            }

            internal DataColumn OR01116Column
            {
                get
                {
                    return this.columnOR01116;
                }
            }

            internal DataColumn OR01117Column
            {
                get
                {
                    return this.columnOR01117;
                }
            }

            internal DataColumn OR01118Column
            {
                get
                {
                    return this.columnOR01118;
                }
            }

            internal DataColumn OR01119Column
            {
                get
                {
                    return this.columnOR01119;
                }
            }

            internal DataColumn OR01120Column
            {
                get
                {
                    return this.columnOR01120;
                }
            }

            internal DataColumn OR01121Column
            {
                get
                {
                    return this.columnOR01121;
                }
            }

            internal DataColumn OR01122Column
            {
                get
                {
                    return this.columnOR01122;
                }
            }

            internal DataColumn OR01123Column
            {
                get
                {
                    return this.columnOR01123;
                }
            }

            internal DataColumn OR01124Column
            {
                get
                {
                    return this.columnOR01124;
                }
            }

            internal DataColumn OR01125Column
            {
                get
                {
                    return this.columnOR01125;
                }
            }

            internal DataColumn OR01126Column
            {
                get
                {
                    return this.columnOR01126;
                }
            }

            internal DataColumn OR01127Column
            {
                get
                {
                    return this.columnOR01127;
                }
            }

            internal DataColumn OR01128Column
            {
                get
                {
                    return this.columnOR01128;
                }
            }

            internal DataColumn OR01129Column
            {
                get
                {
                    return this.columnOR01129;
                }
            }

            internal DataColumn OR01130Column
            {
                get
                {
                    return this.columnOR01130;
                }
            }

            internal DataColumn OR01131Column
            {
                get
                {
                    return this.columnOR01131;
                }
            }

            internal DataColumn OR01132Column
            {
                get
                {
                    return this.columnOR01132;
                }
            }

            internal DataColumn OR01133Column
            {
                get
                {
                    return this.columnOR01133;
                }
            }

            internal DataColumn OR01134Column
            {
                get
                {
                    return this.columnOR01134;
                }
            }

            internal DataColumn OR01135Column
            {
                get
                {
                    return this.columnOR01135;
                }
            }

            internal DataColumn OR01136Column
            {
                get
                {
                    return this.columnOR01136;
                }
            }

            internal DataColumn OR01137Column
            {
                get
                {
                    return this.columnOR01137;
                }
            }

            internal DataColumn OR01138Column
            {
                get
                {
                    return this.columnOR01138;
                }
            }

            internal DataColumn OR01139Column
            {
                get
                {
                    return this.columnOR01139;
                }
            }

            internal DataColumn OR01140Column
            {
                get
                {
                    return this.columnOR01140;
                }
            }

            internal DataColumn OR01141Column
            {
                get
                {
                    return this.columnOR01141;
                }
            }

            internal DataColumn OR01142Column
            {
                get
                {
                    return this.columnOR01142;
                }
            }

            internal DataColumn OR01143Column
            {
                get
                {
                    return this.columnOR01143;
                }
            }

            internal DataColumn OR01144Column
            {
                get
                {
                    return this.columnOR01144;
                }
            }

            internal DataColumn OR01145Column
            {
                get
                {
                    return this.columnOR01145;
                }
            }

            internal DataColumn OR01146Column
            {
                get
                {
                    return this.columnOR01146;
                }
            }
        }

        [DebuggerStepThrough]
        public class OR010100Row : DataRow
        {
            private DSOAPend.OR010100DataTable tableOR010100;

            internal OR010100Row(DataRowBuilder rb) : base(rb)
            {
                this.tableOR010100 = (DSOAPend.OR010100DataTable) this.Table;
            }

            public string OR01001
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01001Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01001Column] = value;
                }
            }

            public int OR01002
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01002Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01002Column] = value;
                }
            }

            public string OR01003
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01003Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01003Column] = value;
                }
            }

            public string OR01004
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01004Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01004Column] = value;
                }
            }

            public string OR01005
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01005Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01005Column] = value;
                }
            }

            public string OR01006
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01006Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01006Column] = value;
                }
            }

            public int OR01007
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01007Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01007Column] = value;
                }
            }

            public int OR01008
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01008Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01008Column] = value;
                }
            }

            public int OR01009
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01009Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01009Column] = value;
                }
            }

            public int OR01010
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01010Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01010Column] = value;
                }
            }

            public int OR01011
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01011Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01011Column] = value;
                }
            }

            public int OR01012
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01012Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01012Column] = value;
                }
            }

            public int OR01013
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01013Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01013Column] = value;
                }
            }

            public int OR01014
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01014Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01014Column] = value;
                }
            }

            public DateTime OR01015
            {
                get
                {
                    return DateType.FromObject(this[this.tableOR010100.OR01015Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01015Column] = value;
                }
            }

            public DateTime OR01016
            {
                get
                {
                    return DateType.FromObject(this[this.tableOR010100.OR01016Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01016Column] = value;
                }
            }

            public string OR01017
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01017Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01017Column] = value;
                }
            }

            public string OR01018
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01018Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01018Column] = value;
                }
            }

            public string OR01019
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01019Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01019Column] = value;
                }
            }

            public string OR01020
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01020Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01020Column] = value;
                }
            }

            public string OR01021
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01021Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01021Column] = value;
                }
            }

            public DateTime OR01022
            {
                get
                {
                    return DateType.FromObject(this[this.tableOR010100.OR01022Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01022Column] = value;
                }
            }

            public string OR01023
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01023Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01023Column] = value;
                }
            }

            public decimal OR01024
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01024Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01024Column] = value;
                }
            }

            public string OR01025
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01025Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01025Column] = value;
                }
            }

            public int OR01026
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01026Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01026Column] = value;
                }
            }

            public int OR01027
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01027Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01027Column] = value;
                }
            }

            public int OR01028
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01028Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01028Column] = value;
                }
            }

            public int OR01029
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01029Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01029Column] = value;
                }
            }

            public int OR01030
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01030Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01030Column] = value;
                }
            }

            public int OR01031
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01031Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01031Column] = value;
                }
            }

            public int OR01032
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01032Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01032Column] = value;
                }
            }

            public int OR01033
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01033Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01033Column] = value;
                }
            }

            public decimal OR01034
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01034Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01034Column] = value;
                }
            }

            public decimal OR01035
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01035Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01035Column] = value;
                }
            }

            public decimal OR01036
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01036Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01036Column] = value;
                }
            }

            public decimal OR01037
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01037Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01037Column] = value;
                }
            }

            public string OR01038
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01038Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01038Column] = value;
                }
            }

            public DateTime OR01039
            {
                get
                {
                    return DateType.FromObject(this[this.tableOR010100.OR01039Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01039Column] = value;
                }
            }

            public DateTime OR01040
            {
                get
                {
                    return DateType.FromObject(this[this.tableOR010100.OR01040Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01040Column] = value;
                }
            }

            public decimal OR01041
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01041Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01041Column] = value;
                }
            }

            public decimal OR01042
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01042Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01042Column] = value;
                }
            }

            public decimal OR01043
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01043Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01043Column] = value;
                }
            }

            public decimal OR01044
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01044Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01044Column] = value;
                }
            }

            public string OR01045
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01045Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01045Column] = value;
                }
            }

            public decimal OR01046
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01046Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01046Column] = value;
                }
            }

            public string OR01047
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01047Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01047Column] = value;
                }
            }

            public decimal OR01048
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01048Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01048Column] = value;
                }
            }

            public string OR01049
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01049Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01049Column] = value;
                }
            }

            public string OR01050
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01050Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01050Column] = value;
                }
            }

            public string OR01051
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01051Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01051Column] = value;
                }
            }

            public string OR01052
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01052Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01052Column] = value;
                }
            }

            public string OR01053
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01053Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01053Column] = value;
                }
            }

            public string OR01054
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01054Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01054Column] = value;
                }
            }

            public string OR01055
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01055Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01055Column] = value;
                }
            }

            public string OR01056
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01056Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01056Column] = value;
                }
            }

            public decimal OR01057
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01057Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01057Column] = value;
                }
            }

            public decimal OR01058
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01058Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01058Column] = value;
                }
            }

            public decimal OR01059
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01059Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01059Column] = value;
                }
            }

            public decimal OR01060
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01060Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01060Column] = value;
                }
            }

            public decimal OR01061
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01061Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01061Column] = value;
                }
            }

            public string OR01062
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01062Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01062Column] = value;
                }
            }

            public decimal OR01063
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01063Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01063Column] = value;
                }
            }

            public decimal OR01064
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01064Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01064Column] = value;
                }
            }

            public int OR01065
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01065Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01065Column] = value;
                }
            }

            public string OR01066
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01066Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01066Column] = value;
                }
            }

            public decimal OR01067
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01067Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01067Column] = value;
                }
            }

            public string OR01068
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01068Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01068Column] = value;
                }
            }

            public string OR01069
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01069Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01069Column] = value;
                }
            }

            public string OR01070
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01070Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01070Column] = value;
                }
            }

            public int OR01071
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01071Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01071Column] = value;
                }
            }

            public string OR01072
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01072Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01072Column] = value;
                }
            }

            public string OR01073
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01073Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01073Column] = value;
                }
            }

            public DateTime OR01074
            {
                get
                {
                    return DateType.FromObject(this[this.tableOR010100.OR01074Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01074Column] = value;
                }
            }

            public DateTime OR01075
            {
                get
                {
                    return DateType.FromObject(this[this.tableOR010100.OR01075Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01075Column] = value;
                }
            }

            public string OR01076
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01076Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01076Column] = value;
                }
            }

            public DateTime OR01077
            {
                get
                {
                    return DateType.FromObject(this[this.tableOR010100.OR01077Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01077Column] = value;
                }
            }

            public string OR01078
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01078Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01078Column] = value;
                }
            }

            public string OR01079
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01079Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01079Column] = value;
                }
            }

            public int OR01080
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01080Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01080Column] = value;
                }
            }

            public int OR01081
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01081Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01081Column] = value;
                }
            }

            public string OR01082
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01082Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01082Column] = value;
                }
            }

            public string OR01083
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01083Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01083Column] = value;
                }
            }

            public string OR01084
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01084Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01084Column] = value;
                }
            }

            public string OR01085
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01085Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01085Column] = value;
                }
            }

            public string OR01086
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01086Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01086Column] = value;
                }
            }

            public string OR01087
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01087Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01087Column] = value;
                }
            }

            public string OR01088
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01088Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01088Column] = value;
                }
            }

            public string OR01089
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01089Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01089Column] = value;
                }
            }

            public string OR01090
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01090Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01090Column] = value;
                }
            }

            public int OR01091
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01091Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01091Column] = value;
                }
            }

            public int OR01092
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01092Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01092Column] = value;
                }
            }

            public int OR01093
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01093Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01093Column] = value;
                }
            }

            public int OR01094
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01094Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01094Column] = value;
                }
            }

            public string OR01095
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01095Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01095Column] = value;
                }
            }

            public string OR01096
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01096Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01096Column] = value;
                }
            }

            public DateTime OR01097
            {
                get
                {
                    return DateType.FromObject(this[this.tableOR010100.OR01097Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01097Column] = value;
                }
            }

            public string OR01098
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01098Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01098Column] = value;
                }
            }

            public string OR01099
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01099Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01099Column] = value;
                }
            }

            public int OR01100
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01100Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01100Column] = value;
                }
            }

            public string OR01101
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01101Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01101Column] = value;
                }
            }

            public int OR01102
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01102Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01102Column] = value;
                }
            }

            public string OR01103
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01103Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01103Column] = value;
                }
            }

            public string OR01104
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01104Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01104Column] = value;
                }
            }

            public string OR01105
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01105Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01105Column] = value;
                }
            }

            public string OR01106
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01106Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01106Column] = value;
                }
            }

            public string OR01107
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01107Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01107Column] = value;
                }
            }

            public string OR01108
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01108Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01108Column] = value;
                }
            }

            public string OR01109
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01109Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01109Column] = value;
                }
            }

            public decimal OR01110
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01110Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01110Column] = value;
                }
            }

            public string OR01111
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01111Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01111Column] = value;
                }
            }

            public decimal OR01112
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01112Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01112Column] = value;
                }
            }

            public string OR01113
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01113Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01113Column] = value;
                }
            }

            public decimal OR01114
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01114Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01114Column] = value;
                }
            }

            public string OR01115
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01115Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01115Column] = value;
                }
            }

            public int OR01116
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR010100.OR01116Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01116Column] = value;
                }
            }

            public string OR01117
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01117Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01117Column] = value;
                }
            }

            public string OR01118
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01118Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01118Column] = value;
                }
            }

            public string OR01119
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01119Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01119Column] = value;
                }
            }

            public string OR01120
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01120Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01120Column] = value;
                }
            }

            public string OR01121
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01121Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01121Column] = value;
                }
            }

            public string OR01122
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01122Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01122Column] = value;
                }
            }

            public string OR01123
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01123Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01123Column] = value;
                }
            }

            public string OR01124
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01124Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01124Column] = value;
                }
            }

            public string OR01125
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01125Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01125Column] = value;
                }
            }

            public string OR01126
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01126Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01126Column] = value;
                }
            }

            public decimal OR01127
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01127Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01127Column] = value;
                }
            }

            public string OR01128
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01128Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01128Column] = value;
                }
            }

            public string OR01129
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01129Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01129Column] = value;
                }
            }

            public string OR01130
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01130Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01130Column] = value;
                }
            }

            public DateTime OR01131
            {
                get
                {
                    return DateType.FromObject(this[this.tableOR010100.OR01131Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01131Column] = value;
                }
            }

            public string OR01132
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01132Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01132Column] = value;
                }
            }

            public string OR01133
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01133Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01133Column] = value;
                }
            }

            public string OR01134
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01134Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01134Column] = value;
                }
            }

            public string OR01135
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01135Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01135Column] = value;
                }
            }

            public string OR01136
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01136Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01136Column] = value;
                }
            }

            public string OR01137
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01137Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01137Column] = value;
                }
            }

            public decimal OR01138
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01138Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01138Column] = value;
                }
            }

            public string OR01139
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01139Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01139Column] = value;
                }
            }

            public decimal OR01140
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR010100.OR01140Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01140Column] = value;
                }
            }

            public string OR01141
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01141Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01141Column] = value;
                }
            }

            public string OR01142
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01142Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01142Column] = value;
                }
            }

            public string OR01143
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01143Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01143Column] = value;
                }
            }

            public string OR01144
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01144Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01144Column] = value;
                }
            }

            public string OR01145
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01145Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01145Column] = value;
                }
            }

            public string OR01146
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR010100.OR01146Column]);
                }
                set
                {
                    this[this.tableOR010100.OR01146Column] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class OR010100RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DSOAPend.OR010100Row eventRow;

            public OR010100RowChangeEvent(DSOAPend.OR010100Row row, DataRowAction action)
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

            public DSOAPend.OR010100Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OR010100RowChangeEventHandler(object sender, DSOAPend.OR010100RowChangeEvent e);

        [DebuggerStepThrough]
        public class OR030100DataTable : DataTable, IEnumerable
        {
            private DataColumn columnOR03001;
            private DataColumn columnOR03002;
            private DataColumn columnOR03003;
            private DataColumn columnOR03004;
            private DataColumn columnOR03005;
            private DataColumn columnOR03006;
            private DataColumn columnOR03007;
            private DataColumn columnOR03008;
            private DataColumn columnOR03009;
            private DataColumn columnOR03010;
            private DataColumn columnOR03011;
            private DataColumn columnOR03012;
            private DataColumn columnOR03013;
            private DataColumn columnOR03014;
            private DataColumn columnOR03015;
            private DataColumn columnOR03016;
            private DataColumn columnOR03017;
            private DataColumn columnOR03018;
            private DataColumn columnOR03019;
            private DataColumn columnOR03020;
            private DataColumn columnOR03021;
            private DataColumn columnOR03022;
            private DataColumn columnOR03023;
            private DataColumn columnOR03024;
            private DataColumn columnOR03025;
            private DataColumn columnOR03026;
            private DataColumn columnOR03027;
            private DataColumn columnOR03028;
            private DataColumn columnOR03029;
            private DataColumn columnOR03030;
            private DataColumn columnOR03031;
            private DataColumn columnOR03032;
            private DataColumn columnOR03033;
            private DataColumn columnOR03034;
            private DataColumn columnOR03035;
            private DataColumn columnOR03036;
            private DataColumn columnOR03037;
            private DataColumn columnOR03038;
            private DataColumn columnOR03039;
            private DataColumn columnOR03040;
            private DataColumn columnOR03041;
            private DataColumn columnOR03042;
            private DataColumn columnOR03043;
            private DataColumn columnOR03044;
            private DataColumn columnOR03045;
            private DataColumn columnOR03046;
            private DataColumn columnOR03047;
            private DataColumn columnOR03048;
            private DataColumn columnOR03049;
            private DataColumn columnOR03050;
            private DataColumn columnOR03051;
            private DataColumn columnOR03052;
            private DataColumn columnOR03053;
            private DataColumn columnOR03054;
            private DataColumn columnOR03055;
            private DataColumn columnOR03056;
            private DataColumn columnOR03057;
            private DataColumn columnOR03058;
            private DataColumn columnOR03059;
            private DataColumn columnOR03060;
            private DataColumn columnOR03061;
            private DataColumn columnOR03062;
            private DataColumn columnOR03063;
            private DataColumn columnOR03064;
            private DataColumn columnOR03065;
            private DataColumn columnOR03066;
            private DataColumn columnOR03067;
            private DataColumn columnOR03068;
            private DataColumn columnOR03069;
            private DataColumn columnOR03070;
            private DataColumn columnOR03071;
            private DataColumn columnOR03072;
            private DataColumn columnOR03073;
            private DataColumn columnOR03074;
            private DataColumn columnOR03075;
            private DataColumn columnOR03076;
            private DataColumn columnOR03077;
            private DataColumn columnOR03078;
            private DataColumn columnOR03079;
            private DataColumn columnOR03080;
            private DataColumn columnOR03081;
            private DataColumn columnOR03082;
            private DataColumn columnOR03083;
            private DataColumn columnOR03084;
            private DataColumn columnOR03085;
            private DataColumn columnOR03086;
            private DataColumn columnOR03087;
            private DataColumn columnOR03088;

            public event DSOAPend.OR030100RowChangeEventHandler OR030100RowChanged;

            public event DSOAPend.OR030100RowChangeEventHandler OR030100RowChanging;

            public event DSOAPend.OR030100RowChangeEventHandler OR030100RowDeleted;

            public event DSOAPend.OR030100RowChangeEventHandler OR030100RowDeleting;

            internal OR030100DataTable() : base("OR030100")
            {
                this.InitClass();
            }

            internal OR030100DataTable(DataTable table) : base(table.TableName)
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

            public void AddOR030100Row(DSOAPend.OR030100Row row)
            {
                this.Rows.Add(row);
            }

            public DSOAPend.OR030100Row AddOR030100Row(string OR03001, string OR03002, string OR03003, int OR03004, string OR03005, string OR03006, string OR03007, decimal OR03008, decimal OR03009, int OR03010, decimal OR03011, decimal OR03012, int OR03013, int OR03014, string OR03015, int OR03016, decimal OR03017, decimal OR03018, DateTime OR03019, decimal OR03020, decimal OR03021, decimal OR03022, decimal OR03023, decimal OR03024, int OR03025, int OR03026, int OR03027, string OR03028, int OR03029, int OR03030, int OR03031, byte[] OR03032, decimal OR03033, string OR03034, string OR03035, decimal OR03036, DateTime OR03037, string OR03038, int OR03039, decimal OR03040, decimal OR03041, DateTime OR03042, decimal OR03043, decimal OR03044, decimal OR03045, string OR03046, decimal OR03047, decimal OR03048, decimal OR03049, decimal OR03050, string OR03051, string OR03052, decimal OR03053, decimal OR03054, string OR03055, decimal OR03056, decimal OR03057, decimal OR03058, decimal OR03059, decimal OR03060, int OR03061, int OR03062, decimal OR03063, decimal OR03064, string OR03065, string OR03066, string OR03067, string OR03068, int OR03069, string OR03070, string OR03071, string OR03072, string OR03073, string OR03074, string OR03075, decimal OR03076, decimal OR03077, string OR03078, decimal OR03079, string OR03080, decimal OR03081, string OR03082, int OR03083, string OR03084, int OR03085, decimal OR03086, string OR03087, decimal OR03088)
            {
                DSOAPend.OR030100Row row = (DSOAPend.OR030100Row) this.NewRow();
                row.ItemArray = new object[] { 
                    OR03001, OR03002, OR03003, OR03004, OR03005, OR03006, OR03007, OR03008, OR03009, OR03010, OR03011, OR03012, OR03013, OR03014, OR03015, OR03016, 
                    OR03017, OR03018, OR03019, OR03020, OR03021, OR03022, OR03023, OR03024, OR03025, OR03026, OR03027, OR03028, OR03029, OR03030, OR03031, OR03032, 
                    OR03033, OR03034, OR03035, OR03036, OR03037, OR03038, OR03039, OR03040, OR03041, OR03042, OR03043, OR03044, OR03045, OR03046, OR03047, OR03048, 
                    OR03049, OR03050, OR03051, OR03052, OR03053, OR03054, OR03055, OR03056, OR03057, OR03058, OR03059, OR03060, OR03061, OR03062, OR03063, OR03064, 
                    OR03065, OR03066, OR03067, OR03068, OR03069, OR03070, OR03071, OR03072, OR03073, OR03074, OR03075, OR03076, OR03077, OR03078, OR03079, OR03080, 
                    OR03081, OR03082, OR03083, OR03084, OR03085, OR03086, OR03087, OR03088
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DSOAPend.OR030100DataTable table = (DSOAPend.OR030100DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DSOAPend.OR030100DataTable();
            }

            public DSOAPend.OR030100Row FindByOR03001OR03002OR03003(string OR03001, string OR03002, string OR03003)
            {
                return (DSOAPend.OR030100Row) this.Rows.Find(new object[] { OR03001, OR03002, OR03003 });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DSOAPend.OR030100Row);
            }

            private void InitClass()
            {
                this.columnOR03001 = new DataColumn("OR03001", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03001);
                this.columnOR03002 = new DataColumn("OR03002", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03002);
                this.columnOR03003 = new DataColumn("OR03003", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03003);
                this.columnOR03004 = new DataColumn("OR03004", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR03004);
                this.columnOR03005 = new DataColumn("OR03005", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03005);
                this.columnOR03006 = new DataColumn("OR03006", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03006);
                this.columnOR03007 = new DataColumn("OR03007", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03007);
                this.columnOR03008 = new DataColumn("OR03008", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03008);
                this.columnOR03009 = new DataColumn("OR03009", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03009);
                this.columnOR03010 = new DataColumn("OR03010", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR03010);
                this.columnOR03011 = new DataColumn("OR03011", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03011);
                this.columnOR03012 = new DataColumn("OR03012", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03012);
                this.columnOR03013 = new DataColumn("OR03013", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR03013);
                this.columnOR03014 = new DataColumn("OR03014", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR03014);
                this.columnOR03015 = new DataColumn("OR03015", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03015);
                this.columnOR03016 = new DataColumn("OR03016", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR03016);
                this.columnOR03017 = new DataColumn("OR03017", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03017);
                this.columnOR03018 = new DataColumn("OR03018", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03018);
                this.columnOR03019 = new DataColumn("OR03019", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnOR03019);
                this.columnOR03020 = new DataColumn("OR03020", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03020);
                this.columnOR03021 = new DataColumn("OR03021", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03021);
                this.columnOR03022 = new DataColumn("OR03022", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03022);
                this.columnOR03023 = new DataColumn("OR03023", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03023);
                this.columnOR03024 = new DataColumn("OR03024", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03024);
                this.columnOR03025 = new DataColumn("OR03025", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR03025);
                this.columnOR03026 = new DataColumn("OR03026", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR03026);
                this.columnOR03027 = new DataColumn("OR03027", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR03027);
                this.columnOR03028 = new DataColumn("OR03028", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03028);
                this.columnOR03029 = new DataColumn("OR03029", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR03029);
                this.columnOR03030 = new DataColumn("OR03030", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR03030);
                this.columnOR03031 = new DataColumn("OR03031", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR03031);
                this.columnOR03032 = new DataColumn("OR03032", typeof(byte[]), null, MappingType.Element);
                this.Columns.Add(this.columnOR03032);
                this.columnOR03033 = new DataColumn("OR03033", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03033);
                this.columnOR03034 = new DataColumn("OR03034", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03034);
                this.columnOR03035 = new DataColumn("OR03035", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03035);
                this.columnOR03036 = new DataColumn("OR03036", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03036);
                this.columnOR03037 = new DataColumn("OR03037", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnOR03037);
                this.columnOR03038 = new DataColumn("OR03038", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03038);
                this.columnOR03039 = new DataColumn("OR03039", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR03039);
                this.columnOR03040 = new DataColumn("OR03040", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03040);
                this.columnOR03041 = new DataColumn("OR03041", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03041);
                this.columnOR03042 = new DataColumn("OR03042", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnOR03042);
                this.columnOR03043 = new DataColumn("OR03043", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03043);
                this.columnOR03044 = new DataColumn("OR03044", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03044);
                this.columnOR03045 = new DataColumn("OR03045", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03045);
                this.columnOR03046 = new DataColumn("OR03046", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03046);
                this.columnOR03047 = new DataColumn("OR03047", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03047);
                this.columnOR03048 = new DataColumn("OR03048", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03048);
                this.columnOR03049 = new DataColumn("OR03049", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03049);
                this.columnOR03050 = new DataColumn("OR03050", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03050);
                this.columnOR03051 = new DataColumn("OR03051", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03051);
                this.columnOR03052 = new DataColumn("OR03052", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03052);
                this.columnOR03053 = new DataColumn("OR03053", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03053);
                this.columnOR03054 = new DataColumn("OR03054", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03054);
                this.columnOR03055 = new DataColumn("OR03055", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03055);
                this.columnOR03056 = new DataColumn("OR03056", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03056);
                this.columnOR03057 = new DataColumn("OR03057", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03057);
                this.columnOR03058 = new DataColumn("OR03058", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03058);
                this.columnOR03059 = new DataColumn("OR03059", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03059);
                this.columnOR03060 = new DataColumn("OR03060", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03060);
                this.columnOR03061 = new DataColumn("OR03061", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR03061);
                this.columnOR03062 = new DataColumn("OR03062", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR03062);
                this.columnOR03063 = new DataColumn("OR03063", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03063);
                this.columnOR03064 = new DataColumn("OR03064", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03064);
                this.columnOR03065 = new DataColumn("OR03065", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03065);
                this.columnOR03066 = new DataColumn("OR03066", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03066);
                this.columnOR03067 = new DataColumn("OR03067", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03067);
                this.columnOR03068 = new DataColumn("OR03068", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03068);
                this.columnOR03069 = new DataColumn("OR03069", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR03069);
                this.columnOR03070 = new DataColumn("OR03070", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03070);
                this.columnOR03071 = new DataColumn("OR03071", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03071);
                this.columnOR03072 = new DataColumn("OR03072", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03072);
                this.columnOR03073 = new DataColumn("OR03073", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03073);
                this.columnOR03074 = new DataColumn("OR03074", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03074);
                this.columnOR03075 = new DataColumn("OR03075", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03075);
                this.columnOR03076 = new DataColumn("OR03076", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03076);
                this.columnOR03077 = new DataColumn("OR03077", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03077);
                this.columnOR03078 = new DataColumn("OR03078", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03078);
                this.columnOR03079 = new DataColumn("OR03079", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03079);
                this.columnOR03080 = new DataColumn("OR03080", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03080);
                this.columnOR03081 = new DataColumn("OR03081", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03081);
                this.columnOR03082 = new DataColumn("OR03082", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03082);
                this.columnOR03083 = new DataColumn("OR03083", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR03083);
                this.columnOR03084 = new DataColumn("OR03084", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03084);
                this.columnOR03085 = new DataColumn("OR03085", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR03085);
                this.columnOR03086 = new DataColumn("OR03086", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03086);
                this.columnOR03087 = new DataColumn("OR03087", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR03087);
                this.columnOR03088 = new DataColumn("OR03088", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnOR03088);
                this.Constraints.Add(new UniqueConstraint("DSOAPendKey3", new DataColumn[] { this.columnOR03001, this.columnOR03002, this.columnOR03003 }, true));
                this.columnOR03001.AllowDBNull = false;
                this.columnOR03002.AllowDBNull = false;
                this.columnOR03003.AllowDBNull = false;
                this.columnOR03004.AllowDBNull = false;
                this.columnOR03005.AllowDBNull = false;
                this.columnOR03006.AllowDBNull = false;
                this.columnOR03007.AllowDBNull = false;
                this.columnOR03008.AllowDBNull = false;
                this.columnOR03009.AllowDBNull = false;
                this.columnOR03010.AllowDBNull = false;
                this.columnOR03011.AllowDBNull = false;
                this.columnOR03012.AllowDBNull = false;
                this.columnOR03013.AllowDBNull = false;
                this.columnOR03014.AllowDBNull = false;
                this.columnOR03015.AllowDBNull = false;
                this.columnOR03016.AllowDBNull = false;
                this.columnOR03017.AllowDBNull = false;
                this.columnOR03018.AllowDBNull = false;
                this.columnOR03019.AllowDBNull = false;
                this.columnOR03020.AllowDBNull = false;
                this.columnOR03021.AllowDBNull = false;
                this.columnOR03022.AllowDBNull = false;
                this.columnOR03023.AllowDBNull = false;
                this.columnOR03024.AllowDBNull = false;
                this.columnOR03025.AllowDBNull = false;
                this.columnOR03026.AllowDBNull = false;
                this.columnOR03027.AllowDBNull = false;
                this.columnOR03028.AllowDBNull = false;
                this.columnOR03029.AllowDBNull = false;
                this.columnOR03030.AllowDBNull = false;
                this.columnOR03031.AllowDBNull = false;
                this.columnOR03032.AllowDBNull = false;
                this.columnOR03033.AllowDBNull = false;
                this.columnOR03034.AllowDBNull = false;
                this.columnOR03035.AllowDBNull = false;
                this.columnOR03036.AllowDBNull = false;
                this.columnOR03037.AllowDBNull = false;
                this.columnOR03038.AllowDBNull = false;
                this.columnOR03039.AllowDBNull = false;
                this.columnOR03040.AllowDBNull = false;
                this.columnOR03041.AllowDBNull = false;
                this.columnOR03042.AllowDBNull = false;
                this.columnOR03043.AllowDBNull = false;
                this.columnOR03044.AllowDBNull = false;
                this.columnOR03045.AllowDBNull = false;
                this.columnOR03046.AllowDBNull = false;
                this.columnOR03047.AllowDBNull = false;
                this.columnOR03048.AllowDBNull = false;
                this.columnOR03049.AllowDBNull = false;
                this.columnOR03050.AllowDBNull = false;
                this.columnOR03051.AllowDBNull = false;
                this.columnOR03052.AllowDBNull = false;
                this.columnOR03053.AllowDBNull = false;
                this.columnOR03054.AllowDBNull = false;
                this.columnOR03055.AllowDBNull = false;
                this.columnOR03056.AllowDBNull = false;
                this.columnOR03057.AllowDBNull = false;
                this.columnOR03058.AllowDBNull = false;
                this.columnOR03059.AllowDBNull = false;
                this.columnOR03060.AllowDBNull = false;
                this.columnOR03061.AllowDBNull = false;
                this.columnOR03062.AllowDBNull = false;
                this.columnOR03063.AllowDBNull = false;
                this.columnOR03064.AllowDBNull = false;
                this.columnOR03065.AllowDBNull = false;
                this.columnOR03066.AllowDBNull = false;
                this.columnOR03067.AllowDBNull = false;
                this.columnOR03068.AllowDBNull = false;
                this.columnOR03069.AllowDBNull = false;
                this.columnOR03070.AllowDBNull = false;
                this.columnOR03071.AllowDBNull = false;
                this.columnOR03072.AllowDBNull = false;
                this.columnOR03073.AllowDBNull = false;
                this.columnOR03074.AllowDBNull = false;
                this.columnOR03075.AllowDBNull = false;
                this.columnOR03076.AllowDBNull = false;
                this.columnOR03077.AllowDBNull = false;
                this.columnOR03078.AllowDBNull = false;
                this.columnOR03079.AllowDBNull = false;
                this.columnOR03080.AllowDBNull = false;
                this.columnOR03081.AllowDBNull = false;
                this.columnOR03082.AllowDBNull = false;
                this.columnOR03083.AllowDBNull = false;
                this.columnOR03084.AllowDBNull = false;
                this.columnOR03085.AllowDBNull = false;
                this.columnOR03086.AllowDBNull = false;
                this.columnOR03087.AllowDBNull = false;
                this.columnOR03088.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnOR03001 = this.Columns["OR03001"];
                this.columnOR03002 = this.Columns["OR03002"];
                this.columnOR03003 = this.Columns["OR03003"];
                this.columnOR03004 = this.Columns["OR03004"];
                this.columnOR03005 = this.Columns["OR03005"];
                this.columnOR03006 = this.Columns["OR03006"];
                this.columnOR03007 = this.Columns["OR03007"];
                this.columnOR03008 = this.Columns["OR03008"];
                this.columnOR03009 = this.Columns["OR03009"];
                this.columnOR03010 = this.Columns["OR03010"];
                this.columnOR03011 = this.Columns["OR03011"];
                this.columnOR03012 = this.Columns["OR03012"];
                this.columnOR03013 = this.Columns["OR03013"];
                this.columnOR03014 = this.Columns["OR03014"];
                this.columnOR03015 = this.Columns["OR03015"];
                this.columnOR03016 = this.Columns["OR03016"];
                this.columnOR03017 = this.Columns["OR03017"];
                this.columnOR03018 = this.Columns["OR03018"];
                this.columnOR03019 = this.Columns["OR03019"];
                this.columnOR03020 = this.Columns["OR03020"];
                this.columnOR03021 = this.Columns["OR03021"];
                this.columnOR03022 = this.Columns["OR03022"];
                this.columnOR03023 = this.Columns["OR03023"];
                this.columnOR03024 = this.Columns["OR03024"];
                this.columnOR03025 = this.Columns["OR03025"];
                this.columnOR03026 = this.Columns["OR03026"];
                this.columnOR03027 = this.Columns["OR03027"];
                this.columnOR03028 = this.Columns["OR03028"];
                this.columnOR03029 = this.Columns["OR03029"];
                this.columnOR03030 = this.Columns["OR03030"];
                this.columnOR03031 = this.Columns["OR03031"];
                this.columnOR03032 = this.Columns["OR03032"];
                this.columnOR03033 = this.Columns["OR03033"];
                this.columnOR03034 = this.Columns["OR03034"];
                this.columnOR03035 = this.Columns["OR03035"];
                this.columnOR03036 = this.Columns["OR03036"];
                this.columnOR03037 = this.Columns["OR03037"];
                this.columnOR03038 = this.Columns["OR03038"];
                this.columnOR03039 = this.Columns["OR03039"];
                this.columnOR03040 = this.Columns["OR03040"];
                this.columnOR03041 = this.Columns["OR03041"];
                this.columnOR03042 = this.Columns["OR03042"];
                this.columnOR03043 = this.Columns["OR03043"];
                this.columnOR03044 = this.Columns["OR03044"];
                this.columnOR03045 = this.Columns["OR03045"];
                this.columnOR03046 = this.Columns["OR03046"];
                this.columnOR03047 = this.Columns["OR03047"];
                this.columnOR03048 = this.Columns["OR03048"];
                this.columnOR03049 = this.Columns["OR03049"];
                this.columnOR03050 = this.Columns["OR03050"];
                this.columnOR03051 = this.Columns["OR03051"];
                this.columnOR03052 = this.Columns["OR03052"];
                this.columnOR03053 = this.Columns["OR03053"];
                this.columnOR03054 = this.Columns["OR03054"];
                this.columnOR03055 = this.Columns["OR03055"];
                this.columnOR03056 = this.Columns["OR03056"];
                this.columnOR03057 = this.Columns["OR03057"];
                this.columnOR03058 = this.Columns["OR03058"];
                this.columnOR03059 = this.Columns["OR03059"];
                this.columnOR03060 = this.Columns["OR03060"];
                this.columnOR03061 = this.Columns["OR03061"];
                this.columnOR03062 = this.Columns["OR03062"];
                this.columnOR03063 = this.Columns["OR03063"];
                this.columnOR03064 = this.Columns["OR03064"];
                this.columnOR03065 = this.Columns["OR03065"];
                this.columnOR03066 = this.Columns["OR03066"];
                this.columnOR03067 = this.Columns["OR03067"];
                this.columnOR03068 = this.Columns["OR03068"];
                this.columnOR03069 = this.Columns["OR03069"];
                this.columnOR03070 = this.Columns["OR03070"];
                this.columnOR03071 = this.Columns["OR03071"];
                this.columnOR03072 = this.Columns["OR03072"];
                this.columnOR03073 = this.Columns["OR03073"];
                this.columnOR03074 = this.Columns["OR03074"];
                this.columnOR03075 = this.Columns["OR03075"];
                this.columnOR03076 = this.Columns["OR03076"];
                this.columnOR03077 = this.Columns["OR03077"];
                this.columnOR03078 = this.Columns["OR03078"];
                this.columnOR03079 = this.Columns["OR03079"];
                this.columnOR03080 = this.Columns["OR03080"];
                this.columnOR03081 = this.Columns["OR03081"];
                this.columnOR03082 = this.Columns["OR03082"];
                this.columnOR03083 = this.Columns["OR03083"];
                this.columnOR03084 = this.Columns["OR03084"];
                this.columnOR03085 = this.Columns["OR03085"];
                this.columnOR03086 = this.Columns["OR03086"];
                this.columnOR03087 = this.Columns["OR03087"];
                this.columnOR03088 = this.Columns["OR03088"];
            }

            public DSOAPend.OR030100Row NewOR030100Row()
            {
                return (DSOAPend.OR030100Row) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DSOAPend.OR030100Row(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.OR030100RowChangedEvent != null) && (this.OR030100RowChangedEvent != null))
                {
                    this.OR030100RowChangedEvent(this, new DSOAPend.OR030100RowChangeEvent((DSOAPend.OR030100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.OR030100RowChangingEvent != null) && (this.OR030100RowChangingEvent != null))
                {
                    this.OR030100RowChangingEvent(this, new DSOAPend.OR030100RowChangeEvent((DSOAPend.OR030100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.OR030100RowDeletedEvent != null) && (this.OR030100RowDeletedEvent != null))
                {
                    this.OR030100RowDeletedEvent(this, new DSOAPend.OR030100RowChangeEvent((DSOAPend.OR030100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.OR030100RowDeletingEvent != null) && (this.OR030100RowDeletingEvent != null))
                {
                    this.OR030100RowDeletingEvent(this, new DSOAPend.OR030100RowChangeEvent((DSOAPend.OR030100Row) e.Row, e.Action));
                }
            }

            public void RemoveOR030100Row(DSOAPend.OR030100Row row)
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

            public DSOAPend.OR030100Row this[int index]
            {
                get
                {
                    return (DSOAPend.OR030100Row) this.Rows[index];
                }
            }

            internal DataColumn OR03001Column
            {
                get
                {
                    return this.columnOR03001;
                }
            }

            internal DataColumn OR03002Column
            {
                get
                {
                    return this.columnOR03002;
                }
            }

            internal DataColumn OR03003Column
            {
                get
                {
                    return this.columnOR03003;
                }
            }

            internal DataColumn OR03004Column
            {
                get
                {
                    return this.columnOR03004;
                }
            }

            internal DataColumn OR03005Column
            {
                get
                {
                    return this.columnOR03005;
                }
            }

            internal DataColumn OR03006Column
            {
                get
                {
                    return this.columnOR03006;
                }
            }

            internal DataColumn OR03007Column
            {
                get
                {
                    return this.columnOR03007;
                }
            }

            internal DataColumn OR03008Column
            {
                get
                {
                    return this.columnOR03008;
                }
            }

            internal DataColumn OR03009Column
            {
                get
                {
                    return this.columnOR03009;
                }
            }

            internal DataColumn OR03010Column
            {
                get
                {
                    return this.columnOR03010;
                }
            }

            internal DataColumn OR03011Column
            {
                get
                {
                    return this.columnOR03011;
                }
            }

            internal DataColumn OR03012Column
            {
                get
                {
                    return this.columnOR03012;
                }
            }

            internal DataColumn OR03013Column
            {
                get
                {
                    return this.columnOR03013;
                }
            }

            internal DataColumn OR03014Column
            {
                get
                {
                    return this.columnOR03014;
                }
            }

            internal DataColumn OR03015Column
            {
                get
                {
                    return this.columnOR03015;
                }
            }

            internal DataColumn OR03016Column
            {
                get
                {
                    return this.columnOR03016;
                }
            }

            internal DataColumn OR03017Column
            {
                get
                {
                    return this.columnOR03017;
                }
            }

            internal DataColumn OR03018Column
            {
                get
                {
                    return this.columnOR03018;
                }
            }

            internal DataColumn OR03019Column
            {
                get
                {
                    return this.columnOR03019;
                }
            }

            internal DataColumn OR03020Column
            {
                get
                {
                    return this.columnOR03020;
                }
            }

            internal DataColumn OR03021Column
            {
                get
                {
                    return this.columnOR03021;
                }
            }

            internal DataColumn OR03022Column
            {
                get
                {
                    return this.columnOR03022;
                }
            }

            internal DataColumn OR03023Column
            {
                get
                {
                    return this.columnOR03023;
                }
            }

            internal DataColumn OR03024Column
            {
                get
                {
                    return this.columnOR03024;
                }
            }

            internal DataColumn OR03025Column
            {
                get
                {
                    return this.columnOR03025;
                }
            }

            internal DataColumn OR03026Column
            {
                get
                {
                    return this.columnOR03026;
                }
            }

            internal DataColumn OR03027Column
            {
                get
                {
                    return this.columnOR03027;
                }
            }

            internal DataColumn OR03028Column
            {
                get
                {
                    return this.columnOR03028;
                }
            }

            internal DataColumn OR03029Column
            {
                get
                {
                    return this.columnOR03029;
                }
            }

            internal DataColumn OR03030Column
            {
                get
                {
                    return this.columnOR03030;
                }
            }

            internal DataColumn OR03031Column
            {
                get
                {
                    return this.columnOR03031;
                }
            }

            internal DataColumn OR03032Column
            {
                get
                {
                    return this.columnOR03032;
                }
            }

            internal DataColumn OR03033Column
            {
                get
                {
                    return this.columnOR03033;
                }
            }

            internal DataColumn OR03034Column
            {
                get
                {
                    return this.columnOR03034;
                }
            }

            internal DataColumn OR03035Column
            {
                get
                {
                    return this.columnOR03035;
                }
            }

            internal DataColumn OR03036Column
            {
                get
                {
                    return this.columnOR03036;
                }
            }

            internal DataColumn OR03037Column
            {
                get
                {
                    return this.columnOR03037;
                }
            }

            internal DataColumn OR03038Column
            {
                get
                {
                    return this.columnOR03038;
                }
            }

            internal DataColumn OR03039Column
            {
                get
                {
                    return this.columnOR03039;
                }
            }

            internal DataColumn OR03040Column
            {
                get
                {
                    return this.columnOR03040;
                }
            }

            internal DataColumn OR03041Column
            {
                get
                {
                    return this.columnOR03041;
                }
            }

            internal DataColumn OR03042Column
            {
                get
                {
                    return this.columnOR03042;
                }
            }

            internal DataColumn OR03043Column
            {
                get
                {
                    return this.columnOR03043;
                }
            }

            internal DataColumn OR03044Column
            {
                get
                {
                    return this.columnOR03044;
                }
            }

            internal DataColumn OR03045Column
            {
                get
                {
                    return this.columnOR03045;
                }
            }

            internal DataColumn OR03046Column
            {
                get
                {
                    return this.columnOR03046;
                }
            }

            internal DataColumn OR03047Column
            {
                get
                {
                    return this.columnOR03047;
                }
            }

            internal DataColumn OR03048Column
            {
                get
                {
                    return this.columnOR03048;
                }
            }

            internal DataColumn OR03049Column
            {
                get
                {
                    return this.columnOR03049;
                }
            }

            internal DataColumn OR03050Column
            {
                get
                {
                    return this.columnOR03050;
                }
            }

            internal DataColumn OR03051Column
            {
                get
                {
                    return this.columnOR03051;
                }
            }

            internal DataColumn OR03052Column
            {
                get
                {
                    return this.columnOR03052;
                }
            }

            internal DataColumn OR03053Column
            {
                get
                {
                    return this.columnOR03053;
                }
            }

            internal DataColumn OR03054Column
            {
                get
                {
                    return this.columnOR03054;
                }
            }

            internal DataColumn OR03055Column
            {
                get
                {
                    return this.columnOR03055;
                }
            }

            internal DataColumn OR03056Column
            {
                get
                {
                    return this.columnOR03056;
                }
            }

            internal DataColumn OR03057Column
            {
                get
                {
                    return this.columnOR03057;
                }
            }

            internal DataColumn OR03058Column
            {
                get
                {
                    return this.columnOR03058;
                }
            }

            internal DataColumn OR03059Column
            {
                get
                {
                    return this.columnOR03059;
                }
            }

            internal DataColumn OR03060Column
            {
                get
                {
                    return this.columnOR03060;
                }
            }

            internal DataColumn OR03061Column
            {
                get
                {
                    return this.columnOR03061;
                }
            }

            internal DataColumn OR03062Column
            {
                get
                {
                    return this.columnOR03062;
                }
            }

            internal DataColumn OR03063Column
            {
                get
                {
                    return this.columnOR03063;
                }
            }

            internal DataColumn OR03064Column
            {
                get
                {
                    return this.columnOR03064;
                }
            }

            internal DataColumn OR03065Column
            {
                get
                {
                    return this.columnOR03065;
                }
            }

            internal DataColumn OR03066Column
            {
                get
                {
                    return this.columnOR03066;
                }
            }

            internal DataColumn OR03067Column
            {
                get
                {
                    return this.columnOR03067;
                }
            }

            internal DataColumn OR03068Column
            {
                get
                {
                    return this.columnOR03068;
                }
            }

            internal DataColumn OR03069Column
            {
                get
                {
                    return this.columnOR03069;
                }
            }

            internal DataColumn OR03070Column
            {
                get
                {
                    return this.columnOR03070;
                }
            }

            internal DataColumn OR03071Column
            {
                get
                {
                    return this.columnOR03071;
                }
            }

            internal DataColumn OR03072Column
            {
                get
                {
                    return this.columnOR03072;
                }
            }

            internal DataColumn OR03073Column
            {
                get
                {
                    return this.columnOR03073;
                }
            }

            internal DataColumn OR03074Column
            {
                get
                {
                    return this.columnOR03074;
                }
            }

            internal DataColumn OR03075Column
            {
                get
                {
                    return this.columnOR03075;
                }
            }

            internal DataColumn OR03076Column
            {
                get
                {
                    return this.columnOR03076;
                }
            }

            internal DataColumn OR03077Column
            {
                get
                {
                    return this.columnOR03077;
                }
            }

            internal DataColumn OR03078Column
            {
                get
                {
                    return this.columnOR03078;
                }
            }

            internal DataColumn OR03079Column
            {
                get
                {
                    return this.columnOR03079;
                }
            }

            internal DataColumn OR03080Column
            {
                get
                {
                    return this.columnOR03080;
                }
            }

            internal DataColumn OR03081Column
            {
                get
                {
                    return this.columnOR03081;
                }
            }

            internal DataColumn OR03082Column
            {
                get
                {
                    return this.columnOR03082;
                }
            }

            internal DataColumn OR03083Column
            {
                get
                {
                    return this.columnOR03083;
                }
            }

            internal DataColumn OR03084Column
            {
                get
                {
                    return this.columnOR03084;
                }
            }

            internal DataColumn OR03085Column
            {
                get
                {
                    return this.columnOR03085;
                }
            }

            internal DataColumn OR03086Column
            {
                get
                {
                    return this.columnOR03086;
                }
            }

            internal DataColumn OR03087Column
            {
                get
                {
                    return this.columnOR03087;
                }
            }

            internal DataColumn OR03088Column
            {
                get
                {
                    return this.columnOR03088;
                }
            }
        }

        [DebuggerStepThrough]
        public class OR030100Row : DataRow
        {
            private DSOAPend.OR030100DataTable tableOR030100;

            internal OR030100Row(DataRowBuilder rb) : base(rb)
            {
                this.tableOR030100 = (DSOAPend.OR030100DataTable) this.Table;
            }

            public string OR03001
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03001Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03001Column] = value;
                }
            }

            public string OR03002
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03002Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03002Column] = value;
                }
            }

            public string OR03003
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03003Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03003Column] = value;
                }
            }

            public int OR03004
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR030100.OR03004Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03004Column] = value;
                }
            }

            public string OR03005
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03005Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03005Column] = value;
                }
            }

            public string OR03006
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03006Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03006Column] = value;
                }
            }

            public string OR03007
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03007Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03007Column] = value;
                }
            }

            public decimal OR03008
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03008Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03008Column] = value;
                }
            }

            public decimal OR03009
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03009Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03009Column] = value;
                }
            }

            public int OR03010
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR030100.OR03010Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03010Column] = value;
                }
            }

            public decimal OR03011
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03011Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03011Column] = value;
                }
            }

            public decimal OR03012
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03012Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03012Column] = value;
                }
            }

            public int OR03013
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR030100.OR03013Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03013Column] = value;
                }
            }

            public int OR03014
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR030100.OR03014Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03014Column] = value;
                }
            }

            public string OR03015
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03015Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03015Column] = value;
                }
            }

            public int OR03016
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR030100.OR03016Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03016Column] = value;
                }
            }

            public decimal OR03017
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03017Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03017Column] = value;
                }
            }

            public decimal OR03018
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03018Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03018Column] = value;
                }
            }

            public DateTime OR03019
            {
                get
                {
                    return DateType.FromObject(this[this.tableOR030100.OR03019Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03019Column] = value;
                }
            }

            public decimal OR03020
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03020Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03020Column] = value;
                }
            }

            public decimal OR03021
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03021Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03021Column] = value;
                }
            }

            public decimal OR03022
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03022Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03022Column] = value;
                }
            }

            public decimal OR03023
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03023Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03023Column] = value;
                }
            }

            public decimal OR03024
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03024Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03024Column] = value;
                }
            }

            public int OR03025
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR030100.OR03025Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03025Column] = value;
                }
            }

            public int OR03026
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR030100.OR03026Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03026Column] = value;
                }
            }

            public int OR03027
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR030100.OR03027Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03027Column] = value;
                }
            }

            public string OR03028
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03028Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03028Column] = value;
                }
            }

            public int OR03029
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR030100.OR03029Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03029Column] = value;
                }
            }

            public int OR03030
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR030100.OR03030Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03030Column] = value;
                }
            }

            public int OR03031
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR030100.OR03031Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03031Column] = value;
                }
            }

            public byte[] OR03032
            {
                get
                {
                    return (byte[]) this[this.tableOR030100.OR03032Column];
                }
                set
                {
                    this[this.tableOR030100.OR03032Column] = value;
                }
            }

            public decimal OR03033
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03033Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03033Column] = value;
                }
            }

            public string OR03034
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03034Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03034Column] = value;
                }
            }

            public string OR03035
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03035Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03035Column] = value;
                }
            }

            public decimal OR03036
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03036Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03036Column] = value;
                }
            }

            public DateTime OR03037
            {
                get
                {
                    return DateType.FromObject(this[this.tableOR030100.OR03037Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03037Column] = value;
                }
            }

            public string OR03038
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03038Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03038Column] = value;
                }
            }

            public int OR03039
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR030100.OR03039Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03039Column] = value;
                }
            }

            public decimal OR03040
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03040Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03040Column] = value;
                }
            }

            public decimal OR03041
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03041Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03041Column] = value;
                }
            }

            public DateTime OR03042
            {
                get
                {
                    return DateType.FromObject(this[this.tableOR030100.OR03042Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03042Column] = value;
                }
            }

            public decimal OR03043
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03043Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03043Column] = value;
                }
            }

            public decimal OR03044
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03044Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03044Column] = value;
                }
            }

            public decimal OR03045
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03045Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03045Column] = value;
                }
            }

            public string OR03046
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03046Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03046Column] = value;
                }
            }

            public decimal OR03047
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03047Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03047Column] = value;
                }
            }

            public decimal OR03048
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03048Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03048Column] = value;
                }
            }

            public decimal OR03049
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03049Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03049Column] = value;
                }
            }

            public decimal OR03050
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03050Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03050Column] = value;
                }
            }

            public string OR03051
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03051Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03051Column] = value;
                }
            }

            public string OR03052
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03052Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03052Column] = value;
                }
            }

            public decimal OR03053
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03053Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03053Column] = value;
                }
            }

            public decimal OR03054
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03054Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03054Column] = value;
                }
            }

            public string OR03055
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03055Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03055Column] = value;
                }
            }

            public decimal OR03056
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03056Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03056Column] = value;
                }
            }

            public decimal OR03057
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03057Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03057Column] = value;
                }
            }

            public decimal OR03058
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03058Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03058Column] = value;
                }
            }

            public decimal OR03059
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03059Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03059Column] = value;
                }
            }

            public decimal OR03060
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03060Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03060Column] = value;
                }
            }

            public int OR03061
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR030100.OR03061Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03061Column] = value;
                }
            }

            public int OR03062
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR030100.OR03062Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03062Column] = value;
                }
            }

            public decimal OR03063
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03063Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03063Column] = value;
                }
            }

            public decimal OR03064
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03064Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03064Column] = value;
                }
            }

            public string OR03065
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03065Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03065Column] = value;
                }
            }

            public string OR03066
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03066Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03066Column] = value;
                }
            }

            public string OR03067
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03067Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03067Column] = value;
                }
            }

            public string OR03068
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03068Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03068Column] = value;
                }
            }

            public int OR03069
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR030100.OR03069Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03069Column] = value;
                }
            }

            public string OR03070
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03070Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03070Column] = value;
                }
            }

            public string OR03071
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03071Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03071Column] = value;
                }
            }

            public string OR03072
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03072Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03072Column] = value;
                }
            }

            public string OR03073
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03073Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03073Column] = value;
                }
            }

            public string OR03074
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03074Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03074Column] = value;
                }
            }

            public string OR03075
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03075Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03075Column] = value;
                }
            }

            public decimal OR03076
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03076Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03076Column] = value;
                }
            }

            public decimal OR03077
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03077Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03077Column] = value;
                }
            }

            public string OR03078
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03078Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03078Column] = value;
                }
            }

            public decimal OR03079
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03079Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03079Column] = value;
                }
            }

            public string OR03080
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03080Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03080Column] = value;
                }
            }

            public decimal OR03081
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03081Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03081Column] = value;
                }
            }

            public string OR03082
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03082Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03082Column] = value;
                }
            }

            public int OR03083
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR030100.OR03083Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03083Column] = value;
                }
            }

            public string OR03084
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03084Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03084Column] = value;
                }
            }

            public int OR03085
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR030100.OR03085Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03085Column] = value;
                }
            }

            public decimal OR03086
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03086Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03086Column] = value;
                }
            }

            public string OR03087
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03087Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03087Column] = value;
                }
            }

            public decimal OR03088
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableOR030100.OR03088Column]);
                }
                set
                {
                    this[this.tableOR030100.OR03088Column] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class OR030100RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DSOAPend.OR030100Row eventRow;

            public OR030100RowChangeEvent(DSOAPend.OR030100Row row, DataRowAction action)
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

            public DSOAPend.OR030100Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OR030100RowChangeEventHandler(object sender, DSOAPend.OR030100RowChangeEvent e);

        [DebuggerStepThrough]
        public class OR040100DataTable : DataTable, IEnumerable
        {
            private DataColumn columnOR04001;
            private DataColumn columnOR04002;
            private DataColumn columnOR04003;
            private DataColumn columnOR04004;
            private DataColumn columnOR04005;
            private DataColumn columnOR04006;
            private DataColumn columnOR04007;
            private DataColumn columnOR04008;
            private DataColumn columnOR04009;
            private DataColumn columnOR04010;
            private DataColumn columnOR04011;
            private DataColumn columnOR04012;
            private DataColumn columnOR04013;
            private DataColumn columnOR04014;

            public event DSOAPend.OR040100RowChangeEventHandler OR040100RowChanged;

            public event DSOAPend.OR040100RowChangeEventHandler OR040100RowChanging;

            public event DSOAPend.OR040100RowChangeEventHandler OR040100RowDeleted;

            public event DSOAPend.OR040100RowChangeEventHandler OR040100RowDeleting;

            internal OR040100DataTable() : base("OR040100")
            {
                this.InitClass();
            }

            internal OR040100DataTable(DataTable table) : base(table.TableName)
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

            public void AddOR040100Row(DSOAPend.OR040100Row row)
            {
                this.Rows.Add(row);
            }

            public DSOAPend.OR040100Row AddOR040100Row(string OR04001, string OR04002, string OR04003, string OR04004, string OR04005, string OR04006, string OR04007, string OR04008, string OR04009, string OR04010, string OR04011, string OR04012, int OR04013, string OR04014)
            {
                DSOAPend.OR040100Row row = (DSOAPend.OR040100Row) this.NewRow();
                row.ItemArray = new object[] { OR04001, OR04002, OR04003, OR04004, OR04005, OR04006, OR04007, OR04008, OR04009, OR04010, OR04011, OR04012, OR04013, OR04014 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DSOAPend.OR040100DataTable table = (DSOAPend.OR040100DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DSOAPend.OR040100DataTable();
            }

            public DSOAPend.OR040100Row FindByOR04001(string OR04001)
            {
                return (DSOAPend.OR040100Row) this.Rows.Find(new object[] { OR04001 });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DSOAPend.OR040100Row);
            }

            private void InitClass()
            {
                this.columnOR04001 = new DataColumn("OR04001", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR04001);
                this.columnOR04002 = new DataColumn("OR04002", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR04002);
                this.columnOR04003 = new DataColumn("OR04003", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR04003);
                this.columnOR04004 = new DataColumn("OR04004", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR04004);
                this.columnOR04005 = new DataColumn("OR04005", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR04005);
                this.columnOR04006 = new DataColumn("OR04006", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR04006);
                this.columnOR04007 = new DataColumn("OR04007", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR04007);
                this.columnOR04008 = new DataColumn("OR04008", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR04008);
                this.columnOR04009 = new DataColumn("OR04009", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR04009);
                this.columnOR04010 = new DataColumn("OR04010", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR04010);
                this.columnOR04011 = new DataColumn("OR04011", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR04011);
                this.columnOR04012 = new DataColumn("OR04012", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR04012);
                this.columnOR04013 = new DataColumn("OR04013", typeof(int), null, MappingType.Element);
                this.Columns.Add(this.columnOR04013);
                this.columnOR04014 = new DataColumn("OR04014", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnOR04014);
                this.Constraints.Add(new UniqueConstraint("DSOAPendKey1", new DataColumn[] { this.columnOR04001 }, true));
                this.columnOR04001.AllowDBNull = false;
                this.columnOR04001.Unique = true;
                this.columnOR04002.AllowDBNull = false;
                this.columnOR04003.AllowDBNull = false;
                this.columnOR04004.AllowDBNull = false;
                this.columnOR04005.AllowDBNull = false;
                this.columnOR04006.AllowDBNull = false;
                this.columnOR04007.AllowDBNull = false;
                this.columnOR04008.AllowDBNull = false;
                this.columnOR04009.AllowDBNull = false;
                this.columnOR04010.AllowDBNull = false;
                this.columnOR04011.AllowDBNull = false;
                this.columnOR04012.AllowDBNull = false;
                this.columnOR04013.AllowDBNull = false;
                this.columnOR04014.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnOR04001 = this.Columns["OR04001"];
                this.columnOR04002 = this.Columns["OR04002"];
                this.columnOR04003 = this.Columns["OR04003"];
                this.columnOR04004 = this.Columns["OR04004"];
                this.columnOR04005 = this.Columns["OR04005"];
                this.columnOR04006 = this.Columns["OR04006"];
                this.columnOR04007 = this.Columns["OR04007"];
                this.columnOR04008 = this.Columns["OR04008"];
                this.columnOR04009 = this.Columns["OR04009"];
                this.columnOR04010 = this.Columns["OR04010"];
                this.columnOR04011 = this.Columns["OR04011"];
                this.columnOR04012 = this.Columns["OR04012"];
                this.columnOR04013 = this.Columns["OR04013"];
                this.columnOR04014 = this.Columns["OR04014"];
            }

            public DSOAPend.OR040100Row NewOR040100Row()
            {
                return (DSOAPend.OR040100Row) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DSOAPend.OR040100Row(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.OR040100RowChangedEvent != null) && (this.OR040100RowChangedEvent != null))
                {
                    this.OR040100RowChangedEvent(this, new DSOAPend.OR040100RowChangeEvent((DSOAPend.OR040100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.OR040100RowChangingEvent != null) && (this.OR040100RowChangingEvent != null))
                {
                    this.OR040100RowChangingEvent(this, new DSOAPend.OR040100RowChangeEvent((DSOAPend.OR040100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.OR040100RowDeletedEvent != null) && (this.OR040100RowDeletedEvent != null))
                {
                    this.OR040100RowDeletedEvent(this, new DSOAPend.OR040100RowChangeEvent((DSOAPend.OR040100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.OR040100RowDeletingEvent != null) && (this.OR040100RowDeletingEvent != null))
                {
                    this.OR040100RowDeletingEvent(this, new DSOAPend.OR040100RowChangeEvent((DSOAPend.OR040100Row) e.Row, e.Action));
                }
            }

            public void RemoveOR040100Row(DSOAPend.OR040100Row row)
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

            public DSOAPend.OR040100Row this[int index]
            {
                get
                {
                    return (DSOAPend.OR040100Row) this.Rows[index];
                }
            }

            internal DataColumn OR04001Column
            {
                get
                {
                    return this.columnOR04001;
                }
            }

            internal DataColumn OR04002Column
            {
                get
                {
                    return this.columnOR04002;
                }
            }

            internal DataColumn OR04003Column
            {
                get
                {
                    return this.columnOR04003;
                }
            }

            internal DataColumn OR04004Column
            {
                get
                {
                    return this.columnOR04004;
                }
            }

            internal DataColumn OR04005Column
            {
                get
                {
                    return this.columnOR04005;
                }
            }

            internal DataColumn OR04006Column
            {
                get
                {
                    return this.columnOR04006;
                }
            }

            internal DataColumn OR04007Column
            {
                get
                {
                    return this.columnOR04007;
                }
            }

            internal DataColumn OR04008Column
            {
                get
                {
                    return this.columnOR04008;
                }
            }

            internal DataColumn OR04009Column
            {
                get
                {
                    return this.columnOR04009;
                }
            }

            internal DataColumn OR04010Column
            {
                get
                {
                    return this.columnOR04010;
                }
            }

            internal DataColumn OR04011Column
            {
                get
                {
                    return this.columnOR04011;
                }
            }

            internal DataColumn OR04012Column
            {
                get
                {
                    return this.columnOR04012;
                }
            }

            internal DataColumn OR04013Column
            {
                get
                {
                    return this.columnOR04013;
                }
            }

            internal DataColumn OR04014Column
            {
                get
                {
                    return this.columnOR04014;
                }
            }
        }

        [DebuggerStepThrough]
        public class OR040100Row : DataRow
        {
            private DSOAPend.OR040100DataTable tableOR040100;

            internal OR040100Row(DataRowBuilder rb) : base(rb)
            {
                this.tableOR040100 = (DSOAPend.OR040100DataTable) this.Table;
            }

            public string OR04001
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR040100.OR04001Column]);
                }
                set
                {
                    this[this.tableOR040100.OR04001Column] = value;
                }
            }

            public string OR04002
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR040100.OR04002Column]);
                }
                set
                {
                    this[this.tableOR040100.OR04002Column] = value;
                }
            }

            public string OR04003
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR040100.OR04003Column]);
                }
                set
                {
                    this[this.tableOR040100.OR04003Column] = value;
                }
            }

            public string OR04004
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR040100.OR04004Column]);
                }
                set
                {
                    this[this.tableOR040100.OR04004Column] = value;
                }
            }

            public string OR04005
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR040100.OR04005Column]);
                }
                set
                {
                    this[this.tableOR040100.OR04005Column] = value;
                }
            }

            public string OR04006
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR040100.OR04006Column]);
                }
                set
                {
                    this[this.tableOR040100.OR04006Column] = value;
                }
            }

            public string OR04007
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR040100.OR04007Column]);
                }
                set
                {
                    this[this.tableOR040100.OR04007Column] = value;
                }
            }

            public string OR04008
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR040100.OR04008Column]);
                }
                set
                {
                    this[this.tableOR040100.OR04008Column] = value;
                }
            }

            public string OR04009
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR040100.OR04009Column]);
                }
                set
                {
                    this[this.tableOR040100.OR04009Column] = value;
                }
            }

            public string OR04010
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR040100.OR04010Column]);
                }
                set
                {
                    this[this.tableOR040100.OR04010Column] = value;
                }
            }

            public string OR04011
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR040100.OR04011Column]);
                }
                set
                {
                    this[this.tableOR040100.OR04011Column] = value;
                }
            }

            public string OR04012
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR040100.OR04012Column]);
                }
                set
                {
                    this[this.tableOR040100.OR04012Column] = value;
                }
            }

            public int OR04013
            {
                get
                {
                    return IntegerType.FromObject(this[this.tableOR040100.OR04013Column]);
                }
                set
                {
                    this[this.tableOR040100.OR04013Column] = value;
                }
            }

            public string OR04014
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR040100.OR04014Column]);
                }
                set
                {
                    this[this.tableOR040100.OR04014Column] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class OR040100RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DSOAPend.OR040100Row eventRow;

            public OR040100RowChangeEvent(DSOAPend.OR040100Row row, DataRowAction action)
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

            public DSOAPend.OR040100Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OR040100RowChangeEventHandler(object sender, DSOAPend.OR040100RowChangeEvent e);
    }
}

