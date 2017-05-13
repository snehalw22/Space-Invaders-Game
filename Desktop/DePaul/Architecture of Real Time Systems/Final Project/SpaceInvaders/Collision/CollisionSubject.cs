using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionSubject 
    {
        public GameObject gameObjA;
        public GameObject gameObjB;
        private CollisionObserver observerRoot;
        
        public CollisionSubject()
        {
            gameObjA = null;
            gameObjB = null;
            observerRoot = null;
        }

        public void attachObserver(CollisionObserver mObserver)
        {

            Debug.Assert(mObserver != null);

            if (observerRoot == null)
            {
                observerRoot = mObserver;
                observerRoot.pPrev = null;
                observerRoot.pNext = null;
            }
            else
            {
                mObserver.pNext = observerRoot;
                observerRoot.pPrev = observerRoot;
                observerRoot = mObserver;
            }

        }

        public void setSubjects(GameObject goA, GameObject goB)
        {
            this.gameObjA = goA;
            this.gameObjB = goB;
        }
        public void notify()
        {
            CollisionObserver colObserver = this.observerRoot;
            Debug.Assert(colObserver != null);

            while (colObserver != null)
            {
                colObserver.notify();
                colObserver = (CollisionObserver)colObserver.pNext;
            }
        }

    }
}
