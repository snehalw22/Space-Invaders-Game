using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Octopus : Alien
    {
        public Octopus(GameObject.GameObjectName mGameObjectName, Sprite.SpriteName mSpriteName, int index,float mX, float mY) : base(mGameObjectName,index, mSpriteName)
        {
            this.setX(mX);
            this.setY(mY);
          //  this.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);
        }

        public override void Accept(CollisionVisitor other)
        {
            other.visitOctopus(this);
        }
        public override void visitMissileRoot(MissileRoot m)
        {
           // Debug.WriteLine("Octopus MissileRoot");
            CollisionPair.detectCollision(this,(GameObject)m.pChild);

        }

        public override void visitMissileStraight(StraightMissile m)
        {
            Debug.WriteLine("Octopus StraightMissile");
            Debug.WriteLine("Both tress finished to roots");
            //  m.hit = true;
            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(this, m);
            currColPair.notifyObserver();

        }
        public override void update()
        {
            base.update();

        }
    }
}
