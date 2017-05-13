using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipMissileFlyingState : ShipState
    {
        public override void handle(CannonShip ship)
        {
          //  Debug.WriteLine("ShipState handle");

        }

        public override void moveLeft(CannonShip ship)
        {
           // Debug.WriteLine("ShipState moveLeft");
            ship.x -= ship.delta;
        }

        public override void moveRight(CannonShip ship)
        {
          //  Debug.WriteLine("ShipState moveRight");
            ship.x += ship.delta;
        }

        public override void shoot(CannonShip ship)
        {
            //Debug.WriteLine("ShipState shoot");
        }
    }
}
