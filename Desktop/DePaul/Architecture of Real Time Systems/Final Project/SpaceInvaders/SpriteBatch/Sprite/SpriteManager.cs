using System;
using System.Diagnostics;
using Azul;

namespace SpaceInvaders
{
    class SpriteManager: Manager
    {
        private static SpriteManager spriteMInstance = null;
        private static Sprite defSprite = new Sprite();
        private SpriteManager(int deltaRefillCount = 3, int prefillCount = 5)
            : base(deltaRefillCount, prefillCount)
        {
            //filling the reserve is done by the base.
        }

        public static void createMInstance(int deltaRefillCount = 3, int prefillCount = 5)
        {
            Debug.WriteLine("Creating Sprite Manager instance");
            Debug.Assert(deltaRefillCount > 0);
            Debug.Assert(prefillCount > 0);
            if (spriteMInstance == null)
            {
                spriteMInstance = new SpriteManager(deltaRefillCount, prefillCount);
            }

            Sprite nullSprite = SpriteManager.add(Sprite.SpriteName.NullObject, Image.ImageName.NullObject,0, 0, 128, 128,Unit.blackColor);
            Debug.Assert(nullSprite != null);

        }

        public static Sprite add(Sprite.SpriteName spriteName, Image.ImageName spriteImageName, float x, float y, float width, float height,Azul.Color azulColor)
        {
            SpriteManager spriteMInstance = SpriteManager.getSingletonInstance();
            Debug.Assert(spriteMInstance != null);

            Sprite nodeAdded = (Sprite)spriteMInstance.genericAdd();

            Debug.Assert(nodeAdded != null);
            //set the attributes of the Image node 
            Image image = ImageManager.find(spriteImageName);
            Debug.Assert(image != null);

            nodeAdded.setAll(spriteName, image, x,  y, width, height,azulColor);

            return nodeAdded;
        }

        public static void remove(Sprite targetNode)
        {
            SpriteManager spriteMInstance = SpriteManager.getSingletonInstance();
            Debug.Assert(spriteMInstance != null);

            Debug.Assert(targetNode != null);
            spriteMInstance.genericRemove(targetNode);

        }
        public static Sprite find(Sprite.SpriteName spriteName)
        {
            SpriteManager spriteMInstance = SpriteManager.getSingletonInstance();
            Debug.Assert(spriteMInstance != null);

            Sprite pseudoSprite = defSprite;
            pseudoSprite.setSpriteName(spriteName);

            Debug.Assert(spriteMInstance != null);

            Sprite targetSprite = (Sprite)spriteMInstance.genericFind(pseudoSprite);
            return targetSprite;

        }



        protected override bool compareConcreteNode(ref MLink targetNode, ref MLink currNode)
        {
            Debug.Assert(targetNode != null);
            Debug.Assert(currNode != null);

            bool result = false;
            Sprite targetSprite = (Sprite)targetNode;
            Sprite currSprite = (Sprite)currNode;

            if (targetSprite.spriteName.Equals(currSprite.spriteName))
            {
                result = true;
            }

            return result;
        }

        // create a Image DLink node and return
        protected override MLink createConcreteNode()
        {
            Sprite sprite = new Sprite(); // different
            Debug.Assert(sprite != null);
            return sprite;
        }

        private static SpriteManager getSingletonInstance()
        {
            Debug.Assert(spriteMInstance != null);
            return spriteMInstance;
        }

        public static MLink changeColor(Sprite targetNode, Color targetColor)
        {
            Debug.Assert(targetNode != null);
            Debug.Assert(targetColor != null);

            Sprite spriteNode = (Sprite)targetNode;
            spriteNode.azulSprite.SwapColor(targetColor);
            return targetNode;
        }

        protected override void printStats(ref MLink targetNode)
        {
            throw new NotImplementedException();
        }

        public static void printList()
        {
            SpriteManager spriteMInstance = SpriteManager.getSingletonInstance();
            Debug.Assert(spriteMInstance != null);

            Debug.WriteLine("");
            Debug.WriteLine("------ Active List: ---------------------------\n");

            MLink pNode = spriteMInstance.activeList;

            int i = 0;
            while (pNode != null)
            {
                Debug.WriteLine("{0}: -------------", i);
                pNode.print();
                i++;
                pNode = pNode.pNext;
            }

            Debug.WriteLine("");
            Debug.WriteLine("------ Reserve List: ---------------------------\n");

            pNode = spriteMInstance.reserveList;
            i = 0;
            while (pNode != null)
            {
                Debug.WriteLine("{0}: -------------", i);
                pNode.print();
                i++;
                pNode = pNode.pNext;
            }
        }
    }
}
