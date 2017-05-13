using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class EnterKeyObserver : InputObserver
    {
        public override void notify()
        {
            GameManager.setGameState(new GameActiveState());
            GameManager.load();
        }

        protected override void nodeStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
