using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionPair : MLink
    {
        public CollisionPair.CollisionPairName collisionPairName;
        public GameObject treeA;
        public GameObject treeB;
        public CollisionSubject colSubject;
        public enum CollisionPairName
        {
            Alien_Missile,
            Alien_Wall,
            Alien_Shield,
            Alien_Ship,

            Missile_Wall,
            Missile_Shield,
            Misisle_UFO,

            Bomb_Wall,
            Bomb_Shield,
            Bomb_Ship,
            Bomb_Missile,

            Ship_Wall,

            UFO_Wall,

            NullObject,
            UnInitialized
        }
        public CollisionPair(): base()
        {
            this.treeA = null;
            this.treeB = null;
            this.collisionPairName = CollisionPairName.UnInitialized;
            colSubject = new CollisionSubject();
        }
        public void set(CollisionPair.CollisionPairName colPairName,GameObject rootA, GameObject rootB)
        {

            Debug.Assert(rootA != null);
            Debug.Assert(rootB != null);

            this.collisionPairName = colPairName;
            this.treeA = rootA;
            this.treeB = rootB;


        }
        public void processCollision()
        {
         //   Debug.WriteLine("detect collision " + this.treeA.cGameObjectName + " " + this.treeB.getName());
         
            detectCollision(this.treeA,this.treeB);
        }

        public static void detectCollision(GameObject pSafeTreeA, GameObject pSafeTreeB)
        {
           // Debug.WriteLine("Dectecting collision");
            // A vs B
            GameObject pNodeA = pSafeTreeA;
            GameObject pNodeB = pSafeTreeB;

                // Debug.WriteLine("\nColPair: start {0}, {1}", pNodeA.cGameObjectName, pNodeB.cGameObjectName);
            while (pNodeA != null)
            {
                // Restart compare
                pNodeB = pSafeTreeB;

                while (pNodeB != null)
                {
                    // who is being tested?
                //        Debug.WriteLine("ColPair: collide:  {0}, {1}", pNodeA.cGameObjectName, pNodeB.cGameObjectName);

                    // Get rectangles
                    CollisionRectangle rectA = pNodeA.cCollisionObj.cCollisionRectangle;
                    CollisionRectangle rectB = pNodeB.cCollisionObj.cCollisionRectangle;

                    // test them
                    if (CollisionRectangle.Intersect(rectA, rectB))
                    {
                        // Boom - it works (Visitor in Action)
                        pNodeA.Accept(pNodeB);
                        break;
                    }

                    pNodeB = (GameObject)pNodeB.pSibling;
                }
                pNodeA = (GameObject)pNodeA.pSibling;
            }
      }
        //public void wash()
        //{
        //    this.treeA = null;
        //    this.treeB = null;
        //    this.collisionPairName = CollisionPair.CollisionPairName.UnInitialized;
        //}

        public void setName(CollisionPairName colName)
        {
            this.collisionPairName = colName;
        }
        protected override void nodeStatistics()
        {
            Debug.WriteLine("name: {0} Hash({1})", this.collisionPairName, this.GetHashCode());     
        }
        public void attach(CollisionObserver observer)
        {
            //Differently done
            observer.setColSubject(colSubject);
            this.colSubject.attachObserver(observer);
        }
        public void setSubject(GameObject gaA, GameObject gaB)
        {
            this.colSubject.setSubjects(gaA, gaB);
        }
        public void notifyObserver()
        {
            this.colSubject.notify();
        }
    }
}
