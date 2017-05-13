using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class Ship : GameObject
    {
        protected Ship.ShipType type;
        public enum ShipType
        {
            CannonShip,
            ShipRoot,
            Uninitilized,
        }

        public Ship(GameObject.GameObjectName mGameObjectName, int index, Sprite.SpriteName mSpriteName) : base(mGameObjectName, index, mSpriteName)
        {
        }
    }
}
