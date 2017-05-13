using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class Shield : GameObject
    {
        public enum ShieldType
        {
            ShieldBrick,
            ShieldGrid,
            Uninitilized,
            ShieldColumn,
            ShieldUnit
        }

        public Shield(GameObject.GameObjectName mGameObjectName, int index,Sprite.SpriteName mSpriteName) : base(mGameObjectName, index, mSpriteName)
        {
        }
    }
}
