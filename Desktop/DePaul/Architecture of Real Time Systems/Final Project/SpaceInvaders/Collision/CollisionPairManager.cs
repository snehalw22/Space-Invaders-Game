using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionPairManager: Manager
    {
        private static CollisionPairManager collisionMInstance = null;
        private static CollisionPair defCollisionPair;
        private CollisionPair currentCollisionP;

        private CollisionPairManager(int deltaRefillCount = 3, int prefillCount = 5)
            : base(deltaRefillCount, prefillCount)
        {
            CollisionPair colPair = new CollisionPair();
            Debug.Assert(colPair != null);
            defCollisionPair = colPair;
            currentCollisionP = null;
        }

        public static void createMInstance(int deltaRefillCount = 3, int prefillCount = 5)
        {
            Debug.WriteLine("Creating Collision Pair Manager instance");

            Debug.Assert(deltaRefillCount > 0);
            Debug.Assert(prefillCount > 0);
            if (collisionMInstance == null)
            {
                collisionMInstance = new CollisionPairManager(deltaRefillCount, prefillCount);
            }

            Debug.Assert(collisionMInstance != null);
        }

        public static CollisionPair add(CollisionPair.CollisionPairName colPairName, GameObject rootA, GameObject rootB)
        {
            CollisionPairManager collisionManInst = CollisionPairManager.getSingletonInstance();
            Debug.Assert(collisionMInstance != null);
            CollisionPair nodeAdded = (CollisionPair)collisionManInst.genericAdd();

            Debug.Assert(nodeAdded != null);
            //set the attributes of the Image node 

            nodeAdded.set(colPairName, rootA,rootB);

            return nodeAdded;
        }

        public static void remove(CollisionPair targetNode)
        {
            CollisionPairManager collisionManInst = CollisionPairManager.getSingletonInstance();
            Debug.Assert(collisionMInstance != null);
            Debug.Assert(targetNode != null);
            collisionManInst.genericRemove(targetNode);

        }
        public static CollisionPair find(CollisionPair.CollisionPairName colPairName)
        {
            CollisionPairManager collisionManInst = CollisionPairManager.getSingletonInstance();
            Debug.Assert(collisionMInstance != null);
          
            CollisionPair pseudoPair = defCollisionPair;
            Debug.Assert(pseudoPair != null);

            pseudoPair.setName(colPairName);

            CollisionPair targetPair = (CollisionPair)collisionManInst.genericFind(pseudoPair);
            return targetPair;
        }

        protected override bool compareConcreteNode(ref MLink targetNode, ref MLink currNode)
        {
            Debug.Assert(targetNode != null);
            Debug.Assert(currNode != null);

            bool result = false;
            CollisionPair targetPair = (CollisionPair)targetNode;
            CollisionPair currPair = (CollisionPair)currNode;

            if (targetPair.collisionPairName.Equals(currPair.collisionPairName))
            {
                result = true;
            }

            return result;
        }

        // create a Image DLink node and return
        protected override MLink createConcreteNode()
        {
            CollisionPair colP = new CollisionPair(); // different
            Debug.Assert(colP != null);
            return colP;
        }

        private static CollisionPairManager getSingletonInstance()
        {
            Debug.Assert(collisionMInstance != null);
            return collisionMInstance;
        }

        protected override void printStats(ref MLink targetNode)
        {

        }

        public static void printList()
        {
            CollisionPairManager collisionManInst = CollisionPairManager.getSingletonInstance();
            Debug.Assert(collisionMInstance != null);
            Debug.WriteLine("");
            Debug.WriteLine("------ Active List Collision Pair Man: ---------------------------\n");

            MLink pNode = collisionManInst.activeList;

            int i = 0;
            while (pNode != null)
            {
                Debug.WriteLine("{0}: -------------", i);
                pNode.print();
                i++;
                pNode = pNode.pNext;
            }

            Debug.WriteLine("");
            Debug.WriteLine("------ Reserve List Collision Pair Man: ---------------------------\n");

            pNode = collisionManInst.reserveList;
            i = 0;
            while (pNode != null)
            {
                Debug.WriteLine("{0}: -------------", i);
                pNode.print();
                i++;
                pNode = pNode.pNext;
            }
        }

        public static void process()
        {
            CollisionPair mColPair = (CollisionPair)collisionMInstance.activeList;
            while (mColPair != null)
            {
                // Process each collision pair
                CollisionPairManager collisionManInst = CollisionPairManager.getSingletonInstance();
                Debug.Assert(collisionMInstance != null);
                collisionManInst.currentCollisionP = mColPair;
                mColPair.processCollision();
                mColPair = (CollisionPair)mColPair.pNext;
        }
        }

        public static CollisionPair getCurrentColPair()
        {

            CollisionPairManager collisionManInst = CollisionPairManager.getSingletonInstance();
            Debug.Assert(collisionMInstance != null);
            return collisionManInst.currentCollisionP;
        }
    }
}

