namespace SistemaPC
{
    using CrystalDecisions.CrystalReports.Engine;
    using System;
    using System.ComponentModel;

    public class RepEnsXFecha : ReportClass
    {
        public override string ResourceName
        {
            get
            {
                return "RepEnsXFecha.rpt";
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
                return this.ReportDefinition.Sections[0];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section2
        {
            get
            {
                return this.ReportDefinition.Sections[1];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section3
        {
            get
            {
                return this.ReportDefinition.Sections[2];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section4
        {
            get
            {
                return this.ReportDefinition.Sections[3];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section5
        {
            get
            {
                return this.ReportDefinition.Sections[4];
            }
        }
    }
}

