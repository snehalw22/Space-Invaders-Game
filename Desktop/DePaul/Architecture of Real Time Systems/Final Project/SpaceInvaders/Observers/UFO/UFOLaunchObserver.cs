using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UFOLaunchObserver : CollisionObserver
    {
        public override void notify()
        {
            UFO ufo = null;

            if(this.colSubject.gameObjA.cGameObjectName == GameObject.GameObjectName.AlienUFO)
            {
                ufo = (UFO)this.colSubject.gameObjA;
            }
            else
            {
                ufo = (UFO)this.colSubject.gameObjB;
            }
            Random random = new Random(DateTime.UtcNow.Millisecond);
            int number = random.Next(Unit.UFOLaunchMin,Unit.UFOLaunchMax);
            ufo.reset();
            ufo.launch = false;
            UFOActivate ufoAct = new UFOActivate(ufo);
            TimerManager.sortedAdd(TimerEvent.TimerEventName.ActivateUFO, ufoAct, number);
        }
    }
}
