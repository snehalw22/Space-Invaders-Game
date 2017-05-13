using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class InputSubject 
    {
        public InputObserver observer;

        public InputSubject()
        {
            observer = null;
        }
      
        public void setObserver(InputObserver mobserver)
        {
            this.observer = mobserver;
        }

        public void attachObserver(InputObserver mObserver)
        {

            Debug.Assert(mObserver != null);

            if (observer == null)
            {
                observer = mObserver;
                observer.pPrev = null;
                observer.pNext = null;
            }
            else
            {
                mObserver.pNext = observer;
                observer.pPrev = observer;
                observer = mObserver;
            }

        }

    }
}
