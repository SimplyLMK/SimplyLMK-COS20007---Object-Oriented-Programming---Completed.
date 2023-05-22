using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        public Color Color { get; set; } = Color.Green;
        public float X { get; set; }
        public float Y { get; set; }
        public int Width { get; } = 100;
        public int Height { get; } = 100;

        public bool Selected { get; set; }

        public Shape(Color color)
        {
            Color = color;
            //float x = X;
            //float y = Y;
            //float width = Width;
            //float height = Height;
            //bool selected = Selected;
        }

        public abstract void Draw();
       // {
       //     if (Selected)
       //     {
       //         DrawOutline();
       //     }
       //     SplashKit.FillRectangle(Color, X, Y, Width, Height);
   
       //}

        public abstract bool IsAt(Point2D p);
        //{
        //    //return SplashKit.PointInRectangle(p, SplashKit.RectangleFrom(X, Y, Width, Height));
        //    return false;
        //}


        public abstract void DrawOutline();
        //{
        //   // SplashKit.FillRectangle(Color.Black, X - 2, Y - 2, Width + 4, Height + 4);
        //}


        public static void Update(Shape shape)
        {
            shape.X = (float)SplashKit.MouseX() - shape.Width / 2;
            shape.Y = (float)SplashKit.MouseY() - shape.Height / 2;
            shape.Color = SplashKit.RandomRGBColor(255);
        }

        public virtual void Save_To(StreamWriter sw)
        {
            sw.WriteColor(Color);
            sw.WriteLine(X);
            sw.WriteLine(Y);
        }

        public virtual void Load_From(StreamReader sr)
        {
            Color = sr.ReadColor();
            X = sr.ReadInteger();
            Y = sr.ReadInteger();
        }


    }
}
