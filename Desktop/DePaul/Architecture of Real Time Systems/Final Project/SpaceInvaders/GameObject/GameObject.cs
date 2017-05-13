using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    abstract class GameObject : CollisionVisitor
    {
        private ProxySprite cProxySprite;
        public float x;
        public float y;
        public int index;
        public GameObjectName cGameObjectName;
        public CollisionObject cCollisionObj;
        public bool death;

        public enum GameObjectName
        {
            Squid,
            Crab,
            Octopus,
            AlienGrid,
            AlienExplosion,
            Column,

            UFORoot,
            AlienUFO,

            ShieldGrid,
            ShieldBrick,

            BombRoot,
            //FlippingBomb,
            //ZigZagBomb,
            //PlungerBomb,
            Bomb,
            MissileRoot,
            StraightMissile,

            CannonShip,
            ShipRoot,

            // Wall,
            WallRight,
            WallTop,
            WallLeft,
            WallDown,
            WallRoot,

            NullObject,
            Uninitialized,
            ShieldColumn,
            ShieldUnit,
            MissileExplosion
        }


        protected GameObject(GameObjectName mGameObjectName, int index, Sprite.SpriteName mSpriteName)
        {
            this.cGameObjectName = mGameObjectName;
            this.x = 0.0f;
            this.y = 0.0f;
            this.index = index;
            this.cProxySprite = ProxySpriteManager.add(mSpriteName);
            Debug.Assert(cProxySprite != null);

            this.cCollisionObj = new CollisionObject(cProxySprite);
            Debug.Assert(cCollisionObj != null);
            this.death = false;
        }

        public void setCollisionRect(float x, float y, float width, float height)
        {
            this.cCollisionObj.setRect(x, y, width, height);
        }
        public void setName(GameObjectName mGameObjName)
        {
            this.cGameObjectName = mGameObjName;

        }
        public override int GetIndex()
        {
            return this.index;
        }

        public void setX(float mX)
        {
            this.x = mX;
        }
        public void setY(float mY)
        {
            this.y = mY;

        }
        public float getX()
        {
            return this.x;
        }
        public float getY()
        {
            return this.y;

        }
        override public Enum getName()
        {
            return this.cGameObjectName;
        }
        public ProxySprite getProxySprite()
        {
            return this.cProxySprite;
        }
        public CollisionObject getCollisionObj()
        {
            return this.cCollisionObj;
        }
        public void markForDeath()
        {
            this.death = true;
        }
        public virtual void update()
        {
            this.cProxySprite.x = this.x;
            this.cProxySprite.y = this.y;

            //this.cProxySprite.update();
            this.cCollisionObj.setCoordinates(this.x, this.y);

            // this.cCollisionObj.cSpriteBox.update();
        }

        public void nodeStatistics()
        {
            Debug.WriteLine("Game Object name: {0} hash({1})", this.cGameObjectName, this.GetHashCode());
            Debug.WriteLine("x : {0}, y : {1}", this.x, this.y);
            if (this.cProxySprite != null)
            {
                Debug.WriteLine("Proxy Sprite Name{0}", this.cProxySprite.cProxySpriteName);
                Debug.WriteLine("Game Sprite Name{0}", this.cProxySprite.rcSprite.getSpriteName());
            }
            else
            {
                Debug.WriteLine("Proxy Sprite Name: null");
                Debug.WriteLine("Game Sprite Name: null");
            }

        }
        protected void updateUnionBox()
        {
            PCSNode node = (PCSNode)this;
            node = node.pChild;

            if (node == null)
            {              
                this.cCollisionObj.cCollisionRectangle.Set(0, 0, 0, 0);
                this.x = 0;
                this.y = 0;
            }
            else
            {
                GameObject gameObj = (GameObject)node;

                CollisionRectangle collisionTotal = this.cCollisionObj.cCollisionRectangle;
                collisionTotal.Set(gameObj.cCollisionObj.cCollisionRectangle);

                while (node != null)
                {
                    gameObj = (GameObject)node;
                    collisionTotal.Union(gameObj.cCollisionObj.cCollisionRectangle);
                    node = node.pSibling;
                }
                this.x = this.cCollisionObj.cCollisionRectangle.x;
                this.y = this.cCollisionObj.cCollisionRectangle.y;
            }
      
        }
        public void addCollisionToBatch(SpriteBatch pSpriteBatch)
        {
            Debug.Assert(pSpriteBatch != null);
            Debug.Assert(this.cCollisionObj != null);
            pSpriteBatch.addToBatch(this.cCollisionObj.cSpriteBox);
        }
        public void addSpriteToBatch(SpriteBatch pSpriteBatch)
        {
            Debug.Assert(pSpriteBatch != null);
            pSpriteBatch.addToBatch(this.cProxySprite);
        }
        public void wash()
        {
            this.cGameObjectName = GameObject.GameObjectName.Uninitialized;
            this.x = 0.0f;
            this.y = 0.0f;
            //dunno what to do
            this.index = 0;
        }
        public void explode(Sprite.SpriteName spriteName)
        {
      
            this.cProxySprite.setAll(spriteName, this.x, this.y);

        }
        public void swapImage(Sprite.SpriteName spriteName)
        {
            this.cProxySprite.setAll(spriteName, this.x, this.y);
        }

        public void removeFromGameManager()
        {
            GameObjectNodeManager.remove(this);
        }
        public void removeFromSpriteBatch()
        {
            SpriteBatchNode sbNode = cProxySprite.getSpriteBatchBNode();
            Debug.Assert(sbNode != null);
            SpriteBatchManager.remove(sbNode);

            ///3 lines commented for ghost Manager
            sbNode = this.cCollisionObj.cSpriteBox.getSpriteBatchBNode();
            Debug.Assert(sbNode != null);
            SpriteBatchManager.remove(sbNode);

            GhostManager.add(this);
     
        }
        public void remove()
        {
            GameObjectNodeManager.remove(this);
            //Remove from batch
              Debug.Assert(cProxySprite != null);
              SpriteBatchNode sbNode = cProxySprite.getSpriteBatchBNode();
            Debug.Assert(sbNode != null);
            SpriteBatchManager.remove(sbNode);

            ///3 lines commented for ghost Manager
            sbNode = this.cCollisionObj.cSpriteBox.getSpriteBatchBNode();
            Debug.Assert(sbNode != null);
            SpriteBatchManager.remove(sbNode);

              GhostManager.add(this);

        }
    }
}
