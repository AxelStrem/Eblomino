namespace Eblomino
{
    public class Kreuz
    {
        private int _x;
        private int _y;

        private int _top;
        private int _bottom;
        private int _left;
        private int _right;

        private int _topRightMin;
        private int _topLeftMin;
        private int _bottomLeftMin;
        private int _bottomRightMin;

        public Kreuz(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int Top
        {
            get { return _top; }
            set { _top = value; }
        }

        public int Bottom
        {
            get { return _bottom; }
            set { _bottom = value; }
        }

        public int Left
        {
            get { return _left; }
            set { _left = value; }
        }

        public int Right
        {
            get { return _right; }
            set { _right = value; }
        }
    }
}