using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace custom_projD
{
    public class Queen : Piece
    {
        private Bitmap _image;
        
        public Queen(Color color) : base (color)
        {
            if(color == Color.White)
            {
                _image = SplashKit.LoadBitmap("queen_white", "Media\\wjbu\\white_queen.png");
            }
            else
            {
                _image = SplashKit.LoadBitmap("queen_black", "Media\\queen_black.png");
            }       
        }

        public override bool Is_Valid_Move(int Rowed, int Columned, Board board)
        {
            int row_offset = Rowed - Row;
            int col_offset = Columned - Col;

            bool Mov_Horiz = row_offset == 0;
            bool Mov_Vert = col_offset == 0;
            bool Move_Diag = Math.Abs(row_offset) == Math.Abs(col_offset);

            if (!(Mov_Horiz || Mov_Vert || Move_Diag))
            {
                return false;
            }

            int rowDir = row_offset != 0 ? Math.Sign(row_offset) : 0;
            int colDir = col_offset != 0 ? Math.Sign(col_offset) : 0;

            int rowDiff = Math.Abs(row_offset);
            int colDiff = Math.Abs(col_offset);

            int maxDiff = Math.Max(rowDiff, colDiff);

            for (int i = 1; i < maxDiff; i++)
            {
                if (board.Coordinate(Row + i * rowDir, Col + i * colDir) != null)
                {
                    return false;
                }
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
            SplashKit.DrawBitmap(_image, x, y);
        }
    }
}
