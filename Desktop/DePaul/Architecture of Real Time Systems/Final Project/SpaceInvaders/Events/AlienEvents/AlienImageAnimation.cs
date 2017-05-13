using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienImageAnimation : Command
    {
        public Sprite cSpriteGame;
        public SLink cCurrImg;
        public SLink cImgList;

        public AlienImageAnimation(Sprite.SpriteName spriteGameName)
        {
            cSpriteGame = (Sprite) SpriteManager.find(spriteGameName);
            Debug.Assert(cSpriteGame != null);

            cCurrImg = null;
            cImgList = null;
        }
        //Attaches the Image Holder to the front of the list and current image is updated with it.
        public void attachImg(Image.ImageName imageName)
        {
            Image image = (Image)ImageManager.find(imageName);

            Debug.Assert(image != null);

            ImageHolder imageHolder = new ImageHolder(image);

            Debug.Assert(imageHolder != null);

            SLink.addToFront(ref cImgList, imageHolder);

            cCurrImg = imageHolder;
        }


        // Move to the next image and if at end, start from the first image again
        public override void execute(float deltaTime)
        {
            ImageHolder imageHolder = null;

            if(cCurrImg.pSNext!=null)
            {
                imageHolder = (ImageHolder)cCurrImg.pSNext;
            }
            else
            {
                imageHolder =(ImageHolder) cImgList;
            }
            cCurrImg = imageHolder;

            this.cSpriteGame.changeImage(imageHolder.cImage);
           
                // Add itself back to timer
            TimerManager.sortedAdd(TimerEvent.TimerEventName.SpriteAnimation, this, Unit.AlienImageSwapEventTime);
            
        }
    }
}
