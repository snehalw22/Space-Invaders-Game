using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipWallObserver : CollisionObserver
    {
        public override void notify()
        {
            GameObject gameObjectA = this.colSubject.gameObjA;
            GameObject gameObjectB = this.colSubject.gameObjB;
            if (gameObjectB.cGameObjectName == GameObject.GameObjectName.WallRight)
            {
                gameObjectA.x = gameObjectA.x - 10.0f;
            }
            if (gameObjectB.cGameObjectName == GameObject.GameObjectName.WallLeft)
            {
                gameObjectA.x = gameObjectA.x + 10.0f;
            }
        }
    }
}
