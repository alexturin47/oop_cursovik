using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace oop_cursovik
{
    abstract class tShape
    {
        public int stepX { get; set; }
        public int stepY { get; set; }

        public abstract void Move();
        public abstract void Draw(Graphics g);
        public abstract bool CheckOut(int width, int height);
    }

    class tPoint : tShape
    {
        private Point _point;

        public tPoint()
        {
            point = new Point(0,0);
            stepX = 0;
            stepY = 0;
        }

        public tPoint(int x, int y)
        {
            point = new Point(x,y);
            stepX = 0;
            stepY = 0;
        }

        public Point point
        {
            get { return _point; }
            set
            {
                _point.X = value.X;
                _point.Y = value.Y;
            }
        }

        public override bool CheckOut(int width, int height)
        {
            if (point.X + stepX >= width || point.X + stepX <= 0) return true;
            if (point.Y + stepY >= width || point.Y + stepY <= 0) return true;
            return false;
        }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            int x = point.X;
            int y = point.Y;          
            x += stepX;
            y += stepY;
            Point pt = new Point(x, y);
            point = pt;
        }
    }

    class tLine : tShape
    {
        public tPoint p1 { get; set; }
        public tPoint p2 { get; set; }
        public Color color { get; set; }
        public int lineWidth { get; set; }

        public tLine()
        {
            p1 = new tPoint(0, 0);
            p2 = new tPoint(0, 0);
            color = Color.Black;
            lineWidth = 1;
        }

        public tLine(int x1, int y1, int x2, int y2, Color clr, int lwidth)
        {
            p1 = new tPoint(x1, y1);
            p2 = new tPoint(x2, y2);
            color = clr;
            lineWidth = lwidth;
        }


        public override bool CheckOut(int width, int height)
        {
            if (p1.CheckOut(width, height) == true && p2.CheckOut(width, height) == true) return true;
            return false;
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(color, lineWidth);
            g.DrawLine(pen, p1.point, p2.point);
        }

        public override void Move()
        {
            p1.Move();
            p2.Move();
        }
    }

    class tRectangle: tShape
    {
        public tPoint p1 { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Color colorLine { get; set; }
        public Color fill { get; set; }
        public int lineWidth;

        public tRectangle()
        {
            p1 = new tPoint(0, 0);
            width = 1;
            height = 1;
            colorLine = Color.Black;
            fill = Color.White;
            lineWidth = 1;
        }

        public tRectangle( int x, int y, int _width, int _height, Color _lineColor, Color _fillColor, int _lineWidth)
        {
            p1 = new tPoint(x, y);
            width = _width;
            height = _height;
            colorLine = _lineColor;
            fill = _fillColor;
            lineWidth = _lineWidth;
        }

        
        public override bool CheckOut(int _width, int _height)
        {
            if (p1.point.X + stepX <= 0 || p1.point.X + width + stepX >= _width || p1.point.Y + stepY <= 0 || p1.point.Y + height +stepY >= _height) return true;
            return false;
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(colorLine, lineWidth);
            SolidBrush br = new SolidBrush(fill);
            g.DrawRectangle(pen, p1.point.X, p1.point.Y, width, height);
            g.FillRectangle(br, p1.point.X, p1.point.Y, width, height);
        }

        public override void Move()
        {
            p1.Move();
        }
    }
}
