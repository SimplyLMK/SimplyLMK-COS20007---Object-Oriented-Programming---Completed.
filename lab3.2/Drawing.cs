using System.Collections.Generic;
using System.Linq;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes = new();
        public Color Background { get; set; } = Color.White;

        public List<Shape> SelectedShapes()
        {
            return _shapes.Where(s => s.Selected).ToList();
        }


        public int ShapeCount
        {
            get
            {
                return _shapes.Count;
            }
        }


        public void Draw()
        {
            SplashKit.ClearScreen(Background);

            foreach (var shape in _shapes)
            {
                shape.Draw();
            }
        }

       

        public void SelectedShapePos(Point2D pt)
        {
            foreach (var shape in _shapes)
            {
                shape.Selected = shape.IsAt(pt);
            }
        }

        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }

        public void RemoveShape()
        {
            SelectedShapes().ForEach(s => _shapes.Remove(s));
        }

    }
}
