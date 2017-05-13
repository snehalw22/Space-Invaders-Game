using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienMissileObserver : CollisionObserver
    {
        public override void notify()
        {
            Debug.WriteLine("Action after the Alien and Missile hits goes here");
            Debug.WriteLine("AlienMissile Observer: {0} {1}", this.colSubject.gameObjA.cGameObjectName, this.colSubject.gameObjB.cGameObjectName);

            Alien a = (Alien)this.colSubject.gameObjA;
            Missile missile = (Missile)this.colSubject.gameObjB;

            missile.remove();
            a.explode(Sprite.SpriteName.AlienExplosion);
            a.markForDeath();

            //Update Score

            if (a.cGameObjectName == GameObject.GameObjectName.Crab)
            {
                PlayerManager.getCurrentPlayer().addScore(Unit.crabPoints);
            }else if (a.cGameObjectName == GameObject.GameObjectName.Squid)
            {
                PlayerManager.getCurrentPlayer().addScore(Unit.squidPoints);
            }
            else if(a.cGameObjectName == GameObject.GameObjectName.Octopus)
            {
                PlayerManager.getCurrentPlayer().addScore(Unit.octopusPoints);
            }

            AlienDeathAnimation deathAni = new AlienDeathAnimation(a);
            TimerManager.sortedAdd(TimerEvent.TimerEventName.DeathAnimation, deathAni, Unit.alienDeathAnimationTime);

            //Check Columns for death
            Column column = (Column)a.pParent;
            column.markForDeathCheck();
          
            //Check Grids for death
            AlienGrid grid = (AlienGrid)column.pParent;
            grid.chehckForEmpty();
        }
    }
}
