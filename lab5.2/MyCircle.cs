using System;
using SplashKitSDK;

namespace ShapeDrawer
{
	public class MyCircle : Shape
	{
        private int _radius;

        public MyCircle() : this(Color.Blue, 50)
        {
        }

        public MyCircle(Color clr, int radius) : base(clr)
        {
           
            _radius = radius;
        }

        public override bool IsAt(Point2D pt)
        {
            
            double x2 = (pt.X - X) * (pt.X - X);
            double y2 = (pt.Y - Y) * (pt.Y - Y);

            if (Math.Sqrt(x2 + y2) < _radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillCircle(Color, X, Y, _radius);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, _radius + 2);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(_radius);

        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _radius = reader.ReadInteger();
        }

    }
}

