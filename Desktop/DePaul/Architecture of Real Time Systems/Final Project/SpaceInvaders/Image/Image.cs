using System;
using System.Diagnostics;
namespace SpaceInvaders
{
   public class Image : MLink
    {
        public ImageName imageName;
        public Azul.Rect imageRect;
        public Texture imageTexture;

        public enum ImageName
        {
            CrabO,
            CrabC,
            OctopusO,
            OctopusC,
            SquidO,
            SquidC,
           
            AlienExplosion,

            AlienUFO,

            ShieldBrick,
            ZigZagU,
            ZigZagD,
            FlippingU,
            FlippingD,
            PlungerU,
            PlungerD,

            StraightMissile,
            MissileExplosion,

            CannonShip,
            ShipExplosion,

            Wall,


            NullObject,
            Uninitilized,
            Splat
        }

        // default constructor
        public Image()
        {
            imageName = ImageName.Uninitilized;
            imageRect = new Azul.Rect();
            imageTexture = null;
        }


        // parameterized constructor
        public Image(ImageName imageName, Texture imageTex, Azul.Rect imageRect  )
        {
            Debug.Assert(imageTex != null);
            Debug.Assert(imageRect != null);
         
            this.setImageName(imageName);
            this.setImageRect(imageRect);
            this.setImageTexture(imageTex);
        }

        // setters for instances
        public void setImageName(ImageName imageName)
        {
            this.imageName = imageName;
        }

        public void setImageRect(Azul.Rect imageRect)
        {
            this.imageRect = imageRect;
        }

        public void setImageTexture(Texture imageTexture)
        {
            this.imageTexture = imageTexture;
        }
        public Azul.Texture getAzulTexture()
        {
            return this.imageTexture.getAzulTexture();
        }
        public Azul.Rect getImageRect()
        {
            return this.imageRect;
        }

        //clear the Image
        public void wash()
        {
            imageName = ImageName.Uninitilized;
            imageRect.Clear();
            imageTexture = null;
        }

        protected override void nodeStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
