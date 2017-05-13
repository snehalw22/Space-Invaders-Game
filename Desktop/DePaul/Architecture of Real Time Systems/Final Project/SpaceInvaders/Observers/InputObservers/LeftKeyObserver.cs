using System;
using System.Diagnostics;

namespace SpaceInvaders
{

    class LeftKeyObserver: InputObserver
    {
        public override void notify()
        {

            CannonShip ship = ShipManager.getShip();
            Debug.Assert(ship != null);

            ship.moveLeft();
        }

        protected override void nodeStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
