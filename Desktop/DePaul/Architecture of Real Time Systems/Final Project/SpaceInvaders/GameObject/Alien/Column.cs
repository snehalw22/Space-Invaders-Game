using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Column : Alien
    {
        public Column(GameObject.GameObjectName mGameObjectName, Sprite.SpriteName mSpriteName, int index, float mX, float mY) : base(mGameObjectName, index, mSpriteName)
        {
            this.x = mX;
            this.y = mY;

          //  this.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);
        }

        public override void Accept(CollisionVisitor other)
        {
            other.visitColumn(this);
        }

        public override void update()
        {
        ////    Debug.WriteLine("Column update");
        //    if (this.pChild == null)
        //    {
        //        if (this.pSibling != null)
        //        {
        //            this.pParent.pChild = this.pSibling;
        //        }
        //        this.remove();
        //   //     Debug.WriteLine("null ss");
        //    }
        //    else
        //    {
                base.updateUnionBox();
                base.update();
          //  }
        }

        public override void visitMissileRoot(MissileRoot m)
        {
           // Debug.WriteLine("Column MissileRoot");
            CollisionPair.detectCollision(m, (GameObject)this.pChild);

        }

        public override void visitMissileStraight(StraightMissile m)
        {
           // Debug.WriteLine("Column StraightMissile");
            CollisionPair.detectCollision(m, (GameObject)this.pChild);
        }

        public void markForDeathCheck()
        {
            Alien alien = (Alien)this.pChild;
            int count = 0;
            while (alien != null)
            {
                //Alien is still active, not marked for death
                if (!alien.death)
                {
                    count++;
                    break;
                }
                alien = (Alien)alien.pSibling;
            }

            if (count == 0)
            {
                this.markForDeath();
                // column.remove();
            }
        }    
    }
}
