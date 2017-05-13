using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BombCollideObserver : CollisionObserver
    {
        public override void notify()
        {
            Debug.WriteLine("Inside BombCollideObserver");
              int random = Utilty.getRandomNum(5,10);

            Bomb bomb = (Bomb)this.colSubject.gameObjA;

            // bomb.reset();
            // Debug.Assert(bomb != null);
     

            bomb.remove();
            ActivateBombSprite abs = new ActivateBombSprite();
            TimerManager.sortedAdd(TimerEvent.TimerEventName.ActivateGameEnd, abs, random);

        }
    }
}
