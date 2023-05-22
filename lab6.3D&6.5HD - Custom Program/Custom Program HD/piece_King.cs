using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custom_projD
{
    public class King : Piece
    {
        private Bitmap _image;
        

        public King(Color color) : base(color)
        {
            if (color == Color.White)
            {
                _image = SplashKit.LoadBitmap("king_white", "Media\\king_white.png");
            }
            else
            {
                _image = SplashKit.LoadBitmap("king_black", "Media\\king_black.png");
            }
        }

        public override bool Is_Valid_Move(int Rowed, int Columned, Board board)
        {
            int row_offset = Math.Abs(Rowed - Row);
            int col_offset = Math.Abs(Columned - Col);

            bool isValid = (row_offset <= 1) && (col_offset <= 1);

            if (!isValid)
            {
                if ((Columned == 2 || Columned == 6)) 
                {
                    return true;
                }

                return false;
            }

            Piece targetPiece = board.Coordinate(Rowed, Columned);
            if (targetPiece != null && targetPiece.PieceColor == this.PieceColor)
            {
                return false;
            }

            return true;
        }





        public override void Move(int newRow, int newCol, Board board)
        {
            if (Math.Abs(newCol - Col) > 1)
            {
 
                if (newCol < Col)
                {
                    Piece rook = board.Coordinate(Row, 0);
                    if (rook != null && rook is Rook)
                    {
                        board.pos[Row, 0] = null;
                        board.pos[Row, 3] = rook;
                        rook.Row = Row;
                        rook.Col = 3;
                    }
                }
                else
                {
                    Piece rook = board.Coordinate(Row, 7);
                    if (rook != null && rook is Rook)
                    {
                        board.pos[Row, 7] = null;
                        board.pos[Row, 5] = rook;
                        rook.Row = Row;
                        rook.Col = 5;
                    }
                }
            }

            base.Move(newRow, newCol, board);
        }

        public bool HasMoved { get; set; }


        public override void Draw(int x, int y)
        {
            SplashKit.DrawBitmap(_image, x, y);
        }

    }


}
