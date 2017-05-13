using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    class WallRight : Wall
    {
        public WallRight(GameObjectName mGameObjectName, int index, Sprite.SpriteName mSpriteName, float x, float y, float width, float height, Wall.WallType walltype) : base(mGameObjectName, index, mSpriteName, walltype)
        {
            this.setCollisionRect(x, y, width, height);
            this.x = x;
            this.y = y;
            //this.cCollisionObj.cSpriteBox.setColor(Unit.redColor);
        }

        public override void Accept(CollisionVisitor other)
        {
            other.VisitWallRight(this);
        }
        public override void update()
        {
            base.update();

        }
        /// Grid Visit

        public override void visitAlienGrid(AlienGrid a)
        {
          //  Debug.WriteLine("WallRight AlienGrid");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(a, this);
            currColPair.notifyObserver();          
        }

        //Ship

        public override void visitShipRoot(ShipRoot s)
        {
           // Debug.WriteLine("WallRight ShipRoot");
            CollisionPair.detectCollision(this, (GameObject)s.pChild);
        }
        public override void visitCannonShip(CannonShip s)
        {
           // Debug.WriteLine("WallRight CannonShip");
          //  Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(s, this);
            currColPair.notifyObserver();
        }

        public override void visitMissileRoot(MissileRoot m)
        {
          //  Debug.WriteLine("WallRight MissileRoot");
            CollisionPair.detectCollision((GameObject)m.pChild, this);
        }
        public override void visitMissileStraight(StraightMissile m)
        {
            Debug.WriteLine("WallRight StraightMissile");
            Debug.WriteLine("Both tress finished to roots");

            m.delta = -2.0f;

            CollisionPair colpair = CollisionPairManager.getCurrentColPair();
            colpair.setSubject(m, this);
            colpair.notifyObserver();
        }
     
        //UFO
        public override void visitUFORoot(UFORoot u)
        {
          //  Debug.WriteLine("WallRight UFORoot");
            CollisionPair.detectCollision(this, (GameObject)u.pChild);
        }
        public override void visitAlienUFO(AlienUFO u)
        {
            Debug.WriteLine("WallRight AlienUFO");
            Debug.WriteLine("Both tress finished to roots");
            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(u,this);
            currColPair.notifyObserver();
        }
    }

}
