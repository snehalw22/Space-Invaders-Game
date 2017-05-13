using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteBatchManager : Manager
    {
        public static SpriteBatchManager sbmInstance = null;
        private static SpriteBatch pseudoSpriteBatchRef = new SpriteBatch();


        private SpriteBatchManager(int deltaRefillCount = 3, int prefillCount = 5)
            : base(deltaRefillCount, prefillCount)
        { }

        public static void createMInstance(int deltaRefillCount = 0, int prefillCount = 1)
        {
            Debug.WriteLine("Creating Sprite Batch Manager instance");
            Debug.Assert(deltaRefillCount > 0);
            Debug.Assert(prefillCount > 0);
            if (sbmInstance == null)
            {
                sbmInstance = new SpriteBatchManager(deltaRefillCount, prefillCount);
            }
            Debug.Assert(sbmInstance != null);
        }
        //Add a Sprite batch with name, Reserve count and Delta count
        public static SpriteBatch add(SpriteBatch.SpriteBatchName mSpriteBatchName, int deltaRefillCount = 1, int prefillCount = 3)
        {
            // Add a node from reserve list to the active list
            Debug.Assert(sbmInstance != null);
            SpriteBatch nodeAdded = (SpriteBatch)sbmInstance.genericAdd();

            Debug.Assert(nodeAdded != null);
            //set the attributes of the node 

            nodeAdded.set(mSpriteBatchName, deltaRefillCount, prefillCount);
            return nodeAdded;
        }

        public static void remove(SpriteBatch targetNode)
        {
            Debug.Assert(sbmInstance != null);
            Debug.Assert(targetNode != null);
            sbmInstance.genericRemove(targetNode);

        }
        public static void remove(SpriteBatchNode targetNode)
        {
            Debug.Assert(sbmInstance != null);
            Debug.Assert(targetNode != null);
            SpriteBatchNodeManager sbnMan = targetNode.getSpriteBatchNodeMan();

            Debug.Assert(sbnMan != null);
            sbnMan.remove(targetNode);
        }
        public static SpriteBatch find(SpriteBatch.SpriteBatchName mSpriteBatchName)
        {
            Debug.Assert(pseudoSpriteBatchRef != null);
            // Wash the PseudoSprite before using it
            pseudoSpriteBatchRef.wash();

            // Set the Name for Find
            pseudoSpriteBatchRef.spriteBatchName = mSpriteBatchName;

            Debug.Assert(sbmInstance != null);

            SpriteBatch targetSpriteBatch = (SpriteBatch)sbmInstance.genericFind(pseudoSpriteBatchRef);
            return targetSpriteBatch;
        }
        // Draw all the elements that are present on the Active List of the Batch Managers
        public static void draw()
        {
            SpriteBatch mSpriteBatch = (SpriteBatch)sbmInstance.activeList;
           
            while (mSpriteBatch != null)
            {
                mSpriteBatch.draw();
                mSpriteBatch = (SpriteBatch)mSpriteBatch.pNext;
            }
        }
        // Compare wheteher the SpriteBatch are the same
        protected override bool compareConcreteNode(ref MLink targetNode, ref MLink currNode)
        {
            Debug.Assert(targetNode != null);
            Debug.Assert(currNode != null);

            bool result = false;
            SpriteBatch targetSpriteBatch = (SpriteBatch)targetNode;
            SpriteBatch currSpriteBatch = (SpriteBatch)currNode;

            if (targetSpriteBatch.spriteBatchName.Equals(currSpriteBatch.spriteBatchName))
            {
                result = true;
            }

            return result;
        }

        protected override MLink createConcreteNode()
        {
            MLink pNode = new SpriteBatch();
            Debug.Assert(pNode != null);
            return pNode;
        }

        protected override void printStats(ref MLink targetNode)
        {
           
        }
        public static void cleanup()
        {
            sbmInstance.activeList = null;
            SpriteBatch pNode =(SpriteBatch) sbmInstance.activeList;
            sbmInstance.activeList = null;
            int i = 0;
            while (pNode != null)
            {
                remove(pNode);
                pNode =(SpriteBatch) pNode.pNext;
            }
        }
        public static void printList()
        {
            Debug.WriteLine("");
            Debug.WriteLine("------ Active List: ---------------------------\n");

            MLink pNode = sbmInstance.activeList;

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

            pNode = sbmInstance.reserveList;
            i = 0;
            while (pNode != null)
            {
                Debug.WriteLine("{0}: -------------", i);
                pNode.print();
                i++;
                pNode = pNode.pNext;
            }
        }

        internal static SpriteBatch add(object bombs)
        {
            throw new NotImplementedException();
        }
    }
}
