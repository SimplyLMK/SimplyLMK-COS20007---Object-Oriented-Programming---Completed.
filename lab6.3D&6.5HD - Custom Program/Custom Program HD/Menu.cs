using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;



namespace custom_projD
{
    

    public class Menu
    {
        private Bitmap background;
        public enum GameMode
        {
            PlayerVsPlayer,
            PlayerVsAI
        }
              
        

        private bool ClickedInside(Rectangle rect)
        {
            return SplashKit.MouseClicked(MouseButton.LeftButton) && SplashKit.PointInRectangle(SplashKit.MousePosition(), rect);
        }

        public GameMode DisplayMenu(Window window)
        {
            Color textColor = Color.Black;
            Font font = SplashKit.LoadFont("AmaticSC-Regular", "Media\\AmaticSC-Regular.ttf");
            Rectangle playerVsPlayerRect = new Rectangle { X = 300, Y = 200, Width = 400, Height = 100 };
            Rectangle playerVsAIRect = new Rectangle { X = 300, Y = 400, Width = 400, Height = 100 };

            while (!window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.White);

                background = SplashKit.LoadBitmap("bg", "Media\\bg_mod.png");
                SplashKit.DrawBitmap(background, -300, 0);

                SplashKit.DrawText("Enter Epic C#hess, where legends are made!", Color.Black, font, 70, 120, 50);

                SplashKit.FillRectangle(Color.LightGray, playerVsPlayerRect);
                SplashKit.DrawText("Player vs Player", Color.Black, font, 70, 350, 210);

                SplashKit.FillRectangle(Color.LightGray, playerVsAIRect);
                SplashKit.DrawText("Player vs AI", Color.Black, font, 70, 380, 410);

                SplashKit.RefreshScreen(60);

                if (ClickedInside(playerVsPlayerRect))
                {
                    return GameMode.PlayerVsPlayer;
                }
                else if (ClickedInside(playerVsAIRect))
                {
                    return GameMode.PlayerVsAI;
                }
            }

            
            return GameMode.PlayerVsPlayer;
        }
    }


}
