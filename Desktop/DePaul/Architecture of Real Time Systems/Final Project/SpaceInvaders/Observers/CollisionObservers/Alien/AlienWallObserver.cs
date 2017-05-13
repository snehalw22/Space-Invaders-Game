using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    class AlienWallObserver : CollisionObserver
    {
        public override void notify()
        {
          //  Debug.WriteLine("Action after the Alien Grid / Wall goes here");
         //   Debug.WriteLine("AlienGrid & Wall Observer: {0} {1}", this.colSubject.gameObjA.cGameObjectName, this.colSubject.gameObjB.cGameObjectName);

            AlienGrid ag = (AlienGrid)this.colSubject.gameObjA;
            Wall wall = (Wall)this.colSubject.gameObjB;

            if (!ag.edgeHit)
            {
                ag.deltaX *= -1.0f;
                ag.setEdgeHit();
            }
        }
      
    }
}
