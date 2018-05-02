using System;
using System.Collections.Generic;
using System.Linq;

namespace Eblomino
{
    public class PlayerGrid
    {
        private int width = 128;
        private List<Kreuz> grid;

        public PlayerGrid()
        {
            grid = new List<Kreuz>(width * width);
            grid.AddRange(Enumerable.Repeat<Kreuz>(null, width * width));
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
            get { return grid[GetAddress(x, y)]; }
            set
            {
                if (x <= -width / 2 || x >= width / 2 || y <= -width / 2 || y >= width / 2)
                {
                    // TODO: resize
                    throw new InvalidOperationException();
                }

                var address = GetAddress(x, y);
                grid[address] = value;
            }
        }

        private int GetAddress(int x, int y)
        {
            return x + width / 2 + (y + width / 2) * width;
        }
    }
}