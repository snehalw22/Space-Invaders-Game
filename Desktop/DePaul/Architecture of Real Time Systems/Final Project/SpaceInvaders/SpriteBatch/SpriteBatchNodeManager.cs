using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBatchNodeManager : Container
    {
        private static SpriteBatchNode cSprteBatNodeRef = new SpriteBatchNode();
        private SpriteBatch.SpriteBatchName name;
        private SpriteBatch rcSpriteBatch;
        public SpriteBatchNodeManager(int deltaRefillCount = 1, int prefillCount = 2)
            : base(deltaRefillCount, prefillCount)
        {
            this.name = SpriteBatch.SpriteBatchName.Uninitialized;
            this.rcSpriteBatch = null;
        }
        public SpriteBatchNode add(SpriteBase mSpriteBase)
        {
            SpriteBatchNode nodeAdded = (SpriteBatchNode)this.genericAdd();

            Debug.Assert(nodeAdded != null);

            nodeAdded.setSpriteBase(mSpriteBase,this);

            return nodeAdded;
        }
        public SpriteBatchNode add(Sprite.SpriteName mName)
        {
            SpriteBatchNode nodeAdded = (SpriteBatchNode)this.genericAdd();

            Debug.Assert(nodeAdded != null);

            nodeAdded.setSprite(mName, this);

            return nodeAdded;
        }
        public SpriteBatchNode add(SpriteBox.SpriteBoxName mSpriteBoxName)
        {
            SpriteBatchNode nodeAdded = (SpriteBatchNode)this.genericAdd();

            Debug.Assert(nodeAdded != null);

            nodeAdded.setSpriteBox(mSpriteBoxName, this);

            return nodeAdded;
        }
        public void remove(SpriteBatchNode targetNode)
        { 
            Debug.Assert(targetNode != null);
            this.genericRemove(targetNode);
        }
     
        protected override bool compareDerivedNode(ref MLink targetNode, ref MLink currNode)
        {
            Debug.Assert(targetNode != null);
            Debug.Assert(currNode != null);

            if (targetNode == currNode)
                return true;
            else
                return false;
        }

        protected override MLink createDerivedClassNode()
        {
            MLink mNode = new SpriteBatchNode();
            Debug.Assert(mNode != null);

            return mNode;
        }

        public void set(SpriteBatch.SpriteBatchName mSpriteBatchName, int deltaRefillCount = 1, int prefillCount = 3)
        {
            Debug.Assert(deltaRefillCount > 0);
            Debug.Assert(prefillCount > 0);
            this.name = mSpriteBatchName;
            this.baseManageReserve(deltaRefillCount, prefillCount);

        }

        internal void setSpriteBatch(SpriteBatch spriteBatch)
        {
            Debug.Assert(spriteBatch != null);
            this.rcSpriteBatch = spriteBatch;
        }

        override protected void derivedDumpNode(MLink pLink)
        {
          
        }

        public void printContainer()
        {
            Debug.WriteLine("");
            Debug.WriteLine("------ Active List: ---------------------------\n");

            MLink pNode = this.activeList;

            int i = 0;
            while (pNode != null)
            {
                Debug.WriteLine("{0}: SpriteBatchName-------------", i , name);
                pNode.print();
                i++;
                pNode = pNode.pNext;
            }

            Debug.WriteLine("");
            Debug.WriteLine("------ Reserve List: ---------------------------\n");

            pNode = this.reserveList;
            i = 0;
            while (pNode != null)
            {
                Debug.WriteLine("{0}: -------------", i);
                pNode.print();
                i++;
                pNode = pNode.pNext;
            }
        }
    }
}
