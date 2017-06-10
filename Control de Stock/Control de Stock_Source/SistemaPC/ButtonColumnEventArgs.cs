namespace SistemaPC
{
    using System;

    public class ButtonColumnEventArgs : EventArgs
    {
        private string m_buttonValue;
        private int m_columnNum;
        private int m_rowNum;

        public ButtonColumnEventArgs(int rowNum, int columnNum, string buttonValue)
        {
            this.m_rowNum = rowNum;
            this.m_columnNum = columnNum;
            this.m_buttonValue = buttonValue;
        }

        public string ButtonValue
        {
            get
            {
                return this.m_buttonValue;
            }
        }

        public int Column
        {
            get
            {
                return this.m_columnNum;
            }
        }

        public int Row
        {
            get
            {
                return this.m_rowNum;
            }
        }
    }
}

