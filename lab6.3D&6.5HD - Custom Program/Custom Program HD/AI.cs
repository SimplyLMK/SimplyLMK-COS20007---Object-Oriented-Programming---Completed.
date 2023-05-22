using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace custom_projD
{

    public static class AI
    {

        public static int PositionsEvaluated = 0;

        public static DateTime DecisionStartTime { get; private set; }
        public static DateTime DecisionEndTime { get; private set; }


        private static List<((int, int), (int, int))> open_mov = new List<((int, int), (int, int))>
        {
            ((1, 6), (2, 6)),
            ((0, 6), (2, 5)),
            ((0, 5), (1, 6)),          
            ((0, 4), (0, 6)),
        };

        private static int cur_open_Movs = 0;

        public static ((int, int), (int, int)) GetOpeningMove()
        {
            if (cur_open_Movs < open_mov.Count)
            {
                ((int, int), (int, int)) move = open_mov[cur_open_Movs];
                cur_open_Movs++;
                return move;
            }
            else
            {
                return ((-1, -1), (-1, -1));
            }
        }


        public static void ExportDataToCSV(int gameNumber, int depth, int positionsEvaluated, long decisionTime, string outcome)
        {
            string filePath = "C:\\C#\\chess.csv";

            // Check if the file exists, and if not, create the file and write the header row
            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("GameNumber,Depth,PositionsEvaluated,DecisionTime,Outcome");
                }
            }

            // Append the data for the current game to the CSV file
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{gameNumber},{depth},{positionsEvaluated},{decisionTime},{outcome}");
            }
        }


        public static int Evaluate(Board board, Piece.Color maximizingColor)
        {
            PositionsEvaluated++;
            int whiteScore = board.Def_Score_Initial_Value(Piece.Color.White);
            int blackScore = board.Def_Score_Initial_Value(Piece.Color.Black);


            if (maximizingColor == Piece.Color.White)
            {
                return whiteScore - blackScore;
            }
            else
            {
                return blackScore - whiteScore;
            }
            
        }

        public static (int, ((int, int), (int, int))) Minimax(Board board, int depth, bool maximizingPlayer, Piece.Color maximizingColor)
        {
            DecisionStartTime = DateTime.Now;
            if (depth == 0 || board.GameOver())
            {
                int score = Evaluate(board, maximizingColor);
                return (score, ((-1, -1), (-1, -1)));
            }

            List<((int, int), (int, int))> moves = board.GetMoves();
            ((int, int), (int, int)) bestMove = moves[new Random().Next(moves.Count)];
            int bestScore = maximizingPlayer ? int.MinValue : int.MaxValue;

            foreach (((int, int) start, (int, int) end) move in moves)
            {
                Piece capturedPiece = board.pos[move.end.Item1, move.end.Item2];
                board.AI_Mov(move.start.Item1, move.start.Item2, move.end.Item1, move.end.Item2);
                (int score, ((int, int), (int, int))) currentMove = Minimax(board, depth - 1, !maximizingPlayer, maximizingColor);
                board.AI_Undo(move.start, move.end, capturedPiece);

                if (maximizingPlayer)
                {
                    if (currentMove.score > bestScore)
                    {
                        bestScore = currentMove.score;
                        bestMove = move;
                    }
                }
                else
                {
                    if (currentMove.score < bestScore)
                    {
                        bestScore = currentMove.score;
                        bestMove = move;
                    }
                }
            }

            DecisionEndTime = DateTime.Now;
            return (bestScore, bestMove);
        }

        public static long DecisionTime
        {
            get
            {
                return (long)(DecisionEndTime - DecisionStartTime).TotalMilliseconds;
            }
        }



    }





}

