using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldGrid : Shield
    {
        public ShieldGrid(GameObject.GameObjectName mGameObjectName, int index, Sprite.SpriteName mSpriteName) : base(mGameObjectName, index, mSpriteName)
        {
       //   this.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);
        }
        public override void update()
        {
            // Go to first child
            base.updateUnionBox();
            base.update();
        }
        public override void Accept(CollisionVisitor other)
        {
            other.visitShieldGrid(this);
        }

        public override void visitMissileRoot(MissileRoot m)
        {
          //   Debug.WriteLine("ShieldUnit MissileRoot");
            CollisionPair.detectCollision((GameObject)m.pChild, this);
        }
        public override void visitMissileStraight(StraightMissile m)
        {
            // Missile vs ShieldGrid
            CollisionPair.detectCollision(m, (GameObject)this.pChild);
        }
        //Bomb

        public override void visitBombRoot(BombRoot b)
        {
         //   Debug.WriteLine("ShieldGrid BombRoot");
            // CollisionPair.detectCollision((GameObject)b.pChild, this);
            CollisionPair.detectCollision((GameObject)b.pChild, this);
        }
        public override void visitFlippingBomb(FlippingBomb b)
        {
         //   Debug.WriteLine("ShieldGrid FlippingBomb");
            CollisionPair.detectCollision(b, (GameObject)this.pChild);
        }
        public override void visitPlungerBomb(PlungerBomb b)
        {
          //  Debug.WriteLine("ShieldGrid PlungerBomb");
            CollisionPair.detectCollision(b, (GameObject)this.pChild);
        }
        public override void visitZigZagBomb(ZigZagBomb b)
        {
           // Debug.WriteLine("ShieldGrid ZigZagBomb");
            CollisionPair.detectCollision(b, (GameObject)this.pChild);
        }

        //Alien
        public override void visitAlienGrid(AlienGrid a)
        {
         //   Debug.WriteLine("ShieldGrid AlienGrid");
            CollisionPair.detectCollision((GameObject)a.pChild, this);
        }
        public override void visitColumn(Column a)
        {
            //   Debug.WriteLine("ShieldGrid AlienGrid");
            //   CollisionPair.detectCollision((GameObject)this.pChild, a);
            CollisionPair.detectCollision(a, (GameObject)this.pChild);
        }
    }
}
