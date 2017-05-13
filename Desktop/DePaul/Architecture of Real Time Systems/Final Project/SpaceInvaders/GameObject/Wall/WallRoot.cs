using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    class WallRoot : Wall
    {
        public WallRoot(GameObjectName mGameObjectName, int index, Sprite.SpriteName mSpriteName,Wall.WallType walltype) : base(mGameObjectName, index, mSpriteName, walltype)
        {
           // this.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);
        }
        public override void update()
        {
            // Go to first child
            base.updateUnionBox();
            base.update();
        }
        public override void Accept(CollisionVisitor other)
        {
            //Debug.WriteLine("Wall Root accept");
            other.VisitWallRoot(this);
        }
        //AlienGrid
        public override void visitAlienGrid(AlienGrid m)
        {
            // Debug.WriteLine("WallRoot AlienGrid");
            // CollisionPair.detectCollision( m, (GameObject)this.pChild);//Chnaged this to fix grid
            CollisionPair.detectCollision(m,(GameObject)this.pChild);
        }

        //Ship
        public override void visitShipRoot(ShipRoot s)
        {
            ///Debug.WriteLine("WallRoot ShipRoot");
            CollisionPair.detectCollision((GameObject)this.pChild, s);
        }
        public override void visitCannonShip(CannonShip s)
        {
           // Debug.WriteLine("WallRoot CannonShip");
            CollisionPair.detectCollision(s, (GameObject)this.pChild);
        }

        //Missile visit

        public override void visitMissileRoot(MissileRoot m)
        {
            //Debug.WriteLine("WallRoot MissileRoot");
            CollisionPair.detectCollision( this, (GameObject)m.pChild);
        }
        public override void visitMissileStraight(StraightMissile m)
        {
            //Debug.WriteLine("WallRoot MissileRoot");
            CollisionPair.detectCollision(m, (GameObject)this.pChild);
        }

        //Bomb

        public override void visitBombRoot(BombRoot b)
        {
            //Debug.WriteLine("WallRoot BombRoot");
                CollisionPair.detectCollision((GameObject)this.pChild,b);
          //  CollisionPair.detectCollision((GameObject)b.pChild, this);
        }
        public override void visitFlippingBomb(FlippingBomb b)
        {
           // Debug.WriteLine("WallRoot FlippingBomb");
            CollisionPair.detectCollision(b, (GameObject)this.pChild);
        }
        public override void visitPlungerBomb(PlungerBomb b)
        {
           // Debug.WriteLine("WallRoot PlungerBomb");
            CollisionPair.detectCollision(b, (GameObject)this.pChild);
        }
        public override void visitZigZagBomb(ZigZagBomb b)
        {
            //Debug.WriteLine("WallRoot ZigZagBomb");
            CollisionPair.detectCollision(b, (GameObject)this.pChild);
        }

        //UFO
        public override void visitUFORoot(UFORoot u)
        {
            //Debug.WriteLine("WallRoot UFORoot");
            CollisionPair.detectCollision((GameObject)this.pChild, u);
        }
        public override void visitAlienUFO(AlienUFO u)
        {
            //Debug.WriteLine("WallRoot AlienUFO");
            CollisionPair.detectCollision(u, (GameObject)this.pChild);
        }
    }
}
