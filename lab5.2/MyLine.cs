using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private Point2D _start;
        private Point2D _end;

        public MyLine() : base(Color.Green)
        {
        }

        public override void Draw()
        {
            if (Selected)
            {
                 DrawOutline();
            }
            SplashKit.DrawLine(Color, _start, _end);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color, _start.X - 2, _start.Y - 2, 5);
            SplashKit.DrawCircle(Color, _end.X - 2, _end.Y - 2, 5);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(_start , _end));
        }

        public void Update(Point2D startPoint, Point2D endPoint)
        {
            _start = startPoint;
            _end = endPoint;
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            //writer.WriteLine(_start);
            //writer.WriteLine(_end);

            writer.WriteLine(_start.X);
            writer.WriteLine(_start.Y);
            writer.WriteLine(_end.X);
            writer.WriteLine(_end.Y);

        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            //_start = reader.ReadSingle();
            //_end = reader.ReadSingle();
            float startX = reader.ReadSingle();
            float startY = reader.ReadSingle();
            float endX = reader.ReadSingle();
            float endY = reader.ReadSingle();
            _start = new Point2D() { X = startX, Y = startY };
            _end = new Point2D() { X = endX, Y = endY };

        }
    }
}

