using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_Week3_05_GameStateManager
{
    class SplashScreen : GameState
    {
        float cooldownTimer = 1.0f;

        public SplashScreen(Program program) : base(program)
        {

        }

        public override void Update()
        {
            cooldownTimer -= Raylib.GetFrameTime();
            if(cooldownTimer < 0)
            {
                program.ChangeGameState(new MenuScreen(program));
            }
        }

        public override void Draw()
        {
            Raylib.DrawText("Splash Screen", 10, 10, 20, Color.GRAY);
        }
    }
}
