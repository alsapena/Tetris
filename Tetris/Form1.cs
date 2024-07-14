using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Tools;
using Tetris.Tools.Figures;

namespace Tetris
{
    public partial class Form1 : Form
    {
        private Board b;
        private List<Figure> figures;
        private List<Figure> newFigures;

        public Form1()
        {
            InitializeComponent();

            b = new Board(20,10);

            //b[5,3] = new Cell(5,3,Color.Blue);

            figures = new List<Figure>();

            figures.Add(new Bar(3, 5, Color.Red));
            
            newFigures = new List<Figure>();

            NewRandom(newFigures);



            //figures.Add(new T(8, 5, Color.Green));

            //figures.Add(new L(8, 2, Color.Orange));

            //figures.Add(new Podium(12, 2, Color.Indigo));

            //figures.Add(new Z(12, 6, Color.IndianRed));
        }

        private int columns = 10;

        private int rows = 20;

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            float width = pictureBox1.Width/(float)b.Columns;

            float height = pictureBox1.Height/(float)b.Rows;

            for (int i = 1; i < b.Rows; i++)
                e.Graphics.DrawLine(Pens.White, 0, i*height, pictureBox1.Width, i*height);
            
            for (int i = 1; i < b.Columns; i++)
                e.Graphics.DrawLine(Pens.White, i * width, 0,i * width, pictureBox1.Height);

            PaintCells(e.Graphics);

            PaintFigures(e.Graphics);
        }

        private void PaintFigures(Graphics graphics)
        {
            float width = pictureBox1.Width / (float)b.Columns;

            float height = pictureBox1.Height / (float)b.Rows;

            foreach (var figure in figures)
            {
                figure.Draw(graphics, width, height, b, percent);
            }
        }

        float percent = 0.9f;

        private void PaintCells(Graphics g)
        {
            
            float width = pictureBox1.Width / (float)b.Columns;

            float height = pictureBox1.Height / (float)b.Rows;

            for (int i = 0; i < b.Rows; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    if (b[i, j] == null)
                        continue;

                    Tools.Tools.PaintCell(g, width, height, i, j, b[i, j], percent);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveFigure(1, 0, true);
        }

        private void NewRandom(List<Figure> ad)
        {
            Random r = new Random(Environment.TickCount);

            int ran = r.Next(0, 8);

            int midle = b.Columns/2;


            switch (ran)
            {
                case 1:
                    ad.Add(new Bar(-3, midle, Color.Red));
                    break;
                case 2:
                    ad.Add(new Z(-3, midle, Color.Green));
                    break;
                case 3:
                    ad.Add(new L(-3, midle, Color.CornflowerBlue));
                    break;
                case 4:
                    ad.Add(new Podium(-3, midle, Color.Gold));
                    break;
                case 5:
                    ad.Add(new T(-3, midle, Color.Fuchsia));
                    break;
                case 6:
                    ad.Add(new Square(-3, midle, Color.Yellow));
                    break;
                case 7:
                    ad.Add(new C(-3, midle, Color.DarkOrange));
                    break;
                default:
                    ad.Add(new Bar(-3, midle, Color.Red));
                    break;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    MoveFigure(0, -1, false);
                    break;
                case Keys.Right:
                    MoveFigure(0, 1, false);
                    break;

                case Keys.Down:
                    MoveFigure(1, 0, true);
                    break;

                case Keys.Up:
                    RotateFigure();
                    break;
            }
        }

        private void RotateFigure()
        {
            foreach (var fig in figures)
            {
                fig.Rotate(b);
            }
            pictureBox1.Invalidate();
        }

        private bool lost;

        private void MoveFigure(int i, int j,bool down)
        {
            if (lost)
                return;

            List<Figure> delete = new List<Figure>();

            List<Figure> news = new List<Figure>();

            if (figures.Count == 0)
                return;

            foreach (var fig in figures)
            {
                if (!fig.Down(b, i, j))
                {
                    if(!down)
                        continue;

                    delete.Add(fig);

                    if (fig.MarkOk(b))
                    {
                        news = newFigures;
 
                        newFigures = new List<Figure>();

                        NewRandom(newFigures);
                    }
                    else
                    {
                        lost = true;
                        
                        MessageBox.Show("You Lost");
                        
                        figures = new List<Figure>();
                        
                        return;
                    }
                }
                else
                {
                    fig.DownOk(b, i, j);
                }
            }

            delete.ForEach(x => figures.Remove(x));
            news.ForEach(x => figures.Add(x));

            Gravity();

            PaintAgain();
        }

        private void PaintAgain()
        {
            pictureBox1.Invalidate();

            pictureBox2.Invalidate();

            label1.Text = count.ToString();
        }

        private int count = 0;

        private void Gravity()
        {
            for (int i = 0; i < b.Rows; i++)
            {
                if (b.Complete(i))
                {
                    count += b.Columns;

                    b.CompleteRow(i);
                }
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lost = false;

            b = new Board(rows,columns);

            figures = new List<Figure>();

            NewRandom(figures);
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if(newFigures.Count <= 0)
                return;

            Figure f = newFigures[0];

            float width = pictureBox2.Width / 5f;

            float height = pictureBox2.Height/5f;

            foreach (var cell in f.Cells)
            {
                Tools.Tools.PaintCell(e.Graphics, width, height, 2 - cell.vY, cell.vX + 2, cell, 1);
            }
        }
        
    }
}
