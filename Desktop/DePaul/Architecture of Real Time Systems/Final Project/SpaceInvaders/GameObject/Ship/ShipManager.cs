using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipManager
    {
        private ShipReadyState shipReadyState;
        private ShipMissileFlyingState shipMissileFlyingState;
        private ShipEndState shipEndState;

        private static ShipManager shipMInstance = null;
   
        private CannonShip cannonShip;
        private StraightMissile missile;

        public enum ShipStateType
        {
            Ready,
            MissileFlying,
            End,
            Uninitilized
        }

        private ShipManager()
        {
            this.shipReadyState = new ShipReadyState();
            this.shipMissileFlyingState = new ShipMissileFlyingState();
            this.shipEndState = new ShipEndState();
            this.cannonShip = null;
            this.missile = null;
        }
        public static void createMInstance()
        {              
            if (shipMInstance == null)
            {
                shipMInstance = new ShipManager();
            }
            Debug.Assert(shipMInstance != null);
        }
        public static ShipManager getSingleton()
        {
      
            Debug.Assert(shipMInstance != null);
            return shipMInstance;
        }

        public static CannonShip getShip()
        {
            ShipManager sm = ShipManager.getSingleton();
            Debug.WriteLine(sm != null);

            return sm.cannonShip;
        }
        public static void setShip(CannonShip ship)
        {
            ShipManager shipMan = ShipManager.getSingleton();
            Debug.Assert(shipMan != null);

            Debug.WriteLine(ship != null);
            shipMan.cannonShip = ship;
        }
        public static ShipState getShipState(ShipStateType shipStateType)
        {
            ShipManager shipMan = ShipManager.getSingleton();
            Debug.Assert(shipMan != null);

            ShipState shipSate = null;

            switch (shipStateType)
            {
                case ShipStateType.Ready:
                    shipSate = shipMan.shipReadyState;
                    break;

                case ShipStateType.MissileFlying:
                    shipSate = shipMan.shipMissileFlyingState;
                    break;

                case ShipStateType.End:
                    shipSate = shipMan.shipEndState;
                    break;
                case ShipStateType.Uninitilized:
                    Debug.WriteLine("Uninitialiazed");
                    break;
                default:
                    Debug.WriteLine("Someth");
                    break;
            }
            return shipSate;
        }

        public static StraightMissile activateMissile()
        {
            ShipManager shipMan = ShipManager.getSingleton();
            Debug.Assert(shipMan != null);

            GameObjectNode gon = GameObjectNodeManager.findGameObjectNode(GameObject.GameObjectName.MissileRoot);
            PCSTree pcsTree = gon.getPCSTree();
            GameObject gameObj = gon.getGameObject();
            Debug.Assert(pcsTree != null);
            Debug.Assert(gameObj != null);

            // StraightMissile missile = new StraightMissile(GameObject.GameObjectName.StraightMissile, Sprite.SpriteName.Straight, 1, 400, 100f,Missile.MissileType.Straight);

            ///to do
             StraightMissile missile =(StraightMissile) FactoryManager.getMissileFactry().createMissile(Missile.MissileType.StraightMissile, GameObject.GameObjectName.StraightMissile, 1, 300, 200);
            //StraightMissile missile = (StraightMissile)GhostManager.find(GameObject.GameObjectName.StraightMissile);
            //if(missile==null)
            //{
            //   missile = (StraightMissile)FactoryManager.getMissileFactry().createMissile(Missile.MissileType.StraightMissile, GameObject.GameObjectName.StraightMissile, 1, 300, 200);
            //}
           //StraightMissile missile = (StraightMissile)GhostManager.find(GameObject.GameObjectName.StraightMissile);

            shipMan.missile = missile;

          //  SpriteBatch missileBatch = SpriteBatchManager.find(SpriteBatch.SpriteBatchName.Missiles);
          //  SpriteBatch boxBatch = SpriteBatchManager.find(SpriteBatch.SpriteBatchName.Boxes);

          //  Debug.Assert(missileBatch != null);
          //  Debug.Assert(boxBatch != null);

           // missile.addSpriteToBatch(missileBatch);
          //  missile.addCollisionToBatch(boxBatch);
            GameObject pMissileRoot = GameObjectNodeManager.find(GameObject.GameObjectName.MissileRoot);
            Debug.Assert(pMissileRoot != null);
            ///////////////////////////Not sure
           // pcsTree.Insert(missile, pMissileRoot);
            // pcsTree.GetRoot.
            pMissileRoot.update();

            return missile;
        }

    }
}
