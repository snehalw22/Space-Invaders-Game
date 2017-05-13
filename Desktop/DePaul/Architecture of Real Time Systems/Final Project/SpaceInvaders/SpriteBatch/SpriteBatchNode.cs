using System;
using System.Diagnostics;

namespace SpaceInvaders
{
   // Class which abstracts the SpriteBox and Sprites
   public class SpriteBatchNode : MLink
    {
        public SpriteBase cSpriteBase;
        public SpriteBatchNodeManager cSBNodeMan;
        public SpriteBatchNode() : base()
        {
            this.cSpriteBase = null;
            cSBNodeMan = null ;
        }

        public void setSpriteBase(SpriteBase mSpriteBase, SpriteBatchNodeManager mSbManager)
        {
            Debug.Assert(mSpriteBase != null);
            Debug.Assert(mSbManager != null);

            this.cSpriteBase = mSpriteBase;
            this.cSBNodeMan = mSbManager;

            cSpriteBase.setSpriteBatchNode(this);
        }

        public void setSpriteBox(SpriteBox.SpriteBoxName spriteBox, SpriteBatchNodeManager mSbManager)
        {
            SpriteBox sprBox = (SpriteBox)SpriteBoxManager.find(spriteBox);

            Debug.Assert(sprBox != null);
            Debug.Assert(mSbManager != null);

            this.cSpriteBase = sprBox;
            this.cSBNodeMan = mSbManager;
        }
        public void setSprite(Sprite.SpriteName mSpriteName, SpriteBatchNodeManager mSbManager)
        {
            Sprite sprite = (Sprite)SpriteManager.find(mSpriteName);

            Debug.Assert(sprite != null);
            Debug.Assert(mSbManager != null);

            this.cSpriteBase = sprite;
            this.cSBNodeMan = mSbManager;
        }

        public SpriteBatchNodeManager getSpriteBatchNodeMan()
        {
            Debug.Assert(this.cSBNodeMan != null);
            return this.cSBNodeMan;
        }
     
        public void wash()
        {
            this.cSpriteBase = null;
        }

        public void print()
        {
            nodeStatistics();
        }

        protected override void nodeStatistics()
        {
            Debug.WriteLine("      node:({0})", this.GetHashCode());

            // Data:
            if (this.cSpriteBase != null)
            {
                Debug.WriteLine("      pSpriteBase: {0} ({1})", this.cSpriteBase.getSpriteName(), this.cSpriteBase.GetHashCode());
            }
            else
            {
                Debug.WriteLine("      pSpriteBase: null ");
            }
        }
    }

   
}
