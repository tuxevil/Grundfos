namespace SistemaPC
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class CustomDataGridTextBoxColumn : DataGridTextBoxColumn
    {
        public event PaintRowEventHandler PaintRow;

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            PaintRowEventArgs args = new PaintRowEventArgs();
            args.RowNumber = rowNum;
            if (this.PaintRowEvent != null)
            {
                this.PaintRowEvent(args);
            }
            if (args.BackColor != null)
            {
                backBrush = args.BackColor;
            }
            if (args.ForeColor != null)
            {
                foreBrush = args.ForeColor;
            }
            args = null;
            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        }

        public delegate void PaintRowEventHandler(PaintRowEventArgs args);
    }
}

