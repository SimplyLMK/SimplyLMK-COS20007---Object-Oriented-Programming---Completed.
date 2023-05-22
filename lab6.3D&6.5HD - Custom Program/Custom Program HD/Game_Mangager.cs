using System;

namespace custom_projD
{
    public class GameManager
    {
        private static GameManager _instance;

        public Menu Menu { get; private set; }
        public Choose_Format timeFormat { get; private set; }
        public Choose_AI_Opponent ChooseAI { get; private set; }
        public GameState GameState { get; private set; }
        public UserInputHandler UserInputHandler { get; private set; }

        private GameManager()
        {
            Menu = new Menu();
            timeFormat = new Choose_Format();
            ChooseAI = new Choose_AI_Opponent();
            GameState = new GameState();
            UserInputHandler = new UserInputHandler();
        }

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }
        }

    }
}
