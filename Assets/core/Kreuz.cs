using System;

namespace Eblomino
{
    public class Kreuz : IComparable<Kreuz>
    {
        private readonly int _x;
        private readonly int _y;

        private int _top;
        private int _bottom;
        private int _left;
        private int _right;

        private int _topRightMin = int.MaxValue;
        private int _topLeftMin = int.MaxValue;
        private int _bottomLeftMin = int.MaxValue;
        private int _bottomRightMin = int.MaxValue;

        public Kreuz(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public int Top
        {
            get { return _top; }
            set
            {
                _topRightMin = Math.Min(value, _right);
                _topLeftMin = Math.Min(value, _left);
                _top = value;
            }
        }

        public int Bottom
        {
            get { return _bottom; }
            set
            {
                _bottomRightMin = Math.Min(value, _right);
                _bottomLeftMin = Math.Min(value, _left);
                _bottom = value;
            }
        }

        public int Left
        {
            get { return _left; }
            set
            {
                _topLeftMin = Math.Min(value, _top);
                _bottomLeftMin = Math.Min(value, _bottom);
                _left = value;
            }
        }

        public int Right
        {
            get { return _right; }
            set
            {
                _topRightMin = Math.Min(value, _top);
                _bottomRightMin = Math.Min(value, _bottom);
                _right = value;
            }
        }

        public int TopRightMin
        {
            get { return _topRightMin; }
        }

        public int TopLeftMin
        {
            get { return _topLeftMin; }
        }

        public int BottomLeftMin
        {
            get { return _bottomLeftMin; }
        }

        public int BottomRightMin
        {
            get { return _bottomRightMin; }
        }

        public int CompareTo(Kreuz other)
        {
            var result = _x.CompareTo(other._x);
            return result != 0 ? _y.CompareTo(other._y) : result;
        }

        public override string ToString()
        {
            return "[" + _x + ", " + _y + "] (↑" + _top + ", ↓" + _bottom + ", →" + _right + ", ←" + _left +
                   " )";
        }
    }
}