using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameActiveState : GameState
    {
      //  int count = 0;
        public override void load()
        {
            ActiveStateLoader loader = new ActiveStateLoader();
            loader.load();    
        }

        public override void update(float totalTime)
        {
            //  count++;
            InputManager.update();
            TimerManager.update(totalTime);
            GameObjectNodeManager.update();
            CollisionPairManager.process();
            PlayerManager.update();
        }
        public override void draw()
        {
            SpriteBatchManager.draw();
        }
    }
}
