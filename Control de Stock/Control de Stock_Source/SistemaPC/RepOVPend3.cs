namespace SistemaPC
{
    using CrystalDecisions.CrystalReports.Engine;
    using System;
    using System.ComponentModel;

    public class RepOVPend3 : ReportClass
    {
        public override string ResourceName
        {
            get
            {
                return "RepOVPend3.rpt";
            }
            set
            {
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section1
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(0);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section10
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(2);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section11
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(6);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section2
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(1);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section3
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(4);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section4
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(7);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section5
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(8);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section6
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(3);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section7
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(5);
            }
        }
    }
}

