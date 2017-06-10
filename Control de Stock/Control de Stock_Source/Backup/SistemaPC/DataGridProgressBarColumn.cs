namespace SistemaPC
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class DataGridProgressBarColumn : DataGridColumnStyle
    {
        private Size m_controlSize;
        private DataGridColumnStylePadding m_padding;
        private bool m_stretchToFit;

        public DataGridProgressBarColumn()
        {
            this.Padding = new DataGridColumnStylePadding(4, 8, 4, 8);
            Size size = new Size(80, 10);
            this.ControlSize = size;
            this.Width = this.GetPreferredSize(null, null).Width;
            this.m_stretchToFit = true;
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

        private Rectangle GetControlBounds(Rectangle cellBounds)
        {
            return new Rectangle(cellBounds.X + this.Padding.Left, cellBounds.Y + this.Padding.Top, this.ControlSize.Width, this.ControlSize.Height);
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
            g.FillRectangle(backBrush, bounds);
            Rectangle controlBounds = this.GetControlBounds(bounds);
            if (this.m_stretchToFit)
            {
                controlBounds.Width = bounds.Width - (this.Padding.Left + this.Padding.Right);
                controlBounds.X = bounds.X + this.Padding.Left;
            }
            Rectangle rect = new Rectangle(controlBounds.X + 2, controlBounds.Y + 2, controlBounds.Width - 3, controlBounds.Height - 3);
            int width = rect.Width;
            double num = ((double) rect.Width) / 100.0;
            rect.Width = (int) Math.Round((double) (IntegerType.FromObject(this.GetColumnValueAtRow(source, rowNum)) * num));
            if (rect.Width > width)
            {
                rect.Width = width;
            }
            using (Pen pen = new Pen(new SolidBrush(Color.Black)))
            {
                g.DrawRectangle(pen, controlBounds);
            }
            using (SolidBrush brush = new SolidBrush(Color.Red))
            {
                g.FillRectangle(brush, rect);
            }
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

        public bool StretchToFit
        {
            get
            {
                return this.m_stretchToFit;
            }
            set
            {
                this.m_stretchToFit = value;
            }
        }
    }
}

