using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    // A generic class which has the common properties and methods of sprites
    public abstract class SpriteBase : MLink
    {
        public SpriteBatchNode spriteBatchNode;
        public SpriteBase() : base()
        {
            spriteBatchNode = null;
        }
        public abstract void update();
        public abstract void render();

        public abstract Enum getSpriteName();

        public SpriteBatchNode getSpriteBatchBNode()
        {
            Debug.Assert(this.spriteBatchNode != null);
            return this.spriteBatchNode;
        }
        public void setSpriteBatchNode(SpriteBatchNode sbNode)
        {
            Debug.Assert(sbNode != null);
            this.spriteBatchNode = sbNode;
        }
    }
}
