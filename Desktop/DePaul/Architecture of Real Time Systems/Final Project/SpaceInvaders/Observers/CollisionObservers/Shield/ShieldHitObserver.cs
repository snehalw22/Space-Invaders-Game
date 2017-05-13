using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldHitObserver : CollisionObserver
    {
        public override void notify()
        {
            Shield shield = (Shield)this.colSubject.gameObjB;

            ShieldColumn col = (ShieldColumn)shield.pParent;
            ShieldUnit unit = (ShieldUnit)col.pParent;

            shield.remove();
            if(col.pChild==null)
            {
                col.remove();
            }
            if(unit.pChild==null)
            {
                unit.remove();
            }
        }
    }
}
