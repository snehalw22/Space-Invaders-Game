using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    class StraightMissile : Missile
    {
      //  public bool hit;
        public float delta;
        public bool launch;
        public StraightMissile(GameObject.GameObjectName mGameObjectName, Sprite.SpriteName mSpriteName,int index, float mX, float mY,Missile.MissileType missileType) : base(mGameObjectName,index, mSpriteName, missileType)
        {
            this.x = mX;
            this.y = mY;
            this.delta =20.0f;
            this.launch = false;
         //   this.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);
            //  hit = false;
        }

        public override void Accept(CollisionVisitor other)
        {
            other.visitMissileStraight(this);
        }
        public override void visitAlienGrid(AlienGrid a)
        {
        //    Debug.WriteLine("StraightMissile AlienGrid");
            CollisionPair.detectCollision(this,(GameObject)a);           
        }
        public override void visitColumn(Column c)
        {
        //    Debug.WriteLine("StraightMissile Column");
            CollisionPair.detectCollision(this, (GameObject)c);
        }

        public override void visitCrab(Crab a)
        {
            Debug.WriteLine("StraightMissile Crab");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(a, this);
            currColPair.notifyObserver();
        }

        public override void visitSquid(Squid a)
        {
            Debug.WriteLine("StraightMissile Squid");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(a, this);
            currColPair.notifyObserver();
        }

        public override void visitOctopus(Octopus a)
        {
            Debug.WriteLine("StraightMissile Octopus");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(a, this);
            currColPair.notifyObserver();

        }
      
        public override void update()
        {
            base.update();
            this.y += delta;
       
        }
        public void setPosition(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public void launchMissile()
        {
            this.launch = true;
        }
        // Walls
        public override void VisitWallRoot(WallRoot w)
        {
           // Debug.WriteLine("StraightMissile WallRoot");
            CollisionPair.detectCollision(this, (GameObject)w.pChild);
        }
        public override void VisitWallTop(WallTop w)
        {
            Debug.WriteLine("StraightMissile WallTop");
            Debug.WriteLine("Both tress finished to roots");

            this.delta = -2.0f;

            CollisionPair colpair = CollisionPairManager.getCurrentColPair();
            colpair.setSubject(this,w);
            colpair.notifyObserver();
        }


        //Bomb
        public override void visitBombRoot(BombRoot b)
        {
          //  Debug.WriteLine("StraightMissile BombRoot");
            CollisionPair.detectCollision(this, (GameObject)b.pChild);
        }
        public override void visitFlippingBomb(FlippingBomb b)
        {
            Debug.WriteLine("StraightMissile FlippingBomb");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(b, this);
            currColPair.notifyObserver();
        }
        public override void visitPlungerBomb(PlungerBomb b)
        {
            Debug.WriteLine("StraightMissile PlungerBomb");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(b, this);
            currColPair.notifyObserver();
        }
        public override void visitZigZagBomb(ZigZagBomb b)
        {
            Debug.WriteLine("StraightMissile ZigZagBomb");
            Debug.WriteLine("Both tress finished to roots");

            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(b, this);
            currColPair.notifyObserver();
        }
//UFO
        public override void visitUFORoot(UFORoot u)
        {
           // Debug.WriteLine("StraightMissile UFORoot");
            CollisionPair.detectCollision(this, (GameObject)u.pChild);
        }
        public override void visitAlienUFO(AlienUFO u)
        {
            Debug.WriteLine("StraightMissile AlienUFO");
            Debug.WriteLine("Both tress finished to roots");
            CollisionPair currColPair = CollisionPairManager.getCurrentColPair();
            Debug.Assert(currColPair != null);
            currColPair.setSubject(this,u);
            currColPair.notifyObserver();
        }
    }
}