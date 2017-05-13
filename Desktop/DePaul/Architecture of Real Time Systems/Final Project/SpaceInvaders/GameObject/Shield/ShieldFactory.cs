using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldFactory
    {
        public PCSTree cPCSTree;
        SpriteBatch cSpriteBatch;
        private PCSNode cParent;

        public ShieldFactory(PCSTree mPCSTree, SpriteBatch mSpriteBatch)
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
        public Shield createShield(Shield.ShieldType mShieldType, GameObject.GameObjectName gameName, int index=0,float mX = 0.0f, float mY = 0.0f)
        {
            Shield shield = null;
            switch (mShieldType)
            {
                case Shield.ShieldType.ShieldBrick:
                    shield = new ShieldBrick(gameName, Sprite.SpriteName.ShieldBrick, index, mX, mY);
                    break;
                case Shield.ShieldType.ShieldColumn:
                    shield = new ShieldColumn(gameName, Sprite.SpriteName.NullObject, index, mX, mY);
                    break;
                case Shield.ShieldType.ShieldUnit:
                    shield = new ShieldUnit(gameName, Sprite.SpriteName.NullObject, index, mX, mY);
                    break;
                case Shield.ShieldType.ShieldGrid:
                    shield = new ShieldGrid(gameName, index,Sprite.SpriteName.NullObject);
                    GameObjectNodeManager.add(shield, cPCSTree);
                    break;
                case Shield.ShieldType.Uninitilized:
                    Debug.WriteLine("Shield Type is Uninitilized");
                    break;
            }

            this.cPCSTree.Insert(shield, this.cParent);
            // cSpriteBatch.addToBatch(shield.getProxySprite());
            // cSpriteBatch.addToBatch(shield.getCollisionObj().cSpriteBox);

            shield.addSpriteToBatch(this.cSpriteBatch);
            shield.addCollisionToBatch(SpriteBatchManager.find(SpriteBatch.SpriteBatchName.Boxes));
            return shield;
        }
        public void removeChildren()
        {
            GameObject rootObj = (GameObject)cPCSTree.getRoot();
            PCSTreeReverseIterator pcsTreeIter = new PCSTreeReverseIterator(rootObj);
            Debug.Assert(pcsTreeIter != null);
            GameObject gameObj = (GameObject)pcsTreeIter.First();
            while (!pcsTreeIter.IsDone())
            {
                if (gameObj.cGameObjectName != GameObject.GameObjectName.ShieldGrid)
                {
                    gameObj.remove();
                }
                gameObj = (GameObject)pcsTreeIter.Next();
            }
        }
        public void activate(Shield shield)
        {
            this.cPCSTree.Insert(shield, this.cParent);
            shield.addSpriteToBatch(this.cSpriteBatch);
            shield.addCollisionToBatch(SpriteBatchManager.find(SpriteBatch.SpriteBatchName.Boxes));
        }
    }
}