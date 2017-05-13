using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CannonShip : Ship
    {
        //public bool hit;
        public float delta;
        private ShipState shipState;
        public CannonShip(GameObject.GameObjectName mGameObjectName, Sprite.SpriteName mSpriteName, int index, float mX, float mY) : base(mGameObjectName,index, mSpriteName)
        {
            this.x = mX;
            this.y = mY;
          //  this.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);
            this.delta = Unit.shipDeltaX;
            this.shipState = null;
            // hit = false;
        }

        public override void Accept(CollisionVisitor other)
        {
            other.visitCannonShip(this);
        }
        public void setShipState(ShipManager.ShipStateType shipState)
        {
            this.shipState = ShipManager.getShipState(shipState);
        }
        public override void update()
        {
            base.update();
        }

        public void moveRight()
        {
            this.shipState.moveRight(this);
        }

        public void moveLeft()
        {
            this.shipState.moveLeft(this);
        }

        public void shoot()
        {
            this.shipState.shoot(this);
        }

        public override void VisitWallRoot(WallRoot w)
        {
            Debug.WriteLine("CannonShip WallRoot");
            CollisionPair.detectCollision(this,(GameObject)w.pChild);
        }
        public override void VisitWallRight(WallRight w)
        {
            Debug.WriteLine("CannonShip WallRight");
            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(this,w);
            currColPair.notifyObserver();
        }
        public override void VisitWallLeft(WallLeft w)
        {
            Debug.WriteLine("CannonShip WallLeft");
            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(this,w);
            currColPair.notifyObserver();
        }


        public override void visitBombRoot(BombRoot b)
        {
              Debug.WriteLine("CannonShip BombRoot");
            CollisionPair.detectCollision(this, (GameObject)b.pChild);
        }
        public override void visitFlippingBomb(FlippingBomb b)
        {
            Debug.WriteLine("CannonShip FlippingBomb");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(b, this);
            currColPair.notifyObserver();
        }
        public override void visitPlungerBomb(PlungerBomb b)
        {
            Debug.WriteLine("CannonShip PlungerBomb");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(b, this);
            currColPair.notifyObserver();
        }
        public override void visitZigZagBomb(ZigZagBomb b)
        {
            Debug.WriteLine("ShieldBrick ZigZagBomb");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(b, this);
            currColPair.notifyObserver();
        }
    }
}