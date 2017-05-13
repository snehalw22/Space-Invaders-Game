using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlayerManager
    {
        private static PlayerManager playerMInstance = null;
        private static Player currentPlayer = null;
        public static SLink playerList=null;
        private PlayerManager()          
        {
           
        }

        public static void createMInstance()
        {       
            if (playerMInstance == null)
            {
                playerMInstance = new PlayerManager();
            }

            Debug.Assert(playerMInstance != null);
        }
        public static PlayerManager getSingleton()
        {
            if (playerMInstance == null)
            {
                playerMInstance = new PlayerManager();
            }

            Debug.Assert(playerMInstance != null);
            return playerMInstance;
        }


        public static Player add(Player.PlayerType playerName)
        {
            Player player = new Player(playerName,0,3);
            SLink.addToFront(ref playerList,player);
            return player;
        }

        public static void setCurrentPlayer(Player player)
        {
            Debug.WriteLine(player != null);
            currentPlayer = player;
        }
        public static Player getCurrentPlayer()
        {
            return currentPlayer;
        }

        public static void update()
        {
            GameObject alienGrid = (GameObject)FactoryManager.getAlienFactry().cPCSTree.getRoot();
            if (alienGrid.pChild==null && currentPlayer.death==false)
            {
                currentPlayer.level = new Level2();
                currentPlayer.level.load();
            }
            if(currentPlayer.death==true)
            {
            //    FontManager.add(Font.FontName.GameOver, SpriteBatch.SpriteBatchName.Text, "Game Over", Glyph.Name.Consolas36pt, 400, 500, Unit.redColor);
            }
            if (currentPlayer.playerType == Player.PlayerType.Player1)
            {
                Font text = FontManager.find(Font.FontName.ScoreNum1);
                Debug.Assert(text != null);
                text.updateText("<" + currentPlayer.score + ">");
            }
            else
            {
                Font text = FontManager.find(Font.FontName.ScoreNum2);
                Debug.Assert(text != null);
                text.updateText("<" + currentPlayer.score + ">");
            }
        }
       
        public static int getShipCount()
        {
            int shipCount = currentPlayer.ships;
            return shipCount;
        }
        public static void reduceShipCount()
        {
            currentPlayer.ships--;
        }

        public static void activatePlayer(Player player)
        {
            currentPlayer = player;
        }
        public static void inactivatePlayer()
        {
            currentPlayer.death = true;
        }
    }
}
