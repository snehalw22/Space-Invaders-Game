using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienFactory
    {
        public PCSTree cPCSTree;
        public SpriteBatch cSpriteBatch;
        private PCSNode cParent;
        public int columnCount;
        public int alienCount;
        public AlienFactory(PCSTree mPCSTree, SpriteBatch mSpriteBatch)
        {
            this.cPCSTree = mPCSTree;
            //this.cSpriteBatch = SpriteBatchManager.find(mSpriteBatch);
            this.cSpriteBatch = mSpriteBatch;
            cParent = null;
            columnCount = 0;
            alienCount = 0;
        }
        public void setParent(PCSNode parentNode)
        {
            this.cParent = parentNode;
          //  Debug.Assert(this.cParent != null);
        }
        public Alien createAlien(Alien.AlienType mAlienType, GameObject.GameObjectName gameName,int index=0, float mX=0.0f, float mY=0.0f)
        {
            Alien alien = null;
            switch (mAlienType)
            {
                case Alien.AlienType.Crab:
                    alien = new Crab(gameName, Sprite.SpriteName.Crab,index, mX, mY);
                    break;
                case Alien.AlienType.Squid:
                    alien = new Squid(gameName, Sprite.SpriteName.Squid, index, mX, mY);
                    break;
                case Alien.AlienType.Octopus:
                    alien = new Octopus(gameName, Sprite.SpriteName.Octopus, index, mX, mY);
                    break;
                case Alien.AlienType.Column:
                    alien = new Column(gameName, Sprite.SpriteName.NullObject, index, mX, mY);
                  //  columnCount++;
                  //  Debug.WriteLine(columnCount);
                    break;
                case Alien.AlienType.AlienGrid:
                    alien = new AlienGrid(gameName, Sprite.SpriteName.NullObject, index, mX, mY);
                    GameObjectNodeManager.add(alien,cPCSTree);
                    break;
                case Alien.AlienType.AlienExplosion:
                    alien = new AlienExplode(gameName, Sprite.SpriteName.AlienExplosion, index, mX, mY);
                    break;
                case Alien.AlienType.Uninitilized:
                    Debug.WriteLine("Alien Type is Uninitilized");
                    break;
            }

            activate(alien);
            return alien;
        }
        public void reduceCount(Alien alien)
        {

            if (alien.cGameObjectName == GameObject.GameObjectName.Column)
            {
                columnCount--;
            }
            else 
            {
                alienCount--;
            }
        }
        public void addColumn()
        {
            this.columnCount++;
        }
        public void activate(Alien alien)
        {
            //SpriteBatch boxBatch = SpriteBatchManager.find(SpriteBatch.SpriteBatchName.Boxes);
            this.cPCSTree.Insert(alien, this.cParent);
            alien.addSpriteToBatch(this.cSpriteBatch);
            alien.addCollisionToBatch(SpriteBatchManager.find(SpriteBatch.SpriteBatchName.Boxes));

            if(alien.cGameObjectName==GameObject.GameObjectName.Column)
            {
                columnCount++;
            }else 
            {
                alienCount++;
            }
        }

        public void removeChildren()
        {
            Debug.WriteLine("Removing childern");
            GameObject rootObj =(GameObject)cPCSTree.getRoot();
            PCSTreeReverseIterator pcsTreeIter = new PCSTreeReverseIterator(rootObj);
            Debug.Assert(pcsTreeIter != null);
            GameObject gameObj = (GameObject)pcsTreeIter.First();
            while (!pcsTreeIter.IsDone())
            {
                if (gameObj.cGameObjectName != GameObject.GameObjectName.AlienGrid)
                {
                    gameObj.remove();
                }
                else
                {
                    gameObj.x = 0;
                    gameObj.y = 0;
                    gameObj.cCollisionObj.cCollisionRectangle.Set(0, 0, 0, 0);
                }
                gameObj = (GameObject)pcsTreeIter.Next();
            }
      }
    }
}
