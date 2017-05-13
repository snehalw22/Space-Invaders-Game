using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ImageManager : Manager
    {
        private static ImageManager imgMInstance = null;

        private ImageManager(int deltaRefillCount = 3, int prefillCount = 5)
            : base(deltaRefillCount, prefillCount)
        {
            //filling the reserve is done by the base.
        }

        public static void createMInstance(int deltaRefillCount = 3, int prefillCount = 5)
        {
            Debug.Assert(deltaRefillCount > 0);
            Debug.Assert(prefillCount > 0);
            if (imgMInstance == null)
            {

                Debug.WriteLine("Creating Image Manager instance");
                imgMInstance = new ImageManager(deltaRefillCount, prefillCount);
            }
            Debug.Assert(imgMInstance != null);
            // Add a default image for reference
            ImageManager.add(Image.ImageName.NullObject, Texture.TextureName.NullObject, new Azul.Rect(0, 0, 0, 0));
        }

       
        public static Image add(Image.ImageName imageName,Texture.TextureName imageTexName, Azul.Rect imageRect)
        {

            ImageManager imgMInstance = ImageManager.getSingletonInstance();
            Debug.Assert(imgMInstance != null);

            Image nodeAdded = (Image)imgMInstance.genericAdd();

            Debug.Assert(nodeAdded != null);
            //set the attributes of the Image node 

            Texture mtexture = TextureManager.find(imageTexName);
            Debug.Assert(mtexture != null);

            nodeAdded.setImageName(imageName);
            nodeAdded.setImageRect(imageRect);
            nodeAdded.setImageTexture(mtexture);

            return nodeAdded;
        }

        public static void remove(Image targetNode)
        {
            ImageManager imgMInstance = ImageManager.getSingletonInstance();
            Debug.Assert(imgMInstance != null);
            Debug.Assert(targetNode != null);
            imgMInstance.genericRemove(targetNode);

        }
        public static Image find(Image.ImageName imageName)
        {
            ImageManager imgMInstance = ImageManager.getSingletonInstance();
            Debug.Assert(imgMInstance != null);
            Image pseudoImage = new Image();
            pseudoImage.setImageName(imageName);

            Debug.Assert(imgMInstance != null);

            Image targetImg =(Image) imgMInstance.genericFind(pseudoImage);
            return targetImg;
        }
        protected override bool compareConcreteNode(ref MLink targetNode,ref MLink currNode)
        {
            Debug.Assert(targetNode != null);
            Debug.Assert(currNode != null);

            bool result=false;
            Image targetImg = (Image)targetNode;
            Image currImage = (Image)currNode;

            if(targetImg.imageName.Equals(currImage.imageName))
            {
                result = true;
            }

            return result;
        }

        // create a Image DLink node and return
        protected override MLink createConcreteNode()
        {
            Image image = new Image(); // different
            Debug.Assert(image != null);
            return image;
        }

        private static ImageManager getSingletonInstance()
        {
            Debug.Assert(imgMInstance != null);
            return imgMInstance;
        }

        protected override void printStats(ref MLink targetNode)
        {
            throw new NotImplementedException();
        }
    }
}
