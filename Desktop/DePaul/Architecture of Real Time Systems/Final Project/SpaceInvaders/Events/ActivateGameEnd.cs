using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ActivateGameEnd : Command
    {

        public override void execute(float deltaTime)
        {
            GameManager.setGameState(new GameEndState());
            GameManager.load();
        }

    }
}
