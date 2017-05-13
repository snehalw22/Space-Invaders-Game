using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameEndObserver : CollisionObserver
    {
        public override void notify()
        {
            if (PlayerManager.getCurrentPlayer().ships == 0)
            {
                // GameManager.setGameState(new GameEndState());
                // GameManager.load();
                ActivateGameEnd abs6 = new ActivateGameEnd();
                TimerManager.sortedAdd(TimerEvent.TimerEventName.ActivateGameEnd, abs6, Unit.gameFreezeTime);

            }
        }
    }
}
