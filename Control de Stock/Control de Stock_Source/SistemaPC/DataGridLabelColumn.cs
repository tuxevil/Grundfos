namespace SistemaPC
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class DataGridLabelColumn : DataGridColumnStyle
    {
        private Size m_controlSize;
        private DataGridColumnStylePadding m_padding;

        public DataGridLabelColumn()
        {
            this.Padding = new DataGridColumnStylePadding(0);
            Size size = new Size(200, 0x18);
            this.ControlSize = size;
            this.Width = this.GetPreferredSize(null, null).Width;
        }

        protected override void Abort(int rowNum)
        {
        }

        protected override bool Commit(CurrencyManager dataSource, int rowNum)
        {
            return true;
        }

        protected override void Edit(CurrencyManager source, int rowNum, Rectangle bounds, bool readOnly, string instantText, bool cellIsVisible)
        {
        }

        protected override int GetMinimumHeight()
        {
            return this.GetPreferredHeight(null, null);
        }

        protected override int GetPreferredHeight(Graphics g, object value)
        {
            return ((this.ControlSize.Height + this.Padding.Top) + this.Padding.Bottom);
        }

        protected override Size GetPreferredSize(Graphics g, object value)
        {
            int width = (this.ControlSize.Width + this.Padding.Left) + this.Padding.Right;
            Size controlSize = this.ControlSize;
            return new Size(width, (controlSize.Height + this.Padding.Top) + this.Padding.Bottom);
        }

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum)
        {
            this.Paint(g, bounds, source, rowNum, false);
        }

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, bool alignToRight)
        {
            this.Paint(g, bounds, source, rowNum, Brushes.White, Brushes.Black, false);
        }

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Far;
            format.LineAlignment = StringAlignment.Center;
            format.FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.DirectionRightToLeft;
            g.FillRectangle(backBrush, bounds);
            RectangleF layoutRectangle = new RectangleF((float) bounds.X, (float) bounds.Y, (float) bounds.Width, (float) bounds.Height);
            g.DrawString(this.GetColumnValueAtRow(source, rowNum).ToString(), this.DataGridTableStyle.DataGrid.Font, foreBrush, layoutRectangle, format);
        }

        public Size ControlSize
        {
            get
            {
                return this.m_controlSize;
            }
            set
            {
                this.m_controlSize = value;
            }
        }

        public DataGridColumnStylePadding Padding
        {
            get
            {
                return this.m_padding;
            }
            set
            {
                this.m_padding = value;
            }
        }
    }
}

