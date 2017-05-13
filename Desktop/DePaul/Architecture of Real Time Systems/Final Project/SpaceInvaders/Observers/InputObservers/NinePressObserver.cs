using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class NinePressObserver : InputObserver
    {
        public override void notify()
        {
            Unit.spriteBoxColor = Unit.blackColor;
            GameObjectNodeManager.changeColor();
        }

        protected override void nodeStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
