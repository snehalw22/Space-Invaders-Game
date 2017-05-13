using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UFOSoundPlay : Command
    {
        UFO ufo;

        public UFOSoundPlay(UFO mUfo)
        {
            this.ufo = mUfo;
        }

        public override void execute(float deltaTime)
        {
            IrrKlang.ISoundEngine soundEngine = FactoryManager.getSoundEngine();        
            if(ufo.launch)
            {
                IrrKlang.ISound music = soundEngine.Play2D("ufo_lowpitch.wav");
                music.Volume = 0.2f;
                TimerManager.sortedAdd(TimerEvent.TimerEventName.UFOPlaySound, this, 2.2f);
            }
        }
    }
}
