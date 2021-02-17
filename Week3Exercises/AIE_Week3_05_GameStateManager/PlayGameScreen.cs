using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace AIE_Week3_05_GameStateManager
{
    class PlayGameScreen : GameState
    {
        public int buttonPressCount = 0;

        public PlayGameScreen(Program program) : base(program)
        {
            
        }

        public override void Update()
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                buttonPressCount += 1;
        }

        public override void Draw()
        {
            Raylib.DrawText("Play Game Screen", 10, 10, 20, Color.GRAY);
            Raylib.DrawText($"Press Count: {buttonPressCount}", 10, 30, 20, Color.GRAY);
        }
    }
}
