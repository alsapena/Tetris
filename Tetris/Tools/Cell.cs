using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Tools
{
    public class Cell
    {
        public Color Color { get; set; }
        public int X { get; set; }

        public int Y { get; set; }

        public int vX { get; set; }

        public int vY { get; set; }

        public Cell(int x,int y,int vx,int vy, Color color)
        {
            Color = color;
            X = x;
            Y = y;
            vX = vx;
            vY = vy;
        }
    }
}
