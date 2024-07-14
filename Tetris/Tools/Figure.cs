using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Tools
{
    public abstract class Figure
    {
        private List<Cell> cells;

        public Figure()
        {
            cells = new List<Cell>();
        }

        public List<Cell> Cells
        {
            get { return cells; }
            set { cells = value; }
        }

        public void Draw(Graphics g, float width, float height, Board b, float percent)
        {
            foreach (var cell in cells)
            {
                Tools.PaintCell(g, width, height, cell.X, cell.Y, cell, percent);
            }
        }

        private bool AnyDown(int i)
        {
            for (int j = 0; j < cells.Count; j++)
            {
                if (i == j) continue;

                if (cells[i].Y == cells[j].Y && cells[i].X <= cells[j].X)
                    return true;

            }

            return false;
        }

        public virtual bool Down(Board board, int i, int j)
        {
            return
                cells.All(
                    cell =>
                        cell.X + i < 0 ||
                        (cell.X + i < board.Rows && cell.Y + j >= 0 && cell.Y + j < board.Columns &&
                         board[cell.X + i, cell.Y + j] == null));
        }

        public bool MarkOk(Board board)
        {
            if (cells.Any(cell => (cell.X >= board.Rows
                                   || cell.Y >= board.Columns
                                   || cell.X < 0
                                   || cell.Y < 0)
                                  || board[cell.X, cell.Y] != null))
                return false;

            foreach (var cell in cells)
            {
                board[cell.X, cell.Y] = cell;

                cell.X = cell.X;
                cell.Y = cell.Y;
            }

            return true;
        }

        public void DownOk(Board board, int i, int j)
        {
            foreach (var cell in cells)
            {
                cell.X = cell.X + i;
                cell.Y = cell.Y + j;
            }
        }

        private bool CanRotate(Board b)
        {

            foreach (var cell in cells)
            {
                int X = cell.vX * 0 - cell.vY * 1;
                int Y = cell.vX * 1 + cell.vY * 0;

                int xv = cell.X + (cell.vY - Y);
                int yv = cell.Y + (X - cell.vX);

                if (xv >= b.Rows || yv < 0 || yv >= b.Columns)
                    return false;
            }

            return true;
        }

        public virtual void Rotate(Board b)
        {
            if(!CanRotate(b))
                return;

            foreach (var cell in cells)
            {
                int X = cell.vX*0 - cell.vY*1;
                int Y = cell.vX*1 + cell.vY*0;
                
                cell.X += (cell.vY - Y);
                cell.Y += (X - cell.vX );

                cell.vX = X;
                cell.vY = Y;

                
            }
        }
    }
}
