﻿using Clocks;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custom_projD
{
    public static class PvP
    {
        public static void PVP_MODE(int black_time, int white_time)
        {
            GameState gameState = GameManager.Instance.GameState;
            UserInputHandler userInputHandler = GameManager.Instance.UserInputHandler;

            Font font = SplashKit.LoadFont("AmaticSC-Regular", "Media\\AmaticSC-Regular.ttf");

            Window window = new Window("Chess", 1000, 800);
            GUI_Board guiBoard = new GUI_Board();
            Board board = new Board(guiBoard);

            Clock white_clock = new Clock(white_time);
            Clock black_clock = new Clock(black_time);

            DateTime lastTick = DateTime.Now;

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (!gameState.GameOver)
                {
                    if (board.CheckMate(Piece.Color.White))
                    {
                        gameState.SetGameOver(Piece.Color.Black);
                        white_clock.Pause();
                        black_clock.Pause();
                    }
                    else if (board.CheckMate(Piece.Color.Black))
                    {
                        gameState.SetGameOver(Piece.Color.White);
                        white_clock.Pause();
                        black_clock.Pause();
                    }
                    else if (white_clock.Flaged())
                    {
                        gameState.SetGameOver(Piece.Color.Black);
                    }
                    else if (black_clock.Flaged())
                    {
                        gameState.SetGameOver(Piece.Color.White);
                    }
                }

                guiBoard.Draw(board.LegalMoves);
                board.Draw();

                if (gameState.GameOver)
                {
                    guiBoard.Announce_winner(gameState.Winner);
                }

                if (userInputHandler.IsMouseClicked(MouseButton.LeftButton))
                {
                    int mouseX = userInputHandler.GetMouseX();
                    int mouseY = userInputHandler.GetMouseY();

                    bool turnSwitched = board.Select_Piece(mouseX, mouseY, guiBoard.Square_Size);

                    if (turnSwitched)
                    {
                        if (board.Current_Turn == Piece.Color.White)
                        {
                            black_clock.Pause();
                            white_clock.Resume();
                        }
                        else
                        {
                            white_clock.Pause();
                            black_clock.Resume();
                        }
                    }
                }

                if ((DateTime.Now - lastTick).TotalMilliseconds >= 1000)
                {
                    if (board.Current_Turn == Piece.Color.White)
                    {
                        white_clock.Tick();
                    }
                    else
                    {
                        black_clock.Tick();
                    }

                    lastTick = DateTime.Now;
                }

                SplashKit.DrawText($"Time: {white_clock.Show()} ", Color.Black, font, 40, 830, 700);
                SplashKit.DrawText($"Time: {black_clock.Show()} ", Color.Black, font, 40, 830, 50);

                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}


