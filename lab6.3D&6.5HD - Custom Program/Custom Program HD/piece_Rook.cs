using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace custom_projD
{
    
    public class Rook : Piece
    {
        private Bitmap _image;

        
        public Rook(Color color ) : base( color )
        {
        if(color == Color.White)
            {
                _image = SplashKit.LoadBitmap("rook_white", "Media\\rook_white.png");
            }
        else
            {
                _image = SplashKit.LoadBitmap("rook_black", "Media\\rook_black.png");
            }

        }

        public override bool Is_Valid_Move(int Rowed, int Columned, Board board)
        {
            int row_offset = Math.Abs(Rowed - Row);
            int col_offset = Math.Abs(Columned - Col);

            if (row_offset == 0 && col_offset == 0)
            {
                return false;
            }

            bool Mov_Horiz = row_offset == 0;
            bool Mov_Vert = col_offset == 0;

            if (!Mov_Horiz && !Mov_Vert)
            {
                return false;
            }

            int rowDir = Rowed > Row ? 1 : -1;
            int colDir = Columned > Col ? 1 : -1;

            if (Mov_Horiz)
            {
                for (int c = Col + colDir; c != Columned; c += colDir)
                {
                    if (board.Coordinate(Row, c) != null)
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int r = Row + rowDir; r != Rowed; r += rowDir)
                {
                    if (board.Coordinate(r, Col) != null)
                    {
                        return false;
                    }
                }
            }

           
            Piece Target_Piece = board.Coordinate(Rowed, Columned);
            if (Target_Piece != null && Target_Piece.PieceColor == this.PieceColor)
            {
                return false;
            }

            return true;
        }

        public override void Move(int Rowed, int Columned, Board board)
        {
            base.Move(Rowed, Columned, board);
            Has_Moved = true;
        }


        public bool HasMoved { get; private set; }


        public override void Draw(int x, int y)
        {
            SplashKit.DrawBitmap(_image, x, y);
        }
      

    }
    
}

    