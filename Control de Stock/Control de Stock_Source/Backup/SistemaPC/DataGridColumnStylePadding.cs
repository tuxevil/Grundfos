namespace SistemaPC
{
    using System;

    public class DataGridColumnStylePadding
    {
        private int m_bottom;
        private int m_left;
        private int m_right;
        private int m_top;

        public DataGridColumnStylePadding(int padValue)
        {
            this.SetPadding(padValue);
        }

        public DataGridColumnStylePadding(int top, int right, int bottom, int left)
        {
            this.UpdatePaddingValues(top, right, bottom, left);
        }

        public void SetPadding(int padValue)
        {
            this.m_left = padValue;
            this.m_right = padValue;
            this.m_top = padValue;
            this.m_bottom = padValue;
        }

        public void SetPadding(int top, int right, int bottom, int left)
        {
            this.UpdatePaddingValues(top, right, bottom, left);
        }

        private void UpdatePaddingValues(int top, int right, int bottom, int left)
        {
            this.m_top = top;
            this.m_right = right;
            this.m_bottom = bottom;
            this.m_left = left;
        }

        public int Bottom
        {
            get
            {
                return this.m_bottom;
            }
            set
            {
                this.m_bottom = value;
            }
        }

        public int Left
        {
            get
            {
                return this.m_left;
            }
            set
            {
                this.m_left = value;
            }
        }

        public int Right
        {
            get
            {
                return this.m_right;
            }
            set
            {
                this.m_right = value;
            }
        }

        public int Top
        {
            get
            {
                return this.m_top;
            }
            set
            {
                this.m_top = value;
            }
        }
    }
}

