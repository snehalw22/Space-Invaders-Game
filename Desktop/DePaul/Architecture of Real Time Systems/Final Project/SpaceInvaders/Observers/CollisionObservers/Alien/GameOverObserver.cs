using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameOverObserver : CollisionObserver
    {
        public override void notify()
        {
            ////restart timer
            GameManager.setGameState(new GameEndState());
            GameManager.load();
        }
    }
}
