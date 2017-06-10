namespace SistemaPC
{
    using CrystalDecisions.CrystalReports.Engine;
    using System;
    using System.ComponentModel;

    public class ConsultaOVPendEnt : ReportClass
    {
        public override string ResourceName
        {
            get
            {
                return "ConsultaOVPendEnt.rpt";
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section8
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(2);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section9
        {
            get
            {
                return this.get_ReportDefinition().get_Sections().get_Item(6);
            }
        }
    }
}

