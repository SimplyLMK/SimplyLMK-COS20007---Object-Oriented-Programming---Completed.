using System;
using System.Collections.Generic;
using Clocks;
using SplashKitSDK;

namespace custom_projD
{
    public class Program
    {
        public static void Activate_Epic_Chess()
        {
            GameManager gameManager = GameManager.Instance;

            Window window = new Window("Chess Menu", 1000, 800);

            Menu.GameMode chosen_Mode = gameManager.Menu.DisplayMenu(window);

            window.Close();

            switch (chosen_Mode)
            {
                case Menu.GameMode.PlayerVsPlayer:
                    Choose_Format.TimeFormat chosen_time_PVP = gameManager.timeFormat.Choose_Time();
                    int white_time_PVP;
                    int black_time_PVP;
                    switch (chosen_time_PVP)
                    {
                        case Choose_Format.TimeFormat.Bullet:
                            white_time_PVP = black_time_PVP = 60;
                            break;
                        case Choose_Format.TimeFormat.Blitz:
                            white_time_PVP = black_time_PVP = 300;
                            break;
                        case Choose_Format.TimeFormat.Rapid:
                            white_time_PVP = black_time_PVP = 600;
                            break;
                        default:
                            white_time_PVP = black_time_PVP = 60;
                            break;
                    }
                    PvP.PVP_MODE(white_time_PVP, black_time_PVP);

                    break;
                case Menu.GameMode.PlayerVsAI:
                    Choose_Format.TimeFormat chosen_time_PVA = gameManager.timeFormat.Choose_Time();
                    int white_time_PVA;
                    int black_time_PVA;

                    Choose_AI_Opponent.DepthLevel chosen_depth_PVA = gameManager.ChooseAI.Choose_Depth();
                    int depth;

                    switch (chosen_time_PVA)
                    {
                        case Choose_Format.TimeFormat.Bullet:
                            white_time_PVA = black_time_PVA = 60;
                            break;
                        case Choose_Format.TimeFormat.Blitz:
                            white_time_PVA = black_time_PVA = 300;
                            break;
                        case Choose_Format.TimeFormat.Rapid:
                            white_time_PVA = black_time_PVA = 600;
                            break;
                        default:
                            white_time_PVA = black_time_PVA = 60;
                            break;
                    }

                    switch (chosen_depth_PVA)
                    {
                        case Choose_AI_Opponent.DepthLevel.Level1:
                            depth = 1;
                            break;
                        case Choose_AI_Opponent.DepthLevel.Level2:
                            depth = 2;
                            break;
                        case Choose_AI_Opponent.DepthLevel.Level3:
                            depth = 3;
                            break;
                        default:
                            depth = 1;
                            break;
                    }

                    PvA.PvA_MODE(white_time_PVA, black_time_PVA, depth);
                    break;
            }
        }


        static void Main(string[] args)
        {
            Activate_Epic_Chess();
        }
    }
}
