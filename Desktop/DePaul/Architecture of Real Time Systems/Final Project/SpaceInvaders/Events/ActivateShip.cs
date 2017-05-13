using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ActivateShip : Command
    {
        public override void execute(float deltaTime)
        {
            int shipCount = PlayerManager.getShipCount();
            if(shipCount >0)
            {
                ShipFactory shipFac = FactoryManager.getShipFactry();
                CannonShip ship =(CannonShip) shipFac.cPCSTree.GetRoot().pChild;
                //CannonShip ship = (CannonShip)GameObjectNodeManager.find(GameObject.GameObjectName.CannonShip);
                ship.x = Unit.shipPosX;
                ship.y = Unit.shipPosY;

                ShipManager.setShip(ship);
                ShipManager.getShip().setShipState(ShipManager.ShipStateType.Ready);
            }
        }
    }
}
