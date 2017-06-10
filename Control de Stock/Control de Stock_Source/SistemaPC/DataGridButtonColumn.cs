namespace SistemaPC
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class DataGridButtonColumn : DataGridColumnStyle
    {
        private Size m_controlSize;
        private Rectangle m_depressedBounds;
        private DataGridColumnStylePadding m_padding;

        public event ButtonColumnClickHandler Click;

        public DataGridButtonColumn()
        {
            Size size = new Size(80, 15);
            this.ControlSize = size;
            this.Padding = new DataGridColumnStylePadding(4, 8, 4, 8);
            this.Width = this.GetPreferredSize(null, null).Width;
        }

        protected override void Abort(int rowNum)
        {
        }

        protected override bool Commit(CurrencyManager dataSource, int rowNum)
        {
            return true;
        }

        private void DataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            DataGrid.HitTestInfo info = this.DataGridTableStyle.DataGrid.HitTest(e.X, e.Y);
            if ((info.Column != -1) && (((e.Button == MouseButtons.Left) & (info.Type == DataGrid.HitTestType.Cell)) & (this.DataGridTableStyle.GridColumnStyles[info.Column] is DataGridButtonColumn)))
            {
                Rectangle rectangle3 = new Rectangle(e.X, e.Y, 1, 1);
                Rectangle cellBounds = this.DataGridTableStyle.DataGrid.GetCellBounds(info.Row, info.Column);
                Rectangle controlBounds = this.GetControlBounds(cellBounds);
                if (rectangle3.IntersectsWith(controlBounds))
                {
                    this.m_depressedBounds = cellBounds;
                    this.DataGridTableStyle.DataGrid.Invalidate(cellBounds);
                }
            }
        }

        private void DataGrid_MouseUp(object sender, MouseEventArgs e)
        {
            DataGrid.HitTestInfo info = this.DataGridTableStyle.DataGrid.HitTest(e.X, e.Y);
            if (!this.m_depressedBounds.Equals(Rectangle.Empty))
            {
                Rectangle cellBounds = this.DataGridTableStyle.DataGrid.GetCellBounds(info.Row, info.Column);
                if (this.m_depressedBounds.Equals(cellBounds))
                {
                    Rectangle rectangle3 = new Rectangle(e.X, e.Y, 1, 1);
                    Rectangle controlBounds = this.GetControlBounds(cellBounds);
                    if (rectangle3.IntersectsWith(controlBounds))
                    {
                        object objectValue = RuntimeHelpers.GetObjectValue(this.DataGridTableStyle.DataGrid.DataSource);
                        string dataMember = this.DataGridTableStyle.DataGrid.DataMember;
                        CurrencyManager source = (CurrencyManager) this.DataGridTableStyle.DataGrid.BindingContext[RuntimeHelpers.GetObjectValue(objectValue), dataMember];
                        string str = StringType.FromObject(this.GetColumnValueAtRow(source, info.Row));
                        if (str.ToLower().Equals("start"))
                        {
                            str = "Stop";
                        }
                        else if (str.ToLower().Equals("stop"))
                        {
                            str = "Start";
                        }
                        this.SetColumnValueAtRow(source, info.Row, str);
                        if (this.ClickEvent != null)
                        {
                            this.ClickEvent(new ButtonColumnEventArgs(info.Row, info.Column, str));
                        }
                    }
                }
                this.m_depressedBounds = Rectangle.Empty;
                this.DataGridTableStyle.DataGrid.Invalidate(cellBounds);
            }
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
            controlBounds.Inflate(-4, -4);
            RectangleF layoutRectangle = new RectangleF((float) bounds.X, (float) bounds.Y, (float) bounds.Width, (float) bounds.Height);
            layoutRectangle.Inflate(-3f, -3f);
            ButtonState inactive = ButtonState.Inactive;
            ControlPaint.DrawButton(g, controlBounds, inactive);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            format.FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.DirectionRightToLeft;
            g.DrawString(this.GetColumnValueAtRow(source, rowNum).ToString(), this.DataGridTableStyle.DataGrid.Font, foreBrush, layoutRectangle, format);
        }

        protected override void SetDataGridInColumn(DataGrid value)
        {
            base.SetDataGridInColumn(value);
            this.DataGridTableStyle.DataGrid.MouseDown += new MouseEventHandler(this.DataGrid_MouseDown);
            this.DataGridTableStyle.DataGrid.MouseUp += new MouseEventHandler(this.DataGrid_MouseUp);
        }

        public virtual Size ControlSize
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

        public delegate void ButtonColumnClickHandler(ButtonColumnEventArgs e);
    }
}

