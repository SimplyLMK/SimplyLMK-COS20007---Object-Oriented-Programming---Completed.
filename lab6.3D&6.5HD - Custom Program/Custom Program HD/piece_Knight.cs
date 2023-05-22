using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace custom_projD
{
    public class Knight : Piece
    {
        private Bitmap _image;

        public Knight(Color color ) : base( color ) 
        {
            if(color == Color.White)
            {
                _image = SplashKit.LoadBitmap("knight_white", "Media\\knight_white.png");
            }
            else
            {
                _image = SplashKit.LoadBitmap("knight_black", "Media\\knight_black.png");
            }
        }

        public override bool Is_Valid_Move(int Rowed, int Columned, Board board)
        {
            int row_offset = Math.Abs(Rowed - Row);
            int col_offset = Math.Abs(Columned - Col);

            bool isValid = (row_offset == 2 && col_offset == 1) || (row_offset == 1 && col_offset == 2);

            if (!isValid)
            {
                return false;
            }

            Piece targetPiece = board.Coordinate(Rowed, Columned);
            if (targetPiece != null && targetPiece.PieceColor == this.PieceColor)
            {
                return false;
            }

            return true;
        }


        public override void Draw(int x, int y)
        {
            SplashKit.DrawBitmap( _image, x, y );
        }

    }
}
