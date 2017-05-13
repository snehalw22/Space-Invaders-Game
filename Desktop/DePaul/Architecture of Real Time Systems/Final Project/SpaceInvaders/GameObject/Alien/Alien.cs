using System;
using System.Diagnostics;

namespace SpaceInvaders
{
   abstract class Alien : GameObject

    {
        public enum AlienType
        {
            Crab,
            Octopus,
            Squid,
            UFO,
            Column,
            AlienGrid,
            AlienExplosion,
            Uninitilized
        }
        public Alien(GameObject.GameObjectName mGameObjectName, int index,Sprite.SpriteName mSpriteName) : base(mGameObjectName, index,  mSpriteName)
        {
        }
        protected Alien.AlienType type;

        public void set(Sprite.SpriteName mSpriteName, int index, float posX, float posY)
        {
            this.swapImage(mSpriteName);
            this.index = index;
            this.x = posX;
            this.y = posY;
            this.death = false;

        }//public void explode()
        //{
        //    this.explode(SpriteBatch.SpriteBatchName.Aliens, Sprite.SpriteName.AlienExplosion);
        //}

    }
}
