using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Manager
    {
        protected MLink activeList;
        protected MLink reserveList;

        private int mNumActiveNodes;
        private int mNumReserveNodes;
        private int mTotalNodes;
        private int deltaRefillCount;

        protected Manager(int deltaRefillCount = 3, int prefillCount = 5)
        {
            Debug.Assert(deltaRefillCount > 0);
            Debug.Assert(prefillCount > 0);

            this.activeList = null;
            this.reserveList = null;

            this.mNumActiveNodes = 0;
            this.mNumReserveNodes = 0;
            this.mTotalNodes = 0;
            this.deltaRefillCount = deltaRefillCount;

            // prefill the nodes in the reserve list
            fillReserve(prefillCount);

            Debug.Assert(reserveList != null);
        }

        //abstarct methods
        protected abstract MLink createConcreteNode();
        protected abstract bool compareConcreteNode(ref MLink targetNode, ref MLink currNode);

        protected abstract void printStats(ref MLink targetNode);

        // prefill the 
        protected void fillReserve(int fillCount)
        {
            Debug.Assert(fillCount > 0);
            // create the Data Node of the Derieved class and add it to reserve list at front
            for (int i = 0; i < fillCount; i++)
            {
                MLink dataNode = this.createConcreteNode();

                Debug.Assert(dataNode != null);
                MLink.addToFront(dataNode, ref this.reserveList);
                mNumReserveNodes++;
                mTotalNodes++;
            }

        }

        // Removes a node from reserve and add it to active
        protected MLink genericAdd()
        {
            //Check if the reserve list is empty, If yes, refill

            if (reserveList == null)
            {
                fillReserve(deltaRefillCount);
            }
            // remove from front of reserve list
            MLink dNode = MLink.removeFromFront(ref reserveList);
            Debug.Assert(dNode != null);

            // add it to the front of active list
            MLink.addToFront(dNode, ref activeList);

            mNumReserveNodes--;
            mNumActiveNodes++;

            return dNode;

        }

        // remove a node from active and add it to reserve
        protected void genericRemove(MLink dataNode)
        {
            Debug.Assert(dataNode != null);

            // remove from active
            MLink.removeNode(dataNode, ref this.activeList);

            //wash the data node
            dataNode.wash();

            //add it to reserve list
            MLink.addToFront(dataNode, ref this.reserveList);
            mNumActiveNodes--;
            mNumReserveNodes++;
        }

        // find the node in active list
        protected MLink genericFind(MLink targetNode)
        {
            Debug.Assert(targetNode != null);
            MLink currNode = this.activeList;

            while (currNode != null)
            {
                bool result = this.compareConcreteNode(ref targetNode, ref currNode);
                if (result)
                {
                    break;
                }
                else
                {
                    currNode = currNode.pNext;
                }
            }
            return currNode;
        }

        public MLink pullReserveNode()
        {
            if(reserveList==null)
            {
                fillReserve(deltaRefillCount);
            }

            Debug.Assert(reserveList != null);

            MLink dataNode = reserveList;

            Debug.Assert(dataNode != null);
            reserveList = reserveList.pNext;

            dataNode.wash();
            return dataNode;

        }

        public void addSorted(MLink mTargetNode)
        {
            Debug.Assert(mTargetNode != null);
            mTargetNode.wash();

            TimerEvent mTargetEvent = (TimerEvent)mTargetNode;

            Debug.Assert(mTargetEvent != null);

            if(this.activeList==null)
            {
                activeList = mTargetNode;             
            }
            else
            {
                // Add to sorted list

                MLink mCurrNode = this.activeList;
                Debug.Assert(mCurrNode != null);

                while(mCurrNode != null)
                {
                    TimerEvent mCurrEvent = (TimerEvent)mCurrNode;
                    if(mTargetEvent.cTriggerTime <= mCurrEvent.cTriggerTime)
                    {
                        if(mCurrEvent.pPrev!=null)
                        {
                            mCurrEvent.pPrev.pNext = mTargetEvent;
                            mTargetEvent.pPrev = mCurrEvent.pPrev;
                            mTargetEvent.pNext = mCurrEvent;
                            mCurrEvent.pPrev = mTargetEvent;
                        }
                        else
                        {

                            mCurrNode.pPrev = mTargetNode;
                            mCurrNode.pPrev.pNext = mCurrNode;
                            activeList = mTargetNode;
                        }
                        break;                    
                    }
                    if(mCurrNode.pNext==null)
                    {
                        mCurrNode.pNext = mTargetNode;
                        mTargetNode.pPrev = mCurrNode;
                        break;
                    }
                    mCurrNode = mCurrNode.pNext;
                }              
                //genericPrint();
            }
        }
        public void genericPrint()
        {
            Debug.WriteLine("No of total Nodes : " + mTotalNodes);
            Debug.WriteLine("No of total Active Nodes : " + mNumActiveNodes);
            Debug.WriteLine("No of total Reserve Nodes : " + mNumReserveNodes);

            Debug.WriteLine("No of Refill count : " + deltaRefillCount);
            Debug.WriteLine("------ Active List: ---------\n");
            MLink dataNode = this.activeList;
            if(dataNode ==null)
            {
                Debug.WriteLine("Active List is Null");
            }

            while(dataNode!=null)
            {
                //printStats(ref dataNode);
                dataNode = dataNode.pNext;
            }

        }

    }
}
