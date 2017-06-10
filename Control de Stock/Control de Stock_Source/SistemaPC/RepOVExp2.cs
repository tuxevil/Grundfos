namespace SistemaPC
{
    using CrystalDecisions.CrystalReports.Engine;
    using System;
    using System.ComponentModel;

    public class RepOVExp2 : ReportClass
    {
        public override string ResourceName
        {
            get
            {
                return "RepOVExp2.rpt";
            }
            set
            {
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
                return this.get_ReportDefinition().get_Sections().get_Item(4);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section11
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(10);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section12
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(5);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section13
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(9);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section16
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(6);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section17
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(8);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section2
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(1);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section3
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(7);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section4
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(13);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section5
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(14);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section6
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(2);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section7
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(12);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section8
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(3);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section9
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(11);
            }
        }
    }
}

