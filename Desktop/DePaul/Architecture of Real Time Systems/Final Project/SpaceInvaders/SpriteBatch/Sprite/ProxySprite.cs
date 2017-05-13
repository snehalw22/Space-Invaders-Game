using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    // This object will point to the SpriteGame
    // Used for rendering multiple Sprites
    class ProxySprite : SpriteBase
    {

        public Sprite rcSprite;
        public float x;
        public float y;
        public ProxySpriteName cProxySpriteName;
        public enum ProxySpriteName
        {
            SpriteProxy,
            Uninitilized
        }
        public ProxySprite() : base()
        {
            this.rcSprite = null;
            this.x = 0.0f;
            this.y = 0.0f;
            this.cProxySpriteName = ProxySpriteName.Uninitilized;
        }
        public ProxySprite(Sprite.SpriteName mSpriteName)
        {
            this.cProxySpriteName = ProxySpriteName.SpriteProxy;
            this.x = 0.0f;
            this.x = 0.0f;
            this.rcSprite = (Sprite)SpriteManager.find(mSpriteName);
            Debug.Assert(rcSprite != null);
        }
        public ProxySpriteName getCProxySpriteName()
        {
            return this.cProxySpriteName;
        }

        public void setCProxySpriteName(ProxySprite.ProxySpriteName mPRoxySpriteName)
        {
            this.cProxySpriteName = mPRoxySpriteName;
        }
        public void setAll(Sprite.SpriteName mSpriteName,float posX =0.0f, float posY=0.0f)
        {
            this.cProxySpriteName = ProxySpriteName.SpriteProxy;
            this.x = posX;
            this.y = posY;
            this.rcSprite = (Sprite)SpriteManager.find(mSpriteName);
            Debug.Assert(rcSprite != null);
        }
        public override void update()
        {
            //this.rcSprite.x = this.x;
            //this.rcSprite.y = this.y;
            //this.rcSprite.update();
        }

        public override void render()
        {
            // Update the sprite again before rendering. 
            this.rcSprite.x = this.x;
            this.rcSprite.y = this.y;
            this.rcSprite.update();
            this.rcSprite.render();
        }

        protected override void nodeStatistics()
        {
           
        }

        public override Enum getSpriteName()
        {
            return rcSprite.getSpriteName();
        }
    }
}
