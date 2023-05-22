using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custom_projD
{
    public class Choose_AI_Opponent
    {
        private Bitmap background;
        private Bitmap lv1;
        private Bitmap lv15;
        private Bitmap lv100;
        public enum DepthLevel
        {
            Level1,
            Level2,
            Level3
        }

        private bool ClickedInside(Rectangle rect)
        {
            return SplashKit.MouseClicked(MouseButton.LeftButton) && SplashKit.PointInRectangle(SplashKit.MousePosition(), rect);
        }

        public DepthLevel Choose_Depth()
        {
            Window window = new Window("Choose AI Depth", 1000, 800);
            Color textColor = Color.Black;
            Font font = SplashKit.LoadFont("AmaticSC-Regular", "Media\\AmaticSC-Regular.ttf");
            Rectangle depth_1 = new Rectangle { X = 50, Y = 450, Width = 200, Height = 50 };
            Rectangle depth_2 = new Rectangle { X = 400, Y = 450, Width = 200, Height = 50 };
            Rectangle depth_3 = new Rectangle { X = 750, Y = 450, Width = 200, Height = 50 };


            while (!window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.White);

                background = SplashKit.LoadBitmap("bg", "Media\\bg_mod.png");
                lv1 = SplashKit.LoadBitmap("lv_1", "Media\\lv_1.png");
                lv15 = SplashKit.LoadBitmap("lv_15", "Media\\lv_15.png");
                lv100 = SplashKit.LoadBitmap("lv_100", "Media\\lv_100.jpg");

                SplashKit.DrawBitmap(background, -300, 0);

                SplashKit.DrawText("CHOOSE YOUR OPPONENT", Color.Black, font, 80, 300, 100);

                SplashKit.FillRectangle(Color.LightGray, depth_1);
                SplashKit.DrawBitmap(lv1, 50, 240);
                SplashKit.DrawText("Lv 1  crook", Color.Black, font, 30, 105, 450);

                SplashKit.FillRectangle(Color.LightGray, depth_2);
                SplashKit.DrawText("Lv 15  High AF wjbu", Color.Black, font, 30, 425, 450);
                SplashKit.DrawBitmap(lv15, 400, 240);

                SplashKit.FillRectangle(Color.LightGray, depth_3);
                SplashKit.DrawText("Lv 100  Gigachad", Color.Black, font, 30, 785, 450);
                SplashKit.DrawBitmap(lv100, 750, 240);

                SplashKit.RefreshScreen(60);

                if (ClickedInside(depth_1))
                {
                    window.Close();
                    return DepthLevel.Level1;
                }
                else if (ClickedInside(depth_2))
                {
                    window.Close();
                    return DepthLevel.Level2;
                }
                else if (ClickedInside(depth_3))
                {
                    window.Close();
                    return DepthLevel.Level3;
                }
            }

            return DepthLevel.Level1;
        }
    }



}

