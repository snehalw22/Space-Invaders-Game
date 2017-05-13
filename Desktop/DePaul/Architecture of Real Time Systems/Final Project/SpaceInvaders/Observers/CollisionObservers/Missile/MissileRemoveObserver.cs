using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MissileRemoveObserver : CollisionObserver
    {
        public MissileRemoveObserver()
        {
        }

        public override void notify()
        {
            // Delete missile
            GameObject gameObjA = this.colSubject.gameObjA;
            GameObject gameObjB = this.colSubject.gameObjB;

            Debug.WriteLine("ShipRemoveMissileObserver: {0} {1}", gameObjA.cGameObjectName, gameObjB.cGameObjectName);
            
            if(gameObjA.cGameObjectName == GameObject.GameObjectName.StraightMissile)
            {
                gameObjA.remove();
            }
            else
            {
                gameObjB.remove();
            }

        }
    }
}
