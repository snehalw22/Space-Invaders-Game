using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipEndState : ShipState
    {
        public override void handle(CannonShip ship)
        {
            Debug.WriteLine("ShipEndState handle");
        }

        public override void moveLeft(CannonShip ship)
        {
         //   Debug.WriteLine("ShipEndState moveLeft");
         //   ship.x -= ship.delta;
        }

        public override void moveRight(CannonShip ship)
        {
        //    Debug.WriteLine("ShipEndState moveRight");
           // ship.x += ship.delta;
        }

        public override void shoot(CannonShip ship)
        {
          //  Debug.WriteLine("ShipEndState shoot");
        }
    }
}
