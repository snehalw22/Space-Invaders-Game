using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ActivatePlayer : Command
    {
        public override void execute(float deltaTime)
        {
            if (PlayerManager.getCurrentPlayer().playerType == Player.PlayerType.Player1)
            {
                Player player2 = (Player)PlayerManager.getCurrentPlayer().pSNext;
                PlayerManager.setCurrentPlayer(player2);
            }

            PlayerManager.getCurrentPlayer().level = new Level2();
            PlayerManager.getCurrentPlayer().level.load();
        }
       }
    }

