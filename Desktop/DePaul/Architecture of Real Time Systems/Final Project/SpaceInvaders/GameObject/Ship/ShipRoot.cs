using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipRoot : Ship
    {  
        public ShipRoot(GameObject.GameObjectName mGameObjectName, Sprite.SpriteName mSpriteName, int index, float mX, float mY) : base(mGameObjectName, index,mSpriteName)
        {
            this.x = mX;
            this.y = mY;
          //  this.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);
        }

        public override void Accept(CollisionVisitor other)
        {
            other.visitShipRoot(this);
        }

        public override void update()
        {
          //  this.privMoveGrid();
            base.updateUnionBox();
            base.update();

        }

        public override void VisitWallRoot(WallRoot w)
        {
            Debug.WriteLine("ShipRoot WallRoot");
            CollisionPair.detectCollision((GameObject)this.pChild, w);
        }
        public override void VisitWallRight(WallRight w)
        {
            Debug.WriteLine("ShipRoot WallRight");
            CollisionPair.detectCollision( w,(GameObject)this.pChild);
        }
        public override void VisitWallLeft(WallLeft w)
        {
            Debug.WriteLine("ShipRoot WallLeft");
            CollisionPair.detectCollision(w, (GameObject)this.pChild);
        }

    
        //Bomb

        public override void visitBombRoot(BombRoot b)
        {
           // Debug.WriteLine("ShipRoot BombRoot");
            CollisionPair.detectCollision((GameObject)this.pChild, b);
        }
        public override void visitFlippingBomb(FlippingBomb b)
        {
         //   Debug.WriteLine("ShipRoot FlippingBomb");
            CollisionPair.detectCollision(b, (GameObject)this.pChild);
        }
        public override void visitPlungerBomb(PlungerBomb b)
        {
            //Debug.WriteLine("ShipRoot PlungerBomb");
            CollisionPair.detectCollision(b, (GameObject)this.pChild);
        }
        public override void visitZigZagBomb(ZigZagBomb b)
        {
          //  Debug.WriteLine("ShipRoot ZigZagBomb");
            CollisionPair.detectCollision(b, (GameObject)this.pChild);
        }

        //Alien

        public override void visitAlienGrid(AlienGrid a)
        {
            Debug.WriteLine("ShipRootss AlienGrid");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(a,this);
            currColPair.notifyObserver();
        }

    }
}
