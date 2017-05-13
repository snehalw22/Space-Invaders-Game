using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Unit
    {
        public static float alienPosX;
        public static float alienPosY;
        public static float alienDeltaX;
        public static float alienDeltaY;
        public static float AlienGridMoveEventTime;
        public static float AlienImageSwapEventTime;
        public static float AlienSoundSwapEventTime;
        public static float alienDeathAnimationTime;
        public static int crabPoints;
        public static int squidPoints;
        public static int octopusPoints;
        public static int ufoPoints;

        public static float ufoPosX;
        public static int ufoPosY;
        public static float ufoDeltaX;
        public static int ufoScore;
        public static float ufoDeathAnimationTime;
        public static int UFOLaunchMin;
        public static int UFOLaunchMax;

        public static float shipPosX;
        public static float shipPosY;
        public static float shipDeltaX;
        public static float shipDeathAnimationTime;

        public static float bombImageSwapTime;
        public static float bombDeltaY;

        public static float gameFreezeTime;



        public static Azul.Color redColor;
        public static Azul.Color greenColor;
        public static Azul.Color blueColor;
        public static Azul.Color blackColor;
        public static Azul.Color whiteColor;
        public static Azul.Color spriteBoxColor;
        public static Azul.Color purpleColor;
        public static Azul.Color tealColor;
        public static Azul.Color yellowColor;
        public Unit()
        {
            alienPosX = 0;
            alienPosY = 0;
            alienDeltaX = 0;
            alienDeltaY = 0;
            AlienGridMoveEventTime = 0;
            AlienImageSwapEventTime = 0;
            AlienSoundSwapEventTime = 0;
            alienDeathAnimationTime = 0.1f;
            crabPoints = 30;
            squidPoints = 20;
            octopusPoints = 10;
            ufoPoints = 100;

            ufoPosX = -50;
            ufoPosY = 900;
            ufoDeltaX = 1;
            ufoScore = 100;
            ufoDeathAnimationTime = 0.3f;
            UFOLaunchMin = 30;
            UFOLaunchMax = 40;


            shipPosX = 448;
            shipPosY = 70;
            shipDeltaX = 6;
            shipDeathAnimationTime = 0;

            bombDeltaY = 0;
            bombImageSwapTime = 0.5f;

            gameFreezeTime = 3f;

            redColor = new Azul.Color(1, 0, 0);
            greenColor = new Azul.Color(0, 1, 0);
            blueColor = new Azul.Color(0, 0, 1);
            blackColor = new Azul.Color(0, 0, 0);
            whiteColor = new Azul.Color(1, 1, 1);

            purpleColor = new Azul.Color(128, 0, 128);
            tealColor = new Azul.Color(0, 0, 139);
            yellowColor = new Azul.Color(255, 255, 0);

            spriteBoxColor = redColor;
        }

        public static void level1()
        {
            alienPosX = 50;
            alienPosY = 850;
            alienDeltaX = 20;
            alienDeltaY = 20;
            AlienGridMoveEventTime = 0.4f;
            AlienImageSwapEventTime = 0.4f;
            AlienSoundSwapEventTime = 0.4f;

            bombDeltaY = 3f;
        }

        public static void level1Mid()
        {
            alienDeltaX = 30;
            alienDeltaY = 40;
            AlienGridMoveEventTime = 0.3f;
            AlienImageSwapEventTime = 0.3f;
            AlienSoundSwapEventTime = 0.3f;
            //     bombDeltaY = 4f;      
        }

        public static void level1Last()
        {
            alienDeltaX = 40;
            alienDeltaY = 50;
            AlienGridMoveEventTime = 0.2f;
            AlienImageSwapEventTime = 0.2f;
            AlienSoundSwapEventTime = 0.2f;
            //   bombDeltaY = 5f;
        }

        public static void level2Start()
        {
            alienPosX = 100;
            alienPosY = 700;
            alienDeltaX = 20;
            alienDeltaY = 30;

            AlienGridMoveEventTime = 0.3f;
            AlienImageSwapEventTime = 0.3f;
            AlienSoundSwapEventTime = 0.3f;
        }

        public static void level2Mid()
        {
            alienDeltaX = 20;
            alienDeltaY = 30;
            AlienGridMoveEventTime = 0.2f;
            AlienImageSwapEventTime = 0.2f;
            AlienSoundSwapEventTime = 0.2f;
        }

        public static void level2Last()
        {
            alienDeltaX = 40;
            alienDeltaY = 50;
            AlienGridMoveEventTime = 0.1f;
            AlienImageSwapEventTime = 0.1f;
            AlienSoundSwapEventTime = 0.1f;
        }
    }
}
