using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace custom_projD
{
    public class GUI_Board 
    {
        private const int Rows = 8;
        private const int Columns = 8;
        private int _squareSize;
        private Bitmap _icon;
        private Bitmap white_win;
        private Bitmap black_win;

        public int Square_Size
        {
            get { return _squareSize; }
            set { _squareSize = value; }
        }

        private Color Light_Square
        { 
            get; set; 
        }
        private Color Dark_Square
        {
            get; set;
        }
        

        public GUI_Board() 
        {
            
            Square_Size = Math.Min(800 / Columns, 800 / Rows);
            Light_Square = Color.LightGoldenrodYellow;
            Dark_Square = Color.SaddleBrown;
            white_win = SplashKit.LoadBitmap("white_win", "Media\\white_win.jpg");
            black_win = SplashKit.LoadBitmap("black_win", "Media\\black_win.jpg");
        }

        public void Draw(List<(int, int)> legalMoves)
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    bool isLightSquare = (row + col) % 2 == 0;
                    Color currentColor;

                    if (legalMoves.Contains((row, col)))
                    {
                        currentColor = Color.SwinburneRed;
                    }
                    else if (isLightSquare)
                    {
                        currentColor = Light_Square;
                    }
                    else
                    {
                        currentColor = Dark_Square;
                    }

                    SplashKit.FillRectangle(currentColor, (col * Square_Size), (row * Square_Size), Square_Size, Square_Size);
                }
            }

            _icon = SplashKit.LoadBitmap("chesscock", "Media\\chesscock.png");
            SplashKit.DrawBitmap(_icon, 840 , 350);
        }

        public void Announce_winner(Piece.Color winner)
        {
            Bitmap game_over;

            if (winner == Piece.Color.White)
            {
                game_over = white_win;
            }
            else
            {
                game_over = black_win;
            }
            int Width = 1000;
            int Height = 800;

            SplashKit.DrawBitmap(game_over, (Width - game_over.Width) / 2, (Height - game_over.Height) / 2);
        }



    }
}
