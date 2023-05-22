using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        private static void Main()
        {
            ShapeKind kindToAdd = ShapeKind.Circle;

            var drawing = new Drawing();
            Point2D startPoint = new Point2D();
            Point2D endPoint = new Point2D();
            MyLine newLine = new MyLine();

            new Window("Drawing Shape", 800, 600);

            while (!SplashKit.WindowCloseRequested("Drawing Shape"))
            {
                SplashKit.ProcessEvents();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    var x = SplashKit.MouseX();
                    var y = SplashKit.MouseY();

                    if (kindToAdd == ShapeKind.Circle)
                    {
                        My_Circle newCircle = new My_Circle { X = x, Y = y };
                        drawing.AddShape(newCircle);
                    }
                    else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        My_Rectangle newRect = new My_Rectangle(Color.Yellow, x, y, 100, 100);
                        drawing.AddShape(newRect);
                    }
                    else if (kindToAdd == ShapeKind.Line)
                    {
                       
                        if (startPoint.X == 0 && startPoint.Y == 0)
                        {
                            startPoint.X = x;
                            startPoint.Y = y;
                        }
            
                        else
                        {
                            endPoint.X = x;
                            endPoint.Y = y;
                            
                            newLine.Update(startPoint, endPoint);
                            drawing.AddShape(newLine);

                            
                            startPoint.X = 0;
                            startPoint.Y = 0;
                            endPoint.X = 0;
                            endPoint.Y = 0;
                        }
                    }

                    drawing.SelectedShapePos(SplashKit.MousePosition());
                }

                if (SplashKit.KeyTyped(KeyCode.KKey))
                {
                    var selectedShapes = drawing.SelectedShapes();
                    foreach (var shape in selectedShapes)
                    {
                        Shape.Update(shape);
                    }
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectedShapePos(SplashKit.MousePosition());
               
                }
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.KeyTyped(KeyCode.BackspaceKey) || SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    drawing.RemoveShape();
                }


                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                else if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                else if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }
                if (SplashKit.KeyDown(KeyCode.SKey))
                {
                    drawing.Save("C:\\C#\\CODE\\lab4\\4.2\\4.2\\Saved.txt");
                }

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {                
                     drawing.Load("C:\\C#\\CODE\\lab4\\4.2\\4.2\\Saved.txt");                 
                }


                SplashKit.ClearScreen(Color.White);
                drawing.Draw();
                SplashKit.RefreshScreen();
            }

            SplashKit.CloseWindow("Drawing Shape");
        }
    }
}
