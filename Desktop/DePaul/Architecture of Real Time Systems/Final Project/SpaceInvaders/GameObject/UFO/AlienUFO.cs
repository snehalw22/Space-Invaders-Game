using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienUFO : UFO
    {
        public float deltaX;

        public AlienUFO(GameObject.GameObjectName mGameObjectName, Sprite.SpriteName mSpriteName, int index, float mX, float mY,UFO.UFOType ufoType) : base(mGameObjectName,index, mSpriteName, ufoType)
        {
            this.deltaX = Unit.ufoDeltaX;
            this.setX(mX);
            this.setY(mY);
        //    this.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);
            this.launch = false;
        }

        public override void Accept(CollisionVisitor other)
        {
            other.visitAlienUFO(this);
        }
       
        public override void update()
        {
            if(launch)
            {
                launchUFO();
            }
            base.update();
        }

        public void launchUFO()
        {
            this.x += deltaX;
        }

        public void reset()
        {
          //  this.swapImage(Sprite.SpriteName.AlienUFO);
            this.x = Unit.ufoPosX;
            this.y = Unit.ufoPosY;
        }
        public override void visitMissileRoot(MissileRoot m)
        {
        //    Debug.WriteLine("AlienUFO MissileRoot");
            CollisionPair.detectCollision(this, (GameObject)m.pChild);
        }

        public override void visitMissileStraight(StraightMissile m)
        {
            Debug.WriteLine("AlienUFO StraightMissile");
            Debug.WriteLine("Both tress finished to roots");
            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(this, m);
            currColPair.notifyObserver();
        }

        // Walls
        public override void VisitWallRoot(WallRoot w)
        {
         //   Debug.WriteLine("AlienUFO WallRoot");
            CollisionPair.detectCollision((GameObject)w.pChild,this);
        }
        public override void VisitWallRight(WallRight w)
        {
            Debug.WriteLine("AlienUFO WallRight");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair colpair = CollisionPairManager.getCurrentColPair();
            colpair.setSubject(this, w);
            colpair.notifyObserver();
        }

    }
}
