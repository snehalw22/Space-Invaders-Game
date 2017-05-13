using System;
using System.Diagnostics;
namespace SpaceInvaders
{

    class RightKeyObserver : InputObserver
    {
        public override void notify()
        {
            CannonShip ship = ShipManager.getShip();
            Debug.Assert(ship != null);

            ship.moveRight();
        }

        protected override void nodeStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
