using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TimerManager : Manager
    {
        private static TimerManager timerMInstance = null;
        private static TimerEvent cTimerEventRef = new TimerEvent();
        protected float currTime = 0.0f;

        private TimerManager(int deltaRefillCount = 3, int prefillCount = 5) :base(deltaRefillCount, prefillCount)
        { }
        public static void createMInstance(int deltaRefillCount = 3, int prefillCount = 5)
        {
            Debug.Assert(deltaRefillCount > 0);
            Debug.Assert(prefillCount > 0);
            if (timerMInstance == null)
            {
                timerMInstance = new TimerManager(deltaRefillCount, prefillCount);
            }
            Debug.Assert(timerMInstance != null);
        }

    
        public static TimerEvent sortedAdd(TimerEvent.TimerEventName mEventName, Command mCommand, float mDeltaTime)
        {
            Debug.Assert(timerMInstance != null);
            Debug.Assert(mCommand != null);
            Debug.Assert(mDeltaTime >= 0.0f);

            TimerEvent timerEvent = (TimerEvent)timerMInstance.pullReserveNode();
            
            timerEvent.setAll(mEventName, mCommand, mDeltaTime);

            Debug.Assert(timerEvent != null);

            timerMInstance.addSorted(timerEvent);

            return timerEvent;
        }
        public static void remove(TimerEvent mTimerEvent)
        {
            Debug.Assert(timerMInstance != null);
            Debug.Assert(mTimerEvent != null);
            timerMInstance.genericRemove(mTimerEvent);

        }
        public static TimerEvent find(TimerEvent.TimerEventName mTimerEventName)
        {
            Debug.Assert(timerMInstance != null);
            TimerEvent pseudoTimer = cTimerEventRef;
            Debug.Assert(pseudoTimer != null);

            pseudoTimer.cTimerEventName = mTimerEventName;

            TimerEvent targetTimer = (TimerEvent)timerMInstance.genericFind(pseudoTimer);
            return targetTimer;
        }
        public static void update(float totalTime)
        {
            TimerManager timerManager = TimerManager.getSingletonInstance();

            timerManager.currTime = totalTime;
            TimerEvent mEvent = (TimerEvent)timerManager.activeList;
            TimerEvent nextEvent = null;
          //  bool eventOcc = false;
            while (mEvent != null && (timerManager.currTime >= mEvent.cTriggerTime))
            {
             //   eventOcc = true;
                nextEvent = (TimerEvent)mEvent.pNext;

                if (timerManager.currTime >= mEvent.cTriggerTime)
                {
                    mEvent.process();
                    mEvent.washTimeEvent();
                    TimerManager.remove(mEvent);
                   
                }
                mEvent = nextEvent;
            }

  
        }

        public static void addDelta(float deltaTime)
        {
            Debug.WriteLine("Adding delta "+deltaTime);
         //   TimerManager.printList();
            TimerManager timerManager = TimerManager.getSingletonInstance();
            TimerEvent mEvent = (TimerEvent)timerManager.activeList;

          //  TimerEvent nextEvent = mEvent;
   
            while (mEvent != null)
            {
                mEvent.cTriggerTime += deltaTime;
                mEvent = (TimerEvent)mEvent.pNext;
            }

            Debug.WriteLine("Adding delta done");
          //  TimerManager.printList();
        }
        public static void removeAll()
        {
         
            TimerManager timerManager = TimerManager.getSingletonInstance();
            TimerEvent mEvent = (TimerEvent)timerManager.activeList;
            //while (mEvent != null)
            //{
            //    mEvent = (TimerEvent)mEvent.pNext;
            //    remove(mEvent);
            //}
            timerManager.activeList = null;
        }
        protected override bool compareConcreteNode(ref MLink targetNode, ref MLink currNode)
        {
            Debug.Assert(targetNode != null);
            Debug.Assert(currNode != null);

            bool result = false;
            TimerEvent targetTimer = (TimerEvent)targetNode;
            TimerEvent currTimer = (TimerEvent)currNode;

            if (targetTimer.cTimerEventName.Equals(currTimer.cTimerEventName))
            {
                result = true;
            }
            return result;
        }
  
        protected override MLink createConcreteNode()
        {
            TimerEvent timerEvent= new TimerEvent(); // different
            Debug.Assert(timerEvent != null);
            return timerEvent;
        }
        private static TimerManager getSingletonInstance()
        {
            Debug.Assert(timerMInstance != null);
            return timerMInstance;
        }
        public static float GetCurrTime()
        {
            Debug.Assert(timerMInstance != null);
            return timerMInstance.currTime;
        }

        public static void print()
        {
            Debug.WriteLine("---------------------Start--------------\n");
            Debug.Assert(timerMInstance != null);
            timerMInstance.genericPrint();
            Debug.WriteLine("------------------------End---------------------------\n");
        }
        public static void printList()
        {
            TimerManager texManInst = TimerManager.getSingletonInstance();
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
        protected override void printStats(ref MLink targetNode)
        {
            Debug.Assert(targetNode != null);
            TimerEvent timerNode = (TimerEvent)targetNode;

            Debug.Assert(timerNode!= null);
            timerNode.printStats();
        }
    }
}
