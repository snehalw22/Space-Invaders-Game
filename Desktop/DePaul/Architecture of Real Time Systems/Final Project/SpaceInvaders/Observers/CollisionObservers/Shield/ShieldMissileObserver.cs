using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldMissileObserver : CollisionObserver
    {
        public override void notify()
        {
            Missile missile = (Missile)this.colSubject.gameObjA;
            Shield shield =  (Shield) this.colSubject.gameObjB;

            missile.remove();
         
        }
    }
}
