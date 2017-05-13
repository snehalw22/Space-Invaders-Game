using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldColumn : Shield
    {
        public ShieldColumn(GameObject.GameObjectName mGameObjectName, Sprite.SpriteName mSpriteName, int index, float mX, float mY) : base(mGameObjectName, index, mSpriteName)
        {
            this.x = mX;
            this.y = mY;
       //     this.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);
        }

        public override void Accept(CollisionVisitor other)
        {
            other.visitShieldColumn(this);
        }

        public override void update()
        {
            base.updateUnionBox();
            base.update();
        }


        public override void visitMissileStraight(StraightMissile m)
        {
            // Missile vs ShieldColumn
            CollisionPair.detectCollision(m, (GameObject)this.pChild);
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

        public override void visitColumn(Column a)
        {
            Debug.WriteLine("ShieldBrick Column");
            CollisionPair.detectCollision(a, (GameObject)this.pChild);

        }

    }
}
