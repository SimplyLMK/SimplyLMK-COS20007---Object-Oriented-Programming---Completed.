using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class My_Circle : Shape
    {

        public int Radius { get; set; }
        public float X { get; set; }
        public float Y { get; set; }


        public My_Circle(Color color, int radius) : base(color)
        {
            Radius = radius;
        }

        public My_Circle() : this(Color.Blue, 50)
        {
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }

            SplashKit.FillCircle(Color, X, Y, Radius);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Red, X, Y, Radius + 2);
        }

       

       public override bool IsAt(Point2D pt) //student note: For some perculliar reason the PointInCircle method does not work. Despite passing the correct arguments, the program returns overload error. My friend had the same problem so we have to resorted to math instead. We check the PointInCircle method in SplashKit lib and it confirm that the arguments we pass is correct. #Line13659 in the lib
        {
            double distance = Math.Sqrt(Math.Pow(pt.X - X, 2) + Math.Pow(pt.Y - Y, 2));
            return distance <= Radius;
        }

        public override void Save_To(StreamWriter sw)
        {
            sw.WriteLine("Circle");
            base.Save_To(sw);
            sw.WriteLine(Radius);

        }

        public override void Load_From(StreamReader sr)
        {
            base.Load_From(sr);
            Radius = sr.ReadInteger();
        }

    }

}

