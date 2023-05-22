using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custom_projD
{
    public class GameState
    {
        public bool GameOver { get; private set; }
        public Piece.Color Winner { get; private set; }

        public GameState()
        {
            GameOver = false;
            Winner = Piece.Color.White;
        }

        public void SetGameOver(Piece.Color winner)
        {
            GameOver = true;
            Winner = winner;
        }
    }

}
