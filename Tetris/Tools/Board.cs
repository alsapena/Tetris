using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Tools
{
    public class Board
    {
        private Cell[,] cells;

        public int Rows { get; set; }

        public int Columns { get; set; }

        public Board(int x,int y)
        {
            Rows = x;
            Columns = y;

            cells = new Cell[x, y];
        }

        public Cell this[int x,int y]
        {
            get
            {
                if (x < 0 || x >= Rows || y < 0 || y >= Columns)
                    throw new Exception("Dimensions wrong");

                return cells[x, y];
            }
            set
            {
                /* set the specified index to value here */

                if (x < 0 || x >= Rows || y < 0 || y >= Columns)
                    throw new Exception("Dimensions wrong");

                cells[x, y] = value;

            }
        }

        public bool Complete(int i)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (cells[i, j] == null)
                    return false;
            }

            return true;
        }

        public void CompleteRow(int i)
        {
            for (int j = 0; j < Columns; j++)
            {
                cells[i, j] = null;
                FixColumn(i, j);
            }
        }

        private void FixColumn(int i, int j)
        {
            for (int r = i ; r >= 1; r--)
            {
                //Swap(r, j, r - 1, j);

                cells[r, j] = cells[r - 1, j];

                if (cells[r, j] != null)
                {
                    cells[r, j].X = r;
                    cells[r, j].Y = j;
                }
            }
        }

        private void Swap(int i, int j, int i1, int j1)
        {
            Cell temp = cells[i, j];

            cells[i, j] = cells[i1, j1];

            cells[i1, j1] = temp;
        }
    }
}
