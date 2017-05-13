using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipReadyState : ShipState
    {
        public override void handle(CannonShip ship)
        {
            ship.setShipState(ShipManager.ShipStateType.MissileFlying);
        }

        public override void moveLeft(CannonShip ship)
        {
           // Debug.WriteLine("ShipReadyState moveLeft");
            ship.x -= ship.delta;
        }

        public override void moveRight(CannonShip ship)
        {
          //  Debug.WriteLine("ShipReadyState moveRight");
            ship.x += ship.delta;
        }

        public override void shoot(CannonShip ship)
        {
           // Debug.WriteLine("ShipReadyState shoot");
            StraightMissile missile = ShipManager.activateMissile();

            Debug.Assert(missile != null);
           
            missile.x = ship.x;
            missile.y = ship.y;
            missile.launchMissile();

            IrrKlang.ISoundEngine sndEngine = FactoryManager.getSoundEngine();
            IrrKlang.ISound music = sndEngine.Play2D("shoot.wav");
            music.Volume = 0.2f;

            this.handle(ship);
        }
    }
}
