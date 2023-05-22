using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace custom_projD
{
    public class Board
    {
        public Piece[,] pos;
        private GUI_Board _guiBoard;
        private Piece _selected;
        private List<(int, int)> legalMoves = new List<(int, int)>();

        public Piece.Color Current_Turn
        {
            get;
            private set;
        }

        public List<(int, int)> LegalMoves
        {
            get { return legalMoves; }
        }

        public Board(GUI_Board guiBoard)
        {
            _guiBoard = guiBoard;
            pos = new Piece[8, 8];

            // Initialize empty board
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    pos[row, col] = null;
                }
            }
            // ROOK
            pos[0, 0] = new Rook(Piece.Color.Black) { Row = 0, Col = 0 };
            pos[0, 7] = new Rook(Piece.Color.Black) { Row = 0, Col = 7 };
            pos[7, 0] = new Rook(Piece.Color.White) { Row = 7, Col = 0 };
            pos[7, 7] = new Rook(Piece.Color.White) { Row = 7, Col = 7 };
            // BISHOP
            pos[0, 2] = new Bishop(Piece.Color.Black) { Row = 0, Col = 2 };
            pos[0, 5] = new Bishop(Piece.Color.Black) { Row = 0, Col = 5 };
            pos[7, 2] = new Bishop(Piece.Color.White) { Row = 7, Col = 2 };
            pos[7, 5] = new Bishop(Piece.Color.White) { Row = 7, Col = 5 };
            // KNIGHT
            pos[0, 1] = new Knight(Piece.Color.Black) { Row = 0, Col = 1 };
            pos[0, 6] = new Knight(Piece.Color.Black) { Row = 0, Col = 6 };
            pos[7, 1] = new Knight(Piece.Color.White) { Row = 7, Col = 1 };
            pos[7, 6] = new Knight(Piece.Color.White) { Row = 7, Col = 6 };
            // QUEEN
            pos[0, 3] = new Queen(Piece.Color.Black) { Row = 0, Col = 3 };
            pos[7, 3] = new Queen(Piece.Color.White) { Row = 7, Col = 3 };
            // KING
            pos[0, 4] = new King(Piece.Color.Black) { Row = 0, Col = 4 };
            pos[7, 4] = new King(Piece.Color.White) { Row = 7, Col = 4 };
            // PAWN        
            for (int col = 0; col < 8; col++)
            {
                pos[1, col] = new Pawn(Piece.Color.Black) { Row = 1, Col = col };
                pos[6, col] = new Pawn(Piece.Color.White) { Row = 6, Col = col };
            }
            //

            Current_Turn = Piece.Color.White;
        }


       
        public Piece Coordinate(int row, int col)   
        {
            if (row >= 0 && row < 8 && col >= 0 && col < 8)
            {
                return pos[row, col];
            }
            return null;
        }

        
        public void Draw() 
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Piece piece = pos[row, col];
                    if (piece != null)
                    {
                        int x = col * _guiBoard.Square_Size;
                        int y = row * _guiBoard.Square_Size;
                        piece.Draw(x, y);
                    }
                }
            }
        }

        
        public bool Select_Piece(int mouseX, int mouseY, int squareSize) 
        {
            bool turnSwitched = false;
            int Rowed = mouseY / squareSize;
            int Columned = mouseX / squareSize;

            if (Rowed < 0 || Rowed >= 8 || Columned < 0 || Columned >= 8)
            {
                return turnSwitched;
            }

            Piece clicked_Piece = Coordinate(Rowed, Columned); 

            if (_selected != null)
            {
                if (_selected == clicked_Piece && clicked_Piece.Is_Selected(mouseX, mouseY, squareSize))
                {
                    Deselect_Piece(); 
                }
                else
                {
                    
                    if (legalMoves.Contains((Rowed, Columned)) || (_selected is King)) 
                    {
                        _selected.Move(Rowed, Columned, this);
                        Switch_Turn();
                        turnSwitched = true;
                        Deselect_Piece();
                    }
                    else if (clicked_Piece != null && clicked_Piece.Is_Selected(mouseX, mouseY, squareSize))
                    {
                        Deselect_Piece();
                        _selected = clicked_Piece;
                        Piece_Chosen();
                    }
                }
            }
            else
            {
                if (clicked_Piece != null && clicked_Piece.Is_Selected(mouseX, mouseY, squareSize) && clicked_Piece.PieceColor == Current_Turn)
                {
                    _selected = clicked_Piece;
                    Piece_Chosen();
                }
            }

            return turnSwitched;
        }





        public void Piece_Chosen() 
        {

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (_selected.Is_Valid_Move(r, c, this))
                    {
                        legalMoves.Add((r, c));
                    }
                }
            }
        }

        public void Deselect_Piece()
        {
            _selected = null;
            legalMoves.Clear();
        }


        public void Switch_Turn()
        {
            if (Current_Turn == Piece.Color.White)
            {
                Current_Turn = Piece.Color.Black;
            }
            else
            {
                Current_Turn = Piece.Color.White;
            }
            TurnNumber++;
        }


        public Piece Find_King(Piece.Color color)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Piece piece_is_king = Coordinate(row, col);
                    if (piece_is_king != null && piece_is_king.PieceColor == color && piece_is_king is King)
                    {
                        return piece_is_king;
                    }
                }
            }
            return null;
        }

        public bool King_Checked(Piece.Color color)
        {
            Piece king = null;
            List<Piece> enemyPieces = new List<Piece>();


            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Piece piece = Coordinate(row, col);
                    if (piece != null)
                    {
                        if (piece.PieceColor == color && piece is King)
                        {
                            king = piece;
                        }
                        else if (piece.PieceColor != color)
                        {
                            enemyPieces.Add(piece);
                        }
                    }
                }
            }

            if (king == null) return false;

            foreach (Piece enemyPiece in enemyPieces)
            {
                if (enemyPiece.Is_Valid_Move(king.Row, king.Col, this))
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckMate (Piece.Color color)
        {
            if (!King_Checked(color))
            {
                return false;
            }

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Piece piece = Coordinate(row, col);

                    if (piece != null && piece.PieceColor == color)
                    {
                        for (int Rowed = 0; Rowed < 8; Rowed++)
                        {
                            for (int Columned = 0; Columned < 8; Columned++)
                            {
                                if (piece.Is_Valid_Move(Rowed, Columned, this))
                                {

                                    Piece OG_Piece = Coordinate(Rowed, Columned);
                                    int OG_Row = piece.Row;
                                    int OG_Col = piece.Col;
                                    pos[Rowed, Columned] = piece;
                                    pos[OG_Row, OG_Col] = null;
                                    piece.Row = Rowed;
                                    piece.Col = Columned;

                                    bool after_mov = King_Checked(color);

                                    pos[OG_Row, OG_Col] = piece;
                                    pos[Rowed, Columned] = OG_Piece;
                                    piece.Row = OG_Row;
                                    piece.Col = OG_Col;

                                    if (!after_mov)
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //Console.WriteLine($"Checkmate detected for {color}");
            return true;
        }



        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////// For AI algorithm//////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        public int TurnNumber { get; private set; } = 0;

        public bool GameOver()
        {
            return CheckMate(Piece.Color.White) || CheckMate(Piece.Color.Black);
        }


        public void AI_Mov(int startRow, int startCol, int endRow, int endCol)
        {
            Piece movedPiece = pos[startRow, startCol];
            pos[startRow, startCol] = null;
            pos[endRow, endCol] = movedPiece;

            movedPiece.Row = endRow;
            movedPiece.Col = endCol;
        }


        public void AI_Undo((int, int) start, (int, int) end, Piece capturedPiece)
        {
            Piece movedPiece = pos[end.Item1, end.Item2];
            pos[start.Item1, start.Item2] = movedPiece;
            pos[end.Item1, end.Item2] = capturedPiece;

            movedPiece.Row = start.Item1;
            movedPiece.Col = start.Item2;
        }



        public List<((int, int), (int, int))> GetMoves()
        {
            List<((int, int), (int, int))> moves = new List<((int, int), (int, int))>();

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Piece piece = Coordinate(row, col);
                    if (piece != null && piece.PieceColor == Current_Turn)
                    {
                        for (int newRow = 0; newRow < 8; newRow++)
                        {
                            for (int newCol = 0; newCol < 8; newCol++)
                            {
                                if (piece.Is_Valid_Move(newRow, newCol, this))
                                {
                                    (int, int) start = (row, col);
                                    (int, int) end = (newRow, newCol);
                                    Piece capturedPiece = Coordinate(newRow, newCol);

                                    Piece OG_Piece = Coordinate(newRow, newCol);
                                    int OG_Row = piece.Row;
                                    int OG_Col = piece.Col;
                                    pos[newRow, newCol] = piece;
                                    pos[OG_Row, OG_Col] = null;
                                    piece.Row = newRow;
                                    piece.Col = newCol;

                                    bool inCheck = King_Checked(Current_Turn);

                                    pos[OG_Row, OG_Col] = piece;
                                    pos[newRow, newCol] = OG_Piece;
                                    piece.Row = OG_Row;
                                    piece.Col = OG_Col;

                                    if (!inCheck)
                                    {
                                        moves.Add((start, end));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return moves;
        }

        public int Def_Score_Initial_Value (Piece.Color color)
        {
           int score = 0;

           for (int row = 0; row < 8; row++)
           {
                for (int col = 0; col < 8; col++)
                {
                    Piece piece = pos[row, col];
                    if (piece != null && piece.PieceColor == color)
                    {
                        int pieceValue = Def_Value(piece);
                        score += pieceValue;
                    }
                }
           }

            return score;
        }

        private int Def_Value (Piece piece)
        {

            if (piece is Pawn) return 1;
            if (piece is Knight) return 3;
           if (piece is Bishop) return 3;
            if (piece is Rook) return 5;
            if (piece is Queen) return 9;
            if (piece is King) return 0; 

            return 0;
        }

        

    }
}