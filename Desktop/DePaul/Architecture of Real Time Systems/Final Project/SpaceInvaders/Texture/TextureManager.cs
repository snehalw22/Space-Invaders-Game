using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TextureManager : Manager
    {
        private static TextureManager texMInstance = null;
        private static Texture cTextureRef = new Texture();
     
        private TextureManager(int deltaRefillCount = 3, int prefillCount = 5)
            : base(deltaRefillCount, prefillCount)
        {
            //filling the reserve is done by the base.
        }

        public static void createMInstance(int deltaRefillCount = 3, int prefillCount = 5)
        {

            Debug.WriteLine("Creating Tex Manager instance");
         
            Debug.Assert(deltaRefillCount > 0);
            Debug.Assert(prefillCount > 0);
            if (texMInstance == null)
            {
                texMInstance = new TextureManager(deltaRefillCount, prefillCount);
            }

            Debug.Assert(texMInstance != null);
            TextureManager.add(Texture.TextureName.NullObject, "HotPink.tga");
        }

        public static Texture add(Texture.TextureName texureName, string azulTex)
        {
            TextureManager texManInst = TextureManager.getSingletonInstance();
            Debug.Assert(texManInst != null);
            Texture nodeAdded = (Texture)texManInst.genericAdd();

            Debug.Assert(nodeAdded != null);
            //set the attributes of the Image node 

            nodeAdded.setAll(texureName, azulTex);

            return nodeAdded;
        }

        public static void remove(Texture targetNode)
        {
            TextureManager texManInst = TextureManager.getSingletonInstance();
            Debug.Assert(texManInst != null);

            Debug.Assert(targetNode != null);
            texManInst.genericRemove(targetNode);

        }
        public static Texture find(Texture.TextureName texName)
        {
            TextureManager texManInst = TextureManager.getSingletonInstance();
            Debug.Assert(texManInst != null);
            Texture pseudoTex = cTextureRef;
            Debug.Assert(pseudoTex != null);

            pseudoTex.setTextureName(texName);

            Texture targetTex = (Texture)texManInst.genericFind(pseudoTex);
            return targetTex;
        }



        protected override bool compareConcreteNode(ref MLink targetNode, ref MLink currNode)
        {
            Debug.Assert(targetNode != null);
            Debug.Assert(currNode != null);

            bool result = false;
            Texture targetTex = (Texture)targetNode;
            Texture currTex = (Texture)currNode;

            if (targetTex.textureName.Equals(currTex.textureName))
            {
                result = true;
            }

            return result;
        }

        // create a Image DLink node and return
        protected override MLink createConcreteNode()
        {
            Texture tex = new Texture(); // different
            Debug.Assert(tex != null);
            return tex;
        }

        private static TextureManager getSingletonInstance()
        {
            Debug.Assert(texMInstance != null);
            return texMInstance;
        }

        protected override void printStats(ref MLink targetNode)
        {
            
        }

        public static void printList()
        {
            TextureManager texManInst = TextureManager.getSingletonInstance();
            Debug.Assert(texManInst != null);

            Debug.WriteLine("");
            Debug.WriteLine("------ Active List: ---------------------------\n");

            MLink pNode = texManInst.activeList;

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

            pNode = texManInst.reserveList;
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
