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
    public class DataOVExp : DataSet
    {
        private OR010100DataTable tableOR010100;
        private OR030100DataTable tableOR030100;
        private PC030100DataTable tablePC030100;
        private PC1TmpFormaDespDataTable tablePC1TmpFormaDesp;
        private SC230100DataTable tableSC230100;
        private SL010100DataTable tableSL010100;

        public DataOVExp()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += handler;
            this.Relations.CollectionChanged += handler;
        }

        protected DataOVExp(SerializationInfo info, StreamingContext context)
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
                if (dataSet.Tables["SL010100"] != null)
                {
                    this.Tables.Add(new SL010100DataTable(dataSet.Tables["SL010100"]));
                }
                if (dataSet.Tables["PC1TmpFormaDesp"] != null)
                {
                    this.Tables.Add(new PC1TmpFormaDespDataTable(dataSet.Tables["PC1TmpFormaDesp"]));
                }
                if (dataSet.Tables["SC230100"] != null)
                {
                    this.Tables.Add(new SC230100DataTable(dataSet.Tables["SC230100"]));
                }
                if (dataSet.Tables["PC030100"] != null)
                {
                    this.Tables.Add(new PC030100DataTable(dataSet.Tables["PC030100"]));
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
            DataOVExp exp = (DataOVExp) base.Clone();
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
            this.DataSetName = "DataOVExp";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DataOVExp.xsd";
            this.Locale = new CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableOR010100 = new OR010100DataTable();
            this.Tables.Add(this.tableOR010100);
            this.tableOR030100 = new OR030100DataTable();
            this.Tables.Add(this.tableOR030100);
            this.tableSL010100 = new SL010100DataTable();
            this.Tables.Add(this.tableSL010100);
            this.tablePC1TmpFormaDesp = new PC1TmpFormaDespDataTable();
            this.Tables.Add(this.tablePC1TmpFormaDesp);
            this.tableSC230100 = new SC230100DataTable();
            this.Tables.Add(this.tableSC230100);
            this.tablePC030100 = new PC030100DataTable();
            this.Tables.Add(this.tablePC030100);
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
            this.tableSC230100 = (SC230100DataTable) this.Tables["SC230100"];
            if (this.tableSC230100 != null)
            {
                this.tableSC230100.InitVars();
            }
            this.tablePC030100 = (PC030100DataTable) this.Tables["PC030100"];
            if (this.tablePC030100 != null)
            {
                this.tablePC030100.InitVars();
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
            if (dataSet.Tables["SL010100"] != null)
            {
                this.Tables.Add(new SL010100DataTable(dataSet.Tables["SL010100"]));
            }
            if (dataSet.Tables["PC1TmpFormaDesp"] != null)
            {
                this.Tables.Add(new PC1TmpFormaDespDataTable(dataSet.Tables["PC1TmpFormaDesp"]));
            }
            if (dataSet.Tables["SC230100"] != null)
            {
                this.Tables.Add(new SC230100DataTable(dataSet.Tables["SC230100"]));
            }
            if (dataSet.Tables["PC030100"] != null)
            {
                this.Tables.Add(new PC030100DataTable(dataSet.Tables["PC030100"]));
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

        private bool ShouldSerializePC030100()
        {
            return false;
        }

        private bool ShouldSerializePC1TmpFormaDesp()
        {
            return false;
        }

        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        private bool ShouldSerializeSC230100()
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OR030100DataTable OR030100
        {
            get
            {
                return this.tableOR030100;
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PC1TmpFormaDespDataTable PC1TmpFormaDesp
        {
            get
            {
                return this.tablePC1TmpFormaDesp;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public SC230100DataTable SC230100
        {
            get
            {
                return this.tableSC230100;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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

            public event DataOVExp.OR010100RowChangeEventHandler OR010100RowChanged;

            public event DataOVExp.OR010100RowChangeEventHandler OR010100RowChanging;

            public event DataOVExp.OR010100RowChangeEventHandler OR010100RowDeleted;

            public event DataOVExp.OR010100RowChangeEventHandler OR010100RowDeleting;

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

            public void AddOR010100Row(DataOVExp.OR010100Row row)
            {
                this.Rows.Add(row);
            }

            public DataOVExp.OR010100Row AddOR010100Row(string OR01001, int OR01002, string OR01003, string OR01004, string OR01005, string OR01006, int OR01007, int OR01008, int OR01009, int OR01010, int OR01011, int OR01012, int OR01013, int OR01014, DateTime OR01015, DateTime OR01016, string OR01017, string OR01018, string OR01019, string OR01020, string OR01021, DateTime OR01022, string OR01023, decimal OR01024, string OR01025, int OR01026, int OR01027, int OR01028, int OR01029, int OR01030, int OR01031, int OR01032, int OR01033, decimal OR01034, decimal OR01035, decimal OR01036, decimal OR01037, string OR01038, DateTime OR01039, DateTime OR01040, decimal OR01041, decimal OR01042, decimal OR01043, decimal OR01044, string OR01045, decimal OR01046, string OR01047, decimal OR01048, string OR01049, string OR01050, string OR01051, string OR01052, string OR01053, string OR01054, string OR01055, string OR01056, decimal OR01057, decimal OR01058, decimal OR01059, decimal OR01060, decimal OR01061, string OR01062, decimal OR01063, decimal OR01064, int OR01065, string OR01066, decimal OR01067, string OR01068, string OR01069, string OR01070, int OR01071, string OR01072, string OR01073, DateTime OR01074, DateTime OR01075, string OR01076, DateTime OR01077, string OR01078, string OR01079, int OR01080, int OR01081, string OR01082, string OR01083, string OR01084, string OR01085, string OR01086, string OR01087, string OR01088, string OR01089, string OR01090, int OR01091, int OR01092, int OR01093, int OR01094, string OR01095, string OR01096, DateTime OR01097, string OR01098, string OR01099, int OR01100, string OR01101, int OR01102, string OR01103, string OR01104, string OR01105, string OR01106, string OR01107, string OR01108, string OR01109, decimal OR01110, string OR01111, decimal OR01112, string OR01113, decimal OR01114, string OR01115, int OR01116, string OR01117, string OR01118, string OR01119, string OR01120, string OR01121, string OR01122, string OR01123, string OR01124, string OR01125, string OR01126, decimal OR01127, string OR01128, string OR01129, string OR01130, DateTime OR01131, string OR01132, string OR01133, string OR01134, string OR01135, string OR01136, string OR01137, decimal OR01138, string OR01139, decimal OR01140, string OR01141, string OR01142, string OR01143, string OR01144, string OR01145, string OR01146)
            {
                DataOVExp.OR010100Row row = (DataOVExp.OR010100Row) this.NewRow();
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
                DataOVExp.OR010100DataTable table = (DataOVExp.OR010100DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataOVExp.OR010100DataTable();
            }

            public DataOVExp.OR010100Row FindByOR01001(string OR01001)
            {
                return (DataOVExp.OR010100Row) this.Rows.Find(new object[] { OR01001 });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataOVExp.OR010100Row);
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
                this.Constraints.Add(new UniqueConstraint("DataOVExpKey1", new DataColumn[] { this.columnOR01001 }, true));
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

            public DataOVExp.OR010100Row NewOR010100Row()
            {
                return (DataOVExp.OR010100Row) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataOVExp.OR010100Row(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.OR010100RowChangedEvent != null) && (this.OR010100RowChangedEvent != null))
                {
                    this.OR010100RowChangedEvent(this, new DataOVExp.OR010100RowChangeEvent((DataOVExp.OR010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.OR010100RowChangingEvent != null) && (this.OR010100RowChangingEvent != null))
                {
                    this.OR010100RowChangingEvent(this, new DataOVExp.OR010100RowChangeEvent((DataOVExp.OR010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.OR010100RowDeletedEvent != null) && (this.OR010100RowDeletedEvent != null))
                {
                    this.OR010100RowDeletedEvent(this, new DataOVExp.OR010100RowChangeEvent((DataOVExp.OR010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.OR010100RowDeletingEvent != null) && (this.OR010100RowDeletingEvent != null))
                {
                    this.OR010100RowDeletingEvent(this, new DataOVExp.OR010100RowChangeEvent((DataOVExp.OR010100Row) e.Row, e.Action));
                }
            }

            public void RemoveOR010100Row(DataOVExp.OR010100Row row)
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

            public DataOVExp.OR010100Row this[int index]
            {
                get
                {
                    return (DataOVExp.OR010100Row) this.Rows[index];
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
            private DataOVExp.OR010100DataTable tableOR010100;

            internal OR010100Row(DataRowBuilder rb) : base(rb)
            {
                this.tableOR010100 = (DataOVExp.OR010100DataTable) this.Table;
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
            private DataOVExp.OR010100Row eventRow;

            public OR010100RowChangeEvent(DataOVExp.OR010100Row row, DataRowAction action)
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

            public DataOVExp.OR010100Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OR010100RowChangeEventHandler(object sender, DataOVExp.OR010100RowChangeEvent e);

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

            public event DataOVExp.OR030100RowChangeEventHandler OR030100RowChanged;

            public event DataOVExp.OR030100RowChangeEventHandler OR030100RowChanging;

            public event DataOVExp.OR030100RowChangeEventHandler OR030100RowDeleted;

            public event DataOVExp.OR030100RowChangeEventHandler OR030100RowDeleting;

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

            public void AddOR030100Row(DataOVExp.OR030100Row row)
            {
                this.Rows.Add(row);
            }

            public DataOVExp.OR030100Row AddOR030100Row(string OR03001, string OR03002, string OR03003, int OR03004, string OR03005, string OR03006, string OR03007, decimal OR03008, decimal OR03009, int OR03010, decimal OR03011, decimal OR03012, int OR03013, int OR03014, string OR03015, int OR03016, decimal OR03017, decimal OR03018, DateTime OR03019, decimal OR03020, decimal OR03021, decimal OR03022, decimal OR03023, decimal OR03024, int OR03025, int OR03026, int OR03027, string OR03028, int OR03029, int OR03030, int OR03031, string OR03032, decimal OR03033, string OR03034, string OR03035, decimal OR03036, DateTime OR03037, string OR03038, int OR03039, decimal OR03040, decimal OR03041, DateTime OR03042, decimal OR03043, decimal OR03044, decimal OR03045, string OR03046, decimal OR03047, decimal OR03048, decimal OR03049, decimal OR03050, string OR03051, string OR03052, decimal OR03053, decimal OR03054, string OR03055, decimal OR03056, decimal OR03057, decimal OR03058, decimal OR03059, decimal OR03060, int OR03061, int OR03062, decimal OR03063, decimal OR03064, string OR03065, string OR03066, string OR03067, string OR03068, int OR03069, string OR03070, string OR03071, string OR03072, string OR03073, string OR03074, string OR03075, decimal OR03076, decimal OR03077, string OR03078, decimal OR03079, string OR03080, decimal OR03081, string OR03082, int OR03083, string OR03084, int OR03085, decimal OR03086, string OR03087, decimal OR03088)
            {
                DataOVExp.OR030100Row row = (DataOVExp.OR030100Row) this.NewRow();
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
                DataOVExp.OR030100DataTable table = (DataOVExp.OR030100DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataOVExp.OR030100DataTable();
            }

            public DataOVExp.OR030100Row FindByOR03001OR03002OR03003(string OR03001, string OR03002, string OR03003)
            {
                return (DataOVExp.OR030100Row) this.Rows.Find(new object[] { OR03001, OR03002, OR03003 });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataOVExp.OR030100Row);
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
                this.columnOR03032 = new DataColumn("OR03032", typeof(string), null, MappingType.Element);
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
                this.Constraints.Add(new UniqueConstraint("DataOVExpKey2", new DataColumn[] { this.columnOR03001, this.columnOR03002, this.columnOR03003 }, true));
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

            public DataOVExp.OR030100Row NewOR030100Row()
            {
                return (DataOVExp.OR030100Row) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataOVExp.OR030100Row(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.OR030100RowChangedEvent != null) && (this.OR030100RowChangedEvent != null))
                {
                    this.OR030100RowChangedEvent(this, new DataOVExp.OR030100RowChangeEvent((DataOVExp.OR030100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.OR030100RowChangingEvent != null) && (this.OR030100RowChangingEvent != null))
                {
                    this.OR030100RowChangingEvent(this, new DataOVExp.OR030100RowChangeEvent((DataOVExp.OR030100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.OR030100RowDeletedEvent != null) && (this.OR030100RowDeletedEvent != null))
                {
                    this.OR030100RowDeletedEvent(this, new DataOVExp.OR030100RowChangeEvent((DataOVExp.OR030100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.OR030100RowDeletingEvent != null) && (this.OR030100RowDeletingEvent != null))
                {
                    this.OR030100RowDeletingEvent(this, new DataOVExp.OR030100RowChangeEvent((DataOVExp.OR030100Row) e.Row, e.Action));
                }
            }

            public void RemoveOR030100Row(DataOVExp.OR030100Row row)
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

            public DataOVExp.OR030100Row this[int index]
            {
                get
                {
                    return (DataOVExp.OR030100Row) this.Rows[index];
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
            private DataOVExp.OR030100DataTable tableOR030100;

            internal OR030100Row(DataRowBuilder rb) : base(rb)
            {
                this.tableOR030100 = (DataOVExp.OR030100DataTable) this.Table;
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

            public string OR03032
            {
                get
                {
                    return StringType.FromObject(this[this.tableOR030100.OR03032Column]);
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
            private DataOVExp.OR030100Row eventRow;

            public OR030100RowChangeEvent(DataOVExp.OR030100Row row, DataRowAction action)
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

            public DataOVExp.OR030100Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OR030100RowChangeEventHandler(object sender, DataOVExp.OR030100RowChangeEvent e);

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

            public event DataOVExp.PC030100RowChangeEventHandler PC030100RowChanged;

            public event DataOVExp.PC030100RowChangeEventHandler PC030100RowChanging;

            public event DataOVExp.PC030100RowChangeEventHandler PC030100RowDeleted;

            public event DataOVExp.PC030100RowChangeEventHandler PC030100RowDeleting;

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

            public void AddPC030100Row(DataOVExp.PC030100Row row)
            {
                this.Rows.Add(row);
            }

            public DataOVExp.PC030100Row AddPC030100Row(string PC03001, string PC03002, string PC03003, int PC03004, string PC03005, string PC03006, string PC03007, decimal PC03008, int PC03009, decimal PC03010, decimal PC03011, decimal PC03012, string PC03013, string PC03014, decimal PC03015, DateTime PC03016, DateTime PC03017, decimal PC03018, decimal PC03019, string PC03020, int PC03021, string PC03022, int PC03023, DateTime PC03024, decimal PC03025, string PC03026, string PC03027, string PC03028, string PC03029, DateTime PC03030, DateTime PC03031, decimal PC03032, decimal PC03033, decimal PC03034, string PC03035, string PC03036, string PC03037, decimal PC03038, string PC03039, string PC03040, string PC03041, decimal PC03042, decimal PC03043, decimal PC03044, string PC03045, decimal PC03046, decimal PC03047, string PC03048, decimal PC03049, string PC03050, string PC03051, string PC03052, string PC03053, decimal PC03054, string PC03055, int PC03056, string PC03057, decimal PC03058, decimal PC03059, string PC03060, int PC03061, decimal PC03062)
            {
                DataOVExp.PC030100Row row = (DataOVExp.PC030100Row) this.NewRow();
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
                DataOVExp.PC030100DataTable table = (DataOVExp.PC030100DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataOVExp.PC030100DataTable();
            }

            public DataOVExp.PC030100Row FindByPC03001PC03002PC03003(string PC03001, string PC03002, string PC03003)
            {
                return (DataOVExp.PC030100Row) this.Rows.Find(new object[] { PC03001, PC03002, PC03003 });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataOVExp.PC030100Row);
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
                this.Constraints.Add(new UniqueConstraint("DataOVExpKey5", new DataColumn[] { this.columnPC03001, this.columnPC03002, this.columnPC03003 }, true));
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

            public DataOVExp.PC030100Row NewPC030100Row()
            {
                return (DataOVExp.PC030100Row) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataOVExp.PC030100Row(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC030100RowChangedEvent != null) && (this.PC030100RowChangedEvent != null))
                {
                    this.PC030100RowChangedEvent(this, new DataOVExp.PC030100RowChangeEvent((DataOVExp.PC030100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC030100RowChangingEvent != null) && (this.PC030100RowChangingEvent != null))
                {
                    this.PC030100RowChangingEvent(this, new DataOVExp.PC030100RowChangeEvent((DataOVExp.PC030100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC030100RowDeletedEvent != null) && (this.PC030100RowDeletedEvent != null))
                {
                    this.PC030100RowDeletedEvent(this, new DataOVExp.PC030100RowChangeEvent((DataOVExp.PC030100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC030100RowDeletingEvent != null) && (this.PC030100RowDeletingEvent != null))
                {
                    this.PC030100RowDeletingEvent(this, new DataOVExp.PC030100RowChangeEvent((DataOVExp.PC030100Row) e.Row, e.Action));
                }
            }

            public void RemovePC030100Row(DataOVExp.PC030100Row row)
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

            public DataOVExp.PC030100Row this[int index]
            {
                get
                {
                    return (DataOVExp.PC030100Row) this.Rows[index];
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
            private DataOVExp.PC030100DataTable tablePC030100;

            internal PC030100Row(DataRowBuilder rb) : base(rb)
            {
                this.tablePC030100 = (DataOVExp.PC030100DataTable) this.Table;
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
            private DataOVExp.PC030100Row eventRow;

            public PC030100RowChangeEvent(DataOVExp.PC030100Row row, DataRowAction action)
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

            public DataOVExp.PC030100Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC030100RowChangeEventHandler(object sender, DataOVExp.PC030100RowChangeEvent e);

        [DebuggerStepThrough]
        public class PC1TmpFormaDespDataTable : DataTable, IEnumerable
        {
            private DataColumn columnCodigo;
            private DataColumn columnDescripcion;

            public event DataOVExp.PC1TmpFormaDespRowChangeEventHandler PC1TmpFormaDespRowChanged;

            public event DataOVExp.PC1TmpFormaDespRowChangeEventHandler PC1TmpFormaDespRowChanging;

            public event DataOVExp.PC1TmpFormaDespRowChangeEventHandler PC1TmpFormaDespRowDeleted;

            public event DataOVExp.PC1TmpFormaDespRowChangeEventHandler PC1TmpFormaDespRowDeleting;

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

            public void AddPC1TmpFormaDespRow(DataOVExp.PC1TmpFormaDespRow row)
            {
                this.Rows.Add(row);
            }

            public DataOVExp.PC1TmpFormaDespRow AddPC1TmpFormaDespRow(int Codigo, string Descripcion)
            {
                DataOVExp.PC1TmpFormaDespRow row = (DataOVExp.PC1TmpFormaDespRow) this.NewRow();
                row.ItemArray = new object[] { Codigo, Descripcion };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataOVExp.PC1TmpFormaDespDataTable table = (DataOVExp.PC1TmpFormaDespDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataOVExp.PC1TmpFormaDespDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataOVExp.PC1TmpFormaDespRow);
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

            public DataOVExp.PC1TmpFormaDespRow NewPC1TmpFormaDespRow()
            {
                return (DataOVExp.PC1TmpFormaDespRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataOVExp.PC1TmpFormaDespRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.PC1TmpFormaDespRowChangedEvent != null) && (this.PC1TmpFormaDespRowChangedEvent != null))
                {
                    this.PC1TmpFormaDespRowChangedEvent(this, new DataOVExp.PC1TmpFormaDespRowChangeEvent((DataOVExp.PC1TmpFormaDespRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.PC1TmpFormaDespRowChangingEvent != null) && (this.PC1TmpFormaDespRowChangingEvent != null))
                {
                    this.PC1TmpFormaDespRowChangingEvent(this, new DataOVExp.PC1TmpFormaDespRowChangeEvent((DataOVExp.PC1TmpFormaDespRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.PC1TmpFormaDespRowDeletedEvent != null) && (this.PC1TmpFormaDespRowDeletedEvent != null))
                {
                    this.PC1TmpFormaDespRowDeletedEvent(this, new DataOVExp.PC1TmpFormaDespRowChangeEvent((DataOVExp.PC1TmpFormaDespRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.PC1TmpFormaDespRowDeletingEvent != null) && (this.PC1TmpFormaDespRowDeletingEvent != null))
                {
                    this.PC1TmpFormaDespRowDeletingEvent(this, new DataOVExp.PC1TmpFormaDespRowChangeEvent((DataOVExp.PC1TmpFormaDespRow) e.Row, e.Action));
                }
            }

            public void RemovePC1TmpFormaDespRow(DataOVExp.PC1TmpFormaDespRow row)
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

            public DataOVExp.PC1TmpFormaDespRow this[int index]
            {
                get
                {
                    return (DataOVExp.PC1TmpFormaDespRow) this.Rows[index];
                }
            }
        }

        [DebuggerStepThrough]
        public class PC1TmpFormaDespRow : DataRow
        {
            private DataOVExp.PC1TmpFormaDespDataTable tablePC1TmpFormaDesp;

            internal PC1TmpFormaDespRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePC1TmpFormaDesp = (DataOVExp.PC1TmpFormaDespDataTable) this.Table;
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
            private DataOVExp.PC1TmpFormaDespRow eventRow;

            public PC1TmpFormaDespRowChangeEvent(DataOVExp.PC1TmpFormaDespRow row, DataRowAction action)
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

            public DataOVExp.PC1TmpFormaDespRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PC1TmpFormaDespRowChangeEventHandler(object sender, DataOVExp.PC1TmpFormaDespRowChangeEvent e);

        [DebuggerStepThrough]
        public class SC230100DataTable : DataTable, IEnumerable
        {
            private DataColumn columnSC23001;
            private DataColumn columnSC23002;
            private DataColumn columnSC23003;
            private DataColumn columnSC23004;
            private DataColumn columnSC23005;
            private DataColumn columnSC23006;
            private DataColumn columnSC23007;
            private DataColumn columnSC23008;
            private DataColumn columnSC23009;
            private DataColumn columnSC23010;
            private DataColumn columnSC23011;
            private DataColumn columnSC23012;
            private DataColumn columnSC23013;
            private DataColumn columnSC23014;
            private DataColumn columnSC23015;
            private DataColumn columnSC23016;
            private DataColumn columnSC23017;
            private DataColumn columnSC23018;
            private DataColumn columnSC23019;
            private DataColumn columnSC23020;
            private DataColumn columnSC23021;
            private DataColumn columnSC23022;
            private DataColumn columnSC23023;
            private DataColumn columnSC23024;
            private DataColumn columnSC23025;
            private DataColumn columnSC23026;
            private DataColumn columnSC23027;

            public event DataOVExp.SC230100RowChangeEventHandler SC230100RowChanged;

            public event DataOVExp.SC230100RowChangeEventHandler SC230100RowChanging;

            public event DataOVExp.SC230100RowChangeEventHandler SC230100RowDeleted;

            public event DataOVExp.SC230100RowChangeEventHandler SC230100RowDeleting;

            internal SC230100DataTable() : base("SC230100")
            {
                this.InitClass();
            }

            internal SC230100DataTable(DataTable table) : base(table.TableName)
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

            public void AddSC230100Row(DataOVExp.SC230100Row row)
            {
                this.Rows.Add(row);
            }

            public DataOVExp.SC230100Row AddSC230100Row(string SC23001, string SC23002, string SC23003, string SC23004, string SC23005, string SC23006, string SC23007, string SC23008, string SC23009, string SC23010, string SC23011, string SC23012, string SC23013, string SC23014, string SC23015, string SC23016, string SC23017, string SC23018, decimal SC23019, string SC23020, string SC23021, decimal SC23022, decimal SC23023, decimal SC23024, string SC23025, string SC23026, string SC23027)
            {
                DataOVExp.SC230100Row row = (DataOVExp.SC230100Row) this.NewRow();
                row.ItemArray = new object[] { 
                    SC23001, SC23002, SC23003, SC23004, SC23005, SC23006, SC23007, SC23008, SC23009, SC23010, SC23011, SC23012, SC23013, SC23014, SC23015, SC23016, 
                    SC23017, SC23018, SC23019, SC23020, SC23021, SC23022, SC23023, SC23024, SC23025, SC23026, SC23027
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DataOVExp.SC230100DataTable table = (DataOVExp.SC230100DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataOVExp.SC230100DataTable();
            }

            public DataOVExp.SC230100Row FindBySC23001(string SC23001)
            {
                return (DataOVExp.SC230100Row) this.Rows.Find(new object[] { SC23001 });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataOVExp.SC230100Row);
            }

            private void InitClass()
            {
                this.columnSC23001 = new DataColumn("SC23001", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23001);
                this.columnSC23002 = new DataColumn("SC23002", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23002);
                this.columnSC23003 = new DataColumn("SC23003", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23003);
                this.columnSC23004 = new DataColumn("SC23004", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23004);
                this.columnSC23005 = new DataColumn("SC23005", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23005);
                this.columnSC23006 = new DataColumn("SC23006", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23006);
                this.columnSC23007 = new DataColumn("SC23007", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23007);
                this.columnSC23008 = new DataColumn("SC23008", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23008);
                this.columnSC23009 = new DataColumn("SC23009", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23009);
                this.columnSC23010 = new DataColumn("SC23010", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23010);
                this.columnSC23011 = new DataColumn("SC23011", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23011);
                this.columnSC23012 = new DataColumn("SC23012", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23012);
                this.columnSC23013 = new DataColumn("SC23013", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23013);
                this.columnSC23014 = new DataColumn("SC23014", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23014);
                this.columnSC23015 = new DataColumn("SC23015", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23015);
                this.columnSC23016 = new DataColumn("SC23016", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23016);
                this.columnSC23017 = new DataColumn("SC23017", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23017);
                this.columnSC23018 = new DataColumn("SC23018", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23018);
                this.columnSC23019 = new DataColumn("SC23019", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC23019);
                this.columnSC23020 = new DataColumn("SC23020", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23020);
                this.columnSC23021 = new DataColumn("SC23021", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23021);
                this.columnSC23022 = new DataColumn("SC23022", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC23022);
                this.columnSC23023 = new DataColumn("SC23023", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC23023);
                this.columnSC23024 = new DataColumn("SC23024", typeof(decimal), null, MappingType.Element);
                this.Columns.Add(this.columnSC23024);
                this.columnSC23025 = new DataColumn("SC23025", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23025);
                this.columnSC23026 = new DataColumn("SC23026", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23026);
                this.columnSC23027 = new DataColumn("SC23027", typeof(string), null, MappingType.Element);
                this.Columns.Add(this.columnSC23027);
                this.Constraints.Add(new UniqueConstraint("DataOVExpKey4", new DataColumn[] { this.columnSC23001 }, true));
                this.columnSC23001.AllowDBNull = false;
                this.columnSC23001.Unique = true;
                this.columnSC23002.AllowDBNull = false;
                this.columnSC23003.AllowDBNull = false;
                this.columnSC23004.AllowDBNull = false;
                this.columnSC23005.AllowDBNull = false;
                this.columnSC23006.AllowDBNull = false;
                this.columnSC23007.AllowDBNull = false;
                this.columnSC23008.AllowDBNull = false;
                this.columnSC23009.AllowDBNull = false;
                this.columnSC23010.AllowDBNull = false;
                this.columnSC23011.AllowDBNull = false;
                this.columnSC23012.AllowDBNull = false;
                this.columnSC23013.AllowDBNull = false;
                this.columnSC23014.AllowDBNull = false;
                this.columnSC23015.AllowDBNull = false;
                this.columnSC23016.AllowDBNull = false;
                this.columnSC23017.AllowDBNull = false;
                this.columnSC23018.AllowDBNull = false;
                this.columnSC23019.AllowDBNull = false;
                this.columnSC23020.AllowDBNull = false;
                this.columnSC23021.AllowDBNull = false;
                this.columnSC23022.AllowDBNull = false;
                this.columnSC23023.AllowDBNull = false;
                this.columnSC23024.AllowDBNull = false;
                this.columnSC23025.AllowDBNull = false;
                this.columnSC23026.AllowDBNull = false;
                this.columnSC23027.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnSC23001 = this.Columns["SC23001"];
                this.columnSC23002 = this.Columns["SC23002"];
                this.columnSC23003 = this.Columns["SC23003"];
                this.columnSC23004 = this.Columns["SC23004"];
                this.columnSC23005 = this.Columns["SC23005"];
                this.columnSC23006 = this.Columns["SC23006"];
                this.columnSC23007 = this.Columns["SC23007"];
                this.columnSC23008 = this.Columns["SC23008"];
                this.columnSC23009 = this.Columns["SC23009"];
                this.columnSC23010 = this.Columns["SC23010"];
                this.columnSC23011 = this.Columns["SC23011"];
                this.columnSC23012 = this.Columns["SC23012"];
                this.columnSC23013 = this.Columns["SC23013"];
                this.columnSC23014 = this.Columns["SC23014"];
                this.columnSC23015 = this.Columns["SC23015"];
                this.columnSC23016 = this.Columns["SC23016"];
                this.columnSC23017 = this.Columns["SC23017"];
                this.columnSC23018 = this.Columns["SC23018"];
                this.columnSC23019 = this.Columns["SC23019"];
                this.columnSC23020 = this.Columns["SC23020"];
                this.columnSC23021 = this.Columns["SC23021"];
                this.columnSC23022 = this.Columns["SC23022"];
                this.columnSC23023 = this.Columns["SC23023"];
                this.columnSC23024 = this.Columns["SC23024"];
                this.columnSC23025 = this.Columns["SC23025"];
                this.columnSC23026 = this.Columns["SC23026"];
                this.columnSC23027 = this.Columns["SC23027"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataOVExp.SC230100Row(builder);
            }

            public DataOVExp.SC230100Row NewSC230100Row()
            {
                return (DataOVExp.SC230100Row) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.SC230100RowChangedEvent != null) && (this.SC230100RowChangedEvent != null))
                {
                    this.SC230100RowChangedEvent(this, new DataOVExp.SC230100RowChangeEvent((DataOVExp.SC230100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.SC230100RowChangingEvent != null) && (this.SC230100RowChangingEvent != null))
                {
                    this.SC230100RowChangingEvent(this, new DataOVExp.SC230100RowChangeEvent((DataOVExp.SC230100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.SC230100RowDeletedEvent != null) && (this.SC230100RowDeletedEvent != null))
                {
                    this.SC230100RowDeletedEvent(this, new DataOVExp.SC230100RowChangeEvent((DataOVExp.SC230100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.SC230100RowDeletingEvent != null) && (this.SC230100RowDeletingEvent != null))
                {
                    this.SC230100RowDeletingEvent(this, new DataOVExp.SC230100RowChangeEvent((DataOVExp.SC230100Row) e.Row, e.Action));
                }
            }

            public void RemoveSC230100Row(DataOVExp.SC230100Row row)
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

            public DataOVExp.SC230100Row this[int index]
            {
                get
                {
                    return (DataOVExp.SC230100Row) this.Rows[index];
                }
            }

            internal DataColumn SC23001Column
            {
                get
                {
                    return this.columnSC23001;
                }
            }

            internal DataColumn SC23002Column
            {
                get
                {
                    return this.columnSC23002;
                }
            }

            internal DataColumn SC23003Column
            {
                get
                {
                    return this.columnSC23003;
                }
            }

            internal DataColumn SC23004Column
            {
                get
                {
                    return this.columnSC23004;
                }
            }

            internal DataColumn SC23005Column
            {
                get
                {
                    return this.columnSC23005;
                }
            }

            internal DataColumn SC23006Column
            {
                get
                {
                    return this.columnSC23006;
                }
            }

            internal DataColumn SC23007Column
            {
                get
                {
                    return this.columnSC23007;
                }
            }

            internal DataColumn SC23008Column
            {
                get
                {
                    return this.columnSC23008;
                }
            }

            internal DataColumn SC23009Column
            {
                get
                {
                    return this.columnSC23009;
                }
            }

            internal DataColumn SC23010Column
            {
                get
                {
                    return this.columnSC23010;
                }
            }

            internal DataColumn SC23011Column
            {
                get
                {
                    return this.columnSC23011;
                }
            }

            internal DataColumn SC23012Column
            {
                get
                {
                    return this.columnSC23012;
                }
            }

            internal DataColumn SC23013Column
            {
                get
                {
                    return this.columnSC23013;
                }
            }

            internal DataColumn SC23014Column
            {
                get
                {
                    return this.columnSC23014;
                }
            }

            internal DataColumn SC23015Column
            {
                get
                {
                    return this.columnSC23015;
                }
            }

            internal DataColumn SC23016Column
            {
                get
                {
                    return this.columnSC23016;
                }
            }

            internal DataColumn SC23017Column
            {
                get
                {
                    return this.columnSC23017;
                }
            }

            internal DataColumn SC23018Column
            {
                get
                {
                    return this.columnSC23018;
                }
            }

            internal DataColumn SC23019Column
            {
                get
                {
                    return this.columnSC23019;
                }
            }

            internal DataColumn SC23020Column
            {
                get
                {
                    return this.columnSC23020;
                }
            }

            internal DataColumn SC23021Column
            {
                get
                {
                    return this.columnSC23021;
                }
            }

            internal DataColumn SC23022Column
            {
                get
                {
                    return this.columnSC23022;
                }
            }

            internal DataColumn SC23023Column
            {
                get
                {
                    return this.columnSC23023;
                }
            }

            internal DataColumn SC23024Column
            {
                get
                {
                    return this.columnSC23024;
                }
            }

            internal DataColumn SC23025Column
            {
                get
                {
                    return this.columnSC23025;
                }
            }

            internal DataColumn SC23026Column
            {
                get
                {
                    return this.columnSC23026;
                }
            }

            internal DataColumn SC23027Column
            {
                get
                {
                    return this.columnSC23027;
                }
            }
        }

        [DebuggerStepThrough]
        public class SC230100Row : DataRow
        {
            private DataOVExp.SC230100DataTable tableSC230100;

            internal SC230100Row(DataRowBuilder rb) : base(rb)
            {
                this.tableSC230100 = (DataOVExp.SC230100DataTable) this.Table;
            }

            public string SC23001
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23001Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23001Column] = value;
                }
            }

            public string SC23002
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23002Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23002Column] = value;
                }
            }

            public string SC23003
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23003Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23003Column] = value;
                }
            }

            public string SC23004
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23004Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23004Column] = value;
                }
            }

            public string SC23005
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23005Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23005Column] = value;
                }
            }

            public string SC23006
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23006Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23006Column] = value;
                }
            }

            public string SC23007
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23007Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23007Column] = value;
                }
            }

            public string SC23008
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23008Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23008Column] = value;
                }
            }

            public string SC23009
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23009Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23009Column] = value;
                }
            }

            public string SC23010
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23010Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23010Column] = value;
                }
            }

            public string SC23011
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23011Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23011Column] = value;
                }
            }

            public string SC23012
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23012Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23012Column] = value;
                }
            }

            public string SC23013
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23013Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23013Column] = value;
                }
            }

            public string SC23014
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23014Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23014Column] = value;
                }
            }

            public string SC23015
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23015Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23015Column] = value;
                }
            }

            public string SC23016
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23016Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23016Column] = value;
                }
            }

            public string SC23017
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23017Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23017Column] = value;
                }
            }

            public string SC23018
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23018Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23018Column] = value;
                }
            }

            public decimal SC23019
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC230100.SC23019Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23019Column] = value;
                }
            }

            public string SC23020
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23020Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23020Column] = value;
                }
            }

            public string SC23021
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23021Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23021Column] = value;
                }
            }

            public decimal SC23022
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC230100.SC23022Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23022Column] = value;
                }
            }

            public decimal SC23023
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC230100.SC23023Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23023Column] = value;
                }
            }

            public decimal SC23024
            {
                get
                {
                    return DecimalType.FromObject(this[this.tableSC230100.SC23024Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23024Column] = value;
                }
            }

            public string SC23025
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23025Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23025Column] = value;
                }
            }

            public string SC23026
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23026Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23026Column] = value;
                }
            }

            public string SC23027
            {
                get
                {
                    return StringType.FromObject(this[this.tableSC230100.SC23027Column]);
                }
                set
                {
                    this[this.tableSC230100.SC23027Column] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class SC230100RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataOVExp.SC230100Row eventRow;

            public SC230100RowChangeEvent(DataOVExp.SC230100Row row, DataRowAction action)
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

            public DataOVExp.SC230100Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SC230100RowChangeEventHandler(object sender, DataOVExp.SC230100RowChangeEvent e);

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

            public event DataOVExp.SL010100RowChangeEventHandler SL010100RowChanged;

            public event DataOVExp.SL010100RowChangeEventHandler SL010100RowChanging;

            public event DataOVExp.SL010100RowChangeEventHandler SL010100RowDeleted;

            public event DataOVExp.SL010100RowChangeEventHandler SL010100RowDeleting;

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

            public void AddSL010100Row(DataOVExp.SL010100Row row)
            {
                this.Rows.Add(row);
            }

            public DataOVExp.SL010100Row AddSL010100Row(string SL01001, string SL01002, string SL01003, string SL01004, string SL01005, string SL01006, string SL01007, string SL01008, string SL01009, string SL01010, string SL01011, string SL01012, string SL01013, string SL01014, string SL01015, string SL01016, string SL01017, string SL01018, string SL01019, string SL01020, string SL01021, string SL01022, string SL01023, string SL01024, string SL01025, string SL01026, string SL01027, string SL01028, string SL01029, string SL01030, string SL01031, string SL01032, string SL01033, string SL01034, string SL01035, string SL01036, string SL01037, string SL01038, string SL01039, string SL01040, string SL01041, string SL01042, string SL01043, string SL01044, string SL01045, string SL01046, string SL01047, string SL01048, string SL01049, DateTime SL01050, DateTime SL01051, string SL01052, string SL01053, string SL01054, string SL01055, string SL01056, string SL01057, string SL01058, string SL01059, string SL01060, string SL01061, string SL01062, string SL01063, string SL01064, string SL01065, string SL01066, string SL01067, string SL01068, string SL01069, string SL01070, string SL01071, string SL01072, string SL01073, string SL01074, string SL01075, string SL01076, string SL01077, string SL01078, string SL01079, string SL01080, string SL01081, string SL01082, string SL01083, string SL01084, string SL01085, string SL01086, string SL01087, string SL01088, string SL01089, string SL01090, string SL01091, string SL01092, string SL01093, string SL01094, string SL01095, string SL01096, string SL01097, string SL01098, string SL01099, string SL01100, string SL01101, string SL01102, string SL01103, string SL01104, string SL01105, string SL01106, string SL01107, string SL01108, string SL01109, string SL01110, string SL01111, string SL01112, string SL01113, string SL01114, string SL01115, string SL01116, string SL01117, string SL01118, string SL01119, string SL01120, string SL01121, string SL01122, string SL01123, string SL01124, string SL01125, string SL01126, string SL01127, string SL01128, string SL01129)
            {
                DataOVExp.SL010100Row row = (DataOVExp.SL010100Row) this.NewRow();
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
                DataOVExp.SL010100DataTable table = (DataOVExp.SL010100DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new DataOVExp.SL010100DataTable();
            }

            public DataOVExp.SL010100Row FindBySL01001(string SL01001)
            {
                return (DataOVExp.SL010100Row) this.Rows.Find(new object[] { SL01001 });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DataOVExp.SL010100Row);
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
                this.Constraints.Add(new UniqueConstraint("DataOVExpKey3", new DataColumn[] { this.columnSL01001 }, true));
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
                return new DataOVExp.SL010100Row(builder);
            }

            public DataOVExp.SL010100Row NewSL010100Row()
            {
                return (DataOVExp.SL010100Row) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.SL010100RowChangedEvent != null) && (this.SL010100RowChangedEvent != null))
                {
                    this.SL010100RowChangedEvent(this, new DataOVExp.SL010100RowChangeEvent((DataOVExp.SL010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.SL010100RowChangingEvent != null) && (this.SL010100RowChangingEvent != null))
                {
                    this.SL010100RowChangingEvent(this, new DataOVExp.SL010100RowChangeEvent((DataOVExp.SL010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.SL010100RowDeletedEvent != null) && (this.SL010100RowDeletedEvent != null))
                {
                    this.SL010100RowDeletedEvent(this, new DataOVExp.SL010100RowChangeEvent((DataOVExp.SL010100Row) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.SL010100RowDeletingEvent != null) && (this.SL010100RowDeletingEvent != null))
                {
                    this.SL010100RowDeletingEvent(this, new DataOVExp.SL010100RowChangeEvent((DataOVExp.SL010100Row) e.Row, e.Action));
                }
            }

            public void RemoveSL010100Row(DataOVExp.SL010100Row row)
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

            public DataOVExp.SL010100Row this[int index]
            {
                get
                {
                    return (DataOVExp.SL010100Row) this.Rows[index];
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
            private DataOVExp.SL010100DataTable tableSL010100;

            internal SL010100Row(DataRowBuilder rb) : base(rb)
            {
                this.tableSL010100 = (DataOVExp.SL010100DataTable) this.Table;
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
            private DataOVExp.SL010100Row eventRow;

            public SL010100RowChangeEvent(DataOVExp.SL010100Row row, DataRowAction action)
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

            public DataOVExp.SL010100Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SL010100RowChangeEventHandler(object sender, DataOVExp.SL010100RowChangeEvent e);
    }
}

