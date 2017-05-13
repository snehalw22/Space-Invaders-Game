using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ZeroKeyPressObserver : InputObserver
    {
        public override void notify()
        {
            Unit.spriteBoxColor = Unit.redColor;
            GameObjectNodeManager.changeColor();
        }

        protected override void nodeStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
