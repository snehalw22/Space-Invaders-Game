using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MissileRoot : Missile
    {
    //    private float deltaY;
        private float total;
        public MissileRoot(GameObject.GameObjectName mGameObjectName, Sprite.SpriteName mSpriteName, int index, float mX, float mY, Missile.MissileType missileType) : base(mGameObjectName, index,mSpriteName,missileType)
        {
            this.x = mX;
            this.y = mY;
        //    this.deltaY = 10.0f;
            this.total = 0.0f;
           // this.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);
        }

        public override void Accept(CollisionVisitor other)
        {
           // Debug.WriteLine("MissilRoot Accept");
            other.visitMissileRoot(this);
        }
        public override void visitAlienGrid(AlienGrid m)
        {
         //   Debug.WriteLine("MissileRoot AlienGrid");
            CollisionPair.detectCollision((GameObject)this.pChild,m);
        }
        public override void visitColumn(Column a)
        {
          //  Debug.WriteLine("MissileRoot Column");
            CollisionPair.detectCollision((GameObject)this.pChild,a);
        }

        public override void visitCrab(Crab a)
        {
        //    Debug.WriteLine("MissileRoot Crab");
       
            CollisionPair.detectCollision(a, (GameObject)this.pChild);
        }

        public override void visitSquid(Squid a)
        {
        //    Debug.WriteLine("MissileRoot Squid");
            CollisionPair.detectCollision(a, (GameObject)this.pChild);
        }

        public override void visitOctopus(Octopus a)
        {
          //  Debug.WriteLine("MissileRoot Octopus");
            CollisionPair.detectCollision(a, (GameObject)this.pChild);
        }
        //public override void visitUFO(UFO a)
        //{
        //    Debug.WriteLine("MissileRoot UFO");
        //    Debug.WriteLine("Both tress finished to roots");
        //    CollisionPair.detectCollision(a, (GameObject)this.pChild);
        //}
        public override void update()
        {
           // this.privMoveGrid();
            base.updateUnionBox();
            base.update();

        }
     
        //Wall
        public override void VisitWallRoot(WallRoot w)
        {
         //   Debug.WriteLine("MissileRoot WallRoot");
            CollisionPair.detectCollision((GameObject)this.pChild,w);
        }
        public override void VisitWallTop(WallTop w)
        {
          //  Debug.WriteLine("MissileRoot WallTop");
            CollisionPair.detectCollision(w, (GameObject)this.pChild);
        }
      
        //Bomb
        public override void visitBombRoot(BombRoot b)
        {
         //   Debug.WriteLine("MissileRoot BombRoot");
            CollisionPair.detectCollision((GameObject)b.pChild, this);
        }
        public override void visitFlippingBomb(FlippingBomb b)
        {
//Debug.WriteLine("MissileRoot FlippingBomb");
            CollisionPair.detectCollision(b, (GameObject)this.pChild);
        }
        public override void visitPlungerBomb(PlungerBomb b)
        {
       //     Debug.WriteLine("MissileRoot PlungerBomb");
            CollisionPair.detectCollision(b, (GameObject)this.pChild);
        }
        public override void visitZigZagBomb(ZigZagBomb b)
        {
          //  Debug.WriteLine("MissileRoot ZigZagBomb");
            CollisionPair.detectCollision(b, (GameObject)this.pChild);
        }

        //UFO
        public override void visitUFORoot(UFORoot u)
        {
       //     Debug.WriteLine("MissileRoot UFORoot");
            CollisionPair.detectCollision((GameObject)u.pChild, this);
        }
        public override void visitAlienUFO(AlienUFO u)
        {
         //   Debug.WriteLine("MissileRoot AlienUFO");
            CollisionPair.detectCollision(u, (GameObject)this.pChild);
        }
    }
}

