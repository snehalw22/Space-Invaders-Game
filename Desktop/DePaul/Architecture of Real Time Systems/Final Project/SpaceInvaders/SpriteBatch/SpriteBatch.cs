using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBatch : MLink
    {
        private static SpriteBatchNode cSpriteBatchNodeRef = new SpriteBatchNode();
        public SpriteBatch.SpriteBatchName spriteBatchName;
        private SpriteBatchNodeManager  cSBNodeManager;
        public enum SpriteBatchName
        {
            Aliens,
            Shields,
            Boxes,
            Missiles,
            Walls,
            UFOs,
            Ships,
            Uninitialized,
            Default,
            Bombs,
            Text
        }
        
        public SpriteBatch() :base()
        {
            this.spriteBatchName = SpriteBatchName.Uninitialized;
            this.cSBNodeManager = new SpriteBatchNodeManager();
        }
        // Not implemented. Yet to implement
       

        public void remove(SpriteBatchNode targetNode)
        {       
            Debug.Assert(targetNode != null);
            this.cSBNodeManager.remove(targetNode);
        }

        // Add method for all the types of SpriteBatchNode

        public SpriteBatchNode addToBatch(SpriteBase mSpriteBase)
        {
            // get the SpriteBaseNode from the reserve list to the active list
            SpriteBatchNode spriteGameNode = (SpriteBatchNode)this.cSBNodeManager.add(mSpriteBase);
            Debug.Assert(spriteGameNode != null);
            return spriteGameNode;
        }
       
        public void set(SpriteBatch.SpriteBatchName mSpriteBatchName, int deltaRefillCount, int prefillCount)
        {
            Debug.Assert(deltaRefillCount > 0);
            Debug.Assert(prefillCount > 0);

            this.spriteBatchName = mSpriteBatchName;
            this.cSBNodeManager.set(mSpriteBatchName, deltaRefillCount, prefillCount);
            this.cSBNodeManager.setSpriteBatch(this);
        }
        public void draw()
        {
            SpriteBatchNode mSpriteBatchNode = (SpriteBatchNode)cSBNodeManager.activeList;

            while (mSpriteBatchNode != null)
            {
                mSpriteBatchNode.cSpriteBase.render();
                mSpriteBatchNode = (SpriteBatchNode)mSpriteBatchNode.pNext;
            }
        }
        public void wash()
        {
            this.spriteBatchName = SpriteBatch.SpriteBatchName.Uninitialized;
        }
        public void printSpriteBatch()
        {
            this.nodeStatistics();
        }
        protected override void nodeStatistics()
        {
            Debug.WriteLine(" Sprite batch Name{0} Hash Code:({1})", this.spriteBatchName, this.GetHashCode());

            Debug.WriteLine("The Sprite Batch Node Manager Statstics:");

            cSBNodeManager.printContainer();
            Debug.WriteLine("-------------------------------");
        }
    }
}
