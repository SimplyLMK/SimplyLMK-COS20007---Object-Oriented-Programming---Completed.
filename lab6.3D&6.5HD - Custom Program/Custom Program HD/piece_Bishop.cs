using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custom_projD
{
    public class Bishop : Piece
    {
        private Bitmap _image;

        public Bishop(Color color) : base(color)
        {
            if(color == Color.White)
            {
                _image = SplashKit.LoadBitmap("bishop_white", "Media\\bishop_white.png");
            }
            else 
            {
                _image = SplashKit.LoadBitmap("bishop_black", "Media\\bishop_black.png");
            }
           
        }

        public override bool Is_Valid_Move(int Rowed, int Columned, Board board)
        {
            int row_offset = Math.Abs(Rowed - Row);
            int col_offset = Math.Abs(Columned - Col);

            bool Move_Diag = row_offset == col_offset;

            if (!Move_Diag)
            {
                return false;
            }

         
            int rowDir = Rowed > Row ? 1 : -1;
            int colDir = Columned > Col ? 1 : -1;

            for (int i = 1; i < row_offset; i++)
            {
                if (board.Coordinate(Row + i * rowDir, Col + i * colDir) != null)
                {
                    return false;
                }
            }


            Piece Target_Piece = board.Coordinate(Rowed, Columned);
            if (Target_Piece != null && Target_Piece.PieceColor == this.PieceColor)
            {
                return false;
            }

            return true;
        }


        public override void Draw(int x, int y)
        {
            SplashKit.DrawBitmap(_image, x, y);
        }

    }
}
