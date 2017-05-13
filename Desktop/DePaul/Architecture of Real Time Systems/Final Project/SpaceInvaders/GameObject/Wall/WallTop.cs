using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class WallTop : Wall
    {
        public WallTop(GameObjectName mGameObjectName, int index, Sprite.SpriteName mSpriteName, float x, float y, float width, float height, Wall.WallType walltype) : base(mGameObjectName, index, mSpriteName, walltype)
        {

            this.setCollisionRect(x, y, width, height);
            this.x = x;
            this.y = y;
            this.cCollisionObj.cSpriteBox.setColor(Unit.redColor);
        }

        public override void Accept(CollisionVisitor other)
        {
            other.VisitWallTop(this);
        }
        public override void update()
        {
            base.update();
        }

        /// Grid Visit

        public override void visitAlienGrid(AlienGrid a)
        {
          //  Debug.WriteLine("WallTop AlienGrid");
          //  Debug.WriteLine("I am hit. now?????");
        }

        //Missile visit

        public override void visitMissileRoot(MissileRoot m)
        {
          //  Debug.WriteLine("WallTop MissileRoot");
            CollisionPair.detectCollision((GameObject)m.pChild, this);
        }
        public override void visitMissileStraight(StraightMissile m)
        {
            Debug.WriteLine("WallTop StraightMissile");
            Debug.WriteLine("Both tress finished to roots");
            //m.hit = true;
          //  m.delta = -2.0f;

            CollisionPair colpair = CollisionPairManager.getCurrentColPair();
            colpair.setSubject(m, this);
            colpair.notifyObserver();
        }
    }
}
