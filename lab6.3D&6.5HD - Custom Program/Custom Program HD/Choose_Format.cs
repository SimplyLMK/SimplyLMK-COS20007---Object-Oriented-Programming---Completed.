using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custom_projD
{
    public class Choose_Format
    {

        private Bitmap background;
        private Bitmap icon;
        public enum TimeFormat
        {
            Bullet,
            Blitz,
            Rapid,
        }

        private bool ClickedInside(Rectangle rect)
        {
            return SplashKit.MouseClicked(MouseButton.LeftButton) && SplashKit.PointInRectangle(SplashKit.MousePosition(), rect);
        }

        public TimeFormat Choose_Time()
        {
            Window window = new Window("Choose time format", 1000, 800);   
            Color textColor = Color.Black;
            Font font = SplashKit.LoadFont("AmaticSC-Regular", "Media\\AmaticSC-Regular.ttf");
            Rectangle bullet = new Rectangle { X = 250, Y = 300, Width = 120, Height = 50 };
            Rectangle Blitz = new Rectangle { X = 450, Y = 300, Width = 120, Height = 50 };
            Rectangle Rapid = new Rectangle { X = 650, Y = 300, Width = 120, Height = 50 };

            while (!window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.White);

                background = SplashKit.LoadBitmap("bg", "Media\\bg_mod.png");
                icon = SplashKit.LoadBitmap("time_formated", "Media\\time_formated.png");
                
                SplashKit.DrawBitmap(background, -300, 0);
                SplashKit.DrawBitmap(icon, 250, 380);


                SplashKit.FillRectangle(Color.LightGray, bullet);
                SplashKit.DrawText("Bullet format", Color.Black, font, 30, 255, 300);

                SplashKit.FillRectangle(Color.LightGray, Blitz);
                SplashKit.DrawText("Blitz format", Color.Black, font, 30, 458, 300);

                SplashKit.FillRectangle(Color.LightGray, Rapid);
                SplashKit.DrawText("Rapid format", Color.Black, font, 30, 658, 300);


                SplashKit.RefreshScreen(60);

                if (ClickedInside(bullet))
                {
                    window.Close();
                    return TimeFormat.Bullet;
                }
                else if (ClickedInside(Blitz))
                {
                    window.Close();
                    return TimeFormat.Blitz;
                }
                else if (ClickedInside(Rapid))
                {
                    window.Close();
                    return TimeFormat.Rapid;
                }

            }


            return TimeFormat.Bullet;
        }
    }
}

