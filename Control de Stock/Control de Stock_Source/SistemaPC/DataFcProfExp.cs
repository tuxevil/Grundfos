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
    public class DataFcProfExp : DataSet
    {
        private OR010100DataTable tableOR010100;
        private OR040100DataTable tableOR040100;
        private PC1TmpItemFcProExpDataTable tablePC1TmpItemFcProExp;
        private PC1TmpOVFcProExpDataTable tablePC1TmpOVFcProExp;
        private SL010100DataTable tableSL010100;

        public DataFcProfExp()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DataFcProfExp(SerializationInfo info, StreamingContext context)
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
                if (dataSet.Tables["OR040100"] != null)
                {
                    this.Tables.Add(new OR040100DataTable(dataSet.Tables["OR040100"]));
                }
                if (dataSet.Tables["SL010100"] != null)
                {
                    this.Tables.Add(new SL010100DataTable(dataSet.Tables["SL010100"]));
                }
                if (dataSet.Tables["PC1TmpOVFcProExp"] != null)
                {
                    this.Tables.Add(new PC1TmpOVFcProExpDataTable(dataSet.Tables["PC1TmpOVFcProExp"]));
                }
                if (dataSet.Tables["PC1TmpItemFcProExp"] != null)
                {
                    this.Tables.Add(new PC1TmpItemFcProExpDataTable(dataSet.Tables["PC1TmpItemFcProExp"]));
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
            DataFcProfExp exp = (DataFcProfExp) base.Clone();
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
            this.DataSetName = "DataFcProfExp";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DataFcProfExp.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableOR010100 = new OR010100DataTable();
            this.Tables.Add(this.tableOR010100);
            this.tableOR040100 = new OR040100DataTable();
            this.Tables.Add(this.tableOR040100);
            this.tableSL010100 = new SL010100DataTable();
            this.Tables.Add(this.tableSL010100);
            this.tablePC1TmpOVFcProExp = new PC1TmpOVFcProExpDataTable();
            this.Tables.Add(this.tablePC1TmpOVFcProExp);
            this.tablePC1TmpItemFcProExp = new PC1TmpItemFcProExpDataTable();
            this.Tables.Add(this.tablePC1TmpItemFcProExp);
        }

        internal void InitVars()
        {
            this.tableOR010100 = (OR010100DataTable) this.Tables["OR010100"];
            if (this.tableOR010100 != null)
            {
                this.tableOR010100.InitVars();
            }
            this.tableOR040100 = (OR040100DataTable) this.Tables["OR040100"];
            if (this.tableOR040100 != null)
            {
                this.tableOR040100.InitVars();
            }
            this.tableSL010100 = (SL010100DataTable) this.Tables["SL010100"];
            if (this.tableSL010100 != null)
            {
                this.tableSL010100.InitVars();
            }
            this.tablePC1TmpOVFcProExp = (PC1TmpOVFcProExpDataTable) this.Tables["PC1TmpOVFcProExp"];
            if (this.tablePC1TmpOVFcProExp != null)
            {
                this.tablePC1TmpOVFcProExp.InitVars();
            }
            this.tablePC1TmpItemFcProExp = (PC1TmpItemFcProExpDataTable) this.Tables["PC1TmpItemFcProExp"];
            if (this.tablePC1TmpItemFcProExp != null)
            {
                this.tablePC1TmpItemFcProExp.InitVars();
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
            if (dataSet.Tables["OR040100"] != null)
            {
                this.Tables.Add(new OR040100DataTable(dataSet.Tables["OR040100"]));
            }
            if (dataSet.Tables["SL010100"] != null)
            {
                this.Tables.Add(new SL010100DataTable(dataSet.Tables["SL010100"]));
            }
            if (dataSet.Tables["PC1TmpOVFcProExp"] != null)
            {
                this.Tables.Add(new PC1TmpOVFcProExpDataTable(dataSet.Tables["PC1TmpOVFcProExp"]));
            }
            if (dataSet.Tables["PC1TmpItemFcProExp"] != null)
            {
                this.Tables.Add(new PC1TmpItemFcProExpDataTable(dataSet.Tables["PC1TmpItemFcProExp"]));
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

        private bool ShouldSerializeOR040100()
        {
            return false;
        }

        private bool ShouldSerializePC1TmpItemFcProExp()
        {
            return false;
        }

        private bool ShouldSerializePC1TmpOVFcProExp()
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OR010100DataTable OR010100
        {
            get
            {
                return this.tableOR010100;
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PC1TmpItemFcProExpDataTable PC1TmpItemFcProExp
        {
            get
            {
                return this.tablePC1TmpItemFcProExp;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PC1TmpOVFcProExpDataTable PC1TmpOVFcProExp
        {
            get
            {
                return this.tablePC1TmpOVFcProExp;
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

            public event DataFcProfExp.OR010100RowChangeEventHandler OR010100RowChanged;

            public event DataFcProfExp.OR010100RowChangeEventHandler OR010100RowChanging;

            public event DataFcProfExp.OR010100RowChangeEventHandler OR010100RowDeleted;

            public event DataFcProfExp.OR010100RowChangeEventHandler OR010100RowDeleting;

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

            public void AddOR010100Row(DataFcProfExp.OR010100Row row)
            {
                this.Rows.Add(row);
            }

            public DataFcProfExp.OR010100Row AddOR010100Row(string OR01001, int OR01002, string OR01003, string OR01004, string OR01005, string OR01006, int OR01007, int OR01008, int OR01009, int OR01010, int OR01011, int OR01012, int OR01013, int OR01014, DateTime OR01015, DateTime OR01016, string OR01017, string OR01018, string OR01019, string OR01020, string OR01021, DateTime OR01022, string OR01023, decimal OR01024, string OR01025, int OR01026, int OR01027, int OR01028, int OR01029, int OR01030, int OR01031, int OR01032, int OR01033, decimal OR01034, decimal OR01035, decimal OR01036, decimal OR01037, string OR01038, DateTime OR01039, DateTime OR01040, decimal OR01041, decimal OR01042, decimal OR01043, decimal OR01044, string OR01045, decimal OR01046, string OR01047, decimal OR01048, string OR01049, string OR01050, string OR01051, string OR01052, string OR01053, string OR01054, string OR01055, string OR01056, decimal OR01057, decimal OR01058, decimal OR01059, decimal OR01060, decimal OR01061, string OR01062, decimal OR01063, decimal OR01064, int OR01065, string OR01066, decimal OR01067, string OR01068, string OR01069, string OR01070, int OR01071, string OR01072, string OR01073, DateTime OR01074, DateTime OR01075, string OR01076, DateTime OR01077, string OR01078, string OR01079, int OR01080, int OR01081, string OR01082, string OR01083, string OR01084, string OR01085, string OR01086, string OR01087, string OR01088, string OR01089, string OR01090, int OR01091, int OR01092, int OR01093, int OR01094, string OR01095, string OR01096, DateTime OR01097, string OR01098, string OR01099, int OR01100, string OR01101, int OR01102, string OR01103, string OR01104, string OR01105, string OR01106, string OR01107, string OR01108, string OR01109, decimal OR01110, string OR01111, decimal OR01112, string OR01113, decimal OR01114, string OR01115, int OR01116, string OR01117, string OR01118, string OR01119, string OR01120, string OR01121, string OR01122, string OR01123, string OR01124, string OR01125, string OR01126, decimal OR01127, string OR01128, string OR01129, string OR01130, DateTime OR01131, string OR01132, string OR01133, string OR01134, string OR01135, string OR01136, string OR01137, decimal OR01138, string OR01139, decimal OR01140, string OR01141, string OR01142, string OR01143, string OR01144, string OR01145, string OR01146)
            {
                DataFcProfExp.OR010100Row row = (DataFcProfExp.OR010100Row) this.NewRow();
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
                DataFcProfExp.OR010100DataTable table = (DataFcProfExp.OR010100DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataFcProfExp.OR010100DataTable();
            }

            public DataFcProfExp.OR010100Row FindByOR01001(string OR01001)
            {
                return (DataFcProfExp.OR010100Row) this.Rows.Find(new object[] { OR01001 });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataFcProfExp.OR010100Row);
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
                this.Constraints.Add(new UniqueConstraint("DataFcProfExpKey1", new DataColumn[] { this.columnOR01001 }, true));
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

            public DataFcProfExp.OR010100Row NewOR010100Row()
            {
                return (DataFcProfExp.OR010100Row) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataFcProfExp.OR010100Row(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.OR010100RowChangedEvent != null) && (this.OR010100RowChangedEvent != null))
                {
                    this.OR010100RowChangedEvent(this, new DataFcProfExp.OR010100RowChangeEvent((DataFcProfExp.OR010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.OR010100RowChangingEvent != null) && (this.OR010100RowChangingEvent != null))
                {
                    this.OR010100RowChangingEvent(this, new DataFcProfExp.OR010100RowChangeEvent((DataFcProfExp.OR010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.OR010100RowDeletedEvent != null) && (this.OR010100RowDeletedEvent != null))
                {
                    this.OR010100RowDeletedEvent(this, new DataFcProfExp.OR010100RowChangeEvent((DataFcProfExp.OR010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.OR010100RowDeletingEvent != null) && (this.OR010100RowDeletingEvent != null))
                {
                    this.OR010100RowDeletingEvent(this, new DataFcProfExp.OR010100RowChangeEvent((DataFcProfExp.OR010100Row) e.Row, e.Action));
                }
            }

            public void RemoveOR010100Row(DataFcProfExp.OR010100Row row)
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

            public DataFcProfExp.OR010100Row this[int index]
            {
                get
                {
                    return (DataFcProfExp.OR010100Row) this.Rows[index];
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
            private DataFcProfExp.OR010100DataTable tableOR010100;

            internal OR010100Row(DataRowBuilder rb) : base(rb)
            {
                this.tableOR010100 = (DataFcProfExp.OR010100DataTable) this.Table;
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
            private DataFcProfExp.OR010100Row eventRow;

            public OR010100RowChangeEvent(DataFcProfExp.OR010100Row row, DataRowAction action)
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

            public DataFcProfExp.OR010100Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OR010100RowChangeEventHandler(object sender, DataFcProfExp.OR010100RowChangeEvent e);

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

            public event DataFcProfExp.OR040100RowChangeEventHandler OR040100RowChanged;

            public event DataFcProfExp.OR040100RowChangeEventHandler OR040100RowChanging;

            public event DataFcProfExp.OR040100RowChangeEventHandler OR040100RowDeleted;

            public event DataFcProfExp.OR040100RowChangeEventHandler OR040100RowDeleting;

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

            public void AddOR040100Row(DataFcProfExp.OR040100Row row)
            {
                this.Rows.Add(row);
            }

            public DataFcProfExp.OR040100Row AddOR040100Row(string OR04001, string OR04002, string OR04003, string OR04004, string OR04005, string OR04006, string OR04007, string OR04008, string OR04009, string OR04010, string OR04011, string OR04012, int OR04013, string OR04014)
            {
                DataFcProfExp.OR040100Row row = (DataFcProfExp.OR040100Row) this.NewRow();
                row.ItemArray = new object[] { OR04001, OR04002, OR04003, OR04004, OR04005, OR04006, OR04007, OR04008, OR04009, OR04010, OR04011, OR04012, OR04013, OR04014 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataFcProfExp.OR040100DataTable table = (DataFcProfExp.OR040100DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataFcProfExp.OR040100DataTable();
            }

            public DataFcProfExp.OR040100Row FindByOR04001(string OR04001)
            {
                return (DataFcProfExp.OR040100Row) this.Rows.Find(new object[] { OR04001 });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataFcProfExp.OR040100Row);
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
                this.Constraints.Add(new UniqueConstraint("DataFcProfExpKey3", new DataColumn[] { this.columnOR04001 }, true));
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

            public DataFcProfExp.OR040100Row NewOR040100Row()
            {
                return (DataFcProfExp.OR040100Row) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataFcProfExp.OR040100Row(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.OR040100RowChangedEvent != null) && (this.OR040100RowChangedEvent != null))
                {
                    this.OR040100RowChangedEvent(this, new DataFcProfExp.OR040100RowChangeEvent((DataFcProfExp.OR040100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.OR040100RowChangingEvent != null) && (this.OR040100RowChangingEvent != null))
                {
                    this.OR040100RowChangingEvent(this, new DataFcProfExp.OR040100RowChangeEvent((DataFcProfExp.OR040100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.OR040100RowDeletedEvent != null) && (this.OR040100RowDeletedEvent != null))
                {
                    this.OR040100RowDeletedEvent(this, new DataFcProfExp.OR040100RowChangeEvent((DataFcProfExp.OR040100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.OR040100RowDeletingEvent != null) && (this.OR040100RowDeletingEvent != null))
                {
                    this.OR040100RowDeletingEvent(this, new DataFcProfExp.OR040100RowChangeEvent((DataFcProfExp.OR040100Row) e.Row, e.Action));
                }
            }

            public void RemoveOR040100Row(DataFcProfExp.OR040100Row row)
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

            public DataFcProfExp.OR040100Row this[int index]
            {
                get
                {
                    return (DataFcProfExp.OR040100Row) this.Rows[index];
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
            private DataFcProfExp.OR040100DataTable tableOR040100;

            internal OR040100Row(DataRowBuilder rb) : base(rb)
            {
                this.tableOR040100 = (DataFcProfExp.OR040100DataTable) this.Table;
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
            private DataFcProfExp.OR040100Row eventRow;

            public OR040100RowChangeEvent(DataFcProfExp.OR040100Row row, DataRowAction action)
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

            public DataFcProfExp.OR040100Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OR040100RowChangeEventHandler(object sender, DataFcProfExp.OR040100RowChangeEvent e);

        [DebuggerStepThrough]
        public class PC1TmpItemFcProExpDataTable : DataTable, IEnumerable
        {
            private DataColumn columnCantidad;
            private DataColumn columnCodigo;
            private DataColumn columnDescripcion;
            private DataColumn columnFechaConf;
            private DataColumn columnLinea;
            private DataColumn columnNroOV;
            private DataColumn columnPrecioUnit;
            private DataColumn columnSeleccion;

            public event DataFcProfExp.PC1TmpItemFcProExpRowChangeEventHandler PC1TmpItemFcProExpRowChanged;

            public event DataFcProfExp.PC1TmpItemFcProExpRowChangeEventHandler PC1TmpItemFcProExpRowChanging;

            public event DataFcProfExp.PC1TmpItemFcProExpRowChangeEventHandler PC1TmpItemFcProExpRowDeleted;

            public event DataFcProfExp.PC1TmpItemFcProExpRowChangeEventHandler PC1TmpItemFcProExpRowDeleting;

            internal PC1TmpItemFcProExpDataTable() : base("PC1TmpItemFcProExp")
            {
                this.InitClass();
            }

            internal PC1TmpItemFcProExpDataTable(DataTable table) : base(table.TableName)
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

            public void AddPC1TmpItemFcProExpRow(DataFcProfExp.PC1TmpItemFcProExpRow row)
            {
                this.Rows.Add(row);
            }

            public DataFcProfExp.PC1TmpItemFcProExpRow AddPC1TmpItemFcProExpRow(string NroOV, string Linea, string Codigo, string Descripcion, decimal Cantidad, DateTime FechaConf, decimal PrecioUnit, bool Seleccion)
            {
                DataFcProfExp.PC1TmpItemFcProExpRow row = (DataFcProfExp.PC1TmpItemFcProExpRow) this.NewRow();
                row.ItemArray = new object[] { NroOV, Linea, Codigo, Descripcion, Cantidad, FechaConf, PrecioUnit, Seleccion };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataFcProfExp.PC1TmpItemFcProExpDataTable table = (DataFcProfExp.PC1TmpItemFcProExpDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataFcProfExp.PC1TmpItemFcProExpDataTable();
            }

            public DataFcProfExp.PC1TmpItemFcProExpRow FindByNroOVLinea(string NroOV, string Linea)
            {
                return (DataFcProfExp.PC1TmpItemFcProExpRow) this.Rows.Find(new object[] { NroOV, Linea });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataFcProfExp.PC1TmpItemFcProExpRow);
            }

            private void InitClass()
            {
                this.columnNroOV = new DataColumn("NroOV", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOV);
                this.columnLinea = new DataColumn("Linea", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnLinea);
                this.columnCodigo = new DataColumn("Codigo", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCodigo);
                this.columnDescripcion = new DataColumn("Descripcion", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnDescripcion);
                this.columnCantidad = new DataColumn("Cantidad", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnCantidad);
                this.columnFechaConf = new DataColumn("FechaConf", typeof(DateTime), null, MappingType.Element);
                this.Columns.Add(this.columnFechaConf);
                this.columnPrecioUnit = new DataColumn("PrecioUnit", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnPrecioUnit);
                this.columnSeleccion = new DataColumn("Seleccion", typeof(bool), null, MappingType.Element);
                this.Columns.Add(this.columnSeleccion);
                this.Constraints.Add(new UniqueConstraint("DataFcProfExpKey2", new DataColumn[] { this.columnNroOV, this.columnLinea }, true));
                this.columnNroOV.AllowDBNull = false;
                this.columnLinea.AllowDBNull = false;
                this.columnCodigo.AllowDBNull = false;
                this.columnDescripcion.AllowDBNull = false;
                this.columnCantidad.AllowDBNull = false;
                this.columnFechaConf.AllowDBNull = false;
                this.columnPrecioUnit.AllowDBNull = false;
                this.columnSeleccion.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnNroOV = this.Columns["NroOV"];
                this.columnLinea = this.Columns["Linea"];
                this.columnCodigo = this.Columns["Codigo"];
                this.columnDescripcion = this.Columns["Descripcion"];
                this.columnCantidad = this.Columns["Cantidad"];
                this.columnFechaConf = this.Columns["FechaConf"];
                this.columnPrecioUnit = this.Columns["PrecioUnit"];
                this.columnSeleccion = this.Columns["Seleccion"];
            }

            public DataFcProfExp.PC1TmpItemFcProExpRow NewPC1TmpItemFcProExpRow()
            {
                return (DataFcProfExp.PC1TmpItemFcProExpRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataFcProfExp.PC1TmpItemFcProExpRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpItemFcProExpRowChangedEvent != null) && (this.PC1TmpItemFcProExpRowChangedEvent != null))
                {
                    this.PC1TmpItemFcProExpRowChangedEvent(this, new DataFcProfExp.PC1TmpItemFcProExpRowChangeEvent((DataFcProfExp.PC1TmpItemFcProExpRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpItemFcProExpRowChangingEvent != null) && (this.PC1TmpItemFcProExpRowChangingEvent != null))
                {
                    this.PC1TmpItemFcProExpRowChangingEvent(this, new DataFcProfExp.PC1TmpItemFcProExpRowChangeEvent((DataFcProfExp.PC1TmpItemFcProExpRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpItemFcProExpRowDeletedEvent != null) && (this.PC1TmpItemFcProExpRowDeletedEvent != null))
                {
                    this.PC1TmpItemFcProExpRowDeletedEvent(this, new DataFcProfExp.PC1TmpItemFcProExpRowChangeEvent((DataFcProfExp.PC1TmpItemFcProExpRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpItemFcProExpRowDeletingEvent != null) && (this.PC1TmpItemFcProExpRowDeletingEvent != null))
                {
                    this.PC1TmpItemFcProExpRowDeletingEvent(this, new DataFcProfExp.PC1TmpItemFcProExpRowChangeEvent((DataFcProfExp.PC1TmpItemFcProExpRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpItemFcProExpRow(DataFcProfExp.PC1TmpItemFcProExpRow row)
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

            internal DataColumn FechaConfColumn
            {
                get
                {
                    return this.columnFechaConf;
                }
            }

            public DataFcProfExp.PC1TmpItemFcProExpRow this[int index]
            {
                get
                {
                    return (DataFcProfExp.PC1TmpItemFcProExpRow) this.Rows[index];
                }
            }

            internal DataColumn LineaColumn
            {
                get
                {
                    return this.columnLinea;
                }
            }

            internal DataColumn NroOVColumn
            {
                get
                {
                    return this.columnNroOV;
                }
            }

            internal DataColumn PrecioUnitColumn
            {
                get
                {
                    return this.columnPrecioUnit;
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
        public class PC1TmpItemFcProExpRow : DataRow
        {
            private DataFcProfExp.PC1TmpItemFcProExpDataTable tablePC1TmpItemFcProExp;

            internal PC1TmpItemFcProExpRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpItemFcProExp = (DataFcProfExp.PC1TmpItemFcProExpDataTable) this.Table;
            }

            public decimal Cantidad
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpItemFcProExp.CantidadColumn]);
                }
                set
                {
                    this[this.tablePC1TmpItemFcProExp.CantidadColumn] = value;
                }
            }

            public string Codigo
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpItemFcProExp.CodigoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpItemFcProExp.CodigoColumn] = value;
                }
            }

            public string Descripcion
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpItemFcProExp.DescripcionColumn]);
                }
                set
                {
                    this[this.tablePC1TmpItemFcProExp.DescripcionColumn] = value;
                }
            }

            public DateTime FechaConf
            {
                get
                {
                    return DateType.FromObject(this[this.tablePC1TmpItemFcProExp.FechaConfColumn]);
                }
                set
                {
                    this[this.tablePC1TmpItemFcProExp.FechaConfColumn] = value;
                }
            }

            public string Linea
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpItemFcProExp.LineaColumn]);
                }
                set
                {
                    this[this.tablePC1TmpItemFcProExp.LineaColumn] = value;
                }
            }

            public string NroOV
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpItemFcProExp.NroOVColumn]);
                }
                set
                {
                    this[this.tablePC1TmpItemFcProExp.NroOVColumn] = value;
                }
            }

            public decimal PrecioUnit
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpItemFcProExp.PrecioUnitColumn]);
                }
                set
                {
                    this[this.tablePC1TmpItemFcProExp.PrecioUnitColumn] = value;
                }
            }

            public bool Seleccion
            {
                get
                {
                    return BooleanType.FromObject(this[this.tablePC1TmpItemFcProExp.SeleccionColumn]);
                }
                set
                {
                    this[this.tablePC1TmpItemFcProExp.SeleccionColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpItemFcProExpRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataFcProfExp.PC1TmpItemFcProExpRow eventRow;

            public PC1TmpItemFcProExpRowChangeEvent(DataFcProfExp.PC1TmpItemFcProExpRow row, DataRowAction action)
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

            public DataFcProfExp.PC1TmpItemFcProExpRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpItemFcProExpRowChangeEventHandler(object sender, DataFcProfExp.PC1TmpItemFcProExpRowChangeEvent e);

        [DebuggerStepThrough]
        public class PC1TmpOVFcProExpDataTable : DataTable, IEnumerable
        {
            private DataColumn columnAlmacen;
            private DataColumn columnCondEnt;
            private DataColumn columnCondPago;
            private DataColumn columnFlete;
            private DataColumn columnMoneda;
            private DataColumn columnNomAlmacen;
            private DataColumn columnNroOV;
            private DataColumn columnTipo;

            public event DataFcProfExp.PC1TmpOVFcProExpRowChangeEventHandler PC1TmpOVFcProExpRowChanged;

            public event DataFcProfExp.PC1TmpOVFcProExpRowChangeEventHandler PC1TmpOVFcProExpRowChanging;

            public event DataFcProfExp.PC1TmpOVFcProExpRowChangeEventHandler PC1TmpOVFcProExpRowDeleted;

            public event DataFcProfExp.PC1TmpOVFcProExpRowChangeEventHandler PC1TmpOVFcProExpRowDeleting;

            internal PC1TmpOVFcProExpDataTable() : base("PC1TmpOVFcProExp")
            {
                this.InitClass();
            }

            internal PC1TmpOVFcProExpDataTable(DataTable table) : base(table.TableName)
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

            public void AddPC1TmpOVFcProExpRow(DataFcProfExp.PC1TmpOVFcProExpRow row)
            {
                this.Rows.Add(row);
            }

            public DataFcProfExp.PC1TmpOVFcProExpRow AddPC1TmpOVFcProExpRow(string NroOV, string Almacen, string NomAlmacen, decimal Flete, string Tipo, string Moneda, string CondPago, string CondEnt)
            {
                DataFcProfExp.PC1TmpOVFcProExpRow row = (DataFcProfExp.PC1TmpOVFcProExpRow) this.NewRow();
                row.ItemArray = new object[] { NroOV, Almacen, NomAlmacen, Flete, Tipo, Moneda, CondPago, CondEnt };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataFcProfExp.PC1TmpOVFcProExpDataTable table = (DataFcProfExp.PC1TmpOVFcProExpDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataFcProfExp.PC1TmpOVFcProExpDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataFcProfExp.PC1TmpOVFcProExpRow);
            }

            private void InitClass()
            {
                this.columnNroOV = new DataColumn("NroOV", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNroOV);
                this.columnAlmacen = new DataColumn("Almacen", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnAlmacen);
                this.columnNomAlmacen = new DataColumn("NomAlmacen", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnNomAlmacen);
                this.columnFlete = new DataColumn("Flete", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnFlete);
                this.columnTipo = new DataColumn("Tipo", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnTipo);
                this.columnMoneda = new DataColumn("Moneda", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnMoneda);
                this.columnCondPago = new DataColumn("CondPago", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCondPago);
                this.columnCondEnt = new DataColumn("CondEnt", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnCondEnt);
                this.columnNroOV.AllowDBNull = false;
                this.columnAlmacen.AllowDBNull = false;
                this.columnNomAlmacen.AllowDBNull = false;
                this.columnFlete.AllowDBNull = false;
                this.columnTipo.AllowDBNull = false;
                this.columnMoneda.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnNroOV = this.Columns["NroOV"];
                this.columnAlmacen = this.Columns["Almacen"];
                this.columnNomAlmacen = this.Columns["NomAlmacen"];
                this.columnFlete = this.Columns["Flete"];
                this.columnTipo = this.Columns["Tipo"];
                this.columnMoneda = this.Columns["Moneda"];
                this.columnCondPago = this.Columns["CondPago"];
                this.columnCondEnt = this.Columns["CondEnt"];
            }

            public DataFcProfExp.PC1TmpOVFcProExpRow NewPC1TmpOVFcProExpRow()
            {
                return (DataFcProfExp.PC1TmpOVFcProExpRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataFcProfExp.PC1TmpOVFcProExpRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpOVFcProExpRowChangedEvent != null) && (this.PC1TmpOVFcProExpRowChangedEvent != null))
                {
                    this.PC1TmpOVFcProExpRowChangedEvent(this, new DataFcProfExp.PC1TmpOVFcProExpRowChangeEvent((DataFcProfExp.PC1TmpOVFcProExpRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpOVFcProExpRowChangingEvent != null) && (this.PC1TmpOVFcProExpRowChangingEvent != null))
                {
                    this.PC1TmpOVFcProExpRowChangingEvent(this, new DataFcProfExp.PC1TmpOVFcProExpRowChangeEvent((DataFcProfExp.PC1TmpOVFcProExpRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpOVFcProExpRowDeletedEvent != null) && (this.PC1TmpOVFcProExpRowDeletedEvent != null))
                {
                    this.PC1TmpOVFcProExpRowDeletedEvent(this, new DataFcProfExp.PC1TmpOVFcProExpRowChangeEvent((DataFcProfExp.PC1TmpOVFcProExpRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpOVFcProExpRowDeletingEvent != null) && (this.PC1TmpOVFcProExpRowDeletingEvent != null))
                {
                    this.PC1TmpOVFcProExpRowDeletingEvent(this, new DataFcProfExp.PC1TmpOVFcProExpRowChangeEvent((DataFcProfExp.PC1TmpOVFcProExpRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpOVFcProExpRow(DataFcProfExp.PC1TmpOVFcProExpRow row)
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

            internal DataColumn CondEntColumn
            {
                get
                {
                    return this.columnCondEnt;
                }
            }

            internal DataColumn CondPagoColumn
            {
                get
                {
                    return this.columnCondPago;
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

            internal DataColumn FleteColumn
            {
                get
                {
                    return this.columnFlete;
                }
            }

            public DataFcProfExp.PC1TmpOVFcProExpRow this[int index]
            {
                get
                {
                    return (DataFcProfExp.PC1TmpOVFcProExpRow) this.Rows[index];
                }
            }

            internal DataColumn MonedaColumn
            {
                get
                {
                    return this.columnMoneda;
                }
            }

            internal DataColumn NomAlmacenColumn
            {
                get
                {
                    return this.columnNomAlmacen;
                }
            }

            internal DataColumn NroOVColumn
            {
                get
                {
                    return this.columnNroOV;
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
        public class PC1TmpOVFcProExpRow : DataRow
        {
            private DataFcProfExp.PC1TmpOVFcProExpDataTable tablePC1TmpOVFcProExp;

            internal PC1TmpOVFcProExpRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpOVFcProExp = (DataFcProfExp.PC1TmpOVFcProExpDataTable) this.Table;
            }

            public bool IsCondEntNull()
            {
                return this.IsNull(this.tablePC1TmpOVFcProExp.CondEntColumn);
            }

            public bool IsCondPagoNull()
            {
                return this.IsNull(this.tablePC1TmpOVFcProExp.CondPagoColumn);
            }

            public void SetCondEntNull()
            {
                this[this.tablePC1TmpOVFcProExp.CondEntColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetCondPagoNull()
            {
                this[this.tablePC1TmpOVFcProExp.CondPagoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string Almacen
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVFcProExp.AlmacenColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVFcProExp.AlmacenColumn] = value;
                }
            }

            public string CondEnt
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpOVFcProExp.CondEntColumn]);
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
                    this[this.tablePC1TmpOVFcProExp.CondEntColumn] = value;
                }
            }

            public string CondPago
            {
                get
                {
                    string str;
                    try
                    {
                        str = StringType.FromObject(this[this.tablePC1TmpOVFcProExp.CondPagoColumn]);
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
                    this[this.tablePC1TmpOVFcProExp.CondPagoColumn] = value;
                }
            }

            public decimal Flete
            {
                get
                {
                    return DecimalType.FromObject(this[this.tablePC1TmpOVFcProExp.FleteColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVFcProExp.FleteColumn] = value;
                }
            }

            public string Moneda
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVFcProExp.MonedaColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVFcProExp.MonedaColumn] = value;
                }
            }

            public string NomAlmacen
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVFcProExp.NomAlmacenColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVFcProExp.NomAlmacenColumn] = value;
                }
            }

            public string NroOV
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVFcProExp.NroOVColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVFcProExp.NroOVColumn] = value;
                }
            }

            public string Tipo
            {
                get
                {
                    return StringType.FromObject(this[this.tablePC1TmpOVFcProExp.TipoColumn]);
                }
                set
                {
                    this[this.tablePC1TmpOVFcProExp.TipoColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpOVFcProExpRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataFcProfExp.PC1TmpOVFcProExpRow eventRow;

            public PC1TmpOVFcProExpRowChangeEvent(DataFcProfExp.PC1TmpOVFcProExpRow row, DataRowAction action)
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

            public DataFcProfExp.PC1TmpOVFcProExpRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpOVFcProExpRowChangeEventHandler(object sender, DataFcProfExp.PC1TmpOVFcProExpRowChangeEvent e);

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

            public event DataFcProfExp.SL010100RowChangeEventHandler SL010100RowChanged;

            public event DataFcProfExp.SL010100RowChangeEventHandler SL010100RowChanging;

            public event DataFcProfExp.SL010100RowChangeEventHandler SL010100RowDeleted;

            public event DataFcProfExp.SL010100RowChangeEventHandler SL010100RowDeleting;

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

            public void AddSL010100Row(DataFcProfExp.SL010100Row row)
            {
                this.Rows.Add(row);
            }

            public DataFcProfExp.SL010100Row AddSL010100Row(string SL01001, string SL01002, string SL01003, string SL01004, string SL01005, string SL01006, string SL01007, string SL01008, string SL01009, string SL01010, string SL01011, string SL01012, string SL01013, string SL01014, string SL01015, string SL01016, string SL01017, string SL01018, string SL01019, string SL01020, string SL01021, string SL01022, string SL01023, string SL01024, string SL01025, string SL01026, string SL01027, string SL01028, string SL01029, string SL01030, string SL01031, string SL01032, string SL01033, string SL01034, string SL01035, string SL01036, string SL01037, string SL01038, string SL01039, string SL01040, string SL01041, string SL01042, string SL01043, string SL01044, string SL01045, string SL01046, string SL01047, string SL01048, string SL01049, DateTime SL01050, DateTime SL01051, string SL01052, string SL01053, string SL01054, string SL01055, string SL01056, string SL01057, string SL01058, string SL01059, string SL01060, string SL01061, string SL01062, string SL01063, string SL01064, string SL01065, string SL01066, string SL01067, string SL01068, string SL01069, string SL01070, string SL01071, string SL01072, string SL01073, string SL01074, string SL01075, string SL01076, string SL01077, string SL01078, string SL01079, string SL01080, string SL01081, string SL01082, string SL01083, string SL01084, string SL01085, string SL01086, string SL01087, string SL01088, string SL01089, string SL01090, string SL01091, string SL01092, string SL01093, string SL01094, string SL01095, string SL01096, string SL01097, string SL01098, string SL01099, string SL01100, string SL01101, string SL01102, string SL01103, string SL01104, string SL01105, string SL01106, string SL01107, string SL01108, string SL01109, string SL01110, string SL01111, string SL01112, string SL01113, string SL01114, string SL01115, string SL01116, string SL01117, string SL01118, string SL01119, string SL01120, string SL01121, string SL01122, string SL01123, string SL01124, string SL01125, string SL01126, string SL01127, string SL01128, string SL01129)
            {
                DataFcProfExp.SL010100Row row = (DataFcProfExp.SL010100Row) this.NewRow();
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
                DataFcProfExp.SL010100DataTable table = (DataFcProfExp.SL010100DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataFcProfExp.SL010100DataTable();
            }

            public DataFcProfExp.SL010100Row FindBySL01001(string SL01001)
            {
                return (DataFcProfExp.SL010100Row) this.Rows.Find(new object[] { SL01001 });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataFcProfExp.SL010100Row);
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
                this.Constraints.Add(new UniqueConstraint("DataFcProfExpKey4", new DataColumn[] { this.columnSL01001 }, true));
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
                return new DataFcProfExp.SL010100Row(builder);
            }

            public DataFcProfExp.SL010100Row NewSL010100Row()
            {
                return (DataFcProfExp.SL010100Row) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.SL010100RowChangedEvent != null) && (this.SL010100RowChangedEvent != null))
                {
                    this.SL010100RowChangedEvent(this, new DataFcProfExp.SL010100RowChangeEvent((DataFcProfExp.SL010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.SL010100RowChangingEvent != null) && (this.SL010100RowChangingEvent != null))
                {
                    this.SL010100RowChangingEvent(this, new DataFcProfExp.SL010100RowChangeEvent((DataFcProfExp.SL010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.SL010100RowDeletedEvent != null) && (this.SL010100RowDeletedEvent != null))
                {
                    this.SL010100RowDeletedEvent(this, new DataFcProfExp.SL010100RowChangeEvent((DataFcProfExp.SL010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.SL010100RowDeletingEvent != null) && (this.SL010100RowDeletingEvent != null))
                {
                    this.SL010100RowDeletingEvent(this, new DataFcProfExp.SL010100RowChangeEvent((DataFcProfExp.SL010100Row) e.Row, e.Action));
                }
            }

            public void RemoveSL010100Row(DataFcProfExp.SL010100Row row)
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

            public DataFcProfExp.SL010100Row this[int index]
            {
                get
                {
                    return (DataFcProfExp.SL010100Row) this.Rows[index];
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
            private DataFcProfExp.SL010100DataTable tableSL010100;

            internal SL010100Row(DataRowBuilder rb) : base(rb)
            {
                this.tableSL010100 = (DataFcProfExp.SL010100DataTable) this.Table;
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
            private DataFcProfExp.SL010100Row eventRow;

            public SL010100RowChangeEvent(DataFcProfExp.SL010100Row row, DataRowAction action)
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

            public DataFcProfExp.SL010100Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SL010100RowChangeEventHandler(object sender, DataFcProfExp.SL010100RowChangeEvent e);
    }
}

