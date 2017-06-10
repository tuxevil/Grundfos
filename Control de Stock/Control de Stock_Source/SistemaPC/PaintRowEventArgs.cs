namespace SistemaPC
{
    using System;
    using System.Drawing;

    public class PaintRowEventArgs : EventArgs
    {
        private Brush _backColor;
        private Brush _foreColor;
        private int _rowNum;

        public Brush BackColor
        {
            get
            {
                return this._backColor;
            }
            set
            {
                this._backColor = value;
            }
        }

        public Brush ForeColor
        {
            get
            {
                return this._foreColor;
            }
            set
            {
                this._foreColor = value;
            }
        }

        public int RowNumber
        {
            get
            {
                return this._rowNum;
            }
            set
            {
                this._rowNum = value;
            }
        }
    }
}

