using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UFODeathAnimation : Command
    {
        public UFO ufo;

        public UFODeathAnimation()
        {
        }
        public UFODeathAnimation(UFO mUfo)
        {
            this.ufo = mUfo;
        }
        public override void execute(float deltaTime)
        {
         if(ufo.type==UFO.UFOType.AlienUFO)
            {
                AlienUFO af = (AlienUFO)ufo;
                af.swapImage(Sprite.SpriteName.AlienUFO);
                af.reset();
            }
        }
    }
}