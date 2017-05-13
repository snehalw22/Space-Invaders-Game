using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameEndState : GameState
    {
        public override void load()
        {
            EndStateLoader loader = new EndStateLoader();
            loader.load();
        }
        public override void update(float totalTime)
        {
          
            for (int i = 0; i < 400; i++)
            {
                if (Azul.Input.GetKeyState((Azul.AZUL_KEY)i))
                {

                   if(i==294)
                    {
                        SpriteBatchManager.cleanup();
                        TimerManager.removeAll();
                        GameObjectNodeManager.cleanup();
                        GameManager.setGameState(new GameStartState());
                        GameManager.load();
                    }
                   break;
                }
            }
            //Console.WriteLine(d);
        }
        public override void draw()
        {
            // throw new NotImplementedException();
            Font font=(Font) FontManager.find(Font.FontName.GameOver);
            font.cFontSprite.update();
            font.cFontSprite.render();
            Font font1 = (Font)FontManager.find(Font.FontName.Instruction1);
            font1.cFontSprite.update();
            font1.cFontSprite.render();

        }
    }
}
