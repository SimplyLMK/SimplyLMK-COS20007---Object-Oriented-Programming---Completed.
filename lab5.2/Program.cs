using System;
using System.Net;
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

        public static void Main()
        {

            var drawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Line;
            Point2D startPoint = new Point2D();
            Point2D endPoint = new Point2D();
            Drawing myDrawing = new Drawing();

            Window window = new Window("Shape Drawer", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                else if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                else if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                    startPoint.X = SplashKit.MouseX();
                    startPoint.Y = SplashKit.MouseY();
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;

                    if (kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle newCircle = new MyCircle();
                        newCircle.X = SplashKit.MouseX();
                        newCircle.Y = SplashKit.MouseY();
                        newShape = newCircle;
                        myDrawing.AddShape(newShape);

                    }

                    else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle newRectangle = new MyRectangle();
                        newRectangle.X = SplashKit.MouseX();
                        newRectangle.Y = SplashKit.MouseY();
                        newShape = newRectangle;
                        myDrawing.AddShape(newShape);

                    }
                    else if (kindToAdd == ShapeKind.Line)
                    {
                        MyLine newLine = new MyLine();
                        if (startPoint.X == 0 && startPoint.Y == 0)
                        {
                            startPoint.X = SplashKit.MouseX();
                            startPoint.Y = SplashKit.MouseY();
                        }

                        else
                        {
                            endPoint.X = SplashKit.MouseX();
                            endPoint.Y = SplashKit.MouseY();

                            newLine.Update(startPoint, endPoint);
                            drawing.AddShape(newLine);


                            startPoint.X = 0;
                            startPoint.Y = 0;
                            endPoint.X = 0;
                            endPoint.Y = 0;
                        }
                        newShape = newLine;
                        myDrawing.AddShape(newShape);
                    }
                   
                       



                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomRGBColor(255);

                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(SplashKit.MousePosition());
                }
                if ((SplashKit.KeyTyped(KeyCode.DeleteKey)) || (SplashKit.KeyTyped(KeyCode.BackspaceKey)))
                {
                    foreach (Shape s in myDrawing.SelectedShapes())
                    {
                        myDrawing.RemoveShape(s);
                    }
                }

                if (SplashKit.KeyDown(KeyCode.SKey))
                {
                    myDrawing.Save("/Users/manhnguyen/Documents/Swinburne_lesson/OOP/assignment/Code/Lab5/5.2C/TestDrawing.txt");
                }

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        myDrawing.Load("/Users/manhnguyen/Documents/Swinburne_lesson/OOP/assignment/Code/Lab5/5.2C/TestDrawing.txt");
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                }



                myDrawing.Draw();
                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }
}
