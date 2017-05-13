using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Sprite : SpriteBase
    {
        public enum SpriteName
        {
            Crab,
            Octopus,
            Squid,
            AlienExplosion,

            UFORoot,
            AlienUFO,

            ShieldBrick,
            Missile,

            ZigZag,
            Flipping,
            Plunger,

            StraightMissile,
            MissileExplosion,

            CannonShip,
            ShipExplosion,
            Wall,

            NullObject,
            Uninitilized,
            Splat
        }

        public SpriteName spriteName;
        public Image spriteImage;
        public Azul.Sprite azulSprite;
        public Azul.Color spriteColor;
        public Azul.Rect screenRect;

        public float x;
        public float y;
        public float sx;
        public float sy;
        public float angle;

        // default ...
        private static Azul.Rect cDefScreenRect = new Azul.Rect();
        private static Azul.Color cDefColor = new Azul.Color(0, 1, 0); 
        //default constructor

        public Sprite() :base()
        {
            this.spriteName = Sprite.SpriteName.Uninitilized;

            this.spriteImage = ImageManager.find(Image.ImageName.NullObject);
            Debug.Assert(this.spriteImage != null);

            this.spriteColor = new Azul.Color();
            Debug.Assert(this.spriteColor != null);

            this.screenRect = new Azul.Rect(cDefScreenRect);
            Debug.Assert(screenRect != null);

            this.azulSprite = new Azul.Sprite(spriteImage.getAzulTexture(), spriteImage.imageRect, cDefScreenRect, this.spriteColor);
            Debug.Assert(this.azulSprite != null);

            this.x = azulSprite.x;
            this.y = azulSprite.y;
            this.sx = azulSprite.sx;
            this.sy = azulSprite.sy;
            this.angle = azulSprite.angle;
        }

        internal void changeImage(Image mImage)
        {
            Debug.Assert(mImage != null);
            this.spriteImage = mImage;

            this.azulSprite.SwapTexture(this.spriteImage.getAzulTexture());
            this.azulSprite.SwapTextureRect(this.spriteImage.getImageRect());
        }

        // parameterized constructor

        public Sprite(SpriteName spriteName, Image spriteImage, Azul.Rect screenRect, Azul.Color mColor)
        {
            //setAll(spriteName,spriteImage,screenRect,mColor);
            Debug.Assert(spriteImage != null);
            Debug.Assert(screenRect != null);
            Debug.Assert(mColor != null);

            this.spriteImage = spriteImage;
            this.spriteName = spriteName;
            this.screenRect.Set(screenRect);
            this.spriteColor.Set(mColor);
           
            this.x = azulSprite.x;
            this.y = azulSprite.y;
            this.sx = azulSprite.sx;
            this.sy = azulSprite.sy;
            this.angle = azulSprite.angle;
        }
     
        public void setAll(SpriteName spriteName, Image spriteImage, float x, float y, float width, float height,Azul.Color mColor)
        {
            Debug.Assert(spriteImage != null);

            this.spriteImage = spriteImage;
            this.spriteName = spriteName;

            //    this.spriteColor.Set(cDefColor.red,cDefColor.green,cDefColor.blue);
            this.spriteColor.Set(mColor);

            this.screenRect.Set(x, y, width, height);

            this.azulSprite.Swap(spriteImage.imageTexture.azulTexture,spriteImage.imageRect, screenRect, spriteColor);

            Debug.Assert(this.azulSprite != null);

            this.x = azulSprite.x;
            this.y = azulSprite.y;
            this.sx = azulSprite.sx;
            this.sy = azulSprite.sy;
            this.angle = azulSprite.angle;
        }
        //Individual setters
        public void setSpriteName(SpriteName spriteName)
        {
            this.spriteName = spriteName;
        }
        private void setX(float x)
        {
            this.x = x;
        }
        private void setY(float y)
        {
            this.y = y;
        }
        private void setSx(float sx)
        {
            this.sx = sx;
        }
        private void setSY(float sy)
        {
            this.sy = sy;
        }
        private void setAngle(float angle)
        {
            this.angle = angle;
        }
        public void setSpriteImage(Image spriteImage)
        {
            this.spriteImage = spriteImage;
        }
        // Azul.Sprite is created from the input rectangle
        public void setAzulSprite(Azul.Sprite azulSprite)
        {
            this.azulSprite = azulSprite;
        }
        // generic method to create a Azul Sprite
        private Azul.Sprite createAzulSprite(Image spriteImage, Azul.Rect screenRect)
        {
            Azul.Sprite azulSprite = new Azul.Sprite(spriteImage.imageTexture.azulTexture, spriteImage.imageRect, screenRect);
            return azulSprite;
        }
        //Update the Azul Sprite
        public override void update()
        {
            this.azulSprite.x = this.x;
            this.azulSprite.y = this.y;
            this.azulSprite.sx = this.sx;
            this.azulSprite.sy = this.sy;
            this.azulSprite.angle = this.angle;

            this.azulSprite.Update();
        }

        // Render the sprite

        public override void render()
        {
            this.azulSprite.Render();
        }
        // Clear the object

        public void wash()
        {
            this.spriteName = SpriteName.Uninitilized;
            this.spriteImage = ImageManager.find(Image.ImageName.Uninitilized);

            Debug.Assert(spriteImage != null);

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;
           
            this.azulSprite.Swap(spriteImage.getAzulTexture(), spriteImage.imageRect, cDefScreenRect,cDefColor);
            this.spriteColor = cDefColor;
            this.screenRect.Set(cDefScreenRect);
        }

        protected override void nodeStatistics()
        {
            Debug.WriteLine(" Sprite Name{0} HashCode({1})", this.spriteName, this.GetHashCode());
            if (this.spriteImage == null)
            {
                Debug.WriteLine("Image Name: Null Image");
            }
            else
            {
                Debug.WriteLine("Image Name: {0}", this.spriteImage.imageName);
            }
        }

        public override Enum getSpriteName()
        {
            return spriteName;
        }
    }
}
