using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Squid : Alien
    {
        public Squid(GameObject.GameObjectName mGameObjectName, Sprite.SpriteName mSpriteName, int index, float mX, float mY) : base(mGameObjectName, index, mSpriteName)
        {
            this.setX(mX);
          //  this.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);
            this.setY(mY);
        }

        public override void Accept(CollisionVisitor other)
        {
            other.visitSquid(this);
        }

        public override void update()
        {
    
            base.update();

        }
        public override void visitMissileRoot(MissileRoot m)
        {
         //   Debug.WriteLine("Squid MissileRoot");
            CollisionPair.detectCollision( this, (GameObject)m.pChild);

        }

     

        public override void visitMissileStraight(StraightMissile m)
        {
            Debug.WriteLine("Squid StraightMissile");
            Debug.WriteLine("Both tress finished to roots");
            //m.hit = true;
            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(this,m);
            currColPair.notifyObserver();

           // m.hit = true;
        }

    }
}
