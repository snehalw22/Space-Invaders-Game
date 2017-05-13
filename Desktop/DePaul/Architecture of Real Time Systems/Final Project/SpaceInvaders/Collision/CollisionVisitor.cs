using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract  class CollisionVisitor : PCSNode
    {
        public virtual void visitAlienGrid(AlienGrid a)
        {
        }

        public virtual void visitColumn(Column a)
        {
        }

        public virtual void visitCrab(Crab a)
        {
        }

        public virtual void visitSquid(Squid a)
        {
        }

        public virtual void visitOctopus(Octopus a)
        {
        }
        //UFO
        public virtual void visitAlienUFO(AlienUFO u)
        {
        }
        public virtual void visitUFORoot(UFORoot u)
        {
        }
        
        //Shields
        public virtual void visitShieldGrid(ShieldGrid s)
        {
        }
        public virtual void visitShieldUnit(ShieldUnit s)
        {
        }    
        public virtual void visitShieldColumn(ShieldColumn s)
        {
        }
        public virtual void visitShieldBrick(ShieldBrick s)
        {         
        }
        
        //Cannon
        public virtual void visitShipRoot(ShipRoot s)
        {
        }
        public virtual void visitCannonShip(CannonShip s)
        {
        }
      
        //Bomb
        public virtual void visitBombRoot(BombRoot b)
        {
        }
        public virtual void visitFlippingBomb(FlippingBomb b)
        {
        }
        public virtual void visitPlungerBomb(PlungerBomb b)
        {
        }
        public virtual void visitZigZagBomb(ZigZagBomb b)
        {
        }
        //Missile
        public virtual void visitMissileRoot(MissileRoot m)
        {
        }
        public virtual void visitMissileStraight(StraightMissile m)
        {          
        }
        
        // Wall

        public virtual void VisitWallRoot(WallRoot w)
        {
        }     
        public virtual void VisitWallRight(WallRight w)
        {          
        }
        public virtual void VisitWallLeft(WallLeft w)
        {
        }
        public virtual void VisitWallTop(WallTop w)
        {
        }
        public virtual void VisitWallDown(WallDown w)
        {
        }

        public virtual void visitNullGameObject(NullGameObject n)
        {
        }

        abstract public void Accept(CollisionVisitor other);
    }
}
