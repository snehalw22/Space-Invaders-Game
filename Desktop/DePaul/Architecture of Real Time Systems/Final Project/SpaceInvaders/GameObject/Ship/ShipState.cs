using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class ShipState
    {
        public abstract void handle(CannonShip ship);
        public abstract void moveRight(CannonShip ship);
        public abstract void moveLeft(CannonShip ship);
        public abstract void shoot(CannonShip ship);
    }
}
