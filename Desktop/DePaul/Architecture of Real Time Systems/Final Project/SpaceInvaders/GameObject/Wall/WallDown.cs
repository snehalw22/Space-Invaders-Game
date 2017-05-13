using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    class WallDown : Wall
    {
        public WallDown(GameObjectName mGameObjectName, int index, Sprite.SpriteName mSpriteName, float x, float y, float width, float height, Wall.WallType walltype) : base(mGameObjectName, index, mSpriteName, walltype)
        {
            this.setCollisionRect(x, y, width, height);
            this.x = x;
            this.y = y;

           this.cCollisionObj.cSpriteBox.setColor(Unit.redColor);
        }

        public override void Accept(CollisionVisitor other)
        {
          //  Debug.WriteLine("Wall accept");
            other.VisitWallDown(this);
        }

        public override void update()
        {
            base.update();

        }
        /// Grid Visit

        public override void visitAlienGrid(AlienGrid a)
        {
         //   Debug.WriteLine("WallDown AlienGrid");
          //  Debug.WriteLine("I am hit. now?????");
        }


        //Bomb

        public override void visitBombRoot(BombRoot b)
        {
            // Debug.WriteLine("WallDown BombRoot");
            // CollisionPair.detectCollision((GameObject)b.pChild,this);
            CollisionPair.detectCollision(this, (GameObject)b.pChild);
        }
        public override void visitFlippingBomb(FlippingBomb b)
        {
            Debug.WriteLine("WallDown FlippingBomb");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(b, this);
            currColPair.notifyObserver();
        }
        public override void visitPlungerBomb(PlungerBomb b)
        {
            Debug.WriteLine("WallDown PlungerBomb");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(b, this);
            currColPair.notifyObserver();
        }
        public override void visitZigZagBomb(ZigZagBomb b)
        {
            Debug.WriteLine("WallDown ZigZagBomb");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(b, this);
            currColPair.notifyObserver();
        }
    }
}
