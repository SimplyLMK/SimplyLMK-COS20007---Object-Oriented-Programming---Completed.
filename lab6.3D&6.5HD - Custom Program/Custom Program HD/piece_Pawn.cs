using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace custom_projD
{
    public class Pawn : Piece
    {
        private Bitmap _image;
        public Pawn(Color color) : base(color)
        {
            if (color == Color.White) 
            {
                _image = SplashKit.LoadBitmap("pawn_white", "Media\\pawn_white.png");
            }
            else 
            {
                _image = SplashKit.LoadBitmap("pawn_black", "Media\\pawn_black.png");
            }
        }
       
        public override bool Is_Valid_Move(int Rowed, int Columned, Board board)
        {
            int row_offset = Rowed - Row;
            int col_offset = Columned - Col;

            bool Move_1Sq = (PieceColor == Color.White && row_offset == -1) || (PieceColor == Color.Black && row_offset == 1);
            bool Move_2Sq = (PieceColor == Color.White && Row == 6 && row_offset == -2) || (PieceColor == Color.Black && Row == 1 && row_offset == 2);

            Piece targetPiece = board.Coordinate(Rowed, Columned);
            bool Is_Foe = (targetPiece != null) && (targetPiece.PieceColor != this.PieceColor);

            bool Move_Diag = (Math.Abs(col_offset) == 1 && ((PieceColor == Color.White && row_offset == -1) || PieceColor == Color.Black && row_offset == 1));
            bool Capture = Move_Diag && Is_Foe;
            bool Move_normal = (Move_1Sq && col_offset == 0 && targetPiece == null) || (Move_2Sq && col_offset == 0 && targetPiece == null);

            return Move_normal || Capture;
        }

        public override void Draw(int x, int y)
        {
            SplashKit.DrawBitmap(_image, x, y);
        }

        


    }
}
