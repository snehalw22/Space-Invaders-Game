using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    class Crab : Alien
    {

        public Crab(GameObject.GameObjectName mGameObjectName,Sprite.SpriteName mSpriteName,int index ,float mX, float mY) : base(mGameObjectName,index, mSpriteName)
        {
            this.x = mX;
            this.y = mY;
          //  this.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);
        }

        public override void Accept(CollisionVisitor other)
        {
            other.visitCrab(this);
        }

        public override void update()
        {
            base.update();

        }

        public override void visitMissileRoot(MissileRoot m)
        {
           // Debug.WriteLine("Crab MissileRoot");
            CollisionPair.detectCollision( this, (GameObject)m.pChild);

        }

        public override void visitMissileStraight(StraightMissile m)
        {
            Debug.WriteLine("Crab StraightMissile");
            Debug.WriteLine("Both tress finished to roots");
            //   m.hit = true;
            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(this, m);
            currColPair.notifyObserver();

        }
    }
}
