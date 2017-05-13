using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    class ShipReadyObserver : CollisionObserver
    {
        // change the state of ship to ready now that its hit
        public override void notify()
        {
            CannonShip cannonShip = ShipManager.getShip();
            cannonShip.setShipState(ShipManager.ShipStateType.Ready);
        }
    }
}
