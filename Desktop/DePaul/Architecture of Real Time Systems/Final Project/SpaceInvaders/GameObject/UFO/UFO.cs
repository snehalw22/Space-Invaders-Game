using System;
using System.Diagnostics;

namespace SpaceInvaders
{
   abstract class UFO : GameObject
    {
        public bool launch;
        public UFOType type;
        public enum UFOType
        {
            UFORoot,
            AlienUFO,
            Uninitilized
        }
        public UFO(GameObject.GameObjectName mGameObjectName, int index, Sprite.SpriteName mSpriteName, UFO.UFOType ufoType) : base(mGameObjectName, index,  mSpriteName)
        {
            this.type = ufoType;
            this.launch = false;
        }
        public void reset()
        {       
            this.x = Unit.ufoPosX;
            this.y = Unit.ufoPosY;
            launch = false;
        }
    }
}
