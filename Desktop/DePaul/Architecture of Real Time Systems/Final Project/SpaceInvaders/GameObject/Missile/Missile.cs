using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class Missile : GameObject
    {
        public Missile.MissileType type;

        public enum MissileType
        {
            StraightMissile,
            MissileRoot,
            MissileExplosion,
            Uninitilized,
        }

        public Missile(GameObject.GameObjectName mGameObjectName, int index, Sprite.SpriteName mSpriteName, Missile.MissileType missileType) : base(mGameObjectName, index, mSpriteName)
        {
            this.type = missileType;
        }

    }
}
