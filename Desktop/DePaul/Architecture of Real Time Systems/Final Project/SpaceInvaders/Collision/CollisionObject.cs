using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionObject
    {
        public SpriteBox cSpriteBox;
        public CollisionRectangle cCollisionRectangle;

        // Extract the rectangle co ordinates of the sprite in the proxy sprite
        // Set those to the sprite box.

        public CollisionObject(ProxySprite mProxySprite)
        {
            Debug.Assert(mProxySprite != null);

            //Create a BoxSprite
            Sprite mSprite = mProxySprite.rcSprite;
            Debug.Assert(mSprite != null);

            cSpriteBox = SpriteBoxManager.add(SpriteBox.SpriteBoxName.Box, mSprite.screenRect);
            Debug.Assert(this.cSpriteBox != null);

            // Set the Collision Rectangle
            this.cCollisionRectangle = new CollisionRectangle(cSpriteBox.cSpriteBoxRect);
            Debug.Assert(this.cCollisionRectangle != null);
            //  this.cSpriteBox.setColor(1, 1, 1);
            // this.cSpriteBox.setColor(Unit.spriteBoxColor);
        }

        public void setCoordinates(float x, float y)
        {

            this.cCollisionRectangle.x = x;
            this.cCollisionRectangle.y = y;

            this.cSpriteBox.x = x;
            this.cSpriteBox.y = y;
            this.cSpriteBox.setSpriteBoxRect(x, y, this.cCollisionRectangle.width, this.cCollisionRectangle.height);
            this.cSpriteBox.update();

        }

        public void setRect(float x, float y, float width, float height)
        {
            this.cCollisionRectangle.Set(x, y, width, height);
        }

        public void wash()
        {
            this.cSpriteBox.wash();
            this.cCollisionRectangle.Set(cSpriteBox.cSpriteBoxRect);
        }
    }
}
