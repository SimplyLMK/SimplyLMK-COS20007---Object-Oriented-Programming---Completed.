using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace custom_projD
{
    public abstract class Piece
    {
      
        public enum Color
        {
            White,
            Black
        }
        public Color PieceColor
        {
            get;
            set;
        }
        public int Row
        {
            get;
            set;
        }
        public int Col
        {
            get;
            set;
        }

        public Piece(Color pieceColor)
        {
            PieceColor = pieceColor;
        }

        public abstract void Draw(int x, int y);
        public virtual void Move(int Rowed, int Columned, Board board)
        {
            board.pos[Row, Col] = null;
            Row = Rowed;
            Col = Columned;
            board.pos[Rowed, Columned] = this;
        }

        public abstract bool Is_Valid_Move(int Rowed, int Columned, Board board);

        public bool Is_Selected(int mouseX, int mouseY, int square_Size)
        {
            int x = Col * square_Size;
            int y = Row * square_Size;
            return mouseX >= x && mouseX <= x + square_Size && mouseY >= y && mouseY <= y + square_Size;
        }

        public bool Has_Moved { get; set; }

       
    }
}
