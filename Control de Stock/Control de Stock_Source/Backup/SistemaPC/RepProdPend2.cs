namespace SistemaPC
{
    using CrystalDecisions.CrystalReports.Engine;
    using System;
    using System.ComponentModel;

    public class RepProdPend2 : ReportClass
    {
        public override string ResourceName
        {
            get
            {
                return "RepProdPend2.rpt";
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
                return this.get_ReportDefinition().get_Sections().get_Item(2);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section4
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(3);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section5
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(4);
            }
        }
    }
}

