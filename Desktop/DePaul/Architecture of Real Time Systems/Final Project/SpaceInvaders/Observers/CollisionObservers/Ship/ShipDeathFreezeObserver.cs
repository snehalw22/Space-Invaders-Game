using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipDeathFreezeObserver : CollisionObserver
    {
        public float delta;

        public ShipDeathFreezeObserver(float mDelta)
        {
            Debug.Assert(mDelta > 0);
            this.delta = mDelta;
        }
        public override void notify()
        {
            TimerManager.addDelta(delta);
            FactoryManager.getBombFactry().removeChildren();
            UFO ufo = (UFO)FactoryManager.getUfoFactry().cParent.pChild;
            if (ufo.launch)
            {
                ufo.reset();
                Random random = new Random(DateTime.UtcNow.Millisecond);
                int number = random.Next(1, 40);
                UFOActivate ufoAct = new UFOActivate(ufo);
                TimerManager.sortedAdd(TimerEvent.TimerEventName.ActivateUFO, ufoAct, number);
            }
            //   Game.freezeGame();     
        }
    }
}
