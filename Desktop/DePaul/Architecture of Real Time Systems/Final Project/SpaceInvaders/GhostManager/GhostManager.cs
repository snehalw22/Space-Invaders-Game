using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    class GhostManager : Manager
    {
        private static Ghost ghostRef = new Ghost();
        private static GhostManager ghostMInstance = null;
        private GhostManager(int deltaRefillCount = 3, int prefillCount = 5)
            : base(deltaRefillCount, prefillCount)
        {
            //filling the reserve is done by the base.
        }
        public static void createMInstance(int deltaRefillCount = 3, int prefillCount = 5)
        {

            Debug.WriteLine("Creating Ghost Manager instance");

            Debug.Assert(deltaRefillCount > 0);
            Debug.Assert(prefillCount > 0);
            if (ghostMInstance == null)
            {
                ghostMInstance = new GhostManager(deltaRefillCount, prefillCount);
            }

            Debug.Assert(ghostMInstance != null);          
        }

        public static Ghost add(GameObject mObject)
        {
            GhostManager ghostManInst = GhostManager.getSingletonInstance();
            Debug.Assert(ghostManInst != null);
            Ghost nodeAdded = (Ghost)ghostManInst.genericAdd();

            Debug.Assert(nodeAdded != null);
            //set the attributes of the Image node 

            nodeAdded.set(mObject);

            return nodeAdded;
        }

        public static void remove(GameObject targetNode)
        {
            Debug.Assert(targetNode != null);
            GhostManager pMan = GhostManager.getSingletonInstance();

            // Compare functions only compares two Nodes
            ghostRef.cObject.cGameObjectName = targetNode.cGameObjectName;
            Ghost pData = (Ghost)pMan.genericFind(ghostRef);

            // release the resource
            pData.cObject = new NullGameObject();
            pMan.genericRemove(pData);

        }
        public static GameObject find(GameObject.GameObjectName gameObjectName)
        {
            GhostManager ghostManInst = GhostManager.getSingletonInstance();

            ghostRef.cObject.cGameObjectName = gameObjectName;

            Ghost ghostNode = (Ghost)ghostManInst.genericFind(ghostRef);
            Debug.Assert(ghostNode != null);
            return ghostNode.cObject;
        }



        protected override bool compareConcreteNode(ref MLink targetNode, ref MLink currNode)
        {
            Debug.Assert(targetNode != null);
            Debug.Assert(currNode != null);

            bool result = false;
            Ghost target = (Ghost)targetNode;
            Ghost curr = (Ghost)currNode;

            if (target.cObject.cGameObjectName.Equals(curr.cObject.cGameObjectName))
            {
                result = true;
            }

            return result;
        }

        // create a Image DLink node and return
        protected override MLink createConcreteNode()
        {
            Ghost ghost = new Ghost(); // different
            Debug.Assert(ghost != null);
            return ghost;
        }

        private static GhostManager getSingletonInstance()
        {
            Debug.Assert(ghostMInstance != null);
            return ghostMInstance;
        }

        protected override void printStats(ref MLink targetNode)
        {

        }

        public static void printList()
        {
            GhostManager manInst = GhostManager.getSingletonInstance();
            Debug.Assert(manInst != null);

            Debug.WriteLine("");
            Debug.WriteLine("------ Active List: ---------------------------\n");

            MLink pNode = manInst.activeList;

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

            pNode = manInst.reserveList;
            i = 0;
            while (pNode != null)
            {
                Debug.WriteLine("{0}: -------------", i);
                //pNode.print();
                i++;
                pNode = pNode.pNext;
            }
        }
    }
}
