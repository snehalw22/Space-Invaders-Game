using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class Wall : GameObject
    {
        public Wall.WallType type;
        public enum WallType
        {
            WallRoot,
            WallRight,
            WallTop,
            WallLeft,
            WallDown,
            Uninitilized,
        }
        public Wall(GameObjectName mGameObjectName, int index, Sprite.SpriteName mSpriteName, Wall.WallType walltype) : base(mGameObjectName, index, mSpriteName)
        {
            type = walltype;
        }
    }
}
