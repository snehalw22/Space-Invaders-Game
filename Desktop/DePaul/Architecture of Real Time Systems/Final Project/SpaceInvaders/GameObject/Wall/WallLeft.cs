using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    class WallLeft : Wall
    {
        public WallLeft(GameObjectName mGameObjectName, int index, Sprite.SpriteName mSpriteName,  float x, float y, float width, float height,Wall.WallType walltype) : base(mGameObjectName, index, mSpriteName, walltype)
        {
            this.setCollisionRect(x, y, width, height);
            this.x = x;
            this.y = y;
         //   this.cCollisionObj.cSpriteBox.setColor(Unit.redColor);
        }

        public override void Accept(CollisionVisitor other)
        {
            other.VisitWallLeft(this);
        }
        public override void update()
        {
            base.update();

        }
        /// Grid Visit

        public override void visitAlienGrid(AlienGrid a)
        {
          //  Debug.WriteLine("WallLeft AlienGrid");
          //  Debug.WriteLine("I am hit. now?????");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(a, this);
            currColPair.notifyObserver();
        }
        //Ship
        public override void visitShipRoot(ShipRoot s)
        {
          //  Debug.WriteLine("WallLeft ShipRoot");
            CollisionPair.detectCollision(this, (GameObject)s.pChild);
        }
        public override void visitCannonShip(CannonShip s)
        {
            Debug.WriteLine("WallLeft CannonShip");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(s, this);
            currColPair.notifyObserver();
        }
     
    }
}
