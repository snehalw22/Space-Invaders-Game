using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Player : SLink
    {
        public int score;
        public int ships;
        public PlayerType playerType;
        public Level level;
        public bool death;
        public enum PlayerType
        {
            Player1,
            Player2,
            Uninitialized
        }

        public Player()
        {      
            this.score = 0;
            this.ships = 3;
            this.level = new Level1();
            death = false;
        }

        public Player(PlayerType playerType,int score,int ships)
        {
            this.playerType = playerType;
            this.score = score;
            this.ships = ships;
        }

        public void setPlayerName(Player.PlayerType mPlayerTypr)
        {
            this.playerType = mPlayerTypr;
        }

        public void addScore(int mScore)
        {
            this.score += mScore;
        }
        public void PlayerActivation()
        {
          
        }
    }
}
