using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UFORoot : UFO
    {
       private float ufoDeltaX;

        public UFORoot(GameObject.GameObjectName mGameObjectName, Sprite.SpriteName mSpriteName, int index, float mX, float mY, UFO.UFOType ufoType) : base(mGameObjectName, index,mSpriteName, ufoType)
        {
            this.x = mX;
            this.y = mY;
            this.ufoDeltaX = Unit.ufoDeltaX;
         //   this.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);
        }

        public override void Accept(CollisionVisitor other)
        {
          //  Debug.WriteLine("UFO Accept");
            other.visitUFORoot(this);
        }

        public override void update()
        {        
            base.updateUnionBox();
            base.update();
        }

        public override void visitMissileRoot(MissileRoot m)
        {
         //   Debug.WriteLine("UFORoot MissileRoot");
            CollisionPair.detectCollision((GameObject)this.pChild,m);
        }

        public override void visitMissileStraight(StraightMissile m)
        {
          ///  Debug.WriteLine("UFORoot StraightMissile");
            CollisionPair.detectCollision(m, (GameObject)this.pChild);
        }

        //wall
        public override void VisitWallRoot(WallRoot w)
        {
          //  Debug.WriteLine("UFORoot WallRoot");
            CollisionPair.detectCollision((GameObject)w.pChild, this);
        }
        public override void VisitWallRight(WallRight w)
        {
            Debug.WriteLine("UFORoot WallRight");
            CollisionPair.detectCollision(w, (GameObject)this.pChild);
        }

    }
}

