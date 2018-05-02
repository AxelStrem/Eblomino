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
            var kreuz = new Kreuz(x, y);
            kreuz.Left = OffsetLength(x, y, -1, 0);
            kreuz.Right = OffsetLength(x, y, 1, 0);
            kreuz.Top = OffsetLength(x, y, 0, 1);
            kreuz.Bottom = OffsetLength(x, y, 0, -1);
            UpdateNeigborsX(x, y, 1, kreuz.Left + 1);
            UpdateNeigborsX(x, y, -1, kreuz.Right + 1);
            UpdateNeigborsY(x, y, 1, kreuz.Bottom + 1);
            UpdateNeigborsY(x, y, -1, kreuz.Top + 1);
            this[x, y] = kreuz;
        }

        public void Print()
        {
            foreach (var kreuz in _grid)
            {
                if (kreuz != null)
                {
                    Console.WriteLine("Kreuz at [" + kreuz.X + ", " + kreuz.Y + "] (↑" + kreuz.Top + ", ↓" + kreuz.Bottom +
                                      ", →" + kreuz.Right + ", ←" + kreuz.Left + " )");
                }
            }
        }
        
        private void UpdateNeigborsX(int x, int y, int deltaX, int delta)
        {
            x += deltaX;
            var neighbor = this[x, y];
            while (neighbor != null)
            {
                if (deltaX < 0)
                {
                    neighbor.Right += delta;
                }
                else if (deltaX > 0)
                {
                    neighbor.Left += delta;
                }
                x += deltaX;
                neighbor = this[x, y];
            }
        }
        
        private void UpdateNeigborsY(int x, int y, int deltaY, int delta)
        {
            y += deltaY;
            var neighbor = this[x, y];
            while (neighbor != null)
            {
                if (deltaY < 0)
                {
                    neighbor.Top += delta;
                }
                else if (deltaY > 0)
                {
                    neighbor.Bottom += delta;
                }
                y += deltaY;
                neighbor = this[x, y];
            }
        }

        private int OffsetLength(int x, int y, int deltaX, int deltaY)
        {
            var neighbor = this[x + deltaX, y + deltaY];
            int length;
            if (neighbor != null)
            {
                if (deltaX < 0)
                {
                    length = neighbor.Left + 1;
                }
                else if (deltaX > 0)
                {
                    length = neighbor.Right + 1;
                }
                else if (deltaY < 0)
                {
                    length = neighbor.Bottom + 1;
                }
                else if (deltaY > 0)
                {
                    length = neighbor.Top + 1;
                }
                else
                {
                    length = 0;
                }
            }
            else
            {
                length = 0;
            }

            return length;
        }

        private Kreuz this[int x, int y]
        {
            get
            {
                if (x <= -_width / 2 || x >= _width / 2 || y <= -_width / 2 || y >= _width / 2)
                {
                    return null;
                }

                return _grid[GetAddress(x, y)];
            }
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