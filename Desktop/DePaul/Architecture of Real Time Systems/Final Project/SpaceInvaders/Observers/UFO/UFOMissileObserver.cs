using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UFOMissileObserver : CollisionObserver
    {
        public override void notify()
        {
            Debug.WriteLine("Action after the Alien and Missile hits goes here");
            Debug.WriteLine("UFOMissileObserver Observer: {0} {1}", this.colSubject.gameObjA.cGameObjectName, this.colSubject.gameObjB.cGameObjectName);

            Missile missile = (Missile)this.colSubject.gameObjA;

            UFO ufo = (UFO)this.colSubject.gameObjB;
           

            missile.remove();
            ufo.explode(Sprite.SpriteName.AlienExplosion);
            //ufo.removeFromGameManager();
            //ufo.markForDeath();

            //Update Score
            PlayerManager.getCurrentPlayer().addScore(Unit.ufoScore);
            
            ufo.launch = false;
            UFODeathAnimation deathAni = new UFODeathAnimation(ufo);
            TimerManager.sortedAdd(TimerEvent.TimerEventName.DeathAnimation, deathAni, Unit.ufoDeathAnimationTime);

            Random random = new Random(DateTime.UtcNow.Millisecond);
            int number = random.Next(Unit.UFOLaunchMin, Unit.UFOLaunchMax);
            UFOActivate ufoAct = new UFOActivate(ufo);
            TimerManager.sortedAdd(TimerEvent.TimerEventName.ActivateUFO, ufoAct, number);
        }
    }
}
