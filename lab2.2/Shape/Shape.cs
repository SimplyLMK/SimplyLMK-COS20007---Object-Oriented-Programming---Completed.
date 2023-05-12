using System.Collections.Generic;
using SplashKitSDK;
namespace ShapeDrawer
{
    public class Shape
    {
        private Color _color = Color.Green;
        private float _x;
        private float _y;
        private int _width;
        private int _height;
        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        public Shape(int x, int y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }


        public bool IsAt(Point2D coor)
        {
            return (coor.X >= _x && coor.X <= _x + _width) && (coor.Y >= _y && coor.Y <= _y + _height);
        }

        public Color Color
        {
            set
            {
                _color = value;
            }
        }

        public float X
        {
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            set 
            { 
                _y = value;
            }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }


        public static void Update(Shape shape)
        {
            shape.X = (float)SplashKit.MouseX() - shape.Width / 2;
            shape.Y = (float)SplashKit.MouseY() - shape.Height / 2;

            if (shape.IsAt(SplashKit.MousePosition()) && SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                shape.Color = SplashKit.RandomRGBColor(255);
            }
        }


    }
}