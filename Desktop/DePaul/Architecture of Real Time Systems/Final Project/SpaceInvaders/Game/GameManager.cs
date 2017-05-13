using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameManager
    {
        public GameState cGameState;
        private static GameManager gameMInstance = null;
        public GameMode gameMode;

        public enum GameMode
        {
            Player1Mode,
            Player2Mode,
            Uninitialized
        }
        public static void createMInstance()
        {

            Debug.WriteLine("Creating Game Manager instance");   
            if (gameMInstance == null)
            {
                gameMInstance = new GameManager();
            }
            Debug.Assert(gameMInstance != null);     
        }
        private static GameManager getSingletonInstance()
        {
            Debug.Assert(gameMInstance != null);
            return gameMInstance;
        }

        public GameManager()
        {
            this.cGameState = new GameStartState();
            this.gameMode = GameMode.Uninitialized;
        }
        public GameManager(GameState mGameState)
        {
            this.cGameState = mGameState;
        }

        public static void setGameState(GameState mGameState)
        {
            GameManager gameManInst = GameManager.getSingletonInstance();
            Debug.Assert(gameManInst != null);
            gameManInst.cGameState = mGameState;
        }
       
        public static void load()
        {
            GameManager gameManInst = GameManager.getSingletonInstance();
            Debug.Assert(gameManInst != null);
            gameManInst.cGameState.load();
        }
        public static void update(float totalTime)
        {
            GameManager gameManInst = GameManager.getSingletonInstance();
            Debug.Assert(gameManInst != null);
            gameManInst.cGameState.update(totalTime);
        }
        public static void draw()
        {
            GameManager gameManInst = GameManager.getSingletonInstance();
            Debug.Assert(gameManInst != null);
            gameManInst.cGameState.draw();
        }

        public static void setGameMode(GameManager.GameMode gameMode)
        {
            if(gameMode==GameMode.Player1Mode)
            {
                Player player = PlayerManager.add(Player.PlayerType.Player1);
                PlayerManager.setCurrentPlayer(player);
            }
            else
            {
                Player player2 = PlayerManager.add(Player.PlayerType.Player2);
               
                Player player1 = PlayerManager.add(Player.PlayerType.Player1);
                PlayerManager.setCurrentPlayer(player1);
            }
        }
    }
}
