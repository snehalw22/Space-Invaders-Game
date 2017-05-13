using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienGridAnimation : Command
    {
        AlienGrid grid;
        IrrKlang.ISoundEngine soundEngine;
        public static int count;
        public AlienGridAnimation(AlienGrid grid, IrrKlang.ISoundEngine eng)
        {
            this.grid = grid;
            Debug.Assert(eng != null);
            this.soundEngine = eng;
            count = 0;
        }

        public override void execute(float deltaTime)
        {
            IrrKlang.ISound music = null;
            //MoveGrid
            grid.moveGrid();
            //Play Sound
            if (count == 0)
            {
                 music = soundEngine.Play2D("fastinvader4.wav");         
                count++;
            }
            else if(count==1)
            {
                music = soundEngine.Play2D("fastinvader3.wav");
                count++;
            }
            else if (count == 2)
            {
               music = soundEngine.Play2D("fastinvader2.wav");              
                count++;
            }
            else if (count == 3)
            {
              music = soundEngine.Play2D("fastinvader1.wav");             
              count = 0;
            }
            music.Volume = 0.2f;
            TimerManager.sortedAdd(TimerEvent.TimerEventName.SpriteAnimation, this, Unit.AlienGridMoveEventTime);
        }

    
    }
}
