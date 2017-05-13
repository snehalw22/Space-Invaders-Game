using System;
using System.Diagnostics;

namespace SpaceInvaders
{ 
    class ShipFactory
    {
    public PCSTree cPCSTree;
    SpriteBatch cSpriteBatch;
    private PCSNode cParent;

    public ShipFactory(PCSTree mPCSTree, SpriteBatch mSpriteBatch)
    {
        this.cPCSTree = mPCSTree;
            //this.cSpriteBatch = SpriteBatchManager.find(mSpriteBatch);
           this.cSpriteBatch = mSpriteBatch;
    }
    public void setParent(PCSNode parentNode)
    {
        this.cParent = parentNode;
        Debug.Assert(this.cParent != null);
    }
    public Ship createShip(Ship.ShipType mShipType, GameObject.GameObjectName gameName, int index = 0, float mX = 0.0f, float mY = 0.0f)
    {
            Ship ship = null;
        switch (mShipType)
        {
                case Ship.ShipType.ShipRoot:
                    ship = new ShipRoot(gameName, Sprite.SpriteName.NullObject, index, mX, mY);
                    GameObjectNodeManager.add(ship, cPCSTree);
                    break;
            case Ship.ShipType.CannonShip:
                    ship = new CannonShip(gameName, Sprite.SpriteName.CannonShip, index, mX, mY);
             
                 //   ship = cannonShip;
                    break;

            case Ship.ShipType.Uninitilized:
                Debug.WriteLine("Missile Type is Uninitilized");
                break;
        }

            this.cPCSTree.Insert(ship, this.cParent);

            // cSpriteBatch.addToBatch(ship.getProxySprite());
            // cSpriteBatch.addToBatch(ship.getCollisionObj().cSpriteBox);
            ship.addSpriteToBatch(this.cSpriteBatch);
            ship.addCollisionToBatch(SpriteBatchManager.find(SpriteBatch.SpriteBatchName.Boxes));
            return ship;
    }
        public void removeChildren()
        {
            GameObject rootObj = (GameObject)cPCSTree.getRoot();
            PCSTreeReverseIterator pcsTreeIter = new PCSTreeReverseIterator(rootObj);
            Debug.Assert(pcsTreeIter != null);
            GameObject gameObj = (GameObject)pcsTreeIter.First();
            while (!pcsTreeIter.IsDone())
            {
                if (gameObj.cGameObjectName != GameObject.GameObjectName.ShipRoot)
                {
                    gameObj.remove();
                }else
                {
                    gameObj.x = 0;
                    gameObj.y = 0;
                    gameObj.cCollisionObj.cCollisionRectangle.Set(0, 0, 0, 0);
                }
                gameObj = (GameObject)pcsTreeIter.Next();
            }
        }

        public void activate(Ship ship)
        {
            //SpriteBatch boxBatch = SpriteBatchManager.find(SpriteBatch.SpriteBatchName.Boxes);
            this.cPCSTree.Insert(ship, this.cParent);
            ship.addSpriteToBatch(this.cSpriteBatch);
            ship.addCollisionToBatch(SpriteBatchManager.find(SpriteBatch.SpriteBatchName.Boxes));
        }

    }
}
