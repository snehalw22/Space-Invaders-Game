using System;
using System.Diagnostics;

namespace SpaceInvaders
{

    class Game : Azul.Game
    {
        int count = 0;
       public static bool freeze = false;
        public static float trigUp=0.0f;
        public static float currTime = 0.0f;
        public override void Initialize()
        {
            this.SetWindowName("Space Invaders");
            this.SetWidthHeight(896, 1024);
            this.SetClearColor(0,0,0, 1.0f);
        }
        public static void freezeGame()
        {
            Game.freeze = true;
            Game.trigUp = Game.currTime + Unit.gameFreezeTime;
        }
        public override void LoadContent()
        {
            new Unit();
            GameManager.createMInstance();
            GameManager.load();

        }
        public override void Update()
        {
           count++;
           currTime = this.GetTime();
            if (!freeze)
            {
                GameManager.update(this.GetTime());
            }else
            {
                if(this.GetTime()>=trigUp)
                {
                    freeze = false;
                }
            }
        }
        public override void Draw()
        {
                GameManager.draw();         
        }
        public override void UnLoadContent()
        {
        }       
    }
}
