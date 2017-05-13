using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldBrick : Shield
    {
        public ShieldBrick(GameObject.GameObjectName mGameObjectName, Sprite.SpriteName mSpriteName,int index , float mX, float mY) : base(mGameObjectName, index, mSpriteName)
        {
            this.x = mX;
            this.y = mY;
          //  this.cCollisionObj.cSpriteBox.setColor(Unit.redColor);
        }

        public override void Accept(CollisionVisitor other)
        {
            other.visitShieldBrick(this);
        }
        public override void update()
        {
            base.update();

        }
       
        public override void visitMissileStraight(StraightMissile m)
        {
            Debug.WriteLine("ShieldBrick StraightMissile");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(m, this);
            currColPair.notifyObserver();
        }

    
        public override void visitFlippingBomb(FlippingBomb b)
        {
            Debug.WriteLine("ShieldBrick FlippingBomb");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(b, this);
            currColPair.notifyObserver();
        }
        public override void visitPlungerBomb(PlungerBomb b)
        {
            Debug.WriteLine("ShieldBrick PlungerBomb");
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

     
        public override void visitColumn(Column a)
        {
            Debug.WriteLine("ShieldBrick Column");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(a, this);
            currColPair.notifyObserver();
        }

    }
}
