using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UFOActivate : Command
    {
        UFO ufo;
        
        public UFOActivate(UFO ufo)
        {
            this.ufo = ufo;
        }
        public override void execute(float deltaTime)
        {

            ufo.launch = true;
            UFOSoundPlay ufoSound = new UFOSoundPlay(ufo);
            TimerManager.sortedAdd(TimerEvent.TimerEventName.ActivateUFO, ufoSound, 0);
        }
    }
}
