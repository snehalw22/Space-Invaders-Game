using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlungerBomb : Bomb
    {
        //public bool active;
        public PlungerBomb(GameObject.GameObjectName mGameObjectName, Sprite.SpriteName mSpriteName, int index, float mX, float mY, BombType bombType) : base(mGameObjectName,index, mSpriteName, bombType)
        {
            this.x = mX;
            this.y = mY;
            this.active = false;
        //    this.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);
        }

        public override void Accept(CollisionVisitor other)
        {
            other.visitPlungerBomb(this);
        }
        public override void update()
        {
            base.update();

        }
   
        //Walls
        public override void VisitWallRoot(WallRoot w)
        {
         //   Debug.WriteLine("PlungerBomb WallRoot");
            CollisionPair.detectCollision(this, (GameObject)w.pChild);
        }
        public override void VisitWallDown(WallDown w)
        {
            Debug.WriteLine("PlungerBomb WallDown");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair colpair = CollisionPairManager.getCurrentColPair();
            colpair.setSubject(this, w);
            colpair.notifyObserver();
        }

        //Missile

        public override void visitMissileRoot(MissileRoot m)
        {
          //  Debug.WriteLine("PlungerBomb MissileRoot");
            CollisionPair.detectCollision(this, (GameObject)m.pChild);
        }
        public override void visitMissileStraight(StraightMissile m)
        {
            Debug.WriteLine("PlungerBomb StraightMissile");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair colpair = CollisionPairManager.getCurrentColPair();
            colpair.setSubject(this, m);
            colpair.notifyObserver();
        }

        //Ship
        public override void visitShipRoot(ShipRoot s)
        {
         //   Debug.WriteLine("WallLeft ShipRoot");
            CollisionPair.detectCollision(this, (GameObject)s.pChild);
        }
        public override void visitCannonShip(CannonShip s)
        {
            Debug.WriteLine("WallLeft CannonShip");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(this,s);
            currColPair.notifyObserver();
        }

    }
}
