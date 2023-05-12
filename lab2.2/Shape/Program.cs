using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800,600);
            Shape shape = new Shape(0, 0, 100, 100);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();   
                shape.Draw();
                Shape.Update(shape);
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);

            
        }
    }
}