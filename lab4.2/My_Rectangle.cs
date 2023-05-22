using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{

    public class My_Rectangle : Shape
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public My_Rectangle(Color color, float x, float y, int width, int height) : base(color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public My_Rectangle() : this(Color.Green, 0, 0, 100, 100)
        {
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }

            SplashKit.FillRectangle(Color, X, Y, Width, Height);
        }

        public override void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, X - 2, Y - 2, Width + 4, Height + 4);
        }

        public override bool IsAt(Point2D p)
        {
            return SplashKit.PointInRectangle(p, SplashKit.RectangleFrom(X, Y, Width, Height));
        }

        public override void Save_To(StreamWriter sw)
        {
            sw.WriteLine("Rectangle");
            base.Save_To(sw);
            sw.WriteLine(Width);
            sw.WriteLine(Height);

        }
        public override void Load_From(StreamReader sr)
        {
            base.Load_From(sr);
            Width = sr.ReadInteger();
            Height = sr.ReadInteger();
        }

    }


}

