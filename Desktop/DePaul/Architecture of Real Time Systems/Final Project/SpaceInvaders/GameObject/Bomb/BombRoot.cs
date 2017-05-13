using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BombRoot : Bomb
    {
        private float delta;

        public BombRoot(GameObject.GameObjectName mGameObjectName, Sprite.SpriteName mSpriteName, int index, float mX, float mY, BombType bombType) : base(mGameObjectName, index, mSpriteName, bombType)
        {
            this.x = mX;
            this.y = mY;
            //this.delta = 4.0f;
            this.delta = Unit.bombDeltaY;
          //  this.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);
        }
        public override void update()
        {
            privMoveGrid();
            base.updateUnionBox();
            base.update();
        }
        public override void Accept(CollisionVisitor other)
        {
           // Debug.WriteLine("BommRoot accept");
            other.visitBombRoot(this);
        }

        private void privMoveGrid()
        {
            PCSTreeForwardIterator iterator = new PCSTreeForwardIterator(this);
            Debug.Assert(iterator != null);

            PCSNode pNode = iterator.First();

            while (!iterator.IsDone())
            {
                Bomb bomb = (Bomb)pNode;
                if(bomb.active)
                {
                    bomb.y -= this.delta;
                }
                //gameObj.y -= this.delta;
                pNode = iterator.Next();
            }
        }
        //Wall
        public override void VisitWallRoot(WallRoot w)
        {
          //  Debug.WriteLine("BombRoot WallRoot");
            CollisionPair.detectCollision((GameObject)w.pChild, this);
        }
        public override void VisitWallDown(WallDown w)
        {
         //   Debug.WriteLine("BombRoot WallDown");
            CollisionPair.detectCollision(w, (GameObject)this.pChild);
        }

        //Missle

        public override void visitMissileRoot(MissileRoot m)
        {
         //   Debug.WriteLine("BombRoot MissileRoot");
            CollisionPair.detectCollision(this, (GameObject)m.pChild);
        }
        public override void visitMissileStraight(StraightMissile m)
        {
           // Debug.WriteLine("BombRoot MissileRoot");
            CollisionPair.detectCollision(m, (GameObject)this.pChild);
        }

     
        //Ship
        public override void visitShipRoot(ShipRoot s)
        {
           // Debug.WriteLine("BombRoot ShipRoot");
            CollisionPair.detectCollision((GameObject)s.pChild, this);
        }
        public override void visitCannonShip(CannonShip s)
        {
           // Debug.WriteLine("BombRoot CannonShip");
            CollisionPair.detectCollision(s, (GameObject)this.pChild);
        }

    }
}
