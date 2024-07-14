using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Tools
{
    public static class Tools
    {
        public static void PaintCell(Graphics g, float width, float height, int i, int j, Cell cell,float percent)
        {

            float difw = width - width * percent;

            float difh = height - height * percent;

            Brush brush = new SolidBrush(cell.Color);

            g.FillRectangle(brush, j * width + difw / 2, i * height + difh / 2, width - difw, height - difh);
        }
    }
}
