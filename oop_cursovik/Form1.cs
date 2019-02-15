using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace oop_cursovik
{
    public partial class Form1 : Form
    {
        private Graphics g;
        private Bitmap bitmap;
        public Color bcg;   // цвет фона
        private bool stop = true;   // флаг остановки для цикла
        private List<tShape> house;
        private int cX; // координаты центра экрана (центра области рисования)
        private int cY; //
        private const int h = 5;
        private const int HWidth = 120; // ширина домика
        private const int HHeight = 100;// высота домика
        private const int WHeight = 60; //высота окна
        private const int WWidth = 50;  //ширина окна
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bcg = Color.White;
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            
            cX = pictureBox1.Width / 2;     // устанвливем центр экрана
            cY = pictureBox1.Height / 2;

            house = new List<tShape>(); // список примитивов для рисования домика

            // рисуем стену
            tRectangle wall = new tRectangle(cX - HWidth/2, cY - HHeight/2, HWidth, HHeight, Color.Black, Color.Orange, 1);
            house.Add(wall);
            //окно
            tRectangle window = new tRectangle(cX - WWidth /2, cY - WHeight/2, WWidth, WHeight, Color.Black, Color.Orange, 1);
            tLine w1 = new tLine(cX, cY - WHeight /2, cX, cY + WHeight/2, Color.Black, 1);
            tLine w2 = new tLine(cX, cY - WHeight/5, cX + WWidth /2, cY - WHeight / 5, Color.Black, 1);
            house.Add(window);
            house.Add(w1);
            house.Add(w2);

            // крыша
            tLine roof_left = new tLine(cX, cY - HHeight-5, cX - HWidth / 2 - 20, cY - WHeight / 2, Color.Green, 2);
            tLine roof_right = new tLine(cX, cY - HHeight-5, cX + HWidth / 2 + 20, cY - WHeight / 2, Color.Green, 2);
            house.Add(roof_left);
            house.Add(roof_right);


            foreach( tShape part in house)
            {
                part.Draw(g);
            }

            pictureBox1.Image = bitmap;

        }

        private void radioMoveArrow_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                e.IsInputKey = true;
        }

        private void radioMoveRandom_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                e.IsInputKey = true;
        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                e.IsInputKey = true;
        }

        // движение стрелками
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int stepX = 0;
            int stepY = 0;
            stop = true;

            switch (e.KeyCode)
            {
                case Keys.Up: { stepY = -h; break; }
                case Keys.Down: { stepY = h; break; }
                case Keys.Left: { stepX = -h; break; }
                case Keys.Right: { stepX = h; break; }
            }
 
            foreach( tShape part in house) //проверка на выход за границы области рисования
            {
                part.stepX = stepX;
                part.stepY = stepY;
                if (part.CheckOutX(pictureBox1.Width, pictureBox1.Height) || part.CheckOutY(pictureBox1.Width, pictureBox1.Height)) return;              
            }

            g.Clear(pictureBox1.BackColor); // перемещение объекта и отрисовка по новым координатам
            foreach( tShape part in house)
            {
                part.Move();
                part.Draw(g);
            }
            pictureBox1.Image = bitmap;
        }


        private void radioMoveArrow_CheckedChanged(object sender, EventArgs e)
        {
            if(radioMoveArrow.Checked)
            {
                stop = true;
            }

        }

        private void radioMoveRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMoveRandom.Checked)
            {
                stop = false;

                Random rnd = new Random();
                int stepX;
                int stepY;
                do
                {
                    stepX = rnd.Next(-3, 3);
                    stepY = rnd.Next(-3, 3);
                } while ((stepX == 0) && (stepY == 0));


                while (!stop)
                {
                    bool moved = false;
                    do
                    {

                        foreach (tShape part in house)
                        {
                            part.stepX = stepX;
                            part.stepY = stepY;

                            if (part.CheckOutX(pictureBox1.Width, pictureBox1.Height))
                            {
                                moved = false;
                                if (stepX > 0)
                                {
                                    stepX = rnd.Next(-3, -1);
                                } else stepX = rnd.Next(1, 3);
                                stepY = rnd.Next(-3, 3);
                                break;
                            }
                            if (part.CheckOutY(pictureBox1.Width, pictureBox1.Height))
                            {
                                moved = false;
                                if (stepY > 0)
                                {
                                    stepY = rnd.Next(-3, -1);
                                } else stepY = rnd.Next(1, 3);
                                stepX = rnd.Next(-3, 3);
                                break;
                            }
                            moved = true;
                        }

                    } while (!moved);

                    g.Clear(pictureBox1.BackColor);
                    foreach (tShape part in house)
                    {
                        part.Move();
                        part.Draw(g);
                    }
                    Thread.Sleep(3);
                    Application.DoEvents();
                    pictureBox1.Image = bitmap;
                }
            }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);

            cX = pictureBox1.Width / 2;     // устанвливем центр экрана
            cY = pictureBox1.Height / 2;
            foreach (tShape part in house)
            {
                part.Draw(g);
            }
            pictureBox1.Image = bitmap;
       }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
