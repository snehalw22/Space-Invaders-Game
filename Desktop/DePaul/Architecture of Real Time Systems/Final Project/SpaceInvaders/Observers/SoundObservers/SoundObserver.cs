using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SoundObserver :CollisionObserver
    {
        IrrKlang.ISoundEngine soundEngine;
        public String soundName;
        public SoundObserver(IrrKlang.ISoundEngine eng, String mSoundName)
        {
            Debug.Assert(eng != null);
            this.soundEngine = eng;
            this.soundName = mSoundName;
        }
        public override void notify()
        {
            IrrKlang.ISound music = soundEngine.Play2D(soundName);
            music.Volume = 0.2f;

        }
    }
}

