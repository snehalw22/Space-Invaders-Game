using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class Bomb : GameObject
    {
        public Bomb.BombType type;
        public bool active;
        public enum BombType
        {
            Flipping,
            ZigZag,
            Plunger,
            Uninitilized,
            BombRoot
        }
        public Bomb(GameObject.GameObjectName mGameObjectName, int index, Sprite.SpriteName mSpriteName, BombType bombType) : base(mGameObjectName, index, mSpriteName)
        {
            this.type = bombType;
        }

        protected void move(float delta)
        {
            this.y -= delta;
        }

    }
}

