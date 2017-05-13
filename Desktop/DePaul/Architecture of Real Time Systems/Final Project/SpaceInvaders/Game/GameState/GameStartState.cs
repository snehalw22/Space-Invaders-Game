using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameStartState : GameState
    {     
        public override void load()
        {
            StartStateLoader loader = new StartStateLoader();
            loader.load();
        }
        public override void update(float totalTime)
        {
        
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_1) == true)
            {
                GameManager.setGameState(new GameActiveState());
                GameManager.setGameMode(GameManager.GameMode.Player1Mode);
                GameManager.load();
            }else
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_2) == true)
            {
                GameManager.setGameState(new GameActiveState());
                GameManager.setGameMode(GameManager.GameMode.Player2Mode);
                GameManager.load();
            }
        }
        public void clearScreen()
        {
           
        }
        public override void draw()
        {
            SpriteBatchManager.draw();

            Sprite crab = SpriteManager.find(Sprite.SpriteName.Crab);
            crab.x = 300;
            crab.y = 700;
            crab.update();
            crab.render();

            Sprite squid = SpriteManager.find(Sprite.SpriteName.Squid);
            squid.x = 300;
            squid.y = 640;
            squid.update();
            squid.render();

            Sprite octopus = SpriteManager.find(Sprite.SpriteName.Octopus);
            octopus.x = 300;
            octopus.y = 560;
            octopus.update();
            octopus.render();

            Sprite ufo = SpriteManager.find(Sprite.SpriteName.AlienUFO);
            ufo.x = 300;
            ufo.y = 500;
            ufo.update();
            ufo.render();

        }

    }
}
