using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldUnit : Shield
    {
        public ShieldUnit(GameObject.GameObjectName mGameObjectName, Sprite.SpriteName mSpriteName, int index, float mX, float mY) : base(mGameObjectName, index, mSpriteName)
        {
            this.x = mX;
            this.y = mY;
          //  this.cCollisionObj.cSpriteBox.setColor(Unit.blueColor);
        }

        public override void Accept(CollisionVisitor other)
        {
            other.visitShieldUnit(this);
        }

        public override void update()
        {
            base.updateUnionBox();
            base.update();
        }

        public override void visitMissileStraight(StraightMissile m)
        {
            //   Debug.WriteLine("ShieldUnit StraightMissile");
            CollisionPair.detectCollision(m, (GameObject)this.pChild);
        }

  
        public override void visitFlippingBomb(FlippingBomb b)
        {
            //   Debug.WriteLine("ShieldUnit FlippingBomb");
            CollisionPair.detectCollision(b, (GameObject)this.pChild);
        }
        public override void visitPlungerBomb(PlungerBomb b)
        {
            //Debug.WriteLine("ShieldUnit PlungerBomb");
            CollisionPair.detectCollision(b, (GameObject)this.pChild);
        }
        public override void visitZigZagBomb(ZigZagBomb b)
        {
            //  Debug.WriteLine("ShieldUnit ZigZagBomb");
            CollisionPair.detectCollision(b, (GameObject)this.pChild);
        }


        public override void visitColumn(Column a)
        {
            //  Debug.WriteLine("ShieldUnit Column");
            CollisionPair.detectCollision(a, (GameObject)this.pChild);
        }

    }
}
