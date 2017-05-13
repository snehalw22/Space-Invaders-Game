using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    class ProxySpriteManager : Manager
    {
        private static ProxySpriteManager proxyMInstance = null;
        private static ProxySprite cProxyRef = new ProxySprite();

        private ProxySpriteManager(int deltaRefillCount = 3, int prefillCount = 5)
            : base(deltaRefillCount, prefillCount) {}

        public static void createMInstance(int deltaRefillCount = 3, int prefillCount = 5)
        {
            Debug.Assert(deltaRefillCount > 0);
            Debug.Assert(prefillCount > 0);
            if (proxyMInstance == null)
            {
               /// Debug.WriteLine("Created a instance of Proxy Manager");
                proxyMInstance = new ProxySpriteManager(deltaRefillCount, prefillCount);
            }
            ProxySprite pPSprite = ProxySpriteManager.add(Sprite.SpriteName.NullObject);

            Debug.Assert(pPSprite != null);
            Debug.Assert(proxyMInstance != null);
        }


        public static ProxySprite add(Sprite.SpriteName mSpriteName)
        {
            ProxySpriteManager spriteBoxMInstance = ProxySpriteManager.getSingletonInstance();
            Debug.Assert(proxyMInstance != null);

            ProxySprite nodeAdded = (ProxySprite)proxyMInstance.genericAdd();

            Debug.Assert(nodeAdded != null);
            //set the attributes of the proxy sprite node        

            nodeAdded.setAll(mSpriteName);
            return nodeAdded;
        }

        public static void remove(ProxySprite targetNode)
        {
            ProxySpriteManager spriteBoxMInstance = ProxySpriteManager.getSingletonInstance();
            Debug.Assert(proxyMInstance != null);

            Debug.Assert(targetNode != null);
            proxyMInstance.genericRemove(targetNode);

        }
        public static ProxySprite find(ProxySprite.ProxySpriteName mProxySpriteName)
        {
            ProxySpriteManager spriteBoxMInstance = ProxySpriteManager.getSingletonInstance();
            Debug.Assert(proxyMInstance != null);

            ProxySprite pseudoProxy = cProxyRef;
            Debug.Assert(pseudoProxy != null);

            pseudoProxy.setCProxySpriteName(mProxySpriteName);

            ProxySprite targetProxy = (ProxySprite)proxyMInstance.genericFind(pseudoProxy);
            return targetProxy;
        }

        protected override bool compareConcreteNode(ref MLink targetNode, ref MLink currNode)
        {
            Debug.Assert(targetNode != null);
            Debug.Assert(currNode != null);

            bool result = false;
            ProxySprite targetProx = (ProxySprite)targetNode;
            ProxySprite currProx = (ProxySprite)currNode;

            if (targetProx.getCProxySpriteName().Equals(currProx.getCProxySpriteName()))
            {
                result = true;
            }

            return result;
        }

        protected override MLink createConcreteNode()
        {
            ProxySprite proxySprite = new ProxySprite(); // different
            Debug.Assert(proxySprite != null);
            return proxySprite;
        }

        protected override void printStats(ref MLink targetNode)
        {
          

        }
        private static ProxySpriteManager getSingletonInstance()
        {
          Debug.Assert(proxyMInstance != null);

            return proxyMInstance;
        }

        public static void printList()
        {
            ProxySpriteManager spriteBoxMInstance = ProxySpriteManager.getSingletonInstance();
            Debug.Assert(proxyMInstance != null);

            Debug.WriteLine("");
            Debug.WriteLine("------ Active List: ---------------------------\n");

            MLink pNode = proxyMInstance.activeList;

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

            pNode = proxyMInstance.reserveList;
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
