using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    class BombFactory
    {
        PCSTree cPCSTree;
        SpriteBatch cSpriteBatch;
        private PCSNode cParent;

        public BombFactory(PCSTree mPCSTree, SpriteBatch mSpriteBatch)
        {
            this.cPCSTree = mPCSTree;
            //  this.cSpriteBatch = SpriteBatchManager.find(mSpriteBatch);
            this.cSpriteBatch = mSpriteBatch;
        }
        public void setParent(PCSNode parentNode)
        {
            this.cParent = parentNode;
            Debug.Assert(this.cParent != null);
        }

        public PCSTree getPCSTree()
        {
            Debug.Assert(this.cPCSTree != null);
            return cPCSTree;
        }
        public Bomb createBomb(Bomb.BombType mBombType, GameObject.GameObjectName gameName,int index=0, float mX = 0.0f, float mY = 0.0f)
        {
            Bomb bomb = null;
            switch (mBombType)
            {
                case Bomb.BombType.Flipping:
                    bomb = new FlippingBomb(gameName, Sprite.SpriteName.Flipping,index, mX, mY, mBombType);
                    break;
                case Bomb.BombType.ZigZag:
                    bomb = new ZigZagBomb(gameName, Sprite.SpriteName.ZigZag, index,mX, mY, mBombType);
                    break;
                case Bomb.BombType.Plunger:
                    bomb = new PlungerBomb(gameName, Sprite.SpriteName.Plunger, index, mX, mY, mBombType);
                    break;
                case Bomb.BombType.BombRoot:
                    bomb = new BombRoot(gameName, Sprite.SpriteName.NullObject, index,mX, mY, mBombType);
                    GameObjectNodeManager.add(bomb, cPCSTree);
                    break;
                case Bomb.BombType.Uninitilized:
                    Debug.WriteLine("Bomb Type is Uninitilized");
                    break;
            }

            activate(bomb);
            return bomb;
        }
        public void activate(Bomb bomb)
        {
            //SpriteBatch boxBatch = SpriteBatchManager.find(SpriteBatch.SpriteBatchName.Boxes);
            this.cPCSTree.Insert(bomb, this.cParent);
            bomb.addSpriteToBatch(this.cSpriteBatch);
            bomb.addCollisionToBatch(SpriteBatchManager.find(SpriteBatch.SpriteBatchName.Boxes));
        }
        public void removeChildren()
        {
            GameObject rootObj = (GameObject)cPCSTree.getRoot();
            PCSTreeReverseIterator pcsTreeIter = new PCSTreeReverseIterator(rootObj);
            Debug.Assert(pcsTreeIter != null);
            GameObject gameObj = (GameObject)pcsTreeIter.First();
            while (!pcsTreeIter.IsDone())
            {
                if (gameObj.cGameObjectName != GameObject.GameObjectName.BombRoot)
                {
                    gameObj.remove();
                }
                gameObj = (GameObject)pcsTreeIter.Next();
            }
        }
    }
}