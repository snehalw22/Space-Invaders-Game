using System;
using System.Diagnostics;

namespace SpaceInvaders
{
   public class InputManager
    {
        private InputSubject leftKeyPress;
        private InputSubject rightKeyPress;
        private InputSubject spaceKeyPress;
        private InputSubject zeroKeyPress;
        private InputSubject nineKeyPress;
        private InputSubject enterKeyPress;
        private static InputManager inputInstance =null;

        private bool spacePressed;
        public static void createMInstance()
        {
            if (inputInstance == null)
            {
                inputInstance = new InputManager();
            }
            Debug.Assert(inputInstance != null);
        }
        public static InputManager getSingleton()
        {
            if (inputInstance == null)
            {
                inputInstance = new InputManager();
            }

            Debug.Assert(inputInstance != null);
            return inputInstance;
        }

        public InputManager()
        {
            leftKeyPress = new InputSubject();
            rightKeyPress = new InputSubject();
            spaceKeyPress = new InputSubject();
            zeroKeyPress = new InputSubject();
            nineKeyPress = new InputSubject();
            enterKeyPress = new InputSubject();
            // attachObservers();

            leftKeyPress.attachObserver(new LeftKeyObserver());
            rightKeyPress.attachObserver(new RightKeyObserver());
            spaceKeyPress.attachObserver(new SpaceKeyObserver());
            zeroKeyPress.attachObserver(new ZeroKeyPressObserver());
            nineKeyPress.attachObserver(new NinePressObserver());
            enterKeyPress.attachObserver(new EnterKeyObserver());
            inputInstance = this;
            spacePressed = false;
        }

        public static void update()
        {
            InputManager inpMan = InputManager.getSingleton();
            Debug.Assert(inpMan != null);

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT) == true)
            {
                inpMan.leftKeyPress.observer.notify();
             
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT) == true)
            {
                inpMan.rightKeyPress.observer.notify();
            }
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE) == true && inpMan.spacePressed == false)
            {
                inpMan.spaceKeyPress.observer.notify();
                inpMan.spacePressed = true;
            }
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_0) == true && inpMan.spacePressed == false)
            {
                inpMan.zeroKeyPress.observer.notify();
            }
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_9) == true && inpMan.spacePressed == false)
            {
                inpMan.nineKeyPress.observer.notify();
            }
            //if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_2) == true && inpMan.spacePressed == false)
            //{
            //    inpMan.enterKeyPress.observer.notify();
            //}
            inpMan.spacePressed = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE);
          
        }

    }
}
