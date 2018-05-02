using System;
using System.Collections.Generic;
using System.Linq;

namespace Eblomino
{
    public class PlayerGrid
    {
        private int _width = 128;
        private Kreuz[] _grid;

        public PlayerGrid()
        {
            _grid = new Kreuz[_width * _width];
            Init(0, 0);
            Init(0, 1);
            Init(1, 0);
            Init(1, 1);
        }

        void Init(int x, int y)
        {
            this[x, y] = new Kreuz();
        }

        private Kreuz this[int x, int y]
        {
            get { return _grid[GetAddress(x, y)]; }
            set
            {
                if (x <= -_width / 2 || x >= _width / 2 || y <= -_width / 2 || y >= _width / 2)
                {
                    // TODO: resize
                    throw new InvalidOperationException();
                }

                var address = GetAddress(x, y);
                _grid[address] = value;
            }
        }

        private int GetAddress(int x, int y)
        {
            return x + _width / 2 + (y + _width / 2) * _width;
        }
    }
}