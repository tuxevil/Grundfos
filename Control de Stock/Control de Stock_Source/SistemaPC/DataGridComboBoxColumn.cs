namespace SistemaPC
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    public class DataGridComboBoxColumn : DataGridColumnStyle
    {
        private System.Windows.Forms.ComboBox m_comboBox = new System.Windows.Forms.ComboBox();
        private DataGridColumnStylePadding m_padding;
        private int m_previouslyEditedCellRow;

        public DataGridComboBoxColumn()
        {
            this.m_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.m_comboBox.Visible = false;
            this.m_comboBox.SizeChanged += new EventHandler(this.ComboBox_SizeChanged);
            this.ControlSize = this.m_comboBox.Size;
            this.Padding = new DataGridColumnStylePadding(4, 8, 4, 8);
            this.Width = this.GetPreferredSize(null, null).Width;
            this.m_comboBox.Items.Add("Redmond, WA");
            this.m_comboBox.Items.Add("Albany, NY");
            this.m_comboBox.Items.Add("St. Louis, MO");
            this.m_comboBox.SelectedIndex = 0;
        }

        protected override void Abort(int rowNum)
        {
            this.m_comboBox.Visible = false;
        }

        private void ComboBox_SizeChanged(object sender, EventArgs e)
        {
            this.ControlSize = this.m_comboBox.Size;
            this.Width = this.GetPreferredSize(null, null).Width;
            this.Invalidate();
        }

        protected override bool Commit(CurrencyManager dataSource, int rowNum)
        {
            if (this.m_previouslyEditedCellRow == rowNum)
            {
                this.SetColumnValueAtRow(dataSource, rowNum, this.m_comboBox.SelectedIndex);
            }
            this.m_comboBox.Visible = false;
            return true;
        }

        protected override void Edit(CurrencyManager source, int rowNum, Rectangle bounds, bool readOnly, string instantText, bool cellIsVisible)
        {
            Debug.WriteLine("ComboBox Edit");
            Point point = this.DataGridTableStyle.DataGrid.PointToClient(Cursor.Position);
            Rectangle controlBounds = this.GetControlBounds(bounds);
            Rectangle rectangle2 = new Rectangle(point.X, point.Y, 1, 1);
            this.m_comboBox.SelectedIndex = IntegerType.FromObject(this.GetColumnValueAtRow(source, rowNum));
            Debug.WriteLine(DoubleType.FromString("SelectedItem: ") + this.m_comboBox.SelectedIndex);
            Point point2 = new Point(controlBounds.X, controlBounds.Y);
            this.m_comboBox.Location = point2;
            this.m_comboBox.Visible = true;
            if (rectangle2.IntersectsWith(controlBounds))
            {
                this.m_comboBox.DroppedDown = true;
            }
            this.m_previouslyEditedCellRow = rowNum;
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
            g.FillRectangle(new SolidBrush(Color.White), bounds);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            Rectangle controlBounds = this.GetControlBounds(bounds);
            int num = IntegerType.FromObject(this.GetColumnValueAtRow(source, rowNum));
            string text = this.m_comboBox.Items[num].ToString();
            RectangleF layoutRectangle = new RectangleF((float) (controlBounds.X + 1), (float) (controlBounds.Y + 4), (float) (controlBounds.Width - 3), (float) ((int) Math.Round((double) g.MeasureString(text, this.m_comboBox.Font).Height)));
            g.DrawString(text, this.m_comboBox.Font, foreBrush, layoutRectangle);
            ControlPaint.DrawBorder3D(g, controlBounds, Border3DStyle.Sunken);
            Rectangle rectangle = controlBounds;
            rectangle.Inflate(-2, -2);
            ControlPaint.DrawComboButton(g, rectangle.X + (controlBounds.Width - 20), rectangle.Y, 0x10, 0x11, ButtonState.Normal);
        }

        protected override void SetDataGridInColumn(DataGrid value)
        {
            base.SetDataGridInColumn(value);
            if (!value.Controls.Contains(this.m_comboBox))
            {
                value.Controls.Add(this.m_comboBox);
            }
        }

        public System.Windows.Forms.ComboBox ComboBox
        {
            get
            {
                return this.m_comboBox;
            }
        }

        public Size ControlSize
        {
            get
            {
                return this.m_comboBox.Size;
            }
            set
            {
                this.m_comboBox.Size = value;
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

