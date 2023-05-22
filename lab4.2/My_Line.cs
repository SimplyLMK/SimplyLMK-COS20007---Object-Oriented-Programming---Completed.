using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private Point2D _startPoint;
        private Point2D _endPoint;

        public MyLine() : base(Color.Red)
        {
        }

        public override void Draw()
        {
            if (Selected)
            {
                SplashKit.DrawLine(Color.Gray, _startPoint, _endPoint);
            }
            SplashKit.DrawLine(Color, _startPoint, _endPoint);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawRectangle(Color, _startPoint.X - 2, _startPoint.Y - 2, 4, 4);
            SplashKit.DrawRectangle(Color, _endPoint.X - 2, _endPoint.Y - 2, 4, 4);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(_startPoint, _endPoint));
        }

        public void Update(Point2D startPoint, Point2D endPoint)
        {
            _startPoint = startPoint;
            _endPoint = endPoint;
        }

        public override void Save_To(StreamWriter sw)
        {
            sw.WriteLine("Line");
            base.Save_To(sw);
            sw.WriteLine(_startPoint.X);
            sw.WriteLine(_startPoint.Y);
            sw.WriteLine(_endPoint.X);
            sw.WriteLine(_endPoint.Y);

        }

        public override void Load_From(StreamReader sr)
        {
            base.Load_From(sr);
            float startX = sr.ReadSingle();
            float startY = sr.ReadSingle();
            float endX = sr.ReadSingle();
            float endY = sr.ReadSingle();
            _startPoint = new Point2D() { X = startX, Y = startY };
            _endPoint = new Point2D() { X = endX, Y = endY };

        }
    }
}
