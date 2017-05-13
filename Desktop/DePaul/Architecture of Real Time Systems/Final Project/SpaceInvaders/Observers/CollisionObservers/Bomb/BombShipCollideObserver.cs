using System;
using System.Diagnostics;

namespace SpaceInvaders
{ 
    class BombShipCollideObserver : CollisionObserver
    {
        public override void notify()
        {
            Debug.WriteLine("BombShipCollideObserver");
            Bomb bomb =(Bomb) this.colSubject.gameObjA;
            CannonShip ship =(CannonShip) this.colSubject.gameObjB;

            Debug.Assert(bomb != null);
            Debug.Assert(ship != null);

        //    bomb.reset();



            ship.setShipState(ShipManager.ShipStateType.End);

            ship.explode(Sprite.SpriteName.ShipExplosion);

            // ActivateBombSprite abs = new ActivateBombSprite(bomb);
            //  TimerManager.sortedAdd(TimerEvent.TimerEventName.ActivateBomb, abs, 0);
            ship.removeFromGameManager();
            ShipRemove objRemove = new ShipRemove(ship);
            TimerManager.sortedAdd(TimerEvent.TimerEventName.ShipRemove, objRemove, Unit.shipDeathAnimationTime);
            //reduce ship count
            PlayerManager.reduceShipCount();

            ActivateShip actiavteShip = new ActivateShip();
            TimerManager.sortedAdd(TimerEvent.TimerEventName.ShipRemove, actiavteShip, Unit.shipDeathAnimationTime+0.1f);
        }
    }
}
