using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    class SpaceKeyObserver : InputObserver
    {
        public override void notify()
        {
            CannonShip ship = ShipManager.getShip();
            Debug.Assert(ship != null);

            ship.shoot();
        }

        protected override void nodeStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
