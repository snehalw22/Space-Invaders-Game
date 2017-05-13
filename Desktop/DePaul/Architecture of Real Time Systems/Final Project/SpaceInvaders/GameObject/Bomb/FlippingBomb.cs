using System;
using System.Diagnostics;
namespace SpaceInvaders
{
     class FlippingBomb : Bomb
    {
        //public bool active;
        public FlippingBomb(GameObject.GameObjectName mGameObjectName, Sprite.SpriteName mSpriteName, int index,float mX, float mY, BombType bombType) : base(mGameObjectName,index, mSpriteName, bombType)
        {
            this.x = mX;
            this.y = mY;
            this.active = false;
          //  this.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);
        }

        public override void Accept(CollisionVisitor other)
        {
            other.visitFlippingBomb(this);
        }
        public override void update()
        {
            base.update();

        }
      
        //Walls
        public override void VisitWallRoot(WallRoot w)
        {
         //   Debug.WriteLine("FlippingBomb WallRoot");
            CollisionPair.detectCollision(this, (GameObject)w.pChild);
        }
        public override void VisitWallDown(WallDown w)
        {
            Debug.WriteLine("FlippingBomb WallDown");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair colpair = CollisionPairManager.getCurrentColPair();
            colpair.setSubject(this, w);
            colpair.notifyObserver();
        }

     
        //Shield
        public override void visitShieldGrid(ShieldGrid s)
        {
       //     Debug.WriteLine("FlippingBomb ShieldGrid");
            CollisionPair.detectCollision(this, (GameObject)s.pChild);
        }
        public override void visitShieldBrick(ShieldBrick s)
        {
            Debug.WriteLine("FlippingBomb ShieldBrick");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(this, s);
            currColPair.notifyObserver();
        }

        //Ship
        public override void visitShipRoot(ShipRoot s)
        {
        //    Debug.WriteLine("FlippingBomb ShipRoot");
            CollisionPair.detectCollision(this, (GameObject)s.pChild);
        }
        public override void visitCannonShip(CannonShip s)
        {
            Debug.WriteLine("FlippingBomb CannonShip");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(this,s);
            currColPair.notifyObserver();
        }

    }
}