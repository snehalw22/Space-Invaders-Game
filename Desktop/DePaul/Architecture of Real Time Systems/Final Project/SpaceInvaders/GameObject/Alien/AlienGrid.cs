using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienGrid : Alien
    {
        public float deltaX;
        public float deltaY;
        public bool edgeHit;
    
        //private bool moveY;
        //private static screenSize;
        public AlienGrid(GameObject.GameObjectName mGameObjectName, Sprite.SpriteName mSpriteName,int index, float mX, float mY) : base(mGameObjectName, index, mSpriteName)
        {
            this.x = mX;
            this.y = mY;
            //  this.deltaX = 20.0f;
            //  this.deltaY = 40.0f;
           this.deltaX = Unit.alienDeltaX;
           this.deltaY = Unit.alienDeltaY;
            edgeHit = false;
          //  this.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);

        }
        public void reversedelta()
        {
            this.x *= -1.0f;
        }
        public void setDeltaX(float delta)
        {
            this.deltaX = delta;
        }
        public void updateDelta()
        {
            if (this.deltaX > 0)
            {
                this.deltaX = Unit.alienDeltaX;
            }
            else
            {
                this.deltaX = Unit.alienDeltaX *-1;
            }
            this.deltaY = Unit.alienDeltaY;
        }
        public void setEdgeHit()
        {
            this.edgeHit = true;
        }
        public override void update()
        {
            //this.move();
            base.updateUnionBox();
            base.update();

        }

        public void moveGrid()
        {
            PCSTreeForwardIterator pcsIterator = new PCSTreeForwardIterator(this);
            Debug.Assert(pcsIterator != null);
            PCSNode node = pcsIterator.First();
            GameObject gameObj;

            while (node != null)
            {
                gameObj = (GameObject)node;
                gameObj.x += this.deltaX;
                if (this.edgeHit)
                {
                    gameObj.y -= this.deltaY;

                }             
                node = pcsIterator.Next();
            }
            this.edgeHit = false;
        }
        public void chehckForEmpty()
        {
            Column column = (Column)this.pChild;
            int count = 0;
              while (column != null)
            {
                //Alien is still active, not marked for death
                if (!column.death)
                {
                    count++;
                    break;
                }
                column = (Column)column.pSibling;
            }

            if (count == 0)
            {
                this.markForDeath();
                // column.remove();
            }
        }

        public override void Accept(CollisionVisitor other)
        {
           // Debug.WriteLine("AlienGrid Accept");
            other.visitAlienGrid(this);
        }
        //----------------------Missile visits---------------------------------------
        public override void visitMissileRoot(MissileRoot m)
        {
           // Debug.WriteLine("AlienGrid MissileRoot");
            CollisionPair.detectCollision(m, (GameObject)this.pChild);
        }

        public override void visitMissileStraight(StraightMissile m)
        {
          //  Debug.WriteLine("AlienGrid StraightMissile");
            CollisionPair.detectCollision(m, (GameObject)this.pChild);
        }
        //----------------------Wall visits---------------------------------------
        public override void VisitWallRoot(WallRoot w)
        {
            //  Debug.WriteLine("AlienGrid WallRoot");
            // CollisionPair.detectCollision(w, (GameObject)this.pChild);//chnaged this to fix grid
            CollisionPair.detectCollision(this, (GameObject)w.pChild);
        }
   
    }
}
