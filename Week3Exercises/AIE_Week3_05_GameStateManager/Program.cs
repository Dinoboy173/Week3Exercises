using System;
using System.Collections.Generic;
using System.IO;
using Raylib_cs;

namespace AIE_Week3_05_GameStateManager
{
    class Program
    {
        int windowWidth = 800;
        int windowHeight = 450;
        string windowTitle = "GameStateMangement";

        GameState currentGameState;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.RunGame();

            PlayGameScreen playGameScreen;
            int bpc = playGameScreen.buttonPressCount;

            List<ScoreEntry> scores = new List<ScoreEntry>()
            {
                new ScoreEntry(bpc)
            };

            //save the scores
            SerialiseScores("highscores.txt", scores);

            //clear the scores
            scores = new List<ScoreEntry>();

            //read scores
            DeSerialiseScores("highscores.txt", scores);
        }

        static void SerialiseScores(string filename, List<ScoreEntry> scores)
        {
            FileInfo fileInfo = new FileInfo(filename);
            Directory.CreateDirectory(fileInfo.Directory.FullName);

            using (StreamWriter sw = File.CreateText(filename))
            {
                foreach (var entry in scores)
                {
                    sw.WriteLine($"{entry.score}");
                }
            }
        }

        static void DeSerialiseScores(string filename, List<ScoreEntry> scores)
        {
            using (StreamReader sr = File.OpenText(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var lineItems = line.Split(" ");
                    int.TryParse(lineItems[1], out int score);

                    var entry = new ScoreEntry(score);
                    scores.Add(entry);
                }
            }
        }

        void RunGame()
        {
            Raylib.InitWindow(windowWidth, windowHeight, windowTitle);
            Raylib.SetTargetFPS(60);

            LoadGame();

            while(!Raylib.WindowShouldClose())
            {
                Update();
                Draw();
            }

            Raylib.CloseWindow();
        }

        void LoadGame()
        {
            currentGameState = new SplashScreen(this);
        }

        void Update()
        {
            if (currentGameState != null)
                currentGameState.Update();
        }

        void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            if (currentGameState != null)
                currentGameState.Draw();

            Raylib.DrawFPS(10, windowHeight - 20);

            Raylib.EndDrawing();
        }

        public void ChangeGameState(GameState newGameState)
        {
            currentGameState = newGameState;
        }
    }
}
