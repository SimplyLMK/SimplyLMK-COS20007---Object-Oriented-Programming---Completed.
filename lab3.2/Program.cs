using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private const int Width = 800;
        private const int Height = 600;

        private static void Main()
        {
            var drawing = new Drawing();

            new Window("Drawing Shape", Width, Height);

            while (!SplashKit.WindowCloseRequested("Drawing Shape"))
            {
                SplashKit.ProcessEvents();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    var x = SplashKit.MouseX();
                    var y = SplashKit.MouseY();
                    var shape = new Shape { X = x, Y = y };
                    drawing.AddShape(shape);
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

                if (SplashKit.KeyTyped(KeyCode.BackspaceKey) || SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    drawing.RemoveShape();
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomRGBColor(255);
                }

                drawing.Draw();

                SplashKit.RefreshScreen();
            }
        }

   
    }
}
