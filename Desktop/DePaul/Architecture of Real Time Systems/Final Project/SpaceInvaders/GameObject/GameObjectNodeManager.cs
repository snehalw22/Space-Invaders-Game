using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameObjectNodeManager : Manager
    {
        // private PCSTree cRoot;
        private static GameObjectNodeManager gamMInstance = null;
        private static GameObjectNode cGameObjNodeRef = new GameObjectNode();
        private GameObjectNodeManager(int deltaRefillCount = 3, int prefillCount = 5)
            : base(deltaRefillCount, prefillCount)
        {
            //  this.cRoot = new PCSTree();
            //  Debug.Assert(this.cRoot != null);
            GameObject gameObject = new NullGameObject();
            Debug.Assert(gameObject != null);
            cGameObjNodeRef.setGameObject(gameObject);
        }

        public static void createMInstance(int deltaRefillCount = 3, int prefillCount = 5)
        {
            Debug.Assert(deltaRefillCount > 0);
            Debug.Assert(prefillCount > 0);
            if (gamMInstance == null)
            {
                gamMInstance = new GameObjectNodeManager(deltaRefillCount, prefillCount);
            }
            Sprite sprite = SpriteManager.add(Sprite.SpriteName.NullObject, Image.ImageName.NullObject, 0, 0, 1, 1,Unit.blackColor);
            Debug.Assert(gamMInstance != null);
        }
        //changed
        public static GameObjectNode add(GameObject mGameObj, PCSTree mTree)
        {
            Debug.Assert(mGameObj != null);
            Debug.Assert(mTree != null);

            GameObjectNodeManager goNInstance = GameObjectNodeManager.getSingletonInstance();
            Debug.Assert(gamMInstance != null);

            GameObjectNode goNode = (GameObjectNode)gamMInstance.genericAdd();
            Debug.Assert(goNode != null);

            goNode.set(mGameObj, mTree);
            return goNode;
        }
    
        public static void remove(GameObject targetNode)
        {
            Debug.WriteLine("I am coming here for 1st time");
        

            GameObjectNodeManager gonManager = GameObjectNodeManager.getSingletonInstance();
            Debug.Assert(gonManager != null);
            //Find the root of the node
            GameObject safetyNode = targetNode;
            GameObject rootNode = null;
            GameObject tempNode = targetNode;

            while (tempNode != null)
            {
                rootNode = tempNode;
                tempNode = (GameObject)tempNode.pParent;

            }

            GameObjectNode gon = (GameObjectNode)gonManager.activeList;
            Debug.Assert(gon != null);

            // Iterate through all the active list nodes to find the root
            while (gon != null)
            {
                if (gon.getGameObject() == rootNode)
                {
                    //Found the root in the active List
                    break;
                }
                gon = (GameObjectNode)gon.pNext;
            }

            gon.removeNode(targetNode);
            gon.print();
        }
        public static GameObject find(GameObject.GameObjectName mGameObjectName)
        {
            GameObjectNodeManager gamMInstance = GameObjectNodeManager.getSingletonInstance();
            Debug.Assert(gamMInstance != null);

            GameObjectNode pseudoGameObjNode = cGameObjNodeRef;
            Debug.Assert(pseudoGameObjNode != null);

            pseudoGameObjNode.getGameObject().setName(mGameObjectName);

            Debug.Assert(pseudoGameObjNode != null);

            GameObjectNode targetGameObjNode = (GameObjectNode)gamMInstance.genericFind(pseudoGameObjNode);
            Debug.Assert(targetGameObjNode != null);

            return targetGameObjNode.getGameObject();
        }

        public static GameObjectNode findGameObjectNode(GameObject.GameObjectName mGameObjectName)
        {
            GameObjectNodeManager gamMInstance = GameObjectNodeManager.getSingletonInstance();
            Debug.Assert(gamMInstance != null);

            GameObjectNode pseudoGameObjNode = cGameObjNodeRef;
            Debug.Assert(pseudoGameObjNode != null);

            pseudoGameObjNode.getGameObject().setName(mGameObjectName);

            Debug.Assert(pseudoGameObjNode != null);

            GameObjectNode targetGameObjNode = (GameObjectNode)gamMInstance.genericFind(pseudoGameObjNode);
            Debug.Assert(targetGameObjNode != null);

            return targetGameObjNode;
        }
        protected override bool compareConcreteNode(ref MLink targetNode, ref MLink currNode)
        {
            Debug.Assert(targetNode != null);
            Debug.Assert(currNode != null);

            bool result = false;
            GameObjectNode targetObjNode = (GameObjectNode)targetNode;
            GameObjectNode currObjNode = (GameObjectNode)currNode;

            if (targetObjNode.getGameObject().getName().Equals(currObjNode.getGameObject().getName()))
            {
                result = true;
            }

            return result;
        }

        protected override MLink createConcreteNode()
        {
            GameObjectNode gameObjectNode = new GameObjectNode(); // different
            Debug.Assert(gameObjectNode != null);
            return gameObjectNode;
        }

        protected override void printStats(ref MLink targetNode)
        {
            throw new NotImplementedException();
        }
        private static GameObjectNodeManager getSingletonInstance()
        {
            Debug.Assert(gamMInstance != null);
            return gamMInstance;
        }
        public static void cleanup()
        {
            GameObjectNodeManager gamMInstance = GameObjectNodeManager.getSingletonInstance();
            Debug.Assert(gamMInstance != null);

            GameObjectNode gameObjNode = (GameObjectNode)gamMInstance.activeList;
            GameObject rootNode = gameObjNode.getGameObject();

            if (rootNode.cGameObjectName == GameObject.GameObjectName.AlienGrid)
            {
                GameObject column = (GameObject)rootNode.pChild;
                if (column.pChild == null)
                {
                    Debug.WriteLine("no aliens");
                    if (column.pSibling != null)
                    {
                        Debug.WriteLine("column has sibling");
                        column = (GameObject)column.pSibling;
                        column.pSibling.pParent = (PCSNode)rootNode;
                        column.remove();
                    }
                    else
                    {
                        // rootNode.remove(column);
                        column.pForward = null;
                        column.pReverse = null;
                        column.remove();
                        rootNode.pForward = null;
                        rootNode.pReverse = null;
                        rootNode.remove();

                        Debug.WriteLine("Done");
                    }
                }
            }
        }
        // Updates all the nodes in the tree
        public static void update()
        {
            GameObjectNodeManager gamMInstance = GameObjectNodeManager.getSingletonInstance();
            Debug.Assert(gamMInstance != null);

            GameObjectNode root = (GameObjectNode)gamMInstance.activeList;
            Debug.Assert(root != null);

            while (root != null)
            {
                // PCSTreeForwardIterator pcsTreeIter = new PCSTreeForwardIterator(root.getGameObject());
                PCSTreeReverseIterator pcsTreeIter = new PCSTreeReverseIterator(root.getGameObject());
                Debug.Assert(pcsTreeIter != null);

                //iterate all the nodes inside the roots
                GameObject gameObj = (GameObject)pcsTreeIter.First();
                while (!pcsTreeIter.IsDone())
                {
                    gameObj.update();
                    gameObj = (GameObject)pcsTreeIter.Next();
                }
                root = (GameObjectNode)root.pNext;
            }
        }

        public static void moveToGhostManager()
        {
            GameObjectNodeManager gamMInstance = GameObjectNodeManager.getSingletonInstance();
            Debug.Assert(gamMInstance != null);

            GameObjectNode root = (GameObjectNode)gamMInstance.activeList;
            Debug.Assert(root != null);

            while (root != null)
            {            
                PCSTreeReverseIterator pcsTreeIter = new PCSTreeReverseIterator(root.getGameObject());
                Debug.Assert(pcsTreeIter != null);
                if (root.getGameObject().cGameObjectName == GameObject.GameObjectName.AlienGrid)
                {
                    GameObject gameObj = (GameObject)pcsTreeIter.First();
                    while (!pcsTreeIter.IsDone())
                    {
                        gameObj = (GameObject)pcsTreeIter.Next();
                        gameObj.remove();
                    }
                }
                root = (GameObjectNode)root.pNext;
            }
        }
        public static void changeColor()
        {
            GameObjectNodeManager gamMInstance = GameObjectNodeManager.getSingletonInstance();
            Debug.Assert(gamMInstance != null);

            GameObjectNode root = (GameObjectNode)gamMInstance.activeList;
            Debug.Assert(root != null);

            while (root != null)
            {
                PCSTreeReverseIterator pcsTreeIter = new PCSTreeReverseIterator(root.getGameObject());
                Debug.Assert(pcsTreeIter != null);
                GameObject gameObj = (GameObject)pcsTreeIter.First();
                while (!pcsTreeIter.IsDone())
                {
                    if (gameObj.cGameObjectName == GameObject.GameObjectName.AlienGrid ||
                        gameObj.cGameObjectName == GameObject.GameObjectName.Column ||
                        gameObj.cGameObjectName == GameObject.GameObjectName.Crab ||
                        gameObj.cGameObjectName == GameObject.GameObjectName.Octopus ||
                        gameObj.cGameObjectName == GameObject.GameObjectName.Squid ||
                         gameObj.cGameObjectName == GameObject.GameObjectName.AlienExplosion ||
                          gameObj.cGameObjectName == GameObject.GameObjectName.UFORoot ||
                          gameObj.cGameObjectName == GameObject.GameObjectName.AlienUFO ||
                          gameObj.cGameObjectName == GameObject.GameObjectName.ShieldGrid ||
                             gameObj.cGameObjectName == GameObject.GameObjectName.ShieldUnit ||
                     gameObj.cGameObjectName == GameObject.GameObjectName.ShieldColumn ||
                      gameObj.cGameObjectName == GameObject.GameObjectName.ShieldBrick ||
                     gameObj.cGameObjectName == GameObject.GameObjectName.BombRoot ||
                  gameObj.cGameObjectName == GameObject.GameObjectName.Bomb ||
                        gameObj.cGameObjectName == GameObject.GameObjectName.MissileRoot ||
                              gameObj.cGameObjectName == GameObject.GameObjectName.StraightMissile ||
                              gameObj.cGameObjectName == GameObject.GameObjectName.CannonShip ||
                              gameObj.cGameObjectName == GameObject.GameObjectName.ShipRoot
                        )
                    {
                        gameObj.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);
                    }
                    gameObj = (GameObject)pcsTreeIter.Next();
                }
                root = (GameObjectNode)root.pNext;
            }
        }
        public static void printList()
        {
            GameObjectNodeManager gamMInstance = GameObjectNodeManager.getSingletonInstance();
            Debug.Assert(gamMInstance != null);

            Debug.WriteLine("");
            Debug.WriteLine("------ Active List: ---------------------------\n");

            MLink pNode = gamMInstance.activeList;

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

            pNode = gamMInstance.reserveList;
            i = 0;
            while (pNode != null)
            {
                Debug.WriteLine("{0}: -------------", i);
                i++;
                pNode = pNode.pNext;
            }
        }
    }
}
