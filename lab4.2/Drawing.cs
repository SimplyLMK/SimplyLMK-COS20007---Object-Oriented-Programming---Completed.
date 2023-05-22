using System.Collections.Generic;

using System.Linq;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes = new();
        private StreamWriter sw;
        private Shape s;
        private string kind;
        private int count;
        
        
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
        public void Save(string filename)
        {
            sw = new StreamWriter(filename);
            sw.WriteColor(Background);
            sw.WriteLine(ShapeCount);

            foreach (Shape s in _shapes)
            {
                s.Save_To(sw);
            }
            sw.Close();
        }

        public void Load(string filename)
        {
            StreamReader sr = new StreamReader(filename);

            try
            {
                Background = sr.ReadColor();
                count = sr.ReadInteger();
                _shapes.Clear();

                for (int i = 0; i < count; i++)
                {
                    kind = sr.ReadLine();

                    switch (kind)
                    {
                        case "Rectangle":
                            s = new My_Rectangle();
                            break;
                        case "Circle":
                            s = new My_Circle();
                            break;
                        case "Line":
                            s = new MyLine();
                            break;
                    }

                    s.Load_From(sr);
                    AddShape(s);
                }
            }

            finally
            {
                sr.Close();
            }



        }

    }
}
